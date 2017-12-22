using System;
using System.Collections.Generic;
using SharpGL;
using System.IO;
using System.Globalization;

namespace AgOpenGPS
{
    public class CYouTurn
    {
        //copy of the mainform address
        private readonly FormGPS mf;
        private readonly OpenGL gl;

        /// <summary> /// Has the you turn shape been built and displayed? /// </summary>
        public bool isYouTurnShapeDisplayed;

        public string pos1 = "Manual Button";
        public string pos2 = "Auto Button";
        public string pos3 = "";
        public string pos4 = "";
        public string pos5 = "";
        public string pos6 = "";
        public string pos7 = "";
        public string pos8 = "";

        /// <summary>  /// turning right or left?/// </summary>
        public bool isYouTurnRight;

        /// <summary> /// What was the last successful you turn direction? /// </summary>
        public bool isLastYouTurnRight;

        /// <summary>/// triggered right after youTurnTriggerPoint is set /// </summary>
        public bool isYouTurnTriggered, isSequenceTriggered;

        /// <summary> /// is the start trigger point 45m from headland set? /// </summary>
        public bool isYouTurnTriggerPointSet;

        /// <summary>  /// The point 45 m from headland that starts everything  /// </summary>
        public vec2 youTurnTriggerPoint = new vec2(0, 0);

        //if not in workArea but in bounds, then we are on headland
        public bool isInWorkArea, isInBoundz, isInHeadland;

        /// <summary> /// At trigger point, was vehicle going same direction as ABLine? /// </summary>        
        public bool isABLineSameAsHeadingAtTrigger;

        //controlled by user in GUI to en/dis able
        public bool isRecordingCustomYouTurn;

        /// <summary> /// Is the youturn button enabled? /// </summary>
        public bool isYouTurnBtnOn;

        public int rowSkipsWidth = 1, rowSkipsHeight = 1;

        /// <summary>  /// distance from headland as offset where to start turn shape /// </summary>
        public int youTurnStartOffset;

        /// <summary> /// 0=Not in youturn, 1=Entering headland, 2=Exiting headland /// </summary>
        public int whereAmI = 0;

        //guidance values
        public double distanceFromCurrentLine;
        public double dxAB, dyAB;
        private int A, B, C;
        public double abHeading;
        private bool isABSameAsFixHeading = true;
        public bool isOnRightSideCurrentLine = true;

        //pure pursuit values
        public vec2 pivotAxlePosYT = new vec2(0, 0);
        public vec2 goalPointYT = new vec2(0, 0);
        public vec2 radiusPointYT = new vec2(0, 0);
        public double steerAngleYT;
        public double rEastYT, rNorthYT;
        public double ppRadiusYT;
        private double minLookAheadDistance;
        private int numShapePoints;

        //list of points for scaled and rotated YouTurn line
        public List<vec4> ytList = new List<vec4>();

        //list of points read from file, this is the actual pattern from a bunch of sources possible
        public List<vec2> youFileList = new List<vec2>();

        //constructor
        public CYouTurn(OpenGL _gl, FormGPS _f)
        {
            mf = _f;
            gl = _gl;

            //how far before or after boundary line should turn happen
            youTurnStartOffset = Properties.Vehicle.Default.set_youStartYouTurnAt;

            //the youturn shape scaling.
            rowSkipsHeight = Properties.Vehicle.Default.set_youSkipHeight;
            rowSkipsWidth = Properties.Vehicle.Default.set_youSkipWidth;

            //Fill in the strings for comboboxes - editable
            string line = Properties.Vehicle.Default.seq_FunctionList;
            string[] words = line.Split(',');

            pos3 = words[0];
            pos4 = words[1];
            pos5 = words[2];
            pos6 = words[3];
            pos7 = words[4];
            pos8 = words[5];

        }

        //Normal copmpletion of youturn
        public void CompleteYouTurn()
        {
            isYouTurnShapeDisplayed = false;
            isYouTurnTriggered = false;
            isYouTurnTriggerPointSet = false;
            if (ytList.Count > 0) ytList.Clear();
            mf.AutoYouTurnButtonsReset();
        }

