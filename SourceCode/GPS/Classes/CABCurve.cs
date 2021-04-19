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
        public bool isBtnCurveOn, isOkToAddPoints, isCurveSet, isOkToAddDesPoints;

        public double distanceFromCurrentLinePivot;
        public bool isABSameAsVehicleHeading = true, isFixHeadingSameWayAsRef;
        public bool isOnRightSideCurrentLine = true;

        public double howManyPathsAway, curveNumber;
        public vec2 refPoint1 = new vec2(1, 1), refPoint2 = new vec2(2, 2);

        public bool isSameWay;
        public double refHeading, moveDistance;
        public double deltaOfRefAndAveHeadings;

        //generated box for finding closest point
        public vec2 boxA = new vec2(0, 0), boxB = new vec2(0, 2);

        public vec2 boxC = new vec2(1, 1), boxD = new vec2(2, 3);
        private int A, B, C;
        private int rA, rB;

        public int currentLocationIndex;

        public double aveLineHeading;

        //pure pursuit values
        public vec2 goalPointCu = new vec2(0, 0);

        public vec2 radiusPointCu = new vec2(0, 0);
        public double steerAngleCu, rEastCu, rNorthCu, ppRadiusCu, manualUturnHeading;

        //the list of points of the ref line.
        public List<vec3> refList = new List<vec3>();
        //the list of points of curve to drive on
        public List<vec3> curList = new List<vec3>();

        public bool isSmoothWindowOpen;
        public List<vec3> smooList = new List<vec3>();

        public List<CCurveLines> curveArr = new List<CCurveLines>();
        public int numCurveLines, numCurveLineSelected;

        public bool isCurveValid;

        public double lastSecond = 0;

        public List<vec3> desList = new List<vec3>();
        public string desName = "**";

        public double pivotDistanceError, pivotDistanceErrorLast, pivotDerivative, pivotDerivativeSmoothed, lastCurveDistance = 10000;
        //derivative counters
        private int counter2;
        public double inty;
        public double steerAngleSmoothed, pivotErrorTotal;
        public double distSteerError, lastDistSteerError, derivativeDistError;

        public CABCurve(FormGPS _f)
        {
            //constructor
            mf = _f;
        }

        public void BuildCurveCurrentList(vec3 pivot)
        {
            double minDistA = 1000000, minDistB;
            //move the ABLine over based on the overlap amount set in vehicle
            double widthMinusOverlap = mf.tool.toolWidth - mf.tool.toolOverlap;


            int refCount = refList.Count;
            if (refCount < 5)
            {
                curList?.Clear();
                return;
            }

            //close call hit
            int cc = 0, dd;
            for (int j = 0; j < refCount; j += 10)
            {
                double dist = ((pivot.easting - refList[j].easting) * (pivot.easting - refList[j].easting))
                                + ((pivot.northing - refList[j].northing) * (pivot.northing - refList[j].northing));
                if (dist < minDistA)
                {
                    minDistA = dist;
                    cc = j;
                }
            }

            minDistA = minDistB = 1000000;

            dd = cc + 7; if (dd > refCount - 1) dd = refCount;
            cc -= 7; if (cc < 0) cc = 0;


            //find the closest 2 points to current close call
            for (int j = cc; j < dd; j++)
            {
                double dist = ((pivot.easting - refList[j].easting) * (pivot.easting - refList[j].easting))
                                + ((pivot.northing - refList[j].northing) * (pivot.northing - refList[j].northing));
                if (dist < minDistA)
                {
                    minDistB = minDistA;
                    rB = rA;
                    minDistA = dist;
                    rA = j;
                }
                else if (dist < minDistB)
                {
                    minDistB = dist;
                    rB = j;
                }
            }

            if (rA >= refCount - 1 || rB >= refCount) return;

            if (rA > rB) { C = rA; rA = rB; rB = C; }

            //same way as line creation or not
            isFixHeadingSameWayAsRef = Math.PI - Math.Abs(Math.Abs(pivot.heading - refList[rA].heading) - Math.PI) < glm.PIBy2;

            //which side of the closest point are we on is next
            //calculate endpoints of reference line based on closest point
            refPoint1.easting = refList[rA].easting - (Math.Sin(refList[rA].heading) * 100.0);
            refPoint1.northing = refList[rA].northing - (Math.Cos(refList[rA].heading) * 100.0);

            refPoint2.easting = refList[rA].easting + (Math.Sin(refList[rA].heading) * 100.0);
            refPoint2.northing = refList[rA].northing + (Math.Cos(refList[rA].heading) * 100.0);

            //x2-x1
            double dx = refPoint2.easting - refPoint1.easting;
            //z2-z1
            double dz = refPoint2.northing - refPoint1.northing;

            //how far are we away from the reference line at 90 degrees - 2D cross product and distance
            double distanceFromRefLine = ((dz * pivot.easting) - (dx * pivot.northing) + (refPoint2.easting
                                    * refPoint1.northing) - (refPoint2.northing * refPoint1.easting))
                                    / Math.Sqrt((dz * dz) + (dx * dx));

            deltaOfRefAndAveHeadings = 1;

            //add or subtract pi by 2 depending on which side of ref line
            //move the ABLine over based on the overlap amount set in vehicle
            //if (mf.tool.toolOffset != 0)
            //{
            //    widthMinusOverlap = mf.tool.toolWidth / 2 - mf.tool.toolOverlap;
            //}
            //else
            //{
            //    widthMinusOverlap = mf.tool.toolWidth - mf.tool.toolOverlap;
            //}

            //determine closest point to vehicle spacing
            howManyPathsAway = Math.Round(distanceFromRefLine / widthMinusOverlap, 0, MidpointRounding.AwayFromZero);

            //right or left
            curveNumber = howManyPathsAway;

            //build current list
            isCurveValid = true;

            //build the current line
            curList?.Clear();

            double distSqAway = (widthMinusOverlap * howManyPathsAway * widthMinusOverlap * howManyPathsAway) * 0.999999;

            if (isFixHeadingSameWayAsRef)
            {
                for (int i = 0; i < refCount - 1; i++)
                {
                    var point = new vec3(
                    refList[i].easting + (Math.Sin(glm.PIBy2 + refList[i].heading) * widthMinusOverlap * howManyPathsAway),
                    refList[i].northing + (Math.Cos(glm.PIBy2 + refList[i].heading) * widthMinusOverlap * howManyPathsAway),
                    refList[i].heading);
                    bool Add = true;
                    for (int t = 0; t < refCount; t++)
                    {
                        double dist = ((point.easting - refList[t].easting) * (point.easting - refList[t].easting)) 
                            + ((point.northing - refList[t].northing) * (point.northing - refList[t].northing));
                        if (dist < distSqAway)
                        {
                            Add = false;
                            break;
                        }
                    }
                    if (Add)
                    {
                        if (curList.Count > 0)
                        {
                            double dist = ((point.easting - curList[curList.Count - 1].easting) * (point.easting - curList[curList.Count - 1].easting)) 
                                + ((point.northing - curList[curList.Count - 1].northing) * (point.northing - curList[curList.Count - 1].northing));
                            if (dist > 1)
                                curList.Add(point);
                        }
                        else curList.Add(point);
                    }
                }
            }
            else  //going opposite direction of refList creation
            {
                for (int i = refCount - 1; i >= 0; i--)
                {
                    var point = new vec3(
                    refList[i].easting + (Math.Sin(glm.PIBy2 + refList[i].heading) * widthMinusOverlap * howManyPathsAway),
                    refList[i].northing + (Math.Cos(glm.PIBy2 + refList[i].heading) * widthMinusOverlap * howManyPathsAway),
                    refList[i].heading);
                    bool Add = true;
                    for (int t = refCount - 1; t >= 0; t--)
                    {
                        double dist = ((point.easting - refList[t].easting) * (point.easting - refList[t].easting)) 
                            + ((point.northing - refList[t].northing) * (point.northing - refList[t].northing));
                        if (dist < distSqAway)
                        {
                            Add = false;
                            break;
                        }
                    }
                    if (Add)
                    {
                        if (curList.Count > 0)
                        {
                            double dist = ((point.easting - curList[curList.Count - 1].easting) * (point.easting - curList[curList.Count - 1].easting)) 
                                + ((point.northing - curList[curList.Count - 1].northing) * (point.northing - curList[curList.Count - 1].northing));
                            if (dist > 1)
                                curList.Add(point);
                        }
                        else curList.Add(point);
                    }
                }
            }

            //we are always building in the direction of travel
            isSameWay = true;

            //int cnt;
            //if (style == 1)
            //{
            //    cnt = curList.Count;
            //    vec3[] arr = new vec3[cnt];
            //    cnt--;
            //    curList.CopyTo(arr);
            //    curList.Clear();

            //    //middle points
            //    for (int i = 1; i < cnt; i++)
            //    {
            //        vec3 pt3 = arr[i];
            //        pt3.heading = Math.Atan2(arr[i + 1].easting - arr[i - 1].easting, arr[i + 1].northing - arr[i - 1].northing);
            //        if (pt3.heading < 0) pt3.heading += glm.twoPI;
            //        curList.Add(pt3);
            //    }

            //    return;
            //}

            int cnt = curList.Count;
            if (cnt > 6)
            {
                vec3[] arr = new vec3[cnt];
                curList.CopyTo(arr);

                for (int i = 1; i < (curList.Count - 1); i++)
                {
                    arr[i].easting = (curList[i - 1].easting + curList[i].easting + curList[i + 1].easting) / 3;
                    arr[i].northing = (curList[i - 1].northing + curList[i].northing + curList[i + 1].northing) / 3;
                }
                curList.Clear();

                for (int i = 0; i < (arr.Length - 1); i++)
                {
                    arr[i].heading = Math.Atan2(arr[i + 1].easting - arr[i].easting, arr[i + 1].northing - arr[i].northing);
                    if (arr[i].heading < 0) arr[i].heading += glm.twoPI;
                    if (arr[i].heading >= glm.twoPI) arr[i].heading -= glm.twoPI;
                }

                arr[arr.Length - 1].heading = arr[arr.Length - 2].heading;


                if (mf.tool.isToolTrailing)
                {
                    //depending on hitch is different profile of draft
                    double hitch;
                    if (mf.tool.isToolTBT && mf.tool.toolTankTrailingHitchLength < 0)
                    {
                        hitch = mf.tool.toolTankTrailingHitchLength * 0.85;
                        hitch += mf.tool.toolTrailingHitchLength * 0.65;
                    }
                    else hitch = mf.tool.toolTrailingHitchLength * 1.0;// - mf.vehicle.wheelbase;

                    //move the line forward based on hitch length ratio
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i].easting -= Math.Sin(arr[i].heading) * (hitch);
                        arr[i].northing -= Math.Cos(arr[i].heading) * (hitch);
                    }

                    ////average the points over 3, center weighted
                    //for (int i = 1; i < arr.Length - 2; i++)
                    //{
                    //    arr2[i].easting = (arr[i - 1].easting + arr[i].easting + arr[i + 1].easting) / 3;
                    //    arr2[i].northing = (arr[i - 1].northing + arr[i].northing + arr[i + 1].northing) / 3;
                    //}

                    //recalculate the heading
                    for (int i = 0; i < (arr.Length - 1); i++)
                    {
                        arr[i].heading = Math.Atan2(arr[i + 1].easting - arr[i].easting, arr[i + 1].northing - arr[i].northing);
                        if (arr[i].heading < 0) arr[i].heading += glm.twoPI;
                        if (arr[i].heading >= glm.twoPI) arr[i].heading -= glm.twoPI;
                    }

                    arr[arr.Length - 1].heading = arr[arr.Length - 2].heading;
                }

                //replace the array 
                //curList.AddRange(arr);
                cnt = arr.Length;
                double distance;
                double spacing = 0.5;

                //add the first point of loop - it will be p1
                curList.Add(arr[0]);
                curList.Add(arr[1]);

                for (int i = 0; i < cnt - 3; i++)
                {
                    // add p1
                    curList.Add(arr[i + 1]);

                    distance = glm.Distance(arr[i + 1], arr[i + 2]);

                    if (distance > spacing)
                    {
                        int loopTimes = (int)(distance / spacing + 1);
                        for (int j = 1; j < loopTimes; j++)
                        {
                            vec3 pos = new vec3(glm.Catmull(j / (double)(loopTimes), arr[i], arr[i + 1], arr[i + 2], arr[i + 3]));
                            curList.Add(pos);
                        }
                    }
                }

                curList.Add(arr[cnt - 2]);
                curList.Add(arr[cnt - 1]);

                //to calc heading based on next and previous points to give an average heading.
                cnt = curList.Count;
                arr = new vec3[cnt];
                cnt--;
                curList.CopyTo(arr);
                curList.Clear();

                //middle points
                for (int i = 1; i < cnt; i++)
                {
                    vec3 pt3 = arr[i];
                    pt3.heading = Math.Atan2(arr[i + 1].easting - arr[i - 1].easting, arr[i + 1].northing - arr[i - 1].northing);
                    if (pt3.heading < 0) pt3.heading += glm.twoPI;
                    curList.Add(pt3);
                }
            }
        }
        public void GetCurrentCurveLine(vec3 pivot, vec3 steer)
        {
            if (refList == null || refList.Count < 5) return;
            if (mf.isStanleyUsed)
            {
                if ((Math.Abs(mf.gyd.lastCurveDistance) > (0.5 * mf.tool.toolWidth)) || !isCurveValid)
                {
                    //build reference list every 2 seconds
                    if ((mf.secondsSinceStart - lastSecond) > 2)
                    {
                        lastSecond = mf.secondsSinceStart;

                        BuildCurveCurrentList(pivot);
                    }
                }
            }
            else
            {
                if ((Math.Abs(lastCurveDistance) > (0.5 * mf.tool.toolWidth)) || !isCurveValid)
                {
                    //build reference list every 2 seconds
                    if ((mf.secondsSinceStart - lastSecond) > 2)
                    {
                        lastSecond = mf.secondsSinceStart;

                        BuildCurveCurrentList(pivot);
                    }
                }
            }


            double dist, dx, dz;
            double minDistA = 1000000, minDistB = 1000000;
            int ptCount = curList.Count;

            if (ptCount > 0)
            {
                if (mf.isStanleyUsed)
                {
                    mf.gyd.StanleyGuidanceCurve(pivot, steer, ref curList);

                }
                else    // Pure Pursuit ------------------------------------------
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

                    //how far from current AB Line is fix
                    distanceFromCurrentLinePivot = ((dz * pivot.easting) - (dx * pivot.northing) + (curList[B].easting
                                * curList[A].northing) - (curList[B].northing * curList[A].easting))
                                    / Math.Sqrt((dz * dz) + (dx * dx));

                    //are we on the right side or not
                    isOnRightSideCurrentLine = distanceFromCurrentLinePivot > 0;

                    //integral slider is set to 0
                    if (mf.vehicle.purePursuitIntegralGain != 0)
                    {
                        pivotDistanceError = distanceFromCurrentLinePivot * 0.2 + pivotDistanceError * 0.8;

                        if (counter2++ > 4)
                        {
                            pivotDerivative = pivotDistanceError - pivotDistanceErrorLast;
                            pivotDistanceErrorLast = pivotDistanceError;
                            counter2 = 0;
                            pivotDerivative *= 2;

                            //limit the derivative
                            //if (pivotDerivative > 0.03) pivotDerivative = 0.03;
                            //if (pivotDerivative < -0.03) pivotDerivative = -0.03;
                            //if (Math.Abs(pivotDerivative) < 0.01) pivotDerivative = 0;
                        }

                        //pivotErrorTotal = pivotDistanceError + pivotDerivative;

                        if (mf.isAutoSteerBtnOn
                            && Math.Abs(pivotDerivative) < (0.1)
                            && mf.avgSpeed > 2.5
                            && !mf.yt.isYouTurnTriggered)
                            //&& Math.Abs(pivotDistanceError) < 0.2)
                       {
                            //if over the line heading wrong way, rapidly decrease integral
                            if ((inty < 0 && distanceFromCurrentLinePivot < 0) || (inty > 0 && distanceFromCurrentLinePivot > 0))
                            {
                                inty += pivotDistanceError * mf.vehicle.purePursuitIntegralGain * -0.04;
                            }
                            else
                            {
                                if (Math.Abs(distanceFromCurrentLinePivot) > 0.02)
                                {
                                    inty += pivotDistanceError * mf.vehicle.purePursuitIntegralGain * -0.02;
                                    if (inty > 0.2) inty = 0.2;
                                    else if (inty < -0.2) inty = -0.2;
                                }
                            }
                        }
                        else inty *= 0.95;
                    }
                    else inty = 0;


                    //absolute the distance
                    distanceFromCurrentLinePivot = Math.Abs(distanceFromCurrentLinePivot);

                    // ** Pure pursuit ** - calc point on ABLine closest to current position
                    double U = (((pivot.easting - curList[A].easting) * dx)
                                + ((pivot.northing - curList[A].northing) * dz))
                                / ((dx * dx) + (dz * dz));

                    rEastCu = curList[A].easting + (U * dx);
                    rNorthCu = curList[A].northing + (U * dz);
                    manualUturnHeading = curList[A].heading;
                    //double minx, maxx, miny, maxy;

                    //used for accumulating distance to find goal point
                    double distSoFar;

                    //update base on autosteer settings and distance from line
                    double goalPointDistance = mf.vehicle.UpdateGoalPointDistance(distanceFromCurrentLinePivot);

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
                    //double localHeading = glm.twoPI - mf.fixHeading;

                    double localHeading;
                    if (isABSameAsVehicleHeading) localHeading = glm.twoPI - mf.fixHeading + inty;
                    else localHeading = glm.twoPI - mf.fixHeading - inty;

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
                                (Math.Atan((mf.vehicle.wheelbase * mf.vehicle.maxAngularVelocity) / (glm.twoPI * mf.avgSpeed * 0.277777)))
                            : (Math.Atan((mf.vehicle.wheelbase * -mf.vehicle.maxAngularVelocity) / (glm.twoPI * mf.avgSpeed * 0.277777))));
                    }

                    lastCurveDistance = distanceFromCurrentLinePivot;

                    //Convert to centimeters
                    distanceFromCurrentLinePivot = Math.Round(distanceFromCurrentLinePivot * 1000.0, MidpointRounding.AwayFromZero);

                    //distance is negative if on left, positive if on right
                    //if you're going the opposite direction left is right and right is left
                    //double temp;
                    if (isABSameAsVehicleHeading)
                    {
                        //temp = (abHeading);
                        if (!isOnRightSideCurrentLine) distanceFromCurrentLinePivot *= -1.0;
                    }

                    //opposite way so right is left
                    else
                    {
                        //temp = (abHeading - Math.PI);
                        //if (temp < 0) temp = (temp + glm.twoPI);
                        //temp = glm.toDegrees(temp);
                        if (isOnRightSideCurrentLine) distanceFromCurrentLinePivot *= -1.0;
                    }

                    bool isBackwards = Math.PI - Math.Abs(Math.Abs(pivot.heading - curList[A].heading) - Math.PI) > glm.PIBy2;

                    if (isBackwards)
                    {
                        isCurveValid = false;
                        lastSecond = 0;
                    }


                    mf.guidanceLineDistanceOff = mf.distanceDisplayPivot = (Int16)distanceFromCurrentLinePivot;
                    mf.guidanceLineSteerAngle = (Int16)(steerAngleCu * 100);
                }

                if (mf.yt.isYouTurnTriggered)
                {
                    lastCurveDistance = 10000;
                    //do the pure pursuit from youTurn
                    mf.yt.DistanceFromYouTurnLine();

                    //now substitute what it thinks are AB line values with auto turn values
                    steerAngleCu = mf.yt.steerAngleYT;
                    distanceFromCurrentLinePivot = mf.yt.distanceFromCurrentLine;

                    goalPointCu = mf.yt.goalPointYT;
                    radiusPointCu.easting = mf.yt.radiusPointYT.easting;
                    radiusPointCu.northing = mf.yt.radiusPointYT.northing;
                    ppRadiusCu = mf.yt.ppRadiusYT;
                }
            }
            else
            {
                //invalid distance so tell AS module
                distanceFromCurrentLinePivot = 32000;
                mf.guidanceLineDistanceOff = 32000;
                lastCurveDistance = 10000;
            }
        }

        public void DrawCurve()
        {
            if (desList.Count > 0)
            {
                GL.Color3(0.95f, 0.42f, 0.750f);
                GL.Begin(PrimitiveType.LineStrip);
                for (int h = 0; h < desList.Count; h++) GL.Vertex3(desList[h].easting, desList[h].northing, 0);
                GL.End();
            }


            int ptCount = refList.Count;
            if (refList.Count == 0) return;

            GL.LineWidth(mf.ABLine.lineWidth);
            GL.Color3(0.96, 0.2f, 0.2f);
            GL.Begin(PrimitiveType.Lines);
            for (int h = 0; h < ptCount; h++) GL.Vertex3(refList[h].easting, refList[h].northing, 0);
            if (!mf.curve.isCurveSet)
            {
                GL.Color3(0.930f, 0.0692f, 0.260f);
                ptCount--;
                GL.Vertex3(refList[ptCount].easting, refList[ptCount].northing, 0);
                GL.Vertex3(mf.pivotAxlePos.easting, mf.pivotAxlePos.northing, 0);
            }
            GL.End();

            //GL.PointSize(8.0f);
            //GL.Begin(PrimitiveType.Points);
            //GL.Color3(1.0f, 1.0f, 0.0f);
            ////GL.Vertex3(goalPointAB.easting, goalPointAB.northing, 0.0);
            //GL.Vertex3(mf.gyd.rEastSteer, mf.gyd.rNorthSteer, 0.0);
            //GL.Color3(1.0f, 0.0f, 1.0f);
            //GL.Vertex3(mf.gyd.rEastPivot, mf.gyd.rNorthPivot, 0.0);
            //GL.End();
            //GL.PointSize(1.0f);




            if (mf.font.isFontOn && refList.Count > 410)
            {
                GL.Color3(0.40f, 0.90f, 0.95f);
                mf.font.DrawText3D(refList[201].easting, refList[201].northing, "&A");
                mf.font.DrawText3D(refList[refList.Count - 200].easting, refList[refList.Count - 200].northing, "&B");
            }

            //just draw ref and smoothed line if smoothing window is open
            if (isSmoothWindowOpen)
            {
                ptCount = smooList.Count;
                if (smooList.Count == 0) return;

                GL.LineWidth(mf.ABLine.lineWidth);
                GL.Color3(0.930f, 0.92f, 0.260f);
                GL.Begin(PrimitiveType.Lines);
                for (int h = 0; h < ptCount; h++) GL.Vertex3(smooList[h].easting, smooList[h].northing, 0);
                GL.End();
            }
            else //normal. Smoothing window is not open.
            {
                ptCount = curList.Count;
                if (ptCount > 0 && isCurveSet)
                {
                    GL.PointSize(2);

                    GL.Color3(0.95f, 0.2f, 0.95f);
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
                            GL.Color3(0.53f, 0.530f, 0.950f);
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
                        GL.PointSize(8.0f);
                        GL.Begin(PrimitiveType.Points);
                        GL.Color3(1.0f, 0.95f, 0.195f);
                        GL.Vertex3(goalPointCu.easting, goalPointCu.northing, 0.0);
                        GL.End();
                    }

                    mf.yt.DrawYouTurn();

                    if (mf.yt.isYouTurnTriggered)
                    {
                        GL.Color3(0.95f, 0.95f, 0.25f);
                        GL.LineWidth(mf.ABLine.lineWidth);
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


            //if (isEditing)
            //{
            //    int ptCount = refList.Count;
            //    if (refList.Count == 0) return;

            //    GL.LineWidth(mf.ABLine.lineWidth);
            //    GL.Color3(0.930f, 0.2f, 0.260f);
            //    GL.Begin(PrimitiveType.Lines);
            //    for (int h = 0; h < ptCount; h++) GL.Vertex3(refList[h].easting, refList[h].northing, 0);
            //    GL.End();

            //    //current line
            //    if (curList.Count > 0 && isCurveSet)
            //    {
            //        ptCount = curList.Count;
            //        GL.Color3(0.95f, 0.2f, 0.950f);
            //        GL.Begin(PrimitiveType.LineStrip);
            //        for (int h = 0; h < ptCount; h++) GL.Vertex3(curList[h].easting, curList[h].northing, 0);
            //        GL.End();
            //    }


            //if (mf.camera.camSetDistance > -200)
            //{
            //    double toolWidth2 = mf.tool.toolWidth - mf.tool.toolOverlap;
            //    double cosHeading2 = Math.Cos(-mf.curve.aveLineHeading);
            //    double sinHeading2 = Math.Sin(-mf.curve.aveLineHeading);

            //    GL.Color3(0.8f, 0.3f, 0.2f);
            //    GL.PointSize(2);
            //    GL.Begin(PrimitiveType.Points);

            //    ptCount = refList.Count;
            //    for (int i = 1; i <= 6; i++)
            //    {
            //        for (int h = 0; h < ptCount; h++)
            //            GL.Vertex3((cosHeading2 * toolWidth2) + mf.curve.refList[h].easting,
            //                          (sinHeading2 * toolWidth2) + mf.curve.refList[h].northing, 0);
            //        toolWidth2 = toolWidth2 + mf.tool.toolWidth - mf.tool.toolOverlap;
            //    }

            //    GL.End();
            //}
            //}
        }

        public void BuildTram()
        {
            mf.tram.BuildTramBnd();
            mf.tram.tramList?.Clear();
            mf.tram.tramArr?.Clear();

            bool isBndExist = mf.bnd.bndArr.Count != 0;

            double pass = 0.5;

            int refCount = refList.Count;

            int cntr = 0;
            if (isBndExist) cntr = 1;

            for (int i = cntr; i <= mf.tram.passes; i++)
            {
                double distSqAway = (mf.tram.tramWidth * (i + 0.5) - mf.tram.halfWheelTrack +mf.tool.halfToolWidth)
                        * (mf.tram.tramWidth * (i + 0.5) - mf.tram.halfWheelTrack +mf.tool.halfToolWidth) * 0.999999;

                mf.tram.tramArr = new List<vec2>();
                mf.tram.tramList.Add(mf.tram.tramArr);
                for (int j = 0; j < refCount; j += 1)
                {
                    var point = new vec2(
                    (Math.Sin(glm.PIBy2 + refList[j].heading) * 
                        ((mf.tram.tramWidth * (pass + i)) - mf.tram.halfWheelTrack + mf.tool.halfToolWidth)) + refList[j].easting,
                    (Math.Cos(glm.PIBy2 + refList[j].heading) * 
                        ((mf.tram.tramWidth * (pass + i)) - mf.tram.halfWheelTrack + mf.tool.halfToolWidth)) + refList[j].northing);

                    bool Add = true;
                    for (int t = 0; t < refCount; t++)
                    {
                        //distance check to be not too close to ref line
                        double dist = ((point.easting - refList[t].easting) * (point.easting - refList[t].easting))
                            + ((point.northing - refList[t].northing) * (point.northing - refList[t].northing));
                        if (dist < distSqAway)
                        {
                            Add = false;
                            break;
                        }
                    }
                    if (Add)
                    {
                        if (isBndExist)
                        {
                            if (mf.tram.tramArr.Count > 0)
                            {
                                //a new point only every 2 meters
                                double dist = ((point.easting - mf.tram.tramArr[mf.tram.tramArr.Count - 1].easting) * (point.easting - mf.tram.tramArr[mf.tram.tramArr.Count - 1].easting))
                                    + ((point.northing - mf.tram.tramArr[mf.tram.tramArr.Count - 1].northing) * (point.northing - mf.tram.tramArr[mf.tram.tramArr.Count - 1].northing));
                                if (dist > 2)
                                {
                                    //if inside the boundary, add
                                    if (mf.bnd.bndArr[0].IsPointInsideBoundaryEar(point))
                                    {
                                        mf.tram.tramArr.Add(point);
                                    }
                                }
                            }
                            else
                            {
                                //need a first point to do distance
                                if (mf.bnd.bndArr[0].IsPointInsideBoundaryEar(point))
                                {
                                    mf.tram.tramArr.Add(point);
                                }
                            }
                        }
                        else
                        {
                            //no boundary to cull points
                            if (mf.tram.tramArr.Count > 0)
                            {
                                double dist = ((point.easting - mf.tram.tramArr[mf.tram.tramArr.Count - 1].easting) * (point.easting - mf.tram.tramArr[mf.tram.tramArr.Count - 1].easting))
                                    + ((point.northing - mf.tram.tramArr[mf.tram.tramArr.Count - 1].northing) * (point.northing - mf.tram.tramArr[mf.tram.tramArr.Count - 1].northing));
                                if (dist > 2)
                                {
                                    mf.tram.tramArr.Add(point);
                                }
                            }
                            else
                            {
                                mf.tram.tramArr.Add(point);
                            }

                        }
                    }

                }
            }

            for (int i = cntr; i <= mf.tram.passes; i++)
            {
                double distSqAway = (mf.tram.tramWidth * (i + 0.5) + mf.tram.halfWheelTrack + mf.tool.halfToolWidth)
                        * (mf.tram.tramWidth * (i + 0.5) + mf.tram.halfWheelTrack + mf.tool.halfToolWidth) * 0.999999;

                mf.tram.tramArr = new List<vec2>();
                mf.tram.tramList.Add(mf.tram.tramArr);
                for (int j = 0; j < refCount; j += 1)
                {
                    var point = new vec2(
                    (Math.Sin(glm.PIBy2 + refList[j].heading) *
                        ((mf.tram.tramWidth * (pass + i)) + mf.tram.halfWheelTrack + mf.tool.halfToolWidth)) + refList[j].easting,
                    (Math.Cos(glm.PIBy2 + refList[j].heading) *
                        ((mf.tram.tramWidth * (pass + i)) + mf.tram.halfWheelTrack + mf.tool.halfToolWidth)) + refList[j].northing);

                    bool Add = true;
                    for (int t = 0; t < refCount; t++)
                    {
                        //distance check to be not too close to ref line
                        double dist = ((point.easting - refList[t].easting) * (point.easting - refList[t].easting))
                            + ((point.northing - refList[t].northing) * (point.northing - refList[t].northing));
                        if (dist < distSqAway)
                        {
                            Add = false;
                            break;
                        }
                    }
                    if (Add)
                    {
                        if (isBndExist)
                        {
                            if (mf.tram.tramArr.Count > 0)
                            {
                                //a new point only every 2 meters
                                double dist = ((point.easting - mf.tram.tramArr[mf.tram.tramArr.Count - 1].easting) * (point.easting - mf.tram.tramArr[mf.tram.tramArr.Count - 1].easting))
                                    + ((point.northing - mf.tram.tramArr[mf.tram.tramArr.Count - 1].northing) * (point.northing - mf.tram.tramArr[mf.tram.tramArr.Count - 1].northing));
                                if (dist > 2)
                                {
                                    //if inside the boundary, add
                                    if (mf.bnd.bndArr[0].IsPointInsideBoundaryEar(point))
                                    {
                                        mf.tram.tramArr.Add(point);
                                    }
                                }
                            }
                            else
                            {
                                //need a first point to do distance
                                if (mf.bnd.bndArr[0].IsPointInsideBoundaryEar(point))
                                {
                                    mf.tram.tramArr.Add(point);
                                }
                            }
                        }
                        else
                        {
                            //no boundary to cull points
                            if (mf.tram.tramArr.Count > 0)
                            {
                                double dist = ((point.easting - mf.tram.tramArr[mf.tram.tramArr.Count - 1].easting) * (point.easting - mf.tram.tramArr[mf.tram.tramArr.Count - 1].easting))
                                    + ((point.northing - mf.tram.tramArr[mf.tram.tramArr.Count - 1].northing) * (point.northing - mf.tram.tramArr[mf.tram.tramArr.Count - 1].northing));
                                if (dist > 2)
                                {
                                    mf.tram.tramArr.Add(point);
                                }
                            }
                            else
                            {
                                mf.tram.tramArr.Add(point);
                            }

                        }
                    }
                }
            }
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
            if (cnt > 0)
            {
                vec3[] arr = new vec3[cnt];
                cnt--;
                refList.CopyTo(arr);
                refList.Clear();

                //middle points
                for (int i = 1; i < cnt; i++)
                {
                    vec3 pt3 = arr[i];
                    pt3.heading = Math.Atan2(arr[i + 1].easting - arr[i - 1].easting, arr[i + 1].northing - arr[i - 1].northing);
                    if (pt3.heading < 0) pt3.heading += glm.twoPI;
                    refList.Add(pt3);
                }
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

        public void SnapABCurve()
        {
            double headingAt90;
            isCurveValid = false;
            lastSecond = 0;

            //calculate the heading 90 degrees to ref ABLine heading
            if (isOnRightSideCurrentLine)
            {
                headingAt90 = glm.PIBy2;
            }
            else
            {
                headingAt90 = -glm.PIBy2;
            }

            double snapD;
            if (mf.isStanleyUsed) snapD = mf.gyd.distanceFromCurrentLinePivot*0.001;
            else snapD = distanceFromCurrentLinePivot*0.001;

            if (isFixHeadingSameWayAsRef)
            {
                moveDistance += snapD;
            }
            else
            {
                headingAt90 += Math.PI;
                moveDistance -= snapD;
            }

            int cnt = refList.Count;
            vec3[] arr = new vec3[cnt];
            refList.CopyTo(arr);
            refList.Clear();

            for (int i = 0; i < cnt; i++)
            {
                arr[i].easting = (Math.Sin(headingAt90 + arr[i].heading) * Math.Abs(snapD) ) + arr[i].easting;
                arr[i].northing = (Math.Cos(headingAt90 + arr[i].heading) * Math.Abs(snapD)) + arr[i].northing;
                refList.Add(arr[i]);
            }            
        }

        public void MoveABCurve(double dist)
        {
            double headingAt90;
            isCurveValid = false;
            lastSecond = 0;

            //calculate the heading 90 degrees to ref ABLine heading

            if (isFixHeadingSameWayAsRef)
            {
                headingAt90 = glm.PIBy2;
                moveDistance += dist;
            }
            else
            {
                headingAt90 = -glm.PIBy2;
                moveDistance -= dist;
            }

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
            return _ = r.northing >= minx && r.northing <= maxx && (r.easting >= miny && r.easting <= maxy);
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
        }

        ////draw the guidance line
    }

    public class CCurveLines
    {
        public List<vec3> curvePts = new List<vec3>();
        public double aveHeading = 3;
        public string Name = "aa";
    }

}


//for (int i = 1; i <= mf.tram.passes; i++)
//{
//    tramArr = new List<vec2>();
//    tramList.Add(tramArr);

//    List<vec2> tramTemp = new List<vec2>();

//    for (int j = 0; j < tramRef.Count; j++)
//    {
//        P1.easting = (hsin * ((mf.tram.tramWidth * (pass + i)) - mf.tram.halfWheelTrack + mf.tool.halfToolWidth)) + tramRef[j].easting;
//        P1.northing = (hcos * ((mf.tram.tramWidth * (pass + i)) - mf.tram.halfWheelTrack + mf.tool.halfToolWidth)) + tramRef[j].northing;

//        if (isBndExist)
//        {
//            if (mf.bnd.bndArr[0].IsPointInsideBoundaryEar(P1))
//            {
//                tramTemp.Add(P1);
//                P1.easting = (hsin * mf.vehicle.trackWidth) + P1.easting;
//                P1.northing = (hcos * mf.vehicle.trackWidth) + P1.northing;
//                tramTemp.Add(P1);
//            }
//        }
//        else
//        {
//            tramTemp.Add(P1);

//            P1.easting = (hsin * mf.vehicle.trackWidth) + P1.easting;
//            P1.northing = (hcos * mf.vehicle.trackWidth) + P1.northing;
//            tramTemp.Add(P1);
//        }

//        if (tramTemp.Count > 6)
//        {
//            vec2[] array = new vec2[tramTemp.Count];
//            tramTemp.CopyTo(array);

//            tramArr.Add(array[0]);
//            tramArr.Add(array[1]);
//            tramArr.Add(array[tramTemp.Count - 2]);
//            tramArr.Add(array[tramTemp.Count - 1]);
//        }

//    }
//}

