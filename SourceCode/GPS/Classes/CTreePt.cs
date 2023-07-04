using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgOpenGPS
{
    public class CTreePt
    {
        private readonly FormGPS mf;
        public double altitude { get; set; }
        public double easting { get; set; }
        public double northing { get; set; }
        public double heading { get; set; }
        public double cutAltitude { get; set; }
        public double lastPassAltitude { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double distance { get; set; }

        public bool isPlanted = false;
        public bool isclose = false;
        public bool isReference = false;
        public bool isSelected = false;
        public bool istrolling = false;

        public string datePlanted = "";
        public string datePlanned = "";




        public int index = 0;
        public string comment;

        //constructor
        public CTreePt(FormGPS _f)
        {
            mf = _f;
            //if (mf != null)
            //{
            //    gl = _gl;
            //}
        }
        public CTreePt(double _easting, double _heading, double _northing, double _lat, double _long)
        {
            easting = _easting;
            northing = _northing;
            heading = _heading;

            //optional parameters

            isPlanted = false;
            isclose = false;
            isReference = false;
            comment = "Tree";
            isSelected = false;
            datePlanned = DateTime.Now.ToString("yyyy-MMMM-dd");
            datePlanted = "";





            latitude = _lat;
            longitude = _long;

            index = 0;

        }
    }
    public class CTree
    {

        private readonly FormGPS mf;
        private double easting, norting, latK, lonK;
        public bool isPlanting = false;
        public bool isSound = true;
        public bool isTreeClose = false;
        public int treeRadi = 10;

        public double cosSectionHeading = 1.0, sinSectionHeading = 0.0;
        public double cosSectionHeading90 = -1.0, sinSectionHeading90 = 0.0;

        public List<CTreePt> ptList = new List<CTreePt>();



        public CTree(FormGPS _f)
        {
            mf = _f;
            //if (mf != null)
            //{
            //    gl = _gl;
            //}
        }




        public void AddPoint(double _easting, double _northing)
        {
            double east = _easting;
            double nort = _northing;

            //fix the azimuth error
            //double eastingTemp = (Math.Cos(mf.pn.convergenceAngle) * east) - (Math.Sin(mf.pn.convergenceAngle) * nort);
            //double northingTemp = (Math.Sin(mf.pn.convergenceAngle) * east) + (Math.Cos(mf.pn.convergenceAngle) * nort);

            //eastingTemp += mf.pn.utmEast;
            //northingTemp += mf.pn.utmNorth;

            //mf.UTMToLatLon(eastingTemp, northingTemp);

            //double latitude = mf.utmLat;
            //double longitude = mf.utmLon;

            double lat = 0;
            double lon = 0;

            mf.pn.ConvertLocalToWGS84(nort, east, out lat, out lon);

            CTreePt point = new CTreePt(_easting, 0, _northing, lat, lon);
            ptList.Add(point);           
            ptList[ptList.Count - 1].index = ptList.Count;
            
        }

        public void DrawTrees()
        {

           
            int ptCount = ptList.Count;
           

            GL.LineWidth(1);
           

                ptCount = ptList.Count;
                if (ptCount > 0)
                {

                    double toole = 1;

                    for (int i = 0; i < ptCount; i++)
                    {

                        float green = Convert.ToSingle(256 / 256);
                        float red = Convert.ToSingle(256 / 256);
                        float blue = Convert.ToSingle(256 / 256);
                        sinSectionHeading = Math.Sin(ptList[i].heading);
                        cosSectionHeading = Math.Cos(ptList[i].heading);
                        sinSectionHeading90 = Math.Sin(-ptList[i].heading);
                        cosSectionHeading90 = Math.Cos(-ptList[i].heading);

                        GL.LineWidth(1);
                        GL.Color3(.8, .8, .8);

                        
                       
                        GL.Begin(PrimitiveType.Lines);
                        GL.Vertex3((cosSectionHeading * -toole / 2) + ptList[i].easting,
                           (sinSectionHeading * -toole / 2) + ptList[i].northing, 0);
                        GL.Vertex3((cosSectionHeading * toole / 2) + ptList[i].easting,
                           (sinSectionHeading * toole / 2) + ptList[i].northing, 0);
                        GL.Vertex3((sinSectionHeading90 * -toole / 2) + ptList[i].easting,
                       (cosSectionHeading90 * -toole / 2) + ptList[i].northing, 0);
                        GL.Vertex3((sinSectionHeading90 * toole / 2) + ptList[i].easting,
                           (cosSectionHeading90 * toole / 2) + ptList[i].northing, 0);
                        GL.End();

                    }

                }

            


        }


    }

}
