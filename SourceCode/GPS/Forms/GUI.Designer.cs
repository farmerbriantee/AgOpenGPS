//Please, if you use this, share the improvements

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using SharpGL;
using AgOpenGPS.Properties;
using Microsoft.Win32;

namespace AgOpenGPS
{
    public partial class FormGPS
    {
        private void LoadGUI()
        {
            //fix buttons
            btnSection1Man.Enabled = false;
            btnSection2Man.Enabled = false;
            btnSection3Man.Enabled = false;
            btnSection4Man.Enabled = false;
            btnSection5Man.Enabled = false;

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
            }
            else
            {
                lblSpeedUnits.Text = "mph";
                metricToolStrip.Checked = false;
                imperialToolStrip.Checked = true;
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
            btnSwapDirection.Visible = false;

            //rate control button

            btnRate.Text = gStr.gsOff;

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

            isBigAltitudeOn = Settings.Default.setMenu_isBigAltitudeOn;
            bigAltitudeToolStripMenuItem.Checked = isBigAltitudeOn;

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

            //set the language to last used
            SetLanguage(Settings.Default.set_culture);
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
        }

        //line up section On Off Auto buttons based on how many there are
        public void LineUpManualBtns()
        {
            if (tabControl1.Visible)
            {
                btnRightYouTurn.Left = (Width - 530) / 2 + 70;
                btnLeftYouTurn.Left = (Width - 530) / 2 - 140;
            }
            else
            {
                btnRightYouTurn.Left = (Width) / 2 + 70;
                btnLeftYouTurn.Left = (Width) / 2 - 140;
            }

            const int top = 200;

            btnSection4Man.Top = Height - top;
            btnSection1Man.Top = Height - top;
            btnSection2Man.Top = Height - top;
            btnSection3Man.Top = Height - top;
            btnSection4Man.Top = Height - top;
            btnSection5Man.Top = Height - top;
            btnSection6Man.Top = Height - top;
            btnSection7Man.Top = Height - top;
            btnSection8Man.Top = Height - top;

            int first2Thirds;
            if (tabControl1.Visible) first2Thirds = (Width - 530) / 2;
            else first2Thirds = (Width) / 2;

            switch (vehicle.numOfSections)
            {
                case 1:
                    btnSection1Man.Left = (first2Thirds) - 30;
                    btnSection1Man.Visible = true;
                    btnSection2Man.Visible = false;
                    btnSection3Man.Visible = false;
                    btnSection4Man.Visible = false;
                    btnSection5Man.Visible = false;
                    btnSection6Man.Visible = false;
                    btnSection7Man.Visible = false;
                    btnSection8Man.Visible = false;
                    break;

                case 2:
                    btnSection1Man.Left = (first2Thirds) - 80;
                    btnSection2Man.Left = (first2Thirds) + 0;
                    btnSection1Man.Visible = true;
                    btnSection2Man.Visible = true;
                    btnSection3Man.Visible = false;
                    btnSection4Man.Visible = false;
                    btnSection5Man.Visible = false;
                    btnSection6Man.Visible = false;
                    btnSection7Man.Visible = false;
                    btnSection8Man.Visible = false;
                    break;

                case 3:
                    btnSection1Man.Left = (first2Thirds) - 110;
                    btnSection2Man.Left = (first2Thirds) - 30;
                    btnSection3Man.Left = (first2Thirds) + 50;
                    btnSection1Man.Visible = true;
                    btnSection2Man.Visible = true;
                    btnSection3Man.Visible = true;
                    btnSection4Man.Visible = false;
                    btnSection5Man.Visible = false;
                    btnSection6Man.Visible = false;
                    btnSection7Man.Visible = false;
                    btnSection8Man.Visible = false;
                    break;

                case 4:
                    btnSection1Man.Left = (first2Thirds) - 160;
                    btnSection2Man.Left = (first2Thirds) - 80;
                    btnSection3Man.Left = (first2Thirds) + 0;
                    btnSection4Man.Left = (first2Thirds) + 80;
                    btnSection1Man.Visible = true;
                    btnSection2Man.Visible = true;
                    btnSection3Man.Visible = true;
                    btnSection4Man.Visible = true;
                    btnSection5Man.Visible = false;
                    btnSection6Man.Visible = false;
                    btnSection7Man.Visible = false;
                    btnSection8Man.Visible = false;
                    break;

                case 5:
                    btnSection1Man.Left = (first2Thirds) - 190;
                    btnSection2Man.Left = (first2Thirds) - 110;
                    btnSection3Man.Left = (first2Thirds) - 30;
                    btnSection4Man.Left = (first2Thirds) + 50;
                    btnSection5Man.Left = (first2Thirds) + 130;
                    btnSection1Man.Visible = true;
                    btnSection2Man.Visible = true;
                    btnSection3Man.Visible = true;
                    btnSection4Man.Visible = true;
                    btnSection5Man.Visible = true;
                    btnSection6Man.Visible = false;
                    btnSection7Man.Visible = false;
                    btnSection8Man.Visible = false;
                    break;

                case 6:
                    btnSection1Man.Left = (first2Thirds) - 240;
                    btnSection2Man.Left = (first2Thirds) - 160;
                    btnSection3Man.Left = (first2Thirds) - 80;
                    btnSection4Man.Left = (first2Thirds) + 0;
                    btnSection5Man.Left = (first2Thirds) + 80;
                    btnSection6Man.Left = (first2Thirds) + 160;
                    btnSection1Man.Visible = true;
                    btnSection2Man.Visible = true;
                    btnSection3Man.Visible = true;
                    btnSection4Man.Visible = true;
                    btnSection5Man.Visible = true;
                    btnSection6Man.Visible = true;
                    btnSection7Man.Visible = false;
                    btnSection8Man.Visible = false;
                    break;

                case 7:
                    btnSection1Man.Left = (first2Thirds) - 270;
                    btnSection2Man.Left = (first2Thirds) - 190;
                    btnSection3Man.Left = (first2Thirds) - 110;
                    btnSection4Man.Left = (first2Thirds) - 30;
                    btnSection5Man.Left = (first2Thirds) + 50;
                    btnSection6Man.Left = (first2Thirds) + 130;
                    btnSection7Man.Left = (first2Thirds) + 210;
                    btnSection1Man.Visible = true;
                    btnSection2Man.Visible = true;
                    btnSection3Man.Visible = true;
                    btnSection4Man.Visible = true;
                    btnSection5Man.Visible = true;
                    btnSection6Man.Visible = true;
                    btnSection7Man.Visible = true;
                    btnSection8Man.Visible = false;

                    break;

                case 8:
                    btnSection1Man.Left = (first2Thirds) - 320;           //390;
                    btnSection2Man.Left = (first2Thirds) - 240;           //290;
                    btnSection3Man.Left = (first2Thirds) - 160;           //190;
                    btnSection4Man.Left = (first2Thirds) - 80;           //90;
                    btnSection5Man.Left = (first2Thirds) + 0;           //10;
                    btnSection6Man.Left = (first2Thirds) + 80;           //110;
                    btnSection7Man.Left = (first2Thirds) + 160;           //210;
                    btnSection8Man.Left = (first2Thirds) + 240;           //310;
                    btnSection1Man.Visible = true;
                    btnSection2Man.Visible = true;
                    btnSection3Man.Visible = true;
                    btnSection4Man.Visible = true;
                    btnSection5Man.Visible = true;
                    btnSection6Man.Visible = true;
                    btnSection7Man.Visible = true;
                    btnSection8Man.Visible = true;
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
                        break;
                }
            }
        }

