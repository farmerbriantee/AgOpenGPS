//Please, if you use this, share the improvements

using SharpGL;

namespace AgOpenGPS
{
    public class CWorldGrid
    {
        private readonly OpenGL gl;
        private readonly FormGPS mf;

        //Z
        public double northingMax;
        public double northingMin;

        //X
        public double eastingMax;
        public double eastingMin;

        private double texZoomE = 4, texZoomN = 4;

        public CWorldGrid(OpenGL _gl, FormGPS _f)
        {
           gl = _gl;
           mf = _f;
        }

        public void DrawFieldSurface()
        {
            //Enable Texture Mapping and set color to white
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            gl.Color(mf.redField, mf.grnField, mf.bluField);

            //the floor
            gl.BindTexture(OpenGL.GL_TEXTURE_2D, mf.texture[1]);	// Select Our Texture
            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);				            // Build Quad From A Triangle Strip
            gl.TexCoord(0, 0); gl.Vertex(eastingMin, northingMax, 0.0);                // Top Left
            gl.TexCoord(texZoomE, 0); gl.Vertex(eastingMax, northingMax, 0.0);               // Top Right
            gl.TexCoord(0, texZoomN); gl.Vertex(eastingMin, northingMin, 0.0);               // Bottom Left
            gl.TexCoord(texZoomE, texZoomN); gl.Vertex(eastingMax, northingMin, 0.0);              // Bottom Right
            gl.End();						// Done Building Triangle Strip
            gl.Disable(OpenGL.GL_TEXTURE_2D);
        }

            //draw easting lines and westing lines to produce a grid
        public void DrawWorldGrid(double _gridZoom)
        {
            //gl.Color(mf.redField, mf.grnField, mf.bluField);
            gl.Color(0, 0, 0);
            gl.Begin(OpenGL.GL_LINES);
            for (double x = eastingMin; x < eastingMax; x += _gridZoom)
            {
                //the x lines
                gl.Vertex(x, northingMax, 0.1 );
                gl.Vertex(x, northingMin, 0.1);
            }

            for (double x = northingMin; x < northingMax; x += _gridZoom)
            {
                //the z lines
                gl.Vertex(eastingMax, x, 0.1 );
                gl.Vertex(eastingMin, x, 0.1 );
            }
            gl.End();
        }

        public void CreateWorldGrid(double northing, double easting)
        {
            //draw a grid 4 km each direction away from initial fix
            northingMax = northing + 2000;
            northingMin = northing - 2000;

            eastingMax = easting + 2000;
            eastingMin = easting - 2000;
        }

        public void checkZoomWorldGrid(double northing, double easting)
        {
            //make sure the grid extends far enough away as you move along
            //just keep it growing as you continue to move in a direction - forever.
            if ((northingMax - northing) < 1000)
            {
                northingMax = northing + 2000;
                texZoomN = (int)((northingMax - northingMin) / 500);
            }
            if ((northing - northingMin) < 1000)
            {
                northingMin = northing - 2000;
                texZoomN = (int)((northingMax - northingMin) / 500);
            }
            if ((eastingMax - easting) < 1000)
            {
                eastingMax = easting + 2000;
                texZoomE = (int)((eastingMax - eastingMin) / 500);
            }
            if ((easting - eastingMin) < 1000)
            {
                eastingMin = easting - 2000;
                texZoomE = (int)((eastingMax - eastingMin) / 500);
            }
        }
    }
}
