//Please, if you use this, share the improvements

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using AgOpenGPS.Forms;
using AgOpenGPS.Forms.Pickers;
using AgOpenGPS.Properties;
using Microsoft.Win32;

namespace AgOpenGPS
{
    public partial class FormGPS
    {
        public bool isTT;

        #region Right Menu
        public bool isABCyled = false;
        private void btnContour_Click(object sender, EventArgs e)
        {
            if (isTT)
            {
                MessageBox.Show(gStr.h_btnContour, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }

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
            if (isTT)
            {
                MessageBox.Show(gStr.h_btnCurve, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }
            
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
            if (isTT)
            {
                MessageBox.Show(gStr.h_btnABLine, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }

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
        private void btnAutoSteer_Click(object sender, EventArgs e)
        {
            if (isTT)
            {
                MessageBox.Show(gStr.h_btnAutoSteer, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }

            //new direction so reset where to put turn diagnostic
            //yt.ResetCreatedYouTurn();

            if (isAutoSteerBtnOn)
            {
                isAutoSteerBtnOn = false;
                btnAutoSteer.Image = Properties.Resources.AutoSteerOff;
                //if (yt.isYouTurnBtnOn) btnAutoYouTurn.PerformClick();
                if (sounds.isSteerSoundOn) sounds.sndAutoSteerOff.Play();
            }
            else
            {
                if (ABLine.isBtnABLineOn | ct.isContourBtnOn | curve.isBtnCurveOn)
                {
                    isAutoSteerBtnOn = true;
                    btnAutoSteer.Image = Properties.Resources.AutoSteerOn;
                    if (sounds.isSteerSoundOn) sounds.sndAutoSteerOn.Play();
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
            if (isTT)
            {
                MessageBox.Show(gStr.h_btnAutoYouTurn, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }
            
            yt.isTurnCreationTooClose = false;

            if (bnd.bndList.Count == 0)
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
                    //if (!isAutoSteerBtnOn) btnAutoSteer.PerformClick();
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
                //yt.rowSkipsWidth = Properties.Settings.Default.set_youSkipWidth;
                //yt.Set_Alternate_skips();

                btnAutoYouTurn.Image = Properties.Resources.YouTurnNo;
                yt.ResetYouTurn();

                //new direction so reset where to put turn diagnostic
                yt.ResetCreatedYouTurn();

                //mc.autoSteerData[mc.sdX] = 0;
                p_239.pgn[p_239.uturn] = 0;
            }
        }
        private void btnCycleLines_Click(object sender, EventArgs e)
        {
            if (isTT)
            {
                if (!ct.isContourBtnOn)
                    MessageBox.Show(gStr.h_btnCycleLines, gStr.gsHelp);
                else
                    MessageBox.Show(gStr.h_btnLockToContour, gStr.gsHelp);

                ResetHelpBtn();
                return;
            }
            
            if (ct.isContourBtnOn)
            {
                ct.SetLockToLine();
                return;
            }

            if (ABLine.numABLines == 0 && curve.numCurveLines == 0) return; 

                //reset to generate new reference
            ABLine.isABValid = false;
            curve.isCurveValid = false;

            if (isAutoSteerBtnOn) btnAutoSteer.PerformClick();

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

        #endregion

        #region Left Panel Menu
        private void steerWizardMenuItem_Click(object sender, EventArgs e)
        {
            Form fcs = Application.OpenForms["FormSteer"];

            if (fcs != null)
            {
                fcs.Focus();
                fcs.Close();
            }

            //check if window already exists
            Form fc = Application.OpenForms["FormSteerWiz"];

            if (fc != null)
            {
                fc.Focus();
                //fc.Close();
                return;
            }

            //
            Form form = new FormSteerWiz(this);
            form.Show(this);

        }
        private void toolStripDropDownButtonDistance_Click(object sender, EventArgs e)
        {
            if (isTT)
            {
                MessageBox.Show(gStr.h_btnDistanceArea, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }
            fd.distanceUser = 0;
            fd.workedAreaTotalUser = 0;
        }        
        private void navPanelToolStrip_Click(object sender, EventArgs e)
        {
            //buttonPanelCounter = 0;
            Form f = Application.OpenForms["FormGPSData"];

            if (f != null)
            {
                f.Focus();
                f.Close();
            }

            Form f1 = Application.OpenForms["FormFieldData"];

            if (f1 != null)
            {
                f1.Focus();
                f1.Close();
            }

            if (panelNavigation.Visible)
            {
                panelNavigation.Visible = false;
            }
            else
            {
                panelNavigation.Visible = true;
                navPanelCounter = 2;
                if (displayBrightness.isWmiMonitor) btnBrightnessDn.Text = (displayBrightness.GetBrightness().ToString()) + "%";
                else btnBrightnessDn.Text = "??";
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
            if (isTT)
            {
                MessageBox.Show(gStr.h_btnFlag, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }

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
            if (isTT)
            {
                MessageBox.Show(gStr.h_btnStartAgIO, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }
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
            if (isTT)
            {
                MessageBox.Show(gStr.h_btnAutoSteerConfig, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }
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
            form.Top = 0;
            form.Left = 0;
            form.Show(this);

        }
        private void stripBtnConfig_Click(object sender, EventArgs e)
        {
            if (isTT)
            {
                MessageBox.Show(gStr.h_btnConfig, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }
            using (FormConfig form = new FormConfig(this))
            {
                form.ShowDialog(this);
            }
        }
        #endregion

        #region Top Panel
        private void lblFieldStatus_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormGPSData"];

            if (f != null)
            {
                f.Focus();
                f.Close();
            }

            Form fff = Application.OpenForms["FormFieldData"];

            if (fff != null)
            {
                fff.Focus();
                fff.Close();
                return;
            }


            Form form = new FormFieldData(this);
            form.Show(this);

            form.Top = this.Top + this.Height / 2 - GPSDataWindowTopOffset;
            form.Left = this.Left + GPSDataWindowLeft;

            Form ff = Application.OpenForms["FormGPS"];
            ff.Focus();


        }

        private void lblSpeed_Click(object sender, EventArgs e)
        {
            if (isTT)
            {
                MessageBox.Show(gStr.h_lblSpeed, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }
            
            Form f = Application.OpenForms["FormGPSData"];

            if (f != null)
            {
                f.Focus();
                f.Close();
                return;
            }

            Form f1 = Application.OpenForms["FormFieldData"];

            if (f1 != null)
            {
                f1.Focus();
                f1.Close();
            }



            //isGPSSentencesOn = true;

            Form form = new FormGPSData(this);
            form.Show(this);

            form.Top = this.Top + this.Height / 2 - GPSDataWindowTopOffset;
            form.Left = this.Left + GPSDataWindowLeft;

            Form ff = Application.OpenForms["FormGPS"];
            ff.Focus();
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

            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                if (fbd.SelectedPath != Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
                {
                    Settings.Default.setF_workingDirectory = fbd.SelectedPath;
                }
                else
                {
                    Settings.Default.setF_workingDirectory = "Default";
                }
                Settings.Default.Save();

                //restart program
                MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
                Close();
            }
        }
        private void enterSimCoordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new FormSimCoords(this))
            {
                form.ShowDialog(this);
            }
        }                
        private void hotKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new Form_Keys(this))
            {
                form.ShowDialog(this);
            }
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new Form_About())
            {
                form.ShowDialog(this);
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
                    ////opening the subkey
                    RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AgOpenGPS");

                    if (regKey == null)
                    {
                        RegistryKey Key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AgOpenGPS");

                        //storing the values
                        Key.SetValue("Language", "en");
                        Key.Close();
                    }
                    else
                    {
                        //adding or editing "Language" subkey to the "SOFTWARE" subkey  
                        RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AgOpenGPS");

                        //storing the values  
                        key.SetValue("Language", "en");
                        key.Close();
                    }

                    Settings.Default.Reset();
                    Settings.Default.Save();

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
             using (var form = new Form_Help(this))
            {
                form.ShowDialog(this);
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
                form.ShowDialog(this);
            }
            SettingsIO.ExportAll(vehiclesDirectory + vehicleFileName + ".XML");
        }
        private void colorsSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tool.isSectionsNotZones)
            {
                using (var form = new FormSectionColor(this))
                {
                    form.ShowDialog(this);
                }
                SettingsIO.ExportAll(vehiclesDirectory + vehicleFileName + ".XML");
            }
            else
            {
                TimedMessageBox(2000, "Cannot use with zones", "Only for Sections");
            }
        }

        //Languages
        private void menuLanguageEnglish_Click(object sender, EventArgs e)
        {
            SetLanguage("en", true);
        }
        private void menuLanguageDanish_Click(object sender, EventArgs e)
        {
            SetLanguage("da", true);
        }
        private void menuLanguageDeutsch_Click(object sender, EventArgs e)
        {
            SetLanguage("de", true);
        }
        private void menuLanguageRussian_Click(object sender, EventArgs e)
        {
            SetLanguage("ru", true);
        }
        private void menuLanguageDutch_Click(object sender, EventArgs e)
        {
            SetLanguage("nl", true);
        }
        private void menuLanguageSpanish_Click(object sender, EventArgs e)
        {
            SetLanguage("es", true);
        }
        private void menuLanguageFrench_Click(object sender, EventArgs e)
        {
            SetLanguage("fr", true);
        }
        private void menuLanguageItalian_Click(object sender, EventArgs e)
        {
            SetLanguage("it", true);
        }
        private void menuLanguageHungarian_Click(object sender, EventArgs e)
        {
            SetLanguage("hu", true);
        }
        private void menuLanguageUkranian_Click(object sender, EventArgs e)
        {
            SetLanguage("uk", true);
        }
        private void menuLanguageSlovak_Click(object sender, EventArgs e)
        {
            SetLanguage("sk", true);
        }
        private void menuLanguagesPolski_Click(object sender, EventArgs e)
        {
            SetLanguage("pl", true);
        }
        private void menuLanguageTest_Click(object sender, EventArgs e)
        {
            SetLanguage("af", true);
        }
        private void menuLanguageTurkish_Click(object sender, EventArgs e)
        {
            SetLanguage("tr", true);
        }          
        private void finnishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage("fi", true);
        }
        private void latvianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage("lv", true);
        }
        private void lithuanianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage("lt", true);
        }


        private void SetLanguage(string lang, bool Restart)
        {
            if (Restart && isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show(this);
                return;
            }

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
            menuLanguageTurkish.Checked = false;
            menuLanguageHungarian.Checked = false;
            menuLanguageLithuanian.Checked = false;
            menuLanguageFinnish.Checked = false;
            menuLanguageLatvian.Checked = false;

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

                case "tr":
                    menuLanguageTurkish.Checked = true;
                    break;

                case "hu":
                    menuLanguageHungarian.Checked = true;
                    break;

                case "lt":
                    menuLanguageLithuanian.Checked = true;
                    break;

                case "lv":
                    menuLanguageLatvian.Checked = true;
                    break;

                case "fi":
                    menuLanguageFinnish.Checked = true;
                    break;

                default:
                    menuLanguageEnglish.Checked = true;
                    lang = "en";
                    break;
            }

            Settings.Default.setF_culture = lang;
            Settings.Default.Save();

            //adding or editing "Language" subkey to the "SOFTWARE" subkey  
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AgOpenGPS");

            //storing the values  
            key.SetValue("Language", lang);
            key.Close();

            if (Restart)
            {
                MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
                System.Environment.Exit(1);
            }
        }

        #endregion

        #region Bottom Menu

        private void btnResetToolHeading_Click(object sender, EventArgs e)
        {
            tankPos.heading = fixHeading;
            tankPos.easting = hitchPos.easting + (Math.Sin(tankPos.heading) * (tool.tankTrailingHitchLength));
            tankPos.northing = hitchPos.northing + (Math.Cos(tankPos.heading) * (tool.tankTrailingHitchLength));
            
            toolPos.heading = tankPos.heading;
            toolPos.easting = tankPos.easting + (Math.Sin(toolPos.heading) * (tool.trailingHitchLength));
            toolPos.northing = tankPos.northing + (Math.Cos(toolPos.heading) * (tool.trailingHitchLength));
        }

        private void btnEditAB_Click(object sender, EventArgs e)
        {
            if (isTT)
            {
                MessageBox.Show(gStr.h_btnEditAB, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }

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

            Process[] processName = Process.GetProcessesByName("Nav");
            if (processName.Length == 0)
            {
                //Start application here
                DirectoryInfo di = new DirectoryInfo(Application.StartupPath);
                string strPath = di.ToString();
                strPath += "\\Nav.exe";
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
                    TimedMessageBox(2000, "No File Found", "Can't Find Tetris");
                }
            }
            else
            {
                //Set foreground window
                ShowWindow(processName[0].MainWindowHandle, 9);
                SetForegroundWindow(processName[0].MainWindowHandle);
            }
        }

        private void btnTramDisplayMode_Click(object sender, EventArgs e)
        {
            if (isTT)
            {
                MessageBox.Show(gStr.h_btnTramDisplayMode, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }

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
            if (isTT)
            {
                MessageBox.Show(gStr.h_btnChangeMappingColor, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }

            using (var form = new FormColorPicker(this, sectionColorDay))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    sectionColorDay = form.useThisColor;
                }
            }

            Settings.Default.setDisplay_colorSectionsDay = sectionColorDay;
            Settings.Default.Save();

            btnChangeMappingColor.BackColor = sectionColorDay;

        }

        //Snaps
        private void btnSnapToPivot_Click(object sender, EventArgs e)
        {
            if (isTT)
            {
                MessageBox.Show(gStr.h_btnSnapToPivot, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }

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
        private void btnABDraw_Click(object sender, EventArgs e)
        {
            if (isTT)
            {
                MessageBox.Show(gStr.h_btnABDraw, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }

            if (ct.isContourBtnOn)
            {
                var form = new FormTimedMessage(2000, (gStr.gsContourOn), ("Turn Off Contour"));
                form.Show(this);
                return;
            }

            if (bnd.bndList.Count == 0)
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
                form.ShowDialog(this);
                ABLine.moveDistance = 0;
                curve.moveDistance = 0;
            }
        }
        private void btnYouSkipEnable_Click(object sender, EventArgs e)
        {
            if (isTT)
            {
                MessageBox.Show(gStr.h_btnYouSkipEnable, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }
            
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
            Properties.Settings.Default.set_youSkipWidth = yt.rowSkipsWidth;
            Properties.Settings.Default.Save();
        }

        private void btnHeadlandOnOff_Click(object sender, EventArgs e)
        {
            if (isTT)
            {
                MessageBox.Show(gStr.h_btnHeadlandOnOff, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }

            if (bnd.bndList.Count > 0 && bnd.bndList[0].hdLine.Count > 0)
            {
                bnd.isHeadlandOn = !bnd.isHeadlandOn;
                if (bnd.isHeadlandOn)
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
            else bnd.isHeadlandOn = false;

            if (!bnd.isHeadlandOn)
            {
                p_239.pgn[p_239.hydLift] = 0;
                vehicle.isHydLiftOn = false;
                btnHydLift.Image = Properties.Resources.HydraulicLiftOff;
                btnHydLift.Visible = false;
            }

        }

        private void btnHydLift_Click(object sender, EventArgs e)
        {
            if (isTT)
            {
                MessageBox.Show(gStr.h_btnHydLift, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }

            if (bnd.isHeadlandOn)
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
                    form.ShowDialog(this);
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

                        if (tool.isSectionsNotZones)
                        {
                            //Update the button colors and text
                            AllSectionsAndButtonsToState(btnStates.Off);

                            //enable disable manual buttons
                            LineUpIndividualSectionBtns();
                        }
                        else
                        {
                            AllZonesAndButtonsToState(btnStates.Off);
                            LineUpAllZoneButtons();
                        }

                        //turn manual button off
                        manualBtnState = btnStates.Off;
                        btnSectionMasterManual.Image = Properties.Resources.ManualOff;

                        //turn auto button off
                        autoBtnState = btnStates.Off;
                        btnSectionMasterAuto.Image = Properties.Resources.SectionMasterOff;


                        //clear out the contour Lists
                        ct.StopContourLine();
                        ct.ResetContour();
                        fd.workedAreaTotal = 0;

                        //clear the section lists
                        for (int j = 0; j < triStrip.Count; j++)
                        {
                            //clean out the lists
                            triStrip[j].patchList?.Clear();
                            triStrip[j].triangleList?.Clear();
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
            Form fh = Application.OpenForms["FormHeadingGraph"];

            if (fh != null)
            {
                fh.Focus();
                return;
            }

            //
            Form formH = new FormHeadingGraph(this);
            formH.Show(this);
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
        
        private void xTEChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check if window already exists
            Form fx = Application.OpenForms["FormXTEGraph"];

            if (fx != null)
            {
                fx.Focus();
                return;
            }

            //
            Form formX = new FormXTEGraph(this);
            formX.Show(this);
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
                form.ShowDialog(this);
            }
        }
        private void correctionToolStrip_Click(object sender, EventArgs e)
        {
            //check if window already exists
            Form fcc = Application.OpenForms["FormCorrection"];

            if (fcc != null)
            {
                fcc.Focus();
                return;
            }

            //
            Form formC = new FormCorrection(this);
            formC.Show(this);
        }

        #endregion

        #region Nav Panel
        private void btn2D_Click(object sender, EventArgs e)
        {
            if (isTT)
            {
                MessageBox.Show(gStr.h_btn2D, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }

            camera.camFollowing = true;
            camera.camPitch = 0;
            navPanelCounter = 2;
        }

        private void btn3D_Click(object sender, EventArgs e)
        {
            if (isTT)
            {
                MessageBox.Show(gStr.h_btn3D, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }
            camera.camFollowing = true;
            camera.camPitch = -73;
            navPanelCounter = 2;
        }

        private void btnN2D_Click(object sender, EventArgs e)
        {
            if (isTT)
            {
                MessageBox.Show(gStr.h_btnN2D, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }
            camera.camFollowing = false;
            camera.camPitch = 0;
            navPanelCounter = 2;
        }

        private void btnN3D_Click(object sender, EventArgs e)
        {
            if (isTT)
            {
                MessageBox.Show(gStr.h_btnN3D, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }
            camera.camPitch = -73;
            camera.camFollowing = false;
            navPanelCounter = 2;
        }

        private void btnBrightnessUp_Click(object sender, EventArgs e)
        {
            if (displayBrightness.isWmiMonitor)
            {
                displayBrightness.BrightnessIncrease();
                btnBrightnessDn.Text = displayBrightness.GetBrightness().ToString() + "%";
                Settings.Default.setDisplay_brightness = displayBrightness.GetBrightness();
                Settings.Default.Save();
            }
            navPanelCounter = 2;
        }

        private void btnBrightnessDn_Click(object sender, EventArgs e)
        {
            if (displayBrightness.isWmiMonitor)
            {
                displayBrightness.BrightnessDecrease();
                btnBrightnessDn.Text = displayBrightness.GetBrightness().ToString() + "%";
                Settings.Default.setDisplay_brightness = displayBrightness.GetBrightness();
                Settings.Default.Save();
            }
            navPanelCounter = 2;
        }

        private void btnDayNightMode_Click(object sender, EventArgs e)
        {
            if (isTT)
            {
                MessageBox.Show(gStr.h_btnDayNightMode, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }
            SwapDayNightMode();
            navPanelCounter = 2;
        }

        //The zoom tilt buttons
        private void btnZoomIn_MouseDown(object sender, MouseEventArgs e)
        {
            //if (isTT)
            //{
            //    MessageBox.Show(gStr.btnZoomIn, gStr.gsHelp);
            //    isTT = false;
            //    return;
            //}
            if (camera.zoomValue <= 20)
            { if ((camera.zoomValue -= camera.zoomValue * 0.1) < 3.0) camera.zoomValue = 3.0; }
            else { if ((camera.zoomValue -= camera.zoomValue * 0.05) < 3.0) camera.zoomValue = 3.0; }
            camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
            SetZoom();
            navPanelCounter = 2;
        }
        private void btnZoomOut_MouseDown(object sender, MouseEventArgs e)
        {
            //if (isTT)
            //{
            //    MessageBox.Show(gStr.btnZoomOut, gStr.gsHelp);
            //    isTT = false;
            //    return;
            //}
            if (camera.zoomValue <= 20) camera.zoomValue += camera.zoomValue * 0.1;
            else camera.zoomValue += camera.zoomValue * 0.05;
            if (camera.zoomValue > 220) camera.zoomValue = 220;
            camera.camSetDistance = camera.zoomValue * camera.zoomValue * -1;
            SetZoom();
            navPanelCounter = 2;
        }
        private void btnpTiltUp_MouseDown(object sender, MouseEventArgs e)
        {
            //if (isTT)
            //{
            //    MessageBox.Show(gStr.btnTiltUp, gStr.gsHelp);
            //    isTT = false;
            //    return;
            //}
            camera.camPitch -= ((camera.camPitch * 0.012) - 1);
            if (camera.camPitch > -58) camera.camPitch = 0;
            navPanelCounter = 2;
        }
        private void btnpTiltDown_MouseDown(object sender, MouseEventArgs e)
        {
            //if (isTT)
            //{
            //    MessageBox.Show(gStr.btnTiltDown, gStr.gsHelp);
            //    isTT = false;
            //    return;
            //}
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
                if (!isFirstFixPositionSet || sentenceCounter > 299)
                {
                    TimedMessageBox(2500, "No GPS", "You are lost with no GPS, Fix that First");
                    return;
                }

                using (var form = new FormJob(this))
                {
                    var result = form.ShowDialog(this);
                    if (result == DialogResult.Yes)
                    {

                        //new field - ask for a directory name
                        using (var form2 = new FormFieldDir(this))
                        { form2.ShowDialog(this); }
                    }

                    //load from  KML
                    else if (result == DialogResult.No)
                    {
                        //ask for a directory name
                        using (var form2 = new FormFieldKML(this))
                        { form2.ShowDialog(this); }
                    }

                    //load from Existing
                    else if (result == DialogResult.Retry)
                    {
                        //ask for a field to copy
                        using (var form2 = new FormFieldExisting(this))
                        { form2.ShowDialog(this); }
                    }

                    if (isJobStarted)
                    {
                        double distance = Math.Pow((pn.latStart - pn.latitude), 2) + Math.Pow((pn.lonStart - pn.longitude), 2);
                        distance = Math.Sqrt(distance);
                        distance *= 100;
                        if (distance > 10) TimedMessageBox(2500, "High Field Start Distance Warning", "Field Start is "
                            + distance.ToString("N1") + " km From current position");
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

                }
            }
            //update GUI areas
        }
        private void toolStripBtnMakeBndContour_Click(object sender, EventArgs e)
        {
            //build all the contour guidance lines from boundaries, all of them.
            using (var form = new FormMakeBndCon(this))
            {
                form.ShowDialog(this);
            }
        }
        private void tramLinesMenuField_Click(object sender, EventArgs e)
        {
            if (ct.isContourBtnOn) btnContour.PerformClick(); 

            if (ABLine.numABLineSelected > 0 && ABLine.isBtnABLineOn)
            {
                Form form99 = new FormTram(this, false);
                form99.Show(this);
                form99.Left = Width - 275;
                form99.Top = 100;
            }
            else if (curve.numCurveLineSelected > 0 && curve.isBtnCurveOn)
            {
                Form form97 = new FormTram(this, true);
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
            if (bnd.bndList.Count == 0)
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
                form.ShowDialog(this);
            }

            if (bnd.bndList.Count > 0 && bnd.bndList[0].hdLine.Count > 0)
            {
                bnd.isHeadlandOn = true;
                btnHeadlandOnOff.Image = Properties.Resources.HeadlandOn;
                btnHeadlandOnOff.Visible = true;
                btnHydLift.Visible = true;
                btnHydLift.Image = Properties.Resources.HydraulicLiftOff;
            }
            else
            {
                bnd.isHeadlandOn = false;
                btnHeadlandOnOff.Image = Properties.Resources.HeadlandOff;
                btnHeadlandOnOff.Visible = false;
                btnHydLift.Visible = false;
                btnHydLift.Image = Properties.Resources.HydraulicLiftOff;
                btnHydLift.Visible = false;
            }
            FixPanelsAndMenus();
            SetZoom();
        }
        private void boundariesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                DialogResult diaRes = DialogResult.None;

                using (var form = new FormBoundary(this))
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        Form form2 = new FormBoundaryPlayer(this);
                        form2.Show(this);
                    }
                    diaRes = form.DialogResult;
                }
                if (diaRes == DialogResult.Yes)
                {
                    var form3 = new FormMap(this);
                    form3.Show(this);
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
                btnPickPath.Enabled = true;
                btnResumePath.Enabled = true;   
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
                btnPickPath.Enabled = true;
                btnResumePath.Enabled = true;
                return;
            }
            else
            {
                btnPathGoStop.Image = Properties.Resources.boundaryStop;
                btnPathRecordStop.Enabled = false;
                btnPickPath.Enabled = false;
                btnResumePath.Enabled = false;
            }
        }

        private void btnPathRecordStop_Click(object sender, EventArgs e)
        {
            if (recPath.isRecordOn)
            {
                recPath.isRecordOn = false;
                btnPathRecordStop.Image = Properties.Resources.BoundaryRecord;
                btnPathGoStop.Enabled = true;
                btnPickPath.Enabled = true;
                btnResumePath.Enabled = true;

                using (var form = new FormRecordName(this))
                {
                    form.ShowDialog(this);
                    if(form.DialogResult == DialogResult.OK) 
                    {
                        String filename = form.filename + ".rec";
                        FileSaveRecPath();
                        FileSaveRecPath(filename);
                    }
                    else
                    {
                        recPath.recList.Clear();
                    }
                }                
            }
            else if (isJobStarted)
            {
                recPath.recList.Clear();
                recPath.isRecordOn = true;
                btnPathRecordStop.Image = Properties.Resources.boundaryStop;
                btnPathGoStop.Enabled = false;
                btnPickPath.Enabled = false;
                btnResumePath.Enabled = false;
            }
        }

        private void btnResumePath_Click(object sender, EventArgs e)
        {
            if (recPath.resumeState == 0)
            {
                recPath.resumeState++;
                btnResumePath.Image = Properties.Resources.pathResumeLast;
                TimedMessageBox(1500, "Resume Style", "Last Stopped Position");
            }

            else if (recPath.resumeState == 1)
            {
                recPath.resumeState++;
                btnResumePath.Image = Properties.Resources.pathResumeClose; 
                TimedMessageBox(1500, "Resume Style", "Closest Point");
            }
            else
            {
                recPath.resumeState = 0;
                btnResumePath.Image = Properties.Resources.pathResumeStart;
                TimedMessageBox(1500, "Resume Style", "Start At Beginning");
            }
        }


        private void btnPickPath_Click(object sender, EventArgs e)
        {
            recPath.resumeState = 0;
            btnResumePath.Image = Properties.Resources.pathResumeStart;
            recPath.currentPositonIndex = 0;

            using (FormRecordPicker form = new FormRecordPicker(this))
            {
                //returns full field.txt file dir name
                if (form.ShowDialog(this) == DialogResult.Yes)
                {
                }
            }
        }

        private void recordedPathStripMenu_Click(object sender, EventArgs e)
        {
            recPath.resumeState = 0;
            btnResumePath.Image = Properties.Resources.pathResumeStart;
            recPath.currentPositonIndex = 0;

            if (isJobStarted)
            {
                if (panelDrag.Visible)
                {
                    panelDrag.Visible = false;
                    recPath.recList.Clear();
                    recPath.StopDrivingRecordedPath();
                }
                else
                {
                    FileLoadRecPath();
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
            sim.stepDistance = ((double)(hsbarStepDistance.Value)) / 5.0 / gpsHz;
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

        private void btnSimReverse_Click(object sender, EventArgs e)
        {
            sim.stepDistance = 0;
            sim.isAccelBack = true;
        }

        private void btnSimForward_Click(object sender, EventArgs e)
        {
            sim.stepDistance = 0;
            sim.isAccelForward = true;
        }

        #endregion


        private void lbludpWatchCounts_Click(object sender, EventArgs e)
        {
            if (isTT)
            {
                MessageBox.Show(gStr.h_lbludpWatchCounts, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }
        }

        private void lblInty_Click(object sender, EventArgs e)
        {
            if (isTT)
            {
                MessageBox.Show(gStr.h_lblIntegral, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }
        }

        private void cboxpRowWidth_Click(object sender, EventArgs e)
        {
            if (isTT)
            {
                MessageBox.Show(gStr.h_btnRowWidthSkips, gStr.gsHelp);
                ResetHelpBtn();
                return;
            }

        }


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

        private void btnHelp_Click(object sender, EventArgs e)
        {
            isTT = !isTT;
            if (isTT)
                btnHelp.Image = Resources.HelpCancel;
            else
            {
                btnHelp.Image = Resources.Help;
                isTT = false;
            }
        }

        private void ResetHelpBtn()
        {
            isTT = false;
            btnHelp.Image = Resources.Help;
        }

        private ToolStripMenuItem steerChartToolStripMenuItem;
        private ToolStripMenuItem headingChartToolStripMenuItem;
        private ToolStripMenuItem xTEChartToolStripMenuItem;
    }//end class
}//end namespace