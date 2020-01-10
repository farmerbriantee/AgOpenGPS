//Please, if you use this, share the improvements

using System;
using System.Collections.Generic;
using System.Text;

namespace AgOpenGPS
{
    public partial class FormGPS
    {
        //very first fix to setup grid etc
        public bool isFirstFixPositionSet = false, isGPSPositionInitialized = false;

        //string to record fixes for elevation maps
        public StringBuilder sbFix = new StringBuilder();

        // autosteer variables for sending serial
        public Int16 guidanceLineDistanceOff, guidanceLineSteerAngle, distanceDisplay;

        //how many fix updates per sec
        public int fixUpdateHz = 5;
        public double fixUpdateTime = 0.2;

        //public StringBuilder sbNMEAFromGPS = new StringBuilder();

        //for heading or Atan2 as camera
        public string headingFromSource;

        public vec3 pivotAxlePos = new vec3(0, 0, 0);
        public vec3 steerAxlePos = new vec3(0, 0, 0);
        public vec3 toolPos = new vec3(0, 0, 0);
        public vec3 tankPos = new vec3(0, 0, 0);
        public vec2 hitchPos = new vec2(0, 0);

        //history
        public vec2 prevFix = new vec2(0, 0);

        //headings
        public double fixHeading = 0.0, camHeading = 0.0, gpsHeading = 0.0, prevGPSHeading = 0.0;

        //storage for the cos and sin of heading
        public double cosSectionHeading = 1.0, sinSectionHeading = 0.0;

        //a distance between previous and current fix
        private double distance = 0.0;
        public double treeSpacingCounter = 0.0;
        public int treeTrigger = 0;

        //how far travelled since last section was added, section points
        double sectionTriggerDistance = 0, sectionTriggerStepDistance = 0;
        public vec2 prevSectionPos = new vec2(0, 0);

        public vec2 prevBoundaryPos = new vec2(0, 0);

        //are we still getting valid data from GPS, resets to 0 in NMEA OGI block, watchdog 
        public int recvCounter = 20;

        //Everything is so wonky at the start
        int startCounter = 0;

        //individual points for the flags in a list
        public List<CFlag> flagPts = new List<CFlag>();

        //tally counters for display
        //public double totalSquareMetersWorked = 0, totalUserSquareMeters = 0, userSquareMetersAlarm = 0;

        public double[] avgSpeed = new double[10];//for average speed
        public double[] avgXTE = new double[20]; //for average cross track error
        public int ringCounter = 0, avgXTECntr, crossTrackError;

        //youturn
        public double distancePivotToTurnLine = -2222;
        public double distanceToolToTurnLine = -2222;

        //the value to fill in you turn progress bar
        public int youTurnProgressBar = 0;

        //IMU 
        double rollCorrectionDistance = 0;
        double gyroCorrection, gyroCorrected;

        //step position - slow speed spinner killer
        private int totalFixSteps = 10, currentStepFix = 0;
        private vec3 vHold;
        public vec3[] stepFixPts = new vec3[60];
        public double distanceCurrentStepFix = 0, fixStepDist, minFixStepDist = 0;
        bool isFixHolding = false, isFixHoldLoaded = false;

        private double nowHz = 0;

        //called by watchdog timer every 10 ms, returns true if new valid fix
        private bool ScanForNMEA()
        {
            //update the recv string so it can display at least something
            recvSentenceSettings = pn.rawBuffer;

            //parse any data from pn.rawBuffer
            pn.ParseNMEA();

            //time for a frame update with new valid nmea data
            if (pn.updatedGGA | pn.updatedOGI | pn.updatedRMC)
            {
                //Measure the frequency of the GPS updates
                swHz.Stop();
                nowHz = ((double)System.Diagnostics.Stopwatch.Frequency) / (double)swHz.ElapsedTicks;

                //simple comp filter
                if (nowHz < 20) HzTime = 0.95 * HzTime + 0.05 * nowHz;
                //HzTime = Math.Round(HzTime, 0);

                swHz.Reset();
                swHz.Start();

                //reset  flags
                pn.updatedGGA = false;
                pn.updatedOGI = false;
                pn.updatedRMC = false;

                //update all data for new frame
                UpdateFixPosition();

                //Update the port connection counter - is reset every time new sentence is valid and ready
                recvCounter++;

                //new position updated
                return true;
            }
            else
            {
                return false;
            }
        }

        public double rollUsed;
        private double offset = 0;
        public double headlandDistanceDelta = 0, boundaryDistanceDelta = 0;

