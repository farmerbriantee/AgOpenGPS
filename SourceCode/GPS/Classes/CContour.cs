using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;

namespace AgOpenGPS
{
    public class CContour
    {
        //copy of the mainform address
        private FormGPS mf;
        private OpenGL gl;

        public bool isContourOn = false, isContourBtnOn = false;

        //used to determine if section was off and now is on or vice versa
        public bool wasSectionOn = false;

        //generated box for finding closest point
        public vec2 boxA = new vec2(0, 0), boxB = new vec2(0, 2);
        public vec2 boxC = new vec2(1, 1), boxD = new vec2(2, 3);

        //current contour patch and point closest to current fix
        public int closestRefPatch = 0, closestRefPoint = 0;

        //angle to path line closest point and fix
        public double refHeading = 0, ref2 = 0;

        // for closest line point to current fix
        public double minDistance = 99999.0, refX=0, refZ=0;

        //generated reference line
        public double refLineSide = 1.0;
        public vec2 refPoint1 = new vec2(1, 1), refPoint2 = new vec2(2, 2);

        public double distanceFromRefLine = 0.0;
        public double distanceFromCurrentLine = 0.0;

        int A = 0, B = 0, C = 0;
        public double abFixHeadingDelta = 0, abHeading = 0;

        public bool isABSameAsFixHeading = true;
        public bool isOnRightSideCurrentLine = true;

        //list of strip data individual points
        public List<vec4> ptList = new List<vec4>();

        //list of the list of individual triangles for entire field
        public List<List<vec4>> stripList = new List<List<vec4>>();

        //list of points for the new contour line
        public List<vec4> guideList = new List<vec4>();
 
        //list of points to determine position ofnew contour line
        public List<cvec> conList = new List<cvec>();

        //constructor
        public CContour(OpenGL gl, FormGPS f)
        {            
            this.mf = f;
            this.gl = gl;
        }

        //start stop and add points to list
        public void StartContourLine()
        {
            isContourOn = true;
            if (ptList.Count == 1)
            {
                //reuse ptList
                ptList.Clear();
            }

            else
            {
                //make new ptList
                ptList = new List<vec4>();
                stripList.Add(ptList);
            }

            vec4 point = new vec4(mf.pivotAxleEasting, mf.fixHeading, mf.pivotAxleNorthing, mf.pn.altitude);
            ptList.Add(point);
        }
        
        //Add current position to stripList
        public void AddPoint()
        {
            vec4 point = new vec4(mf.pivotAxleEasting, mf.fixHeading, mf.pivotAxleNorthing, mf.pn.altitude);
            ptList.Add(point);
        }

        //End the strip
        public void StopContourLine()
        {
            //make sure its long enough to bother
            if (ptList.Count > 10)
            {
                vec4 point = new vec4(mf.pivotAxleEasting, mf.fixHeading, mf.pivotAxleNorthing, mf.pn.altitude);
                ptList.Add(point);
            }

            //delete ptList
            else
            {
                ptList.Clear();
                int ra = stripList.Count-1;
                stripList.RemoveAt(ra);
            }

            //turn it off
            isContourOn = false;
        }

