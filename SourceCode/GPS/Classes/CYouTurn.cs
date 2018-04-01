using SharpGL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace AgOpenGPS
{
    public class CYouTurn
    {
        //copy of the mainform address
        private readonly FormGPS mf;

        private readonly OpenGL gl;
        private readonly OpenGL glb;

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
        public bool isYouTurnRight, isLastToggle;

        /// <summary> /// What was the last successful you turn direction? /// </summary>
        public bool isLastYouTurnRight;

        /// <summary>/// triggered right after youTurnTriggerPoint is set /// </summary>
        public bool isYouTurnTriggered, isSequenceTriggered;

        /// <summary> /// is the start trigger point 45m from headland set? /// </summary>
        public bool isYouTurnTriggerPointSet;

        /// <summary>  /// The point 45 m from headland that starts everything  /// </summary>
        public vec3 youTurnTriggerPoint = new vec3(0, 0, 0);

        //if not in workArea but in bounds, then we are on headland
        public bool isInWorkArea, isInBoundz, isInHeadland;

        /// <summary> /// At trigger point, was vehicle going same direction as ABLine? /// </summary>
        public bool isABLineSameAsHeadingAtTrigger;

        //controlled by user in GUI to en/dis able
        public bool isRecordingCustomYouTurn;

        /// <summary> /// Is the youturn button enabled? /// </summary>
        public bool isYouTurnBtnOn;

        //
        public bool isUsingDubinsTurn;

        //Dew Loop turn 2 -> 2R,3L,2L,2R,3R,2L
        public bool isDew2Set, isDew2Right;
        public int dew2Index;
        public int[] dew2Skips = new int[] { 2, 3, 2, 2, 3, 2 };
        public bool[] dew2Direction = new bool[] { true, false, false, true, true, false };

        public bool isDew4Set;
        public int dew4Index;
        public int[] dew4Skips = new int[] { 3, 4, 3, 3, 4, 3, 4, 2 };
        public bool[] dew4Direction = new bool[] { true, false, false, true, true, true, true, false };

        public int rowSkipsWidth = 1, rowSkipsHeight = 1, lastTime = 3;

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
        public vec3 pivot = new vec3(0, 0, 0);

        public vec2 goalPointYT = new vec2(0, 0);
        public vec2 radiusPointYT = new vec2(0, 0);
        public double steerAngleYT;
        public double rEastYT, rNorthYT;

        public double ppRadiusYT;
        private int numShapePoints;

        //list of points for scaled and rotated YouTurn line
        public List<vec3> ytList = new List<vec3>();

        //list of points read from file, this is the actual pattern from a bunch of sources possible
        public List<vec2> youFileList = new List<vec2>();

        //constructor
        public CYouTurn(OpenGL _gl, OpenGL _glb, FormGPS _f)
        {
            mf = _f;
            gl = _gl;
            glb = _glb;

            //how far before or after boundary line should turn happen
            youTurnStartOffset = Properties.Vehicle.Default.set_youStartYouTurnAt;

            //the youturn shape scaling.
            rowSkipsHeight = Properties.Vehicle.Default.set_youSkipHeight;
            rowSkipsWidth = Properties.Vehicle.Default.set_youSkipWidth;

            isUsingDubinsTurn = Properties.Vehicle.Default.set_youUseDubins;

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

        //called when the 25 m mark is reached before headland
        public void YouTurnTrigger()
        {
            //trigger pulled and make box double ended
            isYouTurnTriggered = true;
            isSequenceTriggered = true;

            //our direction heading into turn
            if (mf.ABLine.isABLineSet) isABLineSameAsHeadingAtTrigger = mf.ABLine.isABSameAsFixHeading;
            else isABLineSameAsHeadingAtTrigger = mf.curve.isSameWay;

            //data buffer for pixels read from off screen buffer
            byte[] grnPix = new byte[401];

            //read a pixel line across full buffer width
            glb.ReadPixels(0, 205, 399, 1, OpenGL.GL_GREEN, OpenGL.GL_UNSIGNED_BYTE, grnPix);

            //set up the positions to scan in the array for applied
            int leftPos = mf.vehicle.rpXPosition - 15;
            if (leftPos < 0) leftPos = 0;
            int rightPos = mf.vehicle.rpXPosition + mf.vehicle.rpWidth + 15;
            if (rightPos > 399) rightPos = 399;

            //do we need a left or right turn
            bool isGrnOnLeft = false, isGrnOnRight = false;

            //green on left means turn right
            for (int j = leftPos; j < mf.vehicle.rpXPosition; j++)
            { isGrnOnLeft = grnPix[j] > 50; }

            //green on right means turn left
            for (int j = (rightPos - 10); j < rightPos; j++)
            { isGrnOnRight = grnPix[j] > 50; }

            //set point and save to start measuring from
            isYouTurnTriggerPointSet = true;
            youTurnTriggerPoint = mf.pivotAxlePos;

            //one side or the other - but not both Exclusive Or
            if (isGrnOnLeft ^ isGrnOnRight)
            {
                isYouTurnRight = !isGrnOnRight;
            }
            else //can't determine which way to turn, so pick opposite of last turn
            {
                //just do the opposite of last turn
                isYouTurnRight = !isLastYouTurnRight;
                isLastYouTurnRight = !isLastYouTurnRight;
            }

            if (mf.yt.isDew2Set)
            {
                bool dir = true;
                if (isDew2Right) dir = dew2Direction[dew2Index];
                else dir = !dew2Direction[dew2Index];

                if (dir)
                {
                    isYouTurnRight = true;
                    isLastYouTurnRight = !isYouTurnRight;
                }
                else
                {
                    isYouTurnRight = false;
                    isLastYouTurnRight = !isYouTurnRight;
                }

                //reset index counter if done turns
            }

            if (mf.yt.isDew4Set)
            {
                bool dir = true;
                if (isDew2Right) dir = dew4Direction[dew4Index];
                else dir = !dew4Direction[dew4Index];

                if (dir)
                {
                    isYouTurnRight = true;
                    isLastYouTurnRight = !isYouTurnRight;
                }
                else
                {
                    isYouTurnRight = false;
                    isLastYouTurnRight = !isYouTurnRight;
                }

                //reset index counter if done turns
            }

            //modify the buttons to show the correct turn direction
            if (isYouTurnRight) mf.AutoYouTurnButtonsRightTurn();
            else mf.AutoYouTurnButtonsLeftTurn();
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

#pragma warning disable CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception

                //Subtract the two headings, if > 1.57 its going the opposite heading as refAB
                double headAB;
                if (mf.ABLine.isABLineSet)
                {
                    double abFixHeadingDelta = (Math.Abs(mf.toolPos.heading - mf.ABLine.abHeading));
                    if (abFixHeadingDelta >= Math.PI) abFixHeadingDelta = Math.Abs(abFixHeadingDelta - glm.twoPI);
                    isToolHeadingSameAsABHeading = (abFixHeadingDelta <= glm.PIBy2);
                    headAB = mf.ABLine.abHeading;
                }
                else  //AB Curve
                {
                    //Subtract the two headings, if > 1.57 its going the opposite heading as refAB
                    double abFixHeadingDelta = (Math.Abs(mf.toolPos.heading - mf.curve.refHeading));
                    if (abFixHeadingDelta >= Math.PI) abFixHeadingDelta = Math.Abs(abFixHeadingDelta - glm.twoPI);
                    isToolHeadingSameAsABHeading = (abFixHeadingDelta <= glm.PIBy2);
                    headAB = mf.curve.refHeading;
                }

                if (!isToolHeadingSameAsABHeading) headAB += Math.PI;

                mf.hl.FindClosestHeadlandPoint(mf.toolPos, headAB);
                if ((int)mf.hl.closestHeadlandPt.easting != -1)
                {
                    mf.distTool = glm.Distance(mf.toolPos, mf.hl.closestHeadlandPt);
#pragma warning restore CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception
                }
                else //we've lost the headland
                {
                    mf.yt.isSequenceTriggered = false;
                    mf.yt.ResetSequenceEventTriggers();
                    mf.distTool = -3333;
                    return;
                }

                //make distance sign correct
                if (isInHeadland) mf.distTool *= -1;
                mf.distTool += (mf.headlandDistanceDelta * 0.5);

                //since same as AB Line, we are entering
                if (isABLineSameAsHeadingAtTrigger == isToolHeadingSameAsABHeading) whereAmI = 1;

                //since opposite of AB Line at trigger we are exiting
                else whereAmI = 2;

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
                    mf.distTool = -2222;
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

                    case 2: //Exiting the headland

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

            CDubins dubYouTurnPath = new CDubins();
            CDubins.turningRadius = mf.vehicle.minTurningRadius;

            double delta;
            //point on AB line closest to pivot axle point from ABLine PurePursuit
            if (mf.ABLine.isABLineSet)
            {
                rEastYT = mf.ABLine.rEastAB;
                rNorthYT = mf.ABLine.rNorthAB;
                isABSameAsFixHeading = mf.ABLine.isABSameAsFixHeading;
                abHeading = mf.ABLine.abHeading;
                delta = 1;
            }
            else
            {
                rEastYT = mf.curve.rEastCu;
                rNorthYT = mf.curve.rNorthCu;
                isABSameAsFixHeading = mf.curve.isSameWay;
                abHeading = mf.curve.refHeading;
                delta = mf.curve.deltaOfRefAndAveHeadings;
            }

            //grab the vehicle widths and offsets
            double widthMinusOverlap = mf.vehicle.toolWidth - mf.vehicle.toolOverlap;
            double toolOffset = mf.vehicle.toolOffset * 2.0;
            double turnOffset = 0;

            //turning right
            if (isTurnRight) turnOffset = (widthMinusOverlap + toolOffset);
            else turnOffset = (widthMinusOverlap - toolOffset);

            //to compensate for AB Curve overlap
            turnOffset *= delta;

            //if using dubins to calculate youturn
            if (isUsingDubinsTurn)
            {
                int skips = 0;
                double head = abHeading;

                //if its straight across it makes 2 loops instead so goal is a little lower then start
                if (!isABSameAsFixHeading) head += 3.14;
                else head -= 0.01;

                var start = new vec3(rEastYT, rNorthYT, head);
                var goal = new vec3();

                head -= Math.PI;
                if (head < 0) head += glm.twoPI;

                //also adjust for rowskips if Dew loops are set
                if (isDew2Set|isDew4Set)
                {

                    if (isDew2Set)
                    {
                        skips = dew2Skips[dew2Index];

                        //if at end of turn, restart sequence
                        dew2Index++;
                        if (dew2Index >= dew2Skips.Length) dew2Index = 0;
                    }

                    if (isDew4Set)
                    {
                        skips = dew4Skips[dew4Index];

                        //if at end of turn, restart sequence
                        dew4Index++;
                        if (dew4Index >= dew4Skips.Length) dew4Index = 0;
                    }
                }
                else
                {
                    skips = rowSkipsWidth;
                }

                //calculate the turn
                if (isTurnRight)
                {
                    goal.easting = rEastYT - (Math.Cos(-head) * turnOffset * skips);
                    goal.northing = rNorthYT - (Math.Sin(-head) * turnOffset * skips);
                    goal.heading = head;
                }
                else
                {
                    goal.easting = rEastYT + (Math.Cos(-head) * turnOffset * skips);
                    goal.northing = rNorthYT + (Math.Sin(-head) * turnOffset * skips);
                    goal.heading = head;
                }

                //generate the turn points
                ytList = dubYouTurnPath.GenerateDubins(start, goal);
            }

            //or the patterns
            else
            {
                numShapePoints = youFileList.Count;
                vec3[] pt = new vec3[numShapePoints];

                //Now put the shape into an array since lists are immutable
                for (int i = 0; i < numShapePoints; i++)
                {
                    pt[i].easting = youFileList[i].easting;
                    pt[i].northing = youFileList[i].northing;
                }

                //start of path on the origin. Mirror the shape if left turn
                if (!isTurnRight)
                {
                    for (int i = 0; i < pt.Length; i++) pt[i].easting *= -1;
                }

                //scaling - Drawing is 10m wide so find ratio of tool width
                double scale = turnOffset * 0.1;
                for (int i = 0; i < pt.Length; i++)
                {
                    pt[i].easting *= scale * rowSkipsWidth;
                    pt[i].northing *= scale * rowSkipsWidth;
                }

                //rotate pattern to match AB Line heading
                for (int i = 0; i < pt.Length; i++)
                {
                    double xr, yr;
                    if (isABSameAsFixHeading)
                    {
                        xr = (Math.Cos(-abHeading) * pt[i].easting) - (Math.Sin(-abHeading) * pt[i].northing);
                        yr = (Math.Sin(-abHeading) * pt[i].easting) + (Math.Cos(-abHeading) * pt[i].northing);
                    }
                    else
                    {
                        xr = (Math.Cos(-abHeading + Math.PI) * pt[i].easting) - (Math.Sin(-abHeading + Math.PI) * pt[i].northing);
                        yr = (Math.Sin(-abHeading + Math.PI) * pt[i].easting) + (Math.Cos(-abHeading + Math.PI) * pt[i].northing);
                    }

                    pt[i].easting = xr + rEastYT;
                    pt[i].northing = yr + rNorthYT;
                    pt[i].heading = Math.Atan2(pt[i].northing, pt[i].easting);
                    ytList.Add(pt[i]);
                }
            }
        }

        //determine distance from youTurn guidance line
        public void DistanceFromYouTurnLine()
        {
            //grab a copy from main
            pivot = mf.pivotAxlePos;
            double minDistA = 1000000, minDistB = 1000000;
            int ptCount = ytList.Count;

            if (ptCount > 0)
            {
                //find the closest 2 points to current fix
                for (int t = 0; t < ptCount; t++)
                {
                    double dist = ((pivot.easting - ytList[t].easting) * (pivot.easting - ytList[t].easting))
                                    + ((pivot.northing - ytList[t].northing) * (pivot.northing - ytList[t].northing));
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
                double dx = ytList[B].easting - ytList[A].easting;
                double dz = ytList[B].northing - ytList[A].northing;
                if (Math.Abs(dx) < Double.Epsilon && Math.Abs(dz) < Double.Epsilon) return;

                //abHeading = Math.Atan2(dz, dx);
                abHeading = ytList[A].heading;

                //how far from current AB Line is fix
                distanceFromCurrentLine = ((dz * pivot.easting) - (dx * pivot.northing) + (ytList[B].easting
                            * ytList[A].northing) - (ytList[B].northing * ytList[A].easting))
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
                double U = (((pivot.easting - ytList[A].easting) * (dx))
                            + ((pivot.northing - ytList[A].northing) * (dz)))
                            / ((dx * dx) + (dz * dz));

                rEastYT = ytList[A].easting + (U * (dx));
                rNorthYT = ytList[A].northing + (U * (dz));

                //used for accumulating distance to find goal point
                double distSoFar;

                //how far should goal point be away  - speed * seconds * kmph -> m/s + min value
                double goalPointDistance = mf.pn.speed * mf.vehicle.goalPointLookAhead * 0.27777777;

                //minimum of Whatever AB Line is meters look ahead
                if (goalPointDistance < mf.vehicle.minLookAheadDistance) goalPointDistance = mf.vehicle.minLookAheadDistance;

                // used for calculating the length squared of next segment.
                double tempDist = 0.0;

                isABSameAsFixHeading = true;
                distSoFar = glm.Distance(ytList[B], rEastYT, rNorthYT);

                //Is this segment long enough to contain the full lookahead distance?
                if (distSoFar > goalPointDistance)
                {
                    //treat current segment like an AB Line
                    goalPointYT.easting = rEastYT + (Math.Sin(ytList[A].heading) * goalPointDistance);
                    goalPointYT.northing = rNorthYT + (Math.Cos(ytList[A].heading) * goalPointDistance);
                }

                //multiple segments required
                else
                {
                    //cycle thru segments and keep adding lengths. check if end and break if so.
                    // ReSharper disable once LoopVariableIsNeverChangedInsideLoop
                    while (B < ptCount - 1)
                    {
                        B++; A++;
                        tempDist = glm.Distance(ytList[B], ytList[A]);
                        if ((tempDist + distSoFar) > goalPointDistance) break; //will we go too far?
                        distSoFar += tempDist;
                    }

                    double t = (goalPointDistance - distSoFar); // the remainder to yet travel
                    t /= tempDist;
                    goalPointYT.easting = (((1 - t) * ytList[A].easting) + (t * ytList[B].easting));
                    goalPointYT.northing = (((1 - t) * ytList[A].northing) + (t * ytList[B].northing));
                }

                //calc "D" the distance from pivot axle to lookahead point
                double goalPointDistanceSquared = glm.DistanceSquared(goalPointYT.northing, goalPointYT.easting, pivot.northing, pivot.easting);

                //calculate the the delta x in local coordinates and steering angle degrees based on wheelbase
                double localHeading = glm.twoPI - mf.fixHeading;
                ppRadiusYT = goalPointDistanceSquared / (2 * (((goalPointYT.easting - pivot.easting) * Math.Cos(localHeading)) + ((goalPointYT.northing - pivot.northing) * Math.Sin(localHeading))));

                steerAngleYT = glm.toDegrees(Math.Atan(2 * (((goalPointYT.easting - pivot.easting) * Math.Cos(localHeading))
                    + ((goalPointYT.northing - pivot.northing) * Math.Sin(localHeading))) * mf.vehicle.wheelbase / goalPointDistanceSquared));

                if (steerAngleYT < -mf.vehicle.maxSteerAngle) steerAngleYT = -mf.vehicle.maxSteerAngle;
                if (steerAngleYT > mf.vehicle.maxSteerAngle) steerAngleYT = mf.vehicle.maxSteerAngle;

                if (ppRadiusYT < -500) ppRadiusYT = -500;
                if (ppRadiusYT > 500) ppRadiusYT = 500;

                radiusPointYT.easting = pivot.easting + (ppRadiusYT * Math.Cos(localHeading));
                radiusPointYT.northing = pivot.northing + (ppRadiusYT * Math.Sin(localHeading));

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
                mf.guidanceLineSteerAngle = (Int16)(steerAngleYT * 100);
            }
            else
            {
                CompleteYouTurn();
            }
        }
    }
}