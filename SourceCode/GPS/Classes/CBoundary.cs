using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public class CBoundary
    {
        //copy of the mainform address
        private readonly FormGPS mf;

        /// <summary>
        /// array of boundaries
        /// </summary>
        /// 
        public List<CBoundaryLines> bndArr = new List<CBoundaryLines>();
        public List<vec3> bndBeingMadePts = new List<vec3>();

        private readonly double scanWidth, boxLength;

        public double createBndOffset;
        public bool isBndBeingMade;

        public bool isDrawRightSide = true, isOkToAddPoints = false;
        //constructor
        public CBoundary(FormGPS _f)
        {
            mf = _f;
            boundarySelected = 0;
            scanWidth = 1.0;
            boxLength = 2000;
            //boundaries array
        }

        // the list of possible bounds points
        public List<vec4> bndClosestList = new List<vec4>();

        public int boundarySelected, closestBoundaryNum;

        //generated box for finding closest point
        public vec2 boxA = new vec2(9000, 9000), boxB = new vec2(9000, 9002);

        public vec2 boxC = new vec2(9001, 9001), boxD = new vec2(9002, 9003);

        //point at the farthest boundary segment from pivotAxle
        public vec3 closestBoundaryPt = new vec3(-10000, -10000, 9);

        public void FindClosestBoundaryPoint(vec3 fromPt, double headAB)
        {
            //heading is based on ABLine, average Curve, and going same direction as AB or not
            //Draw a bounding box to determine if points are in it

            //if (mf.yt.isYouTurnTriggered || mf.yt.isEnteringDriveThru || mf.yt.isExitingDriveThru)
            //{
            //    boxA.easting = fromPt.easting + (Math.Sin(headAB + glm.PIBy2) * -scanWidth); //subtract if positive
            //    boxA.northing = fromPt.northing + (Math.Cos(headAB + glm.PIBy2) * -scanWidth);

            //    boxB.easting = fromPt.easting + (Math.Sin(headAB + glm.PIBy2) * scanWidth);
            //    boxB.northing = fromPt.northing + (Math.Cos(headAB + glm.PIBy2) * scanWidth);

            //    boxC.easting = boxB.easting + (Math.Sin(headAB) * boxLength);
            //    boxC.northing = boxB.northing + (Math.Cos(headAB) * boxLength);

            //    boxD.easting = boxA.easting + (Math.Sin(headAB) * boxLength);
            //    boxD.northing = boxA.northing + (Math.Cos(headAB) * boxLength);

            //    boxA.easting -= (Math.Sin(headAB) * boxLength);
            //    boxA.northing -= (Math.Cos(headAB) * boxLength);

            //    boxB.easting -= (Math.Sin(headAB) * boxLength);
            //    boxB.northing -= (Math.Cos(headAB) * boxLength);
            //}
            //else

            {
                boxA.easting = fromPt.easting + (Math.Sin(headAB + glm.PIBy2) * (scanWidth - 2));
                boxA.northing = fromPt.northing + (Math.Cos(headAB + glm.PIBy2) * (scanWidth - 2));

                boxB.easting = fromPt.easting + (Math.Sin(headAB + glm.PIBy2) * scanWidth);
                boxB.northing = fromPt.northing + (Math.Cos(headAB + glm.PIBy2) * scanWidth);

                boxC.easting = boxB.easting + (Math.Sin(headAB) * boxLength);
                boxC.northing = boxB.northing + (Math.Cos(headAB) * boxLength);

                boxD.easting = boxA.easting + (Math.Sin(headAB) * boxLength);
                boxD.northing = boxA.northing + (Math.Cos(headAB) * boxLength);
            }

            int ptCount;

            //determine if point is inside bounding box
            bndClosestList.Clear();
            vec4 inBox;
            for (int i = 0; i < mf.bnd.bndArr.Count; i++)
            {
                //skip the drive thru
                if (bndArr[i].isDriveThru) continue;

                ptCount = bndArr[i].bndLine.Count;
                for (int p = 0; p < ptCount; p++)
                {
                    if ((((boxB.easting - boxA.easting) * (bndArr[i].bndLine[p].northing - boxA.northing))
                            - ((boxB.northing - boxA.northing) * (bndArr[i].bndLine[p].easting - boxA.easting))) < 0) { continue; }

                    if ((((boxD.easting - boxC.easting) * (bndArr[i].bndLine[p].northing - boxC.northing))
                            - ((boxD.northing - boxC.northing) * (bndArr[i].bndLine[p].easting - boxC.easting))) < 0) { continue; }

                    if ((((boxC.easting - boxB.easting) * (bndArr[i].bndLine[p].northing - boxB.northing))
                            - ((boxC.northing - boxB.northing) * (bndArr[i].bndLine[p].easting - boxB.easting))) < 0) { continue; }

                    if ((((boxA.easting - boxD.easting) * (bndArr[i].bndLine[p].northing - boxD.northing))
                            - ((boxA.northing - boxD.northing) * (bndArr[i].bndLine[p].easting - boxD.easting))) < 0) { continue; }

                    //it's in the box, so add to list
                    inBox.easting = bndArr[i].bndLine[p].easting;
                    inBox.northing = bndArr[i].bndLine[p].northing;
                    inBox.heading = bndArr[i].bndLine[p].heading;
                    inBox.index = i;

                    //which boundary/headland is it from
                    bndClosestList.Add(inBox);
                }
            }

            //which of the points is closest
            closestBoundaryPt.easting = -20000; closestBoundaryPt.northing = -20000;
            ptCount = bndClosestList.Count;
            if (ptCount != 0)
            {
                //determine closest point
                double minDistance = 9999999;
                for (int i = 0; i < ptCount; i++)
                {
                    double dist = ((fromPt.easting - bndClosestList[i].easting) * (fromPt.easting - bndClosestList[i].easting))
                                    + ((fromPt.northing - bndClosestList[i].northing) * (fromPt.northing - bndClosestList[i].northing));
                    if (minDistance >= dist)
                    {
                        minDistance = dist;

                        closestBoundaryPt.easting = bndClosestList[i].easting;
                        closestBoundaryPt.northing = bndClosestList[i].northing;
                        closestBoundaryPt.heading = bndClosestList[i].heading;
                        mf.bnd.closestBoundaryNum = bndClosestList[i].index;
                    }
                }
                if (closestBoundaryPt.heading < 0) closestBoundaryPt.heading += glm.twoPI;
            }
        }

        public void DrawBoundaryLines()
        {
            //draw the boundaries
            GL.Color3(0.75f, 0.5f, 0.250f);

            for (int i = 0; i < bndArr.Count; i++)
            {
                bndArr[i].DrawBoundaryLine(mf.ABLine.lineWidth, mf.mc.isOutOfBounds);
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
                if (mf.bnd.isDrawRightSide)
                {
                    GL.Vertex3(bndBeingMadePts[0].easting, bndBeingMadePts[0].northing, 0);

                    GL.Vertex3(pivot.easting + (Math.Sin(pivot.heading - glm.PIBy2) * -mf.bnd.createBndOffset),
                            pivot.northing + (Math.Cos(pivot.heading - glm.PIBy2) * -mf.bnd.createBndOffset), 0);
                    GL.Vertex3(bndBeingMadePts[bndBeingMadePts.Count - 1].easting, bndBeingMadePts[bndBeingMadePts.Count - 1].northing, 0);
                }
                else
                {
                    GL.Vertex3(bndBeingMadePts[0].easting, bndBeingMadePts[0].northing, 0);

                    GL.Vertex3(pivot.easting + (Math.Sin(pivot.heading - glm.PIBy2) * mf.bnd.createBndOffset),
                            pivot.northing + (Math.Cos(pivot.heading - glm.PIBy2) * mf.bnd.createBndOffset), 0);
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

        public void ResetBoundaries()
        {
            bndArr.Clear();
        }

        //draws the derived closest point
        public void DrawClosestPoint()
        {
            GL.PointSize(4.0f);
            GL.Color3(0.919f, 0.932f, 0.070f);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex3(closestBoundaryPt.easting, closestBoundaryPt.northing, 0);
            GL.End();

            GL.LineWidth(1);
            GL.Color3(0.92f, 0.62f, 0.42f);
            GL.Begin(PrimitiveType.LineStrip);
            GL.Vertex3(boxD.easting, boxD.northing, 0);
            GL.Vertex3(boxA.easting, boxA.northing, 0);
            GL.Vertex3(boxB.easting, boxB.northing, 0);
            GL.Vertex3(boxC.easting, boxC.northing, 0);
            GL.End();
        }
    }
}