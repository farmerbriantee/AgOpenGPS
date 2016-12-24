//Please, if you use this, share the improvements

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpGL;

namespace AgOpenGPS
{
    public class CWorldGrid
    {
        OpenGL gl;
        private FormGPS mf;

        //Z
        public double northingMax = 40;
        public double northingMin = -40;

        //X
        public double eastingMax = 40;
        public double eastingMin = -40;


        public CWorldGrid(OpenGL _gl, FormGPS f)
        {
           gl = _gl;
           this.mf = f;
        }

        public void DrawWorldGrid(double _gridZoom)
        {
            //draw easting lines and westing lines to produce a grid
  
            // Enable Texture Mapping and set color to white
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            gl.Color(0.954, 0.954, 0.954);

            double texZoom = 200/mf.zoomValue;
            //the floor
            gl.BindTexture(OpenGL.GL_TEXTURE_2D, mf.texture[2]);	// Select Our Texture
            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);				            // Build Quad From A Triangle Strip
            gl.TexCoord(0, 0); gl.Vertex(eastingMax, 0.0, northingMax);                // Top Right
            gl.TexCoord(texZoom, 0); gl.Vertex(eastingMin, 0.0, northingMax);               // Top Left
            gl.TexCoord(0, texZoom); gl.Vertex(eastingMax, 0.0, northingMin);               // Bottom Right
            gl.TexCoord(texZoom, texZoom); gl.Vertex(eastingMin, 0.0, northingMin);              // Bottom Left
            gl.End();						// Done Building Triangle Strip
            gl.Disable(OpenGL.GL_TEXTURE_2D);

            gl.Color(0.25f, 0.4f, 0.25f);
            gl.Begin(OpenGL.GL_LINES);
            for (double x = eastingMin; x < eastingMax; x += _gridZoom)
            {
                //the x lines
                gl.Vertex(x, 0.1, northingMax);
                gl.Vertex(x, 0.1, northingMin);
            }

            for (double x = northingMin; x < northingMax; x += _gridZoom)
            {
                //the z lines
                gl.Vertex(eastingMax, 0.1, x);
                gl.Vertex(eastingMin, 0.1, x);
            }

            gl.End();


        }

        public void CreateWorldGrid(double northing, double easting)
        {
            //draw a grid 5 km each direction away from initial fix
            northingMax = northing + 6000;
            northingMin = northing - 6000;

            eastingMax = easting + 6000;
            eastingMin = easting - 6000;
 
        }

        public void checkZoomWorldGrid(double northing, double easting)
        {
            //make sure the grid extends far enough away as you move along
            //just keep it growing as you continue to move in a direction - forever.
            if ((northingMax - northing) < 1500) northingMax = northing + 2000;
            if ((northing - northingMin) < 1500) northingMin = northing - 2000;
            if ((eastingMax - easting) < 1500) eastingMax = easting + 2000;
            if ((easting - eastingMin) < 1500) eastingMin = easting - 2000;
        }

    }
}
