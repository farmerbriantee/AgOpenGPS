//Please, if you use this, share the improvements

using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using AgOpenGPS.Properties;
using System.Globalization;
using System.IO;
using System.Media;

//C:\Program Files(x86)\Arduino\hardware\tools\avr / bin / avrdude - CC:\Program Files(x86)\Arduino\hardware\tools\avr / etc / avrdude.conf 
//- v - patmega328p - carduino - PCOM3 - b57600 - D - Uflash:w: C: \Users\FarmPC\AppData\Local\Temp\arduino_build_448484 / Autosteer_UDP_20.ino.hex:i

namespace AgOpenGPS
{
    public partial class FormGPS
    {
        //ABLines directory
        public string ablinesDirectory;

        //colors for sections and field background
        public byte flagColor = 0;

        //how many cm off line per big pixel
        public int lightbarCmPerPixel;

        //polygon mode for section drawing
        public bool isDrawPolygons;

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
        public bool isDay = true, isDayTime = true;
        public bool isKeyboardOn = true;

        public bool isUTurnOn = true, isLateralOn = true;

        //master Manual and Auto, 3 states possible
        public enum btnStates { Off, Auto, On }
        public btnStates manualBtnState = btnStates.Off;
        public btnStates autoBtnState = btnStates.Off;

        public int[] customColorsList = new int[16];

        //sunrise sunset
        public DateTime dateToday = DateTime.Today;
        public DateTime sunrise = DateTime.Now;
        public DateTime sunset = DateTime.Now;

        public bool isFlashOnOff = false;

        //makes nav panel disappear after 6 seconds
        private int navPanelCounter = 0;

        public uint sentenceCounter = 0;

        //section button states
        public enum manBtn { Off, Auto, On }

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
                worldGrid.checkZoomWorldGrid(pn.fix.northing, pn.fix.easting);

                if (panelNavigation.Visible)
                    lblHz.Text = fixUpdateHz + " ~ " + (frameTime.ToString("N1")) + " " + FixQuality;

                if (isMetric)
                {
                    //fieldStatusStripText.Text = fd.WorkedAreaRemainHectares + "\r\n"+
                    //                               fd.WorkedAreaRemainPercentage +"\r\n" +
                    //                               fd.TimeTillFinished + "\r\n" +
                    //                               fd.WorkRateHectares;
                    if (bnd.bndArr.Count > 0)
                        lblFieldStatus.Text = fd.AreaBoundaryLessInnersHectares + "   " +
                                              fd.WorkedAreaRemainHectares  + "    " + fd.TimeTillFinished 
                                              + "  " + fd.WorkedAreaRemainPercentage+"      "
                                              +fd.WorkedHectares ;
                    else
                        lblFieldStatus.Text = fd.WorkedHectares;

                }
                else //imperial
                {
                    if (bnd.bndArr.Count > 0)
                        lblFieldStatus.Text = fd.AreaBoundaryLessInnersAcres + "   " + fd.WorkedAreaRemainAcres + "   " + 
                                           fd.TimeTillFinished + "  " + fd.WorkedAreaRemainPercentage + "      " +
                                            fd.WorkedAcres;
                    else
                        lblFieldStatus.Text = fd.WorkedAcres;
                }

                //hide the NAv panel in 6  secs
                if (panelNavigation.Visible)
                {
                    if (navPanelCounter-- < 1) panelNavigation.Visible = false;
                }


                lblTopData.Text = (tool.toolWidth * m2FtOrM).ToString("N2") + unitsFtM + " - " + vehicleFileName;
                lblFix.Text = FixQuality;
                lblAge.Text = pn.age.ToString("N1");

