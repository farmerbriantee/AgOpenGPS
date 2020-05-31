using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Audio.OpenAL;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using SharpKml.Base;
using SharpKml.Dom;
using SharpKml.Engine;

namespace AgOpenGPS.prescription
{
    /// <summary>
    /// Prescription Manager <br></br>
    /// prescription = a set of rules on how the jop is applied to the field, e.g. only apply to a specific area
    /// or apply in a certain degree (e.g. 75% or specific seeding quantity - to be developed!)
    /// </summary>
    public class CPrescriptionManager
    {
        // reference to master form (AOG best practice)
        private FormGPS mf;

        // is prescription active?
        private bool isActive = false;

        //Rules
        List<CPrescriptionRule> prescriptionRules = new List<CPrescriptionRule>();

        public bool IsActive { get => isActive; set => isActive = value; }

        public CPrescriptionManager(FormGPS mf)
        {
            // reference to master form
            this.mf = mf;
            // init KMLHelper
            CKmlHelper.initialize(mf);
        }

        public void PaintPolygons()
        {
            // paints polygons in OpenGL for polygons defined in the description rules
            foreach(CPrescriptionRule rule in this.prescriptionRules)
            {
                GL.Begin(PrimitiveType.Polygon); 
                GL.Color4(rule.getColor()); // get color - green value represents percentage
                foreach(vec3 vertex in rule.vertexList)
                {
                    GL.Vertex3(vertex.easting, vertex.northing, 0);
                }
                GL.End();
            }
        }

        /// <summary>
        /// Check if Work shall be applied to the specific pixel by checking the "green value" of the pixel
        /// if there is no prescription active, then work should be applied everywhere where the pixel is not green (standard AGO)
        /// if a prescription is active, work should only be applied where a prescription polygon has been painted before
        /// the green value of the polygon indicates the degree (1-100 percent)
        /// </summary>
        /// <param name="grnPixel">green pixel</param>
        /// <param name="degree">degree to apply work</param>
        /// <returns>true = work shall be applied<br></br> false = already done</returns>
        public bool isApplyWork(byte grnPixel, out int degree)
        {
            
            if(IsActive)
            {
                // Prescription active
                if(grnPixel >= 1 && grnPixel <= 100)
                {
                    // pixel between 1 and 100 --> this is the percentage of a prescription rule, apply work!
                    degree = (int)grnPixel;
                    return true;
                }
                else
                {
                    //other
                    degree = 0;
                    return false;
                }
            }
            else
            {
                // Prescription inactive, AGO standard
                degree = 100;
                return grnPixel == 0 ? true : false;  // if pixel is 0, return true
            }

        }
        /// <summary>
        /// Check if Work shall be applied to the specific pixel by checking the "green value" of the pixel
        /// if there is no prescription active, then work should be applied everywhere where the pixel is not green (standard AGO)
        /// if a prescription is active, work should only be applied where a prescription polygon has been painted before
        /// </summary>
        /// <param name="grnPixel"></param>
        /// <returns>true = work shall be applied<br></br> false = already done</returns>
        public bool isApplyWork(byte grnPixel)
        {
            return isApplyWork(grnPixel, out _);
        }

        /// <summary>
        /// Turn off prescription
        /// </summary>
        public void turnOff()
        {
            this.IsActive = false;
            // remove rules
            prescriptionRules.Clear();
        }
        /// <summary>
        /// Turn on prescription
        /// </summary>
        public void turnOn()
        {
            this.IsActive = true;
        }


