using OpenTK.Graphics.OpenGL;

namespace AgOpenGPS
{
    public partial class CPlots
    {
        public bool IsPointInHeadArea(vec2 testPoint)
        {
            bool result = false;
            int j = hdLine.Count - 1;
            for (int i = 0; i < hdLine.Count; i++)
            {
                if ((hdLine[i].easting < testPoint.easting && hdLine[j].easting >= testPoint.easting) || (hdLine[j].easting < testPoint.easting && hdLine[i].easting >= testPoint.easting))
                {
                    if (hdLine[i].northing + (testPoint.easting - hdLine[i].easting) / (hdLine[j].easting - hdLine[i].easting) * (hdLine[j].northing - hdLine[i].northing) < testPoint.northing)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }

        public bool IsPointInHeadArea(vec3 testPoint)
        {
            bool result = false;
            int j = hdLine.Count - 1;
            for (int i = 0; i < hdLine.Count; i++)
            {
                if ((hdLine[i].easting < testPoint.easting && hdLine[j].easting >= testPoint.easting) || (hdLine[j].easting < testPoint.easting && hdLine[i].easting >= testPoint.easting))
                {
                    if (hdLine[i].northing + (testPoint.easting - hdLine[i].easting) / (hdLine[j].easting - hdLine[i].easting) * (hdLine[j].northing - hdLine[i].northing) < testPoint.northing)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }

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