                if (isJobStarted)
                {
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
                    lblCurveLineName.Text = lblCurrentField.Text = string.Empty;
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

                lbludpWatchCounts.Text = udpWatchCounts.ToString();

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

                if (ABLine.isBtnABLineOn && !ct.isContourBtnOn)
                {
                    btnEditAB.Text = ((int)(ABLine.moveDistance * 100)).ToString();
                }
                if (curve.isBtnCurveOn && !ct.isContourBtnOn)
                {
                    btnEditAB.Text = ((int)(curve.moveDistance * 100)).ToString();
                }

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

                //AutoSteerAuto button enable - Ray Bear inspired code - Thx Ray!
                if (isJobStarted && ahrs.isAutoSteerAuto &&
                    (ABLine.isBtnABLineOn || ct.isContourBtnOn || curve.isBtnCurveOn))
                {
                    if (mc.steerSwitchValue == 0)
                    {
                        if (!isAutoSteerBtnOn) btnAutoSteer.PerformClick();
                    }
                    else
                    {
                        if (isAutoSteerBtnOn) btnAutoSteer.PerformClick();
                    }
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
            //toolStripBtnMakeBndContour.Visible = Properties.Settings.Default.setFeatures.isBndContourOn;
            recordedPathStripMenu.Visible = Properties.Settings.Default.setFeatures.isRecPathOn;
            SmoothABtoolStripMenu.Visible = Properties.Settings.Default.setFeatures.isABSmoothOn;
            deleteContourPathsToolStripMenuItem.Visible = Properties.Settings.Default.setFeatures.isHideContourOn;
            webcamToolStrip.Visible = Properties.Settings.Default.setFeatures.isWebCamOn;
            offsetFixToolStrip.Visible = Properties.Settings.Default.setFeatures.isOffsetFixOn;
            btnContour.Visible = Properties.Settings.Default.setFeatures.isContourOn;
            btnAutoYouTurn.Visible = Properties.Settings.Default.setFeatures.isYouTurnOn;
            btnStanleyPure.Visible = Properties.Settings.Default.setFeatures.isSteerModeOn;
            btnStartAgIO.Visible = Properties.Settings.Default.setFeatures.isAgIOOn;

            btnAutoSteer.Visible = Properties.Settings.Default.setFeatures.isAutoSteerOn;
            btnCycleLines.Visible = Properties.Settings.Default.setFeatures.isCycleLinesOn;
            btnManualOffOn.Visible = Properties.Settings.Default.setFeatures.isManualSectionOn;
            btnSectionOffAutoOn.Visible = Properties.Settings.Default.setFeatures.isAutoSectionOn;
            btnABLine.Visible = Properties.Settings.Default.setFeatures.isABLineOn;
            btnCurve.Visible = Properties.Settings.Default.setFeatures.isCurveOn;

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
                cm2CmOrIn = 0.3937;


                unitsInCm = " in";
                unitsFtM = " ft";
            }

            //timeToShowMenus = Properties.Settings.Default.setDisplay_showMenusTime;

            udpWatchLimit = Properties.Settings.Default.SetGPS_udpWatchMsec;

            startSpeed = Vehicle.Default.setVehicle_startSpeed;

            frameDayColor = Properties.Settings.Default.setDisplay_colorDayFrame;
            frameNightColor = Properties.Settings.Default.setDisplay_colorNightFrame;
            sectionColorDay = Properties.Settings.Default.setDisplay_colorSectionsDay;
            fieldColorDay = Properties.Settings.Default.setDisplay_colorFieldDay;
            fieldColorNight = Properties.Settings.Default.setDisplay_colorFieldNight;

            isSkyOn = Settings.Default.setMenu_isSkyOn;
            isTextureOn = Settings.Default.setDisplay_isTextureOn;

            isGridOn = Settings.Default.setMenu_isGridOn;
            isCompassOn = Settings.Default.setMenu_isCompassOn;
            isSpeedoOn = Settings.Default.setMenu_isSpeedoOn;
            isAutoDayNight = Settings.Default.setDisplay_isAutoDayNight;
            isSideGuideLines = Settings.Default.setMenu_isSideGuideLines;
            //isLogNMEA = Settings.Default.setMenu_isLogNMEA;
            isPureDisplayOn = Settings.Default.setMenu_isPureOn;

            panelNavigation.Location = new System.Drawing.Point(90, 100);
            panelDrag.Location = new System.Drawing.Point(87, 268);

            vehicleOpacity = ((double)(Properties.Settings.Default.setDisplay_vehicleOpacity) * 0.01);
            vehicleOpacityByte = (byte)(255 * ((double)(Properties.Settings.Default.setDisplay_vehicleOpacity) * 0.01));
            isVehicleImage = Properties.Settings.Default.setDisplay_isVehicleImage;


            //displayFieldName = gStr.gsNone;

            string directoryName = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

            {
                sndBoundaryAlarm = new SoundPlayer(Properties.Resources.Alarm10);
            }

            {
                sndHydraulicLift = new SoundPlayer(Properties.Resources.HydUp);
            }

            {
                sndHydraulicLower = new SoundPlayer(Properties.Resources.HydDown);
            }

            //grab the current vehicle filename - make sure it exists
            vehicleFileName = Vehicle.Default.setVehicle_vehicleName;

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

            if (timerSim.Enabled) fixUpdateHz = 10;
            fixUpdateTime = 1 / (double)fixUpdateHz;

            //set the flag mark button to red dot
            btnFlag.Image = Properties.Resources.FlagRed;

            //load the string of custom colors
            string[] words = Properties.Settings.Default.setDisplay_customColors.Split(',');
            for (int i = 0; i < 16; i++)
            {
                customColorsList[i] = int.Parse(words[i], CultureInfo.InvariantCulture);
            }

            //load up colors
            fieldColorDay = (Settings.Default.setDisplay_colorFieldDay);
            sectionColorDay = (Settings.Default.setDisplay_colorSectionsDay);
            fieldColorNight = (Settings.Default.setDisplay_colorFieldNight);

            textColorDay = Settings.Default.setDisplay_colorTextDay;
            textColorNight = Settings.Default.setDisplay_colorTextNight;

            vehicleColor = Settings.Default.setDisplay_colorVehicle;

            isLightbarOn = Settings.Default.setMenu_isLightbarOn;

            //set up grid and lightbar

            isKeyboardOn = Settings.Default.setDisplay_isKeyboardOn;

            if (Properties.Settings.Default.setAS_isAutoSteerAutoOn) btnAutoSteer.Text = "R";
            else btnAutoSteer.Text = "M";

            if (hd.isOn) btnHeadlandOnOff.Image = Properties.Resources.HeadlandOn;
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

            isAngVelGuidance = Properties.Settings.Default.setAS_isAngVelGuidance;

            guidanceLookAheadTime = Properties.Settings.Default.setAS_guidanceLookAheadTime;

            gyd.sideHillCompFactor = Properties.Settings.Default.setAS_sideHillComp;

            //ahrs.isReverseOn = Properties.Settings.Default.setIMU_isReverseOn;
            //ahrs.reverseComp = Properties.Settings.Default.setGPS_reverseComp;
            //ahrs.forwardComp = Properties.Settings.Default.setGPS_forwardComp;

            ahrs = new CAHRS();

            //update the field data areas
            fd.UpdateFieldBoundaryGUIAreas();

            //Set width of section and positions for each section
            SectionSetPosition();

            //Calculate total width and each section width
            SectionCalcWidths();
            LineUpManualBtns();

            //fast or slow section update
            isFastSections = Properties.Vehicle.Default.setSection_isFast;

            yt.rowSkipsWidth = Properties.Vehicle.Default.set_youSkipWidth;
            cboxpRowWidth.SelectedIndex = yt.rowSkipsWidth - 1;
            yt.Set_Alternate_skips();

            DisableYouTurnButtons();

            //which heading source is being used
            headingFromSource = Settings.Default.setGPS_headingFromWhichSource;

            //workswitch stuff
            mc.isWorkSwitchEnabled = Settings.Default.setF_IsWorkSwitchEnabled;
            mc.isWorkSwitchActiveLow = Settings.Default.setF_IsWorkSwitchActiveLow;
            mc.isWorkSwitchManual = Settings.Default.setF_IsWorkSwitchManual;
            mc.isSteerControlsManual = Settings.Default.setF_steerControlsManual;

            minFixStepDist = Settings.Default.setF_minFixStep;

            fd.workedAreaTotalUser = Settings.Default.setF_UserTotalArea;

            yt.uTurnSmoothing = Settings.Default.setAS_uTurnSmoothing;

            //load the lightbar resolution
            lightbarCmPerPixel = Properties.Settings.Default.setDisplay_lightbarCmPerPixel;

            //Stanley guidance
            isStanleyUsed = Properties.Vehicle.Default.setVehicle_isStanleyUsed;
            if (isStanleyUsed)
            {
                btnStanleyPure.Image = Resources.ModeStanley;
            }
            else
            {
                btnStanleyPure.Image = Resources.ModePurePursuit;
            }

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

            isTramOnBackBuffer = Properties.Settings.Default.setTram_isTramOnBackBuffer;

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

            FixPanelsAndMenus(false);
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
                LineUpManualBtns();
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
                LineUpManualBtns();
            }
            btnAutoSteerConfig.ForeColor = Color.Black;
            btnEditAB.ForeColor = Color.Black;

