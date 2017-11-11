using System;
using System.Collections.Generic;
using SharpGL;
using System.IO;
using System.Globalization;

namespace AgOpenGPS
{
    public class CYouTurn
    {
        //copy of the mainform address
        private readonly FormGPS mf;
        private readonly OpenGL gl;

        public bool isYouTurnOn, isAutoTriggered, isAutoPointSet, isAutoTurnRight, isLastAutoTurnRight;
        public bool isRecordingYouTurn, isAutoYouTurnEnabled;
        public int startYouTurnAt;

        //guidance values
        public double distanceFromCurrentLine;
        public double dxAB, dyAB;
        private int A, B, C;
        public double abHeading;
        public bool isABSameAsFixHeading = true;
        public bool isOnRightSideCurrentLine = true;

        //pure pursuit values
        public vec2 pivotAxlePosYT = new vec2(0, 0);
        public vec2 goalPointYT = new vec2(0, 0);
        public vec2 radiusPointYT = new vec2(0, 0);
        public double steerAngleYT;
        public double rEastYT, rNorthYT;
        public double ppRadiusYT;
        private double minLookAheadDistance;
        private int numShapePoints;

        //list of points for scaled and rotated YouTurn line
        public List<vec4> ytList = new List<vec4>();

        //list of points read from file, this is the actual pattern from a bunch of sources possible
        public List<vec2> youFileList = new List<vec2>();

        public vec2 autoYouTurnTriggerPoint = new vec2(0, 0);

        //constructor
        public CYouTurn(OpenGL _gl, FormGPS _f)
        {
            mf = _f;
            gl = _gl;

            //how far before or after boundary line should turn happen
            startYouTurnAt = Properties.Settings.Default.setAS_startYouTurnAt;
        }

        public void CancelYouTurn()
        {
            isYouTurnOn = false;
            isAutoTriggered = false;
            isAutoPointSet = false;
            if (ytList.Count > 0) ytList.Clear();
            mf.AutoYouTurnButtonsReset();
            return;
        }

        public void LoadYouTurnShapeFromFile(string filename)
        {
            //if there is existing shape, delete it
            if (youFileList.Count > 0) youFileList.Clear();

            if (!File.Exists(filename))
            {
                var form = new FormTimedMessage(4000, "Missing Youturn File", "Fix the thing!");
                form.Show();
            }
            else
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    try
                    {
                        string line = reader.ReadLine();
                        int points = int.Parse(line);

                        if (points > 0)
                        {
                            vec2 coords = new vec2();
                            for (int v = 0; v < points; v++)
                            {
                                line = reader.ReadLine();
                                string[] words = line.Split(',');

                                coords.easting = double.Parse(words[0], CultureInfo.InvariantCulture);
                                coords.northing = double.Parse(words[1], CultureInfo.InvariantCulture);
                                youFileList.Add(coords);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        var form = new FormTimedMessage(4000, "Flag File is Corrupt", "But Field is Loaded");
                        form.Show();
                        mf.WriteErrorLog("FieldOpen, Loading Flags, Corrupt Flag File" + e);
                    }
                }
            }
        }

