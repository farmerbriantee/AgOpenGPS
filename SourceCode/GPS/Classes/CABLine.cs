using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public class CABLine
    {
        public double abFixHeadingDelta;
        public double abHeading, abLength;
        public double angVel;

        //the current AB guidance line
        public vec3 currentABLineP1 = new vec3(0.0, 0.0, 0.0);
        public vec3 currentABLineP2 = new vec3(0.0, 1.0, 0.0);

        public double distanceFromCurrentLinePivot;
        public double distanceFromRefLine;
        //pure pursuit values
        public vec2 goalPointAB = new vec2(0, 0);

        //List of all available ABLines
        public List<CABLines> lineArr = new List<CABLines>();

        public int numABLines, numABLineSelected;

        public double howManyPathsAway, moveDistance;
        public bool isABLineBeingSet;
        public bool isABLineSet, isABLineLoaded;
        public bool isABSameAsVehicleHeading = true;
        public bool isABRefSameAsVehicleHeading = true;
        public bool isBtnABLineOn;
        public bool isOnRightSideCurrentLine = true;

        //public bool isOnTramLine;
        //public int tramBasedOn;
        public double ppRadiusAB;
        public vec2 radiusPointAB = new vec2(0, 0);
        public double rEastAB, rNorthAB;
        //the reference line endpoints
        public vec2 refABLineP1 = new vec2(0.0, 0.0);
        public vec2 refABLineP2 = new vec2(0.0, 1.0);

        //the two inital A and B points
        public vec2 refPoint1 = new vec2(0.2, 0.15);
        public vec2 refPoint2 = new vec2(0.3, 0.3);

        public double snapDistance, lastSecond = 0;
        public double steerAngleAB;
        public int lineWidth;

        //design
        public vec2 desPoint1 = new vec2(0.2, 0.15);
        public vec2 desPoint2 = new vec2(0.3, 0.3);
        public double desHeading = 0;
        public vec2 desP1 = new vec2(0.0, 0.0);
        public vec2 desP2 = new vec2(999997, 1.0);
        public string desName = "";

        public double pivotDistanceError, pivotDistanceErrorLast, pivotDerivative, pivotDerivativeSmoothed;
        //derivative counters
        private int counter2;
        public double inty;
        public double steerAngleSmoothed, pivotErrorTotal;
        public double distSteerError, lastDistSteerError, derivativeDistError;


        //Color tramColor = Color.YellowGreen;
        public int tramPassEvery;
        //pointers to mainform controls
        private readonly FormGPS mf;

        public CABLine(FormGPS _f)
        {
            //constructor
            mf = _f;
            //isOnTramLine = true;
            lineWidth = Properties.Settings.Default.setDisplay_lineWidth;
            abLength = Properties.Settings.Default.setAB_lineLength;
        }

        public void GetCurrentABLine(vec3 pivot, vec3 steer)
        {
            double dx, dy;


            if ((mf.secondsSinceStart - lastSecond) > 2)
            {
                lastSecond = mf.secondsSinceStart;


                //move the ABLine over based on the overlap amount set in vehicle
                double widthMinusOverlap = mf.tool.toolWidth - mf.tool.toolOverlap;

                //x2-x1
                dx = refABLineP2.easting - refABLineP1.easting;
                //z2-z1
                dy = refABLineP2.northing - refABLineP1.northing;

                //how far are we away from the reference line at 90 degrees
                distanceFromRefLine = ((dy * pivot.easting) - (dx * pivot.northing) + (refABLineP2.easting
                                        * refABLineP1.northing) - (refABLineP2.northing * refABLineP1.easting))
                                            / Math.Sqrt((dy * dy) + (dx * dx));

                //Which ABLine is the vehicle on, negative is left and positive is right side
                double RefDist = (distanceFromRefLine + (isABSameAsVehicleHeading ? mf.tool.toolOffset : -mf.tool.toolOffset)) / widthMinusOverlap;
                if (RefDist < 0) howManyPathsAway = (int)(RefDist - 0.5);
                else howManyPathsAway = (int)(RefDist + 0.5);

                //depending which way you are going, the offset can be either side
                vec2 point1 = new vec2((Math.Cos(-abHeading) * (widthMinusOverlap * howManyPathsAway + (isABSameAsVehicleHeading ? -mf.tool.toolOffset : mf.tool.toolOffset))) + refPoint1.easting,
                (Math.Sin(-abHeading) * ((widthMinusOverlap * howManyPathsAway) + (isABSameAsVehicleHeading ? -mf.tool.toolOffset : mf.tool.toolOffset))) + refPoint1.northing);

                //create the new line extent points for current ABLine based on original heading of AB line
                currentABLineP1.easting = point1.easting - (Math.Sin(abHeading) * abLength);
                currentABLineP1.northing = point1.northing - (Math.Cos(abHeading) * abLength);

                currentABLineP2.easting = point1.easting + (Math.Sin(abHeading) * abLength);
                currentABLineP2.northing = point1.northing + (Math.Cos(abHeading) * abLength);

                currentABLineP1.heading = abHeading;
                currentABLineP2.heading = abHeading;
            }

            if (mf.isStanleyUsed)
            {
                bool isValid = true;
                mf.gyd.StanleyGuidanceABLine(currentABLineP1, currentABLineP2, pivot, steer, isValid);
            }
            else
            {
                isABRefSameAsVehicleHeading = Math.PI - Math.Abs(Math.Abs(pivot.heading - abHeading) - Math.PI) < glm.PIBy2;

                //get the distance from currently active AB line
                //x2-x1
                dx = currentABLineP2.easting - currentABLineP1.easting;
                //z2-z1
                dy = currentABLineP2.northing - currentABLineP1.northing;

                //save a copy of dx,dy in youTurn
                mf.yt.dxAB = dx; mf.yt.dyAB = dy;

                //how far from current AB Line is fix
                distanceFromCurrentLinePivot = ((dy * pivot.easting) - (dx * pivot.northing) + (currentABLineP2.easting
                            * currentABLineP1.northing) - (currentABLineP2.northing * currentABLineP1.easting))
                            / Math.Sqrt((dy * dy) + (dx * dx));

                //are we on the right side or not
                isOnRightSideCurrentLine = distanceFromCurrentLinePivot > 0;

                //integral slider is set to 0
                if (mf.vehicle.purePursuitIntegralGain != 0)
                {
                    pivotDistanceError = distanceFromCurrentLinePivot * 0.2 + pivotDistanceError * 0.8;

                    if (counter2++ > 4)
                    {
                        pivotDerivative = pivotDistanceError - pivotDistanceErrorLast;
                        pivotDistanceErrorLast = pivotDistanceError;
                        counter2 = 0;
                        pivotDerivative *= 2;

                        //limit the derivative
                        //if (pivotDerivative > 0.03) pivotDerivative = 0.03;
                        //if (pivotDerivative < -0.03) pivotDerivative = -0.03;
                        //if (Math.Abs(pivotDerivative) < 0.01) pivotDerivative = 0;
                    }

                    //pivotErrorTotal = pivotDistanceError + pivotDerivative;

                    if (mf.isAutoSteerBtnOn
                        && Math.Abs(pivotDerivative) < (0.1)
                        && mf.avgSpeed > 2.5
                        && !mf.yt.isYouTurnTriggered)
                    //&& Math.Abs(pivotDistanceError) < 0.2)

                    {
                        //if over the line heading wrong way, rapidly decrease integral
                        if ((inty < 0 && distanceFromCurrentLinePivot < 0) || (inty > 0 && distanceFromCurrentLinePivot > 0))
                        {
                            inty += pivotDistanceError * mf.vehicle.purePursuitIntegralGain * -0.04;
                        }
                        else
                        {
                            if (Math.Abs(distanceFromCurrentLinePivot) > 0.02)
                            {
                                inty += pivotDistanceError * mf.vehicle.purePursuitIntegralGain * -0.02;
                                if (inty > 0.2) inty = 0.2;
                                else if (inty < -0.2) inty = -0.2;
                            }
                        }
                    }
                    else inty *= 0.95;
                }
                else inty = 0;

                //absolute the distance
                distanceFromCurrentLinePivot = Math.Abs(distanceFromCurrentLinePivot);

                //update base on autosteer settings and distance from line
                double goalPointDistance = mf.vehicle.UpdateGoalPointDistance();

                //Subtract the two headings, if > 1.57 its going the opposite heading as refAB
                abFixHeadingDelta = (Math.Abs(mf.fixHeading - abHeading));
                if (abFixHeadingDelta >= Math.PI) abFixHeadingDelta = Math.Abs(abFixHeadingDelta - glm.twoPI);

                // ** Pure pursuit ** - calc point on ABLine closest to current position
                double U = (((pivot.easting - currentABLineP1.easting) * dx)
                            + ((pivot.northing - currentABLineP1.northing) * dy))
                            / ((dx * dx) + (dy * dy));

                //point on AB line closest to pivot axle point
                rEastAB = currentABLineP1.easting + (U * dx);
                rNorthAB = currentABLineP1.northing + (U * dy);

                if (abFixHeadingDelta >= glm.PIBy2)
                {
                    isABSameAsVehicleHeading = false;
                    goalPointAB.easting = rEastAB - (Math.Sin(abHeading) * goalPointDistance);
                    goalPointAB.northing = rNorthAB - (Math.Cos(abHeading) * goalPointDistance);
                }
                else
                {
                    isABSameAsVehicleHeading = true;
                    goalPointAB.easting = rEastAB + (Math.Sin(abHeading) * goalPointDistance);
                    goalPointAB.northing = rNorthAB + (Math.Cos(abHeading) * goalPointDistance);
                }

                //calc "D" the distance from pivot axle to lookahead point
                double goalPointDistanceDSquared
                    = glm.DistanceSquared(goalPointAB.northing, goalPointAB.easting, pivot.northing, pivot.easting);

                //calculate the the new x in local coordinates and steering angle degrees based on wheelbase
                double localHeading;

                if (isABSameAsVehicleHeading) localHeading = glm.twoPI - mf.fixHeading + inty;
                else localHeading = glm.twoPI - mf.fixHeading - inty;

                ppRadiusAB = goalPointDistanceDSquared / (2 * (((goalPointAB.easting - pivot.easting) * Math.Cos(localHeading))
                    + ((goalPointAB.northing - pivot.northing) * Math.Sin(localHeading))));

                steerAngleAB = glm.toDegrees(Math.Atan(2 * (((goalPointAB.easting - pivot.easting) * Math.Cos(localHeading))
                    + ((goalPointAB.northing - pivot.northing) * Math.Sin(localHeading))) * mf.vehicle.wheelbase
                    / goalPointDistanceDSquared));
                if (steerAngleAB < -mf.vehicle.maxSteerAngle) steerAngleAB = -mf.vehicle.maxSteerAngle;
                if (steerAngleAB > mf.vehicle.maxSteerAngle) steerAngleAB = mf.vehicle.maxSteerAngle;

                //limit circle size for display purpose
                if (ppRadiusAB < -500) ppRadiusAB = -500;
                if (ppRadiusAB > 500) ppRadiusAB = 500;

                radiusPointAB.easting = pivot.easting + (ppRadiusAB * Math.Cos(localHeading));
                radiusPointAB.northing = pivot.northing + (ppRadiusAB * Math.Sin(localHeading));

                //Convert to millimeters
                distanceFromCurrentLinePivot = Math.Round(distanceFromCurrentLinePivot * 1000.0, MidpointRounding.AwayFromZero);

                //angular velocity in rads/sec  = 2PI * m/sec * radians/meters
                angVel = glm.twoPI * 0.277777 * mf.pn.speed * (Math.Tan(glm.toRadians(steerAngleAB))) / mf.vehicle.wheelbase;

                //clamp the steering angle to not exceed safe angular velocity
                if (Math.Abs(angVel) > mf.vehicle.maxAngularVelocity)
                {
                    steerAngleAB = glm.toDegrees(steerAngleAB > 0 ? (Math.Atan((mf.vehicle.wheelbase * mf.vehicle.maxAngularVelocity)
                        / (glm.twoPI * mf.pn.speed * 0.277777)))
                        : (Math.Atan((mf.vehicle.wheelbase * -mf.vehicle.maxAngularVelocity) / (glm.twoPI * mf.pn.speed * 0.277777))));
                }

                //distance is negative if on left, positive if on right
                if (isABSameAsVehicleHeading)
                {
                    if (!isOnRightSideCurrentLine)
                    {
                        distanceFromCurrentLinePivot *= -1.0;
                    }
                }

                //opposite way so right is left
                else
                {
                    if (isOnRightSideCurrentLine)
                    {
                        distanceFromCurrentLinePivot *= -1.0;
                    }
                    isOnRightSideCurrentLine = !isOnRightSideCurrentLine;
                }

                mf.guidanceLineDistanceOff = mf.distanceDisplayPivot = (short)distanceFromCurrentLinePivot;
                //mf.distanceDisplaySteer = (short)distanceFromCurrentLineSteer;
                mf.distanceDisplaySteer = 0;// (short)distanceFromCurrentLineSteer;
                mf.guidanceLineSteerAngle = (Int16)(steerAngleAB * 100);
            }

            if (mf.yt.isYouTurnTriggered)
            {
                //do the pure pursuit from youTurn
                mf.yt.DistanceFromYouTurnLine();
            }
        }

        public void DrawABLines()
        {
            //Draw AB Points
            GL.PointSize(8.0f);
            GL.Begin(PrimitiveType.Points);

            GL.Color3(0.95f, 0.0f, 0.0f);
            GL.Vertex3(refPoint1.easting, refPoint1.northing, 0.0);
            GL.Color3(0.0f, 0.90f, 0.95f);
            GL.Vertex3(refPoint2.easting, refPoint2.northing, 0.0);
            GL.End();

            if (mf.font.isFontOn)
            {
                mf.font.DrawText3D(refPoint1.easting, refPoint1.northing, "&A");
                mf.font.DrawText3D(refPoint2.easting, refPoint2.northing, "&B");
            }

            GL.PointSize(1.0f);

            //Draw reference AB line
            GL.LineWidth(lineWidth);
            GL.Enable(EnableCap.LineStipple);
            GL.LineStipple(1, 0x0F00);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(0.930f, 0.2f, 0.2f);
            GL.Vertex3(refABLineP1.easting, refABLineP1.northing, 0);
            GL.Vertex3(refABLineP2.easting, refABLineP2.northing, 0);
            GL.End();
            GL.Disable(EnableCap.LineStipple);

            //draw current AB Line
            GL.LineWidth(lineWidth);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(0.95f, 0.20f, 0.950f);
            GL.Vertex3(currentABLineP1.easting, currentABLineP1.northing, 0.0);
            GL.Vertex3(currentABLineP2.easting, currentABLineP2.northing, 0.0);
            GL.End();

            //ABLine currently being designed
            if (isABLineBeingSet)
            {
                GL.LineWidth(lineWidth);
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(0.95f, 0.20f, 0.950f);
                GL.Vertex3(desP1.easting, desP1.northing, 0.0);
                GL.Vertex3(desP2.easting, desP2.northing, 0.0);
                GL.End();

                GL.Color3(0.2f, 0.950f, 0.20f);
                mf.font.DrawText3D(desPoint1.easting, desPoint1.northing, "&A");
                mf.font.DrawText3D(desPoint2.easting, desPoint2.northing, "&B");
            }

            if (mf.isSideGuideLines && mf.camera.camSetDistance > mf.tool.toolWidth * -120)
            {
                //get the tool offset and width
                double toolOffset = mf.tool.toolOffset * 2;
                double toolWidth = mf.tool.toolWidth - mf.tool.toolOverlap;
                double cosHeading = Math.Cos(-abHeading);
                double sinHeading = Math.Sin(-abHeading);

                GL.Color3(0.56f, 0.650f, 0.650f);
                GL.Enable(EnableCap.LineStipple);
                GL.LineStipple(1, 0x0101);

                GL.LineWidth(lineWidth);
                GL.Begin(PrimitiveType.Lines);

                /*
                for (double i = -2.5; i < 3; i++)
                {
                    GL.Vertex3((cosHeading * ((mf.tool.toolWidth - mf.tool.toolOverlap) * (howManyPathsAway + i))) + refPoint1.easting, (sinHeading * ((mf.tool.toolWidth - mf.tool.toolOverlap) * (howManyPathsAway + i))) + refPoint1.northing, 0);
                    GL.Vertex3((cosHeading * ((mf.tool.toolWidth - mf.tool.toolOverlap) * (howManyPathsAway + i))) + refPoint2.easting, (sinHeading * ((mf.tool.toolWidth - mf.tool.toolOverlap) * (howManyPathsAway + i))) + refPoint2.northing, 0);
                }
                */

                if (isABSameAsVehicleHeading)
                {
                    GL.Vertex3((cosHeading * (toolWidth + toolOffset)) + currentABLineP1.easting, (sinHeading * (toolWidth + toolOffset)) + currentABLineP1.northing, 0);
                    GL.Vertex3((cosHeading * (toolWidth + toolOffset)) + currentABLineP2.easting, (sinHeading * (toolWidth + toolOffset)) + currentABLineP2.northing, 0);
                    GL.Vertex3((cosHeading * (-toolWidth + toolOffset)) + currentABLineP1.easting, (sinHeading * (-toolWidth + toolOffset)) + currentABLineP1.northing, 0);
                    GL.Vertex3((cosHeading * (-toolWidth + toolOffset)) + currentABLineP2.easting, (sinHeading * (-toolWidth + toolOffset)) + currentABLineP2.northing, 0);

                    toolWidth *= 2;
                    GL.Vertex3((cosHeading * toolWidth) + currentABLineP1.easting, (sinHeading * toolWidth) + currentABLineP1.northing, 0);
                    GL.Vertex3((cosHeading * toolWidth) + currentABLineP2.easting, (sinHeading * toolWidth) + currentABLineP2.northing, 0);
                    GL.Vertex3((cosHeading * (-toolWidth)) + currentABLineP1.easting, (sinHeading * (-toolWidth)) + currentABLineP1.northing, 0);
                    GL.Vertex3((cosHeading * (-toolWidth)) + currentABLineP2.easting, (sinHeading * (-toolWidth)) + currentABLineP2.northing, 0);
                }
                else
                {
                    GL.Vertex3((cosHeading * (toolWidth - toolOffset)) + currentABLineP1.easting, (sinHeading * (toolWidth - toolOffset)) + currentABLineP1.northing, 0);
                    GL.Vertex3((cosHeading * (toolWidth - toolOffset)) + currentABLineP2.easting, (sinHeading * (toolWidth - toolOffset)) + currentABLineP2.northing, 0);
                    GL.Vertex3((cosHeading * (-toolWidth - toolOffset)) + currentABLineP1.easting, (sinHeading * (-toolWidth - toolOffset)) + currentABLineP1.northing, 0);
                    GL.Vertex3((cosHeading * (-toolWidth - toolOffset)) + currentABLineP2.easting, (sinHeading * (-toolWidth - toolOffset)) + currentABLineP2.northing, 0);

                    toolWidth *= 2;
                    GL.Vertex3((cosHeading * toolWidth) + currentABLineP1.easting, (sinHeading * toolWidth) + currentABLineP1.northing, 0);
                    GL.Vertex3((cosHeading * toolWidth) + currentABLineP2.easting, (sinHeading * toolWidth) + currentABLineP2.northing, 0);
                    GL.Vertex3((cosHeading * (-toolWidth)) + currentABLineP1.easting, (sinHeading * (-toolWidth)) + currentABLineP1.northing, 0);
                    GL.Vertex3((cosHeading * (-toolWidth)) + currentABLineP2.easting, (sinHeading * (-toolWidth)) + currentABLineP2.northing, 0);
                }

                GL.End();
                GL.Disable(EnableCap.LineStipple);
            }

            if (!mf.isStanleyUsed && mf.camera.camSetDistance > -100)
            {
                //Draw lookahead Point
                GL.PointSize(8.0f);
                GL.Begin(PrimitiveType.Points);
                GL.Color3(1.0f, 1.0f, 0.0f);
                GL.Vertex3(goalPointAB.easting, goalPointAB.northing, 0.0);
                //GL.Vertex3(mf.gyd.rEastSteer, mf.gyd.rNorthSteer, 0.0);
                //GL.Vertex3(mf.gyd.rEastPivot, mf.gyd.rNorthPivot, 0.0);
                GL.End();
                GL.PointSize(1.0f);
            }

            mf.yt.DrawYouTurn();

            GL.PointSize(1.0f);
            GL.LineWidth(1);
        }

        public void BuildTram()
        {
            mf.tram.BuildTramBnd();

            mf.tram.tramList?.Clear();
            mf.tram.tramArr?.Clear();
            List<vec2> tramRef = new List<vec2>();

            bool isBndExist = mf.bnd.bndArr.Count != 0;

            double pass = 0.5;
            double hsin = Math.Sin(abHeading);
            double hcos = Math.Cos(abHeading);

            //divide up the AB line into segments
            vec2 P1 = new vec2();
            for (int i = 0; i < 3200; i += 4)
            {
                P1.easting = (hsin * i) + refABLineP1.easting;
                P1.northing = (hcos * i) + refABLineP1.northing;
                tramRef.Add(P1);
            }

            //create list of list of points of triangle strip of AB Highlight
            double headingCalc = abHeading + glm.PIBy2;
            hsin = Math.Sin(headingCalc);
            hcos = Math.Cos(headingCalc);

            mf.tram.tramList?.Clear();
            mf.tram.tramArr?.Clear();

            //no boundary starts on first pass
            int cntr = 0;
            if (isBndExist) cntr = 1;

            for (int i = cntr; i < mf.tram.passes; i++)
            {
                mf.tram.tramArr = new List<vec2>();
                mf.tram.tramList.Add(mf.tram.tramArr);

                for (int j = 0; j < tramRef.Count; j++)
                {
                    P1.easting = (hsin * ((mf.tram.tramWidth * (pass + i)) - mf.tram.halfWheelTrack + mf.tool.halfToolWidth)) + tramRef[j].easting;
                    P1.northing = (hcos * ((mf.tram.tramWidth * (pass + i)) - mf.tram.halfWheelTrack + mf.tool.halfToolWidth)) + tramRef[j].northing;

                    if (isBndExist)
                    {
                        if (mf.bnd.bndArr[0].IsPointInsideBoundaryEar(P1))
                        {
                            mf.tram.tramArr.Add(P1);
                        }
                    }
                    else
                    {
                        mf.tram.tramArr.Add(P1);
                    }
                }
            }

            for (int i = cntr; i < mf.tram.passes; i++)
            {
                mf.tram.tramArr = new List<vec2>();
                mf.tram.tramList.Add(mf.tram.tramArr);

                for (int j = 0; j < tramRef.Count; j++)
                {
                    P1.easting = (hsin * ((mf.tram.tramWidth * (pass + i)) + mf.tram.halfWheelTrack + mf.tool.halfToolWidth)) + tramRef[j].easting;
                    P1.northing = (hcos * ((mf.tram.tramWidth * (pass + i)) + mf.tram.halfWheelTrack + mf.tool.halfToolWidth)) + tramRef[j].northing;

                    if (isBndExist)
                    {
                        if (mf.bnd.bndArr[0].IsPointInsideBoundaryEar(P1))
                        {
                            mf.tram.tramArr.Add(P1);
                        }
                    }
                    else
                    {
                        mf.tram.tramArr.Add(P1);
                    }
                }
            }

            tramRef?.Clear();
            //outside tram

            if (mf.bnd.bndArr.Count == 0 || mf.tram.passes != 0)
            {
                //return;
            }
        }

        public void DeleteAB()
        {
            refPoint1 = new vec2(0.0, 0.0);
            refPoint2 = new vec2(0.0, 1.0);

            refABLineP1 = new vec2(0.0, 0.0);
            refABLineP2 = new vec2(0.0, 1.0);

            currentABLineP1 = new vec3(0.0, 0.0, 0.0);
            currentABLineP2 = new vec3(0.0, 1.0, 0.0);

            abHeading = 0.0;
            howManyPathsAway = 0.0;
            isABLineSet = false;
            isABLineLoaded = false;
        }

        public void SetABLineByBPoint()
        {
            refPoint2.easting = mf.pn.fix.easting;
            refPoint2.northing = mf.pn.fix.northing;

            //calculate the AB Heading
            abHeading = Math.Atan2(refPoint2.easting - refPoint1.easting, refPoint2.northing - refPoint1.northing);
            if (abHeading < 0) abHeading += glm.twoPI;

            //sin x cos z for endpoints, opposite for additional lines
            refABLineP1.easting = refPoint1.easting - (Math.Sin(abHeading) * abLength);
            refABLineP1.northing = refPoint1.northing - (Math.Cos(abHeading) * abLength);

            refABLineP2.easting = refPoint1.easting + (Math.Sin(abHeading) * abLength);
            refABLineP2.northing = refPoint1.northing + (Math.Cos(abHeading) * abLength);

            isABLineSet = true;
            isABLineLoaded = true;
        }

        public void SetABLineByHeading()
        {
            //heading is set in the AB Form
            refABLineP1.easting = refPoint1.easting - (Math.Sin(abHeading) * abLength);
            refABLineP1.northing = refPoint1.northing - (Math.Cos(abHeading) * abLength);

            refABLineP2.easting = refPoint1.easting + (Math.Sin(abHeading) * abLength);
            refABLineP2.northing = refPoint1.northing + (Math.Cos(abHeading) * abLength);

            refPoint2.easting = refABLineP2.easting;
            refPoint2.northing = refABLineP2.northing;

            isABLineSet = true;
            isABLineLoaded = true;
        }

        public void MoveABLine(double dist)
        {
            double headingCalc;
            //calculate the heading 90 degrees to ref ABLine heading
            if (isABRefSameAsVehicleHeading)
            {
                headingCalc = abHeading + glm.PIBy2;
                moveDistance += dist;
            }
            else
            {
                headingCalc = abHeading - glm.PIBy2;
                moveDistance -= dist;
            }

            //calculate the new points for the reference line and points
            refPoint1.easting = (Math.Sin(headingCalc) * dist) + refPoint1.easting;
            refPoint1.northing = (Math.Cos(headingCalc) * dist) + refPoint1.northing;

            refABLineP1.easting = refPoint1.easting - (Math.Sin(abHeading) * abLength);
            refABLineP1.northing = refPoint1.northing - (Math.Cos(abHeading) * abLength);

            refABLineP2.easting = refPoint1.easting + (Math.Sin(abHeading) * abLength);
            refABLineP2.northing = refPoint1.northing + (Math.Cos(abHeading) * abLength);

            refPoint2.easting = refABLineP2.easting;
            refPoint2.northing = refABLineP2.northing;
            lastSecond = 0;
        }

        public void SnapABLine()
        {
            double headingCalc;

            //calculate the heading 90 degrees to ref ABLine heading
            if (isOnRightSideCurrentLine)
            {

                headingCalc = abHeading + glm.PIBy2;
            }
            else
            {
                headingCalc = abHeading - glm.PIBy2;
            }

            double snapD;
            if (mf.isStanleyUsed) snapD = mf.gyd.distanceFromCurrentLinePivot;
            else snapD = distanceFromCurrentLinePivot;

            snapD *= 0.001;

            if (isABRefSameAsVehicleHeading)
            {
                moveDistance += (snapD);
            }
            else
            {
                headingCalc += Math.PI;
                moveDistance -= (snapD);
            }

            //calculate the new points for the reference line and points
            refPoint1.easting = (Math.Sin(headingCalc) * Math.Abs(snapD)) + refPoint1.easting;
            refPoint1.northing = (Math.Cos(headingCalc) * Math.Abs(snapD)) + refPoint1.northing;

            //refPoint1.easting = mf.pivotAxlePos.easting;
            //refPoint1.northing = mf.pivotAxlePos.northing;

            refABLineP1.easting = refPoint1.easting - (Math.Sin(abHeading) * abLength);
            refABLineP1.northing = refPoint1.northing - (Math.Cos(abHeading) * abLength);

            refABLineP2.easting = refPoint1.easting + (Math.Sin(abHeading) * abLength);
            refABLineP2.northing = refPoint1.northing + (Math.Cos(abHeading) * abLength);

            refPoint2.easting = refABLineP2.easting;
            refPoint2.northing = refABLineP2.northing;
            lastSecond = 0;
        }
    }

    public class CABLines
    {
        public vec2 ref1 = new vec2();
        public vec2 ref2 = new vec2();
        public vec2 origin = new vec2();
        public double heading = 0;
        public string Name = "aa";
    }

}