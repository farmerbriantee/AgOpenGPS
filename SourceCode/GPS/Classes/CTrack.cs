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

        public bool isAB = 

        public CTrack(FormGPS _f)
        {
            //constructor
            mf = _f;
            idx = -1;
        }

        public void LoadGuidanceLine()
        {
            if (gArr[idx].mode == (int)TrackMode.AB)
            {
                mf.ABLine.refLine = new CTrk(gArr[idx]);
                mf.curve.refCurve = null;
                mf.curve.isCurveSet = false;
            }
            else
            {
                mf.curve.refCurve = new CTrk(gArr[idx]);
                mf.ABLine.refLine = null;
                mf.ABLine.isABLineSet = false;
            }

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
        public double heading;
        public string name;
        public bool isVisible;
        public vec2 ptA;
        public vec2 ptB;
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
            mode = 0;
            nudgeDistance = 0;
        }

        public CTrk(CTrk _trk)
        {
            curvePts = new List<vec3>(_trk.curvePts);
            heading = _trk.heading;
            name = _trk.name;
            isVisible = _trk.isVisible;
            ptA = new vec2();
            ptB = new vec2();
            mode = _trk.mode;
            nudgeDistance = _trk.nudgeDistance;
        }
    }
}

        