        //hide the left panel
        public void HideTabControl()
        {
            if (tabControl1.Visible)
            {
                //tab will be gone
                tabControl1.Visible = false;
                openGLControl.Width = Width;
                btnTiltDown.Visible = false;
                btnTiltUp.Visible = false;
                btnABLine.Left = Width - 120;
                btnContour.Left = Width - 120;
                btnManualOffOn.Left = Width - 120;
                btnSectionOffAutoOn.Left = Width - 130;
                btnZoomIn.Left = 3;
                btnZoomIn.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                LineUpManualBtns();
                txtDistanceOffABLine.Left = Width/2 - 60;
                txtDistanceOffABLine.Top = 80;
            }
            else
            {
                //tab will be visible
                tabControl1.Visible = true;
                openGLControl.Width = Width - 530;
                btnTiltDown.Visible = true;
                btnTiltUp.Visible = true;
                btnABLine.Left = Width - 625;
                btnContour.Left = Width - 625;
                btnManualOffOn.Left = Width - 625;
                btnSectionOffAutoOn.Left = Width - 644;
                LineUpManualBtns();
                btnZoomIn.Left = Width - 220;
                btnZoomIn.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
                txtDistanceOffABLine.Left = (Width - 530)/2 - 60;
                txtDistanceOffABLine.Top = -1;
            }
        }

        //update individual btn based on state after push
        private void ManualBtnUpdate(int sectNumber, Button btn)
        {
            switch (section[sectNumber].manBtnState)
            {
                case manBtn.Off:
                    section[sectNumber].manBtnState = manBtn.Auto;
                    btn.Image = Properties.Resources.SectionAuto;
                    break;

                case manBtn.Auto:
                    section[sectNumber].manBtnState = manBtn.On;
                    btn.Image = Properties.Resources.SectionOn;
                    break;

                case manBtn.On:
                    section[sectNumber].manBtnState = manBtn.Off;
                    btn.Image = Properties.Resources.SectionOff;
                    break;
            }
        }
        
