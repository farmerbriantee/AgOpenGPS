using System;

namespace AgOpenGPS
{
    //public class CCartFix
    //{
    //    public double fixLat { get; set; }
    //    public double fixLon { get; set; }
    //    public double heading { get; set; }

    //    public double cartLat { get; set; }
    //    public double cartLon { get; set; }
    //    public double speed { get; set; }

    //    //constructor
    //    public CCartFix(double _fixLat, double _fixLon, double _fixHeading, double _cartLat, double _cartLon, double _speed)
    //    {
    //        fixLat = _fixLat;
    //        fixLon = _fixLon;
    //        heading = _fixHeading;
    //        cartLat = _cartLat;
    //        cartLon = _cartLon;
    //        speed = _speed;
    //    }
    //}

    public class CCart
    {
        private readonly FormGPS mf;

        //the result is placed in these two
        public double utmLat = 0;
        public double utmLon = 0;

        public bool isCartOn, isCartCalled, isCartSentHome;

        public double offsetForward, offsetOutward;

        //the position and heading of cart goal point.
        public vec3 cartPos = new vec3();

        public CCart(FormGPS _f)
        {
            mf = _f;
            offsetForward = 5;
            offsetOutward = 11;
        }

        public void CartCall()
        {
            if (!isCartCalled)
            {
                isCartCalled = true;
                isCartSentHome = false;
                mf.SendUDPMessage("$CALL," + mf.pn.latitude + "," + mf.pn.longitude + "," + mf.fixHeading + "," + 7.2);
            }
        }

        public void CartWait()
        {
            if (!isCartCalled)
            {
                isCartCalled = false;
                isCartSentHome = false;
                mf.SendUDPMessage("$WAIT," + mf.pn.latitude + "," + mf.pn.longitude + "," + mf.fixHeading + "," + 7.2);
            }
        }

        public void CalculatePosition(vec3 currentPos)
        {
            cartPos.easting = currentPos.easting - Math.Cos(-currentPos.heading) * offsetOutward;
            cartPos.northing = currentPos.northing - Math.Sin(-currentPos.heading) * offsetOutward;

            cartPos.easting += Math.Cos(-currentPos.heading + glm.PIBy2) * offsetForward;
            cartPos.northing += Math.Sin(-currentPos.heading + glm.PIBy2) * offsetForward;
            cartPos.heading = currentPos.heading;

            UTMToLatLon(cartPos.easting + mf.pn.utmEast, cartPos.northing + mf.pn.utmNorth);
        }

        public void PositionCart()
        {
            mf.SendUDPMessage("$POS, " + utmLat + "," + utmLon + "," + cartPos.heading + "," + mf.pn.speed);
            //mf.pivotAxlePos.easting + "," + mf.pivotAxlePos.northing + "," + mf.pivotAxlePos.heading
        }

        public void CartSendHome()
        {
            isCartCalled = false;
            isCartSentHome = false;
            mf.SendUDPMessage("$HOME," + mf.pn.latitude + "," + mf.pn.longitude + "," + mf.fixHeading + "," + 7.2);
        }

        private readonly double sm_a = 6378137.0;
        private readonly double sm_b = 6356752.314;
        private readonly double UTMScaleFactor2 = 1.0004001600640256102440976390556;

