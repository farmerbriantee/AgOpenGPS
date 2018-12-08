using OpenTK.Graphics.OpenGL;
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

        /// <summary> /// Has the you turn shape been built and displayed? /// </summary>
        public bool isYouTurnShapeDisplayed;

        /// <summary>  /// turning right or left?/// </summary>
        public bool isYouTurnRight, isLastToggle;

        /// <summary> /// What was the last successful you turn direction? /// </summary>
        public bool isLastYouTurnRight;

        /// <summary>/// triggered right after youTurnTriggerPoint is set /// </summary>
        public bool isYouTurnTriggered;

        public bool isEnteringDriveThru = false, isExitingDriveThru = false;

        /// <summary> /// is the start trigger point 45m from headland set? /// </summary>
        public bool isYouTurnTriggerPointSet;

        //if not in workArea but in bounds, then we are on headland
        public bool isInWorkArea, isInBoundz;

        /// <summary> /// At trigger point, was vehicle going same direction as ABLine? /// </summary>
        public bool isABLineSameAsHeadingAtTrigger;

        //controlled by user in GUI to en/dis able
        public bool isRecordingCustomYouTurn;

        /// <summary> /// Is the youturn button enabled? /// </summary>
        public bool isYouTurnBtnOn;

        //Patterns or Dubins
        public bool isUsingDubinsTurn;

        public double boundaryAngleOffPerpendicular;
        public double distanceTurnBeforeLine = 0, tangencyAngle, distanceCrossLineCalc;

        //Dew Loop turn 2 -> 2R,3L,2L,2R,3R,2L
        public bool isDew2Set, isDew2Right, isDew4Set;

        public int dew2Index, dew4Index;
        public int[] dew2Skips = new int[] { 2, 3, 2, 2, 3, 2 };
        public bool[] dew2Direction = new bool[] { true, false, false, true, true, false };
        public int[] dew4Skips = new int[] { 3, 4, 3, 3, 4, 3, 4, 2 };
        public bool[] dew4Direction = new bool[] { true, false, false, true, true, true, true, false };
        public int rowSkipsWidth = 1, rowSkipsHeight = 1, lastTime = 3;

        /// <summary>  /// distance from headland as offset where to start turn shape /// </summary>
        public int youTurnStartOffset;

        //guidance values
        public double distanceFromCurrentLine, triggerDistanceOffset, dxAB, dyAB;

        private int A, B, C;
        private bool isABSameAsFixHeading = true, isOnRightSideCurrentLine = true, isTurnCreationTooClose = false;

        //pure pursuit values
        public vec3 pivot = new vec3(0, 0, 0);

        public vec2 goalPointYT = new vec2(0, 0);
        public vec2 radiusPointYT = new vec2(0, 0);
        public double steerAngleYT, rEastYT, rNorthYT, ppRadiusYT;
        private int numShapePoints;

        //list of points for scaled and rotated YouTurn line, used for pattern, dubins, abcurve, abline
        public List<vec3> ytList = new List<vec3>();

        //list of points read from file, this is the actual pattern from a bunch of sources possible
        public List<vec2> youFileList = new List<vec2>();

        //to try and pull a UTurn back in bounds
        public double turnDistanceAdjuster;

        //is UTurn pattern in or out of bounds
        public bool isOutOfBounds = false;

        //sequence of operations of finding the next turn 0 to 3
        public int youTurnPhase, curListCount;

        public vec4 crossingCurvePoint = new vec4();
        public vec4 crossingTurnLinePoint = new vec4();

        //constructor
        public CYouTurn(FormGPS _f)
        {
            mf = _f;

            triggerDistanceOffset = Properties.Vehicle.Default.set_youTriggerDistance;

            //how far before or after boundary line should turn happen
            youTurnStartOffset = Properties.Vehicle.Default.set_youStartYouTurnAt;

            //the youturn shape scaling.
            //rowSkipsHeight = Properties.Vehicle.Default.set_youSkipHeight;
            rowSkipsWidth = Properties.Vehicle.Default.set_youSkipWidth;

            isUsingDubinsTurn = Properties.Vehicle.Default.set_youUseDubins;
        }

        //Finds the point where an AB Curve crosses the turn line
        public bool FindCurveTurnPoints()
        {
            crossingCurvePoint.easting = -20000;
            crossingTurnLinePoint.easting = -20000;

            //find closet AB Curve point that will cross and go out of bounds
            curListCount = mf.curve.curList.Count;

            //otherwise we count down
            bool isCountingUp = mf.curve.isABSameAsVehicleHeading;

            //check if outside a border
            if (isCountingUp)
            {
                //for each point in succession keep going till a turnLine is found.
                for (int j = mf.curve.currentLocationIndex; j < curListCount; j++)
                {
                    if (!mf.turn.turnArr[0].IsPointInsideTurn(mf.curve.curList[j]))
                    {                                        //it passed outer turnLine
                        crossingCurvePoint.easting = mf.curve.curList[j - 1].easting;
                        crossingCurvePoint.northing = mf.curve.curList[j - 1].northing;
                        crossingCurvePoint.heading = mf.curve.curList[j - 1].heading;
                        crossingCurvePoint.index = j - 1;
                        crossingTurnLinePoint.index = 0;
                        goto CrossingFound;
                    }

                    for (int i = 1; i < FormGPS.MAXBOUNDARIES; i++)
                    {
                        //make sure not inside a non drivethru boundary
                        if (!mf.bnd.bndArr[i].isSet) continue;
                        if (mf.bnd.bndArr[i].isDriveThru) continue;
                        if (mf.turn.turnArr[i].IsPointInsideTurn(mf.curve.curList[j]))
                        {
                            crossingCurvePoint.easting = mf.curve.curList[j - 1].easting;
                            crossingCurvePoint.northing = mf.curve.curList[j - 1].northing;
                            crossingCurvePoint.heading = mf.curve.curList[j - 1].heading;
                            crossingCurvePoint.index = j - 1;
                            crossingTurnLinePoint.index = i;
                            goto CrossingFound;
                        }
                    }
                }

                //escape for multiple for's
                CrossingFound:;
            }
            else //counting down, going opposite way mf.curve was created.
            {
                for (int j = mf.curve.currentLocationIndex; j > 0; j--)
                {
                    if (!mf.turn.turnArr[0].IsPointInsideTurn(mf.curve.curList[j]))
                    {                                        //it passed outer turnLine
                        crossingCurvePoint.easting = mf.curve.curList[j + 1].easting;
                        crossingCurvePoint.northing = mf.curve.curList[j + 1].northing;
                        crossingCurvePoint.heading = mf.curve.curList[j + 1].heading;
                        crossingCurvePoint.index = j + 1;
                        crossingTurnLinePoint.index = 0;
                        goto CrossingFound;
                    }

                    for (int i = 1; i < FormGPS.MAXBOUNDARIES; i++)
                    {
                        //make sure not inside a non drivethru boundary
                        if (!mf.bnd.bndArr[i].isSet) continue;
                        if (mf.bnd.bndArr[i].isDriveThru) continue;
                        if (mf.turn.turnArr[i].IsPointInsideTurn(mf.curve.curList[j]))
                        {
                            crossingCurvePoint.easting = mf.curve.curList[j].easting;
                            crossingCurvePoint.northing = mf.curve.curList[j].northing;
                            crossingCurvePoint.heading = mf.curve.curList[j].heading;
                            crossingCurvePoint.index = j;
                            crossingTurnLinePoint.index = i;
                            goto CrossingFound;
                        }
                    }
                }

                //escape for multiple for's, point and turnLine index are found
                CrossingFound:;
            }

            int turnNum = crossingTurnLinePoint.index;
            int curTurnLineCount = mf.turn.turnArr[turnNum].turnLine.Count;

            //possible points close to AB Curve point
            List<int> turnLineCloseList = new List<int>();

            for (int j = 0; j < curTurnLineCount; j++)
            {
                if ((mf.turn.turnArr[turnNum].turnLine[j].easting - crossingCurvePoint.easting) < 2
                    && (mf.turn.turnArr[turnNum].turnLine[j].easting - crossingCurvePoint.easting) > -2
                    && (mf.turn.turnArr[turnNum].turnLine[j].northing - crossingCurvePoint.northing) < 2
                    && (mf.turn.turnArr[turnNum].turnLine[j].northing - crossingCurvePoint.northing) > -2)
                {
                    turnLineCloseList.Add(j);
                }
            }

            double dist1, dist2 = 99;
            curTurnLineCount = turnLineCloseList.Count;
            for (int i = 0; i < curTurnLineCount; i++)
            {
                dist1 = glm.Distance(mf.turn.turnArr[turnNum].turnLine[turnLineCloseList[i]].easting,
                                        mf.turn.turnArr[turnNum].turnLine[turnLineCloseList[i]].northing,
                                            crossingCurvePoint.easting, crossingCurvePoint.northing);
                if (dist1 < dist2)
                {
                    crossingTurnLinePoint.index = turnLineCloseList[i];
                    dist2 = dist1;
                }
            }

            //fill up the coords
            crossingTurnLinePoint.easting = mf.turn.turnArr[turnNum].turnLine[crossingTurnLinePoint.index].easting;
            crossingTurnLinePoint.northing = mf.turn.turnArr[turnNum].turnLine[crossingTurnLinePoint.index].northing;
            crossingTurnLinePoint.heading = mf.turn.turnArr[turnNum].turnLine[crossingTurnLinePoint.index].heading;

            return crossingCurvePoint.easting != -20000 && crossingCurvePoint.easting != -20000;
        }

        //while waiting to turn this runs making sure the UTurn isn't out of bounds, and builds it.
        public bool BuildABLineDubinsYouTurn(bool isTurnRight)
        {
            double headAB = mf.ABLine.abHeading;
            if (!mf.ABLine.isABSameAsVehicleHeading) headAB += Math.PI;

            //grab the pure pursuit point right on ABLine
            vec3 onPurePoint = new vec3(mf.ABLine.rEastAB, mf.ABLine.rNorthAB, 0);

            //how far are we from any turn boundary
            mf.turn.FindClosestTurnPoint(isYouTurnRight, onPurePoint, headAB);

            //or did we lose the turnLine - we are on the highway cuz we left the outer/inner turn boundary
            if ((int)mf.turn.closestTurnPt.easting != -20000)
            {
                mf.distancePivotToTurnLine = glm.Distance(mf.pivotAxlePos, mf.turn.closestTurnPt);
            }
            else
            {
                //Full emergency stop code goes here, it thinks its auto turn, but its not!
                mf.distancePivotToTurnLine = -3333;
            }

            //delta between AB heading and boundary closest point heading
            boundaryAngleOffPerpendicular = Math.PI - Math.Abs(Math.Abs(mf.turn.closestTurnPt.heading - headAB) - Math.PI);
            boundaryAngleOffPerpendicular -= glm.PIBy2;
            boundaryAngleOffPerpendicular *= -1;
            if (boundaryAngleOffPerpendicular > 1.25) boundaryAngleOffPerpendicular = 1.25;
            if (boundaryAngleOffPerpendicular < -1.25) boundaryAngleOffPerpendicular = -1.25;

            //for calculating innner circles of turn
            tangencyAngle = (glm.PIBy2 - Math.Abs(boundaryAngleOffPerpendicular)) * 0.5;

            //baseline away from boundary to start calculations
            double toolTurnWidth = mf.vehicle.toolWidth * rowSkipsWidth;

            //distance from TurnLine for trigger added in youturn form, include the 3 m bump forward
            distanceTurnBeforeLine = 3.0 + turnDistanceAdjuster;
            distanceCrossLineCalc = distanceTurnBeforeLine;

            if (mf.vehicle.minTurningRadius * 2 < toolTurnWidth)
            {
                if (boundaryAngleOffPerpendicular < 0)
                {
                    //which is actually left
                    if (isYouTurnRight)
                        distanceTurnBeforeLine += (mf.vehicle.minTurningRadius * Math.Tan(tangencyAngle));//short
                    else
                        distanceTurnBeforeLine += (mf.vehicle.minTurningRadius / Math.Tan(tangencyAngle)); //long
                }
                else
                {
                    //which is actually left
                    if (isYouTurnRight)
                        distanceTurnBeforeLine += (mf.vehicle.minTurningRadius / Math.Tan(tangencyAngle)); //long
                    else
                        distanceTurnBeforeLine += (mf.vehicle.minTurningRadius * Math.Tan(tangencyAngle)); //short
                }
            }
            else //turn Radius is wider then equipment width so ohmega turn
            {
                distanceTurnBeforeLine += (2 * mf.vehicle.minTurningRadius);
            }

            //used for distance calc for other part of turn
            distanceCrossLineCalc = distanceTurnBeforeLine - distanceCrossLineCalc;

            CDubins dubYouTurnPath = new CDubins();
            CDubins.turningRadius = mf.vehicle.minTurningRadius;

            //point on AB line closest to pivot axle point from ABLine PurePursuit
            rEastYT = mf.ABLine.rEastAB;
            rNorthYT = mf.ABLine.rNorthAB;
            isABSameAsFixHeading = mf.ABLine.isABSameAsVehicleHeading;
            double head = mf.ABLine.abHeading;

            //grab the vehicle widths and offsets
            double widthMinusOverlap = mf.vehicle.toolWidth - mf.vehicle.toolOverlap;
            double toolOffset = mf.vehicle.toolOffset * 2.0;
            double turnOffset = 0;

            //turning right
            if (isTurnRight) turnOffset = (widthMinusOverlap + toolOffset);
            else turnOffset = (widthMinusOverlap - toolOffset);

            double turnRadius = turnOffset / Math.Cos(boundaryAngleOffPerpendicular);
            if (!isABSameAsFixHeading) head += Math.PI;

            double turnDiagDistance = mf.distancePivotToTurnLine - distanceTurnBeforeLine;

            //move the start forward 2 meters
            if (youTurnPhase < 2)
            {
                rEastYT += (Math.Sin(head) * turnDiagDistance);
                rNorthYT += (Math.Cos(head) * turnDiagDistance);
            }
            else
            {
                turnDistanceAdjuster += 5;
                rEastYT += (Math.Sin(head) * (turnDiagDistance - 2));
                rNorthYT += (Math.Cos(head) * (turnDiagDistance - 2));
                youTurnPhase = 3;
            }

            var start = new vec3(rEastYT, rNorthYT, head);
            var goal = new vec3();

            turnRadius *= rowSkipsWidth;
            turnOffset *= rowSkipsWidth;

            //move the cross line calc to not include first turn
            goal.easting = rEastYT + (Math.Sin(head) * distanceCrossLineCalc);
            goal.northing = rNorthYT + (Math.Cos(head) * distanceCrossLineCalc);

            //headland angle relative to vehicle heading to head along the boundary left or right
            double bndAngle = head - boundaryAngleOffPerpendicular + glm.PIBy2;

            //now we go the other way to turn round
            head -= Math.PI;
            if (head < 0) head += glm.twoPI;

            if ((mf.vehicle.minTurningRadius * 2.0) < turnOffset)
            {
                //are we right of boundary
                if (boundaryAngleOffPerpendicular > 0)
                {
                    if (!isYouTurnRight) //which is actually right now
                    {
                        goal.easting += (Math.Sin(bndAngle) * turnRadius);
                        goal.northing += (Math.Cos(bndAngle) * turnRadius);

                        double dis = (mf.vehicle.minTurningRadius / Math.Tan(tangencyAngle)); //long
                        goal.easting += (Math.Sin(head) * dis);
                        goal.northing += (Math.Cos(head) * dis);
                    }
                    else //going left
                    {
                        goal.easting -= (Math.Sin(bndAngle) * turnRadius);
                        goal.northing -= (Math.Cos(bndAngle) * turnRadius);

                        double dis = (mf.vehicle.minTurningRadius * Math.Tan(tangencyAngle)); //short
                        goal.easting += (Math.Sin(head) * dis);
                        goal.northing += (Math.Cos(head) * dis);
                    }
                }
                else // going left of boundary
                {
                    if (!isYouTurnRight) //pointing to right
                    {
                        goal.easting += (Math.Sin(bndAngle) * turnRadius);
                        goal.northing += (Math.Cos(bndAngle) * turnRadius);

                        double dis = (mf.vehicle.minTurningRadius * Math.Tan(tangencyAngle)); //short
                        goal.easting += (Math.Sin(head) * dis);
                        goal.northing += (Math.Cos(head) * dis);
                    }
                    else
                    {
                        goal.easting -= (Math.Sin(bndAngle) * turnRadius);
                        goal.northing -= (Math.Cos(bndAngle) * turnRadius);

                        double dis = (mf.vehicle.minTurningRadius / Math.Tan(tangencyAngle)); //long
                        goal.easting += (Math.Sin(head) * dis);
                        goal.northing += (Math.Cos(head) * dis);
                    }
                }
            }
            else
            {
                if (!isTurnRight)
                {
                    goal.easting = rEastYT - (Math.Cos(-head) * turnOffset);
                    goal.northing = rNorthYT - (Math.Sin(-head) * turnOffset);
                }
                else
                {
                    goal.easting = rEastYT + (Math.Cos(-head) * turnOffset);
                    goal.northing = rNorthYT + (Math.Sin(-head) * turnOffset);
                }
            }

            goal.heading = head;

            //generate the turn points
            ytList = dubYouTurnPath.GenerateDubins(start, goal);
            vec3 pt = new vec3();

            int count = ytList.Count;
            if (count == 0) return false;

            pt.easting = ytList[0].easting + (Math.Sin(head) * 4);
            pt.northing = ytList[0].northing + (Math.Cos(head) * 4);
            pt.heading = ytList[0].heading;

            ytList.Insert(0, pt);

            // Phase 0 - back up the turn till it is out of bounds.
            // Phase 1 - move it forward till out of bounds.
            // Phase 2 - move forward couple meters away from turn line.
            // Phase 3 - ytList is made, waiting to get close enough to it

            isOutOfBounds = false;
            switch (youTurnPhase)
            {
                case 0:
                    turnDistanceAdjuster -= 2;
                    for (int j = 0; j < count;)
                    {
                        if (!mf.turn.turnArr[0].IsPointInsideTurn(ytList[j])) isOutOfBounds = true;
                        if (isOutOfBounds) break;

                        for (int i = 1; i < FormGPS.MAXBOUNDARIES; i++)
                        {
                            //make sure not inside a non drivethru boundary
                            if (!mf.bnd.bndArr[i].isSet) continue;
                            if (mf.bnd.bndArr[i].isDriveThru) continue;
                            if (mf.turn.turnArr[i].IsPointInsideTurn(ytList[j]))
                            {
                                isOutOfBounds = true;
                                break;
                            }
                        }
                        if (isOutOfBounds) break;
                        j += 20;
                    }

                    if (isOutOfBounds) youTurnPhase = 1;
                    break;

                case 1:
                    for (int j = 0; j < count;)
                    {
                        if (!mf.turn.turnArr[0].IsPointInsideTurn(ytList[j])) isOutOfBounds = true;
                        if (isOutOfBounds) break;

                        for (int i = 1; i < FormGPS.MAXBOUNDARIES; i++)
                        {
                            //make sure not inside a non drivethru boundary
                            if (!mf.bnd.bndArr[i].isSet) continue;
                            if (mf.bnd.bndArr[i].isDriveThru) continue;
                            if (mf.turn.turnArr[i].IsPointInsideTurn(ytList[j]))
                            {
                                isOutOfBounds = true;
                                break;
                            }
                        }
                        if (isOutOfBounds) break;
                        j += 5;
                    }

                    if (!isOutOfBounds)
                    {
                        youTurnPhase = 2;
                    }
                    else
                    {
                        //turn keeps approaching vehicle and running out of space - end of field?
                        if (isOutOfBounds && turnDiagDistance > 3)
                        {
                            turnDistanceAdjuster += 2;
                            isTurnCreationTooClose = false;
                        }
                        else
                        {
                            isTurnCreationTooClose = true;

                            //set the flag to Critical stop machine
                            if (isTurnCreationTooClose) mf.mc.isOutOfBounds = true;
                        }
                    }
                    break;
            }
            return true;
        }

        public bool BuildABLinePatternYouTurn(bool isTurnRight)
        {
            double headAB = mf.ABLine.abHeading;
            if (!mf.ABLine.isABSameAsVehicleHeading) headAB += Math.PI;

            //grab the pure pursuit point right on ABLine
            vec3 onPurePoint = new vec3(mf.ABLine.rEastAB, mf.ABLine.rNorthAB, 0);

            //how far are we from any turn boundary
            mf.turn.FindClosestTurnPoint(isYouTurnRight, onPurePoint, headAB);

            //or did we lose the turnLine - we are on the highway cuz we left the outer/inner turn boundary
            if ((int)mf.turn.closestTurnPt.easting != -20000)
            {
                mf.distancePivotToTurnLine = glm.Distance(mf.pivotAxlePos, mf.turn.closestTurnPt);
            }
            else
            {
                //Full emergency stop code goes here, it thinks its auto turn, but its not!
                mf.distancePivotToTurnLine = -3333;
            }

            distanceTurnBeforeLine = turnDistanceAdjuster;

            ytList.Clear();

            //point on AB line closest to pivot axle point from ABLine PurePursuit
            rEastYT = mf.ABLine.rEastAB;
            rNorthYT = mf.ABLine.rNorthAB;
            isABSameAsFixHeading = mf.ABLine.isABSameAsVehicleHeading;
            double head = mf.ABLine.abHeading;

            //grab the vehicle widths and offsets
            double widthMinusOverlap = mf.vehicle.toolWidth - mf.vehicle.toolOverlap;
            double toolOffset = mf.vehicle.toolOffset * 2.0;
            double turnOffset = 0;

            //turning right
            if (isTurnRight) turnOffset = (widthMinusOverlap + toolOffset);
            else turnOffset = (widthMinusOverlap - toolOffset);

            //Pattern Turn
            numShapePoints = youFileList.Count;
            vec3[] pt = new vec3[numShapePoints];

            //Now put the shape into an array since lists are immutable
            for (int i = 0; i < numShapePoints; i++)
            {
                pt[i].easting = youFileList[i].easting;
                pt[i].northing = youFileList[i].northing;
            }

            //start of path on the origin. Mirror the shape if left turn
            if (isTurnRight)
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

            if (!isABSameAsFixHeading) head += Math.PI;

            double _turnDiagDistance = mf.distancePivotToTurnLine - distanceTurnBeforeLine;

            //move the start forward
            if (youTurnPhase < 2)
            {
                rEastYT += (Math.Sin(head) * (_turnDiagDistance - turnOffset));
                rNorthYT += (Math.Cos(head) * (_turnDiagDistance - turnOffset));
            }
            else
            {
                _turnDiagDistance -= 2;
                turnDistanceAdjuster += 5;
                rEastYT += (Math.Sin(head) * (_turnDiagDistance - turnOffset));
                rNorthYT += (Math.Cos(head) * (_turnDiagDistance - turnOffset));
                youTurnPhase = 3;
            }

            //rotate pattern to match AB Line heading
            for (int i = 0; i < pt.Length; i++)
            {
                double xr, yr;
                xr = (Math.Cos(-head) * pt[i].easting) - (Math.Sin(-head) * pt[i].northing);
                yr = (Math.Sin(-head) * pt[i].easting) + (Math.Cos(-head) * pt[i].northing);

                pt[i].easting = xr + rEastYT;
                pt[i].northing = yr + rNorthYT;
                pt[i].heading = Math.Atan2(pt[i].northing, pt[i].easting);
                ytList.Add(pt[i]);
            }

            //pattern all made now is it outside a boundary

            //now check to make sure we are not in an inner turn boundary - drive thru is ok
            int count = ytList.Count;
            if (count == 0) return true;

            isOutOfBounds = false;

            // Phase 0 - back up the turn till it is out of bounds.
            // Phase 1 - move it forward till out of bounds.
            // Phase 2 - move forward couple meters away from turn line.

            switch (youTurnPhase)
            {
                case 0:
                    //if (turnDiagnosticAdjuster == 0) turnDiagnosticAdjuster = turnRadius;
                    turnDistanceAdjuster -= 2;
                    for (int j = 0; j < count;)
                    {
                        if (!mf.turn.turnArr[0].IsPointInsideTurn(ytList[j])) isOutOfBounds = true;
                        if (isOutOfBounds) break;

                        for (int i = 1; i < FormGPS.MAXBOUNDARIES; i++)
                        {
                            //make sure not inside a non drivethru boundary
                            if (!mf.bnd.bndArr[i].isSet) continue;
                            if (mf.bnd.bndArr[i].isDriveThru) continue;
                            if (mf.turn.turnArr[i].IsPointInsideTurn(ytList[j]))
                            {
                                isOutOfBounds = true;
                                break;
                            }
                        }
                        if (isOutOfBounds) break;
                        j += 20;
                    }

                    if (isOutOfBounds) youTurnPhase = 1;
                    break;

                case 1:
                    for (int j = 0; j < count;)
                    {
                        if (!mf.turn.turnArr[0].IsPointInsideTurn(ytList[j])) isOutOfBounds = true;
                        if (isOutOfBounds) break;

                        for (int i = 1; i < FormGPS.MAXBOUNDARIES; i++)
                        {
                            //make sure not inside a non drivethru boundary
                            if (!mf.bnd.bndArr[i].isSet) continue;
                            if (mf.bnd.bndArr[i].isDriveThru) continue;
                            if (mf.turn.turnArr[i].IsPointInsideTurn(ytList[j]))
                            {
                                isOutOfBounds = true;
                                break;
                            }
                        }
                        if (isOutOfBounds) break;
                        j += 5;
                    }

                    if (!isOutOfBounds)
                    {
                        youTurnPhase = 2;
                    }
                    else
                    {
                        //turn keeps approaching vehicle and running out of space - end of field?
                        if (isOutOfBounds && _turnDiagDistance > 3)
                        {
                            turnDistanceAdjuster += 2;
                            isTurnCreationTooClose = false;
                        }
                        else
                        {
                            isTurnCreationTooClose = true;

                            //set the flag to Critical stop machine
                            if (isTurnCreationTooClose) mf.mc.isOutOfBounds = true;
                            break;
                        }
                    }
                    break;
            }

            return isOutOfBounds;
        }

        public bool BuildCurvePatternYouTurn(bool isTurnRight, vec3 pivotPos)
        {
            if (youTurnPhase > 0)
            {
                ytList.Clear();
                double delta = mf.curve.deltaOfRefAndAveHeadings;

                double head = crossingCurvePoint.heading;
                if (!mf.curve.isABSameAsVehicleHeading) head += Math.PI;

                //are we going same way as creation of curve
                bool isCountingUp = mf.curve.isABSameAsVehicleHeading;

                //grab the vehicle widths and offsets
                double widthMinusOverlap = mf.vehicle.toolWidth - mf.vehicle.toolOverlap;
                double toolOffset = mf.vehicle.toolOffset * 2.0;
                double turnOffset = 0;

                //turning right
                if (isTurnRight) turnOffset = (widthMinusOverlap + toolOffset);
                else turnOffset = (widthMinusOverlap - toolOffset);

                //to compensate for AB Curve overlap
                turnOffset *= delta;

                //Pattern Turn
                numShapePoints = youFileList.Count;
                vec3[] pt = new vec3[numShapePoints];

                //Now put the shape into an array since lists are immutable
                for (int i = 0; i < numShapePoints; i++)
                {
                    pt[i].easting = youFileList[i].easting;
                    pt[i].northing = youFileList[i].northing;
                }

                //start of path on the origin. Mirror the shape if left turn
                if (isTurnRight)
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
                    xr = (Math.Cos(-head) * pt[i].easting) - (Math.Sin(-head) * pt[i].northing);
                    yr = (Math.Sin(-head) * pt[i].easting) + (Math.Cos(-head) * pt[i].northing);

                    pt[i].easting = xr + crossingCurvePoint.easting;
                    pt[i].northing = yr + crossingCurvePoint.northing;
                    pt[i].heading = Math.Atan2(pt[i].northing, pt[i].easting);
                    ytList.Add(pt[i]);
                }

                //pattern all made now is it outside a boundary
            }

            switch (youTurnPhase)
            {
                case 0: //find the crossing points
                    if (FindCurveTurnPoints()) youTurnPhase = 1;
                    else mf.mc.isOutOfBounds = true;
                    ytList?.Clear();
                    break;

                case 1:
                    //now check to make sure turn is not in an inner turn boundary - drive thru is ok
                    int count = ytList.Count;
                    if (count == 0) return false;
                    isOutOfBounds = false;

                    //Out of bounds?
                    for (int j = 0; j < count;)
                    {
                        if (!mf.turn.turnArr[0].IsPointInsideTurn(ytList[j])) isOutOfBounds = true;
                        if (isOutOfBounds) break;

                        for (int i = 1; i < FormGPS.MAXBOUNDARIES; i++)
                        {
                            //make sure not inside a non drivethru boundary
                            if (!mf.bnd.bndArr[i].isSet) continue;
                            if (mf.bnd.bndArr[i].isDriveThru) continue;
                            if (mf.turn.turnArr[i].IsPointInsideTurn(ytList[j]))
                            {
                                isOutOfBounds = true;
                                break;
                            }
                        }
                        if (isOutOfBounds) break;
                        j += 5;
                    }

                    //first check if not out of bounds, add a bit more to clear turn line, set to phase 2
                    if (!isOutOfBounds)
                    {
                        youTurnPhase = 2;
                        if (mf.curve.isABSameAsVehicleHeading)
                        {
                            crossingCurvePoint.index -= 2;
                            if (crossingCurvePoint.index < 0) crossingCurvePoint.index = 0;
                        }
                        else
                        {
                            crossingCurvePoint.index += 2;
                            if (crossingCurvePoint.index >= curListCount)
                                crossingCurvePoint.index = curListCount - 1;
                        }

                        crossingCurvePoint.easting = mf.curve.curList[crossingCurvePoint.index].easting;
                        crossingCurvePoint.northing = mf.curve.curList[crossingCurvePoint.index].northing;
                        crossingCurvePoint.heading = mf.curve.curList[crossingCurvePoint.index].heading;
                        return true;
                    }

                    //keep moving infield till pattern is all inside
                    if (mf.curve.isABSameAsVehicleHeading)
                    {
                        crossingCurvePoint.index--;
                        if (crossingCurvePoint.index < 0) crossingCurvePoint.index = 0;
                    }
                    else
                    {
                        crossingCurvePoint.index++;
                        if (crossingCurvePoint.index >= curListCount)
                            crossingCurvePoint.index = curListCount - 1;
                    }

                    crossingCurvePoint.easting = mf.curve.curList[crossingCurvePoint.index].easting;
                    crossingCurvePoint.northing = mf.curve.curList[crossingCurvePoint.index].northing;
                    crossingCurvePoint.heading = mf.curve.curList[crossingCurvePoint.index].heading;

                    double tooClose = glm.Distance(ytList[0], pivotPos);
                    isTurnCreationTooClose = tooClose < 3;

                    //set the flag to Critical stop machine
                    if (isTurnCreationTooClose) mf.mc.isOutOfBounds = true;
                    break;

                case 2:
                    youTurnPhase = 3;
                    break;
            }
            return true;
        }

        public bool BuildCurveDubinsYouTurn(bool isTurnRight, vec3 pivotPos)
        {
            if (youTurnPhase > 0)
            {
                isABSameAsFixHeading = mf.curve.isSameWay;

                double head = crossingCurvePoint.heading;
                if (!isABSameAsFixHeading) head += Math.PI;
                double delta = mf.curve.deltaOfRefAndAveHeadings;

                //delta between AB heading and boundary closest point heading
                boundaryAngleOffPerpendicular = Math.PI - Math.Abs(Math.Abs(crossingTurnLinePoint.heading - head) - Math.PI);
                boundaryAngleOffPerpendicular -= glm.PIBy2;
                boundaryAngleOffPerpendicular *= -1;
                if (boundaryAngleOffPerpendicular > 1.25) boundaryAngleOffPerpendicular = 1.25;
                if (boundaryAngleOffPerpendicular < -1.25) boundaryAngleOffPerpendicular = -1.25;

                //for calculating innner circles of turn
                tangencyAngle = (glm.PIBy2 - Math.Abs(boundaryAngleOffPerpendicular)) * 0.5;

                //distance from crossPoint to turn line
                if (mf.vehicle.minTurningRadius * 2 < (mf.vehicle.toolWidth * rowSkipsWidth))
                {
                    if (boundaryAngleOffPerpendicular < 0)
                    {
                        //which is actually left
                        if (isYouTurnRight)
                            distanceTurnBeforeLine = (mf.vehicle.minTurningRadius * Math.Tan(tangencyAngle));//short
                        else
                            distanceTurnBeforeLine = (mf.vehicle.minTurningRadius / Math.Tan(tangencyAngle)); //long
                    }
                    else
                    {
                        //which is actually left
                        if (isYouTurnRight)
                            distanceTurnBeforeLine = (mf.vehicle.minTurningRadius / Math.Tan(tangencyAngle)); //long
                        else
                            distanceTurnBeforeLine = (mf.vehicle.minTurningRadius * Math.Tan(tangencyAngle)); //short
                    }
                }

                //turn Radius is wider then equipment width so ohmega turn
                else
                {
                    distanceTurnBeforeLine = (2 * mf.vehicle.minTurningRadius);
                }

                CDubins dubYouTurnPath = new CDubins();
                CDubins.turningRadius = mf.vehicle.minTurningRadius;

                //grab the vehicle widths and offsets
                double widthMinusOverlap = mf.vehicle.toolWidth - mf.vehicle.toolOverlap;
                double toolOffset = mf.vehicle.toolOffset * 2.0;
                double turnOffset = 0;

                //calculate the true width
                if (isTurnRight) turnOffset = (widthMinusOverlap + toolOffset);
                else turnOffset = (widthMinusOverlap - toolOffset);

                //to compensate for AB Curve overlap
                turnOffset *= delta;

                //diagonally across
                double turnRadius = turnOffset / Math.Cos(boundaryAngleOffPerpendicular);

                //start point of Dubins
                var start = new vec3(crossingCurvePoint.easting, crossingCurvePoint.northing, head);

                var goal = new vec3();
                turnRadius *= rowSkipsWidth;
                turnOffset *= rowSkipsWidth;

                //move the cross line calc to not include first turn
                goal.easting = crossingCurvePoint.easting + (Math.Sin(head) * distanceTurnBeforeLine);
                goal.northing = crossingCurvePoint.northing + (Math.Cos(head) * distanceTurnBeforeLine);

                //headland angle relative to vehicle heading to head along the boundary left or right
                double bndAngle = head - boundaryAngleOffPerpendicular + glm.PIBy2;

                //now we go the other way to turn round
                head -= Math.PI;
                if (head < 0) head += glm.twoPI;

                if ((mf.vehicle.minTurningRadius * 2.0) < turnOffset)
                {
                    //are we right of boundary
                    if (boundaryAngleOffPerpendicular > 0)
                    {
                        if (!isYouTurnRight) //which is actually right now
                        {
                            goal.easting += (Math.Sin(bndAngle) * turnRadius);
                            goal.northing += (Math.Cos(bndAngle) * turnRadius);

                            double dis = (mf.vehicle.minTurningRadius / Math.Tan(tangencyAngle)); //long
                            goal.easting += (Math.Sin(head) * dis);
                            goal.northing += (Math.Cos(head) * dis);
                        }
                        else //going left
                        {
                            goal.easting -= (Math.Sin(bndAngle) * turnRadius);
                            goal.northing -= (Math.Cos(bndAngle) * turnRadius);

                            double dis = (mf.vehicle.minTurningRadius * Math.Tan(tangencyAngle)); //short
                            goal.easting += (Math.Sin(head) * dis);
                            goal.northing += (Math.Cos(head) * dis);
                        }
                    }
                    else // going left of boundary
                    {
                        if (!isYouTurnRight) //pointing to right
                        {
                            goal.easting += (Math.Sin(bndAngle) * turnRadius);
                            goal.northing += (Math.Cos(bndAngle) * turnRadius);

                            double dis = (mf.vehicle.minTurningRadius * Math.Tan(tangencyAngle)); //short
                            goal.easting += (Math.Sin(head) * dis);
                            goal.northing += (Math.Cos(head) * dis);
                        }
                        else
                        {
                            goal.easting -= (Math.Sin(bndAngle) * turnRadius);
                            goal.northing -= (Math.Cos(bndAngle) * turnRadius);

                            double dis = (mf.vehicle.minTurningRadius / Math.Tan(tangencyAngle)); //long
                            goal.easting += (Math.Sin(head) * dis);
                            goal.northing += (Math.Cos(head) * dis);
                        }
                    }
                }
                else
                {
                    if (!isTurnRight)
                    {
                        goal.easting =  crossingCurvePoint.easting   - (Math.Cos(-head) * turnOffset);
                        goal.northing = crossingCurvePoint.northing - (Math.Sin(-head) * turnOffset);
                    }
                    else
                    {
                        goal.easting =  crossingCurvePoint.easting  + (Math.Cos(-head) * turnOffset);
                        goal.northing = crossingCurvePoint.northing + (Math.Sin(-head) * turnOffset);
                    }
                }

                goal.heading = head;

                //generate the turn points
                ytList = dubYouTurnPath.GenerateDubins(start, goal);
                int count = ytList.Count;
                if (count == 0) return false;
            }

            switch (youTurnPhase)
            {
                case 0: //find the crossing points
                    if (FindCurveTurnPoints()) youTurnPhase = 1;
                    ytList?.Clear();
                    break;

                case 1:
                    //now check to make sure we are not in an inner turn boundary - drive thru is ok
                    int count = ytList.Count;
                    if (count == 0) return false;

                    //Are we out of bounds?
                    isOutOfBounds = false;
                    for (int j = 0; j < count;)
                    {
                        if (!mf.turn.turnArr[0].IsPointInsideTurn(ytList[j]))
                        {
                            isOutOfBounds = true;
                            break;
                        }

                        for (int i = 1; i < FormGPS.MAXBOUNDARIES; i++)
                        {
                            //make sure not inside a non drivethru boundary
                            if (!mf.bnd.bndArr[i].isSet) continue;
                            if (mf.bnd.bndArr[i].isDriveThru) continue;
                            if (mf.turn.turnArr[i].IsPointInsideTurn(ytList[j]))
                            {
                                isOutOfBounds = true;
                                break;
                            }
                        }
                        if (isOutOfBounds) break;
                        j += 5;
                    }

                    //first check if not out of bounds, add a bit more to clear turn line, set to phase 2
                    if (!isOutOfBounds)
                    {
                        youTurnPhase = 2;
                        if (mf.curve.isABSameAsVehicleHeading)
                        {
                            crossingCurvePoint.index -= 2;
                            if (crossingCurvePoint.index < 0) crossingCurvePoint.index = 0;
                        }
                        else
                        {
                            crossingCurvePoint.index += 2;
                            if (crossingCurvePoint.index >= curListCount)
                                crossingCurvePoint.index = curListCount - 1;
                        }
                        crossingCurvePoint.easting = mf.curve.curList[crossingCurvePoint.index].easting;
                        crossingCurvePoint.northing = mf.curve.curList[crossingCurvePoint.index].northing;
                        crossingCurvePoint.heading = mf.curve.curList[crossingCurvePoint.index].heading;
                        return true;
                    }

                    //keep moving infield till pattern is all inside
                    if (mf.curve.isABSameAsVehicleHeading)
                    {
                        crossingCurvePoint.index --;
                        if (crossingCurvePoint.index < 0) crossingCurvePoint.index = 0;
                    }
                    else
                    {
                        crossingCurvePoint.index ++;
                        if (crossingCurvePoint.index >= curListCount)
                            crossingCurvePoint.index = curListCount - 1;
                    }
                    crossingCurvePoint.easting = mf.curve.curList[crossingCurvePoint.index].easting;
                    crossingCurvePoint.northing = mf.curve.curList[crossingCurvePoint.index].northing;
                    crossingCurvePoint.heading = mf.curve.curList[crossingCurvePoint.index].heading;

                    double tooClose = glm.Distance(ytList[0], pivotPos);
                    isTurnCreationTooClose = tooClose < 3;

                    //set the flag to Critical stop machine
                    if (isTurnCreationTooClose) mf.mc.isOutOfBounds = true;
                    break;

                case 2:
                    youTurnPhase = 3;
                    break;
            }
            return true;
        }

        //called to initiate turn
        public void YouTurnTrigger()
        {
            //trigger pulled and make box double ended
            isYouTurnTriggered = true;

            //our direction heading into turn
            if (mf.ABLine.isABLineSet) isABLineSameAsHeadingAtTrigger = mf.ABLine.isABSameAsVehicleHeading;
            else isABLineSameAsHeadingAtTrigger = mf.curve.isSameWay;

            //data buffer for pixels read from off screen buffer
            byte[] grnPix = new byte[501];

            //read a pixel line across full buffer width
            //glb.ReadPixels(0, 255, 499, 1, OpenGL.GL_GREEN, OpenGL.GL_UNSIGNED_BYTE, grnPix);
            GL.ReadPixels(0, 255, 499, 1, PixelFormat.Green, PixelType.UnsignedByte, grnPix);

            //set up the positions to scan in the array for applied
            int leftPos = mf.vehicle.rpXPosition - 15;
            if (leftPos < 0) leftPos = 0;
            int rightPos = mf.vehicle.rpXPosition + mf.vehicle.rpWidth + 15;
            if (rightPos > 499) rightPos = 499;

            //do we need a left or right turn
            bool isGrnOnLeft = false, isGrnOnRight = false;

            //green on left means turn right
            for (int j = leftPos; j < mf.vehicle.rpXPosition; j++)
            { isGrnOnLeft = grnPix[j] > 50; }

            //green on right means turn left
            for (int j = (rightPos - 10); j < rightPos; j++)
            { isGrnOnRight = grnPix[j] > 50; }

            //one side or the other - but not both Exclusive Or
            //if (isGrnOnLeft ^ isGrnOnRight)
            //{
            //    isYouTurnRight = !isGrnOnRight;
            //}
            //else //can't determine which way to turn, so pick opposite of last turn
            {
                //just do the opposite of last turn
                isYouTurnRight = !isLastYouTurnRight;
                isLastYouTurnRight = !isLastYouTurnRight;
            }

            //set point and save to start measuring from
            isYouTurnTriggerPointSet = true;

            if (isDew2Set) //Loops of 2,3 skips
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
            }

            if (mf.yt.isDew4Set) //Loops of 3,4 skips
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
            ResetCreatedYouTurn();
        }

        //something went seriously wrong so reset everything
        public void ResetYouTurn()
        {
            //fix you turn
            isYouTurnShapeDisplayed = false;
            isYouTurnTriggered = false;
            isYouTurnTriggerPointSet = false;
            ytList?.Clear();
            mf.AutoYouTurnButtonsReset();
            ResetCreatedYouTurn();
            turnDistanceAdjuster = 0;

            //reset sequence
            //isSequenceTriggered = false;
            //whereAmI = 0;
            //ResetSequenceEventTriggers();
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

        //Resets the drawn YOuTurn and set diagPhase to 0
        public void ResetCreatedYouTurn()
        {
            turnDistanceAdjuster = 0;
            youTurnPhase = 0;
            //isOutOfBounds = false;
            ytList?.Clear();
        }

        //build the points and path of youturn to be scaled and transformed
        public void BuildManualYouTurn(bool isTurnRight, bool isTurnButtonTriggered)
        {
            isYouTurnShapeDisplayed = true;

            double delta, head;
            //point on AB line closest to pivot axle point from ABLine PurePursuit
            if (mf.ABLine.isABLineSet)
            {
                rEastYT = mf.ABLine.rEastAB;
                rNorthYT = mf.ABLine.rNorthAB;
                isABSameAsFixHeading = mf.ABLine.isABSameAsVehicleHeading;
                head = mf.ABLine.abHeading;
                delta = 1;
            }
            else
            {
                rEastYT = mf.curve.rEastCu;
                rNorthYT = mf.curve.rNorthCu;
                isABSameAsFixHeading = mf.curve.isSameWay;
                head = mf.curve.refHeading;
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
            //if (isUsingDubinsTurn)
            {
                CDubins dubYouTurnPath = new CDubins();
                CDubins.turningRadius = mf.vehicle.minTurningRadius;

                //if its straight across it makes 2 loops instead so goal is a little lower then start
                if (!isABSameAsFixHeading) head += 3.14;
                else head -= 0.01;

                //move the start forward 3 meters
                rEastYT += (Math.Sin(head) * 3);
                rNorthYT += (Math.Cos(head) * 3);

                var start = new vec3(rEastYT, rNorthYT, head);
                var goal = new vec3();

                turnOffset *= rowSkipsWidth;

                //now we go the other way to turn round
                head -= Math.PI;
                if (head < 0) head += glm.twoPI;

                //set up the goal point for Dubins
                goal.heading = head;
                if (isTurnButtonTriggered)
                {
                    if (isTurnRight)
                    {
                        goal.easting = rEastYT - (Math.Cos(-head) * turnOffset);
                        goal.northing = rNorthYT - (Math.Sin(-head) * turnOffset);
                    }
                    else
                    {
                        goal.easting = rEastYT + (Math.Cos(-head) * turnOffset);
                        goal.northing = rNorthYT + (Math.Sin(-head) * turnOffset);
                    }
                }

                //generate the turn points
                ytList = dubYouTurnPath.GenerateDubins(start, goal);
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
                double abHeading = ytList[A].heading;

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
                double U = (((pivot.easting - ytList[A].easting) * dx)
                            + ((pivot.northing - ytList[A].northing) * dz))
                            / ((dx * dx) + (dz * dz));

                rEastYT = ytList[A].easting + (U * dx);
                rNorthYT = ytList[A].northing + (U * dz);

                //update base on autosteer settings and distance from line
                double goalPointDistance = mf.vehicle.UpdateGoalPointDistance(distanceFromCurrentLine);
                mf.lookaheadActual = goalPointDistance;

                //used for accumulating distance to find goal point
                double distSoFar;

                isABSameAsFixHeading = true;
                distSoFar = glm.Distance(ytList[B], rEastYT, rNorthYT);

                // used for calculating the length squared of next segment.
                double tempDist = 0.0;

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

        //Duh.... What does this do....
        public void DrawYouTurn()
        {
            {
                //GL.PointSize(8);
                //GL.Begin(PrimitiveType.Points);
                //{
                //    GL.Color3(0.95f, 0.05f, 0.05f);
                //    GL.Vertex3(crossingCurvePoint.easting, crossingCurvePoint.northing, 0);
                //    GL.Color3(0.05f, 9, 0.05f);
                //    GL.Vertex3(crossingTurnLinePoint.easting, crossingTurnLinePoint.northing, 0);
                //}
                //GL.End();

                int ptCount = ytList.Count;
                if (ptCount == 0) return;

                if (!isOutOfBounds)
                    GL.Color3(0.395f, 0.925f, 0.30f);
                else
                    GL.Color3(0.9495f, 0.395f, 0.325f);
                GL.LineWidth(4);
                {
                    GL.Begin(PrimitiveType.LineStrip);
                    for (int i = 0; i < ptCount; i++)
                    {
                        GL.Vertex3(ytList[i].easting, ytList[i].northing, 0);
                    }
                    GL.End();
                }
            }
        }
    }
}