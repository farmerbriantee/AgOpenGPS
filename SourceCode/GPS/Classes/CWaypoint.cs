using SharpGL;

namespace AgOpenGPS
{
    public class CWaypoint
    {
        //pointers to mainform controls
        private readonly FormGPS mf;
        private readonly OpenGL gl;

        public CWaypoint(OpenGL _gl, FormGPS _f)
        {
            //constructor
            gl = _gl;
            mf = _f;
        }
    }
}