        public void UTMToLatLon(double X, double Y)
        {
            double cmeridian;

            X -= 500000.0;
            X *= UTMScaleFactor2;

            /* If in southern hemisphere, adjust y accordingly. */
            if (mf.pn.hemisphere == 'S')
                Y -= 10000000.0;
            Y *= UTMScaleFactor2;

            cmeridian = (-183.0 + (mf.pn.zone * 6.0)) * 0.01745329251994329576923690766743;
            double[] latlon = new double[2]; //= MapXYToLatLon(X, Y, cmeridian);

            double phif, Nf, Nfpow, nuf2, ep2, tf, tf2, tf4, cf;
            double x1frac, x2frac, x3frac, x4frac, x5frac, x6frac, x7frac, x8frac;
            double x2poly, x3poly, x4poly, x5poly, x6poly, x7poly, x8poly;

            /* Get the value of phif, the footpoint latitude. */
            phif = FootpointLatitude(Y);

            /* Precalculate ep2 */
            ep2 = (Math.Pow(sm_a, 2.0) - Math.Pow(sm_b, 2.0))
                  / Math.Pow(sm_b, 2.0);

            /* Precalculate cos (phif) */
            cf = Math.Cos(phif);

            /* Precalculate nuf2 */
            nuf2 = ep2 * Math.Pow(cf, 2.0);

            /* Precalculate Nf and initialize Nfpow */
            Nf = Math.Pow(sm_a, 2.0) / (sm_b * Math.Sqrt(1 + nuf2));
            Nfpow = Nf;

            /* Precalculate tf */
            tf = Math.Tan(phif);
            tf2 = tf * tf;
            tf4 = tf2 * tf2;

            /* Precalculate fractional coefficients for x**n in the equations
               below to simplify the expressions for latitude and longitude. */
            x1frac = 1.0 / (Nfpow * cf);

            Nfpow *= Nf;   /* now equals Nf**2) */
            x2frac = tf / (2.0 * Nfpow);

            Nfpow *= Nf;   /* now equals Nf**3) */
            x3frac = 1.0 / (6.0 * Nfpow * cf);

            Nfpow *= Nf;   /* now equals Nf**4) */
            x4frac = tf / (24.0 * Nfpow);

            Nfpow *= Nf;   /* now equals Nf**5) */
            x5frac = 1.0 / (120.0 * Nfpow * cf);

            Nfpow *= Nf;   /* now equals Nf**6) */
            x6frac = tf / (720.0 * Nfpow);

            Nfpow *= Nf;   /* now equals Nf**7) */
            x7frac = 1.0 / (5040.0 * Nfpow * cf);

            Nfpow *= Nf;   /* now equals Nf**8) */
            x8frac = tf / (40320.0 * Nfpow);

            /* Precalculate polynomial coefficients for x**n.
               -- x**1 does not have a polynomial coefficient. */
            x2poly = -1.0 - nuf2;

            x3poly = -1.0 - 2 * tf2 - nuf2;

            x4poly = 5.0 + 3.0 * tf2 + 6.0 * nuf2 - 6.0 * tf2 * nuf2
                - 3.0 * (nuf2 * nuf2) - 9.0 * tf2 * (nuf2 * nuf2);

            x5poly = 5.0 + 28.0 * tf2 + 24.0 * tf4 + 6.0 * nuf2 + 8.0 * tf2 * nuf2;

            x6poly = -61.0 - 90.0 * tf2 - 45.0 * tf4 - 107.0 * nuf2
                + 162.0 * tf2 * nuf2;

            x7poly = -61.0 - 662.0 * tf2 - 1320.0 * tf4 - 720.0 * (tf4 * tf2);

            x8poly = 1385.0 + 3633.0 * tf2 + 4095.0 * tf4 + 1575 * (tf4 * tf2);

            /* Calculate latitude */
            latlon[0] = phif + x2frac * x2poly * (X * X)
                + x4frac * x4poly * Math.Pow(X, 4.0)
                + x6frac * x6poly * Math.Pow(X, 6.0)
                + x8frac * x8poly * Math.Pow(X, 8.0);

            /* Calculate longitude */
            latlon[1] = cmeridian + x1frac * X
                + x3frac * x3poly * Math.Pow(X, 3.0)
                + x5frac * x5poly * Math.Pow(X, 5.0)
                + x7frac * x7poly * Math.Pow(X, 7.0);

            utmLat = latlon[0] * 57.295779513082325225835265587528;
            utmLon = latlon[1] * 57.295779513082325225835265587528;
        }

        private double FootpointLatitude(double y)
        {
            double y_, alpha_, beta_, gamma_, delta_, epsilon_, n;
            double result;

            /* Precalculate n (Eq. 10.18) */
            n = (sm_a - sm_b) / (sm_a + sm_b);

            /* Precalculate alpha_ (Eq. 10.22) */
            /* (Same as alpha in Eq. 10.17) */
            alpha_ = ((sm_a + sm_b) / 2.0)
                * (1 + (Math.Pow(n, 2.0) / 4) + (Math.Pow(n, 4.0) / 64));

            /* Precalculate y_ (Eq. 10.23) */
            y_ = y / alpha_;

            /* Precalculate beta_ (Eq. 10.22) */
            beta_ = (3.0 * n / 2.0) + (-27.0 * Math.Pow(n, 3.0) / 32.0)
                + (269.0 * Math.Pow(n, 5.0) / 512.0);

            /* Precalculate gamma_ (Eq. 10.22) */
            gamma_ = (21.0 * Math.Pow(n, 2.0) * 0.0625)
                + (-55.0 * Math.Pow(n, 4.0) / 32.0);

            /* Precalculate delta_ (Eq. 10.22) */
            delta_ = (151.0 * Math.Pow(n, 3.0) / 96.0)
                + (-417.0 * Math.Pow(n, 5.0) / 128.0);

            /* Precalculate epsilon_ (Eq. 10.22) */
            epsilon_ = (1097.0 * Math.Pow(n, 4.0) / 512.0);

            /* Now calculate the sum of the series (Eq. 10.21) */
            result = y_ + (beta_ * Math.Sin(2.0 * y_))
                + (gamma_ * Math.Sin(4.0 * y_))
                + (delta_ * Math.Sin(6.0 * y_))
                + (epsilon_ * Math.Sin(8.0 * y_));

            return result;
        }
    }
}