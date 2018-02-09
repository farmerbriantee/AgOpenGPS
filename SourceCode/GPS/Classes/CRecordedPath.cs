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
        public double easting { get; set; }
        public double northing { get; set; }
        public double heading { get; set; }

        //constructor
        public CRecPathPt(double _easting, double _northing, double _heading, double _speed)
        {
            easting = _easting;
            northing = _northing;
            heading = _heading;
            speed = _speed;
        }
    }

    public class CRecordedPath
    {
        //pointers to mainform controls
        private readonly FormGPS mf;
        private readonly OpenGL gl;

        public CRecordedPath(OpenGL _gl, FormGPS _f)
        {
            //constructor
            gl = _gl;
            mf = _f;
        }

    }
}
