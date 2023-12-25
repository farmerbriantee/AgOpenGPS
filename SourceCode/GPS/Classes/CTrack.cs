using OpenTK.Graphics.OpenGL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public enum TrackMode { None = 0, AB = 2, Curve = 4, bndTrackOuter = 8, bndTrackInner = 16, bndCurve = 32};//, Heading, Circle, Spiral

    public class CTrack
    {
        //pointers to mainform controls
        private readonly FormGPS mf;

        public List<CTrk> gArr = new List<CTrk>();

        public int idx;

        public bool isLine;

        public bool isAutoTrack = false, isAutoSnapToPivot = false;

        public CTrack(FormGPS _f)
        {
            //constructor
            mf = _f;
            idx = -1;
        }

        public bool LoadABLine(int idx)
        {
            //if (mf.trk.gArr[idx].isVisible)
            //{
            //    refPtA = mf.trk.gArr[idx].ptA;
            //    abHeading = mf.trk.gArr[idx].heading;
            //    SetABLineByHeading();
            //    isABLineSet = true;
            //    mf.yt.ResetYouTurn();
            //    mf.guidanceLineText = mf.trk.gArr[idx].name;
            //    return true;
            //}
            //else
            { return false; }
        }
        public void LoadCurve(int idx)
        {
            //refCurve.heading = mf.trk.gArr[idx].heading;
            //refCurve.curvePts?.Clear();
            //for (int i = 0; i < mf.trk.gArr[idx].curvePts.Count; i++)
            //{
            //    refCurve.curvePts.Add(mf.trk.gArr[idx].curvePts[i]);
            //}
            //isCurveSet = true;
            //mf.yt.ResetYouTurn();
            //mf.guidanceLineText = mf.trk.gArr[idx].name;
        }


        public int FindNextVisibleLine()
        {
            //while (true)
            //{
            //    numABLineSelected++;

            //    if (numABLineSelected > numABLines) numABLineSelected = 1;

            //    if (mf.trk.gArr[numABLineSelected - 1].isVisible) return numABLineSelected;
            //}
            return 0;
        }
    }
    public class CTrk
    {
        public List<vec3> curvePts = new List<vec3>();
        public double heading = 3;
        public string name = "aa";
        public bool isVisible = true;
        public vec2 ptA = new vec2();
        public vec2 ptB = new vec2();
        public int mode = 0;
        public double nudgeDistance = 0;
    }
}

        //public int FindClosestRefTrack(vec3 pivot)
        //{
        //    //ABDraw is open
        //    Form fcs = Application.OpenForms["FormABDraw"];

        //    if (fcs != null)
        //    {
        //        return idx;
        //    }

        //    //no tracks check
        //    if (tracksArr.Count == 0) return idx;

        //    //only 1 track
        //    if (tracksArr.Count == 1) return idx;

        //    int trak = -1;
        //    int cntr = 0;

        //    //Count visible
        //    for (int i = 0; i < tracksArr.Count; i++)
        //    {
        //        if (tracksArr[i].isVisible)
        //        {
        //            cntr++;
        //            trak = i;
        //        }
        //    }

        //    //only 1 track visible of the group
        //    if (cntr == 1) return trak;

        //    //no visible tracks
        //    if (cntr == 0) return -1;


        //    //determine if any aligned reasonably close
        //    bool [] isAlignedArr = new bool[tracksArr.Count];
        //    for (int i = 0; i < tracksArr.Count; i++)
        //    {
        //        double diff = Math.PI - Math.Abs(Math.Abs(pivot.heading - tracksArr[i].aveHeading) - Math.PI);
        //        if ( diff < 1.2 || diff > 2.3)
        //            isAlignedArr[i] = true;
        //        else
        //            isAlignedArr[i] = false;
        //    }

        //    double minDistA = double.MaxValue;
        //    for (int i = 0; i < tracksArr.Count; i++)
        //    {
        //        if (!isAlignedArr[i]) continue;
        //        if (!tracksArr[i].isVisible) continue;

        //        for (int j = 0; j < tracksArr[i].trackPts.Count; j++)
        //        {

        //        double dist = glm.DistanceSquared(tracksArr[i].trackPts[j], pivot);

        //            if (dist < minDistA)
        //            {
        //                minDistA = dist;
        //                trak = i;
        //            }
        //        }
        //    }

        //    return trak;
        //}

        //public void BuildTrackCurrentList(vec3 pivot)
        //{
        //    //auto trach routine
        //    if (mf.trk.isAutoTrack)
        //    {
        //        idx = FindClosestRefTrack(pivot);
        //    }

        //    if (idx == -1) return;

        //    double minDistA = 1000000, minDistB;
        //    //move the ABLine over based on the overlap amount set in vehicle
        //    double widthMinusOverlap = mf.tool.width - mf.tool.overlap;

        //    int refCount = tracksArr[idx].trackPts.Count;
        //    if (refCount < 5)
        //    {
        //        curPts?.Clear();
        //        return;
        //    }

        //    //close call hit
        //    int cc = 0, dd;

        //    for (int j = 0; j < refCount; j += 10)
        //    {
        //        double dist = ((mf.guidanceLookPos.easting - tracksArr[idx].trackPts[j].easting) * (mf.guidanceLookPos.easting - tracksArr[idx].trackPts[j].easting))
        //                        + ((mf.guidanceLookPos.northing - tracksArr[idx].trackPts[j].northing) * (mf.guidanceLookPos.northing - tracksArr[idx].trackPts[j].northing));
        //        if (dist < minDistA)
        //        {
        //            minDistA = dist;
        //            cc = j;
        //        }
        //    }

        //    minDistA = minDistB = 1000000;

        //    dd = cc + 7; if (dd > refCount - 1) dd = refCount;
        //    cc -= 7; if (cc < 0) cc = 0;

        //    //find the closest 2 points to current close call
        //    for (int j = cc; j < dd; j++)
        //    {
        //        double dist = ((mf.guidanceLookPos.easting - tracksArr[idx].trackPts[j].easting) * (mf.guidanceLookPos.easting - tracksArr[idx].trackPts[j].easting))
        //                        + ((mf.guidanceLookPos.northing - tracksArr[idx].trackPts[j].northing) * (mf.guidanceLookPos.northing - tracksArr[idx].trackPts[j].northing));
        //        if (dist < minDistA)
        //        {
        //            minDistB = minDistA;
        //            rB = rA;
        //            minDistA = dist;
        //            rA = j;
        //        }
        //        else if (dist < minDistB)
        //        {
        //            minDistB = dist;
        //            rB = j;
        //        }
        //    }

        //    //reset the line over jump
        //    isLateralTriggered = false;

        //    //if (rA >= refCount - 1 || rB >= refCount) return;

        //    if (rA > rB) { C = rA; rA = rB; rB = C; }

        //    //same way as line creation or not
        //    isHeadingSameWay = Math.PI - Math.Abs(Math.Abs(pivot.heading - tracksArr[idx].trackPts[rA].heading) - Math.PI) < glm.PIBy2;

        //    if (mf.yt.isYouTurnTriggered) isHeadingSameWay = !isHeadingSameWay;

        //    //which side of the closest point are we on is next
        //    //calculate endpoints of reference line based on closest point
        //    refPoint1.easting = tracksArr[idx].trackPts[rA].easting - (Math.Sin(tracksArr[idx].trackPts[rA].heading) * 300.0);
        //    refPoint1.northing = tracksArr[idx].trackPts[rA].northing - (Math.Cos(tracksArr[idx].trackPts[rA].heading) * 300.0);

        //    refPoint2.easting = tracksArr[idx].trackPts[rA].easting + (Math.Sin(tracksArr[idx].trackPts[rA].heading) * 300.0);
        //    refPoint2.northing = tracksArr[idx].trackPts[rA].northing + (Math.Cos(tracksArr[idx].trackPts[rA].heading) * 300.0);

        //    if (idx > -1 && tracksArr[idx].nudgeDistance != 0)
        //    {
        //        refPoint1.easting += (Math.Sin(tracksArr[idx].trackPts[rA].heading + glm.PIBy2) * tracksArr[idx].nudgeDistance);
        //        refPoint1.northing += (Math.Cos(tracksArr[idx].trackPts[rA].heading + glm.PIBy2) * tracksArr[idx].nudgeDistance);

        //        refPoint2.easting += (Math.Sin(tracksArr[idx].trackPts[rA].heading + glm.PIBy2) * tracksArr[idx].nudgeDistance);
        //        refPoint2.northing += (Math.Cos(tracksArr[idx].trackPts[rA].heading + glm.PIBy2) * tracksArr[idx].nudgeDistance);
        //    }

        //    //x2-x1
        //    double dx = refPoint2.easting - refPoint1.easting;
        //    //z2-z1
        //    double dz = refPoint2.northing - refPoint1.northing;

        //    //how far are we away from the reference line at 90 degrees - 2D cross product and distance
        //    distanceFromRefLine = ((dz * mf.guidanceLookPos.easting) - (dx * mf.guidanceLookPos.northing) + (refPoint2.easting
        //                        * refPoint1.northing) - (refPoint2.northing * refPoint1.easting))
        //                        / Math.Sqrt((dz * dz) + (dx * dx));

        //    //bnd line
        //    distanceFromRefLine -= (0.5 * widthMinusOverlap);

        //    double RefDist = (distanceFromRefLine + (isHeadingSameWay ? mf.tool.offset : -mf.tool.offset)) / widthMinusOverlap;
        //    if (RefDist < 0) howManyPathsAway = (int)(RefDist-0.5);
        //    else howManyPathsAway = (int)(RefDist+0.5);

        //    //build current list
        //    isTrackValid = true;

        //    //build the current line
        //    curPts?.Clear();

        //    double distAway = widthMinusOverlap * howManyPathsAway + (isHeadingSameWay ? -mf.tool.offset : mf.tool.offset) + tracksArr[idx].nudgeDistance;

        //    //bnd line
        //    distAway += (0.5 * widthMinusOverlap);

        //    if (howManyPathsAway > -1) howManyPathsAway += 1;

        //    double distSqAway = (distAway * distAway) - 0.01;
        //    vec3 point;
        //    for (int i = 0; i < refCount; i++)
        //    {
        //        point = new vec3(
        //        tracksArr[idx].trackPts[i].easting + (Math.Sin(glm.PIBy2 + tracksArr[idx].trackPts[i].heading) * distAway),
        //        tracksArr[idx].trackPts[i].northing + (Math.Cos(glm.PIBy2 + tracksArr[idx].trackPts[i].heading) * distAway),
        //        tracksArr[idx].trackPts[i].heading);
        //        bool Add = true;

        //        for (int t = 0; t < refCount; t++)
        //        {
        //            double dist = ((point.easting - tracksArr[idx].trackPts[t].easting) * (point.easting - tracksArr[idx].trackPts[t].easting))
        //                + ((point.northing - tracksArr[idx].trackPts[t].northing) * (point.northing - tracksArr[idx].trackPts[t].northing));
        //            if (dist < distSqAway)
        //            {
        //                Add = false;
        //                break;
        //            }
        //        }

        //        if (Add)
        //        {
        //            if (curPts.Count > 0)
        //            {
        //                double dist = ((point.easting - curPts[curPts.Count - 1].easting) * (point.easting - curPts[curPts.Count - 1].easting))
        //                    + ((point.northing - curPts[curPts.Count - 1].northing) * (point.northing - curPts[curPts.Count - 1].northing));
        //                if (dist > 1.0)
        //                    curPts.Add(point);
        //            }
        //            else curPts.Add(point);
        //        }
        //    }

        //    int cnt = curPts.Count;
        //    if (cnt > 6)
        //    {
        //        vec3[] arr = new vec3[cnt];
        //        curPts.CopyTo(arr);

        //        //for (int i = 1; i < (curPts.Count - 1); i++)
        //        //{
        //        //    arr[i].easting = (curPts[i - 1].easting + curPts[i].easting + curPts[i + 1].easting) / 3;
        //        //    arr[i].northing = (curPts[i - 1].northing + curPts[i].northing + curPts[i + 1].northing) / 3;
        //        //}
        //        curPts.Clear();

        //        for (int i = 0; i < (arr.Length - 1); i++)
        //        {
        //            arr[i].heading = Math.Atan2(arr[i + 1].easting - arr[i].easting, arr[i + 1].northing - arr[i].northing);
        //            if (arr[i].heading < 0) arr[i].heading += glm.twoPI;
        //            if (arr[i].heading >= glm.twoPI) arr[i].heading -= glm.twoPI;
        //        }

        //        arr[arr.Length - 1].heading = arr[arr.Length - 2].heading;


        //        //if (mf.tool.isToolTrailing)
        //        //{
        //        //    //depending on hitch is different profile of draft
        //        //    double hitch;
        //        //    if (mf.tool.isToolTBT && mf.tool.tankTrailingHitchLength < 0)
        //        //    {
        //        //        hitch = mf.tool.tankTrailingHitchLength * 0.65;
        //        //        hitch += mf.tool.trailingHitchLength * 0.5;
        //        //    }
        //        //    else hitch = mf.tool.trailingHitchLength * 1.0;// - mf.vehicle.wheelbase;

        //        //    //move the line forward based on hitch length ratio
        //        //    for (int i = 0; i < arr.Length; i++)
        //        //    {
        //        //        arr[i].easting -= Math.Sin(arr[i].heading) * (hitch);
        //        //        arr[i].northing -= Math.Cos(arr[i].heading) * (hitch);
        //        //    }

        //        //    ////average the points over 3, center weighted
        //        //    //for (int i = 1; i < arr.Length - 2; i++)
        //        //    //{
        //        //    //    arr2[i].easting = (arr[i - 1].easting + arr[i].easting + arr[i + 1].easting) / 3;
        //        //    //    arr2[i].northing = (arr[i - 1].northing + arr[i].northing + arr[i + 1].northing) / 3;
        //        //    //}

        //        //    //recalculate the heading
        //        //    for (int i = 0; i < (arr.Length - 1); i++)
        //        //    {
        //        //        arr[i].heading = Math.Atan2(arr[i + 1].easting - arr[i].easting, arr[i + 1].northing - arr[i].northing);
        //        //        if (arr[i].heading < 0) arr[i].heading += glm.twoPI;
        //        //        if (arr[i].heading >= glm.twoPI) arr[i].heading -= glm.twoPI;
        //        //    }

        //        //    arr[arr.Length - 1].heading = arr[arr.Length - 2].heading;
        //        //}

        //        //replace the array 
        //        //curPts.AddRange(arr);
        //        cnt = arr.Length;
        //        double distance;
        //        double spacing = 3;

        //        //add the first point of loop - it will be p1
        //        curPts.Add(arr[0]);
        //        //curPts.Add(arr[1]);

        //        for (int i = 0; i < cnt - 3; i++)
        //        {
        //            // add p1
        //            curPts.Add(arr[i + 1]);

        //            distance = glm.Distance(arr[i + 1], arr[i + 2]);

        //            if (distance > spacing)
        //            {
        //                int loopTimes = (int)(distance / spacing + 1);
        //                for (int j = 1; j < loopTimes; j++)
        //                {
        //                    vec3 pos = new vec3(glm.Catmull(j / (double)(loopTimes), arr[i], arr[i + 1], arr[i + 2], arr[i + 3]));
        //                    curPts.Add(pos);
        //                }
        //            }
        //        }

        //        curPts.Add(arr[cnt - 2]);
        //        curPts.Add(arr[cnt - 1]);

        //        //to calc heading based on next and previous points to give an average heading.
        //        cnt = curPts.Count;
        //        arr = new vec3[cnt];
        //        cnt--;
        //        curPts.CopyTo(arr);
        //        curPts.Clear();

        //        curPts.Add(new vec3(arr[0]));

        //        //middle points
        //        for (int i = 1; i < cnt; i++)
        //        {
        //            vec3 pt3 = new vec3(arr[i]);
        //            pt3.heading = Math.Atan2(arr[i + 1].easting - arr[i - 1].easting, arr[i + 1].northing - arr[i - 1].northing);
        //            if (pt3.heading < 0) pt3.heading += glm.twoPI;
        //            curPts.Add(pt3);
        //        }

        //        int k = arr.Length - 1;
        //        vec3 pt33 = new vec3(arr[k]);
        //        pt33.heading = Math.Atan2(arr[k].easting - arr[k - 1].easting, arr[k].northing - arr[k - 1].northing);
        //        if (pt33.heading < 0) pt33.heading += glm.twoPI;
        //        curPts.Add(pt33);

        //        if (mf.trk.tracksArr == null || mf.trk.tracksArr.Count == 0) return;
        //        if (mf.bnd.bndList.Count > 0 
        //            && !(mf.trk.tracksArr[mf.trk.idx].mode == (int)TrackMode.bndTrackOuter)
        //            && !(mf.trk.tracksArr[mf.trk.idx].mode == (int)TrackMode.bndTrackInner))
        //        {
        //            int ptCnt = curPts.Count - 1;

        //            //end
        //            while (mf.bnd.bndList[0].fenceLineEar.IsPointInPolygon(curPts[curPts.Count - 1]))
        //            {
        //                for (int i = 1; i < 10; i++)
        //                {
        //                    vec3 pt = new vec3(curPts[ptCnt]);
        //                    pt.easting += (Math.Sin(pt.heading) * i);
        //                    pt.northing += (Math.Cos(pt.heading) * i);
        //                    curPts.Add(pt);
        //                }
        //                ptCnt = curPts.Count - 1;
        //            }

        //            //and the beginning
        //            pt33 = new vec3(curPts[0]);

        //            while (mf.bnd.bndList[0].fenceLineEar.IsPointInPolygon(curPts[0]))
        //            {
        //                pt33 = new vec3(curPts[0]);

        //                for (int i = 1; i < 10; i++)
        //                {
        //                    vec3 pt = new vec3(pt33);
        //                    pt.easting -= (Math.Sin(pt.heading) * i);
        //                    pt.northing -= (Math.Cos(pt.heading) * i);
        //                    curPts.Insert(0, pt);
        //                }
        //            }
        //        }
        //    }

        //    lastSecond = mf.secondsSinceStart;
        //}