        //determine closest point on applied 
        public void BuildContourGuidanceLine(double eastFix, double northFix)
        {   
            //build a frustum box ahead of fix to find adjacent paths and points
            //double startX = eastFix + Math.Sin(mf.fixHeading)* 0;
            //double startY = northFix + Math.Cos(mf.fixHeading) * 0;

            boxA.x = eastFix - Math.Sin(mf.fixHeading + glm.PIBy2) *  2.0 * mf.vehicle.toolWidth;
            boxA.z = northFix - Math.Cos(mf.fixHeading + glm.PIBy2) * 2.0 * mf.vehicle.toolWidth;
                                                                      
            boxB.x = eastFix + Math.Sin(mf.fixHeading + glm.PIBy2) *  2.0 * mf.vehicle.toolWidth;
            boxB.z = northFix + Math.Cos(mf.fixHeading + glm.PIBy2) * 2.0 * mf.vehicle.toolWidth;

            boxC.x = boxB.x + Math.Sin(mf.fixHeading) * 13.0;
            boxC.z = boxB.z + Math.Cos(mf.fixHeading) * 13.0;
                                                         
            boxD.x = boxA.x + Math.Sin(mf.fixHeading) * 13.0;
            boxD.z = boxA.z + Math.Cos(mf.fixHeading) * 13.0;

            conList.Clear();
            guideList.Clear();
            int ptCount;

            //check if no strips yet, return
            int stripCount = stripList.Count;
            if (stripCount == 0) return;

            cvec pointC = new cvec();
            
            //determine if points are in frustum box
            for (int s = 0; s < stripCount; s++)
            {
                ptCount = stripList[s].Count;
                for (int p = 0; p < ptCount; p++)
                {
                    if (((boxB.x - boxA.x) * (stripList[s][p].z - boxA.z) -
                            (boxB.z - boxA.z) * (stripList[s][p].x - boxA.x)) < 0) continue;
                    if (((boxD.x - boxC.x) * (stripList[s][p].z - boxC.z) -
                            (boxD.z - boxC.z) * (stripList[s][p].x - boxC.x)) < 0) continue;
                    if (((boxC.x - boxB.x) * (stripList[s][p].z - boxB.z) -
                            (boxC.z - boxB.z) * (stripList[s][p].x - boxB.x)) < 0) continue;
                    if (((boxA.x - boxD.x) * (stripList[s][p].z - boxD.z) -
                            (boxA.z - boxD.z) * (stripList[s][p].x - boxD.x)) < 0) continue;

                    //in the box so is it parallelish or perpedicularish to current heading
                    ref2 = Math.PI - Math.Abs(Math.Abs(mf.fixHeading - stripList[s][p].y) - Math.PI);
                    if (ref2 < 1.4 || ref2 > 1.74)
                    {                    
                        //it's in the box and parallelish so add to list
                        pointC.x = stripList[s][p].x;
                        pointC.z = stripList[s][p].z;
                        pointC.h = stripList[s][p].y;
                        pointC.strip = s;
                        pointC.pt = p;
                        conList.Add(pointC);
                    }
                }
            }

            //determine closest point
            ptCount = conList.Count;
            if (ptCount == 0)
            {
                distanceFromCurrentLine = 9999;
                return;
            }

            minDistance = 99999;
            for (int i = 0; i < ptCount; i++)
            {
                double dist = (eastFix - conList[i].x) * (eastFix - conList[i].x) +
                                (northFix - conList[i].z) * (northFix - conList[i].z);
                if (minDistance >= dist)
                {
                    minDistance = dist;
                    closestRefPoint = i;
                }
            }

            //now we have closest point, the distance squared from it, and which patch and point its from
            int strip = conList[closestRefPoint].strip;
            int pt = conList[closestRefPoint].pt;
            refX = stripList[strip][pt].x;
            refZ = stripList[strip][pt].z;
            refHeading = stripList[strip][pt].y;

            //are we going same direction as stripList was created?
            bool isSameWay = false;
            if (Math.PI - Math.Abs(Math.Abs(mf.fixHeading - refHeading) - Math.PI) < 1.4) isSameWay = true;

            //which side of the patch are we on is next
            //calculate endpoints of reference line based on closest point
            refPoint1.x = refX - Math.Sin(refHeading) * 50.0;
            refPoint1.z = refZ - Math.Cos(refHeading) * 50.0;

            refPoint2.x = refX + Math.Sin(refHeading) * 50.0;
            refPoint2.z = refZ + Math.Cos(refHeading) * 50.0;

            //x2-x1
            double dx = refPoint2.x - refPoint1.x;
            //z2-z1
            double dz = refPoint2.z - refPoint1.z;

            //how far are we away from the reference line at 90 degrees - 2D cross product and distance
            distanceFromRefLine = (dz * mf.fixPosX - dx * mf.fixPosZ + refPoint2.x *
                                    refPoint1.z - refPoint2.z * refPoint1.x) /
                                        Math.Sqrt(dz * dz + dx * dx);

            //add or subtract pi by 2 depending on which side of ref line
            double piSide;

            //sign of distance determines which side of line we are on
            if (distanceFromRefLine > 0) piSide = glm.PIBy2;
            else piSide = -glm.PIBy2;

            //offset calcs
            double toolOffset = mf.vehicle.toolOffset;
            if (isSameWay) toolOffset = 0.0;
            else
            {
                if (distanceFromRefLine > 0) toolOffset = toolOffset * 2.0;
                else toolOffset = toolOffset * -2.0;
            }

            //move the Guidance Line over based on the overlap, width, and offset amount set in vehicle
            double widthMinusOverlap = mf.vehicle.toolWidth - mf.vehicle.toolOverlap + toolOffset;
            
            //absolute the distance
            distanceFromRefLine = Math.Abs(distanceFromRefLine);
           
            //make the new guidance line list called guideList
            ptCount = stripList[strip].Count-1;
            int start, stop;
            vec4 point;

            if (isSameWay)
            {
                start = pt - 10;
                if (start < 0) start = 0;
                stop = pt + 40;
                if (stop > ptCount) stop = ptCount+1;
            }

            else
            {
                start = pt - 40;
                if (start < 0) start = 0;
                stop = pt + 10;
                if (stop > ptCount) stop = ptCount+1;
            }                


            for (int i = start; i < stop; i++)
            {
                point = new vec4(
                    stripList[strip][i].x + Math.Sin(piSide + stripList[strip][i].y) * widthMinusOverlap,
                    stripList[strip][i].y,
                    stripList[strip][i].z + Math.Cos(piSide + stripList[strip][i].y) * widthMinusOverlap,
                    0);
                guideList.Add(point);
            }
        }
        
