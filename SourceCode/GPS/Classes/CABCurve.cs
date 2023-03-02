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
        public bool isBtnCurveOn, isCurveSet, isOkToAddDesPoints;

        public double distanceFromCurrentLinePivot;
        public double distanceFromRefLine;

        public bool isHeadingSameWay = true;

        public double howManyPathsAway;
        public vec2 refPoint1 = new vec2(1, 1), refPoint2 = new vec2(2, 2);

        public double refHeading, moveDistance;
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

        public bool isCurveValid, isLateralTriggered;

        public double lastSecond = 0;

        public List<vec3> desList = new List<vec3>();
        public string desName = "**";

        public double pivotDistanceError, pivotDistanceErrorLast, pivotDerivative, pivotDerivativeSmoothed, lastCurveDistance = 10000;
        //derivative counters
        private int counter2;
        public double inty;

        public CABCurve(FormGPS _f)
        {
            //constructor
            mf = _f;
            refList.Capacity = 1024;
            curList.Capacity = 1024;
        }

        public void BuildCurveCurrentList(vec3 pivot)
        {
            double minDistA = 1000000, minDistB;
            //move the ABLine over based on the overlap amount set in vehicle
            double widthMinusOverlap = mf.tool.width - mf.tool.overlap;

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
                double dist = ((mf.guidanceLookPos.easting - refList[j].easting) * (mf.guidanceLookPos.easting - refList[j].easting))
                                + ((mf.guidanceLookPos.northing - refList[j].northing) * (mf.guidanceLookPos.northing - refList[j].northing));
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
                double dist = ((mf.guidanceLookPos.easting - refList[j].easting) * (mf.guidanceLookPos.easting - refList[j].easting))
                                + ((mf.guidanceLookPos.northing - refList[j].northing) * (mf.guidanceLookPos.northing - refList[j].northing));
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

            //reset the line over jump
            isLateralTriggered = false;

            if (rA >= refCount - 1 || rB >= refCount) return;

            if (rA > rB) { C = rA; rA = rB; rB = C; }

            //same way as line creation or not
            isHeadingSameWay = Math.PI - Math.Abs(Math.Abs(pivot.heading - refList[rA].heading) - Math.PI) < glm.PIBy2;

            if (mf.yt.isYouTurnTriggered) isHeadingSameWay = !isHeadingSameWay;

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
            distanceFromRefLine = ((dz * mf.guidanceLookPos.easting) - (dx * mf.guidanceLookPos.northing) + (refPoint2.easting
                                * refPoint1.northing) - (refPoint2.northing * refPoint1.easting))
                                / Math.Sqrt((dz * dz) + (dx * dx));

            double RefDist = (distanceFromRefLine + (isHeadingSameWay ? mf.tool.offset : -mf.tool.offset)) / widthMinusOverlap;
            if (RefDist < 0) howManyPathsAway = (int)(RefDist - 0.5);
            else howManyPathsAway = (int)(RefDist + 0.5);

            //build current list
            isCurveValid = true;

            //build the current line
            curList?.Clear();

            double distAway = widthMinusOverlap * howManyPathsAway + (isHeadingSameWay ? -mf.tool.offset : mf.tool.offset);

            double distSqAway = (distAway * distAway) - 0.01;

            for (int i = 0; i < refCount - 1; i++)
            {
                vec3 point = new vec3(
                refList[i].easting + (Math.Sin(glm.PIBy2 + refList[i].heading) * distAway),
                refList[i].northing + (Math.Cos(glm.PIBy2 + refList[i].heading) * distAway),
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
                    if (mf.tool.isToolTBT && mf.tool.tankTrailingHitchLength < 0)
                    {
                        hitch = mf.tool.tankTrailingHitchLength * 0.85;
                        hitch += mf.tool.trailingHitchLength * 0.65;
                    }
                    else hitch = mf.tool.trailingHitchLength * 1.0;// - mf.vehicle.wheelbase;

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
                double spacing = 2;

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
            lastSecond = mf.secondsSinceStart;
        }

        public void GetCurrentCurveLine(vec3 pivot, vec3 steer)
        {
            if (refList == null || refList.Count < 5) return;

            //build new current ref line if required
            if (!isCurveValid || ((mf.secondsSinceStart - lastSecond) > 0.66 
                && (!mf.isAutoSteerBtnOn || mf.mc.steerSwitchHigh)))
                BuildCurveCurrentList(pivot);

            double dist, dx, dz;
            double minDistA = 1000000, minDistB = 1000000;
            int ptCount = curList.Count;

            if (ptCount > 0)
            {
                if (mf.yt.isYouTurnTriggered && mf.yt.DistanceFromYouTurnLine())//do the pure pursuit from youTurn
                {
                    //now substitute what it thinks are AB line values with auto turn values
                    steerAngleCu = mf.yt.steerAngleYT;
                    distanceFromCurrentLinePivot = mf.yt.distanceFromCurrentLine;

                    goalPointCu = mf.yt.goalPointYT;
                    radiusPointCu.easting = mf.yt.radiusPointYT.easting;
                    radiusPointCu.northing = mf.yt.radiusPointYT.northing;
                    ppRadiusCu = mf.yt.ppRadiusYT;
                    mf.vehicle.modeActualXTE = (distanceFromCurrentLinePivot);
                }
                else if (mf.isStanleyUsed)//Stanley
                {
                    mf.gyd.StanleyGuidanceCurve(pivot, steer, ref curList);
                }
                else// Pure Pursuit ------------------------------------------
                {
                    //find the closest 2 points to current fix
                    for (int t = 0; t < ptCount; t++)
                    {
                        dist = glm.DistanceSquared(pivot, curList[t]);

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

                    //integral slider is set to 0
                    if (mf.vehicle.purePursuitIntegralGain != 0 && !mf.isReverse)
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

                        if (mf.isAutoSteerBtnOn && mf.avgSpeed > 2.5 && Math.Abs(pivotDerivative) < 0.1)
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

                    // ** Pure pursuit ** - calc point on ABLine closest to current position
                    double U = (((pivot.easting - curList[A].easting) * dx)
                                + ((pivot.northing - curList[A].northing) * dz))
                                / ((dx * dx) + (dz * dz));

                    rEastCu = curList[A].easting + (U * dx);
                    rNorthCu = curList[A].northing + (U * dz);
                    manualUturnHeading = curList[A].heading;
                    //double minx, maxx, miny, maxy;

                    //update base on autosteer settings and distance from line
                    double goalPointDistance = mf.vehicle.UpdateGoalPointDistance();

                    bool ReverseHeading = mf.isReverse ? !isHeadingSameWay : isHeadingSameWay;

                    int count = ReverseHeading ? 1 : -1;
                    vec3 start = new vec3(rEastCu, rNorthCu, 0);
                    double distSoFar = 0;

                    for (int i = ReverseHeading ? B : A; i < ptCount && i >= 0; i += count)
                    {
                        // used for calculating the length squared of next segment.
                        double tempDist = glm.Distance(start, curList[i]);

                        //will we go too far?
                        if ((tempDist + distSoFar) > goalPointDistance)
                        {
                            double j = (goalPointDistance - distSoFar) / tempDist; // the remainder to yet travel

                            goalPointCu.easting = (((1 - j) * start.easting) + (j * curList[i].easting));
                            goalPointCu.northing = (((1 - j) * start.northing) + (j * curList[i].northing));
                            break;
                        }
                        else distSoFar += tempDist;
                        start = curList[i];
                    }

                    //calc "D" the distance from pivot axle to lookahead point
                    double goalPointDistanceSquared = glm.DistanceSquared(goalPointCu.northing, goalPointCu.easting, pivot.northing, pivot.easting);

                    //calculate the the delta x in local coordinates and steering angle degrees based on wheelbase
                    //double localHeading = glm.twoPI - mf.fixHeading;

                    double localHeading;
                    if (ReverseHeading) localHeading = glm.twoPI - mf.fixHeading + inty;
                    else localHeading = glm.twoPI - mf.fixHeading - inty;

                    ppRadiusCu = goalPointDistanceSquared / (2 * (((goalPointCu.easting - pivot.easting) * Math.Cos(localHeading)) + ((goalPointCu.northing - pivot.northing) * Math.Sin(localHeading))));

                    steerAngleCu = glm.toDegrees(Math.Atan(2 * (((goalPointCu.easting - pivot.easting) * Math.Cos(localHeading))
                        + ((goalPointCu.northing - pivot.northing) * Math.Sin(localHeading))) * mf.vehicle.wheelbase / goalPointDistanceSquared));

                    if (mf.ahrs.imuRoll != 88888)
                        steerAngleCu += mf.ahrs.imuRoll * -mf.gyd.sideHillCompFactor;

                    if (steerAngleCu < -mf.vehicle.maxSteerAngle) steerAngleCu = -mf.vehicle.maxSteerAngle;
                    if (steerAngleCu > mf.vehicle.maxSteerAngle) steerAngleCu = mf.vehicle.maxSteerAngle;

                    //if (ppRadiusCu < -500) ppRadiusCu = -500;
                    //if (ppRadiusCu > 500) ppRadiusCu = 500;

                    //radiusPointCu.easting = pivot.easting + (ppRadiusCu * Math.Cos(localHeading));
                    //radiusPointCu.northing = pivot.northing + (ppRadiusCu * Math.Sin(localHeading));

                    ////angular velocity in rads/sec  = 2PI * m/sec * radians/meters
                    //double angVel = glm.twoPI * 0.277777 * mf.pn.speed * (Math.Tan(glm.toRadians(steerAngleCu))) / mf.vehicle.wheelbase;

                    ////clamp the steering angle to not exceed safe angular velocity
                    //if (Math.Abs(angVel) > mf.vehicle.maxAngularVelocity)
                    //{
                    //    steerAngleCu = glm.toDegrees(steerAngleCu > 0 ?
                    //            (Math.Atan((mf.vehicle.wheelbase * mf.vehicle.maxAngularVelocity) / (glm.twoPI * mf.avgSpeed * 0.277777)))
                    //        : (Math.Atan((mf.vehicle.wheelbase * -mf.vehicle.maxAngularVelocity) / (glm.twoPI * mf.avgSpeed * 0.277777))));
                    //}

                    if (!isHeadingSameWay)
                        distanceFromCurrentLinePivot *= -1.0;

                    //used for acquire/hold mode 
                    mf.vehicle.modeActualXTE = (distanceFromCurrentLinePivot);

                    double steerHeadingError = (pivot.heading - curList[A].heading);
                    //Fix the circular error
                    if (steerHeadingError > Math.PI)
                        steerHeadingError -= Math.PI;
                    else if (steerHeadingError < -Math.PI)
                        steerHeadingError += Math.PI;

                    if (steerHeadingError > glm.PIBy2)
                        steerHeadingError -= Math.PI;
                    else if (steerHeadingError < -glm.PIBy2)
                        steerHeadingError += Math.PI;

                    mf.vehicle.modeActualHeadingError = glm.toDegrees(steerHeadingError);


                    //Convert to centimeters
                    mf.guidanceLineDistanceOff = (short)Math.Round(distanceFromCurrentLinePivot * 1000.0, MidpointRounding.AwayFromZero);
                    mf.guidanceLineSteerAngle = (short)(steerAngleCu * 100);
                }
            }
            else
            {
                //invalid distance so tell AS module
                distanceFromCurrentLinePivot = 32000;
                mf.guidanceLineDistanceOff = 32000;
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
            if (refList == null|| refList.Count == 0)  return;

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

            if (mf.font.isFontOn && refList.Count > 410)
            {
                GL.Color3(0.40f, 0.90f, 0.95f);
                mf.font.DrawText3D(refList[201].easting, refList[201].northing, "&A");
                mf.font.DrawText3D(refList[refList.Count - 200].easting, refList[refList.Count - 200].northing, "&B");
            }

            //just draw ref and smoothed line if smoothing window is open
            if (isSmoothWindowOpen)
            {
                if (smooList == null || smooList.Count == 0) return;

                GL.LineWidth(mf.ABLine.lineWidth);
                GL.Color3(0.930f, 0.92f, 0.260f);
                GL.Begin(PrimitiveType.Lines);
                for (int h = 0; h < smooList.Count; h++) GL.Vertex3(smooList[h].easting, smooList[h].northing, 0);
                GL.End();
            }
            else //normal. Smoothing window is not open.
            {
                if (curList.Count > 0 && isCurveSet)
                {
                    GL.PointSize(4);
                    GL.Color3(0.95f, 0.2f, 0.95f);
                    GL.Begin(PrimitiveType.LineStrip);
                    for (int h = 0; h < curList.Count; h++) GL.Vertex3(curList[h].easting, curList[h].northing, 0);
                    GL.End();

                    if (!mf.isStanleyUsed && mf.camera.camSetDistance > -200)
                    {
                        //Draw lookahead Point
                        GL.PointSize(8.0f);
                        GL.Begin(PrimitiveType.Points);
                        GL.Color3(1.0f, 0.95f, 0.195f);
                        GL.Vertex3(goalPointCu.easting, goalPointCu.northing, 0.0);
                        GL.End();
                    }

                    mf.yt.DrawYouTurn();
                }
            }
            GL.PointSize(1.0f);
        }

        public void BuildTram()
        {
            mf.tram.BuildTramBnd();
            mf.tram.tramList?.Clear();
            mf.tram.tramArr?.Clear();

            bool isBndExist = mf.bnd.bndList.Count != 0;

            double pass = 0.5;

            int refCount = refList.Count;

            int cntr = 0;
            if (isBndExist) cntr = 1;

            for (int i = cntr; i <= mf.tram.passes; i++)
            {
                double distSqAway = (mf.tram.tramWidth * (i + 0.5) - mf.tram.halfWheelTrack + mf.tool.halfWidth)
                        * (mf.tram.tramWidth * (i + 0.5) - mf.tram.halfWheelTrack + mf.tool.halfWidth) * 0.999999;

                mf.tram.tramArr = new List<vec2>
                {
                    Capacity = 128
                };

                mf.tram.tramList.Add(mf.tram.tramArr);
                for (int j = 0; j < refCount; j += 1)
                {
                    vec2 point = new vec2(
                    (Math.Sin(glm.PIBy2 + refList[j].heading) *
                        ((mf.tram.tramWidth * (pass + i)) - mf.tram.halfWheelTrack + mf.tool.halfWidth)) + refList[j].easting,
                    (Math.Cos(glm.PIBy2 + refList[j].heading) *
                        ((mf.tram.tramWidth * (pass + i)) - mf.tram.halfWheelTrack + mf.tool.halfWidth)) + refList[j].northing);

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
                        //a new point only every 2 meters
                        double dist = mf.tram.tramArr.Count > 0 ? ((point.easting - mf.tram.tramArr[mf.tram.tramArr.Count - 1].easting) * (point.easting - mf.tram.tramArr[mf.tram.tramArr.Count - 1].easting))
                            + ((point.northing - mf.tram.tramArr[mf.tram.tramArr.Count - 1].northing) * (point.northing - mf.tram.tramArr[mf.tram.tramArr.Count - 1].northing)) : 3.0;
                        if (dist > 2)
                        {
                            //if inside the boundary, add
                            if (!isBndExist || mf.bnd.bndList[0].fenceLineEar.IsPointInPolygon(point))
                            {
                                mf.tram.tramArr.Add(point);
                            }
                        }
                    }
                }
            }

            for (int i = cntr; i <= mf.tram.passes; i++)
            {
                double distSqAway = (mf.tram.tramWidth * (i + 0.5) + mf.tram.halfWheelTrack + mf.tool.halfWidth)
                        * (mf.tram.tramWidth * (i + 0.5) + mf.tram.halfWheelTrack + mf.tool.halfWidth) * 0.999999;

                mf.tram.tramArr = new List<vec2>
                {
                    Capacity = 128
                };

                mf.tram.tramList.Add(mf.tram.tramArr);
                for (int j = 0; j < refCount; j += 1)
                {
                    vec2 point = new vec2(
                    (Math.Sin(glm.PIBy2 + refList[j].heading) *
                        ((mf.tram.tramWidth * (pass + i)) + mf.tram.halfWheelTrack + mf.tool.halfWidth)) + refList[j].easting,
                    (Math.Cos(glm.PIBy2 + refList[j].heading) *
                        ((mf.tram.tramWidth * (pass + i)) + mf.tram.halfWheelTrack + mf.tool.halfWidth)) + refList[j].northing);

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
                        //a new point only every 2 meters
                        double dist = mf.tram.tramArr.Count > 0 ? ((point.easting - mf.tram.tramArr[mf.tram.tramArr.Count - 1].easting) * (point.easting - mf.tram.tramArr[mf.tram.tramArr.Count - 1].easting))
                            + ((point.northing - mf.tram.tramArr[mf.tram.tramArr.Count - 1].northing) * (point.northing - mf.tram.tramArr[mf.tram.tramArr.Count - 1].northing)) : 3.0;
                        if (dist > 2)
                        {
                            //if inside the boundary, add
                            if (!isBndExist || mf.bnd.bndList[0].fenceLineEar.IsPointInPolygon(point))
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
            if (!isCurveSet || cnt < 200) return;

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

            if (arr == null || cnt < 1) return;
            if (smooList == null) return;   

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
            if (smooList == null) return;
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

        public void MoveABCurve(double dist)
        {
            isCurveValid = false;
            lastSecond = 0;

            int cnt = refList.Count;
            vec3[] arr = new vec3[cnt];
            refList.CopyTo(arr);
            refList.Clear();

            moveDistance += isHeadingSameWay ? dist : -dist;

            for (int i = 0; i < cnt; i++)
            {
                arr[i].easting += Math.Cos(arr[i].heading) * (isHeadingSameWay ? dist : -dist);
                arr[i].northing -= Math.Sin(arr[i].heading) * (isHeadingSameWay ? dist : -dist);
                refList.Add(arr[i]);
            }
        }

        public bool PointOnLine(vec3 pt1, vec3 pt2, vec3 pt)
        {
            vec2 r = new vec2(0, 0);
            if (pt1.northing == pt2.northing && pt1.easting == pt2.easting) { pt1.northing -= 0.00001; }

            double U = ((pt.northing - pt1.northing) * (pt2.northing - pt1.northing)) + ((pt.easting - pt1.easting) * (pt2.easting - pt1.easting));

            double Udenom = Math.Pow(pt2.northing - pt1.northing, 2) + Math.Pow(pt2.easting - pt1.easting, 2);

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
        }
    }

    public class CCurveLines
    {
        public List<vec3> curvePts = new List<vec3>();
        public double aveHeading = 3;
        public string Name = "aa";
    }
}



