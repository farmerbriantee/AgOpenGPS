using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace AgOpenGPS
{
    public class CYouTurn
    {
        //copy of the mainform address
        private readonly FormGPS mf;

        /// <summary>/// triggered right after youTurnTriggerPoint is set /// </summary>
        public bool isYouTurnTriggered;

        /// <summary>  /// turning right or left?/// </summary>
        public bool isYouTurnRight;
        private int semiCircleIndex = -1;

        /// <summary> /// Is the youturn button enabled? /// </summary>
        public bool isYouTurnBtnOn;

        public double boundaryAngleOffPerpendicular, youTurnRadius;

        public int rowSkipsWidth = 1, uTurnSmoothing;

        public bool alternateSkips = false, previousBigSkip = true;
        public int rowSkipsWidth2 = 3, turnSkips = 2;

        /// <summary>  /// distance from headland as offset where to start turn shape /// </summary>
        public int youTurnStartOffset;

        //guidance values
        public double distanceFromCurrentLine, uturnDistanceFromBoundary, dxAB, dyAB;

        //private int sA, sB, C, pA, pB;
        //private int rA, rB;

        public double distanceFromCurrentLineSteer, distanceFromCurrentLinePivot;
        public double steerAngleGu, rEastSteer, rNorthSteer, rEastPivot, rNorthPivot;
        public double pivotCurvatureOffset, lastCurveDistance = 10000;

        private int A, B;
        private bool isHeadingSameWay = true;
        public bool isTurnCreationTooClose = false, isTurnCreationNotCrossingError = false, turnTooCloseTrigger = false;

        //pure pursuit values
        public vec3 pivot = new vec3(0, 0, 0);

        public vec2 goalPointYT = new vec2(0, 0);
        public vec2 radiusPointYT = new vec2(0, 0);
        public double steerAngleYT, rEastYT, rNorthYT, ppRadiusYT;

        //list of points for scaled and rotated YouTurn line, used for pattern, dubins, abcurve, abline
        public List<vec3> ytList = new List<vec3>();
        private List<vec3> ytList2 = new List<vec3>();

        //for 3Pt turns - second turn
        public List<vec3> pt3ListSecondLine = new List<vec3>();

        //third turn.
        //public List<vec3> pt3List3 = new List<vec3>();
        public int uTurnStyle = 0;

        public int pt3Phase = 0;
        public vec3 pt3TurnNewAB = new vec3(0, 0, 0);
        public bool isLastFrameForward = true;

        //is UTurn pattern in or out of bounds
        public bool isOutOfBounds = false;

        //sequence of operations of finding the next turn 0 to 3
        public int youTurnPhase;

        public vec4 crossingCurvePoint = new vec4();
        public double crossingheading = 0;

        //constructor
        public CYouTurn(FormGPS _f)
        {
            mf = _f;

            uturnDistanceFromBoundary = Properties.Settings.Default.set_youTurnDistanceFromBoundary;

            //how far before or after boundary line should turn happen
            youTurnStartOffset = Properties.Settings.Default.set_youTurnExtensionLength;

            rowSkipsWidth = Properties.Settings.Default.set_youSkipWidth;
            Set_Alternate_skips();

            ytList.Capacity = 128;

            youTurnRadius = Properties.Settings.Default.set_youTurnRadius;

            uTurnStyle = Properties.Settings.Default.set_uTurnStyle;

            uTurnSmoothing = Properties.Settings.Default.setAS_uTurnSmoothing;
        }

        //Finds the point where an AB Curve crosses the turn line
        public bool FindCurveTurnPoints()
        {
            crossingCurvePoint.easting = -20000;
            //find closet AB Curve point that will cross and go out of bounds
            int Count = mf.curve.isHeadingSameWay ? 1 : -1;
            int turnNum = 99;
            int j;

            for (j = mf.curve.currentLocationIndex; j > 0 && j < mf.curve.curList.Count; j += Count)
            {
                int turnIndex = mf.bnd.IsPointInsideTurnArea(mf.curve.curList[j]);
                if (turnIndex != 0)
                {
                    crossingCurvePoint.easting = mf.curve.curList[j - Count].easting;
                    crossingCurvePoint.northing = mf.curve.curList[j - Count].northing;
                    crossingCurvePoint.heading = mf.curve.curList[j - Count].heading;
                    crossingCurvePoint.index = j - Count;
                    turnNum = turnIndex;
                    break;
                }
            }

            if (turnNum < 0) //uturn will be on outer boundary turn
                turnNum = 0;
            else if (turnNum == 99)
            {
                //curve does not cross a boundary - oops
                isTurnCreationNotCrossingError = true;
                return false;
            }

            for (int i = 0; i < mf.bnd.bndList[turnNum].turnLine.Count - 2; i++)
            {
                int res = GetLineIntersection(
                        mf.bnd.bndList[turnNum].turnLine[i].easting,
                        mf.bnd.bndList[turnNum].turnLine[i].northing,
                        mf.bnd.bndList[turnNum].turnLine[i + 1].easting,
                        mf.bnd.bndList[turnNum].turnLine[i + 1].northing,

                        mf.curve.curList[j].easting,
                        mf.curve.curList[j].northing,
                        mf.curve.curList[j - Count].easting,
                        mf.curve.curList[j - Count].northing,

                         ref iE, ref iN
                         );

                if (res == 1)
                {
                    crossingCurvePoint.easting = iE;
                    crossingCurvePoint.northing = iN;

                    double hed = Math.Atan2(mf.bnd.bndList[turnNum].turnLine[i + 1].easting - mf.bnd.bndList[turnNum].turnLine[i].easting,
                        mf.bnd.bndList[turnNum].turnLine[i + 1].northing - mf.bnd.bndList[turnNum].turnLine[i].northing);
                    if (hed < 0) hed += glm.twoPI;
                    crossingheading = hed;
                    break;
                }
            }

            //int curTurnLineCount = mf.bnd.bndList[turnNum].turnLine.Count;

            ////possible points close to AB Curve point
            //List<int> turnLineCloseList = new List<int>();

            //for ( j = 0; j < curTurnLineCount; j++)
            //{
            //    if ((mf.bnd.bndList[turnNum].turnLine[j].easting - crossingCurvePoint.easting) < 15
            //        && (mf.bnd.bndList[turnNum].turnLine[j].easting - crossingCurvePoint.easting) > -15
            //        && (mf.bnd.bndList[turnNum].turnLine[j].northing - crossingCurvePoint.northing) < 15
            //        && (mf.bnd.bndList[turnNum].turnLine[j].northing - crossingCurvePoint.northing) > -15)
            //    {
            //        turnLineCloseList.Add(j);
            //    }
            //}

            //double dist1, dist2 = 99;
            //curTurnLineCount = turnLineCloseList.Count;
            //int index = -1;
            //for (int i = 0; i < curTurnLineCount; i++)
            //{
            //    dist1 = glm.Distance(mf.bnd.bndList[turnNum].turnLine[turnLineCloseList[i]].easting,
            //                            mf.bnd.bndList[turnNum].turnLine[turnLineCloseList[i]].northing,
            //                                crossingCurvePoint.easting, crossingCurvePoint.northing);
            //    if (dist1 < dist2)
            //    {
            //        index = turnLineCloseList[i];
            //        dist2 = dist1;
            //    }
            //}

            //crossingheading = -20000;
            //if (index >= 0)
            //    crossingheading = mf.bnd.bndList[turnNum].turnLine[index].heading;

            return crossingheading != -20000 && crossingCurvePoint.easting != -20000;
            //return true;
        }

        // Returns 1 if the lines intersect, otherwis
        public double iE = 0, iN = 0;

        public int GetLineIntersection(double p0x, double p0y, double p1x, double p1y,
                double p2x, double p2y, double p3x, double p3y, ref double iEast, ref double iNorth)
        {
            double s1x, s1y, s2x, s2y;
            s1x = p1x - p0x;
            s1y = p1y - p0y;

            s2x = p3x - p2x;
            s2y = p3y - p2y;

            double s, t;
            s = (-s1y * (p0x - p2x) + s1x * (p0y - p2y)) / (-s2x * s1y + s1x * s2y);

            if (s >= 0 && s <= 1)
            {
                //check oher side
                t = (s2x * (p0y - p2y) - s2y * (p0x - p2x)) / (-s2x * s1y + s1x * s2y);
                if (t >= 0 && t <= 1)
                {
                    // Collision detected
                    iEast = p0x + (t * s1x);
                    iNorth = p0y + (t * s1y);
                    return 1;
                }
            }

            return 0; // No collision
        }

        public void AddSequenceLines(double head)
        {
            vec3 pt;
            for (int a = 0; a < youTurnStartOffset; a++)
            {
                pt.easting = ytList[0].easting + (Math.Sin(head) * 0.511);
                pt.northing = ytList[0].northing + (Math.Cos(head) * 0.511);
                pt.heading = ytList[0].heading;
                ytList.Insert(0, pt);
            }

            int count = ytList.Count;

            for (int i = 1; i <= youTurnStartOffset; i++)
            {
                pt.easting = ytList[count - 1].easting + (Math.Sin(head) * i * 0.511);
                pt.northing = ytList[count - 1].northing + (Math.Cos(head) * i * 0.511);
                pt.heading = head;
                ytList.Add(pt);
            }

            double distancePivotToTurnLine;
            count = ytList.Count;
            for (int i = 0; i < count; i += 2)
            {
                distancePivotToTurnLine = glm.Distance(ytList[i], mf.pivotAxlePos);
                if (distancePivotToTurnLine > 3)
                {
                    isTurnCreationTooClose = false;
                }
                else
                {
                    isTurnCreationTooClose = true;
                    //set the flag to Critical stop machine
                    if (isTurnCreationTooClose) mf.mc.isOutOfBounds = true;
                    break;
                }
            }
        }

        public bool KStyleTurn(bool isTurnRight, double headAB)
        {
            //grab the pure pursuit point right on ABLine
            vec3 onPurePoint = new vec3(mf.ABLine.rEastAB, mf.ABLine.rNorthAB, 0);

            //how far are we from any turn boundary
            FindClosestTurnPoint(onPurePoint);

            //or did we lose the turnLine - we are on the highway cuz we left the outer/inner turn boundary
            if (closestTurnPt.segmentIndex != -1)
            {
                mf.distancePivotToTurnLine = glm.Distance(mf.pivotAxlePos, closestTurnPt.closePt);
            }
            else
            {
                //Full emergency stop code goes here, it thinks its auto turn, but its not!
                return false;
            }

            //delta between AB heading and boundary closest point heading
            boundaryAngleOffPerpendicular = Math.PI - Math.Abs(Math.Abs(closestTurnPt.closePt.heading - headAB) - Math.PI);
            boundaryAngleOffPerpendicular -= glm.PIBy2;
            boundaryAngleOffPerpendicular *= -1;
            if (boundaryAngleOffPerpendicular > 1.25) boundaryAngleOffPerpendicular = 1.25;
            if (boundaryAngleOffPerpendicular < -1.25) boundaryAngleOffPerpendicular = -1.25;

            //for calculating innner circles of turn
            double tangencyAngle = (glm.PIBy2 - Math.Abs(boundaryAngleOffPerpendicular)) * 0.5;
            double tangencyFactor = Math.Tan(tangencyAngle);

            //grab the vehicle widths and offsets
            double turnOffset = (mf.tool.width - mf.tool.overlap) * rowSkipsWidth + (isYouTurnRight ? -mf.tool.offset * 2.0 : mf.tool.offset * 2.0);

            //double turnRadius = turnOffset / Math.Cos(boundaryAngleOffPerpendicular);
            double turnRadius = youTurnRadius;

            isHeadingSameWay = mf.ABLine.isHeadingSameWay;
            double head = mf.ABLine.abHeading;
            if (!isHeadingSameWay) head += Math.PI;

            double abLineHeading = head;

            //intersection of ABline and boundary
            rEastYT = closestTurnPt.closePt.easting;
            rNorthYT = closestTurnPt.closePt.northing;

            vec3 oneStart = new vec3
            {
                easting = rEastYT,
                northing = rNorthYT,
                heading = 0
            };

            vec3 oneEnd = new vec3
            {
                easting = rEastYT,
                northing = rNorthYT,
                heading = 0
            };

            vec3 twoStart = new vec3
            {
                easting = rEastYT,
                northing = rNorthYT,
                heading = 0
            };

            vec3 twoEnd = new vec3
            {
                easting = rEastYT,
                northing = rNorthYT,
                heading = 0
            };

            if (boundaryAngleOffPerpendicular < 0)
            {
                //which is actually left
                if (isYouTurnRight)
                {
                    turnRadius = (youTurnRadius * tangencyFactor);//short
                }
                else
                {
                    turnRadius = (youTurnRadius / tangencyFactor); //long
                }
            }
            else
            {
                //which is actually left
                if (isYouTurnRight)
                {
                    turnRadius = (youTurnRadius / tangencyFactor); //long
                }
                else
                {
                    turnRadius = (youTurnRadius * tangencyFactor); //short
                }
            }

            //move the start back away from turn line youTurnRadius distance based on tangency
            oneStart.easting -= (Math.Sin(head) * turnRadius);
            oneStart.northing -= (Math.Cos(head) * turnRadius);
            oneStart.heading = head;

            double arcAngle = glm.PIBy2;
            // move the goal left or right at 90 degrees
            if (!isTurnRight) //means going right
            {
                head += glm.PIBy2;
                arcAngle -= boundaryAngleOffPerpendicular;
                //head -= angle;
            }
            else
            {
                head -= glm.PIBy2;
                arcAngle += boundaryAngleOffPerpendicular;
                //head += angle;
            }

            if (head < -Math.PI) head += glm.twoPI;
            if (head > Math.PI) head -= glm.twoPI;

            //point to set next AB Line via lateral
            pt3TurnNewAB.easting = oneEnd.easting + (Math.Sin(head) * mf.tool.width);
            pt3TurnNewAB.northing = oneEnd.northing + (Math.Cos(head) * mf.tool.width);

            oneEnd.easting = oneStart.easting + Math.Sin(head) * youTurnRadius;
            oneEnd.northing = oneStart.northing + Math.Cos(head) * youTurnRadius;

            twoEnd.heading = 0; // - angle;
            oneEnd.heading = 0;

            //two.easting = pt3TurnNewAB.easting - (Math.Sin(head) * mf.vehicle.minTurningRadius);
            //two.northing = pt3TurnNewAB.northing - (Math.Cos(head) * mf.vehicle.minTurningRadius);

            double r = youTurnRadius;
            int numSegments = (int)(arcAngle * 16);

            double theta = arcAngle / (double)(numSegments - 1);

            double tanFactor = Math.Tan(theta);
            double radialFactor = Math.Cos(theta);

            double startAngle = abLineHeading;
            if (!isYouTurnRight)
            {
                startAngle -= 1.57;
            }
            else
            {
                startAngle += 1.57;
            }

            if (startAngle < -Math.PI) startAngle += glm.twoPI;
            if (startAngle > Math.PI) startAngle -= glm.twoPI;

            double x = r * Math.Sin(startAngle);
            double y = r * Math.Cos(startAngle);

            vec3 pt;
            for (int ii = 0; ii < numSegments; ii++)
            {
                //glVertex2f(x + cx, y + cy);
                pt.easting = x + oneEnd.easting;
                pt.northing = y + oneEnd.northing;
                pt.heading = 0;

                ytList.Add(pt);

                double tx;
                double ty;
                if (!isYouTurnRight)
                {
                    tx = y;
                    ty = -x;
                }
                else
                {
                    tx = -y;
                    ty = x;
                }

                x += tx * tanFactor;
                y += ty * tanFactor;

                x *= radialFactor;
                y *= radialFactor;
            }

            for (int a = 0; a < 8; a++)
            {
                pt.easting = ytList[0].easting - (Math.Sin(abLineHeading) * 0.5);
                pt.northing = ytList[0].northing - (Math.Cos(abLineHeading) * 0.5);
                pt.heading = ytList[0].heading;
                ytList.Insert(0, pt);
            }

            //we are following the turn line now.
            head -= boundaryAngleOffPerpendicular;

            //from end of turn to over new AB a bit
            //double twoEndExtension = mf.tool.width + mf.vehicle.wheelbase - youTurnRadius;
            //if (mf.tool.width < turnRadius) twoEndExtension = mf.vehicle.wheelbase;
            int twoEndExtension = (int)(mf.tool.width * 5);

            //add the tail to first turn
            int count = ytList.Count;
            for (int i = 1; i <= twoEndExtension; i++)
            {
                pt.easting = ytList[count - 1].easting + (Math.Sin(head) * i * 0.5);
                pt.northing = ytList[count - 1].northing + (Math.Cos(head) * i * 0.5);
                pt.heading = 0;
                ytList.Add(pt);
            }

            //calculate line headings
            vec3[] arr = new vec3[ytList.Count];
            ytList.CopyTo(arr);
            ytList.Clear();

            //headings of line one
            for (int i = 0; i < arr.Length - 1; i++)
            {
                arr[i].heading = Math.Atan2(arr[i + 1].easting - arr[i].easting, arr[i + 1].northing - arr[i].northing);
                if (arr[i].heading < 0) arr[i].heading += glm.twoPI;
                ytList.Add(arr[i]);
            }

            //LINE TWO - use end of line one for end of line two, both same direction bit longer
            twoEnd.easting = ytList[ytList.Count - 1].easting;
            twoEnd.northing = ytList[ytList.Count - 1].northing;
            twoEnd.heading = ytList[ytList.Count - 1].heading;

            if (twoEnd.heading < -Math.PI) twoEnd.heading += glm.twoPI;
            if (twoEnd.heading > Math.PI) twoEnd.heading -= glm.twoPI;

            //straight line
            twoStart = twoEnd;

            ////backing up to this point
            twoStart.easting -= (Math.Sin(head) * 40);
            twoStart.northing -= (Math.Cos(head) * 40);

            pt3ListSecondLine?.Clear();
            pt = twoStart;
            pt3ListSecondLine.Add(pt);

            //from start to end
            count = pt3ListSecondLine.Count;
            for (int i = 1; i <= 80; i++)
            {
                pt.easting = pt3ListSecondLine[count - 1].easting + (Math.Sin(head) * i * 0.5);
                pt.northing = pt3ListSecondLine[count - 1].northing + (Math.Cos(head) * i * 0.5);
                pt.heading = 0;
                pt3ListSecondLine.Add(pt);
            }

            if (pt3ListSecondLine.Count != 0)
            {
                youTurnPhase = 3;
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool BuildABLineDubinsYouTurn(bool isTurnRight)
        {
            double headAB = mf.ABLine.abHeading;

            if (!mf.isBtnAutoSteerOn) mf.ABLine.isHeadingSameWay
                    = Math.PI - Math.Abs(Math.Abs(mf.fixHeading - mf.ABLine.abHeading) - Math.PI) < glm.PIBy2;

            if (!mf.ABLine.isHeadingSameWay) headAB += Math.PI;

            if (uTurnStyle == 0)
            {
                if (youTurnPhase == 3) return true;
                double toolTurnWidth = mf.tool.width * rowSkipsWidth;

                //*********************************************************** Omega Turn ************************************

                if (youTurnRadius * 2 >= toolTurnWidth)
                {
                    //we are doing an omega turn
                    if (youTurnPhase == 0)
                    {
                        //grab the pure pursuit point right on ABLine
                        vec3 onPurePoint = new vec3(mf.ABLine.rEastAB, mf.ABLine.rNorthAB, 0);

                        //how far are we from any turn boundary
                        FindClosestTurnPoint(onPurePoint);

                        //or did we lose the turnLine - we are on the highway cuz we left the outer/inner turn boundary
                        if (closestTurnPt.segmentIndex != -1)
                        {
                            //calculate the distance to the turnline
                            mf.distancePivotToTurnLine = glm.Distance(mf.pivotAxlePos, closestTurnPt.closePt);
                        }
                        else
                        {
                            //Full emergency stop code goes here, it thinks its auto turn, but its not!
                            return false;
                        }

                        //distance from TurnLine for trigger added in youturn form, include the 3 m bump forward
                        double distanceTurnBeforeLine = (2 * youTurnRadius);

                        CDubins dubYouTurnPath = new CDubins();
                        CDubins.turningRadius = youTurnRadius;

                        //point on AB line closest to pivot axle point from ABLine PurePursuit, where we are at the moment
                        rEastYT = mf.ABLine.rEastAB;
                        rNorthYT = mf.ABLine.rNorthAB;
                        isHeadingSameWay = mf.ABLine.isHeadingSameWay;
                        double head = mf.ABLine.abHeading;

                        //grab the vehicle widths and offsets
                        double turnOffset = (mf.tool.width - mf.tool.overlap) * rowSkipsWidth + (isYouTurnRight ? -mf.tool.offset * 2.0 : mf.tool.offset * 2.0);

                        if (!isHeadingSameWay) head += Math.PI;

                        //troligtvis avståndet från axeln till svänglinjen
                        double turnDiagDistance = mf.distancePivotToTurnLine;

                        //move to the point that is crossing the turnline
                        rEastYT += (Math.Sin(head) * turnDiagDistance);
                        rNorthYT += (Math.Cos(head) * turnDiagDistance);

                        vec3 start = new vec3(rEastYT, rNorthYT, head);
                        vec3 goal = new vec3
                        {
                            //move the cross line calc to not include first turn
                            easting = rEastYT + (Math.Sin(head) * distanceTurnBeforeLine),
                            northing = rNorthYT + (Math.Cos(head) * distanceTurnBeforeLine)
                        };

                        //now we go the other way to turn round
                        head -= Math.PI;
                        if (head < -Math.PI) head += glm.twoPI;
                        if (head > Math.PI) head -= glm.twoPI;

                        if (!isTurnRight)
                        {
                            goal.easting = rEastYT - (Math.Cos(-head) * turnOffset);
                            goal.northing = rNorthYT - (Math.Sin(-head) * turnOffset);
                        }
                        else
                        {
                            goal.easting = rEastYT + (Math.Cos(-head) * turnOffset);
                            goal.northing = rNorthYT + (Math.Sin(-head) * turnOffset);
                        }
                        goal.easting += (Math.Sin(head) * 1);
                        goal.northing += (Math.Cos(head) * 1);
                        goal.heading = head;

                        //generate the turn points
                        ytList = dubYouTurnPath.GenerateDubins(start, goal);
                        AddSequenceLines(head);
                        //time1 = timer.ElapsedMilliseconds;
                        //timer.Stop();
                        //timer.Reset();

                        if (ytList.Count == 0) return false;
                        else youTurnPhase = 1;
                    }

                    if (youTurnPhase == 1)
                    {
                        //timer.Start();
                        ytList = MoveTurnInsideTurnLine(ytList, headAB);

                        if (!(ytList.Count > 5))
                        {
                            //mf.TimedMessageBox(5000, "Timed", "Time:  " + timer.ElapsedMilliseconds.ToString());
                            isOutOfBounds = true;
                            isTurnCreationTooClose = true;
                            youTurnPhase = 4;
                            mf.mc.isOutOfBounds = true;
                            return false;
                        }
                        //time2 = timer.ElapsedMilliseconds;
                        //timer.Stop();
                        //timer.Reset();
                        //mf.TimedMessageBox(5000, "Timed", "Time1: " + time1.ToString() + "  Time2: " + time2.ToString());
                        isOutOfBounds = false;
                        youTurnPhase = 3;
                        return true;
                    }

                    return true;

                }
                else
                {   
                    //*********   Albin Vigre - wide uturn line following **************************************************

                    double pointSpacing = youTurnRadius * 0.1;

                    //step 1 turn in to the turnline
                    if (youTurnPhase == 0)
                    {
                        isOutOfBounds = true;
                        //timer.Start();
                        //grab the pure pursuit point right on ABLine
                        vec3 onPurePoint = new vec3(mf.ABLine.rEastAB, mf.ABLine.rNorthAB, 0);

                        //how far are we from any turn boundary
                        FindClosestTurnPoint(onPurePoint);

                        //save a copy for first point
                        inClosestTurnPt = new CClose(closestTurnPt);

                        //already no turnline
                        if (inClosestTurnPt.segmentIndex == -1) return false;

                        //calculate the distance to the turnline
                        mf.distancePivotToTurnLine = glm.Distance(mf.pivotAxlePos, closestTurnPt.closePt);

                        //point on AB line closest to pivot axle point from ABLine PurePursuit aka where we are
                        rEastYT = mf.ABLine.rEastAB;
                        rNorthYT = mf.ABLine.rNorthAB;
                        isHeadingSameWay = mf.ABLine.isHeadingSameWay;
                        double head = mf.ABLine.abHeading;

                        if (!isHeadingSameWay) head += Math.PI;
                        if (head >= glm.twoPI) head -= glm.twoPI;

                        //thistance to turnline from where we are
                        double turnDiagDistance = mf.distancePivotToTurnLine;

                        //moves the point to the crossing with the turnline
                        rEastYT += (Math.Sin(head) * turnDiagDistance);
                        rNorthYT += (Math.Cos(head) * turnDiagDistance);

                        //creates half a circle starting at the crossing point
                        ytList.Clear();
                        vec3 currentPos = new vec3(rEastYT, rNorthYT, head);
                        ytList.Add(currentPos);

                        ///CDubins.turningRadius = youTurnRadius;
                        //Taken from Dubbins
                        while (Math.Abs(head - currentPos.heading) < Math.PI)
                        {
                            //Update the position of the car
                            currentPos.easting += pointSpacing * Math.Sin(currentPos.heading);
                            currentPos.northing += pointSpacing * Math.Cos(currentPos.heading);

                            //Which way are we turning?
                            double turnParameter = 1.0;

                            if (isTurnRight) turnParameter = -1.0;

                            //Update the heading
                            currentPos.heading += (pointSpacing / youTurnRadius) * turnParameter;

                            //Add the new coordinate to the path
                            ytList.Add(currentPos);
                        }

                        //move the half circle to tangent the turnline
                        ytList = MoveTurnInsideTurnLine(ytList, head);

                        //if it couldn't be done this will trigger
                        if (ytList.Count < 5 || semiCircleIndex == -1)
                        {
                            isOutOfBounds = true;
                            isTurnCreationTooClose = true;
                            youTurnPhase = 4;
                            mf.mc.isOutOfBounds = true;
                            //mf.TimedMessageBox(5000, "Timed", "Time:  " + timer.ElapsedMilliseconds.ToString());
                            return false;
                        }

                        //we need to delete the points after the point that is outside and correct the heading
                        int cnt = ytList.Count;
                        vec3[] arr23 = new vec3[cnt];
                        ytList.CopyTo(arr23);
                        ytList.Clear();

                        for (int i = 0; i < cnt; i++)
                        {
                            if (i == semiCircleIndex)
                                break;
                            if (arr23[i].heading >= glm.twoPI) arr23[i].heading -= glm.twoPI;
                            else if (arr23[i].heading < 0) arr23[i].heading += glm.twoPI;
                            ytList.Add(arr23[i]);
                        }

                        mf.distancePivotToTurnLine = glm.Distance(ytList[0], mf.pivotAxlePos);

                        youTurnPhase = 1;
                        return true;
                    }
                    //step 2, create the turn out fron the turnline into the next AB
                    if (youTurnPhase == 1)
                    {
                        //timer.Start();
                        //now we need to find the turn in point on the next AB-line
                        double head = mf.ABLine.abHeading;
                        if (!isHeadingSameWay) head += Math.PI;
                        if (head >= glm.twoPI) head -= glm.twoPI;

                        double turnOffset = (mf.tool.width - mf.tool.overlap) * rowSkipsWidth + (isYouTurnRight ? -mf.tool.offset * 2.0 : mf.tool.offset * 2.0);

                        //we move the turnline crossing point perpenicualar out from the ABline
                        CDubins.turningRadius = turnOffset;
                        vec2 pointpos;
                        if (!isTurnRight)
                        {
                            pointpos = DubinsMath.GetRightCircleCenterPos(new vec2(closestTurnPt.closePt.easting, closestTurnPt.closePt.northing), head);
                        }
                        else
                        {
                            pointpos = DubinsMath.GetLeftCircleCenterPos(new vec2(closestTurnPt.closePt.easting, closestTurnPt.closePt.northing), head);
                        }

                        vec3 pointPos = new vec3(pointpos.easting, pointpos.northing, head);

                        //step 1 if point is outside back up until inside boundary
                        int stopIfWayOut = 0;
                        double cosHead = Math.Cos(head) * 4;
                        double sinHead = Math.Sin(head) * 4;
                        while (mf.bnd.IsPointInsideTurnArea(pointPos) != 0)
                        {
                            stopIfWayOut++;
                            pointPos.easting -= sinHead;
                            pointPos.northing -= cosHead;
                            if (stopIfWayOut == 200)
                            {
                                //mf.TimedMessageBox(5000, "Timed", "Time:  " + timer.ElapsedMilliseconds.ToString());
                                isTurnCreationTooClose = true;
                                isOutOfBounds = true;
                                youTurnPhase = 4; //turn is not valid since it is outside
                                mf.mc.isOutOfBounds = true;
                                return false;
                            }
                        }

                        //step 2 if pont is inside move forward until it's outside turnboundary
                        cosHead = Math.Cos(head) * 3;
                        sinHead = Math.Sin(head) * 3;
                        while (mf.bnd.IsPointInsideTurnArea(pointPos) == 0)
                        {
                            pointPos.easting += sinHead;
                            pointPos.northing += cosHead;
                        }
                        pointPos.heading = head;

                        //step 3 create half cirkle in new list
                        ytList2?.Clear();
                        ytList2.Add(pointPos);
                        //CDubins.turningRadius = youTurnRadius;
                        //Taken from Dubbins
                        while (Math.Abs(head - pointPos.heading) < Math.PI)
                        {
                            //Update the position of the car
                            pointPos.easting += pointSpacing * Math.Sin(pointPos.heading);
                            pointPos.northing += pointSpacing * Math.Cos(pointPos.heading);

                            //Which way are we turning?
                            double turnParameter = 1.0;

                            if (!isTurnRight) turnParameter = -1.0; //now we turn "the wrong" way

                            //Update the heading
                            pointPos.heading += (pointSpacing / youTurnRadius) * turnParameter;

                            //Add the new coordinate to the path
                            ytList2.Add(pointPos);
                        }

                        //move the half circle to tangent the turnline
                        ytList2 = MoveTurnInsideTurnLine(ytList2, head);

                        if (ytList2.Count < 5 || semiCircleIndex == -1)
                        {
                            //mf.TimedMessageBox(5000, "Timed", "Time:  " + timer.ElapsedMilliseconds.ToString());
                            isOutOfBounds = true;
                            isTurnCreationTooClose = true;
                            mf.mc.isOutOfBounds = true;
                            youTurnPhase = 4;
                            return false;
                        }

                        //we need to delete the points after the point that is outside
                        //we need to turn the heading of the poinnts since they were created the wrong way, and delete the point after the one that is out of turnbnd
                        int cnt = ytList2.Count;
                        vec3[] arr23 = new vec3[cnt];
                        ytList2.CopyTo(arr23);
                        ytList2.Clear();

                        for (int i = 0; i < cnt; i++)
                        {
                            if (i == semiCircleIndex)
                                break;
                            arr23[i].heading += Math.PI;
                            if (arr23[i].heading >= glm.twoPI) arr23[i].heading -= glm.twoPI;
                            else if (arr23[i].heading < 0) arr23[i].heading += glm.twoPI;
                            ytList2.Add(arr23[i]);
                        }

                        youTurnPhase = 2;
                        return true;
                    }

                    //step 3, bind the turns together with help of the turnline
                    if (youTurnPhase == 2)
                    {
                        //timer.Start();
                        int cnt1 = ytList.Count;
                        int cnt2 = ytList2.Count;

                        //finds out start and goal point along the tunline
                        FindClosestTurnPoint(ytList[cnt1 - 1]);
                        inClosestTurnPt = new CClose(closestTurnPt);
                        FindClosestTurnPoint(ytList2[cnt2 - 1]);
                        outClosestTurnPt = new CClose(closestTurnPt);

                        //we have 2 different turnLine crossings
                        if (inClosestTurnPt.turnLineNum != outClosestTurnPt.turnLineNum)
                            return false;

                        vec3 startPoint = inClosestTurnPt.closePt;
                        vec3 goalPoint = outClosestTurnPt.closePt;

                        //we will find the closest turnline point to the start- and goalpoint int the list of turnline points
                        int startPointIndex = 0;
                        int goalPointIndex = 0;

                        int pointList = 0;
                        int goalPointList = 0;

                        //step 1 check which boundary they hits
                        bool startPointIndexFound = false;
                        bool goalPointIndexFound = false;

                        for (int i = 0; i < mf.bnd.bndList.Count; i++)
                        {
                            for (int j = 0; j < mf.bnd.bndList[i].turnLine.Count - 1; j++)
                            {
                                //heading between the boundarylines
                                double hed = Math.Atan2(mf.bnd.bndList[i].turnLine[j + 1].easting - mf.bnd.bndList[i].turnLine[j].easting,
                             mf.bnd.bndList[i].turnLine[j + 1].northing - mf.bnd.bndList[i].turnLine[j].northing);
                                if (hed < 0) hed += glm.twoPI;

                                //chek if the heading matches
                                //a very smal probability of it being the wrong point
                                if (hed == startPoint.heading)
                                {
                                    startPointIndex = j;
                                    startPointIndexFound = true;
                                    pointList = i;
                                }

                                if (hed == goalPoint.heading)
                                {
                                    goalPointIndex = j;
                                    goalPointIndexFound = true;
                                    goalPointList = i;
                                }

                            }

                        }

                        if (pointList != goalPointList || !startPointIndexFound || !goalPointIndexFound)
                        {
                            //invalid turn the in and out turn arn't on same boundar
                            //mf.TimedMessageBox(5000, "Timed", "Time:  " + timer.ElapsedMilliseconds.ToString());
                            isTurnCreationTooClose = true;
                            mf.mc.isOutOfBounds = true;
                            youTurnPhase = 4;
                            isOutOfBounds = true;
                            return false;
                        }

                        //step 2 create points from startPoint to all turnline points in between
                        bool isBndHeadingSameWay = true;
                        if (Math.Abs(startPoint.heading - ytList[cnt1 - 1].heading) > glm.PIBy2) isBndHeadingSameWay = false;

                        if (!isBndHeadingSameWay) startPoint.heading += Math.PI;
                        if (startPoint.heading < 0) startPoint.heading += glm.twoPI;
                        else if (startPoint.heading > glm.twoPI) startPoint.heading -= glm.twoPI;

                        double distanceToNextPoint;

                        //if there are some turnline points between start- and goalpoint
                        if (isBndHeadingSameWay)
                        {
                            //runs until startpoint is one less than goalpoint
                            for (; startPointIndex != goalPointIndex; startPointIndex++)
                            {
                                //calculates dist to next point
                                if (startPointIndex >= mf.bnd.bndList[pointList].turnLine.Count - 1) startPointIndex = 0;
                                distanceToNextPoint = glm.Distance(startPoint, mf.bnd.bndList[pointList].turnLine[startPointIndex + 1]);


                                //creates points to that point
                                for (int i = 0; i * pointSpacing < distanceToNextPoint; i++)
                                {

                                    startPoint.easting += pointSpacing * Math.Sin(startPoint.heading);
                                    startPoint.northing += pointSpacing * Math.Cos(startPoint.heading);
                                    ytList.Add(startPoint);
                                }

                                //to handle when pasing the first and last point in list and so that we dont end up outside the index
                                int secondIndex = startPointIndex;
                                if (startPointIndex >= mf.bnd.bndList[pointList].turnLine.Count - 2) secondIndex = -1;

                                startPoint = mf.bnd.bndList[pointList].turnLine[startPointIndex + 1];
                                double hed = Math.Atan2(mf.bnd.bndList[pointList].turnLine[secondIndex + 2].easting - mf.bnd.bndList[pointList].turnLine[startPointIndex + 1].easting,
                            mf.bnd.bndList[pointList].turnLine[secondIndex + 2].northing - mf.bnd.bndList[pointList].turnLine[startPointIndex + 1].northing);
                                if (hed < 0) hed += glm.twoPI;
                                startPoint.heading = hed;

                                //we adds the point
                                ytList.Add(startPoint);

                            }
                        }
                        else //if we are going against the turnline direction
                        {
                            for (; goalPointIndex != startPointIndex; startPointIndex--)
                            {

                                if (startPointIndex <= 0) startPointIndex = mf.bnd.bndList[pointList].turnLine.Count - 1;
                                distanceToNextPoint = glm.Distance(startPoint, mf.bnd.bndList[pointList].turnLine[startPointIndex]);

                                for (int i = 0; i * pointSpacing < distanceToNextPoint; i++)
                                {

                                    startPoint.easting += pointSpacing * Math.Sin(startPoint.heading);
                                    startPoint.northing += pointSpacing * Math.Cos(startPoint.heading);

                                    ytList.Add(startPoint);
                                }

                                startPoint = mf.bnd.bndList[pointList].turnLine[startPointIndex];
                                double hed = Math.Atan2(mf.bnd.bndList[pointList].turnLine[startPointIndex - 1].easting - mf.bnd.bndList[pointList].turnLine[startPointIndex].easting,
                           mf.bnd.bndList[pointList].turnLine[startPointIndex - 1].northing - mf.bnd.bndList[pointList].turnLine[startPointIndex].northing);
                                if (hed < 0) hed += glm.twoPI;
                                startPoint.heading = hed;

                                ytList.Add(startPoint);
                            }
                        }

                        // step 3 create points from last turnline point to goalPoint
                        double distanceToGoalPoint = glm.Distance(startPoint, goalPoint);

                        for (int i = 0; i * pointSpacing < distanceToGoalPoint; i++)
                        {

                            startPoint.easting += pointSpacing * Math.Sin(startPoint.heading);
                            startPoint.northing += pointSpacing * Math.Cos(startPoint.heading);

                            ytList.Add(startPoint);
                        }

                        // step 4 add the turn out to the ytList
                        for (int a = 0; a < cnt2; cnt2--)
                        {
                            ytList.Add(ytList2[cnt2 - 1]);
                        }

                        // step 5 add line extensions
                        isHeadingSameWay = mf.ABLine.isHeadingSameWay;
                        double head = mf.ABLine.abHeading;
                        if (isHeadingSameWay) head += Math.PI;
                        if (head >= glm.twoPI) head -= glm.twoPI;

                        AddSequenceLines(head);
                        isOutOfBounds = false;
                        youTurnPhase = 3;
                        turnTooCloseTrigger = false;
                        isTurnCreationTooClose = false;
                        return true;
                    }
                }
                return true;
            }

            else if (uTurnStyle == 1)
            {
                // ************************************************** K Turn ***************************************
                return (KStyleTurn(isTurnRight, headAB));
            }

            //just in case
            else
            {
                return false;
            }
        }

        //public double iE = 0, iN = 0;
        // the list of possible bounds points
        public List<CClose> turnClosestList = new List<CClose>();

        //point at the farthest turn segment from pivotAxle
        public CClose closestTurnPt = new CClose();

        //where the in and out tangents cross for ALbin curve
        public CClose inClosestTurnPt = new CClose();
        public CClose outClosestTurnPt = new CClose();

        public void FindClosestTurnPoint(vec3 fromPt)
        {
            double eP = fromPt.easting;
            double nP = fromPt.northing;
            double eAB, nAB;
            turnClosestList?.Clear();

            CClose cClose;

            if (mf.ABLine.isHeadingSameWay)
            {
                eAB = mf.ABLine.currentLinePtB.easting;
                nAB = mf.ABLine.currentLinePtB.northing;
            }
            else
            {
                eAB = mf.ABLine.currentLinePtA.easting;
                nAB = mf.ABLine.currentLinePtA.northing;
            }

            turnClosestList.Clear();

            for (int j = 0; j < mf.bnd.bndList.Count; j++)
            {
                for (int i = 0; i < mf.bnd.bndList[j].turnLine.Count - 1; i++)
                {
                    int res = GetLineIntersection(
                        mf.bnd.bndList[j].turnLine[i].easting,
                        mf.bnd.bndList[j].turnLine[i].northing,
                        mf.bnd.bndList[j].turnLine[i + 1].easting,
                        mf.bnd.bndList[j].turnLine[i + 1].northing,
                        eP, nP, eAB, nAB, ref iE, ref iN
                    );

                    if (res == 1)
                    {
                        cClose = new CClose();
                        cClose.closePt.easting = iE;
                        cClose.closePt.northing = iN;

                        double hed = Math.Atan2(mf.bnd.bndList[j].turnLine[i + 1].easting - mf.bnd.bndList[j].turnLine[i].easting,
                            mf.bnd.bndList[j].turnLine[i + 1].northing - mf.bnd.bndList[j].turnLine[i].northing);
                        if (hed < 0) hed += glm.twoPI;
                        cClose.closePt.heading = hed;
                        cClose.turnLineNum = j;
                        cClose.segmentIndex = i;

                        turnClosestList.Add(new CClose(cClose));
                    }
                }
            }

            //determine closest point
            double minDistance = double.MaxValue;

            if (turnClosestList.Count > 0)
            {
                for (int i = 0; i < turnClosestList.Count; i++)
                {
                    double dist = (((fromPt.easting - turnClosestList[i].closePt.easting) * (fromPt.easting - turnClosestList[i].closePt.easting))
                                    + ((fromPt.northing - turnClosestList[i].closePt.northing) * (fromPt.northing - turnClosestList[i].closePt.northing)));

                    if (minDistance >= dist)
                    {
                        
                        minDistance = dist;
                        closestTurnPt = new CClose(turnClosestList[i]);
                    }
                }
            }
        }

        private List<vec3> MoveTurnInsideTurnLine(List<vec3> uTurnList, double head)
        {
            //step 1 make array out of the list so that we can modify the position
            double cosHead = Math.Cos(head);
            double sinHead = Math.Sin(head);
            int cnt = uTurnList.Count;
            vec3[] arr2 = new vec3[cnt];
            uTurnList.CopyTo(arr2);
            uTurnList.Clear();

            semiCircleIndex = -1;
            //step 2 move the turn inside with steps of 1 meter
            bool pointOutOfBnd = true;
            int j = 0;
            int stopIfWayOut = 0;
            while (pointOutOfBnd)
            {
                stopIfWayOut++;
                pointOutOfBnd = false;
                mf.distancePivotToTurnLine = glm.Distance(arr2[0], mf.pivotAxlePos);

                for (int i = 0; i < cnt; i++)
                {
                    arr2[i].easting -= (sinHead);
                    arr2[i].northing -= (cosHead);
                }

                for (; j < cnt; j += 1)
                {
                    if (mf.bnd.IsPointInsideTurnArea(arr2[j]) != 0)
                    {
                        pointOutOfBnd = true;
                        if (j > 0) j--;
                        break;
                    }
                }

                if (stopIfWayOut == 1000 || (mf.distancePivotToTurnLine < 3))
                {
                    //for some reason it doesn't go inside boundary, return empty list
                    return uTurnList;

                }
            }

            ////step 3, the turn is now inside by 0-1 meters so we move it out again 1 meter
            //for (int i = 0; i < cnt; i++)
            //{
            //    arr2[i].easting += (sinHead);
            //    arr2[i].northing += (cosHead);
            //}

            //step 4, the turn is now outside again we move it inside in steps of 0.1 meters

            //pointOutOfBnd = true;
            //j = 0;
            //while (pointOutOfBnd)
            //{
            //    pointOutOfBnd = false;
            //    mf.distancePivotToTurnLine = glm.Distance(arr2[0], mf.pivotAxlePos);

            //    for (int i = 0; i < cnt; i++)
            //    {
            //        arr2[i].easting -= (sinHead * 0.1);
            //        arr2[i].northing -= (cosHead * 0.1);
            //    }

            //    for (; j < cnt; j += 2)
            //    {
            //        if (mf.bnd.IsPointInsideTurnArea(arr2[j]) != 0)
            //        {
            //            pointOutOfBnd = true;
            //            if (j > 0) j--;
            //            break;
            //        }
            //    }
            //    //no error handeling since we just were 1 meter back and it was okay then
            //}


            //step 5, we ar now inside turnfence by 0-0.1 meters, move the turn forward until it hits the turnfence in steps of 0.05 meters
            while (!pointOutOfBnd)
            {

                for (int i = 0; i < cnt; i++)
                {
                    arr2[i].easting += (sinHead * 0.1);
                    arr2[i].northing += (cosHead * 0.1);
                }

                for (int a = 0; a < cnt; a++)
                {
                    if (mf.bnd.IsPointInsideTurnArea(arr2[a]) != 0)
                    {
                        semiCircleIndex = a;
                        uTurnList.AddRange(arr2);
                        return uTurnList;
                    }
                }
            }

            //if empty - no creation.
            return uTurnList;

            //step 6, we have now placed the turn, so send it back in a list

        }

        public bool BuildCurveDubinsYouTurn(bool isTurnRight, vec3 pivotPos)
        {
            if (youTurnPhase > 0)
            {
                isHeadingSameWay = mf.curve.isHeadingSameWay;

                double head = crossingCurvePoint.heading;
                if (!isHeadingSameWay) head += Math.PI;

                //delta between AB heading and boundary closest point heading
                boundaryAngleOffPerpendicular = Math.PI - Math.Abs(Math.Abs(crossingheading - head) - Math.PI);
                boundaryAngleOffPerpendicular -= glm.PIBy2;
                boundaryAngleOffPerpendicular *= -1;
                if (boundaryAngleOffPerpendicular > 1.25) boundaryAngleOffPerpendicular = 1.25;
                if (boundaryAngleOffPerpendicular < -1.25) boundaryAngleOffPerpendicular = -1.25;

                //for calculating innner circles of turn
                double tangencyAngle = (glm.PIBy2 - Math.Abs(boundaryAngleOffPerpendicular)) * 0.5;

                double distanceTurnBeforeLine;
                //distance from crossPoint to turn line
                if (youTurnRadius * 2 < (mf.tool.width * rowSkipsWidth))
                {
                    if (boundaryAngleOffPerpendicular < 0)
                    {
                        //which is actually left
                        if (isYouTurnRight)
                            distanceTurnBeforeLine = (youTurnRadius * Math.Tan(tangencyAngle));//short
                        else
                            distanceTurnBeforeLine = (youTurnRadius / Math.Tan(tangencyAngle)); //long
                    }
                    else
                    {
                        //which is actually left
                        if (isYouTurnRight)
                            distanceTurnBeforeLine = (youTurnRadius / Math.Tan(tangencyAngle)); //long
                        else
                            distanceTurnBeforeLine = (youTurnRadius * Math.Tan(tangencyAngle)); //short
                    }
                }

                //turn Radius is wider then equipment width so ohmega turn
                else
                {
                    distanceTurnBeforeLine = (2 * youTurnRadius);
                }

                CDubins dubYouTurnPath = new CDubins();
                CDubins.turningRadius = youTurnRadius;

                //grab the vehicle widths and offsets
                double turnOffset = (mf.tool.width - mf.tool.overlap) * rowSkipsWidth + (isYouTurnRight ? -mf.tool.offset * 2.0 : mf.tool.offset * 2.0);

                //diagonally across
                double turnRadius = turnOffset / Math.Cos(boundaryAngleOffPerpendicular);

                //start point of Dubins
                vec3 start = new vec3(crossingCurvePoint.easting, crossingCurvePoint.northing, head);

                vec3 goal = new vec3
                {
                    //move the cross line calc to not include first turn
                    easting = crossingCurvePoint.easting + (Math.Sin(head) * distanceTurnBeforeLine),
                    northing = crossingCurvePoint.northing + (Math.Cos(head) * distanceTurnBeforeLine)
                };

                //headland angle relative to vehicle heading to head along the boundary left or right
                double bndAngle = head - boundaryAngleOffPerpendicular + glm.PIBy2;

                //now we go the other way to turn round
                head -= Math.PI;
                if (head < -Math.PI) head += glm.twoPI;
                if (head > Math.PI) head -= glm.twoPI;

                if ((youTurnRadius * 2.0) < turnOffset)
                {
                    //are we right of boundary
                    if (boundaryAngleOffPerpendicular > 0)
                    {
                        if (!isYouTurnRight) //which is actually right now
                        {
                            goal.easting += (Math.Sin(bndAngle) * turnRadius);
                            goal.northing += (Math.Cos(bndAngle) * turnRadius);

                            double dis = (youTurnRadius / Math.Tan(tangencyAngle)); //long
                            goal.easting += (Math.Sin(head) * dis);
                            goal.northing += (Math.Cos(head) * dis);
                        }
                        else //going left
                        {
                            goal.easting -= (Math.Sin(bndAngle) * turnRadius);
                            goal.northing -= (Math.Cos(bndAngle) * turnRadius);

                            double dis = (youTurnRadius * Math.Tan(tangencyAngle)); //short
                            goal.easting += (Math.Sin(head) * dis);
                            goal.northing += (Math.Cos(head) * dis);
                        }
                    }
                    else // going left of boundary
                    {
                        if (!isYouTurnRight) //pointing to right
                        {
                            goal.easting += (Math.Sin(bndAngle) * turnRadius);
                            goal.northing += (Math.Cos(bndAngle) * turnRadius);

                            double dis = (youTurnRadius * Math.Tan(tangencyAngle)); //short
                            goal.easting += (Math.Sin(head) * dis);
                            goal.northing += (Math.Cos(head) * dis);
                        }
                        else
                        {
                            goal.easting -= (Math.Sin(bndAngle) * turnRadius);
                            goal.northing -= (Math.Cos(bndAngle) * turnRadius);

                            double dis = (youTurnRadius / Math.Tan(tangencyAngle)); //long
                            goal.easting += (Math.Sin(head) * dis);
                            goal.northing += (Math.Cos(head) * dis);
                        }
                    }
                }
                else
                {
                    if (!isTurnRight)
                    {
                        goal.easting = crossingCurvePoint.easting - (Math.Cos(-head) * turnOffset);
                        goal.northing = crossingCurvePoint.northing - (Math.Sin(-head) * turnOffset);
                    }
                    else
                    {
                        goal.easting = crossingCurvePoint.easting + (Math.Cos(-head) * turnOffset);
                        goal.northing = crossingCurvePoint.northing + (Math.Sin(-head) * turnOffset);
                    }
                }

                goal.heading = head;

                //goal.easting += (Math.Sin(head) * 0.5);
                //goal.northing += (Math.Cos(head) * 0.5);
                //goal.heading = head;

                //generate the turn points
                ytList = dubYouTurnPath.GenerateDubins(start, goal);
                int count = ytList.Count;
                if (count == 0) return false;

                //these are the lead in lead out lines that add to the turn
                AddSequenceLines(head);
            }

            switch (youTurnPhase)
            {
                case 0: //find the crossing points
                    if (FindCurveTurnPoints()) youTurnPhase = 1;
                    ytList?.Clear();
                    break;

                case 1:
                    //now check to make sure we are not in an inner turn boundary - drive thru is ok
                    int count = ytList.Count;
                    if (count == 0) return false;

                    //Are we out of bounds?
                    isOutOfBounds = false;
                    for (int j = 0; j < count; j += 2)
                    {
                        if (mf.bnd.IsPointInsideTurnArea(ytList[j]) != 0)
                        {
                            isOutOfBounds = true;
                            break;
                        }
                    }

                    //first check if not out of bounds, add a bit more to clear turn line, set to phase 2
                    if (!isOutOfBounds)
                    {
                        youTurnPhase = 2;
                        //if (mf.curve.isABSameAsVehicleHeading)
                        //{
                        //    crossingCurvePoint.index -= 2;
                        //    if (crossingCurvePoint.index < 0) crossingCurvePoint.index = 0;
                        //}
                        //else
                        //{
                        //    crossingCurvePoint.index += 2;
                        //    if (crossingCurvePoint.index >= curListCount)
                        //        crossingCurvePoint.index = curListCount - 1;
                        //}
                        //crossingCurvePoint.easting = mf.curve.curList[crossingCurvePoint.index].easting;
                        //crossingCurvePoint.northing = mf.curve.curList[crossingCurvePoint.index].northing;
                        //crossingCurvePoint.heading = mf.curve.curList[crossingCurvePoint.index].heading;
                        return true;
                    }

                    //keep moving infield till pattern is all inside
                    if (mf.curve.isHeadingSameWay)
                    {
                        crossingCurvePoint.index--;
                        if (crossingCurvePoint.index < 0) crossingCurvePoint.index = 0;
                    }
                    else
                    {
                        crossingCurvePoint.index++;
                        if (crossingCurvePoint.index >= mf.curve.curList.Count)
                            crossingCurvePoint.index = mf.curve.curList.Count - 1;
                    }
                    crossingCurvePoint.easting = mf.curve.curList[crossingCurvePoint.index].easting;
                    crossingCurvePoint.northing = mf.curve.curList[crossingCurvePoint.index].northing;
                    crossingCurvePoint.heading = mf.curve.curList[crossingCurvePoint.index].heading;

                    double tooClose = glm.Distance(ytList[0], pivotPos);
                    isTurnCreationTooClose = tooClose < 3;

                    //set the flag to Critical stop machine
                    if (isTurnCreationTooClose)
                        mf.mc.isOutOfBounds = true;
                    break;

                case 2:
                    youTurnPhase = 3;
                    break;
            }
            return true;
        }

        public void SmoothYouTurn(int smPts)
        {
            //count the reference list of original curve
            int cnt = ytList.Count;

            //the temp array
            vec3[] arr = new vec3[cnt];

            //read the points before and after the setpoint
            for (int s = 0; s < smPts / 2; s++)
            {
                arr[s].easting = ytList[s].easting;
                arr[s].northing = ytList[s].northing;
                arr[s].heading = ytList[s].heading;
            }

            for (int s = cnt - (smPts / 2); s < cnt; s++)
            {
                arr[s].easting = ytList[s].easting;
                arr[s].northing = ytList[s].northing;
                arr[s].heading = ytList[s].heading;
            }

            //average them - center weighted average
            for (int i = smPts / 2; i < cnt - (smPts / 2); i++)
            {
                for (int j = -smPts / 2; j < smPts / 2; j++)
                {
                    arr[i].easting += ytList[j + i].easting;
                    arr[i].northing += ytList[j + i].northing;
                }
                arr[i].easting /= smPts;
                arr[i].northing /= smPts;
                arr[i].heading = ytList[i].heading;
            }

            ytList?.Clear();

            //calculate new headings on smoothed line
            for (int i = 1; i < cnt - 1; i++)
            {
                arr[i].heading = Math.Atan2(arr[i + 1].easting - arr[i].easting, arr[i + 1].northing - arr[i].northing);
                if (arr[i].heading < 0) arr[i].heading += glm.twoPI;
                ytList.Add(arr[i]);
            }
        }

        //called to initiate turn
        public void YouTurnTrigger()
        {
            //trigger pulled
            isYouTurnTriggered = true;

            if (alternateSkips && rowSkipsWidth2 > 1)
            {
                if (--turnSkips == 0)
                {
                    isYouTurnRight = !isYouTurnRight;
                    turnSkips = rowSkipsWidth2 * 2 - 1;
                }
                else if (previousBigSkip = !previousBigSkip)
                    rowSkipsWidth = rowSkipsWidth2 - 1;
                else
                    rowSkipsWidth = rowSkipsWidth2;
            }
            else isYouTurnRight = !isYouTurnRight;

            if (uTurnStyle == 0)
            {
                mf.guidanceLookPos.easting = ytList[ytList.Count - 1].easting;
                mf.guidanceLookPos.northing = ytList[ytList.Count - 1].northing;
            }
            else if (uTurnStyle == 1)
            {
                mf.guidanceLookPos.easting = pt3TurnNewAB.easting;
                mf.guidanceLookPos.northing = pt3TurnNewAB.northing;

                pt3Phase = 0;
            }

            if (mf.trk.idx > -1 && mf.trk.gArr.Count > 0)
            {
                if (mf.trk.gArr[mf.trk.idx].mode == (int)TrackMode.AB)
                {
                    mf.ABLine.isLateralTriggered = true;
                    mf.ABLine.isABValid = false;
                }
                else
                {
                    mf.curve.isLateralTriggered = true;
                    mf.curve.isCurveValid = false;
                }
            }
        }

        //Normal copmpletion of youturn
        public void CompleteYouTurn()
        {
            isYouTurnTriggered = false;
            ResetCreatedYouTurn();
            mf.sounds.isBoundAlarming = false;
        }

        public void Set_Alternate_skips()
        {
            rowSkipsWidth2 = rowSkipsWidth;
            turnSkips = rowSkipsWidth2 * 2 - 1;
            previousBigSkip = false;
        }

        //something went seriously wrong so reset everything
        public void ResetYouTurn()
        {
            //fix you turn
            isYouTurnTriggered = false;
            ytList?.Clear();
            ResetCreatedYouTurn();
            mf.sounds.isBoundAlarming = false;
            isTurnCreationTooClose = false;
            isTurnCreationNotCrossingError = false;
        }

        public void ResetCreatedYouTurn()
        {
            youTurnPhase = 0;
            ytList?.Clear();
            pt3ListSecondLine?.Clear();
            pt3Phase = 0;
        }

        public void BuildManualYouLateral(bool isTurnRight)
        {
            double head;
            //point on AB line closest to pivot axle point from ABLine PurePursuit
            if (mf.trk.idx > -1 && mf.trk.gArr.Count > 0)
            {
                if (mf.trk.gArr[mf.trk.idx].mode == (int)TrackMode.AB)
                {
                    rEastYT = mf.ABLine.rEastAB;
                    rNorthYT = mf.ABLine.rNorthAB;
                    isHeadingSameWay = mf.ABLine.isHeadingSameWay;
                    head = mf.ABLine.abHeading;
                    mf.ABLine.isLateralTriggered = true;
                }
                else
                {
                    rEastYT = mf.curve.rEastCu;
                    rNorthYT = mf.curve.rNorthCu;
                    isHeadingSameWay = mf.curve.isHeadingSameWay;
                    head = mf.curve.manualUturnHeading;
                    mf.curve.isLateralTriggered = true;
                }
            }
            else return;

            //grab the vehicle widths and offsets
            double turnOffset = (mf.tool.width - mf.tool.overlap); //remove rowSkips

            //if its straight across it makes 2 loops instead so goal is a little lower then start
            if (!isHeadingSameWay) head += Math.PI;

            //move the start forward 2 meters, this point is critical to formation of uturn
            rEastYT += (Math.Sin(head) * 2);
            rNorthYT += (Math.Cos(head) * 2);

            if (isTurnRight)
            {
                mf.guidanceLookPos.easting = rEastYT + (Math.Cos(-head) * turnOffset);
                mf.guidanceLookPos.northing = rNorthYT + (Math.Sin(-head) * turnOffset);
            }
            else
            {
                mf.guidanceLookPos.easting = rEastYT - (Math.Cos(-head) * turnOffset);
                mf.guidanceLookPos.northing = rNorthYT - (Math.Sin(-head) * turnOffset);
            }

            mf.ABLine.isABValid = false;
            mf.curve.isCurveValid = false;
        }

        //build the points and path of youturn to be scaled and transformed
        public void BuildManualYouTurn(bool isTurnRight, bool isTurnButtonTriggered)
        {
            isYouTurnTriggered = true;

            double head;
            //point on AB line closest to pivot axle point from ABLine PurePursuit
            if (mf.trk.idx > -1 && mf.trk.gArr.Count > 0)
            {
                if (mf.trk.gArr[mf.trk.idx].mode == (int)TrackMode.AB)
                {
                    rEastYT = mf.ABLine.rEastAB;
                    rNorthYT = mf.ABLine.rNorthAB;
                    isHeadingSameWay = mf.ABLine.isHeadingSameWay;
                    head = mf.ABLine.abHeading;
                    mf.ABLine.isLateralTriggered = true;
                }

                else
                {
                    rEastYT = mf.curve.rEastCu;
                    rNorthYT = mf.curve.rNorthCu;
                    isHeadingSameWay = mf.curve.isHeadingSameWay;
                    head = mf.curve.manualUturnHeading;
                    mf.curve.isLateralTriggered = true;
                }
            }
            else return;

            //grab the vehicle widths and offsets
            double turnOffset = (mf.tool.width - mf.tool.overlap) * rowSkipsWidth + (isTurnRight ? mf.tool.offset * 2.0 : -mf.tool.offset * 2.0);

            CDubins dubYouTurnPath = new CDubins();
            CDubins.turningRadius = youTurnRadius;

            //if its straight across it makes 2 loops instead so goal is a little lower then start
            if (!isHeadingSameWay) head += 3.14;
            else head -= 0.01;

            //move the start forward 2 meters, this point is critical to formation of uturn
            rEastYT += (Math.Sin(head) * 4);
            rNorthYT += (Math.Cos(head) * 4);

            //now we have our start point
            vec3 start = new vec3(rEastYT, rNorthYT, head);
            vec3 goal = new vec3();

            //now we go the other way to turn round
            head -= Math.PI;
            if (head < 0) head += glm.twoPI;

            //set up the goal point for Dubins
            goal.heading = head;
            if (isTurnButtonTriggered)
            {
                if (isTurnRight)
                {
                    goal.easting = rEastYT - (Math.Cos(-head) * turnOffset);
                    goal.northing = rNorthYT - (Math.Sin(-head) * turnOffset);
                }
                else
                {
                    goal.easting = rEastYT + (Math.Cos(-head) * turnOffset);
                    goal.northing = rNorthYT + (Math.Sin(-head) * turnOffset);
                }
            }

            //generate the turn points
            ytList = dubYouTurnPath.GenerateDubins(start, goal);

            mf.guidanceLookPos.easting = ytList[ytList.Count - 1].easting;
            mf.guidanceLookPos.northing = ytList[ytList.Count - 1].northing;

            //vec3 pt;
            //for (double a = 0; a < 2; a += 0.2)
            //{
            //    pt.easting = ytList[0].easting + (Math.Sin(head) * a);
            //    pt.northing = ytList[0].northing + (Math.Cos(head) * a);
            //    pt.heading = ytList[0].heading;
            //    ytList.Insert(0, pt);
            //}

            //int count = ytList.Count;

            //for (double i = 0.2; i <= 7; i += 0.2)
            //{
            //    pt.easting = ytList[count - 1].easting + (Math.Sin(head) * i);
            //    pt.northing = ytList[count - 1].northing + (Math.Cos(head) * i);
            //    pt.heading = head;
            //    ytList.Add(pt);
            //}

            mf.ABLine.isABValid = false;
            mf.curve.isCurveValid = false;
        }

        public int onA;

        //determine distance from youTurn guidance line
        public bool DistanceFromYouTurnLine()
        {
            //grab a copy from main - the steer position
            double minDistA = 1000000, minDistB = 1000000;
            int ptCount = ytList.Count;

            if (ptCount > 0)
            {
                if (mf.isStanleyUsed)
                {
                    pivot = mf.steerAxlePos;

                    //find the closest 2 points to current fix
                    for (int t = 0; t < ptCount; t++)
                    {
                        double dist = ((pivot.easting - ytList[t].easting) * (pivot.easting - ytList[t].easting))
                                        + ((pivot.northing - ytList[t].northing) * (pivot.northing - ytList[t].northing));
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

                    if (minDistA > 16)
                    {
                        CompleteYouTurn();
                        return false;
                    }

                    //just need to make sure the points continue ascending or heading switches all over the place
                    if (A > B)
                    {
                        (B, A) = (A, B);
                    }

                    //minDistA = 100;
                    //int closestPt = 0;
                    //for (int i = 0; i < ptCount; i++)
                    //{
                    //    double distancePiv = glm.DistanceSquared(ytList[i], pivot);
                    //    if (distancePiv < minDistA)
                    //    {
                    //        minDistA = distancePiv;
                    //    }
                    //}

                    //feed backward to turn slower to keep pivot on
                    A -= 7;
                    if (A < 0)
                    {
                        A = 0;
                    }
                    B = A + 1;

                    //return and reset if too far away or end of the line
                    if (B >= ptCount - 8)
                    {
                        CompleteYouTurn();
                        return false;
                    }

                    //get the distance from currently active AB line, precalc the norm of line
                    double dx = ytList[B].easting - ytList[A].easting;
                    double dz = ytList[B].northing - ytList[A].northing;
                    if (Math.Abs(dx) < Double.Epsilon && Math.Abs(dz) < Double.Epsilon) return false;

                    double abHeading = ytList[A].heading;

                    //how far from current AB Line is steer point 90 degrees from steer position
                    distanceFromCurrentLine = ((dz * pivot.easting) - (dx * pivot.northing) + (ytList[B].easting
                                * ytList[A].northing) - (ytList[B].northing * ytList[A].easting))
                                    / Math.Sqrt((dz * dz) + (dx * dx));

                    //Calc point on ABLine closest to current position and 90 degrees to segment heading
                    double U = (((pivot.easting - ytList[A].easting) * dx)
                                + ((pivot.northing - ytList[A].northing) * dz))
                                / ((dx * dx) + (dz * dz));

                    //critical point used as start for the uturn path - critical
                    rEastYT = ytList[A].easting + (U * dx);
                    rNorthYT = ytList[A].northing + (U * dz);

                    //the first part of stanley is to extract heading error
                    double abFixHeadingDelta = (pivot.heading - abHeading);

                    //Fix the circular error - get it from -Pi/2 to Pi/2
                    if (abFixHeadingDelta > Math.PI) abFixHeadingDelta -= Math.PI;
                    else if (abFixHeadingDelta < Math.PI) abFixHeadingDelta += Math.PI;
                    if (abFixHeadingDelta > glm.PIBy2) abFixHeadingDelta -= Math.PI;
                    else if (abFixHeadingDelta < -glm.PIBy2) abFixHeadingDelta += Math.PI;

                    if (mf.isReverse) abFixHeadingDelta *= -1;
                    //normally set to 1, less then unity gives less heading error.
                    abFixHeadingDelta *= mf.vehicle.stanleyHeadingErrorGain;
                    if (abFixHeadingDelta > 0.74) abFixHeadingDelta = 0.74;
                    if (abFixHeadingDelta < -0.74) abFixHeadingDelta = -0.74;

                    //the non linear distance error part of stanley
                    steerAngleYT = Math.Atan((distanceFromCurrentLine * mf.vehicle.stanleyDistanceErrorGain) / ((mf.avgSpeed * 0.277777) + 1));

                    //clamp it to max 42 degrees
                    if (steerAngleYT > 0.74) steerAngleYT = 0.74;
                    if (steerAngleYT < -0.74) steerAngleYT = -0.74;

                    //add them up and clamp to max in vehicle settings
                    steerAngleYT = glm.toDegrees((steerAngleYT + abFixHeadingDelta) * -1.0);
                    if (steerAngleYT < -mf.vehicle.maxSteerAngle) steerAngleYT = -mf.vehicle.maxSteerAngle;
                    if (steerAngleYT > mf.vehicle.maxSteerAngle) steerAngleYT = mf.vehicle.maxSteerAngle;
                }
                else
                {
                    pivot = mf.pivotAxlePos;

                    //find the closest 2 points to current fix
                    for (int t = 0; t < ptCount; t++)
                    {
                        double dist = ((pivot.easting - ytList[t].easting) * (pivot.easting - ytList[t].easting))
                                        + ((pivot.northing - ytList[t].northing) * (pivot.northing - ytList[t].northing));
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
                    if (A > B)
                    {
                        (B, A) = (A, B);
                    }

                    onA = A;
                    double distancePiv = glm.Distance(ytList[A], pivot);

                    if (distancePiv > 1 || (B >= ptCount - 1))
                    {
                        {
                            CompleteYouTurn();
                            return false;
                        }
                    }

                    //get the distance from currently active AB line
                    double dx = ytList[B].easting - ytList[A].easting;
                    double dz = ytList[B].northing - ytList[A].northing;

                    if (Math.Abs(dx) < double.Epsilon && Math.Abs(dz) < double.Epsilon) return false;

                    //how far from current AB Line is fix
                    distanceFromCurrentLine = ((dz * pivot.easting) - (dx * pivot.northing) + (ytList[B].easting
                                * ytList[A].northing) - (ytList[B].northing * ytList[A].easting))
                                    / Math.Sqrt((dz * dz) + (dx * dx));

                    // ** Pure pursuit ** - calc point on ABLine closest to current position
                    double U = (((pivot.easting - ytList[A].easting) * dx)
                                + ((pivot.northing - ytList[A].northing) * dz))
                                / ((dx * dx) + (dz * dz));

                    rEastYT = ytList[A].easting + (U * dx);
                    rNorthYT = ytList[A].northing + (U * dz);

                    //sharp turns on you turn.
                    //update base on autosteer settings and distance from line
                    double goalPointDistance = 0.8 * mf.vehicle.UpdateGoalPointDistance();

                    isHeadingSameWay = true;
                    bool ReverseHeading = !mf.isReverse;

                    int count = ReverseHeading ? 1 : -1;
                    vec3 start = new vec3(rEastYT, rNorthYT, 0);
                    double distSoFar = 0;

                    for (int i = ReverseHeading ? B : A; i < ptCount && i >= 0; i += count)
                    {
                        // used for calculating the length squared of next segment.
                        double tempDist = glm.Distance(start, ytList[i]);

                        //will we go too far?
                        if ((tempDist + distSoFar) > goalPointDistance)
                        {
                            double j = (goalPointDistance - distSoFar) / tempDist; // the remainder to yet travel

                            goalPointYT.easting = (((1 - j) * start.easting) + (j * ytList[i].easting));
                            goalPointYT.northing = (((1 - j) * start.northing) + (j * ytList[i].northing));
                            break;
                        }
                        else distSoFar += tempDist;
                        start = ytList[i];
                        if (i == ptCount - 1)//goalPointDistance is longer than remaining u-turn
                        {
                            CompleteYouTurn();
                            return false;
                        }

                        if (pt3Phase == 1 && i < 2)
                        {
                            CompleteYouTurn();
                            return false;
                        }

                        if (uTurnStyle == 1 && pt3Phase == 0 && isLastFrameForward && mf.isReverse)
                        {
                            ytList.Clear();
                            ytList.AddRange(pt3ListSecondLine);
                            pt3Phase++;
                            return true;
                        }

                        if (uTurnStyle == 1 && pt3Phase == 1 && !isLastFrameForward && !mf.isReverse)
                        {
                            CompleteYouTurn();
                            return false;
                        }

                        isLastFrameForward = mf.isReverse;
                    }

                    //calc "D" the distance from pivot axle to lookahead point
                    double goalPointDistanceSquared = glm.DistanceSquared(goalPointYT.northing, goalPointYT.easting, pivot.northing, pivot.easting);

                    //calculate the the delta x in local coordinates and steering angle degrees based on wheelbase
                    double localHeading = glm.twoPI - mf.fixHeading;
                    ppRadiusYT = goalPointDistanceSquared / (2 * (((goalPointYT.easting - pivot.easting) * Math.Cos(localHeading)) + ((goalPointYT.northing - pivot.northing) * Math.Sin(localHeading))));

                    steerAngleYT = glm.toDegrees(Math.Atan(2 * (((goalPointYT.easting - pivot.easting) * Math.Cos(localHeading))
                        + ((goalPointYT.northing - pivot.northing) * Math.Sin(localHeading))) * mf.vehicle.wheelbase / goalPointDistanceSquared));

                    if (steerAngleYT < -mf.vehicle.maxSteerAngle) steerAngleYT = -mf.vehicle.maxSteerAngle;
                    if (steerAngleYT > mf.vehicle.maxSteerAngle) steerAngleYT = mf.vehicle.maxSteerAngle;

                    if (ppRadiusYT < -500) ppRadiusYT = -500;
                    if (ppRadiusYT > 500) ppRadiusYT = 500;

                    radiusPointYT.easting = pivot.easting + (ppRadiusYT * Math.Cos(localHeading));
                    radiusPointYT.northing = pivot.northing + (ppRadiusYT * Math.Sin(localHeading));

                    //distance is negative if on left, positive if on right
                    if (!isHeadingSameWay)
                        distanceFromCurrentLine *= -1.0;
                }

                //used for smooth mode
                mf.vehicle.modeActualXTE = (distanceFromCurrentLine);

                //Convert to centimeters
                mf.guidanceLineDistanceOff = (short)Math.Round(distanceFromCurrentLine * 1000.0, MidpointRounding.AwayFromZero);
                mf.guidanceLineSteerAngle = (short)(steerAngleYT * 100);
                return true;
            }
            else
            {
                CompleteYouTurn();
                return false;
            }
        }

        //Duh.... What does this do....
        public void DrawYouTurn()
        {
            int ptCount = ytList.Count;
            if (ptCount < 3) return;
            GL.PointSize(mf.ABLine.lineWidth * 2);

            if (isYouTurnTriggered)
                GL.Color3(0.95f, 0.5f, 0.95f);
            else if (isOutOfBounds)
                GL.Color3(0.9495f, 0.395f, 0.325f);
            else
                GL.Color3(0.395f, 0.925f, 0.30f);

            GL.Begin(PrimitiveType.Points);
            for (int i = 0; i < ptCount; i++)
            {
                GL.Vertex3(ytList[i].easting, ytList[i].northing, 0);
            }
            GL.Color3(0.195f, 0.41f, 0.980f);

            //if (pt3Phase == 0)
            //{
            //    GL.Color3(0.95f, 0.925f, 0.30f);

            //    for (int i = 0; i < pt3ListSecondLine.Count; i++)
            //    {
            //        GL.Vertex3(pt3ListSecondLine[i].easting, pt3ListSecondLine[i].northing, 0);
            //    }
            //}
            GL.End();
        }

        public class CClose
        {
            public vec3 closePt = new vec3();
            public int turnLineNum;
            public int segmentIndex;

            public CClose()
            {
                closePt = new vec3();
                turnLineNum = -1;
                segmentIndex = -1;
            }

            public CClose(CClose _clo)
            {
                closePt = new vec3(_clo.closePt);
                turnLineNum = _clo.turnLineNum;
                segmentIndex = _clo.segmentIndex;
            }
        }
    }
}