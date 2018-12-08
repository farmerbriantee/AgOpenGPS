using SharpGL;
using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public class CGenPathPt
    {
        public double easting { get; set; }
        public double northing { get; set; }
        public double heading { get; set; }
        public int sequence { get; set; }

        //constructor
        public CGenPathPt(double _easting, double _northing, double _heading, int _sequence = 0)
        {
            easting = _easting;
            northing = _northing;
            heading = _heading;
            sequence = _sequence;
        }
    }

    public class CGenPath
    {
        //copy of the mainform address
        private readonly FormGPS mf;
        private readonly OpenGL gl;

        //original start position
        public vec3 homePoint = new vec3(0, 0, 0);

        //point to start field
        public vec3 startInfieldPoint = new vec3(9999, 9999, 0);

        public vec3 headingInfieldPoint = new vec3(9999, 9999, 0);
        public bool isStartInfieldPointSet, isPathToInfieldMade;

        private vec3 startHeadlandPoint = new vec3(9999, 9999, 0);
        private vec3 endHeadlandPoint = new vec3(9999, 9999, 0);

        public int numHeadlandPasses;

        private double distance;
        private vec3 point;

        public double distanceFromRefLine, distanceFromCurrentLine, refLineSide = 1.0;
        private int A, B, C;
        public double abFixHeadingDelta, segmentHeading;
        public bool isABSameAsFixHeading = true, isOnRightSideCurrentLine = true;

        public int lastPointFound = -1, currentPositonIndex;

        //pure pursuit values
        public vec3 pivotAxlePosGP = new vec3(0, 0, 0);

        public vec3 homePos = new vec3();
        public vec2 goalPointGP = new vec2(0, 0);
        public vec2 radiusPointGP = new vec2(0, 0);
        public double steerAngleGP, rEastGP, rNorthGP, ppRadiusGP;

        //Drive the genPath list
        public bool isDrivingGenLine, isDrivingInField, isDrivingHome;

        public bool isEndOfTheGenLine, isBtnDriveGenPathOn;

        public int genListCount;

        //the path to follow to do the headland
        public List<vec3> accList = new List<vec3>();

        //the whole path to follow to do the headland
        public List<CGenPathPt> genList = new List<CGenPathPt>();

        //the whole path to follow to do the headland
        public List<vec3> guideList = new List<vec3>();

        //the whole path to follow to do the headland
        public List<vec3> dubList = new List<vec3>();

        //constructor
        public CGenPath(OpenGL _gl, FormGPS _f)
        {
            mf = _f;
            gl = _gl;
            numHeadlandPasses = 2;
        }

        public bool StartDrivingRecordedPath()
        {
            genListCount = genList.Count;
            if (genListCount < 5) return false;
            //set a speed of 9 kmh
            mf.sim.stepDistance = 9 / 17.86;
            isDrivingGenLine = true;
            return true;
        }

        public void StopDrivingRecordedPath()
        {
            mf.sim.stepDistance = 0;
        }

        public void GenerateGuideHelper()
        {
            //keep copy of original position/heading
            homePoint = mf.pivotAxlePos;
            endHeadlandPoint = homePoint;

            ////first find out which side is inside the boundary
            //insideOutside = glm.PIBy2;
            //point.easting = mf.bnd.ptList[3].easting - (Math.Sin(insideOutside + mf.bnd.ptList[3].heading) * 2.0);
            //point.northing = mf.bnd.ptList[3].northing - (Math.Cos(insideOutside + mf.bnd.ptList[3].heading) * 2.0);
            //if (!mf.bnd.IsPointInsideBoundary(point)) insideOutside *= -1.0;

            //clear the main list
            guideList.Clear();

            for (int passNumber = 1; passNumber <= 3; passNumber++)
            {
                //determine the start point of first headland -
                accList.Clear();
                BuildOneHeadlandPath((mf.vehicle.toolWidth - mf.vehicle.toolOverlap) * passNumber);

                for (int i = 0; i < accList.Count; i++)
                {
                    vec3 pt = new vec3(accList[i].easting, accList[i].northing, accList[i].heading);
                    guideList.Add(pt);
                }
            }
        }

        public void GenerateHeadlandPath()
        {
            //first find out which side is inside the boundary
            //insideOutside = glm.PIBy2;
            //point.easting = mf.bnd.ptList[3].easting - (Math.Sin(insideOutside + mf.bnd.ptList[3].heading) * 2.0);
            //point.northing = mf.bnd.ptList[3].northing - (Math.Cos(insideOutside + mf.bnd.ptList[3].heading) * 2.0);
            //if (!mf.bnd.IsPointInsideBoundary(point)) insideOutside *= -1.0;

            //keep copy of original position/heading
            homePoint = mf.pivotAxlePos;

            //clear the main list
            genList.Clear();

            for (int passNumber = 1; passNumber <= numHeadlandPasses; passNumber++)
            {
                //determine the start point of first headland -
                accList.Clear();
                BuildOneHeadlandPath((mf.vehicle.toolWidth - mf.vehicle.toolOverlap) * ((double)passNumber - 0.4));
                startHeadlandPoint = accList[0];

                CDubins dubPath = new CDubins();
                CDubins.turningRadius = mf.vehicle.minTurningRadius * 1.2;

                ////get the dubins path vec3 point coordinates of turn
                //dubList.Clear();
                //if (passNumber == 1) dubList = dubPath.GenerateDubins(mf.pivotAxlePos, startHeadlandPoint, mf.bnd);
                //else dubList = dubPath.GenerateDubins(endHeadlandPoint, startHeadlandPoint, mf.bnd);

                //transfer point list to genList class
                for (int i = 0; i < dubList.Count; i++)
                {
                    CGenPathPt pt = new CGenPathPt(dubList[i].easting, dubList[i].northing, dubList[i].heading);
                    if (i < 5) pt.sequence = 1;
                    genList.Add(pt);
                }

                for (int i = 0; i < accList.Count; i++)
                {
                    CGenPathPt pt = new CGenPathPt(accList[i].easting, accList[i].northing, accList[i].heading);
                    if (i < 5) pt.sequence = 2;
                    genList.Add(pt);
                }

                for (int i = 0; i < 5; i++)
                {
                    CGenPathPt pt = new CGenPathPt(accList[i].easting, accList[i].northing, accList[i].heading);
                    genList.Add(pt);
                }
                endHeadlandPoint = accList[5];
            }
            genListCount = genList.Count;
            currentPositonIndex = 0;
            isEndOfTheGenLine = false;
        }

        public void GeneratePathToStartInfield()
        {
            //go to the startpoint
            CDubins dubPathToStart = new CDubins();
            CDubins.turningRadius = mf.vehicle.minTurningRadius * 1.2;

            ////get the dubins path vec3 point coordinates of turn
            //dubList.Clear();
            //dubList = dubPathToStart.GenerateDubins(endHeadlandPoint, startInfieldPoint, mf.bnd);

            //transfer point list to genList class
            for (int i = 0; i < dubList.Count; i++)
            {
                CGenPathPt pt = new CGenPathPt(dubList[i].easting, dubList[i].northing, dubList[i].heading);
                if (i < 10) pt.sequence = 1;
                genList.Add(pt);
            }

            //made the path so set the flag
            isPathToInfieldMade = true;

            genListCount = genList.Count;
            currentPositonIndex = 0;
            isEndOfTheGenLine = false;
        }

        public void GeneratePathHome()
        {
            genList.Clear();
            currentPositonIndex = 0;
            isEndOfTheGenLine = false;

            //go to the startpoint
            CDubins dubPathToStart = new CDubins();
            CDubins.turningRadius = mf.vehicle.minTurningRadius * 2.0;

            ////get the dubins path vec3 point coordinates of turn
            //dubList.Clear();
            //dubList = dubPathToStart.GenerateDubins(mf.pivotAxlePos, homePoint, mf.bnd);

            //transfer point list to genList class
            for (int i = 0; i < dubList.Count; i++)
            {
                CGenPathPt pt = new CGenPathPt(dubList[i].easting, dubList[i].northing, dubList[i].heading);
                genList.Add(pt);
            }

            genListCount = genList.Count;
            currentPositonIndex = 0;

            //shut everything off
            isDrivingHome = true;
        }

        public void UpdatePosition()
        {
            if (isDrivingGenLine)
            {
                pivotAxlePosGP = mf.pivotAxlePos;

                FindGoalPointGenPath(genListCount);
                PurePursuit();

                if (!isEndOfTheGenLine)
                {
                    //mf.sim.stepDistance = recList[C].speed / 17.86;
                    //north = recList[C].northing;

                    if (genList[C].sequence != lastListPointSequence)
                    {
                        if (genList[C].sequence == 1) TriggerEnterSequence();
                        if (genList[C].sequence == 2) TriggerExitSequence();
                    }

                    lastListPointSequence = genList[C].sequence;
                }
                else if (isPathToInfieldMade)
                {
                    //End of GenPath, turn everything on for infield
                    TriggerExitSequence();

                    isDrivingGenLine = false;
                    isDrivingInField = true;
                    isDrivingHome = false;
                    isEndOfTheGenLine = false;

                    //no longer needed
                    genList.Clear();

                    //turn on UTurn
                    mf.btnSnap.PerformClick();
                    mf.btnAutoSteer.PerformClick();
                    mf.btnEnableAutoYouTurn.PerformClick();
                }
                else
                {
                    TriggerEnterSequence();
                    isDrivingGenLine = false;
                    isDrivingInField = false;
                    GeneratePathHome();
                }
                return;
            }
            if (isDrivingInField)
            {
                //loss of headland line for 5 frames triggers all done, so go home
                if (mf.distPivot == -3333)
                    headlandLostCtr++;
                else headlandLostCtr = 0;
                if (headlandLostCtr > 5)
                {
                    TriggerEnterSequence();
                    mf.btnAutoSteer.PerformClick();
                    mf.btnEnableAutoYouTurn.PerformClick();
                    isDrivingInField = false;
                    GeneratePathHome();
                }
                return;
            }
            if (isDrivingHome)
            {
                pivotAxlePosGP = mf.pivotAxlePos;
                FindGoalPointGenPath(genListCount);
                PurePursuit();

                if (isEndOfTheGenLine) //if end of the line then stop
                {
                    //turn everything off for infield
                    TriggerEnterSequence();
                    isDrivingGenLine = false;
                    isDrivingInField = false;
                    isDrivingHome = false;
                    mf.btnDriveGenPath.PerformClick();
                    genList.Clear();
                    isEndOfTheGenLine = false;
                }
            }
        }

        public void BuildOneHeadlandPath(double totalHeadWidth)
        {
            //clear the headland point list
            accList.Clear();

            //determine how wide a headland space
            //totalHeadWidth = (mf.vehicle.toolWidth - mf.vehicle.toolOverlap) * (passNum - 0.45);

            ////count the points from the boundary
            //int boundaryPtCount = mf.bnd.ptList.Count;

            //for (int i = 0; i < boundaryPtCount; i++)
            //{
            //    //calculate the point inside the boundary
            //    point.easting = mf.bnd.ptList[i].easting - (System.Math.Sin(insideOutside + mf.bnd.ptList[i].heading) * totalHeadWidth);
            //    point.northing = mf.bnd.ptList[i].northing - (Math.Cos(insideOutside + mf.bnd.ptList[i].heading) * totalHeadWidth);
            //    point.heading = mf.bnd.ptList[i].heading;

            //    //only add if inside actual field boundary
            //    if (mf.bnd.IsPointInsideBoundary(point)) accList.Add(point);
            //}

            int headCount = accList.Count;

            ////remove the points too close to boundary
            //for (int i = 0; i < boundaryPtCount; i++)
            //{
            //    for (int j = 0; j < headCount; j++)
            //    {
            //        //make sure distance between headland and boundary is not less then width
            //        distance = glm.Distance(mf.bnd.ptList[i], accList[j]);
            //        if (distance < (totalHeadWidth * 0.98))
            //        {
            //            accList.RemoveAt(j);
            //            headCount = accList.Count;
            //            j = 0;
            //        }
            //    }
            //}

            //make sure distance isn't too small between points on headland

            headCount = accList.Count;
            //double spacing = mf.vehicle.toolWidth * 0.25;
            const double spacing = 0.9;
            //double distance;
            for (int i = 0; i < headCount - 1; i++)
            {
                distance = glm.Distance(accList[i], accList[i + 1]);
                if (distance < spacing)
                {
                    accList.RemoveAt(i + 1);
                    headCount = accList.Count;
                    i = 0;
                }
            }

            //make sure distance isn't too big between points on headland
            //vec3 point;
            headCount = accList.Count;
            for (int i = 0; i < headCount; i++)
            {
                int j = i + 1;
                if (j == headCount) j = 0;
                distance = glm.Distance(accList[i], accList[j]);
                if (distance > (spacing * 1.1))
                {
                    point.easting = (accList[i].easting + accList[j].easting) / 2.0;
                    point.northing = (accList[i].northing + accList[j].northing) / 2.0;
                    point.heading = accList[i].heading;

                    accList.Insert(j, point);
                    headCount = accList.Count;
                    i = 0;
                }
            }

            //make sure headings are correct for calculated points
            //to calc heading based on next and previous points to give an average heading.
            int cnt = accList.Count;
            if (cnt == 0) return;
            vec3[] arr = new vec3[cnt];
            cnt--;
            accList.CopyTo(arr);
            accList.Clear();

            //first point needs last, first, second points
            vec3 pt3 = arr[0];
            pt3.heading = Math.Atan2(arr[1].easting - arr[cnt].easting, arr[1].northing - arr[cnt].northing);
            accList.Add(pt3);
            for (int i = 1; i < cnt; i++)
            {
                pt3 = arr[i];
                pt3.heading = Math.Atan2(arr[i + 1].easting - arr[i - 1].easting, arr[i + 1].northing - arr[i - 1].northing);
                accList.Add(pt3);
            }
            pt3 = arr[cnt];
            pt3.heading = Math.Atan2(arr[0].easting - arr[cnt - 1].easting, arr[0].northing - arr[cnt - 1].northing);
            accList.Add(pt3);
        }

        private void TriggerEnterSequence()
        {
            for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
            {
                if (mf.seq.seqEnter[i].function != 0)
                {
                    mf.DoYouTurnSequenceEvent(mf.seq.seqEnter[i].function, mf.seq.seqEnter[i].action);
                }
            }
        }

        private void TriggerExitSequence()
        {
            for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
            {
                if (mf.seq.seqExit[i].function != 0)
                    mf.DoYouTurnSequenceEvent(mf.seq.seqExit[i].function, mf.seq.seqExit[i].action);
            }
        }

        private int lastListPointSequence;

        private int headlandLostCtr;

        private void PurePursuit()
        {
            //calc "D" the distance from pivot axle to lookahead point
            double goalPointDistanceSquared = glm.DistanceSquared(goalPointGP.northing, goalPointGP.easting, pivotAxlePosGP.northing, pivotAxlePosGP.easting);

            //calculate the the delta x in local coordinates and steering angle degrees based on wheelbase
            double localHeading = glm.twoPI - mf.fixHeading;
            ppRadiusGP = goalPointDistanceSquared / (2 * (((goalPointGP.easting - pivotAxlePosGP.easting) * Math.Cos(localHeading)) + ((goalPointGP.northing - pivotAxlePosGP.northing) * Math.Sin(localHeading))));

            steerAngleGP = glm.toDegrees(Math.Atan(2 * (((goalPointGP.easting - pivotAxlePosGP.easting) * Math.Cos(localHeading))
                + ((goalPointGP.northing - pivotAxlePosGP.northing) * Math.Sin(localHeading))) * mf.vehicle.wheelbase / goalPointDistanceSquared));

            if (steerAngleGP < -mf.vehicle.maxSteerAngle) steerAngleGP = -mf.vehicle.maxSteerAngle;
            if (steerAngleGP > mf.vehicle.maxSteerAngle) steerAngleGP = mf.vehicle.maxSteerAngle;

            if (ppRadiusGP < -500) ppRadiusGP = -500;
            if (ppRadiusGP > 500) ppRadiusGP = 500;

            radiusPointGP.easting = pivotAxlePosGP.easting + (ppRadiusGP * Math.Cos(localHeading));
            radiusPointGP.northing = pivotAxlePosGP.northing + (ppRadiusGP * Math.Sin(localHeading));

            //angular velocity in rads/sec  = 2PI * m/sec * radians/meters
            double angVel = glm.twoPI * 0.277777 * mf.pn.speed * (Math.Tan(glm.toRadians(steerAngleGP))) / mf.vehicle.wheelbase;

            //clamp the steering angle to not exceed safe angular velocity
            if (Math.Abs(angVel) > mf.vehicle.maxAngularVelocity)
            {
                steerAngleGP = glm.toDegrees(steerAngleGP > 0 ?
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
            else if (isOnRightSideCurrentLine)
            {
                distanceFromCurrentLine *= -1.0;
            }

            mf.guidanceLineDistanceOff = (Int16)distanceFromCurrentLine;
            mf.guidanceLineSteerAngle = (Int16)(steerAngleGP * 100);
        }

        private vec2 FindGoalPointGenPath(int ptCount)
        {
            //find the closest 2 points to current fix
            double minDistA = 9999999999;

            //set the search range close to current position
            int top = currentPositonIndex + 25;
            if (top > ptCount) top = ptCount;

            double dist;
            for (int t = currentPositonIndex; t < top; t++)
            {
                dist = ((pivotAxlePosGP.easting - genList[t].easting) * (pivotAxlePosGP.easting - genList[t].easting))
                                + ((pivotAxlePosGP.northing - genList[t].northing) * (pivotAxlePosGP.northing - genList[t].northing));
                if (dist < minDistA)
                {
                    minDistA = dist;
                    A = t;
                }
            }

            //Save the closest point
            C = A;

            //next point is the next in list
            B = A + 1;
            if (B == ptCount)
            {
                //don't go past the end of the list - "end of the line" trigger
                A--;
                B--;
                isEndOfTheGenLine = true;
            }

            //save current position
            currentPositonIndex = A;

            //get the distance from currently active AB line
            //x2-x1
            double dx = genList[B].easting - genList[A].easting;
            //z2-z1
            double dz = genList[B].northing - genList[A].northing;

            if (Math.Abs(dx) < Double.Epsilon && Math.Abs(dz) < Double.Epsilon) return goalPointGP;

            //abHeading = Math.Atan2(dz, dx);
            segmentHeading = genList[A].heading;

            //how far from current AB Line is fix
            distanceFromCurrentLine = ((dz * pivotAxlePosGP.easting) - (dx * pivotAxlePosGP
                .northing) + (genList[B].easting
                        * genList[A].northing) - (genList[B].northing * genList[A].easting))
                            / Math.Sqrt((dz * dz) + (dx * dx));

            //are we on the right side or not
            isOnRightSideCurrentLine = distanceFromCurrentLine > 0;

            //absolute the distance
            distanceFromCurrentLine = Math.Abs(distanceFromCurrentLine);

            // ** Pure pursuit ** - calc point on ABLine closest to current position
            double U = (((pivotAxlePosGP.easting - genList[A].easting) * dx)
                        + ((pivotAxlePosGP.northing - genList[A].northing) * dz))
                        / ((dx * dx) + (dz * dz));

            rEastGP = genList[A].easting + (U * dx);
            rNorthGP = genList[A].northing + (U * dz);

            //Subtract the two headings, if > 1.57 its going the opposite heading as refAB
            abFixHeadingDelta = (Math.Abs(mf.fixHeading - segmentHeading));
            if (abFixHeadingDelta >= Math.PI) abFixHeadingDelta = Math.Abs(abFixHeadingDelta - glm.twoPI);

            //used for accumulating distance to find goal point
            double distSoFar;

            //how far should goal point be away  - speed * seconds * kmph -> m/s + min value
            double goalPointDistance = mf.pn.speed * mf.vehicle.goalPointLookAhead * 0.27777777;

            //minimum of 4.0 meters look ahead
            if (goalPointDistance < 4.0) goalPointDistance = 4.0;

            // used for calculating the length squared of next segment.
            double tempDist = 0.0;

            //counting up
            isABSameAsFixHeading = true;
            distSoFar = glm.Distance(genList[B].easting, genList[B].northing, rEastGP, rNorthGP);

            //Is this segment long enough to contain the full lookahead distance?
            if (distSoFar > goalPointDistance)
            {
                //treat current segment like an AB Line
                goalPointGP.easting = rEastGP + (Math.Sin(genList[A].heading) * goalPointDistance);
                goalPointGP.northing = rNorthGP + (Math.Cos(genList[A].heading) * goalPointDistance);
            }

            //multiple segments required
            else
            {
                //cycle thru segments and keep adding lengths. check if end and break if so.
                // ReSharper disable once LoopVariableIsNeverChangedInsideLoop
                while (B < ptCount - 1)
                {
                    B++; A++;
                    tempDist = glm.Distance(genList[B].easting, genList[B].northing, genList[A].easting, genList[A].northing);

                    //will we go too far?
                    if ((tempDist + distSoFar) > goalPointDistance)
                    {
                        //A--; B--;
                        break; //tempDist contains the full length of next segment
                    }

                    distSoFar += tempDist;
                }

                // the remainder to yet travel
                double t = (goalPointDistance - distSoFar);
                t /= tempDist;

                goalPointGP.easting = (((1 - t) * genList[A].easting) + (t * genList[B].easting));
                goalPointGP.northing = (((1 - t) * genList[A].northing) + (t * genList[B].northing));
            }
            return goalPointGP;
        }

        public void DrawGeneratedPath()
        {
            ////draw generated path so far.
            int ptCount = genList.Count;
            if (ptCount < 5) return;
            gl.LineWidth(2);
            gl.Color(0.9574f, 0.92069760f, 0.23f);
            gl.Begin(OpenGL.GL_LINE_STRIP);
            for (int h = 1; h < ptCount; h++) gl.Vertex(genList[h].easting, genList[h].northing, 0);
            gl.End();
        }
    }
}