using System;

namespace AgOpenGPS
{
    public static class
    Utility
    {
        const double TAU = (2 * Math.PI);

        public static double
        CheckAngle(double angle)
        {
            for (; angle < 0D;) { angle += TAU; }

            for (; angle > TAU;) { angle -= TAU; }

            return angle;
        }
    }
}
