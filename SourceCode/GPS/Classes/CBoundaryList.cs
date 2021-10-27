using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public partial class CBoundaryList
    {
        //list of coordinates of boundary line
        public List<vec3> fenceLine = new List<vec3>(128);
        public List<vec2> fenceLineEar = new List<vec2>(128);
        public List<vec3> hdLine = new List<vec3>(128);
        public List<vec3> turnLine = new List<vec3>(128);


        //constructor
        public CBoundaryList()
        {
            area = 0;
            isDriveAround = false;
            isDriveThru = false;
        }

        public bool IsPointInPolygon(vec3 testPoint, ref List<vec3> polygon)
        {
            bool result = false;
            int j = polygon.Count - 1;
            for (int i = 0; i < polygon.Count; i++)
            {
                if ((polygon[i].easting < testPoint.easting && polygon[j].easting >= testPoint.easting)
                    || (polygon[j].easting < testPoint.easting && polygon[i].easting >= testPoint.easting))
                {
                    if (polygon[i].northing + (testPoint.easting - polygon[i].easting)
                        / (polygon[j].easting - polygon[i].easting) * (polygon[j].northing - polygon[i].northing)
                        < testPoint.northing)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }

        public bool IsPointInPolygon(vec2 testPoint, ref List<vec3> polygon)
        {
            bool result = false;
            int j = polygon.Count - 1;
            for (int i = 0; i < polygon.Count; i++)
            {
                if ((polygon[i].easting < testPoint.easting && polygon[j].easting >= testPoint.easting)
                    || (polygon[j].easting < testPoint.easting && polygon[i].easting >= testPoint.easting))
                {
                    if (polygon[i].northing + (testPoint.easting - polygon[i].easting)
                        / (polygon[j].easting - polygon[i].easting) * (polygon[j].northing - polygon[i].northing)
                        < testPoint.northing)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }
        public bool IsPointInPolygon(vec2 testPoint, ref List<vec2> polygon)
        {
            bool result = false;
            int j = polygon.Count - 1;
            for (int i = 0; i < polygon.Count; i++)
            {
                if ((polygon[i].easting < testPoint.easting && polygon[j].easting >= testPoint.easting)
                    || (polygon[j].easting < testPoint.easting && polygon[i].easting >= testPoint.easting))
                {
                    if (polygon[i].northing + (testPoint.easting - polygon[i].easting)
                        / (polygon[j].easting - polygon[i].easting) * (polygon[j].northing - polygon[i].northing)
                        < testPoint.northing)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }
        public bool IsPointInPolygon(vec3 testPoint, ref List<vec2> polygon)
        {
            bool result = false;
            int j = polygon.Count - 1;
            for (int i = 0; i < polygon.Count; i++)
            {
                if ((polygon[i].easting < testPoint.easting && polygon[j].easting >= testPoint.easting)
                    || (polygon[j].easting < testPoint.easting && polygon[i].easting >= testPoint.easting))
                {
                    if (polygon[i].northing + (testPoint.easting - polygon[i].easting)
                        / (polygon[j].easting - polygon[i].easting) * (polygon[j].northing - polygon[i].northing)
                        < testPoint.northing)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }
    }
}