            Properties.Settings.Default.setDisplay_isDayMode = isDay;
            Properties.Settings.Default.Save();
        }

        private void FixPanelsAndMenus(bool isButtonsVisible)
        {
            panelAB.Size = new System.Drawing.Size(780 + ((Width - 900) / 2), 64);
            panelAB.Location = new Point((Width - 900) / 3 + 64, this.Height - 66);

            //if (isButtonsVisible)
            //{
            //    oglMain.Left = 75;
            //    oglMain.Width = this.Width - statusStripLeft.Width - 84;
            //    oglMain.Height = this.Height - panelAB.Height - 58;
            //    panelAB.Visible = true;
            //    panelRight.Visible = true;
            //}
            //else
            //{
            //    if (!isJobStarted)
            //    {
            //        panelAB.Visible = false;
            //        panelRight.Visible = false;
            //    }
            //    oglMain.Left = 75;
            //    oglMain.Width = this.Width - statusStripLeft.Width - 22; //22
            //    oglMain.Height = this.Height - 62;
            //}

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

            LineUpManualBtns();
        }

        //line up section On Off Auto buttons based on how many there are
        public void LineUpManualBtns()
        {
            int oglCenter = 0;

            oglCenter = statusStripLeft.Width + oglMain.Width / 2;

            int top = 130;

            int buttonMaxWidth = 400, buttonHeight = 25;


            if ((Height - oglMain.Height) < 80) //max size - buttons hid
            {
                top = Height - 70;
                if (panelSim.Visible == true)
                {
                    top = Height - 100;
                    panelSim.Top = Height - 60;
                }

            }
            else //buttons exposed
            {
                top = Height - 130;
                if (panelSim.Visible == true)
                {
                    top = Height - 160;
                    panelSim.Top = Height - 120;
                }
            }

            //if (!isJobStarted) top = Height - 40;

            btnSection1Man.Top = btnSection2Man.Top = btnSection3Man.Top = 
            btnSection4Man.Top = btnSection5Man.Top = btnSection6Man.Top =
            btnSection7Man.Top = btnSection8Man.Top = btnSection9Man.Top =
            btnSection10Man.Top = btnSection11Man.Top = btnSection12Man.Top =
            btnSection13Man.Top = btnSection14Man.Top =  btnSection15Man.Top =
            btnSection16Man.Top = top;

            int oglButtonWidth = oglMain.Width * 3 / 4;

            int buttonWidth = oglButtonWidth / tool.numOfSections;
            if (buttonWidth > buttonMaxWidth) buttonWidth = buttonMaxWidth;

            btnSection1Man.Size = btnSection2Man.Size = btnSection3Man.Size = 
            btnSection4Man.Size = btnSection5Man.Size = btnSection6Man.Size = 
            btnSection7Man.Size = btnSection8Man.Size = btnSection9Man.Size = 
            btnSection10Man.Size = btnSection11Man.Size = btnSection12Man.Size = 
            btnSection13Man.Size = btnSection14Man.Size = btnSection15Man.Size = 
            btnSection16Man.Size = new System.Drawing.Size(buttonWidth, buttonHeight);

            btnSection1Man.Left = (oglCenter) - (tool.numOfSections * btnSection1Man.Size.Width) / 2;
            btnSection2Man.Left = btnSection1Man.Left + btnSection1Man.Size.Width;
            btnSection3Man.Left = btnSection2Man.Left + btnSection1Man.Size.Width;
            btnSection4Man.Left = btnSection3Man.Left + btnSection1Man.Size.Width;
            btnSection5Man.Left = btnSection4Man.Left + btnSection1Man.Size.Width;
            btnSection6Man.Left = btnSection5Man.Left + btnSection1Man.Size.Width;
            btnSection7Man.Left = btnSection6Man.Left + btnSection1Man.Size.Width;
            btnSection8Man.Left = btnSection7Man.Left + btnSection1Man.Size.Width;
            btnSection9Man.Left = btnSection8Man.Left + btnSection1Man.Size.Width;
            btnSection10Man.Left = btnSection9Man.Left + btnSection1Man.Size.Width;
            btnSection11Man.Left = btnSection10Man.Left + btnSection1Man.Size.Width;
            btnSection12Man.Left = btnSection11Man.Left + btnSection1Man.Size.Width;
            btnSection13Man.Left = btnSection12Man.Left + btnSection1Man.Size.Width;
            btnSection14Man.Left = btnSection13Man.Left + btnSection1Man.Size.Width;
            btnSection15Man.Left = btnSection14Man.Left + btnSection1Man.Size.Width;
            btnSection16Man.Left = btnSection15Man.Left + btnSection1Man.Size.Width;

            btnSection1Man.Visible = tool.numOfSections > 0;
            btnSection2Man.Visible = tool.numOfSections > 1;
            btnSection3Man.Visible = tool.numOfSections > 2;
            btnSection4Man.Visible = tool.numOfSections > 3;
            btnSection5Man.Visible = tool.numOfSections > 4;
            btnSection6Man.Visible = tool.numOfSections > 5;
            btnSection7Man.Visible = tool.numOfSections > 6;
            btnSection8Man.Visible = tool.numOfSections > 7;
            btnSection9Man.Visible = tool.numOfSections > 8;
            btnSection10Man.Visible = tool.numOfSections > 9;
            btnSection11Man.Visible = tool.numOfSections > 10;
            btnSection12Man.Visible = tool.numOfSections > 11;
            btnSection13Man.Visible = tool.numOfSections > 12;
            btnSection14Man.Visible = tool.numOfSections > 13;
            btnSection15Man.Visible = tool.numOfSections > 14;
            btnSection16Man.Visible = tool.numOfSections > 15;
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

        //force all the buttons same according to two main buttons
        public void ManualAllBtnsUpdate()
        {
            ManualBtnUpdate(0, btnSection1Man);
            ManualBtnUpdate(1, btnSection2Man);
            ManualBtnUpdate(2, btnSection3Man);
            ManualBtnUpdate(3, btnSection4Man);
            ManualBtnUpdate(4, btnSection5Man);
            ManualBtnUpdate(5, btnSection6Man);
            ManualBtnUpdate(6, btnSection7Man);
            ManualBtnUpdate(7, btnSection8Man);
            ManualBtnUpdate(8, btnSection9Man);
            ManualBtnUpdate(9, btnSection10Man);
            ManualBtnUpdate(10, btnSection11Man);
            ManualBtnUpdate(11, btnSection12Man);
            ManualBtnUpdate(12, btnSection13Man);
            ManualBtnUpdate(13, btnSection14Man);
            ManualBtnUpdate(14, btnSection15Man);
            ManualBtnUpdate(15, btnSection16Man);

        }
        //update individual btn based on state after push

        private void ManualBtnUpdate(int sectNumber, Button btn)
        {
            switch (section[sectNumber].manBtnState)
            {
                case manBtn.Off:
                    section[sectNumber].manBtnState = manBtn.Auto;
                    if (isDay)
                    {
                        btn.BackColor = Color.Lime;
                        btn.ForeColor = Color.Black;
                    }
                    else
                    {
                        btn.BackColor = Color.ForestGreen;
                        btn.ForeColor = Color.White;
                    }
                    break;
            

                case manBtn.Auto:
                    section[sectNumber].manBtnState = manBtn.On;
                    if (isDay)
                    {
                        btn.BackColor = Color.Yellow;
                        btn.ForeColor = Color.Black;
                    }
                    else
                    {
                        btn.BackColor = Color.DarkGoldenrod;
                        btn.ForeColor = Color.White;
                    }
                    break;

                case manBtn.On:
                    section[sectNumber].manBtnState = manBtn.Off;
                    if (isDay)
                    {
                        btn.ForeColor = Color.Black;
                        btn.BackColor = Color.Red;
                    }
                    else
                    {
                        btn.BackColor = Color.Crimson;
                        btn.ForeColor = Color.White;
                    }
                    break;
            }
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
                        SwapDirection();
                        return;
                    }

                    middle = oglMain.Width / 2 - oglMain.Width / 4;
                    if (point.X > middle - 140 && point.X < middle && isUTurnOn)
                    {
                        if (yt.isYouTurnTriggered)
                        {
                            yt.ResetYouTurn();
                        }
                        else
                        {
                            yt.isYouTurnTriggered = true;
                            yt.BuildManualYouTurn(false, true);
                            return;
                        }
                    }

                    if (point.X > middle && point.X < middle + 140 && isUTurnOn)
                    {
                        if (yt.isYouTurnTriggered)
                        {
                            yt.ResetYouTurn();
                        }
                        else
                        {
                            yt.isYouTurnTriggered = true;
                            yt.BuildManualYouTurn(true, true);
                            return;
                        }
                    }
                }

