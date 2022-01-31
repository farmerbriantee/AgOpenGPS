using System;

namespace AgOpenGPS
{

    internal sealed class CSunTimes
    {
        #region Private Data Members

        private readonly object mLock = new object();

        private const double mDR = Math.PI / 180;
        private const double mK1 = 15 * mDR * 1.0027379;

        private readonly int[] mRiseTimeArr = new int[2] { 0, 0 };
        private readonly int[] mSetTimeArr = new int[2] { 0, 0 };

        private readonly double[] mSunPositionInSkyArr = new double[2] { 0.0, 0.0 };
        private readonly double[] mRightAscentionArr = new double[3] { 0.0, 0.0, 0.0 };
        private readonly double[] mDecensionArr = new double[3] { 0.0, 0.0, 0.0 };
        private readonly double[] mVHzArr = new double[3] { 0.0, 0.0, 0.0 };

        #endregion

        private static readonly CSunTimes mInstance = new CSunTimes();    // The singleton instance

        private CSunTimes() { }

        public static CSunTimes Instance => mInstance;

        /// <summary>
        /// Calculate sunrise and sunset times. Returns false if time zone and longitude are incompatible.
        /// </summary>
        /// <param name="lat">Latitude in decimal notation.</param>
        /// <param name="lon">Longitude in decimal notation.</param>
        /// <param name="date">Date for which to calculate.</param>
        /// <param name="riseTime">Sunrise time (output)</param>
        /// <param name="setTime">Sunset time (output)</param>
        public bool CalculateSunRiseSetTimes(double lat, double lon, DateTime date,
                                                ref DateTime riseTime, ref DateTime setTime)
        {
            lock (mLock)    // lock for thread safety
            {
                double zone = -(int)Math.Round(TimeZone.CurrentTimeZone.GetUtcOffset(date).TotalSeconds / 3600);
                double jd = GetJulianDay(date) - 2451545;  // Julian day relative to Jan 1.5, 2000

                lon /= 360;
                double tz = zone / 24;
                double ct = jd / 36525 + 1;                                 // centuries since 1900.0
                double t0 = LocalSiderealTimeForTimeZone(lon, jd, tz);      // local sidereal time

                // get sun position at start of day
                jd += tz;
                CalculateSunPosition(jd, ct);
                double ra0 = mSunPositionInSkyArr[0];
                double dec0 = mSunPositionInSkyArr[1];

                // get sun position at end of day
                jd += 1;
                CalculateSunPosition(jd, ct);
                double ra1 = mSunPositionInSkyArr[0];
                double dec1 = mSunPositionInSkyArr[1];

                // make continuous 
                if (ra1 < ra0)
                    ra1 += 2 * Math.PI;

                mRightAscentionArr[0] = ra0;
                mDecensionArr[0] = dec0;

                // check each hour of this day
                for (int k = 0; k < 24; k++)
                {
                    mRightAscentionArr[2] = ra0 + (k + 1) * (ra1 - ra0) / 24;
                    mDecensionArr[2] = dec0 + (k + 1) * (dec1 - dec0) / 24;
                    mVHzArr[2] = TestHour(k, t0, lat);

                    // advance to next hour
                    mRightAscentionArr[0] = mRightAscentionArr[2];
                    mDecensionArr[0] = mDecensionArr[2];
                    mVHzArr[0] = mVHzArr[2];
                }

                riseTime = new DateTime(date.Year, date.Month, date.Day, mRiseTimeArr[0], mRiseTimeArr[1], 0);
                setTime = new DateTime(date.Year, date.Month, date.Day, mSetTimeArr[0], mSetTimeArr[1], 0);

                return true;
            }
        }

        #region Private Methods

        private int Sign(double value)
        {
            int rv;
            if (value > 0.0) rv = 1;
            else if (value < 0.0) rv = -1;
            else rv = 0;

            return rv;
        }

        // Local Sidereal Time for zone
        private double LocalSiderealTimeForTimeZone(double lon, double jd, double z)
        {
            double s = 24110.5 + 8640184.812999999 * jd / 36525 + 86636.6 * z + 86400 * lon;
            s /= 86400;
            s -= Math.Floor(s);
            return s * 360 * mDR;
        }

