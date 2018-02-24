using System;
using System.Globalization;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormBoundary : Form
    {
        private readonly FormGPS mf = null;

        public FormBoundary(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void FormBoundary_Load(object sender, EventArgs e)
        {
            btnLeftRight.Image = mf.boundz.isDrawRightSide ? Properties.Resources.BoundaryRight
                            : Properties.Resources.BoundaryLeft;
            btnLeftRight.Enabled = false;

            if (mf.boundz.isSet)
            {
                btnOuter.Enabled = false;
                btnLoadBoundaryFromGE.Enabled = false;
                btnOpenGoogleEarth.Enabled = false;
                btnSerialOK.Enabled = false;
                btnDelete.Enabled = true;
            }
            else
            {
                btnOuter.Enabled = true;
                btnLoadBoundaryFromGE.Enabled = true;
                btnOpenGoogleEarth.Enabled = true;
                btnSerialOK.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnOuter_Click(object sender, EventArgs e)
        {
            btnLeftRight.Enabled = true;
            btnLoadBoundaryFromGE.Enabled = false;
            btnOpenGoogleEarth.Enabled = false;
            btnOuter.Enabled = false;
            btnSerialOK.Enabled = true;
            mf.boundz.ResetBoundary();
        }

        private void btnSerialCancel_Click(object sender, EventArgs e)
        {
            mf.boundz.isOkToAddPoints = false;
        }

        private void btnLeftRight_Click(object sender, EventArgs e)
        {
            mf.boundz.isDrawRightSide = !mf.boundz.isDrawRightSide;

            btnLeftRight.Image = mf.boundz.isDrawRightSide ? Properties.Resources.BoundaryRight : Properties.Resources.BoundaryLeft;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnLeftRight.Enabled = false;
            btnOuter.Enabled = true;
            btnLoadBoundaryFromGE.Enabled = true;
            btnOpenGoogleEarth.Enabled = true;
            btnSerialOK.Enabled = false;
            btnDelete.Enabled = false;

            mf.boundz.ResetBoundary();
            mf.FileSaveOuterBoundary();

            btnLeftRight.Image = mf.boundz.isDrawRightSide ? Properties.Resources.BoundaryRight : Properties.Resources.BoundaryLeft;
        }

        private double easting, northing, latK, lonK;

        private void btnLoadBoundaryFromGE_Click(object sender, EventArgs e)
        {
            string fileAndDirectory;
            {
                //create the dialog instance
                OpenFileDialog ofd = new OpenFileDialog
                {
                    //set the filter to text KML only
                    Filter = "KML files (*.KML)|*.KML",

                    //the initial directory, fields, for the open dialog
                    InitialDirectory = mf.fieldsDirectory + mf.currentFieldDirectory
                };

                //was a file selected
                if (ofd.ShowDialog() == DialogResult.Cancel) return;
                else fileAndDirectory = ofd.FileName;
            }

            //start to read the file
            string line = null;
            int index;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(fileAndDirectory))
            {
                bool done = false;
                try
                {
                    while (!reader.EndOfStream && !done)
                    {
                        line = reader.ReadLine();
                        index = line.IndexOf("coord");

                        if (index != -1)
                        {
                            line = reader.ReadLine();
                            line = line.Trim();
                            string[] numberSets = line.Split(' ');
                            done = true;

                            //at least 3 points
                            if (numberSets.Length > 2)
                            {
                                //reset boundary
                                mf.boundz.ResetBoundary();
                                foreach (var item in numberSets)
                                {
                                    string[] fix = item.Split(',');
                                    double.TryParse(fix[0], NumberStyles.Float, CultureInfo.InvariantCulture, out lonK);
                                    double.TryParse(fix[1], NumberStyles.Float, CultureInfo.InvariantCulture, out latK);
                                    DecDeg2UTM(latK, lonK);
                                    vec3 bndPt = new vec3(easting, northing, 0);

                                    //TODO - calculate heading!
                                    mf.boundz.ptList.Add(bndPt);
                                }
                                mf.boundz.CalculateBoundaryArea();
                                mf.boundz.PreCalcBoundaryLines();
                                mf.boundz.isSet = true;
                                mf.FileSaveOuterBoundary();
                                Close();
                            }
                            else
                            {
                                mf.TimedMessageBox(2000, "Error reading KML", "Choose or Build a Different one");
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private const double sm_a = 6378137.0;
        private const double sm_b = 6356752.314;
        private const double UTMScaleFactor = 0.9996;

        public void DecDeg2UTM(double latitude, double longitude)
        {
            //zone = Math.Floor((longitude + 180.0) * 0.16666666666666666666666666666667) + 1;
            GeoUTMConverterXY(latitude * 0.01745329251994329576923690766743,
                                longitude * 0.01745329251994329576923690766743);
        }

        private void btnOpenGoogleEarth_Click(object sender, EventArgs e)
        {
            //save new copy of kml with selected flag and view in GoogleEarth
            mf.FileMakeCurrentKML(mf.pn.latitude, mf.pn.longitude);

            //Process.Start(@"C:\Program Files (x86)\Google\Google Earth\client\googleearth", workingDirectory + currentFieldDirectory + "\\Flags.KML");
            System.Diagnostics.Process.Start(mf.fieldsDirectory + mf.currentFieldDirectory + "\\CurrentPosition.KML");
        }

        private double ArcLengthOfMeridian(double phi)
        {
            const double n = (sm_a - sm_b) / (sm_a + sm_b);
            double alpha = ((sm_a + sm_b) / 2.0) * (1.0 + (Math.Pow(n, 2.0) / 4.0) + (Math.Pow(n, 4.0) / 64.0));
            double beta = (-3.0 * n / 2.0) + (9.0 * Math.Pow(n, 3.0) * 0.0625) + (-3.0 * Math.Pow(n, 5.0) / 32.0);
            double gamma = (15.0 * Math.Pow(n, 2.0) * 0.0625) + (-15.0 * Math.Pow(n, 4.0) / 32.0);
            double delta = (-35.0 * Math.Pow(n, 3.0) / 48.0) + (105.0 * Math.Pow(n, 5.0) / 256.0);
            double epsilon = (315.0 * Math.Pow(n, 4.0) / 512.0);
            return alpha * (phi + (beta * Math.Sin(2.0 * phi))
                    + (gamma * Math.Sin(4.0 * phi))
                    + (delta * Math.Sin(6.0 * phi))
                    + (epsilon * Math.Sin(8.0 * phi)));
        }

        private double[] MapLatLonToXY(double phi, double lambda, double lambda0)
        {
            double[] xy = new double[2];
            double ep2 = (Math.Pow(sm_a, 2.0) - Math.Pow(sm_b, 2.0)) / Math.Pow(sm_b, 2.0);
            double nu2 = ep2 * Math.Pow(Math.Cos(phi), 2.0);
            double n = Math.Pow(sm_a, 2.0) / (sm_b * Math.Sqrt(1 + nu2));
            double t = Math.Tan(phi);
            double t2 = t * t;
            double l = lambda - lambda0;
            double l3Coef = 1.0 - t2 + nu2;
            double l4Coef = 5.0 - t2 + (9 * nu2) + (4.0 * (nu2 * nu2));
            double l5Coef = 5.0 - (18.0 * t2) + (t2 * t2) + (14.0 * nu2) - (58.0 * t2 * nu2);
            double l6Coef = 61.0 - (58.0 * t2) + (t2 * t2) + (270.0 * nu2) - (330.0 * t2 * nu2);
            double l7Coef = 61.0 - (479.0 * t2) + (179.0 * (t2 * t2)) - (t2 * t2 * t2);
            double l8Coef = 1385.0 - (3111.0 * t2) + (543.0 * (t2 * t2)) - (t2 * t2 * t2);

            /* Calculate easting (x) */
            xy[0] = (n * Math.Cos(phi) * l)
                + (n / 6.0 * Math.Pow(Math.Cos(phi), 3.0) * l3Coef * Math.Pow(l, 3.0))
                + (n / 120.0 * Math.Pow(Math.Cos(phi), 5.0) * l5Coef * Math.Pow(l, 5.0))
                + (n / 5040.0 * Math.Pow(Math.Cos(phi), 7.0) * l7Coef * Math.Pow(l, 7.0));

            /* Calculate northing (y) */
            xy[1] = ArcLengthOfMeridian(phi)
                + (t / 2.0 * n * Math.Pow(Math.Cos(phi), 2.0) * Math.Pow(l, 2.0))
                + (t / 24.0 * n * Math.Pow(Math.Cos(phi), 4.0) * l4Coef * Math.Pow(l, 4.0))
                + (t / 720.0 * n * Math.Pow(Math.Cos(phi), 6.0) * l6Coef * Math.Pow(l, 6.0))
                + (t / 40320.0 * n * Math.Pow(Math.Cos(phi), 8.0) * l8Coef * Math.Pow(l, 8.0));

            return xy;
        }

        private void GeoUTMConverterXY(double lat, double lon)
        {
            double[] xy = MapLatLonToXY(lat, lon, (-183.0 + (mf.pn.zone * 6.0)) * 0.01745329251994329576923690766743);

            xy[0] = (xy[0] * UTMScaleFactor) + 500000.0;
            xy[1] *= UTMScaleFactor;
            if (xy[1] < 0.0)
                xy[1] += 10000000.0;

            //keep a copy of actual easting and northings
            //actualEasting = xy[0];
            //actualNorthing = xy[1];

            //if a field is open, the real one is subtracted from the integer
            easting = xy[0] - mf.pn.utmEast;
            northing = xy[1] - mf.pn.utmNorth;
        }
    }
}