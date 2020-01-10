//Please, if you use this, share the improvements

using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using AgOpenGPS.Properties;
using Microsoft.Win32;

namespace AgOpenGPS
{
    public partial class FormGPS
    {
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
            CFlag flagPt = new CFlag(pn.latitude, pn.longitude, pn.fix.easting, pn.fix.northing, fixHeading, flagColor, nextflag, DateTime.Today.ToString());
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
        private void btnHeadlandOnOff_Click(object sender, EventArgs e)
        {
            if (hd.headArr[0].hdLine.Count > 0)
            {
                hd.isOn = !hd.isOn;
                if (hd.isOn) btnHeadlandOnOff.Image = Properties.Resources.HeadlandOn;
                else btnHeadlandOnOff.Image = Properties.Resources.HeadlandOff;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string fileAndDirectory;
            {
                //create the dialog instance
                OpenFileDialog ofd = new OpenFileDialog
                {
                    //set the filter to text KML only
                    Filter = "KML files (*.KML)|*.KML",

                    //the initial directory, fields, for the open dialog
                    InitialDirectory = fieldsDirectory + currentFieldDirectory
                };

                //was a file selected
                if (ofd.ShowDialog() == DialogResult.Cancel) return;
                else fileAndDirectory = ofd.FileName;
            }

            //start to read the file
            string line = null;
            string coordinates = null;
            int startIndex;
            //int i = 0;

            using (System.IO.StreamReader reader = new System.IO.StreamReader(fileAndDirectory))
            {
                try
                {
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();

                        startIndex = line.IndexOf("<coordinates>");

                        if (startIndex != -1)
                        {
                            while (true)
                            {
                                int endIndex = line.IndexOf("</coordinates>");

                                if (endIndex == -1)
                                {
                                    //just add the line
                                    if (startIndex == -1) coordinates = coordinates + line.Substring(0);
                                    else coordinates = coordinates + line.Substring(startIndex + 13);
                                }
                                else
                                {
                                    if (startIndex == -1) coordinates = coordinates + line.Substring(0, endIndex);
                                    else coordinates = coordinates + line.Substring(startIndex + 13, endIndex - (startIndex + 13));
                                    break;
                                }
                                line = reader.ReadLine();
                                line = line.Trim();
                                startIndex = -1;
                            }

                            line = coordinates;
                            char[] delimiterChars = { ' ', '\t', '\r', '\n' };
                            
                            string[] numberSets = line.Split(delimiterChars);


                            //at least 3 points
                            if (numberSets.Length > 1)
                            {
                                double latK, lonK;
                                string[] item = numberSets[1].Split(',');

                                double.TryParse(item[0], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out lonK);
                                double.TryParse(item[1], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out latK);
                                double[] xy = pn.DecDeg2UTM(latK, lonK);

                                //match new fix to current position
                                double easting = xy[0] - pn.utmEast;
                                double northing = xy[1] - pn.utmNorth;

                                double east = easting;
                                double nort = northing;

                                //fix the azimuth error
                                easting = (Math.Cos(-pn.convergenceAngle) * east) - (Math.Sin(-pn.convergenceAngle) * nort);
                                northing = (Math.Sin(-pn.convergenceAngle) * east) + (Math.Cos(-pn.convergenceAngle) * nort);

                                //add the point to boundary
                                vec3 bndPt = new vec3(easting, northing, 0);
                                //mf.bnd.bndArr[i].bndLine.Add(bndPt);
                                int nextflag = flagPts.Count + 1;
                                CFlag flagPt = new CFlag(latK, lonK, easting, northing, 0, flagColor, nextflag);
                                flagPts.Add(flagPt);
                                //FileSaveFlags();

                            }
                        }
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
        }
        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            isFullScreen = !isFullScreen;
            if (isFullScreen)
            {
                this.WindowState = FormWindowState.Normal;
                //this.TopMost = true;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                btnFullScreen.BackgroundImage = Properties.Resources.WindowNormal;

            }
            else
            {
                this.TopMost = false;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                btnFullScreen.BackgroundImage = Properties.Resources.WindowFullScreen;

            }
        }
        private void btnShutdown_Click(object sender, EventArgs e)
        {
            DialogResult result3 = MessageBox.Show(gStr.gsOff,
                    gStr.gsWaiting,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
            if (result3 == DialogResult.Yes) Close();

        }
        private void btnReverseDirection_Click(object sender, EventArgs e)
        {
            sim.headingTrue += Math.PI;
            if (sim.headingTrue > (2.0 * Math.PI)) sim.headingTrue -= (2.0 * Math.PI);
            if (sim.headingTrue < 0) sim.headingTrue += (2.0 * Math.PI);

        }
        private void btnSimSetSpeedToZero_Click(object sender, EventArgs e)
        {
            sim.stepDistance = 0;
            hsbarStepDistance.Value = 0;
        }
        private void btnDayNightMode_Click(object sender, EventArgs e)
        {
            SwapDayNightMode();
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
        private void headlandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bnd.bndArr.Count == 0)
            {
                TimedMessageBox(2000, gStr.gsNoBoundary, gStr.gsCreateABoundaryFirst);
                return;
            }

            GetHeadland();
        }
        private void toolToolStripMenu_Click(object sender, EventArgs e)
        {
            using (var form = new FormToolSettings(this, 0))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                }
            }
        }
        private void arduinoSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new FormArduinoSettings(this, 0))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                }
            }

        }                     
        private void batmanToolStrip_Click(object sender, EventArgs e)
        {
            //if (secondRowCounter < 8) return;
            Properties.Settings.Default.setDisplay_isBatmanOn = !Properties.Settings.Default.setDisplay_isBatmanOn;
            Properties.Settings.Default.Save();
            SwapBatmanPanels();

        }
        private void simplifyToolStrip_Click(object sender, EventArgs e)
        {
            isSimple = !isSimple;

            Settings.Default.setDisplay_isSimple = isSimple;
            Settings.Default.Save();
            SwapBatmanPanels();
            FixPanelsAndMenus();
        }
        private void topMenuSaveEnvironment_Click(object sender, EventArgs e)
        {
            FileSaveEnvironment();
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
        private void topMenuLoadVehicle_Click(object sender, EventArgs e)
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
                using (var form = new FormIMU(this))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK) { }
                }

                TimedMessageBox(3000, gStr.gsDidyoumakechangestothevehicle, gStr.gsBesuretosavevehicleifyoudid);
            }
        }
        private void topMenuSaveVehicle_Click(object sender, EventArgs e)
        {
            FileSaveVehicle();
        }
        private void topMenuLoadTool_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show();
                return;
            }
            if (FileOpenTool())
            {
                using (var form = new FormToolSettings(this, 0))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK) { }
                }

                TimedMessageBox(3000, gStr.gsDidYouMakeChanges, gStr.gsBeSureToSaveIfYouDid);
            }
        }
        private void topMenuSaveTool_Click(object sender, EventArgs e)
        {
            FileSaveTool();
        }
        private void topMenuLoadEnvironment_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show();
                return;
            }

            if (FileOpenEnvironment())
            {
                MessageBox.Show(gStr.gsProgramWillExitPleaseRestart, gStr.gsProgramWillExitPleaseRestart);
                if (isJobStarted) JobClose();
                Application.Exit();
            }
            else
            {
                MessageBox.Show(gStr.gsError,
                    gStr.gsFileError,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

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
            //lblSpeedUnits.Text = gStr.gsKMH;
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
            //lblSpeedUnits.Text = gStr.gsMPH;
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

        private void autoDayNightModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isAutoDayNight = !isAutoDayNight;
            autoDayNightModeToolStripMenuItem.Checked = isAutoDayNight;
            Settings.Default.setDisplay_isAutoDayNight = isSpeedoOn;
            Settings.Default.Save();
        }



        //sections Day
        private void nightModeToolSection_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog
            {
                FullOpen = true,
                AnyColor = true,
                SolidColorOnly = false,
                Color = Settings.Default.setDisplay_colorSectionsNight
            };

            if (colorDlg.ShowDialog() != DialogResult.OK) return;

            sectionColorNight = colorDlg.Color;

            Settings.Default.setDisplay_colorSectionsNight = sectionColorNight;
            Settings.Default.Save();

        }
        private void dayModeToolSection_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog
            {
                FullOpen = true,
                AnyColor = true,
                SolidColorOnly = false,
                Color = Settings.Default.setDisplay_colorSectionsDay
            };

            if (colorDlg.ShowDialog() != DialogResult.OK) return;

            sectionColorDay = colorDlg.Color;

            Settings.Default.setDisplay_colorSectionsDay = sectionColorDay;
            Settings.Default.Save();

        }

        //field day color
        private void dayModeToolField_Click(object sender, EventArgs e)
        {
            //color picker for fields

            ColorDialog colorDlg = new ColorDialog
            {
                FullOpen = true,
                AnyColor = true,
                SolidColorOnly = false,
                Color = Settings.Default.setDisplay_colorFieldDay
            };

            if (colorDlg.ShowDialog() != DialogResult.OK) return;

            fieldColorDay = colorDlg.Color;

            Settings.Default.setDisplay_colorFieldDay = fieldColorDay;
            Settings.Default.Save();
        }
        private void nightModeToolField_Click(object sender, EventArgs e)
        {
                //color picker for fields

                ColorDialog colorDlg = new ColorDialog
                {
                    FullOpen = true,
                    AnyColor = true,
                    SolidColorOnly = false,
                    Color = Settings.Default.setDisplay_colorFieldNight
                };

                if (colorDlg.ShowDialog() != DialogResult.OK) return;

                fieldColorNight = colorDlg.Color;

                Settings.Default.setDisplay_colorFieldNight = fieldColorNight;
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
        private void menuLanguageUkranian_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show();
                return;
            }
            SetLanguage("uk");
            MessageBox.Show(gStr.gsProgramWillExitPleaseRestart);
            Close();
        }
        private void menuLanguageSlovak_Click(object sender, EventArgs e)
        {
            if (isJobStarted)
            {
                var form = new FormTimedMessage(2000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show();
                return;
            }
            SetLanguage("sk");
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
            menuLanguageUkranian.Checked = false;
            menuLanguageSlovak.Checked = false;

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

                case "uk":
                    menuLanguageUkranian.Checked = true;
                    break;

                case "sk":
                    menuLanguageSlovak.Checked = true;
                    break;
            }

            //adding or editing "Language" subkey to the "SOFTWARE" subkey  
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AgOpenGPS");

            //storing the values  
            key.SetValue("Language", lang);
            key.Close();
        }

    }//end class
}//end namespace