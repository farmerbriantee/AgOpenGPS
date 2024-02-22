using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public partial class CBoundary
    {

        public int turnSelected, closestTurnNum;
        public double iE = 0, iN = 0;
        // the list of possible bounds points
        //public List<vec3> turnClosestList = new List<vec3>();

        //point at the farthest turn segment from pivotAxle
        //public vec3 closestTurnPt = new vec3(-10000, -10000, 9);

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
            return -1; //is outside border turn
        }

        //public vec3 closePt;

        //public void FoindClosestTurnPoint(vec3 fromPt)
        //{
        //    double eP = fromPt.easting;
        //    double nP = fromPt.northing;
        //    double eAB, nAB;

        //    if (mf.ABLine.isHeadingSameWay)
        //    {
        //        eAB = mf.ABLine.currentLinePtB.easting;
        //        nAB = mf.ABLine.currentLinePtB.northing;
        //    }
        //    else
        //    {
        //        eAB = mf.ABLine.currentLinePtA.easting;
        //        nAB = mf.ABLine.currentLinePtA.northing;
        //    }

        //    turnClosestList.Clear();

        //    for (int j = 0; j < bndList.Count; j++)
        //    {
        //        for (int i = 0; i < mf.bnd.bndList[j].turnLine.Count - 1; i++)
        //        {
        //            int res = mf.yt.GetLineIntersection(
        //                mf.bnd.bndList[j].turnLine[i].easting,
        //                mf.bnd.bndList[j].turnLine[i].northing,
        //                mf.bnd.bndList[j].turnLine[i + 1].easting,
        //                mf.bnd.bndList[j].turnLine[i + 1].northing,
        //                eP, nP, eAB, nAB, ref iE, ref iN
        //                );

        //            if (res == 1)
        //            {
        //                closePt.easting = iE;
        //                closePt.northing = iN;

        //                double hed = Math.Atan2(mf.bnd.bndList[j].turnLine[i + 1].easting - mf.bnd.bndList[j].turnLine[i].easting,
        //                    mf.bnd.bndList[j].turnLine[i + 1].northing - mf.bnd.bndList[j].turnLine[i].northing);
        //                if (hed < 0) hed += glm.twoPI;
        //                closePt.heading = hed;
        //                turnClosestList.Add(closePt);
        //            }
        //        }
        //    }

        //    //determine closest point
        //    double minDistance = double.MaxValue;

        //    if (turnClosestList.Count == 1)
        //    {
        //        closestTurnPt.easting = turnClosestList[0].easting;
        //        closestTurnPt.northing = turnClosestList[0].northing;
        //        closestTurnPt.heading = turnClosestList[0].heading;

        //        if (closestTurnPt.heading < 0) closestTurnPt.heading += glm.twoPI;
        //        return;
        //    }

        //    if (turnClosestList.Count > 0 || turnClosestList.Count != 0)
        //    {
        //        for (int i = 0; i < turnClosestList.Count; i++)
        //        {
        //            double dist = (((fromPt.easting - turnClosestList[i].easting) * (fromPt.easting - turnClosestList[i].easting))
        //                            + ((fromPt.northing - turnClosestList[i].northing) * (fromPt.northing - turnClosestList[i].northing)));

        //            if (minDistance >= dist)
        //            {
        //                minDistance = dist;
        //                closestTurnPt.easting = turnClosestList[i].easting;
        //                closestTurnPt.northing = turnClosestList[i].northing;
        //                closestTurnPt.heading = turnClosestList[i].heading;
        //            }
        //        }
        //        if (closestTurnPt.heading < 0) closestTurnPt.heading += glm.twoPI;
        //    }
        //}

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
                bndList[j].FixTurnLine(totalHeadWidth, 2);

                //count the reference list of original curve
                int cnt = bndList[j].turnLine.Count;

                //the temp array
                vec3[] arr = new vec3[cnt];

                for (int s = 0; s < cnt; s++)
                {
                    arr[s] = bndList[j].turnLine[s];
                }

                double delta = 0;
                bndList[j].turnLine?.Clear();

                for (int i = 0; i < arr.Length; i++)
                {
                    if (i == 0)
                    {
                        bndList[j].turnLine.Add(arr[i]);
                        continue;
                    }
                    delta += (arr[i - 1].heading - arr[i].heading);
                    if (Math.Abs(delta) > 0.005)
                    {
                        bndList[j].turnLine.Add(arr[i]);
                        delta = 0;
                    }
                }

                if (bndList[j].turnLine.Count > 0)
                {
                    vec3 end = new vec3(bndList[j].turnLine[0].easting,
                        bndList[j].turnLine[0].northing, bndList[j].turnLine[0].heading);
                    bndList[j].turnLine.Add(end);
                }
            }
        }
    }
}