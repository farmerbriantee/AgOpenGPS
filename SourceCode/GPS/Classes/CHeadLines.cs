using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public class CHeadLines
    {
        //list of coordinates of boundary line
        public List<vec3> hdLine = new List<vec3>();

        //the list of constants and multiples of the boundary
        public List<vec2> calcList = new List<vec2>();

        public void ResetHead()
        {
            calcList?.Clear();
            hdLine?.Clear();
            hdLine.Capacity = 128;
            calcList.Capacity = 128;
        }

        public bool IsPointInHeadArea(vec3 testPointv2)
        {
            if (calcList.Count < 3) return false;
            int j = hdLine.Count - 1;
            bool oddNodes = false;

            //test against the constant and multiples list the test point
            for (int i = 0; i < hdLine.Count; j = i++)
            {
                if ((hdLine[i].northing < testPointv2.northing && hdLine[j].northing >= testPointv2.northing)
                || (hdLine[j].northing < testPointv2.northing && hdLine[i].northing >= testPointv2.northing))
                {
                    oddNodes ^= ((testPointv2.northing * calcList[i].northing) + calcList[i].easting < testPointv2.easting);
                }
            }
            return oddNodes; //true means inside.
        }

        public bool IsPointInHeadArea(vec2 testPointv2)
        {
            if (calcList.Count < 3) return false;
            int j = hdLine.Count - 1;
            bool oddNodes = false;

            //test against the constant and multiples list the test point
            for (int i = 0; i < hdLine.Count; j = i++)
            {
                if ((hdLine[i].northing < testPointv2.northing && hdLine[j].northing >= testPointv2.northing)
                || (hdLine[j].northing < testPointv2.northing && hdLine[i].northing >= testPointv2.northing))
                {
                    oddNodes ^= ((testPointv2.northing * calcList[i].northing) + calcList[i].easting < testPointv2.easting);
                }
            }
            return oddNodes; //true means inside.
        }

        public void DrawHeadLine(int linewidth)
        {
            ////draw the turn line oject
            //if (hdLine.Count < 1) return;
            //int ptCount = hdLine.Count;
            //GL.LineWidth(linewidth);
            //GL.Color3(0.732f, 0.7932f, 0.30f);
            //GL.Begin(PrimitiveType.LineStrip);
            //for (int h = 0; h < ptCount; h++) GL.Vertex3(hdLine[h].easting, hdLine[h].northing, 0);
            //GL.Vertex3(hdLine[0].easting, hdLine[0].northing, 0);
            //GL.End();

            if (hdLine.Count < 2) return;
            int ptCount = hdLine.Count;
            if (ptCount > 1)
            {
                GL.LineWidth(linewidth);
                GL.Color3(0.960f, 0.96232f, 0.30f);
                //GL.PointSize(2);

                GL.Begin(PrimitiveType.LineLoop);
                for (int i = 0; i < ptCount; i++)
                {
                    GL.Vertex3(hdLine[i].easting, hdLine[i].northing, 0);
                }
                GL.End();
            }
        }

        public void DrawHeadLineBackBuffer()
        {
            if (hdLine.Count < 2) return;
            int ptCount = hdLine.Count;
            if (ptCount > 1)
            {
                GL.LineWidth(3);
                GL.Color3((byte)0, (byte)250, (byte)0);

                GL.Begin(PrimitiveType.LineLoop);
                for (int i = 0; i < ptCount; i++)
                {
                    GL.Vertex3(hdLine[i].easting, hdLine[i].northing, 0);
                }
                GL.End();
            }
        }

        public void PreCalcHeadLines()
        {
            int j = hdLine.Count - 1;
            //clear the list, constant is easting, multiple is northing
            calcList.Clear();
            vec2 constantMultiple = new vec2(0, 0);

            for (int i = 0; i < hdLine.Count; j = i++)
            {
                //check for divide by zero
                if (Math.Abs(hdLine[i].northing - hdLine[j].northing) < double.Epsilon)
                {
                    constantMultiple.easting = hdLine[i].easting;
                    constantMultiple.northing = 0;
                    calcList.Add(constantMultiple);
                }
                else
                {
                    //determine constant and multiple and add to list
                    constantMultiple.easting = hdLine[i].easting - ((hdLine[i].northing * hdLine[j].easting)
                                    / (hdLine[j].northing - hdLine[i].northing)) + ((hdLine[i].northing * hdLine[i].easting)
                                        / (hdLine[j].northing - hdLine[i].northing));
                    constantMultiple.northing = (hdLine[j].easting - hdLine[i].easting) / (hdLine[j].northing - hdLine[i].northing);
                    calcList.Add(constantMultiple);
                }
            }
        }
    }
}