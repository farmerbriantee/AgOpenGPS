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

        public static double
        RelativeAngle_L(double angle1, double angle2)
        {
            angle1 = CheckAngle(angle1);
            angle2 = CheckAngle(angle2);

            if (angle1 > angle2)
            {
                return (angle2 + TAU) - angle1;
            }
            else if (angle1 < angle2)
            {
                return angle2 - angle1;
            }

            return 0D;
        }

        public static double
        RelativeAngle_R(double angle1, double angle2)
        {
            angle1 = CheckAngle(angle1);
            angle2 = CheckAngle(angle2);

            if (angle1 < angle2)
            {
                return -((angle1 + TAU) - angle2);
            }
            else if (angle1 > angle2)
            {
                return -(angle1 - angle2);
            }

            return 0D;
        }
    }
}
