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
        //very first fix to setup grid etc
        public bool isFirstFixPositionSet = false, isGPSPositionInitialized = false;

        //how many fix updates per sec
        public int fixUpdateHz = 5;
        public double fixUpdateTime = 0.2;

        public int delayFixPrev = 2, delayCameraPrev = 6;

        //for heading or Atan2 as camera
        public bool isAtanCam = true;

        //Current fix positions
        public double fixPosX = 0.0, fixPosY = 0.0, fixPosZ = -7.0;
        public double pivotAxleEasting = 0, pivotAxleNorthing = 0;
        public double hitchEasting = 0, hitchNorthing = 0;
        public double toolEasting = 0, toolNorthing = 0;
        public double prevToolEasting = 0, prevToolNorthing = 0;

        //array index for previous northing and easting positions
        private static int numPrevs = 20;
        public double[] prevNorthing = new double[numPrevs];
        public double[] prevEasting = new double[numPrevs];


        //headings
        public double fixHeading = 0.0, fixHeadingCam = 0.0, fixHeadingSection = 0.0;

        //storage for the cos and sin of heading
        public double cosHeading = 1.0, sinHeading = 0.0;

        //a distance between previous and current fix
        private double distance = 0.0, userDistance = 0;

        public double prevFixHeadingSection = 0;
  
        //how far travelled since last section was added, section points
        double sectionTriggerDistance = 0, sectionTriggerStepDistance = 0;
        
        public double prevSectionEasting = 0, prevSectionNorthing = 0;

        //Low speed detection variables
        public double prevLowSpeedEasting = 0, prevLowSpeedNorthing = 0;
        double distanceLowSpeed = 0;

        //are we still getting valid data from GPS, resets to 0 in NMEA RMC block, watchdog 
        public int recvCounter = 20;

        //Everything is so wonky at the start
        int startCounter = 0;

        //individual points
        List<CPointData> pointAntenna = new List<CPointData>();

        //tally counters for display
        public double totalSquareMeters = 0;
        public double totalDistance = 0;

        //used to determine NMEA sentence frequency
        private int timerPn = 1;        
        private double et = 0, hzTime = 0;
        
        //called by watchdog timer every 50 ms
        private void ScanForNMEA()
        {
            //parse any data from pn.rawBuffer
            pn.ParseNMEA();

            //check if time for a frame update
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
                    et = (1 / (hzTime*0.000025));
                    if (et > 4 && et < 8) fixUpdateHz = 5;
                    if (et > 9 && et < 13) fixUpdateHz = 10;
                    if (et > 0.5 && et < 2) fixUpdateHz = 1;
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

            //Update the port counter - is reset every time new sentence is valid and ready
            recvCounter++;
        }

        //called by the openglDraw routine 10 times per second.
        private void UpdateFixPosition()
        {
            startCounter++;

            //if its a valid fix data for RMC or GGA
            //this is the current position taken from the latest sentence
            textBoxRcv.Text = pn.theSent;

            if (!isGPSPositionInitialized)
            {
                InitializeFirstFewGPSPositions();
                return;
            }

            //calc low speed distance travelled if speed < 2 kph and app not starting
            if (pn.speed < 2.0) distanceLowSpeed = pn.Distance(pn.northing, pn.easting, prevLowSpeedNorthing, prevLowSpeedEasting);
            else distanceLowSpeed = -1;
           
            //calculate lookahead at full speed, no sentence misses
            CalculateSectionLookAhead(toolNorthing, toolEasting, cosHeading, sinHeading);

            //do the distance from line calculations for contour and AB
            if (ct.isContourBtnOn) ct.DistanceFromContourLine();
            else ct.distanceFromCurrentLine = 9999;

            if (ABLine.isABLineSet && !ct.isContourBtnOn) ABLine.getCurrentABLine();
            else ABLine.distanceFromCurrentLine = 9999;

            //module communications current heading variable
            modcom.autosteerActualHeading = fixHeading;

            //time to record next fix
            if (distanceLowSpeed > 0.1 | pn.speed > 2.0 | startCounter < 20)
            {
                //positions and headings 
                CalculatePositionHeading();

                //To prevent drawing high numbers of triangles, determine and test before drawing vertex
                sectionTriggerDistance = pn.Distance(toolNorthing, toolEasting, prevSectionNorthing, prevSectionEasting);

                //section on off and points, contour points
                if (sectionTriggerDistance > sectionTriggerStepDistance)
                        AddSectionContourPathPoints();

                //calc distance travelled since last GPS fix
                distance = pn.Distance(pn.northing, pn.easting, prevNorthing[0], prevEasting[0]);
                totalDistance += distance; //distance tally                   
                userDistance += distance;//userDistance can be reset

                //save a copy of previous positions for cam heading of desired filtering or delay
                for (int x = numPrevs - 1; x > 0; x--) { prevNorthing[x] = prevNorthing[x - 1]; prevEasting[x] = prevEasting[x - 1]; }

                //most recent fixes
                prevEasting[0] = pn.easting; prevNorthing[0] = pn.northing;

                prevToolNorthing = toolNorthing;
                prevToolEasting = toolEasting;
                prevFixHeadingSection = fixHeadingSection;
            }

            //openGLControl_Draw routine triggered manually
            openGLControl.DoRender();

        //end of UppdateFixPosition
        }

        //add the points for section, contour line points, Area Calc feature
        private void AddSectionContourPathPoints()
        {
                //save the north & east as previous
                prevSectionNorthing = toolNorthing;
                prevSectionEasting = toolEasting;

               //build the polygon to calculate area
                if (periArea.isBtnPerimeterOn)
                {
                    //Right side
                    vec2 point = new vec2(cosHeading * (section[vehicle.numberOfSections-1].positionRight) + toolEasting,
                        sinHeading * (section[vehicle.numberOfSections-1].positionRight) + toolNorthing);
                    periArea.periList.Add(point);
                }

            if (isJobStarted)//add the pathpoint
            {
 
                int sectionCounter = 0;


                //send the current and previous GPS fore/aft corrected fix to each section
                for (int j = 0; j < vehicle.numberOfSections; j++)
                {
                    if (section[j].isSectionOn)
                    {
                        section[j].AddPathPoint(toolNorthing, toolEasting, cosHeading, sinHeading);
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
                ct.BuildContourGuidanceLine(pn.easting, pn.northing);



            }
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
                prevEasting[0] = pn.easting;
                prevNorthing[0] = pn.northing;

                //run once and return
                isFirstFixPositionSet = true;
                return;
            }

            else
            {
                //save a copy of previous positions for cam heading of desired filtering or delay
                for (int x = numPrevs - 1; x > 0; x--) { prevNorthing[x] = prevNorthing[x - 1]; prevEasting[x] = prevEasting[x - 1]; }

                //most recent fixes
                prevEasting[0] = pn.easting; prevNorthing[0] = pn.northing;

                if (startCounter > delayCameraPrev) isGPSPositionInitialized = true;

                //in radians
                fixHeading = Math.Atan2(pn.easting - prevEasting[delayFixPrev], pn.northing - prevNorthing[delayFixPrev]);
                if (fixHeading < 0) fixHeading += glm.twoPI;

                prevToolEasting = pn.easting + Math.Sin(fixHeading) * (vehicle.toolTrailingHitchLength + vehicle.hitchLength);
                prevToolNorthing = pn.northing + Math.Cos(fixHeading) * (vehicle.toolTrailingHitchLength + vehicle.hitchLength);
                prevFixHeadingSection = fixHeading;
                fixHeadingSection = fixHeading;

                return;
            }
        }

        //all the hitch, pivot, section, trailing hitch, headings and fixes
        private void CalculatePositionHeading()
        {
            //determine fix positions and heading
            fixPosX = (pn.easting);
            fixPosZ = (pn.northing);

            //save a copy to calc distance for next time, make these current.
            prevLowSpeedEasting = pn.easting;
            prevLowSpeedNorthing = pn.northing;

            //in radians
            fixHeading = Math.Atan2(pn.easting - prevEasting[delayFixPrev], pn.northing - prevNorthing[delayFixPrev]);
            if (fixHeading < 0) fixHeading += glm.twoPI;

            //translate world to the pivot axle
            pivotAxleEasting = pn.easting - (Math.Sin(fixHeading) * vehicle.antennaPivot);
            pivotAxleNorthing = pn.northing - (Math.Cos(fixHeading) * vehicle.antennaPivot);

            //determine where the rigid vehicle hitch ends
            hitchEasting = pn.easting + (Math.Sin(fixHeading) * (vehicle.hitchLength - vehicle.antennaPivot));
            hitchNorthing = pn.northing + (Math.Cos(fixHeading) * (vehicle.hitchLength - vehicle.antennaPivot));

            //tool attached via a trailing hitch
            if (vehicle.isToolTrailing)
            {
                //Torriem rules!!!!! Oh yes, this is all his. Thank-you
                double t;
                double dist = Math.Sqrt((hitchNorthing - prevToolNorthing) * (hitchNorthing - prevToolNorthing) +
                                                            (hitchEasting - prevToolEasting) * (hitchEasting - prevToolEasting));
                if (dist != 0)
                {
                    t = (vehicle.toolTrailingHitchLength + vehicle.hitchLength) / dist;
                    prevToolEasting = hitchEasting + t * (hitchEasting - prevToolEasting);
                    prevToolNorthing = hitchNorthing + t * (hitchNorthing - prevToolNorthing);
                    fixHeadingSection = Math.Atan2(hitchEasting - prevToolEasting, hitchNorthing - prevToolNorthing);
                    if (fixHeadingSection < 0) fixHeadingSection += glm.twoPI;
                }

                //the tool is seriously jacknifed so just spring it back.
                double over = Math.PI - Math.Abs(Math.Abs(fixHeadingSection - fixHeading) - Math.PI);

                if (over < 1.9)
                {
                    toolEasting = hitchEasting + (Math.Sin(fixHeadingSection) * (vehicle.toolTrailingHitchLength));
                    toolNorthing = hitchNorthing + (Math.Cos(fixHeadingSection) * (vehicle.toolTrailingHitchLength));
                }

                else
                {
                    fixHeadingSection = fixHeading;
                    toolEasting = hitchEasting + (Math.Sin(fixHeadingSection) * (vehicle.toolTrailingHitchLength));
                    toolNorthing = hitchNorthing + (Math.Cos(fixHeadingSection) * (vehicle.toolTrailingHitchLength));
                    prevToolNorthing = toolNorthing;
                    prevToolEasting = toolEasting;
                }
            }

            //rigidly connected to vehicle
            else
            {
                fixHeadingSection = fixHeading;
                toolEasting = hitchEasting;
                toolNorthing = hitchNorthing;
            }

            //in degrees for glRotate opengl methods.
            fixHeadingCam = Math.Atan2(pn.easting - prevEasting[delayCameraPrev], pn.northing - prevNorthing[delayCameraPrev]);
            if (fixHeadingCam < 0) fixHeadingCam += glm.twoPI;

            //to degrees for openGL camera
            fixHeadingCam = glm.degrees(fixHeadingCam);

            //used to increase triangle count when going around corners, less on straight
            //pick the slow moving side edge of tool
            double metersPerSec = pn.speed * 0.277777777;

            //whichever is less
            if (vehicle.toolFarLeftSpeed < vehicle.toolFarRightSpeed)
                sectionTriggerStepDistance = vehicle.toolFarLeftSpeed / metersPerSec;
            else sectionTriggerStepDistance = vehicle.toolFarRightSpeed / metersPerSec;

            //finally determine distance
            sectionTriggerStepDistance = sectionTriggerStepDistance * sectionTriggerStepDistance * metersPerSec * triangleResolution + 1.0;

            //  ** Torriem Cam   *****
            //Default using fix Atan2 to calc cam, if unchecked in display settings use True Heading from NMEA
            if (!isAtanCam)
            {
                //use NMEA headings for camera and tractor graphic
                fixHeading = glm.radians(pn.headingTrue);
                fixHeadingCam = pn.headingTrue;
            }

            //check to make sure the grid is big enough
            worldGrid.checkZoomWorldGrid(pn.northing, pn.easting);

            //precalc the sin and cos of heading * -1
            sinHeading = Math.Sin(-fixHeadingSection);
            cosHeading = Math.Cos(-fixHeadingSection);

        }
        
        //calculate the extreme tool left, right velocities, each section lookahead, and whether or not its going backwards
        public void CalculateSectionLookAhead(double northing, double easting, double cosHeading, double sinHeading)
        {
            
            //calculate left side of section 1

            vec3 left = new vec3(0, 0, 0);
            vec3 right = left;

            double leftSpeed, rightSpeed = 0;

            //now loop all the section rights and the one extreme left
            for (int j = 0; j < vehicle.numberOfSections; j++)
            {
                if (j == 0)
                {
                    //only one first left point, the rest are all rights moved over to left
                    section[j].leftPoint = new vec3(cosHeading * (section[j].positionLeft) + easting,
                                       0, sinHeading * (section[j].positionLeft) + northing);

                    left = section[j].leftPoint - section[j].lastLeftPoint;
                    
                    //save a copy for next time
                    section[j].lastLeftPoint = section[j].leftPoint;
                    
                    //get the speed for left side only once
                    leftSpeed = left.GetLength()* vehicle.toolLookAhead / fixUpdateTime * 10;

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


                section[j].rightPoint = new vec3(cosHeading * (section[j].positionRight) + easting,
                                    0, sinHeading * (section[j].positionRight) + northing);

                //now we have left and right for this section
                right = section[j].rightPoint - section[j].lastRightPoint;

                //save a copy for next time
                section[j].lastRightPoint = section[j].rightPoint;

                //grab vector length and convert to meters/sec/10 pixels per meter                
                rightSpeed = right.GetLength()* vehicle.toolLookAhead / fixUpdateTime * 10;

                //choose fastest speed
                if (leftSpeed > rightSpeed)  section[j].sectionLookAhead = leftSpeed;
                else section[j].sectionLookAhead = rightSpeed;

                double head = left.HeadingXZ();
                if (head < 0) head += glm.twoPI;

                double head2 = right.HeadingXZ();
                if (head2 < 0) head2 += glm.twoPI;

                //if both left and right sides of section are going backwards turn off section, negative lookahead
                if (Math.PI - Math.Abs(Math.Abs(head - fixHeadingSection) - Math.PI) > glm.PIBy2 &&
                        Math.PI - Math.Abs(Math.Abs(head2 - fixHeadingSection) - Math.PI) > glm.PIBy2)
                    
                    section[j].sectionLookAhead = Math.Abs(section[j].sectionLookAhead) * -1;
                
            }//endfor

            //with left and right tool velocity to determine rate of triangle generation, corners are more
            //save far right speed, 0 if going backwards, in meters/sec
            if (section[vehicle.numberOfSections - 1].sectionLookAhead > 0) vehicle.toolFarRightSpeed = rightSpeed * 0.05;
            else vehicle.toolFarRightSpeed = 0;

            //safe left side, 0 if going backwards, in meters/sec convert back from pixels/m
            if (section[0].sectionLookAhead > 0) vehicle.toolFarLeftSpeed = vehicle.toolFarLeftSpeed * 0.05;
            else vehicle.toolFarLeftSpeed = 0;
            
            
        } 


    }//end class
}//end namespace