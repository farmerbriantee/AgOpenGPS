using SharpKml.Dom;
using SharpKml.Engine;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgOpenGPS.prescription
{
    
    class CKmlHelper
    {
        // Helper class for KML handling and conversions (e.g. LatLong -> UTC)

        private static FormGPS mf;
        private static CKmlHelper instance;


        public static void initialize(FormGPS mf)
        {
            // set reference to Master Form 
            CKmlHelper.mf = mf;
        }

        public static CKmlHelper getInstance()
        {
            // create instance if not yet happened
            if (CKmlHelper.instance is null)
            {
                // create instance
                CKmlHelper.instance = new CKmlHelper();
            }

            // check if class have been initialized / reference to master form is existing
            if (CKmlHelper.mf is null)
            {
                throw new Exception("CKmlHelper was not initialized!");
            }

            // return instance
            return CKmlHelper.instance;

        }

        public vec3 convertKMLpoint2vec(string kmlTriple)
        {
            // convert KML String in format "longitude,latitude,altitude" to UTM, return vec3
            double[] xy = convertKMLpoint2easting_northing(kmlTriple);
            return new vec3(xy[0], xy[1], 0);
        }

        public vec3 convertKMLpoint2vec(double lonK, double latK)
        {
            // convert KML String in format "longitude,latitude,altitude" to UTM, return vec3
            double[] xy = convertKMLpoint2easting_northing(lonK, latK);
            return new vec3(xy[0], xy[1], 0);
        }


        public double[] convertKMLpoint2easting_northing(string kmlTriple)
        {
            // convert KML String in format "longitude,latitude,altitude" to UTM, return easting, northing
            string[] fix = kmlTriple.Split(',');
            double lonK;
            double.TryParse(fix[0], NumberStyles.Float, CultureInfo.InvariantCulture, out lonK);
            double latK;
            double.TryParse(fix[1], NumberStyles.Float, CultureInfo.InvariantCulture, out latK);

            return convertKMLpoint2easting_northing(lonK, latK);


        }
        public double[] convertKMLpoint2easting_northing(double lonK, double latK)
        {
            double[] xy = mf.pn.DecDeg2UTM(latK, lonK);

            //match new fix to current position
            double easting = xy[0] - mf.pn.utmEast;
            double northing = xy[1] - mf.pn.utmNorth;

            double east = easting;
            double nort = northing;

            //fix the azimuth error
            easting = (Math.Cos(-mf.pn.convergenceAngle) * east) - (Math.Sin(-mf.pn.convergenceAngle) * nort);
            northing = (Math.Sin(-mf.pn.convergenceAngle) * east) + (Math.Cos(-mf.pn.convergenceAngle) * nort);

            double[] coords = new double[2];
            coords[0] = easting;
            coords[1] = northing;

            return coords;

        }

        public bool loadKMLFile(out Kml kml)
        {
            string fileAndDirectory;

            //-- open file dialog
            OpenFileDialog ofd = new OpenFileDialog
            {
                //set the filter to text KML only
                Filter = "KML files (*.KML)|*.KML",

            };

            //-- was a file selected
            if (ofd.ShowDialog() == DialogResult.Cancel)
            {
                kml = null;
                return false;
            }
            else
            {
                fileAndDirectory = ofd.FileName;
            }

            System.IO.StreamReader reader = new System.IO.StreamReader(fileAndDirectory);
            KmlFile file = KmlFile.Load(reader);
            kml = file.Root as Kml;
            return true;
        }

    }
}
