using System;

namespace AgOpenGPS
{
   public static class glm
    {
       //inches to meters
       public static double in2m = 0.0254;

       //meters to inches
       public static double m2in = 39.3701;

       //meters to feet
       public static double m2ft = 3.28084;

       //the pi's
       public static double twoPI = 6.28318530717958647692;

       public static double PIBy2 = 1.57079632679489661923;

       public static float acos(float x)
        {
            return (float)Math.Acos(x);
        }

        public static float acosh(float x)
        {
            if (x < (1f)) return (0f);
            return (float)Math.Log(x + Math.Sqrt(x * x - (1f)));
        }

        public static float asin(float x)
        {
            return (float)Math.Asin(x);
        }

        public static float asinh(float x)
        {
            return (x < 0f ? -1f : (x > 0f ? 1f : 0f)) * (float)Math.Log(Math.Abs(x) + Math.Sqrt(1f + x * x));
        }

        public static float atan(float y, float x)
        {
            return (float)Math.Atan2(y, x);
        }

        public static float atan(float y_over_x)
        {
            return (float)Math.Atan(y_over_x);
        }

        public static float atanh(float x)
        {
            if (Math.Abs(x) >= 1f) return 0;
            return (0.5f) * (float)Math.Log((1f + x) / (1f - x));
        }

        public static float cos(float angle)
        {
            return (float)Math.Cos(angle);
        }

        public static float cosh(float angle)
        {
            return (float)Math.Cosh(angle);
        }

        public static float toDegrees(float radians)
        {
            return radians * (57.295779513082325225835265587528f);
        }
        public static double toDegrees(double radians)
        {
            return radians * (57.295779513082325225835265587528);
        }

        public static float toRadians(float degrees)
        {
            return degrees * (0.01745329251994329576923690766743f);
        }
        public static double toRadians(double degrees)
        {
            return degrees * (0.01745329251994329576923690768489);
        }

        public static float sin(float angle)
        {
            return (float)Math.Sin(angle);
        }

        public static float sinh(float angle)
        {
            return (float)Math.Sinh(angle);
        }

        public static float tan(float angle)
        {
            return (float)Math.Tan(angle);
        }

        public static float tanh(float angle)
        {
            return (float)Math.Tanh(angle);
        }
    }
}
