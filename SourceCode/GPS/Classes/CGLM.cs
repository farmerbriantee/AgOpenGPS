using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public static class NudChk
    {
        public static bool CheckValue(this NumericUpDown numericUpDown, ref decimal value)
        {
            if (value < numericUpDown.Minimum)
            {
                value = numericUpDown.Minimum;
                MessageBox.Show("Serious Settings Problem with - " + numericUpDown.Name
                    + " \n\rMinimum has been exceeded\n\rDouble check ALL your Settings and \n\rFix it and Resave Vehicle File",
                "Critical Settings Warning",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return true;
            }
            else if (value > numericUpDown.Maximum)
            {
                value = numericUpDown.Maximum;
                MessageBox.Show("Serious Settings Problem with - " + numericUpDown.Name
                    + " \n\rMaximum has been exceeded\n\rDouble check ALL your Settings and \n\rFix it and Resave Vehicle File",
                "Critical Settings Warning",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return true;
            }

            //value is ok
            return false;
        }

        public static bool CheckValueCm(this NumericUpDown numericUpDown, ref double value)
        {
            //convert to cm
            value *= 100;
            bool isChanged = false;

            if (value < (double)numericUpDown.Minimum)
            {
                value = (double)numericUpDown.Minimum / 2.4;
                MessageBox.Show("Serious Settings Problem with - " + numericUpDown.Name
                    + " \n\rMinimum has been exceeded\n\rDouble check ALL your Settings and \n\rFix it and Resave Vehicle File",
                "Critical Settings Warning",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                isChanged = true;
            }
            else if (value > (double)numericUpDown.Maximum)
            {
                value = (double)numericUpDown.Maximum / 2.6;
                MessageBox.Show("Serious Settings Problem with - " + numericUpDown.Name
                    + " \n\rMaximum has been exceeded\n\rDouble check ALL your Settings and \n\rFix it and Resave Vehicle File",
                "Critical Settings Warning",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                isChanged = true;
            }

            //revert back to meters
            value *= 0.01;

            //value is ok
            return isChanged;
        }
    }

    public static class glm
    {
        // Catmull Rom interpoint spline calculation
        public static vec3 Catmull(double t, vec3 p0, vec3 p1, vec3 p2, vec3 p3)
        {
            double tt = t * t;
            double ttt = tt * t;

            double q1 = -ttt + 2.0f * tt - t;
            double q2 = 3.0f * ttt - 5.0f * tt + 2.0f;
            double q3 = -3.0f * ttt + 4.0f * tt + t;
            double q4 = ttt - tt;

            double tx = 0.5f * (p0.easting * q1 + p1.easting * q2 + p2.easting * q3 + p3.easting * q4);
            double ty = 0.5f * (p0.northing * q1 + p1.northing * q2 + p2.northing * q3 + p3.northing * q4);

            vec3 ret = new vec3(tx, ty, 0);
            return ret;

            //f(t) = a_3 * t^3 + a_2 * t^2 + a_1 * t + a_0  cubic polynomial
            //vec3 a = 2.0 * p1;
            //vec3 b = p2 - p0;
            //vec3 c = 2.0 * p0 - 5.0 * p1 + 4.0 * p2 - p3;
            //vec3 d = -1.0 * p0 + 3.0 * p1 - 3.0 * p2 + p3;

            //return (0.5 * (a + (t * b) + (t * t * c) + (t * t * t * d)));
            //

            //vec2 p0 = new vec2(1, 0);
            //vec2 p1 = new vec2(3, 2);
            //vec2 p2 = new vec2(5, 3);
            //vec2 p3 = new vec2(6, 1);

            //vec2 a = 2.0 * p1;
            //vec2 b = p2 - p0;
            //vec2 c = 2.0 * p0 - 5.0 * p1 + 4.0 * p2 - p3;
            //vec2 d = -1.0 * p0 + 3.0 * p1 - 3.0 * p2 + p3;

            //double tt = 0.25;

            //vec2 pos = 0.5 * (a + (tt*b) + (tt * tt * c) + (tt * tt * tt * d));


        }


        // Catmull Rom gradient calculation
        public static double CatmullGradient(double t, vec3 p0, vec3 p1, vec3 p2, vec3 p3)
        {
            double tt = t * t;

            double q1 = -3.0f * tt + 4.0f * t - 1;
            double q2 = 9.0f * tt - 10.0f * t;
            double q3 = -9.0f * tt + 8.0f * t + 1.0f;
            double q4 = 3.0f * tt - 2.0f * t;

            double tx = 0.5f * (p0.easting * q1 + p1.easting * q2 + p2.easting * q3 + p3.easting * q4);
            double ty = 0.5f * (p0.northing * q1 + p1.northing * q2 + p2.northing * q3 + p3.northing * q4);

            return Math.Atan2(tx, ty);

            //f(t) = a_3 * t^3 + a_2 * t^2 + a_1 * t + a_0  cubic polynomial
            //vec3 a = 2.0 * p1;
            //vec3 b = p2 - p0;
            //vec3 c = 2.0 * p0 - 5.0 * p1 + 4.0 * p2 - p3;
            //vec3 d = -1.0 * p0 + 3.0 * p1 - 3.0 * p2 + p3;

            //return (0.5 * (a + (t * b) + (t * t * c) + (t * t * t * d)));
            //
        }

        //Regex file expression
        public static string fileRegex = "(^(PRN|AUX|NUL|CON|COM[1-9]|LPT[1-9]|(\\.+)$)(\\..*)?$)|(([\\x00-\\x1f\\\\?*:\";‌​|/<>])+)|([\\.]+)";

        //inches to meters
        public static double in2m = 0.0254;

        //meters to inches
        public static double m2in = 39.3701;

        //meters to feet
        public static double m2ft = 3.28084;

        //feet to meters
        public static double ft2m = 0.3048;

        //Hectare to Acres
        public static double ha2ac = 2.47105;

        //Acres to Hectare
        public static double ac2ha = 0.404686;

        //Meters to Acres
        public static double m2ac = 0.000247105;

        //Meters to Hectare
        public static double m2ha = 0.0001;

        // liters per hectare to us gal per acre
        public static double galAc2Lha = 9.35396;

        //us gal per acre to liters per hectare
        public static double LHa2galAc = 0.106907;

        //Liters to Gallons
        public static double L2Gal = 0.264172;

        //Gallons to Liters
        public static double Gal2L = 3.785412534258;

        //the pi's
        public static double twoPI = 6.28318530717958647692;

        public static double PIBy2 = 1.57079632679489661923;

        //Degrees Radians Conversions
        public static double toDegrees(double radians)
        {
            return radians * 57.295779513082325225835265587528;
        }

        public static double toRadians(double degrees)
        {
            return degrees * 0.01745329251994329576923690768489;
        }

        //Distance calcs of all kinds
        public static double Distance(double east1, double north1, double east2, double north2)
        {
            return Math.Sqrt(
                Math.Pow(east1 - east2, 2)
                + Math.Pow(north1 - north2, 2));
        }

        public static double Distance(vec2 first, vec2 second)
        {
            return Math.Sqrt(
                Math.Pow(first.easting - second.easting, 2)
                + Math.Pow(first.northing - second.northing, 2));
        }

        public static double Distance(vec2 first, vec3 second)
        {
            return Math.Sqrt(
                Math.Pow(first.easting - second.easting, 2)
                + Math.Pow(first.northing - second.northing, 2));
        }

        public static double Distance(vec3 first, vec2 second)
        {
            return Math.Sqrt(
                Math.Pow(first.easting - second.easting, 2)
                + Math.Pow(first.northing - second.northing, 2));
        }

        public static double Distance(vec3 first, vec3 second)
        {
            return Math.Sqrt(
                Math.Pow(first.easting - second.easting, 2)
                + Math.Pow(first.northing - second.northing, 2));
        }

        public static double Distance(vec2 first, double east, double north)
        {
            return Math.Sqrt(
                Math.Pow(first.easting - east, 2)
                + Math.Pow(first.northing - north, 2));
        }

        public static double Distance(vec3 first, double east, double north)
        {
            return Math.Sqrt(
                Math.Pow(first.easting - east, 2)
                + Math.Pow(first.northing - north, 2));
        }

        public static double Distance(vecFix2Fix first, vec2 second)
        {
            return Math.Sqrt(
                Math.Pow(first.easting - second.easting, 2)
                + Math.Pow(first.northing - second.northing, 2));
        }

        public static double Distance(vecFix2Fix first, vecFix2Fix second)
        {
            return Math.Sqrt(
                Math.Pow(first.easting - second.easting, 2)
                + Math.Pow(first.northing - second.northing, 2));
        }



        //not normalized distance, no square root
        public static double DistanceSquared(double northing1, double easting1, double northing2, double easting2)
        {
            return Math.Pow(easting1 - easting2, 2) + Math.Pow(northing1 - northing2, 2);
        }

        public static double DistanceSquared(vec3 first, vec2 second)
        {
            return (
            Math.Pow(first.easting - second.easting, 2)
            + Math.Pow(first.northing - second.northing, 2));
        }

        public static double DistanceSquared(vec2 first, vec3 second)
        {
            return (
            Math.Pow(first.easting - second.easting, 2)
            + Math.Pow(first.northing - second.northing, 2));
        }

        public static double DistanceSquared(vec3 first, vec3 second)
        {
            return (
            Math.Pow(first.easting - second.easting, 2)
            + Math.Pow(first.northing - second.northing, 2));
        }
        public static double DistanceSquared(vec2 first, vec2 second)
        {
            return (
            Math.Pow(first.easting - second.easting, 2)
            + Math.Pow(first.northing - second.northing, 2));
        }
    }
}