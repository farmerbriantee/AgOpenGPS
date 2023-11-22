//Please, if you use this, share the improvements

using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using AgOpenGPS.Properties;
using System.Globalization;
using System.IO;
using System.Media;
using System.Reflection;

namespace AgOpenGPS
{
    public enum TBrand { AGOpenGPS, Case, Claas, Deutz, Fendt, JDeere, Kubota, Massey, NewHolland, Same, Steyr, Ursus, Valtra }
    public enum HBrand { AgOpenGPS, Case, Claas, JDeere, NewHolland }
    public enum WDBrand { AgOpenGPS, Case, Challenger, JDeere, NewHolland, Holder }

    public partial class FormGPS
    {
        //ABLines directory
        public string ablinesDirectory;

        //colors for sections and field background
        public byte flagColor = 0;

        //how many cm off line per big pixel
        public int lightbarCmPerPixel =2;

        //polygon mode for section drawing
        public bool isDrawPolygons = false;

        public CFeatureSettings featureSettings = new CFeatureSettings();

        public Color frameDayColor;
        public Color frameNightColor;
        public Color sectionColorDay;
        public Color fieldColorDay;
        public Color fieldColorNight;

        public Color textColorDay;
        public Color textColorNight;

        public Color vehicleColor;
        public double vehicleOpacity;
        public byte vehicleOpacityByte;
        public bool isVehicleImage;

        //Is it in 2D or 3D, metric or imperial, display lightbar, display grid etc
        public bool isMetric = true, isLightbarOn = true, isGridOn, isFullScreen;
        public bool isUTurnAlwaysOn, isCompassOn, isSpeedoOn, isAutoDayNight, isSideGuideLines = true;
        public bool isPureDisplayOn = true, isSkyOn = true, isRollMeterOn = false, isTextureOn = true;
        public bool isDay = true, isDayTime = true, isBrightnessOn = true;
        public bool isKeyboardOn = true, isAutoStartAgIO = true, isSvennArrowOn = true;

        public bool isUTurnOn = true, isLateralOn = true;

        public int[] customColorsList = new int[16];

        //sunrise sunset
        public DateTime dateToday = DateTime.Today;
        public DateTime sunrise = DateTime.Now;
        public DateTime sunset = DateTime.Now;

        public bool isFlashOnOff = false;

        //makes nav panel disappear after 6 seconds
        private int navPanelCounter = 0;

        public uint sentenceCounter = 0;


