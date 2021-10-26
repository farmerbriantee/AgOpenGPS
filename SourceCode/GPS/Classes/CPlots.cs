using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public partial class CPlots
    {
        //list of coordinates of boundary line
        public List<vec3> bndLine = new List<vec3>(128);
        public List<vec2> bndLineEar = new List<vec2>(128);
        public List<vec3> hdLine = new List<vec3>(128);
        public List<vec3> turnLine = new List<vec3>(128);

        //area variable
        public double area;

        //boundary variables
        public bool isDriveAround, isDriveThru;

        //constructor
        public CPlots()
        {
            area = 0;
            isDriveAround = false;
            isDriveThru = false;
        }

    }
}