        private void UpdateFixPosition()
        {
            //start the watch and time till it gets back here
            swFrame.Reset();
            swFrame.Start();

            startCounter++;
            totalFixSteps = fixUpdateHz * 6;
            if (!isGPSPositionInitialized) { InitializeFirstFewGPSPositions(); return; }

            #region Antenna Offset

            if (vehicle.antennaOffset != 0)
            {
                if (vehicle.antennaOffset < 0)
                {
                    offset -= 0.01;
                    if (offset < vehicle.antennaOffset) offset = vehicle.antennaOffset;
                    pn.fix.easting = (Math.Cos(-fixHeading) * offset) + pn.fix.easting;
                    pn.fix.northing = (Math.Sin(-fixHeading) * offset) + pn.fix.northing;

                }
                else
                {
                    offset += 0.01;
                    if (offset > vehicle.antennaOffset) offset = vehicle.antennaOffset;
                    pn.fix.easting = (Math.Cos(-fixHeading) * offset) + pn.fix.easting;
                    pn.fix.northing = (Math.Sin(-fixHeading) * offset) + pn.fix.northing;
                }
            }

            #endregion

            #region Roll

            rollUsed = 0;

            if (ahrs.isRollFromBrick | ahrs.isRollFromAutoSteer | ahrs.isRollFromGPS | ahrs.isRollFromExtUDP)
            {
                rollUsed = ((double)(ahrs.rollX16 - ahrs.rollZeroX16)) * 0.0625;

                //change for roll to the right is positive times -1
                rollCorrectionDistance = Math.Sin(glm.toRadians((rollUsed))) * -vehicle.antennaHeight;

                // roll to left is positive  **** important!!
                // not any more - April 30, 2019 - roll to right is positive Now! Still Important
                pn.fix.easting = (Math.Cos(-fixHeading) * rollCorrectionDistance) + pn.fix.easting;
                pn.fix.northing = (Math.Sin(-fixHeading) * rollCorrectionDistance) + pn.fix.northing;
            }

            //pitchDistance = (pitch * vehicle.antennaHeight);
            //pn.fix.easting = (Math.Sin(fixHeading) * pitchDistance) + pn.fix.easting;
            //pn.fix.northing = (Math.Cos(fixHeading) * pitchDistance) + pn.fix.northing;

            #endregion Roll

            #region Step Fix

            //**** heading of the vec3 structure is used for distance in Step fix!!!!!

            //grab the most current fix and save the distance from the last fix
            distanceCurrentStepFix = glm.Distance(pn.fix, stepFixPts[0]);

            //tree spacing
            if (vehicle.treeSpacing != 0 && section[0].isSectionOn) treeSpacingCounter += (distanceCurrentStepFix * 100);

            //keep the distance below spacing
            if (treeSpacingCounter > vehicle.treeSpacing && vehicle.treeSpacing != 0)
            {
                if (treeTrigger == 0) treeTrigger = 1;
                else treeTrigger = 0;
                while (treeSpacingCounter > vehicle.treeSpacing) treeSpacingCounter -= vehicle.treeSpacing;
            }

            fixStepDist = distanceCurrentStepFix;

            //if  min distance isn't exceeded, keep adding old fixes till it does
            if (distanceCurrentStepFix <= minFixStepDist)
            {
                for (currentStepFix = 0; currentStepFix < totalFixSteps; currentStepFix++)
                {
                    fixStepDist += stepFixPts[currentStepFix].heading;
                    if (fixStepDist > minFixStepDist)
                    {
                        //if we reached end, keep the oldest and stay till distance is exceeded
                        if (currentStepFix < (totalFixSteps - 1)) currentStepFix++;
                        isFixHolding = false;
                        break;
                    }
                    else isFixHolding = true;
                }
            }

            // only takes a single fix to exceeed min distance
            else currentStepFix = 0;

            //if total distance is less then the addition of all the fixes, keep last one as reference
            if (isFixHolding)
            {
                if (isFixHoldLoaded == false)
                {
                    vHold = stepFixPts[(totalFixSteps - 1)];
                    isFixHoldLoaded = true;
                }

                //cycle thru like normal
                for (int i = totalFixSteps - 1; i > 0; i--) stepFixPts[i] = stepFixPts[i - 1];

                //fill in the latest distance and fix
                stepFixPts[0].heading = glm.Distance(pn.fix, stepFixPts[0]);
                stepFixPts[0].easting = pn.fix.easting;
                stepFixPts[0].northing = pn.fix.northing;

                //reload the last position that was triggered.
                stepFixPts[(totalFixSteps - 1)].heading = glm.Distance(vHold, stepFixPts[(totalFixSteps - 1)]);
                stepFixPts[(totalFixSteps - 1)].easting = vHold.easting;
                stepFixPts[(totalFixSteps - 1)].northing = vHold.northing;
            }

            else //distance is exceeded, time to do all calcs and next frame
            {
                //positions and headings 
                CalculatePositionHeading();

                //get rid of hold position
                isFixHoldLoaded = false;

                //don't add the total distance again
                stepFixPts[(totalFixSteps - 1)].heading = 0;

                //grab sentences for logging
                if (isLogNMEA) pn.logNMEASentence.Append(recvSentenceSettings);

                //To prevent drawing high numbers of triangles, determine and test before drawing vertex
                sectionTriggerDistance = glm.Distance(pn.fix, prevSectionPos);

                //section on off and points, contour points
                if (sectionTriggerDistance > sectionTriggerStepDistance && isJobStarted)
                {
                    AddSectionContourPathPoints();

                    //grab fix and elevation
                    if (isLogElevation) sbFix.Append(pn.fix.easting.ToString("N2") + "," + pn.fix.northing.ToString("N2") + ","
                                                        + pn.altitude.ToString("N2") + ","
                                                        + pn.latitude + "," + pn.longitude + "\r\n");
                }

                //test if travelled far enough for new boundary point
                double boundaryDistance = glm.Distance(pn.fix, prevBoundaryPos);
                if (boundaryDistance > 1) AddBoundaryAndPerimiterPoint();

                //calc distance travelled since last GPS fix
                distance = glm.Distance(pn.fix, prevFix);
                if ((fd.distanceUser += distance) > 3000) fd.distanceUser = 0; ;//userDistance can be reset

                //most recent fixes are now the prev ones
                prevFix.easting = pn.fix.easting; prevFix.northing = pn.fix.northing;

                //load up history with valid data
                for (int i = totalFixSteps - 1; i > 0; i--) stepFixPts[i] = stepFixPts[i - 1];
                stepFixPts[0].heading = glm.Distance(pn.fix, stepFixPts[0]);
                stepFixPts[0].easting = pn.fix.easting;
                stepFixPts[0].northing = pn.fix.northing;
            }
            #endregion fix

            #region AutoSteer

            //preset the values
            guidanceLineDistanceOff = 32000;

            if (ct.isContourBtnOn)
            {
                ct.DistanceFromContourLine(pivotAxlePos, steerAxlePos);
            }
            else
            {
                if (curve.isCurveSet)
                {
                    //do the calcs for AB Curve
                    curve.GetCurrentCurveLine(pivotAxlePos, steerAxlePos);
                }

                if (ABLine.isABLineSet)
                {
                    ABLine.GetCurrentABLine(pivotAxlePos, steerAxlePos);
                    if (yt.isRecordingCustomYouTurn)
                    {
                        //save reference of first point
                        if (yt.youFileList.Count == 0)
                        {
                            vec2 start = new vec2(steerAxlePos.easting, steerAxlePos.northing);
                            yt.youFileList.Add(start);
                        }
                        else
                        {
                            //keep adding points
                            vec2 point = new vec2(steerAxlePos.easting - yt.youFileList[0].easting, steerAxlePos.northing - yt.youFileList[0].northing);
                            yt.youFileList.Add(point);
                        }
                    }
                }
            }

            // autosteer at full speed of updates
            if (!isAutoSteerBtnOn) //32020 means auto steer is off
            {
                guidanceLineDistanceOff = 32020;
            }

            //if the whole path driving driving process is green
            if (recPath.isDrivingRecordedPath) recPath.UpdatePosition();

            // If Drive button enabled be normal, or just fool the autosteer and fill values
            if (!ast.isInFreeDriveMode)
            {
                if (rollUsed != 0)
                {
                    guidanceLineSteerAngle = (Int16)(guidanceLineSteerAngle +
                        ((-rollUsed) * ((double)mc.autoSteerSettings[mc.ssKd] / 50)) * 500);
                }

                //fill up0 the appropriate arrays with new values
                mc.autoSteerData[mc.sdSpeed] = unchecked((byte)(pn.speed * 4.0));
                mc.machineControlData[mc.cnSpeed] = mc.autoSteerData[mc.sdSpeed];

                mc.autoSteerData[mc.sdDistanceHi] = unchecked((byte)(guidanceLineDistanceOff >> 8));
                mc.autoSteerData[mc.sdDistanceLo] = unchecked((byte)(guidanceLineDistanceOff));

                mc.autoSteerData[mc.sdSteerAngleHi] = unchecked((byte)(guidanceLineSteerAngle >> 8));
                mc.autoSteerData[mc.sdSteerAngleLo] = unchecked((byte)(guidanceLineSteerAngle));

                //out serial to autosteer module  //indivdual classes load the distance and heading deltas 
                AutoSteerDataOutToPort();
            }

            else
            {
                //fill up the auto steer array with free drive values
                //fill up the auto steer array with free drive values
                mc.autoSteerData[mc.sdSpeed] = unchecked((byte)(pn.speed * 4.0 + 16));
                mc.machineControlData[mc.cnSpeed] = mc.autoSteerData[mc.sdSpeed];

                //make steer module think everything is normal
                guidanceLineDistanceOff = 0;
                mc.autoSteerData[mc.sdDistanceHi] = unchecked((byte)(0));
                mc.autoSteerData[mc.sdDistanceLo] = unchecked((byte)0);

                guidanceLineSteerAngle = (Int16)(ast.driveFreeSteerAngle * 100);
                mc.autoSteerData[mc.sdSteerAngleHi] = unchecked((byte)(guidanceLineSteerAngle >> 8));
                mc.autoSteerData[mc.sdSteerAngleLo] = unchecked((byte)(guidanceLineSteerAngle));

                //out serial to autosteer module  //indivdual classes load the distance and heading deltas 
                AutoSteerDataOutToPort();
            }

            //for average cross track error
            if (guidanceLineDistanceOff < 29000)
            {
                avgXTE[avgXTECntr] = Math.Abs(guidanceLineDistanceOff);
                if (avgXTECntr++ > 10) avgXTECntr = 0;
                crossTrackError = 0;
                for (int i = 0; i < 11; i++)
                {
                    crossTrackError += (int)avgXTE[i];
                }
                crossTrackError /= 10;
            }
            else
            {
                avgXTE[avgXTECntr] = 0;
                if (avgXTECntr++ > 10) avgXTECntr = 0;
                crossTrackError = 0;
            }

            #endregion

            #region Youturn

            //reset the fault distance to an appropriate weird number
            //-2222 means it fell out of the loop completely
            //-3333 means unable to find a nearest point at all even though inside the work area of field
            // -4444 means cross trac error too high
            distancePivotToTurnLine = -4444;

            //always force out of bounds and change only if in bounds after proven so
            mc.isOutOfBounds = true;

            //if an outer boundary is set, then apply critical stop logic
            if (bnd.bndArr.Count > 0)
            {
                //Are we inside outer and outside inner all turn boundaries, no turn creation problems
                if (IsInsideGeoFence() && !yt.isTurnCreationTooClose && !yt.isTurnCreationNotCrossingError)
                {
                    //reset critical stop for bounds violation
                    mc.isOutOfBounds = false;

                    //do the auto youturn logic if everything is on.
                    if (yt.isYouTurnBtnOn && isAutoSteerBtnOn)
                    {
                        //if we are too much off track > 1.3m, kill the diagnostic creation, start again
                        if (crossTrackError > 1300 && !yt.isYouTurnTriggered)
                        {
                            yt.ResetCreatedYouTurn();
                        }
                        else
                        {
                            //now check to make sure we are not in an inner turn boundary - drive thru is ok
                            if (yt.youTurnPhase != 3)
                            {
                                if (crossTrackError > 500)
                                {
                                    yt.ResetCreatedYouTurn();
                                }
                                else
                                {
                                    if (yt.isUsingDubinsTurn)
                                    {
                                        if (ABLine.isABLineSet) yt.BuildABLineDubinsYouTurn(yt.isYouTurnRight);
                                        else yt.BuildCurveDubinsYouTurn(yt.isYouTurnRight, pivotAxlePos);
                                    }
                                    else
                                    {
                                        if (ABLine.isABLineSet) yt.BuildABLinePatternYouTurn(yt.isYouTurnRight);
                                        else yt.BuildCurvePatternYouTurn(yt.isYouTurnRight, pivotAxlePos);
                                    }
                                }
                            }
                            else //wait to trigger the actual turn since its made and waiting
                            {
                                //distance from current pivot to first point of youturn pattern
                                distancePivotToTurnLine = glm.Distance(yt.ytList[0], steerAxlePos);

                                if ((distancePivotToTurnLine <= 20.0) && (distancePivotToTurnLine >= 18.0) && !yt.isYouTurnTriggered)

                                    if (!isBoundAlarming)
                                    {
                                        sndBoundaryAlarm.Play();
                                        isBoundAlarming = true;
                                    }

                                //if we are close enough to pattern, trigger.
                                if ((distancePivotToTurnLine <= 1.0) && (distancePivotToTurnLine >= 0) && !yt.isYouTurnTriggered)
                                {
                                    yt.YouTurnTrigger();
                                    isBoundAlarming = false;
                                }
                            }
                        }
                    } // end of isInWorkingArea
                }
                // here is stop logic for out of bounds - in an inner or out the outer turn border.
                else
                {
                    mc.isOutOfBounds = true;
                    if (yt.isYouTurnBtnOn)
                    {
                        yt.ResetCreatedYouTurn();
                        sim.stepDistance = 0 / 17.86;
                    }
                }
            }
            else
            {
                mc.isOutOfBounds = false;
            }

            #endregion

            //calculate lookahead at full speed, no sentence misses
            CalculateSectionLookAhead(toolPos.northing, toolPos.easting, cosSectionHeading, sinSectionHeading);

            //update main window
            oglMain.MakeCurrent();
            oglMain.Refresh();

            //end of UppdateFixPosition

            swFrame.Stop();

            //stop the timer and calc how long it took to do calcs and draw
            frameTime = (double)swFrame.ElapsedTicks / (double)System.Diagnostics.Stopwatch.Frequency * 1000;
        }

