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

        public struct
        LineSegment2
        {
            public readonly vec2
            point1,
            point2;

            public readonly Line2
            equation;

            public
            LineSegment2(vec2 p_point1, vec2 p_point2)
            {
                point1 = p_point1;
                point2 = p_point2;

                double dx = Math.Abs(point2.northing - point1.northing);
                double dy = Math.Abs(point2.easting - point1.easting);

                double
                xIntercept,
                yIntercept;

                if (dx == 0D && dy == 0D)
                {
                    equation = new Line2(double.NaN, double.NaN, double.NaN);
                    return;
                }
                if (dx == 0)
                {
                    xIntercept = (point1.northing + point2.northing) * 0.5;
                    equation = Line2.DefineByX(xIntercept);
                    return;
                }
                if (dy == 0D)
                {
                    yIntercept = (point1.easting + point2.easting) * 0.5;
                    equation = Line2.DefineByY(yIntercept);
                    return;
                }

                double slope =
                    (point2.easting - point1.easting) /
                    (point2.northing - point1.northing);

                yIntercept =
                point1.easting -
                (slope * point1.northing);

                xIntercept = (0D - yIntercept) / slope;

                equation = new Line2(slope, xIntercept, yIntercept);
            }

            public double
            Length()
            {
                return Math.Sqrt(
                    Math.Pow(point2.northing - point1.northing, 2) +
                    Math.Pow(point2.easting - point1.easting, 2));
            }
        }

        public struct
        Ray2
        {
            public readonly vec2 point;
            public readonly double direction;
            public readonly Line2 equation;

            public
            Ray2(vec2 p_point, double p_direction)
            {
                point = p_point;

                direction = p_direction;
                {
                    const double twoPI = 2 * Math.PI;
                    for (; direction < 0D;) { direction += twoPI; }
                    for (; direction > twoPI;) { direction -= twoPI; }
                }

                if (direction == 0D || direction == Math.PI)
                {
                    equation = Line2.DefineByY(point.easting);
                    return;
                }
                if (direction == (Math.PI * 0.5) ||
                    direction == (Math.PI * 1.5))
                {
                    equation = Line2.DefineByX(point.northing);
                    return;
                }

                double
                slope = Math.Tan(direction),
                yIntercept = point.easting - (slope * point.northing),
                xIntercept = (0D - yIntercept) / slope;

                equation = new Line2(slope, xIntercept, yIntercept);
            }
        }
    }
}
