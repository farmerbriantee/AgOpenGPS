using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public class CABCurve
    {
        //pointers to mainform controls
        private readonly FormGPS mf;

        //flag for starting stop adding points
        public bool isCurveBtnOn, isOkToAddPoints, isCurveSet;

        private int closestRefIndex = 0;
        public double distanceFromCurrentLine;
        public bool isABSameAsVehicleHeading = true;
        public bool isOnRightSideCurrentLine = true;

        public double howManyPathsAway;
        public vec2 refPoint1 = new vec2(1, 1), refPoint2 = new vec2(2, 2);

        public bool isSameWay;
        public double refHeading;
        public double deltaOfRefAndAveHeadings;

        //generated box for finding closest point
        public vec2 boxA = new vec2(0, 0), boxB = new vec2(0, 2);

        public vec2 boxC = new vec2(1, 1), boxD = new vec2(2, 3);
        private int A, B, C;
        public int currentLocationIndex;

        public double aveLineHeading;

        //pure pursuit values
        public vec2 goalPointCu = new vec2(0, 0);

        public vec2 radiusPointCu = new vec2(0, 0);
        public double steerAngleCu;
        public double rEastCu, rNorthCu;
        public double ppRadiusCu;

        public bool isSmoothWindowOpen;

        //the list of points of the ref line.
        public List<vec3> refList = new List<vec3>();

        public List<vec3> smooList = new List<vec3>();

        //the list of points of curve to drive on
        public List<vec3> curList = new List<vec3>();

        public CABCurve(FormGPS _f)
        {
            //constructor
            mf = _f;
        }

        //for calculating for display the averaged new line
        public void SmoothAB(int smPts)
        {
            //count the reference list of original curve
            int cnt = refList.Count;

            //just go back if not very long
            if (!isCurveSet || cnt < 400) return;

            //the temp array
            vec3[] arr = new vec3[cnt];

            //read the points before and after the setpoint
            for (int s = 0; s < smPts / 2; s++)
            {
                arr[s].easting = refList[s].easting;
                arr[s].northing = refList[s].northing;
                arr[s].heading = refList[s].heading;
            }

            for (int s = cnt - (smPts / 2); s < cnt; s++)
            {
                arr[s].easting = refList[s].easting;
                arr[s].northing = refList[s].northing;
                arr[s].heading = refList[s].heading;
            }

            //average them - center weighted average
            for (int i = smPts / 2; i < cnt - (smPts / 2); i++)
            {
                for (int j = -smPts / 2; j < smPts / 2; j++)
                {
                    arr[i].easting += refList[j + i].easting;
                    arr[i].northing += refList[j + i].northing;
                }
                arr[i].easting /= smPts;
                arr[i].northing /= smPts;
                arr[i].heading = refList[i].heading;
            }

            //make a list to draw
            smooList?.Clear();
            for (int i = 0; i < cnt; i++)
            {
                smooList.Add(arr[i]);
            }
        }

        public void CalculateTurnHeadings()
        {
            //to calc heading based on next and previous points to give an average heading.
            int cnt = refList.Count;
            vec3[] arr = new vec3[cnt];
            cnt--;
            refList.CopyTo(arr);
            refList.Clear();

            //first point needs last, first, second points
            vec3 pt3 = arr[0];

            //middle points
            for (int i = 1; i < cnt; i++)
            {
                pt3 = arr[i];
                pt3.heading = Math.Atan2(arr[i + 1].easting - arr[i - 1].easting, arr[i + 1].northing - arr[i - 1].northing);
                if (pt3.heading < 0) pt3.heading += glm.twoPI;
                refList.Add(pt3);
            }
        }

        //turning the visual line into the real reference line to use
        public void SaveSmoothAsRefList()
        {
            //oops no smooth list generated
            int cnt = smooList.Count;
            if (cnt == 0) return;

            //eek
            refList?.Clear();

            //copy to an array to calculate all the new headings
            vec3[] arr = new vec3[cnt];
            smooList.CopyTo(arr);

            //calculate new headings on smoothed line
            for (int i = 1; i < cnt - 1; i++)
            {
                arr[i].heading = Math.Atan2(arr[i + 1].easting - arr[i].easting, arr[i + 1].northing - arr[i].northing);
                if (arr[i].heading < 0) arr[i].heading += glm.twoPI;
                refList.Add(arr[i]);
            }
        }

        public void GetCurrentCurveLine(vec3 pivot, vec3 steer)
        {
            //determine closest point
            double minDistance = 9999999;
            int ptCount = refList.Count;
            int ptCnt = ptCount - 1;
            if (ptCount < 5) return;

            boxA.easting = pivot.easting - (Math.Sin(aveLineHeading + glm.PIBy2) * 2000);
            boxA.northing = pivot.northing - (Math.Cos(aveLineHeading + glm.PIBy2) * 2000);

            boxB.easting = pivot.easting + (Math.Sin(aveLineHeading + glm.PIBy2) * 2000);
            boxB.northing = pivot.northing + (Math.Cos(aveLineHeading + glm.PIBy2) * 2000);

            boxC.easting = boxB.easting + (Math.Sin(aveLineHeading) * 1.0);
            boxC.northing = boxB.northing + (Math.Cos(aveLineHeading) * 1.0);

            boxD.easting = boxA.easting + (Math.Sin(aveLineHeading) * 1.0);
            boxD.northing = boxA.northing + (Math.Cos(aveLineHeading) * 1.0);

            boxA.easting -= (Math.Sin(aveLineHeading) * 1.0);
            boxA.northing -= (Math.Cos(aveLineHeading) * 1.0);

            boxB.easting -= (Math.Sin(aveLineHeading) * 1.0);
            boxB.northing -= (Math.Cos(aveLineHeading) * 1.0);

            //determine if point are in frustum box
            for (int s = 0; s < ptCnt; s++)
            {
                if ((((boxB.easting - boxA.easting) * (refList[s].northing - boxA.northing))
                        - ((boxB.northing - boxA.northing) * (refList[s].easting - boxA.easting))) < 0) { continue; }

                if ((((boxD.easting - boxC.easting) * (refList[s].northing - boxC.northing))
                        - ((boxD.northing - boxC.northing) * (refList[s].easting - boxC.easting))) < 0) { continue; }

                closestRefIndex = s;
                break;
            }

            double dist = ((pivot.easting - refList[closestRefIndex].easting) * (pivot.easting - refList[closestRefIndex].easting))
                            + ((pivot.northing - refList[closestRefIndex].northing) * (pivot.northing - refList[closestRefIndex].northing));

            minDistance = Math.Sqrt(dist);

            //grab the heading at the closest point
            refHeading = refList[closestRefIndex].heading;

            //which side of the patch are we on is next
            //calculate endpoints of reference line based on closest point
            refPoint1.easting = refList[closestRefIndex].easting - (Math.Sin(refHeading) * 50.0);
            refPoint1.northing = refList[closestRefIndex].northing - (Math.Cos(refHeading) * 50.0);

            refPoint2.easting = refList[closestRefIndex].easting + (Math.Sin(refHeading) * 50.0);
            refPoint2.northing = refList[closestRefIndex].northing + (Math.Cos(refHeading) * 50.0);

            //x2-x1
            double dx = refPoint2.easting - refPoint1.easting;
            //z2-z1
            double dz = refPoint2.northing - refPoint1.northing;

            //how far are we away from the reference line at 90 degrees - 2D cross product and distance
            double distanceFromRefLine = ((dz * pivot.easting) - (dx * pivot.northing) + (refPoint2.easting
                                    * refPoint1.northing) - (refPoint2.northing * refPoint1.easting));
            //   / Math.Sqrt((dz * dz) + (dx * dx));
            //are we going same direction as stripList was created?
            isSameWay = Math.PI - Math.Abs(Math.Abs(pivot.heading - refHeading) - Math.PI) < glm.PIBy2;
            deltaOfRefAndAveHeadings = Math.PI - Math.Abs(Math.Abs(aveLineHeading - refHeading) - Math.PI);
            deltaOfRefAndAveHeadings = Math.Cos(deltaOfRefAndAveHeadings);

            //add or subtract pi by 2 depending on which side of ref line
            double piSide;

            //sign of distance determines which side of line we are on
            if (distanceFromRefLine > 0) piSide = glm.PIBy2;
            else piSide = -glm.PIBy2;

            //move the ABLine over based on the overlap amount set in vehicle
            double widthMinusOverlap = mf.vehicle.toolWidth - mf.vehicle.toolOverlap;
            howManyPathsAway = Math.Round(minDistance / widthMinusOverlap, 0, MidpointRounding.AwayFromZero);

            //build the current line
            curList?.Clear();
            for (int i = 0; i < ptCount; i++)
            {
                var point = new vec3(
                    refList[i].easting + (Math.Sin(piSide + aveLineHeading) * widthMinusOverlap * howManyPathsAway),
                    refList[i].northing + (Math.Cos(piSide + aveLineHeading) * widthMinusOverlap * howManyPathsAway),
                    refList[i].heading);
                curList.Add(point);
            }

            double minDistA = 1000000, minDistB = 1000000;

            ptCount = curList.Count;

            if (ptCount > 0)
            {
                if (mf.isStanleyUsed)
                {
                    //find the closest 2 points to current fix
                    for (int t = 0; t < ptCount; t++)
                    {
                        dist = ((steer.easting - curList[t].easting) * (steer.easting - curList[t].easting))
                                        + ((steer.northing - curList[t].northing) * (steer.northing - curList[t].northing));
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

                    currentLocationIndex = A;

                    //get the distance from currently active AB line
                    dx = curList[B].easting - curList[A].easting;
                    dz = curList[B].northing - curList[A].northing;

                    if (Math.Abs(dx) < Double.Epsilon && Math.Abs(dz) < Double.Epsilon) return;

                    //abHeading = Math.Atan2(dz, dx);
                    double abHeading = curList[A].heading;

                    //how far from current AB Line is fix
                    distanceFromCurrentLine = ((dz * steer.easting) - (dx * steer.northing) + (curList[B].easting
                                * curList[A].northing) - (curList[B].northing * curList[A].easting))
                                    / Math.Sqrt((dz * dz) + (dx * dx));

                    //are we on the right side or not
                    isOnRightSideCurrentLine = distanceFromCurrentLine > 0;

                    //absolute the distance
                    distanceFromCurrentLine = Math.Abs(distanceFromCurrentLine);

                    //Subtract the two headings, if > 1.57 its going the opposite heading as refAB
                    double abFixHeadingDelta = (Math.Abs(mf.fixHeading - abHeading));
                    if (abFixHeadingDelta >= Math.PI) abFixHeadingDelta = Math.Abs(abFixHeadingDelta - glm.twoPI);
                    isABSameAsVehicleHeading = abFixHeadingDelta < glm.PIBy2;

                    // calc point on ABLine closest to current position
                    double U = (((steer.easting - curList[A].easting) * dx)
                                + ((steer.northing - curList[A].northing) * dz))
                                / ((dx * dx) + (dz * dz));

                    rEastCu = curList[A].easting + (U * dx);
                    rNorthCu = curList[A].northing + (U * dz);

                    //distance is negative if on left, positive if on right
                    if (isABSameAsVehicleHeading)
                    {
                        if (!isOnRightSideCurrentLine)
                        {
                            distanceFromCurrentLine *= -1.0;
                        }
                        abFixHeadingDelta = (steer.heading - abHeading);
                    }

                    //opposite way so right is left
                    else
                    {
                        if (isOnRightSideCurrentLine)
                        {
                            distanceFromCurrentLine *= -1.0;
                        }
                        abFixHeadingDelta = (steer.heading - abHeading + Math.PI);
                    }

                    //Fix the circular error
                    if (abFixHeadingDelta > Math.PI) abFixHeadingDelta -= Math.PI;
                    else if (abFixHeadingDelta < Math.PI) abFixHeadingDelta += Math.PI;

                    if (abFixHeadingDelta > glm.PIBy2) abFixHeadingDelta -= Math.PI;
                    else if (abFixHeadingDelta < -glm.PIBy2) abFixHeadingDelta += Math.PI;

                    abFixHeadingDelta *= mf.vehicle.stanleyHeadingErrorGain;
                    if (abFixHeadingDelta > 0.74) abFixHeadingDelta = 0.74;
                    if (abFixHeadingDelta < -0.74) abFixHeadingDelta = -0.74;

                    steerAngleCu = Math.Atan((distanceFromCurrentLine * mf.vehicle.stanleyGain) / ((mf.pn.speed * 0.277777) + 1));

                    if (steerAngleCu > 0.74) steerAngleCu = 0.74;
                    if (steerAngleCu < -0.74) steerAngleCu = -0.74;

                    steerAngleCu = glm.toDegrees((steerAngleCu + abFixHeadingDelta) * -1.0);

                    if (steerAngleCu < -mf.vehicle.maxSteerAngle) steerAngleCu = -mf.vehicle.maxSteerAngle;
                    if (steerAngleCu > mf.vehicle.maxSteerAngle) steerAngleCu = mf.vehicle.maxSteerAngle;

                    //Convert to millimeters
                    distanceFromCurrentLine = Math.Round(distanceFromCurrentLine * 1000.0, MidpointRounding.AwayFromZero);
                }
                else
                {
                    //find the closest 2 points to current fix
                    for (int t = 0; t < ptCount; t++)
                    {
                        dist = ((pivot.easting - curList[t].easting) * (pivot.easting - curList[t].easting))
                                        + ((pivot.northing - curList[t].northing) * (pivot.northing - curList[t].northing));
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

                    currentLocationIndex = A;

                    //get the distance from currently active AB line
                    dx = curList[B].easting - curList[A].easting;
                    dz = curList[B].northing - curList[A].northing;

                    if (Math.Abs(dx) < Double.Epsilon && Math.Abs(dz) < Double.Epsilon) return;

                    //abHeading = Math.Atan2(dz, dx);
                    double abHeading = curList[A].heading;

                    //how far from current AB Line is fix
                    distanceFromCurrentLine = ((dz * pivot.easting) - (dx * pivot.northing) + (curList[B].easting
                                * curList[A].northing) - (curList[B].northing * curList[A].easting))
                                    / Math.Sqrt((dz * dz) + (dx * dx));

                    //are we on the right side or not
                    isOnRightSideCurrentLine = distanceFromCurrentLine > 0;

                    //absolute the distance
                    distanceFromCurrentLine = Math.Abs(distanceFromCurrentLine);

                    // ** Pure pursuit ** - calc point on ABLine closest to current position
                    double U = (((pivot.easting - curList[A].easting) * dx)
                                + ((pivot.northing - curList[A].northing) * dz))
                                / ((dx * dx) + (dz * dz));

                    rEastCu = curList[A].easting + (U * dx);
                    rNorthCu = curList[A].northing + (U * dz);

                    //double minx, maxx, miny, maxy;

                    //minx = Math.Min(curList[A].northing, curList[B].northing);
                    //maxx = Math.Max(curList[A].northing, curList[B].northing);

                    //miny = Math.Min(curList[A].easting, curList[B].easting);
                    //maxy = Math.Max(curList[A].easting, curList[B].easting);

                    //isValid = rNorthCu >= minx && rNorthCu <= maxx && (rEastCu >= miny && rEastCu <= maxy);

                    //if (!isValid)
                    //{
                    //    //invalid distance so tell AS module
                    //    distanceFromCurrentLine = 32000;
                    //    mf.guidanceLineDistanceOff = 32000;
                    //    return;
                    //}

                    //used for accumulating distance to find goal point
                    double distSoFar;

                    //update base on autosteer settings and distance from line
                    double goalPointDistance = mf.vehicle.UpdateGoalPointDistance(distanceFromCurrentLine);
                    mf.lookaheadActual = goalPointDistance;

                    // used for calculating the length squared of next segment.
                    double tempDist = 0.0;

                    if (!isSameWay)
                    {
                        //counting down
                        isABSameAsVehicleHeading = false;
                        distSoFar = glm.Distance(curList[A], rEastCu, rNorthCu);
                        //Is this segment long enough to contain the full lookahead distance?
                        if (distSoFar > goalPointDistance)
                        {
                            //treat current segment like an AB Line
                            goalPointCu.easting = rEastCu - (Math.Sin(curList[A].heading) * goalPointDistance);
                            goalPointCu.northing = rNorthCu - (Math.Cos(curList[A].heading) * goalPointDistance);
                        }

                        //multiple segments required
                        else
                        {
                            //cycle thru segments and keep adding lengths. check if start and break if so.
                            while (A > 0)
                            {
                                B--; A--;
                                tempDist = glm.Distance(curList[B], curList[A]);

                                //will we go too far?
                                if ((tempDist + distSoFar) > goalPointDistance) break; //tempDist contains the full length of next segment
                                else distSoFar += tempDist;
                            }

                            double t = (goalPointDistance - distSoFar); // the remainder to yet travel
                            t /= tempDist;

                            goalPointCu.easting = (((1 - t) * curList[B].easting) + (t * curList[A].easting));
                            goalPointCu.northing = (((1 - t) * curList[B].northing) + (t * curList[A].northing));
                        }
                    }
                    else
                    {
                        //counting up
                        isABSameAsVehicleHeading = true;
                        distSoFar = glm.Distance(curList[B], rEastCu, rNorthCu);

                        //Is this segment long enough to contain the full lookahead distance?
                        if (distSoFar > goalPointDistance)
                        {
                            //treat current segment like an AB Line
                            goalPointCu.easting = rEastCu + (Math.Sin(curList[A].heading) * goalPointDistance);
                            goalPointCu.northing = rNorthCu + (Math.Cos(curList[A].heading) * goalPointDistance);
                        }

                        //multiple segments required
                        else
                        {
                            //cycle thru segments and keep adding lengths. check if end and break if so.
                            // ReSharper disable once LoopVariableIsNeverChangedInsideLoop
                            while (B < ptCount - 1)
                            {
                                B++; A++;
                                tempDist = glm.Distance(curList[B], curList[A]);

                                //will we go too far?
                                if ((tempDist + distSoFar) > goalPointDistance)
                                {
                                    //A--; B--;
                                    break; //tempDist contains the full length of next segment
                                }

                                distSoFar += tempDist;
                            }

                            //xt = (((1 - t) * x0 + t * x1)
                            //yt = ((1 - t) * y0 + t * y1))

                            double t = (goalPointDistance - distSoFar); // the remainder to yet travel
                            t /= tempDist;

                            goalPointCu.easting = (((1 - t) * curList[A].easting) + (t * curList[B].easting));
                            goalPointCu.northing = (((1 - t) * curList[A].northing) + (t * curList[B].northing));
                        }
                    }

                    //calc "D" the distance from pivot axle to lookahead point
                    double goalPointDistanceSquared = glm.DistanceSquared(goalPointCu.northing, goalPointCu.easting, pivot.northing, pivot.easting);

                    //calculate the the delta x in local coordinates and steering angle degrees based on wheelbase
                    double localHeading = glm.twoPI - mf.fixHeading;
                    ppRadiusCu = goalPointDistanceSquared / (2 * (((goalPointCu.easting - pivot.easting) * Math.Cos(localHeading)) + ((goalPointCu.northing - pivot.northing) * Math.Sin(localHeading))));

                    steerAngleCu = glm.toDegrees(Math.Atan(2 * (((goalPointCu.easting - pivot.easting) * Math.Cos(localHeading))
                        + ((goalPointCu.northing - pivot.northing) * Math.Sin(localHeading))) * mf.vehicle.wheelbase / goalPointDistanceSquared));

                    if (steerAngleCu < -mf.vehicle.maxSteerAngle) steerAngleCu = -mf.vehicle.maxSteerAngle;
                    if (steerAngleCu > mf.vehicle.maxSteerAngle) steerAngleCu = mf.vehicle.maxSteerAngle;

                    if (ppRadiusCu < -500) ppRadiusCu = -500;
                    if (ppRadiusCu > 500) ppRadiusCu = 500;

                    radiusPointCu.easting = pivot.easting + (ppRadiusCu * Math.Cos(localHeading));
                    radiusPointCu.northing = pivot.northing + (ppRadiusCu * Math.Sin(localHeading));

                    //angular velocity in rads/sec  = 2PI * m/sec * radians/meters
                    double angVel = glm.twoPI * 0.277777 * mf.pn.speed * (Math.Tan(glm.toRadians(steerAngleCu))) / mf.vehicle.wheelbase;

                    //clamp the steering angle to not exceed safe angular velocity
                    if (Math.Abs(angVel) > mf.vehicle.maxAngularVelocity)
                    {
                        steerAngleCu = glm.toDegrees(steerAngleCu > 0 ?
                                (Math.Atan((mf.vehicle.wheelbase * mf.vehicle.maxAngularVelocity) / (glm.twoPI * mf.pn.speed * 0.277777)))
                            : (Math.Atan((mf.vehicle.wheelbase * -mf.vehicle.maxAngularVelocity) / (glm.twoPI * mf.pn.speed * 0.277777))));
                    }
                    //Convert to centimeters
                    distanceFromCurrentLine = Math.Round(distanceFromCurrentLine * 1000.0, MidpointRounding.AwayFromZero);

                    //distance is negative if on left, positive if on right
                    //if you're going the opposite direction left is right and right is left
                    //double temp;
                    if (isABSameAsVehicleHeading)
                    {
                        //temp = (abHeading);
                        if (!isOnRightSideCurrentLine) distanceFromCurrentLine *= -1.0;
                    }

                    //opposite way so right is left
                    else
                    {
                        //temp = (abHeading - Math.PI);
                        //if (temp < 0) temp = (temp + glm.twoPI);
                        //temp = glm.toDegrees(temp);
                        if (isOnRightSideCurrentLine) distanceFromCurrentLine *= -1.0;
                    }
                }

                mf.guidanceLineDistanceOff = (Int16)distanceFromCurrentLine;
                mf.guidanceLineSteerAngle = (Int16)(steerAngleCu * 100);
                

                if (mf.yt.isYouTurnTriggered)
                {
                    //do the pure pursuit from youTurn
                    mf.yt.DistanceFromYouTurnLine();
                    mf.seq.DoSequenceEvent();

                    //now substitute what it thinks are AB line values with auto turn values
                    steerAngleCu = mf.yt.steerAngleYT;
                    distanceFromCurrentLine = mf.yt.distanceFromCurrentLine;

                    goalPointCu = mf.yt.goalPointYT;
                    radiusPointCu.easting = mf.yt.radiusPointYT.easting;
                    radiusPointCu.northing = mf.yt.radiusPointYT.northing;
                    ppRadiusCu = mf.yt.ppRadiusYT;
                }
            }
            else
            {
                //invalid distance so tell AS module
                distanceFromCurrentLine = 32000;
                mf.guidanceLineDistanceOff = 32000;
            }
        }

        public void SnapABCurve()
        {
            double headingAt90;

            //calculate the heading 90 degrees to ref ABLine heading
            if (isOnRightSideCurrentLine) headingAt90 = glm.PIBy2;
            else headingAt90 = -glm.PIBy2;

            int cnt = refList.Count;
            vec3[] arr = new vec3[cnt];
            refList.CopyTo(arr);
            refList.Clear();

            for (int i = 0; i < cnt; i++)
            {
                arr[i].easting = (Math.Sin(headingAt90 + arr[i].heading) * Math.Abs(distanceFromCurrentLine) * 0.001) + arr[i].easting;
                arr[i].northing = (Math.Cos(headingAt90 + arr[i].heading) * Math.Abs(distanceFromCurrentLine) * 0.001) + arr[i].northing;
                refList.Add(arr[i]);
            }
        }

        public void MoveABCurve(double dist)
        {
            double headingAt90;

            //calculate the heading 90 degrees to ref ABLine heading
            if (isABSameAsVehicleHeading) headingAt90 = glm.PIBy2;
            else headingAt90 = -glm.PIBy2;

            int cnt = refList.Count;
            vec3[] arr = new vec3[cnt];
            refList.CopyTo(arr);
            refList.Clear();

            for (int i = 0; i < cnt; i++)
            {
                arr[i].easting = (Math.Sin(headingAt90 + arr[i].heading) * dist) + arr[i].easting;
                arr[i].northing = (Math.Cos(headingAt90 + arr[i].heading) * dist) + arr[i].northing;
                refList.Add(arr[i]);
            }
        }

        public bool PointOnLine(vec3 pt1, vec3 pt2, vec3 pt)
        {
            bool isValid = false;

            var r = new vec2(0, 0);
            if (pt1.northing == pt2.northing && pt1.easting == pt2.easting) { pt1.northing -= 0.00001; }

            var U = ((pt.northing - pt1.northing) * (pt2.northing - pt1.northing)) + ((pt.easting - pt1.easting) * (pt2.easting - pt1.easting));

            var Udenom = Math.Pow(pt2.northing - pt1.northing, 2) + Math.Pow(pt2.easting - pt1.easting, 2);

            U /= Udenom;

            r.northing = pt1.northing + (U * (pt2.northing - pt1.northing));
            r.easting = pt1.easting + (U * (pt2.easting - pt1.easting));

            double minx, maxx, miny, maxy;

            minx = Math.Min(pt1.northing, pt2.northing);
            maxx = Math.Max(pt1.northing, pt2.northing);

            miny = Math.Min(pt1.easting, pt2.easting);
            maxy = Math.Max(pt1.easting, pt2.easting);

            return isValid = r.northing >= minx && r.northing <= maxx && (r.easting >= miny && r.easting <= maxy);
        }

        //add extensons
        public void AddFirstLastPoints()
        {
            int ptCnt = refList.Count - 1;
            for (int i = 1; i < 200; i++)
            {
                vec3 pt = new vec3(refList[ptCnt]);
                pt.easting += (Math.Sin(pt.heading) * i);
                pt.northing += (Math.Cos(pt.heading) * i);
                refList.Add(pt);
            }

            //and the beginning
            vec3 start = new vec3(refList[0]);
            for (int i = 1; i < 200; i++)
            {
                vec3 pt = new vec3(start);
                pt.easting -= (Math.Sin(pt.heading) * i);
                pt.northing -= (Math.Cos(pt.heading) * i);
                refList.Insert(0, pt);
            }
        }

        public void ResetCurveLine()
        {
            curList?.Clear();
            refList?.Clear();
            isCurveSet = false;
            isOkToAddPoints = false;
            closestRefIndex = 0;
        }

        ////draw the guidance line
        public void DrawCurve()
        {
            int ptCount = refList.Count;
            if (refList.Count == 0) return;

            GL.LineWidth(2);
            GL.Color3(0.30f, 0.692f, 0.60f);
            GL.Begin(PrimitiveType.LineStrip);
            for (int h = 0; h < ptCount; h++) GL.Vertex3(refList[h].easting, refList[h].northing, 0);
            GL.Color3(0.930f, 0.0692f, 0.260f);
            if (!mf.curve.isCurveSet)
            {
                ptCount--;
                GL.Vertex3(refList[ptCount].easting, refList[ptCount].northing, 0);
#pragma warning disable CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception
                GL.Vertex3(mf.pivotAxlePos.easting, mf.pivotAxlePos.northing, 0);
#pragma warning restore CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception
            }
            GL.End();

            //just draw ref and smoothed line if smoothing window is open
            if (isSmoothWindowOpen)
            {
                ptCount = smooList.Count;
                if (smooList.Count == 0) return;

                GL.LineWidth(2);
                GL.Color3(0.930f, 0.92f, 0.260f);
                GL.Begin(PrimitiveType.Lines);
                for (int h = 0; h < ptCount; h++) GL.Vertex3(smooList[h].easting, smooList[h].northing, 0);
                GL.End();

                //GL.Color3(0.64f, 0.64f, 0.750f);
                //GL.Begin(PrimitiveType.Lines);
                //GL.Vertex3(boxA.easting, boxA.northing, 0);
                //GL.Vertex3(boxB.easting, boxB.northing, 0);
                //GL.Vertex3(boxC.easting, boxC.northing, 0);
                //GL.Vertex3(boxD.easting, boxD.northing, 0);
                //GL.End();
            }            
            else //normal. Smoothing window is not open.
            {
                ptCount = curList.Count;
                if (ptCount > 0 && isCurveSet)
                {
                    GL.PointSize(2);

                    GL.Color3(0.95f, 0.2f, 0.0f);
                    GL.Begin(PrimitiveType.LineStrip);
                    for (int h = 0; h < ptCount; h++) GL.Vertex3(curList[h].easting, curList[h].northing, 0);
                    GL.End();

                    if (mf.isPureDisplayOn && !mf.isStanleyUsed)
                    {
                        if (ppRadiusCu < 100 && ppRadiusCu > -100)
                        {
                            const int numSegments = 100;
                            double theta = glm.twoPI / numSegments;
                            double c = Math.Cos(theta);//precalculate the sine and cosine
                            double s = Math.Sin(theta);
                            double x = ppRadiusCu;//we start at angle = 0
                            double y = 0;

                            GL.LineWidth(1);
                            GL.Color3(0.95f, 0.30f, 0.950f);
                            GL.Begin(PrimitiveType.LineLoop);
                            for (int ii = 0; ii < numSegments; ii++)
                            {
                                //glVertex2f(x + cx, y + cy);//output vertex
                                GL.Vertex3(x + radiusPointCu.easting, y + radiusPointCu.northing, 0);//output vertex
                                double t = x;//apply the rotation matrix
                                x = (c * x) - (s * y);
                                y = (s * t) + (c * y);
                            }
                            GL.End();
                        }

                        //Draw lookahead Point
                        GL.PointSize(4.0f);
                        GL.Begin(PrimitiveType.Points);
                        GL.Color3(1.0f, 0.5f, 0.95f);
                        GL.Vertex3(goalPointCu.easting, goalPointCu.northing, 0.0);
                        GL.End();
                    }

                    mf.yt.DrawYouTurn();

                    if (mf.yt.isYouTurnTriggered)
                    {
                        GL.Color3(0.95f, 0.95f, 0.25f);
                        GL.LineWidth(4);
                        ptCount = mf.yt.ytList.Count;
                        if (ptCount > 0)
                        {
                            GL.Begin(PrimitiveType.Points);
                            for (int i = 0; i < ptCount; i++)
                            {
                                GL.Vertex3(mf.yt.ytList[i].easting, mf.yt.ytList[i].northing, 0);
                            }
                            GL.End();
                        }
                        GL.Color3(0.95f, 0.05f, 0.05f);
                    }
                }
            }
            GL.PointSize(1.0f);
        }
    }
}