        //build the points and path 
        public void BuildYouTurnListToRight(bool isTurnRight)
        {
            isYouTurnOn = true;

            //grab the Lookahead that ABLine uses
            minLookAheadDistance = mf.ABLine.minLookAheadDistance;

            //point on AB line closest to pivot axle point from ABLine PurePursuit
            rEastYT = mf.ABLine.rEastAB;
            rNorthYT = mf.ABLine.rNorthAB;
            isABSameAsFixHeading = mf.ABLine.isABSameAsFixHeading;
            pivotAxlePosYT = mf.pivotAxlePos;

            //grab the vehicle widths and offsets
            double widthMinusOverlap = mf.vehicle.toolWidth - mf.vehicle.toolOverlap;
            double toolOffset = mf.vehicle.toolOffset * 2.0;
            double turnOffset = 0;
            abHeading = mf.ABLine.abHeading;

            //turning right same as AB line
            if ((isTurnRight && isABSameAsFixHeading) || (isTurnRight && !isABSameAsFixHeading))
            {
                turnOffset = (widthMinusOverlap + toolOffset);
            }

            //turning left same way as AB line
            if ((!isTurnRight && isABSameAsFixHeading) || (!isTurnRight && !isABSameAsFixHeading))
            {
                turnOffset = (widthMinusOverlap - toolOffset);
            }

            numShapePoints = youFileList.Count;
            vec4[] pt = new vec4[numShapePoints];

            //Now put the shape into an array since lists are immutable
            for (int i = 0; i < numShapePoints; i++)
            {
                pt[i].x = youFileList[i].easting;
                pt[i].z = youFileList[i].northing;
            }

            //start of path on the origin. Mirror the shape if left turn
            if (!isTurnRight)
            {
                for (int i = 0; i < pt.Length; i++) pt[i].x *= -1;
            }

            //scaling - Drawing is 10m wide so find ratio of tool width
            double scale = turnOffset * 0.1;
            for (int i = 0; i < pt.Length; i++)
            {
                pt[i].x *= scale;
                pt[i].z *= scale;
            }

            //rotate pattern to match AB Line heading
            for (int i = 0; i < pt.Length; i++)
            {
                double xr, yr;
                if (isABSameAsFixHeading)
                {
                    xr = (Math.Cos(-abHeading) * pt[i].x) - (Math.Sin(-abHeading) * pt[i].z);
                    yr = (Math.Sin(-abHeading) * pt[i].x) + (Math.Cos(-abHeading) * pt[i].z);
                }
                else
                {
                    xr = (Math.Cos(-abHeading+Math.PI) * pt[i].x) - (Math.Sin(-abHeading+Math.PI) * pt[i].z);
                    yr = (Math.Sin(-abHeading+Math.PI) * pt[i].x) + (Math.Cos(-abHeading+Math.PI) * pt[i].z);
                }

                pt[i].x = xr+rEastYT;
                pt[i].z = yr+rNorthYT;
                pt[i].k = 0;
                pt[i].y = Math.Atan2(pt[i].z, pt[i].x);
                ytList.Add(pt[i]);
            }
        }

