using System;

namespace AgOpenGPS
{
    public static class Geometrics
    {
        /*
        *  Geometric vector defined in two dimensions.
        *  Defined in terms of cartesian x,y change
        *  and polar magnitude and direction.
        */
        public struct
        Vector2
        {
            public readonly double x;
            public readonly double y;
            public readonly double magnitude;
            public readonly double direction;

            private
            Vector2(double p_x, double p_y, double p_magnitude, double p_direction)
            {
                x = p_x;
                y = p_y;
                magnitude = p_magnitude;
                direction = p_direction;
            }

            public static Vector2
            Polar(double magnitude, double direction)
            {
                magnitude = Math.Abs(magnitude);

                const double twoPI = 2 * Math.PI;
                for (; direction < 0D;) { direction += twoPI; }
                for (; direction > twoPI;) { direction -= twoPI; }

                double x = (magnitude * Math.Cos(direction));
                double y = (magnitude * Math.Sin(direction));

                return new Vector2(x, y, magnitude, direction);
            }

            public static Vector2
            Cartesian(double x, double y)
            {
                double magnitude =
                Math.Abs(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)));

                double direction = Math.Atan2(y, x);
                {
                    const double twoPI = 2 * Math.PI;
                    for (; direction < 0D;) { direction += twoPI; }
                    for (; direction > twoPI;) { direction -= twoPI; }
                }

                return new Vector2(x, y, magnitude, direction);
            }

            public static Vector2 operator +
            (Vector2 left, Vector2 right)
            {
                return Vector2.Cartesian
                    (left.x + right.x, left.y + right.y);
            }

            public static Vector2 operator -
            (Vector2 left, Vector2 right)
            {
                return Vector2.Cartesian
                    (left.x + (-right.x), left.y + (-right.y));
            }

            public static Vector2
            Reverse(Vector2 vector)
            {
                return Vector2.Cartesian
                    (-(vector.x), -(vector.y));
            }

            public static Vector2
            Scale(Vector2 vector, double scalar)
            {
                return Vector2.Polar
                    (vector.magnitude * scalar, vector.direction);
            }
        }

        public struct
        Line2
        {
            public readonly double
            slope,
            xIntercept,
            yIntercept;

            public Line2(double p_slope, double p_xIntercept, double p_yIntercept)
            {
                slope = p_slope;
                xIntercept = p_xIntercept;
                yIntercept = p_yIntercept;
            }

            public static Line2
            DefineByX(double xIntercept)
            {
                return new Line2(double.NaN, xIntercept, double.NaN);
            }

            public static Line2
            DefineByY(double yIntercept)
            {
                return new Line2(0D, double.NaN, yIntercept);
            }
        }
    }
}