        //Timer triggers at 125 msec
        private void tmrWatchdog_tick(object sender, EventArgs e)
        {
            //Check for a newline char, if none then just return
            if (++sentenceCounter > 20)
            {
                ShowNoGPSWarning();
                return;
            }

            if (threeSecondCounter++ >= 12)
            {
                threeSecondCounter = 0;
                threeSeconds++;
            }
            if (oneSecondCounter++ >= 4)
            {
                oneSecondCounter = 0;
                oneSecond++;
            }
            if (oneHalfSecondCounter++ >= 2)
            {
                oneHalfSecondCounter = 0;
                oneHalfSecond++;
            }
            if (oneFifthSecondCounter++ >= 0)
            {
                oneFifthSecondCounter = 0;
                oneFifthSecond++;
            }

            /////////////////////////////////////////////////////////   333333333333333  ////////////////////////////////////////
            //every 3 second update status
            if (displayUpdateThreeSecondCounter != threeSeconds)
            {
                //reset the counter
                displayUpdateThreeSecondCounter = threeSeconds;

                //check to make sure the grid is big enough
                //worldGrid.checkZoomWorldGrid(pn.fix.northing, pn.fix.easting);

                //hide the NAv panel in 6  secs
                if (panelNavigation.Visible)
                {
                    if (navPanelCounter-- < 2) panelNavigation.Visible = false;
                }

                if (panelNavigation.Visible)
                    lblHz.Text = gpsHz.ToString("N1") + " ~ " + (frameTime.ToString("N1")) + " " + FixQuality;
 
                lblFix.Text = FixQuality + pn.age.ToString("N1");

                if (isJobStarted)
                {
                    if (isMetric)
                    {
                        if (bnd.bndList.Count > 0)
                            lblFieldStatus.Text = fd.AreaBoundaryLessInnersHectares + "   "
                                + fd.WorkedHectares + "    "
                                + fd.TimeTillFinished + "   "
                                + fd.WorkRateHectares;
                        else
                            lblFieldStatus.Text = fd.WorkedHectares + "   " + fd.WorkRateHectares;

                    }
                    else //imperial
                    {
                        if (bnd.bndList.Count > 0)
                            lblFieldStatus.Text = fd.AreaBoundaryLessInnersAcres + "   "
                                + fd.WorkedAcres + "    "
                                + fd.TimeTillFinished + "   "
                                + fd.WorkRateAcres;
                        else
                            lblFieldStatus.Text = fd.WorkedAcres + "   " + fd.WorkRateAcres;
                    }

                    lblCurrentField.Text = "Field: " + displayFieldName;

                    if (curve.numCurveLineSelected > 0 && curve.isBtnCurveOn)
                    {
                        lblCurveLineName.Text = "Cur-" + curve.curveArr[curve.numCurveLineSelected - 1].Name;
                    }

                    else if (ABLine.numABLineSelected > 0 && ABLine.isBtnABLineOn)
                    {
                        lblCurveLineName.Text = "AB-" + ABLine.lineArr[ABLine.numABLineSelected - 1].Name;
                    }
                    else lblCurveLineName.Text = string.Empty;
                }
                else
                {
                    lblCurveLineName.Text = lblFieldStatus.Text = string.Empty;
                    lblCurrentField.Text = (tool.width * m2FtOrM).ToString("N2") + unitsFtM + " - " + vehicleFileName;
                }


                if (isJobStarted)
                {
                    if (ABLine.isBtnABLineOn || curve.isBtnCurveOn)
                    {
                        if (!btnEditAB.Visible)
                        {
                            //btnMakeLinesFromBoundary.Visible = true;
                            btnEditAB.Visible = true;
                            btnSnapToPivot.Visible = true;
                            cboxpRowWidth.Visible = true;
                            btnYouSkipEnable.Visible = true;
                        }
                    }
                    else
                    {
                        if (btnEditAB.Visible)
                        {
                            //btnMakeLinesFromBoundary.Visible = false;
                            btnEditAB.Visible = false;
                            btnSnapToPivot.Visible = false;
                            cboxpRowWidth.Visible = false;
                            btnYouSkipEnable.Visible = false;
                        }
                    }
                }

                //save nmea log file
                if (isLogNMEA) FileSaveNMEA();

            }//end every 3 seconds

            //every second update all status ///////////////////////////   1 1 1 1 1 1 ////////////////////////////
            if (displayUpdateOneSecondCounter != oneSecond)
            {
                //reset the counter
                displayUpdateOneSecondCounter = oneSecond;

                //counter used for saving field in background
                minuteCounter++;
                tenMinuteCounter++;

                if (isStanleyUsed)
                {
                    if (curve.isBtnCurveOn || ABLine.isBtnABLineOn)
                    {
                        lblInty.Text = gyd.inty.ToString("N3");
                    }
                }
                else
                {
                    if (curve.isBtnCurveOn)
                    {
                        lblInty.Text = curve.inty.ToString("N3");
                    }

                    else if (ABLine.isBtnABLineOn && !ct.isContourBtnOn)
                    {
                        lblInty.Text = ABLine.inty.ToString("N3");
                    }

                    else if (ct.isContourBtnOn) lblInty.Text = ct.inty.ToString("N3");
                }

                if (recPath.isDrivingRecordedPath) lblInty.Text = recPath.inty.ToString("N3");

                if (ABLine.isBtnABLineOn && !ct.isContourBtnOn)
                {
                    btnEditAB.Text = ((int)(ABLine.moveDistance * 100)).ToString();
                }
                if (curve.isBtnCurveOn && !ct.isContourBtnOn)
                {
                    btnEditAB.Text = ((int)(curve.moveDistance * 100)).ToString();
                }

                //statusbar flash red undefined headland
                if (mc.isOutOfBounds && panelSim.BackColor == Color.Transparent
                    || !mc.isOutOfBounds && panelSim.BackColor == Color.Tomato)
                {
                    if (!mc.isOutOfBounds)
                    {
                        panelSim.BackColor = Color.Transparent;
                    }
                    else
                    {
                        panelSim.BackColor = Color.Tomato;
                    }
                }
            }

            //every half of a second update all status  ////////////////    0.5  0.5   0.5    0.5    /////////////////
            if (displayUpdateHalfSecondCounter != oneHalfSecond)
            {
                //reset the counter
                displayUpdateHalfSecondCounter = oneHalfSecond;

                isFlashOnOff = !isFlashOnOff;

                //the main formgps window
                if (isMetric)  //metric or imperial
                {
                    //status strip values
                    distanceToolBtn.Text = fd.DistanceUserMeters + "\r\n" + fd.WorkedUserHectares;

                }
                else  //Imperial Measurements
                {
                    //acres on the master section soft control and sections
                    //status strip values
                    distanceToolBtn.Text = fd.DistanceUserFeet + "\r\n" + fd.WorkedUserAcres;
                }

                //Make sure it is off when it should
                if ((!ABLine.isBtnABLineOn && !ct.isContourBtnOn && !curve.isBtnCurveOn && isAutoSteerBtnOn)
                    ) btnAutoSteer.PerformClick();

                //the main formgps window
                if (isMetric)  //metric or imperial
                {
                    lblSpeed.Text = SpeedKPH;
                    //btnContour.Text = XTE; //cross track error

                }
                else  //Imperial Measurements
                {
                    lblSpeed.Text = SpeedMPH;
                    //btnContour.Text = InchXTE; //cross track error
                }

            } //end every 1/2 second

            //every fifth second update  ///////////////////////////   FIFTH Fifth ////////////////////////////
            if (displayUpdateOneFifthCounter != oneFifthSecond)
            {
                //reset the counter
                displayUpdateOneFifthCounter = oneFifthSecond;

                btnAutoSteerConfig.Text = SetSteerAngle + "\r\n" + ActualSteerAngle;

                secondsSinceStart = (DateTime.Now - Process.GetCurrentProcess().StartTime).TotalSeconds;

                //integralStatusLeftSide.Text = "I: " + gyd.inty.ToString("N3");

                //lblAV.Text = ABLine.angVel.ToString("N3");
            }
        }//wait till timer fires again.  

        private void IsBetweenSunriseSunset(double lat, double lon)
        {
            CSunTimes.Instance.CalculateSunRiseSetTimes(pn.latitude, pn.longitude, dateToday, ref sunrise, ref sunset);
            //isDay = (DateTime.Now.Ticks < sunset.Ticks && DateTime.Now.Ticks > sunrise.Ticks);
        }