                if (point.Y < 150 && point.Y > 90 && (ABLine.isBtnABLineOn || curve.isBtnCurveOn))
                {
                    int middle = oglMain.Width / 2 - oglMain.Width / 4;
                    if (point.X > middle - 140 && point.X < middle && isLateralOn)
                    {
                        yt.BuildManualYouLateral(false);
                        return;
                    }

                    if (point.X > middle && point.X < middle + 140 && isLateralOn)
                    {
                        yt.BuildManualYouLateral(true);
                        return;
                    }
                }

                //vehicle direcvtion reset
                int centerLeft = oglMain.Width / 2;
                int centerUp = oglMain.Height / 2;

                if (point.X > centerLeft - 40 && point.X < centerLeft + 40 && point.Y > centerUp - 60 && point.Y < centerUp + 60)
                {
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
                    if (point.Y < 180 && point.Y > 90)
                    {
                        if (camera.zoomValue <= 20) camera.zoomValue += camera.zoomValue * 0.2;
                        else camera.zoomValue += camera.zoomValue * 0.1;
                        if (camera.zoomValue > 180) camera.zoomValue = 180;
                        camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
                        SetZoom();
                        return;
                    }

                    //++
                    if (point.Y < 90)
                    {
                        if (camera.zoomValue <= 20)
                        { if ((camera.zoomValue -= camera.zoomValue * 0.2) < 6.0) camera.zoomValue = 6.0; }
                        else { if ((camera.zoomValue -= camera.zoomValue * 0.1) < 6.0) camera.zoomValue = 6.0; }

                        camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
                        SetZoom();
                        return;
                    }
                }

                mouseX = point.X;
                mouseY = oglMain.Height - point.Y;
                leftMouseDownOnOpenGL = true;
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
                oglZoom.Width = 180;
                oglZoom.Height = 180;
            }
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
                return Convert.ToString(Math.Round(avgSpeed*0.62137, 1));
            }
        }
        public string SpeedKPH
        {
            get
            {
                return Convert.ToString(Math.Round(avgSpeed, 1));
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
    }//end class
}//end namespace