//Please, if you use this, share the improvements

using System.IO.Ports;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SharpGL;
using System.Drawing;
using System.Text;
using System.Diagnostics;

namespace AgOpenGPS
{
    public partial class FormGPS
    {
        public  double toLatitude;
        public  double toLongitude;

        //very first fix to setup grid etc
        public bool isFirstFixPositionSet = false, isGPSPositionInitialized = false;

        // autosteer variables for sending serial
        public Int16 guidanceLineDistanceOff, guidanceLineHeadingDelta;

        //how many fix updates per sec
        public int fixUpdateHz = 5;
        public double fixUpdateTime = 0.2;

        //for heading or Atan2 as camera
        public bool isAtanCam = true;

        //Current fix positions
        public double prevNorthing, prevEasting;
        public double fixPosX = 0.0, fixPosY = 0.0, fixPosZ = -7.0;
        public double pivotAxleEasting = 0, pivotAxleNorthing = 0, hitchEasting = 0, hitchNorthing = 0;
        public double toolEasting = 0, toolNorthing = 0, fixHeadingSection = 0.0;
        public double tankEasting = 0, tankNorthing = 0, fixHeadingTank = 0;

        //headings
        public double fixHeading = 0.0, fixHeadingCam = 0.0;

        //storage for the cos and sin of heading
        public double cosSectionHeading = 1.0, sinSectionHeading = 0.0;

        //a distance between previous and current fix
        private double distance = 0.0, userDistance = 0;
  
        //how far travelled since last section was added, section points
        double sectionTriggerDistance = 0, sectionTriggerStepDistance = 0;        
        public double prevSectionEasting = 0, prevSectionNorthing = 0;

        //step distances and positions for boundary
        public double prevBoundaryEasting = 0, prevBoundaryNorthing = 0, boundaryTriggerDistance = 6.0;

        //are we still getting valid data from GPS, resets to 0 in NMEA RMC block, watchdog 
        public int recvCounter = 20;

        //Everything is so wonky at the start
        int startCounter = 0;

        //individual points for the flags in a list
        List<CFlag> flagPts = new List<CFlag>();

        //tally counters for display
        public double totalSquareMeters = 0, totalUserSquareMeters = 0, userSquareMetersAlarm = 0;

        //used to determine NMEA sentence frequency
        private int timerPn = 1;        
        private double et = 0, hzTime = 0;

        public double[] avgSpeed = new double[10];//for average speed
        public int ringCounter = 0;  
      
        //IMU 
        //double tiltDistance = 0;
        //double roll = 0, pitch = 0, angVel = 0;
        //double avgPitch = 0, avgRoll = 0, avgAngVel = 0;
        
        //public double[] avgTiltRoll = new double[10];//for tilt
        //public int ringCounterTiltRoll = 0;        
        //public double[] avgTiltPitch = new double[10];//for pitch
        //public int ringCounterTiltPitch = 0;        
        //public double[] avgAngularVelocity = new double[30];//for angular velocity
        //public int ringCounterAngularVelocity = 0;

        public double pitchZero, rollZero;

        private int totalFixSteps = 20, currentStepFix = 0;
        private vec3 vHold;
        public vec3[] stepFixPts = new vec3[50];
        public double distanceCurrentStepFix = 0, fixStepDist, minFixStepDist = 0;        
        bool isFixHolding = false, isFixHoldLoaded = false;
        
