using System.Collections.Generic;
using SharpGL;

namespace AgOpenGPS
{
    public class CPerimeter
    {
        //copy of the mainform address
        private FormGPS mf;
        private OpenGL gl;

        //list of coordinates of perimter line
        public List<vec2> periList = new List<vec2>();

        //button status
        public bool isBtnPerimeterOn = false;

        //area variable
        public double area = 0, areaTotal = 0;

       //constructor
        public CPerimeter(OpenGL gl, FormGPS f)
        {            
            this.mf = f;
            this.gl = gl;
        }

        public void DrawPerimeterLine()
        {
            ////draw the perimeter line so far
            int ptCount = periList.Count;
            if (ptCount < 1) return;
            gl.LineWidth(2);
            gl.Color(0.2f, 1.0f, 0.0f);
            gl.Begin(OpenGL.GL_LINE_STRIP);
            for (int h = 0; h < ptCount; h++) gl.Vertex(periList[h].x, 0, periList[h].z);
            gl.End();

            //the "close the loop" line
            gl.LineWidth(1);
            gl.Color(1.0f, 0.8f, 0.0f);
            gl.Begin(OpenGL.GL_LINE_STRIP);
            gl.Vertex(periList[ptCount-1].x, 0, periList[ptCount-1].z);
            gl.Vertex(periList[0].x, 0, periList[0].z);
            gl.End();
            
             
            area = 0;         // Accumulates area in the loop

            int j = ptCount-1;  // The last vertex is the 'previous' one to the first

            for (int i=0; i<ptCount; i++)
            {
                area = area + (periList[j].x + periList[i].x) * (periList[j].z - periList[i].z); 
                j = i;  //j is previous vertex to i
            }
     
            area = System.Math.Abs(area/2);

        }

    }
}
