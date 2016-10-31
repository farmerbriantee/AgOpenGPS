//Please, if you use this, share the improvements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public double altitude = 0;
        public double speed = 0;
        public double headingTrue = 0;
        public DateTime utcDateTime;

        //public CPointData(double latitude, double longitude, double northing, double easting, double altitude, double speed, double headingTrue, DateTime utcDateTime)
        public CPointData( double northing, double easting, double speed, double headingTrue)
        {
            //this.latitude = Math.Round(latitude, 7);
            //this.longitude = Math.Round(longitude, 7);
            this.northing = Math.Round(northing, 3);
            this.easting = Math.Round(easting, 3);
            //this.altitude = altitude;
            this.speed = Math.Round(speed,1);
            this.headingTrue = headingTrue;
            //this.utcDateTime = utcDateTime;
        }


    }
}