        //called by watchdog timer every 50 ms
        private void ScanForNMEA()
        {
            //parse any data from pn.rawBuffer
            pn.ParseNMEA();

            //time for a frame update with new valid nmea data
            if (pn.updatedGGA | pn.updatedRMC)
            {
                //if saving a file ignore any movement
                if (isSavingFile) return;

                //accumulate time over multiple frames  
                hzTime += swFrame.ElapsedMilliseconds;

                //reset the timer         
                swFrame.Reset();

                //now calculate NMEA rate
                if (timerPn++ == 36)
                {
                    et = (1 / (hzTime * 0.000025));
                    if (et > 4 && et < 8) fixUpdateHz = 5;
                    if (et > 9 && et < 13) fixUpdateHz = 10;
                    if (et > 1.2 && et < 3) fixUpdateHz = 2;
                    if (et > 0.8 && et < 1.2) fixUpdateHz = 1;
                    fixUpdateTime = 1 / (double)fixUpdateHz;
                    timerPn = 0;
                    hzTime = 0;
                    //fixUpdateHz = 5;
                    //fixUpdateTime = 0.2;
                }

                //start the watch and time till it gets back here
                swFrame.Start();

                //reset both flags
                pn.updatedGGA = false;
                pn.updatedRMC = false;

                //update all data for new frame
                UpdateFixPosition();
            }

            //must make sure arduinos are kept off
            else
            {
                if (!isGPSPositionInitialized)
                {
                    modcom.relaySectionControl[0] = (byte)0;
                    SectionControlOutToPort();
                    modcom.autoSteerControl[0] = (byte)127;
                    modcom.autoSteerControl[1] = (byte)(254);
                    modcom.autoSteerControl[2] = (byte)0;
                    modcom.autoSteerControl[3] = (byte)(0);
                    modcom.autoSteerControl[4] = (byte)(125);
                    modcom.autoSteerControl[5] = (byte)20;
                    modcom.autoSteerControl[6] = (byte)(125);
                    modcom.autoSteerControl[7] = (byte)20;
                    AutoSteerControlOutToPort();
                }

            }

            //Update the port connecition counter - is reset every time new sentence is valid and ready
            recvCounter++;
        }

