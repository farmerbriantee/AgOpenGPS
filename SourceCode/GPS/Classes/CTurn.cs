using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public partial class CBoundary
    {
        // the list of possible bounds points
        public List<vec4> turnClosestList = new List<vec4>();

        public int turnSelected, closestTurnNum;

        //generated box for finding closest point
        public vec2 boxA = new vec2(9000, 9000), boxB = new vec2(9000, 9002);

        public vec2 boxC = new vec2(9001, 9001), boxD = new vec2(9002, 9003);

        private readonly double boxLength;

        //point at the farthest turn segment from pivotAxle
        public vec3 closestTurnPt = new vec3(-10000, -10000, 9);

        public int IsPointInsideTurnArea(vec3 pt)
        {
            if (bndList.Count > 0 && bndList[0].turnLine.IsPointInPolygon(pt))
            {
                for (int i = 1; i < bndList.Count; i++)
                {
                    if (bndList[i].isDriveThru) continue;
                    if (bndList[i].turnLine.IsPointInPolygon(pt))
                    {
                        return i;
                    }
                }
                return 0;
            }
            return -1;
        }

        public void FindClosestTurnPoint(bool isYouTurnRight, vec3 fromPt, double headAB)
        {
            //initial scan is straight ahead of pivot point of vehicle to find the right turnLine/boundary
            vec3 pt = new vec3();
            vec3 rayPt = new vec3();

            int closestTurnNum = 99;

            double cosHead = Math.Cos(headAB);
            double sinHead = Math.Sin(headAB);

            for (int b = 1; b < mf.maxCrossFieldLength; b += 2)
            {
                pt.easting = fromPt.easting + (sinHead * b);
                pt.northing = fromPt.northing + (cosHead * b);

                int idx = IsPointInsideTurnArea(pt);
                if (idx != 0)
                {
                    closestTurnNum = idx;
                    rayPt.easting = pt.easting;
                    rayPt.northing = pt.northing;
                    break;
                }
            }
            if (closestTurnNum < 0) closestTurnNum = 0;

            //second scan is straight ahead of outside of tool based on turn direction
            double scanWidthL, scanWidthR;
            if (isYouTurnRight) //its actually left
            {
                scanWidthL = -(mf.tool.toolWidth * 0.25) - (mf.tool.toolWidth * 0.5);
                scanWidthR = (mf.tool.toolWidth * 0.25) - (mf.tool.toolWidth * 0.5);
            }
            else
            {
                scanWidthL = -(mf.tool.toolWidth * 0.25) + (mf.tool.toolWidth * 0.5);
                scanWidthR = (mf.tool.toolWidth * 0.25) + (mf.tool.toolWidth * 0.5);
            }

            //isYouTurnRight actuall means turning left - Painful, but it switches later
            boxA.easting = fromPt.easting + (Math.Sin(headAB + glm.PIBy2) * scanWidthL);
            boxA.northing = fromPt.northing + (Math.Cos(headAB + glm.PIBy2) * scanWidthL);

            boxB.easting = fromPt.easting + (Math.Sin(headAB + glm.PIBy2) * scanWidthR);
            boxB.northing = fromPt.northing + (Math.Cos(headAB + glm.PIBy2) * scanWidthR);

            boxC.easting = boxB.easting + (Math.Sin(headAB) * boxLength);
            boxC.northing = boxB.northing + (Math.Cos(headAB) * boxLength);

            boxD.easting = boxA.easting + (Math.Sin(headAB) * boxLength);
            boxD.northing = boxA.northing + (Math.Cos(headAB) * boxLength);

            //determine if point is inside bounding box of the 1 turn chosen above
            turnClosestList.Clear();

            vec4 inBox;

            int ptCount = bndList[closestTurnNum].turnLine.Count;
            for (int p = 0; p < ptCount; p++)
            {
                if ((((boxB.easting - boxA.easting) * (bndList[closestTurnNum].turnLine[p].northing - boxA.northing))
                        - ((boxB.northing - boxA.northing) * (bndList[closestTurnNum].turnLine[p].easting - boxA.easting))) < 0) { continue; }

                if ((((boxD.easting - boxC.easting) * (bndList[closestTurnNum].turnLine[p].northing - boxC.northing))
                        - ((boxD.northing - boxC.northing) * (bndList[closestTurnNum].turnLine[p].easting - boxC.easting))) < 0) { continue; }

                if ((((boxC.easting - boxB.easting) * (bndList[closestTurnNum].turnLine[p].northing - boxB.northing))
                        - ((boxC.northing - boxB.northing) * (bndList[closestTurnNum].turnLine[p].easting - boxB.easting))) < 0) { continue; }

                if ((((boxA.easting - boxD.easting) * (bndList[closestTurnNum].turnLine[p].northing - boxD.northing))
                        - ((boxA.northing - boxD.northing) * (bndList[closestTurnNum].turnLine[p].easting - boxD.easting))) < 0) { continue; }

                //it's in the box, so add to list
                inBox.easting = bndList[closestTurnNum].turnLine[p].easting;
                inBox.northing = bndList[closestTurnNum].turnLine[p].northing;
                inBox.heading = bndList[closestTurnNum].turnLine[p].heading;
                inBox.index = closestTurnNum;

                //which turn/headland is it from
                turnClosestList.Add(inBox);
            }

            if (turnClosestList.Count == 0)
            {
                if (isYouTurnRight) //its actually left
                {
                    scanWidthL = -(mf.tool.toolWidth * 0.5);
                    scanWidthR = 0;
                }
                else
                {
                    scanWidthL = 0;
                    scanWidthR = (mf.tool.toolWidth * 0.5);
                }

                //isYouTurnRight actuall means turning left - Painful, but it switches later
                boxA.easting = fromPt.easting + (Math.Sin(headAB + glm.PIBy2) * scanWidthL);
                boxA.northing = fromPt.northing + (Math.Cos(headAB + glm.PIBy2) * scanWidthL);

                boxB.easting = fromPt.easting + (Math.Sin(headAB + glm.PIBy2) * scanWidthR);
                boxB.northing = fromPt.northing + (Math.Cos(headAB + glm.PIBy2) * scanWidthR);

                boxC.easting = boxB.easting + (Math.Sin(headAB) * boxLength);
                boxC.northing = boxB.northing + (Math.Cos(headAB) * boxLength);

                boxD.easting = boxA.easting + (Math.Sin(headAB) * boxLength);
                boxD.northing = boxA.northing + (Math.Cos(headAB) * boxLength);

                //determine if point is inside bounding box of the 1 turn chosen above
                turnClosestList.Clear();

                ptCount = bndList[closestTurnNum].turnLine.Count;

                for (int p = 0; p < ptCount; p++)
                {
                    if ((((boxB.easting - boxA.easting) * (bndList[closestTurnNum].turnLine[p].northing - boxA.northing))
                            - ((boxB.northing - boxA.northing) * (bndList[closestTurnNum].turnLine[p].easting - boxA.easting))) < 0) { continue; }

                    if ((((boxD.easting - boxC.easting) * (bndList[closestTurnNum].turnLine[p].northing - boxC.northing))
                            - ((boxD.northing - boxC.northing) * (bndList[closestTurnNum].turnLine[p].easting - boxC.easting))) < 0) { continue; }

                    if ((((boxC.easting - boxB.easting) * (bndList[closestTurnNum].turnLine[p].northing - boxB.northing))
                            - ((boxC.northing - boxB.northing) * (bndList[closestTurnNum].turnLine[p].easting - boxB.easting))) < 0) { continue; }

                    if ((((boxA.easting - boxD.easting) * (bndList[closestTurnNum].turnLine[p].northing - boxD.northing))
                            - ((boxA.northing - boxD.northing) * (bndList[closestTurnNum].turnLine[p].easting - boxD.easting))) < 0) { continue; }

                    //it's in the box, so add to list
                    inBox.easting = bndList[closestTurnNum].turnLine[p].easting;
                    inBox.northing = bndList[closestTurnNum].turnLine[p].northing;
                    inBox.heading = bndList[closestTurnNum].turnLine[p].heading;
                    inBox.index = closestTurnNum;

                    //which turn/headland is it from
                    turnClosestList.Add(inBox);
                }
            }
            //which of the points is closest
            //closestTurnPt.easting = -20000; closestTurnPt.northing = -20000;
            ptCount = turnClosestList.Count;
            if (ptCount != 0)
            {
                double totalDist = 0.75 * Math.Sqrt(((fromPt.easting - rayPt.easting) * (fromPt.easting - rayPt.easting))
                + ((fromPt.northing - rayPt.northing) * (fromPt.northing - rayPt.northing)));

                //determine closest point
                double minDistance = 9999999;
                for (int i = 0; i < ptCount; i++)
                {
                    double dist = Math.Sqrt(((fromPt.easting - turnClosestList[i].easting) * (fromPt.easting - turnClosestList[i].easting))
                                    + ((fromPt.northing - turnClosestList[i].northing) * (fromPt.northing - turnClosestList[i].northing)));

                    //double distRay = ((rayPt.easting - turnClosestList[i].easting) * (rayPt.easting - turnClosestList[i].easting))
                    //                + ((rayPt.northing - turnClosestList[i].northing) * (rayPt.northing - turnClosestList[i].northing));

                    if (minDistance >= dist && dist > totalDist)
                    {
                        minDistance = dist;
                        closestTurnPt.easting = turnClosestList[i].easting;
                        closestTurnPt.northing = turnClosestList[i].northing;
                        closestTurnPt.heading = turnClosestList[i].heading;
                    }
                }
                if (closestTurnPt.heading < 0) closestTurnPt.heading += glm.twoPI;
            }
        }

        public void BuildTurnLines()
        {
            if (bndList.Count == 0)
            {
                //mf.TimedMessageBox(1500, " No Boundaries", "No Turn Lines Made");
                return;
            }

            //update the GUI values for boundaries
            mf.fd.UpdateFieldBoundaryGUIAreas();

            //to fill the list of line points
            vec3 point = new vec3();

            //determine how wide a headland space
            double totalHeadWidth = mf.yt.uturnDistanceFromBoundary;

            //inside boundaries
            for (int j = 0; j < bndList.Count; j++)
            {
                bndList[j].turnLine.Clear();
                if (bndList[j].isDriveThru) continue;

                int ptCount = bndList[j].fenceLine.Count;

                for (int i = ptCount - 1; i >= 0; i--)
                {
                    //calculate the point outside the boundary
                    point.easting = bndList[j].fenceLine[i].easting + (-Math.Sin(glm.PIBy2 + bndList[j].fenceLine[i].heading) * totalHeadWidth);
                    point.northing = bndList[j].fenceLine[i].northing + (-Math.Cos(glm.PIBy2 + bndList[j].fenceLine[i].heading) * totalHeadWidth);
                    point.heading = bndList[j].fenceLine[i].heading;
                    if (point.heading < -glm.twoPI) point.heading += glm.twoPI;

                    //only add if outside actual field boundary
                    if (j == 0 == bndList[j].fenceLineEar.IsPointInPolygon(point))
                    {
                        vec3 tPnt = new vec3(point.easting, point.northing, point.heading);
                        bndList[j].turnLine.Add(tPnt);
                    }
                }
                bndList[j].FixTurnLine(totalHeadWidth, mf.tool.toolWidth * 0.33);
            }
        }
    }
}