        public bool isBoundAlarming;


        //all the hitch, pivot, section, trailing hitch, headings and fixes
        private void CalculatePositionHeading()
        {
            switch (headingFromSource)
            {
                case "Fix":
                    gpsHeading = Math.Atan2(pn.fix.easting - stepFixPts[currentStepFix].easting, pn.fix.northing - stepFixPts[currentStepFix].northing);
                    if (gpsHeading < 0) gpsHeading += glm.twoPI;
                    fixHeading = gpsHeading;

                    //determine fix positions and heading in degrees for glRotate opengl methods.
                    int camStep = currentStepFix * 4;
                    if (camStep > (totalFixSteps - 1)) camStep = (totalFixSteps - 1);
                    camHeading = Math.Atan2(pn.fix.easting - stepFixPts[camStep].easting, pn.fix.northing - stepFixPts[camStep].northing);
                    if (camHeading < 0) camHeading += glm.twoPI;
                    camHeading = glm.toDegrees(camHeading);
                    break;

                case "GPS":
                    //use NMEA headings for camera and tractor graphic
                    fixHeading = glm.toRadians(pn.headingTrue);
                    camHeading = pn.headingTrue;
                    gpsHeading = glm.toRadians(pn.headingTrue);
                    break;

                case "HDT":
                    //use NMEA headings for camera and tractor graphic
                    fixHeading = glm.toRadians(pn.headingHDT);
                    camHeading = pn.headingHDT;
                    gpsHeading = glm.toRadians(pn.headingHDT);
                    break;
            }

            //an IMU with heading correction, add the correction
            if (ahrs.isHeadingFromBrick | ahrs.isHeadingFromAutoSteer | ahrs.isHeadingFromPAOGI | ahrs.isHeadingFromExtUDP)
            {
                //current gyro angle in radians
                double correctionHeading = (glm.toRadians((double)ahrs.correctionHeadingX16 * 0.0625));

                //Difference between the IMU heading and the GPS heading
                double gyroDelta = (correctionHeading + gyroCorrection) - gpsHeading;
                if (gyroDelta < 0) gyroDelta += glm.twoPI;

                //calculate delta based on circular data problem 0 to 360 to 0, clamp to +- 2 Pi
                if (gyroDelta >= -glm.PIBy2 && gyroDelta <= glm.PIBy2) gyroDelta *= -1.0;
                else
                {
                    if (gyroDelta > glm.PIBy2) { gyroDelta = glm.twoPI - gyroDelta; }
                    else { gyroDelta = (glm.twoPI + gyroDelta) * -1.0; }
                }
                if (gyroDelta > glm.twoPI) gyroDelta -= glm.twoPI;
                if (gyroDelta < -glm.twoPI) gyroDelta += glm.twoPI;

                //if the gyro and last corrected fix is < 10 degrees, super low pass for gps
                if (Math.Abs(gyroDelta) < 0.18)
                {
                    //a bit of delta and add to correction to current gyro
                    gyroCorrection += (gyroDelta * (0.25 / fixUpdateHz));
                    if (gyroCorrection > glm.twoPI) gyroCorrection -= glm.twoPI;
                    if (gyroCorrection < -glm.twoPI) gyroCorrection += glm.twoPI;
                }
                else
                {
                    //a bit of delta and add to correction to current gyro
                    gyroCorrection += (gyroDelta * (2.0 / fixUpdateHz));
                    if (gyroCorrection > glm.twoPI) gyroCorrection -= glm.twoPI;
                    if (gyroCorrection < -glm.twoPI) gyroCorrection += glm.twoPI;
                }

                //determine the Corrected heading based on gyro and GPS
                gyroCorrected = correctionHeading + gyroCorrection;
                if (gyroCorrected > glm.twoPI) gyroCorrected -= glm.twoPI;
                if (gyroCorrected < 0) gyroCorrected += glm.twoPI;

                fixHeading = gyroCorrected;
            }

            #region pivot hitch trail

            //translate world to the pivot axle
            pivotAxlePos.easting = pn.fix.easting - (Math.Sin(fixHeading) * vehicle.antennaPivot);
            pivotAxlePos.northing = pn.fix.northing - (Math.Cos(fixHeading) * vehicle.antennaPivot);
            pivotAxlePos.heading = fixHeading;

            //translate from pivot position to steer axle position
            steerAxlePos.easting = pivotAxlePos.easting + (Math.Sin(fixHeading) * vehicle.wheelbase);
            steerAxlePos.northing = pivotAxlePos.northing + (Math.Cos(fixHeading) * vehicle.wheelbase);
            steerAxlePos.heading = fixHeading;

            //determine where the rigid vehicle hitch ends
            hitchPos.easting = pn.fix.easting + (Math.Sin(fixHeading) * (tool.hitchLength - vehicle.antennaPivot));
            hitchPos.northing = pn.fix.northing + (Math.Cos(fixHeading) * (tool.hitchLength - vehicle.antennaPivot));

            //tool attached via a trailing hitch
            if (tool.isToolTrailing)
            {
                double over;
                if (tool.isToolTBT)
                {
                    //Torriem rules!!!!! Oh yes, this is all his. Thank-you
                    if (distanceCurrentStepFix != 0)
                    {
                        double t = (tool.toolTankTrailingHitchLength) / distanceCurrentStepFix;
                        tankPos.easting = hitchPos.easting + t * (hitchPos.easting - tankPos.easting);
                        tankPos.northing = hitchPos.northing + t * (hitchPos.northing - tankPos.northing);
                        tankPos.heading = Math.Atan2(hitchPos.easting - tankPos.easting, hitchPos.northing - tankPos.northing);
                    }

                    ////the tool is seriously jacknifed or just starting out so just spring it back.
                    over = Math.Abs(Math.PI - Math.Abs(Math.Abs(tankPos.heading - fixHeading) - Math.PI));

                    if (over < 2.0 && startCounter > 50)
                    {
                        tankPos.easting = hitchPos.easting + (Math.Sin(tankPos.heading) * (tool.toolTankTrailingHitchLength));
                        tankPos.northing = hitchPos.northing + (Math.Cos(tankPos.heading) * (tool.toolTankTrailingHitchLength));
                    }

                    //criteria for a forced reset to put tool directly behind vehicle
                    if (over > 2.0 | startCounter < 51)
                    {
                        tankPos.heading = fixHeading;
                        tankPos.easting = hitchPos.easting + (Math.Sin(tankPos.heading) * (tool.toolTankTrailingHitchLength));
                        tankPos.northing = hitchPos.northing + (Math.Cos(tankPos.heading) * (tool.toolTankTrailingHitchLength));
                    }
                }
                else
                {
                    tankPos.heading = fixHeading;
                    tankPos.easting = hitchPos.easting;
                    tankPos.northing = hitchPos.northing;
                }

                //Torriem rules!!!!! Oh yes, this is all his. Thank-you
                if (distanceCurrentStepFix != 0)
                {
                    double t = (tool.toolTrailingHitchLength) / distanceCurrentStepFix;
                    toolPos.easting = tankPos.easting + t * (tankPos.easting - toolPos.easting);
                    toolPos.northing = tankPos.northing + t * (tankPos.northing - toolPos.northing);
                    toolPos.heading = Math.Atan2(tankPos.easting - toolPos.easting, tankPos.northing - toolPos.northing);
                }

                ////the tool is seriously jacknifed or just starting out so just spring it back.
                over = Math.Abs(Math.PI - Math.Abs(Math.Abs(toolPos.heading - tankPos.heading) - Math.PI));

                if (over < 1.9 && startCounter > 50)
                {
                    toolPos.easting = tankPos.easting + (Math.Sin(toolPos.heading) * (tool.toolTrailingHitchLength));
                    toolPos.northing = tankPos.northing + (Math.Cos(toolPos.heading) * (tool.toolTrailingHitchLength));
                }

                //criteria for a forced reset to put tool directly behind vehicle
                if (over > 1.9 | startCounter < 51)
                {
                    toolPos.heading = tankPos.heading;
                    toolPos.easting = tankPos.easting + (Math.Sin(toolPos.heading) * (tool.toolTrailingHitchLength));
                    toolPos.northing = tankPos.northing + (Math.Cos(toolPos.heading) * (tool.toolTrailingHitchLength));
                }
            }

            //rigidly connected to vehicle
            else
            {
                toolPos.heading = fixHeading;
                toolPos.easting = hitchPos.easting;
                toolPos.northing = hitchPos.northing;
            }

            #endregion
            //used to increase triangle count when going around corners, less on straight
            //pick the slow moving side edge of tool
            double distance = tool.toolWidth * 0.5;
            if (distance > 8) distance = 8;

            
            //whichever is less
            if (tool.toolFarLeftSpeed < tool.toolFarRightSpeed)
            {
                double twist = tool.toolFarLeftSpeed / tool.toolFarRightSpeed;
                //twist *= twist;
                if (twist < 0.2) twist = 0.2;
                sectionTriggerStepDistance = distance * twist* twist;
            }
            else
            {
                double twist = tool.toolFarRightSpeed / tool.toolFarLeftSpeed;
                //twist *= twist;
                if (twist < 0.2) twist = 0.2;

                sectionTriggerStepDistance = distance * twist*twist;
            }

            //finally determine distance
            if (!curve.isOkToAddPoints) sectionTriggerStepDistance = sectionTriggerStepDistance + 0.5;
            else sectionTriggerStepDistance = 1.0;

            //precalc the sin and cos of heading * -1
            sinSectionHeading = Math.Sin(-toolPos.heading);
            cosSectionHeading = Math.Cos(-toolPos.heading);
        }