        //call for position update after valid NMEA sentence
        private void UpdateFixPosition()
        {
            startCounter++;
            totalFixSteps = fixUpdateHz * 4;

            if (!isGPSPositionInitialized) {  InitializeFirstFewGPSPositions();   return;  }
            
    #region tilt
            ////average out angular velocity
            //int times = 30;
            //avgAngularVelocity[ringCounterTiltRoll] = modcom.angularVelocity;
            //if (ringCounterAngularVelocity++ == times) ringCounterAngularVelocity = 0;
            //angVel = 0;
            //for (int c = 0; c <= times - 1; c++) angVel += avgAngularVelocity[c];
            //angVel /= times;
            //avgAngVel = Math.Round(angVel, 1);

            ////average out the roll angle
            //times = 5;
            //avgTiltRoll[ringCounterTiltRoll] = modcom.rollAngle+rollZero;
            //if (ringCounterTiltRoll++ == times) ringCounterTiltRoll = 0;
            //roll = 0;
            //for (int c = 0; c <= times - 1; c++) roll += avgTiltRoll[c];
            //roll /= times;
            //avgRoll = Math.Round(roll, 1);

            ////Convert 16 bit int to degrees, take the sin of it
            //roll = Math.Sin(glm.toRadians(roll));
            //tiltDistance = Math.Abs(roll * vehicle.antennaHeight);

            ////tilt to left is positive 
            //if (roll > 0)
            //{
            //    pn.easting = (Math.Cos(fixHeading) * tiltDistance) + pn.easting;
            //    pn.northing = (Math.Sin(fixHeading) * -tiltDistance) + pn.northing;
            //}

            //else
            //{
            //    pn.easting = (Math.Cos(fixHeading) * -tiltDistance) + pn.easting;
            //    pn.northing = (Math.Sin(fixHeading) * tiltDistance) + pn.northing;
            //}

            ////average out the pitch angle
            //times = 5;
            //avgTiltPitch[ringCounterTiltPitch] = modcom.pitchAngle+pitchZero;
            //if (ringCounterTiltPitch++ == times - 1) ringCounterTiltPitch = 0;
            //pitch = 0;
            //for (int c = 0; c < times; c++) pitch += avgTiltPitch[c];
            //pitch /= times;
            //avgPitch = Math.Round(pitch, 1);
            ////Convert 16 bit int to degrees, take the sin of it
            //pitch = Math.Sin(glm.toRadians(pitch));

            //tiltDistance = (pitch * vehicle.antennaHeight);
            ////pn.easting = (Math.Sin(fixHeading) * tiltDistance) + pn.easting;
            //pn.northing = (Math.Cos(fixHeading) * tiltDistance) + pn.northing;

#endregion            

    #region Step Fix

            //grab the most current fix and save the distance from the last fix
            distanceCurrentStepFix = pn.Distance(pn.northing, pn.easting, stepFixPts[0].z, stepFixPts[0].x);
            fixStepDist = distanceCurrentStepFix;

            //if  min distance isn't exceeded, keep adding old fixes till it does
            if (distanceCurrentStepFix <= minFixStepDist)
            {
                for (currentStepFix = 0; currentStepFix < totalFixSteps; currentStepFix++)
                {
                    fixStepDist += stepFixPts[currentStepFix].h;
                    if (fixStepDist > minFixStepDist)
                    {
                        //if we reached end, keep the oldest and stay till distance is exceeded
                        if (currentStepFix < (totalFixSteps-1) ) currentStepFix++; 
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
                stepFixPts[0].h = pn.Distance(pn.northing, pn.easting, stepFixPts[0].z, stepFixPts[0].x);
                stepFixPts[0].x = pn.easting;
                stepFixPts[0].z = pn.northing;

                //reload the last position that was triggered.
                stepFixPts[(totalFixSteps - 1)].h = pn.Distance(vHold.z, vHold.x, stepFixPts[(totalFixSteps - 1)].z, stepFixPts[(totalFixSteps - 1)].x);
                stepFixPts[(totalFixSteps - 1)].x = vHold.x;
                stepFixPts[(totalFixSteps - 1)].z = vHold.z;
            }
            
            else //distance is exceeded, time to do all calcs and next frame
            {
                //positions and headings 
                CalculatePositionHeading();

                //get rid of hold position
                isFixHoldLoaded = false;

                //don't add the total distance again
                stepFixPts[(totalFixSteps - 1)].h = 0;

                //grab sentences for logging
                if (isLogNMEA)
                {
                    if (ct.isContourOn)
                    {
                        pn.logNMEASentence.Append(recvSentenceSettings);
                    }
                }

                //To prevent drawing high numbers of triangles, determine and test before drawing vertex
                sectionTriggerDistance = pn.Distance(pn.northing, pn.easting, prevSectionNorthing, prevSectionEasting);

                //section on off and points, contour points
                if (sectionTriggerDistance > sectionTriggerStepDistance)
                        AddSectionContourPathPoints();

                //test if travelled far enough for new boundary point
                double boundaryDistance = pn.Distance(pn.northing, pn.easting, prevBoundaryNorthing, prevBoundaryEasting);
                if (boundaryDistance > boundaryTriggerDistance) AddBoundaryPoint();

                //calc distance travelled since last GPS fix
                distance = pn.Distance(pn.northing, pn.easting, prevNorthing, prevEasting);
                userDistance += distance;//userDistance can be reset

               //most recent fixes are now the prev ones
                prevEasting = pn.easting; prevNorthing = pn.northing;

                //load up history with valid data
                for (int i = totalFixSteps - 1; i > 0; i--) stepFixPts[i] = stepFixPts[i - 1];
                stepFixPts[0].h = pn.Distance(pn.northing, pn.easting, stepFixPts[0].z, stepFixPts[0].x);
                stepFixPts[0].x = pn.easting;
                stepFixPts[0].z = pn.northing;
            }

#endregion

    #region AutoSteer
            //preset the values
            guidanceLineDistanceOff = 32000;
            guidanceLineHeadingDelta = 0;

            //do the distance from line calculations for contour and AB
            if (ct.isContourBtnOn) ct.DistanceFromContourLine();
            if (ABLine.isABLineSet && !ct.isContourBtnOn) ABLine.getCurrentABLine();

            // autosteer at full speed of updates
            if (!isAutoSteerBtnOn)
            {
                guidanceLineDistanceOff = 32020;
                guidanceLineHeadingDelta = 32020;
            }

            // modcom.autoSteerControl[2] contains the section relay byte
            modcom.autoSteerControl[3] = (byte)(pn.speed * 4.0);

            modcom.autoSteerControl[4] = (byte)(guidanceLineDistanceOff >> 8);
            modcom.autoSteerControl[5] = (byte)guidanceLineDistanceOff;

            modcom.autoSteerControl[6] = (byte)(guidanceLineHeadingDelta >> 8);
            modcom.autoSteerControl[7] = (byte)guidanceLineHeadingDelta;

            //out serial to autosteer module  //indivdual classes load the distance and heading deltas 
            AutoSteerControlOutToPort();
            #endregion

            //calculate lookahead at full speed, no sentence misses
            CalculateSectionLookAhead(toolNorthing, toolEasting, cosSectionHeading, sinSectionHeading);

            //openGLControl_Draw routine triggered manually
            openGLControl.DoRender();

        //end of UppdateFixPosition
        }

        double overTank, overSect;

        //all the hitch, pivot, section, trailing hitch, headings and fixes
        private void CalculatePositionHeading()
        {
            //in radians
            fixHeading = Math.Atan2(pn.easting - stepFixPts[currentStepFix].x, pn.northing - stepFixPts[currentStepFix].z);
            if (fixHeading < 0) fixHeading += glm.twoPI;

            //determine fix positions and heading
            fixPosX = (pn.easting);
            fixPosZ = (pn.northing);
 

       #region pivot hitch trail

            //translate world to the pivot axle
            pivotAxleEasting = pn.easting - (Math.Sin(fixHeading) * vehicle.antennaPivot);
            pivotAxleNorthing = pn.northing - (Math.Cos(fixHeading) * vehicle.antennaPivot);

            //determine where the rigid vehicle hitch ends
            hitchEasting = pn.easting + (Math.Sin(fixHeading) * (vehicle.hitchLength - vehicle.antennaPivot));
            hitchNorthing = pn.northing + (Math.Cos(fixHeading) * (vehicle.hitchLength - vehicle.antennaPivot));

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
                        tankEasting = hitchEasting + t * (hitchEasting - tankEasting);
                        tankNorthing = hitchNorthing + t * (hitchNorthing - tankNorthing);
                        fixHeadingTank = Math.Atan2(hitchEasting - tankEasting, hitchNorthing - tankNorthing);
                    }


                    ////the tool is seriously jacknifed or just starting out so just spring it back.
                    over = Math.Abs(Math.PI - Math.Abs(Math.Abs(fixHeadingTank - fixHeading) - Math.PI));
                    overTank = over;

                    if (over < 2.0 && startCounter > 50)
                    {
                        tankEasting = hitchEasting + (Math.Sin(fixHeadingTank) * (vehicle.tankTrailingHitchLength));
                        tankNorthing = hitchNorthing + (Math.Cos(fixHeadingTank) * (vehicle.tankTrailingHitchLength));
                    }

                    //criteria for a forced reset to put tool directly behind vehicle
                    if (over > 2.0 | startCounter < 51 )
                    {
                        fixHeadingTank = fixHeading;
                        tankEasting = hitchEasting + (Math.Sin(fixHeadingTank) * (vehicle.tankTrailingHitchLength));
                        tankNorthing = hitchNorthing + (Math.Cos(fixHeadingTank) * (vehicle.tankTrailingHitchLength));
                    }

                }

                else
                {
                    fixHeadingTank = fixHeading;
                    tankEasting = hitchEasting;
                    tankNorthing = hitchNorthing;
                }

                //Torriem rules!!!!! Oh yes, this is all his. Thank-you
                if (distanceCurrentStepFix != 0)
                {
                    double t = (vehicle.toolTrailingHitchLength) / distanceCurrentStepFix;
                    toolEasting = tankEasting + t * (tankEasting - toolEasting);
                    toolNorthing = tankNorthing + t * (tankNorthing - toolNorthing);
                    fixHeadingSection = Math.Atan2(tankEasting - toolEasting, tankNorthing - toolNorthing);
                }


                ////the tool is seriously jacknifed or just starting out so just spring it back.
                over = Math.Abs(Math.PI - Math.Abs(Math.Abs(fixHeadingSection - fixHeadingTank) - Math.PI));
                overSect = over;

                if (over < 1.9 && startCounter > 50)
                {
                    toolEasting = tankEasting + (Math.Sin(fixHeadingSection) * (vehicle.toolTrailingHitchLength));
                    toolNorthing = tankNorthing + (Math.Cos(fixHeadingSection) * (vehicle.toolTrailingHitchLength));
                }

                //criteria for a forced reset to put tool directly behind vehicle
                if (over > 1.9 | startCounter < 51 )
                {
                    fixHeadingSection = fixHeadingTank;
                    toolEasting = tankEasting + (Math.Sin(fixHeadingSection) * (vehicle.toolTrailingHitchLength));
                    toolNorthing = tankNorthing + (Math.Cos(fixHeadingSection) * (vehicle.toolTrailingHitchLength));
                }
            }

