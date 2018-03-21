using SharpGL;
using System;
using System.Collections.Generic;

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
        public double includeAngle;

        private double oneSide, distance;

        //closest headland segment from pivotAxle
        public vec3 closestHeadlandPt = new vec3(-10000, -10000, 0);

        //generated box for finding closest point
        public vec2 boxA = new vec2(9999, 0), boxB = new vec2(9990, 2);

        public vec2 boxC = new vec2(9991, 1), boxD = new vec2(9992, 3);

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
            includeAngle = glm.PIBy2 / 2.0;
        }

        public void FindClosestHeadlandPoint(vec3 fromPt, double headAB)
        {
            //heading is based on ABLine, average Curve, and going same direction as AB or not
            //Draw a bounding box to determine if points are in it

            if (mf.yt.isSequenceTriggered)
            {
                boxA.easting = fromPt.easting + (Math.Sin(headAB + glm.PIBy2) * mf.vehicle.toolFarLeftPosition); //subtract if positive
                boxA.northing = fromPt.northing + (Math.Cos(headAB + glm.PIBy2) * mf.vehicle.toolFarLeftPosition);

                boxB.easting = fromPt.easting + (Math.Sin(headAB + glm.PIBy2) * mf.vehicle.toolFarRightPosition);
                boxB.northing = fromPt.northing + (Math.Cos(headAB + glm.PIBy2) * mf.vehicle.toolFarRightPosition);

                boxC.easting = boxB.easting + (Math.Sin(headAB) * 60.0);
                boxC.northing = boxB.northing + (Math.Cos(headAB) * 60.0);

                boxD.easting = boxA.easting + (Math.Sin(headAB) * 60.0);
                boxD.northing = boxA.northing + (Math.Cos(headAB) * 60.0);

                boxA.easting -= (Math.Sin(headAB) * 60.0);
                boxA.northing -= (Math.Cos(headAB) * 60.0);

                boxB.easting -= (Math.Sin(headAB) * 60.0);
                boxB.northing -= (Math.Cos(headAB) * 60.0);
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

        private vec3 point;

        public void BuildHeadland(double widthSet)
        {
            //count the points from the boundary
            int ptCount = mf.boundz.ptList.Count;

            //first find out which side is inside the boundary
            oneSide = glm.PIBy2;
            point.easting = mf.boundz.ptList[3].easting - (Math.Sin(oneSide + mf.boundz.ptList[3].heading) * 2.0);
            point.northing = mf.boundz.ptList[3].northing - (Math.Cos(oneSide + mf.boundz.ptList[3].heading) * 2.0);

            if (!mf.boundz.IsPointInsideBoundary(point)) oneSide *= -1.0;

            //clear the headland point list
            mf.hl.ptList.Clear();

            //determine how wide a headland space
            double totalHeadWidth = mf.vehicle.toolWidth * widthSet;

            for (int i = 0; i < ptCount; i++)
            {
                //calculate the point inside the boundary
                point.easting = mf.boundz.ptList[i].easting - (Math.Sin(oneSide + mf.boundz.ptList[i].heading) * totalHeadWidth);
                point.northing = mf.boundz.ptList[i].northing - (Math.Cos(oneSide + mf.boundz.ptList[i].heading) * totalHeadWidth);
                point.heading = mf.boundz.ptList[i].heading;

                //only add if inside actual field boundary
                if (mf.boundz.IsPointInsideBoundary(point)) mf.hl.ptList.Add(point);
            }

            int headCount = mf.hl.ptList.Count;

            //remove the points too close to boundary
            for (int i = 0; i < ptCount; i++)
            {
                for (int j = 0; j < headCount; j++)
                {
                    //make sure distance between headland and boundary is not less then width
                    distance = glm.Distance(mf.boundz.ptList[i], mf.hl.ptList[j]);
                    if (distance < (totalHeadWidth * 0.98))
                    {
                        mf.hl.ptList.RemoveAt(j);
                        headCount = mf.hl.ptList.Count;
                        j = 0;
                    }
                }
            }

            //fix the gaps and overlaps
            FixHeadlandList();

            //pre calculate all the constants and multiples
            mf.hl.PreCalcHeadlandLines();
        }

        public void FixHeadlandList()
        {
            //make sure distance isn't too small between points on headland
            int headCount = mf.hl.ptList.Count;
            double spacing = mf.vehicle.toolWidth * 0.25;
            double distance;
            for (int i = 0; i < headCount - 1; i++)
            {
                distance = glm.Distance(mf.hl.ptList[i], mf.hl.ptList[i + 1]);
                if (distance < spacing)
                {
                    mf.hl.ptList.RemoveAt(i + 1);
                    headCount = mf.hl.ptList.Count;
                    i = 0;
                }
            }

            //make sure distance isn't too big between points on headland
            vec3 point;
            headCount = mf.hl.ptList.Count;
            for (int i = 0; i < headCount; i++)
            {
                int j = i + 1;
                if (j == headCount) j = 0;
                distance = glm.Distance(mf.hl.ptList[i], mf.hl.ptList[j]);
                if (distance > (spacing))
                {
                    point.easting = (mf.hl.ptList[i].easting + mf.hl.ptList[j].easting) / 2.0;
                    point.northing = (mf.hl.ptList[i].northing + mf.hl.ptList[j].northing) / 2.0;
                    point.heading = mf.hl.ptList[i].heading;

                    mf.hl.ptList.Insert(j, point);
                    headCount = mf.hl.ptList.Count;
                    i = 0;
                }
            }

            //make sure headings are correct for calculated points
            mf.hl.CalculateHeadings();

            //must be perpendicularish to the guidance line to be a headland point
            headCount = mf.hl.ptList.Count;
            double ref2;
            if (mf.ABLine.isABLineSet)
            {
                for (int i = 0; i < headCount; i++)
                {
                    ref2 = Math.PI - Math.Abs(Math.Abs(mf.ABLine.abHeading - mf.hl.ptList[i].heading) - Math.PI);
                    if (ref2 < (glm.PIBy2 - mf.hl.includeAngle) || (ref2 > glm.PIBy2 + mf.hl.includeAngle))
                    {
                        mf.hl.ptList.RemoveAt(i);
                        headCount = mf.hl.ptList.Count;
                        i = 0;
                    }
                }
            }
            else
            {
                for (int i = 0; i < headCount; i++)
                {
                    ref2 = Math.PI - Math.Abs(Math.Abs(mf.curve.aveLineHeading - mf.hl.ptList[i].heading) - Math.PI);
                    if (ref2 < (glm.PIBy2 - mf.hl.includeAngle) || (ref2 > glm.PIBy2 + mf.hl.includeAngle))
                    {
                        mf.hl.ptList.RemoveAt(i);
                        headCount = mf.hl.ptList.Count;
                        i = 0;
                    }
                }
            }

            //line is built
            mf.hl.isSet = true;
        }

        public void CalculateHeadings()
        {
            //to calc heading based on next and previous points to give an average heading.
            int cnt = ptList.Count;
            if (cnt == 0) return;
            vec3[] arr = new vec3[cnt];
            cnt--;
            ptList.CopyTo(arr);
            ptList.Clear();

            //first point needs last, first, second points
            vec3 pt3 = arr[0];
            pt3.heading = Math.Atan2(arr[1].easting - arr[cnt].easting, arr[1].northing - arr[cnt].northing);
            ptList.Add(pt3);
            for (int i = 1; i < cnt; i++)
            {
                pt3 = arr[i];
                pt3.heading = Math.Atan2(arr[i + 1].easting - arr[i - 1].easting, arr[i + 1].northing - arr[i - 1].northing);
                ptList.Add(pt3);
            }
            pt3 = arr[cnt];
            pt3.heading = Math.Atan2(arr[0].easting - arr[cnt - 1].easting, arr[0].northing - arr[cnt - 1].northing);
            ptList.Add(pt3);
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
            gl.Color(0.8629198f, 0.969272f, 0.5360f);
            gl.Begin(OpenGL.GL_POINTS);
            for (int h = 1; h < ptCount; h++) gl.Vertex(ptList[h].easting, ptList[h].northing, 0);
            gl.End();

            //gl.LineWidth(2);
            //gl.Color(0.4f, 0.60f, 0.60f);
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