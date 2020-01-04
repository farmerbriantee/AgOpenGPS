//Please, if you use this, share the improvements

using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using AgOpenGPS.Properties;
using Microsoft.Win32;
using System.Collections.Generic;

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
        private bool isDrawPolygons;

        //Is it in 2D or 3D, metric or imperial, display lightbar, display grid etc
        public bool isIn3D = true, isMetric = true, isLightbarOn = true, isGridOn, isFullScreen;
        public bool isUTurnAlwaysOn, isCompassOn, isSpeedoOn, isSideGuideLines = true;
        public bool isPureDisplayOn = true, isSkyOn = true, isRollMeterOn = false;
        public bool isDay = true, isSimple;

        //master Manual and Auto, 3 states possible
        public enum btnStates { Off, Auto, On }
        public btnStates manualBtnState = btnStates.Off;
        public btnStates autoBtnState = btnStates.Off;

        public Color dayColor = Properties.Settings.Default.setDisplay_colorDayMode;
        public Color nightColor = Properties.Settings.Default.setDisplay_colorNightMode;
        public Color sectionColor = Properties.Settings.Default.setDisplay_colorSections;
        public Color fieldColor = Properties.Settings.Default.setDisplay_colorField;


        //section button states
        public enum manBtn { Off, Auto, On }

        private void LoadGUI()
        {
            //set the language to last used
            SetLanguage(Settings.Default.setF_culture);

            //set the flag mark button to red dot
            btnFlag.Image = Properties.Resources.FlagRed;

            //night mode
            isDay = Properties.Settings.Default.setDisplay_isDayMode;
            isDay = !isDay;
            SwapDayNightMode();

            isSimple = Properties.Settings.Default.setDisplay_isSimple;

            //metric settings
            isMetric = Settings.Default.setMenu_isMetric;
            metricToolStrip.Checked = isMetric;

            if (isMetric)
            {
                lblSpeedUnits.Text = gStr.gsKMH;
                metricToolStrip.Checked = true;
                imperialToolStrip.Checked = false;
                //lblFlowLeft.Text = "LPM"; lblFlowRight.Text = "LPM";
            }
            else
            {
                lblSpeedUnits.Text = gStr.gsMPH;
                metricToolStrip.Checked = false;
                imperialToolStrip.Checked = true;
                //lblFlowLeft.Text = "GPM"; lblFlowRight.Text = "GPM";

            }

            //load up colors
            fieldColor = (Settings.Default.setDisplay_colorField);
            sectionColor = (Settings.Default.setDisplay_colorSections);

            DisableYouTurnButtons();

            //set up grid and lightbar
            isGridOn = Settings.Default.setMenu_isGridOn;
            gridOnToolStripMenuItem.Checked = isGridOn;

            //log NMEA 
            isLogNMEA = Settings.Default.setMenu_isLogNMEA;
            logNMEAToolStripMenuItem.Checked = isLogNMEA;

            isLightbarOn = Settings.Default.setMenu_isLightbarOn;
            lightbarToolStripMenuItem.Checked = isLightbarOn;

            isSideGuideLines = Settings.Default.setMenu_isSideGuideLines;
            extraGuidesToolStripMenuItem.Checked = isSideGuideLines;

            isPureDisplayOn = Settings.Default.setMenu_isPureOn;
            pursuitOnToolStripMenuItem.Checked = isPureDisplayOn;

            isSkyOn = Settings.Default.setMenu_isSkyOn;
            skyOnToolStripMenuItem.Checked = isSkyOn;

            isCompassOn = Settings.Default.setMenu_isCompassOn;
            compassOnToolStripMenuItem.Checked = isCompassOn;

            isSpeedoOn = Settings.Default.setMenu_isSpeedoOn;
            speedoOnToolStripMenuItem.Checked = isSpeedoOn;

            isUTurnAlwaysOn = Settings.Default.setMenu_isUTurnAlwaysOn;
            uTurnAlwaysOnToolStripMenuItem.Checked = isUTurnAlwaysOn;

            if (Settings.Default.setMenu_isOGLZoomOn == 1)
                topFieldViewToolStripMenuItem.Checked = true;
            else topFieldViewToolStripMenuItem.Checked = false;

            oglZoom.Width = 400;
            oglZoom.Height = 400;
            oglZoom.Visible = true;
            oglZoom.Left = 300;
            oglZoom.Top = 80;

            oglZoom.SendToBack();

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

            LineUpManualBtns();

            yt.rowSkipsWidth = Properties.Vehicle.Default.set_youSkipWidth;
            cboxpRowWidth.SelectedIndex = yt.rowSkipsWidth - 1;

            //default to come up in mini panel, exit remembers 

            SwapBatmanPanels();

            if (Properties.Settings.Default.setAS_isAutoSteerAutoOn) btnAutoSteer.Text = "A";
            else btnAutoSteer.Text = "M";

            //panelSim.Location = Settings.Default.setDisplay_panelSimLocation;

            FixPanelsAndMenus();

            layoutPanelRight.Enabled = false;
            //boundaryToolStripBtn.Enabled = false;
            toolStripBtnDropDownBoundaryTools.Enabled = false;

            if (isNTRIP_RequiredOn)
            {
                btnStartStopNtrip.Visible = true;
                lblNTRIPSeconds.Visible = true;
                lblWatch.Visible = true;
                NTRIPBytesMenu.Visible = true;
                pbarNtripMenu.Visible = true;
            }
            else
            {
                btnStartStopNtrip.Visible = false;
                lblNTRIPSeconds.Visible = false;
                lblWatch.Visible = false;
                NTRIPBytesMenu.Visible = false;
                pbarNtripMenu.Visible = false;
            }

            if (Properties.Settings.Default.setUDP_isOn)
            {
                pbarUDPComm.Visible = true;
                toolStripStatusLabel2.Visible = true;
            }
            else
            {
                pbarUDPComm.Visible = false;
                toolStripStatusLabel2.Visible = false;
            }

            if (hd.isOn) btnHeadlandOnOff.Image = Properties.Resources.HeadlandOn;
            else btnHeadlandOnOff.Image = Properties.Resources.HeadlandOff;

            isFullScreen = false;
        }        

        private void SwapDayNightMode()
        {
            isDay = !isDay;
            if (isDay)
            {
                btnDayNightMode.Image = Properties.Resources.WindowNightMode;

                this.BackColor = dayColor;
                foreach (Control c in this.Controls)
                {
                    //if (c is Label || c is Button)
                    {
                        c.ForeColor = Color.Black;
                    }
                }
                LineUpManualBtns();
            }
            else //nightmode
            {
                btnDayNightMode.Image = Properties.Resources.WindowDayMode;
                this.BackColor = nightColor;

                foreach (Control c in this.Controls)
                {
                    {
                        c.ForeColor = Color.White;
                    }
                }
                LineUpManualBtns();
            }

            Properties.Settings.Default.setDisplay_isDayMode = isDay;
            Properties.Settings.Default.Save();
        }

        private void FixPanelsAndMenus()
        {

            //if (panelSim.Left + 443 > Width - 200) panelSim.Left = Width - 200 - 443;
            //if (panelSim.Top < 80) panelSim.Top = 80;
            //if (panelSim.Top > Height - 150) panelSim.Top = Height - 150;


            //if (panelSim.Left < 75) panelSim.Left = 75;

            if (!isSimple)
            {
                steerChartTool.Visible = true;
                youTurnStripBtn.Visible = true;
                toolToolbottomStripBtn.Visible = true;
                vehicleToolStripBtn.Visible = true;
                steerChartTool.Visible = true;
                AutoSteerToolBtn.Visible = true;
                toolStripMenuRecPath.Visible = true;
                toolStripDropDownButton3.Visible = true;
                toolStripStatusLabel2.Visible = true;
                pbarUDPComm.Visible = true;
            }


            if (Width > 1100)
            {
                youTurnStripBtn.Visible = true;
                //ZoomExtentsStripBtn.Visible = true;
                //stripEqWidth.Visible = false;
            }
            else
            {
                youTurnStripBtn.Visible = false;
                //ZoomExtentsStripBtn.Visible = false;
                //stripEqWidth.Visible = false;
            }


            if (Width > 1200)
            {
                snapLeftBigStrip.Visible = true;
                snapRightBigStrip.Visible = true;
            }
            else
            {
                snapLeftBigStrip.Visible = false;
                snapRightBigStrip.Visible = false;
            }

            if (Width > 1400)
            {
                steerChartTool.Visible = true;
            }
            else
            {
                steerChartTool.Visible = false;
            }
            

            if (isSimple)
            {
                steerChartTool.Visible = false;
                youTurnStripBtn.Visible = false;
                toolToolbottomStripBtn.Visible = false;
                vehicleToolStripBtn.Visible = false;
                steerChartTool.Visible = false;
                AutoSteerToolBtn.Visible = false;
                toolStripMenuRecPath.Visible = false;
                toolStripDropDownButton3.Visible = false;
                toolStripStatusLabel2.Visible = false;
                pbarUDPComm.Visible = false;

            }
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
            return (" " +  gStr.gsLost + " ");
        }

        //hide the left panel
        public void SwapBatmanPanels()
        {
            //Properties.Settings.Default.Save();
            if (Properties.Settings.Default.setDisplay_isBatmanOn)
            {
                //Batman mini-panel shows
                //if (panelSim.Left < 390) panelSim.Left = 390;
                oglMain.Left = statusStripLeft.Width + panelBatman.Width;

                    if (isSimple)
                    {
                        oglMain.Width = Width - statusStripLeft.Width - panelBatman.Width - 112;
                    }
                    else
                        oglMain.Width = Width - statusStripLeft.Width - panelBatman.Width - 200;


                panelBatman.Left = statusStripLeft.Width;
                //tableLayoutPanelDisplay.Left = 181;
                //panelSim.Left = 350;
                panelFieldData.Width = oglMain.Width + panelBatman.Width+3;


                panelBatman.Visible = true;
                //statusStripLeft.Left = 8;
                panelSim.Left = 250;

                if (panelDrag.Visible) panelDrag.Left = statusStripLeft.Width + panelBatman.Width + 5;

                LineUpManualBtns();
            }
            else
            {
                //no side panel
                oglMain.Left = statusStripLeft.Width;
                if (isSimple)
                {
                    oglMain.Width = Width - (statusStripLeft.Width) - 112;
                }
                else
                    oglMain.Width = Width - (statusStripLeft.Width) - 202;
                panelBatman.Visible = false;
                
                panelSim.Left = 80;

                panelFieldData.Width = oglMain.Width+3;
                if (panelDrag.Visible) panelDrag.Left = statusStripLeft.Width + 10;

                LineUpManualBtns();
            }

        }

        //line up section On Off Auto buttons based on how many there are
        public void LineUpManualBtns()
        {
            int oglCenter = 0;

            if (panelBatman.Visible)
            {
                oglCenter = panelBatman.Width + statusStripLeft.Width + oglMain.Width/2;
            }

            else
            {
                oglCenter = statusStripLeft.Width + oglMain.Width / 2; 
            }

            int top = 180;
            if (panelSim.Visible == true) top = 230;

            btnSection1Man.Top  = Height - top;
            btnSection2Man.Top  = Height - top;
            btnSection3Man.Top  = Height - top;
            btnSection4Man.Top  = Height - top;
            btnSection5Man.Top  = Height - top;
            btnSection6Man.Top  = Height - top;
            btnSection7Man.Top  = Height - top;
            btnSection8Man.Top  = Height - top;
            btnSection9Man.Top  = Height - top;
            btnSection10Man.Top = Height - top;
            btnSection11Man.Top = Height - top;
            btnSection12Man.Top = Height - top;
            btnSection13Man.Top = Height - top;
            btnSection14Man.Top = Height - top;
            btnSection15Man.Top = Height - top;
            btnSection16Man.Top = Height - top;

            int oglButtonWidth = oglMain.Width * 3/4;
            //if (tool.numOfSections < 9 )  oglButtonWidth = oglMain.Width * 5/6;

            int buttonMaxWidth = 120, buttonHeight = 30;

            int buttonWidth = oglButtonWidth / tool.numOfSections;
            if (buttonWidth > buttonMaxWidth) buttonWidth = buttonMaxWidth;
            btnSection1Man.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnSection2Man.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnSection3Man.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnSection4Man.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnSection5Man.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnSection6Man.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnSection7Man.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnSection8Man.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnSection9Man.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnSection10Man.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnSection11Man.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnSection12Man.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnSection13Man.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnSection14Man.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnSection15Man.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            btnSection16Man.Size = new System.Drawing.Size(buttonWidth, buttonHeight);

            switch (tool.numOfSections)
            {
                case 1:
                    btnSection1Man.Left = (oglCenter) - btnSection1Man.Size.Width/2;
                    break;

                case 2:                    
                    btnSection1Man.Left = (oglCenter) - btnSection1Man.Size.Width;
                    btnSection2Man.Left = btnSection1Man.Left + btnSection1Man.Size.Width;
                    break;

                case 3:
                    btnSection1Man.Left = (oglCenter) - btnSection1Man.Size.Width/2 - btnSection1Man.Size.Width;
                    btnSection2Man.Left = btnSection1Man.Left + btnSection1Man.Size.Width;
                    btnSection3Man.Left = btnSection2Man.Left + btnSection1Man.Size.Width;
                    break;

                case 4:
                    btnSection1Man.Left = (oglCenter) - (tool.numOfSections * btnSection1Man.Size.Width) / 2;
                    btnSection2Man.Left = btnSection1Man.Left + btnSection1Man.Size.Width;
                    btnSection3Man.Left = btnSection2Man.Left + btnSection1Man.Size.Width;
                    btnSection4Man.Left = btnSection3Man.Left + btnSection1Man.Size.Width;

                    break;

                case 5:
                    btnSection1Man.Left = (oglCenter) - (tool.numOfSections * btnSection1Man.Size.Width) / 2;
                    btnSection2Man.Left = btnSection1Man.Left + btnSection1Man.Size.Width;
                    btnSection3Man.Left = btnSection2Man.Left + btnSection1Man.Size.Width;
                    btnSection4Man.Left = btnSection3Man.Left + btnSection1Man.Size.Width;
                    btnSection5Man.Left = btnSection4Man.Left + btnSection1Man.Size.Width;
                    break;

                case 6:
                    btnSection1Man.Left = (oglCenter) - (tool.numOfSections * btnSection1Man.Size.Width)/2;
                    btnSection2Man.Left = btnSection1Man.Left + btnSection1Man.Size.Width;
                    btnSection3Man.Left = btnSection2Man.Left + btnSection1Man.Size.Width;
                    btnSection4Man.Left = btnSection3Man.Left + btnSection1Man.Size.Width;
                    btnSection5Man.Left = btnSection4Man.Left + btnSection1Man.Size.Width;
                    btnSection6Man.Left = btnSection5Man.Left + btnSection1Man.Size.Width;
                    break;

                case 7:
                    btnSection1Man.Left = (oglCenter) - (tool.numOfSections * btnSection1Man.Size.Width) / 2;
                    btnSection2Man.Left = btnSection1Man.Left + btnSection1Man.Size.Width;
                    btnSection3Man.Left = btnSection2Man.Left + btnSection1Man.Size.Width;
                    btnSection4Man.Left = btnSection3Man.Left + btnSection1Man.Size.Width;
                    btnSection5Man.Left = btnSection4Man.Left + btnSection1Man.Size.Width;
                    btnSection6Man.Left = btnSection5Man.Left + btnSection1Man.Size.Width;
                    btnSection7Man.Left = btnSection6Man.Left + btnSection1Man.Size.Width;
                    break;

                case 8:
                    btnSection1Man.Left = (oglCenter) - (tool.numOfSections * btnSection1Man.Size.Width) / 2;
                    btnSection2Man.Left = btnSection1Man.Left + btnSection1Man.Size.Width;
                    btnSection3Man.Left = btnSection2Man.Left + btnSection1Man.Size.Width;
                    btnSection4Man.Left = btnSection3Man.Left + btnSection1Man.Size.Width;
                    btnSection5Man.Left = btnSection4Man.Left + btnSection1Man.Size.Width;
                    btnSection6Man.Left = btnSection5Man.Left + btnSection1Man.Size.Width;
                    btnSection7Man.Left = btnSection6Man.Left + btnSection1Man.Size.Width;
                    btnSection8Man.Left = btnSection7Man.Left + btnSection1Man.Size.Width;
                    break;

                case 9:
                    btnSection1Man.Left = (oglCenter) - (tool.numOfSections * btnSection1Man.Size.Width) / 2;
                    btnSection2Man.Left = btnSection1Man.Left + btnSection1Man.Size.Width;
                    btnSection3Man.Left = btnSection2Man.Left + btnSection1Man.Size.Width;
                    btnSection4Man.Left = btnSection3Man.Left + btnSection1Man.Size.Width;
                    btnSection5Man.Left = btnSection4Man.Left + btnSection1Man.Size.Width;
                    btnSection6Man.Left = btnSection5Man.Left + btnSection1Man.Size.Width;
                    btnSection7Man.Left = btnSection6Man.Left + btnSection1Man.Size.Width;
                    btnSection8Man.Left = btnSection7Man.Left + btnSection1Man.Size.Width;
                    btnSection9Man.Left = btnSection8Man.Left + btnSection1Man.Size.Width;
                    break;

                case 10:
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
                    break;

                case 11:
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
                    break;

                case 12:
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
                    break;
                case 13:
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
                    break;
                case 14:
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
                    break;
                case 15:
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
                    break;
                case 16:
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
                    break;
            }

            //if (isJobStarted)
            {
                switch (tool.numOfSections)
                {
                    case 1:
                        btnSection1Man.Visible = true;
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
                        break;

                    case 2:
                        btnSection1Man.Visible = true;
                        btnSection2Man.Visible = true;
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
                         btnSection12Man.Visible = false;
                         btnSection12Man.Visible = false;
                         btnSection12Man.Visible = false;
                         btnSection12Man.Visible = false;
                        break;

                    case 3:
                        btnSection1Man.Visible = true;
                        btnSection2Man.Visible = true;
                        btnSection3Man.Visible = true;
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
                        break;

                    case 4:
                        btnSection1Man.Visible = true;
                        btnSection2Man.Visible = true;
                        btnSection3Man.Visible = true;
                        btnSection4Man.Visible = true;
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
                        break;

                    case 5:
                        btnSection1Man.Visible = true;
                        btnSection2Man.Visible = true;
                        btnSection3Man.Visible = true;
                        btnSection4Man.Visible = true;
                        btnSection5Man.Visible = true;
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
                        break;

                    case 6:
                        btnSection1Man.Visible = true;
                        btnSection2Man.Visible = true;
                        btnSection3Man.Visible = true;
                        btnSection4Man.Visible = true;
                        btnSection5Man.Visible = true;
                        btnSection6Man.Visible = true;
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
                        break;

                    case 7:
                        btnSection1Man.Visible = true;
                        btnSection2Man.Visible = true;
                        btnSection3Man.Visible = true;
                        btnSection4Man.Visible = true;
                        btnSection5Man.Visible = true;
                        btnSection6Man.Visible = true;
                        btnSection7Man.Visible = true;
                        btnSection8Man.Visible = false;
                        btnSection9Man.Visible = false;
                         btnSection10Man.Visible = false;
                         btnSection11Man.Visible = false;
                         btnSection12Man.Visible = false;
                         btnSection13Man.Visible = false;
                         btnSection14Man.Visible = false;
                         btnSection15Man.Visible = false;
                         btnSection16Man.Visible = false;
                        break;

                    case 8:
                        btnSection1Man.Visible = true;
                        btnSection2Man.Visible = true;
                        btnSection3Man.Visible = true;
                        btnSection4Man.Visible = true;
                        btnSection5Man.Visible = true;
                        btnSection6Man.Visible = true;
                        btnSection7Man.Visible = true;
                        btnSection8Man.Visible = true;
                        btnSection9Man.Visible = false;
                         btnSection10Man.Visible = false;
                         btnSection11Man.Visible = false;
                         btnSection12Man.Visible = false;
                         btnSection13Man.Visible = false;
                         btnSection14Man.Visible = false;
                         btnSection15Man.Visible = false;
                         btnSection16Man.Visible = false;
                        break;

                    case 9:
                        btnSection1Man.Visible = true;
                        btnSection2Man.Visible = true;
                        btnSection3Man.Visible = true;
                        btnSection4Man.Visible = true;
                        btnSection5Man.Visible = true;
                        btnSection6Man.Visible = true;
                        btnSection7Man.Visible = true;
                        btnSection8Man.Visible = true;
                        btnSection9Man.Visible = true;
                         btnSection10Man.Visible = false;
                         btnSection11Man.Visible = false;
                         btnSection12Man.Visible = false;
                         btnSection13Man.Visible = false;
                         btnSection14Man.Visible = false;
                         btnSection15Man.Visible = false;
                         btnSection16Man.Visible = false;
                        break;

                    case 10:
                        btnSection1Man.Visible = true;
                        btnSection2Man.Visible = true;
                        btnSection3Man.Visible = true;
                        btnSection4Man.Visible = true;
                        btnSection5Man.Visible = true;
                        btnSection6Man.Visible = true;
                        btnSection7Man.Visible = true;
                        btnSection8Man.Visible = true;
                        btnSection9Man.Visible = true;
                         btnSection10Man.Visible = true;
                         btnSection11Man.Visible = false;
                         btnSection12Man.Visible = false;
                         btnSection13Man.Visible = false;
                         btnSection14Man.Visible = false;
                         btnSection15Man.Visible = false;
                         btnSection16Man.Visible = false;
                        break;

                    case 11:
                        btnSection1Man.Visible = true;
                        btnSection2Man.Visible = true;
                        btnSection3Man.Visible = true;
                        btnSection4Man.Visible = true;
                        btnSection5Man.Visible = true;
                        btnSection6Man.Visible = true;
                        btnSection7Man.Visible = true;
                        btnSection8Man.Visible = true;
                        btnSection9Man.Visible = true;
                         btnSection10Man.Visible = true;
                         btnSection11Man.Visible = true;
                         btnSection12Man.Visible = false;
                         btnSection13Man.Visible = false;
                         btnSection14Man.Visible = false;
                         btnSection15Man.Visible = false;
                         btnSection16Man.Visible = false;
                        break;

                    case 12:
                        btnSection1Man.Visible = true;
                        btnSection2Man.Visible = true;
                        btnSection3Man.Visible = true;
                        btnSection4Man.Visible = true;
                        btnSection5Man.Visible = true;
                        btnSection6Man.Visible = true;
                        btnSection7Man.Visible = true;
                        btnSection8Man.Visible = true;
                        btnSection9Man.Visible = true;
                         btnSection10Man.Visible = true;
                         btnSection11Man.Visible = true;
                         btnSection12Man.Visible = true;
                         btnSection13Man.Visible = false;
                         btnSection14Man.Visible = false;
                         btnSection15Man.Visible = false;
                         btnSection16Man.Visible = false;
                        break;

                    case 13:
                        btnSection1Man.Visible = true;
                        btnSection2Man.Visible = true;
                        btnSection3Man.Visible = true;
                        btnSection4Man.Visible = true;
                        btnSection5Man.Visible = true;
                        btnSection6Man.Visible = true;
                        btnSection7Man.Visible = true;
                        btnSection8Man.Visible = true;
                        btnSection9Man.Visible = true;
                         btnSection10Man.Visible = true;
                         btnSection11Man.Visible = true;
                         btnSection12Man.Visible = true;
                         btnSection13Man.Visible = true;
                         btnSection14Man.Visible = false;
                         btnSection15Man.Visible = false;
                         btnSection16Man.Visible = false;
                        break;

                    case 14:
                        btnSection1Man.Visible = true;
                        btnSection2Man.Visible = true;
                        btnSection3Man.Visible = true;
                        btnSection4Man.Visible = true;
                        btnSection5Man.Visible = true;
                        btnSection6Man.Visible = true;
                        btnSection7Man.Visible = true;
                        btnSection8Man.Visible = true;
                        btnSection9Man.Visible = true;
                         btnSection10Man.Visible = true;
                         btnSection11Man.Visible = true;
                         btnSection12Man.Visible = true;
                         btnSection13Man.Visible = true;
                         btnSection14Man.Visible = true;
                         btnSection15Man.Visible = false;
                         btnSection16Man.Visible = false;
                        break;

                    case 15:
                        btnSection1Man.Visible = true;
                        btnSection2Man.Visible = true;
                        btnSection3Man.Visible = true;
                        btnSection4Man.Visible = true;
                        btnSection5Man.Visible = true;
                        btnSection6Man.Visible = true;
                        btnSection7Man.Visible = true;
                        btnSection8Man.Visible = true;
                        btnSection9Man.Visible = true;
                         btnSection10Man.Visible = true;
                         btnSection11Man.Visible = true;
                         btnSection12Man.Visible = true;
                         btnSection13Man.Visible = true;
                         btnSection14Man.Visible = true;
                         btnSection15Man.Visible = true;
                         btnSection16Man.Visible = false;
                        break;

                    case 16:
                        btnSection1Man.Visible = true;
                        btnSection2Man.Visible = true;
                        btnSection3Man.Visible = true;
                        btnSection4Man.Visible = true;
                        btnSection5Man.Visible = true;
                        btnSection6Man.Visible = true;
                        btnSection7Man.Visible = true;
                        btnSection8Man.Visible = true;
                        btnSection9Man.Visible = true;
                         btnSection10Man.Visible = true;
                         btnSection11Man.Visible = true;
                         btnSection12Man.Visible = true;
                         btnSection13Man.Visible = true;
                         btnSection14Man.Visible = true;
                         btnSection15Man.Visible = true;
                         btnSection16Man.Visible = true;
                        break;
                }
            }
        }

        //force all the buttons same according to two main buttons
        private void ManualAllBtnsUpdate()
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
                    btn.BackColor = Color.Lime;
                    btn.ForeColor = Color.Black;
                    break;

                case manBtn.Auto:
                    section[sectNumber].manBtnState = manBtn.On;
                    btn.BackColor = Color.Yellow;
                    btn.ForeColor = Color.Black;
                    break;

                case manBtn.On:
                    section[sectNumber].manBtnState = manBtn.Off;
                    btn.ForeColor = Color.Black;
                    btn.BackColor = Color.Red;
                    break;
            }
        }
        
        //Function to delete flag
        private void DeleteSelectedFlag()
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

        private void DoNTRIPSecondRoutine()
        {
            //count up the ntrip clock only if everything is alive
            if (startCounter > 50 && recvCounter < 20 && isNTRIP_RequiredOn)
            {
                IncrementNTRIPWatchDog();
            }

            //Have we connection
            if (isNTRIP_RequiredOn && !isNTRIP_Connected && !isNTRIP_Connecting)
            {
                if (!isNTRIP_Starting && ntripCounter > 20)
                {
                    StartNTRIP();
                }
            }

            if (isNTRIP_Connecting)
            {
                if (ntripCounter > 28)
                {
                    TimedMessageBox(2000, gStr.gsSocketConnectionProblem, gStr.gsNotConnectingToCaster);
                    ReconnectRequest();
                }
                if (clientSocket != null && clientSocket.Connected)
                {
                    //TimedMessageBox(2000, "NTRIP Not Connected", " At the StartNTRIP() ");
                    //ReconnectRequest();
                    //return;
                    SendAuthorization();
                }

            }

            if (isNTRIP_RequiredOn)
            {
                //update byte counter and up counter
                if (ntripCounter > 59) lblNTRIPSeconds.Text = (ntripCounter / 60) + " Mins";
                else if (ntripCounter < 60 && ntripCounter > 22) lblNTRIPSeconds.Text = ntripCounter + " Secs";
                else lblNTRIPSeconds.Text = gStr.gsConnectingIn + " " + (Math.Abs(ntripCounter - 22));

                pbarNtripMenu.Value = unchecked((byte)(tripBytes * 0.02));
                NTRIPBytesMenu.Text = ((tripBytes) * 0.001).ToString("###,###,###") + " kb";

                //watchdog for Ntrip
                if (isNTRIP_Connecting) lblWatch.Text = gStr.gsAuthourizing;
                else
                {
                    if (NTRIP_Watchdog > 10) lblWatch.Text = gStr.gsWaiting;
                    else lblWatch.Text = gStr.gsListening;
                }

                if (sendGGAInterval > 0 && isNTRIP_Sending)
                {
                    lblWatch.Text = gStr.gsSendingGGA;
                    isNTRIP_Sending = false;
                }
            }
        }

        //Timer triggers at 10 msec, and is THE clock of the whole program
        //Timer stopped while parsing nmea
        private void tmrWatchdog_tick(object sender, EventArgs e)
        {

            //Check for a newline char, if none then just return
            int cr = pn.rawBuffer.IndexOf("\n", StringComparison.Ordinal);
            if (cr == -1) return;

            //go see if data ready for draw and position updates
            tmrWatchdog.Enabled = false;

            //did we get a new fix position?
            if (ScanForNMEA())
            {
                if (threeSecondCounter++ >= fixUpdateHz * 2)
                {
                    threeSecondCounter = 0;
                    threeSeconds++;
                }
                if (oneSecondCounter++ >= fixUpdateHz)
                {
                    oneSecondCounter = 0;
                    oneSecond++;
                }
                if (oneHalfSecondCounter++ >= fixUpdateHz / 2)
                {
                    oneHalfSecondCounter = 0;
                    oneHalfSecond++;
                }
                if (oneFifthSecondCounter++ >= fixUpdateHz / 5)
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

                    if (panelBatman.Visible)
                    {
                        if (isMetric)
                        {
                            lblAltitude.Text = Altitude;
                        }
                        else //imperial
                        {
                            lblAltitude.Text = AltitudeFeet;
                        }       
                        
                        lblSats.Text = SatsTracked;
                        lblZone.Text = pn.zone.ToString();
                    }

                    if (isMetric)
                    {
                        lblTotalFieldArea.Text = fd.AreaBoundaryLessInnersHectares;
                        lblTotalAppliedArea.Text = fd.WorkedHectares;
                        lblWorkRemaining.Text = fd.WorkedAreaRemainHectares;
                        lblPercentRemaining.Text = fd.WorkedAreaRemainPercentage;
                        lblTimeRemaining.Text = fd.TimeTillFinished;

                        lblAreaAppliedMinusOverlap.Text = ((fd.actualAreaCovered * glm.m2ha).ToString("N2"));
                        lblAreaMinusActualApplied.Text = (((fd.areaBoundaryOuterLessInner - fd.actualAreaCovered) * glm.m2ha).ToString("N2"));
                        lblOverlapPercent.Text = (fd.overlapPercent.ToString("N2")) + "%";
                        lblAreaOverlapped.Text = (((fd.workedAreaTotal - fd.actualAreaCovered) * glm.m2ha).ToString("N3"));

                        btnManualOffOn.Text = fd.AreaBoundaryLessInnersHectares;
                        //lblpAreaWorked.Text = fd.WorkedHectares;
                        //toolStripLblFieldFinish.Text = fd.WorkedAreaRemainPercentage + " \r\n" +
                        //    fd.WorkedAreaRemainHectares + " \r\n" + fd.TimeTillFinished;
                        //status strip values
                        lblEqSpec.Text = (Math.Round(tool.toolWidth, 2)).ToString() + " m  " + vehicleFileName + toolFileName;
                    }
                    else //imperial
                    {
                        btnManualOffOn.Text = fd.AreaBoundaryLessInnersAcres;
                        //lblpAreaWorked.Text = fd.WorkedAcres;
                        //toolStripLblFieldFinish.Text = fd.WorkedAreaRemainPercentage + " \r\n" +
                        //    fd.WorkedAreaRemainAcres + " \r\n" + fd.TimeTillFinished;
                        lblEqSpec.Text =  (Math.Round(tool.toolWidth * glm.m2ft, 2)).ToString() + " ft  " + vehicleFileName + toolFileName;
                    }

                    //not Metric/Standard units sensitive
                    if (ABLine.isBtnABLineOn) btnABLine.Text = "# " + PassNumber;
                    else btnABLine.Text = "";

                    if (curve.isBtnCurveOn) btnCurve.Text = "# " + CurveNumber;
                    else btnCurve.Text = "";


                    //update the online indicator 63 green red 64
                    if (recvCounter > 20 && toolStripBtnGPSStength.Image.Height != 64)
                    {
                        //stripOnlineGPS.Value = 1;
                        lblEasting.Text = "-";
                        lblNorthing.Text = gStr.gsNoGPS;
                        //lblZone.Text = "-";
                        toolStripBtnGPSStength.Image = Resources.GPSSignalPoor;
                    }
                    else if (recvCounter < 20 && toolStripBtnGPSStength.Image.Height != 63)
                    {
                        //stripOnlineGPS.Value = 100;
                        toolStripBtnGPSStength.Image = Resources.GPSSignalGood;
                    }

                }//end every 3 seconds

                //every second update all status ///////////////////////////   1 1 1 1 1 1 ////////////////////////////
                if (displayUpdateOneSecondCounter != oneSecond)
                {
                    //reset the counter
                    displayUpdateOneSecondCounter = oneSecond;

                    //counter used for saving field in background
                    saveCounter++;

                    if (ABLine.isBtnABLineOn && !ct.isContourBtnOn)
                    {
                        btnEditHeadingB.Text = ((int)(ABLine.moveDistance * 100)).ToString();
                    }
                    if (curve.isBtnCurveOn && !ct.isContourBtnOn)
                    {
                        btnEditHeadingB.Text = ((int)(curve.moveDistance * 100)).ToString();
                    }

                    if (mc.steerSwitchValue == 0)
                    {
                        this.AutoSteerToolBtn.BackColor = System.Drawing.Color.LightBlue;
                    }
                    else
                    {
                        this.AutoSteerToolBtn.BackColor = System.Drawing.Color.Transparent;
                    }

                    if (panelBatman.Visible)
                    {
                        //both
                        lblLatitude.Text = Latitude;
                        lblLongitude.Text = Longitude;

                        pbarAutoSteerComm.Value = pbarSteer;
                        pbarRelayComm.Value = pbarRelay;
                        pbarUDPComm.Value = pbarUDP;

                        lblRoll.Text = RollInDegrees;
                        lblYawHeading.Text = GyroInDegrees;
                        lblGPSHeading.Text = GPSHeading;

                        //up in the menu a few pieces of info
                        if (isJobStarted)
                        {
                            lblEasting.Text = "E:" + (pn.fix.easting).ToString("N2");
                            lblNorthing.Text = "N:" + (pn.fix.northing).ToString("N2");
                        }
                        else
                        {
                            lblEasting.Text = "E:" + (pn.actualEasting).ToString("N2");
                            lblNorthing.Text = "N:" + (pn.actualNorthing).ToString("N2");
                        }

                        lblUturnByte.Text = Convert.ToString(mc.autoSteerData[mc.sdYouTurnByte], 2).PadLeft(6, '0');
                    }
                    
                    //AutoSteerAuto button enable - Ray Bear inspired code - Thx Ray!
                    if (isJobStarted && ahrs.isAutoSteerAuto && !recPath.isDrivingRecordedPath && 
                        (ABLine.isABLineSet || ct.isContourBtnOn || curve.isCurveSet))
                    {
                        if (mc.steerSwitchValue == 0)
                        {
                            if (!isAutoSteerBtnOn) btnAutoSteer.PerformClick();
                        }
                        else
                        {
                            if ( isAutoSteerBtnOn) btnAutoSteer.PerformClick();
                        }
                    }

                    //Make sure it is off when it should
                    if ((!ABLine.isABLineSet && !ct.isContourBtnOn && !curve.isCurveSet && isAutoSteerBtnOn) || (recPath.isDrivingRecordedPath && isAutoSteerBtnOn)) btnAutoSteer.PerformClick();

                    //do all the NTRIP routines
                    DoNTRIPSecondRoutine();

                    //the main formgps window
                    if (isMetric)  //metric or imperial
                    {
                        //Hectares on the master section soft control and sections
                        btnSectionOffAutoOn.Text = fd.WorkedHectares;
                        lblSpeed.Text = SpeedKPH;

                        //status strip values
                        distanceToolBtn.Text = fd.DistanceUserMeters + "\r\n" + fd.WorkedUserHectares2;

                        btnContour.Text = XTE; //cross track error

                    }
                    else  //Imperial Measurements
                    {
                        //acres on the master section soft control and sections
                        btnSectionOffAutoOn.Text = fd.WorkedAcres;
                        lblSpeed.Text = SpeedMPH;

                        //status strip values
                        distanceToolBtn.Text = fd.DistanceUserFeet + "\r\n" + fd.WorkedUserAcres2;
                        btnContour.Text = InchXTE; //cross track error
                    }

                    //statusbar flash red undefined headland
                    if (mc.isOutOfBounds && statusStripBottom.BackColor == Color.Transparent
                        || !mc.isOutOfBounds && statusStripBottom.BackColor == Color.Tomato)
                    {
                        if (!mc.isOutOfBounds)
                        {
                            statusStripBottom.BackColor = Color.Transparent;
                        }
                        else
                        {
                            statusStripBottom.BackColor = Color.Tomato;
                        }
                    }

                }

                //every half of a second update all status  ////////////////    0.5  0.5   0.5    0.5    /////////////////
                if (displayUpdateHalfSecondCounter != oneHalfSecond)
                {
                    //reset the counter
                    displayUpdateHalfSecondCounter = oneHalfSecond;

                    if (hd.isOn)
                    {
                        //if (hd.isOn)
                        //lblUpDown.Text = hd.FindHeadlandDistance().ToString();
                        hd.FindHeadlandDistance();
                        if (hd.isToolUp)
                        {
                            lblHeadLeftDist.BackColor = Color.Salmon;
                            lblHeadRightDist.BackColor = Color.Salmon;
                        }
                        else
                        {
                            lblHeadLeftDist.BackColor = Color.LightSeaGreen;
                            lblHeadRightDist.BackColor = Color.LightSeaGreen;

                        }

                        lblHeadLeftDist.Text = hd.leftToolDistance.ToString("N2");
                        lblHeadRightDist.Text = hd.rightToolDistance.ToString("N2");
                    }

                    lblRightSpeed.Text = tool.toolFarRightSpeed.ToString("N2");
                    lblLeftSpeed.Text = tool.toolFarLeftSpeed.ToString("N2");
                    lblTrigger.Text = sectionTriggerStepDistance.ToString("N2");


                } //end every 1/2 second

                //every fifth second update  ///////////////////////////   FIFTH Fifth ////////////////////////////
                if (displayUpdateOneFifthCounter != oneFifthSecond)
                {
                    //reset the counter
                    displayUpdateOneFifthCounter = oneFifthSecond;

                    if (guidanceLineDistanceOff == 32020 | guidanceLineDistanceOff == 32000)
                    {
                        steerAnglesToolStripDropDownButton1.Text = "Off \r\n" + ActualSteerAngle;
                    }
                    else
                    {
                        steerAnglesToolStripDropDownButton1.Text = SetSteerAngle + "\r\n" + ActualSteerAngle;
                    }
                    lblHz.Text = NMEAHz + "Hz " + (int)(frameTime) + "\r\n" + FixQuality + HzTime.ToString("N1") + " Hz";
                    

                }

            } //there was a new GPS update

            //start timer again and wait for new fix
            tmrWatchdog.Enabled = true;

        }//wait till timer fires again.  

        #region Properties // ---------------------------------------------------------------------

        public string Zone { get { return Convert.ToString(pn.zone); } }
        public string FixNorthing { get { return Convert.ToString(Math.Round(pn.fix.northing + pn.utmNorth, 2)); } }
        public string FixEasting { get { return Convert.ToString(Math.Round(pn.fix.easting + pn.utmEast, 2)); } }
        public string Latitude { get { return Convert.ToString(Math.Round(pn.latitude, 7)); } }
        public string Longitude { get { return Convert.ToString(Math.Round(pn.longitude, 7)); } }

        public string SatsTracked { get { return Convert.ToString(pn.satellitesTracked); } }
        public string HDOP { get { return Convert.ToString(pn.hdop); } }
        public string NMEAHz { get { return Convert.ToString(fixUpdateHz); } }
        public string PassNumber { get { return Convert.ToString(ABLine.passNumber); } }
        public string CurveNumber { get { return Convert.ToString(curve.curveNumber); } }
        public string Heading { get { return Convert.ToString(Math.Round(glm.toDegrees(fixHeading), 1)) + "\u00B0"; } }
        public string GPSHeading { get { return (Math.Round(glm.toDegrees(gpsHeading), 1)) + "\u00B0"; } }
        public string Status { get { if (pn.status == "A") return "Active"; else return "Void"; } }
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
                if (ahrs.correctionHeadingX16 != 9999)
                    return Math.Round(ahrs.correctionHeadingX16 * 0.0625, 1) + "\u00B0";
                else return "-";
            }
        }
        public string RollInDegrees
        {
            get
            {
                if (ahrs.rollX16 != 9999)
                    return Math.Round((ahrs.rollX16 - ahrs.rollZeroX16) * 0.0625, 1) + "\u00B0";
                else return "-";
            }
        }
        public string SetSteerAngle { get { return ((double)(guidanceLineSteerAngle) * 0.01).ToString("N1") + "\u00B0"; } }
        public string ActualSteerAngle { get { return ((double)(actualSteerAngleDisp) * 0.01).ToString("N1") + "\u00B0"; } }

        public string FixHeading { get { return Math.Round(fixHeading, 4).ToString(); } }

        public string LookAhead { get { return ((int)(section[0].sectionLookAhead)).ToString(); } }
        public string StepFixNum { get { return (currentStepFix).ToString(); } }
        public string CurrentStepDistance { get { return Math.Round(distanceCurrentStepFix, 3).ToString(); } }
        public string TotalStepDistance { get { return Math.Round(fixStepDist, 3).ToString(); } }

        public string WorkSwitchValue { get { return mc.workSwitchValue.ToString(); } }
        public string AgeDiff { get { return pn.ageDiff.ToString(); } }

        //Metric and Imperial Properties
        public string SpeedMPH
        {
            get
            {
                double spd = 0;
                for (int c = 0; c < 10; c++) spd += avgSpeed[c];
                spd *= 0.0621371;
                return Convert.ToString(Math.Round(spd, 1));
            }
        }
        public string SpeedKPH
        {
            get
            {
                double spd = 0;
                for (int c = 0; c < 10; c++) spd += avgSpeed[c];
                spd *= 0.1;
                return Convert.ToString(Math.Round(spd, 1));
            }
        }

        public string XTE
        {
            get
            {
                //double spd = 0;
                //for (int c = 0; c < 20; c++) spd += avgXTE[c];
                //spd *= 0.1;
                //return ((int)(spd * 0.05) + " cm");
                return (crossTrackError/10 + gStr.gsCM);
            }
        }
        public string InchXTE
        {
            get
            {
                //double spd = 0;
                //for (int c = 0; c < 20; c++) spd += avgXTE[c];
                //spd *= 0.1;
                //return ((int)(spd * 0.019685) + " in");
                return ((int)(crossTrackError/25.54) + " in");
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