        //perimeter and boundary point generation
        public void AddBoundaryAndPerimiterPoint()
        {
            //save the north & east as previous
            prevBoundaryPos.easting = pn.fix.easting;
            prevBoundaryPos.northing = pn.fix.northing;

            //build the boundary line

            if (bnd.isOkToAddPoints)
            {
                if (bnd.isDrawRightSide)
                {
                    //Right side
                    //vec3 point = new vec3(cosSectionHeading * (section[tool.numOfSections - 1].positionRight) + toolPos.easting,
                    //    sinSectionHeading * (section[tool.numOfSections - 1].positionRight) + toolPos.northing, toolPos.heading);
                    vec3 point = new vec3(
                        pivotAxlePos.easting + (Math.Sin(pivotAxlePos.heading - glm.PIBy2) * -bnd.createBndOffset),
                        pivotAxlePos.northing + (Math.Cos(pivotAxlePos.heading - glm.PIBy2) * -bnd.createBndOffset), 
                        pivotAxlePos.heading);
                    bnd.bndBeingMadePts.Add(point);
                }

                //draw on left side
                else
                {
                    //Right side
                    //vec3 point = new vec3(cosSectionHeading * (section[0].positionLeft) + toolPos.easting,
                    //    sinSectionHeading * (section[0].positionLeft) + toolPos.northing, toolPos.heading);
                    vec3 point = new vec3(
                        pivotAxlePos.easting + (Math.Sin(pivotAxlePos.heading - glm.PIBy2) * bnd.createBndOffset),
                        pivotAxlePos.northing + (Math.Cos(pivotAxlePos.heading - glm.PIBy2) * bnd.createBndOffset), 
                        pivotAxlePos.heading);

                    bnd.bndBeingMadePts.Add(point);
                }
            }
        }