        //something went seriously wrong so reset everything
        public void ResetYouTurnAndSequenceEvents()
        {
            //fix you turn
            isYouTurnShapeDisplayed = false;
            isYouTurnTriggered = false;
            isYouTurnTriggerPointSet = false;
            if (ytList.Count > 0) ytList.Clear();
            mf.AutoYouTurnButtonsReset();
            mf.youTurnProgressBar = 0;

            //reset sequence
            isSequenceTriggered = false;
            whereAmI = 0;
            ResetSequenceEventTriggers();
        }

        //reset trig flag to false on all array elements with a function
        public void ResetSequenceEventTriggers()
        {
            for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
            {
                if (mf.seq.seqEnter[i].function != 0) mf.seq.seqEnter[i].isTrig = false;
                if (mf.seq.seqExit[i].function != 0) mf.seq.seqExit[i].isTrig = false;
            }
        }

        //determine when if and how functions are triggered
        public void DoSequenceEvent()
        {
            if (mf.yt.isSequenceTriggered)
            {
                //determine if Section is entry or exit based on trigger point direction
                bool isToolHeadingSameAsABHeading;

                //Subtract the two headings, if > 1.57 its going the opposite heading as refAB
                double abFixHeadingDelta = (Math.Abs(mf.fixHeadingSection - mf.ABLine.abHeading));
                if (abFixHeadingDelta >= Math.PI) abFixHeadingDelta = Math.Abs(abFixHeadingDelta - glm.twoPI);

                if (abFixHeadingDelta >= glm.PIBy2) isToolHeadingSameAsABHeading = false;
                else isToolHeadingSameAsABHeading = true;

                mf.hl.FindClosestHeadlandPoint(mf.toolPos);
                if ((int)mf.hl.closestHeadlandPt.easting != -1)
                    mf.distTool = mf.pn.Distance(mf.toolPos.northing, mf.toolPos.easting,
                        mf.hl.closestHeadlandPt.northing, mf.hl.closestHeadlandPt.easting);
                else //we've lost the headland
                {
                    mf.yt.isSequenceTriggered = false;
                    mf.yt.ResetSequenceEventTriggers();
                    mf.distTool = 999;
                    return;
                }



                if (isABLineSameAsHeadingAtTrigger == isToolHeadingSameAsABHeading)
                {
                    //since same as AB Line, we are entering
                    whereAmI = 1;
                    if (isInHeadland) mf.distTool *= -1;
                }
                else
                {
                    //since opposite of AB Line at trigger we are exiting
                    whereAmI = 2;
                    if (isInHeadland) mf.distTool *= -1;
                }

                //did we do all the events?
                int c = 0;
                for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
                {
                    //checked for any not triggered yet (false) - if there is, not done yet
                    if (!mf.seq.seqEnter[i].isTrig) c++;
                    if (!mf.seq.seqExit[i].isTrig) c++;
                }

                if (c == 0)
                {
                    //sequences all done so reset everything
                    isSequenceTriggered = false;
                    whereAmI = 0;
                    ResetSequenceEventTriggers();
                }

                switch (whereAmI)
                {
                    case 0: //not in you turn
                        break;

                    case 1: //Entering the headland

                        for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
                        {
                            //have we gone past the distance and still haven't done it
                            if (mf.distTool < mf.seq.seqEnter[i].distance && !mf.seq.seqEnter[i].isTrig)
                            {
                                //it shall only run once
                                mf.seq.seqEnter[i].isTrig = true;

                                //send the function and action to perform
                                mf.DoYouTurnSequenceEvent(mf.seq.seqEnter[i].function, mf.seq.seqEnter[i].action);
                            }
                        }
                        break;

                    case 2: //Leaving the headland

                        for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
                        {
                            //have we gone past the distance and still haven't done it
                            if (mf.distTool > mf.seq.seqExit[i].distance && !mf.seq.seqExit[i].isTrig)
                            {
                                //it shall only run once
                                mf.seq.seqExit[i].isTrig = true;

                                //send the function and action to perform
                                mf.DoYouTurnSequenceEvent(mf.seq.seqExit[i].function, mf.seq.seqExit[i].action);
                            }
                        }
                        break;
                }
            }
        }