        public void LoadSettings()
        {            //metric settings

            CheckSettingsNotNull();

            isMetric = Settings.Default.setMenu_isMetric;

            tramLinesMenuField.Visible = Properties.Settings.Default.setFeatures.isTramOn;
            headlandToolStripMenuItem.Visible = Properties.Settings.Default.setFeatures.isHeadlandOn;

            boundariesToolStripMenuItem.Visible = Properties.Settings.Default.setFeatures.isBoundaryOn;
            recordedPathStripMenu.Visible = Properties.Settings.Default.setFeatures.isRecPathOn;
            SmoothABtoolStripMenu.Visible = Properties.Settings.Default.setFeatures.isABSmoothOn;
            deleteContourPathsToolStripMenuItem.Visible = Properties.Settings.Default.setFeatures.isHideContourOn;
            webcamToolStrip.Visible = Properties.Settings.Default.setFeatures.isWebCamOn;
            offsetFixToolStrip.Visible = Properties.Settings.Default.setFeatures.isOffsetFixOn;
            btnContour.Visible = Properties.Settings.Default.setFeatures.isContourOn;
            btnAutoYouTurn.Visible = Properties.Settings.Default.setFeatures.isYouTurnOn;
            btnStartAgIO.Visible = Properties.Settings.Default.setFeatures.isAgIOOn;

            btnAutoSteer.Visible = Properties.Settings.Default.setFeatures.isAutoSteerOn;
            btnCycleLines.Visible = Properties.Settings.Default.setFeatures.isCycleLinesOn;
            btnCycleLinesBk.Visible = Properties.Settings.Default.setFeatures.isCycleLinesOn;
            btnSectionMasterManual.Visible = Properties.Settings.Default.setFeatures.isManualSectionOn;
            btnSectionMasterAuto.Visible = Properties.Settings.Default.setFeatures.isAutoSectionOn;
            btnABLine.Visible = Properties.Settings.Default.setFeatures.isABLineOn;
            btnCurve.Visible = Properties.Settings.Default.setFeatures.isCurveOn;
            btnStanleyPure.Visible = Properties.Settings.Default.setFeatures.isSteerModeOn;

            isUTurnOn = Properties.Settings.Default.setFeatures.isUTurnOn;
            isLateralOn = Properties.Settings.Default.setFeatures.isLateralOn;

            if (isMetric)
            {
                inchOrCm2m = 0.01;
                m2InchOrCm = 100.0;

                m2FtOrM = 1.0;
                ftOrMtoM = 1.0;

                inOrCm2Cm = 1.0;
                cm2CmOrIn = 1.0;

                unitsFtM = " m";
                unitsInCm = " cm";
            }
            else
            {
                inchOrCm2m = glm.in2m;
                m2InchOrCm = glm.m2in;

                m2FtOrM = glm.m2ft;
                ftOrMtoM = glm.ft2m;

                inOrCm2Cm = 2.54;
                cm2CmOrIn = 0.394;

                unitsInCm = " in";
                unitsFtM = " ft";
            }

            udpWatchLimit = Properties.Settings.Default.SetGPS_udpWatchMsec;
            pn.headingTrueDualOffset = Properties.Settings.Default.setGPS_dualHeadingOffset;

            startSpeed = Settings.Default.setVehicle_startSpeed;

            frameDayColor = Properties.Settings.Default.setDisplay_colorDayFrame.CheckColorFor255();
            frameNightColor = Properties.Settings.Default.setDisplay_colorNightFrame.CheckColorFor255();
            sectionColorDay = Properties.Settings.Default.setDisplay_colorSectionsDay.CheckColorFor255();
            fieldColorDay = Properties.Settings.Default.setDisplay_colorFieldDay.CheckColorFor255();
            fieldColorNight = Properties.Settings.Default.setDisplay_colorFieldNight.CheckColorFor255();

            Properties.Settings.Default.setDisplay_colorDayFrame = frameDayColor;
            Properties.Settings.Default.setDisplay_colorNightFrame = frameNightColor;
            Properties.Settings.Default.setDisplay_colorSectionsDay = sectionColorDay;
            Properties.Settings.Default.setDisplay_colorFieldDay = fieldColorDay;
            Properties.Settings.Default.setDisplay_colorFieldNight = fieldColorNight;
            Properties.Settings.Default.Save();

            isSkyOn = Settings.Default.setMenu_isSkyOn;
            isTextureOn = Settings.Default.setDisplay_isTextureOn;

            isGridOn = Settings.Default.setMenu_isGridOn;
            isBrightnessOn = Settings.Default.setDisplay_isBrightnessOn;

            isCompassOn = Settings.Default.setMenu_isCompassOn;
            isSpeedoOn = Settings.Default.setMenu_isSpeedoOn;
            isAutoDayNight = Settings.Default.setDisplay_isAutoDayNight;
            isSideGuideLines = Settings.Default.setMenu_isSideGuideLines;
            isSvennArrowOn = Settings.Default.setDisplay_isSvennArrowOn;

            //isLogNMEA = Settings.Default.setMenu_isLogNMEA;
            isPureDisplayOn = Settings.Default.setMenu_isPureOn;

            isAutoStartAgIO = Settings.Default.setDisplay_isAutoStartAgIO;

            panelNavigation.Location = new System.Drawing.Point(90, 100);
            panelDrag.Location = new System.Drawing.Point(87, 268);

            vehicleOpacity = ((double)(Properties.Settings.Default.setDisplay_vehicleOpacity) * 0.01);
            vehicleOpacityByte = (byte)(255 * ((double)(Properties.Settings.Default.setDisplay_vehicleOpacity) * 0.01));
            isVehicleImage = Properties.Settings.Default.setDisplay_isVehicleImage;

            string directoryName = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

            //grab the current vehicle filename - make sure it exists
            vehicleFileName = Settings.Default.setVehicle_vehicleName;

            simulatorOnToolStripMenuItem.Checked = Settings.Default.setMenu_isSimulatorOn;
            if (simulatorOnToolStripMenuItem.Checked)
            {
                panelSim.Visible = true;
                timerSim.Enabled = true;
            }
            else
            {
                panelSim.Visible = false;
                timerSim.Enabled = false;
            }

            if (timerSim.Enabled) gpsHz = 10;

            if ( Properties.Settings.Default.setVehicle_isStanleyUsed)
            {
                btnStanleyPure.Image = Resources.ModeStanley;
            }
            else
            {
                btnStanleyPure.Image = Resources.ModePurePursuit;
            }

            //set the flag mark button to red dot
            btnFlag.Image = Properties.Resources.FlagRed;

            //load the string of custom colors
            string[] words = Properties.Settings.Default.setDisplay_customColors.Split(',');
            for (int i = 0; i < 16; i++)
            {
                Color test;
                customColorsList[i] = int.Parse(words[i], CultureInfo.InvariantCulture);
                test = Color.FromArgb(customColorsList[i]).CheckColorFor255();
                int iCol = (test.A << 24) | (test.R << 16) | (test.G << 8) | test.B;
                customColorsList[i] = iCol;
            }

            Properties.Settings.Default.setDisplay_customColors = "";
            for (int i = 0; i < 15; i++)
                Properties.Settings.Default.setDisplay_customColors += customColorsList[i].ToString() + ",";
            Properties.Settings.Default.setDisplay_customColors += customColorsList[15].ToString();

            Properties.Settings.Default.Save();


            //load up colors
            fieldColorDay = (Settings.Default.setDisplay_colorFieldDay.CheckColorFor255());
            sectionColorDay = (Settings.Default.setDisplay_colorSectionsDay.CheckColorFor255());
            fieldColorNight = (Settings.Default.setDisplay_colorFieldNight.CheckColorFor255());

            textColorDay = Settings.Default.setDisplay_colorTextDay.CheckColorFor255();
            textColorNight = Settings.Default.setDisplay_colorTextNight.CheckColorFor255();

            vehicleColor = Settings.Default.setDisplay_colorVehicle.CheckColorFor255();

            isLightbarOn = Settings.Default.setMenu_isLightbarOn;

            //set up grid and lightbar

            isKeyboardOn = Settings.Default.setDisplay_isKeyboardOn;

            if (Properties.Settings.Default.setAS_isAutoSteerAutoOn) btnAutoSteer.Text = "R";
            else btnAutoSteer.Text = "M";

            if (bnd.isHeadlandOn) btnHeadlandOnOff.Image = Properties.Resources.HeadlandOn;
            else btnHeadlandOnOff.Image = Properties.Resources.HeadlandOff;

            btnChangeMappingColor.BackColor = sectionColorDay;
            btnChangeMappingColor.Text = Application.ProductVersion.ToString(CultureInfo.InvariantCulture);

            if (Properties.Settings.Default.setDisplay_isStartFullScreen)
            {
                this.WindowState = FormWindowState.Maximized;
                isFullScreen = true;
            }
            else
            {
                isFullScreen = false;
            }

            //is rtk on?
            isRTK = Properties.Settings.Default.setGPS_isRTK;
            isRTK_KillAutosteer = Properties.Settings.Default.setGPS_isRTK_KillAutoSteer;

            pn.ageAlarm = Properties.Settings.Default.setGPS_ageAlarm;

            isConstantContourOn = Properties.Settings.Default.setAS_isConstantContourOn;
            isSteerInReverse = Properties.Settings.Default.setAS_isSteerInReverse;

            guidanceLookAheadTime = Properties.Settings.Default.setAS_guidanceLookAheadTime;

            gyd.sideHillCompFactor = Properties.Settings.Default.setAS_sideHillComp;

            ahrs = new CAHRS();

            fd.UpdateFieldBoundaryGUIAreas();

            btnSection1Man.Visible = false;
            btnSection2Man.Visible = false;
            btnSection3Man.Visible = false;
            btnSection4Man.Visible = false;
            btnSection5Man.Visible = false;
            btnSection6Man.Visible = false;
            btnSection7Man.Visible = false;
            btnSection8Man.Visible = false;
            btnSection9Man.Visible = false;
            btnSection10Man.Visible = false;
            btnSection11Man.Visible = false;
            btnSection12Man.Visible = false;
            btnSection13Man.Visible = false;
            btnSection14Man.Visible = false;
            btnSection15Man.Visible = false;
            btnSection16Man.Visible = false;

            btnZone1.Visible = false;
            btnZone2.Visible = false;
            btnZone3.Visible = false;
            btnZone4.Visible = false;
            btnZone5.Visible = false;
            btnZone6.Visible = false;
            btnZone7.Visible = false;
            btnZone8.Visible = false;

            if (tool.isSectionsNotZones)
            {
                //Set width of section and positions for each section
                SectionSetPosition();

                //Calculate total width and each section width
                SectionCalcWidths();
                LineUpIndividualSectionBtns();
            }
            else
            {
                SectionCalcMulti();
                LineUpAllZoneButtons();
            }

            //yt.rowSkipsWidth = Properties.Settings.Default.set_youSkipWidth;
            //cboxpRowWidth.SelectedIndex = yt.rowSkipsWidth - 1;
            //yt.Set_Alternate_skips();

            DisableYouTurnButtons();

            //which heading source is being used
            headingFromSource = Settings.Default.setGPS_headingFromWhichSource;

            //workswitch stuff
            mc.isRemoteWorkSystemOn = Settings.Default.setF_isRemoteWorkSystemOn;

            mc.isWorkSwitchActiveLow = Settings.Default.setF_isWorkSwitchActiveLow;
            mc.isWorkSwitchManualSections = Settings.Default.setF_isWorkSwitchManualSections;
            mc.isWorkSwitchEnabled = Settings.Default.setF_isWorkSwitchEnabled;

            mc.isSteerWorkSwitchEnabled = Settings.Default.setF_isSteerWorkSwitchEnabled;
            mc.isSteerWorkSwitchManualSections = Settings.Default.setF_isSteerWorkSwitchManualSections;

            minHeadingStepDist = Settings.Default.setF_minHeadingStepDistance;
            gpsMinimumStepDistance = Settings.Default.setGPS_minimumStepLimit;

            fd.workedAreaTotalUser = Settings.Default.setF_UserTotalArea;

            yt.uTurnSmoothing = Settings.Default.setAS_uTurnSmoothing;

            tool.halfWidth = (tool.width - tool.overlap) / 2.0;
            tool.contourWidth = (tool.width - tool.overlap) / 3.0;

            //load the lightbar resolution
            lightbarCmPerPixel = 2;

            isStanleyUsed = Properties.Settings.Default.setVehicle_isStanleyUsed;

            //main window first
            if (Settings.Default.setWindow_Maximized)
            {
                WindowState = FormWindowState.Normal;
                Location = Settings.Default.setWindow_Location;
                Size = Settings.Default.setWindow_Size;
            }
            else if (Settings.Default.setWindow_Minimized)
            {
                //WindowState = FormWindowState.Minimized;
                Location = Settings.Default.setWindow_Location;
                Size = Settings.Default.setWindow_Size;
            }
            else
            {
                Location = Settings.Default.setWindow_Location;
                Size = Settings.Default.setWindow_Size;
            }

            //night mode
            isDay = Properties.Settings.Default.setDisplay_isDayMode;
            isDay = !isDay;
            SwapDayNightMode();

            if (!Properties.Settings.Default.setDisplay_isTermsAccepted)
            {
                using (var form = new Form_First())
                {
                    if (form.ShowDialog(this) != DialogResult.OK)
                    {
                        Close();
                    }
                }
            }

            //load uturn properties
            yt = new CYouTurn(this);

            FixPanelsAndMenus();
            camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
            SetZoom();
        }

