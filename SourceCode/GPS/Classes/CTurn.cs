using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public partial class CBoundary
    {
        // the list of possible bounds points
        public List<vec4> turnClosestList = new List<vec4>();

        public int turnSelected, closestTurnNum;

        //point at the farthest turn segment from pivotAxle
        public vec3 closestTurnPt = new vec3(-10000, -10000, 9);

        public void FindClosestTurnPoint(bool isYouTurnRight, vec3 fromPt, double headAB)
        {
            //initial scan is straight ahead of pivot point of vehicle to find the right turnLine/boundary
            vec3 pt = new vec3();
            vec3 rayPt = new vec3();

            bool isFound = false;
            int closestTurnNum = 99;

            double cosHead = Math.Cos(headAB);
            double sinHead = Math.Sin(headAB);

            for (int b = 1; b < mf.maxCrossFieldLength; b += 2)
            {
                pt.easting = fromPt.easting + (sinHead * b);
                pt.northing = fromPt.northing + (cosHead * b);

                if (bndArr[0].IsPointInTurnWorkArea(pt))
                {
                    for (int t = 1; t < bndArr.Count; t++)
                    {
                        if (bndArr[t].isDriveThru) continue;
                        if (bndArr[t].isDriveAround) continue;
                        if (bndArr[t].IsPointInTurnWorkArea(pt))
                        {
                            isFound = true;
                            closestTurnNum = t;
                            rayPt.easting = pt.easting;
                            rayPt.northing = pt.northing;
                            break;
                        }
                    }
                    if (isFound) break;
                }
                else
                {
                    closestTurnNum = 0;
                    rayPt.easting = pt.easting;
                    rayPt.northing = pt.northing;
                    break;
                }
            }

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

            int ptCount = bndArr[closestTurnNum].turnLine.Count;
            for (int p = 0; p < ptCount; p++)
            {
                if ((((boxB.easting - boxA.easting) * (bndArr[closestTurnNum].turnLine[p].northing - boxA.northing))
                        - ((boxB.northing - boxA.northing) * (bndArr[closestTurnNum].turnLine[p].easting - boxA.easting))) < 0) { continue; }

                if ((((boxD.easting - boxC.easting) * (bndArr[closestTurnNum].turnLine[p].northing - boxC.northing))
                        - ((boxD.northing - boxC.northing) * (bndArr[closestTurnNum].turnLine[p].easting - boxC.easting))) < 0) { continue; }

                if ((((boxC.easting - boxB.easting) * (bndArr[closestTurnNum].turnLine[p].northing - boxB.northing))
                        - ((boxC.northing - boxB.northing) * (bndArr[closestTurnNum].turnLine[p].easting - boxB.easting))) < 0) { continue; }

                if ((((boxA.easting - boxD.easting) * (bndArr[closestTurnNum].turnLine[p].northing - boxD.northing))
                        - ((boxA.northing - boxD.northing) * (bndArr[closestTurnNum].turnLine[p].easting - boxD.easting))) < 0) { continue; }

                //it's in the box, so add to list
                inBox.easting = bndArr[closestTurnNum].turnLine[p].easting;
                inBox.northing = bndArr[closestTurnNum].turnLine[p].northing;
                inBox.heading = bndArr[closestTurnNum].turnLine[p].heading;
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

                ptCount = bndArr[closestTurnNum].turnLine.Count;

                for (int p = 0; p < ptCount; p++)
                {
                    if ((((boxB.easting - boxA.easting) * (bndArr[closestTurnNum].turnLine[p].northing - boxA.northing))
                            - ((boxB.northing - boxA.northing) * (bndArr[closestTurnNum].turnLine[p].easting - boxA.easting))) < 0) { continue; }

                    if ((((boxD.easting - boxC.easting) * (bndArr[closestTurnNum].turnLine[p].northing - boxC.northing))
                            - ((boxD.northing - boxC.northing) * (bndArr[closestTurnNum].turnLine[p].easting - boxC.easting))) < 0) { continue; }

                    if ((((boxC.easting - boxB.easting) * (bndArr[closestTurnNum].turnLine[p].northing - boxB.northing))
                            - ((boxC.northing - boxB.northing) * (bndArr[closestTurnNum].turnLine[p].easting - boxB.easting))) < 0) { continue; }

                    if ((((boxA.easting - boxD.easting) * (bndArr[closestTurnNum].turnLine[p].northing - boxD.northing))
                            - ((boxA.northing - boxD.northing) * (bndArr[closestTurnNum].turnLine[p].easting - boxD.easting))) < 0) { continue; }

                    //it's in the box, so add to list
                    inBox.easting = bndArr[closestTurnNum].turnLine[p].easting;
                    inBox.northing = bndArr[closestTurnNum].turnLine[p].northing;
                    inBox.heading = bndArr[closestTurnNum].turnLine[p].heading;
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
            //update the GUI values for boundaries
            mf.fd.UpdateFieldBoundaryGUIAreas();

            if (bndArr.Count == 0)
            {
                //mf.TimedMessageBox(1500, " No Boundaries", "No Turn Lines Made");
                return;
            }

            //to fill the list of line points
            vec3 point = new vec3();

            //determine how wide a headland space
            double totalHeadWidth = mf.yt.uturnDistanceFromBoundary;

            //inside boundaries
            for (int j = 0; j < bndArr.Count; j++)
            {
                bndArr[j].turnLine.Clear();
                if (bndArr[j].isDriveThru || bndArr[j].isDriveAround) continue;

                int ptCount = bndArr[j].bndLine.Count;

                for (int i = ptCount - 1; i >= 0; i--)
                {
                    //calculate the point outside the boundary
                    point.easting = bndArr[j].bndLine[i].easting + (-Math.Sin(glm.PIBy2 + bndArr[j].bndLine[i].heading) * totalHeadWidth);
                    point.northing = bndArr[j].bndLine[i].northing + (-Math.Cos(glm.PIBy2 + bndArr[j].bndLine[i].heading) * totalHeadWidth);
                    point.heading = bndArr[j].bndLine[i].heading;
                    if (point.heading < -glm.twoPI) point.heading += glm.twoPI;

                    //only add if outside actual field boundary
                    if (j == 0 == bndArr[j].IsPointInsideBoundaryEar(point))
                    {
                        vec3 tPnt = new vec3(point.easting, point.northing, point.heading);
                        bndArr[j].turnLine.Add(tPnt);
                    }
                }
                bndArr[j].FixTurnLine(totalHeadWidth, mf.tool.toolWidth * 0.33);
            }
        }

        public void DrawTurnLines()
        {
            GL.LineWidth(mf.ABLine.lineWidth);
            GL.Color3(0.3555f, 0.6232f, 0.20f);
            //GL.PointSize(2);

            for (int i = 0; i < bndArr.Count; i++)
            {
                if (bndArr[i].isDriveAround) continue;
                //turnArr[i].DrawTurnLine();
                {
                    ////draw the turn line oject
                    int ptCount = bndArr[i].turnLine.Count;
                    if (ptCount < 1) continue;

                    GL.Begin(PrimitiveType.LineLoop);
                    for (int h = 0; h < ptCount; h++) GL.Vertex3(bndArr[i].turnLine[h].easting, bndArr[i].turnLine[h].northing, 0);
                    GL.End();
                }
            }
        }
    }
}