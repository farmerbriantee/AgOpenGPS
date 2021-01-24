//Please, if you use this, share the improvements

using System;

namespace AgOpenGPS
{
    public class CPointData
    {
        //WGS84 Lat Long
        public double latitude = 0;

        public double longitude = 0;

        //UTM coordinates
        public double northing = 0;

        public double easting = 0;

        //other GIS Info
        //public double altitude = 0;
        //public double speed = 0;
        //public double headingTrue = 0;
        //public DateTime utcDateTime;

        //public CPointData(double latitude, double longitude, double northing, double easting, double altitude, double speed, double headingTrue, DateTime utcDateTime)
        public CPointData(double _easting, double _northing, double _lati, double _longi)
        {
            latitude = Math.Round(_lati, 7);
            longitude = Math.Round(_longi, 7);
            easting = Math.Round(_easting, 7);
            northing = Math.Round(_northing, 7);
            //altitude = altitude;
            //speed = Math.Round(speed,1);
            //headingTrue = headingTrue;
            //utcDateTime = utcDateTime;
        }
    }
}