        //get list of points from txt shape file
        public void LoadYouTurnShapeFromFile(string filename)
        {
            //if there is existing shape, delete it
            if (youFileList.Count > 0) youFileList.Clear();

            if (!File.Exists(filename))
            {
                var form = new FormTimedMessage(4000, "Missing Youturn File", "Fix the thing!");
                form.Show();
            }
            else
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    try
                    {
                        string line = reader.ReadLine();
                        int points = int.Parse(line);

                        if (points > 0)
                        {
                            vec2 coords = new vec2();
                            for (int v = 0; v < points; v++)
                            {
                                line = reader.ReadLine();
                                string[] words = line.Split(',');

                                coords.easting = double.Parse(words[0], CultureInfo.InvariantCulture);
                                coords.northing = double.Parse(words[1], CultureInfo.InvariantCulture);
                                youFileList.Add(coords);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        var form = new FormTimedMessage(4000, "Flag File is Corrupt", "But Field is Loaded");
                        form.Show();
                        mf.WriteErrorLog("FieldOpen, Loading Flags, Corrupt Flag File" + e);
                    }
                }
            }
        }

        //build the points and path of youturn to be scaled and transformed
        public void BuildYouTurnListToRight(bool isTurnRight)
        {
            isYouTurnShapeDisplayed = true;

            //grab the Lookahead that ABLine uses
            minLookAheadDistance = mf.ABLine.minLookAheadDistance;

            //point on AB line closest to pivot axle point from ABLine PurePursuit
            rEastYT = mf.ABLine.rEastAB;
            rNorthYT = mf.ABLine.rNorthAB;
            isABSameAsFixHeading = mf.ABLine.isABSameAsFixHeading;
            pivotAxlePosYT = mf.pivotAxlePos;

            //grab the vehicle widths and offsets
            double widthMinusOverlap = mf.vehicle.toolWidth - mf.vehicle.toolOverlap;
            double toolOffset = mf.vehicle.toolOffset * 2.0;
            double turnOffset = 0;
            abHeading = mf.ABLine.abHeading;

            //turning right same as AB line
            if ((isTurnRight && isABSameAsFixHeading) || (isTurnRight && !isABSameAsFixHeading))
            {
                turnOffset = (widthMinusOverlap + toolOffset);
            }

            //turning left same way as AB line
            if ((!isTurnRight && isABSameAsFixHeading) || (!isTurnRight && !isABSameAsFixHeading))
            {
                turnOffset = (widthMinusOverlap - toolOffset);
            }

            numShapePoints = youFileList.Count;
            vec4[] pt = new vec4[numShapePoints];

            //Now put the shape into an array since lists are immutable
            for (int i = 0; i < numShapePoints; i++)
            {
                pt[i].x = youFileList[i].easting;
                pt[i].z = youFileList[i].northing;
            }

            //for (int i = 0; i < pt.Length; i++)
            //{
            //    bool started = false;
            //    if (pt[i].x >= 5.0)
            //    {
            //        if (!started) started = true;

            //        //create a line of 10 points
            //        pt[i].x += ((rowSkipsWidth - 1) * 10);
            //    }
            //}

            //start of path on the origin. Mirror the shape if left turn
            if (!isTurnRight)
            {
                for (int i = 0; i < pt.Length; i++) pt[i].x *= -1;
            }

            //scaling - Drawing is 10m wide so find ratio of tool width
            double scale = turnOffset * 0.1;
            for (int i = 0; i < pt.Length; i++)
            {
                pt[i].x *= scale*rowSkipsWidth;
                pt[i].z *= scale*rowSkipsHeight;
            }

            //rotate pattern to match AB Line heading
            for (int i = 0; i < pt.Length; i++)
            {
                double xr, yr;
                if (isABSameAsFixHeading)
                {
                    xr = (Math.Cos(-abHeading) * pt[i].x) - (Math.Sin(-abHeading) * pt[i].z);
                    yr = (Math.Sin(-abHeading) * pt[i].x) + (Math.Cos(-abHeading) * pt[i].z);
                }
                else
                {
                    xr = (Math.Cos(-abHeading+Math.PI) * pt[i].x) - (Math.Sin(-abHeading+Math.PI) * pt[i].z);
                    yr = (Math.Sin(-abHeading+Math.PI) * pt[i].x) + (Math.Cos(-abHeading+Math.PI) * pt[i].z);
                }

                pt[i].x = xr+rEastYT;
                pt[i].z = yr+rNorthYT;
                pt[i].k = 0;
                pt[i].y = Math.Atan2(pt[i].z, pt[i].x);
                ytList.Add(pt[i]);
            }
        }

