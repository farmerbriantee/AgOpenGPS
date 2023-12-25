using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public class CHeadLine
    {
        //pointers to mainform controls
        private readonly FormGPS mf;

        public List<CHeadPath> tracksArr = new List<CHeadPath>();

        public int idx;

        public List<vec3> desList = new List<vec3>();

        public CHeadLine(FormGPS _f)
        {
            //constructor
            mf = _f;
        }

        //for calculating for display the averaged new line

        public void CalculateHeadings(ref List<vec3> xList)
        {
            //to calc heading based on next and previous points to give an average heading.
            int cnt = xList.Count;
            if (cnt > 3)
            {
                vec3[] arr = new vec3[cnt];
                cnt--;
                xList.CopyTo(arr);
                xList.Clear();

                vec3 pt3 = arr[0];
                pt3.heading = Math.Atan2(arr[1].easting - arr[0].easting, arr[1].northing - arr[0].northing);
                if (pt3.heading < 0) pt3.heading += glm.twoPI;
                xList.Add(pt3);

                //middle points
                for (int i = 1; i < cnt; i++)
                {
                    pt3 = arr[i];
                    pt3.heading = Math.Atan2(arr[i + 1].easting - arr[i - 1].easting, arr[i + 1].northing - arr[i - 1].northing);
                    if (pt3.heading < 0) pt3.heading += glm.twoPI;
                    xList.Add(pt3);
                }

                pt3 = arr[arr.Length - 1];
                pt3.heading = Math.Atan2(arr[arr.Length - 1].easting - arr[arr.Length - 2].easting,
                    arr[arr.Length - 1].northing - arr[arr.Length - 2].northing);
                if (pt3.heading < 0) pt3.heading += glm.twoPI;
                xList.Add(pt3);
            }
        }

        //add extensons
        public void AddFirstLastPoints(ref List<vec3> xList)
        {
            int ptCnt = xList.Count - 1;
            vec3 start = new vec3(xList[0]);

            if (mf.bnd.bndList.Count > 0)
            {
                //end
                while (mf.bnd.bndList[0].fenceLineEar.IsPointInPolygon(xList[xList.Count - 1]))
                {
                    for (int i = 1; i < 10; i++)
                    {
                        vec3 pt = new vec3(xList[ptCnt]);
                        pt.easting += (Math.Sin(pt.heading) * i);
                        pt.northing += (Math.Cos(pt.heading) * i);
                        xList.Add(pt);
                    }
                    ptCnt = xList.Count - 1;
                }

                //and the beginning
                start = new vec3(xList[0]);

                while (mf.bnd.bndList[0].fenceLineEar.IsPointInPolygon(xList[0]))
                {
                    for (int i = 1; i < 10; i++)
                    {
                        vec3 pt = new vec3(start);
                        pt.easting -= (Math.Sin(pt.heading) * i);
                        pt.northing -= (Math.Cos(pt.heading) * i);
                        xList.Insert(0, pt);
                    }
                    start = new vec3(xList[0]);
                }
            }
            else
            {
                for (int i = 1; i < 1000; i += 5)
                {
                    vec3 pt = new vec3(xList[ptCnt]);
                    pt.easting += (Math.Sin(pt.heading) * i);
                    pt.northing += (Math.Cos(pt.heading) * i);
                    xList.Add(pt);
                }

                //and the beginning
                start = new vec3(xList[0]);

                for (int i = 1; i < 1000; i += 5)
                {
                    vec3 pt = new vec3(start);
                    pt.easting -= (Math.Sin(pt.heading) * i);
                    pt.northing -= (Math.Cos(pt.heading) * i);
                    xList.Insert(0, pt);
                }
            }
        }
    }

    public class CHeadPath
    {
        public List<vec3> trackPts = new List<vec3>();
        public string name = "aa";
        public double moveDistance = 0;
        public int mode = 0;
        public int a_point = 0;
    }
}