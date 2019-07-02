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
        private byte redSections, grnSections, bluSections;
        public byte redField, grnField, bluField;
        public byte flagColor = 0;

        //how many cm off line per big pixel
        public int lightbarCmPerPixel;

        //polygon mode for section drawing
        private bool isDrawPolygons;

        //Is it in 2D or 3D, metric or imperial, display lightbar, display grid etc
        public bool isIn3D = true, isMetric = true, isLightbarOn = true, isGridOn, isSideGuideLines = true;
        public bool isPureDisplayOn = true, isSkyOn = true, isBigAltitudeOn = false;

        //master Manual and Auto, 3 states possible
        public enum btnStates { Off, Auto, On }
        public btnStates manualBtnState = btnStates.Off;
        public btnStates autoBtnState = btnStates.Off;

        //section button states
        public enum manBtn { Off, Auto, On }

        private void LoadGUI()
        {
            //set the language to last used
            SetLanguage(Settings.Default.set_culture);

            //set the flag mark button to red dot
            btnFlag.Image = Properties.Resources.FlagRed;

            //metric settings
            isMetric = Settings.Default.setMenu_isMetric;
            metricToolStrip.Checked = isMetric;

            if (isMetric)
            {
                lblSpeedUnits.Text = "kmh";
                metricToolStrip.Checked = true;
                imperialToolStrip.Checked = false;
                //lblFlowLeft.Text = "LPM"; lblFlowRight.Text = "LPM";
            }
            else
            {
                lblSpeedUnits.Text = "mph";
                metricToolStrip.Checked = false;
                imperialToolStrip.Checked = true;
                //lblFlowLeft.Text = "GPM"; lblFlowRight.Text = "GPM";

            }

            //load up colors
            redField = (Settings.Default.setF_FieldColorR);
            grnField = (Settings.Default.setF_FieldColorG);
            bluField = (Settings.Default.setF_FieldColorB);

            redSections = Settings.Default.setF_SectionColorR;
            grnSections = Settings.Default.setF_SectionColorG;
            bluSections = Settings.Default.setF_SectionColorB;

            //turn off the turn signals lol
            btnRightYouTurn.Visible = false;
            btnLeftYouTurn.Visible = false;

            //rate control button
            btnDualRate.Text = gStr.gsOff;
            if (isMetric)
            {
                btnSelectRate1.Text = Math.Round(rcd.rateLeft,1).ToString();
                btnSelectRate2.Text = Math.Round(rcd.rateRight,1).ToString();
            }
            else
            {
                btnSelectRate1.Text = (rcd.rateLeft * glm.LHa2galAc).ToString("N1");
                btnSelectRate2.Text = (rcd.rateRight * glm.LHa2galAc).ToString("N1");
            }

            if (rcd.isSingleFlowMeter)
            {
                //btnSelectSingleDualMeter.Image = Resources.FlowMeterSingle;
            }
            else
            {
               // btnSelectSingleDualMeter.Image = Resources.FlowMeterDual;
            }

            //area side settings
            isAreaOnRight = Settings.Default.setMenu_isAreaRight;
            toolStripMenuAreaSide.Checked = isAreaOnRight;

            //set up grid and lightbar
            isGridOn = Settings.Default.setMenu_isGridOn;
            gridToolStripMenuItem.Checked = isGridOn;

            //log NMEA 
            isLogNMEA = Settings.Default.setMenu_isLogNMEA;
            logNMEAMenuItem.Checked = isLogNMEA;

            isLightbarOn = Settings.Default.setMenu_isLightbarOn;
            lightbarToolStripMenuItem.Checked = isLightbarOn;

            isSideGuideLines = Settings.Default.setMenu_isSideGuideLines;
            sideGuideLines.Checked = isSideGuideLines;

            isPureDisplayOn = Settings.Default.setMenu_isPureOn;
            pursuitLineToolStripMenuItem.Checked = isPureDisplayOn;

            isSkyOn = Settings.Default.setMenu_isSkyOn;
            skyToolStripMenu.Checked = isSkyOn;

            simulatorOnToolStripMenuItem.Checked = Settings.Default.setMenu_isSimulatorOn;
            if (simulatorOnToolStripMenuItem.Checked)
            {
                panelSimControls.Visible = true;
                timerSim.Enabled = true;
            }
            else
            {
                panelSimControls.Visible = false;
                timerSim.Enabled = false;
            }

            LineUpManualBtns();
            tabControl1.SelectedIndex = 3;

            yt.rowSkipsWidth = Properties.Vehicle.Default.set_youSkipWidth;
            cboxpRowWidth.SelectedIndex = yt.rowSkipsWidth - 1;

            //default to come up in mini panel, exit remembers 

            SwapBatmanPanels();
            SwapBatmanPanels();

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
        }

        //hide the left panel
        public void SwapBatmanPanels()
        {
            if (Properties.Settings.Default.setDisplay_isLargePanel)
            {
                //Batman mini-panel shows
                panelSimControls.Left = 245;
                oglMain.Left = 240;
                oglMain.Width = Width - 240 - 102;
                btnpTiltDown.Left = 245;
                btnpTiltUp.Left = 245;
                btnZoomIn.Left = 245;
                btnZoomOut.Left = 245;
                btnZoomExtents.Left = 245;
                cboxpRowWidth.Left = 245;
                txtDistanceOffABLine.Left = (Width - 245-100)/2 + 185;
                panelBatman.Visible = true;
                tabControl1.Visible = false;
                Properties.Settings.Default.setDisplay_isLargePanel = false;
                Properties.Settings.Default.Save();
                LineUpManualBtns();
            }
            else
            {
                //Big tab will be visible
                panelSimControls.Left = 345;
                oglMain.Left = 340;
                oglMain.Width = Width - 340 - 102;
                btnpTiltDown.Left = 345;
                btnpTiltUp.Left = 345;
                btnZoomIn.Left = 345;
                btnZoomOut.Left = 345;
                btnZoomExtents.Left = 345;
                cboxpRowWidth.Left = 345;
                txtDistanceOffABLine.Left = (Width - 345 - 100)/2 + 287;
                txtDistanceOffABLine.Top = -1;
                tabControl1.SelectedIndex = 3;
                panelBatman.Visible = false;
                tabControl1.Visible = true;
                Properties.Settings.Default.setDisplay_isLargePanel = true;
                Properties.Settings.Default.Save();
                LineUpManualBtns();

            }
        }

        //line up section On Off Auto buttons based on how many there are
        public void LineUpManualBtns()
        {
            if (tabControl1.Visible)
            {
                btnRightYouTurn.Left = (Width - 440) / 2 + 475;
                btnLeftYouTurn.Left = (Width - 440) / 2 + 115;
            }
            else
            {
                btnRightYouTurn.Left = (Width-340) / 2 + 362;
                btnLeftYouTurn.Left = (Width-340) / 2 + 10;
            }

            int top = 0;
            if (panelSimControls.Visible == true)
            {
                top = 190;
                if (vehicle.numOfSections > 8) top = 230;
            }
            else{
                top = 140;
                if (vehicle.numOfSections > 8) top = 180;
            }

            btnSection1Man.Top = Height - top;
            btnSection2Man.Top = Height - top;
            btnSection3Man.Top = Height - top;
            btnSection4Man.Top = Height - top;
            btnSection5Man.Top = Height - top;
            btnSection6Man.Top = Height - top;
            btnSection7Man.Top = Height - top;
            btnSection8Man.Top = Height - top;

            int first2Thirds;
            if (tabControl1.Visible) first2Thirds = (Width - 535) / 2 + 385;
            else first2Thirds = (Width-395) / 2 + 260;

            int even = 60;
            int offset = 7;

            switch (vehicle.numOfSections)
            {
                case 1:
                    btnSection1Man.Left = (first2Thirds) - 20;
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
                    break;

                case 2:
                    btnSection1Man.Left = (first2Thirds)+ offset - even;
                    btnSection2Man.Left = (first2Thirds)+ offset + 0;
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
                    break;

                case 3:
                    btnSection1Man.Left = (first2Thirds) - 80;
                    btnSection2Man.Left = (first2Thirds) - 20;
                    btnSection3Man.Left = (first2Thirds) + 40;
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
                    break;

                case 4:
                    btnSection1Man.Left = (first2Thirds)+ offset - even*2;
                    btnSection2Man.Left = (first2Thirds)+ offset - even;
                    btnSection3Man.Left = (first2Thirds)+ offset + 0;
                    btnSection4Man.Left = (first2Thirds)+ offset + even;
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
                    break;

                case 5:
                    btnSection1Man.Left = (first2Thirds) - 140;
                    btnSection2Man.Left = (first2Thirds) - 80;
                    btnSection3Man.Left = (first2Thirds) - 20;
                    btnSection4Man.Left = (first2Thirds) + 40;
                    btnSection5Man.Left = (first2Thirds) + 100;
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
                    break;

                case 6:
                    btnSection1Man.Left = (first2Thirds)+ offset - even*3;
                    btnSection2Man.Left = (first2Thirds)+ offset - even*2;
                    btnSection3Man.Left = (first2Thirds)+ offset - even;
                    btnSection4Man.Left = (first2Thirds)+ offset + 0;
                    btnSection5Man.Left = (first2Thirds)+ offset+ even;
                    btnSection6Man.Left = (first2Thirds) + offset + even*2;
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
                    break;

                case 7:
                    btnSection1Man.Left = (first2Thirds) - 200;
                    btnSection2Man.Left = (first2Thirds) - 140;
                    btnSection3Man.Left = (first2Thirds) - 80;
                    btnSection4Man.Left = (first2Thirds) - 20;
                    btnSection5Man.Left = (first2Thirds) + 40;
                    btnSection6Man.Left = (first2Thirds) + 100;
                    btnSection7Man.Left = (first2Thirds) + 160;
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

                    break;

                case 8:
                    btnSection1Man.Left = (first2Thirds)+ offset - even*4;           //390;
                    btnSection2Man.Left = (first2Thirds)+ offset - even*3;           //290;
                    btnSection3Man.Left = (first2Thirds)+ offset - even*2;           //190;
                    btnSection4Man.Left = (first2Thirds)+ offset - even;           //90;
                    btnSection5Man.Left = (first2Thirds)+ offset + 0;           //10;
                    btnSection6Man.Left = (first2Thirds)+ offset + even;           //110;
                    btnSection7Man.Left = (first2Thirds)+ offset + even*2;           //210;
                    btnSection8Man.Left = (first2Thirds)+ offset + even*3;           //310;
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
                    break;

                case 9:
                    btnSection1Man.Top = Height - top;
                    btnSection2Man.Top = Height - top;
                    btnSection3Man.Top = Height - top + 42;
                    btnSection4Man.Top = Height - top;
                    btnSection5Man.Top = Height - top + 42;
                    btnSection6Man.Top = Height - top;
                    btnSection7Man.Top = Height - top + 42;
                    btnSection8Man.Top = Height - top;
                    btnSection9Man.Top = Height - top;

                    even = 80; offset = 14;
                    btnSection1Man.Left = (first2Thirds) + offset - even * 3;
                    btnSection2Man.Left = (first2Thirds) + offset - even * 2;
                    btnSection4Man.Left = (first2Thirds) + offset - even;
                    btnSection6Man.Left = (first2Thirds) + offset + 0;
                    btnSection8Man.Left = (first2Thirds) + offset + even;
                    btnSection9Man.Left = (first2Thirds) + offset + even * 2;

                    btnSection3Man.Left = (first2Thirds) - 100;
                    btnSection5Man.Left = (first2Thirds) - 20;
                    btnSection7Man.Left = (first2Thirds) + 60;

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
                    break;

                case 10:
                    btnSection1Man.Top = Height - top;
                    btnSection2Man.Top = Height - top + 42;
                    btnSection3Man.Top = Height - top;
                    btnSection4Man.Top = Height - top + 42;
                    btnSection5Man.Top = Height - top;
                    btnSection6Man.Top = Height - top + 42;
                    btnSection7Man.Top = Height - top;
                    btnSection8Man.Top = Height - top + 42;
                    btnSection9Man.Top = Height - top;
                    btnSection10Man.Top = Height - top + 42;


                    btnSection1Man.Left = (first2Thirds) - 200;
                    btnSection3Man.Left = (first2Thirds) - 120;
                    btnSection5Man.Left = (first2Thirds) - 40;
                    btnSection7Man.Left = (first2Thirds) + 40;
                    btnSection9Man.Left = (first2Thirds) + 120;

                    btnSection2Man.Left = (first2Thirds) - 160;
                    btnSection4Man.Left = (first2Thirds) - 80;  
                    btnSection6Man.Left = (first2Thirds) - 0; 
                    btnSection8Man.Left = (first2Thirds) + 80;  
                    btnSection10Man.Left = (first2Thirds) + 160;        


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
                    break;

                case 11:
                    btnSection1Man.Top = Height - top;
                    btnSection2Man.Top = Height - top;
                    btnSection3Man.Top = Height - top + 42;
                    btnSection4Man.Top = Height - top;
                    btnSection5Man.Top = Height - top + 42;
                    btnSection6Man.Top = Height - top;
                    btnSection7Man.Top = Height - top + 42;
                    btnSection8Man.Top = Height - top;
                    btnSection9Man.Top = Height - top + 42;
                    btnSection10Man.Top = Height - top;
                    btnSection11Man.Top = Height - top;


                    btnSection1Man.Left = (first2Thirds) - 200;
                    btnSection2Man.Left = (first2Thirds) - 140;
                    btnSection4Man.Left = (first2Thirds) - 80;
                    btnSection6Man.Left = (first2Thirds) - 20;
                    btnSection8Man.Left = (first2Thirds) + 40;
                    btnSection10Man.Left = (first2Thirds) + 100;
                    btnSection11Man.Left = (first2Thirds) + 160;

                    btnSection3Man.Left = (first2Thirds) - 110;
                    btnSection5Man.Left = (first2Thirds) - 50;
                    btnSection7Man.Left = (first2Thirds) +10;
                    btnSection9Man.Left = (first2Thirds) + 70;


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
                    break;

                case 12:
                    btnSection1Man.Top = Height - top;
                    btnSection2Man.Top = Height - top + 42;
                    btnSection3Man.Top = Height - top;
                    btnSection4Man.Top = Height - top + 42;
                    btnSection5Man.Top = Height - top;
                    btnSection6Man.Top = Height - top + 42;
                    btnSection7Man.Top = Height - top;
                    btnSection8Man.Top = Height - top + 42;
                    btnSection9Man.Top = Height - top;
                    btnSection10Man.Top = Height - top + 42;
                    btnSection11Man.Top = Height - top;
                    btnSection12Man.Top = Height - top + 42;

                    offset = -9; even = 70;
                    btnSection1Man.Left = (first2Thirds)  + offset - even*3;
                    btnSection3Man.Left = (first2Thirds)  + offset - even*2;
                    btnSection5Man.Left = (first2Thirds)  + offset - even;
                    btnSection7Man.Left = (first2Thirds)  + offset + 0;
                    btnSection9Man.Left = (first2Thirds)  + offset+ even;                     
                    btnSection11Man.Left = (first2Thirds) + offset + even * 2;

                    offset = 22;
                    btnSection2Man.Left = (first2Thirds)  + offset - even*3;
                    btnSection4Man.Left = (first2Thirds)  + offset - even*2;
                    btnSection6Man.Left = (first2Thirds)  + offset - even;
                    btnSection8Man.Left = (first2Thirds)  + offset + 0;
                    btnSection10Man.Left = (first2Thirds) + offset + even;
                    btnSection12Man.Left = (first2Thirds) + offset + even * 2;

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
                    break;
            }

            if (isJobStarted)
            {
                switch (vehicle.numOfSections)
                {
                    case 1:
                        btnSection1Man.Enabled = true;
                        btnSection2Man.Enabled = false;
                        btnSection3Man.Enabled = false;
                        btnSection4Man.Enabled = false;
                        btnSection5Man.Enabled = false;
                        btnSection6Man.Enabled = false;
                        btnSection7Man.Enabled = false;
                        btnSection8Man.Enabled = false;
                        btnSection9Man.Enabled = false;
                        btnSection10Man.Enabled = false;
                        btnSection11Man.Enabled = false;
                        btnSection12Man.Enabled = false;
                        break;

                    case 2:
                        btnSection1Man.Enabled = true;
                        btnSection2Man.Enabled = true;
                        btnSection3Man.Enabled = false;
                        btnSection4Man.Enabled = false;
                        btnSection5Man.Enabled = false;
                        btnSection6Man.Enabled = false;
                        btnSection7Man.Enabled = false;
                        btnSection8Man.Enabled = false;
                        btnSection9Man.Enabled = false;
                        btnSection10Man.Enabled = false;
                        btnSection11Man.Enabled = false;
                        btnSection12Man.Enabled = false;
                        break;

                    case 3:
                        btnSection1Man.Enabled = true;
                        btnSection2Man.Enabled = true;
                        btnSection3Man.Enabled = true;
                        btnSection4Man.Enabled = false;
                        btnSection5Man.Enabled = false;
                        btnSection6Man.Enabled = false;
                        btnSection7Man.Enabled = false;
                        btnSection8Man.Enabled = false;
                        btnSection9Man.Enabled = false;
                        btnSection10Man.Enabled = false;
                        btnSection11Man.Enabled = false;
                        btnSection12Man.Enabled = false;
                        break;

                    case 4:
                        btnSection1Man.Enabled = true;
                        btnSection2Man.Enabled = true;
                        btnSection3Man.Enabled = true;
                        btnSection4Man.Enabled = true;
                        btnSection5Man.Enabled = false;
                        btnSection6Man.Enabled = false;
                        btnSection7Man.Enabled = false;
                        btnSection8Man.Enabled = false;
                        btnSection9Man.Enabled = false;
                        btnSection10Man.Enabled = false;
                        btnSection11Man.Enabled = false;
                        btnSection12Man.Enabled = false;
                        break;

                    case 5:
                        btnSection1Man.Enabled = true;
                        btnSection2Man.Enabled = true;
                        btnSection3Man.Enabled = true;
                        btnSection4Man.Enabled = true;
                        btnSection5Man.Enabled = true;
                        btnSection6Man.Enabled = false;
                        btnSection7Man.Enabled = false;
                        btnSection8Man.Enabled = false;
                        btnSection9Man.Enabled = false;
                        btnSection10Man.Enabled = false;
                        btnSection11Man.Enabled = false;
                        btnSection12Man.Enabled = false;
                        break;

                    case 6:
                        btnSection1Man.Enabled = true;
                        btnSection2Man.Enabled = true;
                        btnSection3Man.Enabled = true;
                        btnSection4Man.Enabled = true;
                        btnSection5Man.Enabled = true;
                        btnSection6Man.Enabled = true;
                        btnSection7Man.Enabled = false;
                        btnSection8Man.Enabled = false;
                        btnSection9Man.Enabled = false;
                        btnSection10Man.Enabled = false;
                        btnSection11Man.Enabled = false;
                        btnSection12Man.Enabled = false;
                        break;

                    case 7:
                        btnSection1Man.Enabled = true;
                        btnSection2Man.Enabled = true;
                        btnSection3Man.Enabled = true;
                        btnSection4Man.Enabled = true;
                        btnSection5Man.Enabled = true;
                        btnSection6Man.Enabled = true;
                        btnSection7Man.Enabled = true;
                        btnSection8Man.Enabled = false;
                        btnSection9Man.Enabled = false;
                        btnSection10Man.Enabled = false;
                        btnSection11Man.Enabled = false;
                        btnSection12Man.Enabled = false;
                        break;

                    case 8:
                        btnSection1Man.Enabled = true;
                        btnSection2Man.Enabled = true;
                        btnSection3Man.Enabled = true;
                        btnSection4Man.Enabled = true;
                        btnSection5Man.Enabled = true;
                        btnSection6Man.Enabled = true;
                        btnSection7Man.Enabled = true;
                        btnSection8Man.Enabled = true;
                        btnSection9Man.Enabled = false;
                        btnSection10Man.Enabled = false;
                        btnSection11Man.Enabled = false;
                        btnSection12Man.Enabled = false;
                        break;

                    case 9:
                        btnSection1Man.Enabled = true;
                        btnSection2Man.Enabled = true;
                        btnSection3Man.Enabled = true;
                        btnSection4Man.Enabled = true;
                        btnSection5Man.Enabled = true;
                        btnSection6Man.Enabled = true;
                        btnSection7Man.Enabled = true;
                        btnSection8Man.Enabled = true;
                        btnSection9Man.Enabled = true;
                        btnSection10Man.Enabled = false;
                        btnSection11Man.Enabled = false;
                        btnSection12Man.Enabled = false;
                        break;

                    case 10:
                        btnSection1Man.Enabled = true;
                        btnSection2Man.Enabled = true;
                        btnSection3Man.Enabled = true;
                        btnSection4Man.Enabled = true;
                        btnSection5Man.Enabled = true;
                        btnSection6Man.Enabled = true;
                        btnSection7Man.Enabled = true;
                        btnSection8Man.Enabled = true;
                        btnSection9Man.Enabled = true;
                        btnSection10Man.Enabled = true;
                        btnSection11Man.Enabled = false;
                        btnSection12Man.Enabled = false;
                        break;

                    case 11:
                        btnSection1Man.Enabled = true;
                        btnSection2Man.Enabled = true;
                        btnSection3Man.Enabled = true;
                        btnSection4Man.Enabled = true;
                        btnSection5Man.Enabled = true;
                        btnSection6Man.Enabled = true;
                        btnSection7Man.Enabled = true;
                        btnSection8Man.Enabled = true;
                        btnSection9Man.Enabled = true;
                        btnSection10Man.Enabled = true;
                        btnSection11Man.Enabled = true;
                        btnSection12Man.Enabled = false;
                        break;

                    case 12:
                        btnSection1Man.Enabled = true;
                        btnSection2Man.Enabled = true;
                        btnSection3Man.Enabled = true;
                        btnSection4Man.Enabled = true;
                        btnSection5Man.Enabled = true;
                        btnSection6Man.Enabled = true;
                        btnSection7Man.Enabled = true;
                        btnSection8Man.Enabled = true;
                        btnSection9Man.Enabled = true;
                        btnSection10Man.Enabled = true;
                        btnSection11Man.Enabled = true;
                        btnSection12Man.Enabled = true;
                        break;
                }
            }
        }

        //update individual btn based on state after push
        private void ManualBtnUpdate(int sectNumber, Button btn)
        {
            switch (section[sectNumber].manBtnState)
            {
                case manBtn.Off:
                    section[sectNumber].manBtnState = manBtn.Auto;
                    btn.BackColor = Color.Lime;
                    break;

                case manBtn.Auto:
                    section[sectNumber].manBtnState = manBtn.On;
                    btn.BackColor = Color.Yellow;
                    break;

                case manBtn.On:
                    section[sectNumber].manBtnState = manBtn.Off;
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

        // Buttons //-----------------------------------------------------------------------
        private void btnMakeContourFromBoundary_Click(object sender, EventArgs e)
        {
            //build all the contour guidance lines from boundaries, all of them. 
            ct.BuildBoundaryContours();
        }

        private void btnStanley_Click(object sender, EventArgs e)
        {
            isStanleyUsed = !isStanleyUsed;
            if (isStanleyUsed) btnStanley.Text = "StanLee";
            else btnStanley.Text = "Pure P";
            Properties.Vehicle.Default.setVehicle_isStanleyUsed = isStanleyUsed;
            Properties.Vehicle.Default.Save();
        }

        private void btnStartStopNtrip_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.setNTRIP_isOn)
            {
                if (isNTRIP_RequiredOn)
                {
                    ShutDownNTRIP();
                    btnStartStopNtrip.Text = "Start";
                    lblWatch.Text = "Stopped";
                    lblNTRIPSeconds.Text = "Offline ";
                    isNTRIP_RequiredOn = false;
                }
                else
                {
                    isNTRIP_RequiredOn = true;
                    btnStartStopNtrip.Text = "Stop";
                    lblWatch.Text = "Waiting";
                }
            }
            else
            {
                TimedMessageBox(2000, "Turn ON Ntrip Client", " NTRIP Client Not Set Up");
            }
        }

        //rate control
        private void btnDualRate_Click(object sender, EventArgs e)
        {
            if (!rcd.isSingleFlowMeter && vehicle.numOfSections % 2 != 0 && !rcd.isRateControlOn)
            {
                TimedMessageBox(3500, "Even # of Sections Only", "You Must Have an Even Number of Sections");
                return;
            }

            if (isJobStarted)
            {
                rcd.isRateControlOn = !rcd.isRateControlOn;

                if (rcd.isRateControlOn)
                {
                    mc.relayRateSettings[mc.rsFlowCalFactorLeftHi] = (byte)(Properties.Settings.Default.setRate_FlowmeterCalNumberLeft >> 8);
                    mc.relayRateSettings[mc.rsFlowCalFactorLeftLo] = (byte)(Properties.Settings.Default.setRate_FlowmeterCalNumberLeft);
                    mc.relayRateSettings[mc.rsFlowCalFactorRightHi] = (byte)(Properties.Settings.Default.setRate_FlowmeterCalNumberRight >> 8);
                    mc.relayRateSettings[mc.rsFlowCalFactorRightLo] = (byte)(Properties.Settings.Default.setRate_FlowmeterCalNumberRight);
                    RateRelayOutToPort(mc.relayRateSettings, CModuleComm.numRelayRateSettingsItems);

                    //get the last saved rates from setting file - always stored in L/Ha
                    rcd.rateLeft = Properties.Settings.Default.setRate_rateLeft;
                    rcd.rateRight = Properties.Settings.Default.setRate_rateRight;
                    //btnSelectSingleDualMeter.Enabled = false;

                    if (rcd.isSingleFlowMeter)
                    {
                        //btnRateRightDn.Visible = false;
                        //btnRateRightUp.Visible = false;
                        btnRateLeftDn.Visible = true;
                        btnRateLeftUp.Visible = true;
                        btnSelectRate1.Visible = true;
                        btnSelectRate2.Visible = true;

                        //lblFlowRateRight.Visible = false;
                        //lblRateAppliedActualRight.Visible = false;
                        //lblRateSetpointRight.Visible = false;
                        //lblFlowRight.Visible = false;

                        lblFlowRateLeft.Visible = true;
                        lblRateAppliedActualLeft.Visible = true;
                        lblRateSetpointLeft.Visible = true;
                        lblFlowLeft.Visible = true;
                    }
                    else
                    {
                        //btnRateRightDn.Visible = true;
                        //btnRateRightUp.Visible = true;
                        btnRateLeftDn.Visible = true;
                        btnRateLeftUp.Visible = true;

                        btnSelectRate1.Visible = false;
                        btnSelectRate2.Visible = false;

                        //lblFlowRateRight.Visible = true;
                        //lblRateAppliedActualRight.Visible = true;
                        //lblRateSetpointRight.Visible = true;
                        //lblFlowRight.Visible = true;

                        lblFlowRateLeft.Visible = true;
                        lblRateAppliedActualLeft.Visible = true;
                        lblRateSetpointLeft.Visible = true;
                        lblFlowLeft.Visible = true;
                    }

                    btnDualRate.Image = Properties.Resources.RateControlOn;
                    btnDualRate.Text = "On";

                    if (isMetric)
                    {
                        lblRateSetpointLeft.Text = (rcd.rateLeft).ToString("N1");
                        //lblRateSetpointRight.Text = (rcd.rateRight).ToString("N1");
                    }
                    else
                    {
                        lblRateSetpointLeft.Text = (rcd.rateLeft * glm.LHa2galAc).ToString("N1");
                        //lblRateSetpointRight.Text = (rcd.rateRight * glm.LHa2galAc).ToString("N1");
                    }
                }
                else
                {
                    //btnRateRightDn.Visible = false;
                    //btnRateRightUp.Visible = false;
                    btnRateLeftDn.Visible = false;
                    btnRateLeftUp.Visible = false;
                    btnSelectRate1.Visible = false;
                    btnSelectRate2.Visible = false;

                    //lblFlowRateRight.Visible = false;
                    //lblRateAppliedActualRight.Visible = false;
                    //lblRateSetpointRight.Visible = false;
                    //lblFlowRight.Visible = false;

                    lblFlowRateLeft.Visible = false;
                    lblRateAppliedActualLeft.Visible = false;
                    lblRateSetpointLeft.Visible = false;
                    lblFlowLeft.Visible = false;

                    //btnSelectSingleDualMeter.Enabled = true;

                    btnDualRate.Image = Properties.Resources.RateControlOff;
                    btnDualRate.Text = "Off";
                    //lblRateAppliedActualRight.Text = "-";
                    lblRateAppliedActualLeft.Text = "-";
                    lblFlowRateLeft.Text = "-";
                    //lblFlowRateRight.Text = "-";

                    rcd.rateSetPointLeft = 0.0;
                    rcd.rateSetPointRight = 0.0;

                    mc.relayRateData[mc.rdRateSetPointLeftLo] = 0;
                    mc.relayRateData[mc.rdRateSetPointLeftHi] = 0;
                    mc.relayRateData[mc.rdRateSetPointRightLo] = 0;
                    mc.relayRateData[mc.rdRateSetPointRightHi] = 0;
                    mc.relayRateData[mc.rdTramLine] = 0;

                    RateRelayOutToPort(mc.relayRateData, CModuleComm.numRelayRateDataItems);
                }
            }
            else { TimedMessageBox(1500, "Field not Open", "Start a Field First"); }
        }
        private void btnRateLeftUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (isMetric)
            {
                rcd.rateLeft++;
                lblRateSetpointLeft.Text = rcd.rateLeft.ToString("N1");
            }
            else
            {
                rcd.rateLeft++;
                lblRateSetpointLeft.Text = (rcd.rateLeft * glm.LHa2galAc).ToString("N1");
            }
        }
        private void btnRateLeftDn_MouseDown(object sender, MouseEventArgs e)
        {
            if (isMetric)
            {
                rcd.rateLeft--;
                if (rcd.rateLeft < 2.0) rcd.rateLeft = 2.0;
                lblRateSetpointLeft.Text = rcd.rateLeft.ToString("N1");
            }
            else
            {
                rcd.rateLeft--;
                if (rcd.rateLeft < 2.0) rcd.rateLeft = 2.0;
                lblRateSetpointLeft.Text = (rcd.rateLeft * glm.LHa2galAc).ToString("N1");
            }
        }
        private void btnRateRightUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (isMetric)
            {
                rcd.rateRight++;
                //lblRateSetpointRight.Text = rcd.rateRight.ToString("N1");
            }
            else
            {
                rcd.rateRight++;
                //lblRateSetpointRight.Text = (rcd.rateRight * glm.LHa2galAc).ToString("N1");
            }
        }
        private void btnRateRightDn_MouseDown(object sender, MouseEventArgs e)
        {
            if (isMetric)
            {
                rcd.rateRight--;
                if (rcd.rateRight < 2.0) rcd.rateRight = 2.0;
                //lblRateSetpointRight.Text = rcd.rateRight.ToString("N1");
            }
            else
            {
                rcd.rateRight--;
                if (rcd.rateRight < 2.0) rcd.rateRight = 2.0;
                //lblRateSetpointRight.Text = (rcd.rateRight * glm.LHa2galAc).ToString("N1");
            }
        }
        private void btnDualRateConfig_Click(object sender, EventArgs e)
        {
            var form = new FormDualRate(this);
            form.ShowDialog();
            btnSelectRate1.BackColor = Color.LightSkyBlue;
            btnSelectRate2.BackColor = Color.LightGray;
            if (isMetric)
            {
                lblRateSetpointLeft.Text = (rcd.rateLeft).ToString("N1");
                //lblRateSetpointRight.Text = (rcd.rateRight).ToString("N1");
                btnSelectRate1.Text = Math.Round(rcd.rateLeft, 1).ToString();
                btnSelectRate2.Text = Math.Round(rcd.rateRight, 1).ToString();
            }
            else
            {
                lblRateSetpointLeft.Text = (rcd.rateLeft * glm.LHa2galAc).ToString("N1");
                //lblRateSetpointRight.Text = (rcd.rateRight * glm.LHa2galAc).ToString("N1");
                btnSelectRate1.Text = (rcd.rateLeft * glm.LHa2galAc).ToString("N1");
                btnSelectRate2.Text = (rcd.rateRight * glm.LHa2galAc).ToString("N1");
            }
        }
        private void btnSelectRate1_Click(object sender, EventArgs e)
        {
            rcd.rateLeft = Settings.Default.setRate_rateLeft;
            rcd.isRate1Selected = true;
            btnSelectRate1.BackColor = Color.LightSkyBlue;
            btnSelectRate2.BackColor = Color.LightGray;
            if (isMetric)
            {
                lblRateSetpointLeft.Text = (rcd.rateLeft).ToString("N1");
            }
            else
            {
                lblRateSetpointLeft.Text = (rcd.rateLeft * glm.LHa2galAc).ToString("N1");
            }
        }
        private void btnSelectRate2_Click(object sender, EventArgs e)
        {
            rcd.rateLeft = Settings.Default.setRate_rateRight;
            rcd.isRate1Selected = false;
            btnSelectRate2.BackColor = Color.LightSkyBlue;
            btnSelectRate1.BackColor = Color.LightGray;

            if (isMetric)
            {
                lblRateSetpointLeft.Text = (rcd.rateLeft).ToString("N1");
            }
            else
            {
                lblRateSetpointLeft.Text = (rcd.rateLeft * glm.LHa2galAc).ToString("N1");
            }
        }
        private void btnSelectSingleDualMeter_Click(object sender, EventArgs e)
        {
            if (rcd.isSingleFlowMeter && vehicle.numOfSections % 2 != 0)
            {
                TimedMessageBox(3000, "Dual Flow Meters Needs Even # Sections", "Go to Vehicle Config and Select Even # of Sections");
                return;
            }

            rcd.isSingleFlowMeter = !rcd.isSingleFlowMeter;
            if (rcd.isSingleFlowMeter)
            {
                //btnSelectSingleDualMeter.Image = Resources.FlowMeterSingle;
            }
            else
            {
                //btnSelectSingleDualMeter.Image = Resources.FlowMeterDual;
            }

            Settings.Default.setRate_isSingleFlowMeter = rcd.isSingleFlowMeter;
            Settings.Default.Save();
        }


        private void btnGenerateSelf_Click(object sender, EventArgs e)
        {
            if (bnd.bndArr[0].isSet)// && (ABLine.isABLineSet | curve.isCurveSet))
            {
                //field too small or moving
                if (bnd.bndArr[0].bndLine.Count < 200) { TimedMessageBox(3000, "!!!!", gStr.gsBoundaryTooSmall); return; }
                if (pn.speed > 0.2) { TimedMessageBox(3000, "Vehicle Moving", "You Must Be Standing Still"); return; }

                using (var form = new FormSelf(this))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                    }
                }
            }
            else { TimedMessageBox(3000, gStr.gsBoundaryNotSet, gStr.gsCreateBoundaryFirst); }
        }

        private void btnGoSelf_Click(object sender, EventArgs e)
        {
            if (!self.isPausedSelfDriving)
            {
                //already running?
                if (self.isSelfDriving)
                {
                    self.StopSelfDriving();
                    return;
                }

                if (!self.StartSelfDriving())
                {
                    //Cancel the self - something went seriously wrong
                    TimedMessageBox(1500, "Unable to create path", "Is Start too close to boundary?");
                    self.StopSelfDriving();
                }
                else
                {
                    btnGoSelf.Image = Properties.Resources.AutoStop;
                }
            }
            else
            {
                self.isPausedSelfDriving = false;
                btnPauseDrivingPath.BackColor = Color.Lime;
            }
        }

        private void btnManualAutoDrive_Click(object sender, EventArgs e)
        {
            if (isInAutoDrive)
            {
                isInAutoDrive = false;
                btnManualAutoDrive.Image = Properties.Resources.Cancel64;
                btnManualAutoDrive.Text = "Manual";
            }
            else
            {
                isInAutoDrive = true;
                btnManualAutoDrive.Image = Properties.Resources.OK64;
                btnManualAutoDrive.Text = "Auto";
            }
        }

        private void goPathMenu_Click(object sender, EventArgs e)
        {
            if (!recPath.isPausedDrivingRecordedPath)
            {
                //already running?
                if (recPath.isDrivingRecordedPath)
                {
                    recPath.StopDrivingRecordedPath();
                    return;
                }

                //start the recorded path driving process

                //if ABLine isn't set, turn off the YouTurn
                if (ABLine.isABLineSet)
                {
                    ABLine.DeleteAB();
                    ABLine.isABLineBeingSet = false;
                    txtDistanceOffABLine.Visible = false;

                    //change image to reflect on off
                    btnABLine.Image = Properties.Resources.ABLineOff;
                    ABLine.isBtnABLineOn = false;

                    ABLine.isABLineBeingSet = false;
                    DisableYouTurnButtons();
                    if (isAutoSteerBtnOn) btnAutoSteer.PerformClick();
                    btnCurve.Enabled = true;
                }

                if (curve.isCurveSet) curve.ResetCurveLine();
                if (yt.isYouTurnBtnOn) btnEnableAutoYouTurn.PerformClick();

                if (!recPath.StartDrivingRecordedPath())
                {
                    //Cancel the recPath - something went seriously wrong
                    recPath.StopDrivingRecordedPath();
                    TimedMessageBox(1500, "Problem Making Path", "Couldn't generate valid path");
                }
                else
                {
                    btnDrivePath.Image = Properties.Resources.AutoStop;
                    goPathMenu.Image = Properties.Resources.AutoStop;
                }
            }
            else
            {
                recPath.isPausedDrivingRecordedPath = false;
                btnPauseDrivingPath.BackColor = Color.Lime;
                pausePathMenu.BackColor = Color.Lime;
            }
        }

        private void pausePathMenu_Click(object sender, EventArgs e)
        {
            if (recPath.isPausedDrivingRecordedPath)
            {
                btnPauseDrivingPath.BackColor = Color.Lime;
                pausePathMenu.BackColor = Color.Lime;
            }
            else
            {
                btnPauseDrivingPath.BackColor = Color.OrangeRed;
                pausePathMenu.BackColor = Color.OrangeRed;
            }

            recPath.isPausedDrivingRecordedPath = !recPath.isPausedDrivingRecordedPath;
        }

        private void recordPathMenu_Click(object sender, EventArgs e)
        {
            if (recPath.isRecordOn)
            {
                FileSaveRecPath();
                recPath.isRecordOn = false;
                btnRecPathPauseRecord.Image = Properties.Resources.BoundaryRecord;
                recordPathMenu.Image = Properties.Resources.BoundaryRecord;
            }
            else if (isJobStarted)
            {
                recPath.recList.Clear();
                recPath.isRecordOn = true;
                btnRecPathPauseRecord.Image = Properties.Resources.boundaryStop;
                recordPathMenu.Image = Properties.Resources.boundaryStop;
            }
        }

        private void deletePathMenu_Click(object sender, EventArgs e)
        {
            recPath.recList.Clear();
            recPath.StopDrivingRecordedPath();
            FileSaveRecPath();
        }


        //record playback buttons
        private void btnStopDrivingPath_Click(object sender, EventArgs e)
        {
            recPath.StopDrivingRecordedPath();
        }
        private void btnDeleteRecPath_Click(object sender, EventArgs e)
        {
            recPath.recList.Clear();
            recPath.StopDrivingRecordedPath();
            FileSaveRecPath();
        }
        private void btnRecPathPauseRecord_Click(object sender, EventArgs e)
        {
            if (recPath.isRecordOn)
            {
                FileSaveRecPath();
                recPath.isRecordOn = false;
                btnRecPathPauseRecord.Image = Properties.Resources.BoundaryRecord;
                recordPathMenu.Image = Properties.Resources.BoundaryRecord;
            }
            else if (isJobStarted)
            {
                recPath.recList.Clear();
                recPath.isRecordOn = true;
                btnRecPathPauseRecord.Image = Properties.Resources.boundaryStop;
                recordPathMenu.Image = Properties.Resources.boundaryStop;
            }
        }
        private void btnPauseDrivingPath_Click(object sender, EventArgs e)
        {
            if (recPath.isPausedDrivingRecordedPath)
            {
                btnPauseDrivingPath.BackColor = Color.Lime;
                pausePathMenu.BackColor = Color.Lime;
            }
            else
            {
                btnPauseDrivingPath.BackColor = Color.OrangeRed;
                pausePathMenu.BackColor = Color.OrangeRed;
            }

            recPath.isPausedDrivingRecordedPath = !recPath.isPausedDrivingRecordedPath;
        }
        private void btnDrivePath_Click(object sender, EventArgs e)
        {
            if (!recPath.isPausedDrivingRecordedPath)
            {
                //already running?
                if (recPath.isDrivingRecordedPath)
                {
                    recPath.StopDrivingRecordedPath();
                    return;
                }

                //start the recorded path driving process

                //if ABLine isn't set, turn off the YouTurn
                if (ABLine.isABLineSet)
                {
                    ABLine.DeleteAB();
                    ABLine.isABLineBeingSet = false;
                    txtDistanceOffABLine.Visible = false;

                    //change image to reflect on off
                    btnABLine.Image = Properties.Resources.ABLineOff;
                    ABLine.isBtnABLineOn = false;

                    ABLine.isABLineBeingSet = false;
                    DisableYouTurnButtons();
                    if (isAutoSteerBtnOn) btnAutoSteer.PerformClick();
                    btnCurve.Enabled = true;
                }

                if (curve.isCurveSet) curve.ResetCurveLine();
                if (yt.isYouTurnBtnOn) btnEnableAutoYouTurn.PerformClick();

                if (!recPath.StartDrivingRecordedPath())
                {
                    //Cancel the recPath - something went seriously wrong
                    recPath.StopDrivingRecordedPath();
                    TimedMessageBox(1500, "Problem Making Path", "Couldn't generate valid path");
                }
                else
                {
                    btnDrivePath.Image = Properties.Resources.AutoStop;
                    goPathMenu.Image = Properties.Resources.AutoStop;
                }
            }
            else
            {
                recPath.isPausedDrivingRecordedPath = false;
                btnPauseDrivingPath.BackColor = Color.Lime;
                pausePathMenu.BackColor = Color.Lime;
            }
        }

        //LIDAR control
        private void btnLidarOnOff_Click(object sender, EventArgs e)
        {
            isLidarBtnOn = !isLidarBtnOn;
            if (isLidarBtnOn)
            {
                btnLidarOnOff.Text = "Lidar On";
                btnLidarOnOff.Image = Properties.Resources.boundaryPlay;
            }
            else
            {
                btnLidarOnOff.Text = "Lidar Off";
                btnLidarOnOff.Image = Properties.Resources.boundaryStop;
            }

        }

        //Guidance types
        private void btnAutoSteer_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Question.Play();

            //new direction so reset where to put turn diagnostic
            yt.ResetCreatedYouTurn();

            if (isAutoSteerBtnOn)
            {
                isAutoSteerBtnOn = false;
                btnAutoSteer.Image = Properties.Resources.AutoSteerOff;
            }
            else
            {
                if (ABLine.isABLineSet | ct.isContourBtnOn | curve.isCurveSet)
                {
                    isAutoSteerBtnOn = true;
                    btnAutoSteer.Image = Properties.Resources.AutoSteerOn;
                }
                else
                {
                    var form = new FormTimedMessage(2000,(gStr.gsNoGuidanceLines),(gStr.gsTurnOnContourOrABLine));
                    form.Show();
                }
            }
        }
        private void btnABLine_Click(object sender, EventArgs e)
        {
            //if contour is on, turn it off
            if (ct.isContourBtnOn) { if (ct.isContourBtnOn) btnContour.PerformClick(); }

            //new direction so reset where to put turn diagnostic
            yt.ResetCreatedYouTurn();
            btnContourPriority.Enabled = true;
            
            if (ABLine.isABLineSet)
            {
                ABLine.abHeading = glm.toRadians(AB0.heading);
                ABLine.refPoint1.easting = AB0.X;
                ABLine.refPoint1.northing = AB0.Y;
                ABLine.SetABLineByHeading();
            }

            using (var form = new FormABLine(this))
            {
                ABLine.isABLineBeingSet = true;
                txtDistanceOffABLine.Visible = true;

                var result = form.ShowDialog();

                //Comes back

                //if ABLine isn't set, turn off the YouTurn
                if (!ABLine.isABLineSet)
                {
                    ABLine.isABLineBeingSet = false;
                    txtDistanceOffABLine.Visible = false;

                    //change image to reflect on off
                    btnABLine.Image = Properties.Resources.ABLineOff;
                    ABLine.isBtnABLineOn = false;

                    ABLine.isABLineBeingSet = false;

                    DisableYouTurnButtons();

                    if (isAutoSteerBtnOn) btnAutoSteer.PerformClick();
                    btnCurve.Enabled = true;

                }

                //ab line is made
                else
                {
                    //change image to reflect on off
                    btnABLine.Image = Properties.Resources.ABLineOn;
                    ABLine.isBtnABLineOn = true;

                    ABLine.isABLineBeingSet = false;
                    EnableYouTurnButtons();
                    btnCurve.Enabled = false;
                }
            }
        }
        private void btnCurve_Click(object sender, EventArgs e)
        {
            //if contour is on, turn it off
            if (ct.isContourBtnOn) { if (ct.isContourBtnOn) btnContour.PerformClick(); }

            //new direction so reset where to put turn diagnostic
            yt.ResetCreatedYouTurn();

            //check if window already exists
            Form fc = Application.OpenForms["FormABCurve"];

            if (fc != null)
            {
                fc.Focus();
                return;
            }

            curve.isCurveBtnOn = !curve.isCurveBtnOn;
            btnCurve.Image = curve.isCurveBtnOn ? Properties.Resources.CurveOn : Properties.Resources.CurveOff;

            if (curve.isCurveBtnOn)
            {
                //turn off youturn...
                btnRightYouTurn.Enabled = false;
                btnLeftYouTurn.Enabled = false;
                btnRightYouTurn.Visible = false;
                btnLeftYouTurn.Visible = false;

                btnEnableAutoYouTurn.Enabled = false;
                yt.isYouTurnBtnOn = false;
                btnEnableAutoYouTurn.Image = Properties.Resources.YouTurnNo;
                yt.ResetYouTurn();

                //kill the ABLine
                ABLine.DeleteAB();
                ABLine.tramPassEvery = 0;
                ABLine.passBasedOn = 0;

                //save the no ABLine;
                FileSaveABLine();
                ABLine.isABLineBeingSet = false;
                txtDistanceOffABLine.Visible = false;

                //change image to reflect on off
                btnABLine.Image = Properties.Resources.ABLineOff;
                ABLine.isBtnABLineOn = false;

                ABLine.isABLineBeingSet = false;
                //btnContour.Enabled = false;
                btnABLine.Enabled = false;

                if (isAutoSteerBtnOn) btnAutoSteer.PerformClick();
                btnContourPriority.Enabled = true;

                Form form = new FormABCurve(this);
                form.Show();
            }
            else
            {
                btnContour.Enabled = true;
                btnABLine.Enabled = true;
                curve.isOkToAddPoints = false;
                curve.isCurveSet = false;
                DisableYouTurnButtons();
                btnContourPriority.Enabled = false;
                //curve.ResetCurveLine();
            }
        }
        private void btnContour_Click(object sender, EventArgs e)
        {
            ct.isContourBtnOn = !ct.isContourBtnOn;
            btnContour.Image = ct.isContourBtnOn ? Properties.Resources.ContourOn : Properties.Resources.ContourOff;

            if (ct.isContourBtnOn)
            {
                //turn off youturn...
                btnRightYouTurn.Enabled = false;
                btnLeftYouTurn.Enabled = false;
                btnRightYouTurn.Visible = false;
                btnLeftYouTurn.Visible = false;

                btnEnableAutoYouTurn.Enabled = false;
                yt.isYouTurnBtnOn = false;
                btnEnableAutoYouTurn.Image = Properties.Resources.YouTurnNo;
                btnContourPriority.Enabled = true;

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
                if (ABLine.isABLineSet | curve.isCurveSet)
                {
                    btnRightYouTurn.Enabled = true;
                    btnLeftYouTurn.Enabled = true;
                    btnRightYouTurn.Visible = true;
                    btnLeftYouTurn.Visible = true;

                    //auto YouTurn shutdown
                    yt.isYouTurnBtnOn = false;
                    yt.ResetYouTurn();

                    //turn off youturn...
                    btnEnableAutoYouTurn.Enabled = true;
                    btnEnableAutoYouTurn.Image = Properties.Resources.YouTurnNo;
                }
                //btnContourPriority.Enabled = false;

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
                if (ABLine.isABLineSet)
                {
                    ABLine.SnapABLine();

                    //DialogResult result3 = MessageBox.Show("Save AB Line Snap?",
                    //                            "Save or Not",
                    //                            MessageBoxButtons.YesNo,
                    //                            MessageBoxIcon.Question,
                    //                            MessageBoxDefaultButton.Button2);
                    //if (result3 == DialogResult.Yes)
                    {
                        FileSaveABLine();
                    }
                }
                else if (curve.isCurveSet)
                {
                    curve.SnapABCurve();
                }
                else
                {
                    var form = new FormTimedMessage(2000, (gStr.gsNoGuidanceLines), (gStr.gsTurnOnContourOrABLine));
                    form.Show();
                }
            }
        }

        //Snaps
        private void SnapSmallLeft()
        {
            if (!ct.isContourBtnOn)
            {
                if (ABLine.isABLineSet)
                {
                    //snap distance is in cm
                    yt.ResetCreatedYouTurn();
                    double dist = 0.01 * Properties.Settings.Default.setDisplay_snapDistanceSmall;

                    ABLine.MoveABLine(-dist);
                    FileSaveABLine();
                }
                else if (curve.isCurveSet)
                {
                    //snap distance is in cm
                    yt.ResetCreatedYouTurn();
                    double dist = 0.01 * Properties.Settings.Default.setDisplay_snapDistanceSmall;

                    curve.MoveABCurve(-dist);
                }
                else
                {
                    var form = new FormTimedMessage(2000, (gStr.gsNoGuidanceLines), (gStr.gsTurnOnContourOrABLine));
                    form.Show();
                }
            }
        }
        private void SnapSmallRight()
        {
            if (!ct.isContourBtnOn)
            {
                if (ABLine.isABLineSet)
                {
                    //snap distance is in cm
                    yt.ResetCreatedYouTurn();
                    double dist = 0.01 * Properties.Settings.Default.setDisplay_snapDistanceSmall;
                    ABLine.MoveABLine(dist);
                    FileSaveABLine();
                }
                else if (curve.isCurveSet)
                {
                    //snap distance is in cm
                    yt.ResetCreatedYouTurn();
                    double dist = 0.01 * Properties.Settings.Default.setDisplay_snapDistanceSmall;
                    curve.MoveABCurve(dist);
                }
                else
                {
                    var form = new FormTimedMessage(2000, (gStr.gsNoGuidanceLines), (gStr.gsTurnOnContourOrABLine));
                    form.Show();
                }
            }
        }
        private void SnapRight()
        {
            if (!ct.isContourBtnOn)
            {
                if (ABLine.isABLineSet)
                {
                    //snap distance is in cm
                    yt.ResetCreatedYouTurn();
                    double dist = 0.01 * Properties.Settings.Default.setDisplay_snapDistance;

                    ABLine.MoveABLine(dist);
                    FileSaveABLine();
                }
                else if (curve.isCurveSet)
                {
                    //snap distance is in cm
                    yt.ResetCreatedYouTurn();
                    double dist = 0.01 * Properties.Settings.Default.setDisplay_snapDistance;
                    curve.MoveABCurve(dist);
                }
                else
                {
                    var form = new FormTimedMessage(2000, (gStr.gsNoGuidanceLines), (gStr.gsTurnOnContourOrABLine));
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
                    double dist = 0.01 * Properties.Settings.Default.setDisplay_snapDistance;

                    ABLine.MoveABLine(-dist);
                    FileSaveABLine();
                }
                else if (curve.isCurveSet)
                {
                    //snap distance is in cm
                    yt.ResetCreatedYouTurn();
                    double dist = 0.01 * Properties.Settings.Default.setDisplay_snapDistance;

                    curve.MoveABCurve(-dist);
                }
                else
                {
                    var form = new FormTimedMessage(2000, (gStr.gsNoGuidanceLines), (gStr.gsTurnOnContourOrABLine));
                    form.Show();
                }
            }

        }

        private void btnSmallSnapLeft_Click(object sender, EventArgs e)
        { 
                SnapSmallLeft();
        }
        private void btnSmallSnapRight_Click(object sender, EventArgs e)
        {
            SnapSmallRight();
        }
        private void btnSnapRight_Click(object sender, EventArgs e)
        {
            SnapRight();
        }
        private void btnSnapLeft_Click(object sender, EventArgs e)
        {
            SnapLeft();
        }

        private void btnSmallLeft2_Click(object sender, EventArgs e)
        {
            SnapSmallLeft();
        }
        private void btnSmallRight2_Click(object sender, EventArgs e)
        {
            SnapSmallRight();
        }
        private void btnBigLeft2_Click(object sender, EventArgs e)
        {
            SnapLeft();
        }
        private void btnBigRight2_Click(object sender, EventArgs e)
        {
            SnapRight();
        }

        //AB Line context menu
        private void contextMenuStripAB_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ABLine.isABLineSet || ct.isContourBtnOn)
            {
                e.Cancel = true;
                return;
            }
            toolStripMenuAB1.Text = AB1.heading.ToString("N3");
            toolStripMenuAB2.Text = AB2.heading.ToString("N3");
        }
        private void toolStripMenuOriginal_Click(object sender, EventArgs e)
        {
            ABLine.abHeading = glm.toRadians(AB0.heading);
            ABLine.refPoint1.easting = AB0.X;
            ABLine.refPoint1.northing = AB0.Y;
            ABLine.SetABLineByHeading();
        }
        private void toolStripMenuAB1_Click(object sender, EventArgs e)
        {
            ABLine.abHeading = glm.toRadians(AB1.heading);
            ABLine.refPoint1.easting = AB1.X;
            ABLine.refPoint1.northing = AB1.Y;
            ABLine.SetABLineByHeading();
        }
        private void toolStripMenuAB2_Click(object sender, EventArgs e)
        {
            ABLine.abHeading = glm.toRadians(AB2.heading);
            ABLine.refPoint1.easting = AB2.X;
            ABLine.refPoint1.northing = AB2.Y;
            ABLine.SetABLineByHeading();
        }
        private void toolStripMenuPlus90_Click(object sender, EventArgs e)
        {
            ABLine.abHeading += glm.PIBy2;
            ABLine.SetABLineByHeading();
        }
        private void toolStripMenuChoose_Click(object sender, EventArgs e)
        {
            using (var form = new FormSwapAB(this))
            {
                var result = form.ShowDialog();
            }
            toolStripMenuAB1.Text = AB1.heading.ToString("N3");
            toolStripMenuAB2.Text = AB2.heading.ToString("N3");
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
                    for (int j = 0; j < vehicle.numOfSections; j++)
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
                    for (int j = 0; j < vehicle.numOfSections; j++)
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
                    for (int j = 0; j < vehicle.numOfSections; j++)
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
                    for (int j = 0; j < vehicle.numOfSections; j++)
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

        //measure area button
        private void btnPerimeter_Click(object sender, EventArgs e)
        {
            if (periArea.isBtnPerimeterOn && periArea.periPtList.Count > 0)
            {
                periArea.isBtnPerimeterOn = false;
                //btnPerimeter.Text = "Paused";
                btnPerimeter.Image = Properties.Resources.PeriDone;
                return;
            }

            //periArea.isBtnPerimeterOn = !periArea.isBtnPerimeterOn;

            if (!periArea.isBtnPerimeterOn && periArea.periPtList.Count > 0)
            {
                periArea.periPtList.Clear();
                periArea.calcList.Clear();
                //btnPerimeter.Text = "Cleared";
                btnPerimeter.Image = Properties.Resources.PeriArea;
                return;
            }

            if (!periArea.isBtnPerimeterOn && periArea.periPtList.Count == 0)
            {
                //btnPerimeter.Text = "Logging";
                btnPerimeter.Image = Properties.Resources.PeriDraw;
                periArea.isBtnPerimeterOn = true;
                var form = new FormTimedMessage(3000, gStr.gsDrawingHasBegun, gStr.gsClickButtonAgainToStop);
                form.Show();
            }
        }
        private void btnGPSData_Click(object sender, EventArgs e)
        {
            Form form = new FormGPSData(this);
            form.Show();
        }
        private void btnFileExplorer_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                FileSaveFlagsKML();
            }
            Process.Start(fieldsDirectory + currentFieldDirectory);
        }
        private void toolStripZoomOut_Click(object sender, EventArgs e)
        {

            if (camera.zoomValue <= 20) camera.zoomValue += camera.zoomValue * 0.2;
            else camera.zoomValue += camera.zoomValue * 0.05;
            camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
            SetZoom();
        }
        private void toolStripZoomIn_Click(object sender, EventArgs e)
        {
            if (camera.zoomValue <= 20)
            { if ((camera.zoomValue -= camera.zoomValue * 0.2) < 6.0) camera.zoomValue = 6.0; }
            else { if ((camera.zoomValue -= camera.zoomValue * 0.05) < 6.0) camera.zoomValue = 6.0; }

            camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
            SetZoom();
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
            camera.camPitch -= ((camera.camPitch * 0.02) - 1);
            if (camera.camPitch > 0) camera.camPitch = 0;
        }
        private void btnpTiltDown_MouseDown(object sender, MouseEventArgs e)
        {
            camera.camPitch += ((camera.camPitch * 0.02) - 1);
            if (camera.camPitch < -80) camera.camPitch = -80;
        }
        private void btnZoomExtents_Click(object sender, EventArgs e)
        {
            //if (isJobStarted)
            {
                if (camera.camSetDistance < -400) camera.camSetDistance = -250;
                else camera.camSetDistance = -5 * maxFieldDistance;
                if (camera.camSetDistance == 0) camera.camSetDistance = -2000;
                SetZoom();
            }
        }

        private void btnFlag_Click(object sender, EventArgs e)
        {
            int nextflag = flagPts.Count + 1;
            CFlag flagPt = new CFlag(pn.latitude, pn.longitude, pn.fix.easting, pn.fix.northing, flagColor, nextflag);
            flagPts.Add(flagPt);
            FileSaveFlags();
        }
        private void btnFixOffset_Click(object sender, EventArgs e)
        {
            using (var form = new FormShiftPos(this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) { }
            }
        }
        private void btnSmoothAB_Click(object sender, EventArgs e)
        {
            if (isJobStarted && curve.isCurveBtnOn)
            {
                using (var form = new FormSmoothAB(this))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK) { }
                }
            }

            else
            {
                TimedMessageBox(2000, gStr.gsFieldNotOpen, gStr.gsStartNewField);
            }
        }

        //YouTurn on off
        private void btnLeftYouTurn_Click(object sender, EventArgs e)
        {
            if (yt.isYouTurnTriggered)
            {
                //is it turning left already?
                if (!yt.isYouTurnRight)
                {
                    yt.ResetYouTurn();
                    AutoYouTurnButtonsReset();
                }
                else
                {
                    yt.isYouTurnRight = false;
                    AutoYouTurnButtonsLeftTurn();
                }
            }
            else
            {
                if (yt.isYouTurnTriggered)
                {
                    yt.ResetYouTurn();
                    AutoYouTurnButtonsReset();
                }
                else
                {
                    yt.isYouTurnTriggered = true;
                    yt.BuildManualYouTurn(false, true);
                    AutoYouTurnButtonsLeftTurn();
                }
            }
        }
        private void btnRightYouTurn_Click(object sender, EventArgs e)
        {
            //is it already turning right, then cancel autoturn
            if (yt.isYouTurnTriggered)
            {
                //is it turning right already?
                if (yt.isYouTurnRight)
                {
                    yt.ResetYouTurn();
                    AutoYouTurnButtonsReset();
                }
                else
                {
                    //make it turn the other way
                    yt.isYouTurnRight = true;
                    AutoYouTurnButtonsRightTurn();
                }
            }
            else
            {
                if (yt.isYouTurnTriggered)
                {
                    yt.ResetYouTurn();
                    AutoYouTurnButtonsReset();
                }
                else
                {
                    yt.isYouTurnTriggered = true;
                    yt.BuildManualYouTurn(true, true);
                    AutoYouTurnButtonsRightTurn();
                }
            }
        }
        private void btnSwapDirection_Click_1(object sender, EventArgs e)
        {
            if (!yt.isYouTurnTriggered)
            {
                //is it turning right already?
                if (yt.isYouTurnRight)
                {
                    yt.isYouTurnRight = false;
                    yt.isLastYouTurnRight = !yt.isLastYouTurnRight;
                    AutoYouTurnButtonsReset();
                }
                else
                {
                    //make it turn the other way
                    yt.isYouTurnRight = true;
                    yt.isLastYouTurnRight = !yt.isLastYouTurnRight;
                    AutoYouTurnButtonsReset();
                }
            }
        }

        private void btnEnableAutoYouTurn_Click(object sender, EventArgs e)
        {
            if (!yt.isYouTurnBtnOn)
            {
                //new direction so reset where to put turn diagnostic
                yt.ResetCreatedYouTurn();

                yt.isYouTurnBtnOn = true;
                yt.isTurnCreationTooClose = false;
                yt.isTurnCreationNotCrossingError = false;
                yt.ResetYouTurn();
                //mc.autoSteerData[mc.sdX] = 0;
                mc.machineControlData[mc.cnYouTurn] = 0;

                btnEnableAutoYouTurn.Image = Properties.Resources.Youturn80;
            }
            else
            {
                yt.isYouTurnBtnOn = false;
                yt.rowSkipsWidth = Properties.Vehicle.Default.set_youSkipWidth;
                btnEnableAutoYouTurn.Image = Properties.Resources.YouTurnNo;
                yt.ResetYouTurn();

                //new direction so reset where to put turn diagnostic
                yt.ResetCreatedYouTurn();

                //mc.autoSteerData[mc.sdX] = 0;
                mc.machineControlData[mc.cnYouTurn] = 0;
            }
        }
        public void AutoYouTurnButtonsRightTurn()
        {
            btnRightYouTurn.BackColor = Color.Yellow;
            btnRightYouTurn.Height = 110;
            btnRightYouTurn.Width = 110;
            btnLeftYouTurn.Height = 90;
            btnLeftYouTurn.Width = 96;
            btnLeftYouTurn.Text = "";
            btnLeftYouTurn.BackColor = Color.LightSteelBlue;
        }
        public void AutoYouTurnButtonsLeftTurn()
        {
            btnRightYouTurn.BackColor = Color.LightSteelBlue;
            btnRightYouTurn.Height = 90;
            btnRightYouTurn.Width = 96;
            btnRightYouTurn.Text = "";
            btnLeftYouTurn.Height = 110;
            btnLeftYouTurn.Width = 110;
            btnLeftYouTurn.BackColor = Color.Yellow;
        }
        public void AutoYouTurnButtonsReset()
        {
            //new direction so reset where to put turn diagnostic
            yt.ResetCreatedYouTurn();

            //fix the buttons
            btnLeftYouTurn.BackColor = Color.LightSteelBlue;
            btnRightYouTurn.BackColor = Color.LightSteelBlue;
            btnLeftYouTurn.Height = 90;
            btnLeftYouTurn.Width = 96;
            btnRightYouTurn.Height = 90;
            btnRightYouTurn.Width = 96;
            btnLeftYouTurn.Text = "";
            btnRightYouTurn.Text = "";

            // why yes it is backwards, puzzling
            if (!yt.isYouTurnRight)
            {
                btnLeftYouTurn.BackColor = Color.LightSteelBlue;
                btnRightYouTurn.BackColor = Color.LightGreen;
            }
            else
            {
                btnLeftYouTurn.BackColor = Color.LightGreen;
                btnRightYouTurn.BackColor = Color.LightSteelBlue;
            }
        }
        public void EnableYouTurnButtons()
        {
            btnRightYouTurn.Enabled = true;
            btnLeftYouTurn.Enabled = true;
            btnRightYouTurn.Visible = true;
            btnLeftYouTurn.Visible = true;

            //auto YouTurn disabled
            yt.isYouTurnBtnOn = false;
            yt.ResetYouTurn();

            //turn off youturn...
            btnEnableAutoYouTurn.Enabled = true;
            btnEnableAutoYouTurn.Image = Properties.Resources.YouTurnNo;
        }
        public void DisableYouTurnButtons()
        {
            btnRightYouTurn.Enabled = false;
            btnLeftYouTurn.Enabled = false;
            btnRightYouTurn.Visible = false;
            btnLeftYouTurn.Visible = false;

            btnEnableAutoYouTurn.Enabled = false;
            yt.isYouTurnBtnOn = false;
            btnEnableAutoYouTurn.Image = Properties.Resources.YouTurnNo;
            yt.ResetYouTurn();
        }

        //Options
        private void btnFlagsGoogleEarth_Click(object sender, EventArgs e)
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
        private void btnWebCam_Click(object sender, EventArgs e)
        {
            Form form = new FormWebCam();
            form.Show();
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            Process.Start("http://AgOpenGPS.gh-ortner.com/doku.php");
        }
        private void btnDeleteAllData_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                DialogResult result3 = MessageBox.Show("Delete All Contours and Sections?",
                    "Delete For sure?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (result3 == DialogResult.Yes)
                {
                    FileCreateContour();
                    FileCreateSections();

                    if (rcd.isRateControlOn)
                        btnDualRate.PerformClick();

                    rcd.ShutdownRateControl();  //double dam sure its off

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

                    //clear the section lists
                    for (int j = 0; j < MAXSECTIONS; j++)
                    {
                        //clean out the lists
                        section[j].patchList?.Clear();
                        section[j].triangleList?.Clear();
                    }

                    //clear out the contour Lists
                    ct.StopContourLine(pivotAxlePos);
                    ct.ResetContour();
                    fd.workedAreaTotal = 0;
                }
                else TimedMessageBox(1500, "Nothing Deleted", "Action has been cancelled");
            }
        }
        private void cboxpRowWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            yt.rowSkipsWidth = cboxpRowWidth.SelectedIndex + 1;
            yt.ResetCreatedYouTurn();
            Properties.Vehicle.Default.set_youSkipWidth = yt.rowSkipsWidth;
            Properties.Vehicle.Default.Save();
        }

        // Menu Items ------------------------------------------------------------------

        //File drop down items
        private void loadVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show();
                return;
            }
            if (FileOpenVehicle())
            {
                using (var form = new FormSettings(this, 0))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK) { }
                }
                using (var form = new FormDisplaySettings(this))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK) { }
                }

                TimedMessageBox(4000, "Did you make changes to the vehicle?", "Be sure to save vehicle if you did.");
            }

        }
        private void saveVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileSaveVehicle();
        }
        private void fieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JobNewOpenResume();
        }
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
                MessageBox.Show(gStr.gsProgramExitAndRestart);
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
                MessageBox.Show("AgOpenGPS will Exit", "Please Restart the Program");
                if (isJobStarted) JobClose();
                Application.Exit();
            }
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
            MessageBox.Show(gStr.gsProgramExitAndRestart);
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
            MessageBox.Show(gStr.gsProgramExitAndRestart);
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
            MessageBox.Show(gStr.gsProgramExitAndRestart);
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
            MessageBox.Show(gStr.gsProgramExitAndRestart);
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
            MessageBox.Show(gStr.gsProgramExitAndRestart);
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
            MessageBox.Show(gStr.gsProgramExitAndRestart);
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
            MessageBox.Show(gStr.gsProgramExitAndRestart);
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
                DialogResult result2 = MessageBox.Show("Really Reset Everything?", "Reset settings",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result2 == DialogResult.Yes)
                {
                    Settings.Default.Reset();
                    Settings.Default.Save();
                    Vehicle.Default.Reset();
                    Vehicle.Default.Save();
                    MessageBox.Show(gStr.gsProgramExitAndRestart);
                    Application.Exit();
                }
            }
        }
        private void logNMEAMenuItem_Click(object sender, EventArgs e)
        {
            isLogNMEA = !isLogNMEA;
            logNMEAMenuItem.Checked = isLogNMEA;
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
            polygonsToolStripMenuItem.Checked = !polygonsToolStripMenuItem.Checked;
        }
        private void gridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isGridOn = !isGridOn;
            gridToolStripMenuItem.Checked = isGridOn;
            Settings.Default.setMenu_isGridOn = isGridOn;
            Settings.Default.Save();
        }
        private void sideGuideLines_Click(object sender, EventArgs e)
        {
            isSideGuideLines = !isSideGuideLines;
            sideGuideLines.Checked = isSideGuideLines;
            Settings.Default.setMenu_isSideGuideLines = isSideGuideLines;
            Settings.Default.Save();
        }
        private void pursuitLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isPureDisplayOn = !isPureDisplayOn;
            pursuitLineToolStripMenuItem.Checked = isPureDisplayOn;
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
            lblSpeedUnits.Text = "kmh";
            if (isMetric)
            {
                btnSelectRate1.Text = Math.Round(rcd.rateLeft,1).ToString("N1");
                btnSelectRate2.Text = Math.Round(rcd.rateRight,1).ToString("N1");
                lblFlowLeft.Text = "LPM"; //lblFlowRight.Text = "LPM";

            }
            else
            {
                btnSelectRate1.Text = (rcd.rateLeft * glm.LHa2galAc).ToString("N1");
                btnSelectRate2.Text = (rcd.rateRight * glm.LHa2galAc).ToString("N1");
                lblFlowLeft.Text = "GPM"; //lblFlowRight.Text = "GPM";

            }

        }
        private void skyToolStripMenu_Click(object sender, EventArgs e)
        {
            isSkyOn = !isSkyOn;
            skyToolStripMenu.Checked = isSkyOn;
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
            lblSpeedUnits.Text = "mph";

            if (isMetric)
            {
                btnSelectRate1.Text = Math.Round(rcd.rateLeft,1).ToString("N1");
                btnSelectRate2.Text = Math.Round(rcd.rateRight,1).ToString("N1");
                lblFlowLeft.Text = "LPM"; //lblFlowRight.Text = "LPM";
            }
            else
            {
                btnSelectRate1.Text = (rcd.rateLeft * glm.LHa2galAc).ToString("N1");
                btnSelectRate2.Text = (rcd.rateRight * glm.LHa2galAc).ToString("N1");
                lblFlowLeft.Text = "GPM"; //lblFlowRight.Text = "GPM";
            }
        }
        private void simulatorOnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (simulatorOnToolStripMenuItem.Checked)
            {
                panelSimControls.Visible = true;
                timerSim.Enabled = true;
            }
            else
            {
                panelSimControls.Visible = false;
                timerSim.Enabled = false;
            }

            Settings.Default.setMenu_isSimulatorOn = simulatorOnToolStripMenuItem.Checked;
            Settings.Default.Save();
            LineUpManualBtns();
        }

        //setting color off Options Menu
        private void sectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //color picker for sections
            ColorDialog colorDlg = new ColorDialog
            {
                FullOpen = true,
                AnyColor = true,
                SolidColorOnly = false,
                Color = Color.FromArgb(255, redSections, grnSections, bluSections)
            };

            if (colorDlg.ShowDialog() != DialogResult.OK) return;

            redSections = colorDlg.Color.R;
            if (redSections > 253) redSections = 253;
            grnSections = colorDlg.Color.G;
            if (grnSections > 253) grnSections = 253;
            bluSections = colorDlg.Color.B;
            if (bluSections > 253) bluSections = 253;

            Settings.Default.setF_SectionColorR = redSections;
            Settings.Default.setF_SectionColorG = grnSections;
            Settings.Default.setF_SectionColorB = bluSections;
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
                Color = Color.FromArgb(255, Settings.Default.setF_FieldColorR,
                Settings.Default.setF_FieldColorG, Settings.Default.setF_FieldColorB)
            };

            if (colorDlg.ShowDialog() != DialogResult.OK) return;

            redField = colorDlg.Color.R;
            if (redField > 253) redField = 253;
            grnField = colorDlg.Color.G;
            if (grnField > 253) grnField = 253;
            bluField = colorDlg.Color.B;
            if (bluField > 253) bluField = 253;

            Settings.Default.setF_FieldColorR = redField;
            Settings.Default.setF_FieldColorG = grnField;
            Settings.Default.setF_FieldColorB = bluField;
            Settings.Default.Save();
        }

        //Area button context menu items
        private void toolStripMenuAreaSide_Click(object sender, EventArgs e)
        {
            isAreaOnRight = !isAreaOnRight;
            Settings.Default.setMenu_isAreaRight = isAreaOnRight;
            Settings.Default.Save();
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

        private void oglMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //0 at bottom for opengl, 0 at top for windows, so invert Y value
                Point point = oglMain.PointToClient(Cursor.Position);
                mouseX = point.X;
                mouseY = oglMain.Height - point.Y;
                leftMouseDownOnOpenGL = true;
            }
        }

        //taskbar buttons
        private void toolStripBtnSmoothABCurve_Click(object sender, EventArgs e)
        {
            if (isJobStarted && curve.isCurveBtnOn)
            {
                using (var form = new FormSmoothAB(this))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK) { }
                }
            }

            else
            {
                if (!isJobStarted)  TimedMessageBox(2000, gStr.gsFieldNotOpen, gStr.gsStartNewField);
                else TimedMessageBox(2000, gStr.gsCurveNotOn, gStr.gsCurveTurnOn);
            }
        }
        private void toolStripAreYouSure_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                DialogResult result3 = MessageBox.Show("Delete All Contours and Sections?",
                    "Delete For sure?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (result3 == DialogResult.Yes)
                {
                    FileCreateContour();
                    FileCreateSections();

                    if (rcd.isRateControlOn)
                        btnDualRate.PerformClick();

                    rcd.ShutdownRateControl();  //double dam sure its off

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
                else TimedMessageBox(1500, "Nothing Deleted", "Action has been cancelled");
            }
        }
        private void toolStripBtnMakeBndContour_Click(object sender, EventArgs e)
        {
            //build all the contour guidance lines from boundaries, all of them. 
            ct.BuildBoundaryContours();
        }
        private void toolStripBtnSnap_Click(object sender, EventArgs e)
        {
            if (ABLine.isABLineSet) ABLine.SnapABLine();
            else if (curve.isCurveSet) curve.SnapABCurve();
            else
            {
                var form = new FormTimedMessage(2000, (gStr.gsNoGuidanceLines), (gStr.gsTurnOnContourOrABLine));
                form.Show();
            }
        }
        
        private void toolstripYouTurnConfig_Click(object sender, EventArgs e)
        {
            var form = new FormYouTurn(this);
            form.ShowDialog();
            cboxpRowWidth.SelectedIndex = yt.rowSkipsWidth - 1;
        }
        private void treePlanterToolStripMenuItem_Click(object sender, EventArgs e)
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


        private void toolstripAutoSteerConfig_Click(object sender, EventArgs e)
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
        private void toolStripAutoSteerChart_Click(object sender, EventArgs e)
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

        private void toolStripNTRIPConfig_Click(object sender, EventArgs e)
        {
            SettingsNTRIP();
        }
        private void deleteContourPathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FileCreateContour();
            ct.stripList?.Clear();
            ct.ptList?.Clear();
            ct.ctList?.Clear();
            contourSaveList?.Clear();
        }


        private void toolstripVehicleConfig_Click(object sender, EventArgs e)
        {
            using (var form = new FormSettings(this, 0))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) { }
            }
        }
        private void toolstripDisplayConfig_Click(object sender, EventArgs e)
        {
            using (var form = new FormDisplaySettings(this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) { }
            }
        }
        private void toolstripUSBPortsConfig_Click(object sender, EventArgs e)
        {
            SettingsCommunications();
        }
        private void toolstripUDPConfig_Click(object sender, EventArgs e)
        {
            SettingsUDP();
        }
        private void toolstripResetTrip_Click_1(object sender, EventArgs e)
        {
            fd.distanceUser = 0;
            fd.workedAreaTotalUser = 0;
        }
        private void toolstripVR_Click(object sender, EventArgs e)
        {
            if (!isJobStarted)
            {
                TimedMessageBox(1000, "No Field Open", "Please Start a Field");
                return;
            }

            using (var form = new FormVRate(this))
            {
                var result = form.ShowDialog();
                //if (result == DialogResult.OK)
                //{
                //    Form form2 = new FormBoundaryPlayer(this);
                //    form2.Show();
                //}
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
        private void toolstripBoundary_Click(object sender, EventArgs e)
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
            else { TimedMessageBox(3000, gStr.gsFieldNotOpen, gStr.gsStartNewField ); }
        }
        private void toolstripField_Click(object sender, EventArgs e)
        {
            JobNewOpenResume();
        }
        private void toolStripBtnHideTabs_Click(object sender, EventArgs e)
        {
            SwapBatmanPanels();
        }
        private void toolStripBatman_Click(object sender, EventArgs e)
        {
            SwapBatmanPanels();
        }

        //camera tool buttons
        private void CameraFollowingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            camera.camFollowing = true;
            camera.camPitch = -70;
        }
        private void CameraNorthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            camera.camFollowing = false;
        }
        private void CameraTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            camera.camFollowing = true;
            camera.camPitch = 0;
        }

        //Sim controls
        private void timerSim_Tick(object sender, EventArgs e)
        {
            //if a GPS is connected disable sim
            //if (!sp.IsOpen)
            {
                if (isAutoSteerBtnOn && (guidanceLineDistanceOff != 32000)) sim.DoSimTick(guidanceLineSteerAngle * 0.01);
                else if (recPath.isDrivingRecordedPath) sim.DoSimTick(guidanceLineSteerAngle * 0.01);
                else if (self.isSelfDriving) sim.DoSimTick(guidanceLineSteerAngle * 0.01);
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
            sim.latitude = Properties.Settings.Default.setGPS_Latitude;
            sim.longitude = Properties.Settings.Default.setGPS_Longitude;
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
        public string Heading { get { return Convert.ToString(Math.Round(glm.toDegrees(fixHeading), 1)) + "\u00B0"; } }
        public string GPSHeading { get { return (Math.Round(glm.toDegrees(gpsHeading), 1)) + "\u00B0"; } }
        public string Status { get { if (pn.status == "A") return "Active"; else return "Void"; } }
        public string FixQuality
        {
            get
            {
                if (timerSim.Enabled)
                    return "Simulator";
                else if (pn.fixQuality == 0) return "Invalid";
                else if (pn.fixQuality == 1) return "GPS fix";
                else if (pn.fixQuality == 2) return "DGPS fix";
                else if (pn.fixQuality == 3) return "PPS fix";
                else if (pn.fixQuality == 4) return "RTK fix";
                else if (pn.fixQuality == 5) return "Flt RTK";
                else if (pn.fixQuality == 6) return "Estimate";
                else if (pn.fixQuality == 7) return "Man IP";
                else if (pn.fixQuality == 8) return "Simulator";
                else return "Unknown";
            }
        }

        public string GyroInDegrees
        {
            get
            {
                if (mc.gyroHeading != 9999)
                    return Math.Round(mc.gyroHeading * 0.0625, 1) + "\u00B0";
                else return "-";
            }
        }
        public string RollInDegrees
        {
            get
            {
                if (mc.rollRaw != 9999)
                    return Math.Round((mc.rollRaw - ahrs.rollZero) * 0.0625, 1) + "\u00B0";
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
                return (crossTrackError/10 + " cm");
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

        public string PeriAreaAcres { get { return Math.Round(periArea.area * 0.000247105, 2).ToString(); } }
        public string PeriAreaHectares { get { return Math.Round(periArea.area * 0.0001, 2).ToString(); } }

        //rate control DUAL
        public string RateDualAccumulatedVolumeLiters { get { return rcd.dualVolumeActual.ToString("N0") + " L"; } }
        public string RateDualAccumulatedVolumeGallons { get { return ((double)rcd.dualVolumeActual * 0.264172875).ToString("N0") + " Gal"; } }
        public string RateAppliedActualRightLPerHA
        {
            get
            {
                if (rcd.rateSetPointRight != 0)
                    return (rcd.rateActualRight / (rcd.currentWidthRight * pn.speed * .0016666666666 + 0.0001)).ToString("N1");
                else return "0";
            }
        }
        public string RateAppliedActualRightGPA
        {
            get
            {
                if (rcd.rateSetPointRight != 0)
                    return ((rcd.rateActualRight / (rcd.currentWidthRight * pn.speed * .0016666666666 + 0.0001)) * glm.LHa2galAc).ToString("N1");
                else return "0";
            }
        }
        public string RateAppliedActualLeftLPerHA
        {
            get
            {
                if (rcd.rateSetPointLeft != 0)
                    return (rcd.rateActualLeft / (rcd.currentWidthLeft * pn.speed * .0016666666666 + 0.0001)).ToString("N1");
                else return "0";
            }
        }
        public string RateAppliedActualLeftGPA
        {
            get
            {
                if (rcd.rateSetPointLeft != 0)
                    return ((rcd.rateActualLeft / (rcd.currentWidthLeft * pn.speed * .0016666666666 + 0.0001)) * glm.LHa2galAc).ToString("N1");
                else return "0";
            }
        }

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
            //go see if data ready for draw and position updates
            tmrWatchdog.Enabled = false;

            //did we get a new fix position?
            if (ScanForNMEA())
            {

                if (threeSecondCounter++ >= fixUpdateHz * 3)
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
                if (oneFifthSecondCounter++ >= 0)
                {
                    oneFifthSecondCounter = 0;
                    oneFifthSecond++;
                }

                //every fifth second update  ///////////////////////////   FIFTH Fifth ////////////////////////////
                if (displayUpdateOneFifthCounter != oneFifthSecond)
                {
                    //reset the counter
                    displayUpdateOneFifthCounter = oneFifthSecond;

                    lblHeading.Text = Heading;

                    if (tabControl1.SelectedIndex == 3 && tabControl1.Visible)
                    {

                        if (guidanceLineDistanceOff == 32020 | guidanceLineDistanceOff == 32000)
                        {
                            lblSetpointSteerAngle2.Text = "Off  ";
                            //lblDiffSteerAngle2.Text = "Off";
                        }
                        else
                        {
                            lblSetpointSteerAngle2.Text = SetSteerAngle;
                            //lblDiffSteerAngle2.Text = DiffSteerAngle;
                        }

                        lblActualSteerAngle2.Text = ActualSteerAngle;
                        {

                            lblRoll.Text = RollInDegrees;
                            lblYawHeading.Text = GyroInDegrees;
                            lblGPSHeading.Text = GPSHeading;
                            lblHeading2.Text = lblHeading.Text;
                        }
                    }

                    if (panelBatman.Visible)
                    {
                        lblpRoll.Text = RollInDegrees;
                        lblpYawHeading.Text = GyroInDegrees;
                        lblpGPSHeading.Text = GPSHeading;
                    }
                }

                //every second update all status ///////////////////////////   1 1 1 1 1 1 ////////////////////////////
                if (displayUpdateOneSecondCounter != oneSecond)
                {
                    //reset the counter
                    displayUpdateOneSecondCounter = oneSecond;

                    //counter used for saving field in background
                    saveCounter++;

                    //count up the ntrip clock only if everything is alive
                    if (startCounter > 50 && recvCounter < 20 && isNTRIP_RequiredOn)
                    {
                        IncrementNTRIPWatchDog();
                    }

                    //double vr = 0;
                    int cnt = rateMap.mapList.Count;
                    if (cnt > 5)
                    {
                        for (int i = 0; i < cnt; i++)
                        {
                            if (Math.Abs(rateMap.mapList[i].easting - pn.fix.easting) < 9)
                            {
                                if (Math.Abs(rateMap.mapList[i].northing - pn.fix.northing) < 9)
                                {
                                    lblVRRed.Text = rateMap.mapList[i].red.ToString();
                                    lblVRGrn.Text = rateMap.mapList[i].grn.ToString();
                                    lblVRBlu.Text = rateMap.mapList[i].blu.ToString();
                                    //vr = rateMap.mapList[i].heading;
                                    break;
                                }
                            }
                        }

                        //rcd.rateLeft = vr / 3;
                        //lblRateSetpointLeft.Text = rcd.rateLeft.ToString("N1");
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
                            TimedMessageBox(2000, " Socket Connection Problem ", " Not Connecting to Caster ");
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

                    //display items
                    lblUturnByte.Text = Convert.ToString(mc.autoSteerData[mc.sdYouTurnByte], 2).PadLeft(6, '0');

                    if (isNTRIP_RequiredOn)
                    {
                        //update byte counter and up counter
                        if (ntripCounter > 59) lblNTRIPSeconds.Text = (ntripCounter / 60) + " Mins";
                        else if (ntripCounter < 60 && ntripCounter > 22) lblNTRIPSeconds.Text = ntripCounter + " Secs";
                        else lblNTRIPSeconds.Text = "Connecting in " + (ntripCounter - 22);

                        pbarNtrip.Value = (byte)(tripBytes * 0.02);
                        lblNtripBytes.Text = ((tripBytes) * 0.001).ToString("###,###,###") + " Kb";

                        //watchdog for Ntrip
                        if (isNTRIP_Connecting) lblWatch.Text = "Authorizing";
                        else
                        {
                            if (NTRIP_Watchdog > 10) lblWatch.Text = "Waiting";
                            else lblWatch.Text = "Listening";
                        }

                        if (sendGGAInterval > 0 && isNTRIP_Sending)
                        {
                            lblWatch.Text = "Sending GGA";
                            isNTRIP_Sending = false;
                        }
                    }

                    //the main formgps window
                    if (isMetric)  //metric or imperial
                    {
                        //Hectares on the master section soft control and sections
                        btnSectionOffAutoOn.Text = fd.WorkedHectares;
                        lblSpeed.Text = SpeedKPH;

                        //status strip values
                        stripDistance.Text = fd.DistanceUserMeters + "\r\n" + fd.WorkedUserHectares2;

                        //rate
                        if (rcd.isRateControlOn && tabControl1.SelectedIndex == 1)
                        {
                            lblDualAccumulatedVolume.Text = RateDualAccumulatedVolumeLiters;
                            //lblRateAppliedActualRight.Text = RateAppliedActualRightLPerHA;
                            lblRateAppliedActualLeft.Text = RateAppliedActualLeftLPerHA;

                            lblFlowRateLeft.Text = rcd.rateSetPointLeft.ToString("N1");
                            //lblFlowRateRight.Text = rcd.rateSetPointRight.ToString("N1");
                        }

                        //from rateRelay
                        txtBoxRecvArduino.Text = mc.serialRecvRelayRateStr;
                        txtBoxSendArduino.Text = mc.relayRateData[2] + "," + mc.relayRateData[3] + "," + mc.relayRateData[4] //relay and speed x 4
                            + "," + mc.relayRateData[5] + "," + mc.relayRateData[6] + "," + mc.relayRateData[7] + "," + mc.relayRateData[8] //setpoint hi lo left and right
                        + "," + mc.relayRateData[9];

                        btnContour.Text = XTE; //cross track error

                    }
                    else  //Imperial Measurements
                    {
                        //acres on the master section soft control and sections
                        btnSectionOffAutoOn.Text = fd.WorkedAcres;
                        lblSpeed.Text = SpeedMPH;

                        //status strip values
                        stripDistance.Text = fd.DistanceUserFeet + "\r\n" + fd.WorkedUserAcres2;
                        btnContour.Text = InchXTE; //cross track error

                        //rate
                        if (rcd.isRateControlOn && tabControl1.SelectedIndex == 1)
                        {
                            lblDualAccumulatedVolume.Text = RateDualAccumulatedVolumeGallons;
                            //lblRateAppliedActualRight.Text = RateAppliedActualRightGPA;
                            lblRateAppliedActualLeft.Text = RateAppliedActualLeftGPA;
                            lblFlowRateLeft.Text = (rcd.rateSetPointLeft * 0.264172875).ToString("N1");
                            //lblFlowRateRight.Text = (rcd.rateSetPointRight * 0.264172875).ToString("N1");
                        }

                        //from rateRelay
                        txtBoxRecvArduino.Text = mc.serialRecvRelayRateStr;
                        txtBoxSendArduino.Text = mc.relayRateData[2] + "," + mc.relayRateData[3] + "," + mc.relayRateData[4] //relay and speed x 4
                            + "," + mc.relayRateData[5] + "," + mc.relayRateData[6] + "," + mc.relayRateData[7] + "," + mc.relayRateData[8] //setpoint hi lo left and right
                        + "," + mc.relayRateData[9];
                    }

                    //statusbar flash red undefined headland
                    if (mc.isOutOfBounds && statusStrip1.BackColor == SystemColors.ControlLight
                        || !mc.isOutOfBounds && statusStrip1.BackColor == Color.Tomato)
                    {
                        if (!mc.isOutOfBounds)
                        {
                            statusStrip1.BackColor = SystemColors.ControlLight;
                            menuStrip1.BackColor = SystemColors.ControlLight;
                            lblSpeed.BackColor = SystemColors.ControlLight;
                            lblHeading.BackColor = SystemColors.ControlLight;
                            lblSpeedUnits.BackColor = SystemColors.ControlLight;
                            txtDistanceOffABLine.BackColor = SystemColors.ControlLight;
                            lblHz.BackColor = SystemColors.ControlLight;
                            lblFixQuality.BackColor = SystemColors.ControlLight;
                        }
                        else
                        {
                            statusStrip1.BackColor = Color.Tomato;
                            menuStrip1.BackColor = Color.Tomato;
                            lblSpeed.BackColor = Color.Tomato;
                            lblHeading.BackColor = Color.Tomato;
                            lblSpeedUnits.BackColor = Color.Tomato;
                            txtDistanceOffABLine.BackColor = Color.Tomato;
                            lblHz.BackColor = Color.Tomato;
                            lblFixQuality.BackColor = Color.Tomato;
                        }
                    }

                    //not Metric/Standard units sensitive
                    lblFixQuality.Text = FixQuality;
                    lblLidarDistance.Text = (mc.lidarDistance * 0.01).ToString();
                    lblHz.Text = NMEAHz + "Hz " + (int)(frameTime);


                }

                //every half of a second update all status  ////////////////    0.5  0.5   0.5    0.5    /////////////////
                if (displayUpdateHalfSecondCounter != oneHalfSecond)
                {
                    //reset the counter
                    displayUpdateHalfSecondCounter = oneHalfSecond;

                    if (tabControl1.SelectedIndex == 3 && tabControl1.Visible)
                    {
                        //both
                        lblLatitude.Text = Latitude;
                        lblLongitude.Text = Longitude;

                        lblMachineControl.Text = Convert.ToString(mc.machineControlData[mc.cnPedalControl], 2).PadLeft(8, '0');
                        lblLookAhead.Text = lookaheadActual.ToString("N1") + " m";

                        txtBoxRecvAutoSteer.Text = mc.serialRecvAutoSteerStr;
                        txtBoxSendAutoSteer.Text = mc.autoSteerData[mc.sdRelayLo] + ", " + mc.autoSteerData[mc.sdSpeed]
                                                + ", " + guidanceLineDistanceOff + ", " + guidanceLineSteerAngle + ", " + mc.machineControlData[mc.cnYouTurn];


                        //up in the menu a few pieces of info
                        if (isJobStarted)
                        {
                            lblEasting.Text = "E:" + Math.Round(pn.fix.easting, 1).ToString();
                            lblNorthing.Text = "N:" + Math.Round(pn.fix.northing, 1).ToString();
                        }
                        else
                        {
                            lblEasting.Text = "E:" + ((int)pn.actualEasting).ToString();
                            lblNorthing.Text = "N:" + ((int)pn.actualNorthing).ToString();
                        }

                        tboxSentence.Text = recvSentenceSettings;

                    }

                    if (isMetric)
                    {
                        if (bnd.bndArr[0].isSet)
                        {
                            if (yt.isYouTurnRight)
                            {
                                if (!yt.isYouTurnTriggered) btnLeftYouTurn.Text = DistPivotM;
                                else { btnLeftYouTurn.Text = ""; btnRightYouTurn.Text = "Cancel" + "\r\n" + yt.onA; }
                            }
                            else
                            {
                                if (!yt.isYouTurnTriggered) btnRightYouTurn.Text = DistPivotM;
                                else { btnRightYouTurn.Text = ""; btnLeftYouTurn.Text = "Cancel" + "\r\n" + yt.onA; }
                            }
                        }
                    }
                    else
                    {

                        if (bnd.bndArr[0].isSet)
                        {
                            if (yt.isYouTurnRight)
                            {
                                if (!yt.isYouTurnTriggered) btnLeftYouTurn.Text = DistPivotFt;
                                else { btnLeftYouTurn.Text = ""; btnRightYouTurn.Text = "Cancel" + "\r\n" + yt.onA; }
                            }
                            else
                            {
                                if (!yt.isYouTurnTriggered) btnRightYouTurn.Text = DistPivotFt;
                                else { btnRightYouTurn.Text = ""; btnLeftYouTurn.Text = "Cancel" + "\r\n" + yt.onA; }
                            }
                        }
                    }

                } //end every 1/2 second
                  /////////////////////////////////////////////////////////   333333333333333  ////////////////////////////////////////

                //every 3 second update status
                if (displayUpdateThreeSecondCounter != threeSeconds)
                {
                    //reset the counter
                    displayUpdateThreeSecondCounter = threeSeconds;

                    if (panelBatman.Visible)
                    {
                        if (isMetric)
                        {
                            lblpAltitude.Text = Altitude;
                            lblpBoundaryArea.Text = fd.AreaBoundaryLessInnersHectares;
                            lblpAreaWorked.Text = fd.WorkedHectares;
                            lblpFieldAreaRemain.Text = fd.WorkedAreaRemainHectares;
                        }
                        else //imperial
                        {
                            lblpAltitude.Text = AltitudeFeet;
                            lblpBoundaryArea.Text = fd.AreaBoundaryLessInnersAcres;
                            lblpAreaWorked.Text = fd.WorkedAcres;
                            lblpFieldAreaRemain.Text = fd.WorkedAreaRemainAcres;
                        }

                        //both
                        lblpFieldAreaRemainPercent.Text = fd.WorkedAreaRemainPercentage;
                        lblpTimeToFinish.Text = fd.TimeTillFinished;
                    }

                    //The tabbed is selected and the info tab
                    if (tabControl1.SelectedIndex == 3 && tabControl1.Visible)
                    {
                        if (isMetric)
                        {
                            lblAltitude.Text = Altitude;
                            lblBoundaryArea.Text = fd.AreaBoundaryLessInnersHectares;
                            lblBoundaryDistanceAway.Text = ((int)(distancePivotToTurnLine)) + " m";
                            //if (distPivot > 0) lblBoundaryDistanceAway.Text = ((int)(distPivot)) + " m";
                            //else lblBoundaryDistanceAway.Text = "***";
                            //if (distTool > -2220) lblHeadlandDistanceFromTool.Text = DistPivotM;
                            //else lblHeadlandDistanceFromTool.Text = " * ";
                        }
                        else //imperial
                        {
                            lblAltitude.Text = AltitudeFeet;
                            ////Boundary
                            lblBoundaryArea.Text = fd.AreaBoundaryLessInnersAcres;
                            lblBoundaryDistanceAway.Text = ((int)(glm.m2ft * distancePivotToTurnLine)) + " ft";
                            //if (distPivot > 0) lblBoundaryDistanceAway.Text = ((int)(glm.m2ft * distPivot)) + " ft";
                            //else lblBoundaryDistanceAway.Text = "***";
                            //lblHeadlandDistanceFromTool.Text = DistPivotFt;
                        }

                        //both
                        lblSats.Text = SatsTracked;
                        lblZone.Text = pn.zone.ToString();
                        tboxSentence.Text = recvSentenceSettings;
                    }

                    //the main formgps window
                    if (isMetric)  //metric or imperial
                    {
                        //Hectares on the master section soft control and sections
                        btnPerimeter.Text = PeriAreaHectares;    //area button

                        //status strip values
                        stripEqWidth.Text = vehiclefileName + (Math.Round(vehicle.toolWidth, 2)).ToString() + " m";

                        //Hectares per hour
                        lblAreaRate.Text = fd.WorkRateHectares;
                    }
                    else  //Imperial Measurements
                    {
                        btnPerimeter.Text = PeriAreaAcres;

                        //status strip values
                        stripEqWidth.Text = vehiclefileName + (Math.Round(vehicle.toolWidth * glm.m2ft, 2)).ToString() + " ft";

                        //Acres per hour
                        lblAreaRate.Text = fd.WorkRateAcres;
                    }

                    //not Metric/Standard units sensitive
                    btnABLine.Text = PassNumber;

                    //update the online indicator
                    if (recvCounter > 50)
                    {
                        stripOnlineGPS.Value = 1;
                        lblEasting.Text = "-";
                        lblNorthing.Text = gStr.gsNoGPS;
                        lblZone.Text = "-";
                        tboxSentence.Text = gStr.gsNoSentenceData;
                    }
                    else stripOnlineGPS.Value = 100;

                }//end every 3 seconds

                swFrame.Stop();

                //stop the timer and calc how long it took to do calcs and draw
                frameTime = (double)swFrame.ElapsedTicks / (double)System.Diagnostics.Stopwatch.Frequency * 1000;

            } //there was a new GPS update

            //start timer again and wait for new fix
            tmrWatchdog.Enabled = true;

        }//wait till timer fires again.  
    }//end class
}//end namespace