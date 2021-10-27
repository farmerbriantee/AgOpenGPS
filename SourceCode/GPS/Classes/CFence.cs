using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public partial class CBoundary
    {
        public List<vec3> bndBeingMadePts = new List<vec3>(128);

        public double createBndOffset;
        public bool isBndBeingMade;

        // the list of possible bounds points
        public List<vec4> bndClosestList = new List<vec4>();

        public bool isDrawRightSide = true, isOkToAddPoints = false;

        public int fenceSelected, closestFenceNum;

        //point at the farthest boundary segment from pivotAxle
        public vec3 closestFencePt = new vec3(-10000, -10000, 9);

        public bool IsInsideAllFences(vec3 testPoint)
        {
            //first where are we, must be inside outer and outside of inner geofence non drive thru turn borders
            if (glm.IsPointInPolygon(testPoint, ref bndList[0].fenceLine))
            {
                for (int i = 1; i < bndList.Count; i++)
                {
                    //make sure not inside a non drivethru boundary
                    if (bndList[i].isDriveThru) continue;
                    if (glm.IsPointInPolygon(testPoint, ref bndList[i].fenceLine))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            //we are safely inside outer, outside inner boundaries
            return true;
        }

        public void DrawFenceLines()
        {
            //draw the boundaries
            GL.Color3(0.75f, 0.5f, 0.250f);

            for (int i = 0; i < bndList.Count; i++)
            {
                bndList[i].DrawFenceLine(mf.ABLine.lineWidth, mf.mc.isOutOfBounds);
            }

            if (bndBeingMadePts.Count > 0)
            {
                //the boundary so far
                vec3 pivot = mf.pivotAxlePos;
                GL.LineWidth(mf.ABLine.lineWidth);
                GL.Color3(0.825f, 0.22f, 0.90f);
                GL.Begin(PrimitiveType.LineStrip);
                for (int h = 0; h < bndBeingMadePts.Count; h++) GL.Vertex3(bndBeingMadePts[h].easting, bndBeingMadePts[h].northing, 0);
                GL.Color3(0.295f, 0.972f, 0.290f);
                GL.Vertex3(bndBeingMadePts[0].easting, bndBeingMadePts[0].northing, 0);
                GL.End();

                //line from last point to pivot marker
                GL.Color3(0.825f, 0.842f, 0.0f);
                GL.Enable(EnableCap.LineStipple);
                GL.LineStipple(1, 0x0700);
                GL.Begin(PrimitiveType.LineStrip);
                if (isDrawRightSide)
                {
                    GL.Vertex3(bndBeingMadePts[0].easting, bndBeingMadePts[0].northing, 0);

                    GL.Vertex3(pivot.easting + (Math.Sin(pivot.heading - glm.PIBy2) * -createBndOffset),
                            pivot.northing + (Math.Cos(pivot.heading - glm.PIBy2) * -createBndOffset), 0);
                    GL.Vertex3(bndBeingMadePts[bndBeingMadePts.Count - 1].easting, bndBeingMadePts[bndBeingMadePts.Count - 1].northing, 0);
                }
                else
                {
                    GL.Vertex3(bndBeingMadePts[0].easting, bndBeingMadePts[0].northing, 0);

                    GL.Vertex3(pivot.easting + (Math.Sin(pivot.heading - glm.PIBy2) * createBndOffset),
                            pivot.northing + (Math.Cos(pivot.heading - glm.PIBy2) * createBndOffset), 0);
                    GL.Vertex3(bndBeingMadePts[bndBeingMadePts.Count - 1].easting, bndBeingMadePts[bndBeingMadePts.Count - 1].northing, 0);
                }
                GL.End();
                GL.Disable(EnableCap.LineStipple);

                //boundary points
                GL.Color3(0.0f, 0.95f, 0.95f);
                GL.PointSize(6.0f);
                GL.Begin(PrimitiveType.Points);
                for (int h = 0; h < bndBeingMadePts.Count; h++) GL.Vertex3(bndBeingMadePts[h].easting, bndBeingMadePts[h].northing, 0);
                GL.End();
            }
        }
        
    }
}

        
//public void FindClosestBoundaryPoint(vec3 fromPt, double headAB)
        //{
        //    {
        //        boxA.easting = fromPt.easting + (Math.Sin(headAB + glm.PIBy2) * (scanWidth - 2));
        //        boxA.northing = fromPt.northing + (Math.Cos(headAB + glm.PIBy2) * (scanWidth - 2));

        //        boxB.easting = fromPt.easting + (Math.Sin(headAB + glm.PIBy2) * scanWidth);
        //        boxB.northing = fromPt.northing + (Math.Cos(headAB + glm.PIBy2) * scanWidth);

        //        boxC.easting = boxB.easting + (Math.Sin(headAB) * boxLength);
        //        boxC.northing = boxB.northing + (Math.Cos(headAB) * boxLength);

        //        boxD.easting = boxA.easting + (Math.Sin(headAB) * boxLength);
        //        boxD.northing = boxA.northing + (Math.Cos(headAB) * boxLength);
        //    }

        //    int ptCount;

        //    //determine if point is inside bounding box
        //    bndClosestList.Clear();
        //    vec4 inBox;
        //    for (int i = 0; i < plots.Count; i++)
        //    {
        //        //skip the drive thru
        //        if (plots[i].isDriveThru) continue;

        //        ptCount = plots[i].bndLine.Count;
        //        for (int p = 0; p < ptCount; p++)
        //        {
        //            if ((((boxB.easting - boxA.easting) * (plots[i].bndLine[p].northing - boxA.northing))
        //                    - ((boxB.northing - boxA.northing) * (plots[i].bndLine[p].easting - boxA.easting))) < 0) { continue; }

        //            if ((((boxD.easting - boxC.easting) * (plots[i].bndLine[p].northing - boxC.northing))
        //                    - ((boxD.northing - boxC.northing) * (plots[i].bndLine[p].easting - boxC.easting))) < 0) { continue; }

        //            if ((((boxC.easting - boxB.easting) * (plots[i].bndLine[p].northing - boxB.northing))
        //                    - ((boxC.northing - boxB.northing) * (plots[i].bndLine[p].easting - boxB.easting))) < 0) { continue; }

        //            if ((((boxA.easting - boxD.easting) * (plots[i].bndLine[p].northing - boxD.northing))
        //                    - ((boxA.northing - boxD.northing) * (plots[i].bndLine[p].easting - boxD.easting))) < 0) { continue; }

        //            //it's in the box, so add to list
        //            inBox.easting = plots[i].bndLine[p].easting;
        //            inBox.northing = plots[i].bndLine[p].northing;
        //            inBox.heading = plots[i].bndLine[p].heading;
        //            inBox.index = i;

        //            //which boundary/headland is it from
        //            bndClosestList.Add(inBox);
        //        }
        //    }

        //    //which of the points is closest
        //    closestBoundaryPt.easting = -20000; closestBoundaryPt.northing = -20000;
        //    ptCount = bndClosestList.Count;
        //    if (ptCount != 0)
        //    {
        //        //determine closest point
        //        double minDistance = 9999999;
        //        for (int i = 0; i < ptCount; i++)
        //        {
        //            double dist = ((fromPt.easting - bndClosestList[i].easting) * (fromPt.easting - bndClosestList[i].easting))
        //                            + ((fromPt.northing - bndClosestList[i].northing) * (fromPt.northing - bndClosestList[i].northing));
        //            if (minDistance >= dist)
        //            {
        //                minDistance = dist;

        //                closestBoundaryPt.easting = bndClosestList[i].easting;
        //                closestBoundaryPt.northing = bndClosestList[i].northing;
        //                closestBoundaryPt.heading = bndClosestList[i].heading;
        //                closestBoundaryNum = bndClosestList[i].index;
        //            }
        //        }
        //        if (closestBoundaryPt.heading < 0) closestBoundaryPt.heading += glm.twoPI;
        //    }
        //}