        //determine distance from contour guidance line
        public void DistanceFromContourLine()
        {
            double minDistA = 1000000, minDistB = 1000000;
            int ptCount = guideList.Count;
            //distanceFromCurrentLine = 9999;
            if (ptCount > 0)
            {
                //find the closest 2 points to current fix
                for (int t = 0; t < ptCount; t++)
                {
                    double dist = (mf.pn.easting - guideList[t].x) * (mf.pn.easting - guideList[t].x) +
                                    (mf.pn.northing - guideList[t].z) * (mf.pn.northing - guideList[t].z);
                    if (dist < minDistA)
                    {
                        minDistB = minDistA;
                        B = A;
                        minDistA = dist;
                        A = t;
                    }

                    else if (dist < minDistB)
                    {
                        minDistB = dist;
                        B = t;
                    }
                }

                //just need to make sure the points continue ascending or heading switches all over the place
                if (A > B) { C = A; A = B; B = C; }

                //get the distance from currently active AB line
                //x2-x1
                double dx = guideList[B].x - guideList[A].x;
                //z2-z1
                double dz = guideList[B].z - guideList[A].z;

                //abHeading = Math.Atan2(dz, dx);
                abHeading = guideList[A].y;

                //how far from current AB Line is fix
                distanceFromCurrentLine = (dz * mf.fixPosX - dx * mf.fixPosZ + guideList[B].x *
                            guideList[A].z - guideList[B].z * guideList[A].x) /
                                Math.Sqrt(dz * dz + dx * dx);

                //are we on the right side or not
                if (distanceFromCurrentLine > 0) isOnRightSideCurrentLine = true;
                else isOnRightSideCurrentLine = false;

                //absolute the distance
                distanceFromCurrentLine = Math.Abs(distanceFromCurrentLine);

                //Subtract the two headings, if > 1.57 its going the opposite heading as refAB
                abFixHeadingDelta = (Math.Abs(mf.fixHeading - abHeading));
                if (abFixHeadingDelta >= Math.PI) abFixHeadingDelta = Math.Abs(abFixHeadingDelta - glm.twoPI);

                if (abFixHeadingDelta >= glm.PIBy2) isABSameAsFixHeading = false;
                else isABSameAsFixHeading = true;

                //Convert to centimeters
                distanceFromCurrentLine = Math.Round(distanceFromCurrentLine * 1000.0, MidpointRounding.AwayFromZero);

                //distance is negative if on left, positive if on right
                //if you're going the opposite direction left is right and right is left
                double temp;
                if (isABSameAsFixHeading)
                {
                    temp = (abHeading);
                    if (!isOnRightSideCurrentLine) distanceFromCurrentLine *= -1.0;
                }

                //opposite way so right is left
                else
                {
                    temp = (abHeading - Math.PI);
                    if (temp < 0) temp = (temp + glm.twoPI);
                    //temp = glm.toDegrees(temp);
                    if (isOnRightSideCurrentLine) distanceFromCurrentLine *= -1.0;
                }

                mf.guidanceLineDistanceOff = (Int16)distanceFromCurrentLine;
                mf.guidanceLineHeadingDelta = (Int16)((Math.Atan2(Math.Sin(temp - mf.fixHeading),
                                                    Math.Cos(temp - mf.fixHeading))) * 10000);

                //depending on which side of line, neg angle needs negating.
                if (distanceFromCurrentLine < 0) mf.guidanceLineHeadingDelta *= -1;
           }

            else
            {
                distanceFromCurrentLine = 32000;
                mf.guidanceLineDistanceOff = (Int16)32000;

            }


        }

