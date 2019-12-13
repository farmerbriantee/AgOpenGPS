using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public class CHead
    {
        //copy of the mainform address
        private readonly FormGPS mf;

        public double singleSpaceHeadlandDistance;
        public bool isOn;

        /// <summary>
        /// array of turns
        /// </summary>
        public List<CHeadLines> headArr = new List<CHeadLines>();

        //constructor
        public CHead(FormGPS _f)
        {
            mf = _f;
            singleSpaceHeadlandDistance = 18;
            isOn = false;
        }


        public void FindPointsDriveAround(vec3 fromPt, double headAB, ref vec3 start, ref vec3 stop)
        {
            //initial scan is straight ahead of pivot point of vehicle to find the right turnLine/boundary
            vec3 pt = new vec3();

            bool isFound = false;
            int closestTurnNum = 99;
            int closestTurnIndex = 99999;
            int mazeDim = mf.mazeGrid.mazeColXDim * mf.mazeGrid.mazeRowYDim;

            double cosHead = Math.Cos(headAB);
            double sinHead = Math.Sin(headAB);

            for (int b = 1; b < 1600; b += 2)
            {
                pt.easting = fromPt.easting + (sinHead * b);
                pt.northing = fromPt.northing + (cosHead * b);

                if (mf.turn.turnArr[0].IsPointInTurnWorkArea(pt))
                {
                    for (int t = 1; t < mf.bnd.bndArr.Count; t++)
                    {
                        if (!mf.bnd.bndArr[t].isSet || mf.bnd.bndArr[t].isDriveThru) continue;

                        if (mf.bnd.bndArr[t].isDriveAround)
                        {
                            if (mf.hd.headArr[t].IsPointInHeadArea(pt))
                            {
                                isFound = true;
                                closestTurnNum = t;
                                closestTurnIndex = b;

                                start.easting = fromPt.easting + (sinHead * b);
                                start.northing = fromPt.northing + (cosHead * b);
                                start.heading = headAB;
                                break;
                            }
                        }
                        else
                        {
                            //its a uturn obstacle
                            if (mf.turn.turnArr[t].IsPointInTurnWorkArea(pt))
                            {
                                start.easting = 88888;
                                return;
                            }
                        }
                    }
                }
                else
                {
                    isFound = true;
                    start.easting = 88888;
                    closestTurnNum = 0;
                    return;
                }
                if (isFound) break;
            }

            isFound = false;

            for (int b = closestTurnIndex + 200; b > closestTurnIndex; b--)
            {
                pt.easting = fromPt.easting + (sinHead * b);
                pt.northing = fromPt.northing + (cosHead * b);

                if (mf.hd.headArr[closestTurnNum].IsPointInHeadArea(pt))
                {
                    isFound = true;

                    stop.easting = fromPt.easting + (sinHead * b);
                    stop.northing = fromPt.northing + (cosHead * b);
                    stop.heading = headAB;
                }

                if (isFound) break;
            }

            for (int i = 0; i < 30; i++)
            {
                start.easting -= sinHead;
                start.northing -= cosHead;
                start.heading = headAB;

                int iStart = (int)((((int)((start.northing - mf.minFieldY) / mf.mazeGrid.mazeScale)) * mf.mazeGrid.mazeColXDim)
                    + (int)((start.easting - mf.minFieldX) / mf.mazeGrid.mazeScale));

                if (iStart >= mazeDim)
                {
                    isFound = true;
                    start.easting = 88888;
                    closestTurnNum = 0;
                    return;
                }

                if (mf.mazeGrid.mazeArr[iStart] == 0) break;
            }

            for (int i = 0; i < 30; i++)
            {
                stop.easting += sinHead;
                stop.northing += cosHead;
                stop.heading = headAB;

                int iStop = (int)((((int)((stop.northing - mf.minFieldY) / mf.mazeGrid.mazeScale)) * mf.mazeGrid.mazeColXDim)
                    + (int)((stop.easting - mf.minFieldX) / mf.mazeGrid.mazeScale));

                if (iStop >= mazeDim)
                {
                    isFound = true;
                    start.easting = 88888;
                    closestTurnNum = 0;
                    return;
                }

                if (mf.mazeGrid.mazeArr[iStop] == 0) break;
            }
        }

        public bool IsPointInsideHeads(vec3 pt)
        {
            //if inside outer boundary, then potentially add
            if (headArr.Count > 0 && headArr[0].IsPointInHeadArea(pt))
            {
                for (int b = 1; b < mf.bnd.bndArr.Count; b++)
                {
                    if (mf.bnd.bndArr[b].isSet)
                    {
                        if (headArr[b].IsPointInHeadArea(pt))
                        {
                            //point is in an inner turn area but inside outer
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsPointInsideHeads(vec2 pt)
        {
            //if inside outer boundary, then potentially add
            if (headArr.Count > 0 && headArr[0].IsPointInHeadArea(pt))
            {
                for (int b = 1; b < mf.bnd.bndArr.Count; b++)
                {
                    if (mf.bnd.bndArr[b].isSet)
                    {
                        if (headArr[b].IsPointInHeadArea(pt))
                        {
                            //point is in an inner turn area but inside outer
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }


        public void DrawHeadLines()
        {

            //for (int i = 0; i < mf.bnd.bndArr.Count; i++)
            {
                if (headArr[0].hdLine.Count > 0 && isOn) headArr[0].DrawHeadLine(mf.ABLine.lineWidth);
            }
        }
    }
}