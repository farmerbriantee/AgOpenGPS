//Please, if you use this, share the improvements

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using AgOpenGPS.Properties;
using Microsoft.Win32;

namespace AgOpenGPS
{
    public partial class FormGPS
    {

        #region Right Menu
        private void btnContour_Click(object sender, EventArgs e)
        {
            ct.isContourBtnOn = !ct.isContourBtnOn;
            btnContour.Image = ct.isContourBtnOn ? Properties.Resources.ContourOn : Properties.Resources.ContourOff;

            if (ct.isContourBtnOn)
            {
                btnCycleLines.Image = Properties.Resources.ColorLocked;
                //turn off youturn...
                DisableYouTurnButtons();
                guidanceLookAheadTime = 0.5;
            }

            else
            {
                if (ABLine.isBtnABLineOn | curve.isBtnCurveOn)
                {
                    EnableYouTurnButtons();
                    ABLine.isABValid = false;
                    curve.isCurveValid = false;
                }

                btnCycleLines.Image = Properties.Resources.ABLineCycle;
                guidanceLookAheadTime = Properties.Settings.Default.setAS_guidanceLookAheadTime;
            }
        }
        private void btnCurve_Click(object sender, EventArgs e)
        {
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

            curve.isCurveValid = false;

            if (curve.isBtnCurveOn == false && curve.isCurveSet)
            {
                //display the curve
                curve.isCurveSet = true;
                EnableYouTurnButtons();
                btnCurve.Image = Properties.Resources.CurveOn;
                curve.isBtnCurveOn = true;
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
            form.Show(this);
        }
        private void btnABLine_Click(object sender, EventArgs e)
        {
            //invalidate line
            ABLine.isABValid = false;

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
                
            curve.isBtnCurveOn = false;
            btnCurve.Image = Properties.Resources.CurveOff;

            //if there is a line in memory, just use it.
            if (ABLine.isBtnABLineOn == false && ABLine.isABLineLoaded)
            {                
                ABLine.isABLineSet = true;
                EnableYouTurnButtons();
                btnABLine.Image = Properties.Resources.ABLineOn;
                ABLine.isBtnABLineOn = true;
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
                form.Show(this);
        }

        public bool isABCyled = false;
        private void btnCycleLines_Click(object sender, EventArgs e)
        {
            if (ct.isContourBtnOn)
            {
                ct.SetLockToLine();
                return;
            }

            if (ABLine.numABLines == 0 && curve.numCurveLines == 0) return; 

                //reset to generate new reference
            ABLine.isABValid = false;
            curve.isCurveValid = false;

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
                lblCurveLineName.Text = ABLine.lineArr[ABLine.numABLineSelected - 1].Name;
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
                lblCurveLineName.Text = curve.curveArr[idx].Name;
            }
        }

        private void SetABLine(int num)
        {
                ABLine.refPoint1 = ABLine.lineArr[ABLine.numABLineSelected - 1].origin;
                //ABLine.refPoint2 = ABLine.lineArr[ABLine.numABLineSelected - 1].ref2;
                ABLine.abHeading = ABLine.lineArr[ABLine.numABLineSelected - 1].heading;
                ABLine.SetABLineByHeading();
                ABLine.isABLineSet = true;
                ABLine.isABLineLoaded = true;
                yt.ResetYouTurn();
        }
        private void SetCurveLine(int num)
        {
                int idx = curve.numCurveLineSelected - 1;
                curve.aveLineHeading = curve.curveArr[idx].aveHeading;
                curve.refList?.Clear();
                for (int i = 0; i < curve.curveArr[idx].curvePts.Count; i++)
                {
                    curve.refList.Add(curve.curveArr[idx].curvePts[i]);
                }
                curve.isCurveSet = true;
                yt.ResetYouTurn();
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
                    form.Show(this);
                }
            }
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

                if (ABLine.isBtnABLineOn || curve.isBtnCurveOn)
                {
                    if (!isAutoSteerBtnOn) btnAutoSteer.PerformClick();
                }
                else return;