            //rigidly connected to vehicley
            else
            {
                fixHeadingSection = fixHeading;
                toolEasting = hitchEasting;
                toolNorthing = hitchNorthing;
            }

#endregion

           //in degrees for glRotate opengl methods.
            int camStep = currentStepFix * 2;
            if (camStep > (totalFixSteps - 1)) camStep = (totalFixSteps - 1);


            fixHeadingCam = Math.Atan2(pn.easting - stepFixPts[camStep].x, pn.northing - stepFixPts[camStep].z);
            if (fixHeadingCam < 0) fixHeadingCam += glm.twoPI;

            //to degrees for openGL camera
            fixHeadingCam = glm.toDegrees(fixHeadingCam);

            //used to increase triangle count when going around corners, less on straight
            //pick the slow moving side edge of tool
            double metersPerSec = pn.speed * 0.277777777;

            //whichever is less
            if (vehicle.toolFarLeftSpeed < vehicle.toolFarRightSpeed)
                sectionTriggerStepDistance = vehicle.toolFarLeftSpeed / metersPerSec;
            else sectionTriggerStepDistance = vehicle.toolFarRightSpeed / metersPerSec;

            //finally determine distance
            sectionTriggerStepDistance = sectionTriggerStepDistance * sectionTriggerStepDistance * 
                metersPerSec * triangleResolution*2.0 + 1.0;

