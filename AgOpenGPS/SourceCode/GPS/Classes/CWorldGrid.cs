//Please, if you use this, share the improvements

using OpenTK.Graphics.OpenGL;

namespace AgOpenGPS
{
    public class CWorldGrid
    {
        private readonly FormGPS mf;

        //Z
        public double northingMax;

        public double northingMin;

        //X
        public double eastingMax;

        public double eastingMin;

        private double texZoomE = 20, texZoomN = 20;

        public CWorldGrid(FormGPS _f)
        {
            mf = _f;
        }

        public void DrawFieldSurface()
        {
            GL.Enable(EnableCap.Texture2D);
            GL.Color3(mf.redField, mf.grnField, mf.bluField);
            GL.BindTexture(TextureTarget.Texture2D, mf.texture[1]);
            GL.Begin(PrimitiveType.TriangleStrip);
            GL.TexCoord2(0, 0);
            GL.Vertex3(eastingMin, northingMax, 0.0);
            GL.TexCoord2(texZoomE, 0.0);
            GL.Vertex3(eastingMax, northingMax, 0.0);
            GL.TexCoord2(0.0, texZoomN);
            GL.Vertex3(eastingMin, northingMin, 0.0);
            GL.TexCoord2(texZoomE, texZoomN);
            GL.Vertex3(eastingMax, northingMin, 0.0);
            GL.End();
            GL.Disable(EnableCap.Texture2D);
        }

        public void DrawWorldGrid(double _gridZoom)
        {
            GL.Color3(0, 0, 0);
            //GL.LineWidth(1);
            GL.Begin(PrimitiveType.Lines);
            for (double num = eastingMin; num < eastingMax; num += _gridZoom)
            {
                GL.Vertex3(num, northingMax, 0.1);
                GL.Vertex3(num, northingMin, 0.1);
            }
            for (double num2 = northingMin; num2 < northingMax; num2 += _gridZoom)
            {
                GL.Vertex3(eastingMax, num2, 0.1);
                GL.Vertex3(eastingMin, num2, 0.1);
            }
            GL.End();
        }

        public void CreateWorldGrid(double northing, double easting)
        {
            northingMax = northing + 16000.0;
            northingMin = northing - 16000.0;
            eastingMax = easting + 16000.0;
            eastingMin = easting - 16000.0;
        }

        public void checkZoomWorldGrid(double northing, double easting)
        {
            if (northingMax - northing < 1000.0)
            {
                northingMax = northing + 2000.0;
                texZoomN = (double)(int)((northingMax - northingMin) / 500.0);
            }
            if (northing - northingMin < 1000.0)
            {
                northingMin = northing - 2000.0;
                texZoomN = (double)(int)((northingMax - northingMin) / 500.0);
            }
            if (eastingMax - easting < 1000.0)
            {
                eastingMax = easting + 2000.0;
                texZoomE = (double)(int)((eastingMax - eastingMin) / 500.0);
            }
            if (easting - eastingMin < 1000.0)
            {
                eastingMin = easting - 2000.0;
                texZoomE = (double)(int)((eastingMax - eastingMin) / 500.0);
            }
        }
    }
}