        //add the points for section, contour line points, Area Calc feature
        private void AddSectionContourPathPoints()
        {

            if (recPath.isRecordOn)
            {
                //keep minimum speed of 1.0
                double speed = pn.speed;
                if (pn.speed < 1.0) speed = 1.0;
                bool autoBtn = (autoBtnState == btnStates.Auto);

                CRecPathPt pt = new CRecPathPt(steerAxlePos.easting, steerAxlePos.northing, steerAxlePos.heading, pn.speed, autoBtn);
                recPath.recList.Add(pt);
            }

            if (curve.isOkToAddPoints)
            {
                vec3 pt = new vec3(pivotAxlePos.easting, pivotAxlePos.northing, pivotAxlePos.heading);
                curve.refList.Add(pt);
            }

            //save the north & east as previous
            prevSectionPos.northing = pn.fix.northing;
            prevSectionPos.easting = pn.fix.easting;

            // if non zero, at least one section is on.
            int sectionCounter = 0;

            //send the current and previous GPS fore/aft corrected fix to each section
            for (int j = 0; j < tool.numOfSections + 1; j++)
            {
                if (section[j].isSectionOn)
                {
                    section[j].AddPathPoint(toolPos.northing, toolPos.easting, cosSectionHeading, sinSectionHeading);
                    sectionCounter++;
                }
            }
            if ((ABLine.isBtnABLineOn && !ct.isContourBtnOn && ABLine.isABLineSet && isAutoSteerBtnOn) ||
                        (!ct.isContourBtnOn && curve.isBtnCurveOn && curve.isCurveSet && isAutoSteerBtnOn))
            {
                //no contour recorded
                if (ct.isContourOn) { ct.StopContourLine(steerAxlePos); }
            }
            else
            {
                //if (ABLine.isABLineSet && isAutoSteerBtnOn)
                //if (isStanleyUsed)
                //{
                //    //Contour Base Track.... At least One section on, turn on if not
                //    if (sectionCounter != 0)
                //    {
                //        //keep the line going, everything is on for recording path
                //        if (ct.isContourOn) ct.AddPoint(steerAxlePos);
                //        else
                //        {
                //            ct.StartContourLine(steerAxlePos);
                //            ct.AddPoint(steerAxlePos);
                //        }
                //    }

                //    //All sections OFF so if on, turn off
                //    else { if (ct.isContourOn) { ct.StopContourLine(steerAxlePos); } }

                //    //Build contour line if close enough to a patch
                //    if (ct.isContourBtnOn) ct.BuildContourGuidanceLine(steerAxlePos);

                //}

                //else
                {
                    //Contour Base Track.... At least One section on, turn on if not
                    if (sectionCounter != 0)
                    {
                        //keep the line going, everything is on for recording path
                        if (ct.isContourOn) ct.AddPoint(pivotAxlePos);
                        else
                        {
                            ct.StartContourLine(pivotAxlePos);
                            ct.AddPoint(pivotAxlePos);
                        }
                    }

                    //All sections OFF so if on, turn off
                    else { if (ct.isContourOn) { ct.StopContourLine(pivotAxlePos); } }

                    //Build contour line if close enough to a patch
                    if (ct.isContourBtnOn) ct.BuildContourGuidanceLine(pivotAxlePos);
                }
            }

        }

