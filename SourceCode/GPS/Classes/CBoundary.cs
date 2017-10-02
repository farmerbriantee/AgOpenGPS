using System;
using System.Collections.Generic;
using SharpGL;

namespace AgOpenGPS
{
    public class CBoundary
    {
        //copy of the mainform address
        private readonly FormGPS mf;
        private readonly OpenGL gl;
        private readonly OpenGL glb;

        //constructor
        public CBoundary(OpenGL _gl, OpenGL _glb, FormGPS _f)
        {
            mf = _f;
            gl = _gl;
            glb = _glb;

            area = 0;
            isSet = false;
            isDrawRightSide = true;
            isOkToAddPoints = false;
        }

        //list of coordinates of boundary line
        public List<vec2> ptList = new List<vec2>();

        //the list of constants and multiples of the boundary
        public List<vec2> calcList = new List<vec2>();

        //list of the list of patch data individual triangles for that entire section activity
        //public List<List<vec2>> boundaryLineList = new List<List<vec2>>();

        //area variable
        public double area;
        public string areaHectare = "";
        public string areaAcre = "";

        //boundary variables
        public bool isOkToAddPoints;
        public bool isSet;
        public bool isDrawRightSide;

        public void ResetBoundary()
        {
            calcList.Clear();
            ptList.Clear();
            area = 0;
            areaAcre = "";
            areaHectare = "";

            isDrawRightSide = true;
            isSet = false;
            isOkToAddPoints = false;
        }

        public void PreCalcBoundaryLines()
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
                    constantMultiple.easting = ptList[i].easting - (ptList[i].northing * ptList[j].easting) /
                                    (ptList[j].northing - ptList[i].northing) + (ptList[i].northing * ptList[i].easting) /
                                        (ptList[j].northing - ptList[i].northing);
                    constantMultiple.northing = (ptList[j].easting - ptList[i].easting) / (ptList[j].northing - ptList[i].northing);
                    calcList.Add(constantMultiple);
                }
            }

            areaHectare = Math.Round((mf.boundary.area * 0.0001), 1) + " Ha";
            areaAcre = Math.Round(mf.boundary.area * 0.000247105, 1) + " Ac";
        }

        public bool IsPrePointInPolygon(vec2 testPoint)
        {
            if (calcList.Count < 10) return false;
            int j = ptList.Count - 1;
            bool oddNodes = false;
            //vec2 testPoint = new vec2(mf.toolPos.easting, mf.toolPos.northing);

            //test against the constant and multiples list the test point
            for (int i = 0; i < ptList.Count; j = i++)
            {
                if ((ptList[i].northing < testPoint.northing && ptList[j].northing >= testPoint.northing
                || ptList[j].northing < testPoint.northing && ptList[i].northing >= testPoint.northing))
                {
                    oddNodes ^= (testPoint.northing * calcList[i].northing + calcList[i].easting < testPoint.easting);
                }
            }
            return oddNodes; //true means inside.
        }

        public void DrawBoundaryLine()
        {
            ////draw the perimeter line so far
            int ptCount = ptList.Count;
            if (ptCount < 1) return;
            gl.LineWidth(4);
            gl.Color(0.98f, 0.2f, 0.60f);
            gl.Begin(OpenGL.GL_LINE_STRIP);
            for (int h = 0; h < ptCount; h++) gl.Vertex(ptList[h].easting, ptList[h].northing, 0);
            gl.End();

            //the "close the loop" line
            gl.LineWidth(4);
            gl.Color(0.9f, 0.32f, 0.70f);
            gl.Begin(OpenGL.GL_LINE_STRIP);
            gl.Vertex(ptList[ptCount - 1].easting, ptList[ptCount - 1].northing, 0);
            gl.Vertex(ptList[0].easting, ptList[0].northing, 0);
            gl.End();
        }

        //draw a blue line in the back buffer for section control over boundary line
        public void DrawBoundaryLineOnBackBuffer()
        {
            ////draw the perimeter line so far
            int ptCount = ptList.Count;
            if (ptCount < 1) return;
            glb.LineWidth(4);
            glb.Color(0.0f, 0.99f, 0.0f);
            glb.Begin(OpenGL.GL_LINE_STRIP);
            for (int h = 0; h < ptCount; h++) glb.Vertex(ptList[h].easting, ptList[h].northing, 0);
            glb.End();

            //the "close the loop" line
            glb.LineWidth(4);
            glb.Color(0.0f, 0.990f, 0.0f);
            glb.Begin(OpenGL.GL_LINE_STRIP);
            glb.Vertex(ptList[ptCount - 1].easting, ptList[ptCount - 1].northing, 0);
            glb.Vertex(ptList[0].easting, ptList[0].northing, 0);
            glb.End();
        }

        public void CalculateBoundaryArea()
        {
            int ptCount = ptList.Count;
            if (ptCount < 1) return;

            area = 0;         // Accumulates area in the loop
            int j = ptCount - 1;  // The last vertex is the 'previous' one to the first

            for (int i = 0; i < ptCount; j = i++)
            {
                area = area + (ptList[j].easting + ptList[i].easting) * (ptList[j].northing - ptList[i].northing);
            }
            area = Math.Abs(area / 2);
        }

        //the non precalculated version
        public bool IsPointInPolygon()
        {
            bool result = false;
            int j = ptList.Count - 1;
            vec2 testPoint = new vec2(mf.pn.easting, mf.pn.northing);

            if (j < 10) return true;

            for (int i = 0; i < ptList.Count; j = i++)
            {
                result ^= ptList[i].northing > testPoint.northing ^ ptList[j].northing > testPoint.northing &&
                    testPoint.easting < (ptList[j].easting - ptList[i].easting) *
                    (testPoint.northing - ptList[i].northing) / (ptList[j].northing - ptList[i].northing) + ptList[i].easting;
            }
            return result;
        }
    }
}
