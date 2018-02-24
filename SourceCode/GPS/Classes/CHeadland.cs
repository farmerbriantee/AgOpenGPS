using System;
using System.Collections.Generic;
using SharpGL;

namespace AgOpenGPS
{
    public class CHeadland
    {
        //copy of the mainform address
        private readonly FormGPS mf;
        private readonly OpenGL gl;

        public bool isSet;
        public bool isDrawRightSide;
        public bool isOkToAddPoints;

        //closest headland segment from pivotAxle
        public vec3 closestHeadlandPt = new vec3(-1, -1, 0);

        //generated box for finding closest point
        public vec2 boxA = new vec2(0, 0), boxB = new vec2(0, 2);
        public vec2 boxC = new vec2(1, 1), boxD = new vec2(2, 3);

        //list of coordinates of headland line
        public List<vec3> ptList = new List<vec3>();

        //the list of constants and multiples of the headland
        public List<vec2> calcList = new List<vec2>();

        // the list of possible headland points
        public List<vec3> hdList = new List<vec3>();

        //constructor
        public CHeadland(OpenGL _gl, FormGPS _f)
        {
            mf = _f;
            gl = _gl;
            isSet = false;
            isDrawRightSide = true;
            isOkToAddPoints = false;
        }

        public void FindClosestHeadlandPoint(vec3 fromPt)
        {
            //heading is based on ABLine and going same direction as AB or not
            double headAB = mf.ABLine.abHeading;
            if (!mf.ABLine.isABSameAsFixHeading)
                headAB += Math.PI;
            //Draw a bounding box to determine if points are in it

            if (mf.yt.isSequenceTriggered)
            {
                boxA.easting = fromPt.easting + (Math.Sin(headAB + glm.PIBy2) * mf.vehicle.toolFarLeftPosition); //subtract if positive
                boxA.northing = fromPt.northing + (Math.Cos(headAB + glm.PIBy2) * mf.vehicle.toolFarLeftPosition);

                boxB.easting = fromPt.easting + (Math.Sin(headAB + glm.PIBy2) * mf.vehicle.toolFarRightPosition);
                boxB.northing = fromPt.northing + (Math.Cos(headAB + glm.PIBy2) * mf.vehicle.toolFarRightPosition);

                boxC.easting = boxB.easting + (Math.Sin(headAB) * 70.0);
                boxC.northing = boxB.northing + (Math.Cos(headAB) * 70.0);

                boxD.easting = boxA.easting + (Math.Sin(headAB) * 70.0);
                boxD.northing = boxA.northing + (Math.Cos(headAB) * 70.0);

                boxA.easting -= (Math.Sin(headAB) * 50.0);
                boxA.northing -= (Math.Cos(headAB) * 50.0);

                boxB.easting -= (Math.Sin(headAB) * 50.0);
                boxB.northing -= (Math.Cos(headAB) * 50.0);
            }
            else
            {
                boxA.easting = fromPt.easting + (Math.Sin(headAB + glm.PIBy2) * mf.vehicle.toolFarLeftPosition);
                boxA.northing = fromPt.northing + (Math.Cos(headAB + glm.PIBy2) * mf.vehicle.toolFarLeftPosition);

                boxB.easting = fromPt.easting + (Math.Sin(headAB + glm.PIBy2) * mf.vehicle.toolFarRightPosition);
                boxB.northing = fromPt.northing + (Math.Cos(headAB + glm.PIBy2) * mf.vehicle.toolFarRightPosition);

                boxC.easting = boxB.easting + (Math.Sin(headAB) * 2000.0);
                boxC.northing = boxB.northing + (Math.Cos(headAB) * 2000.0);

                boxD.easting = boxA.easting + (Math.Sin(headAB) * 2000.0);
                boxD.northing = boxA.northing + (Math.Cos(headAB) * 2000.0);
            }

            //determine if point is inside bounding box
            hdList.Clear();
            int ptCount = ptList.Count;
            for (int p = 0; p < ptCount; p++)
            {
                if ((((boxB.easting - boxA.easting) * (ptList[p].northing - boxA.northing))
                        - ((boxB.northing - boxA.northing) * (ptList[p].easting - boxA.easting))) < 0) { continue; }

                if ((((boxD.easting - boxC.easting) * (ptList[p].northing - boxC.northing))
                        - ((boxD.northing - boxC.northing) * (ptList[p].easting - boxC.easting))) < 0) { continue; }

                if ((((boxC.easting - boxB.easting) * (ptList[p].northing - boxB.northing))
                        - ((boxC.northing - boxB.northing) * (ptList[p].easting - boxB.easting))) < 0) { continue; }

                if ((((boxA.easting - boxD.easting) * (ptList[p].northing - boxD.northing))
                        - ((boxA.northing - boxD.northing) * (ptList[p].easting - boxD.easting))) < 0) { continue; }

                //it's in the box, so add to list 
                closestHeadlandPt.easting = ptList[p].easting;
                closestHeadlandPt.northing = ptList[p].northing;
                hdList.Add(closestHeadlandPt);
            }

            //which of the points is closest
            closestHeadlandPt.easting = -1; closestHeadlandPt.northing = -1;
            ptCount = hdList.Count;
            if (ptCount == 0)
            {
                return;
            }
            else
            {
                //determine closest point
                double minDistance = 9999999;
                for (int i = 0; i < ptCount; i++)
                {
                    double dist = ((fromPt.easting - hdList[i].easting) * (fromPt.easting - hdList[i].easting))
                                    + ((fromPt.northing - hdList[i].northing) * (fromPt.northing - hdList[i].northing));
                    if (minDistance >= dist)
                    {
                        minDistance = dist;
                        closestHeadlandPt = hdList[i];
                    }
                }
            }
        }