        //calculate the extreme tool left, right velocities, each section lookahead, and whether or not its going backwards
        public void CalculateSectionLookAhead(double northing, double easting, double cosHeading, double sinHeading)
        {
            //calculate left side of section 1
            vec2 left = new vec2(0, 0);
            vec2 right = left;
            double leftSpeed = 0, rightSpeed = 0, leftLook = 0, rightLook = 0;

            //now loop all the section rights and the one extreme left
            for (int j = 0; j < tool.numOfSections; j++)
            {
                if (j == 0)
                {
                    //only one first left point, the rest are all rights moved over to left
                    section[j].leftPoint = new vec2(cosHeading * (section[j].positionLeft) + easting,
                                       sinHeading * (section[j].positionLeft) + northing);

                    left = section[j].leftPoint - section[j].lastLeftPoint;

                    //save a copy for next time
                    section[j].lastLeftPoint = section[j].leftPoint;

                    //get the speed for left side only once
                    leftSpeed = left.GetLength() / fixUpdateTime * 10;
                    leftLook = leftSpeed * tool.toolLookAhead;

                    //save the far left speed
                    tool.toolFarLeftSpeed = leftSpeed;
                }
                else
                {
                    //right point from last section becomes this left one
                    section[j].leftPoint = section[j - 1].rightPoint;
                    left = section[j].leftPoint - section[j].lastLeftPoint;

                    //save a copy for next time
                    section[j].lastLeftPoint = section[j].leftPoint;
                    leftSpeed = rightSpeed;
                }

                section[j].rightPoint = new vec2(cosHeading * (section[j].positionRight) + easting,
                                    sinHeading * (section[j].positionRight) + northing);

                //now we have left and right for this section
                right = section[j].rightPoint - section[j].lastRightPoint;

                //save a copy for next time
                section[j].lastRightPoint = section[j].rightPoint;

                //grab vector length and convert to meters/sec/10 pixels per meter                
                rightSpeed = right.GetLength() / fixUpdateTime * 10;
                rightLook = rightSpeed * tool.toolLookAhead;

                //Is section outer going forward or backward
                double head = left.HeadingXZ();
                if (Math.PI - Math.Abs(Math.Abs(head - toolPos.heading) - Math.PI) > glm.PIBy2) leftLook *= -1;

                head = right.HeadingXZ();
                if (Math.PI - Math.Abs(Math.Abs(head - toolPos.heading) - Math.PI) > glm.PIBy2) rightLook *= -1;

                //choose fastest speed
                if (leftLook > rightLook) section[j].sectionLookAhead = leftLook;
                else section[j].sectionLookAhead = rightLook;

                if (section[j].sectionLookAhead > 190) section[j].sectionLookAhead = 190;

                //Doing the slow mo, exceeding buffer so just set as minimum 0.5 meter
                if (currentStepFix >= totalFixSteps - 1) section[j].sectionLookAhead = 5;
            }//endfor

            //set up the super for youturn
            section[tool.numOfSections].isInsideBoundary = true;

            //determine if section is in boundary using the section left/right positions
            bool isLeftIn = true, isRightIn = true;
            for (int j = 0; j < tool.numOfSections; j++)
            {
                if (bnd.bndArr.Count > 0)
                {
                    //is a headland
                    if ( hd.isOn)
                    {
                        if (j == 0)
                        {
                            //only one first left point, the rest are all rights moved over to left
                            isLeftIn = hd.headArr[0].IsPointInHeadArea(section[j].leftPoint);
                            isRightIn = hd.headArr[0].IsPointInHeadArea(section[j].rightPoint);

                            //merge the two sides into in or out
                            if (!isLeftIn && !isRightIn) section[j].isInsideBoundary = false;
                            else section[j].isInsideBoundary = true;
                        }

                        else
                        {
                            //grab the right of previous section, its the left of this section
                            isLeftIn = isRightIn;
                            isRightIn = hd.headArr[0].IsPointInHeadArea(section[j].rightPoint);
                            for (int i = 1; i < hd.headArr.Count; i++)
                            {
                                //inner boundaries should normally NOT have point inside
                                //if (hd.headArr[i].isSet) isRightIn &= !hd.headArr[i].IsPointInHeadArea(section[j].rightPoint);
                            }

                            if (!isLeftIn && !isRightIn) section[j].isInsideBoundary = false;
                            else section[j].isInsideBoundary = true;
                        }
                        section[tool.numOfSections].isInsideBoundary &= section[j].isInsideBoundary;
                    }

                    //only outside boundary
                    else
                    {
                        if (j == 0)
                        {
                            //only one first left point, the rest are all rights moved over to left
                            isLeftIn = bnd.bndArr[0].IsPointInsideBoundary(section[j].leftPoint);
                            isRightIn = bnd.bndArr[0].IsPointInsideBoundary(section[j].rightPoint);

                            for (int i = 1; i < bnd.bndArr.Count; i++)
                            {
                                //inner boundaries should normally NOT have point inside
                                if (bnd.bndArr[i].isSet)
                                {
                                    isLeftIn &= !bnd.bndArr[i].IsPointInsideBoundary(section[j].leftPoint);
                                    isRightIn &= !bnd.bndArr[i].IsPointInsideBoundary(section[j].rightPoint);
                                }
                            }

                            //merge the two sides into in or out
                            if (isLeftIn && isRightIn) section[j].isInsideBoundary = true;
                            else section[j].isInsideBoundary = false;
                        }

                        else
                        {
                            //grab the right of previous section, its the left of this section
                            isLeftIn = isRightIn;
                            isRightIn = bnd.bndArr[0].IsPointInsideBoundary(section[j].rightPoint);
                            for (int i = 1; i < bnd.bndArr.Count; i++)
                            {
                                //inner boundaries should normally NOT have point inside
                                if (bnd.bndArr[i].isSet) isRightIn &= !bnd.bndArr[i].IsPointInsideBoundary(section[j].rightPoint);
                            }

                            if (isLeftIn && isRightIn) section[j].isInsideBoundary = true;
                            else section[j].isInsideBoundary = false;
                        }
                        section[tool.numOfSections].isInsideBoundary &= section[j].isInsideBoundary;
                    }
                }

                //no boundary created so always inside
                else
                {
                    section[j].isInsideBoundary = true;
                    section[tool.numOfSections].isInsideBoundary = false;
                }
            }

            //with left and right tool velocity to determine rate of triangle generation, corners are more
            //save far right speed, 0 if going backwards, in meters/sec
            if (section[tool.numOfSections - 1].sectionLookAhead > 0) tool.toolFarRightSpeed = rightSpeed * 0.1;
            else tool.toolFarRightSpeed = 0;

            //save left side, 0 if going backwards, in meters/sec convert back from pixels/m
            if (section[0].sectionLookAhead > 0) tool.toolFarLeftSpeed = tool.toolFarLeftSpeed * 0.1;
            else tool.toolFarLeftSpeed = 0;

        }

