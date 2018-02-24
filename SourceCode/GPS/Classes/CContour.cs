using System;
using System.Collections.Generic;
using SharpGL;

namespace AgOpenGPS
{
    public class CContour
    {
        //copy of the mainform address
        private readonly FormGPS mf;
        private readonly OpenGL gl;

        public bool isContourOn, isContourBtnOn;

        //used to determine if section was off and now is on or vice versa
        public bool wasSectionOn;

        //generated box for finding closest point
        public vec2 boxA = new vec2(0, 0), boxB = new vec2(0, 2);
        public vec2 boxC = new vec2(1, 1), boxD = new vec2(2, 3);

        //current contour patch and point closest to current fix
        public int closestRefPatch, closestRefPoint;

        //angle to path line closest point and fix
        public double refHeading, ref2;

        // for closest line point to current fix
        public double minDistance = 99999.0, refX, refZ;

        //generated reference line
        public double refLineSide = 1.0;
        public vec2 refPoint1 = new vec2(1, 1), refPoint2 = new vec2(2, 2);

        public double distanceFromRefLine;
        public double distanceFromCurrentLine;

        private int A, B, C;
        public double abFixHeadingDelta, abHeading;

        public bool isABSameAsFixHeading = true;
        public bool isOnRightSideCurrentLine = true;

        //pure pursuit values
        public vec3 pivotAxlePosCT = new vec3(0, 0, 0);
        public vec2 goalPointCT = new vec2(0, 0);
        public vec2 radiusPointCT = new vec2(0, 0);
        public double steerAngleCT;
        public double rEastCT, rNorthCT;
        public double ppRadiusCT;

        //list of strip data individual points
        public List<vec3> ptList = new List<vec3>();

        //list of the list of individual Lines for entire field
        public List<List<vec3>> stripList = new List<List<vec3>>();

        //list of points for the new contour line
        public List<vec3> ctList = new List<vec3>();

        //list of points to determine position ofnew contour line
        public List<cvec> conList = new List<cvec>();

        //constructor
        public CContour(OpenGL _gl, FormGPS _f)
        {
            mf = _f;
            if (mf != null)
            {
                gl = _gl;
            }
        }

        //start stop and add points to list
        public void StartContourLine()
        {
            isContourOn = true;
            if (ptList.Count == 1)
            {
                //reuse ptList
                ptList.Clear();
            }
            else
            {
                //make new ptList
                ptList = new List<vec3>();
                stripList.Add(ptList);
            }
            //grab a copy from main
            pivotAxlePosCT = mf.pivotAxlePos;

            pivotAxlePosCT.easting -= (Math.Sin(mf.fixHeading) * 5.0);
            pivotAxlePosCT.northing -= (Math.Cos(mf.fixHeading) * 5.0);

            vec3 point = new vec3(pivotAxlePosCT.easting, pivotAxlePosCT.northing, mf.fixHeading);
            ptList.Add(point);
        }

        //Add current position to stripList
        public void AddPoint()
        {
#pragma warning disable CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception
            vec3 point = new vec3(mf.pivotAxlePos.easting, mf.pivotAxlePos.northing, mf.fixHeading);
#pragma warning restore CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception
            ptList.Add(point);
        }

        //End the strip
        public void StopContourLine()
        {
            //make sure its long enough to bother
            if (ptList.Count > 10)
            {
                //grab a copy from main
                pivotAxlePosCT = mf.pivotAxlePos;

                pivotAxlePosCT.easting += (Math.Sin(mf.fixHeading) * 5.0);
                pivotAxlePosCT.northing += (Math.Cos(mf.fixHeading) * 5.0);

                vec3 point = new vec3(pivotAxlePosCT.easting, pivotAxlePosCT.northing, mf.fixHeading);
                ptList.Add(point);

                //add the point list to the save list for appending to contour file
                mf.contourSaveList.Add(ptList);
            }

            //delete ptList
            else
            {
                ptList.Clear();
                int ra = stripList.Count-1;
                stripList.RemoveAt(ra);
            }

            //turn it off
            isContourOn = false;
        }

