using OpenTK.Graphics.OpenGL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public class CHeadLine
    {
        //pointers to mainform controls
        private readonly FormGPS mf;

        //flag for starting stop adding points
        public bool isBtnTrackOn, isOkToAddDesPoints;

        public double distanceFromCurrentLinePivot;
        public double distanceFromRefLine;

        public bool isHeadingSameWay = true;

        public double howManyPathsAway;
        public vec2 refPoint1 = new vec2(1, 1), refPoint2 = new vec2(2, 2);

        public double refHeading, moveOffset=0, mode=0;
        public int currentLocationIndex;

        //pure pursuit values
        public vec2 goalPoint = new vec2(0, 0);

        public vec2 radiusPointCu = new vec2(0, 0);
        public double steerAngle, rEast, rNorth, ppRadius, manualUturnHeading;

        //the list of points of trk to drive on
        public List<vec3> curPts = new List<vec3>();

        public bool isSmoothWindowOpen;
        public List<vec3> smooList = new List<vec3>();

        public List<CHeadPath> tracksArr = new List<CHeadPath>();

        public int idx;

        public bool isTrackValid, isLateralTriggered;

        public double lastSecond = 0;

        public List<vec3> desList = new List<vec3>();

        public double pivotDistanceError, pivotDistanceErrorLast, pivotDerivative, pivotDerivativeSmoothed, lastCurveDistance = 10000;
        //derivative counters
        private int counter2;
        public double inty;

        public bool isAutoTrack = false;

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
            if (cnt > 0)
            {                
                vec3[] arr = new vec3[cnt];
                cnt--;
                xList.CopyTo(arr);
                xList.Clear();

                //middle points
                for (int i = 1; i < cnt; i++)
                {
                    vec3 pt3 = arr[i];
                    pt3.heading = Math.Atan2(arr[i + 1].easting - arr[i - 1].easting, arr[i + 1].northing - arr[i - 1].northing);
                    if (pt3.heading < 0) pt3.heading += glm.twoPI;
                    xList.Add(pt3);
                }
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
                for (int i = 1; i < 1000; i+=5)
                {
                    vec3 pt = new vec3(xList[ptCnt]);
                    pt.easting += (Math.Sin(pt.heading) * i);
                    pt.northing += (Math.Cos(pt.heading) * i);
                    xList.Add(pt);
                }

                //and the beginning
                start = new vec3(xList[0]);

                for (int i = 1; i < 1000; i+=5)
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
    }
}



