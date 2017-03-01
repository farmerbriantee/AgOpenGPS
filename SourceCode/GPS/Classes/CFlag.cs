using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgOpenGPS
{
    class CFlag
    {
        //WGS84 Lat Long
        public double latitude = 0;
        public double longitude = 0;

        //UTM coordinates
        public double northing = 0;
        public double easting = 0;

        //color of the flag - 0 is red, 1 is green, 2 is purple
        public int color = 0;

        public int ID = 0;

        //constructor
        public CFlag(double lati, double longi, double easting, double northing, int color, int ID)
        {
            this.latitude = Math.Round(lati, 7);
            this.longitude = Math.Round(longi, 7);
            this.easting = Math.Round(easting, 7);
            this.northing = Math.Round(northing, 7);
            this.color = color;
            this.ID = ID;

        }

    }
}
