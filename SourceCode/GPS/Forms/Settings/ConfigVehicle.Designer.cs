using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormConfig
    {

        #region Vehicle Save---------------------------------------------
        private void btnVehicleSave_Click(object sender, EventArgs e)
        {
            if (tboxVehicleNameSave.Text.Trim().Length > 0)
            {
                SaveDisplaySettings();

                SettingsIO.ExportAll(mf.vehiclesDirectory + tboxVehicleNameSave.Text.Trim() + ".XML");
                UpdateVehicleListView();
                lblCurrentVehicle.Text = tboxVehicleNameSave.Text.Trim();
                Properties.Vehicle.Default.setVehicle_vehicleName = tboxVehicleNameSave.Text.Trim();
                Properties.Vehicle.Default.Save();
                tboxVehicleNameSave.Text = "";
                btnVehicleSave.Enabled = false;
            }
        }

        private void tboxVehicleNameSave_TextChanged(object sender, EventArgs e)
        {
            var textboxSender = (TextBox)sender;
            var cursorPosition = textboxSender.SelectionStart;
            textboxSender.Text = Regex.Replace(textboxSender.Text, glm.fileRegex, "");
            textboxSender.SelectionStart = cursorPosition;

            if (String.IsNullOrEmpty(tboxVehicleNameSave.Text.Trim()))
            {
                btnVehicleSave.Enabled = false;
            }
            else
            {
                btnVehicleSave.Enabled = true;
            }
        }
        private void tboxVehicleNameSave_Click(object sender, EventArgs e)
        {
            if (mf.isKeyboardOn)
            {
                mf.KeyboardToText((TextBox)sender, this);
            }
        }

        private void btnVehicleSaveAs_Click(object sender, EventArgs e)
        {
            if (lvVehicles.SelectedItems.Count > 0)
            {
                DialogResult result3 = MessageBox.Show(
                    "Overwrite: " + lvVehicles.SelectedItems[0].SubItems[0].Text + ".XML",
                    gStr.gsSaveAndReturn,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (result3 == DialogResult.Yes)
                {
                    SettingsIO.ExportAll(mf.vehiclesDirectory + lvVehicles.SelectedItems[0].SubItems[0].Text + ".XML");
                }
                UpdateVehicleListView();
            }
        }

        private void UpdateVehicleListView()
        {
            DirectoryInfo dinfo = new DirectoryInfo(mf.vehiclesDirectory);
            FileInfo[] Files = dinfo.GetFiles("*.XML");

            //load the listbox
            lvVehicles.Items.Clear();
            foreach (FileInfo file in Files)
            {
                lvVehicles.Items.Add(Path.GetFileNameWithoutExtension(file.Name));
            }

            //deselect everything
            lvVehicles.SelectedItems.Clear();
        }

        private void btnVehicleLoad_Click(object sender, EventArgs e)
        {
            if (!mf.isJobStarted)
            {
                if (lvVehicles.SelectedItems.Count > 0)
                {
                    DialogResult result3 = MessageBox.Show(
                        "Load: " + lvVehicles.SelectedItems[0].SubItems[0].Text + ".XML",
                        gStr.gsSaveAndReturn,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
                    if (result3 == DialogResult.Yes)
                    {
                        SettingsIO.ImportAll(mf.vehiclesDirectory + lvVehicles.SelectedItems[0].SubItems[0].Text + ".XML");
                        mf.vehicleFileName = lvVehicles.SelectedItems[0].SubItems[0].Text;
                        Properties.Vehicle.Default.setVehicle_vehicleName = mf.vehicleFileName;
                        Properties.Vehicle.Default.Save();

                        mf.vehicle = new CVehicle(mf);
                        mf.tool = new CTool(mf);

                        //fix the checkboxes on summary
                        //SaveDisplaySettings();

                        //reset AOG
                        mf.LoadSettings();

                        chkDisplaySky.Checked = mf.isSkyOn;
                        chkDisplayFloor.Checked = mf.isTextureOn;
                        chkDisplayGrid.Checked = mf.isGridOn;
                        chkDisplaySpeedo.Checked = mf.isSpeedoOn;
                        chkDisplayDayNight.Checked = mf.isAutoDayNight;
                        chkDisplayExtraGuides.Checked = mf.isSideGuideLines;
                        chkDisplayLogNMEA.Checked = mf.isLogNMEA;
                        chkDisplayPolygons.Checked = mf.isDrawPolygons;
                        chkDisplayLightbar.Checked = mf.isLightbarOn;
                        chkDisplayKeyboard.Checked = mf.isKeyboardOn;
                        chkDisplayStartFullScreen.Checked = Properties.Settings.Default.setDisplay_isStartFullScreen;

                        if (mf.isMetric) rbtnDisplayMetric.Checked = true;
                        else rbtnDisplayImperial.Checked = true;

                        SaveDisplaySettings();

                        lblCurrentVehicle.Text = Properties.Vehicle.Default.setVehicle_vehicleName;

                        if (mf.isMetric)
                        {
                            lblInchesCm.Text = gStr.gsCentimeters;
                            lblFeetMeters.Text = gStr.gsMeters;
                            lblSecTotalWidthFeet.Visible = false;
                            lblSecTotalWidthInches.Visible = false;
                            lblSecTotalWidthMeters.Visible = true;
                        }
                        else
                        {
                            lblInchesCm.Text = gStr.gsInches;
                            lblFeetMeters.Text = "Feet";
                            lblSecTotalWidthFeet.Visible = true;
                            lblSecTotalWidthInches.Visible = true;
                            lblSecTotalWidthMeters.Visible = false;
                        }

                        if (mf.isMetric)
                        {
                            lblSecTotalWidthMeters.Text = (mf.tool.toolWidth * 100).ToString() + " cm";
                        }
                        else
                        {
                            double toFeet = mf.tool.toolWidth * 3.2808;
                            lblSecTotalWidthFeet.Text = Convert.ToString((int)toFeet) + "'";
                            double temp = Math.Round((toFeet - Math.Truncate(toFeet)) * 12, 0);
                            lblSecTotalWidthInches.Text = Convert.ToString(temp) + '"';
                        }


                        //Form Steer Settings
                        mf.p_252.pgn[mf.p_252.countsPerDegree] = unchecked((byte)Properties.Settings.Default.setAS_countsPerDegree);
                        mf.p_252.pgn[mf.p_252.ackerman] = unchecked((byte)Properties.Settings.Default.setAS_ackerman);

                        mf.p_252.pgn[mf.p_252.wasOffsetHi] = unchecked((byte)(Properties.Settings.Default.setAS_wasOffset >> 8));
                        mf.p_252.pgn[mf.p_252.wasOffsetLo] = unchecked((byte)(Properties.Settings.Default.setAS_wasOffset));

                        mf.p_252.pgn[mf.p_252.highPWM] = unchecked((byte)Properties.Settings.Default.setAS_highSteerPWM);
                        mf.p_252.pgn[mf.p_252.lowPWM] = unchecked((byte)Properties.Settings.Default.setAS_lowSteerPWM);
                        mf.p_252.pgn[mf.p_252.gainProportional] = unchecked((byte)Properties.Settings.Default.setAS_Kp);
                        mf.p_252.pgn[mf.p_252.minPWM] = unchecked((byte)Properties.Settings.Default.setAS_minSteerPWM);

                        mf.SendPgnToLoop(mf.p_252.pgn);

                        //machine module settings
                        mf.p_238.pgn[mf.p_238.set0] = Properties.Vehicle.Default.setArdMac_setting0;
                        mf.p_238.pgn[mf.p_238.raiseTime] = Properties.Vehicle.Default.setArdMac_hydRaiseTime;
                        mf.p_238.pgn[mf.p_238.lowerTime] = Properties.Vehicle.Default.setArdMac_hydLowerTime;

                        mf.SendPgnToLoop(mf.p_238.pgn);

                        //steer config
                        mf.p_251.pgn[mf.p_251.set0] = Properties.Vehicle.Default.setArdSteer_setting0;
                        mf.p_251.pgn[mf.p_251.set1] = Properties.Vehicle.Default.setArdSteer_setting1;
                        mf.p_251.pgn[mf.p_251.maxPulse] = Properties.Vehicle.Default.setArdSteer_maxPulseCounts;
                        mf.p_251.pgn[mf.p_251.minSpeed] = 5; //0.5 kmh

                        if (Properties.Settings.Default.setAS_isAngVelGuidance)
                            mf.p_251.pgn[mf.p_251.angVel] = 1;
                        else mf.p_251.pgn[mf.p_251.angVel] = 0;

                        mf.SendPgnToLoop(mf.p_251.pgn);

                        mf.TimedMessageBox(2500, "Steer and Machine Settings Sent",  "Was Steer Module Connected?");
                    }

                    UpdateVehicleListView();

                }
            }
            else
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show(this);
            }
            //Close();
        }

        private void btnVehicleDelete_Click(object sender, EventArgs e)
        {
            if (lvVehicles.SelectedItems.Count > 0)
            {
                DialogResult result3 = MessageBox.Show(
                "Delete: " + lvVehicles.SelectedItems[0].SubItems[0].Text + ".XML",
                gStr.gsSaveAndReturn,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button2);
                if (result3 == DialogResult.Yes)
                {
                    File.Delete(mf.vehiclesDirectory + lvVehicles.SelectedItems[0].SubItems[0].Text + ".XML");
                }
                UpdateVehicleListView();
            }
        }        

        private void rbtnDisplayImperial_Click(object sender, EventArgs e)
        {
            mf.TimedMessageBox(2000, "Units Set", "Imperial");
            Close();
        }

        private void rbtnDisplayMetric_Click(object sender, EventArgs e)
        {
            mf.TimedMessageBox(2000, "Units Set", "Metric");
            Close();
        }

        private void nudMenusOnTime_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
            }
        }

        private void SaveDisplaySettings()
        {
            mf.isSkyOn = chkDisplaySky.Checked;
            mf.isTextureOn = chkDisplayFloor.Checked;
            mf.isGridOn = chkDisplayGrid.Checked;
            mf.isSpeedoOn = chkDisplaySpeedo.Checked;
            mf.isAutoDayNight = chkDisplayDayNight.Checked;
            mf.isSideGuideLines = chkDisplayExtraGuides.Checked;
            mf.isLogNMEA = chkDisplayLogNMEA.Checked;
            mf.isDrawPolygons = chkDisplayPolygons.Checked;
            mf.isLightbarOn = chkDisplayLightbar.Checked;
            mf.isKeyboardOn = chkDisplayKeyboard.Checked;
            //mf.timeToShowMenus = (int)nudMenusOnTime.Value;

            Properties.Settings.Default.setMenu_isSkyOn = mf.isSkyOn;
            Properties.Settings.Default.setDisplay_isTextureOn = mf.isTextureOn;
            Properties.Settings.Default.setMenu_isGridOn = mf.isGridOn;
            Properties.Settings.Default.setMenu_isCompassOn = mf.isCompassOn;
            Properties.Settings.Default.setMenu_isSpeedoOn = mf.isSpeedoOn;
            Properties.Settings.Default.setDisplay_isAutoDayNight = mf.isAutoDayNight;
            Properties.Settings.Default.setDisplay_isStartFullScreen = chkDisplayStartFullScreen.Checked;
            Properties.Settings.Default.setMenu_isSideGuideLines = mf.isSideGuideLines;
            //Properties.Settings.Default.setMenu_isLogNMEA = mf.isLogNMEA;
            Properties.Settings.Default.setMenu_isPureOn = mf.isPureDisplayOn;
            Properties.Settings.Default.setMenu_isLightbarOn = mf.isLightbarOn;
            Properties.Settings.Default.setDisplay_isKeyboardOn = mf.isKeyboardOn;
            //Properties.Settings.Default.setDisplay_showMenusTime = mf.timeToShowMenus;

            if (rbtnDisplayMetric.Checked) { Properties.Settings.Default.setMenu_isMetric = true; mf.isMetric = true; }
            else { Properties.Settings.Default.setMenu_isMetric = false; mf.isMetric = false; }

            Properties.Settings.Default.Save();
        }

        #endregion

        #region VConfig Enter/Leave

        private void tabVConfig_Enter(object sender, EventArgs e)
        {
            if (mf.vehicle.vehicleType == 0) rbtnTractor.Checked = true;
            else if (mf.vehicle.vehicleType == 1) rbtnHarvester.Checked = true;
            else if (mf.vehicle.vehicleType == 2) rbtn4WD.Checked = true;
        }

        private void tabVConfig_Leave(object sender, EventArgs e)
        {
            if (rbtnTractor.Checked)
            {
                mf.vehicle.vehicleType = 0;
                Properties.Vehicle.Default.setVehicle_vehicleType = 0;
            }
            if (rbtnHarvester.Checked)
            {
                mf.vehicle.vehicleType = 1;
                Properties.Vehicle.Default.setVehicle_vehicleType = 1;
            }
            if (rbtn4WD.Checked)
            {
                mf.vehicle.vehicleType = 2;
                Properties.Vehicle.Default.setVehicle_vehicleType = 2;
            }

            if (mf.vehicle.vehicleType == 0) //2WD tractor
            {
                Properties.Vehicle.Default.setVehicle_isPivotBehindAntenna = true;
                Properties.Vehicle.Default.setVehicle_isSteerAxleAhead = true;
            }
            if (mf.vehicle.vehicleType == 1) //harvestor
            {
                Properties.Vehicle.Default.setVehicle_isPivotBehindAntenna = true;
                Properties.Vehicle.Default.setVehicle_isSteerAxleAhead = false ;
            }
            if (mf.vehicle.vehicleType == 2) //4WD
            {
                Properties.Vehicle.Default.setVehicle_isPivotBehindAntenna = false;
                Properties.Vehicle.Default.setVehicle_isSteerAxleAhead = true;
            }

            Properties.Vehicle.Default.Save();

            mf.vehicle.isPivotBehindAntenna = Properties.Vehicle.Default.setVehicle_isPivotBehindAntenna;
            mf.vehicle.isSteerAxleAhead = Properties.Vehicle.Default.setVehicle_isSteerAxleAhead;
        }

        #endregion

        #region Antenna Enter/Leave
        private void tabVAntenna_Enter(object sender, EventArgs e)
        {
            nudAntennaHeight.Value = (int)(Properties.Vehicle.Default.setVehicle_antennaHeight* mf.m2InchOrCm);

            nudAntennaPivot.Value = (int)((Properties.Vehicle.Default.setVehicle_antennaPivot)* mf.m2InchOrCm);

            nudAntennaOffset.Value = (int)(Properties.Vehicle.Default.setVehicle_antennaOffset* mf.m2InchOrCm);


            if (Properties.Vehicle.Default.setVehicle_vehicleType == 0)
                pboxAntenna.BackgroundImage = Properties.Resources.AntennaTractor;

            else if (Properties.Vehicle.Default.setVehicle_vehicleType == 1)
                pboxAntenna.BackgroundImage = Properties.Resources.AntennaHarvester;

            else if (Properties.Vehicle.Default.setVehicle_vehicleType == 2)
                pboxAntenna.BackgroundImage = Properties.Resources.Antenna4WD;
        }

        private void tabVAntenna_Leave(object sender, EventArgs e)
        {
            Properties.Vehicle.Default.Save();
        }

        private void nudAntennaPivot_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                Properties.Vehicle.Default.setVehicle_antennaPivot = (double)nudAntennaPivot.Value * mf.inchOrCm2m;
                mf.vehicle.antennaPivot = Properties.Vehicle.Default.setVehicle_antennaPivot;
            }
        }

        private void nudAntennaOffset_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                Properties.Vehicle.Default.setVehicle_antennaOffset = (double)nudAntennaOffset.Value * mf.inchOrCm2m;
                mf.vehicle.antennaOffset = Properties.Vehicle.Default.setVehicle_antennaOffset;
            }
        }

        private void nudAntennaHeight_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                Properties.Vehicle.Default.setVehicle_antennaHeight = (double)nudAntennaHeight.Value * mf.inchOrCm2m;
                mf.vehicle.antennaHeight = Properties.Vehicle.Default.setVehicle_antennaHeight;
            }
        }

        #endregion

        #region Vehicle Dimensions
        private void tabVDimensions_Enter(object sender, EventArgs e)
        {
            nudMinTurnRadius.Value = (int)(Properties.Vehicle.Default.setVehicle_minTurningRadius * mf.m2InchOrCm);

            nudWheelbase.Value = (int)(Math.Abs(Properties.Vehicle.Default.setVehicle_wheelbase) * mf.m2InchOrCm);
            
            nudVehicleTrack.Value = (int)(Math.Abs(Properties.Vehicle.Default.setVehicle_trackWidth) * mf.m2InchOrCm);

            if (mf.vehicle.vehicleType == 0) pictureBox1.Image = Properties.Resources.RadiusWheelBase;
            else if (mf.vehicle.vehicleType == 1) pictureBox1.Image = Properties.Resources.RadiusWheelBaseHarvester;
            else if (mf.vehicle.vehicleType == 2) pictureBox1.Image = Properties.Resources.RadiusWheelBase4WD;

        }

        private void tabVDimensions_Leave(object sender, EventArgs e)
        {
        }

        private void nudMinTurnRadius_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                Properties.Vehicle.Default.setVehicle_minTurningRadius = (double)nudMinTurnRadius.Value * mf.inchOrCm2m;
                mf.vehicle.minTurningRadius = Properties.Vehicle.Default.setVehicle_minTurningRadius;
                Properties.Vehicle.Default.Save();
            }
        }

        private void nudWheelbase_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                Properties.Vehicle.Default.setVehicle_wheelbase = (double)nudWheelbase.Value * mf.inchOrCm2m;
                mf.vehicle.wheelbase = Properties.Vehicle.Default.setVehicle_wheelbase;
                Properties.Vehicle.Default.Save();
            }
        }

        private void nudVehicleTrack_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                Properties.Vehicle.Default.setVehicle_trackWidth = (double)nudVehicleTrack.Value * mf.inchOrCm2m;
                mf.vehicle.trackWidth = Properties.Vehicle.Default.setVehicle_trackWidth;
                mf.tram.halfWheelTrack = mf.vehicle.trackWidth * 0.5;
                Properties.Vehicle.Default.Save();
            }
        }

        #endregion

        #region Vehicle Guidance

        private void tabVGuidance_Enter(object sender, EventArgs e)
        {
            if (mf.isMetric)
            {
                nudSnapDistance.DecimalPlaces = 0;
                nudSnapDistance.Value = (int)((double)Properties.Settings.Default.setAS_snapDistance * mf.cm2CmOrIn);
            }
            else
            {
                nudSnapDistance.DecimalPlaces = 1;
                nudSnapDistance.Value = (decimal)Math.Round(((double)Properties.Settings.Default.setAS_snapDistance * mf.cm2CmOrIn), 1,MidpointRounding.AwayFromZero);
            }
            
            nudABLength.Value = (decimal)Math.Round(((double)Properties.Settings.Default.setAB_lineLength * mf.m2FtOrM));

            nudGuidanceLookAhead.Value = (decimal)Properties.Settings.Default.setAS_guidanceLookAheadTime;

            double bob = ((double)Properties.Settings.Default.setDisplay_lightbarCmPerPixel * mf.cm2CmOrIn);
            if (bob < 1) bob = 1;
            nudLightbarCmPerPixel.Value = (decimal)bob;
            
            nudLineWidth.Value = Properties.Settings.Default.setDisplay_lineWidth;

            cboxAutoSteerAuto.Checked = Properties.Settings.Default.setAS_isAutoSteerAutoOn;
            if (Properties.Settings.Default.setAS_isAutoSteerAutoOn)
            {
                cboxAutoSteerAuto.Image = Properties.Resources.AutoSteerOn;
                cboxAutoSteerAuto.Text = "Remote";
            }
            else
            {
                cboxAutoSteerAuto.Image = Properties.Resources.AutoSteerOff;
                cboxAutoSteerAuto.Text = gStr.gsManual;
            }

            cboxAngVel.Checked = Properties.Settings.Default.setAS_isAngVelGuidance;

            label20.Text = mf.unitsInCm;
            label79.Text = mf.unitsFtM;
            label102.Text = mf.unitsInCm;
        }

        private void tabVGuidance_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.setAS_isAutoSteerAutoOn = cboxAutoSteerAuto.Checked;
            Properties.Settings.Default.Save();
        }

        private void cboxAutoSteerAuto_Click(object sender, EventArgs e)
        {
            if (cboxAutoSteerAuto.Checked)
            {
                cboxAutoSteerAuto.Image = Properties.Resources.AutoSteerOn;
                cboxAutoSteerAuto.Text = "Remote";
                mf.ahrs.isAutoSteerAuto = true;
            }
            else
            {
                cboxAutoSteerAuto.Image = Properties.Resources.AutoSteerOff;
                cboxAutoSteerAuto.Text = gStr.gsManual;
                mf.ahrs.isAutoSteerAuto = false;
            }
        }

        private void cboxAngVel_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.setAS_isAngVelGuidance = cboxAngVel.Checked;
            mf.isAngVelGuidance = cboxAngVel.Checked;

        }

        private void nudLineWidth_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                Properties.Settings.Default.setDisplay_lineWidth = (int)nudLineWidth.Value;
                mf.ABLine.lineWidth = Properties.Settings.Default.setDisplay_lineWidth;
            }
        }

        private void nudSnapDistance_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                Properties.Settings.Default.setAS_snapDistance = ((double)nudSnapDistance.Value * mf.inOrCm2Cm);
                mf.ABLine.snapDistance = Properties.Settings.Default.setAS_snapDistance;
            }
        }

        private void nudGuidanceLookAhead_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                Properties.Settings.Default.setAS_guidanceLookAheadTime = ((double)nudGuidanceLookAhead.Value);
                mf.guidanceLookAheadTime = Properties.Settings.Default.setAS_guidanceLookAheadTime;
            }
        }


        private void nudABLength_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                Properties.Settings.Default.setAB_lineLength = ((double)nudABLength.Value * mf.ftOrMtoM);
                mf.ABLine.abLength = Properties.Settings.Default.setAB_lineLength;
            }
        }

        private void nudLightbarCmPerPixel_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                Properties.Settings.Default.setDisplay_lightbarCmPerPixel = (int)((double)nudLightbarCmPerPixel.Value * mf.inOrCm2Cm);
                mf.lightbarCmPerPixel = Properties.Settings.Default.setDisplay_lightbarCmPerPixel;

            }
        }
        #endregion

    }
}