        // Buttons //-----------------------------------------------------------------------
        //Auto steer off and on
        private void btnAutoSteer_Click(object sender, EventArgs e)
        {
            if (isAutoSteerBtnOn)
            {
                isAutoSteerBtnOn = false;
                btnAutoSteer.Image = Properties.Resources.AutoSteerOff;
            }
            else
            {
                if (ABLine.isABLineSet | ct.isContourBtnOn)
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

        //ABLine
        private void btnABLine_Click(object sender, EventArgs e)
        {
            //if contour is on, turn it off
            if (ct.isContourBtnOn)
            {
                ct.isContourBtnOn = !ct.isContourBtnOn;
                btnContour.Image = Properties.Resources.ContourOff;
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
                    ABLine.isABLineBeingSet = false;

                    if (isAutoSteerBtnOn) btnAutoSteer.PerformClick();

                    btnRightYouTurn.Enabled = false;
                    btnLeftYouTurn.Enabled = false;
                    btnRightYouTurn.Visible = false;
                    btnLeftYouTurn.Visible = false;
                    btnSwapDirection.Visible = false;

                    btnEnableAutoYouTurn.Enabled = false;
                    yt.isYouTurnBtnOn = false;
                    btnEnableAutoYouTurn.Image = Properties.Resources.YouTurnNo;
                }

                //ab line is made
                else
                {
                    //change image to reflect on off
                    btnABLine.Image = Properties.Resources.ABLineOn;
                    ABLine.isABLineBeingSet = false;

                    btnRightYouTurn.Enabled = true;
                    btnLeftYouTurn.Enabled = true;
                    btnRightYouTurn.Visible = true;
                    btnLeftYouTurn.Visible = true;
                    btnSwapDirection.Visible = true;


                    //auto YouTurn disabled
                    yt.isYouTurnBtnOn = false;
                    yt.ResetYouTurnAndSequenceEvents();
                    youTurnProgressBar = 0;

                    //turn off youturn...
                    btnEnableAutoYouTurn.Enabled = true;
                    btnEnableAutoYouTurn.Image = Properties.Resources.YouTurnNo;
                }
            }
        }

        //turn on contour guidance or off
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
                btnSwapDirection.Visible = false;


                btnEnableAutoYouTurn.Enabled = false;
                yt.isYouTurnBtnOn = false;
                btnEnableAutoYouTurn.Image = Properties.Resources.YouTurnNo;
            }