        private void ZoomByMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                if (camera.zoomValue <= 20) camera.zoomValue += camera.zoomValue * 0.06;
                else camera.zoomValue += camera.zoomValue * 0.02;
                if (camera.zoomValue > 120) camera.zoomValue = 120;
                camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
                SetZoom();
            }
            else
            {
                if (camera.zoomValue <= 20)
                { if ((camera.zoomValue -= camera.zoomValue * 0.06) < 6.0) camera.zoomValue = 6.0; }
                else { if ((camera.zoomValue -= camera.zoomValue * 0.02) < 6.0) camera.zoomValue = 6.0; }

                camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
                SetZoom();
            }
        }

        public void SwapDayNightMode()
        {
            isDay = !isDay;
            if (isDay)
            {
                btnDayNightMode.Image = Properties.Resources.WindowNightMode;

                this.BackColor = frameDayColor;
                foreach (Control c in this.Controls)
                {
                    //if (c is Label || c is Button)
                    {
                        c.ForeColor = textColorDay;
                    }
                }

                foreach (Control c in panelNavigation.Controls)
                {
                    //if (c is Label || c is Button)
                    {
                        c.ForeColor = textColorDay;
                    }
                }
            }
            else //nightmode
            {
                btnDayNightMode.Image = Properties.Resources.WindowDayMode;
                this.BackColor = frameNightColor;

                foreach (Control c in this.Controls)
                {
                    {
                        c.ForeColor = textColorNight;
                    }
                }
                foreach (Control c in panelNavigation.Controls)
                {
                    //if (c is Label || c is Button)
                    {
                        c.ForeColor = textColorDay;
                    }
                }

            }

            if (tool.isSectionsNotZones)
            {
                LineUpIndividualSectionBtns();
            }
            else
            {
                LineUpAllZoneButtons();
            }

            Properties.Settings.Default.setDisplay_isDayMode = isDay;
            Properties.Settings.Default.Save();
        }

        private void FixPanelsAndMenus()
        {
            panelAB.Size = new System.Drawing.Size(780 + ((Width - 900) / 2), 64);
            panelAB.Location = new Point((Width - 900) / 3 + 64, this.Height - 66);

            if (!isJobStarted)
            {
                panelAB.Visible = false;
                panelRight.Visible = false;

                oglMain.Left = 75;
                oglMain.Width = this.Width - statusStripLeft.Width - 22; //22
                oglMain.Height = this.Height - 62;
            }
            else
            {
                panelAB.Visible = true;
                panelRight.Visible = true;
                oglMain.Left = 75;
                oglMain.Width = this.Width - statusStripLeft.Width - 84; //22
                oglMain.Height = this.Height - 120;
            }

            if (tool.isSectionsNotZones)
            {
                LineUpIndividualSectionBtns();
            }
            else
            {
                LineUpAllZoneButtons();
            }
        }

        public void SaveFormGPSWindowSettings()
        {
            //save window settings
            if (WindowState == FormWindowState.Maximized)
            {
                Settings.Default.setWindow_Location = RestoreBounds.Location;
                Settings.Default.setWindow_Size = RestoreBounds.Size;
                Settings.Default.setWindow_Maximized = false;
                Settings.Default.setWindow_Minimized = false;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                Settings.Default.setWindow_Location = Location;
                Settings.Default.setWindow_Size = Size;
                Settings.Default.setWindow_Maximized = false;
                Settings.Default.setWindow_Minimized = false;
            }
            else
            {
                Settings.Default.setWindow_Location = RestoreBounds.Location;
                Settings.Default.setWindow_Size = RestoreBounds.Size;
                Settings.Default.setWindow_Maximized = false;
                Settings.Default.setWindow_Minimized = true;
            }

            Settings.Default.setDisplay_camPitch = camera.camPitch;
            Properties.Settings.Default.setDisplay_camZoom = camera.zoomValue;

            Settings.Default.setF_UserTotalArea = fd.workedAreaTotalUser;

            //Settings.Default.setDisplay_panelSnapLocation = panelSnap.Location;
            Settings.Default.setDisplay_panelSimLocation = panelSim.Location;

            Settings.Default.Save();
        }

        public string FindDirection(double heading)
        {
            if (heading < 0) heading += glm.twoPI;

            heading = glm.toDegrees(heading);

            if (heading > 337.5 || heading < 22.5)
            {
                return (" " +  gStr.gsNorth + " ");
            }
            if (heading > 22.5 && heading < 67.5)
            {
                return (" " +  gStr.gsN_East + " ");
            }
            if (heading > 67.5 && heading < 111.5)
            {
                return (" " +  gStr.gsEast + " ");
            }
            if (heading > 111.5 && heading < 157.5)
            {
                return (" " +  gStr.gsS_East + " ");
            }
            if (heading > 157.5 && heading < 202.5)
            {
                return (" " +  gStr.gsSouth + " ");
            }
            if (heading > 202.5 && heading < 247.5)
            {
                return (" " +  gStr.gsS_West + " ");
            }
            if (heading > 247.5 && heading < 292.5)
            {
                return (" " +  gStr.gsWest + " ");
            }
            if (heading > 292.5 && heading < 337.5)
            {
                return (" " +  gStr.gsN_West + " ");
            }
            return (" ?? ");
        }

        //Mouse Clicks 
        private void oglMain_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                //0 at bottom for opengl, 0 at top for windows, so invert Y value
                Point point = oglMain.PointToClient(Cursor.Position);

                if (point.Y < 90 && point.Y > 30 && (ABLine.isBtnABLineOn || curve.isBtnCurveOn))
                {

                    int middle = oglMain.Width / 2 + oglMain.Width / 5;
                    if (point.X > middle - 80 && point.X < middle + 80)
                    {
                        if (isTT)
                        {
                            MessageBox.Show(gStr.h_lblSwapDirectionCancel, gStr.gsHelp);
                            ResetHelpBtn();
                            return;
                        }
                        SwapDirection();
                        return;
                    }

                    //manual uturn triggering
                    middle = oglMain.Width / 2 - oglMain.Width / 4;
                    if (point.X > middle - 140 && point.X < middle && isUTurnOn)
                    {
                        if (isTT)
                        {
                            MessageBox.Show(gStr.h_lblManualTurnCancelTouch, gStr.gsHelp);
                            ResetHelpBtn();
                            return;
                        }

                        

                        if (yt.isYouTurnTriggered)
                        {
                            yt.ResetYouTurn();
                        }
                        else
                        {
                            if (vehicle.functionSpeedLimit > avgSpeed)
                            {
                                yt.isYouTurnTriggered = true;
                                yt.BuildManualYouTurn(false, true);
                            }
                            else
                            {
                                SpeedLimitExceeded();
                            }
                            return;
                        }
                    }

                    if (point.X > middle && point.X < middle + 140 && isUTurnOn)
                    {
                        if (isTT)
                        {
                            MessageBox.Show(gStr.h_lblManualTurnCancelTouch, gStr.gsHelp);
                            ResetHelpBtn();
                            return;
                        }

                        if (yt.isYouTurnTriggered)
                        {
                            yt.ResetYouTurn();
                        }
                        else
                        {
                            if (vehicle.functionSpeedLimit > avgSpeed)
                            {
                                yt.isYouTurnTriggered = true;
                                yt.BuildManualYouTurn(true, true);
                            }
                            else
                            {
                                SpeedLimitExceeded();
                            }

                            return;
                        }
                    }
                }

                if (point.Y < 150 && point.Y > 90 && (ABLine.isBtnABLineOn || curve.isBtnCurveOn))
                {
                    int middle = oglMain.Width / 2 - oglMain.Width / 4;
                    if (point.X > middle - 140 && point.X < middle && isLateralOn)
                    {
                        if (isTT)
                        {
                            MessageBox.Show(gStr.h_lblLateralTurnTouch, gStr.gsHelp);
                            ResetHelpBtn();
                            return;
                        }

                        if (vehicle.functionSpeedLimit > avgSpeed)
                        {
                            yt.BuildManualYouLateral(false);
                        }
                        else
                        {
                            SpeedLimitExceeded();
                        }

                        return;
                    }

                    if (point.X > middle && point.X < middle + 140 && isLateralOn)
                    {
                        if (isTT)
                        {
                            MessageBox.Show(gStr.h_lblLateralTurnTouch, gStr.gsHelp);
                            ResetHelpBtn();
                            return;
                        }

                        if (vehicle.functionSpeedLimit > avgSpeed)
                        {
                            yt.BuildManualYouLateral(true);
                        }
                        else
                        {
                            SpeedLimitExceeded();
                        }

                        return;
                    }
                }

                //vehicle direcvtion reset
                int centerLeft = oglMain.Width / 2;
                int centerUp = oglMain.Height / 2;

                if (point.X > centerLeft - 40 && point.X < centerLeft + 40 && point.Y > centerUp - 60 && point.Y < centerUp + 60)
                {
                    if (isTT)
                    {
                        MessageBox.Show(gStr.h_lblVehicleDirectionResetTouch, gStr.gsHelp);        
                        ResetHelpBtn();
                        return;
                    }


                    Array.Clear(stepFixPts, 0, stepFixPts.Length);
                    isFirstHeadingSet = false;
                    isReverse = false;
                    TimedMessageBox(2000, "Reset Direction", "Drive Forward > 1.5 kmh");
                    return;
                }

                //prevent flag selection if flag form is up
                Form fc = Application.OpenForms["FormFlags"];
                if (fc != null)
                {
                    fc.Focus();
                    return;
                }

                if (point.X > oglMain.Width - 80)
                {
                    //---
                    if (point.Y < 210 && point.Y > 120)
                    {
                        if (camera.zoomValue <= 20) camera.zoomValue += camera.zoomValue * 0.2;
                        else camera.zoomValue += camera.zoomValue * 0.1;
                        if (camera.zoomValue > 180) camera.zoomValue = 180;
                        camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
                        SetZoom();
                        return;
                    }

                    //++
                    if (point.Y < 120 && point.Y > 30)
                    {
                        if (camera.zoomValue <= 20)
                        { if ((camera.zoomValue -= camera.zoomValue * 0.2) < 6.0) camera.zoomValue = 6.0; }
                        else { if ((camera.zoomValue -= camera.zoomValue * 0.1) < 6.0) camera.zoomValue = 6.0; }

                        camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
                        SetZoom();
                        return;
                    }
                }

                //check for help touch on steer circle
                if (isTT)
                {
                    int sizer = oglMain.Height / 9;
                    if(point.Y > oglMain.Height-sizer && point.X > oglMain.Width - sizer)
                    {
                        MessageBox.Show(gStr.h_lblSteerCircleTouch, gStr.gsHelp);
                        ResetHelpBtn();
                        return;
                    }
                }

                mouseX = point.X;
                mouseY = oglMain.Height - point.Y;
                leftMouseDownOnOpenGL = true;
            }

            ResetHelpBtn();
        }

        private void SpeedLimitExceeded()
        {
            if (isMetric)
            {
                TimedMessageBox(2000, gStr.gsTooFast, gStr.gsSlowDownBelow + " " 
                    + vehicle.functionSpeedLimit.ToString() + " "+ gStr.gsKMH);
            }
            else
            {
                TimedMessageBox(2000, gStr.gsTooFast, gStr.gsSlowDownBelow + " "
                    + (vehicle.functionSpeedLimit* 0.621371).ToString() + " " + gStr.gsMPH);
           }
        }

        private void oglZoom_MouseClick(object sender, MouseEventArgs e)
        {
            if ((sender as Control).IsDragging()) return;

            if (oglZoom.Width == 180)
            {
                oglZoom.Width = 300;
                oglZoom.Height = 300;
            }

            else if (oglZoom.Width == 300)
            {
                oglZoom.Top = 55;
                oglZoom.Left = 3;
                oglZoom.Width = this.Width-6;
                oglZoom.Height = this.Height-61;
            }
            else if (oglZoom.Width > 300)
            {
                oglZoom.Width = 180;
                oglZoom.Height = 180;
            }
        }
        public void SwapDirection()
        {
            if (!yt.isYouTurnTriggered)
            {
                yt.isYouTurnRight = !yt.isYouTurnRight;
                yt.ResetCreatedYouTurn();
            }
            else if (yt.isYouTurnBtnOn)
                btnAutoYouTurn.PerformClick();
        }

        //Function to delete flag
        public void DeleteSelectedFlag()
        {
            //delete selected flag and set selected to none
            flagPts.RemoveAt(flagNumberPicked - 1);
            flagNumberPicked = 0;

            // re-sort the id's based on how many flags left
            int flagCnt = flagPts.Count;
            if (flagCnt > 0)
            {
                for (int i = 0; i < flagCnt; i++) flagPts[i].ID = i + 1;
            }
        }
        public void EnableYouTurnButtons()
        {
            yt.ResetYouTurn();

            yt.isYouTurnBtnOn = false;
            btnAutoYouTurn.Enabled = true;

            btnAutoYouTurn.Image = Properties.Resources.YouTurnNo;
        }
        public void DisableYouTurnButtons()
        {

            //btnAutoYouTurn.Enabled = false;

            yt.isYouTurnBtnOn = false;
            btnAutoYouTurn.Image = Properties.Resources.YouTurnNo;
            yt.ResetYouTurn();
        }

        private void ShowNoGPSWarning()
        {
            //update main window
            sentenceCounter = 300;
            oglMain.MakeCurrent();
            oglMain.Refresh();
        }

        #region Properties // ---------------------------------------------------------------------

        public string Latitude { get { return Convert.ToString(Math.Round(pn.latitude, 7)); } }
        public string Longitude { get { return Convert.ToString(Math.Round(pn.longitude, 7)); } }
        public string SatsTracked { get { return Convert.ToString(pn.satellitesTracked); } }
        public string HDOP { get { return Convert.ToString(pn.hdop); } }
        public string Heading { get { return Convert.ToString(Math.Round(glm.toDegrees(fixHeading), 1)) + "\u00B0"; } }
        public string GPSHeading { get { return (Math.Round(glm.toDegrees(gpsHeading), 1)) + "\u00B0"; } }
        public string FixQuality
        {
            get
            {
                if (timerSim.Enabled)
                    return "Sim: ";
                else if (pn.fixQuality == 0) return "Invalid: ";
                else if (pn.fixQuality == 1) return "GPS single: ";
                else if (pn.fixQuality == 2) return "DGPS : ";
                else if (pn.fixQuality == 3) return "PPS : ";
                else if (pn.fixQuality == 4) return "RTK fix: ";
                else if (pn.fixQuality == 5) return "Float: ";
                else if (pn.fixQuality == 6) return "Estimate: ";
                else if (pn.fixQuality == 7) return "Man IP: ";
                else if (pn.fixQuality == 8) return "Sim: ";
                else return "Unknown: ";
            }
        }

        public string GyroInDegrees
        {
            get
            {
                if (ahrs.imuHeading != 99999)
                    return Math.Round(ahrs.imuHeading, 1) + "\u00B0";
                else return "-";
            }
        }
        public string RollInDegrees
        {
            get
            {
                if (ahrs.imuRoll != 88888)
                    return Math.Round((ahrs.imuRoll), 1) + "\u00B0";
                else return "-";
            }
        }
        public string SetSteerAngle { get { return ((double)(guidanceLineSteerAngle) * 0.01).ToString("N1"); } }
        public string ActualSteerAngle { get { return ((mc.actualSteerAngleDegrees) ).ToString("N1") ; } }

        //Metric and Imperial Properties
        public string SpeedMPH
        {
            get
            {
                if (avgSpeed > 2)
                    return (avgSpeed * 0.62137).ToString("N1");
                else
                    return(avgSpeed * 0.62137).ToString("N2");
            }
        }
        public string SpeedKPH
        {
            get
            {
                if (avgSpeed > 2)
                    return (avgSpeed).ToString("N1");
                else
                    return (avgSpeed).ToString("N2");
            }
        }

        public string FixOffset { get { return (pn.fixOffset.easting.ToString("N2") + ", " + pn.fixOffset.northing.ToString("N2")); } }
        public string FixOffsetInch { get { return ((pn.fixOffset.easting*glm.m2in).ToString("N0")+ ", " + (pn.fixOffset.northing*glm.m2in).ToString("N0")); } }

        public string Altitude { get { return Convert.ToString(Math.Round(pn.altitude,1)); } }
        public string AltitudeFeet { get { return Convert.ToString((Math.Round((pn.altitude * 3.28084),1))); } }
        public string DistPivotM
        {
            get
            {
                if (distancePivotToTurnLine > 0 )
                    return ((int)(distancePivotToTurnLine)) + " m";
                else return "--";
            }
        }
        public string DistPivotFt
        {
            get
            {
                if (distancePivotToTurnLine > 0 ) return (((int)(glm.m2ft * (distancePivotToTurnLine))) + " ft");
                else return "--";
            }
        }

        #endregion properties 

        public enum textures : uint
        {
            SkyDay, Floor, Font,
            Turn, TurnCancel, TurnManual,
            Compass, Speedo, SpeedoNeedle,
            Lift, SkyNight, SteerPointer,
            SteerDot, Tractor, QuestionMark,
            FrontWheels, FourWDFront, FourWDRear,
            Harvester, Lateral, bingGrid, NoGPS
        }

        //Load Bitmaps brand
        public Bitmap GetTractorBrand(TBrand brand)
        {
            Bitmap bitmap;
            if (brand == TBrand.Case)
                bitmap = Resources.z_TractorCase;
            else if (brand == TBrand.Claas)
                bitmap = Resources.z_TractorClaas;
            else if (brand == TBrand.Deutz)
                bitmap = Resources.z_TractorDeutz;
            else if (brand == TBrand.Fendt)
                bitmap = Resources.z_TractorFendt;
            else if (brand == TBrand.JDeere)
                bitmap = Resources.z_TractorJDeere;
            else if (brand == TBrand.Kubota)
                bitmap = Resources.z_TractorKubota;
            else if (brand == TBrand.Massey)
                bitmap = Resources.z_TractorMassey;
            else if (brand == TBrand.NewHolland)
                bitmap = Resources.z_TractorNH;
            else if (brand == TBrand.Same)
                bitmap = Resources.z_TractorSame;
            else if (brand == TBrand.Steyr)
                bitmap = Resources.z_TractorSteyr;
            else if (brand == TBrand.Ursus)
                bitmap = Resources.z_TractorUrsus;
            else if (brand == TBrand.Valtra)
                bitmap = Resources.z_TractorValtra;
            else
                bitmap = Resources.z_TractorAoG;

            return bitmap;
        }

        public Bitmap GetHarvesterBrand(HBrand brandH)
        {
            Bitmap harvesterbitmap;
            if (brandH == HBrand.Case)
                harvesterbitmap = Resources.z_HarvesterCase;
            else if (brandH == HBrand.Claas)
                harvesterbitmap = Resources.z_HarvesterClaas;
            else if (brandH == HBrand.JDeere)
                harvesterbitmap = Resources.z_HarvesterJD;
            else if (brandH == HBrand.NewHolland)
                harvesterbitmap = Resources.z_HarvesterNH;
            else
                harvesterbitmap = Resources.z_HarvesterAoG;

            return harvesterbitmap;
        }

        public Bitmap Get4WDBrandFront(WDBrand brandWDF)
        {
            Bitmap bitmap4WDFront;
            if (brandWDF == WDBrand.Case)
                bitmap4WDFront = Resources.z_4WDFrontCase;
            else if (brandWDF == WDBrand.Challenger)
                bitmap4WDFront = Resources.z_4WDFrontChallenger;
            else if (brandWDF == WDBrand.JDeere)
                bitmap4WDFront = Resources.z_4WDFrontJDeere;
            else if (brandWDF == WDBrand.NewHolland)
                bitmap4WDFront = Resources.z_4WDFrontNH;
            else if (brandWDF == WDBrand.Holder)
                bitmap4WDFront = Resources.z_4WDFrontHolder;
            else
                bitmap4WDFront = Resources.z_4WDFrontAoG;

            return bitmap4WDFront;
        }
        
        public Bitmap Get4WDBrandRear(WDBrand brandWDR)
        {
            Bitmap bitmap4WDRear;
            if (brandWDR == WDBrand.Case)
                bitmap4WDRear = Resources.z_4WDRearCase;
            else if (brandWDR == WDBrand.Challenger)
                bitmap4WDRear = Resources.z_4WDRearChallenger;
            else if (brandWDR == WDBrand.JDeere)
                bitmap4WDRear = Resources.z_4WDRearJDeere;
            else if (brandWDR == WDBrand.NewHolland)
                bitmap4WDRear = Resources.z_4WDRearNH;
            else if (brandWDR == WDBrand.Holder)
                bitmap4WDRear = Resources.z_4WDRearHolder;
            else
                bitmap4WDRear = Resources.z_4WDRearAoG;

            return bitmap4WDRear;
        }

    }//end class
}//end namespace