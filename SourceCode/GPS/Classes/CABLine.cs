
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Diagnostics;
using SharpGL;
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
        public vec2 refPoint1 = new vec2(0.2, 0.2);
        public vec2 refPoint2 = new vec2(0.3, 0.3);

        //the reference line endpoints
        public vec2 refABLineP1 = new vec2(0.0, 0.0);
        public vec2 refABLineP2 = new vec2(0.0, 1.0);

        //the current AB guidance line
        public vec2 currentABLineP1 = new vec2(0.0, 0.0);
        public vec2 currentABLineP2 = new vec2(0.0, 1.0);

        //pure pursuit values
        public vec2 pivotAxlePosAB = new vec2(0, 0);
        public vec2 goalPointAB = new vec2(0, 0);
        public vec2 radiusPointAB = new vec2(0, 0);
        public double steerAngleAB = 0;
        double rEastAB = 0, rNorthAB = 0;
        public double ppRadiusAB = 0;

        public CABLine(OpenGL gl, FormGPS f)
        {
            //constructor
            this.gl = gl;
            this.mf = f;
        } 

        public void DeleteAB()
        {
            refPoint1 = new vec2(0.0, 0.0);
            refPoint2 = new vec2(0.0, 1.0);

            refABLineP1 = new vec2(0.0, 0.0);
            refABLineP2 = new vec2(0.0, 1.0);

            currentABLineP1 = new vec2(0.0, 0.0);
            currentABLineP2 = new vec2(0.0, 1.0);

            abHeading = 0.0;

            passNumber = 0.0;

            howManyPathsAway = 0.0;

            isABLineSet = false;
        }

        public void SetABLineByBPoint()
        {
            refPoint2.easting = mf.fixPosX;
            refPoint2.northing = mf.fixPosY;
            Console.WriteLine(refPoint2.easting);
            Console.WriteLine(refPoint2.northing);

            abHeading = Math.Atan2(refPoint2.easting - refPoint1.easting, refPoint2.northing - refPoint1.northing);

            if (abHeading < 0) abHeading += glm.twoPI;


            //sin x cos z for endpoints, opposite for additional lines
            refABLineP1.easting = refPoint1.easting - Math.Sin(abHeading) * 2000.0;
            refABLineP1.northing = refPoint1.northing - Math.Cos(abHeading) * 2000.0;

            refABLineP2.easting = refPoint1.easting + Math.Sin(abHeading) * 2000.0;
            refABLineP2.northing = refPoint1.northing + Math.Cos(abHeading) * 2000.0;

            isABLineSet = true;
        }

        public void SetABLineByHeading()
        {
            refABLineP1.easting = refPoint1.easting - Math.Sin(abHeading) * 2000.0;
            refABLineP1.northing = refPoint1.northing - Math.Cos(abHeading) * 2000.0;

            refABLineP2.easting = refPoint1.easting + Math.Sin(abHeading) * 2000.0;
            refABLineP2.northing = refPoint1.northing + Math.Cos(abHeading) * 2000.0;

            refPoint2.easting = refABLineP2.easting;
            refPoint2.northing = refABLineP2.northing;

            isABLineSet = true;
        }

        public void snapABLine()
        {
            double headingCalc;
            //calculate the heading 90 degrees to ref ABLine heading 
            if (isOnRightSideCurrentLine) headingCalc = abHeading + glm.PIBy2;
            else headingCalc = abHeading - glm.PIBy2;

            //calculate the new points for the reference line and points
            refPoint1.easting = Math.Sin(headingCalc) * Math.Abs(distanceFromCurrentLine) * 0.001 + refPoint1.easting;
            refPoint1.northing = Math.Cos(headingCalc) * Math.Abs(distanceFromCurrentLine) * 0.001 + refPoint1.northing;

            refABLineP1.easting = refPoint1.easting - Math.Sin(abHeading) * 2000.0;
            refABLineP1.northing = refPoint1.northing - Math.Cos(abHeading) * 2000.0;

            refABLineP2.easting = refPoint1.easting + Math.Sin(abHeading) * 2000.0;
            refABLineP2.northing = refPoint1.northing + Math.Cos(abHeading) * 2000.0;

            refPoint2.easting = refABLineP2.easting;
            refPoint2.northing = refABLineP2.northing;

        }

        public void getCurrentABLine()
        {
            //grab a copy from main
            pivotAxlePosAB = mf.pivotAxlePos;

            //move the ABLine over based on the overlap amount set in vehicle
            double widthMinusOverlap = mf.vehicle.toolWidth - mf.vehicle.toolOverlap;

            //distance from a point to a line defined by two points
            // |(y2-y1)x0 - (x2-x1)y0 + x2y1 - y2x1|
            // --------------------------------------
            // SQRT( (y2-y1)*(y2-y1) + (x2-x1)*(x2-x1) )


            //x2-x1
            double dx = refPoint2.easting - refPoint1.easting;
            //z2-z1
            double dy = refPoint2.northing - refPoint1.northing;

            //how far are we away from the reference line at 90 degrees
            distanceFromRefLine = (dy * pivotAxlePosAB.easting - dx * pivotAxlePosAB.northing + refPoint2.easting *
                                    refPoint1.northing - refPoint2.northing * refPoint1.easting) /
                                        Math.Sqrt(dy * dy + dx * dx);

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

            double toolOffset = mf.vehicle.toolOffset;
            if (passNumber % 2 == 0 | passNumber == 0) toolOffset = 0;
            if (passNumber != 0) toolOffset *= 2.0;
            
            //calculate the new point that is number of implement widths over
            vec2 point1 = new vec2(Math.Cos(-abHeading) * (widthMinusOverlap * howManyPathsAway * refLineSide + toolOffset) + refPoint1.easting,
                Math.Sin(-abHeading) * (widthMinusOverlap * howManyPathsAway * refLineSide + toolOffset) + refPoint1.northing);

            //create the new line extent points for current ABLine based on original heading of AB line
            currentABLineP1.easting = point1.easting - Math.Sin(abHeading) * 10000.0;
            currentABLineP1.northing = point1.northing - Math.Cos(abHeading) * 10000.0;

            currentABLineP2.easting = point1.easting + Math.Sin(abHeading) * 10000.0;
            currentABLineP2.northing = point1.northing + Math.Cos(abHeading) * 10000.0;
           
            //get the distance from currently active AB line
            //x2-x1
            dx = currentABLineP2.easting - currentABLineP1.easting;
            //z2-z1
            dy = currentABLineP2.northing - currentABLineP1.northing;

            //how far from current AB Line is fix
            distanceFromCurrentLine = (dy * pivotAxlePosAB.easting - dx * pivotAxlePosAB.northing + currentABLineP2.easting *
                        currentABLineP1.northing - currentABLineP2.northing * currentABLineP1.easting) /
                            Math.Sqrt(dy * dy + dx * dx);

            //are we on the right side or not
            if (distanceFromCurrentLine > 0) isOnRightSideCurrentLine = true;
            else isOnRightSideCurrentLine = false;

            //absolute the distance
            distanceFromCurrentLine = Math.Abs(distanceFromCurrentLine);

            //Subtract the two headings, if > 1.57 its going the opposite heading as refAB
            abFixHeadingDelta = (Math.Abs(mf.fixHeading - abHeading));
            if (abFixHeadingDelta >= Math.PI) abFixHeadingDelta = Math.Abs(abFixHeadingDelta - glm.twoPI);

            // ** Pure pursuit ** - calc point on ABLine closest to current position      
            if (currentABLineP1.easting == currentABLineP2.easting && currentABLineP1.northing == currentABLineP2.northing) currentABLineP1.easting -= 0.00001;

            dx = currentABLineP2.easting - currentABLineP1.easting;
            dy = currentABLineP2.northing - currentABLineP1.northing;

            double U = (((pivotAxlePosAB.easting - currentABLineP1.easting) * (dx)) +
                        ((pivotAxlePosAB.northing - currentABLineP1.northing) * (dy)))
                        / (dx*dx + dy*dy);

            //point on AB line closest to pivot axle point
            rEastAB = currentABLineP1.easting + (U * dx );
            rNorthAB = currentABLineP1.northing + (U * dy );

            //var minx, maxx, miny, maxy;
            //minx = Math.min(line1.x, line2.x);
            //maxx = Math.max(line1.x, line2.x);
            //miny = Math.min(line1.y, line2.y);
            //maxy = Math.max(line1.y, line2.y);
            //isValid = (r.latitude >= minx && r.latitude <= maxx) && (r.longitude >= miny && r.longitude <= maxy);
            
            //how far should goal point be away  - speed * seconds * kmph -> m/s + min value
            double goalPointDistance = (mf.pn.speed * mf.vehicle.goalPointLookAhead * 0.2777777777);

            if (goalPointDistance < 3.0) goalPointDistance = 3.0;

            if (abFixHeadingDelta >= glm.PIBy2)
            {
                isABSameAsFixHeading = false;
                goalPointAB.easting = rEastAB - Math.Sin(abHeading) * goalPointDistance;
                goalPointAB.northing = rNorthAB - Math.Cos(abHeading) * goalPointDistance;
            }

            else
            {
                isABSameAsFixHeading = true;
                goalPointAB.easting = rEastAB + Math.Sin(abHeading) * goalPointDistance;
                goalPointAB.northing = rNorthAB + Math.Cos(abHeading) * goalPointDistance;
            }

            //calc "D" the distance from pivot axle to lookahead point
            double goalPointDistanceDSquared = mf.pn.DistanceSquared(goalPointAB.northing, goalPointAB.easting, pivotAxlePosAB.northing, pivotAxlePosAB.easting);

            //calculate the the new x in local coordinates and steering angle degrees based on wheelbase
            double localHeading = glm.twoPI - mf.fixHeading;
            ppRadiusAB = goalPointDistanceDSquared / (2 * ((goalPointAB.easting - pivotAxlePosAB.easting) * Math.Cos(localHeading) + (goalPointAB.northing - pivotAxlePosAB.northing) * Math.Sin(localHeading)));

            steerAngleAB = glm.toDegrees(Math.Atan( 2 * (((goalPointAB.easting - pivotAxlePosAB.easting) * Math.Cos(localHeading)) +
                ((goalPointAB.northing - pivotAxlePosAB.northing) * Math.Sin(localHeading))) * mf.vehicle.wheelbase / goalPointDistanceDSquared)) ;

            if (ppRadiusAB < -500) ppRadiusAB = -500;
            if (ppRadiusAB > 500) ppRadiusAB = 500;

            radiusPointAB.easting = pivotAxlePosAB.easting + ppRadiusAB * Math.Cos(localHeading);
            radiusPointAB.northing = pivotAxlePosAB.northing + ppRadiusAB * Math.Sin(localHeading);

            //Convert to millimeters
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
                if (isOnRightSideCurrentLine) distanceFromCurrentLine *= -1.0;
            }

            mf.guidanceLineDistanceOff = (Int16)distanceFromCurrentLine;
            //mf.guidanceLineHeadingDelta = (Int16)((Math.Atan2(Math.Sin(temp - mf.fixHeading),
            //                                    Math.Cos(temp - mf.fixHeading))) * 10000);

            mf.guidanceLineSteerAngle = (Int16)(steerAngleAB * 10);

        }

        public void DrawABLines()
        {
                //Draw AB Points
                gl.PointSize(8.0f);
                gl.Begin(OpenGL.GL_POINTS);

                gl.Color(0.5f, 0.0f, 0.0f);
                gl.Vertex(refPoint1.easting, refPoint1.northing, 0.0);
                gl.Color(0.0f, 0.0f, 0.5f);
                gl.Vertex(refPoint2.easting, refPoint2.northing, 0.0);

                //gl.Color(1.0f, 1.0f, 0.25f);
                //gl.Vertex(rEast, rNorth, 0.0);

                gl.Color(1.0f, 0.5f, 0.95f);
                gl.Vertex(goalPointAB.easting, goalPointAB.northing, 0.0);

                //gl.Color(0.6f, 0.95f, 0.95f);
                //gl.Vertex(radiusPointAB.easting, radiusPointAB.northing, 0.0);

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
                    gl.Vertex(refABLineP1.easting, refABLineP1.northing, 0);
                    gl.Vertex(refABLineP2.easting, refABLineP2.northing, 0);
                    gl.End();

                    gl.LineWidth(1);

                    //getCurrentABLine();

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

                    gl.Vertex(currentABLineP1.easting, currentABLineP1.northing, 0.0);
                    gl.Vertex(currentABLineP2.easting, currentABLineP2.northing, 0.0);
                    gl.End();


                    //{
                    //    gl.Color(0.990f, 0.190f, 0.990f);
                    //    gl.Begin(OpenGL.GL_LINE_LOOP); 
                    //    for(int ii = 0; ii < num_segments; ii++) 
                    //    { 
                    //        double theta = 2.0f * 3.1415926f * (double)(ii) / (double)(num_segments);//get the current angle 

                    //        double x = radius * Math.Cos(theta);//calculate the x component 
                    //        double y = radius * Math.Sin(theta);//calculate the y component 

                    //        gl.Vertex(x + radiusPointAB.easting, y + radiusPointAB.northing);//output vertex 

                    //    } 
                    //    gl.End(); 
                    //}

                    int num_segments = 100;
                    {
                        gl.Color(0.95f, 0.30f, 0.950f);
	                    double theta = glm.twoPI / (double)(num_segments); 
	                    double c = Math.Cos(theta);//precalculate the sine and cosine
	                    double s = Math.Sin(theta);
	                    double t;
    
	                    double x = ppRadiusAB;//we start at angle = 0 
	                    double y = 0; 
    
	                    gl.Begin(OpenGL.GL_LINE_LOOP); 
	                    for(int ii = 0; ii < num_segments; ii++) 
	                    { 
		                    //glVertex2f(x + cx, y + cy);//output vertex 
                            gl.Vertex(x + radiusPointAB.easting, y + radiusPointAB.northing);//output vertex 
        
		                    //apply the rotation matrix
		                    t = x;
		                    x = c * x - s * y;
		                    y = s * t + c * y;
	                    } 
	                    gl.End(); 
                    }

                    gl.LineWidth(1);

                }
        }

        public void ResetABLine()
        {
            refPoint1 = new vec2(0.2, 0.2);
            refPoint2 = new vec2(0.3, 0.3);

            refABLineP1 = new vec2(0.0, 0.0);
            refABLineP2 = new vec2(0.0, 1.0);

            currentABLineP1 = new vec2(0.0, 0.0);
            currentABLineP2 = new vec2(0.0, 1.0);

            abHeading = 0.0;
            isABLineSet = false;
            isABLineBeingSet = false;
            howManyPathsAway = 0.0;
            passNumber = 0;
        }



    }
}