        //draw the red follow me line
        public void DrawContourLine()
        {
            //gl.Color(0.98f, 0.98f, 0.50f);
            //gl.Begin(OpenGL.GL_LINE_STRIP);
            ////for (int h = 0; h < ptCount; h++) gl.Vertex(guideList[h].x, 0, guideList[h].z);
            //gl.Vertex(boxA.x, 0, boxA.z);
            //gl.Vertex(boxB.x, 0, boxB.z);
            //gl.Vertex(boxC.x, 0, boxC.z);
            //gl.Vertex(boxD.x, 0, boxD.z);
            //gl.Vertex(boxA.x, 0, boxA.z);
            //gl.End();

            ////draw the guidance line
            int ptCount = guideList.Count;
            gl.LineWidth(2);
            gl.Color(0.98f, 0.2f, 0.0f);
            gl.Begin(OpenGL.GL_LINE_STRIP);
            for (int h = 0; h < ptCount; h++) gl.Vertex(guideList[h].x, 0, guideList[h].z);
            gl.End();

            ////draw the reference line
            //gl.PointSize(3.0f);
            ////if (isContourBtnOn)
            //{
            //    ptCount = stripList.Count;
            //    if (ptCount > 0)
            //    {
            //        ptCount = stripList[closestRefPatch].Count;
            //        gl.Begin(OpenGL.GL_POINTS);
            //        for (int i = 0; i < ptCount; i++)
            //        {
            //            gl.Vertex(stripList[closestRefPatch][i].x, 0, stripList[closestRefPatch][i].z);
            //        }
            //        gl.End();
            //    }
            //}


            //ptCount = conList.Count;
            //if (ptCount > 0)
            //{
            //    //draw closest point and side of line points
            //    gl.Color(0.5f, 0.900f, 0.90f);
            //    gl.PointSize(4.0f);
            //    gl.Begin(OpenGL.GL_POINTS);

            //    for (int i = 0; i < ptCount; i++)
            //    {
            //        gl.Vertex(conList[i].x, 0, conList[i].z);
            //    }

            //    gl.End();


            //    //draw closest point and side of line points
            //    gl.Color(0.35f, 0.30f, 0.90f);
            //    gl.PointSize(6.0f);
            //    gl.Begin(OpenGL.GL_POINTS);
            //    gl.Vertex(conList[closestRefPoint].x, 0, conList[closestRefPoint].z);
            //    gl.End();

            //}

        }

    }//class
}//namespace