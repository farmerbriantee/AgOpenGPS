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

                        if (Properties.Settings.Default.setAS_isConstantContourOn)
                            mf.p_251.pgn[mf.p_251.angVel] = 1;
                        else mf.p_251.pgn[mf.p_251.angVel] = 0;

                        mf.SendPgnToLoop(mf.p_251.pgn);

                        //Send Pin configuration
                        SendRelaySettingsToMachineModule();

                        ///Remind the user
                        mf.TimedMessageBox(2500, "Steer and Machine Settings Sent",  "Were Modules Connected?");
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

            cboxConstantContour.Checked = Properties.Settings.Default.setAS_isConstantContourOn;

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

        private void cboxConstantContour_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.setAS_isConstantContourOn = cboxConstantContour.Checked;
            mf.isConstantContourOn = cboxConstantContour.Checked;

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

        #region Brand
        //brand variables
        TBrand brand;
        HBrand brandH;
        WDBrand brand4WD;


        //Check Brand is changed
        private void rbtnBrandTAoG_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                brand = TBrand.AGOpenGPS;
        }

        private void rbtnBrandTCase_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                brand = TBrand.Case;
        }

        private void rbtnBrandTClaas_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                brand = TBrand.Claas;
        }

        private void rbtnBrandTDeutz_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                brand = TBrand.Deutz;
        }

        private void rbtnBrandTFendt_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                brand = TBrand.Fendt;
        }

        private void rbtnBrandTJDeere_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                brand = TBrand.JDeere;
        }

        private void rbtnBrandTKubota_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                brand = TBrand.Kubota;
        }

        private void rbtnBrandTMassey_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                brand = TBrand.Massey;
        }

        private void rbtnBrandTNH_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                brand = TBrand.NewHolland;
        }

        private void rbtnBrandTSame_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                brand = TBrand.Same;
        }

        private void rbtnBrandTSteyr_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                brand = TBrand.Steyr;
        }

        private void rbtnBrandTUrsus_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                brand = TBrand.Ursus;
        }

        private void rbtnBrandTValtra_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                brand = TBrand.Valtra;
        }

        private void rbtnBrandHAoG_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                brandH = HBrand.AGOpenGPS;
        }

        private void rbtnBrandHCase_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                brandH = HBrand.Case;
        }

        private void rbtnBrandHClaas_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                brandH = HBrand.Claas;
        }

        private void rbtnBrandHJDeere_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                brandH = HBrand.JDeere;
        }
        private void rbtnBrandHNH_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                brandH = HBrand.NewHolland;
        }
        private void rbtnBrand4WDAoG_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                brand4WD = WDBrand.AGOpenGPS;
        }

        private void rbtnBrand4WDCase_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                brand4WD = WDBrand.Case;
        }

        private void rbtnBrand4WDChallenger_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                brand4WD = WDBrand.Challenger;
        }

        private void rbtnBrand4WDJDeere_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                brand4WD = WDBrand.JDeere;
        }
        private void rbtnBrand4WDNH_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                brand4WD = WDBrand.NewHolland;
        }

        private void tabVBrand_Leave(object sender, EventArgs e)
        {
            if (rbtnTractor.Checked == true)
            {
                Settings.Default.setBrand_TBrand = brand;

                Bitmap bitmap = mf.GetTractorBrand(brand);


                //GL.GenTextures(1, out mf.texture[13]);//Already done on startup
                //Draw vehicle by brand
                GL.BindTexture(TextureTarget.Texture2D, mf.texture[13]);
                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
                bitmap.UnlockBits(bitmapData);

            }

            if (rbtnHarvester.Checked == true)

            {
                Settings.Default.setBrand_HBrand = brandH;
                Bitmap bitmap = mf.GetHarvesterBrand(brandH);


                GL.BindTexture(TextureTarget.Texture2D, mf.texture[18]);
                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
                bitmap.UnlockBits(bitmapData);

            }

            if (rbtn4WD.Checked == true)

            {
                Settings.Default.setBrand_WDBrand = brand4WD;
                Bitmap bitmap = mf.Get4WDBrandFront(brand4WD);


                GL.BindTexture(TextureTarget.Texture2D, mf.texture[16]);
                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
                bitmap.UnlockBits(bitmapData);
            }

            if (rbtn4WD.Checked == true)

            {
                Settings.Default.setBrand_WDBrand = brand4WD;
                Bitmap bitmap = mf.Get4WDBrandRear(brand4WD);


                GL.BindTexture(TextureTarget.Texture2D, mf.texture[17]);
                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
                bitmap.UnlockBits(bitmapData);

            }

        }

        private void tabVBrand_Enter(object sender, EventArgs e)
        {
            //Brand constructor
            brand = Settings.Default.setBrand_TBrand;

            if (brand == TBrand.Case)
                rbtnBrandTCase.Checked = true;
            else if (brand == TBrand.Claas)
                rbtnBrandTClaas.Checked = true;
            else if (brand == TBrand.Deutz)
                rbtnBrandTDeutz.Checked = true;
            else if (brand == TBrand.Fendt)
                rbtnBrandTFendt.Checked = true;
            else if (brand == TBrand.JDeere)
                rbtnBrandTJDeere.Checked = true;
            else if (brand == TBrand.Kubota)
                rbtnBrandTKubota.Checked = true;
            else if (brand == TBrand.Massey)
                rbtnBrandTMassey.Checked = true;
            else if (brand == TBrand.NewHolland)
                rbtnBrandTNH.Checked = true;
            else if (brand == TBrand.Same)
                rbtnBrandTSame.Checked = true;
            else if (brand == TBrand.Steyr)
                rbtnBrandTSteyr.Checked = true;
            else if (brand == TBrand.Ursus)
                rbtnBrandTUrsus.Checked = true;
            else if (brand == TBrand.Valtra)
                rbtnBrandTValtra.Checked = true;
            else
                rbtnBrandTAoG.Checked = true;


            brandH = Settings.Default.setBrand_HBrand;


            if (brandH == HBrand.Case)
                rbtnBrandHCase.Checked = true;
            else if (brandH == HBrand.Claas)
                rbtnBrandHClaas.Checked = true;
            else if (brandH == HBrand.JDeere)
                rbtnBrandHJDeere.Checked = true;
            else if (brandH == HBrand.NewHolland)
                rbtnBrandHNH.Checked = true;
            else
                rbtnBrandHAoG.Checked = true;


            brand4WD = Settings.Default.setBrand_WDBrand;


            if (brand4WD == WDBrand.Case)
                rbtnBrand4WDCase.Checked = true;
            else if (brand4WD == WDBrand.Challenger)
                rbtnBrand4WDChallenger.Checked = true;
            else if (brand4WD == WDBrand.JDeere)
                rbtnBrand4WDJDeere.Checked = true;
            else if (brand4WD == WDBrand.NewHolland)
                rbtnBrand4WDNH.Checked = true;
            else
                rbtnBrand4WDAoG.Checked = true;
        }
            #endregion
    }
}

