using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public class CContour
    {
        //copy of the mainform address
        private readonly FormGPS mf;

        public bool isContourOn, isContourBtnOn, isRightPriority = true;

        //used to determine if section was off and now is on or vice versa
        public bool wasSectionOn;

        //generated box for finding closest point
        public vec2 boxA = new vec2(0, 0), boxB = new vec2(0, 2);

        public vec2 boxC = new vec2(1, 1), boxD = new vec2(2, 3);
        public vec2 boxE = new vec2(3, 4), boxF = new vec2(4, 5);
        public vec2 boxG = new vec2(6, 6), boxH = new vec2(7, 7);

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

        public bool isABSameAsVehicleHeading = true;
        public bool isOnRightSideCurrentLine = true;

        //pure pursuit values
        public bool isValid;

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
        public CContour(FormGPS _f)
        {
            mf = _f;
        }

        //start stop and add points to list
        public void StartContourLine(vec3 pivot)
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

            //pivot.easting -= (Math.Sin(pivot.heading) * 5.0);
            //pivot.northing -= (Math.Cos(pivot.heading) * 5.0);

            vec3 point = new vec3(pivot.easting, pivot.northing, pivot.heading);
            ptList.Add(point);
        }

        //Add current position to stripList
        public void AddPoint(vec3 pivot)
        {
            vec3 point = new vec3(pivot.easting, pivot.northing, pivot.heading);
            ptList.Add(point);
        }

        //End the strip
        public void StopContourLine(vec3 pivot)
        {
            //make sure its long enough to bother
            if (ptList.Count > 10)
            {
                //pivot.easting += (Math.Sin(pivot.heading) * 5.0);
                //pivot.northing += (Math.Cos(pivot.heading) * 5.0);

                vec3 point = new vec3(pivot.easting, pivot.northing, mf.fixHeading);
                ptList.Add(point);

                //add the point list to the save list for appending to contour file
                mf.contourSaveList.Add(ptList);
            }

            //delete ptList
            else
            {
                ptList.Clear();
                int ra = stripList.Count - 1;
                if (ra > 0) stripList.RemoveAt(ra);
            }

            //turn it off
            isContourOn = false;
        }

        //build contours for boundaries
        public void BuildBoundaryContours()
        {
            if (!mf.bnd.bndArr[0].isSet)
            {
                mf.TimedMessageBox(1500, "Boundary Contour Error", "No Boundaries Made");
                return;
            }

            vec3 point = new vec3();
            //determine how wide a headland space
            double totalHeadWidth = ((mf.vehicle.toolWidth - mf.vehicle.toolOverlap) * 0.5) - 0.2;

            //outside boundary

            //count the points from the boundary
            int ptCount = mf.bnd.bndArr[0].bndLine.Count;

            ptList = new List<vec3>();
            stripList.Add(ptList);

            for (int i = ptCount - 1; i >= 0; i--)
            {
                //calculate the point inside the boundary
                point.easting = mf.bnd.bndArr[0].bndLine[i].easting - (-Math.Sin(glm.PIBy2 + mf.bnd.bndArr[0].bndLine[i].heading) * totalHeadWidth);
                point.northing = mf.bnd.bndArr[0].bndLine[i].northing - (-Math.Cos(glm.PIBy2 + mf.bnd.bndArr[0].bndLine[i].heading) * totalHeadWidth);
                point.heading = mf.bnd.bndArr[0].bndLine[i].heading - Math.PI;
                if (point.heading < -glm.twoPI) point.heading += glm.twoPI;
                ptList.Add(point);
            }

            //totalHeadWidth = (mf.vehicle.toolWidth - mf.vehicle.toolOverlap) * 0.5 + 0.2 + (mf.vehicle.toolWidth - mf.vehicle.toolOverlap);

            for (int j = 1; j < FormGPS.MAXBOUNDARIES; j++)
            {
                if (!mf.bnd.bndArr[j].isSet) continue;

                //count the points from the boundary
                ptCount = mf.bnd.bndArr[j].bndLine.Count;

                ptList = new List<vec3>();
                stripList.Add(ptList);

                for (int i = ptCount - 1; i >= 0; i--)
                {
                    //calculate the point inside the boundary
                    point.easting = mf.bnd.bndArr[j].bndLine[i].easting - (-Math.Sin(glm.PIBy2 + mf.bnd.bndArr[j].bndLine[i].heading) * totalHeadWidth);
                    point.northing = mf.bnd.bndArr[j].bndLine[i].northing - (-Math.Cos(glm.PIBy2 + mf.bnd.bndArr[j].bndLine[i].heading) * totalHeadWidth);
                    point.heading = mf.bnd.bndArr[j].bndLine[i].heading - Math.PI;
                    if (point.heading < -glm.twoPI) point.heading += glm.twoPI;

                    //only add if inside actual field boundary
                    ptList.Add(point);
                }

                //add the point list to the save list for appending to contour file
                //mf.contourSaveList.Add(ptList);
            }

            mf.TimedMessageBox(1500, "Boundary Contour", "Contour Path Created");
        }

        //determine closest point on left side
        public void BuildContourGuidanceLine(vec3 pivot)
        {
            double toolWid = mf.vehicle.toolWidth;

            double sinH = Math.Sin(pivot.heading) * 2.0 * toolWid;
            double cosH = Math.Cos(pivot.heading) * 2.0 * toolWid;

            double sin2HL = 0;
            double cos2HL = 0;
            double sin2HR = 0;
            double cos2HR = 0;

            if (mf.vehicle.toolOffset < 0)
            {
                //sticks out more left
                sin2HL = Math.Sin(pivot.heading + glm.PIBy2) * (1.33 * (toolWid + Math.Abs(mf.vehicle.toolOffset * 2)));
                cos2HL = Math.Cos(pivot.heading + glm.PIBy2) * (1.33 * (toolWid + Math.Abs(mf.vehicle.toolOffset * 2)));

                sin2HR = Math.Sin(pivot.heading + glm.PIBy2) * (1.33 * (toolWid + Math.Abs(mf.vehicle.toolOffset)));
                cos2HR = Math.Cos(pivot.heading + glm.PIBy2) * (1.33 * (toolWid + Math.Abs(mf.vehicle.toolOffset)));
            }
            else
            {
                //sticks out more right
                sin2HL = Math.Sin(pivot.heading + glm.PIBy2) * (1.33 * (toolWid + Math.Abs(mf.vehicle.toolOffset)));
                cos2HL = Math.Cos(pivot.heading + glm.PIBy2) * (1.33 * (toolWid + Math.Abs(mf.vehicle.toolOffset)));

                sin2HR = Math.Sin(pivot.heading + glm.PIBy2) * (1.33 * (toolWid + Math.Abs(mf.vehicle.toolOffset * 2)));
                cos2HR = Math.Cos(pivot.heading + glm.PIBy2) * (1.33 * (toolWid + Math.Abs(mf.vehicle.toolOffset * 2)));
            }

            //narrow equipment needs bigger bounding box.
            if (mf.vehicle.toolWidth < 6)
            {
                sinH = Math.Sin(pivot.heading) * 4 * toolWid;
                cosH = Math.Cos(pivot.heading) * 4 * toolWid;
            }

            double sin3H = Math.Sin(pivot.heading + glm.PIBy2) * 0.5;
            double cos3H = Math.Cos(pivot.heading + glm.PIBy2) * 0.5;

            //build a frustum box ahead of fix to find adjacent paths and points

            //left
            boxA.easting = pivot.easting - sin2HL;
            boxA.northing = pivot.northing - cos2HL;
            boxA.easting -= (sinH * 0.25); //bottom left outside
            boxA.northing -= (cosH * 0.25);

            boxD.easting = boxA.easting + sinH; //top left outside
            boxD.northing = boxA.northing + cosH;

            boxE.easting = pivot.easting - sin3H; // inside bottom
            boxE.northing = pivot.northing - cos3H;

            boxG.easting = boxE.easting + (sinH * 0.3); //inside top
            boxG.northing = boxE.northing + (cosH * 0.3);

            //right
            boxB.easting = pivot.easting + sin2HR;
            boxB.northing = pivot.northing + cos2HR;
            boxB.easting -= (sinH * 0.25);
            boxB.northing -= (cosH * 0.25);

            boxC.easting = boxB.easting + sinH;
            boxC.northing = boxB.northing + cosH;

            boxF.easting = pivot.easting + sin3H;
            boxF.northing = pivot.northing + cos3H;

            boxH.easting = boxF.easting + (sinH * 0.3); //inside top
            boxH.northing = boxF.northing + (cosH * 0.3);

            conList.Clear();
            ctList.Clear();
            int ptCount;

            //check if no strips yet, return
            int stripCount = stripList.Count;
            if (stripCount == 0) return;

            cvec pointC = new cvec();
            if (isRightPriority)
            {
                //determine if points are in right side frustum box
                for (int s = 0; s < stripCount; s++)
                {
                    ptCount = stripList[s].Count;
                    for (int p = 0; p < ptCount; p++)
                    {
                        //FHCBF
                        if ((((boxH.easting - boxC.easting) * (stripList[s][p].northing - boxC.northing))
                                - ((boxH.northing - boxC.northing) * (stripList[s][p].easting - boxC.easting))) < 0) { continue; }

                        if ((((boxC.easting - boxB.easting) * (stripList[s][p].northing - boxB.northing))
                                - ((boxC.northing - boxB.northing) * (stripList[s][p].easting - boxB.easting))) < 0) { continue; }

                        if ((((boxB.easting - boxF.easting) * (stripList[s][p].northing - boxF.northing))
                                - ((boxB.northing - boxF.northing) * (stripList[s][p].easting - boxF.easting))) < 0) { continue; }

                        if ((((boxF.easting - boxH.easting) * (stripList[s][p].northing - boxH.northing))
                                - ((boxF.northing - boxH.northing) * (stripList[s][p].easting - boxH.easting))) < 0) { continue; }

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

                if (conList.Count == 0)
                {
                    //determine if points are in frustum box
                    for (int s = 0; s < stripCount; s++)
                    {
                        ptCount = stripList[s].Count;
                        for (int p = 0; p < ptCount; p++)
                        {
                            //EADGE
                            if ((((boxG.easting - boxE.easting) * (stripList[s][p].northing - boxE.northing))
                                    - ((boxG.northing - boxE.northing) * (stripList[s][p].easting - boxE.easting))) < 0) { continue; }

                            if ((((boxE.easting - boxA.easting) * (stripList[s][p].northing - boxA.northing))
                                    - ((boxE.northing - boxA.northing) * (stripList[s][p].easting - boxA.easting))) < 0) { continue; }

                            if ((((boxA.easting - boxD.easting) * (stripList[s][p].northing - boxD.northing))
                                    - ((boxA.northing - boxD.northing) * (stripList[s][p].easting - boxD.easting))) < 0) { continue; }

                            if ((((boxD.easting - boxG.easting) * (stripList[s][p].northing - boxG.northing))
                                    - ((boxD.northing - boxG.northing) * (stripList[s][p].easting - boxG.easting))) < 0) { continue; }

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
                }
            }
            else
            {
                for (int s = 0; s < stripCount; s++)
                {
                    ptCount = stripList[s].Count;
                    for (int p = 0; p < ptCount; p++)
                    {
                        //EADGE
                        if ((((boxG.easting - boxE.easting) * (stripList[s][p].northing - boxE.northing))
                                - ((boxG.northing - boxE.northing) * (stripList[s][p].easting - boxE.easting))) < 0) { continue; }

                        if ((((boxE.easting - boxA.easting) * (stripList[s][p].northing - boxA.northing))
                                - ((boxE.northing - boxA.northing) * (stripList[s][p].easting - boxA.easting))) < 0) { continue; }

                        if ((((boxA.easting - boxD.easting) * (stripList[s][p].northing - boxD.northing))
                                - ((boxA.northing - boxD.northing) * (stripList[s][p].easting - boxD.easting))) < 0) { continue; }

                        if ((((boxD.easting - boxG.easting) * (stripList[s][p].northing - boxG.northing))
                                - ((boxD.northing - boxG.northing) * (stripList[s][p].easting - boxG.easting))) < 0) { continue; }

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

                if (conList.Count == 0)
                {
                    //determine if points are in frustum box
                    for (int s = 0; s < stripCount; s++)
                    {
                        ptCount = stripList[s].Count;
                        for (int p = 0; p < ptCount; p++)
                        {
                            if ((((boxH.easting - boxC.easting) * (stripList[s][p].northing - boxC.northing))
                                    - ((boxH.northing - boxC.northing) * (stripList[s][p].easting - boxC.easting))) < 0) { continue; }

                            if ((((boxC.easting - boxB.easting) * (stripList[s][p].northing - boxB.northing))
                                    - ((boxC.northing - boxB.northing) * (stripList[s][p].easting - boxB.easting))) < 0) { continue; }

                            if ((((boxB.easting - boxF.easting) * (stripList[s][p].northing - boxF.northing))
                                    - ((boxB.northing - boxF.northing) * (stripList[s][p].easting - boxF.easting))) < 0) { continue; }

                            if ((((boxF.easting - boxH.easting) * (stripList[s][p].northing - boxH.northing))
                                    - ((boxF.northing - boxH.northing) * (stripList[s][p].easting - boxH.easting))) < 0) { continue; }

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
                }
            }

            //no points in the box, exit
            ptCount = conList.Count;
            if (ptCount == 0)
            {
                distanceFromCurrentLine = 9999;
                distanceFromCurrentLine = 32000;
                mf.guidanceLineDistanceOff = 32000;
                return;
            }

            //determine closest point
            minDistance = 99999;
            for (int i = 0; i < ptCount; i++)
            {
                double dist = ((pivot.easting - conList[i].x) * (pivot.easting - conList[i].x))
                                + ((pivot.northing - conList[i].z) * (pivot.northing - conList[i].z));
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
            ptCount = stripList[strip].Count - 1;
            int start, stop;

            start = pt - 135; if (start < 0) start = 0;
            stop = pt + 135; if (stop > ptCount) stop = ptCount + 1;

            double distSq = widthMinusOverlap * widthMinusOverlap * 0.95;
            bool fail = false;

            for (int i = start; i < stop; i++)
            {
                //var point = new vec3(
                //    stripList[strip][i].easting + (Math.Sin(piSide + stripList[strip][i].heading) * widthMinusOverlap),
                //    stripList[strip][i].northing + (Math.Cos(piSide + stripList[strip][i].heading) * widthMinusOverlap),
                //    stripList[strip][i].heading);
                //ctList.Add(point);

                var point = new vec3(
                    stripList[strip][i].easting + (Math.Sin(piSide + stripList[strip][i].heading) * widthMinusOverlap),
                    stripList[strip][i].northing + (Math.Cos(piSide + stripList[strip][i].heading) * widthMinusOverlap),
                    stripList[strip][i].heading);
                //ctList.Add(point);

                //make sure its not closer then 1 eq width
                for (int j = start; j < stop; j++)
                {
                    double check = glm.DistanceSquared(point.northing, point.easting, stripList[strip][j].northing, stripList[strip][j].easting);
                    if (check < distSq)
                    {
                        fail = true;
                        break;
                    }
                }

                if (!fail) ctList.Add(point);
                fail = false;
            }

            //if no boundaries, just return.
            //if (!mf.bnd.bndArr[0].isSet) return;

            int ctCount = ctList.Count;
            if (ctCount < 6) return;

            const double spacing = 1.0;
            double distance;
            for (int i = 0; i < ctCount - 1; i++)
            {
                distance = glm.Distance(ctList[i], ctList[i + 1]);
                if (distance < spacing)
                {
                    ctList.RemoveAt(i + 1);
                    ctCount = ctList.Count;
                    i--;
                }
            }

            //{
            //    //count the reference list of original curve
            //    int cnt = ctList.Count;

            //    //just go back if not very long
            //    if (cnt < 10) return;

            //    //the temp array
            //    vec3[] arr = new vec3[cnt];

            //    //how many samples
            //    const int smPts = 2;

            //    //read the points before and after the setpoint
            //    for (int s = 0; s < smPts; s++)
            //    {
            //        arr[s].easting = ctList[s].easting;
            //        arr[s].northing = ctList[s].northing;
            //        arr[s].heading = ctList[s].heading;
            //    }

            //    for (int s = cnt - smPts; s < cnt; s++)
            //    {
            //        arr[s].easting = ctList[s].easting;
            //        arr[s].northing = ctList[s].northing;
            //        arr[s].heading = ctList[s].heading;
            //    }

            //    //average them - center weighted average
            //    for (int i = smPts; i < cnt - smPts; i++)
            //    {
            //        for (int j = -smPts; j < smPts; j++)
            //        {
            //            arr[i].easting += ctList[j + i].easting;
            //            arr[i].northing += ctList[j + i].northing;
            //        }
            //        arr[i].easting /= (smPts * 2);
            //        arr[i].northing /= (smPts * 2);
            //        arr[i].heading = ctList[i].heading;
            //    }

            //    //make a list to draw
            //    ctList?.Clear();
            //    for (int i = 0; i < cnt; i++)
            //    {
            //        ctList.Add(arr[i]);
            //    }
            //}
        }

        public void CalculateContourHeadings()
        {
            //to calc heading based on next and previous points to give an average heading.
            int cnt = ctList.Count;
            vec3[] arr = new vec3[cnt];
            cnt--;
            ctList.CopyTo(arr);
            ctList.Clear();

            //middle points
            for (int i = 1; i < cnt; i++)
            {
                vec3 pt3 = arr[i];
                pt3.heading = Math.Atan2(arr[i + 1].easting - arr[i-1].easting, arr[i + 1].northing - arr[i-1].northing);
                if (pt3.heading < 0) pt3.heading += glm.twoPI;
                ctList.Add(pt3);
            }
        }

        //determine distance from contour guidance line
        public void DistanceFromContourLine(vec3 pivot, vec3 steer)
        {
            isValid = false;
            double minDistA = 1000000, minDistB = 1000000;
            int ptCount = ctList.Count;
            //distanceFromCurrentLine = 9999;
            if (ptCount > 8)
            {
                if (mf.isStanleyUsed)
                {
                    //find the closest 2 points to current fix
                    for (int t = 0; t < ptCount; t++)
                    {
                        double dist = ((steer.easting - ctList[t].easting) * (steer.easting - ctList[t].easting))
                                        + ((steer.northing - ctList[t].northing) * (steer.northing - ctList[t].northing));
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

                    //just need to make sure the points continue ascending in list order or heading switches all over the place
                    if (A > B) { C = A; A = B; B = C; }

                    //get the distance from currently active AB line
                    //x2-x1
                    double dx = ctList[B].easting - ctList[A].easting;
                    //z2-z1
                    double dy = ctList[B].northing - ctList[A].northing;

                    if (Math.Abs(dx) < Double.Epsilon && Math.Abs(dy) < Double.Epsilon) return;

                    abHeading = Math.Atan2(dx, dy);
                    //abHeading = ctList[A].heading;

                    //how far from current AB Line is fix
                    distanceFromCurrentLine = ((dy * steer.easting) - (dx * steer.northing) + (ctList[B].easting
                                * ctList[A].northing) - (ctList[B].northing * ctList[A].easting))
                                    / Math.Sqrt((dy * dy) + (dx * dx));

                    //are we on the right side or not
                    isOnRightSideCurrentLine = distanceFromCurrentLine > 0;

                    //absolute the distance
                    distanceFromCurrentLine = Math.Abs(distanceFromCurrentLine);

                    //Subtract the two headings, if > 1.57 its going the opposite heading as refAB
                    abFixHeadingDelta = (Math.Abs(mf.fixHeading - abHeading));
                    if (abFixHeadingDelta >= Math.PI) abFixHeadingDelta = Math.Abs(abFixHeadingDelta - glm.twoPI);

                    isABSameAsVehicleHeading = abFixHeadingDelta < glm.PIBy2;


                    // calc point on ABLine closest to current position
                    double U = (((steer.easting - ctList[A].easting) * dx) + ((steer.northing - ctList[A].northing) * dy))
                                / ((dx * dx) + (dy * dy));

                    rEastCT = ctList[A].easting + (U * dx);
                    rNorthCT = ctList[A].northing + (U * dy);

                    ////find closest point to goal to get heading. 
                    //minDistA = 99999;
                    //for (int t = 0; t < ptCount; t++)
                    //{
                    //    double dist = ((rEastCT - ctList[t].easting) * (rEastCT - ctList[t].easting))
                    //                    + ((rNorthCT - ctList[t].northing) * (rNorthCT - ctList[t].northing));
                    //    if (dist < minDistA)
                    //    {
                    //        A = t;
                    //    }
                    //}

                    //abHeading = ctList[A].heading;

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

                    steerAngleCT = Math.Atan((distanceFromCurrentLine * mf.vehicle.stanleyGain) / ((mf.pn.speed * 0.277777) + 1));

                    if (steerAngleCT > 0.74) steerAngleCT = 0.74;
                    if (steerAngleCT < -0.74) steerAngleCT = -0.74;

                    steerAngleCT = glm.toDegrees((steerAngleCT + abFixHeadingDelta) * -1.0);

                    if (steerAngleCT < -mf.vehicle.maxSteerAngle) steerAngleCT = -mf.vehicle.maxSteerAngle;
                    if (steerAngleCT > mf.vehicle.maxSteerAngle) steerAngleCT = mf.vehicle.maxSteerAngle;

                    //Convert to millimeters
                    distanceFromCurrentLine = Math.Round(distanceFromCurrentLine * 1000.0, MidpointRounding.AwayFromZero);
                }
                else
                {
                    //find the closest 2 points to current fix
                    for (int t = 0; t < ptCount; t++)
                    {
                        double dist = ((pivot.easting - ctList[t].easting) * (pivot.easting - ctList[t].easting))
                                        + ((pivot.northing - ctList[t].northing) * (pivot.northing - ctList[t].northing));
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

                    //just need to make sure the points continue ascending in list order or heading switches all over the place
                    if (A > B) { C = A; A = B; B = C; }

                    //get the distance from currently active AB line
                    //x2-x1
                    double dx = ctList[B].easting - ctList[A].easting;
                    //z2-z1
                    double dy = ctList[B].northing - ctList[A].northing;

                    if (Math.Abs(dx) < Double.Epsilon && Math.Abs(dy) < Double.Epsilon) return;

                    //abHeading = Math.Atan2(dz, dx);
                    abHeading = ctList[A].heading;

                    //how far from current AB Line is fix
                    distanceFromCurrentLine = ((dy * mf.pn.fix.easting) - (dx * mf.pn.fix.northing) + (ctList[B].easting
                                * ctList[A].northing) - (ctList[B].northing * ctList[A].easting))
                                    / Math.Sqrt((dy * dy) + (dx * dx));

                    //are we on the right side or not
                    isOnRightSideCurrentLine = distanceFromCurrentLine > 0;

                    //absolute the distance
                    distanceFromCurrentLine = Math.Abs(distanceFromCurrentLine);

                    // ** Pure pursuit ** - calc point on ABLine closest to current position
                    double U = (((pivot.easting - ctList[A].easting) * dx) + ((pivot.northing - ctList[A].northing) * dy))
                                / ((dx * dx) + (dy * dy));

                    rEastCT = ctList[A].easting + (U * dx);
                    rNorthCT = ctList[A].northing + (U * dy);

                    ////determine if the point is between 2 points initially determined
                    //double minx, maxx, miny, maxy;

                    //minx = Math.Min(ctList[A].northing, ctList[B].northing);
                    //maxx = Math.Max(ctList[A].northing, ctList[B].northing);

                    //miny = Math.Min(ctList[A].easting, ctList[B].easting);
                    //maxy = Math.Max(ctList[A].easting, ctList[B].easting);

                    //isValid = (rNorthCT >= minx && rNorthCT <= maxx) && (rEastCT >= miny && rEastCT <= maxy);
                    //if (!isValid)
                    //{
                    //    //invalid distance so tell AS module
                    //    distanceFromCurrentLine = 32000;
                    //    mf.guidanceLineDistanceOff = 32000;
                    //    return;
                    //}

                    //Subtract the two headings, if > 1.57 its going the opposite heading as refAB
                    abFixHeadingDelta = (Math.Abs(mf.fixHeading - abHeading));
                    if (abFixHeadingDelta >= Math.PI) abFixHeadingDelta = Math.Abs(abFixHeadingDelta - glm.twoPI);

                    //used for accumulating distance to find goal point
                    double distSoFar;

                    //update base on autosteer settings and distance from line
                    double goalPointDistance = mf.vehicle.UpdateGoalPointDistance(distanceFromCurrentLine);
                    mf.lookaheadActual = goalPointDistance;

                    // used for calculating the length squared of next segment.
                    double tempDist = 0.0;

                    if (abFixHeadingDelta >= glm.PIBy2)
                    {
                        //counting down
                        isABSameAsVehicleHeading = false;
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
                        isABSameAsVehicleHeading = true;
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
                    double goalPointDistanceSquared = glm.DistanceSquared(goalPointCT.northing, goalPointCT.easting, pivot.northing, pivot.easting);

                    //calculate the the delta x in local coordinates and steering angle degrees based on wheelbase
                    double localHeading = glm.twoPI - mf.fixHeading;
                    ppRadiusCT = goalPointDistanceSquared / (2 * (((goalPointCT.easting - pivot.easting) * Math.Cos(localHeading)) + ((goalPointCT.northing - pivot.northing) * Math.Sin(localHeading))));

                    steerAngleCT = glm.toDegrees(Math.Atan(2 * (((goalPointCT.easting - pivot.easting) * Math.Cos(localHeading))
                        + ((goalPointCT.northing - pivot.northing) * Math.Sin(localHeading))) * mf.vehicle.wheelbase / goalPointDistanceSquared));

                    if (steerAngleCT < -mf.vehicle.maxSteerAngle) steerAngleCT = -mf.vehicle.maxSteerAngle;
                    if (steerAngleCT > mf.vehicle.maxSteerAngle) steerAngleCT = mf.vehicle.maxSteerAngle;

                    if (ppRadiusCT < -500) ppRadiusCT = -500;
                    if (ppRadiusCT > 500) ppRadiusCT = 500;

                    radiusPointCT.easting = pivot.easting + (ppRadiusCT * Math.Cos(localHeading));
                    radiusPointCT.northing = pivot.northing + (ppRadiusCT * Math.Sin(localHeading));

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
                    if (isABSameAsVehicleHeading)
                    {
                        if (!isOnRightSideCurrentLine) distanceFromCurrentLine *= -1.0;
                    }

                    //opposite way so right is left
                    else if (isOnRightSideCurrentLine)
                    {
                        distanceFromCurrentLine *= -1.0;
                    }
                }

                //fill in the autosteer variables
                mf.guidanceLineDistanceOff = (Int16)distanceFromCurrentLine;
                mf.guidanceLineSteerAngle = (Int16)(steerAngleCT * 100);
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
            ////draw the guidance line
            int ptCount = ctList.Count;
            GL.LineWidth(2);
            GL.Color3(0.98f, 0.2f, 0.0f);
            GL.Begin(PrimitiveType.LineStrip);
            for (int h = 0; h < ptCount; h++) GL.Vertex3(ctList[h].easting, ctList[h].northing, 0);
            GL.End();

            //GL.PointSize(6.0f);
            //GL.Begin(PrimitiveType.Points);

            //GL.Color3(1.0f, 0.95f, 0.095f);
            //GL.Vertex3(rEastCT, rNorthCT, 0.0);
            //GL.End();
            //GL.PointSize(1.0f);


            GL.PointSize(4.0f);
            GL.Begin(PrimitiveType.Points);

            GL.Color3(0.7f, 0.7f, 0.25f);
            for (int h = 0; h < ptCount; h++) GL.Vertex3(ctList[h].easting, ctList[h].northing, 0);

            GL.End();
            //GL.PointSize(1.0f);

            //GL.Color3(0.98f, 0.98f, 0.50f);
            //GL.Begin(PrimitiveType.LineStrip);
            ////for (int h = 0; h < ptCount; h++) GL.Vertex3(guideList[h].x, 0, guideList[h].z);
            //GL.Vertex3(boxE.easting, boxE.northing, 0);
            //GL.Vertex3(boxA.easting, boxA.northing, 0);
            //GL.Vertex3(boxD.easting, boxD.northing, 0);
            //GL.Vertex3(boxG.easting, boxG.northing, 0);
            //GL.Vertex3(boxE.easting, boxE.northing, 0);
            //GL.End();

            //GL.Begin(PrimitiveType.LineStrip);
            ////for (int h = 0; h < ptCount; h++) GL.Vertex3(guideList[h].x, 0, guideList[h].z);
            //GL.Vertex3(boxF.easting, boxF.northing, 0);
            //GL.Vertex3(boxH.easting, boxH.northing, 0);
            //GL.Vertex3(boxC.easting, boxC.northing, 0);
            //GL.Vertex3(boxB.easting, boxB.northing, 0);
            //GL.Vertex3(boxF.easting, boxF.northing, 0);
            //GL.End();

            ////draw the reference line
            //GL.PointSize(3.0f);
            ////if (isContourBtnOn)
            //{
            //    ptCount = stripList.Count;
            //    if (ptCount > 0)
            //    {
            //        ptCount = stripList[closestRefPatch].Count;
            //        GL.Begin(PrimitiveType.Points);
            //        for (int i = 0; i < ptCount; i++)
            //        {
            //            GL.Vertex2(stripList[closestRefPatch][i].easting, stripList[closestRefPatch][i].northing);
            //        }
            //        GL.End();
            //    }
            //}

            //ptCount = conList.Count;
            //if (ptCount > 0)
            //{
            //    //draw closest point and side of line points
            //    GL.Color3(0.5f, 0.900f, 0.90f);
            //    GL.PointSize(4.0f);
            //    GL.Begin(PrimitiveType.Points);
            //    for (int i = 0; i < ptCount; i++) GL.Vertex3(conList[i].x, conList[i].z, 0);
            //    GL.End();

            //    GL.Color3(0.35f, 0.30f, 0.90f);
            //    GL.PointSize(6.0f);
            //    GL.Begin(PrimitiveType.Points);
            //    GL.Vertex3(conList[closestRefPoint].x, conList[closestRefPoint].z, 0);
            //    GL.End();
            //}

            if (mf.isPureDisplayOn && distanceFromCurrentLine != 32000 && !mf.isStanleyUsed)
            {
                if (ppRadiusCT < 50 && ppRadiusCT > -50)
                {
                    const int numSegments = 100;
                    double theta = glm.twoPI / numSegments;
                    double c = Math.Cos(theta);//precalculate the sine and cosine
                    double s = Math.Sin(theta);
                    double x = ppRadiusCT;//we start at angle = 0
                    double y = 0;

                    GL.LineWidth(1);
                    GL.Color3(0.795f, 0.230f, 0.7950f);
                    GL.Begin(PrimitiveType.LineLoop);
                    for (int ii = 0; ii < numSegments; ii++)
                    {
                        //glVertex2f(x + cx, y + cy);//output vertex
                        GL.Vertex3(x + radiusPointCT.easting, y + radiusPointCT.northing, 0);//output vertex

                        //apply the rotation matrix
                        double t = x;
                        x = (c * x) - (s * y);
                        y = (s * t) + (c * y);
                    }
                    GL.End();
                }

                //Draw lookahead Point
                GL.PointSize(6.0f);
                GL.Begin(PrimitiveType.Points);

                GL.Color3(1.0f, 0.95f, 0.095f);
                GL.Vertex3(goalPointCT.easting, goalPointCT.northing, 0.0);
                GL.End();
                GL.PointSize(1.0f);
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