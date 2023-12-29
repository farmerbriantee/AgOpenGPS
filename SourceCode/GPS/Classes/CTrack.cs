using OpenTK.Graphics.OpenGL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        public int FindClosestRefTrack(vec3 pivot)
        {
            //no tracks check
            if (gArr.Count == 0) return idx;

            //only 1 track
            if (gArr.Count == 1) return idx;

            int trak = -1;
            int cntr = 0;

            //Count visible
            for (int i = 0; i < gArr.Count; i++)
            {
                if (gArr[i].isVisible)
                {
                    cntr++;
                    trak = i;
                }
            }

            //only 1 track visible of the group
            if (cntr == 1) return trak;

            //no visible tracks
            if (cntr == 0) return -1;

            //determine if any aligned reasonably close
            bool[] isAlignedArr = new bool[gArr.Count];
            for (int i = 0; i < gArr.Count; i++)
            {
                double diff = Math.PI - Math.Abs(Math.Abs(pivot.heading - gArr[i].heading) - Math.PI);
                if (diff < 1.2 || diff > 2.3)
                    isAlignedArr[i] = true;
                else
                    isAlignedArr[i] = false;
            }

            double minDistA = double.MaxValue;
            for (int i = 0; i < gArr.Count; i++)
            {
                if (!isAlignedArr[i]) continue;
                if (!gArr[i].isVisible) continue;

                double dist = glm.DistanceSquared(gArr[i].ptA, pivot);

                if (dist < minDistA)
                {
                    minDistA = dist;
                    trak = i;
                }

                dist = glm.DistanceSquared(gArr[i].ptB, pivot);

                if (dist < minDistA)
                {
                    minDistA = dist;
                    trak = i;
                }


                //for (int j = 0; j < gArr[i].curvePts.Count; j++)
                //{

                //    double dist = glm.DistanceSquared(gArr[i].curvePts[j], pivot);

                //    if (dist < minDistA)
                //    {
                //        minDistA = dist;
                //        trak = i;
                //    }
                //}
            }

            return trak;
        }


        public void NudgeTrack(double dist)
        {
            if (idx > -1)
            {
                if (gArr[idx].mode == (int)TrackMode.AB)
                {
                    mf.ABLine.isABValid = false;
                    mf.ABLine.lastSecond = 0;
                    gArr[idx].nudgeDistance += mf.ABLine.isHeadingSameWay ? dist : -dist;
                }
                else
                {
                    mf.curve.isCurveValid = false;
                    mf.curve.lastSecond = 0;
                    gArr[idx].nudgeDistance += mf.curve.isHeadingSameWay ? dist : -dist;

                }

                if (gArr[idx].nudgeDistance > 0.5 * mf.tool.width) gArr[idx].nudgeDistance -= mf.tool.width;
                else if (gArr[idx].nudgeDistance < -0.5 * mf.tool.width) gArr[idx].nudgeDistance += mf.tool.width;
            }
        }

        public void NudgeDistanceReset()
        {
            if (idx > -1 && gArr.Count > 0)
            {
                if (gArr[idx].mode == (int)TrackMode.AB)
                {
                    mf.ABLine.isABValid = false;
                    mf.ABLine.lastSecond = 0;
                }
                else
                {
                    mf.curve.isCurveValid = false;
                    mf.curve.lastSecond = 0;
                }

                gArr[idx].nudgeDistance = 0;
            }
        }

        public void SnapToPivot()
        {
            //if (isBtnGuidanceOn)

            if (idx > -1)
                {
                if (gArr[idx].mode == (int)(TrackMode.AB))
                {
                    NudgeTrack(mf.ABLine.distanceFromCurrentLinePivot);

                }
                else
                {
                    NudgeTrack(mf.curve.distanceFromCurrentLinePivot);
                }

            }
        }


    }


    public class CTrk
    {
        public List<vec3> curvePts = new List<vec3>();
        public double heading;
        public string name;
        public bool isVisible;
        public vec2 ptA;
        public vec2 ptB;
        public vec2 endPtA;
        public vec2 endPtB;
        public int mode;
        public double nudgeDistance;

        public CTrk()
        {
            curvePts = new List<vec3>();
            heading = 3;
            name = "aa";
            isVisible = true;
            ptA = new vec2();
            ptB = new vec2();
            endPtA = new vec2();
            endPtB = new vec2();
            mode = 0;
            nudgeDistance = 0;
        }

        public CTrk(CTrk _trk)
        {
            curvePts = new List<vec3>(_trk.curvePts);
            heading = _trk.heading;
            name = _trk.name;
            isVisible = _trk.isVisible;
            ptA = _trk.ptA;
            ptB = _trk.ptB;
            endPtA = new vec2();
            endPtB = new vec2();
            mode = _trk.mode;
            nudgeDistance = _trk.nudgeDistance;
        }
    }
}

        


