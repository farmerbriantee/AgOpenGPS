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
        public double y;
        public double z;

        public double this[int index]
        {
            get
            {
                if (index == 0) return x;
                else if (index == 1) return y;
                else if (index == 2) return z;
                else throw new Exception("Out of range.");
            }
            set
            {
                if (index == 0) x = value;
                else if (index == 1) y = value;
                else if (index == 2) z = value;
                else throw new Exception("Out of range.");
            }
        }

        public vec3(double s)
        {
            x = y = z = s;
        }

        public vec3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public vec3(vec3 v)
        {
            this.x = v.x;
            this.y = v.y;
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
            y /= length;
            z /= length;
        }

        //Returns the length of the vector
        public double GetLength()
        {
            return System.Math.Sqrt(x * x + y * y + z * z);
        }

        // Calculates the squared length of the vector.
        public double GetLengthSquared()
        {
            return (x * x + y * y + z * z);
        }

        public static vec3 operator +(vec3 lhs, vec3 rhs)
        {
            return new vec3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }

        public static vec3 operator +(vec3 lhs, double rhs)
        {
            return new vec3(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs);
        }

        public static vec3 operator -(vec3 lhs, vec3 rhs)
        {
            return new vec3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }

        public static vec3 operator -(vec3 lhs, double rhs)
        {
            return new vec3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);
        }

        public static vec3 operator *(vec3 self, double s)
        {
            return new vec3(self.x * s, self.y * s, self.z * s);
        }
        public static vec3 operator *(double lhs, vec3 rhs)
        {
            return new vec3(rhs.x * lhs, rhs.y * lhs, rhs.z * lhs);
        }

        public static vec3 operator /(vec3 lhs, double rhs)
        {
            return new vec3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        }

        public static vec3 operator *(vec3 lhs, vec3 rhs)
        {
            return new vec3(rhs.x * lhs.x, rhs.y * lhs.y, rhs.z * lhs.z);
        }

        public double[] to_array()
        {
            return new[] { x, y, z };
        }
    }

    //
    public struct vec2
    {
        public double x;
        public double y;

        public double this[int index]
        {
            get
            {
                if (index == 0) return x;
                else if (index == 1) return y;
                else throw new Exception("Out of range.");
            }
            set
            {
                if (index == 0) x = value;
                else if (index == 1) y = value;
                else throw new Exception("Out of range.");
            }
        }

        public vec2(double s)
        {
            x = y = s;
        }

        public vec2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public vec2(vec2 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        public vec2(vec3 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        public static vec2 operator +(vec2 lhs, vec2 rhs)
        {
            return new vec2(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        public static vec2 operator +(vec2 lhs, double rhs)
        {
            return new vec2(lhs.x + rhs, lhs.y + rhs);
        }

        public static vec2 operator -(vec2 lhs, vec2 rhs)
        {
            return new vec2(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        public static vec2 operator -(vec2 lhs, double rhs)
        {
            return new vec2(lhs.x - rhs, lhs.y - rhs);
        }

        public static vec2 operator *(vec2 self, double s)
        {
            return new vec2(self.x * s, self.y * s);
        }

        public static vec2 operator *(double lhs, vec2 rhs)
        {
            return new vec2(rhs.x * lhs, rhs.y * lhs);
        }

        public static vec2 operator *(vec2 lhs, vec2 rhs)
        {
            return new vec2(rhs.x * lhs.x, rhs.y * lhs.y);
        }

        public static vec2 operator /(vec2 lhs, double rhs)
        {
            return new vec2(lhs.x / rhs, lhs.y / rhs);
        }

        public double[] to_array()
        {
            return new[] { x, y };
        }
    }
}
