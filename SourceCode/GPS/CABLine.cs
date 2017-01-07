
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Diagnostics;
using SharpGL;
using SharpGL.SceneGraph.Assets;
using System.Drawing;

namespace AgOpenGPS
{
    public class CABLine
    {

        public double abHeading = 0.0;
        public double abFixHeadingDelta = 0;

        public bool isABSameAsFixHeading = true;
        public bool isOnRightSideCurrentLine = true;

        public double refLineSide = 1.0;

        public double distanceFromRefLine = 0.0;
        public double distanceFromCurrentLine = 0.0;
        public double snapDistance = 0;

        public bool isABLineSet = false;
        public bool isABLineBeingSet = false;

        public double passNumber = 0.0;

        public double howManyPathsAway = 0.0;

        //tramlines
        Color tramColor = Color.YellowGreen;
        public int tramPassEvery = 0;
        public int passBasedOn = 0;

        //pointers to mainform controls
        private FormGPS mf;
        private OpenGL gl;


        //the two inital A and B points
        public vec3 refPoint1 = new vec3(0.2, 0.0, 0.2);
        public vec3 refPoint2 = new vec3(0.3, 0.0, 0.3);

        //the reference line endpoints
        public vec3 refABLineP1 = new vec3(0.0, 0.0, 0.0);
        public vec3 refABLineP2 = new vec3(0.0, 0.0, 1.0);

        //the current AB guidance line
        public vec3 currentABLineP1 = new vec3(0.0, 0.0, 0.0);
        public vec3 currentABLineP2 = new vec3(0.0, 0.0, 1.0);

        public CABLine(OpenGL gl, FormGPS f)
        {
            //constructor
            this.gl = gl;
            this.mf = f;
        } 

        public void DeleteAB()
        {
            refPoint1 = new vec3(0.0, 0.0, 0.0);
            refPoint2 = new vec3(0.0, 0.0, 1.0);

            refABLineP1 = new vec3(0.0, 0.0, 0.0);
            refABLineP2 = new vec3(0.0, 0.0, 1.0);

            currentABLineP1 = new vec3(0.0, 0.0, 0.0);
            currentABLineP2 = new vec3(0.0, 0.0, 1.0);

            abHeading = 0.0;

            passNumber = 0.0;

            howManyPathsAway = 0.0;

            isABLineSet = false;
        }

        public void SetABLineByBPoint()
        {
            refPoint2.x = mf.fixPosX;
            refPoint2.z = mf.fixPosZ;
            Console.WriteLine(refPoint2.x);
            Console.WriteLine(refPoint2.z);

            abHeading = Math.Atan2(refPoint2.x - refPoint1.x, refPoint2.z - refPoint1.z);

            if (abHeading < 0) abHeading += glm.twoPI;


            //sin x cos z for endpoints, opposite for additional lines
            refABLineP1.x = refPoint1.x - Math.Sin(abHeading) * 10000.0;
            refABLineP1.z = refPoint1.z - Math.Cos(abHeading) * 10000.0;

            refABLineP2.x = refPoint1.x + Math.Sin(abHeading) * 10000.0;
            refABLineP2.z = refPoint1.z + Math.Cos(abHeading) * 10000.0;

            isABLineSet = true;
        }

        public void SetABLineByHeading()
        {
            refABLineP1.x = refPoint1.x - Math.Sin(abHeading) * 10000.0;
            refABLineP1.z = refPoint1.z - Math.Cos(abHeading) * 10000.0;

            refABLineP2.x = refPoint1.x + Math.Sin(abHeading) * 10000.0;
            refABLineP2.z = refPoint1.z + Math.Cos(abHeading) * 10000.0;

            refPoint2.x = refABLineP2.x;
            refPoint2.z = refABLineP2.z;

            isABLineSet = true;
        }

        public void snapABLine()
        {
            double headingCalc;
            //calculate the heading 90 degrees to ref ABLine heading 
            if (isOnRightSideCurrentLine) headingCalc = abHeading + glm.PIBy2;
            else headingCalc = abHeading - glm.PIBy2;

            //calculate the new points for the reference line and points
            refPoint1.x = Math.Sin(headingCalc) * Math.Abs(distanceFromCurrentLine) * 0.01 + refPoint1.x;
            refPoint1.z = Math.Cos(headingCalc) * Math.Abs(distanceFromCurrentLine) * 0.01 + refPoint1.z;

            refABLineP1.x = refPoint1.x - Math.Sin(abHeading) * 10000.0;
            refABLineP1.z = refPoint1.z - Math.Cos(abHeading) * 10000.0;

            refABLineP2.x = refPoint1.x + Math.Sin(abHeading) * 10000.0;
            refABLineP2.z = refPoint1.z + Math.Cos(abHeading) * 10000.0;

            refPoint2.x = refABLineP2.x;
            refPoint2.z = refABLineP2.z;

        }
 