        //determine distance from youTurn guidance line
        public void DistanceFromYouTurnLine()
        {
            //grab a copy from main
            pivotAxlePosYT = mf.pivotAxlePos;
            double minDistA = 1000000, minDistB = 1000000;
            int ptCount = ytList.Count;

            if (ptCount > 0)
            {
                //find the closest 2 points to current fix
                for (int t = 0; t < ptCount; t++)
                {
                    double dist = ((pivotAxlePosYT.easting - ytList[t].x) * (pivotAxlePosYT.easting - ytList[t].x))
                                    + ((pivotAxlePosYT.northing - ytList[t].z) * (pivotAxlePosYT.northing - ytList[t].z));
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
                double dx = ytList[B].x - ytList[A].x;
                double dz = ytList[B].z - ytList[A].z;
                if (Math.Abs(dx) < Double.Epsilon && Math.Abs(dz) < Double.Epsilon) return;

                //abHeading = Math.Atan2(dz, dx);
                abHeading = ytList[A].y;

                //how far from current AB Line is fix
                distanceFromCurrentLine = ((dz * mf.pn.easting) - (dx * mf.pn.northing) + (ytList[B].x
                            * ytList[A].z) - (ytList[B].z * ytList[A].x))
                                / Math.Sqrt((dz * dz) + (dx * dx));

                //are we on the right side or not
                isOnRightSideCurrentLine = distanceFromCurrentLine > 0;

                //absolute the distance
                distanceFromCurrentLine = Math.Abs(distanceFromCurrentLine);

                //return and reset if too far away or end of the line
                if (distanceFromCurrentLine > 5 || B >= ptCount - 3)
                {
                    CancelYouTurn();
                    return;
                }

                // ** Pure pursuit ** - calc point on ABLine closest to current position      
                double U = (((pivotAxlePosYT.easting - ytList[A].x) * (dx))
                            + ((pivotAxlePosYT.northing - ytList[A].z) * (dz)))
                            / ((dx * dx) + (dz * dz));

                rEastYT = ytList[A].x + (U * (dx));
                rNorthYT = ytList[A].z + (U * (dz));

                //used for accumulating distance to find goal point
                double distSoFar;

                //how far should goal point be away  - speed * seconds * kmph -> m/s + min value
                double goalPointDistance = mf.pn.speed * mf.vehicle.goalPointLookAhead * 0.27777777;

                //minimum of Whatever AB Line is meters look ahead
                if (goalPointDistance < minLookAheadDistance) goalPointDistance = minLookAheadDistance;

                // used for calculating the length squared of next segment.
                double tempDist = 0.0;

                isABSameAsFixHeading = true;
                distSoFar = mf.pn.Distance(ytList[B].z, ytList[B].x, rNorthYT, rEastYT);

                //Is this segment long enough to contain the full lookahead distance?
                if (distSoFar > goalPointDistance)
                {
                    //treat current segment like an AB Line
                    goalPointYT.easting = rEastYT + (Math.Sin(ytList[A].y) * goalPointDistance);
                    goalPointYT.northing = rNorthYT + (Math.Cos(ytList[A].y) * goalPointDistance);
                }

                //multiple segments required
                else
                {
                    //cycle thru segments and keep adding lengths. check if end and break if so.
                    // ReSharper disable once LoopVariableIsNeverChangedInsideLoop
                    while (B < ptCount - 1)
                    {
                        B++; A++;
                        tempDist = mf.pn.Distance(ytList[B].z, ytList[B].x, ytList[A].z, ytList[A].x);
                        if ((tempDist + distSoFar) > goalPointDistance) break; //will we go too far?
                        distSoFar += tempDist;
                    }

                    double t = (goalPointDistance - distSoFar); // the remainder to yet travel
                    t /= tempDist;
                    goalPointYT.easting = (((1 - t) * ytList[A].x) + (t * ytList[B].x));
                    goalPointYT.northing = (((1 - t) * ytList[A].z) + (t * ytList[B].z));
                }

                //calc "D" the distance from pivot axle to lookahead point
                double goalPointDistanceSquared = mf.pn.DistanceSquared(goalPointYT.northing, goalPointYT.easting, pivotAxlePosYT.northing, pivotAxlePosYT.easting);

                //calculate the the delta x in local coordinates and steering angle degrees based on wheelbase
                double localHeading = glm.twoPI - mf.fixHeading;
                ppRadiusYT = goalPointDistanceSquared / (2 * (((goalPointYT.easting - pivotAxlePosYT.easting) * Math.Cos(localHeading)) + ((goalPointYT.northing - pivotAxlePosYT.northing) * Math.Sin(localHeading))));

                steerAngleYT = glm.toDegrees(Math.Atan(2 * (((goalPointYT.easting - pivotAxlePosYT.easting) * Math.Cos(localHeading))
                    + ((goalPointYT.northing - pivotAxlePosYT.northing) * Math.Sin(localHeading))) * mf.vehicle.wheelbase / goalPointDistanceSquared));

                if (steerAngleYT < -mf.vehicle.maxSteerAngle) steerAngleYT = -mf.vehicle.maxSteerAngle;
                if (steerAngleYT > mf.vehicle.maxSteerAngle) steerAngleYT = mf.vehicle.maxSteerAngle;

                if (ppRadiusYT < -500) ppRadiusYT = -500;
                if (ppRadiusYT > 500) ppRadiusYT = 500;

                radiusPointYT.easting = pivotAxlePosYT.easting + (ppRadiusYT * Math.Cos(localHeading));
                radiusPointYT.northing = pivotAxlePosYT.northing + (ppRadiusYT * Math.Sin(localHeading));

                //angular velocity in rads/sec  = 2PI * m/sec * radians/meters
                double angVel = glm.twoPI * 0.277777 * mf.pn.speed * (Math.Tan(glm.toRadians(steerAngleYT))) / mf.vehicle.wheelbase;

                //clamp the steering angle to not exceed safe angular velocity
                if (Math.Abs(angVel) > mf.vehicle.maxAngularVelocity)
                {
                    steerAngleYT = glm.toDegrees(steerAngleYT > 0 ?
                            (Math.Atan((mf.vehicle.wheelbase * mf.vehicle.maxAngularVelocity) / (glm.twoPI * mf.pn.speed * 0.277777)))
                        : (Math.Atan((mf.vehicle.wheelbase * -mf.vehicle.maxAngularVelocity) / (glm.twoPI * mf.pn.speed * 0.277777))));
                }
                //Convert to centimeters
                distanceFromCurrentLine = Math.Round(distanceFromCurrentLine * 1000.0, MidpointRounding.AwayFromZero);

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

                mf.guidanceLineDistanceOff = (Int16)distanceFromCurrentLine;
                mf.guidanceLineSteerAngle = (Int16)(steerAngleYT * 10);
            }
            else
            {
                CancelYouTurn();
            }
        }
    }
}
