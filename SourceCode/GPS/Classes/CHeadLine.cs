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

        public List<CTrackPath> tracksArr = new List<CTrackPath>();

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
        public void SmoothTrack(int smPts)
        {
            if (idx == -1) return;

            //count the reference list of original trk
            int cnt = tracksArr[idx].trackPts.Count;

            //just go back if not very long

            //the temp array
            vec3[] arr = new vec3[cnt];

            //read the points before and after the setpoint
            for (int s = 0; s < smPts / 2; s++)
            {
                arr[s].easting = tracksArr[idx].trackPts[s].easting;
                arr[s].northing = tracksArr[idx].trackPts[s].northing;
                arr[s].heading = tracksArr[idx].trackPts[s].heading;
            }

            for (int s = cnt - (smPts / 2); s < cnt; s++)
            {
                arr[s].easting = tracksArr[idx].trackPts[s].easting;
                arr[s].northing = tracksArr[idx].trackPts[s].northing;
                arr[s].heading = tracksArr[idx].trackPts[s].heading;
            }

            //average them - center weighted average
            for (int i = smPts / 2; i < cnt - (smPts / 2); i++)
            {
                for (int j = -smPts / 2; j < smPts / 2; j++)
                {
                    arr[i].easting += tracksArr[idx].trackPts[j + i].easting;
                    arr[i].northing += tracksArr[idx].trackPts[j + i].northing;
                }
                arr[i].easting /= smPts;
                arr[i].northing /= smPts;
                arr[i].heading = tracksArr[idx].trackPts[i].heading;
            }

            //make a list to draw
            smooList?.Clear();

            if (arr == null || cnt < 1) return;
            if (smooList == null) return;   

            for (int i = 0; i < cnt; i++)
            {
                smooList.Add(arr[i]);
            }
        }

        public void CalculateTurnHeadings()
        {
            //to calc heading based on next and previous points to give an average heading.
            int cnt = tracksArr[idx].trackPts.Count;
            if (cnt > 0)
            {
                vec3[] arr = new vec3[cnt];
                cnt--;
                tracksArr[idx].trackPts.CopyTo(arr);
                tracksArr[idx].trackPts.Clear();

                //middle points
                for (int i = 1; i < cnt; i++)
                {
                    vec3 pt3 = arr[i];
                    pt3.heading = Math.Atan2(arr[i + 1].easting - arr[i - 1].easting, arr[i + 1].northing - arr[i - 1].northing);
                    if (pt3.heading < 0) pt3.heading += glm.twoPI;
                    tracksArr[idx].trackPts.Add(pt3);
                }
            }
        }

        //turning the visual line into the real reference line to use
        public void SaveSmoothAsCurve()
        {
            //oops no smooth list generated
            if (smooList == null) return;
            int cnt = smooList.Count;
            if (cnt == 0) return;

            //eek
            tracksArr[idx].trackPts?.Clear();

            //copy to an array to calculate all the new headings
            vec3[] arr = new vec3[cnt];
            smooList.CopyTo(arr);

            //calculate new headings on smoothed line
            for (int i = 1; i < cnt - 1; i++)
            {
                arr[i].heading = Math.Atan2(arr[i + 1].easting - arr[i].easting, arr[i + 1].northing - arr[i].northing);
                if (arr[i].heading < 0) arr[i].heading += glm.twoPI;
                tracksArr[idx].trackPts.Add(arr[i]);
            }
        }

        public void MoveABCurve(double dist)
        {
            isTrackValid = false;
            lastSecond = 0;

            tracksArr[idx].moveDistance += isHeadingSameWay ? dist : -dist;

            if (tracksArr[idx].moveDistance > 0.5*mf.tool.width) tracksArr[idx].moveDistance -= mf.tool.width;
            else if (tracksArr[idx].moveDistance < -0.5 * mf.tool.width) tracksArr[idx].moveDistance += mf.tool.width;
        }

        public void RemoveMoveDistance()
        {
            isTrackValid = false;
            lastSecond = 0;

            tracksArr[idx].moveDistance = 0;                
        }

        public bool PointOnLine(vec3 pt1, vec3 pt2, vec3 pt)
        {
            vec2 r = new vec2(0, 0);
            if (pt1.northing == pt2.northing && pt1.easting == pt2.easting) { pt1.northing -= 0.00001; }

            double U = ((pt.northing - pt1.northing) * (pt2.northing - pt1.northing)) + ((pt.easting - pt1.easting) * (pt2.easting - pt1.easting));

            double Udenom = Math.Pow(pt2.northing - pt1.northing, 2) + Math.Pow(pt2.easting - pt1.easting, 2);

            U /= Udenom;

            r.northing = pt1.northing + (U * (pt2.northing - pt1.northing));
            r.easting = pt1.easting + (U * (pt2.easting - pt1.easting));

            double minx, maxx, miny, maxy;

            minx = Math.Min(pt1.northing, pt2.northing);
            maxx = Math.Max(pt1.northing, pt2.northing);

            miny = Math.Min(pt1.easting, pt2.easting);
            maxy = Math.Max(pt1.easting, pt2.easting);
            return _ = r.northing >= minx && r.northing <= maxx && (r.easting >= miny && r.easting <= maxy);
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