        private void getCurrentABLine()
        {
            //move the ABLine over based on the overlap amount set in vehicle
            double widthMinusOverlap = mf.vehicle.toolWidth - mf.vehicle.toolOverlap;

            //distance from a point to a line defined by two points
            // |(z2-z1)x0 - (x2-x1)z0 + x2z1 - z2x1|
            // --------------------------------------
            // SQRT( (z2-z1)*(z2-z1) + (x2-x1)*(x2-x1) )


            //x2-x1
            double dx = refPoint2.x - refPoint1.x;
            //z2-z1
            double dz = refPoint2.z - refPoint1.z;

            //how far are we away from the reference line at 90 degrees
            distanceFromRefLine = (dz * mf.fixPosX - dx * mf.fixPosZ + refPoint2.x *
                                    refPoint1.z - refPoint2.z * refPoint1.x) /
                                        Math.Sqrt(dz * dz + dx * dx);

            //sign of distance determines which side of line we are on
            if (distanceFromRefLine > 0) refLineSide = 1;
            else refLineSide = -1;

            //absolute the distance
            distanceFromRefLine = Math.Abs(distanceFromRefLine);

            //Which ABLine is the vehicle on, negative is left and positive is right side
            howManyPathsAway = Math.Round(distanceFromRefLine / widthMinusOverlap, 0, MidpointRounding.AwayFromZero);

            //not used, left for reference only, can be done directly from distance measurement as above
            //which side of the reference line is the fix - 2 dimensional cross product
            //side = ((b.x - a.x) * (c.z - a.z) - (b.z - a.z) * (c.x - a.x)) > 0;

            //generate that pass number as signed integer
            passNumber = Convert.ToInt32(refLineSide * howManyPathsAway);

            //calculate the new point that is number of implement widths over
            vec3 point1 = new vec3(Math.Cos(-abHeading) * (widthMinusOverlap * howManyPathsAway * refLineSide + snapDistance) + refPoint1.x,
                0, Math.Sin(-abHeading) * (widthMinusOverlap * howManyPathsAway * refLineSide + snapDistance)+ refPoint1.z);

            //create the new line extent points for current ABLine based on original heading of AB line
            currentABLineP1.x = point1.x - Math.Sin(abHeading) * 10000.0;
            currentABLineP1.z = point1.z - Math.Cos(abHeading) * 10000.0;

            currentABLineP2.x = point1.x + Math.Sin(abHeading) * 10000.0;
            currentABLineP2.z = point1.z + Math.Cos(abHeading) * 10000.0;

            //get the distance from currently active AB line
            //x2-x1
            dx = currentABLineP2.x - currentABLineP1.x;
            //z2-z1
            dz = currentABLineP2.z - currentABLineP1.z;

            //how far from current AB Line is fix
            distanceFromCurrentLine = (dz * mf.fixPosX - dx * mf.fixPosZ + currentABLineP2.x *
                        currentABLineP1.z - currentABLineP2.z * currentABLineP1.x) /
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
            distanceFromCurrentLine = Math.Round(distanceFromCurrentLine * 100.0, 0);

            //distance is negative if on left, positive if on right
            //if you're going the opposite direction left is right and right is left
            if (isABSameAsFixHeading)
            {
                if (!isOnRightSideCurrentLine) distanceFromCurrentLine *= -1.0;
            }

            //opposite way so right is left
            else
            {
                if (isOnRightSideCurrentLine) distanceFromCurrentLine *= -1.0;
            }
        }

        public void DrawABLines()
        {
                //Draw AB Points
                gl.PointSize(8.0f);
                gl.Begin(OpenGL.GL_POINTS);
                gl.Color(0.5f, 0.0f, 0.0f);
                gl.Vertex(refPoint1.x, 0.0, refPoint1.z);
                gl.Color(0.0f, 0.0f, 0.5f);
                gl.Vertex(refPoint2.x, 0.0, refPoint2.z);
                gl.End();
                gl.PointSize(1.0f);


                if (isABLineSet)
                {
                    //Draw reference AB line
                    gl.LineWidth(2);
                    gl.Enable(OpenGL.GL_LINE_STIPPLE);
                    gl.LineStipple(1, 0x07F0);
                    gl.Begin(OpenGL.GL_LINES);
                    gl.Color(0.9f, 0.5f, 0.7f);
                    gl.Vertex(refABLineP1.x, 0, refABLineP1.z);
                    gl.Vertex(refABLineP2.x, 0, refABLineP2.z);
                    gl.End();

                    gl.LineWidth(1);

                    getCurrentABLine();

                    //draw current AB Line
                    gl.Disable(OpenGL.GL_LINE_STIPPLE);
                    gl.LineWidth(3);
                    gl.Begin(OpenGL.GL_LINES);
                    gl.Color(0.9f, 0.0f, 0.0f);

                    //calculate if tram line is here
                    if (tramPassEvery != 0)
                    {
                        int pass = (int)passNumber + (tramPassEvery*300) - passBasedOn;
                        if (pass % tramPassEvery != 0) gl.Color(0.9f, 0.0f, 0.0f);
                        else gl.Color(0, 0.9, 0);
                    }

                    //based on line pass, make ref purple
                    if (passBasedOn == passNumber && tramPassEvery != 0) gl.Color(0.990f, 0.190f, 0.990f);

                    gl.Vertex(currentABLineP1.x, 0.0, currentABLineP1.z);
                    gl.Vertex(currentABLineP2.x, 0.0, currentABLineP2.z);
                    gl.End();

                    gl.LineWidth(1);

                }
        }



    }
}
