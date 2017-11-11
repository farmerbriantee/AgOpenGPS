
using System;
using SharpGL;

namespace AgOpenGPS
{
    public class CABLine
    {
        public double abHeading;
        public double abFixHeadingDelta;

        public bool isABSameAsFixHeading = true;
        public bool isOnRightSideCurrentLine = true;

        public double refLineSide = 1.0;

        public double distanceFromRefLine;
        public double distanceFromCurrentLine;
        public double snapDistance;

        public bool isABLineSet;
        public bool isABLineBeingSet;

        public double passNumber;

        public double howManyPathsAway;

        //tramlines
        //Color tramColor = Color.YellowGreen;
        public int tramPassEvery;
        public int passBasedOn;

        //pointers to mainform controls
        private readonly FormGPS mf;
        private readonly OpenGL gl;

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
        public double steerAngleAB;
        public double rEastAB, rNorthAB;
        public double ppRadiusAB;
        public double minLookAheadDistance = 8.0;

        public CABLine(OpenGL _gl, FormGPS _f)
        {
            //constructor
            gl = _gl;
            mf = _f;
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
            refPoint2.easting = mf.pn.easting;
            refPoint2.northing = mf.pn.northing;

            //calculate the AB Heading
            abHeading = Math.Atan2(refPoint2.easting - refPoint1.easting, refPoint2.northing - refPoint1.northing);
            if (abHeading < 0) abHeading += glm.twoPI;

            //sin x cos z for endpoints, opposite for additional lines
            refABLineP1.easting = refPoint1.easting - (Math.Sin(abHeading) * 4000.0);
            refABLineP1.northing = refPoint1.northing - (Math.Cos(abHeading) * 4000.0);

            refABLineP2.easting = refPoint1.easting + (Math.Sin(abHeading) * 4000.0);
            refABLineP2.northing = refPoint1.northing + (Math.Cos(abHeading) * 4000.0);

            isABLineSet = true;
        }

        public void SetABLineByHeading()
        {
            //heading is set in the AB Form
            refABLineP1.easting = refPoint1.easting - (Math.Sin(abHeading) * 4000.0);
            refABLineP1.northing = refPoint1.northing - (Math.Cos(abHeading) * 4000.0);

            refABLineP2.easting = refPoint1.easting + (Math.Sin(abHeading) * 4000.0);
            refABLineP2.northing = refPoint1.northing + (Math.Cos(abHeading) * 4000.0);

            refPoint2.easting = refABLineP2.easting;
            refPoint2.northing = refABLineP2.northing;

            isABLineSet = true;
        }

        public void SnapABLine()
        {
            double headingCalc;
            //calculate the heading 90 degrees to ref ABLine heading 
            if (isOnRightSideCurrentLine) headingCalc = abHeading + glm.PIBy2;
            else headingCalc = abHeading - glm.PIBy2;

            //calculate the new points for the reference line and points
            refPoint1.easting = (Math.Sin(headingCalc) * Math.Abs(distanceFromCurrentLine) * 0.001) + refPoint1.easting;
            refPoint1.northing = (Math.Cos(headingCalc) * Math.Abs(distanceFromCurrentLine) * 0.001) + refPoint1.northing;

            refABLineP1.easting = refPoint1.easting - (Math.Sin(abHeading) * 4000.0);
            refABLineP1.northing = refPoint1.northing - (Math.Cos(abHeading) * 4000.0);

            refABLineP2.easting = refPoint1.easting + (Math.Sin(abHeading) * 4000.0);
            refABLineP2.northing = refPoint1.northing + (Math.Cos(abHeading) * 4000.0);

            refPoint2.easting = refABLineP2.easting;
            refPoint2.northing = refABLineP2.northing;
        }

        public double angVel;

