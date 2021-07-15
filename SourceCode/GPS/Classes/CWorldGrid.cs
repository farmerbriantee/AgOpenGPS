//Please, if you use this, share the improvements

using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;

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

        public double GridSize = 20000;
        public double Count = 40;

        public CWorldGrid(FormGPS _f)
        {
            mf = _f;
        }

        public void DrawFieldSurface()
        {
            Color field = mf.fieldColorDay;
            if (!mf.isDay) field = mf.fieldColorNight;

            if (mf.isTextureOn)
            {
                //adjust bitmap zoom based on cam zoom
                if (mf.camera.zoomValue > 100) Count = 10;
                else if (mf.camera.zoomValue > 80) Count = 20;
                else if (mf.camera.zoomValue  > 50) Count = 40;
                else if (mf.camera.zoomValue > 20) Count = 80;
                else  Count = 240;

                GL.Enable(EnableCap.Texture2D);
                GL.Color3(field.R, field.G, field.B);
                GL.BindTexture(TextureTarget.Texture2D, mf.texture[1]);
                GL.Begin(PrimitiveType.TriangleStrip);

                GL.TexCoord2(0, 0);
                GL.Vertex3(eastingMin, northingMax, 0.0);
                GL.TexCoord2(Count, 0.0);
                GL.Vertex3(eastingMax, northingMax, 0.0);
                GL.TexCoord2(0.0, Count);
                GL.Vertex3(eastingMin, northingMin, 0.0);
                GL.TexCoord2(Count, Count);
                GL.Vertex3(eastingMax, northingMin, 0.0);

                GL.End();
                GL.Disable(EnableCap.Texture2D);
            }
            else
            {
                GL.Color3(field.R, field.G, field.B);
                GL.Begin(PrimitiveType.TriangleStrip);
                GL.Vertex3(eastingMin, northingMax, 0.0);
                GL.Vertex3(eastingMax, northingMax, 0.0);
                GL.Vertex3(eastingMin, northingMin, 0.0);
                GL.Vertex3(eastingMax, northingMin, 0.0);
                GL.End();
            }
        }

        public void DrawWorldGrid(double _gridZoom)
        {
            _gridZoom *= 0.65;

            if (mf.isDay)
            {
                GL.Color3(0.5, 0.5, 0.5);
            }
            else
            {
                GL.Color3(0.17, 0.17, 0.17);
            }
            GL.LineWidth(1);
            GL.Begin(PrimitiveType.Lines);
            for (double num = Math.Round(eastingMin / _gridZoom, MidpointRounding.AwayFromZero) * _gridZoom; num < eastingMax; num += _gridZoom)
            {
                if (num < eastingMin) continue;

                GL.Vertex3(num, northingMax, 0.1);
                GL.Vertex3(num, northingMin, 0.1);
            }
            for (double num2 = Math.Round(northingMin / _gridZoom, MidpointRounding.AwayFromZero) * _gridZoom; num2 < northingMax; num2 += _gridZoom)
            {
                if (num2 < northingMin) continue;

                GL.Vertex3(eastingMax, num2, 0.1);
                GL.Vertex3(eastingMin, num2, 0.1);
            }
            GL.End();
        }

        public void checkZoomWorldGrid(double northing, double easting)
        {
            double n = Math.Round(northing / (GridSize / Count * 2), MidpointRounding.AwayFromZero) * (GridSize / Count * 2);
            double e = Math.Round(easting / (GridSize / Count * 2), MidpointRounding.AwayFromZero) * (GridSize / Count * 2);

            northingMax = n + GridSize;
            northingMin = n - GridSize;
            eastingMax = e + GridSize;
            eastingMin = e - GridSize;
        }
    }
}