using SharpGL;
using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public class CRecPathPt
    {
        public double easting { get; set; }
        public double northing { get; set; }
        public double heading { get; set; }
        public double speed { get; set; }
        public bool autoBtnState { get; set; }

        //constructor
        public CRecPathPt(double _easting, double _northing, double _heading, double _speed,
                            bool _autoBtnState)
        {
            easting = _easting;
            northing = _northing;
            heading = _heading;
            speed = _speed;
            autoBtnState = _autoBtnState;
        }
    }

    public class CRecordedPath
    {
        //pointers to mainform controls
        private readonly OpenGL gl;

        private readonly FormGPS mf;

        public int lastPointFound = -1, currentPositonIndex;

        //generated reference line
        public vec2 refPoint1 = new vec2(1, 1), refPoint2 = new vec2(2, 2);

        public double distanceFromRefLine, distanceFromCurrentLine, refLineSide = 1.0;
        public double abFixHeadingDelta, segmentHeading;
        public bool isABSameAsFixHeading = true, isOnRightSideCurrentLine = true;

        //pure pursuit values
        public vec3 pivotAxlePosRP = new vec3(0, 0, 0);

        public vec2 goalPointRP = new vec2(0, 0);
        public vec2 radiusPointRP = new vec2(0, 0);
        public double steerAngleRP, rEastRP, rNorthRP, ppRadiusRP;

        //the recorded path from driving around
        public List<CRecPathPt> recList = new List<CRecPathPt>();

        public bool isRecordOn;

        public bool isFollowingDubinsPath, isFollowingRecPath;

        //constructor
        public CRecordedPath(OpenGL _gl, FormGPS _f)
        {
            gl = _gl;
            mf = _f;
        }


        public void DrawRecordedLine()
        {
            int ptCount = recList.Count;
            if (ptCount < 1) return;
            gl.LineWidth(1);
            gl.Color(0.6f, 0.62f, 0.60f);
            gl.Begin(OpenGL.GL_LINE_STRIP);
            for (int h = 0; h < ptCount; h++) gl.Vertex(recList[h].easting, recList[h].northing, 0);
            gl.End();

            //if (mf.isPureDisplayOn)
            //{
            //    const int numSegments = 100;
            //    {
            //        gl.Color(0.95f, 0.630f, 0.950f);

            //        double theta = glm.twoPI / (numSegments);
            //        double c = Math.Cos(theta);//precalculate the sine and cosine
            //        double s = Math.Sin(theta);

            //        double x = ppRadiusRP;//we start at angle = 0
            //        double y = 0;

            //        gl.LineWidth(1);
            //        gl.Begin(OpenGL.GL_LINE_LOOP);
            //        for (int ii = 0; ii < numSegments; ii++)
            //        {
            //            //glVertex2f(x + cx, y + cy);//output vertex
            //            gl.Vertex(x + radiusPointRP.easting, y + radiusPointRP.northing);//output vertex

            //            //apply the rotation matrix
            //            double t = x;
            //            x = (c * x) - (s * y);
            //            y = (s * t) + (c * y);
            //        }
            //        gl.End();

            //        //Draw lookahead Point
            //        gl.PointSize(8.0f);
            //        gl.Begin(OpenGL.GL_POINTS);

            //        //gl.Color(1.0f, 1.0f, 0.25f);
            //        //gl.Vertex(rEast, rNorth, 0.0);

            //        gl.Color(1.0f, 0.5f, 0.95f);
            //        gl.Vertex(goalPointRP.easting, goalPointRP.northing, 0.0);

            //        gl.End();
            //        gl.PointSize(1.0f);
            //    }
            //}
        }
    }
}