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

        //Z
        public double northingMax = 400;
        public double northingMin = -400;

        //X
        public double eastingMax = 400;
        public double eastingMin = -400;


        public CWorldGrid(OpenGL _gl)
        {
           gl = _gl; 
        }

        public void DrawWorldGrid(double _gridZoom)
        {
            //draw easting lines and westing lines to produce a grid
            gl.Color(0.7f, 0.7f, 0.7f);
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
            northingMax = northing + 3000;
            northingMin = northing - 3000;

            eastingMax = easting + 3000;
            eastingMin = easting - 3000;
 
        }

        public void checkZoomWorldGrid(double northing, double easting)
        {
            //make sure the grid extends far enough away as you move along
            //just keep it growing as you continue to move in a direction - forever.
            if ((northingMax - northing) < 500) northingMax = northing + 2000;
            if ((northing - northingMin) < 500) northingMin = northing - 2000;
            if ((eastingMax - easting) < 500) eastingMax = easting + 2000;
            if ((easting - eastingMin) < 500) eastingMin = easting - 2000;
        }

    }
}