        //the start of first few frames to initialize entire program
        private void InitializeFirstFewGPSPositions()
        {
            if (!isFirstFixPositionSet)
            {
                //reduce the huge utm coordinates
                pn.utmEast = (int)(pn.fix.easting);
                pn.utmNorth = (int)(pn.fix.northing);
                pn.fix.easting = pn.fix.easting - pn.utmEast;
                pn.fix.northing = pn.fix.northing - pn.utmNorth;

                //calculate the central meridian of current zone
                pn.centralMeridian = -177 + ((pn.zone - 1) * 6);

                //Azimuth Error - utm declination
                pn.convergenceAngle = Math.Atan(Math.Sin(glm.toRadians(pn.latitude)) * Math.Tan(glm.toRadians(pn.longitude - pn.centralMeridian)));
                lblConvergenceAngle.Text = Math.Round(glm.toDegrees(pn.convergenceAngle), 2).ToString();

                //Draw a grid once we know where in the world we are.
                isFirstFixPositionSet = true;
                worldGrid.CreateWorldGrid(pn.fix.northing, pn.fix.easting);

                //most recent fixes
                prevFix.easting = pn.fix.easting;
                prevFix.northing = pn.fix.northing;

                stepFixPts[0].easting = pn.fix.easting;
                stepFixPts[0].northing = pn.fix.northing;
                stepFixPts[0].heading = 0;

                //run once and return
                isFirstFixPositionSet = true;

                //set up the modules
                mc.ResetAllModuleCommValues();

                AutoSteerSettingsOutToPort();

                return;
            }

            else
            {
                //most recent fixes
                prevFix.easting = pn.fix.easting; prevFix.northing = pn.fix.northing;

                //load up history with valid data
                for (int i = totalFixSteps - 1; i > 0; i--)
                {
                    stepFixPts[i].easting = stepFixPts[i - 1].easting;
                    stepFixPts[i].northing = stepFixPts[i - 1].northing;
                    stepFixPts[i].heading = stepFixPts[i - 1].heading;
                }

                stepFixPts[0].heading = glm.Distance(pn.fix, stepFixPts[0]);
                stepFixPts[0].easting = pn.fix.easting;
                stepFixPts[0].northing = pn.fix.northing;

                //keep here till valid data
                if (startCounter > (totalFixSteps/2.0)) isGPSPositionInitialized = true;

                //in radians
                fixHeading = Math.Atan2(pn.fix.easting - stepFixPts[totalFixSteps - 1].easting, pn.fix.northing - stepFixPts[totalFixSteps - 1].northing);
                if (fixHeading < 0) fixHeading += glm.twoPI;
                toolPos.heading = fixHeading;

                //send out initial zero settings
                if (isGPSPositionInitialized)
                {
                    //set up the modules
                    mc.ResetAllModuleCommValues();

                    AutoSteerSettingsOutToPort();

                    IsBetweenSunriseSunset(pn.latitude, pn.longitude);

                    //set display accordingly
                    isDayTime = (DateTime.Now.Ticks < sunset.Ticks && DateTime.Now.Ticks > sunrise.Ticks);

                    lblSunrise.Text = sunrise.ToString("HH:mm");
                    lblSunset.Text = sunset.ToString("HH:mm");

                    if (isAutoDayNight)
                    {
                        isDay = isDayTime;
                        isDay = !isDay;
                        SwapDayNightMode();
                    }
                }
                return;
            }
        }

        public bool IsInsideGeoFence()
        {
            //first where are we, must be inside outer and outside of inner geofence non drive thru turn borders
            if (gf.geoFenceArr[0].IsPointInGeoFenceArea(pivotAxlePos))
            {
                for (int i = 1; i < bnd.bndArr.Count; i++)
                {
                    //make sure not inside a non drivethru boundary
                    if (!bnd.bndArr[i].isSet) continue;
                    if (bnd.bndArr[i].isDriveThru) continue;
                    if (gf.geoFenceArr[i].IsPointInGeoFenceArea(pivotAxlePos))
                    {
                        distancePivotToTurnLine = -3333;
                        return false;
                    }
                }
            }
            else
            {
                distancePivotToTurnLine = -3333;
                return false;
            }
            //we are safely inside outer, outside inner boundaries
            return true;
        }       

        // intense math section....   the lat long converted to utm   *********************************************************
            #region utm Calculations
        private double sm_a = 6378137.0;
        private double sm_b = 6356752.314;
        private double UTMScaleFactor2 = 1.0004001600640256102440976390556;

        //the result is placed in these two
        public double utmLat = 0;
        public double utmLon = 0;

        //public double RollDistance { get => rollCorrectionDistance; set => rollCorrectionDistance = value; }

        public void UTMToLatLon(double X, double Y)
        {
            double cmeridian;

            X -= 500000.0;
            X *= UTMScaleFactor2;

            /* If in southern hemisphere, adjust y accordingly. */
            if (pn.hemisphere == 'S')
                Y -= 10000000.0;
            Y *= UTMScaleFactor2;

            cmeridian = (-183.0 + (pn.zone * 6.0)) * 0.01745329251994329576923690766743;
            double[] latlon = new double[2]; //= MapXYToLatLon(X, Y, cmeridian);          
  
            double phif, Nf, Nfpow, nuf2, ep2, tf, tf2, tf4, cf;
            double x1frac, x2frac, x3frac, x4frac, x5frac, x6frac, x7frac, x8frac;
            double x2poly, x3poly, x4poly, x5poly, x6poly, x7poly, x8poly;

            /* Get the value of phif, the footpoint latitude. */
            phif = FootpointLatitude(Y);

            /* Precalculate ep2 */
            ep2 = (Math.Pow(sm_a, 2.0) - Math.Pow(sm_b, 2.0))
                  / Math.Pow(sm_b, 2.0);

            /* Precalculate cos (phif) */
            cf = Math.Cos(phif);

            /* Precalculate nuf2 */
            nuf2 = ep2 * Math.Pow(cf, 2.0);

            /* Precalculate Nf and initialize Nfpow */
            Nf = Math.Pow(sm_a, 2.0) / (sm_b * Math.Sqrt(1 + nuf2));
            Nfpow = Nf;

            /* Precalculate tf */
            tf = Math.Tan(phif);
            tf2 = tf * tf;
            tf4 = tf2 * tf2;

            /* Precalculate fractional coefficients for x**n in the equations
               below to simplify the expressions for latitude and longitude. */
            x1frac = 1.0 / (Nfpow * cf);

            Nfpow *= Nf;   /* now equals Nf**2) */
            x2frac = tf / (2.0 * Nfpow);

            Nfpow *= Nf;   /* now equals Nf**3) */
            x3frac = 1.0 / (6.0 * Nfpow * cf);

            Nfpow *= Nf;   /* now equals Nf**4) */
            x4frac = tf / (24.0 * Nfpow);

            Nfpow *= Nf;   /* now equals Nf**5) */
            x5frac = 1.0 / (120.0 * Nfpow * cf);

            Nfpow *= Nf;   /* now equals Nf**6) */
            x6frac = tf / (720.0 * Nfpow);

            Nfpow *= Nf;   /* now equals Nf**7) */
            x7frac = 1.0 / (5040.0 * Nfpow * cf);

            Nfpow *= Nf;   /* now equals Nf**8) */
            x8frac = tf / (40320.0 * Nfpow);

            /* Precalculate polynomial coefficients for x**n.
               -- x**1 does not have a polynomial coefficient. */
            x2poly = -1.0 - nuf2;

            x3poly = -1.0 - 2 * tf2 - nuf2;

            x4poly = 5.0 + 3.0 * tf2 + 6.0 * nuf2 - 6.0 * tf2 * nuf2
                - 3.0 * (nuf2 * nuf2) - 9.0 * tf2 * (nuf2 * nuf2);

            x5poly = 5.0 + 28.0 * tf2 + 24.0 * tf4 + 6.0 * nuf2 + 8.0 * tf2 * nuf2;

            x6poly = -61.0 - 90.0 * tf2 - 45.0 * tf4 - 107.0 * nuf2
                + 162.0 * tf2 * nuf2;

            x7poly = -61.0 - 662.0 * tf2 - 1320.0 * tf4 - 720.0 * (tf4 * tf2);

            x8poly = 1385.0 + 3633.0 * tf2 + 4095.0 * tf4 + 1575 * (tf4 * tf2);

            /* Calculate latitude */
            latlon[0] = phif + x2frac * x2poly * (X * X)
                + x4frac * x4poly * Math.Pow(X, 4.0)
                + x6frac * x6poly * Math.Pow(X, 6.0)
                + x8frac * x8poly * Math.Pow(X, 8.0);

            /* Calculate longitude */
            latlon[1] = cmeridian + x1frac * X
                + x3frac * x3poly * Math.Pow(X, 3.0)
                + x5frac * x5poly * Math.Pow(X, 5.0)
                + x7frac * x7poly * Math.Pow(X, 7.0);

            utmLat = latlon[0] * 57.295779513082325225835265587528;
            utmLon = latlon[1] * 57.295779513082325225835265587528;
        }
 