            //  ** Torriem Cam   *****
            //Default using fix Atan2 to calc cam, if unchecked in display settings use True Heading from NMEA
            if (!isAtanCam)
            {
                //use NMEA headings for camera and tractor graphic
                fixHeading = glm.toRadians(pn.headingTrue);
                fixHeadingCam = pn.headingTrue;
            }

            //check to make sure the grid is big enough
            worldGrid.checkZoomWorldGrid(pn.northing, pn.easting);

            //precalc the sin and cos of heading * -1
            sinSectionHeading = Math.Sin(-fixHeadingSection);
            cosSectionHeading = Math.Cos(-fixHeadingSection);
        }

        private void AddBoundaryPoint()
        {
            //save the north & east as previous
            prevBoundaryEasting = pn.easting;
            prevBoundaryNorthing = pn.northing;

            //build the boundary line
            if (boundary.isOkToAddPoints)
            {
                if (boundary.isDrawRightSide)
                {
                    //Right side
                    vec2 point = new vec2(cosSectionHeading * (section[vehicle.numOfSections - 1].positionRight) + toolEasting,
                        sinSectionHeading * (section[vehicle.numOfSections - 1].positionRight) + toolNorthing);
                    boundary.ptList.Add(point);
                }

                    //draw on left side
                else
                {
                    //Right side
                    vec2 point = new vec2(cosSectionHeading * (section[0].positionLeft) + toolEasting,
                        sinSectionHeading * (section[0].positionLeft) + toolNorthing);
                    boundary.ptList.Add(point);
                }

            }

            //build the polygon to calculate area
            if (periArea.isBtnPerimeterOn)
            {
                if (isAreaOnRight)
                {
                    //Right side
                    vec2 point = new vec2(cosSectionHeading * (section[vehicle.numOfSections - 1].positionRight) + toolEasting,
                        sinSectionHeading * (section[vehicle.numOfSections - 1].positionRight) + toolNorthing);
                    periArea.periPtList.Add(point);
                }

                    //draw on left side
                else
                {
                    //Right side
                    vec2 point = new vec2(cosSectionHeading * (section[0].positionLeft) + toolEasting,
                        sinSectionHeading * (section[0].positionLeft) + toolNorthing);
                    periArea.periPtList.Add(point);
                }

            }
        }