        //determine closest point on applied 
        public void BuildContourGuidanceLine(double eastFix, double northFix)
        {
            //build a frustum box ahead of fix to find adjacent paths and points
            //double startX = eastFix + Math.Sin(mf.fixHeading)* 0;
            //double startY = northFix + Math.Cos(mf.fixHeading) * 0;

            boxA.easting = eastFix - (Math.Sin(mf.fixHeading + glm.PIBy2) *  2.0 * mf.vehicle.toolWidth);
            boxA.northing = northFix - (Math.Cos(mf.fixHeading + glm.PIBy2) * 2.0 * mf.vehicle.toolWidth);

            boxB.easting = eastFix + (Math.Sin(mf.fixHeading + glm.PIBy2) *  2.0 * mf.vehicle.toolWidth);
            boxB.northing = northFix + (Math.Cos(mf.fixHeading + glm.PIBy2) * 2.0 * mf.vehicle.toolWidth);

            boxC.easting = boxB.easting + (Math.Sin(mf.fixHeading) * 13.0);
            boxC.northing = boxB.northing + (Math.Cos(mf.fixHeading) * 13.0);

            boxD.easting = boxA.easting + (Math.Sin(mf.fixHeading) * 13.0);
            boxD.northing = boxA.northing + (Math.Cos(mf.fixHeading) * 13.0);

            conList.Clear();
            ctList.Clear();
            int ptCount;

            //check if no strips yet, return
            int stripCount = stripList.Count;
            if (stripCount == 0) return;

            cvec pointC = new cvec();

            //determine if points are in frustum box
            for (int s = 0; s < stripCount; s++)
            {
                ptCount = stripList[s].Count;
                for (int p = 0; p < ptCount; p++)
                {
                    if ((((boxB.easting - boxA.easting) * (stripList[s][p].northing - boxA.northing))
                            - ((boxB.northing - boxA.northing) * (stripList[s][p].easting - boxA.easting))) < 0) { continue; }

                    if ((((boxD.easting - boxC.easting) * (stripList[s][p].northing - boxC.northing))
                            - ((boxD.northing - boxC.northing) * (stripList[s][p].easting - boxC.easting))) < 0) { continue; }

                    if ((((boxC.easting - boxB.easting) * (stripList[s][p].northing - boxB.northing))
                            - ((boxC.northing - boxB.northing) * (stripList[s][p].easting - boxB.easting))) < 0) { continue; }

                    if ((((boxA.easting - boxD.easting) * (stripList[s][p].northing - boxD.northing))
                            - ((boxA.northing - boxD.northing) * (stripList[s][p].easting - boxD.easting))) < 0) { continue; }

                    //in the box so is it parallelish or perpedicularish to current heading
                    ref2 = Math.PI - Math.Abs(Math.Abs(mf.fixHeading - stripList[s][p].heading) - Math.PI);
                    if (ref2 < 1.2 || ref2 > 1.9)
                    {
                        //it's in the box and parallelish so add to list
                        pointC.x = stripList[s][p].easting;
                        pointC.z = stripList[s][p].northing;
                        pointC.h = stripList[s][p].heading;
                        pointC.strip = s;
                        pointC.pt = p;
                        conList.Add(pointC);
                    }
                }
            }

            //no points in the box, exit
            ptCount = conList.Count;
            if (ptCount == 0)
            {
                distanceFromCurrentLine = 9999;
                return;
            }

            //determine closest point
            minDistance = 99999;
            for (int i = 0; i < ptCount; i++)
            {
                double dist = ((eastFix - conList[i].x) * (eastFix - conList[i].x))
                                + ((northFix - conList[i].z) * (northFix - conList[i].z));
                if (minDistance >= dist)
                {
                    minDistance = dist;
                    closestRefPoint = i;
                }
            }

            //now we have closest point, the distance squared from it, and which patch and point its from
            int strip = conList[closestRefPoint].strip;
            int pt = conList[closestRefPoint].pt;
            refX = stripList[strip][pt].easting;
            refZ = stripList[strip][pt].northing;
            refHeading = stripList[strip][pt].heading;

            //are we going same direction as stripList was created?
            bool isSameWay = Math.PI - Math.Abs(Math.Abs(mf.fixHeading - refHeading) - Math.PI) < 1.4;

            //which side of the patch are we on is next
            //calculate endpoints of reference line based on closest point
            refPoint1.easting = refX - (Math.Sin(refHeading) * 50.0);
            refPoint1.northing = refZ - (Math.Cos(refHeading) * 50.0);

            refPoint2.easting = refX + (Math.Sin(refHeading) * 50.0);
            refPoint2.northing = refZ + (Math.Cos(refHeading) * 50.0);

            //x2-x1
            double dx = refPoint2.easting - refPoint1.easting;
            //z2-z1
            double dz = refPoint2.northing - refPoint1.northing;

            //how far are we away from the reference line at 90 degrees - 2D cross product and distance
            distanceFromRefLine = ((dz * mf.pn.fix.easting) - (dx * mf.pn.fix.northing) + (refPoint2.easting
                                    * refPoint1.northing) - (refPoint2.northing * refPoint1.easting))
                                        / Math.Sqrt((dz * dz) + (dx * dx));

            //add or subtract pi by 2 depending on which side of ref line
            double piSide;

            //sign of distance determines which side of line we are on
            if (distanceFromRefLine > 0) piSide = glm.PIBy2;
            else piSide = -glm.PIBy2;

            //offset calcs
            double toolOffset = mf.vehicle.toolOffset;
            if (isSameWay)
            {
                toolOffset = 0.0;
            }
            else
            {
                if (distanceFromRefLine > 0) toolOffset *= 2.0;
                else toolOffset *= -2.0;
            }

            //move the Guidance Line over based on the overlap, width, and offset amount set in vehicle
            double widthMinusOverlap = mf.vehicle.toolWidth - mf.vehicle.toolOverlap + toolOffset;

            //absolute the distance
            distanceFromRefLine = Math.Abs(distanceFromRefLine);

            //make the new guidance line list called guideList
            ptCount = stripList[strip].Count-1;
            int start, stop;
            if (isSameWay)
            {
                start = pt - 25; if (start < 0) start = 0;
                stop = pt + 60;  if (stop > ptCount) stop = ptCount+1;
            }
            else
            {
                start = pt - 60; if (start < 0) start = 0;
                stop = pt + 25;  if (stop > ptCount) stop = ptCount+1;
            }

            for (int i = start; i < stop; i++)
            {
                var point = new vec3(
                    stripList[strip][i].easting + (Math.Sin(piSide + stripList[strip][i].heading) * widthMinusOverlap),
                    stripList[strip][i].northing + (Math.Cos(piSide + stripList[strip][i].heading) * widthMinusOverlap),
                    stripList[strip][i].heading);
                ctList.Add(point);
            }
        }

