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

        // Buttons //-----------------------------------------------------------------------

        private void btnStartStopNtrip_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.setNTRIP_isOn)
            {
                if (isNTRIP_RequiredOn)
                {
                    ShutDownNTRIP();
                    btnStartStopNtrip.Text = gStr.gsStart;
                    lblWatch.Text = gStr.gsStopped;
                    lblNTRIPSeconds.Text = gStr.gsOffline;
                    isNTRIP_RequiredOn = false;
                }
                else
                {
                    isNTRIP_RequiredOn = true;
                    btnStartStopNtrip.Text = gStr.gsStop;
                    lblWatch.Text = gStr.gsWaiting;
                }
            }
            else
            {
                TimedMessageBox(2000, gStr.gsTurnONNtripClient, gStr.gsNTRIPClientNotSetUp);
            }
        }

        private void btnManualAutoDrive_Click(object sender, EventArgs e)
        {
            //if (isInAutoDrive)
            //{
            //    isInAutoDrive = false;
            //    btnManualAutoDrive.Image = Properties.Resources.Cancel64;
            //    btnManualAutoDrive.Text = gStr.gsManual;
            //}
            //else
            //{
            //    isInAutoDrive = true;
            //    btnManualAutoDrive.Image = Properties.Resources.OK64;
            //    btnManualAutoDrive.Text = gStr.gsAuto;
            //}
        }

        private void goPathMenu_Click(object sender, EventArgs e)
        {
            if (bnd.bndArr.Count == 0)
            {
                TimedMessageBox(2000, gStr.gsNoBoundary, gStr.gsCreateABoundaryFirst);
                return;
            }

            //if contour is on, turn it off
            if (ct.isContourBtnOn) { if (ct.isContourBtnOn) btnContour.PerformClick(); }
            //btnContourPriority.Enabled = true;

            if (yt.isYouTurnBtnOn) btnAutoYouTurn.PerformClick();
            if (isAutoSteerBtnOn) btnAutoSteer.PerformClick();

            DisableYouTurnButtons();

            //if ABLine isn't set, turn off the YouTurn
            if (ABLine.isABLineSet)
            {
                //ABLine.DeleteAB();
                ABLine.isABLineBeingSet = false;
                ABLine.isABLineSet = false;
                //lblDistanceOffLine.Visible = false;

                //change image to reflect on off
                btnABLine.Image = Properties.Resources.ABLineOff;
                ABLine.isBtnABLineOn = false;
            }

            if (curve.isCurveSet)
            {

                //make sure the other stuff is off
                curve.isOkToAddPoints = false;
                curve.isCurveSet = false;
                //btnContourPriority.Enabled = false;
                curve.isBtnCurveOn = false;
                btnCurve.Image = Properties.Resources.CurveOff;
            }

            if (!recPath.isPausedDrivingRecordedPath)
            {
                //already running?
                if (recPath.isDrivingRecordedPath)
                {
                    recPath.StopDrivingRecordedPath();
                    return;
                }

                //start the recorded path driving process



                if (!recPath.StartDrivingRecordedPath())
                {
                    //Cancel the recPath - something went seriously wrong
                    recPath.StopDrivingRecordedPath();
                    TimedMessageBox(1500, gStr.gsProblemMakingPath, gStr.gsCouldntGenerateValidPath);
                }
                else
                {
                    goPathMenu.Image = Properties.Resources.AutoStop;
                }
            }
            else
            {
                recPath.isPausedDrivingRecordedPath = false;
                pausePathMenu.BackColor = Color.Lime;
            }
        }

        private void PausePathMenu_Click(object sender, EventArgs e)
        {
            if (recPath.isPausedDrivingRecordedPath)
            {
                //btnPauseDrivingPath.BackColor = Color.Lime;
                pausePathMenu.BackColor = Color.Lime;
            }
            else
            {
                //btnPauseDrivingPath.BackColor = Color.OrangeRed;
                pausePathMenu.BackColor = Color.OrangeRed;
            }

            recPath.isPausedDrivingRecordedPath = !recPath.isPausedDrivingRecordedPath;

        }


        private void RecordPathMenu_Click(object sender, EventArgs e)
        {
            if (recPath.isRecordOn)
            {
                FileSaveRecPath();
                recPath.isRecordOn = false;
                recordPathMenu.Image = Properties.Resources.BoundaryRecord;
            }
            else if (isJobStarted)
            {
                recPath.recList.Clear();
                recPath.isRecordOn = true;
                recordPathMenu.Image = Properties.Resources.boundaryStop;
            }
        }

        private void DeletePathMenu_Click(object sender, EventArgs e)
        {
            recPath.recList.Clear();
            recPath.StopDrivingRecordedPath();
            FileSaveRecPath();

        }

        //LIDAR control
        private void btnAutoSteer_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Question.Play();

            //new direction so reset where to put turn diagnostic
            yt.ResetCreatedYouTurn();

            if (isAutoSteerBtnOn)
            {
                isAutoSteerBtnOn = false;
                btnAutoSteer.Image = Properties.Resources.AutoSteerOff;
                if (yt.isYouTurnBtnOn) btnAutoYouTurn.PerformClick();
            }
            else
            {
                if (ABLine.isBtnABLineOn | ct.isContourBtnOn | curve.isBtnCurveOn)
                {
                    isAutoSteerBtnOn = true;
                    btnAutoSteer.Image = Properties.Resources.AutoSteerOn;
                }
                else
                {
                    var form = new FormTimedMessage(2000,(gStr.gsNoGuidanceLines),(gStr.gsTurnOnContourOrMakeABLine));
                    form.Show();
                }
            }
        }

        private void BtnMakeLinesFromBoundary_Click(object sender, EventArgs e)
        {
            if (ct.isContourBtnOn)
            {
                var form = new FormTimedMessage(2000, (gStr.gsContourOn), (gStr.gsTurnOffContourFirst));
                form.Show();
                return;
            }

            if (bnd.bndArr.Count == 0)
            {
                TimedMessageBox(2000, gStr.gsNoBoundary, gStr.gsCreateABoundaryFirst);
                return;
            }

            GetAB();
        }
        private void btnCycleLines_Click(object sender, EventArgs e)
        {
            if (ABLine.isBtnABLineOn && ABLine.numABLines > 0)
            {
                ABLine.moveDistance = 0;

                ABLine.numABLineSelected++;
                if (ABLine.numABLineSelected > ABLine.numABLines) ABLine.numABLineSelected = 1;
                ABLine.refPoint1 = ABLine.lineArr[ABLine.numABLineSelected - 1].origin;
                //ABLine.refPoint2 = ABLine.lineArr[ABLine.numABLineSelected - 1].ref2;
                ABLine.abHeading = ABLine.lineArr[ABLine.numABLineSelected - 1].heading;
                ABLine.SetABLineByHeading();
                ABLine.isABLineSet = true;
                ABLine.isABLineLoaded = true;
                yt.ResetYouTurn();
                btnCycleLines.Text = "AB-" + ABLine.numABLineSelected;
                if (tram.displayMode > 0) ABLine.BuildTram();
            }
            else if (curve.isBtnCurveOn && curve.numCurveLines > 0)
            {
                curve.moveDistance = 0;

                curve.numCurveLineSelected++;
                if (curve.numCurveLineSelected > curve.numCurveLines) curve.numCurveLineSelected = 1;

                int idx = curve.numCurveLineSelected - 1;
                curve.aveLineHeading = curve.curveArr[idx].aveHeading;
                curve.refList?.Clear();
                for (int i = 0; i < curve.curveArr[idx].curvePts.Count; i++)
                {
                    curve.refList.Add(curve.curveArr[idx].curvePts[i]);
                }
                curve.isCurveSet = true;
                yt.ResetYouTurn();
                btnCycleLines.Text = "Cur-" + curve.numCurveLineSelected;
                if (tram.displayMode > 0) curve.BuildTram();
            }
        }


        private void btnABLine_Click(object sender, EventArgs e)
        {
            btnCycleLines.Text = "AB-" + ABLine.numABLineSelected;

            //check if window already exists
            Form f = Application.OpenForms["FormABCurve"];

            if (f != null)
            {
                f.Focus();
                return;
            }

            Form af = Application.OpenForms["FormABLine"];

            if (af != null)
            {
                af.Close();
                return;
            }


            //if contour is on, turn it off
            if (ct.isContourBtnOn) { if (ct.isContourBtnOn) btnContour.PerformClick(); }
            //btnContourPriority.Enabled = true;

            //make sure the other stuff is off
            curve.isOkToAddPoints = false;
                
            curve.isBtnCurveOn = false;
            btnCurve.Image = Properties.Resources.CurveOff;

            //if there is a line in memory, just use it.
            if (ABLine.isBtnABLineOn == false && ABLine.isABLineLoaded)
            {                
                ABLine.isABLineSet = true;
                EnableYouTurnButtons();
                btnABLine.Image = Properties.Resources.ABLineOn;
                ABLine.isBtnABLineOn = true;
                if (tram.displayMode > 0 ) ABLine.BuildTram();
                return;
            }
            
            //check if window already exists, return if true
            Form fc = Application.OpenForms["FormABLine"];

            if (fc != null)
            {
                fc.Focus();
                return;
            }

            //Bring up the form
            ABLine.isBtnABLineOn = true;
            btnABLine.Image = Properties.Resources.ABLineOn;

            //turn off youturn...
            //DisableYouTurnButtons();
            //yt.ResetYouTurn();

            var form = new FormABLine(this);
                form.Show();
        }

        private void btnCurve_Click(object sender, EventArgs e)
        {
            btnCycleLines.Text = "Cur-" + curve.numCurveLineSelected;

            //check if window already exists, return if true

            Form f = Application.OpenForms["FormABLine"];

            if (f != null)
            {
                f.Focus();
                return;
            }

            //check if window already exists
            Form cf = Application.OpenForms["FormABCurve"];

            if (cf != null)
            {
                cf.Close();
                return;
            }


            //if contour is on, turn it off
            if (ct.isContourBtnOn) { if (ct.isContourBtnOn) btnContour.PerformClick(); }

            //turn off ABLine 
            ABLine.isABLineBeingSet = false;
            ABLine.isABLineSet = false;
            //lblDistanceOffLine.Visible = false;

            //change image to reflect on off
            btnABLine.Image = Properties.Resources.ABLineOff;
            ABLine.isBtnABLineOn = false;

            //new direction so reset where to put turn diagnostic
            //yt.ResetCreatedYouTurn();

            if (curve.isBtnCurveOn == false && curve.isCurveSet)
            {
                //display the curve
                curve.isCurveSet = true;
                EnableYouTurnButtons();
                btnCurve.Image = Properties.Resources.CurveOn;
                curve.isBtnCurveOn = true;
                curve.BuildTram();
                return;
            }


            //check if window already exists
            Form fc = Application.OpenForms["FormABCurve"];

            if (fc != null)
            {
                fc.Focus();
                return;
            }

            curve.isBtnCurveOn = true;
            btnCurve.Image = Properties.Resources.CurveOn;

            EnableYouTurnButtons();
            //btnContourPriority.Enabled = true;

            Form form = new FormABCurve(this);
            form.Show();
        }

        private void btnContour_Click(object sender, EventArgs e)
        {
            ct.isContourBtnOn = !ct.isContourBtnOn;
            btnContour.Image = ct.isContourBtnOn ? Properties.Resources.ContourOn : Properties.Resources.ContourOff;

            if (ct.isContourBtnOn)
            {
                //turn off youturn...
                DisableYouTurnButtons();
                if (ct.isRightPriority)
                {
                    btnContourPriority.Image = Properties.Resources.ContourPriorityRight;
                }
                else
                {
                    btnContourPriority.Image = Properties.Resources.ContourPriorityLeft;
                }
            }

            else
            {
                if (ABLine.isBtnABLineOn | curve.isBtnCurveOn)
                {
                    EnableYouTurnButtons();
                }

                btnContourPriority.Image = Properties.Resources.Snap2;
            }
        }
        private void btnContourPriority_Click(object sender, EventArgs e)
        {
            if (ct.isContourBtnOn)
            {

                ct.isRightPriority = !ct.isRightPriority;

                if (ct.isRightPriority)
                {
                    btnContourPriority.Image = Properties.Resources.ContourPriorityRight;
                }
                else
                {
                    btnContourPriority.Image = Properties.Resources.ContourPriorityLeft;
                }
            }
            else
            {
                if (ABLine.isBtnABLineOn)
                {
                    ABLine.SnapABLine();
                }
                else if (curve.isBtnCurveOn)
                {
                    curve.SnapABCurve();
                }
                else
                {
                    var form = new FormTimedMessage(2000, (gStr.gsNoGuidanceLines), (gStr.gsTurnOnContourOrMakeABLine));
                    form.Show();
                }
            }
        }

        //Snaps
        private void SnapRight()
        {
            if (!ct.isContourBtnOn)
            {
                if (ABLine.isABLineSet)
                {
                    //snap distance is in cm
                    yt.ResetCreatedYouTurn();
                    double dist = 0.01 * Properties.Settings.Default.setAS_snapDistance;

                    ABLine.MoveABLine(dist);
                }
                else if (curve.isCurveSet)
                {
                    //snap distance is in cm
                    yt.ResetCreatedYouTurn();
                    double dist = 0.01 * Properties.Settings.Default.setAS_snapDistance;
                    curve.MoveABCurve(dist);

                }
                else
                {
                    var form = new FormTimedMessage(2000, (gStr.gsNoGuidanceLines), (gStr.gsTurnOnContourOrMakeABLine));
                    form.Show();
                }
            }

        }
        private void SnapLeft()
        {
            if (!ct.isContourBtnOn)
            {
                if (ABLine.isABLineSet)
                {
                    //snap distance is in cm
                    yt.ResetCreatedYouTurn();
                    double dist = 0.01 * Properties.Settings.Default.setAS_snapDistance;

                    ABLine.MoveABLine(-dist);

                    //FileSaveABLine();
                }
                else if (curve.isCurveSet)
                {
                    //snap distance is in cm
                    yt.ResetCreatedYouTurn();
                    double dist = 0.01 * Properties.Settings.Default.setAS_snapDistance;

                    curve.MoveABCurve(-dist);

                }
                else
                {
                    var form = new FormTimedMessage(2000, (gStr.gsNoGuidanceLines), (gStr.gsTurnOnContourOrMakeABLine));
                    form.Show();
                }
            }
        }

        private void btnSnapRight_Click(object sender, EventArgs e)
        {
            SnapRight();
        }
        private void btnSnapLeft_Click(object sender, EventArgs e)
        {
            SnapLeft();
        }


        //Section Manual and Auto
        private void btnManualOffOn_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Asterisk.Play();

            switch (manualBtnState)
            {
                case btnStates.Off:
                    manualBtnState = btnStates.On;
                    btnManualOffOn.Image = Properties.Resources.ManualOn;

                    //if Auto is on, turn it off
                    autoBtnState = btnStates.Off;
                    btnSectionOffAutoOn.Image = Properties.Resources.SectionMasterOff;

                    //turn all the sections allowed and update to ON!! Auto changes to ON
                    for (int j = 0; j < tool.numOfSections; j++)
                    {
                        section[j].isAllowedOn = true;
                        section[j].manBtnState = manBtn.Auto;
                    }

                    ManualAllBtnsUpdate();
                    break;

                case btnStates.On:
                    manualBtnState = btnStates.Off;
                    btnManualOffOn.Image = Properties.Resources.ManualOff;

                    //turn section buttons all OFF or Auto if SectionAuto was on or off
                    for (int j = 0; j < tool.numOfSections; j++)
                    {
                        section[j].isAllowedOn = false;
                        section[j].manBtnState = manBtn.On;
                    }

                    //Update the button colors and text
                    ManualAllBtnsUpdate();
                    break;
            }
        }
        private void btnSectionOffAutoOn_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Exclamation.Play();

            switch (autoBtnState)
            {
                case btnStates.Off:

                    autoBtnState = btnStates.Auto;
                    btnSectionOffAutoOn.Image = Properties.Resources.SectionMasterOn;

                    //turn off manual if on
                    manualBtnState = btnStates.Off;
                    btnManualOffOn.Image = Properties.Resources.ManualOff;

                    //turn all the sections allowed and update to ON!! Auto changes to ON
                    for (int j = 0; j < tool.numOfSections; j++)
                    {
                        section[j].isAllowedOn = true;
                        section[j].manBtnState = manBtn.Off;
                    }

                    ManualAllBtnsUpdate();
                    break;

                case btnStates.Auto:
                    autoBtnState = btnStates.Off;

                    btnSectionOffAutoOn.Image = Properties.Resources.SectionMasterOff;

                    //turn section buttons all OFF or Auto if SectionAuto was on or off
                    for (int j = 0; j < tool.numOfSections; j++)
                    {
                        section[j].isAllowedOn = false;
                        section[j].manBtnState = manBtn.On;
                    }

                    //Update the button colors and text
                    ManualAllBtnsUpdate();
                    break;
            }
        }

        //individual buttons for sections
        private void btnSection1Man_Click(object sender, EventArgs e)
        {
            if (autoBtnState != btnStates.Auto)
            {
                //if auto is off just have on-off for choices of section buttons
                if (section[0].manBtnState == manBtn.Off) section[0].manBtnState = manBtn.Auto;
                ManualBtnUpdate(0, btnSection1Man);
                return;
            }

            ManualBtnUpdate(0, btnSection1Man);
        }
        private void btnSection2Man_Click(object sender, EventArgs e)
        {
            //if auto is off just have on-off for choices of section buttons
            if (autoBtnState != btnStates.Auto)
            {
                if (section[1].manBtnState == manBtn.Off) section[1].manBtnState = manBtn.Auto;
                ManualBtnUpdate(1, btnSection2Man);
                return;
            }

            ManualBtnUpdate(1, btnSection2Man);
        }
        private void btnSection3Man_Click(object sender, EventArgs e)
        {
            //if auto is off just have on-off for choices of section buttons
            if (autoBtnState != btnStates.Auto)
            {
                if (section[2].manBtnState == manBtn.Off) section[2].manBtnState = manBtn.Auto;
                ManualBtnUpdate(2, btnSection3Man);
                return;
            }

            ManualBtnUpdate(2, btnSection3Man);
        }
        private void btnSection4Man_Click(object sender, EventArgs e)
        {
            //if auto is off just have on-off for choices of section buttons
            if (autoBtnState != btnStates.Auto)
            {
                if (section[3].manBtnState == manBtn.Off) section[3].manBtnState = manBtn.Auto;
                ManualBtnUpdate(3, btnSection4Man);
                return;
            }
            ManualBtnUpdate(3, btnSection4Man);
        }
        private void btnSection5Man_Click(object sender, EventArgs e)
        {
            //if auto is off just have on-off for choices of section buttons
            if (autoBtnState != btnStates.Auto)
            {
                if (section[4].manBtnState == manBtn.Off) section[4].manBtnState = manBtn.Auto;
                ManualBtnUpdate(4, btnSection5Man);
                return;
            }

            ManualBtnUpdate(4, btnSection5Man);
        }
        private void btnSection6Man_Click(object sender, EventArgs e)
        {
            //if auto is off just have on-off for choices of section buttons
            if (autoBtnState != btnStates.Auto)
            {
                if (section[5].manBtnState == manBtn.Off) section[5].manBtnState = manBtn.Auto;
                ManualBtnUpdate(5, btnSection6Man);
                return;
            }

            ManualBtnUpdate(5, btnSection6Man);
        }
        private void btnSection7Man_Click(object sender, EventArgs e)
        {
            //if auto is off just have on-off for choices of section buttons
            if (autoBtnState != btnStates.Auto)
            {
                if (section[6].manBtnState == manBtn.Off) section[6].manBtnState = manBtn.Auto;
                ManualBtnUpdate(6, btnSection7Man);
                return;
            }

            ManualBtnUpdate(6, btnSection7Man);
        }
        private void btnSection8Man_Click(object sender, EventArgs e)
        {
            //if auto is off just have on-off for choices of section buttons
            if (autoBtnState != btnStates.Auto)
            {
                if (section[7].manBtnState == manBtn.Off) section[7].manBtnState = manBtn.Auto;
                ManualBtnUpdate(7, btnSection8Man);
                return;
            }

            ManualBtnUpdate(7, btnSection8Man);
        }
        private void btnSection9Man_Click(object sender, EventArgs e)
        {
            //if auto is off just have on-off for choices of section buttons
            if (autoBtnState != btnStates.Auto)
            {
                if (section[8].manBtnState == manBtn.Off) section[8].manBtnState = manBtn.Auto;
                ManualBtnUpdate(8, btnSection9Man);
                return;
            }

            ManualBtnUpdate(8, btnSection9Man);

        }
        private void btnSection10Man_Click(object sender, EventArgs e)
        {
            //if auto is off just have on-off for choices of section buttons
            if (autoBtnState != btnStates.Auto)
            {
                if (section[9].manBtnState == manBtn.Off) section[9].manBtnState = manBtn.Auto;
                ManualBtnUpdate(9, btnSection10Man);
                return;
            }

            ManualBtnUpdate(9, btnSection10Man);

        }
        private void btnSection11Man_Click(object sender, EventArgs e)
        {
            //if auto is off just have on-off for choices of section buttons
            if (autoBtnState != btnStates.Auto)
            {
                if (section[10].manBtnState == manBtn.Off) section[10].manBtnState = manBtn.Auto;
                ManualBtnUpdate(10, btnSection11Man);
                return;
            }

            ManualBtnUpdate(10, btnSection11Man);

        }
        private void btnSection12Man_Click(object sender, EventArgs e)
        {
            //if auto is off just have on-off for choices of section buttons
            if (autoBtnState != btnStates.Auto)
            {
                if (section[11].manBtnState == manBtn.Off) section[11].manBtnState = manBtn.Auto;
                ManualBtnUpdate(11, btnSection12Man);
                return;
            }

            ManualBtnUpdate(11, btnSection12Man);
        }
        private void btnSection13Man_Click(object sender, EventArgs e)
        {
            //if auto is off just have on-off for choices of section buttons
            if (autoBtnState != btnStates.Auto)
            {
                if (section[12].manBtnState == manBtn.Off) section[12].manBtnState = manBtn.Auto;
                ManualBtnUpdate(12, btnSection13Man);
                return;
            }

            ManualBtnUpdate(12, btnSection13Man);

        }
        private void btnSection14Man_Click(object sender, EventArgs e)
        {
            //if auto is off just have on-off for choices of section buttons
            if (autoBtnState != btnStates.Auto)
            {
                if (section[13].manBtnState == manBtn.Off) section[13].manBtnState = manBtn.Auto;
                ManualBtnUpdate(13, btnSection14Man);
                return;
            }

            ManualBtnUpdate(13, btnSection14Man);

        }
        private void btnSection15Man_Click(object sender, EventArgs e)
        {
            //if auto is off just have on-off for choices of section buttons
            if (autoBtnState != btnStates.Auto)
            {
                if (section[14].manBtnState == manBtn.Off) section[14].manBtnState = manBtn.Auto;
                ManualBtnUpdate(14, btnSection15Man);
                return;
            }

            ManualBtnUpdate(14, btnSection15Man);
        }
        private void btnSection16Man_Click(object sender, EventArgs e)
        {
            //if auto is off just have on-off for choices of section buttons
            if (autoBtnState != btnStates.Auto)
            {
                if (section[15].manBtnState == manBtn.Off) section[15].manBtnState = manBtn.Auto;
                ManualBtnUpdate(15, btnSection16Man);
                return;
            }

            ManualBtnUpdate(15, btnSection16Man);
        }













        //The zoom tilt buttons
        private void btnZoomIn_MouseDown(object sender, MouseEventArgs e)
        {
            if (camera.zoomValue <= 20) camera.zoomValue += camera.zoomValue * 0.1;
            else camera.zoomValue += camera.zoomValue * 0.05;
            if (camera.zoomValue > 220) camera.zoomValue = 220;
            camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
            SetZoom();
        }
        private void btnZoomOut_MouseDown(object sender, MouseEventArgs e)
        {
            if (camera.zoomValue <= 20)
            { if ((camera.zoomValue -= camera.zoomValue * 0.1) < 6.0) camera.zoomValue = 6.0; }
            else { if ((camera.zoomValue -= camera.zoomValue * 0.05) < 6.0) camera.zoomValue = 6.0; }
            camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
            SetZoom();
        }
        private void btnpTiltUp_MouseDown(object sender, MouseEventArgs e)
        {
            camera.camPitch -= ((camera.camPitch * 0.012) - 1);
            if (camera.camPitch > -58) camera.camPitch = 0;
        }
        private void btnpTiltDown_MouseDown(object sender, MouseEventArgs e)
        {
            if (camera.camPitch > -59) camera.camPitch = -60;
            camera.camPitch += ((camera.camPitch * 0.012) - 1);
            if (camera.camPitch < -85) camera.camPitch = -85;
        }
        private void btnMoveDown_MouseDown(object sender, MouseEventArgs e)
        {
            offX += (Math.Sin(fixHeading) * 10);
            offY += (Math.Cos(fixHeading) * 10);
        }
        private void btnMoveUp_MouseDown(object sender, MouseEventArgs e)
        {
            offX -= (Math.Sin(fixHeading) * 10);
            offY -= (Math.Cos(fixHeading) * 10);
        }
        private void btnMoveLeft_MouseDown(object sender, MouseEventArgs e)
        {
            offY += (Math.Sin(-fixHeading) * 10);
            offX += (Math.Cos(-fixHeading) * 10);
        }
        private void btnMoveRight_MouseDown(object sender, MouseEventArgs e)
        {
            offY -= (Math.Sin(-fixHeading) * 10);
            offX -= (Math.Cos(-fixHeading) * 10);
        }
        private void btnMoveHome_Click(object sender, EventArgs e)
        {
            offX = 0;
            offY = 0;
        }

        //
        private void btnSaveAB_Click(object sender, EventArgs e)
        {
            if (ABLine.isBtnABLineOn)
            {
                //index to last one.
                int idx = ABLine.numABLineSelected - 1;

                if (idx >= 0)
                {
                    ABLine.lineArr[idx].heading = ABLine.abHeading;
                    //calculate the new points for the reference line and points
                    ABLine.lineArr[idx].origin.easting = ABLine.refPoint1.easting;
                    ABLine.lineArr[idx].origin.northing = ABLine.refPoint1.northing;

                    //sin x cos z for endpoints, opposite for additional lines
                    ABLine.lineArr[idx].ref1.easting = ABLine.lineArr[idx].origin.easting - (Math.Sin(ABLine.lineArr[idx].heading) * 2000.0);
                    ABLine.lineArr[idx].ref1.northing = ABLine.lineArr[idx].origin.northing - (Math.Cos(ABLine.lineArr[idx].heading) * 2000.0);
                    ABLine.lineArr[idx].ref2.easting = ABLine.lineArr[idx].origin.easting + (Math.Sin(ABLine.lineArr[idx].heading) * 2000.0);
                    ABLine.lineArr[idx].ref2.northing = ABLine.lineArr[idx].origin.northing + (Math.Cos(ABLine.lineArr[idx].heading) * 2000.0);
                }

                FileSaveABLines();
                ABLine.moveDistance = 0;
            }

            if (curve.isBtnCurveOn)
            {
                if (curve.refList.Count > 0)
                {
                    //array number is 1 less since it starts at zero
                    int idx = curve.numCurveLineSelected - 1;

                    //curve.curveArr[idx].Name = textBox1.Text.Trim();
                    if (idx >= 0)
                    {
                        curve.curveArr[idx].aveHeading = curve.aveLineHeading;
                        curve.curveArr[idx].curvePts.Clear();
                        //write out the Curve Points
                        foreach (var item in curve.refList)
                        {
                            curve.curveArr[idx].curvePts.Add(item);
                        }
                    }

                    //save entire list
                    FileSaveCurveLines();
                    curve.moveDistance = 0;
                }
            }
        }

        private void btnEditAB_Click(object sender, EventArgs e)
        {
            //if (isAutoSteerBtnOn) btnAutoSteer.PerformClick();

            Form fc = Application.OpenForms["FormEditAB"];

            if (fc != null)
            {
                fc.Focus();
                return;
            }

            if (ABLine.numABLineSelected > 0 && ABLine.isBtnABLineOn)
            {
                Form form = new FormEditAB(this);
                form.Show();
            }
            else if (curve.numCurveLineSelected > 0 && curve.isBtnCurveOn)
            {
                Form form = new FormEditCurve(this);
                form.Show();
            }
            else
            {
                var form = new FormTimedMessage(1500, gStr.gsNoABLineActive, gStr.gsPleaseEnterABLine);
                return;
            }
        }
        private void btnTramMenu_Click(object sender, EventArgs e)
        {
            curve.isOkToAddPoints = false;

            if (ct.isContourBtnOn) { if (ct.isContourBtnOn) btnContour.PerformClick(); }

            if (ABLine.numABLineSelected > 0 && ABLine.isBtnABLineOn)
            {
                Form form99 = new FormTram(this);
                form99.Show();
                form99.Left = Width - 275;
                form99.Top = 100;
            }
            else if (curve.numCurveLineSelected > 0 && curve.isBtnCurveOn)
            {
                Form form97 = new FormTramCurve(this);
                form97.Show();
                form97.Left = Width - 275;
                form97.Top = 100;
            }
            else
            {
                var form = new FormTimedMessage(1500, gStr.gsNoABLineActive, gStr.gsPleaseEnterABLine);
                form.Show();
                layoutPanelRight.Enabled = true;
                ABLine.isEditing = false;
                return;
            }
        }
        private void btnFlag_Click(object sender, EventArgs e)
        {
            int nextflag = flagPts.Count + 1;
            CFlag flagPt = new CFlag(pn.latitude, pn.longitude, pn.fix.easting, pn.fix.northing, flagColor, nextflag);
            flagPts.Add(flagPt);
            FileSaveFlags();
        }
        private void btnAutoYouTurn_Click(object sender, EventArgs e)
        {
            yt.isTurnCreationTooClose = false;

            if (bnd.bndArr.Count == 0)
            {
                TimedMessageBox(2000, gStr.gsNoBoundary, gStr.gsCreateABoundaryFirst);
                return;
            }

            if (!yt.isYouTurnBtnOn)
            {
                //new direction so reset where to put turn diagnostic
                yt.ResetCreatedYouTurn();

                if (!isAutoSteerBtnOn) return;
                yt.isYouTurnBtnOn = true;
                yt.isTurnCreationTooClose = false;
                yt.isTurnCreationNotCrossingError = false;
                yt.ResetYouTurn();
                //mc.autoSteerData[mc.sdX] = 0;
                mc.machineControlData[mc.cnYouTurn] = 0;
                btnAutoYouTurn.Image = Properties.Resources.Youturn80;
            }
            else
            {
                yt.isYouTurnBtnOn = false;
                yt.rowSkipsWidth = Properties.Vehicle.Default.set_youSkipWidth;
                btnAutoYouTurn.Image = Properties.Resources.YouTurnNo;
                yt.ResetYouTurn();

                //new direction so reset where to put turn diagnostic
                yt.ResetCreatedYouTurn();

                //mc.autoSteerData[mc.sdX] = 0;
                mc.machineControlData[mc.cnYouTurn] = 0;
            }
        }

        //Mouse Clicks 
        private void oglMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //0 at bottom for opengl, 0 at top for windows, so invert Y value
                Point point = oglMain.PointToClient(Cursor.Position);

                //label3.Text = point.X.ToString();

                if (point.Y < 120 && point.Y > 50)
                {
                    int middle = oglMain.Width / 2 + oglMain.Width / 5;
                    if (point.X > middle - 60 && point.X < middle + 60)
                    {
                        SwapDirection();
                        return;
                    }

                    middle = oglMain.Width / 2 - oglMain.Width / 4;
                    if (point.X > middle - 80 && point.X < middle)
                    {
                        if (yt.isYouTurnTriggered)
                        {
                            yt.ResetYouTurn();
                        }
                        else
                        {
                            if (yt.isYouTurnBtnOn) btnAutoYouTurn.PerformClick();
                            yt.isYouTurnTriggered = true;
                            yt.BuildManualYouTurn(false, true);
                            return;
                        }
                    }

                    if (point.X > middle && point.X < middle + 80)
                    {
                        if (yt.isYouTurnTriggered)
                        {
                            yt.ResetYouTurn();
                        }
                        else
                        {
                            if (yt.isYouTurnBtnOn) btnAutoYouTurn.PerformClick();
                            yt.isYouTurnTriggered = true;
                            yt.BuildManualYouTurn(true, true);
                            return;
                        }
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
               
        public void EnableYouTurnButtons()
        {
            yt.ResetYouTurn();

            yt.isYouTurnBtnOn = false;
            btnAutoYouTurn.Enabled = true;
            btnAutoYouTurn.Image = Properties.Resources.YouTurnNo;
        }
        public void DisableYouTurnButtons()
        {

            btnAutoYouTurn.Enabled = false;
            yt.isYouTurnBtnOn = false;
            btnAutoYouTurn.Image = Properties.Resources.YouTurnNo;
            yt.ResetYouTurn();
        }

        //Options
        private void cboxpRowWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            yt.rowSkipsWidth = cboxpRowWidth.SelectedIndex + 1;
            yt.ResetCreatedYouTurn();
            Properties.Vehicle.Default.set_youSkipWidth = yt.rowSkipsWidth;
            Properties.Vehicle.Default.Save();
        }

        // Menu Items ------------------------------------------------------------------
        private void boundariesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                using (var form = new FormBoundary(this))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Form form2 = new FormBoundaryPlayer(this);
                        form2.Show();
                    }
                }
            }
            else { TimedMessageBox(3000, gStr.gsFieldNotOpen, gStr.gsStartNewField); }
        }

        private void toolStripBtnMakeBndContour_Click_1(object sender, EventArgs e)
        {
            //build all the contour guidance lines from boundaries, all of them.
            using (var form = new FormMakeBndCon(this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) { }
            }
        }

        private void deleteContourPathsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //FileCreateContour();
            ct.stripList?.Clear();
            ct.ptList?.Clear();
            ct.ctList?.Clear();
            contourSaveList?.Clear();
        }

        private void fileExplorerToolStripItem_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                FileSaveFlagsKML();
            }
            Process.Start(fieldsDirectory + currentFieldDirectory);
        }

        private void toolStripDeleteApplied_Click(object sender, EventArgs e)
        {
            //FileCreateContour();
            ct.stripList?.Clear();
            ct.ptList?.Clear();
            ct.ctList?.Clear();
            contourSaveList?.Clear();
        }

        private void toolStripAreYouSure_Click_1(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                DialogResult result3 = MessageBox.Show(gStr.gsDeleteAllContoursAndSections,
                    gStr.gsDeleteForSure,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (result3 == DialogResult.Yes)
                {
                    FileCreateContour();
                    FileCreateSections();
                    //FileCreateElevation();

                    //turn auto button off
                    autoBtnState = btnStates.Off;
                    btnSectionOffAutoOn.Image = Properties.Resources.SectionMasterOff;

                    //turn section buttons all OFF and zero square meters
                    for (int j = 0; j < MAXSECTIONS; j++)
                    {
                        section[j].isAllowedOn = false;
                        section[j].manBtnState = manBtn.On;
                    }

                    //turn manual button off
                    manualBtnState = btnStates.Off;
                    btnManualOffOn.Image = Properties.Resources.ManualOff;

                    //Update the button colors and text
                    ManualAllBtnsUpdate();

                    //enable disable manual buttons
                    LineUpManualBtns();

                    //clear out the contour Lists
                    ct.StopContourLine(pivotAxlePos);
                    ct.ResetContour();
                    fd.workedAreaTotal = 0;

                    //clear the section lists
                    for (int j = 0; j < MAXSECTIONS; j++)
                    {
                        //clean out the lists
                        section[j].patchList?.Clear();
                        section[j].triangleList?.Clear();
                    }
                    patchSaveList?.Clear();
                }
                else TimedMessageBox(1500, gStr.gsNothingDeleted, gStr.gsActionHasBeenCancelled);
            }
        }

        private void boundaryToolStripBtn_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                using (var form = new FormBoundary(this))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Form form2 = new FormBoundaryPlayer(this);
                        form2.Show();
                    }
                }
            }
            else { TimedMessageBox(3000, gStr.gsFieldNotOpen, gStr.gsStartNewField); }
        }

        private void toolStripBtnField_Click(object sender, EventArgs e)
        {
            JobNewOpenResume();
        }

        private void SmoothABtoolStripMenu_Click(object sender, EventArgs e)
        {
            if (isJobStarted && curve.isBtnCurveOn)
            {
                using (var form = new FormSmoothAB(this))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK) { }
                }
            }
            else
            {
                if (!isJobStarted) TimedMessageBox(2000, gStr.gsFieldNotOpen, gStr.gsStartNewField);
                else TimedMessageBox(2000, gStr.gsCurveNotOn, gStr.gsTurnABCurveOn);
            }
        }

        private void toolstripDisplayConfig_Click_1(object sender, EventArgs e)
        {
            using (var form = new FormIMU(this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) { }
            }

            if (Properties.Settings.Default.setAS_isAutoSteerAutoOn) btnAutoSteer.Text = "A";
            else btnAutoSteer.Text = "M";
        }

        private void toolstripUSBPortsConfig_Click_1(object sender, EventArgs e)
        {
            SettingsCommunications();
        }

        private void toolstripUDPConfig_Click_1(object sender, EventArgs e)
        {
            SettingsUDP();
        }

        private void toolStripNTRIPConfig_Click_1(object sender, EventArgs e)
        {
            SettingsNTRIP();
        }

        private void toolstripVehicleConfig_Click_1(object sender, EventArgs e)
        {
            using (var form = new FormSettings(this, 0))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (Properties.Settings.Default.setAS_isAutoSteerAutoOn) btnAutoSteer.Text = "A";
                    else btnAutoSteer.Text = "M";
                }
            }
        }

        private void toolstripYouTurnConfig_Click_1(object sender, EventArgs e)
        {
            var form = new FormYouTurn(this);
            form.ShowDialog();
            cboxpRowWidth.SelectedIndex = yt.rowSkipsWidth - 1;
        }

        private void toolstripAutoSteerConfig_Click_1(object sender, EventArgs e)
        {
            //check if window already exists
            Form fc = Application.OpenForms["FormSteer"];

            if (fc != null)
            {
                fc.Focus();
                return;
            }

            //
            Form form = new FormSteer(this);
            form.Show();
        }

        private void toolStripAutoSteerChart_Click_1(object sender, EventArgs e)
        {
            //check if window already exists
            Form fcg = Application.OpenForms["FormSteerGraph"];

            if (fcg != null)
            {
                fcg.Focus();
                return;
            }

            //
            Form formG = new FormSteerGraph(this);
            formG.Show();
        }

        private void twoDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            camera.camFollowing = true;
            camera.camPitch = 0;
        }

        private void threeDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            camera.camFollowing = true;
            camera.camPitch = -70;
        }

        private void northToolStripMenuItem_Click(object sender, EventArgs e)
        {
            camera.camFollowing = false;
            camera.camPitch = 0;
        }
        private void dNorthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            camera.camPitch = -70;
            camera.camFollowing = false;
        }

        private void toolStripDropDownButtonDistance_Click(object sender, EventArgs e)
        {
            fd.distanceUser = 0;
            fd.workedAreaTotalUser = 0;
        }

        private void toolStripBatman_Click_1(object sender, EventArgs e)
        {
        }

        private void toolStripBtnPower_ButtonClick(object sender, EventArgs e)
        {
            DialogResult result3 = MessageBox.Show(gStr.gsOff,
                                gStr.gsWaiting,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2);
            if (result3 == DialogResult.Yes) Close();
        }
        
        private void googleEarthFlagsToolStrip_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                //save new copy of flags
                FileSaveFlagsKML();

                //Process.Start(@"C:\Program Files (x86)\Google\Google Earth\client\googleearth", workingDirectory + currentFieldDirectory + "\\Flags.KML");
                Process.Start(fieldsDirectory + currentFieldDirectory + "\\Flags.KML");
            }
            else
            {
                var form = new FormTimedMessage(1500, gStr.gsFieldNotOpen, gStr.gsStartNewField);
                form.Show();
            }
        }

        private void treePlantToolStrip_Click(object sender, EventArgs e)
        {
            //check if window already exists
            Form fc = Application.OpenForms["FormTreePlant"];

            if (fc != null)
            {
                fc.Focus();
                return;
            }

            //
            Form form = new FormTreePlant(this);
            form.Show();
        }

        private void webcamToolStrip_Click(object sender, EventArgs e)
        {
            Form form = new FormWebCam();
            form.Show();
        }

        private void offsetFixToolStrip_Click(object sender, EventArgs e)
        {
            using (var form = new FormShiftPos(this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) { }
            }
        }

        private void AutoSteerToolBtn_Click(object sender, EventArgs e)
        {
            //check if window already exists
            Form fc = Application.OpenForms["FormSteer"];

            if (fc != null)
            {
                fc.Focus();
                fc.Close();
                return;
            }

            //
            Form form = new FormSteer(this);
            form.Show();
        }

        private void vehicleToolStripBtn_Click(object sender, EventArgs e)
        {
            using (var form = new FormSettings(this, 0))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (Properties.Settings.Default.setAS_isAutoSteerAutoOn) btnAutoSteer.Text = "A";
                    else btnAutoSteer.Text = "M";
                }
            }
        }

        private void youTurnStripBtn_Click(object sender, EventArgs e)
        {
            var form = new FormYouTurn(this);
            form.ShowDialog();
            cboxpRowWidth.SelectedIndex = yt.rowSkipsWidth - 1;
        }

        private void toolStripBtnGPSStength_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormGPSData"];

            if (f != null)
            {
                f.Focus();
                f.Close();
                return;
            }

            Form form = new FormGPSData(this);
            form.Show();
        }

        private void toolStripBtnDrag_ButtonClick(object sender, EventArgs e)
        {
            if (panelDrag.Visible)
            {
                offX = 0;
                offY = 0;
                panelDrag.Visible = false;
            }
            else
            {
                panelDrag.Top = 80;
                panelDrag.Left = 76;
                panelDrag.Visible = true;
            }
        }

        private void ZoomExtentsStripBtn_Click(object sender, EventArgs e)
        {
            if (camera.camSetDistance < -400) camera.camSetDistance = -75;
            else camera.camSetDistance = -3 * maxFieldDistance;
            if (camera.camSetDistance == 0) camera.camSetDistance = -2000;
            SetZoom();
        }

        private void topFieldViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings.Default.setMenu_isOGLZoomOn == 1)
            {
                Settings.Default.setMenu_isOGLZoomOn = 0;
                Settings.Default.Save();
                topFieldViewToolStripMenuItem.Checked = false;
                oglZoom.Width = 400;
                oglZoom.Height = 400;
                oglZoom.SendToBack();
            }
            else
            {
                Settings.Default.setMenu_isOGLZoomOn = 1;
                Settings.Default.Save();
                topFieldViewToolStripMenuItem.Checked = true;
                oglZoom.Visible = true;
                oglZoom.Width = 300;
                oglZoom.Height = 300;
                oglZoom.Left = 80;
                oglZoom.Top = 80;
                if (isJobStarted) oglZoom.BringToFront();
            }
        }


        //File drop down items
        private void setWorkingDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show();
                return;
            }

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            fbd.Description = "Currently: " + Settings.Default.setF_workingDirectory;

            if (Settings.Default.setF_workingDirectory == "Default") fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else fbd.SelectedPath = Settings.Default.setF_workingDirectory;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AgOpenGPS",true);

                if (fbd.SelectedPath != Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
                {
                    //save the user set directory in Registry
                    regKey.SetValue("Directory", fbd.SelectedPath);
                    regKey.Close();
                    Settings.Default.setF_workingDirectory = fbd.SelectedPath;
                    Settings.Default.Save();
                }
                else
                {
                    regKey.SetValue("Directory", "Default");
                    regKey.Close();
                    Settings.Default.setF_workingDirectory = "Default";
                    Settings.Default.Save();
                }

                //restart program
                MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
                Close();
            }
        }
        private void enterSimCoordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = DialogResult.Cancel;
            using (var form = new FormSimCoords(this))
            {
                result = form.ShowDialog();
            }

            if (result == DialogResult.OK)
            {
                MessageBox.Show(gStr.gsProgramWillExitPleaseRestart, gStr.gsProgramWillExitPleaseRestart);
                if (isJobStarted) JobClose();
                Application.Exit();
            }
        }


        //Help menu drop down items
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new Form_About())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) { }
            }
        }

        //Shortcut keys
        private void shortcutKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new FormShortcutKeys())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) { }
            }
        }

        //Options Drop down menu items
        private void resetALLToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                MessageBox.Show(gStr.gsCloseFieldFirst);
            }
            else
            {
                DialogResult result2 = MessageBox.Show(gStr.gsReallyResetEverything, gStr.gsResetAll,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result2 == DialogResult.Yes)
                {
                    Settings.Default.Reset();
                    Settings.Default.Save();

                    Vehicle.Default.Reset();
                    Vehicle.Default.Save();
                    MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
                    Application.Exit();
                }
            }
        }
        private void logNMEAMenuItem_Click(object sender, EventArgs e)
        {
            isLogNMEA = !isLogNMEA;
            logNMEAToolStripMenuItem.Checked = isLogNMEA;
            Settings.Default.setMenu_isLogNMEA = isLogNMEA;
            Settings.Default.Save();
        }
        private void lightbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isLightbarOn = !isLightbarOn;
            lightbarToolStripMenuItem.Checked = isLightbarOn;
            Settings.Default.setMenu_isLightbarOn = isLightbarOn;
            Settings.Default.Save();
        }
        private void polygonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isDrawPolygons = !isDrawPolygons;
            polygonsOnToolStripMenuItem.Checked = !polygonsOnToolStripMenuItem.Checked;
        }
        private void gridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isGridOn = !isGridOn;
            gridOnToolStripMenuItem.Checked = isGridOn;
            Settings.Default.setMenu_isGridOn = isGridOn;
            Settings.Default.Save();
        }
        private void sideGuideLines_Click(object sender, EventArgs e)
        {
            isSideGuideLines = !isSideGuideLines;
            extraGuidesToolStripMenuItem.Checked = isSideGuideLines;
            Settings.Default.setMenu_isSideGuideLines = isSideGuideLines;
            Settings.Default.Save();
        }
        private void pursuitLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isPureDisplayOn = !isPureDisplayOn;
            pursuitOnToolStripMenuItem.Checked = isPureDisplayOn;
            Settings.Default.setMenu_isPureOn = isPureDisplayOn;
            Settings.Default.Save();
        }
        private void metricToolStrip_Click(object sender, EventArgs e)
        {
            metricToolStrip.Checked = true;
            imperialToolStrip.Checked = false;
            isMetric = true;
            Settings.Default.setMenu_isMetric = isMetric;
            Settings.Default.Save();
            lblSpeedUnits.Text = gStr.gsKMH;
        }
        private void skyToolStripMenu_Click(object sender, EventArgs e)
        {
            isSkyOn = !isSkyOn;
            skyOnToolStripMenuItem.Checked = isSkyOn;

            Settings.Default.setMenu_isSkyOn = isSkyOn;
            Settings.Default.Save();
        }
        private void imperialToolStrip_Click(object sender, EventArgs e)
        {
            metricToolStrip.Checked = false;
            imperialToolStrip.Checked = true;
            isMetric = false;
            Settings.Default.setMenu_isMetric = isMetric;
            Settings.Default.Save();
            lblSpeedUnits.Text = gStr.gsMPH;
        }
        private void simulatorOnToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (sp.IsOpen)
            {
                simulatorOnToolStripMenuItem.Checked = false;
                panelSim.Visible = false;
                timerSim.Enabled = false;

                TimedMessageBox(2000, gStr.gsGPSConnected, gStr.gsSimulatorForcedOff);
            }
            else
            {
                if (isJobStarted)
                {
                    TimedMessageBox(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                    return;
                }
                if (simulatorOnToolStripMenuItem.Checked)
                {
                    panelSim.Visible = true;
                    timerSim.Enabled = true;
                    DialogResult result3 = MessageBox.Show(gStr.gsAgOpenGPSWillExitPlzRestart, gStr.gsTurningOnSimulator ,MessageBoxButtons.OK);
                    Application.Exit();

                }
                else
                {
                    panelSim.Visible = false;
                    timerSim.Enabled = false;
                    //TimedMessageBox(3000, "Simulator Turning Off", "Application will Exit");
                    DialogResult result3 = MessageBox.Show(gStr.gsAgOpenGPSWillExitPlzRestart, gStr.gsTurningOffSimulator, MessageBoxButtons.OK);
                    Application.Exit();
                }
            }

            Settings.Default.setMenu_isSimulatorOn = simulatorOnToolStripMenuItem.Checked;
            Settings.Default.Save();
            LineUpManualBtns();
        }
        private void uTurnAlwaysOnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isUTurnAlwaysOn = !isUTurnAlwaysOn;
            uTurnAlwaysOnToolStripMenuItem.Checked = isUTurnAlwaysOn;
            Settings.Default.setMenu_isUTurnAlwaysOn = isUTurnAlwaysOn;
            Settings.Default.Save();
        }
        private void compassOnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isCompassOn = !isCompassOn;
            compassOnToolStripMenuItem.Checked = isCompassOn;
            Settings.Default.setMenu_isCompassOn = isCompassOn;
            Settings.Default.Save();
        }
        private void speedoOnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isSpeedoOn = !isSpeedoOn;
            speedoOnToolStripMenuItem.Checked = isSpeedoOn;
            Settings.Default.setMenu_isSpeedoOn = isSpeedoOn;
            Settings.Default.Save();
        }


        //setting color off Options Menu
        private void sectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog
            {
                FullOpen = true,
                AnyColor = true,
                SolidColorOnly = false,
                Color = Settings.Default.setDisplay_colorSections
            };

            if (colorDlg.ShowDialog() != DialogResult.OK) return;

            sectionColor = colorDlg.Color;

            Settings.Default.setDisplay_colorSections = sectionColor;
            Settings.Default.Save();

        }
        private void fieldToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //color picker for fields

            ColorDialog colorDlg = new ColorDialog
            {
                FullOpen = true,
                AnyColor = true,
                SolidColorOnly = false,
                Color = Settings.Default.setDisplay_colorField
            };

            if (colorDlg.ShowDialog() != DialogResult.OK) return;

            fieldColor = colorDlg.Color;

            Settings.Default.setDisplay_colorField = fieldColor;
            Settings.Default.Save();
        }

        private void dayModeToolStrip_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog
            {
                FullOpen = true,
                AnyColor = true,
                SolidColorOnly = true,
                Color = Properties.Settings.Default.setDisplay_colorDayMode
            };

            if (colorDlg.ShowDialog() != DialogResult.OK) return;

            dayColor = colorDlg.Color;

            Properties.Settings.Default.setDisplay_colorDayMode = dayColor;
                Settings.Default.Save();
            isDay = false;
            SwapDayNightMode();

        }

        private void nightModeToolStrip_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog
            {
                FullOpen = true,
                AnyColor = true,
                SolidColorOnly = true,
                Color = Properties.Settings.Default.setDisplay_colorNightMode
            };

            if (colorDlg.ShowDialog() != DialogResult.OK) return;

            nightColor = colorDlg.Color;

            Properties.Settings.Default.setDisplay_colorNightMode = nightColor;
            Settings.Default.Save();
            isDay = true;
            SwapDayNightMode();


        }




        //The flag context menus
        private void toolStripMenuItemFlagRed_Click(object sender, EventArgs e)
        {
            flagColor = 0;
            btnFlag.Image = Properties.Resources.FlagRed;
        }
        private void toolStripMenuGrn_Click(object sender, EventArgs e)
        {
            flagColor = 1;
            btnFlag.Image = Properties.Resources.FlagGrn;
        }
        private void toolStripMenuYel_Click(object sender, EventArgs e)
        {
            flagColor = 2;
            btnFlag.Image = Properties.Resources.FlagYel;
        }
        private void toolStripMenuFlagDelete_Click(object sender, EventArgs e)
        {
            //delete selected flag and set selected to none
            DeleteSelectedFlag();
            FileSaveFlags();
        }
        private void toolStripMenuFlagDeleteAll_Click(object sender, EventArgs e)
        {
            flagNumberPicked = 0;
            flagPts.Clear();
            FileSaveFlags();
        }
        private void contextMenuStripFlag_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            toolStripMenuFlagDelete.Enabled = flagNumberPicked != 0;

            toolStripMenuFlagDeleteAll.Enabled = flagPts.Count > 0;
        }


        //OpenGL Window context Menu and functions
        private void deleteFlagToolOpenGLContextMenu_Click(object sender, EventArgs e)
        {
            //delete selected flag and set selected to none
            DeleteSelectedFlag();
            FileSaveFlags();
        }
        private void contextMenuStripOpenGL_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //dont bring up menu if no flag selected
            if (flagNumberPicked == 0) e.Cancel = true;
        }
        private void googleEarthOpenGLContextMenu_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                //save new copy of kml with selected flag and view in GoogleEarth
                FileSaveSingleFlagKML(flagNumberPicked);

                //Process.Start(@"C:\Program Files (x86)\Google\Google Earth\client\googleearth", workingDirectory + currentFieldDirectory + "\\Flags.KML");
                Process.Start(fieldsDirectory + currentFieldDirectory + "\\Flag.KML");
            }
        }

        //taskbar buttons    
        
        private void toolstripVR_Click(object sender, EventArgs e)
        {
            if (!isJobStarted)
            {
                TimedMessageBox(1000, gStr.gsFieldNotOpen, gStr.gsStartNewField);
                return;
            }

            //if (bnd.bndArr[0].isSet && (ABLine.isABLineSet | curve.isCurveSet))
            //{
            //    //field too small
            //    //if (bnd.bndArr[0].bndLine.Count < 4) { TimedMessageBox(3000, "!!!!", gStr.gsBoundaryTooSmall); return; }
            //    //using (var form = new FormHeadland(this))
            //    //{
            //    //    var result = form.ShowDialog();
            //    //    if (result == DialogResult.OK)
            //    //    {

            //    //    }
            //    //}
            //}
            //else { TimedMessageBox(3000, gStr.gsBoundaryNotSet, gStr.gsCreateBoundaryFirst); }
            //TimedMessageBox(1500, "Headlands not Implemented", "Some time soon they will be functional");
        }

        //Sim controls
        private void timerSim_Tick(object sender, EventArgs e)
        {
            //if a GPS is connected disable sim
            if (!sp.IsOpen)
            {
                if (isAutoSteerBtnOn && (guidanceLineDistanceOff != 32000)) sim.DoSimTick(guidanceLineSteerAngle * 0.01);
                else if (recPath.isDrivingRecordedPath) sim.DoSimTick(guidanceLineSteerAngle * 0.01);
                //else if (self.isSelfDriving) sim.DoSimTick(guidanceLineSteerAngle * 0.01);
                else sim.DoSimTick(sim.steerAngleScrollBar);
            }
        }
        private void hsbarSteerAngle_Scroll(object sender, ScrollEventArgs e)
        {
            sim.steerAngleScrollBar = (hsbarSteerAngle.Value - 300) * 0.1;
            btnResetSteerAngle.Text = sim.steerAngleScrollBar.ToString("N1");
        }
        private void hsbarStepDistance_Scroll(object sender, ScrollEventArgs e)
        {
            sim.stepDistance = ((double)(hsbarStepDistance.Value)) / 10.0 / (double)fixUpdateHz;
        }
        private void btnResetSteerAngle_Click(object sender, EventArgs e)
        {
            sim.steerAngleScrollBar = 0;
            hsbarSteerAngle.Value = 300;
            btnResetSteerAngle.Text = sim.steerAngleScrollBar.ToString("N1");
        }
        private void btnResetSim_Click(object sender, EventArgs e)
        {
            sim.latitude = Properties.Settings.Default.setGPS_SimLatitude;
            sim.longitude = Properties.Settings.Default.setGPS_SimLongitude;
        }

        //Languages
        private void menuLanguageEnglish_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show();
                return;
            }
            SetLanguage("en");
            MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
            Close();

        }
        private void menuLanguageDeutsch_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show();
                return;
            }
            SetLanguage("de");
            MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
            Close();

        }
        private void menuLanguageRussian_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show();
                return;
            }
            SetLanguage("ru");
            MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
            Close();
        }
        private void menuLanguageDutch_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show();
                return;
            }
            SetLanguage("nl");
            MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
            Close();
        }
        private void menuLanguageSpanish_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show();
                return;
            }
            SetLanguage("es");
            MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
            Close();
        }
        private void menuLanguageFrench_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show();
                return;
            }
            SetLanguage("fr");
            MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
            Close();
        }
        private void menuLanguageItalian_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show();
                return;
            }
            SetLanguage("it");
            MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
            Close();
        }
        private void SetLanguage(string lang)
        {
            //reset them all to false
            menuLanguageEnglish.Checked = false;
            menuLanguageDeutsch.Checked = false;
            menuLanguageRussian.Checked = false;
            menuLanguageDutch.Checked = false;
            menuLanguageSpanish.Checked = false;
            menuLanguageFrench.Checked = false;
            menuLanguageItalian.Checked = false;

            switch (lang)
            {
                case "en":
                    menuLanguageEnglish.Checked = true;
                    break;

                case "ru":
                    menuLanguageRussian.Checked = true;
                    break;

                case "de":
                    menuLanguageDeutsch.Checked = true;
                    break;

                case "nl":
                    menuLanguageDutch.Checked = true;
                    break;

                case "it":
                    menuLanguageItalian.Checked = true;
                    break;

                case "es":
                    menuLanguageSpanish.Checked = true;
                    break;

                case "fr":
                    menuLanguageFrench.Checked = true;
                    break;
            }

            //adding or editing "Language" subkey to the "SOFTWARE" subkey  
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AgOpenGPS");

            //storing the values  
            key.SetValue("Language", lang);
            key.Close();
        }

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
    }//end class
}//end namespace