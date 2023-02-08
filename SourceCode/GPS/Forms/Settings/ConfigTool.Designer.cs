using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormConfig
    {
        private decimal sectionWidth1, sectionWidth2, sectionWidth3, sectionWidth4, sectionWidth5, sectionWidth6,
                sectionWidth7, sectionWidth8, sectionWidth9, sectionWidth10, sectionWidth11, sectionWidth12,
                sectionWidth13, sectionWidth14, sectionWidth15, sectionWidth16;

        private decimal sectionPosition1, sectionPosition2, sectionPosition3, sectionPosition4,
                        sectionPosition5, sectionPosition6, sectionPosition7, sectionPosition8, sectionPosition9,
                        sectionPosition10, sectionPosition11, sectionPosition12, sectionPosition13, sectionPosition14,
                        sectionPosition15, sectionPosition16, sectionPosition17;

        private double defaultSectionWidth;

        private int numberOfSections;

        //private double maxWidth = 5000;


        #region Config
        private void tabTConfig_Enter(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.setTool_isToolFront)
            {
                rbtnTBT.Checked = false;
                rbtnTrailing.Checked = false;
                rbtnFixedRear.Checked = false;
                rbtnFront.Checked = true;
            }
            else if (Properties.Settings.Default.setTool_isToolTBT)
            {
                rbtnTBT.Checked = true;
                rbtnTrailing.Checked = false;
                rbtnFixedRear.Checked = false;
                rbtnFront.Checked = false;
            }
            else if (Properties.Settings.Default.setTool_isToolTrailing)
            {
                rbtnTBT.Checked = false;
                rbtnTrailing.Checked = true;
                rbtnFixedRear.Checked = false;
                rbtnFront.Checked = false;
            }
            else if (Properties.Settings.Default.setTool_isToolRearFixed)
            {
                rbtnTBT.Checked = false;
                rbtnTrailing.Checked = false;
                rbtnFixedRear.Checked = true;
                rbtnFront.Checked = false;
            }
        }
        private void tabTConfig_Leave(object sender, EventArgs e)
        {
            if (rbtnFront.Checked)
            {
                Properties.Settings.Default.setTool_isToolFront = true;
                Properties.Settings.Default.setTool_isToolTBT = false;
                Properties.Settings.Default.setTool_isToolTrailing = false;
                Properties.Settings.Default.setTool_isToolRearFixed = false;
            }
            else if (rbtnTBT.Checked)
            {
                Properties.Settings.Default.setTool_isToolFront = false;
                Properties.Settings.Default.setTool_isToolTBT = true;
                Properties.Settings.Default.setTool_isToolTrailing = true;
                Properties.Settings.Default.setTool_isToolRearFixed = false;
            }
            else if (rbtnTrailing.Checked)
            {
                Properties.Settings.Default.setTool_isToolFront = false;
                Properties.Settings.Default.setTool_isToolTBT = false;
                Properties.Settings.Default.setTool_isToolTrailing = true;
                Properties.Settings.Default.setTool_isToolRearFixed = false;
            }
            else if (rbtnFixedRear.Checked)
            {
                Properties.Settings.Default.setTool_isToolFront = false;
                Properties.Settings.Default.setTool_isToolTBT = false;
                Properties.Settings.Default.setTool_isToolTrailing = false;
                Properties.Settings.Default.setTool_isToolRearFixed = true;
            }

            mf.tool.isToolRearFixed = Properties.Settings.Default.setTool_isToolRearFixed;
            mf.tool.isToolTrailing = Properties.Settings.Default.setTool_isToolTrailing;
            mf.tool.isToolTBT = Properties.Settings.Default.setTool_isToolTBT;
            mf.tool.isToolFrontFixed = Properties.Settings.Default.setTool_isToolFront;

            //mf.tool.hitchLength = (double)nudDrawbarLength.Value * mf.inchOrCm2m;
            if (Properties.Settings.Default.setTool_isToolFront && mf.tool.hitchLength < 0)
                mf.tool.hitchLength *= -1;
            else if (!Properties.Settings.Default.setTool_isToolFront && mf.tool.hitchLength > 0)
                mf.tool.hitchLength *= -1;
            Properties.Settings.Default.setVehicle_hitchLength = mf.tool.hitchLength;

            Properties.Settings.Default.Save();
        }

        #endregion

        #region  Hitch

        private void tabTHitch_Enter(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.setTool_isToolFront)
            {
                nudTrailingHitchLength.Visible = false;
                nudDrawbarLength.Visible = true;
                nudTankHitch.Visible = false;

                nudTrailingHitchLength.Left = 0;
                nudDrawbarLength.Left = 342;
                nudTankHitch.Left = 0;

                picboxToolHitch.BackgroundImage = Properties.Resources.ToolHitchPageFront;
            }
            else if (Properties.Settings.Default.setTool_isToolTBT)
            {
                nudTrailingHitchLength.Visible = true;
                nudDrawbarLength.Visible = true;
                nudTankHitch.Visible = true;

                nudTrailingHitchLength.Left = 152;
                nudDrawbarLength.Left = 644;
                nudTankHitch.Left = 433;

                picboxToolHitch.BackgroundImage = Properties.Resources.ToolHitchPageTBT;
            }
            else if (Properties.Settings.Default.setTool_isToolRearFixed)
            {
                nudTrailingHitchLength.Visible = false;
                nudDrawbarLength.Visible = true;
                nudTankHitch.Visible = false;

                nudTrailingHitchLength.Left = 0;
                nudDrawbarLength.Left = 220;
                nudTankHitch.Left = 0;

                picboxToolHitch.BackgroundImage = Properties.Resources.ToolHitchPageRear;
            }
            else if (Properties.Settings.Default.setTool_isToolTrailing)
            {
                nudTrailingHitchLength.Visible = true;
                nudDrawbarLength.Visible = true;
                nudTankHitch.Visible = false;

                nudTrailingHitchLength.Left = 290;
                nudDrawbarLength.Left = 575;
                nudTankHitch.Left = 0;

                picboxToolHitch.BackgroundImage = Properties.Resources.ToolHitchPageTrailing;
            }

            double dis = (Math.Abs(Properties.Settings.Default.setVehicle_hitchLength) * mf.m2InchOrCm);
            nudDrawbarLength.Value = (decimal)(Math.Abs(Properties.Settings.Default.setVehicle_hitchLength)*mf.m2InchOrCm);
            nudTrailingHitchLength.Value = (decimal)(Math.Abs(Properties.Settings.Default.setTool_toolTrailingHitchLength) * mf.m2InchOrCm);
            nudTankHitch.Value = (decimal)(Math.Abs(Properties.Settings.Default.setVehicle_tankTrailingHitchLength) * mf.m2InchOrCm);
        }

        private void tabTHitch_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }


        private void nudDrawbarLength_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                mf.tool.hitchLength = (double)nudDrawbarLength.Value * mf.inchOrCm2m;
                if (!Properties.Settings.Default.setTool_isToolFront)
                {
                    mf.tool.hitchLength *= -1;
                }
                Properties.Settings.Default.setVehicle_hitchLength = mf.tool.hitchLength;
            }
        }

        private void nudTankHitch_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                mf.tool.tankTrailingHitchLength = (double)nudTankHitch.Value * -mf.inchOrCm2m;
                Properties.Settings.Default.setVehicle_tankTrailingHitchLength = mf.tool.tankTrailingHitchLength;

            }
        }

        private void nudTrailingHitchLength_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                mf.tool.trailingHitchLength = (double)nudTrailingHitchLength.Value * -mf.inchOrCm2m;
                Properties.Settings.Default.setTool_toolTrailingHitchLength = mf.tool.trailingHitchLength;

            }
        }


        #endregion

        #region Settings

        private void tabTSettings_Enter(object sender, EventArgs e)
        {
            nudLookAhead.Value =    (decimal)Properties.Settings.Default.setVehicle_toolLookAheadOn;
            nudLookAheadOff.Value = (decimal)Properties.Settings.Default.setVehicle_toolLookAheadOff;
            nudTurnOffDelay.Value = (decimal)Properties.Settings.Default.setVehicle_toolOffDelay;
            nudOffset.Value =       (int)(Properties.Settings.Default.setVehicle_toolOffset*mf.m2InchOrCm);
            nudOverlap.Value =      (int)(Properties.Settings.Default.setVehicle_toolOverlap*mf.m2InchOrCm);
        }

        private void tabTSettings_Leave(object sender, EventArgs e)
        {

            Properties.Settings.Default.setVehicle_toolLookAheadOn = mf.tool.lookAheadOnSetting;
            Properties.Settings.Default.setVehicle_toolLookAheadOff = mf.tool.lookAheadOffSetting;
            Properties.Settings.Default.setVehicle_toolOffDelay = mf.tool.turnOffDelay;

            ////line up manual buttons based on # of sections
            //mf.LineUpManualBtns();

            ////update the sections to newly configured widths and positions in main
            //mf.SectionSetPosition();

            ////update the widths of sections and tool width in main
            //mf.SectionCalcWidths();

            Properties.Settings.Default.Save();
        }
        private void nudLookAhead_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                if (nudLookAheadOff.Value > (nudLookAhead.Value * 0.8m))
                {
                    nudLookAheadOff.Value = nudLookAhead.Value * 0.8m;
                }

                mf.tool.lookAheadOnSetting = (double)nudLookAhead.Value;
                mf.tool.lookAheadOffSetting = (double)nudLookAheadOff.Value;
                mf.tool.turnOffDelay = 0;
            }
        }

        private void nudLookAheadOff_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                if (nudLookAheadOff.Value > (nudLookAhead.Value * 0.8m))
                {
                    nudLookAheadOff.Value = nudLookAhead.Value * 0.8m;
                }
                mf.tool.lookAheadOffSetting = (double)nudLookAheadOff.Value;

                if (nudLookAheadOff.Value > 0)
                {
                    mf.tool.turnOffDelay = 0;
                    nudTurnOffDelay.Value = 0;
                }

                mf.tool.lookAheadOnSetting = (double)nudLookAhead.Value;
                mf.tool.lookAheadOffSetting = (double)nudLookAheadOff.Value;
                mf.tool.turnOffDelay = 0;


            }
        }

        private void nudTurnOffDelay_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                if (nudTurnOffDelay.Value > 0)
                {
                    nudLookAheadOff.Value = 0;
                }
                mf.tool.turnOffDelay = (double)nudTurnOffDelay.Value;
                mf.tool.lookAheadOffSetting = (double)nudLookAheadOff.Value;
                mf.tool.lookAheadOnSetting = (double)nudLookAhead.Value;
            }
        }

        private void nudOverlap_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                Properties.Settings.Default.setVehicle_toolOverlap = mf.tool.overlap 
                    = (double)nudOverlap.Value * mf.inchOrCm2m;
            }
        }

        private void nudOffset_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                Properties.Settings.Default.setVehicle_toolOffset = mf.tool.offset 
                    = (double)nudOffset.Value * mf.inchOrCm2m;
            }
        }

        #endregion

        #region Sections 

        private void tabTSections_Enter(object sender, EventArgs e)
        {
            cboxIsUnique.Checked = !mf.tool.isSectionsNotZones;

             cboxSectionBoundaryControl.Checked = Properties.Settings.Default.setTool_isSectionOffWhenOut;

            nudCutoffSpeed.Value = (decimal)Properties.Settings.Default.setVehicle_slowSpeedCutoff;

            if (cboxIsUnique.Checked)
            {
                cboxIsUnique.BackgroundImage = Properties.Resources.ConT_Symmetric;
                cboxNumberOfZones.Visible = lblZonesBox.Visible = true;
            }
            else
            {
                cboxIsUnique.BackgroundImage = Properties.Resources.ConT_Asymmetric;
                cboxNumberOfZones.Visible = lblZonesBox.Visible = false;
            }

            nudNumberOfSections.Maximum = FormGPS.MAXSECTIONS;
            
            //fix ManualOffOnAuto buttons
            mf.manualBtnState = btnStates.Off;
            mf.btnSectionMasterManual.Image = Properties.Resources.ManualOff;

            //fix auto button
            mf.autoBtnState = btnStates.Off;
            mf.btnSectionMasterAuto.Image = Properties.Resources.SectionMasterOff;

            nudMinCoverage.Value = Properties.Settings.Default.setVehicle_minCoverage;

            if (mf.tool.isSectionsNotZones)
            {
                //Update the button colors and text
                mf.AllSectionsAndButtonsToState(btnStates.Off);

                //enable disable manual buttons
                mf.LineUpIndividualSectionBtns();

                numberOfSections = Properties.Settings.Default.setVehicle_numSections;

                cboxNumSections.Text = numberOfSections.ToString();
                defaultSectionWidth = Properties.Settings.Default.setTool_defaultSectionWidth;
                nudDefaultSectionWidth.Value = (int)(defaultSectionWidth * mf.m2InchOrCm);

                panelSymmetricSections.Visible = false;

                nudNumberOfSections.Visible = false;
                cboxNumSections.Visible = true;

                nudSection1.Value = Math.Abs((Properties.Settings.Default.setSection_position2 - Properties.Settings.Default.setSection_position1) * (decimal)mf.m2InchOrCm);
                nudSection2.Value = Math.Abs((Properties.Settings.Default.setSection_position3 - Properties.Settings.Default.setSection_position2) * (decimal)mf.m2InchOrCm);
                nudSection3.Value = Math.Abs((Properties.Settings.Default.setSection_position4 - Properties.Settings.Default.setSection_position3) * (decimal)mf.m2InchOrCm);
                nudSection4.Value = Math.Abs((Properties.Settings.Default.setSection_position5 - Properties.Settings.Default.setSection_position4) * (decimal)mf.m2InchOrCm);
                nudSection5.Value = Math.Abs((Properties.Settings.Default.setSection_position6 - Properties.Settings.Default.setSection_position5) * (decimal)mf.m2InchOrCm);
                nudSection6.Value = Math.Abs((Properties.Settings.Default.setSection_position7 - Properties.Settings.Default.setSection_position6) * (decimal)mf.m2InchOrCm);
                nudSection7.Value = Math.Abs((Properties.Settings.Default.setSection_position8 - Properties.Settings.Default.setSection_position7) * (decimal)mf.m2InchOrCm);
                nudSection8.Value = Math.Abs((Properties.Settings.Default.setSection_position9 - Properties.Settings.Default.setSection_position8) * (decimal)mf.m2InchOrCm);
                nudSection9.Value = Math.Abs((Properties.Settings.Default.setSection_position10 - Properties.Settings.Default.setSection_position9) * (decimal)mf.m2InchOrCm);
                nudSection10.Value = Math.Abs((Properties.Settings.Default.setSection_position11 - Properties.Settings.Default.setSection_position10) * (decimal)mf.m2InchOrCm);
                nudSection11.Value = Math.Abs((Properties.Settings.Default.setSection_position12 - Properties.Settings.Default.setSection_position11) * (decimal)mf.m2InchOrCm);
                nudSection12.Value = Math.Abs((Properties.Settings.Default.setSection_position13 - Properties.Settings.Default.setSection_position12) * (decimal)mf.m2InchOrCm);
                nudSection13.Value = Math.Abs((Properties.Settings.Default.setSection_position14 - Properties.Settings.Default.setSection_position13) * (decimal)mf.m2InchOrCm);
                nudSection14.Value = Math.Abs((Properties.Settings.Default.setSection_position15 - Properties.Settings.Default.setSection_position14) * (decimal)mf.m2InchOrCm);
                nudSection15.Value = Math.Abs((Properties.Settings.Default.setSection_position16 - Properties.Settings.Default.setSection_position15) * (decimal)mf.m2InchOrCm);
                nudSection16.Value = Math.Abs((Properties.Settings.Default.setSection_position17 - Properties.Settings.Default.setSection_position16) * (decimal)mf.m2InchOrCm);

                //based on number of sections and values update the page before displaying
                UpdateSpinners();
            }
            else
            {
                //turn section buttons all OFF
                mf.AllZonesAndButtonsToState(btnStates.Off);

                cboxNumSections.Visible = false;

                panelSymmetricSections.Visible = true;
                nudNumberOfSections.Visible = true;

                numberOfSections = Properties.Settings.Default.setTool_numSectionsMulti;
                nudNumberOfSections.Value = numberOfSections;

                defaultSectionWidth = Properties.Settings.Default.setTool_sectionWidthMulti;
                nudDefaultSectionWidth.Value = (int)(defaultSectionWidth * mf.m2InchOrCm);

                SetNudZoneMinMax();

                nudZone1To.Value = mf.tool.zoneRanges[1];
                nudZone2To.Value = mf.tool.zoneRanges[2];
                nudZone3To.Value = mf.tool.zoneRanges[3];
                nudZone4To.Value = mf.tool.zoneRanges[4];
                nudZone5To.Value = mf.tool.zoneRanges[5];
                nudZone6To.Value = mf.tool.zoneRanges[6];
                nudZone7To.Value = mf.tool.zoneRanges[7];
                nudZone8To.Value = mf.tool.zoneRanges[8];

                cboxNumberOfZones.SelectedIndexChanged -= cboxNumberOfZones_SelectedIndexChanged;
                cboxNumberOfZones.Text = mf.tool.zones.ToString();
                cboxNumberOfZones.SelectedIndexChanged += cboxNumberOfZones_SelectedIndexChanged;

                words = Properties.Settings.Default.setTool_zones.Split(',');
                lblVehicleToolWidth.Text = Convert.ToString((int)(numberOfSections * defaultSectionWidth * 100 * mf.cm2CmOrIn));

                mf.LineUpAllZoneButtons();
                SetNudZoneVisibility();
            }
        }

        private void tabTSections_Leave(object sender, EventArgs e)
        {
            if (mf.tool.isSectionsNotZones)
            {
                //take the section widths and convert to meters and positions along tool.
                CalculateSectionPositions();

                Properties.Settings.Default.setTool_isSectionOffWhenOut = cboxSectionBoundaryControl.Checked;
                mf.tool.isSectionOffWhenOut = cboxSectionBoundaryControl.Checked;

                //save the values in each spinner for section position widths in settings
                Properties.Settings.Default.setSection_position1 = sectionPosition1;
                Properties.Settings.Default.setSection_position2 = sectionPosition2;
                Properties.Settings.Default.setSection_position3 = sectionPosition3;
                Properties.Settings.Default.setSection_position4 = sectionPosition4;
                Properties.Settings.Default.setSection_position5 = sectionPosition5;
                Properties.Settings.Default.setSection_position6 = sectionPosition6;
                Properties.Settings.Default.setSection_position7 = sectionPosition7;
                Properties.Settings.Default.setSection_position8 = sectionPosition8;
                Properties.Settings.Default.setSection_position9 = sectionPosition9;
                Properties.Settings.Default.setSection_position10 = sectionPosition10;
                Properties.Settings.Default.setSection_position11 = sectionPosition11;
                Properties.Settings.Default.setSection_position12 = sectionPosition12;
                Properties.Settings.Default.setSection_position13 = sectionPosition13;
                Properties.Settings.Default.setSection_position14 = sectionPosition14;
                Properties.Settings.Default.setSection_position15 = sectionPosition15;
                Properties.Settings.Default.setSection_position16 = sectionPosition16;
                Properties.Settings.Default.setSection_position17 = sectionPosition17;

                mf.tool.numOfSections = numberOfSections;

                Properties.Settings.Default.setVehicle_numSections = mf.tool.numOfSections;

                //line up manual buttons based on # of sections
                mf.LineUpIndividualSectionBtns();

                //update the sections to newly configured widths and positions in main
                mf.SectionSetPosition();

                //update the widths of sections and tool width in main
                mf.SectionCalcWidths();

                mf.tram.isOuter = ((int)(mf.tram.tramWidth / mf.tool.width + 0.5)) % 2 == 0 ? true : false;
                Properties.Settings.Default.setTool_isTramOuter = mf.tram.isOuter;

                Properties.Settings.Default.setVehicle_toolWidth = mf.tool.width;

                SendRelaySettingsToMachineModule();
            }
            else
            {
                mf.tool.numOfSections = numberOfSections;
                Properties.Settings.Default.setTool_numSectionsMulti = mf.tool.numOfSections;

                mf.tool.width = numberOfSections * defaultSectionWidth;
                Properties.Settings.Default.setVehicle_toolWidth = mf.tool.width;

                mf.tram.isOuter = ((int)(mf.tram.tramWidth / mf.tool.width + 0.5)) % 2 == 0 ? true : false;
                Properties.Settings.Default.setTool_isTramOuter = mf.tram.isOuter;

                Properties.Settings.Default.Save();

                mf.SectionCalcMulti();

                for (int i = 0; i < 9; i++)
                {
                    mf.tool.zoneRanges[i] = 0;
                }

                mf.tool.zoneRanges[0] = mf.tool.zones;

                if (mf.tool.zones == 2)
                {
                    mf.tool.zoneRanges[1] = (int)nudZone1To.Value;
                    mf.tool.zoneRanges[2] = (int)nudZone2To.Value;
                }
                else if (mf.tool.zones == 3)
                {
                    mf.tool.zoneRanges[1] = (int)nudZone1To.Value;
                    mf.tool.zoneRanges[2] = (int)nudZone2To.Value;
                    mf.tool.zoneRanges[3] = (int)nudZone3To.Value;
                }
                else if (mf.tool.zones == 4)
                {
                    mf.tool.zoneRanges[1] = (int)nudZone1To.Value;
                    mf.tool.zoneRanges[2] = (int)nudZone2To.Value;
                    mf.tool.zoneRanges[3] = (int)nudZone3To.Value;
                    mf.tool.zoneRanges[4] = (int)nudZone4To.Value;
                }
                else if (mf.tool.zones == 5)
                {
                    mf.tool.zoneRanges[1] = (int)nudZone1To.Value;
                    mf.tool.zoneRanges[2] = (int)nudZone2To.Value;
                    mf.tool.zoneRanges[3] = (int)nudZone3To.Value;
                    mf.tool.zoneRanges[4] = (int)nudZone4To.Value;
                    mf.tool.zoneRanges[5] = (int)nudZone5To.Value;
                }
                else if (mf.tool.zones == 6)
                {
                    mf.tool.zoneRanges[1] = (int)nudZone1To.Value;
                    mf.tool.zoneRanges[2] = (int)nudZone2To.Value;
                    mf.tool.zoneRanges[3] = (int)nudZone3To.Value;
                    mf.tool.zoneRanges[4] = (int)nudZone4To.Value;
                    mf.tool.zoneRanges[5] = (int)nudZone5To.Value;
                    mf.tool.zoneRanges[6] = (int)nudZone6To.Value;
                }
                else if (mf.tool.zones == 7)
                {
                    mf.tool.zoneRanges[1] = (int)nudZone1To.Value;
                    mf.tool.zoneRanges[2] = (int)nudZone2To.Value;
                    mf.tool.zoneRanges[3] = (int)nudZone3To.Value;
                    mf.tool.zoneRanges[4] = (int)nudZone4To.Value;
                    mf.tool.zoneRanges[5] = (int)nudZone5To.Value;
                    mf.tool.zoneRanges[6] = (int)nudZone6To.Value;
                    mf.tool.zoneRanges[7] = (int)nudZone7To.Value;
                }
                else if (mf.tool.zones == 8)
                {
                    mf.tool.zoneRanges[1] = (int)nudZone1To.Value;
                    mf.tool.zoneRanges[2] = (int)nudZone2To.Value;
                    mf.tool.zoneRanges[3] = (int)nudZone3To.Value;
                    mf.tool.zoneRanges[4] = (int)nudZone4To.Value;
                    mf.tool.zoneRanges[5] = (int)nudZone5To.Value;
                    mf.tool.zoneRanges[6] = (int)nudZone6To.Value;
                    mf.tool.zoneRanges[7] = (int)nudZone7To.Value;
                    mf.tool.zoneRanges[8] = (int)nudZone8To.Value;
                }

                String str = "";
                str = String.Join(",",mf.tool.zoneRanges);
                Properties.Settings.Default.setTool_zones = str;

                mf.LineUpAllZoneButtons();
            }

            //no multi color zones
            if (mf.tool.isSectionsNotZones)
                Properties.Settings.Default.setColor_isMultiColorSections = mf.tool.isMultiColoredSections = false;

            Properties.Settings.Default.Save();
        }

        private void nudZone1To_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                mf.tool.zoneRanges[1] = (int)nudZone1To.Value;
                SetNudZoneVisibility(); 
            }
        }

        private void nudZone2To_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                mf.tool.zoneRanges[2] = (int)nudZone2To.Value;
                SetNudZoneVisibility();
            }
        }

        private void nudZone3To_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                mf.tool.zoneRanges[3] = (int)nudZone3To.Value;
                SetNudZoneVisibility();
            }
        }

        private void nudZone4To_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                mf.tool.zoneRanges[4] = (int)nudZone4To.Value;
                SetNudZoneVisibility();
            }
        }

        private void nudZone5To_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                mf.tool.zoneRanges[5] = (int)nudZone5To.Value;
                SetNudZoneVisibility();
            }
        }

        private void nudZone6To_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                mf.tool.zoneRanges[6] = (int)nudZone6To.Value;
                SetNudZoneVisibility();
            }
        }

        private void nudZone7To_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                mf.tool.zoneRanges[7] = (int)nudZone7To.Value;
                SetNudZoneVisibility();
            }
        }

        private void nudZone8To_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                mf.tool.zoneRanges[8] = (int)nudZone8To.Value;
                SetNudZoneVisibility();
            }
        }
        private void cboxNumberOfZones_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.tool.zones = cboxNumberOfZones.SelectedIndex + 1;
            if (mf.tool.zones == 1) mf.tool.zones = 0;

            SetNudZoneMinMax();
            FillZoneNudsWithDefaultValues();
            SetNudZoneVisibility();
        }

        private void FillZoneNudsWithDefaultValues()
        {
            nudZone1To.Value = 0;
            nudZone2To.Value = 0;
            nudZone3To.Value = 0;
            nudZone4To.Value = 0;
            nudZone5To.Value = 0;
            nudZone6To.Value = 0;
            nudZone7To.Value = 0;
            nudZone8To.Value = 0;

            if (mf.tool.zones != 0)
            {
                int defa = numberOfSections / mf.tool.zones;
                if (mf.tool.zones == 2)
                {
                    nudZone1To.Value += defa;
                    nudZone2To.Value = numberOfSections;
                }
                else if (mf.tool.zones == 3)
                {
                    nudZone1To.Value += defa;
                    nudZone2To.Value += 2 * defa;
                    nudZone3To.Value = numberOfSections;
                }
                else if (mf.tool.zones == 4)
                {
                    nudZone1To.Value += defa;
                    nudZone2To.Value += 2 * defa;
                    nudZone3To.Value += 3 * defa;
                    nudZone4To.Value = numberOfSections;
                }
                else if (mf.tool.zones == 5)
                {
                    nudZone1To.Value += defa;
                    nudZone2To.Value += 2 * defa;
                    nudZone3To.Value += 3 * defa;
                    nudZone4To.Value += 4 * defa;
                    nudZone5To.Value = numberOfSections;
                }
                else if (mf.tool.zones == 6)
                {
                    nudZone1To.Value += defa;
                    nudZone2To.Value += 2 * defa;
                    nudZone3To.Value += 3 * defa;
                    nudZone4To.Value += 4 * defa;
                    nudZone5To.Value += 5 * defa;
                    nudZone6To.Value = numberOfSections;
                }
                else if (mf.tool.zones == 7)
                {
                    nudZone1To.Value += defa;
                    nudZone2To.Value += 2 * defa;
                    nudZone3To.Value += 3 * defa;
                    nudZone4To.Value += 4 * defa;
                    nudZone5To.Value += 5 * defa;
                    nudZone6To.Value += 6 * defa;
                    nudZone7To.Value = numberOfSections;
                }
                else if (mf.tool.zones == 8)
                {
                    nudZone1To.Value += defa;
                    nudZone2To.Value += 2 * defa;
                    nudZone3To.Value += 3 * defa;
                    nudZone4To.Value += 4 * defa;
                    nudZone5To.Value += 5 * defa;
                    nudZone6To.Value += 6 * defa;
                    nudZone7To.Value += 7 * defa;
                    nudZone8To.Value = numberOfSections;
                }
            }
        }

        private void SetNudZoneMinMax()
        {
            nudZone1To.Maximum = numberOfSections;
            nudZone2To.Maximum = numberOfSections;
            nudZone3To.Maximum = numberOfSections;
            nudZone4To.Maximum = numberOfSections;
            nudZone5To.Maximum = numberOfSections;
            nudZone6To.Maximum = numberOfSections;
            nudZone7To.Maximum = numberOfSections;
            nudZone8To.Maximum = numberOfSections;
        }

        private void SetNudZoneVisibility()
        {
            nudZone1To.Visible = false;
            nudZone2To.Visible = false;
            nudZone3To.Visible = false;
            nudZone4To.Visible = false;
            nudZone5To.Visible = false;
            nudZone6To.Visible = false;
            nudZone7To.Visible = false;
            nudZone8To.Visible = false;

            lblZoneStart1.Visible = false;
            lblZoneStart2.Visible = false;
            lblZoneStart3.Visible = false;
            lblZoneStart4.Visible = false;
            lblZoneStart5.Visible = false;
            lblZoneStart6.Visible = false;
            lblZoneStart7.Visible = false;
            lblZoneStart8.Visible = false;

            if (mf.tool.zones == 0) return;

            if (mf.tool.zones > 1)
            {
                nudZone2To.Visible = true;
                nudZone1To.Visible = true;
                lblZoneStart1.Visible = true;
                lblZoneStart2.Visible = true;
                lblZoneStart2.Text = (nudZone1To.Value + 1).ToString();
            }

            if (mf.tool.zones > 2)
            {
                nudZone3To.Visible = true;
                lblZoneStart3.Visible = true;
                lblZoneStart3.Text = (nudZone2To.Value + 1).ToString();
            }

            if (mf.tool.zones > 3)
            {
                nudZone4To.Visible = true;
                lblZoneStart4.Visible = true;
                lblZoneStart4.Text = (nudZone3To.Value + 1).ToString();
            }

            if (mf.tool.zones > 4)
            {
                nudZone5To.Visible = true;
                lblZoneStart5.Visible = true;
                lblZoneStart5.Text = (nudZone4To.Value + 1).ToString();
            }

            if (mf.tool.zones > 5)
            {
                nudZone6To.Visible = true;
                lblZoneStart6.Visible = true;
                lblZoneStart6.Text = (nudZone5To.Value + 1).ToString();
            }

            if (mf.tool.zones > 6)
            {
                nudZone7To.Visible = true;
                lblZoneStart7.Visible = true;
                lblZoneStart7.Text = (nudZone6To.Value + 1).ToString();
            }

            if (mf.tool.zones > 7)
            {
                nudZone8To.Visible = true;
                lblZoneStart8.Visible = true;
                lblZoneStart8.Text = (nudZone7To.Value + 1).ToString();
            }

        }

        private void cboxIsUnique_Click(object sender, EventArgs e)
        {
            mf.tool.isSectionsNotZones = !cboxIsUnique.Checked;
            Properties.Settings.Default.setTool_isSectionsNotZones = !cboxIsUnique.Checked;
            tabTSections_Enter(this, e);
        }

        private void nudNumberOfSections_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                numberOfSections = (int)nudNumberOfSections.Value;
                SetNudZoneMinMax();

                Properties.Settings.Default.setTool_numSectionsMulti = numberOfSections;
                Properties.Settings.Default.Save();

                lblVehicleToolWidth.Text = Convert.ToString((int)(numberOfSections * defaultSectionWidth * 100 * mf.cm2CmOrIn));
                SectionFeetInchesTotalWidthLabelUpdate();
                FillZoneNudsWithDefaultValues();
                SetNudZoneVisibility(); 
            }
        }

        private void nudDefaultSectionWidth_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                defaultSectionWidth = (double)nudDefaultSectionWidth.Value * mf.inchOrCm2m;

                if (mf.tool.isSectionsNotZones)
                    Properties.Settings.Default.setTool_defaultSectionWidth = defaultSectionWidth;
                else
                    Properties.Settings.Default.setTool_sectionWidthMulti = defaultSectionWidth;

                Properties.Settings.Default.Save();

                lblVehicleToolWidth.Text = Convert.ToString((int)(numberOfSections * defaultSectionWidth * 100 * mf.cm2CmOrIn));
                SectionFeetInchesTotalWidthLabelUpdate();
            }
        }

        private void cboxNumSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mf.tool.isSectionsNotZones)
            {
                numberOfSections = cboxNumSections.SelectedIndex + 1;

                decimal wide = nudDefaultSectionWidth.Value;

                if (mf.isMetric)
                {
                    if (numberOfSections * wide > 4800)
                    {
                        wide = 99;
                        mf.TimedMessageBox(3000, "Too Wide", "Max 50 Meters");
                    }
                }
                else
                {
                    if (numberOfSections * wide > 1900)
                    {
                        wide = 19;
                        mf.TimedMessageBox(3000, "Too Wide", "Max 164 Feet");
                    }
                }

                nudSection1.Value = wide;
                nudSection2.Value = wide;
                nudSection3.Value = wide;
                nudSection4.Value = wide;
                nudSection5.Value = wide;
                nudSection6.Value = wide;
                nudSection7.Value = wide;
                nudSection8.Value = wide;
                nudSection9.Value = wide;
                nudSection10.Value = wide;
                nudSection11.Value = wide;
                nudSection12.Value = wide;
                nudSection13.Value = wide;
                nudSection14.Value = wide;
                nudSection15.Value = wide;
                nudSection16.Value = wide;

                UpdateSpinners();

                //take the section widths and convert to meters and positions along tool.
                CalculateSectionPositions();
                //line up manual buttons based on # of sections
                mf.LineUpIndividualSectionBtns();

                //update the sections to newly configured widths and positions in main
                mf.SectionSetPosition();

                //update the widths of sections and tool width in main
                mf.SectionCalcWidths();
            }
        }

        private void NudSection1_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
            UpdateSpinners();
        }

        private void nudCutoffSpeed_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                mf.vehicle.slowSpeedCutoff = (double)nudCutoffSpeed.Value;
                Properties.Settings.Default.setVehicle_slowSpeedCutoff = (double)nudCutoffSpeed.Value;
            }
        }

        private void nudMinCoverage_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                mf.tool.minCoverage = (int)nudMinCoverage.Value;
                Properties.Settings.Default.setVehicle_minCoverage = mf.tool.minCoverage;
            }
        }

        public void UpdateSpinners()
        {
            int i = (int)numberOfSections;
            switch (i)
            {
                case 1:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = false; nudSection2.Visible = false;
                        nudSection3.Enabled = false; nudSection3.Visible = false;
                        nudSection4.Enabled = false; nudSection4.Visible = false;
                        nudSection5.Enabled = false; nudSection5.Visible = false;
                        nudSection6.Enabled = false; nudSection6.Visible = false;
                        nudSection7.Enabled = false; nudSection7.Visible = false;
                        nudSection8.Enabled = false; nudSection8.Visible = false;
                        nudSection9.Enabled = false; nudSection9.Visible = false;
                        nudSection10.Enabled = false; nudSection10.Visible = false;
                        nudSection11.Enabled = false; nudSection11.Visible = false;
                        nudSection12.Enabled = false; nudSection12.Visible = false;
                        nudSection13.Enabled = false; nudSection13.Visible = false;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)nudSection1.Value);
                        break;
                    }
                case 2:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = false; nudSection3.Visible = false;
                        nudSection4.Enabled = false; nudSection4.Visible = false;
                        nudSection6.Enabled = false; nudSection6.Visible = false;
                        nudSection7.Enabled = false; nudSection7.Visible = false;
                        nudSection8.Enabled = false; nudSection8.Visible = false;
                        nudSection5.Enabled = false; nudSection5.Visible = false;
                        nudSection9.Enabled = false; nudSection9.Visible = false;
                        nudSection10.Enabled = false; nudSection10.Visible = false;
                        nudSection11.Enabled = false; nudSection11.Visible = false;
                        nudSection12.Enabled = false; nudSection12.Visible = false;
                        nudSection13.Enabled = false; nudSection13.Visible = false;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value));
                        break;
                    }
                case 3:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = false; nudSection4.Visible = false;
                        nudSection5.Enabled = false; nudSection5.Visible = false;
                        nudSection6.Enabled = false; nudSection6.Visible = false;
                        nudSection7.Enabled = false; nudSection7.Visible = false;
                        nudSection8.Enabled = false; nudSection8.Visible = false;
                        nudSection9.Enabled = false; nudSection9.Visible = false;
                        nudSection10.Enabled = false; nudSection10.Visible = false;
                        nudSection11.Enabled = false; nudSection11.Visible = false;
                        nudSection12.Enabled = false; nudSection12.Visible = false;
                        nudSection13.Enabled = false; nudSection13.Visible = false;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value));
                        break;
                    }
                case 4:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = false; nudSection5.Visible = false;
                        nudSection6.Enabled = false; nudSection6.Visible = false;
                        nudSection7.Enabled = false; nudSection7.Visible = false;
                        nudSection8.Enabled = false; nudSection8.Visible = false;
                        nudSection9.Enabled = false; nudSection9.Visible = false;
                        nudSection10.Enabled = false; nudSection10.Visible = false;
                        nudSection11.Enabled = false; nudSection11.Visible = false;
                        nudSection12.Enabled = false; nudSection12.Visible = false;
                        nudSection13.Enabled = false; nudSection13.Visible = false;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value + nudSection4.Value));
                        break;
                    }
                case 5:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = true; nudSection5.Visible = true;
                        nudSection6.Enabled = false; nudSection6.Visible = false;
                        nudSection7.Enabled = false; nudSection7.Visible = false;
                        nudSection8.Enabled = false; nudSection8.Visible = false;
                        nudSection9.Enabled = false; nudSection9.Visible = false;
                        nudSection10.Enabled = false; nudSection10.Visible = false;
                        nudSection11.Enabled = false; nudSection11.Visible = false;
                        nudSection12.Enabled = false; nudSection12.Visible = false;
                        nudSection13.Enabled = false; nudSection13.Visible = false;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value + nudSection4.Value + nudSection5.Value));
                        break;
                    }
                case 6:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = true; nudSection5.Visible = true;
                        nudSection6.Enabled = true; nudSection6.Visible = true;
                        nudSection7.Enabled = false; nudSection7.Visible = false;
                        nudSection8.Enabled = false; nudSection8.Visible = false;
                        nudSection9.Enabled = false; nudSection9.Visible = false;
                        nudSection10.Enabled = false; nudSection10.Visible = false;
                        nudSection11.Enabled = false; nudSection11.Visible = false;
                        nudSection12.Enabled = false; nudSection12.Visible = false;
                        nudSection13.Enabled = false; nudSection13.Visible = false;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value + nudSection4.Value
                                + nudSection5.Value + nudSection6.Value));
                        break;
                    }
                case 7:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = true; nudSection5.Visible = true;
                        nudSection6.Enabled = true; nudSection6.Visible = true;
                        nudSection7.Enabled = true; nudSection7.Visible = true;
                        nudSection8.Enabled = false; nudSection8.Visible = false;
                        nudSection9.Enabled = false; nudSection9.Visible = false;
                        nudSection10.Enabled = false; nudSection10.Visible = false;
                        nudSection11.Enabled = false; nudSection11.Visible = false;
                        nudSection12.Enabled = false; nudSection12.Visible = false;
                        nudSection13.Enabled = false; nudSection13.Visible = false;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value
                            + nudSection4.Value + nudSection5.Value + nudSection6.Value + nudSection7.Value));
                        break;
                    }
                case 8:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = true; nudSection5.Visible = true;
                        nudSection6.Enabled = true; nudSection6.Visible = true;
                        nudSection7.Enabled = true; nudSection7.Visible = true;
                        nudSection8.Enabled = true; nudSection8.Visible = true;
                        nudSection9.Enabled = false; nudSection9.Visible = false;
                        nudSection10.Enabled = false; nudSection10.Visible = false;
                        nudSection11.Enabled = false; nudSection11.Visible = false;
                        nudSection12.Enabled = false; nudSection12.Visible = false;
                        nudSection13.Enabled = false; nudSection13.Visible = false;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value
                            + nudSection4.Value + nudSection5.Value + nudSection6.Value + nudSection7.Value + nudSection8.Value));
                        break;
                    }

                case 9:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = true; nudSection5.Visible = true;
                        nudSection6.Enabled = true; nudSection6.Visible = true;
                        nudSection7.Enabled = true; nudSection7.Visible = true;
                        nudSection8.Enabled = true; nudSection8.Visible = true;
                        nudSection9.Enabled = true; nudSection9.Visible = true;
                        nudSection10.Enabled = false; nudSection10.Visible = false;
                        nudSection11.Enabled = false; nudSection11.Visible = false;
                        nudSection12.Enabled = false; nudSection12.Visible = false;
                        nudSection13.Enabled = false; nudSection13.Visible = false;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value
                            + nudSection4.Value + nudSection5.Value + nudSection6.Value + nudSection7.Value + nudSection8.Value
                            + nudSection9.Value));
                        break;
                    }

                case 10:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = true; nudSection5.Visible = true;
                        nudSection6.Enabled = true; nudSection6.Visible = true;
                        nudSection7.Enabled = true; nudSection7.Visible = true;
                        nudSection8.Enabled = true; nudSection8.Visible = true;
                        nudSection9.Enabled = true; nudSection9.Visible = true;
                        nudSection10.Enabled = true; nudSection10.Visible = true;
                        nudSection11.Enabled = false; nudSection11.Visible = false;
                        nudSection12.Enabled = false; nudSection12.Visible = false;
                        nudSection13.Enabled = false; nudSection13.Visible = false;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value
                            + nudSection4.Value + nudSection5.Value + nudSection6.Value + nudSection7.Value + nudSection8.Value
                            + nudSection9.Value + nudSection10.Value));
                        break;
                    }

                case 11:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = true; nudSection5.Visible = true;
                        nudSection6.Enabled = true; nudSection6.Visible = true;
                        nudSection7.Enabled = true; nudSection7.Visible = true;
                        nudSection8.Enabled = true; nudSection8.Visible = true;
                        nudSection9.Enabled = true; nudSection9.Visible = true;
                        nudSection10.Enabled = true; nudSection10.Visible = true;
                        nudSection11.Enabled = true; nudSection11.Visible = true;
                        nudSection12.Enabled = false; nudSection12.Visible = false;
                        nudSection13.Enabled = false; nudSection13.Visible = false;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value
                            + nudSection4.Value + nudSection5.Value + nudSection6.Value + nudSection7.Value + nudSection8.Value
                             + nudSection9.Value + nudSection10.Value + nudSection11.Value));
                        break;
                    }

                case 12:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = true; nudSection5.Visible = true;
                        nudSection6.Enabled = true; nudSection6.Visible = true;
                        nudSection7.Enabled = true; nudSection7.Visible = true;
                        nudSection8.Enabled = true; nudSection8.Visible = true;
                        nudSection9.Enabled = true; nudSection9.Visible = true;
                        nudSection10.Enabled = true; nudSection10.Visible = true;
                        nudSection11.Enabled = true; nudSection11.Visible = true;
                        nudSection12.Enabled = true; nudSection12.Visible = true;
                        nudSection13.Enabled = false; nudSection13.Visible = false;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value
                            + nudSection4.Value + nudSection5.Value + nudSection6.Value + nudSection7.Value + nudSection8.Value
                            + nudSection9.Value + nudSection10.Value + nudSection11.Value + nudSection12.Value));
                        break;
                    }

                case 13:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = true; nudSection5.Visible = true;
                        nudSection6.Enabled = true; nudSection6.Visible = true;
                        nudSection7.Enabled = true; nudSection7.Visible = true;
                        nudSection8.Enabled = true; nudSection8.Visible = true;
                        nudSection9.Enabled = true; nudSection9.Visible = true;
                        nudSection10.Enabled = true; nudSection10.Visible = true;
                        nudSection11.Enabled = true; nudSection11.Visible = true;
                        nudSection12.Enabled = true; nudSection12.Visible = true;
                        nudSection13.Enabled = true; nudSection13.Visible = true;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value
                            + nudSection4.Value + nudSection5.Value + nudSection6.Value + nudSection7.Value + nudSection8.Value
                            + nudSection9.Value + nudSection10.Value + nudSection11.Value + nudSection12.Value
                            + nudSection13.Value));
                        break;
                    }

                case 14:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = true; nudSection5.Visible = true;
                        nudSection6.Enabled = true; nudSection6.Visible = true;
                        nudSection7.Enabled = true; nudSection7.Visible = true;
                        nudSection8.Enabled = true; nudSection8.Visible = true;
                        nudSection9.Enabled = true; nudSection9.Visible = true;
                        nudSection10.Enabled = true; nudSection10.Visible = true;
                        nudSection11.Enabled = true; nudSection11.Visible = true;
                        nudSection12.Enabled = true; nudSection12.Visible = true;
                        nudSection13.Enabled = true; nudSection13.Visible = true;
                        nudSection14.Enabled = true; nudSection14.Visible = true;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value
                            + nudSection4.Value + nudSection5.Value + nudSection6.Value + nudSection7.Value + nudSection8.Value
                            + nudSection9.Value + nudSection10.Value + nudSection11.Value + nudSection12.Value
                            + nudSection13.Value + nudSection14.Value));
                        break;
                    }

                case 15:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = true; nudSection5.Visible = true;
                        nudSection6.Enabled = true; nudSection6.Visible = true;
                        nudSection7.Enabled = true; nudSection7.Visible = true;
                        nudSection8.Enabled = true; nudSection8.Visible = true;
                        nudSection9.Enabled = true; nudSection9.Visible = true;
                        nudSection10.Enabled = true; nudSection10.Visible = true;
                        nudSection11.Enabled = true; nudSection11.Visible = true;
                        nudSection12.Enabled = true; nudSection12.Visible = true;
                        nudSection13.Enabled = true; nudSection13.Visible = true;
                        nudSection14.Enabled = true; nudSection14.Visible = true;
                        nudSection15.Enabled = true; nudSection15.Visible = true;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value
                            + nudSection4.Value + nudSection5.Value + nudSection6.Value + nudSection7.Value + nudSection8.Value
                            + nudSection9.Value + nudSection10.Value + nudSection11.Value + nudSection12.Value
                            + nudSection13.Value + nudSection14.Value + nudSection15.Value));
                        break;
                    }

                case 16:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = true; nudSection5.Visible = true;
                        nudSection6.Enabled = true; nudSection6.Visible = true;
                        nudSection7.Enabled = true; nudSection7.Visible = true;
                        nudSection8.Enabled = true; nudSection8.Visible = true;
                        nudSection9.Enabled = true; nudSection9.Visible = true;
                        nudSection10.Enabled = true; nudSection10.Visible = true;
                        nudSection11.Enabled = true; nudSection11.Visible = true;
                        nudSection12.Enabled = true; nudSection12.Visible = true;
                        nudSection13.Enabled = true; nudSection13.Visible = true;
                        nudSection14.Enabled = true; nudSection14.Visible = true;
                        nudSection15.Enabled = true; nudSection15.Visible = true;
                        nudSection16.Enabled = true; nudSection16.Visible = true;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value
                            + nudSection4.Value + nudSection5.Value + nudSection6.Value + nudSection7.Value + nudSection8.Value
                            + nudSection9.Value + nudSection10.Value + nudSection11.Value + nudSection12.Value
                            + nudSection13.Value + nudSection14.Value + nudSection15.Value + nudSection16.Value));
                        break;
                    }

            }
            //update in settings dialog ONLY total tool width
            SectionFeetInchesTotalWidthLabelUpdate();
        }

        //update tool width label at bottom of window
        private void SectionFeetInchesTotalWidthLabelUpdate()
        {
            if (mf.isMetric)
            {
                lblSecTotalWidthMeters.Text = Convert.ToDouble(lblVehicleToolWidth.Text) + " cm";
            }
            else
            {
                double toFeet = (Convert.ToDouble(lblVehicleToolWidth.Text) * 0.08334);
                lblSecTotalWidthFeet.Text = Convert.ToString((int)toFeet) + "'";
                double temp = Math.Round((toFeet - Math.Truncate(toFeet)) * 12, 0);
                lblSecTotalWidthInches.Text = Convert.ToString(temp) + '"';
            }
        }

        //Convert section width to positions along toolbar
        private void CalculateSectionPositions()
        {
            int i = numberOfSections;

            //convert to meters spinner value
            sectionWidth1  = nudSection1.Value * (decimal)mf.inchOrCm2m;
            sectionWidth2  = nudSection2.Value * (decimal)mf.inchOrCm2m;
            sectionWidth3  = nudSection3.Value * (decimal)mf.inchOrCm2m;
            sectionWidth4  = nudSection4.Value * (decimal)mf.inchOrCm2m;
            sectionWidth5  = nudSection5.Value * (decimal)mf.inchOrCm2m;
            sectionWidth6  = nudSection6.Value * (decimal)mf.inchOrCm2m;
            sectionWidth7  = nudSection7.Value * (decimal)mf.inchOrCm2m;
            sectionWidth8  = nudSection8.Value * (decimal)mf.inchOrCm2m;
            sectionWidth9  = nudSection9.Value * (decimal)mf.inchOrCm2m;
            sectionWidth10 = nudSection10.Value * (decimal)mf.inchOrCm2m;
            sectionWidth11 = nudSection11.Value * (decimal)mf.inchOrCm2m;
            sectionWidth12 = nudSection12.Value * (decimal)mf.inchOrCm2m;
            sectionWidth13 = nudSection13.Value * (decimal)mf.inchOrCm2m;
            sectionWidth14 = nudSection14.Value * (decimal)mf.inchOrCm2m;
            sectionWidth15 = nudSection15.Value * (decimal)mf.inchOrCm2m;
            sectionWidth16 = nudSection16.Value * (decimal)mf.inchOrCm2m;

            switch (i)
            {
                case 1:
                    {
                        sectionPosition2 = sectionWidth1 / 2.0M;
                        sectionPosition1 = sectionPosition2 * -1;
                        sectionPosition3 = 0;
                        sectionPosition4 = 0;
                        sectionPosition5 = 0;
                        sectionPosition6 = 0;
                        sectionPosition7 = 0;
                        sectionPosition8 = 0;
                        sectionPosition9 = 0;
                        sectionPosition10 = 0;
                        sectionPosition11 = 0;
                        sectionPosition12 = 0;
                        sectionPosition13 = 0;
                        sectionPosition14 = 0;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;

                        break;
                    }
                case 2:
                    {
                        sectionPosition1 = sectionWidth1 * -1;
                        sectionPosition2 = 0;
                        sectionPosition3 = sectionWidth2;
                        sectionPosition4 = 0;
                        sectionPosition5 = 0;
                        sectionPosition6 = 0;
                        sectionPosition7 = 0;
                        sectionPosition8 = 0;
                        sectionPosition9 = 0;
                        sectionPosition10 = 0;
                        sectionPosition11 = 0;
                        sectionPosition12 = 0;
                        sectionPosition13 = 0;
                        sectionPosition14 = 0;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;

                        break;
                    }
                case 3:
                    {
                        sectionPosition3 = sectionWidth2 / 2.0M;
                        sectionPosition2 = sectionPosition3 * -1;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition4 = sectionPosition3 + sectionWidth3;
                        sectionPosition5 = 0;
                        sectionPosition6 = 0;
                        sectionPosition7 = 0;
                        sectionPosition8 = 0;
                        sectionPosition9 = 0;
                        sectionPosition10 = 0;
                        sectionPosition11 = 0;
                        sectionPosition12 = 0;
                        sectionPosition13 = 0;
                        sectionPosition14 = 0;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;

                        break;
                    }
                case 4:
                    {
                        sectionPosition2 = sectionWidth2 * -1;
                        sectionPosition3 = 0;
                        sectionPosition4 = sectionWidth3;
                        sectionPosition5 = sectionWidth3 + sectionWidth4;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition6 = 0;
                        sectionPosition7 = 0;
                        sectionPosition8 = 0;
                        sectionPosition9 = 0;
                        sectionPosition10 = 0;
                        sectionPosition11 = 0;
                        sectionPosition12 = 0;
                        sectionPosition13 = 0;
                        sectionPosition14 = 0;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;

                        break;
                    }
                case 5:
                    {
                        sectionPosition4 = sectionWidth3 / 2.0M;
                        sectionPosition3 = sectionPosition4 * -1;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition5 = sectionPosition4 + sectionWidth4;
                        sectionPosition6 = sectionPosition5 + sectionWidth5;
                        sectionPosition7 = 0;
                        sectionPosition8 = 0;
                        sectionPosition9 = 0;
                        sectionPosition10 = 0;
                        sectionPosition11 = 0;
                        sectionPosition12 = 0;
                        sectionPosition13 = 0;
                        sectionPosition14 = 0;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;

                        break;
                    }
                case 6:
                    {
                        sectionPosition4 = 0;
                        sectionPosition3 = sectionWidth3 * -1;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition5 = sectionWidth4;
                        sectionPosition6 = sectionPosition5 + sectionWidth5;
                        sectionPosition7 = sectionPosition6 + sectionWidth6;
                        sectionPosition8 = 0;
                        sectionPosition9 = 0;
                        sectionPosition10 = 0;
                        sectionPosition11 = 0;
                        sectionPosition12 = 0;
                        sectionPosition13 = 0;
                        sectionPosition14 = 0;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;

                        break;
                    }
                case 7:
                    {
                        sectionPosition5 = sectionWidth4 / 2.0M;
                        sectionPosition4 = sectionPosition5 * -1;
                        sectionPosition3 = sectionPosition4 - sectionWidth3;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition6 = sectionPosition5 + sectionWidth5;
                        sectionPosition7 = sectionPosition6 + sectionWidth6;
                        sectionPosition8 = sectionPosition7 + sectionWidth7;
                        sectionPosition9 = 0;
                        sectionPosition10 = 0;
                        sectionPosition11 = 0;
                        sectionPosition12 = 0;
                        sectionPosition13 = 0;
                        sectionPosition14 = 0;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;

                        break;
                    }
                case 8:
                    {
                        sectionPosition5 = 0;
                        sectionPosition4 = sectionWidth4 * -1;
                        sectionPosition3 = sectionPosition4 - sectionWidth3;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition6 = sectionWidth5;
                        sectionPosition7 = sectionPosition6 + sectionWidth6;
                        sectionPosition8 = sectionPosition7 + sectionWidth7;
                        sectionPosition9 = sectionPosition8 + sectionWidth8;
                        sectionPosition10 = 0;
                        sectionPosition11 = 0;
                        sectionPosition12 = 0;
                        sectionPosition13 = 0;
                        sectionPosition14 = 0;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;

                        break;
                    }
                case 9:
                    {
                        sectionPosition6 = sectionWidth5 / 2.0M;
                        sectionPosition5 = sectionPosition6 * -1;
                        sectionPosition4 = sectionPosition5 - sectionWidth4;
                        sectionPosition3 = sectionPosition4 - sectionWidth3;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition7 = sectionPosition6 + sectionWidth6;
                        sectionPosition8 = sectionPosition7 + sectionWidth7;
                        sectionPosition9 = sectionPosition8 + sectionWidth8;
                        sectionPosition10 = sectionPosition9 + sectionWidth9;
                        sectionPosition11 = 0;
                        sectionPosition12 = 0;
                        sectionPosition13 = 0;
                        sectionPosition14 = 0;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;

                        break;
                    }
                case 10:
                    {
                        sectionPosition6 = 0;
                        sectionPosition5 = sectionWidth5 * -1;
                        sectionPosition4 = sectionPosition5 - sectionWidth4;
                        sectionPosition3 = sectionPosition4 - sectionWidth3;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition7 = sectionWidth6;
                        sectionPosition8 = sectionPosition7 + sectionWidth7;
                        sectionPosition9 = sectionPosition8 + sectionWidth8;
                        sectionPosition10 = sectionPosition9 + sectionWidth9;
                        sectionPosition11 = sectionPosition10 + sectionWidth10;
                        sectionPosition12 = 0;
                        sectionPosition13 = 0;
                        sectionPosition14 = 0;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;

                        break;
                    }
                case 11:
                    {
                        sectionPosition7 = sectionWidth6 / 2.0M;
                        sectionPosition6 = sectionPosition7 * -1;
                        sectionPosition5 = sectionPosition6 - sectionWidth5;
                        sectionPosition4 = sectionPosition5 - sectionWidth4;
                        sectionPosition3 = sectionPosition4 - sectionWidth3;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition8 = sectionPosition7 + sectionWidth7;
                        sectionPosition9 = sectionPosition8 + sectionWidth8;
                        sectionPosition10 = sectionPosition9 + sectionWidth9;
                        sectionPosition11 = sectionPosition10 + sectionWidth10;
                        sectionPosition12 = sectionPosition11 + sectionWidth11;
                        sectionPosition13 = 0;
                        sectionPosition14 = 0;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;

                        break;
                    }
                case 12:
                    {
                        sectionPosition7 = 0;
                        sectionPosition6 = sectionWidth6 * -1;
                        sectionPosition5 = sectionPosition6 - sectionWidth5;
                        sectionPosition4 = sectionPosition5 - sectionWidth4;
                        sectionPosition3 = sectionPosition4 - sectionWidth3;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition8 = sectionWidth7;
                        sectionPosition9 = sectionPosition8 + sectionWidth8;
                        sectionPosition10 = sectionPosition9 + sectionWidth9;
                        sectionPosition11 = sectionPosition10 + sectionWidth10;
                        sectionPosition12 = sectionPosition11 + sectionWidth11;
                        sectionPosition13 = sectionPosition12 + sectionWidth12;
                        sectionPosition14 = 0;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;
                        break;
                    }
                case 13:
                    {
                        sectionPosition8 = sectionWidth7 / 2.0M; ;
                        sectionPosition7 = sectionPosition8 * -1;
                        sectionPosition6 = sectionPosition7 - sectionWidth6;
                        sectionPosition5 = sectionPosition6 - sectionWidth5;
                        sectionPosition4 = sectionPosition5 - sectionWidth4;
                        sectionPosition3 = sectionPosition4 - sectionWidth3;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition9 = sectionPosition8 + sectionWidth8;
                        sectionPosition10 = sectionPosition9 + sectionWidth9;
                        sectionPosition11 = sectionPosition10 + sectionWidth10;
                        sectionPosition12 = sectionPosition11 + sectionWidth11;
                        sectionPosition13 = sectionPosition12 + sectionWidth12;
                        sectionPosition14 = sectionPosition13 + sectionWidth13;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;

                        break;
                    }

                case 14:
                    {
                        sectionPosition8 = 0;
                        sectionPosition7 = sectionWidth7 * -1;
                        sectionPosition6 = sectionPosition7 - sectionWidth6;
                        sectionPosition5 = sectionPosition6 - sectionWidth5;
                        sectionPosition4 = sectionPosition5 - sectionWidth4;
                        sectionPosition3 = sectionPosition4 - sectionWidth3;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition9 = sectionWidth8;
                        sectionPosition10 = sectionPosition9 + sectionWidth9;
                        sectionPosition11 = sectionPosition10 + sectionWidth10;
                        sectionPosition12 = sectionPosition11 + sectionWidth11;
                        sectionPosition13 = sectionPosition12 + sectionWidth12;
                        sectionPosition14 = sectionPosition13 + sectionWidth13;
                        sectionPosition15 = sectionPosition14 + sectionWidth14;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;
                        break;
                    }
                case 15:
                    {
                        sectionPosition9 = sectionWidth8 / 2.0M;
                        sectionPosition8 = sectionPosition9 * -1; ;
                        sectionPosition7 = sectionPosition8 - sectionWidth7;
                        sectionPosition6 = sectionPosition7 - sectionWidth6;
                        sectionPosition5 = sectionPosition6 - sectionWidth5;
                        sectionPosition4 = sectionPosition5 - sectionWidth4;
                        sectionPosition3 = sectionPosition4 - sectionWidth3;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition10 = sectionPosition9 + sectionWidth9;
                        sectionPosition11 = sectionPosition10 + sectionWidth10;
                        sectionPosition12 = sectionPosition11 + sectionWidth11;
                        sectionPosition13 = sectionPosition12 + sectionWidth12;
                        sectionPosition14 = sectionPosition13 + sectionWidth13;
                        sectionPosition15 = sectionPosition14 + sectionWidth14;
                        sectionPosition16 = sectionPosition15 + sectionWidth15;
                        sectionPosition17 = 0;

                        break;
                    }


                case 16:
                    {
                        sectionPosition9 = 0;
                        sectionPosition8 = sectionWidth8 * -1;
                        sectionPosition7 = sectionPosition8 - sectionWidth7;
                        sectionPosition6 = sectionPosition7 - sectionWidth6;
                        sectionPosition5 = sectionPosition6 - sectionWidth5;
                        sectionPosition4 = sectionPosition5 - sectionWidth4;
                        sectionPosition3 = sectionPosition4 - sectionWidth3;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition10 = sectionWidth9;
                        sectionPosition11 = sectionPosition10 + sectionWidth10;
                        sectionPosition12 = sectionPosition11 + sectionWidth11;
                        sectionPosition13 = sectionPosition12 + sectionWidth12;
                        sectionPosition14 = sectionPosition13 + sectionWidth13;
                        sectionPosition15 = sectionPosition14 + sectionWidth14;
                        sectionPosition16 = sectionPosition15 + sectionWidth15;
                        sectionPosition17 = sectionPosition16 + sectionWidth16;
                        break;
                    }
            }
        }

        #endregion

        #region Switch

        private void tabTSwitches_Enter(object sender, EventArgs e)
        {
            //set accordingly
            chkSelectSteerSwitch.Checked = mf.mc.isSteerWorkSwitchEnabled;
            chkSelectWorkSwitch.Checked = mf.mc.isWorkSwitchEnabled;

            if (Properties.Settings.Default.setF_isWorkSwitchManualSections)
            {
                chkSetManualSections.Checked = true;
                chkSetAutoSections.Checked = false;
            }
            else
            {
                chkSetManualSections.Checked = false;
                chkSetAutoSections.Checked = true;
            }

            if (Properties.Settings.Default.setF_isSteerWorkSwitchManualSections)
            {
                chkSetManualSectionsSteer.Checked = true;
                chkSetAutoSectionsSteer.Checked = false;
            }
            else
            {
                chkSetManualSectionsSteer.Checked = false;
                chkSetAutoSectionsSteer.Checked = true;
            }

            chkSetManualSections.Enabled = chkSetAutoSections.Enabled = chkWorkSwActiveLow.Enabled = chkSelectWorkSwitch.Checked;
            chkSetManualSectionsSteer.Enabled = chkSetAutoSectionsSteer.Enabled = chkSelectSteerSwitch.Checked;


            chkWorkSwActiveLow.Checked = Properties.Settings.Default.setF_isWorkSwitchActiveLow;
            if (chkWorkSwActiveLow.Checked) chkWorkSwActiveLow.Image = Properties.Resources.SwitchActiveClosed;
            else chkWorkSwActiveLow.Image = Properties.Resources.SwitchActiveOpen;
        }

        private void tabTSwitches_Leave(object sender, EventArgs e)
        {
            //active low on work switch
            mf.mc.isWorkSwitchActiveLow = Properties.Settings.Default.setF_isWorkSwitchActiveLow = chkWorkSwActiveLow.Checked;

            //is work switch enabled
            mf.mc.isWorkSwitchEnabled = Properties.Settings.Default.setF_isWorkSwitchEnabled = chkSelectWorkSwitch.Checked;

            //Are auto or manual sections controlled. 
            mf.mc.isWorkSwitchManualSections = Properties.Settings.Default.setF_isWorkSwitchManualSections = chkSetManualSections.Checked;

            //Are auto or manual sections controlled for steer
            mf.mc.isSteerWorkSwitchEnabled = Properties.Settings.Default.setF_isSteerWorkSwitchEnabled = chkSelectSteerSwitch.Checked;

            //does steer switch control manual or auto sections
            mf.mc.isSteerWorkSwitchManualSections = Properties.Settings.Default.setF_isSteerWorkSwitchManualSections = chkSetManualSectionsSteer.Checked;

            if (!mf.mc.isSteerWorkSwitchEnabled && !mf.mc.isWorkSwitchEnabled)
                mf.mc.isRemoteWorkSystemOn = Properties.Settings.Default.setF_isRemoteWorkSystemOn = false;
            else
                mf.mc.isRemoteWorkSystemOn = Properties.Settings.Default.setF_isRemoteWorkSystemOn = true;
            //save
            Properties.Settings.Default.Save();
        }

        private void chkSelectWorkSwitch_Click(object sender, EventArgs e)
        {
            chkSetManualSections.Enabled = chkSetAutoSections.Enabled= chkWorkSwActiveLow.Enabled = chkSelectWorkSwitch.Checked;
        }

        private void chkSelectSteerSwitch_Click(object sender, EventArgs e)
        {
            chkSetManualSectionsSteer.Enabled = chkSetAutoSectionsSteer.Enabled = chkSelectSteerSwitch.Checked;
        }

        private void chkWorkSwActiveLow_Click(object sender, EventArgs e)
        {
            if (chkWorkSwActiveLow.Checked) chkWorkSwActiveLow.Image = Properties.Resources.SwitchActiveClosed;
            else chkWorkSwActiveLow.Image = Properties.Resources.SwitchActiveOpen;
        }

        private void chkSetManualSections_Click(object sender, EventArgs e)
        {
            chkSetAutoSections.Checked = false;
            chkSetManualSections.Checked = true;
        }

        private void chkSetAutoSections_Click(object sender, EventArgs e)
        {
            chkSetManualSections.Checked = false;
            chkSetAutoSections.Checked = true;
        }

        private void chkSetAutoSectionsSteer_Click(object sender, EventArgs e)
        {
            chkSetManualSectionsSteer.Checked = false;
            chkSetAutoSectionsSteer.Checked = true;
        }

        private void chkSetManualSectionsSteer_Click(object sender, EventArgs e)
        {
            chkSetAutoSectionsSteer.Checked = false;
            chkSetManualSectionsSteer.Checked = true;
        }
        #endregion
    }
}