                yt.isYouTurnBtnOn = true;
                yt.isTurnCreationTooClose = false;
                yt.isTurnCreationNotCrossingError = false;
                yt.ResetYouTurn();
                p_239.pgn[p_239.uturn] = 0;
                btnAutoYouTurn.Image = Properties.Resources.Youturn80;
            }
            else
            {
                yt.isYouTurnBtnOn = false;
                yt.rowSkipsWidth = Properties.Vehicle.Default.set_youSkipWidth;
                yt.Set_Alternate_skips();

                btnAutoYouTurn.Image = Properties.Resources.YouTurnNo;
                yt.ResetYouTurn();

                //new direction so reset where to put turn diagnostic
                yt.ResetCreatedYouTurn();

                //mc.autoSteerData[mc.sdX] = 0;
                p_239.pgn[p_239.uturn] = 0;
            }
        }

        #endregion

        #region Section Buttons
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

        #endregion

        #region Left Panel Menu
        private void toolStripDropDownButtonDistance_Click(object sender, EventArgs e)
        {
            fd.distanceUser = 0;
            fd.workedAreaTotalUser = 0;
        }        
        private void navPanelToolStrip_Click(object sender, EventArgs e)
        {
            //buttonPanelCounter = 0;

            if (panelNavigation.Visible)
            {
                panelNavigation.Visible = false;
            }
            else
            {
                panelNavigation.Visible = true;
                navPanelCounter = 2;
            }
        }
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
        private void toolStripMenuFlagForm_Click(object sender, EventArgs e)
        {
            Form fc = Application.OpenForms["FormFlags"];

            if (fc != null)
            {
                fc.Focus();
                return;
            }

            if (flagPts.Count > 0)
            {
                flagNumberPicked = 1;
                Form form = new FormFlags(this);
                form.Show(this);
            }            
        }

        private void btnFlag_Click(object sender, EventArgs e)
        {
            int nextflag = flagPts.Count + 1;
            CFlag flagPt = new CFlag(pn.latitude, pn.longitude, pn.fix.easting, pn.fix.northing, fixHeading, flagColor, nextflag, (nextflag).ToString());
            flagPts.Add(flagPt);
            FileSaveFlags();

            Form fc = Application.OpenForms["FormFlags"];

            if (fc != null)
            {
                fc.Focus();
                return;
            }

            if (flagPts.Count > 0)
            {
                flagNumberPicked = nextflag;
                Form form = new FormFlags(this);
                form.Show(this);
            }
        }

        private void btnStartAgIO_Click(object sender, EventArgs e)
        {
            Process[] processName = Process.GetProcessesByName("AgIO");
            if (processName.Length == 0)
            {
                //Start application here
                DirectoryInfo di = new DirectoryInfo(Application.StartupPath);
                string strPath = di.ToString();
                strPath += "\\AgIO.exe";
                try
                {
                    //TimedMessageBox(2000, "Please Wait", "Starting AgIO");
                    ProcessStartInfo processInfo = new ProcessStartInfo();
                    processInfo.FileName = strPath;
                    //processInfo.ErrorDialog = true;
                    //processInfo.UseShellExecute = false;
                    processInfo.WorkingDirectory = Path.GetDirectoryName(strPath);
                    Process proc = Process.Start(processInfo);
                }
                catch
                {
                    TimedMessageBox(2000, "No File Found", "Can't Find AgIO");
                }
            }
            else
            {
                //Set foreground window
                ShowWindow(processName[0].MainWindowHandle, 9);
                SetForegroundWindow(processName[0].MainWindowHandle);
            }
        }
        private void btnAutoSteerConfig_Click(object sender, EventArgs e)
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
            form.Show(this);

        }

        #endregion

        #region Top Panel
        private void lblSpeed_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormGPSData"];

            if (f != null)
            {
                f.Focus();
                f.Close();
                return;
            }

            isGPSSentencesOn = true;

            Form form = new FormGPSData(this);
            form.Show(this);

        }
        private void btnShutdown_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnMinimizeMainForm_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnMaximizeMainForm_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else this.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region File Menu

        //File drop down items
        private void setWorkingDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show(this);
                return;
            }

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            fbd.Description = "Currently: " + Settings.Default.setF_workingDirectory;

            if (Settings.Default.setF_workingDirectory == "Default") fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else fbd.SelectedPath = Settings.Default.setF_workingDirectory;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                if (fbd.SelectedPath != Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
                {
                    Settings.Default.setF_workingDirectory = fbd.SelectedPath;
                    Settings.Default.Save();
                }
                else
                {
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
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new Form_About())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) { }
            }
        }
        private void resetALLToolStripMenuItem_Click(object sender, EventArgs e)
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

                    Settings.Default.setF_culture = "en";
                    Settings.Default.setF_workingDirectory = "Default";
                    Settings.Default.Save();

                    MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
                    System.Environment.Exit(1);
                }
            }
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

        private void helpMenuItem_Click(object sender, EventArgs e)
        {
            bool notFound = false;
            try
            {
                switch (Settings.Default.setF_culture)
                {
                    case "en":
                        System.Diagnostics.Process.Start("Manual.pdf");
                        break;

                    case "ru":
                        System.Diagnostics.Process.Start("Manual.ru.pdf");
                        break;

                    case "da":
                        System.Diagnostics.Process.Start("Manual.da.pdf");
                        break;

                    case "de":
                        System.Diagnostics.Process.Start("Manual.de.pdf");
                        break;

                    case "nl":
                        System.Diagnostics.Process.Start("Manual.nl.pdf");
                        break;

                    case "it":
                        System.Diagnostics.Process.Start("Manual.it.pdf");
                        break;

                    case "es":
                        System.Diagnostics.Process.Start("Manual.es.pdf");
                        break;

                    case "fr":
                        System.Diagnostics.Process.Start("Manual.fr.pdf");
                        break;

                    case "uk":
                        System.Diagnostics.Process.Start("Manual.uk.pdf");
                        break;

                    case "sk":
                        System.Diagnostics.Process.Start("Manual.sk.pdf");
                        break;

                    case "pl":
                        System.Diagnostics.Process.Start("Manual.pl.pdf");
                        break;

                    case "af":
                        System.Diagnostics.Process.Start("Manual.af.pdf");
                        break;

                    default:
                        System.Diagnostics.Process.Start("Manual.pdf");
                        break;
                }

            }
            catch
            {
                notFound = true;
            }

            if (notFound)
            {
                try
                {
                    System.Diagnostics.Process.Start("Manual.pdf");
                }
                catch
                {
                    TimedMessageBox(2000, "No File Found", "Can't Find Manual.pdf");
                }
            }
        }

        private void simulatorOnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                TimedMessageBox(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                return;
            }
            if (simulatorOnToolStripMenuItem.Checked)
            {
                if (sentenceCounter < 299)
                {
                    TimedMessageBox(2000, "Conected", "GPS");
                    simulatorOnToolStripMenuItem.Checked = false;
                    return;
                }

                simulatorOnToolStripMenuItem.Checked = true;
                panelSim.Visible = true;
                timerSim.Enabled = true;
                //DialogResult result3 = MessageBox.Show(gStr.gsAgOpenGPSWillExitPlzRestart, gStr.gsTurningOnSimulator, MessageBoxButtons.OK);
                Settings.Default.setMenu_isSimulatorOn = simulatorOnToolStripMenuItem.Checked;
                Settings.Default.Save();

                isFirstFixPositionSet = false;
                isFirstHeadingSet = false;
                isGPSPositionInitialized = false;
                startCounter = 0;

                //System.Environment.Exit(1);
            }
            else
            {
                panelSim.Visible = false;
                timerSim.Enabled = false;
                simulatorOnToolStripMenuItem.Checked = false;
                //TimedMessageBox(3000, "Simulator Turning Off", "Application will Exit");
                //DialogResult result3 = MessageBox.Show(gStr.gsAgOpenGPSWillExitPlzRestart, gStr.gsTurningOffSimulator, MessageBoxButtons.OK);
                Settings.Default.setMenu_isSimulatorOn = simulatorOnToolStripMenuItem.Checked;
                Settings.Default.Save();

                //worldGrid.CreateWorldGrid(0, 0);
                isFirstFixPositionSet = false;
                isGPSPositionInitialized = false;
                isFirstHeadingSet = false;
                startCounter = 0;

                //System.Environment.Exit(1);
            }

            Settings.Default.setMenu_isSimulatorOn = simulatorOnToolStripMenuItem.Checked;
            Settings.Default.Save();
        }
        private void colorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new FormColor(this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                }
            }
        }

        //Languages
        private void menuLanguageEnglish_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show(this);
                return;
            }
            SetLanguage("en");
            MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
            System.Environment.Exit(1);

        }
        private void menuLanguageDanish_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show(this);
                return;
            }
            SetLanguage("da");
            MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
            System.Environment.Exit(1);

        }

        private void menuLanguageDeutsch_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show(this);
                return;
            }
            SetLanguage("de");
            MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
            System.Environment.Exit(1);

        }
        private void menuLanguageRussian_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show(this);
                return;
            }
            SetLanguage("ru");
            MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
            System.Environment.Exit(1);
        }
        private void menuLanguageDutch_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show(this);
                return;
            }
            SetLanguage("nl");
            MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
            System.Environment.Exit(1);
        }
        private void menuLanguageSpanish_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show(this);
                return;
            }
            SetLanguage("es");
            MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
            System.Environment.Exit(1);
        }
        private void menuLanguageFrench_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show(this);
                return;
            }
            SetLanguage("fr");
            MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
            System.Environment.Exit(1);
        }
        private void menuLanguageItalian_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show(this);
                return;
            }
            SetLanguage("it");
            MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
            System.Environment.Exit(1);
        }
        private void menuLanguageUkranian_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show(this);
                return;
            }
            SetLanguage("uk");
            MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
            System.Environment.Exit(1);
        }
        private void menuLanguageSlovak_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show(this);
                return;
            }
            SetLanguage("sk");
            MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
            System.Environment.Exit(1);

        }
        private void menuLanguagesPolski_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show(this);
                return;
            }
            SetLanguage("pl");
            MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
            System.Environment.Exit(1);
        }
        private void menuLanguageTest_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show(this);
                return;
            }
            SetLanguage("af");
            MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
            System.Environment.Exit(1);
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
            menuLanguageUkranian.Checked = false;
            menuLanguageSlovak.Checked = false;
            menuLanguagePolish.Checked = false;
            menuLanguageDanish.Checked = false;

            menuLanguageTest.Checked = false;

            switch (lang)
            {
                case "en":
                    menuLanguageEnglish.Checked = true;
                    break;

                case "ru":
                    menuLanguageRussian.Checked = true;
                    break;

                case "da":
                    menuLanguageDanish.Checked = true;
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

                case "uk":
                    menuLanguageUkranian.Checked = true;
                    break;

                case "sk":
                    menuLanguageSlovak.Checked = true;
                    break;

                case "pl":
                    menuLanguagePolish.Checked = true;
                    break;

                case "af":
                    menuLanguageTest.Checked = true;
                    break;

                default:
                    menuLanguageEnglish.Checked = true;
                    lang = "en";
                    break;
            }

            Settings.Default.setF_culture = lang;
            Settings.Default.Save();
        }
        #endregion

        #region Bottom Menu

        private void btnEditAB_Click(object sender, EventArgs e)
        {
            //if (isAutoSteerBtnOn) btnAutoSteer.PerformClick();

            Form fc = Application.OpenForms["FormEditAB"];

            if (fc != null)
            {
                fc.Focus();
                return;
            }

            Form fcc = Application.OpenForms["FormEditCurve"];

            if (fcc != null)
            {
                fcc.Focus();
                return;
            }

            if (ABLine.numABLineSelected > 0 && ABLine.isBtnABLineOn)
            {
                Form form = new FormEditAB(this);
                form.Show(this);
            }
            else if (curve.numCurveLineSelected > 0 && curve.isBtnCurveOn)
            {
                Form form = new FormEditCurve(this);
                form.Show(this);
            }
            else
            {
                var form = new FormTimedMessage(1500, gStr.gsNoABLineActive, gStr.gsPleaseEnterABLine);
                return;
            }
        }

        public void CloseTopMosts()
        {
            Form fc = Application.OpenForms["FormSteer"];

            if (fc != null)
            {
                fc.Focus();
                fc.Close();
            }

            fc = Application.OpenForms["FormSteerGraph"];

            if (fc != null)
            {
                fc.Focus();
                fc.Close();
            }

            fc = Application.OpenForms["FormGPSData"];

            if (fc != null)
            {
                fc.Focus();
                fc.Close();
            }

        }

        private void btnOpenConfig_Click(object sender, EventArgs e)
        {
            //check if window already exists

            //Form form = new FormConfig(this);
            //form.Show(this);

            using (var form = new FormConfig(this))
            {
                form.ShowDialog(this);
            }

        }

        private void btnTramDisplayMode_Click(object sender, EventArgs e)
        {
            tram.displayMode++;
            if (tram.displayMode > 3) tram.displayMode = 0;

            switch (tram.displayMode)
            {
                case 0:
                    btnTramDisplayMode.Image = Properties.Resources.TramOff;
                    break;
                case 1:
                    btnTramDisplayMode.Image = Properties.Resources.TramAll;
                    break;
                case 2:
                    btnTramDisplayMode.Image = Properties.Resources.TramLines;
                    break;
                case 3:
                    btnTramDisplayMode.Image = Properties.Resources.TramOuter;
                    break;

                default:
                    break;
            }
        }

        private void btnChangeMappingColor_Click(object sender, EventArgs e)
        {
            using (var form = new FormColorPicker(this, sectionColorDay))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    sectionColorDay = form.useThisColor;
                }
            }

            Settings.Default.setDisplay_colorSectionsDay = sectionColorDay;
            Settings.Default.Save();

            btnChangeMappingColor.BackColor = sectionColorDay;

        }

        //Snaps
        private void btnContourPriority_Click(object sender, EventArgs e)
        {
            if (ABLine.isBtnABLineOn)
            {
                ABLine.MoveABLine(ABLine.distanceFromCurrentLinePivot);
            }
            else if (curve.isBtnCurveOn)
            {
                curve.MoveABCurve(curve.distanceFromCurrentLinePivot);
            }
            else
            {
                var form = new FormTimedMessage(2000, (gStr.gsNoGuidanceLines), (gStr.gsTurnOnContourOrMakeABLine));
                form.Show(this);
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
                    form.Show(this);
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
                    form.Show(this);
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
        private void BtnMakeLinesFromBoundary_Click(object sender, EventArgs e)
        {
            if (ct.isContourBtnOn)
            {
                var form = new FormTimedMessage(2000, (gStr.gsContourOn), ("Turn Off Contour"));
                form.Show(this);
                return;
            }

            if (bnd.bndArr.Count == 0)
            {
                TimedMessageBox(2000, gStr.gsNoBoundary, gStr.gsCreateABoundaryFirst);
                return;
            }

            GetAB();
        }
        public void GetAB()
        {
            if (ct.isContourBtnOn) { if (ct.isContourBtnOn) btnContour.PerformClick(); }

            using (var form = new FormABDraw(this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                }
                ABLine.moveDistance = 0;
                curve.moveDistance = 0;
            }
        }
        private void btnYouSkipEnable_Click(object sender, EventArgs e)
        {
            yt.alternateSkips = !yt.alternateSkips;
            if (yt.alternateSkips)
            {
                btnYouSkipEnable.Image = Resources.YouSkipOn;
                //make sure at least 1
                if (yt.rowSkipsWidth < 2)
                {
                    yt.rowSkipsWidth = 2;
                    cboxpRowWidth.Text = "1";
                }
                yt.Set_Alternate_skips();
                yt.ResetCreatedYouTurn();
                if (!yt.isYouTurnBtnOn) btnAutoYouTurn.PerformClick();
            }
            else
            {
                btnYouSkipEnable.Image = Resources.YouSkipOff;
            }
        }

        private void cboxpRowWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            yt.rowSkipsWidth = cboxpRowWidth.SelectedIndex + 1;
            yt.Set_Alternate_skips();
            yt.ResetCreatedYouTurn();
            Properties.Vehicle.Default.set_youSkipWidth = yt.rowSkipsWidth;
            Properties.Vehicle.Default.Save();
        }
        private void btnHeadlandOnOff_Click(object sender, EventArgs e)
        {
            if (hd.headArr[0].hdLine.Count > 0)
            {
                hd.isOn = !hd.isOn;
                if (hd.isOn)
                {
                    btnHeadlandOnOff.Image = Properties.Resources.HeadlandOn;
                    btnHydLift.Visible = true;
                }
                else
                {
                    btnHydLift.Visible = false;
                    btnHeadlandOnOff.Image = Properties.Resources.HeadlandOff;
                }
            }

            if (!hd.isOn)
            {
                p_239.pgn[p_239.hydLift] = 0;
                vehicle.isHydLiftOn = false;
                btnHydLift.Image = Properties.Resources.HydraulicLiftOff;
                btnHydLift.Visible = false;
            }

        }
        private void btnHydLift_Click(object sender, EventArgs e)
        {
            if (hd.isOn)
            {
                vehicle.isHydLiftOn = !vehicle.isHydLiftOn;
                if (vehicle.isHydLiftOn)
                {
                    btnHydLift.Image = Properties.Resources.HydraulicLiftOn;
                }
                else
                {
                    btnHydLift.Image = Properties.Resources.HydraulicLiftOff;
                    p_239.pgn[p_239.hydLift] = 0;
                }
            }
            else
            {
                p_239.pgn[p_239.hydLift] = 0;
                vehicle.isHydLiftOn = false;
                btnHydLift.Image = Properties.Resources.HydraulicLiftOff;
                btnHydLift.Visible = false;
            }
        }


        #endregion

        #region Tools Menu

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
         private void deleteContourPathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FileCreateContour();
            ct.stripList?.Clear();
            ct.ptList?.Clear();
            ct.ctList?.Clear();
            contourSaveList?.Clear();
        }
        private void toolStripAreYouSure_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                if (autoBtnState == btnStates.Off && manualBtnState == btnStates.Off)
                {

                    DialogResult result3 = MessageBox.Show(gStr.gsDeleteAllContoursAndSections,
                        gStr.gsDeleteForSure,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
                    if (result3 == DialogResult.Yes)
                    {
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

                        FileCreateContour();
                        FileCreateSections();

                    }
                    else
                    {
                        TimedMessageBox(1500, gStr.gsNothingDeleted, gStr.gsActionHasBeenCancelled);
                    }
                }
                else
                {
                   TimedMessageBox(1500, "Sections are on", "Turn Auto or Manual Off First");
                }
            }
        }
        private void headingChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check if window already exists
            Form fcg = Application.OpenForms["FormHeadingGraph"];

            if (fcg != null)
            {
                fcg.Focus();
                return;
            }

            //
            Form formG = new FormHeadingGraph(this);
            formG.Show(this);
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
            formG.Show(this);
        }
        private void webcamToolStrip_Click(object sender, EventArgs e)
        {
            Form form = new FormWebCam();
            form.Show(this);
        }
        private void offsetFixToolStrip_Click(object sender, EventArgs e)
        {
            using (var form = new FormShiftPos(this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) { }
            }
        }

        #endregion

        #region Nav Panel
        private void btn2D_Click(object sender, EventArgs e)
        {
            camera.camFollowing = true;
            camera.camPitch = 0;
            navPanelCounter = 2;
        }

        private void btn3D_Click(object sender, EventArgs e)
        {
            camera.camFollowing = true;
            camera.camPitch = -73;
            navPanelCounter = 2;
        }

        private void btnN2D_Click(object sender, EventArgs e)
        {
            camera.camFollowing = false;
            camera.camPitch = 0;
            navPanelCounter = 2;
        }

        private void btnN3D_Click(object sender, EventArgs e)
        {
            camera.camPitch = -73;
            camera.camFollowing = false;
            navPanelCounter = 2;
        }

        private void btnDayNightMode_Click(object sender, EventArgs e)
        {
            SwapDayNightMode();
            navPanelCounter = 2;
        }

        //The zoom tilt buttons
        private void btnZoomIn_MouseDown(object sender, MouseEventArgs e)
        {
            if (camera.zoomValue <= 20)
            { if ((camera.zoomValue -= camera.zoomValue * 0.1) < 3.0) camera.zoomValue = 3.0; }
            else { if ((camera.zoomValue -= camera.zoomValue * 0.05) < 3.0) camera.zoomValue = 3.0; }
            camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
            SetZoom();
            navPanelCounter = 2;
        }
        private void btnZoomOut_MouseDown(object sender, MouseEventArgs e)
        {
            if (camera.zoomValue <= 20) camera.zoomValue += camera.zoomValue * 0.1;
            else camera.zoomValue += camera.zoomValue * 0.05;
            if (camera.zoomValue > 220) camera.zoomValue = 220;
            camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
            SetZoom();
            navPanelCounter = 2;
        }
        private void btnpTiltUp_MouseDown(object sender, MouseEventArgs e)
        {
            camera.camPitch -= ((camera.camPitch * 0.012) - 1);
            if (camera.camPitch > -58) camera.camPitch = 0;
            navPanelCounter = 2;
        }
        private void btnpTiltDown_MouseDown(object sender, MouseEventArgs e)
        {
            if (camera.camPitch > -59) camera.camPitch = -60;
            camera.camPitch += ((camera.camPitch * 0.012) - 1);
            if (camera.camPitch < -76) camera.camPitch = -76;
            navPanelCounter = 2;
        }

        #endregion

        #region Field Menu
        private void toolStripBtnFieldOpen_Click(object sender, EventArgs e)
        {

            //DateTime dt1 = new DateTime(2021, 03, 15);
            //DateTime dt2 = DateTime.Today;

            //if (dt1.Date < dt2.Date)
            //{
            //    System.Environment.Exit(1);
            //}

            //bring up dialog if no job active, close job if one is
            if (!isJobStarted)
            {
                using (var form = new FormJob(this))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        //ask for a directory name
                        using (var form2 = new FormFieldDir(this))
                        { form2.ShowDialog(); }
                    }

                    //load from  KML
                    else if (result == DialogResult.No)
                    {
                        //ask for a directory name
                        using (var form2 = new FormFieldKML(this))
                        { form2.ShowDialog(); }
                    }
                }

                if (isJobStarted)
                {
                    panelRight.Enabled = true;
                    //boundaryToolStripBtn.Enabled = true;
                    FieldMenuButtonEnableDisable(true);
                }
                else
                {
                    panelRight.Enabled = false;
                    //boundaryToolStripBtn.Enabled = false;
                    FieldMenuButtonEnableDisable(false);
                }
            }
        }
        private void toolStripBtnField_Click(object sender, EventArgs e)
        {
            CloseCurrentJob();
        }
        private void CloseCurrentJob()
        {
            //bring up dialog if no job active, close job if one is

            if (autoBtnState == btnStates.Auto)
            {
                TimedMessageBox(2000, "Safe Shutdown", "Turn off Auto Section Control");
                return;
            }

            if (manualBtnState == btnStates.On)
            {
                TimedMessageBox(2000, "Safe Shutdown", "Turn off Auto Section Control");
                return;
            }

            //close the current job and ask how to or if to save
            if (isJobStarted)
            {
                bool closing = false;
                int choice = SaveOrNot(closing);
                switch (choice)
                {
                    //OK
                    case 0:
                        Settings.Default.setF_CurrentDir = currentFieldDirectory;
                        Settings.Default.Save();
                        FileSaveEverythingBeforeClosingField();
                        panelRight.Enabled = false;
                        //boundaryToolStripBtn.Enabled = false;
                        FieldMenuButtonEnableDisable(false);
                        displayFieldName = gStr.gsNone;
                        break;

                    //Ignore and return
                    case 1:
                        break;

                    //Save As
                    case 2:
                        //close current field but remember last used like normal
                        Settings.Default.setF_CurrentDir = currentFieldDirectory;
                        Settings.Default.Save();
                        FileSaveEverythingBeforeClosingField();
                        panelRight.Enabled = false;
                        //boundaryToolStripBtn.Enabled = false;
                        FieldMenuButtonEnableDisable(false);

                        //ask for a directory name
                        using (var form2 = new FormSaveAs(this))
                        {
                            form2.ShowDialog();
                        }

                        break;
                }
            }
            //update GUI areas
        }
        private void toolStripBtnMakeBndContour_Click(object sender, EventArgs e)
        {
            //build all the contour guidance lines from boundaries, all of them.
            using (var form = new FormMakeBndCon(this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) { }
            }
        }
        private void tramLinesMenuField_Click(object sender, EventArgs e)
        {
            if (ct.isContourBtnOn) btnContour.PerformClick(); 

            if (ABLine.numABLineSelected > 0 && ABLine.isBtnABLineOn)
            {
                Form form99 = new FormTram(this);
                form99.Show(this);
                form99.Left = Width - 275;
                form99.Top = 100;
            }
            else if (curve.numCurveLineSelected > 0 && curve.isBtnCurveOn)
            {
                Form form97 = new FormTramCurve(this);
                form97.Show(this);
                form97.Left = Width - 275;
                form97.Top = 100;
            }
            else
            {
                var form = new FormTimedMessage(1500, gStr.gsNoABLineActive, gStr.gsPleaseEnterABLine);
                form.Show(this);
                panelRight.Enabled = true;
                //ABLine.isEditing = false;
                return;
            }
        }
        private void headlandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bnd.bndArr.Count == 0)
            {
                TimedMessageBox(2000, gStr.gsNoBoundary, gStr.gsCreateABoundaryFirst);
                return;
            }

            GetHeadland();
        }
        public void GetHeadland()
        {
            using (var form = new FormHeadland (this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                }
            }

            if (hd.headArr[0].hdLine.Count > 0)
            {
                hd.isOn = true;
                btnHeadlandOnOff.Image = Properties.Resources.HeadlandOn;
                btnHeadlandOnOff.Visible = true;
                btnHydLift.Visible = true;
                btnHydLift.Image = Properties.Resources.HydraulicLiftOff;
            }
            else
            {
                hd.isOn = false;
                btnHeadlandOnOff.Image = Properties.Resources.HeadlandOff;
                btnHeadlandOnOff.Visible = false;
                btnHydLift.Visible = false;
                btnHydLift.Image = Properties.Resources.HydraulicLiftOff;
                btnHydLift.Visible = false;
            }
            FixPanelsAndMenus(true);
            SetZoom();
        }
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
                        form2.Show(this);
                    }
                }
            }
            else { TimedMessageBox(3000, gStr.gsFieldNotOpen, gStr.gsStartNewField); }
        }

        //Recorded Path
        private void btnPathGoStop_Click(object sender, EventArgs e)
        {
            #region Turn off Guidance
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
                curve.isCurveSet = false;
                //btnContourPriority.Enabled = false;
                curve.isBtnCurveOn = false;
                btnCurve.Image = Properties.Resources.CurveOff;
            }

            #endregion

            //already running?
            if (recPath.isDrivingRecordedPath)
            {
                recPath.StopDrivingRecordedPath();
                btnPathGoStop.Image = Properties.Resources.boundaryPlay;
                btnPathRecordStop.Enabled = true;
                btnPathDelete.Enabled = true;
                return;
            }

            //start the recorded path driving process
            if (!recPath.StartDrivingRecordedPath())
            {
                //Cancel the recPath - something went seriously wrong
                recPath.StopDrivingRecordedPath();
                TimedMessageBox(1500, gStr.gsProblemMakingPath, gStr.gsCouldntGenerateValidPath);
                btnPathGoStop.Image = Properties.Resources.boundaryPlay;
                btnPathRecordStop.Enabled = true;
                btnPathDelete.Enabled = true;
                return;
            }
            else
            {
                btnPathGoStop.Image = Properties.Resources.boundaryStop;
                btnPathRecordStop.Enabled = false;
                btnPathDelete.Enabled = false;
            }
        }

        private void btnPathRecordStop_Click(object sender, EventArgs e)
        {
            if (recPath.isRecordOn)
            {
                FileSaveRecPath();
                recPath.isRecordOn = false;
                btnPathRecordStop.Image = Properties.Resources.BoundaryRecord;
                btnPathGoStop.Enabled = true;
                btnPathDelete.Enabled = true;
            }
            else if (isJobStarted)
            {
                recPath.recList.Clear();
                recPath.isRecordOn = true;
                btnPathRecordStop.Image = Properties.Resources.boundaryStop;
                btnPathGoStop.Enabled = false;
                btnPathDelete.Enabled = false;
            }
        }

        private void btnPathDelete_Click(object sender, EventArgs e)
        {
            recPath.recList.Clear();
            recPath.StopDrivingRecordedPath();
            FileSaveRecPath();
        }

        private void recordedPathStripMenu_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                if (panelDrag.Visible)
                {
                    panelDrag.Visible = false;
                }
                else
                {
                    panelDrag.Visible = true;
                }
            }
            else
            {
             TimedMessageBox(3000, gStr.gsFieldNotOpen, gStr.gsStartNewField); 
            }
        }

        #endregion

        #region OpenGL Window context Menu and functions
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

        #endregion

        #region Sim controls
        private void timerSim_Tick(object sender, EventArgs e)
        {
            if (recPath.isDrivingRecordedPath || isAutoSteerBtnOn && (guidanceLineDistanceOff != 32000))
                sim.DoSimTick(guidanceLineSteerAngle * 0.01);
            else sim.DoSimTick(sim.steerAngleScrollBar);
        }

        private void hsbarSteerAngle_Scroll(object sender, ScrollEventArgs e)
        {
            sim.steerAngleScrollBar = (hsbarSteerAngle.Value - 400) * 0.1;
            btnResetSteerAngle.Text = sim.steerAngleScrollBar.ToString("N1");
        }
        private void hsbarStepDistance_Scroll(object sender, ScrollEventArgs e)
        {
            sim.stepDistance = ((double)(hsbarStepDistance.Value)) / 5.0 / (double)fixUpdateHz;
        }
        private void btnResetSteerAngle_Click(object sender, EventArgs e)
        {
            sim.steerAngleScrollBar = 0;
            hsbarSteerAngle.Value = 400;
            btnResetSteerAngle.Text = sim.steerAngleScrollBar.ToString("N1");
        }
        private void btnResetSim_Click(object sender, EventArgs e)
        {
            sim.latitude = Properties.Settings.Default.setGPS_SimLatitude;
            sim.longitude = Properties.Settings.Default.setGPS_SimLongitude;
        }
        private void btnSimSetSpeedToZero_Click(object sender, EventArgs e)
        {
            sim.stepDistance = 0;
            hsbarStepDistance.Value = 0;
        }
        #endregion

        public void FixTramModeButton()
        {
            if (tram.tramList.Count > 0 || tram.tramBndOuterArr.Count > 0)
                btnTramDisplayMode.Visible = true;
            else btnTramDisplayMode.Visible = false;

            switch (tram.displayMode)
            {
                case 0:
                    btnTramDisplayMode.Image = Properties.Resources.TramOff;
                    break;
                case 1:
                    btnTramDisplayMode.Image = Properties.Resources.TramAll;
                    break;
                case 2:
                    btnTramDisplayMode.Image = Properties.Resources.TramLines;
                    break;
                case 3:
                    btnTramDisplayMode.Image = Properties.Resources.TramOuter;
                    break;

                default:
                    break;
            }

        }

        private void googleEarthFlagsToolStrip_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                //save new copy of flags
                FileSaveFieldKML();

                //Process.Start(@"C:\Program Files (x86)\Google\Google Earth\client\googleearth", workingDirectory + currentFieldDirectory + "\\Flags.KML");
                Process.Start(fieldsDirectory + currentFieldDirectory + "\\Field.KML");
            }
            else
            {
                var form = new FormTimedMessage(1500, gStr.gsFieldNotOpen, gStr.gsStartNewField);
                form.Show(this);
            }
        }
        private void ZoomExtentsStripBtn_Click(object sender, EventArgs e)
        {
            if (camera.camSetDistance < -400) camera.camSetDistance = -75;
            else camera.camSetDistance = -3 * maxFieldDistance;
            if (camera.camSetDistance == 0) camera.camSetDistance = -2000;
            SetZoom();
        }

        private Button btnEditAB;
    }//end class
}//end namespace