        public void ResetHeadland()
        {
            calcList.Clear();
            ptList.Clear();

            isDrawRightSide = true;
            isSet = false;
            isOkToAddPoints = false;
        }

        public bool IsPointInsideHeadland(vec2 testPoint)
        {
            if (calcList.Count < 10) return false;
            int j = ptList.Count - 1;
            bool oddNodes = false;

            //test against the constant and multiples list the test point
            for (int i = 0; i < ptList.Count; j = i++)
            {
                if ((ptList[i].northing < testPoint.northing && ptList[j].northing >= testPoint.northing)
                || (ptList[j].northing < testPoint.northing && ptList[i].northing >= testPoint.northing))
                {
                    oddNodes ^= ((testPoint.northing * calcList[i].northing) + calcList[i].easting < testPoint.easting);
                }
            }
            return oddNodes; //true means inside.
        }

        public bool IsPointInsideHeadland(vec3 testPoint)
        {
            if (calcList.Count < 10) return false;
            int j = ptList.Count - 1;
            bool oddNodes = false;

            //test against the constant and multiples list the test point
            for (int i = 0; i < ptList.Count; j = i++)
            {
                if ((ptList[i].northing < testPoint.northing && ptList[j].northing >= testPoint.northing)
                || (ptList[j].northing < testPoint.northing && ptList[i].northing >= testPoint.northing))
                {
                    oddNodes ^= ((testPoint.northing * calcList[i].northing) + calcList[i].easting < testPoint.easting);
                }
            }
            return oddNodes; //true means inside.
        }

        public void DrawHeadlandLine()
        {
            ////draw the perimeter line so far
            int ptCount = ptList.Count;
            if (ptCount < 1) return;
            gl.PointSize(4);
            gl.Color(0.9198f, 0.9272f, 0.360f);
            gl.Begin(OpenGL.GL_POINTS);
            for (int h = 0; h < ptCount; h++) gl.Vertex(ptList[h].easting, ptList[h].northing, 0);
            gl.End();

            ////the "close the loop" line
            //gl.LineWidth(2);
            //gl.Color(0.9f, 0.32f, 0.70f);
            //gl.Begin(OpenGL.GL_LINE_STRIP);
            //gl.Vertex(ptList[ptCount - 1].easting, ptList[ptCount - 1].northing, 0);
            //gl.Vertex(ptList[0].easting, ptList[0].northing, 0);
            //gl.End();

            //gl.LineWidth(2);
            //gl.Color(0.98f, 0.2f, 0.60f);
            //gl.Begin(OpenGL.GL_LINE_STRIP);
            //gl.Vertex(boxD.easting, boxD.northing, 0);
            //gl.Vertex(boxA.easting, boxA.northing, 0);
            //gl.Vertex(boxB.easting, boxB.northing, 0);
            //gl.Vertex(boxC.easting, boxC.northing, 0);
            //gl.End();

            gl.Color(0.919f, 0.0932f, 0.070f);
            gl.Begin(OpenGL.GL_POINTS);
            gl.Vertex(closestHeadlandPt.easting, closestHeadlandPt.northing, 0);
            gl.End();
        }

        public void PreCalcHeadlandLines()
        {
            int j = ptList.Count - 1;
            //clear the list, constant is easting, multiple is northing
            calcList.Clear();
            vec2 constantMultiple = new vec2(0, 0);

            for (int i = 0; i < ptList.Count; j = i++)
            {
                //check for divide by zero
                if (Math.Abs(ptList[i].northing - ptList[j].northing) < 0.00000000001)
                {
                    constantMultiple.easting = ptList[i].easting;
                    constantMultiple.northing = 0;
                }
                else
                {
                    //determine constant and multiple and add to list
                    constantMultiple.easting = ptList[i].easting - ((ptList[i].northing * ptList[j].easting)
                                    / (ptList[j].northing - ptList[i].northing)) + ((ptList[i].northing * ptList[i].easting)
                                        / (ptList[j].northing - ptList[i].northing));
                    constantMultiple.northing = (ptList[j].easting - ptList[i].easting) / (ptList[j].northing - ptList[i].northing);
                    calcList.Add(constantMultiple);
                }
            }
        }

        public double CalculateHeadlandArea()
        {
            int ptCount = ptList.Count;
            if (ptCount < 1) return 0.0;

            double area = 0;         // Accumulates area in the loop
            int j = ptCount - 1;  // The last vertex is the 'previous' one to the first

            for (int i = 0; i < ptCount; j = i++)
            {
                area += (ptList[j].easting + ptList[i].easting) * (ptList[j].northing - ptList[i].northing);
            }
            return Math.Abs(area / 2);
        }
    }// end of CHeadland
}
