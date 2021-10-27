using OpenTK.Graphics.OpenGL;

namespace AgOpenGPS
{
    public partial class CBoundaryList
    {

        public void DrawHeadLine()
        {
            if (hdLine.Count > 1)
            {
                GL.Begin(PrimitiveType.LineLoop);
                for (int i = 0; i < hdLine.Count; i++)
                {
                    GL.Vertex3(hdLine[i].easting, hdLine[i].northing, 0);
                }
                GL.End();
            }
        }

        public void DrawHeadLineBackBuffer()
        {
            if (hdLine.Count > 1)
            {
                GL.Begin(PrimitiveType.LineLoop);
                for (int i = 0; i < hdLine.Count; i++)
                {
                    GL.Vertex3(hdLine[i].easting, hdLine[i].northing, 0);
                }
                GL.End();
            }
        }
    }
}