        public void GetCurrentABLine()
        {
            //grab a copy from main
            pivotAxlePosAB = mf.pivotAxlePos;

            //move the ABLine over based on the overlap amount set in vehicle
            double widthMinusOverlap = mf.vehicle.toolWidth - mf.vehicle.toolOverlap;

             //x2-x1
            double dx = refABLineP2.easting - refABLineP1.easting;
            //z2-z1
            double dy = refABLineP2.northing - refABLineP1.northing;

            //how far are we away from the reference line at 90 degrees
            distanceFromRefLine = ((dy * pivotAxlePosAB.easting) - (dx * pivotAxlePosAB.northing) + (refABLineP2.easting
                                    * refABLineP1.northing) - (refABLineP2.northing * refABLineP1.easting))
                                        / Math.Sqrt((dy * dy) + (dx * dx));

            //sign of distance determines which side of line we are on
            if (distanceFromRefLine > 0) refLineSide = 1;
            else refLineSide = -1;

            //absolute the distance
            distanceFromRefLine = Math.Abs(distanceFromRefLine);

            //Which ABLine is the vehicle on, negative is left and positive is right side
            howManyPathsAway = Math.Round(distanceFromRefLine / widthMinusOverlap, 0, MidpointRounding.AwayFromZero);

            //generate that pass number as signed integer
            passNumber = Convert.ToInt32(refLineSide * howManyPathsAway);

            //calculate the new point that is number of implement widths over
            double toolOffset = mf.vehicle.toolOffset;
            vec2 point1;

            //depending which way you are going, the offset can be either side
            if (isABSameAsFixHeading)
            {
                point1 = new vec2((Math.Cos(-abHeading) * ((widthMinusOverlap * howManyPathsAway * refLineSide) - toolOffset)) + refPoint1.easting,
                (Math.Sin(-abHeading) * ((widthMinusOverlap * howManyPathsAway * refLineSide) - toolOffset)) + refPoint1.northing);
            }
            else
            {
                point1 = new vec2((Math.Cos(-abHeading) * ((widthMinusOverlap * howManyPathsAway * refLineSide) + toolOffset)) + refPoint1.easting,
                    (Math.Sin(-abHeading) * ((widthMinusOverlap * howManyPathsAway * refLineSide) + toolOffset)) + refPoint1.northing);
            }

            //create the new line extent points for current ABLine based on original heading of AB line
            currentABLineP1.easting = point1.easting - (Math.Sin(abHeading) * 40000.0);
            currentABLineP1.northing = point1.northing - (Math.Cos(abHeading) * 40000.0);

            currentABLineP2.easting = point1.easting + (Math.Sin(abHeading) * 40000.0);
            currentABLineP2.northing = point1.northing + (Math.Cos(abHeading) * 40000.0);

            //get the distance from currently active AB line
            //x2-x1
            dx = currentABLineP2.easting - currentABLineP1.easting;
            //z2-z1
            dy = currentABLineP2.northing - currentABLineP1.northing;

            //save a copy of dx,dy in youTurn
            mf.yt.dxAB = dx; mf.yt.dyAB = dy;

            //how far from current AB Line is fix
            distanceFromCurrentLine = ((dy * pivotAxlePosAB.easting) - (dx * pivotAxlePosAB.northing) + (currentABLineP2.easting
                        * currentABLineP1.northing) - (currentABLineP2.northing * currentABLineP1.easting))
                        / Math.Sqrt((dy * dy) + (dx * dx));

            //are we on the right side or not
            isOnRightSideCurrentLine = distanceFromCurrentLine > 0;

            //absolute the distance
            distanceFromCurrentLine = Math.Abs(distanceFromCurrentLine);

            //Subtract the two headings, if > 1.57 its going the opposite heading as refAB
            abFixHeadingDelta = (Math.Abs(mf.fixHeading - abHeading));
            if (abFixHeadingDelta >= Math.PI) abFixHeadingDelta = Math.Abs(abFixHeadingDelta - glm.twoPI);

            // ** Pure pursuit ** - calc point on ABLine closest to current position      
            double U = (((pivotAxlePosAB.easting - currentABLineP1.easting) * (dx))
                        + ((pivotAxlePosAB.northing - currentABLineP1.northing) * (dy)))
                        / ((dx * dx) + (dy * dy));

            //point on AB line closest to pivot axle point
            rEastAB = currentABLineP1.easting + (U * dx );
            rNorthAB = currentABLineP1.northing + (U * dy );

            //how far should goal point be away  - speed * seconds * kmph -> m/s + min value
            double goalPointDistance = (mf.pn.speed * mf.vehicle.goalPointLookAhead * 0.2777777777);
            if (goalPointDistance < minLookAheadDistance) goalPointDistance = minLookAheadDistance;

            if (abFixHeadingDelta >= glm.PIBy2)
            {
                isABSameAsFixHeading = false;
                goalPointAB.easting = rEastAB - (Math.Sin(abHeading) * goalPointDistance);
                goalPointAB.northing = rNorthAB - (Math.Cos(abHeading) * goalPointDistance);
            }
            else
            {
                isABSameAsFixHeading = true;
                goalPointAB.easting = rEastAB + (Math.Sin(abHeading) * goalPointDistance);
                goalPointAB.northing = rNorthAB + (Math.Cos(abHeading) * goalPointDistance);
            }

            //calc "D" the distance from pivot axle to lookahead point
            double goalPointDistanceDSquared = mf.pn.DistanceSquared(goalPointAB.northing, goalPointAB.easting, pivotAxlePosAB.northing, pivotAxlePosAB.easting);

            //calculate the the new x in local coordinates and steering angle degrees based on wheelbase
            double localHeading = glm.twoPI - mf.fixHeading;
            ppRadiusAB = goalPointDistanceDSquared / (2 * (((goalPointAB.easting - pivotAxlePosAB.easting) * Math.Cos(localHeading)) + ((goalPointAB.northing - pivotAxlePosAB.northing) * Math.Sin(localHeading))));

            steerAngleAB = glm.toDegrees(Math.Atan( 2 * (((goalPointAB.easting - pivotAxlePosAB.easting) * Math.Cos(localHeading))
                + ((goalPointAB.northing - pivotAxlePosAB.northing) * Math.Sin(localHeading))) * mf.vehicle.wheelbase / goalPointDistanceDSquared)) ;
            if (steerAngleAB < -mf.vehicle.maxSteerAngle) steerAngleAB = -mf.vehicle.maxSteerAngle;
            if (steerAngleAB > mf.vehicle.maxSteerAngle) steerAngleAB = mf.vehicle.maxSteerAngle;

            //limit circle size for display purpose
            if (ppRadiusAB < -500) ppRadiusAB = -500;
            if (ppRadiusAB > 500) ppRadiusAB = 500;

            radiusPointAB.easting = pivotAxlePosAB.easting + (ppRadiusAB * Math.Cos(localHeading));
            radiusPointAB.northing = pivotAxlePosAB.northing + (ppRadiusAB * Math.Sin(localHeading));

            //Convert to millimeters
            distanceFromCurrentLine = Math.Round(distanceFromCurrentLine * 1000.0, MidpointRounding.AwayFromZero);

            //angular velocity in rads/sec  = 2PI * m/sec * radians/meters
            angVel = glm.twoPI * 0.277777 * mf.pn.speed * (Math.Tan(glm.toRadians(steerAngleAB)))/mf.vehicle.wheelbase;

            //clamp the steering angle to not exceed safe angular velocity
            if (Math.Abs(angVel) > mf.vehicle.maxAngularVelocity)
            {
                steerAngleAB = glm.toDegrees(steerAngleAB > 0 ? (Math.Atan((mf.vehicle.wheelbase * mf.vehicle.maxAngularVelocity) / (glm.twoPI * mf.pn.speed * 0.277777)))
                    : (Math.Atan((mf.vehicle.wheelbase * -mf.vehicle.maxAngularVelocity) / (glm.twoPI * mf.pn.speed * 0.277777))));
            }

            //distance is negative if on left, positive if on right
            if (isABSameAsFixHeading)
            {
                if (!isOnRightSideCurrentLine) distanceFromCurrentLine *= -1.0;
            }

            //opposite way so right is left
            else
            {
                //double temp = (abHeading - Math.PI);
                //if (temp < 0) temp = (temp + glm.twoPI);
                if (isOnRightSideCurrentLine) distanceFromCurrentLine *= -1.0;
            }

            //mf.guidanceLineHeadingDelta = (Int16)((Math.Atan2(Math.Sin(temp - mf.fixHeading), Math.Cos(temp - mf.fixHeading))) * 10000);
            mf.guidanceLineDistanceOff = (Int16)distanceFromCurrentLine;
            mf.guidanceLineSteerAngle = (Int16)(steerAngleAB * 10);

            if (mf.yt.isYouTurnOn)
            {
                //do the pure pursuit from youTurn
                mf.yt.DistanceFromYouTurnLine();

                //now substitute what it thinks are AB line values with auto turn values
                steerAngleAB = mf.yt.steerAngleYT;
                distanceFromCurrentLine = mf.yt.distanceFromCurrentLine;

                goalPointAB = mf.yt.goalPointYT;
                radiusPointAB.easting = mf.yt.radiusPointYT.easting;
                radiusPointAB.northing = mf.yt.radiusPointYT.northing;
                ppRadiusAB = mf.yt.ppRadiusYT;
                //angVel
            }
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
                gl.Disable(OpenGL.GL_LINE_STIPPLE);

                //draw current AB Line
                gl.LineWidth(3);
                gl.Begin(OpenGL.GL_LINES);
                gl.Color(0.9f, 0.0f, 0.0f);

                //calculate if tram line is here
                if (tramPassEvery != 0)
                {
                    int pass = (int)passNumber + (tramPassEvery * 300) - passBasedOn;
                    if (pass % tramPassEvery != 0) gl.Color(0.9f, 0.0f, 0.0f);
                    else gl.Color(0, 0.9, 0);
                }

                //based on line pass, make ref purple
                if (Math.Abs(passBasedOn - passNumber) < 0.0000000001 && tramPassEvery != 0) gl.Color(0.990f, 0.190f, 0.990f);

                gl.Vertex(currentABLineP1.easting, currentABLineP1.northing, 0.0);
                gl.Vertex(currentABLineP2.easting, currentABLineP2.northing, 0.0);
                gl.End();

                if (mf.isSideGuideLines)
                {
                    //get the tool offset and width
                    double toolOffset = mf.vehicle.toolOffset * 2;
                    double toolWidth = mf.vehicle.toolWidth - mf.vehicle.toolOverlap;

                    gl.Color(0.0f, 0.90f, 0.50f);
                    gl.LineWidth(1);
                    gl.Begin(OpenGL.GL_LINES);

                    //precalculate sin cos
                    double cosHeading = Math.Cos(-abHeading);
                    double sinHeading = Math.Sin(-abHeading);

                    if (isABSameAsFixHeading)
                    {
                        gl.Vertex((cosHeading * (toolWidth + toolOffset)) + currentABLineP1.easting, (sinHeading * (toolWidth + toolOffset)) + currentABLineP1.northing, 0);
                        gl.Vertex((cosHeading * (toolWidth + toolOffset)) + currentABLineP2.easting, (sinHeading * (toolWidth + toolOffset)) + currentABLineP2.northing, 0);
                        gl.Vertex((cosHeading * (-toolWidth + toolOffset)) + currentABLineP1.easting, (sinHeading * (-toolWidth + toolOffset)) + currentABLineP1.northing, 0);
                        gl.Vertex((cosHeading * (-toolWidth + toolOffset)) + currentABLineP2.easting, (sinHeading * (-toolWidth + toolOffset)) + currentABLineP2.northing, 0);

                        toolWidth *= 2;
                        gl.Vertex((cosHeading * (toolWidth)) + currentABLineP1.easting, (sinHeading * (toolWidth)) + currentABLineP1.northing, 0);
                        gl.Vertex((cosHeading * (toolWidth)) + currentABLineP2.easting, (sinHeading * (toolWidth)) + currentABLineP2.northing, 0);
                        gl.Vertex((cosHeading * (-toolWidth)) + currentABLineP1.easting, (sinHeading * (-toolWidth)) + currentABLineP1.northing, 0);
                        gl.Vertex((cosHeading * (-toolWidth)) + currentABLineP2.easting, (sinHeading * (-toolWidth)) + currentABLineP2.northing, 0);
                    }
                    else
                    {
                        gl.Vertex((cosHeading * (toolWidth - toolOffset)) + currentABLineP1.easting, (sinHeading * (toolWidth - toolOffset)) + currentABLineP1.northing, 0);
                        gl.Vertex((cosHeading * (toolWidth - toolOffset)) + currentABLineP2.easting, (sinHeading * (toolWidth - toolOffset)) + currentABLineP2.northing, 0);
                        gl.Vertex((cosHeading * (-toolWidth - toolOffset)) + currentABLineP1.easting, (sinHeading * (-toolWidth - toolOffset)) + currentABLineP1.northing, 0);
                        gl.Vertex((cosHeading * (-toolWidth - toolOffset)) + currentABLineP2.easting, (sinHeading * (-toolWidth - toolOffset)) + currentABLineP2.northing, 0);

                        toolWidth *= 2;
                        gl.Vertex((cosHeading * (toolWidth)) + currentABLineP1.easting, (sinHeading * (toolWidth)) + currentABLineP1.northing, 0);
                        gl.Vertex((cosHeading * (toolWidth)) + currentABLineP2.easting, (sinHeading * (toolWidth)) + currentABLineP2.northing, 0);
                        gl.Vertex((cosHeading * (-toolWidth)) + currentABLineP1.easting, (sinHeading * (-toolWidth)) + currentABLineP1.northing, 0);
                        gl.Vertex((cosHeading * (-toolWidth)) + currentABLineP2.easting, (sinHeading * (-toolWidth)) + currentABLineP2.northing, 0);
                    }
                    gl.End();
                }

                if (mf.isPureDisplayOn)
                {
                    //draw the guidance circle
                    const int numSegments = 100;
                    {
                        gl.Color(0.95f, 0.30f, 0.950f);
                        double theta = glm.twoPI / numSegments;
                        double c = Math.Cos(theta);//precalculate the sine and cosine
                        double s = Math.Sin(theta);

                        double x = ppRadiusAB;//we start at angle = 0 
                        double y = 0;

                        gl.LineWidth(1);
                        gl.Begin(OpenGL.GL_LINE_LOOP);
                        for (int ii = 0; ii < numSegments; ii++)
                        {
                            //output vertex 
                            gl.Vertex(x + radiusPointAB.easting, y + radiusPointAB.northing);

                            //apply the rotation matrix
                            double t = x;
                            x = (c * x) - (s * y);
                            y = (s * t) + (c * y);
                        }
                        gl.End();
                    }
                    //Draw lookahead Point
                    gl.PointSize(4.0f);
                    gl.Begin(OpenGL.GL_POINTS);
                    gl.Color(1.0f, 0.5f, 0.95f);
                    gl.Vertex(goalPointAB.easting, goalPointAB.northing, 0.0);
                    //gl.Color(0.6f, 0.95f, 0.95f);
                    //gl.Vertex(mf.at.rEastAT, mf.at.rNorthAT, 0.0);
                    //gl.Color(0.6f, 0.95f, 0.95f);
                    //gl.Vertex(mf.at.turnRadiusPt.easting, mf.at.turnRadiusPt.northing, 0.0);
                    gl.End();
                    gl.PointSize(1.0f);
                }

                if (mf.yt.isYouTurnOn)
                {
                    gl.Color(0.95f, 0.95f, 0.25f);
                    gl.LineWidth(2);
                    int ptCount = mf.yt.ytList.Count;
                    if (ptCount > 0)
                    {
                        gl.Begin(OpenGL.GL_LINE_STRIP);
                        for (int i = 0; i < ptCount; i++)
                        {
                            gl.Vertex(mf.yt.ytList[i].x, mf.yt.ytList[i].z, 0);
                        }
                        gl.End();
                    }

                    gl.Color(0.95f, 0.05f, 0.05f);
                }

                if (mf.yt.isRecordingYouTurn)
                {
                    gl.Color(0.05f, 0.05f, 0.95f);
                    gl.PointSize(4.0f);
                    int ptCount = mf.yt.youFileList.Count;
                    if (ptCount > 1)
                    {
                        gl.Begin(OpenGL.GL_POINTS);
                        for (int i = 1; i < ptCount; i++)
                        {
                            gl.Vertex(mf.yt.youFileList[i].easting + mf.yt.youFileList[0].easting, mf.yt.youFileList[i].northing + mf.yt.youFileList[0].northing, 0);
                        }
                        gl.End();
                    }
                }

                gl.PointSize(1.0f);
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
