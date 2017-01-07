//Please, if you use this, share the improvements

using System;

namespace AgOpenGPS
{
    /// <summary>
    /// Represents a three dimensional vector.
    /// </summary>
    public struct vec3
    {
        public double x;
        public double h;
        public double z;

        public double this[int index]
        {
            get
            {
                if (index == 0) return x;
                else if (index == 1) return h;
                else if (index == 2) return z;
                else throw new Exception("Out of range.");
            }
            set
            {
                if (index == 0) x = value;
                else if (index == 1) h = value;
                else if (index == 2) z = value;
                else throw new Exception("Out of range.");
            }
        }

        public vec3(double s)
        {
            x = h = z = s;
        }

        public vec3(double x, double y, double z)
        {
            this.x = x;
            this.h = y;
            this.z = z;
        }

        public vec3(vec3 v)
        {
            this.x = v.x;
            this.h = v.h;
            this.z = v.z;
        }

        public double HeadingXZ()
        {
            return Math.Atan2(x, z);
        }
 
        public void Normalize()
        {
            double length = GetLength();
            if (length == 0)
            {
                throw new DivideByZeroException("Trying to normalize a vector with length of zero.");
            }

            x /= length;
            h /= length;
            z /= length;
        }

        //Returns the length of the vector
        public double GetLength()
        {
            return System.Math.Sqrt(x * x + h * h + z * z);
        }

        // Calculates the squared length of the vector.
        public double GetLengthSquared()
        {
            return (x * x + h * h + z * z);
        }

        public static vec3 operator +(vec3 lhs, vec3 rhs)
        {
            return new vec3(lhs.x + rhs.x, lhs.h + rhs.h, lhs.z + rhs.z);
        }

        public static vec3 operator +(vec3 lhs, double rhs)
        {
            return new vec3(lhs.x + rhs, lhs.h + rhs, lhs.z + rhs);
        }

        public static vec3 operator -(vec3 lhs, vec3 rhs)
        {
            return new vec3(lhs.x - rhs.x, lhs.h - rhs.h, lhs.z - rhs.z);
        }

        public static vec3 operator -(vec3 lhs, double rhs)
        {
            return new vec3(lhs.x - rhs, lhs.h - rhs, lhs.z - rhs);
        }

        public static vec3 operator *(vec3 self, double s)
        {
            return new vec3(self.x * s, self.h * s, self.z * s);
        }
        public static vec3 operator *(double lhs, vec3 rhs)
        {
            return new vec3(rhs.x * lhs, rhs.h * lhs, rhs.z * lhs);
        }

        public static vec3 operator /(vec3 lhs, double rhs)
        {
            return new vec3(lhs.x / rhs, lhs.h / rhs, lhs.z / rhs);
        }

        public static vec3 operator *(vec3 lhs, vec3 rhs)
        {
            return new vec3(rhs.x * lhs.x, rhs.h * lhs.h, rhs.z * lhs.z);
        }

        public double[] to_array()
        {
            return new[] { x, h, z };
        }
    }

    //
    public struct vec2
    {
        public double x;
        public double z;

        public double this[int index]
        {
            get
            {
                if (index == 0) return x;
                else if (index == 1) return z;
                else throw new Exception("Out of range.");
            }
            set
            {
                if (index == 0) x = value;
                else if (index == 1) z = value;
                else throw new Exception("Out of range.");
            }
        }

        public vec2(double s)
        {
            x = z = s;
        }

        public vec2(double x, double z)
        {
            this.x = x;
            this.z = z;
        }

        public vec2(vec2 v)
        {
            this.x = v.x;
            this.z = v.z;
        }

        public vec2(vec3 v)
        {
            this.x = v.x;
            this.z = v.z;
        }

        public static vec2 operator +(vec2 lhs, vec2 rhs)
        {
            return new vec2(lhs.x + rhs.x, lhs.z + rhs.z);
        }

        public static vec2 operator +(vec2 lhs, double rhs)
        {
            return new vec2(lhs.x + rhs, lhs.z + rhs);
        }

        public static vec2 operator -(vec2 lhs, vec2 rhs)
        {
            return new vec2(lhs.x - rhs.x, lhs.z - rhs.z);
        }

        public static vec2 operator -(vec2 lhs, double rhs)
        {
            return new vec2(lhs.x - rhs, lhs.z - rhs);
        }

        public static vec2 operator *(vec2 self, double s)
        {
            return new vec2(self.x * s, self.z * s);
        }

        public static vec2 operator *(double lhs, vec2 rhs)
        {
            return new vec2(rhs.x * lhs, rhs.z * lhs);
        }

        public static vec2 operator *(vec2 lhs, vec2 rhs)
        {
            return new vec2(rhs.x * lhs.x, rhs.z * lhs.z);
        }

        public static vec2 operator /(vec2 lhs, double rhs)
        {
            return new vec2(lhs.x / rhs, lhs.z / rhs);
        }

        public double[] to_array()
        {
            return new[] { x, z };
        }
    }

    //
    public struct cvec
    {
        public double x;
        public double z;
        public double h;
        public int strip;
        public int pt;

         public cvec(double x, double z, double h, int s, int p)
        {
            this.x = x;
            this.z = z;
            this.h = h;
            this.strip = s;
            this.pt = p;
        }

       //public double this[int index]
        //{
        //    get
        //    {
        //        if (index == 0) return x;
        //        else if (index == 1) return z;
        //        else if (index == 2) return strip;
        //        else if (index == 3) return pt;
        //        else if (index == 4) return h;
        //        else throw new Exception("Out of range.");
        //    }
        //    set
        //    {
        //        if (index == 0) x = value;
        //        else if (index == 1) z = value;
        //        else if (index == 4) h = value;
        //        else if (index == 2) strip = (int)value;
        //        else if (index == 3) pt = (int)value;

        //        else throw new Exception("Out of range.");
        //    }
        //}

        //public cvec(double set)
        //{
        //    x = z = set;
        //    pt = (int)set;
        //}


        //public cvec(vec2 v)
        //{
        //    this.x = v.x;
        //    this.z = v.z;
        //}

         public cvec(vec3 v)
         {
             this.x = v.x;
             this.z = v.z;
             this.h = v.h;
             this.strip = 99999;
             this.pt = 99999;
         }

        //public static cvec operator +(cvec lhs, cvec rhs)
        //{
        //    return new cvec(lhs.x + rhs.x, lhs.z + rhs.z);
        //}

        //public static cvec operator +(cvec lhs, double rhs)
        //{
        //    return new cvec(lhs.x + rhs, lhs.z + rhs);
        //}

        //public static cvec operator -(cvec lhs, cvec rhs)
        //{
        //    return new cvec(lhs.x - rhs.x, lhs.z - rhs.z);
        //}

        //public static cvec operator -(cvec lhs, double rhs)
        //{
        //    return new cvec(lhs.x - rhs, lhs.z - rhs);
        //}

        //public static cvec operator *(cvec self, double s)
        //{
        //    return new cvec(self.x * s, self.z * s);
        //}

        //public static cvec operator *(double lhs, cvec rhs)
        //{
        //    return new cvec(rhs.x * lhs, rhs.z * lhs);
        //}

        //public static cvec operator *(cvec lhs, cvec rhs)
        //{
        //    return new cvec(rhs.x * lhs.x, rhs.z * lhs.z);
        //}

        //public static cvec operator /(cvec lhs, double rhs)
        //{
        //    return new cvec(lhs.x / rhs, lhs.z / rhs);
        //}

        //public double[] to_array()
        //{
        //    return new[] { x, z };
        //}
    }
}
