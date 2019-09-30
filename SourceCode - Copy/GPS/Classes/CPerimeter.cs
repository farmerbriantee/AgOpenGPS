using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public class CPerimeter
    {
        //copy of the mainform address
        //private FormGPS mf;

        //list of coordinates of perimter line
        public List<vec2> periPtList = new List<vec2>();

        public List<vec2> calcList = new List<vec2>();

        //list of the list of patch data individual triangles for that entire section activity
        public List<List<vec2>> periLineList = new List<List<vec2>>();

        //button status
        public bool isBtnPerimeterOn = false;

        //area variable
        public double area = 0;

        public void DrawPerimeterLine()
        {
            ////draw the perimeter line so far
            int ptCount = periPtList.Count;
            if (ptCount < 1) return;
            GL.LineWidth(2);
            GL.Color3(0.2f, 0.98f, 0.0f);
            GL.Begin(PrimitiveType.LineStrip);
            for (int h = 0; h < ptCount; h++) GL.Vertex3(periPtList[h].easting, periPtList[h].northing, 0);
            GL.End();

            //the "close the loop" line
            GL.LineWidth(1);
            GL.Color3(0.98f, 0.8f, 0.0f);
            GL.Begin(PrimitiveType.LineStrip);
            GL.Vertex3(periPtList[ptCount - 1].easting, periPtList[ptCount - 1].northing, 0);
            GL.Vertex3(periPtList[0].easting, periPtList[0].northing, 0);
            GL.End();

            area = 0;         // Accumulates area in the loop

            int j = ptCount - 1;  // The last vertex is the 'previous' one to the first

            for (int i = 0; i < ptCount; j = i++)
            {
                area += (periPtList[j].easting + periPtList[i].easting) * (periPtList[j].northing - periPtList[i].northing);
            }

            area = System.Math.Abs(area / 2);
        }
    }
}