        //add the points for section, contour line points, Area Calc feature
        private void AddSectionContourPathPoints()
        {
            //save the north & east as previous
            prevSectionNorthing = pn.northing;
            prevSectionEasting = pn.easting;

            if (isJobStarted)//add the pathpoint
            {
                // if non zero, at least one section is on.
                int sectionCounter = 0;

                //send the current and previous GPS fore/aft corrected fix to each section
                for (int j = 0; j < vehicle.numOfSections+1; j++)
                {
                    if (section[j].isSectionOn)
                    {
                        section[j].AddPathPoint(toolNorthing, toolEasting, cosSectionHeading, sinSectionHeading);
                        sectionCounter++;
                    }
                }
                
                //Contour Base Track.... At least One section on, turn on if not
                if (sectionCounter != 0)
                {
                    //keep the line going, everything is on for recording path
                    if (ct.isContourOn) ct.AddPoint();
                    else { ct.StartContourLine(); ct.AddPoint(); }
                }

                //All sections OFF so if on, turn off
                else { if (ct.isContourOn) { ct.StopContourLine(); }  }

                //Build contour line if close enough to a patch
                if (ct.isContourBtnOn) ct.BuildContourGuidanceLine(pn.easting, pn.northing);


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
                if (Math.PI - Math.Abs(Math.Abs(head - fixHeadingSection) - Math.PI) > glm.PIBy2) leftLook *= -1;

                head = right.HeadingXZ();
                if (Math.PI - Math.Abs(Math.Abs(head - fixHeadingSection) - Math.PI) > glm.PIBy2) rightLook *= -1;

                //choose fastest speed
                if (leftLook > rightLook)  section[j].sectionLookAhead = leftLook;
                else section[j].sectionLookAhead = rightLook;

                if (section[j].sectionLookAhead > 190) section[j].sectionLookAhead = 190;

                //Doing the slow mo, exceeding buffer so just set as minimum 0.5 meter
                if (currentStepFix >= totalFixSteps - 1) section[j].sectionLookAhead = 5;

            }//endfor

            //determine if section is in boundary using the section left/right positions
            for (int j = 0; j < vehicle.numOfSections; j++)
            {
                bool isLeftIn = true, isRightIn = true;

                if (boundary.isSet)
                {
                    if (j == 0)
                    {
                        //only one first left point, the rest are all rights moved over to left
                        isLeftIn = boundary.IsPrePointInPolygon(section[j].leftPoint);
                        isRightIn = boundary.IsPrePointInPolygon(section[j].rightPoint);

                        if (isLeftIn && isRightIn) section[j].isInsideBoundary = true;
                        else section[j].isInsideBoundary = false;
                    }

                    else
                    {
                        //grab the last right, its the left of this section
                        isLeftIn = isRightIn;
                        isRightIn = boundary.IsPrePointInPolygon(section[j].rightPoint);
                        if (isLeftIn && isRightIn) section[j].isInsideBoundary = true;
                        else section[j].isInsideBoundary = false;
                    }
                }

                //no boundary created so always inside
                else section[j].isInsideBoundary = true;                
            }

            //with left and right tool velocity to determine rate of triangle generation, corners are more
            //save far right speed, 0 if going backwards, in meters/sec
            if (section[vehicle.numOfSections - 1].sectionLookAhead > 0) vehicle.toolFarRightSpeed = rightSpeed * 0.05;
            else vehicle.toolFarRightSpeed = 0;

            //safe left side, 0 if going backwards, in meters/sec convert back from pixels/m
            if (section[0].sectionLookAhead > 0) vehicle.toolFarLeftSpeed = vehicle.toolFarLeftSpeed * 0.05;
            else vehicle.toolFarLeftSpeed = 0;    
      
            //calculate using left and right points whether or not section is in boundary
            
        }