        // determine Julian day from calendar date
        // (Jean Meeus, "Astronomical Algorithms", Willmann-Bell, 1991)
        private double GetJulianDay(DateTime date)
        {
            int month = date.Month;
            int day = date.Day;
            int year = date.Year;

            bool gregorian = year >= 1583;

            if ((month == 1) || (month == 2))
            {
                year--;
                month += 12;
            }

            double a = Math.Floor((double)year / 100);
            double b;
            if (gregorian)
                b = 2 - a + Math.Floor(a / 4);
            else
                b = 0.0;

            double jd = Math.Floor(365.25 * (year + 4716))
                       + Math.Floor(30.6001 * (month + 1))
                       + day + b - 1524.5;

            return jd;
        }

        // sun's position using fundamental arguments 
        // (Van Flandern & Pulkkinen, 1979)
        private void CalculateSunPosition(double jd, double ct)
        {
            double g, lo, s, u, v, w;

            lo = 0.779072 + 0.00273790931 * jd;
            lo -= Math.Floor(lo);
            lo = lo * 2 * Math.PI;

            g = 0.993126 + 0.0027377785 * jd;
            g -= Math.Floor(g);
            g = g * 2 * Math.PI;

            v = 0.39785 * Math.Sin(lo);
            v -= 0.01 * Math.Sin(lo - g);
            v += 0.00333 * Math.Sin(lo + g);
            v -= 0.00021 * ct * Math.Sin(lo);

            u = 1 - 0.03349 * Math.Cos(g);
            u -= 0.00014 * Math.Cos(2 * lo);
            u += 0.00008 * Math.Cos(lo);

            w = -0.0001 - 0.04129 * Math.Sin(2 * lo);
            w += 0.03211 * Math.Sin(g);
            w += 0.00104 * Math.Sin(2 * lo - g);
            w -= 0.00035 * Math.Sin(2 * lo + g);
            w -= 0.00008 * ct * Math.Sin(g);

            // compute sun's right ascension
            s = w / Math.Sqrt(u - v * v);
            mSunPositionInSkyArr[0] = lo + Math.Atan(s / Math.Sqrt(1 - s * s));

            // ...and declination 
            s = v / Math.Sqrt(u);
            mSunPositionInSkyArr[1] = Math.Atan(s / Math.Sqrt(1 - s * s));
        }

        // test an hour for an event
        private double TestHour(int k, double t0, double lat)
        {
            double[] ha = new double[3];
            double a, b, c, d, e, s, z;
            double time;
            int hr, min;

            ha[0] = t0 - mRightAscentionArr[0] + k * mK1;
            ha[2] = t0 - mRightAscentionArr[2] + k * mK1 + mK1;

            ha[1] = (ha[2] + ha[0]) / 2;    // hour angle at half hour
            mDecensionArr[1] = (mDecensionArr[2] + mDecensionArr[0]) / 2;  // declination at half hour

            s = Math.Sin(lat * mDR);
            c = Math.Cos(lat * mDR);
            z = Math.Cos(90.833 * mDR);    // refraction + sun semidiameter at horizon

            if (k <= 0)
                mVHzArr[0] = s * Math.Sin(mDecensionArr[0]) + c * Math.Cos(mDecensionArr[0]) * Math.Cos(ha[0]) - z;

            mVHzArr[2] = s * Math.Sin(mDecensionArr[2]) + c * Math.Cos(mDecensionArr[2]) * Math.Cos(ha[2]) - z;

            if (Sign(mVHzArr[0]) == Sign(mVHzArr[2]))
                return mVHzArr[2];  // no event this hour

            mVHzArr[1] = s * Math.Sin(mDecensionArr[1]) + c * Math.Cos(mDecensionArr[1]) * Math.Cos(ha[1]) - z;

            a = 2 * mVHzArr[0] - 4 * mVHzArr[1] + 2 * mVHzArr[2];
            b = -3 * mVHzArr[0] + 4 * mVHzArr[1] - mVHzArr[2];
            d = b * b - 4 * a * mVHzArr[0];

            if (d < 0)
                return mVHzArr[2];  // no event this hour

            d = Math.Sqrt(d);
            e = (-b + d) / (2 * a);

            if ((e > 1) || (e < 0))
                e = (-b - d) / (2 * a);

            time = k + e + 1 / (double)120; // time of an event

            hr = (int)Math.Floor(time);
            min = (int)Math.Floor((time - hr) * 60);

            if ((mVHzArr[0] < 0) && (mVHzArr[2] > 0))
            {
                mRiseTimeArr[0] = hr;
                mRiseTimeArr[1] = min;
            }

            if ((mVHzArr[0] > 0) && (mVHzArr[2] < 0))
            {
                mSetTimeArr[0] = hr;
                mSetTimeArr[1] = min;
            }

            return mVHzArr[2];
        }

        #endregion  // Private Methods
    }
}
