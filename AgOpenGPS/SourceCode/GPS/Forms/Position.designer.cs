//Please, if you use this, share the improvements

using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public partial class FormGPS
    {
        //very first fix to setup grid etc
        public bool isFirstFixPositionSet = false, isGPSPositionInitialized = false;

        // autosteer variables for sending serial
        public Int16 guidanceLineDistanceOff, guidanceLineSteerAngle;

        //how far between new section triangle trigger
        public double triangleResolution = 1.0;

        //how many fix updates per sec
        public int fixUpdateHz = 5;
        public double fixUpdateTime = 0.2;

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
  
        //how far travelled since last section was added, section points
        double sectionTriggerDistance = 0, sectionTriggerStepDistance = 0; 
        public vec2 prevSectionPos = new vec2(0, 0);
        
        //step distances and positions for boundary, 4 meters before next point
        public double boundaryTriggerDistance = 4.0;
        public vec2 prevBoundaryPos = new vec2(0, 0);

        //are we still getting valid data from GPS, resets to 0 in NMEA OGI block, watchdog 
        public int recvCounter = 20;

        //Everything is so wonky at the start
        int startCounter = 0;

        //individual points for the flags in a list
        List<CFlag> flagPts = new List<CFlag>();

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
        double gyroDelta, gyroCorrection, gyroRaw, gyroCorrected;

        //step position - slow speed spinner killer
        private int totalFixSteps = 10, currentStepFix = 0;
        private vec3 vHold;
        public vec3[] stepFixPts = new vec3[60];
        public double distanceCurrentStepFix = 0, fixStepDist, minFixStepDist = 0;        
        bool isFixHolding = false, isFixHoldLoaded = false;

        //called by watchdog timer every 10 ms
        private bool ScanForNMEA()
        {
            //if saving a file ignore any movement
            if (isSavingFile) return false;

            //parse any data from pn.rawBuffer
            pn.ParseNMEA();

            //time for a frame update with new valid nmea data
            if (pn.updatedGGA | pn.updatedOGI | pn.updatedRMC)
            {

                //start the watch and time till it gets back here
                swFrame.Reset();
                swFrame.Start();

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
                if (isGPSPositionInitialized)
                {
                    return false;
                }
                else
                {
                    mc.ResetAllModuleCommValues();
                    recvCounter++;
                    return false;
                }
            }
        }

        public double eastingBeforeRoll;
        public double eastingAfterRoll;
        public double rollUsed;
        private double offset = 0;
        public double headlandDistanceDelta = 0, boundaryDistanceDelta = 0;

        private void UpdateFixPosition()
        {
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

            if ((ahrs.isRollBrick | ahrs.isRollDogs | ahrs.isRollPAOGI) && mc.rollRaw != 9999)
            {
                //for charting in GPS Data window
                eastingBeforeRoll = pn.fix.easting;
                rollUsed = (double)mc.rollRaw/16;

                //calculate how far the antenna moves based on sidehill roll
                double roll = Math.Sin(glm.toRadians((mc.rollRaw - ahrs.rollZero) * 0.0625));

                //change for roll to the right is positive times -1
                rollCorrectionDistance = roll * vehicle.antennaHeight * -1.0;

                // roll to left is positive  **** important!!
                // not any more - April 30, 2019 - roll to right is positive
                pn.fix.easting = (Math.Cos(-fixHeading) * rollCorrectionDistance) + pn.fix.easting;
                pn.fix.northing = (Math.Sin(-fixHeading) * rollCorrectionDistance) + pn.fix.northing;

                //for charting the position after roll adjustment
                eastingAfterRoll = pn.fix.easting;
            }
            else
            {
                eastingAfterRoll = pn.fix.easting;
                eastingBeforeRoll = pn.fix.easting;
            }

            //pitchDistance = (pitch * vehicle.antennaHeight);
            //pn.fix.easting = (Math.Sin(fixHeading) * pitchDistance) + pn.fix.easting;
            //pn.fix.northing = (Math.Cos(fixHeading) * pitchDistance) + pn.fix.northing;

            #endregion Roll

            #region Step Fix

            //**** heading of the vec3 structure is used for distance in Step fix!!!!!

            //grab the most current fix and save the distance from the last fix
            distanceCurrentStepFix = glm.Distance(pn.fix, stepFixPts[0]);
            if (vehicle.treeSpacing != 0 && section[0].isSectionOn) treeSpacingCounter += (distanceCurrentStepFix*100);
            
            //keep the distance below spacing
            while (treeSpacingCounter > vehicle.treeSpacing && vehicle.treeSpacing != 0) treeSpacingCounter -= vehicle.treeSpacing;            

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
                if (isLogNMEA)  { if (ct.isContourOn)  { pn.logNMEASentence.Append(recvSentenceSettings); } }

                //To prevent drawing high numbers of triangles, determine and test before drawing vertex
                sectionTriggerDistance = glm.Distance(pn.fix, prevSectionPos);

                //section on off and points, contour points
                if (sectionTriggerDistance > sectionTriggerStepDistance && isJobStarted)
                {
                    AddSectionContourPathPoints();
                }

                //test if travelled far enough for new boundary point
                double boundaryDistance = glm.Distance(pn.fix, prevBoundaryPos);
                if (boundaryDistance > boundaryTriggerDistance) AddBoundaryAndPerimiterPoint();

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

            //if self driving, do the update
            if (self.isSelfDriving) self.UpdatePosition();

            // If Drive button enabled be normal, or just fool the autosteer and fill values
            if (!ast.isInFreeDriveMode)
            {
                if (ahrs.isHeadingPAOGI)
                {
                    guidanceLineSteerAngle = (Int16)(guidanceLineSteerAngle + (pn.nRoll * ((double)mc.autoSteerSettings[mc.ssKd]) * 4.166666));
                }

                //fill up0 the appropriate arrays with new values
                mc.autoSteerData[mc.sdSpeed] = (byte)(pn.speed * 4.0);
                mc.machineControlData[mc.cnSpeed] = mc.autoSteerData[mc.sdSpeed];

                mc.autoSteerData[mc.sdDistanceHi] = (byte)(guidanceLineDistanceOff >> 8);
                mc.autoSteerData[mc.sdDistanceLo] = (byte)guidanceLineDistanceOff;

                mc.autoSteerData[mc.sdSteerAngleHi] = (byte)(guidanceLineSteerAngle >> 8);
                mc.autoSteerData[mc.sdSteerAngleLo] = (byte)guidanceLineSteerAngle;

                //out serial to autosteer module  //indivdual classes load the distance and heading deltas 
                AutoSteerDataOutToPort();
            }

            else
            {
                //fill up the auto steer array with free drive values
                mc.autoSteerData[mc.sdSpeed] = (byte)(pn.speed * 4.0 + 8);
                mc.machineControlData[mc.cnSpeed] = mc.autoSteerData[mc.sdSpeed];

                //make steer module think everything is normal
                mc.autoSteerData[mc.sdDistanceHi] = (byte)(0);
                mc.autoSteerData[mc.sdDistanceLo] = (byte)0;

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

            #region DualRatecontrol
            //do the relayRateControl
            if (rcd.isRateControlOn)
            {
                if (rcd.isSingleFlowMeter)
                {
                    rcd.CalculateRateLitersPerMinuteSingle();
                    mc.relayRateData[mc.rdRateSetPointLeftHi] = (byte)((Int16)(rcd.rateSetPointLeft * 100.0) >> 8);
                    mc.relayRateData[mc.rdRateSetPointLeftLo] = (byte)(rcd.rateSetPointLeft * 100.0);

                    mc.relayRateData[mc.rdRateSetPointRightHi] = 0;
                    mc.relayRateData[mc.rdRateSetPointRightLo] = 0;

                    mc.relayRateData[mc.rdSpeedXFour] = (byte)(pn.speed * 4.0);
                    //relay byte is built in SerialComm function BuildRelayByte()
                    //youturn control byte is built in SerialComm BuildYouTurnByte()

                }
                else
                {
                    rcd.CalculateRateLitersPerMinuteDual();
                    mc.relayRateData[mc.rdRateSetPointLeftHi] = (byte)((Int16)(rcd.rateSetPointLeft * 100.0) >> 8);
                    mc.relayRateData[mc.rdRateSetPointLeftLo] = (byte)(rcd.rateSetPointLeft * 100.0);

                    mc.relayRateData[mc.rdRateSetPointRightHi] = (byte)((Int16)(rcd.rateSetPointRight * 100.0) >> 8);
                    mc.relayRateData[mc.rdRateSetPointRightLo] = (byte)(rcd.rateSetPointRight * 100.0);

                    mc.relayRateData[mc.rdSpeedXFour] = (byte)(pn.speed * 4.0);
                    //relay byte is built in SerialComm function BuildRelayByte()
                    //youturn control byte is built in SerialComm BuildYouTurnByte()
                }

                //send out the port
                RateRelayOutToPort(mc.relayRateData, CModuleComm.numRelayRateDataItems);

                //if the relay rate port is open, check switches
                //if (spRelay.IsOpen) DoRemoteSectionSwitch();
                if ((spRelay.IsOpen) | (isUDPSendConnected)) DoRemoteSectionSwitch();
            }
            else
            {
                mc.relayRateData[mc.rdRateSetPointLeftHi] = (byte)0;
                mc.relayRateData[mc.rdRateSetPointLeftHi] = (byte)0;
                mc.relayRateData[mc.rdRateSetPointRightHi] = (byte)0;
                mc.relayRateData[mc.rdRateSetPointRightHi] = (byte)0;
                mc.relayRateData[mc.rdSpeedXFour] = (byte)(pn.speed * 4.0);
                //relay byte is built in SerialComm.cs - function BuildRelayByte()
                //youturn control byte is built in SerialComm BuildYouTurnByte()
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
            if (bnd.bndArr[0].isSet)
            {
                //Are we inside outer and outside inner all turn boundaries, no turn creation problems
                if (IsInWorkingArea() && !yt.isTurnCreationTooClose && !yt.isTurnCreationNotCrossingError)
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

                                //if we are close enough to pattern, trigger.
                                if ((distancePivotToTurnLine <= 2.0) && (distancePivotToTurnLine >= 0) && !yt.isYouTurnTriggered)
                                    yt.YouTurnTrigger();
                            }

                            ////Turn is triggered - this is not run if shape is drawn
                            //if (yt.isYouTurnTriggered && yt.isYouTurnBtnOn)
                            //{
                            //    //if we are too much off track - 10 degrees 1500 mm, pointing wrong way, kill the turn
                            //    //if ((Math.Abs(guidanceLineSteerAngle) > 1000) && (Math.Abs(guidanceLineDistanceOff) > 1500))
                            //    //{
                            //    //    yt.ResetYouTurn();
                            //    //}
                            //    //else
                            //    //{
                            //    //    //keep from running this again since youturn is plotted now
                            //    //    yt.isYouTurnTriggerPointSet = false;
                            //    //    yt.isLastYouTurnRight = yt.isYouTurnRight;
                            //    //    yt.isYouTurnInProgress = true;
                            //    //}
                            //}
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
        }


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
                    int camStep = currentStepFix*4;
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

            //make sure there is a gyro otherwise 9999 are sent from autosteer
            if ((ahrs.isHeadingBrick | ahrs.isHeadingBNO | ahrs.isHeadingPAOGI) && mc.gyroHeading != 9999)
            {
                //current gyro angle in radians
                gyroRaw = (glm.toRadians((double)mc.prevGyroHeading * 0.0625));

                //Difference between the IMU heading and the GPS heading
                gyroDelta = (gyroRaw + gyroCorrection) - gpsHeading;
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
                gyroCorrected = gyroRaw + gyroCorrection;
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
            hitchPos.easting = pn.fix.easting + (Math.Sin(fixHeading) * (vehicle.hitchLength - vehicle.antennaPivot));
            hitchPos.northing = pn.fix.northing + (Math.Cos(fixHeading) * (vehicle.hitchLength - vehicle.antennaPivot));

            //tool attached via a trailing hitch
            if (vehicle.isToolTrailing)
            {
                double over;
                if (vehicle.tankTrailingHitchLength < -2.0)
                {
                    //Torriem rules!!!!! Oh yes, this is all his. Thank-you
                    if (distanceCurrentStepFix != 0)
                    {
                        double t = (vehicle.tankTrailingHitchLength) / distanceCurrentStepFix;
                        tankPos.easting = hitchPos.easting + t * (hitchPos.easting - tankPos.easting);
                        tankPos.northing = hitchPos.northing + t * (hitchPos.northing - tankPos.northing);
                        tankPos.heading = Math.Atan2(hitchPos.easting - tankPos.easting, hitchPos.northing - tankPos.northing);
                    }

                    ////the tool is seriously jacknifed or just starting out so just spring it back.
                    over = Math.Abs(Math.PI - Math.Abs(Math.Abs(tankPos.heading - fixHeading) - Math.PI));

                    if (over < 2.0 && startCounter > 50)
                    {
                        tankPos.easting = hitchPos.easting + (Math.Sin(tankPos.heading) * (vehicle.tankTrailingHitchLength));
                        tankPos.northing = hitchPos.northing + (Math.Cos(tankPos.heading) * (vehicle.tankTrailingHitchLength));
                    }

                    //criteria for a forced reset to put tool directly behind vehicle
                    if (over > 2.0 | startCounter < 51)
                    {
                        tankPos.heading = fixHeading;
                        tankPos.easting = hitchPos.easting + (Math.Sin(tankPos.heading) * (vehicle.tankTrailingHitchLength));
                        tankPos.northing = hitchPos.northing + (Math.Cos(tankPos.heading) * (vehicle.tankTrailingHitchLength));
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
                    double t = (vehicle.toolTrailingHitchLength) / distanceCurrentStepFix;
                    toolPos.easting = tankPos.easting + t * (tankPos.easting - toolPos.easting);
                    toolPos.northing = tankPos.northing + t * (tankPos.northing - toolPos.northing);
                    toolPos.heading = Math.Atan2(tankPos.easting - toolPos.easting, tankPos.northing - toolPos.northing);
                }

                ////the tool is seriously jacknifed or just starting out so just spring it back.
                over = Math.Abs(Math.PI - Math.Abs(Math.Abs(toolPos.heading - tankPos.heading) - Math.PI));

                if (over < 1.9 && startCounter > 50)
                {
                    toolPos.easting = tankPos.easting + (Math.Sin(toolPos.heading) * (vehicle.toolTrailingHitchLength));
                    toolPos.northing = tankPos.northing + (Math.Cos(toolPos.heading) * (vehicle.toolTrailingHitchLength));
                }

                //criteria for a forced reset to put tool directly behind vehicle
                if (over > 1.9 | startCounter < 51)
                {
                    toolPos.heading = tankPos.heading;
                    toolPos.easting = tankPos.easting + (Math.Sin(toolPos.heading) * (vehicle.toolTrailingHitchLength));
                    toolPos.northing = tankPos.northing + (Math.Cos(toolPos.heading) * (vehicle.toolTrailingHitchLength));
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
            double metersPerSec = pn.speed * 0.277777777;

            //whichever is less
            if (vehicle.toolFarLeftSpeed < vehicle.toolFarRightSpeed)
                sectionTriggerStepDistance = vehicle.toolFarLeftSpeed / metersPerSec;
            else sectionTriggerStepDistance = vehicle.toolFarRightSpeed / metersPerSec;

            //finally determine distance
            if (!curve.isOkToAddPoints) sectionTriggerStepDistance = sectionTriggerStepDistance * sectionTriggerStepDistance *
                metersPerSec * triangleResolution * 2.0 + 1.0;
            else sectionTriggerStepDistance = 1.0;

            //check to make sure the grid is big enough
            worldGrid.checkZoomWorldGrid(pn.fix.northing, pn.fix.easting);

            //precalc the sin and cos of heading * -1
            sinSectionHeading = Math.Sin(-toolPos.heading);
            cosSectionHeading = Math.Cos(-toolPos.heading);
        }

        //perimeter and boundary point generation
        private void AddBoundaryAndPerimiterPoint()
        {
            //save the north & east as previous
            prevBoundaryPos.easting = pn.fix.easting;
            prevBoundaryPos.northing = pn.fix.northing;

            //build the boundary line
            
                bool isInner = false;
                for (int i = 0; i < MAXBOUNDARIES; i++) isInner |= bnd.bndArr[i].isOkToAddPoints;

            if (isInner)
            {
                if (bnd.bndArr[bnd.boundarySelected].isDrawRightSide)
                {
                    //Right side
                    CBndPt point = new CBndPt(cosSectionHeading * (section[vehicle.numOfSections - 1].positionRight) + toolPos.easting,
                        sinSectionHeading * (section[vehicle.numOfSections - 1].positionRight) + toolPos.northing, toolPos.heading);
                    bnd.bndArr[bnd.boundarySelected].bndLine.Add(point);
                }

                //draw on left side
                else
                {
                    //Right side
                    CBndPt point = new CBndPt(cosSectionHeading * (section[0].positionLeft) + toolPos.easting,
                        sinSectionHeading * (section[0].positionLeft) + toolPos.northing, toolPos.heading);
                    bnd.bndArr[bnd.boundarySelected].bndLine.Add(point);
                }
            }
            

            //build the polygon to calculate area
            if (periArea.isBtnPerimeterOn)
            {
                if (isAreaOnRight)
                {
                    //Right side
                    vec2 point = new vec2(cosSectionHeading * (section[vehicle.numOfSections - 1].positionRight) + toolPos.easting,
                        sinSectionHeading * (section[vehicle.numOfSections - 1].positionRight) + toolPos.northing);
                    periArea.periPtList.Add(point);
                }

                    //draw on left side
                else
                {
                    //Right side
                    vec2 point = new vec2(cosSectionHeading * (section[0].positionLeft) + toolPos.easting,
                        sinSectionHeading * (section[0].positionLeft) + toolPos.northing);
                    periArea.periPtList.Add(point);
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
            for (int j = 0; j < vehicle.numOfSections + 1; j++)
            {
                if (section[j].isSectionOn)
                {
                    section[j].AddPathPoint(toolPos.northing, toolPos.easting, cosSectionHeading, sinSectionHeading);
                    sectionCounter++;
                }
            }
            if ((ABLine.isBtnABLineOn && !ct.isContourBtnOn && ABLine.isABLineSet && isAutoSteerBtnOn) || 
                        (!ct.isContourBtnOn && curve.isCurveBtnOn && curve.isCurveSet && isAutoSteerBtnOn))
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
            for (int j = 0; j < vehicle.numOfSections; j++)
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
                    leftLook = leftSpeed * vehicle.toolLookAhead;

                    //save the far left speed
                    vehicle.toolFarLeftSpeed = leftSpeed;
                }
                else
                {
                    //right point from last section becomes this left one
                    section[j].leftPoint = section[j-1].rightPoint;
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
                rightLook = rightSpeed * vehicle.toolLookAhead;

                //Is section outer going forward or backward
                double head = left.HeadingXZ();
                if (Math.PI - Math.Abs(Math.Abs(head - toolPos.heading) - Math.PI) > glm.PIBy2) leftLook *= -1;

                head = right.HeadingXZ();
                if (Math.PI - Math.Abs(Math.Abs(head - toolPos.heading) - Math.PI) > glm.PIBy2) rightLook *= -1;

                //choose fastest speed
                if (leftLook > rightLook)  section[j].sectionLookAhead = leftLook;
                else section[j].sectionLookAhead = rightLook;

                if (section[j].sectionLookAhead > 190) section[j].sectionLookAhead = 190;

                //Doing the slow mo, exceeding buffer so just set as minimum 0.5 meter
                if (currentStepFix >= totalFixSteps - 1) section[j].sectionLookAhead = 5;
            }//endfor

            //set up the super for youturn
            section[vehicle.numOfSections].isInsideBoundary = true;

            //determine if section is in boundary using the section left/right positions
            bool isLeftIn = true, isRightIn = true;
            for (int j = 0; j < vehicle.numOfSections; j++)
            {
                if (bnd.bndArr[0].isSet)
                {
                    if (j == 0)
                    {
                        //only one first left point, the rest are all rights moved over to left
                        isLeftIn = bnd.bndArr[0].IsPointInsideBoundary(section[j].leftPoint);
                        isRightIn = bnd.bndArr[0].IsPointInsideBoundary(section[j].rightPoint);

                        for (int i = 1; i < MAXBOUNDARIES; i++)
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
                        for (int i = 1; i < MAXBOUNDARIES; i++)
                        {
                            //inner boundaries should normally NOT have point inside
                            if (bnd.bndArr[i].isSet) isRightIn &= !bnd.bndArr[i].IsPointInsideBoundary(section[j].rightPoint);
                        }

                        if (isLeftIn && isRightIn) section[j].isInsideBoundary = true;
                        else section[j].isInsideBoundary = false;
                    }
                    section[vehicle.numOfSections].isInsideBoundary &= section[j].isInsideBoundary;
                }

                //no boundary created so always inside
                else
                {
                    section[j].isInsideBoundary = true;
                    section[vehicle.numOfSections].isInsideBoundary = false;
                }
            }

            //with left and right tool velocity to determine rate of triangle generation, corners are more
            //save far right speed, 0 if going backwards, in meters/sec
            if (section[vehicle.numOfSections - 1].sectionLookAhead > 0) vehicle.toolFarRightSpeed = rightSpeed * 0.05;
            else vehicle.toolFarRightSpeed = 0;

            //save left side, 0 if going backwards, in meters/sec convert back from pixels/m
            if (section[0].sectionLookAhead > 0) vehicle.toolFarLeftSpeed = vehicle.toolFarLeftSpeed * 0.05;
            else vehicle.toolFarLeftSpeed = 0;                
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
                lblConvergenceAngle.Text = Math.Round(glm.toDegrees(pn.convergenceAngle), 3).ToString();

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
                if (startCounter > (totalFixSteps/2)) isGPSPositionInitialized = true;

                //in radians
                fixHeading = Math.Atan2(pn.fix.easting - stepFixPts[totalFixSteps - 1].easting, pn.fix.northing - stepFixPts[totalFixSteps - 1].northing);
                if (fixHeading < 0) fixHeading += glm.twoPI;
                toolPos.heading = fixHeading;

                //send out initial zero settings
                if (isGPSPositionInitialized) AutoSteerSettingsOutToPort();
                return;
            }
        }

        public bool IsInWorkingArea()
        {
            //first where are we, must be inside outer and outside of inner geofence non drive thru turn borders
            if (gf.geoFenceArr[0].IsPointInGeoFenceArea(pivotAxlePos))
            {
                for (int i = 1; i < MAXBOUNDARIES; i++)
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

        //Matthias's Switch routine
        //MTZ8302 April 2018
        private void DoRemoteSectionSwitch()
        {
            //Byte RateNumClicks = 0;
            float RateCalcFactor = 1.10F;

            //MainSW or RateSW was used
            if (rcd.SectMainSWFromArduino != rcd.SectMainSWFromArduinoOld)
            {    //Rate SW                
                 //witch Rate left/right? left = 0
                if ((rcd.SectMainSWFromArduino & 16) == 16) { rcd.RateStepsLeft = false; } else { rcd.RateStepsLeft = true; }
                //Rate direction 1 = up
                if ((rcd.SectMainSWFromArduino & 32) == 32) { rcd.RateUp = true; } else { rcd.RateUp = false; }

                //Rate SW Bit[2+3] = 3 steps
                rcd.RateStepsFromArudino = 0;
                if ((rcd.SectMainSWFromArduino & 4) == 4) { rcd.RateStepsFromArudino = 1; }
                if ((rcd.SectMainSWFromArduino & 8) == 8) { rcd.RateStepsFromArudino = rcd.RateStepsFromArudino + 2; }
                if ((rcd.RateStepsFromArudino > rcd.RateStepsFromArduinoOld) && ((rcd.RateStepsLeft != rcd.RateStepsLeftOld) | (rcd.RateUp != rcd.RateUpOld)))
                {   //same side/direction then reduce by last value to prevent to much effect
                    int Val = 0;
                    Val = rcd.RateStepsFromArudino; // Bak Value
                    rcd.RateStepsFromArudino = rcd.RateStepsFromArudino - rcd.RateStepsFromArduinoOld;
                    rcd.RateStepsFromArduinoOld = Val;
                }
                else rcd.RateStepsFromArduinoOld = rcd.RateStepsFromArudino;

                rcd.RateStepsLeftOld = rcd.RateStepsLeft;
                rcd.RateUpOld = rcd.RateUp;

                //change Rate
                if (rcd.isRateControlOn && (rcd.RateStepsFromArudino > 0))
                {
                    float RateChangeFaktor = 1f;
                    double rateOld = 0f;
                    for (byte a = 1; a <= rcd.RateStepsFromArudino; a++)
                    {
                        RateChangeFaktor = RateChangeFaktor * RateCalcFactor;
                    }

                    //witch rate to change
                    if (rcd.RateUp && rcd.RateStepsLeft)
                    {
                        rateOld = rcd.rateLeft;
                        rcd.rateLeft = Math.Round((rcd.rateLeft * RateChangeFaktor), 0);
                    }
                    if (!rcd.RateUp && rcd.RateStepsLeft)
                    {
                        rateOld = rcd.rateLeft;
                        rcd.rateLeft = Math.Round((rcd.rateLeft / RateChangeFaktor), 0);
                    }
                    if (rcd.RateUp && !rcd.RateStepsLeft)
                    {
                        rateOld = rcd.rateRight;
                        rcd.rateRight = Math.Round((rcd.rateRight * RateChangeFaktor), 0);
                    }
                    if (!rcd.RateUp && !rcd.RateStepsLeft)
                    {
                        rateOld = rcd.rateRight;
                        rcd.rateRight = Math.Round((rcd.rateRight / RateChangeFaktor), 0);
                    }

                    //display new value 
                    if (rcd.RateStepsLeft)
                    {  //left
                        if (isMetric)
                        {
                            if (rcd.rateLeft < 2.0) rcd.rateLeft = 2.0;
                            lblRateSetpointLeft.Text = rcd.rateLeft.ToString("N1");
                            string str1 = (rcd.rateLeft).ToString("N1") + " new Rate left";
                            string str2 = "before: " + (rateOld).ToString("N1");
                            TimedMessageBox(1500, str1, str2);
                        }
                        else
                        {
                            if (rcd.rateLeft < 2.0) rcd.rateLeft = 2.0;
                            lblRateSetpointLeft.Text = (rcd.rateLeft * glm.LHa2galAc).ToString("N1");
                            string str1 = (rcd.rateLeft * glm.LHa2galAc).ToString("N1") + " new Rate left";
                            string str2 = "before: " + (rateOld * glm.LHa2galAc).ToString("N1");
                            TimedMessageBox(1500, str1, str2);
                        }
                    }
                    else //right
                    {
                        if (isMetric)
                        {
                            if (rcd.rateLeft < 2.0) rcd.rateLeft = 2.0;
                            lblRateSetpointLeft.Text = rcd.rateLeft.ToString("N1");
                            string str1 = (rcd.rateLeft).ToString("N1") + " new Rate left";
                            string str2 = "before: " + (rateOld).ToString("N1");
                            TimedMessageBox(1500, str1, str2);
                        }
                        else
                        {
                            if (rcd.rateLeft < 2.0) rcd.rateLeft = 2.0;
                            lblRateSetpointLeft.Text = (rcd.rateLeft * glm.LHa2galAc).ToString("N1");
                            string str1 = (rcd.rateLeft * glm.LHa2galAc).ToString("N1") + " new Rate left";
                            string str2 = "before: " + (rateOld * glm.LHa2galAc).ToString("N1");
                            TimedMessageBox(1500, str1, str2);
                        }
                    }
                }

                //Main SW pressed
                if ((rcd.SectMainSWFromArduino & 1) == 1)
                {
                    //set butto off and then press it = ON
                    autoBtnState = btnStates.Off;
                    btnSectionOffAutoOn.PerformClick();
                } // if Main SW ON

                //if Main SW in Arduino is pressed OFF
                if ((rcd.SectMainSWFromArduino & 2) == 2)
                {
                    //set button on and then press it = OFF
                    autoBtnState = btnStates.Auto;
                    btnSectionOffAutoOn.PerformClick();
                } // if Main SW OFF

                rcd.SectMainSWFromArduinoOld = rcd.SectMainSWFromArduino;
            }  //Main or Rate SW


            if (rcd.RelayFromArduinoLo != 0)
            {
                // ON Signal from Arduino 
                if ((rcd.RelayFromArduinoLo & 128) == 128 & vehicle.numOfSections > 7)
                {
                    if (section[7].manBtnState != manBtn.Auto) section[7].manBtnState = manBtn.Auto;
                    btnSection8Man.PerformClick();
                }
                if ((rcd.RelayFromArduinoLo & 64) == 64 & vehicle.numOfSections > 6)
                {
                    if (section[6].manBtnState != manBtn.Auto) section[6].manBtnState = manBtn.Auto;
                    btnSection7Man.PerformClick();
                }
                if ((rcd.RelayFromArduinoLo & 32) == 32 & vehicle.numOfSections > 5)
                {
                    if (section[5].manBtnState != manBtn.Auto) section[5].manBtnState = manBtn.Auto;
                    btnSection6Man.PerformClick();
                }
                if ((rcd.RelayFromArduinoLo & 16) == 16 & vehicle.numOfSections > 4)
                {
                    if (section[4].manBtnState != manBtn.Auto) section[4].manBtnState = manBtn.Auto;
                    btnSection5Man.PerformClick();
                }
                if ((rcd.RelayFromArduinoLo & 8) == 8 & vehicle.numOfSections > 3)
                {
                    if (section[3].manBtnState != manBtn.Auto) section[3].manBtnState = manBtn.Auto;
                    btnSection4Man.PerformClick();
                }
                if ((rcd.RelayFromArduinoLo & 4) == 4 & vehicle.numOfSections > 2)
                {
                    if (section[2].manBtnState != manBtn.Auto) section[2].manBtnState = manBtn.Auto;
                    btnSection3Man.PerformClick();
                }
                if ((rcd.RelayFromArduinoLo & 2) == 2 & vehicle.numOfSections > 1)
                {
                    if (section[1].manBtnState != manBtn.Auto) section[1].manBtnState = manBtn.Auto;
                    btnSection2Man.PerformClick();
                }
                if ((rcd.RelayFromArduinoLo & 1) == 1)
                {
                    if (section[0].manBtnState != manBtn.Auto) section[0].manBtnState = manBtn.Auto;
                    btnSection1Man.PerformClick();
                }
                rcd.RelayFromArduinoOldLo = rcd.RelayFromArduinoLo;
            } //if RelayFromArduinoLo != 0 

            if (rcd.RelayFromArduinoHi != 0)
            {
                // sections ON signal from Arduino  
                /* 16sections
                                   if ((rcd.RelayFromArduinoHi & 128) == 128 & vehicle.numOfSections > 15)
                                    {
                                        if (section[15].manBtnState != manBtn.Auto) section[15].manBtnState = manBtn.Auto;
                                        btnSection16Man.PerformClick();
                                    }
                                    if ((rcd.RelayFromArduinoHi & 64) == 64 & vehicle.numOfSections > 14)
                                    {
                                        if (section[14].manBtnState != manBtn.Auto) section[14].manBtnState = manBtn.Auto;
                                        btnSection15Man.PerformClick();
                                    }
                                    if ((rcd.RelayFromArduinoHi & 32) == 32 & vehicle.numOfSections > 13)
                                    {
                                        if (section[13].manBtnState != manBtn.Auto) section[13].manBtnState = manBtn.Auto;
                                        btnSection14Man.PerformClick();
                                    }
                                    if ((rcd.RelayFromArduinoHi & 16) == 16 & vehicle.numOfSections > 12)
                                    {
                                        if (section[12].manBtnState != manBtn.Auto) section[12].manBtnState = manBtn.Auto;
                                        btnSection13Man.PerformClick();
                                    }
                */
                if ((rcd.RelayFromArduinoHi & 8) == 8 & vehicle.numOfSections > 11)
                {
                    if (section[11].manBtnState != manBtn.Auto) section[11].manBtnState = manBtn.Auto;
                    btnSection12Man.PerformClick();
                }
                if ((rcd.RelayFromArduinoHi & 4) == 4 & vehicle.numOfSections > 10)
                {
                    if (section[10].manBtnState != manBtn.Auto) section[10].manBtnState = manBtn.Auto;
                    btnSection11Man.PerformClick();
                }
                if ((rcd.RelayFromArduinoHi & 2) == 2 & vehicle.numOfSections > 9)
                {
                    if (section[9].manBtnState != manBtn.Auto) section[9].manBtnState = manBtn.Auto;
                    btnSection10Man.PerformClick();
                }
                if ((rcd.RelayFromArduinoHi & 1) == 1 & vehicle.numOfSections > 8)
                {
                    if (section[8].manBtnState != manBtn.Auto) section[8].manBtnState = manBtn.Auto;
                    btnSection9Man.PerformClick();
                }
                rcd.RelayFromArduinoOldHi = rcd.RelayFromArduinoHi;
            } //if RelayFromArduinoHi != 0                 


            // Switches have changed
            if (rcd.SectSWOffFromArduinoLo != rcd.SectSWOffFromArduinoOldLo)
            {
                //if Main = Auto then change section to Auto if Off signal from Arduino stopped
                if (autoBtnState == btnStates.Auto)
                {
                    if (((rcd.SectSWOffFromArduinoOldLo & 128) == 128) & ((rcd.SectSWOffFromArduinoLo & 128) != 128) & (section[7].manBtnState == manBtn.Off))
                    {
                        btnSection8Man.PerformClick();
                    }
                    if (((rcd.SectSWOffFromArduinoOldLo & 64) == 64) & ((rcd.SectSWOffFromArduinoLo & 64) != 64) & (section[6].manBtnState == manBtn.Off))
                    {
                        btnSection7Man.PerformClick();
                    }
                    if (((rcd.SectSWOffFromArduinoOldLo & 32) == 32) & ((rcd.SectSWOffFromArduinoLo & 32) != 32) & (section[5].manBtnState == manBtn.Off))
                    {
                        btnSection6Man.PerformClick();
                    }
                    if (((rcd.SectSWOffFromArduinoOldLo & 16) == 16) & ((rcd.SectSWOffFromArduinoLo & 16) != 16) & (section[4].manBtnState == manBtn.Off))
                    {
                        btnSection5Man.PerformClick();
                    }
                    if (((rcd.SectSWOffFromArduinoOldLo & 8) == 8) & ((rcd.SectSWOffFromArduinoLo & 8) != 8) & (section[3].manBtnState == manBtn.Off))
                    {
                        btnSection4Man.PerformClick();
                    }
                    if (((rcd.SectSWOffFromArduinoOldLo & 4) == 4) & ((rcd.SectSWOffFromArduinoLo & 4) != 4) & (section[2].manBtnState == manBtn.Off))
                    {
                        btnSection3Man.PerformClick();
                    }
                    if (((rcd.SectSWOffFromArduinoOldLo & 2) == 2) & ((rcd.SectSWOffFromArduinoLo & 2) != 2) & (section[1].manBtnState == manBtn.Off))
                    {
                        btnSection2Man.PerformClick();
                    }
                    if (((rcd.SectSWOffFromArduinoOldLo & 1) == 1) & ((rcd.SectSWOffFromArduinoLo & 1) != 1) & (section[0].manBtnState == manBtn.Off))
                    {
                        btnSection1Man.PerformClick();
                    }
                }
                rcd.SectSWOffFromArduinoOldLo = rcd.SectSWOffFromArduinoLo;
            }
            if (rcd.SectSWOffFromArduinoHi != rcd.SectSWOffFromArduinoOldHi)
            {
                //if Main = Auto then change section to Auto if Off signal from Arduino stopped
                if (autoBtnState == btnStates.Auto)
                {
                    /* 16 sections                   if (((rcd.SectSWOffFromArduinoOldHi & 128) == 128) & ((rcd.SectSWOffFromArduinoHi & 128) != 128) & (section[15].manBtnState == manBtn.Off))
                                       { btnSection16Man.PerformClick(); }
                                       if (((rcd.SectSWOffFromArduinoOldHi & 64) == 64) & ((rcd.SectSWOffFromArduinoHi & 64) != 64) & (section[14].manBtnState == manBtn.Off))
                                       { btnSection15Man.PerformClick(); }
                                       if (((rcd.SectSWOffFromArduinoOldHi & 32) == 32) & ((rcd.SectSWOffFromArduinoHi & 32) != 32) & (section[13].manBtnState == manBtn.Off))
                                       { btnSection14Man.PerformClick(); }
                                       if (((rcd.SectSWOffFromArduinoOldHi & 16) == 16) & ((rcd.SectSWOffFromArduinoHi & 16) != 16) & (section[12].manBtnState == manBtn.Off))
                                       { btnSection13Man.PerformClick(); }
                                */

                    if (((rcd.SectSWOffFromArduinoOldHi & 8) == 8) & ((rcd.SectSWOffFromArduinoHi & 8) != 8) & (section[11].manBtnState == manBtn.Off))
                    {
                        btnSection12Man.PerformClick();
                    }
                    if (((rcd.SectSWOffFromArduinoOldHi & 4) == 4) & ((rcd.SectSWOffFromArduinoHi & 4) != 4) & (section[10].manBtnState == manBtn.Off))
                    {
                        btnSection11Man.PerformClick();
                    }
                    if (((rcd.SectSWOffFromArduinoOldHi & 2) == 2) & ((rcd.SectSWOffFromArduinoHi & 2) != 2) & (section[9].manBtnState == manBtn.Off))
                    {
                        btnSection10Man.PerformClick();
                    }
                    if (((rcd.SectSWOffFromArduinoOldHi & 1) == 1) & ((rcd.SectSWOffFromArduinoHi & 1) != 1) & (section[8].manBtnState == manBtn.Off))
                    {
                        btnSection9Man.PerformClick();
                    }
                }
                rcd.SectSWOffFromArduinoOldHi = rcd.SectSWOffFromArduinoHi;
            }

            // OFF Signal from Arduino
            if (rcd.SectSWOffFromArduinoLo != 0)
            {
                //if section SW in Arduino is switched to OFF; check always, if switch is locked to off GUI should not change
                if ((rcd.SectSWOffFromArduinoLo & 128) == 128 & section[7].manBtnState != manBtn.Off)
                {
                    section[7].manBtnState = manBtn.On;
                    btnSection8Man.PerformClick();
                }
                if ((rcd.SectSWOffFromArduinoLo & 64) == 64 & section[6].manBtnState != manBtn.Off)
                {
                    section[6].manBtnState = manBtn.On;
                    btnSection7Man.PerformClick();
                }
                if ((rcd.SectSWOffFromArduinoLo & 32) == 32 & section[5].manBtnState != manBtn.Off)
                {
                    section[5].manBtnState = manBtn.On;
                    btnSection6Man.PerformClick();
                }
                if ((rcd.SectSWOffFromArduinoLo & 16) == 16 & section[4].manBtnState != manBtn.Off)
                {
                    section[4].manBtnState = manBtn.On;
                    btnSection5Man.PerformClick();
                }
                if ((rcd.SectSWOffFromArduinoLo & 8) == 8 & section[3].manBtnState != manBtn.Off)
                {
                    section[3].manBtnState = manBtn.On;
                    btnSection4Man.PerformClick();
                }
                if ((rcd.SectSWOffFromArduinoLo & 4) == 4 & section[2].manBtnState != manBtn.Off)
                {
                    section[2].manBtnState = manBtn.On;
                    btnSection3Man.PerformClick();
                }
                if ((rcd.SectSWOffFromArduinoLo & 2) == 2 & section[1].manBtnState != manBtn.Off)
                {
                    section[1].manBtnState = manBtn.On;
                    btnSection2Man.PerformClick();
                }
                if ((rcd.SectSWOffFromArduinoLo & 1) == 1 & section[0].manBtnState != manBtn.Off)
                {
                    section[0].manBtnState = manBtn.On;
                    btnSection1Man.PerformClick();
                }
            } // if SectsSWOffFromArduinoLo !=0
            if (rcd.SectSWOffFromArduinoHi != 0)
            {
                //if section SW in Arduino is switched to OFF; check always, if switch is locked to off GUI should not change
                /* 16 sections                   if ((rcd.SectSWOffFromArduinoHi & 128) == 128 & section[15].manBtnState != manBtn.Off)
                                   {
                                       section[15].manBtnState = manBtn.On;
                                       btnSection16Man.PerformClick();
                                   }
                                   if ((rcd.SectSWOffFromArduinoHi & 64) == 64 & section[14].manBtnState != manBtn.Off)
                                   {
                                       section[14].manBtnState = manBtn.On;
                                       btnSection15Man.PerformClick();
                                   }
                                   if ((rcd.SectSWOffFromArduinoHi & 32) == 32 & section[13].manBtnState != manBtn.Off)
                                   {
                                       section[13].manBtnState = manBtn.On;
                                       btnSection14Man.PerformClick();
                                   }
                                   if ((rcd.SectSWOffFromArduinoHi & 16) == 16 & section[12].manBtnState != manBtn.Off)
                                   {
                                       section[12].manBtnState = manBtn.On;
                                       btnSection13Man.PerformClick();
                                   }
               */
                if ((rcd.SectSWOffFromArduinoHi & 8) == 8 & section[11].manBtnState != manBtn.Off)
                {
                    section[11].manBtnState = manBtn.On;
                    btnSection12Man.PerformClick();
                }
                if ((rcd.SectSWOffFromArduinoHi & 4) == 4 & section[10].manBtnState != manBtn.Off)
                {
                    section[10].manBtnState = manBtn.On;
                    btnSection11Man.PerformClick();
                }
                if ((rcd.SectSWOffFromArduinoHi & 2) == 2 & section[9].manBtnState != manBtn.Off)
                {
                    section[9].manBtnState = manBtn.On;
                    btnSection10Man.PerformClick();
                }
                if ((rcd.SectSWOffFromArduinoHi & 1) == 1 & section[8].manBtnState != manBtn.Off)
                {
                    section[8].manBtnState = manBtn.On;
                    btnSection9Man.PerformClick();
                }
            } // if SectsSWOffFromArduinoLo !=0
              // end adds by MTZ8302------------------------------------------------------------------------------------
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
//        headlandDistanceDelta *= vehicle.toolWidth;
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
