using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public class CGeoFenceLines
    {
        //list of coordinates of boundary line
        public List<vec2> geoFenceLine = new List<vec2>();

        //the list of constants and multiples of the boundary
        public List<vec2> calcList = new List<vec2>();

        public void ResetGeoFence()
        {
            calcList?.Clear();
            geoFenceLine?.Clear();
        }

        public bool IsPointInGeoFenceArea(vec3 testPointv2)
        {
            if (calcList.Count < 3) return false;
            int j = geoFenceLine.Count - 1;
            bool oddNodes = false;

            //test against the constant and multiples list the test point
            for (int i = 0; i < geoFenceLine.Count; j = i++)
            {
                if ((geoFenceLine[i].northing < testPointv2.northing && geoFenceLine[j].northing >= testPointv2.northing)
                || (geoFenceLine[j].northing < testPointv2.northing && geoFenceLine[i].northing >= testPointv2.northing))
                {
                    oddNodes ^= ((testPointv2.northing * calcList[i].northing) + calcList[i].easting < testPointv2.easting);
                }
            }
            return oddNodes; //true means inside.
        }

        public bool IsPointInGeoFenceArea(vec2 testPointv2)
        {
            if (calcList.Count < 3) return false;
            int j = geoFenceLine.Count - 1;
            bool oddNodes = false;

            //test against the constant and multiples list the test point
            for (int i = 0; i < geoFenceLine.Count; j = i++)
            {
                if ((geoFenceLine[i].northing < testPointv2.northing && geoFenceLine[j].northing >= testPointv2.northing)
                || (geoFenceLine[j].northing < testPointv2.northing && geoFenceLine[i].northing >= testPointv2.northing))
                {
                    oddNodes ^= ((testPointv2.northing * calcList[i].northing) + calcList[i].easting < testPointv2.easting);
                }
            }
            return oddNodes; //true means inside.
        }

        public void DrawGeoFenceLine()
        {
            ////draw the turn line oject
            if (geoFenceLine.Count < 1) return;
            int ptCount = geoFenceLine.Count;
            GL.LineWidth(3);
            GL.Color3(0.96555f, 0.1232f, 0.50f);
            //GL.PointSize(4);
            GL.Begin(PrimitiveType.LineStrip);
            for (int h = 0; h < ptCount; h++) GL.Vertex3(geoFenceLine[h].easting, geoFenceLine[h].northing, 0);
            GL.Vertex3(geoFenceLine[0].easting, geoFenceLine[0].northing, 0);
            GL.End();
        }

        public void FixGeoFenceLine(double totalHeadWidth, List<vec3> curBnd, double spacing)
        {
            //count the points from the boundary
            int lineCount = geoFenceLine.Count;
            double distance = 0;

            //int headCount = mf.bndArr[inTurnNum].bndLine.Count;
            int bndCount = curBnd.Count;

            //remove the points too close to boundary
            for (int i = 0; i < bndCount; i++)
            {
                for (int j = 0; j < lineCount; j++)
                {
                    //make sure distance between headland and boundary is not less then width
                    distance = glm.Distance(curBnd[i], geoFenceLine[j]);
                    if (distance < (totalHeadWidth * 0.96))
                    {
                        geoFenceLine.RemoveAt(j);
                        lineCount = geoFenceLine.Count;
                        j = -1;
                    }
                }
            }

            //make sure distance isn't too small between points on turnLine
            bndCount = geoFenceLine.Count;

            //double spacing = mf.tool.toolWidth * 0.25;
            for (int i = 0; i < bndCount - 1; i++)
            {
                distance = glm.Distance(geoFenceLine[i], geoFenceLine[i + 1]);
                if (distance < spacing)
                {
                    geoFenceLine.RemoveAt(i + 1);
                    bndCount = geoFenceLine.Count;
                    i--;
                }
            }

            //make sure distance isn't too big between points on Turn
            bndCount = geoFenceLine.Count;
            for (int i = 0; i < bndCount; i++)
            {
                int j = i + 1;
                if (j == bndCount) j = 0;
                distance = glm.Distance(geoFenceLine[i], geoFenceLine[j]);
                if (distance > (spacing * 1.25))
                {
                    vec2 pointB = new vec2((geoFenceLine[i].easting + geoFenceLine[j].easting) / 2.0, (geoFenceLine[i].northing + geoFenceLine[j].northing) / 2.0);

                    geoFenceLine.Insert(j, pointB);
                    bndCount = geoFenceLine.Count;
                    i--;
                }
            }

            //make sure headings are correct for calculated points
            //CalculateTurnHeadings();
        }

        public void PreCalcTurnLines()
        {
            int j = geoFenceLine.Count - 1;
            //clear the list, constant is easting, multiple is northing
            calcList.Clear();
            vec2 constantMultiple = new vec2(0, 0);

            for (int i = 0; i < geoFenceLine.Count; j = i++)
            {
                //check for divide by zero
                if (Math.Abs(geoFenceLine[i].northing - geoFenceLine[j].northing) < double.Epsilon)
                {
                    constantMultiple.easting = geoFenceLine[i].easting;
                    constantMultiple.northing = 0;
                    calcList.Add(constantMultiple);
                }
                else
                {
                    //determine constant and multiple and add to list
                    constantMultiple.easting = geoFenceLine[i].easting - ((geoFenceLine[i].northing * geoFenceLine[j].easting)
                                    / (geoFenceLine[j].northing - geoFenceLine[i].northing)) + ((geoFenceLine[i].northing * geoFenceLine[i].easting)
                                        / (geoFenceLine[j].northing - geoFenceLine[i].northing));
                    constantMultiple.northing = (geoFenceLine[j].easting - geoFenceLine[i].easting) / (geoFenceLine[j].northing - geoFenceLine[i].northing);
                    calcList.Add(constantMultiple);
                }
            }
        }
    }
}