        private double FootpointLatitude(double y)
        {
            double y_, alpha_, beta_, gamma_, delta_, epsilon_, n;
            double result;

            /* Precalculate n (Eq. 10.18) */
            n = (sm_a - sm_b) / (sm_a + sm_b);

            /* Precalculate alpha_ (Eq. 10.22) */
            /* (Same as alpha in Eq. 10.17) */
            alpha_ = ((sm_a + sm_b) / 2.0)
                * (1 + (Math.Pow(n, 2.0) / 4) + (Math.Pow(n, 4.0) / 64));

            /* Precalculate y_ (Eq. 10.23) */
            y_ = y / alpha_;

            /* Precalculate beta_ (Eq. 10.22) */
            beta_ = (3.0 * n / 2.0) + (-27.0 * Math.Pow(n, 3.0) / 32.0)
                + (269.0 * Math.Pow(n, 5.0) / 512.0);

            /* Precalculate gamma_ (Eq. 10.22) */
            gamma_ = (21.0 * Math.Pow(n, 2.0) * 0.0625)
                + (-55.0 * Math.Pow(n, 4.0) / 32.0);

            /* Precalculate delta_ (Eq. 10.22) */
            delta_ = (151.0 * Math.Pow(n, 3.0) / 96.0)
                + (-417.0 * Math.Pow(n, 5.0) / 128.0);

            /* Precalculate epsilon_ (Eq. 10.22) */
            epsilon_ = (1097.0 * Math.Pow(n, 4.0) / 512.0);

            /* Now calculate the sum of the series (Eq. 10.21) */
            result = y_ + (beta_ * Math.Sin(2.0 * y_))
                + (gamma_ * Math.Sin(4.0 * y_))
                + (delta_ * Math.Sin(6.0 * y_))
                + (epsilon_ * Math.Sin(8.0 * y_));

            return result;
        }

#endregion

    }//end class
}//end namespace

////its a drive thru inner boundary
//else
//{

//    if (distPivot < yt.triggerDistance && distPivot > (yt.triggerDistance - 2.0) && !yt.isEnteringDriveThru && !yt.isInboundary && isBndInWay)
//    {
//        //our direction heading into turn
//        //yt.youTurnTriggerPoint = pivotAxlePos;
//        yt.isEnteringDriveThru = true;
//        headlandAngleOffPerpendicular = Math.PI - Math.Abs(Math.Abs(hl.closestHeadlandPt.heading - pivotAxlePos.heading) - Math.PI);
//        if (headlandAngleOffPerpendicular < 0) headlandAngleOffPerpendicular += glm.twoPI;
//        //while (headlandAngleOffPerpendicular > 1.57) headlandAngleOffPerpendicular -= 1.57;
//        headlandAngleOffPerpendicular -= glm.PIBy2;
//        headlandDistanceDelta = Math.Tan(Math.Abs(headlandAngleOffPerpendicular));
//        headlandDistanceDelta *= tool.toolWidth;
//    }

//    if (yt.isEnteringDriveThru)
//    {
//        int c = 0;
//        for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
//        {
//            //checked for any not triggered yet (false) - if there is, not done yet
//            if (!seq.seqEnter[i].isTrig) c++;
//        }

//        if (c == 0)
//        {
//            //sequences all done so reset everything
//            //yt.isSequenceTriggered = false;
//            yt.whereAmI = 0;
//            yt.ResetSequenceEventTriggers();
//            distTool = -2222;
//            yt.isEnteringDriveThru = false;
//            yt.isExitingDriveThru = true;
//            //yt.youTurnTriggerPoint = pivotAxlePos;
//        }
//    }

//    if (yt.isExitingDriveThru)
//    {
//        int c = 0;
//        for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
//        {
//            //checked for any not triggered yet (false) - if there is, not done yet
//            if (!seq.seqExit[i].isTrig) c++;
//        }

//        if (c == 0)
//        {
//            //sequences all done so reset everything
//            //yt.isSequenceTriggered = false;
//            yt.whereAmI = 0;
//            yt.ResetSequenceEventTriggers();
//            distTool = -2222;
//            yt.isEnteringDriveThru = false;
//            yt.isExitingDriveThru = false;
//            yt.youTurnTriggerPoint = pivotAxlePos;
//        }
//    }
//}

//Do the sequencing of functions around the turn.
//if (yt.isSequenceTriggered) yt.DoSequenceEvent();

//do sequencing for drive thru boundaries
//if (yt.isEnteringDriveThru || yt.isExitingDriveThru) yt.DoDriveThruSequenceEvent();

//else //make sure youturn and sequence is off - we are not in normal turn here
//{
//    if (yt.isYouTurnTriggered | yt.isSequenceTriggered)
//    {
//        yt.ResetYouTurn();
//    }
//}
