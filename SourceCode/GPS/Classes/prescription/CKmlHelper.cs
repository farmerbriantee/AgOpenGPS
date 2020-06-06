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
    /// <summary>
    /// Helper class for KML handling and conversion
    /// Uses SharpKML
    /// </summary>
    class CKmlHelper
    {
        private static FormGPS mf;  // reference to master form
        private static CKmlHelper instance; // singleton instance

        /// <summary>
        /// Initialize the helper class with a reference to the AGO mater form (needed for re-use of the conversion logic)
        /// Must be called once
        /// </summary>
        /// <param name="mf"></param>
        public static void initialize(FormGPS mf)
        {
            // set reference to Master Form 
            CKmlHelper.mf = mf;
        }

        /// <summary>
        /// Get an instance of the Helper class
        /// </summary>
        /// <returns>instance</returns>
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

        /// <summary>
        /// Convert a point / KML string "long,lat,alt" to a UTM Vec used in AGO
        /// </summary>
        /// <param name="kmlTriple"></param>
        /// <returns></returns>
        public vec3 convertKMLpoint2vec(string kmlTriple)
        {
            // convert KML String in format "longitude,latitude,altitude" to UTM, return vec3
            double[] xy = convertKMLpoint2easting_northing(kmlTriple);
            return new vec3(xy[0], xy[1], 0);
        }

        /// <summary>
        /// Convert KML point to a UTM Vec
        /// </summary>
        /// <param name="lonK">Longitude</param>
        /// <param name="latK">Latitude</param>
        /// <returns>Vector (altitude 0)</returns>
        public vec3 convertKMLpoint2vec(double lonK, double latK)
        {
            // convert KML String in format "longitude,latitude,altitude" to UTM, return vec3
            double[] xy = convertKMLpoint2easting_northing(lonK, latK);
            return new vec3(xy[0], xy[1], 0);
        }

        /// <summary>
        /// Convert KML point to easting/northing array; altitude is dropped
        /// </summary>
        /// <param name="kmlTriple">kmlString (longitude, latitude, altitude)</param>
        /// <returns></returns>
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
        /// <summary>
        /// Convert Longitude, Latitude to Easting, Northing
        /// </summary>
        /// <param name="lonK">Longitude</param>
        /// <param name="latK">Latitude</param>
        /// <returns></returns>
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

        /// <summary>
        /// Load a KML file and return an KML object
        /// </summary>
        /// <param name="kml">KML object</param>
        /// <returns>True if file was loaded</returns>
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