        //the start of first few frames to initialize entire program
        private void InitializeFirstFewGPSPositions()
        {
            if (!isFirstFixPositionSet)
            {
                //reduce the huge utm coordinates
                pn.utmEast = (int)(pn.easting);
                pn.utmNorth = (int)(pn.northing);
                pn.easting = pn.easting - pn.utmEast;
                pn.northing = pn.northing - pn.utmNorth;

                //Draw a grid once we know where in the world we are.
                isFirstFixPositionSet = true;
                worldGrid.CreateWorldGrid(pn.northing, pn.easting);

                //most recent fixes
                prevEasting = pn.easting;
                prevNorthing = pn.northing;

                stepFixPts[0].x = pn.easting;
                stepFixPts[0].z = pn.northing;
                stepFixPts[0].h = 0;

                //run once and return
                isFirstFixPositionSet = true;
                return;
            }

            else
            {
 
                //most recent fixes
                prevEasting = pn.easting; prevNorthing = pn.northing;

                //load up history with valid data
                for (int i = totalFixSteps - 1; i > 0; i--)
                {
                    stepFixPts[i].x = stepFixPts[i - 1].x;
                    stepFixPts[i].z = stepFixPts[i - 1].z;
                    stepFixPts[i].h = stepFixPts[i - 1].h;
                }

                stepFixPts[0].h = pn.Distance(pn.northing, pn.easting, stepFixPts[0].z, stepFixPts[0].x);
                stepFixPts[0].x = pn.easting;
                stepFixPts[0].z = pn.northing;

                //keep here till valid data
                if (startCounter > totalFixSteps) isGPSPositionInitialized = true;

                //in radians
                fixHeading = Math.Atan2(pn.easting - stepFixPts[totalFixSteps - 1].x, pn.northing - stepFixPts[totalFixSteps - 1].z); 
                if (fixHeading < 0) fixHeading += glm.twoPI;
                fixHeadingSection = fixHeading;

                if (isGPSPositionInitialized) AutoSteerSettingsOutToPort();

                return;
            }
        }

 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private double sm_a = 6378137.0;
        private double sm_b = 6356752.314;
        private double UTMScaleFactor2 = 1.0004001600640256102440976390556;

        //the result is placed in these two
        public double utmLat = 0;
        public double utmLon = 0;

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
            gamma_ = (21.0 * Math.Pow(n, 2.0) / 16.0)
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

    }//end class
}//end namespace

//double angle = 0;
//double x = 0, y = 0;

//for (int j = 0; j < stepFixNumber; j++)
//{
//    angle = Math.Atan2(pn.easting - stepFixPts[j].x, pn.northing - stepFixPts[j].z);
//    x += Math.Cos(angle);
//    y += Math.Sin(angle);
//}

////x += Math.Cos(angle);
////y += Math.Sin(angle);

//fixHeadingCam = Math.Atan2(y, x);


//double x = 0, z = 0;
//x += pn.northing;
//x += stepFixPts[0].x;
//x += stepFixPts[1].x;
//x /= 3.0;

//z += pn.easting;
//z += stepFixPts[0].z;
//z += stepFixPts[1].z;
//z /= 3.0;

//double x2 = 0, z2 = 0;
//x2 += stepFixPts[2].x;
//x2 += stepFixPts[3].x;
//x2 += stepFixPts[4].x;
//x2 /= 3.0;

//z2 += stepFixPts[2].z;
//z2 += stepFixPts[3].z;
//z2 += stepFixPts[4].z;
//z2 /= 3.0;