            else
            {
                if (ABLine.isABLineSet)
                {
                    btnRightYouTurn.Enabled = true;
                    btnLeftYouTurn.Enabled = true;
                    btnRightYouTurn.Visible = true;
                    btnLeftYouTurn.Visible = true;
                    btnSwapDirection.Visible = true;

                    //auto YouTurn shutdown
                    yt.isYouTurnBtnOn = false;
                    yt.ResetYouTurnAndSequenceEvents();
                    youTurnProgressBar = 0;

                    //turn off youturn...
                    btnEnableAutoYouTurn.Enabled = true;
                    btnEnableAutoYouTurn.Image = Properties.Resources.YouTurnNo;
                }
            }
        }
        private void btnABCurve_Click(object sender, EventArgs e)
        {
            //if contour is on, turn it off
            if (ct.isContourBtnOn)
            {
                ct.isContourBtnOn = !ct.isContourBtnOn;
                btnContour.Image = Properties.Resources.ContourOff;
            }

            //turn off youturn...
            btnRightYouTurn.Enabled = false;
            btnLeftYouTurn.Enabled = false;
            btnRightYouTurn.Visible = false;
            btnLeftYouTurn.Visible = false;
            btnSwapDirection.Visible = false;

            btnEnableAutoYouTurn.Enabled = false;
            yt.isYouTurnBtnOn = false;
            btnEnableAutoYouTurn.Image = Properties.Resources.YouTurnNo;
            yt.ResetYouTurnAndSequenceEvents();

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
            ABLine.isABLineBeingSet = false;

            if (isAutoSteerBtnOn) btnAutoSteer.PerformClick();

            Form form = new FormABCurve(this);
            form.Show();
        }

        //button for Manual On Off of the sections
        private void btnManualOffOn_Click(object sender, EventArgs e)
        {
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
        //button for Auto on-off, has the acres displayed
        private void btnSectionOffAutoOn_Click(object sender, EventArgs e)
        {
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

        //The main flag marker button 
        private void btnFlag_Click(object sender, EventArgs e)
        {
            int nextflag = flagPts.Count + 1;
            CFlag flagPt = new CFlag(pn.latitude, pn.longitude, pn.fix.easting, pn.fix.northing, flagColor, nextflag);
            flagPts.Add(flagPt);
            FileSaveFlags();
        }

        //The zoom buttons in out
        private void btnZoomIn_MouseDown(object sender, MouseEventArgs e)
        {
            if (camera.zoomValue <= 20) camera.zoomValue += camera.zoomValue * 0.1;
            else camera.zoomValue += camera.zoomValue * 0.05;
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
        //view tilt up down and saving in settings
        private void btnTiltUp_MouseDown(object sender, MouseEventArgs e)
        {
            camera.camPitch -= ((camera.camPitch * 0.03) - 1);
            if (camera.camPitch > 0) camera.camPitch = 0;
        }
        private void btnTiltDown_MouseDown(object sender, MouseEventArgs e)
        {
            camera.camPitch += ((camera.camPitch * 0.03) - 1);
            if (camera.camPitch < -80) camera.camPitch = -80;
        }

        private void btnSwapDirection_Click(object sender, EventArgs e)
        {
            if (!yt.isYouTurnTriggerPointSet)
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
        private void btnSnap_Click(object sender, EventArgs e)
        {
           ABLine.SnapABLine();
        }

        //tab config buttons
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

        //YouTurn on off
        private void btnEnableAutoYouTurn_Click(object sender, EventArgs e)
        {
            if (!yt.isYouTurnBtnOn)
            {
                yt.isYouTurnBtnOn = true;
                btnEnableAutoYouTurn.Image = Properties.Resources.Youturn80;
            }
            else
            {
                yt.isYouTurnBtnOn = false;
                btnEnableAutoYouTurn.Image = Properties.Resources.YouTurnNo;
            }
        }

        //Rate
 
        private void btnRateConfig_Click(object sender, EventArgs e)
        {
            var form = new FormRate(this);
            form.ShowDialog();
            if (isMetric)
            {
                btnRate1Select.Text = (rc.rate1).ToString("N1");
                btnRate2Select.Text = (rc.rate2).ToString("N1");
            }
            else
            {
                btnRate1Select.Text = (rc.rate1 * glm.LHa2galAc).ToString("N1");
                btnRate2Select.Text = (rc.rate2 * glm.LHa2galAc).ToString("N1");
            }
        }
        private void btnRate_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                rc.isRateControlOn = !rc.isRateControlOn;

                if (rc.isRateControlOn)
                {
                    mc.relayRateSettings[mc.rsFlowCalFactorHi] = (byte)(Properties.Settings.Default.setRate_FlowmeterCalNumber >> 8);
                    mc.relayRateSettings[mc.rsFlowCalFactorLo] = (byte)(Properties.Settings.Default.setRate_FlowmeterCalNumber);
                    RateRelayOutToPort(mc.relayRateSettings, CModuleComm.numRelayRateSettingsItems);

                    //get the last saved rates from setting file - always stored in L/Ha
                    rc.rate1 = Properties.Settings.Default.setRate_rate1;
                    rc.rate2 = Properties.Settings.Default.setRate_rate2;


                    btnRate1Select.Visible = true;
                    btnRate2Select.Visible = true;
                    btnRateDn.Visible = true;
                    btnRateUp.Visible = true;
                    btnRate.Image = Properties.Resources.RateControlOn;
                    btnRate.Text = "-";

                    if (isMetric)
                    {
                        btnRate1Select.Text = (rc.rate1).ToString("N1");
                        btnRate2Select.Text = (rc.rate2).ToString("N1");
                    }
                    else
                    {
                        btnRate1Select.Text = (rc.rate1 * glm.LHa2galAc).ToString("N1");
                        btnRate2Select.Text = (rc.rate2 * glm.LHa2galAc).ToString("N1");
                    }

                    if (rc.isRate1Selected)
                    {
                        btnRate2Select.ForeColor = Color.SlateGray;
                        btnRate1Select.ForeColor = Color.Black;
                    }
                    else
                    {
                        btnRate1Select.ForeColor = Color.SlateGray;
                        btnRate2Select.ForeColor = Color.Black;
                    }
                }
                else
                {
                    btnRate1Select.Visible = false;
                    btnRate2Select.Visible = false;
                    btnRateDn.Visible = false;
                    btnRateUp.Visible = false;
                    btnRate.Image = Properties.Resources.RateControlOff;
                    btnRate.Text =(gStr.gsOff);
                    lblRateAppliedActual.Text = "-";
                    rc.rateSetPoint = 0.0;
                    mc.relayRateData[mc.rdRateSetPointLo] = 0;
                    mc.relayRateData[mc.rdRateSetPointHi] = 0;
                    RateRelayOutToPort(mc.relayRateData, CModuleComm.numRelayRateDataItems);
                }
            }
            else { TimedMessageBox(3000, gStr.gsFieldNotOpen, gStr.gsStartNewField); }
        }
        private void btnRate1Select_Click(object sender, EventArgs e)
        {
            rc.isRate1Selected = true;
            btnRate2Select.ForeColor = Color.SlateGray;
            btnRate1Select.ForeColor = Color.Black;
        }
        private void btnRate2Select_Click(object sender, EventArgs e)
        {
            rc.isRate1Selected = false;
            btnRate1Select.ForeColor = Color.SlateGray;
            btnRate2Select.ForeColor = Color.Black;
        }
        private void btnRateUp_Click(object sender, EventArgs e)
        {
            if (isMetric)
            {
                if (rc.isRate1Selected)
                {
                    rc.rate1 += 1.0;
                    btnRate1Select.Text = rc.rate1.ToString("N1");
                }
                else
                {
                    rc.rate2 += 1.0;
                    btnRate2Select.Text = rc.rate2.ToString("N1");
                }
            }
            else
            {
                if (rc.isRate1Selected)
                {
                    rc.rate1 += 1.0;
                    btnRate1Select.Text = (rc.rate1*glm.LHa2galAc).ToString("N1");
                }
                else
                {
                    rc.rate2 += 1.0;
                    btnRate2Select.Text = (rc.rate2*glm.LHa2galAc).ToString("N1");
                }
            }
        }
        private void btnRateDn_Click(object sender, EventArgs e)
        {
            if (isMetric)
            {
                if (rc.isRate1Selected)
                {
                    rc.rate1 -= 1.0;
                    if (rc.rate1 < 2.0) rc.rate1 = 2.0;
                    btnRate1Select.Text = rc.rate1.ToString("N1");
                }
                else
                {
                    rc.rate2 -= 1.0;
                    if (rc.rate2 < 2.0) rc.rate2 = 2.0;
                    btnRate2Select.Text = rc.rate2.ToString("N1");
                }
            }
            else
            {
                if (rc.isRate1Selected)
                {
                    rc.rate1 -= 1.0;
                    if (rc.rate1 < 2.0) rc.rate1 = 2.0;
                    btnRate1Select.Text = (rc.rate1 * glm.LHa2galAc).ToString("N1");
                }
                else
                {
                    rc.rate2 -= 1.0;
                    if (rc.rate2 < 2.0) rc.rate2 = 2.0;
                    btnRate2Select.Text = (rc.rate2 * glm.LHa2galAc).ToString("N1");
                }
            }
        }
        private void btnLeftYouTurn_Click(object sender, EventArgs e)
        {
            if (yt.isYouTurnTriggerPointSet)
            {
                //is it turning left already?
                if (!yt.isYouTurnRight)
                {
                    yt.ResetYouTurnAndSequenceEvents();
                    distanceToStartAutoTurn = -1;
                    AutoYouTurnButtonsReset();
                    youTurnProgressBar = 0;
                }
                else
                {
                    yt.isYouTurnRight = false;
                    AutoYouTurnButtonsLeftTurn();
                }
            }
            else
            {
                if (yt.isYouTurnShapeDisplayed)
                {
                    yt.ResetYouTurnAndSequenceEvents();
                    distanceToStartAutoTurn = -1;
                    AutoYouTurnButtonsReset();
                }
                else
                {
                    yt.isYouTurnShapeDisplayed = true;
                    yt.BuildYouTurnListToRight(false);
                    AutoYouTurnButtonsLeftTurn();
                }
            }
        }
        private void btnRightYouTurn_Click(object sender, EventArgs e)
        {
            //is it already turning right, then cancel autoturn
            if (yt.isYouTurnTriggerPointSet)
            {
                //is it turning right already?
                if (yt.isYouTurnRight)
                {
                    yt.ResetYouTurnAndSequenceEvents();
                    distanceToStartAutoTurn = -1;
                    youTurnProgressBar = 0;
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
                if (yt.isYouTurnShapeDisplayed)
                {
                    yt.ResetYouTurnAndSequenceEvents();
                    distanceToStartAutoTurn = -1;
                    AutoYouTurnButtonsReset();
                }
                else
                {
                    yt.isYouTurnShapeDisplayed = true;
                    yt.BuildYouTurnListToRight(true);
                    AutoYouTurnButtonsRightTurn();
                }
            }
        }

        public void AutoYouTurnButtonsRightTurn()
        {
            btnRightYouTurn.BackColor = Color.Yellow;
            btnRightYouTurn.Height = 120;
            btnRightYouTurn.Width = 120;
            btnLeftYouTurn.Height = 64;
            btnLeftYouTurn.Width = 64;
            btnLeftYouTurn.BackColor = Color.LightSteelBlue;
        }
        public void AutoYouTurnButtonsLeftTurn()
        {
            btnRightYouTurn.BackColor = Color.LightSteelBlue;
            btnRightYouTurn.Height = 64;
            btnRightYouTurn.Width = 64;
            btnLeftYouTurn.Height = 120;
            btnLeftYouTurn.Width = 120;
            btnLeftYouTurn.BackColor = Color.Yellow;
        }
        public void AutoYouTurnButtonsReset()
        {
            btnLeftYouTurn.BackColor = Color.LightSteelBlue;
            btnRightYouTurn.BackColor = Color.LightSteelBlue;
            btnLeftYouTurn.Height = 64;
            btnLeftYouTurn.Width = 64;
            btnRightYouTurn.Height = 64;
            btnRightYouTurn.Width = 64;

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
            Process.Start("http://agopengps.gh-ortner.com/doku.php");
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
                    FileCreateRecPath();

                    if (rc.isRateControlOn)
                        btnRate.PerformClick();

                    rc.ShutdownRateControl();  //double dam sure its off

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

                    btnSection1Man.Enabled = false;
                    btnSection2Man.Enabled = false;
                    btnSection3Man.Enabled = false;
                    btnSection4Man.Enabled = false;
                    btnSection5Man.Enabled = false;
                    btnSection6Man.Enabled = false;
                    btnSection7Man.Enabled = false;
                    btnSection8Man.Enabled = false;

                    //clear the section lists
                    for (int j = 0; j < MAXSECTIONS; j++)
                    {
                        //clean out the lists
                        section[j].patchList?.Clear();
                        section[j].triangleList?.Clear();
                    }

                    //clear out the contour Lists
                    ct.StopContourLine();
                    ct.ResetContour();
                }
                else TimedMessageBox(1500, "Nothing Deleted", "Action has been cancelled");
            }
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
            FileOpenVehicle();
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
                btnRate1Select.Text = (rc.rate1).ToString("N1");
                btnRate2Select.Text = (rc.rate2).ToString("N1");
            }
            else
            {
                btnRate1Select.Text = (rc.rate1 * glm.LHa2galAc).ToString("N1");
                btnRate2Select.Text = (rc.rate2 * glm.LHa2galAc).ToString("N1");
            }

        }
        private void bigAltitudeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isBigAltitudeOn = !isBigAltitudeOn;
            bigAltitudeToolStripMenuItem.Checked = isBigAltitudeOn;
            Settings.Default.setMenu_isBigAltitudeOn = isBigAltitudeOn;
            Settings.Default.Save();
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
                btnRate1Select.Text = (rc.rate1).ToString("N1");
                btnRate2Select.Text = (rc.rate2).ToString("N1");
            }
            else
            {
                btnRate1Select.Text = (rc.rate1 * glm.LHa2galAc).ToString("N1");
                btnRate2Select.Text = (rc.rate2 * glm.LHa2galAc).ToString("N1");
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


        //function mouse down in window for picking
        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //0 at bottom for opengl, 0 at top for windows, so invert Y value
                Point point = openGLControl.PointToClient(Cursor.Position);
                mouseX = point.X;
                mouseY = openGLControl.Height - point.Y;
                leftMouseDownOnOpenGL = true;
            }
        }

        //taskbar buttons
        private void toolstripYouTurnConfig_Click(object sender, EventArgs e)
        {
            var form = new FormYouTurn(this);
            form.ShowDialog();
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
            userDistance = 0;
            totalUserSquareMeters = 0;
        }
        private void toolstripHeadland_Click(object sender, EventArgs e)
        {
            if (boundz.isSet)
            {
                //field too small
                if (boundz.ptList.Count < 4) { TimedMessageBox(3000, "!!!!", gStr.gsBoundaryTooSmall); return; }
                using (var form = new FormHeadland(this))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {

                    }
                }
            }
            else { TimedMessageBox(3000, gStr.gsBoundaryNotSet, gStr.gsCreateBoundaryFirst); }
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

        //batman to maximize GPS mapping - hide tab control
        private void btnHideTabs_Click(object sender, EventArgs e)
        {
            HideTabControl();
        }        
        
        //Sim controls
        private void timerSim_Tick(object sender, EventArgs e)
        {
            //if a GPS is connected disable sim
            if (!sp.IsOpen)
            {
                if (isAutoSteerBtnOn) sim.DoSimTick(guidanceLineSteerAngle / 100.0);
                //if (recPath.isBtnFollowOn)sim.DoSimTick(guidanceLineSteerAngle / 100.0);
                else sim.DoSimTick(sim.steerAngleScrollBar);
            }
        }
        private void tbarStepDistance_Scroll(object sender, EventArgs e)
        {
            sim.stepDistance = ((double)(tbarStepDistance.Value)) / 10.0 / (double)fixUpdateHz;
        }
        private void tbarSteerAngle_Scroll(object sender, EventArgs e)
        {
            sim.steerAngleScrollBar = (tbarSteerAngle.Value) * 0.1;
            lblSteerAngle.Text = sim.steerAngleScrollBar.ToString("N1");
        }
        private void btnResetSteerAngle_Click(object sender, EventArgs e)
        {
            sim.steerAngleScrollBar = 0;
            tbarSteerAngle.Value = 0;
            lblSteerAngle.Text = sim.steerAngleScrollBar.ToString("N1");
        }
        private void btnResetSim_Click(object sender, EventArgs e)
        {
            sim.latitude = 53.0;
            sim.longitude = -111.0;
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
                if (pn.fixQuality == 0) return "Invalid";
                else if (pn.fixQuality == 1) return "GPS fix";
                else if (pn.fixQuality == 2) return "DGPS fix";
                else if (pn.fixQuality == 3) return "PPS fix";
                else if (pn.fixQuality == 4) return "RTK fix";
                else if (pn.fixQuality == 5) return "Flt RTK";
                else if (pn.fixQuality == 6) return "Estimate";
                else if (pn.fixQuality == 7) return "Man IP";
                else if (pn.fixQuality == 8) return "Sim";
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
        public string PureSteerAngle { get { return ((double)(guidanceLineSteerAngle) * 0.01) + "\u00B0"; } }

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

        public string Altitude { get { return Convert.ToString(Math.Round(pn.altitude,3)); } }
        public string AltitudeFeet { get { return Convert.ToString((Math.Round((pn.altitude * 3.28084),3))); } }

        public string PeriAreaAcres { get { return Math.Round(periArea.area * 0.000247105, 2).ToString(); } }
        public string PeriAreaHectares { get { return Math.Round(periArea.area * 0.0001, 2).ToString(); } }
        public string Acres { get {
                if (totalSquareMeters < 404048) return (totalSquareMeters * 0.000247105).ToString("N2");
                    else return (totalSquareMeters * 0.000247105).ToString("N1");  }  }
        public string Hectares { get { if (totalSquareMeters < 99000) return (totalSquareMeters * 0.0001).ToString("N2");
                    else return (totalSquareMeters * 0.0001).ToString("N1"); }  }
        public string AcresUser { get { return (totalUserSquareMeters * 0.000247105).ToString("N2") + " Ac"; } }
        public string HectaresUser { get { return (totalUserSquareMeters * 0.0001).ToString("N2") + " Ha"; } }

        public string RateAccumulatedVolumeLiters { get { return rc.volumeActual.ToString("N0") + " L"; } }
        public string RateAccumulatedVolumeGallons { get { return ((double)rc.volumeActual * 0.264172875).ToString("N0") + " Gal"; } }

        public string RateAppliedActualLPerHA { get {
                if (rc.currentWidth > 0) return (rc.rateActual / ((rc.currentWidth) * pn.speed * .0016666666666 + 0.00001)).ToString("N1");
                else return ("0.0");
            } }
        public string RateAppliedActualGPA { get {
                if (rc.currentWidth > 0)
                    return ((rc.rateActual / ((rc.currentWidth) * pn.speed * .0016666666666 + 0.00001)) * glm.LHa2galAc).ToString("N1");
                else return ("0.0");
            } }

        public Texture ParticleTexture { get; set; }

        #endregion properties 

        //Timer triggers at 20 msec, 50 hz, and is THE clock of the whole program//
        private void tmrWatchdog_tick(object sender, EventArgs e)
        {
            //go see if data ready for draw and position updates
            //tmrWatchdog.Enabled = false;
            ScanForNMEA();
            //tmrWatchdog.Enabled = true;
            statusUpdateCounter++;

            if (fiveSecondCounter++ > 100) { fiveSecondCounter = 0; }


            //every half of a second update all status
            if (statusUpdateCounter > 6)
            {
                //reset the counter
                statusUpdateCounter = 0;

                //counter used for saving field in background
                saveCounter++;

                if (tabControl1.SelectedIndex == 0 && tabControl1.Visible)
                {
                    if (isMetric)
                    {
                        lblAltitude.Text = Altitude;
                        ////boundary and headland
                        lblBoundaryArea.Text = boundz.areaHectare;
                        if (distPivot > 0) lblHeadlandDistanceAway.Text = ((int)(distPivot)) + "m";
                        else lblHeadlandDistanceAway.Text = "***";
                        lblHeadlandDistanceFromTool.Text = ((int)(distTool)) + "m";
                    }
                    else //imperial
                    {
                        lblAltitude.Text = AltitudeFeet;
                        ////Boundary
                        lblBoundaryArea.Text = boundz.areaAcre;
                        if (distPivot > 0) lblHeadlandDistanceAway.Text = ((int)(glm.m2ft * distPivot)) + "ft";
                        else lblHeadlandDistanceAway.Text = "***";
                        lblHeadlandDistanceFromTool.Text = ((int)(glm.m2ft * distTool)) + "ft";
                    }

                    //both
                    lblLatitude.Text = Latitude;
                    lblLongitude.Text = Longitude;
                    lblFixQuality.Text = FixQuality;
                    lblSats.Text = SatsTracked;

                    lblRoll.Text = RollInDegrees;
                    lblYawHeading.Text = GyroInDegrees;
                    lblGPSHeading.Text = GPSHeading;
                    //lblEmlidPitch.Text = pn.nPitch.ToString("N2");

                    //lblTurnProgressBar.Value = youTurnProgressBar;

                    //up in the menu a few pieces of info
                    if (isJobStarted)
                    {
                        lblEasting.Text = "E: " + Math.Round(pn.fix.easting, 1).ToString();
                        lblNorthing.Text = "N: " + Math.Round(pn.fix.northing, 1).ToString();
                    }
                    else
                    {
                        lblEasting.Text = "E: " + ((int)pn.actualEasting).ToString();
                        lblNorthing.Text = "N: " + ((int)pn.actualNorthing).ToString();
                    }

                    lblZone.Text = pn.zone.ToString();
                    tboxSentence.Text = recvSentenceSettings;

                }

                //the main formgps window
                if (isMetric)  //metric or imperial
                {
                    //Hectares on the master section soft control and sections
                    btnSectionOffAutoOn.Text = Hectares;
                    btnPerimeter.Text = PeriAreaHectares;    //area button
                    lblSpeed.Text = SpeedKPH;

                    //status strip values
                    stripDistance.Text = Convert.ToString((UInt16)(userDistance)) + " m\r\n"+HectaresUser;
                    //stripAreaUser.Text = ;
                    stripAreaRate.Text = (Math.Round(vehicle.toolWidth * pn.speed * 0.1, 2)).ToString()+ "\r\n  Ha/hr";
                    stripEqWidth.Text = vehiclefileName + (Math.Round(vehicle.toolWidth, 2)).ToString() + " m";

                    //rate
                    if (rc.isRateControlOn && tabControl1.SelectedIndex == 2)
                    {
                        lblAccumulatedVolume.Text = RateAccumulatedVolumeLiters;
                        lblRateAppliedActual.Text = RateAppliedActualLPerHA;
                        btnRate.Text = rc.rateSetPoint.ToString("N1");
                    }
                }
                else  //Imperial Measurements
                {
                    //acres on the master section soft control and sections
                    btnSectionOffAutoOn.Text = Acres;
                    btnPerimeter.Text = PeriAreaAcres; 
                    lblSpeed.Text = SpeedMPH;

                    //status strip values
                    stripDistance.Text = Convert.ToString((UInt16)(userDistance * 3.28084)) + " ft\r\n" + AcresUser;
                    //stripAreaUser.Text = ;
                    stripAreaRate.Text = ((int)((vehicle.toolWidth * pn.speed * 0.1) * 2.47)).ToString() + "\r\n  Ac/hr";
                    stripEqWidth.Text = vehiclefileName + (Math.Round(vehicle.toolWidth * glm.m2ft, 2)).ToString() + " ft";

                    //rate
                    if (rc.isRateControlOn && tabControl1.SelectedIndex == 2)
                    {
                        lblAccumulatedVolume.Text = RateAccumulatedVolumeGallons;
                        lblRateAppliedActual.Text = RateAppliedActualGPA;
                        btnRate.Text = (rc.rateSetPoint * 0.264172875).ToString("N1");
                    }
                }

                //not Metric/Standard units sensitive
                stripHz.Text = NMEAHz + "Hz " + (int)(frameTime)+ "\r\n" + Convert.ToString(mc.relayRateData[mc.rdYouTurnControlByte], 2).PadLeft(6, '0');
                lblHeading.Text = Heading;
                btnABLine.Text = PassNumber;
                lblPureSteerAngle.Text = PureSteerAngle;

                //binary of sequences
                //stripSequenceBinary.Text = ; ;
                


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
            }
            //wait till timer fires again.     
        }


    }//end class
}//end namespace