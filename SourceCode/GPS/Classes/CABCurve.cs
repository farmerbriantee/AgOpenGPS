using SharpGL;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public class CCurvePt
    {
        public double altitude { get; set; }
        public double easting { get; set; }
        public double northing { get; set; }
        public double heading { get; set; }

        //constructor
        public CCurvePt(double _easting, double _heading, double _northing)
        {
            easting = _easting;
            northing = _northing;
            heading = _heading;
        }
    }

    public class CABCurve
    {
        //pointers to mainform controls
        private readonly FormGPS mf;
        private readonly OpenGL gl;

        //flag for starting stop adding points
        public bool isOkToAddPoints, isCurveSet;

        //the list of points of the ref line. 
        public List<CCurvePt> refList = new List<CCurvePt>();

        //the list of points of curve to drive on
        public List<CCurvePt> curList = new List<CCurvePt>();



        public CABCurve(OpenGL _gl, FormGPS _f)
        {
            //constructor
            gl = _gl;
            mf = _f;
        }
    }
}