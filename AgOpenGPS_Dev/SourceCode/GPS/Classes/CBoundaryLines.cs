using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public class CBndPt
    {
        public double easting { get; set; }
        public double northing { get; set; }
        public double heading { get; set; }

        //constructor
        public CBndPt(double _easting, double _northing, double _heading)
        {
            easting = _easting;
            northing = _northing;
            heading = _heading;
        }
    }

    public class CBoundaryLines
    {
        //constructor
        public CBoundaryLines()
        {
            area = 0;
            isSet = false;
            isOkToAddPoints = false;
            isDriveThru = false;
            isDrawRightSide = true;
        }

        //list of coordinates of boundary line
        public List<CBndPt> bndLine = new List<CBndPt>();

        //the list of constants and multiples of the boundary
        public List<vec2> calcList = new List<vec2>();

        //area variable
        public double area;
        public string areaHectare = "";
        public string areaAcre = "";

        //boundary variables
        public bool isOkToAddPoints, isSet, isDriveThru, isDrawRightSide;

        public void CalculateBoundaryHeadings()
        {
            //to calc heading based on next and previous points to give an average heading.
            int cnt = bndLine.Count;
            CBndPt[] arr = new CBndPt[cnt];
            cnt--;
            bndLine.CopyTo(arr);
            bndLine.Clear();

            //first point needs last, first, second points
            CBndPt pt3 = arr[0];
            pt3.heading = Math.Atan2(arr[1].easting - arr[cnt].easting, arr[1].northing - arr[cnt].northing);
            if (pt3.heading < 0) pt3.heading += glm.twoPI;
            bndLine.Add(pt3);

            //middle points
            for (int i = 1; i < cnt; i++)
            {
                pt3 = arr[i];
                pt3.heading = Math.Atan2(arr[i + 1].easting - arr[i - 1].easting, arr[i + 1].northing - arr[i - 1].northing);
                if (pt3.heading < 0) pt3.heading += glm.twoPI;
                bndLine.Add(pt3);
            }

            //last and first point
            pt3 = arr[cnt];
            pt3.heading = Math.Atan2(arr[0].easting - arr[cnt - 1].easting, arr[0].northing - arr[cnt - 1].northing);
            if (pt3.heading < 0) pt3.heading += glm.twoPI;
            bndLine.Add(pt3);
        }

        public void ResetBoundary()
        {
            calcList.Clear();
            bndLine.Clear();
            area = 0;
            areaAcre = "";
            areaHectare = "";
            isSet = false;
            isOkToAddPoints = false;
            isDriveThru = false;
        }

        public void FixBoundaryLine(int bndNum)
        {
            //count the points from the boundary
            int ptCount = bndLine.Count;

            //first find out which side is inside the boundary
            double oneSide = glm.PIBy2;
            vec3 point = new vec3(bndLine[3].easting - (Math.Sin(oneSide + bndLine[3].heading) * 2.0),
            bndLine[3].northing - (Math.Cos(oneSide + bndLine[3].heading) * 2.0), 0.0);

            //make sure boundaries are wound correctly
            if (bndNum == 0)
            {
                //outside an outer boundary means its wound clockwise
                if (!IsPointInsideBoundary(point)) ReverseWinding();
            }
            else
            {
                //inside an inner boundary means its wound clockwise
                if (IsPointInsideBoundary(point)) ReverseWinding();
            }

            //make sure distance isn't too small between points on headland
            int headCount = bndLine.Count;

            const double spacing = 2;
            double distance;
            for (int i = 0; i < headCount - 1; i++)
            {
                distance = glm.Distance(bndLine[i], bndLine[i + 1]);
                if (distance < spacing)
                {
                    bndLine.RemoveAt(i + 1);
                    headCount = bndLine.Count;
                    i = 0;
                }
            }

            ////make sure distance isn't too big between points on boundary
            //headCount = bndLine.Count;
            //for (int i = 0; i < headCount; i++)
            //{
            //    int j = i + 1;
            //    if (j == headCount) j = 0;
            //    distance = glm.Distance(bndLine[i], bndLine[j]);
            //    if (distance > (spacing * 1.15))
            //    {
            //        CBndPt pointB = new CBndPt((bndLine[i].easting + bndLine[j].easting) / 2.0, (bndLine[i].northing + bndLine[j].northing) / 2.0, bndLine[i].heading);

            //        bndLine.Insert(j, pointB);
            //        headCount = bndLine.Count;
            //        i = 0;
            //    }
            //}

            //make sure headings are correct for calculated points
            CalculateBoundaryHeadings();
        }

        private void ReverseWinding()
        {
            //reverse the boundary
            int cnt = bndLine.Count;
            CBndPt[] arr = new CBndPt[cnt];
            cnt--;
            bndLine.CopyTo(arr);
            bndLine.Clear();
            for (int i = cnt; i >= 0; i--)
            {
                arr[i].heading -= Math.PI;
                if (arr[i].heading < 0) arr[i].heading += glm.twoPI;
                bndLine.Add(arr[i]);
            }
        }

        public void PreCalcBoundaryLines()
        {
            int j = bndLine.Count - 1;
            //clear the list, constant is easting, multiple is northing
            calcList.Clear();
            vec2 constantMultiple = new vec2(0, 0);

            for (int i = 0; i < bndLine.Count; j = i++)
            {
                //check for divide by zero
                if (Math.Abs(bndLine[i].northing - bndLine[j].northing) < 0.00000000001)
                {
                    constantMultiple.easting = bndLine[i].easting;
                    constantMultiple.northing = 0;
                    calcList.Add(constantMultiple);
                }
                else
                {
                    //determine constant and multiple and add to list
                    constantMultiple.easting = bndLine[i].easting - ((bndLine[i].northing * bndLine[j].easting)
                                    / (bndLine[j].northing - bndLine[i].northing)) + ((bndLine[i].northing * bndLine[i].easting)
                                        / (bndLine[j].northing - bndLine[i].northing));
                    constantMultiple.northing = (bndLine[j].easting - bndLine[i].easting) / (bndLine[j].northing - bndLine[i].northing);
                    calcList.Add(constantMultiple);
                }
            }

            areaHectare = Math.Round(area * 0.0001, 3) + " Ha";
            areaAcre = Math.Round(area * 0.000247105, 3) + " Ac";
        }

        public bool IsPointInsideBoundary(vec3 testPointv3)
        {
            if (calcList.Count < 3) return false;
            int j = bndLine.Count - 1;
            bool oddNodes = false;

            //test against the constant and multiples list the test point
            for (int i = 0; i < bndLine.Count; j = i++)
            {
                if ((bndLine[i].northing < testPointv3.northing && bndLine[j].northing >= testPointv3.northing)
                || (bndLine[j].northing < testPointv3.northing && bndLine[i].northing >= testPointv3.northing))
                {
                    oddNodes ^= ((testPointv3.northing * calcList[i].northing) + calcList[i].easting < testPointv3.easting);
                }
            }
            return oddNodes; //true means inside.
        }

        public bool IsPointInsideBoundary(vec2 testPointv2)
        {
            if (calcList.Count < 3) return false;
            int j = bndLine.Count - 1;
            bool oddNodes = false;

            //test against the constant and multiples list the test point
            for (int i = 0; i < bndLine.Count; j = i++)
            {
                if ((bndLine[i].northing < testPointv2.northing && bndLine[j].northing >= testPointv2.northing)
                || (bndLine[j].northing < testPointv2.northing && bndLine[i].northing >= testPointv2.northing))
                {
                    oddNodes ^= ((testPointv2.northing * calcList[i].northing) + calcList[i].easting < testPointv2.easting);
                }
            }
            return oddNodes; //true means inside.
        }

        public void DrawBoundaryLine()
        {
            ////draw the perimeter line so far
            int ptCount = bndLine.Count;
            if (ptCount < 1) return;
            GL.LineWidth(2);
            if (isDriveThru) GL.Color3(0.25f, 0.952f, 0.960f);
            else GL.Color3(0.95f, 0.2f, 0.860f);
            GL.Begin(PrimitiveType.LineStrip);
            for (int h = 0; h < ptCount; h++) GL.Vertex3(bndLine[h].easting, bndLine[h].northing, 0);
            GL.Vertex3(bndLine[0].easting, bndLine[0].northing, 0);
            GL.End();

            //gl.LineWidth(2);
            //gl.Color(0.98f, 0.2f, 0.60f);
            //gl.Begin(OpenGL.GL_LINE_STRIP);
            //gl.End();

            //ptCount = bdList.Count;
            //if (ptCount < 1) return;
            //gl.PointSize(4);
            //gl.Color(0.19f, 0.932f, 0.70f);
            //gl.Begin(OpenGL.GL_POINTS);
            ////gl.Vertex(closestBoundaryPt.easting, closestBoundaryPt.northing, 0);
            //gl.End();
        }

        //draw a blue line in the back buffer for section control over boundary line
        public void DrawBoundaryLineOnBackBuffer()
        {
            ////draw the perimeter line so far
            int ptCount = bndLine.Count;
            if (ptCount < 1) return;
            //glb.LineWidth(4);
            //glb.Color(0.0f, 0.99f, 0.0f);
            //glb.Begin(OpenGL.GL_LINE_STRIP);
            //for (int h = 0; h < ptCount; h++) glb.Vertex(ptList[h].easting, ptList[h].northing, 0);
            //glb.End();

            ////the "close the loop" line
            //glb.LineWidth(4);
            //glb.Color(0.0f, 0.990f, 0.0f);
            //glb.Begin(OpenGL.GL_LINE_STRIP);
            //glb.Vertex(ptList[ptCount - 1].easting, ptList[ptCount - 1].northing, 0);
            //glb.Vertex(ptList[0].easting, ptList[0].northing, 0);
            //glb.End();
        }

        //obvious
        public void CalculateBoundaryArea()
        {
            int ptCount = bndLine.Count;
            if (ptCount < 1) return;

            area = 0;         // Accumulates area in the loop
            int j = ptCount - 1;  // The last vertex is the 'previous' one to the first

            for (int i = 0; i < ptCount; j = i++)
            {
                area += (bndLine[j].easting + bndLine[i].easting) * (bndLine[j].northing - bndLine[i].northing);
            }
            area = Math.Abs(area / 2);
        }
    }
}