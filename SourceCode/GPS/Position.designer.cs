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
        public bool isFirstFixPositionSet = false;

        //how many fix updates per sec
        public int rmcUpdateHz = 5;
        public int delayFixPrev = 2;
        public int delayCameraPrev = 6;

        //Current fix position
        public double fixPosX = 0.0;
        public double fixPosY = 0.0;
        public double fixPosZ = -7.0;

        public double pivotAxleEasting = 0;
        public double pivotAxleNorthing = 0;

        public double hitchEasting = 0;
        public double hitchNorthing = 0;

        public double toolEasting = 0;
        public double toolNorthing = 0;

        public double prevToolEasting = 0;
        public double prevToolNorthing = 0;

        //array index for previous northing and easting positions
        private static int numPrevs = 20;
        public double[] prevNorthing = new double[numPrevs];
        public double[] prevEasting = new double[numPrevs];


        //headings
        public double fixHeading = 0.0;
        public double fixHeadingCam = 0.0;
        public double fixHeadingSection = 0.0;
        public double deltaFix = 0;

        //storage for the cos and sin of heading
        public double cosHeading = 1.0;
        public double sinHeading = 0.0;

        //a distance between previous and current fix
        private double distance = 0.0;
        public double sectionDistance = 0;
        public double userDistance = 0;

        //how far travelled since last section was added, section points
        double sectionTriggerDistance = 0;
        public double prevSectionEasting = 0;
        public double prevSectionNorthing = 0;

        //Low speed detection variables
        public double prevLowSpeedEasting = 0;
        public double prevLowSpeedNorthing = 0;
        double distanceLowSpeed = 0;


        //are we still getting valid data from GPS, resets to 0 in NMEA RMC block, watchdog 
        public int recvCounter = 20;

        //Everything is so wonky at the start, so no delay for first 20 frames
        int startCounter = 0;

        //individual points
        List<CPointData> pointAntenna = new List<CPointData>();
        //List<CPointData> pointPivot = new List<CPointData>();
        //List<CPointData> pointHitch = new List<CPointData>();
        //List<CPointData> pointTool = new List<CPointData>();

        //tally counters for display
        public double totalSquareMeters = 0;
        public double totalDistance = 0;


        //called by the openglDraw routine 10 times per second.
        private void UpdateFixPosition()
        {
            startCounter++;

            //if saving a file ignore any movement
            if (isSavingFile) return;

            //add what has been rec'd to the nmea buffer
            pn.rawBuffer += recvSentence.ToString();
            recvSentence.Clear();

            //parse the line received GGA and RMC
            pn.ParseNMEA();

            //if its a valid fix data for RMC or GGA
            if (pn.updatedGGA | pn.updatedRMC)
            {
                //this is the current position taken from the latest sentence
                textBoxRcv.Text = pn.theSent;


                if (!isFirstFixPositionSet)
                {
                    //Draw a grid once we know where in the world we are.
                    isFirstFixPositionSet = true;
                    worldGrid.CreateWorldGrid(pn.northing, pn.easting);

                    //most recent fixes
                    prevEasting[0] = pn.easting; prevNorthing[0] = pn.northing;
                    prevSectionEasting = pn.easting + 0.00001; prevSectionNorthing = pn.northing + 0.00001;
                    prevToolEasting = pn.easting + 0.00001; prevToolNorthing = pn.northing + 0.00001;

                    //save a copy of previous positions for cam heading of desired filtering or delay
                    for (int x = 0; x > numPrevs; x++) { prevNorthing[x] = prevNorthing[0]; prevEasting[x] = prevEasting[0]; }
                    return;
                }

                //calc low speed distance travelled if speed < 2 kph and app not starting
                if (pn.speed < 2.0) distanceLowSpeed = pn.Distance(pn.northing, pn.easting, prevLowSpeedNorthing, prevLowSpeedEasting);
                else distanceLowSpeed = -1;

                //time to record next fix
                if (distanceLowSpeed > 0.1 | pn.speed > 2.0 | startCounter < 50)
                {

                    //determine fix positions and heading
                    fixPosX = (pn.easting);
                    fixPosZ = (pn.northing);

                    //save a copy to calc distance 
                    prevLowSpeedEasting = pn.easting;
                    prevLowSpeedNorthing = pn.northing;

                    //in radians
                    fixHeading = Math.Atan2(pn.easting - prevEasting[delayFixPrev], pn.northing - prevNorthing[delayFixPrev]);
                    if (fixHeading < 0) fixHeading += glm.twoPI;

                    //translate world to the pivot axle
                    pivotAxleEasting = pn.easting - (Math.Sin(fixHeading) * vehicle.antennaPivot);
                    pivotAxleNorthing = pn.northing - (Math.Cos(fixHeading) * vehicle.antennaPivot);

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

                        //calculate the final tool position
                        double over = Math.PI - Math.Abs(Math.Abs(fixHeadingSection - fixHeading) - Math.PI);

                        if (over < 1.8)
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

                    if (isDrawVehicleTrack)
                    {
                        //Point where the GPS antenna is.
                        CPointData pd = new CPointData(pn.easting, pn.northing);
                        pointAntenna.Add(pd);

                        ////center of pivoting axle
                        //CPointData pdP = new CPointData(pivotAxleEasting, pivotAxleNorthing);
                        //pointPivot.Add(pdP);

                        //////Center of hitch
                        ////CPointData pdA = new CPointData(hitchEasting, hitchNorthing);
                        ////pointHitch.Add(pdA);

                        ////center of implement
                        //CPointData pdI = new CPointData(toolEasting, toolNorthing);
                        //pointTool.Add(pdI);
                    }

                    //in degrees for glRotate opengl methods.
                    fixHeadingCam = Math.Atan2(pn.easting - prevEasting[delayCameraPrev], pn.northing - prevNorthing[delayCameraPrev]);
                    if (fixHeadingCam < 0) fixHeadingCam += glm.twoPI;

                    //used to increase triangle count when going aroud corners.
                    deltaFix = (Math.PI - Math.Abs(Math.Abs(fixHeadingCam - fixHeading) - Math.PI))*7.0;
                    if (deltaFix > 0.75) deltaFix = 0.75;
                    deltaFix = 1.0 - deltaFix;

                    //to degrees for openGL camera
                    fixHeadingCam = glm.degrees(fixHeadingCam);

                    //check to make sure the grid is big enough
                    worldGrid.checkZoomWorldGrid(pn.northing, pn.easting);

                    //precalc the sin and cos of heading * -1
                    sinHeading = Math.Sin(-fixHeadingSection);
                    cosHeading = Math.Cos(-fixHeadingSection);

                    //calc distance travelled since last GPS fix
                    distance = pn.Distance(pn.northing, pn.easting, prevNorthing[0], prevEasting[0]);

                    //To prevent drawing high numbers of triangles, determine and test before drawing vertex
                    sectionTriggerDistance = pn.Distance(toolNorthing, toolEasting, prevSectionNorthing, prevSectionEasting);

                    //speed compensated min length limit triangles. The faster you go, the less of them
                    if (sectionTriggerDistance > (pn.speed * deltaFix*0.5 + 0.5))
                    {
                        if (isJobStarted)//add the pathpoint
                        {
                            //save the north & east as previous
                            prevSectionNorthing = toolNorthing;
                            prevSectionEasting = toolEasting;

                            //send the current and previous GPS fore/aft corrected fix to each section
                            for (int j = 0; j < vehicle.numberOfSections; j++)
                            {
                                if (section[j].isSectionOn)
                                {
                                    section[j].AddPathPoint(toolNorthing, toolEasting, cosHeading, sinHeading);
                                    totalSquareMeters += sectionTriggerDistance * section[j].sectionWidth;
                                }//area is made up of square meters in each section
                            }
                        }
                    }

                    totalDistance += distance; //distance tally                   
                    userDistance += distance;//userDistance can be reset

                    //save a copy of previous positions for cam heading of desired filtering or delay
                    for (int x = numPrevs - 1; x > 0; x--) { prevNorthing[x] = prevNorthing[x - 1]; prevEasting[x] = prevEasting[x - 1]; }

                    //most recent fixes
                    prevEasting[0] = pn.easting; prevNorthing[0] = pn.northing;
                }
            }
            // there hasn't been a sentence for while
            else if (recvCounter > 16) textBoxRcv.Text = "************  NO GGA or RMC **************";
        }//end of UppdateFixPosition

    }//end class
}//end namespace