        //determine distance from contour guidance line
        public void DistanceFromContourLine()
        {
            //grab a copy from main
            pivotAxlePosCT = mf.pivotAxlePos;

            double minDistA = 1000000, minDistB = 1000000;
            int ptCount = ctList.Count;
            //distanceFromCurrentLine = 9999;
            if (ptCount > 0)
            {
                //find the closest 2 points to current fix
                for (int t = 0; t < ptCount; t++)
                {
                    double dist = ((pivotAxlePosCT.easting - ctList[t].easting) * (pivotAxlePosCT.easting - ctList[t].easting))
                                    + ((pivotAxlePosCT.northing - ctList[t].northing) * (pivotAxlePosCT.northing - ctList[t].northing));
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
                //x2-x1
                double dx = ctList[B].easting - ctList[A].easting;
                //z2-z1
                double dz = ctList[B].northing - ctList[A].northing;

                if (Math.Abs(dx) < Double.Epsilon && Math.Abs(dz) < Double.Epsilon) return;

                //abHeading = Math.Atan2(dz, dx);
                abHeading = ctList[A].heading;

                //how far from current AB Line is fix
                distanceFromCurrentLine = ((dz * pivotAxlePosCT.easting) - (dx * pivotAxlePosCT
                    .northing) + (ctList[B].easting
                            * ctList[A].northing) - (ctList[B].northing * ctList[A].easting))
                                / Math.Sqrt((dz * dz) + (dx * dx));

                //are we on the right side or not
                isOnRightSideCurrentLine = distanceFromCurrentLine > 0;

                //absolute the distance
                distanceFromCurrentLine = Math.Abs(distanceFromCurrentLine);

                // ** Pure pursuit ** - calc point on ABLine closest to current position      
                double U = (((pivotAxlePosCT.easting - ctList[A].easting) * (dx))
                            + ((pivotAxlePosCT.northing - ctList[A].northing) * (dz)))
                            / ((dx * dx) + (dz * dz));

                rEastCT = ctList[A].easting + (U * (dx));
                rNorthCT = ctList[A].northing + (U * (dz));

                //Subtract the two headings, if > 1.57 its going the opposite heading as refAB
                abFixHeadingDelta = (Math.Abs(mf.fixHeading - abHeading));
                if (abFixHeadingDelta >= Math.PI) abFixHeadingDelta = Math.Abs(abFixHeadingDelta - glm.twoPI);

                //used for accumulating distance to find goal point
                double distSoFar;

                //how far should goal point be away  - speed * seconds * kmph -> m/s + min value
                double goalPointDistance = mf.pn.speed * mf.vehicle.goalPointLookAhead * 0.27777777;

                //minimum of 4.0 meters look ahead
                if (goalPointDistance < 4.0) goalPointDistance = 4.0;

                // used for calculating the length squared of next segment.
                double tempDist = 0.0;

                if (abFixHeadingDelta >= glm.PIBy2)
                {
                    //counting down
                    isABSameAsFixHeading = false;
                    distSoFar = glm.Distance(ctList[A], rEastCT, rNorthCT);
                    //Is this segment long enough to contain the full lookahead distance?
                    if (distSoFar > goalPointDistance)
                    {
                        //treat current segment like an AB Line
                        goalPointCT.easting = rEastCT - (Math.Sin(ctList[A].heading) * goalPointDistance);
                        goalPointCT.northing = rNorthCT - (Math.Cos(ctList[A].heading) * goalPointDistance);
                    }

                    //multiple segments required
                    else
                    {
                        //cycle thru segments and keep adding lengths. check if start and break if so.
                        while (A > 0)
                        {
                            B--; A--;
                            tempDist = glm.Distance(ctList[B], ctList[A]);

                            //will we go too far?
                            if ((tempDist + distSoFar) > goalPointDistance)
                            {
                                //A++; B++;
                                break; //tempDist contains the full length of next segment
                            }
                            else
                            {
                                distSoFar += tempDist;
                            }
                        }

                        double t = (goalPointDistance - distSoFar); // the remainder to yet travel
                        t /= tempDist;

                        goalPointCT.easting = (((1 - t) * ctList[B].easting) + (t * ctList[A].easting));
                        goalPointCT.northing = (((1 - t) * ctList[B].northing) + (t * ctList[A].northing));
                    }
                }
                else
                {
                    //counting up
                    isABSameAsFixHeading = true;
                    distSoFar = glm.Distance(ctList[B], rEastCT, rNorthCT);

                    //Is this segment long enough to contain the full lookahead distance?
                    if (distSoFar > goalPointDistance)
                    {
                        //treat current segment like an AB Line
                        goalPointCT.easting = rEastCT + (Math.Sin(ctList[A].heading) * goalPointDistance);
                        goalPointCT.northing = rNorthCT + (Math.Cos(ctList[A].heading) * goalPointDistance);
                    }

                    //multiple segments required
                    else
                    {
                        //cycle thru segments and keep adding lengths. check if end and break if so.
                        // ReSharper disable once LoopVariableIsNeverChangedInsideLoop
                        while (B < ptCount - 1)
                        {
                            B++; A++;
                            tempDist = glm.Distance(ctList[B], ctList[A]);

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

                        goalPointCT.easting = (((1 - t) * ctList[A].easting) + (t * ctList[B].easting));
                        goalPointCT.northing = (((1 - t) * ctList[A].northing) + (t * ctList[B].northing));
                    }
                }

                //calc "D" the distance from pivot axle to lookahead point
                double goalPointDistanceSquared = glm.DistanceSquared(goalPointCT.northing, goalPointCT.easting, pivotAxlePosCT.northing, pivotAxlePosCT.easting);

                //calculate the the delta x in local coordinates and steering angle degrees based on wheelbase
                double localHeading = glm.twoPI - mf.fixHeading;
                ppRadiusCT = goalPointDistanceSquared / (2 * (((goalPointCT.easting - pivotAxlePosCT.easting) * Math.Cos(localHeading)) + ((goalPointCT.northing - pivotAxlePosCT.northing) * Math.Sin(localHeading))));

                steerAngleCT = glm.toDegrees(Math.Atan(2 * (((goalPointCT.easting - pivotAxlePosCT.easting) * Math.Cos(localHeading))
                    + ((goalPointCT.northing - pivotAxlePosCT.northing) * Math.Sin(localHeading))) * mf.vehicle.wheelbase / goalPointDistanceSquared));

                if (steerAngleCT < -mf.vehicle.maxSteerAngle) steerAngleCT = -mf.vehicle.maxSteerAngle;
                if (steerAngleCT > mf.vehicle.maxSteerAngle) steerAngleCT = mf.vehicle.maxSteerAngle;

                if (ppRadiusCT < -500) ppRadiusCT = -500;
                if (ppRadiusCT > 500) ppRadiusCT = 500;

                radiusPointCT.easting = pivotAxlePosCT.easting + (ppRadiusCT * Math.Cos(localHeading));
                radiusPointCT.northing = pivotAxlePosCT.northing + (ppRadiusCT * Math.Sin(localHeading));

                //angular velocity in rads/sec  = 2PI * m/sec * radians/meters
                double angVel = glm.twoPI * 0.277777 * mf.pn.speed * (Math.Tan(glm.toRadians(steerAngleCT))) / mf.vehicle.wheelbase;

                //clamp the steering angle to not exceed safe angular velocity
                if (Math.Abs(angVel) > mf.vehicle.maxAngularVelocity)
                {
                    steerAngleCT = glm.toDegrees(steerAngleCT > 0 ?
                            (Math.Atan((mf.vehicle.wheelbase * mf.vehicle.maxAngularVelocity) / (glm.twoPI * mf.pn.speed * 0.277777)))
                        : (Math.Atan((mf.vehicle.wheelbase * -mf.vehicle.maxAngularVelocity) / (glm.twoPI * mf.pn.speed * 0.277777))));
                }
                //Convert to centimeters
                distanceFromCurrentLine = Math.Round(distanceFromCurrentLine * 1000.0, MidpointRounding.AwayFromZero);

                //distance is negative if on left, positive if on right
                //if you're going the opposite direction left is right and right is left
                //double temp;
                if (isABSameAsFixHeading)
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

                mf.guidanceLineDistanceOff = (Int16)distanceFromCurrentLine;
                mf.guidanceLineSteerAngle = (Int16)(steerAngleCT*100);
                //mf.guidanceLineHeadingDelta = (Int16)((Math.Atan2(Math.Sin(temp - mf.fixHeading),
                //                                    Math.Cos(temp - mf.fixHeading))) * 10000);
           }
            else
            {
                //invalid distance so tell AS module
                distanceFromCurrentLine = 32000;
                mf.guidanceLineDistanceOff = 32000;
            }
        }

        //draw the red follow me line
        public void DrawContourLine()
        {
            //gl.Color(0.98f, 0.98f, 0.50f);
            //gl.Begin(OpenGL.GL_LINE_STRIP);
            ////for (int h = 0; h < ptCount; h++) gl.Vertex(guideList[h].x, 0, guideList[h].z);
            //gl.Vertex(boxA.easting, boxA.northing, 0);
            //gl.Vertex(boxB.easting, boxB.northing, 0);
            //gl.Vertex(boxC.easting, boxC.northing, 0);
            //gl.Vertex(boxD.easting, boxD.northing, 0);
            //gl.Vertex(boxA.easting, boxA.northing, 0);
            //gl.End();

            ////draw the guidance line
            int ptCount = ctList.Count;
            gl.LineWidth(2);
            gl.Color(0.98f, 0.2f, 0.0f);
            gl.Begin(OpenGL.GL_LINE_STRIP);
            for (int h = 0; h < ptCount; h++) gl.Vertex(ctList[h].easting, ctList[h].northing, 0);
            gl.End();

            gl.PointSize(2.0f);
            gl.Begin(OpenGL.GL_POINTS);

            gl.Color(0.7f, 0.7f, 0.25f);
            for (int h = 0; h < ptCount; h++) gl.Vertex(ctList[h].easting, ctList[h].northing, 0);

            gl.End();
            gl.PointSize(1.0f);

            ////draw the reference line
            //gl.PointSize(3.0f);
            ////if (isContourBtnOn)
            //{
            //    ptCount = stripList.Count;
            //    if (ptCount > 0)
            //    {
            //        ptCount = stripList[closestRefPatch].Count;
            //        gl.Begin(OpenGL.GL_POINTS);
            //        for (int i = 0; i < ptCount; i++)
            //        {
            //            gl.Vertex(stripList[closestRefPatch][i].x, 0, stripList[closestRefPatch][i].z);
            //        }
            //        gl.End();
            //    }
            //}

            //ptCount = conList.Count;
            //if (ptCount > 0)
            //{
            ////draw closest point and side of line points
            //gl.Color(0.5f, 0.900f, 0.90f);
            //gl.PointSize(4.0f);
            //gl.Begin(OpenGL.GL_POINTS);
            //for (int i = 0; i < ptCount; i++)  gl.Vertex(conList[i].x, conList[i].z, 0);
            //gl.End();

            //gl.Color(0.35f, 0.30f, 0.90f);
            //gl.PointSize(6.0f);
            //gl.Begin(OpenGL.GL_POINTS);
            //gl.Vertex(conList[closestRefPoint].x, conList[closestRefPoint].z, 0);
            //gl.End();
            //}
            if (mf.isPureDisplayOn)
            {
                const int numSegments = 100;
                {
                    gl.Color(0.95f, 0.30f, 0.950f);

                    double theta = glm.twoPI / (numSegments);
                    double c = Math.Cos(theta);//precalculate the sine and cosine
                    double s = Math.Sin(theta);

                    double x = ppRadiusCT;//we start at angle = 0 
                    double y = 0;

                    gl.LineWidth(1);
                    gl.Begin(OpenGL.GL_LINE_LOOP);
                    for (int ii = 0; ii < numSegments; ii++)
                    {
                        //glVertex2f(x + cx, y + cy);//output vertex 
                        gl.Vertex(x + radiusPointCT.easting, y + radiusPointCT.northing);//output vertex 

                        //apply the rotation matrix
                        double t = x;
                        x = (c * x) - (s * y);
                        y = (s * t) + (c * y);
                    }
                    gl.End();

                    //Draw lookahead Point
                    gl.PointSize(4.0f);
                    gl.Begin(OpenGL.GL_POINTS);

                    //gl.Color(1.0f, 1.0f, 0.25f);
                    //gl.Vertex(rEast, rNorth, 0.0);

                    gl.Color(1.0f, 0.5f, 0.95f);
                    gl.Vertex(goalPointCT.easting, goalPointCT.northing, 0.0);

                    gl.End();
                    gl.PointSize(1.0f);
                }
            }
        }

        //Reset the contour to zip
        public void ResetContour()
        {
            stripList.Clear();
             ptList?.Clear();
             ctList?.Clear();
        }
    }//class
}//namespace