        public void addPrescription()
        {
            // List for Polygon Import Errors
            List<Polygon> polygonsWithError = new List<Polygon>();

            // open file dialog to load KML
            if(CKmlHelper.getInstance().loadKMLFile(out Kml kml))
            {
               if(kml != null)
                {
                    // get all polygons inside
                    foreach(var poly in kml.Flatten().OfType<Polygon>())
                    {
                        // get outer boundary coords
                        List<Vector> vec = poly.OuterBoundary.LinearRing.Coordinates.ToList();
                        // check if polygon is convex - only convex polygons supported up to now
                        if (isConvex(vec))
                        {
                            // create a rule for each polygon
                            CPrescriptionRule rule = new CPrescriptionRule();
                            foreach (Vector v in vec)
                            {
                                // add a vertex for each coord
                                rule.addVertex(CKmlHelper.getInstance().convertKMLpoint2vec(v.Longitude, v.Latitude));
                            }
                            // add rule
                            prescriptionRules.Add(rule);
                        }
                        else
                        {
                            // not convex polygion - add polygon to Error Buffer
                            polygonsWithError.Add(poly);
                        }
                    }
                }

                // give message if there were import errors
                if (polygonsWithError.Count > 0)
                {
                    StringBuilder msg = new StringBuilder();
                    foreach(Polygon pErr in polygonsWithError){
                        Placemark place = pErr.GetParent<Placemark>();
                        // polygon is not convex, throw an error / show message
                        msg.AppendLine("Placemark " + place.Name + " contains a not convex polygon. Polygon skipped.");
                    }
                    //Message Box
                    MessageBox.Show(msg.ToString(), "Import Errors occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //set active
            turnOn();
        }

        /// <summary>
        /// Check if Polygon is convex - only convex polygons support up to now
        /// </summary>
        /// <param name="vecs"></param>
        /// <returns></returns>
        public bool isConvex(List<Vector> vecs)
        {
            // all credits go to Rod Stephaens http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/
            // For each set of three adjacent points A, B, C,
            // find the dot product AB · BC. If the sign of
            // all the dot products is the same, the angles
            // are all positive or negative (depending on the
            // order in which we visit them) so the polygon
            // is convex.
            bool got_negative = false;
            bool got_positive = false;
            int num_points = vecs.Count;
            int B, C;
            for (int A = 0; A < num_points; A++)
            {
                B = (A + 1) % num_points;
                C = (B + 1) % num_points;

                double cross_product =
                    CrossProductLength(
                        vecs[A].Latitude, vecs[A].Longitude,
                        vecs[B].Latitude, vecs[B].Longitude,
                        vecs[C].Latitude, vecs[C].Longitude);
                if (cross_product < 0)
                {
                    got_negative = true;
                }
                else if (cross_product > 0)
                {
                    got_positive = true;
                }
                if (got_negative && got_positive) return false;
            }

            // If we got this far, the polygon is convex.
            return true;
        }

        public static double CrossProductLength(double Ax, double Ay,
            double Bx, double By, double Cx, double Cy)
        {
            // all credits go to Rod Stephaens http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/
            // Return the cross product AB x BC.
            // The cross product is a vector perpendicular to AB
            // and BC having length |AB| * |BC| * Sin(theta) and
            // with direction given by the right-hand rule.
            // For two vectors in the X-Y plane, the result is a
            // vector with X and Y components 0 so the Z component
            // gives the vector's length and direction.

            // Get the vectors' coordinates.
            double BAx = Ax - Bx;
            double BAy = Ay - By;
            double BCx = Cx - Bx;
            double BCy = Cy - By;

            // Calculate the Z coordinate of the cross product.
            return (BAx * BCy - BAy * BCx);
        }



    }

    public class CPrescriptionRule
    {
        // Prescription Rule
        // A prescription rule consists of a geometry (polygon) and (for now) of a percentage on how to apply a current job (e.g. seeding, spraying)

        // Vertices of the polygon
        public readonly List<vec3> vertexList = new List<vec3>();
        // Degree to apply the job (for now percent, always 100)
        public readonly int degree = 100;

        public Color4 getColor()
        {
            // get Color this rule when the polygon is painted
            // the color reflects the degree/percentage as green value
            // the green value is used in the openGL control / backbuffer for collison detection (to check if we are inside the polygon)
            return new Color4((byte)255, (byte)this.degree, (byte)0, (byte)80);
        }

        public void addVertex(vec3 vertex)
        {
            vertexList.Add(vertex);
        }

    }
}