        //determine distance from youTurn guidance line
        public void DistanceFromYouTurnLine()
        {
            //grab a copy from main
            pivotAxlePosYT = mf.pivotAxlePos;
            double minDistA = 1000000, minDistB = 1000000;
            int ptCount = ytList.Count;

            if (ptCount > 0)
            {
                //find the closest 2 points to current fix
                for (int t = 0; t < ptCount; t++)
                {
                    double dist = ((pivotAxlePosYT.easting - ytList[t].x) * (pivotAxlePosYT.easting - ytList[t].x))
                                    + ((pivotAxlePosYT.northing - ytList[t].z) * (pivotAxlePosYT.northing - ytList[t].z));
                    if (dist < minDistA)
                    {
                        minDistB = minDistA;
                        B = A;
                        minDistA = dist;
                        A = t;
                    }
                    else if (dist < minDistB)
                    {
                        minDistB = dist;
                        B = t;
                    }
                }

                //just need to make sure the points continue ascending or heading switches all over the place
                if (A > B) { C = A; A = B; B = C; }

                //get the distance from currently active AB line                
                double dx = ytList[B].x - ytList[A].x;
                double dz = ytList[B].z - ytList[A].z;
                if (Math.Abs(dx) < Double.Epsilon && Math.Abs(dz) < Double.Epsilon) return;

                //abHeading = Math.Atan2(dz, dx);
                abHeading = ytList[A].y;

                //how far from current AB Line is fix
                distanceFromCurrentLine = ((dz * mf.pn.easting) - (dx * mf.pn.northing) + (ytList[B].x
                            * ytList[A].z) - (ytList[B].z * ytList[A].x))
                                / Math.Sqrt((dz * dz) + (dx * dx));

                //are we on the right side or not
                isOnRightSideCurrentLine = distanceFromCurrentLine > 0;

                //absolute the distance
                distanceFromCurrentLine = Math.Abs(distanceFromCurrentLine);

                //return and reset if too far away or end of the line
                if (distanceFromCurrentLine > 5 || B >= ptCount - 3)
                {
                    CompleteYouTurn();
                    return;
                }

                // ** Pure pursuit ** - calc point on ABLine closest to current position      
                double U = (((pivotAxlePosYT.easting - ytList[A].x) * (dx))
                            + ((pivotAxlePosYT.northing - ytList[A].z) * (dz)))
                            / ((dx * dx) + (dz * dz));

                rEastYT = ytList[A].x + (U * (dx));
                rNorthYT = ytList[A].z + (U * (dz));

                //used for accumulating distance to find goal point
                double distSoFar;

                //how far should goal point be away  - speed * seconds * kmph -> m/s + min value
                double goalPointDistance = mf.pn.speed * mf.vehicle.goalPointLookAhead * 0.27777777;

                //minimum of Whatever AB Line is meters look ahead
                if (goalPointDistance < minLookAheadDistance) goalPointDistance = minLookAheadDistance;

                // used for calculating the length squared of next segment.
                double tempDist = 0.0;

                isABSameAsFixHeading = true;
                distSoFar = mf.pn.Distance(ytList[B].z, ytList[B].x, rNorthYT, rEastYT);

                //Is this segment long enough to contain the full lookahead distance?
                if (distSoFar > goalPointDistance)
                {
                    //treat current segment like an AB Line
                    goalPointYT.easting = rEastYT + (Math.Sin(ytList[A].y) * goalPointDistance);
                    goalPointYT.northing = rNorthYT + (Math.Cos(ytList[A].y) * goalPointDistance);
                }

                //multiple segments required
                else
                {
                    //cycle thru segments and keep adding lengths. check if end and break if so.
                    // ReSharper disable once LoopVariableIsNeverChangedInsideLoop
                    while (B < ptCount - 1)
                    {
                        B++; A++;
                        tempDist = mf.pn.Distance(ytList[B].z, ytList[B].x, ytList[A].z, ytList[A].x);
                        if ((tempDist + distSoFar) > goalPointDistance) break; //will we go too far?
                        distSoFar += tempDist;
                    }

                    double t = (goalPointDistance - distSoFar); // the remainder to yet travel
                    t /= tempDist;
                    goalPointYT.easting = (((1 - t) * ytList[A].x) + (t * ytList[B].x));
                    goalPointYT.northing = (((1 - t) * ytList[A].z) + (t * ytList[B].z));
                }

                //calc "D" the distance from pivot axle to lookahead point
                double goalPointDistanceSquared = mf.pn.DistanceSquared(goalPointYT.northing, goalPointYT.easting, pivotAxlePosYT.northing, pivotAxlePosYT.easting);

                //calculate the the delta x in local coordinates and steering angle degrees based on wheelbase
                double localHeading = glm.twoPI - mf.fixHeading;
                ppRadiusYT = goalPointDistanceSquared / (2 * (((goalPointYT.easting - pivotAxlePosYT.easting) * Math.Cos(localHeading)) + ((goalPointYT.northing - pivotAxlePosYT.northing) * Math.Sin(localHeading))));

                steerAngleYT = glm.toDegrees(Math.Atan(2 * (((goalPointYT.easting - pivotAxlePosYT.easting) * Math.Cos(localHeading))
                    + ((goalPointYT.northing - pivotAxlePosYT.northing) * Math.Sin(localHeading))) * mf.vehicle.wheelbase / goalPointDistanceSquared));

                if (steerAngleYT < -mf.vehicle.maxSteerAngle) steerAngleYT = -mf.vehicle.maxSteerAngle;
                if (steerAngleYT > mf.vehicle.maxSteerAngle) steerAngleYT = mf.vehicle.maxSteerAngle;

                if (ppRadiusYT < -500) ppRadiusYT = -500;
                if (ppRadiusYT > 500) ppRadiusYT = 500;

                radiusPointYT.easting = pivotAxlePosYT.easting + (ppRadiusYT * Math.Cos(localHeading));
                radiusPointYT.northing = pivotAxlePosYT.northing + (ppRadiusYT * Math.Sin(localHeading));

                //angular velocity in rads/sec  = 2PI * m/sec * radians/meters
                double angVel = glm.twoPI * 0.277777 * mf.pn.speed * (Math.Tan(glm.toRadians(steerAngleYT))) / mf.vehicle.wheelbase;

                //clamp the steering angle to not exceed safe angular velocity
                if (Math.Abs(angVel) > mf.vehicle.maxAngularVelocity)
                {
                    steerAngleYT = glm.toDegrees(steerAngleYT > 0 ?
                            (Math.Atan((mf.vehicle.wheelbase * mf.vehicle.maxAngularVelocity) / (glm.twoPI * mf.pn.speed * 0.277777)))
                        : (Math.Atan((mf.vehicle.wheelbase * -mf.vehicle.maxAngularVelocity) / (glm.twoPI * mf.pn.speed * 0.277777))));
                }
                //Convert to centimeters
                distanceFromCurrentLine = Math.Round(distanceFromCurrentLine * 1000.0, MidpointRounding.AwayFromZero);

                //distance is negative if on left, positive if on right
                //if you're going the opposite direction left is right and right is left
                if (isABSameAsFixHeading)
                {
                    if (!isOnRightSideCurrentLine) distanceFromCurrentLine *= -1.0;
                }

                //opposite way so right is left
                else
                {
                    if (isOnRightSideCurrentLine) distanceFromCurrentLine *= -1.0;
                }

                mf.guidanceLineDistanceOff = (Int16)distanceFromCurrentLine;
                mf.guidanceLineSteerAngle = (Int16)(steerAngleYT * 10);
            }
            else
            {
                CompleteYouTurn();
            }
        }
    }
}
