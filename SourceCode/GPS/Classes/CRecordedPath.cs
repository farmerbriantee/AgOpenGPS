using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgOpenGPS
{
    public class CRecPathPt
    {
        public double speed { get; set; }
        public vec2 v2 { get; set; }
        public double heading { get; set; }

        //constructor
        public CRecPathPt(vec2 _v2, double _heading, double _speed)
        {
            v2 = _v2;
            heading = _heading;
            speed = _speed;
        }
    }

    public class CRecordedPath
    {
        //pointers to mainform controls
        private readonly OpenGL gl;

        private readonly FormGPS mf;
        public bool isRecordingPath;

        public List<CRecPathPt> recList = new List<CRecPathPt>();

        public CRecordedPath(OpenGL _gl,FormGPS _f )
        {
            //constructor
            gl = _gl;
            mf = _f;
        }

        public void DrawLine()
        {
            int ptCount = recList.Count;
            if (ptCount < 1) return;
            gl.LineWidth(1);
            gl.Color(0.98f, 0.2f, 0.60f);
            gl.Begin(OpenGL.GL_LINE_STRIP);
            for (int h = 0; h < ptCount; h++) gl.Vertex(recList[h].v2.easting, recList[h].v2.northing, 0);
            gl.End();

        }

    }
}
