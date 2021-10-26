using System;

namespace AgOpenGPS
{
    public partial class CBoundary
    {
        public bool isHeadlandOn;
        public double leftToolDistance;
        public double rightToolDistance;

        //generated box for finding closest point
        public vec2 downL = new vec2(9000, 9000), downR = new vec2(9000, 9002);

        public bool isToolInHeadland, isToolUp, isToolOuterPointsInHeadland;

        public bool isToolLeftIn = false;
        public bool isToolRightIn = false;
        public bool isLookRightIn = false;
        public bool isLookLeftIn = false;

        public void SetHydPosition()
        {
            if (mf.vehicle.isHydLiftOn && mf.pn.speed > 0.2 && mf.autoBtnState == FormGPS.btnStates.Auto)
            {
                if (isToolInHeadland)
                {
                    mf.p_239.pgn[mf.p_239.hydLift] = 2;
                    isToolUp = true;
                }
                else
                {
                    mf.p_239.pgn[mf.p_239.hydLift] = 1;
                    isToolUp = false;
                }
            }
        }

        public void WhereAreToolCorners()
        {
            if (bndList.Count > 0 && bndList[0].hdLine.Count > 0)
            {
                bool isLeftInWk, isRightInWk = true;

                if (isHeadlandOn)
                {
                    for (int j = 0; j < mf.tool.numOfSections; j++)
                    {
                        if (j == 0)
                        {
                            //only one first left point, the rest are all rights moved over to left
                            isLeftInWk = bndList[0].IsPointInPolygon(mf.section[j].leftPoint, ref bndList[0].hdLine);
                            isRightInWk = bndList[0].IsPointInPolygon(mf.section[j].rightPoint, ref bndList[0].hdLine);

                            //save left side
                            mf.tool.isLeftSideInHeadland = !isLeftInWk;

                            //merge the two sides into in or out
                            mf.section[j].isInHeadlandArea = !isLeftInWk && !isRightInWk;

                        }
                        else
                        {
                            //grab the right of previous section, its the left of this section
                            isLeftInWk = isRightInWk;
                            isRightInWk = bndList[0].IsPointInPolygon(mf.section[j].rightPoint, ref bndList[0].hdLine);

                            mf.section[j].isInHeadlandArea = !isLeftInWk && !isRightInWk;
                        }
                    }

                    //save right side
                    mf.tool.isRightSideInHeadland = !isRightInWk;

                    //is the tool in or out based on endpoints
                    isToolOuterPointsInHeadland = mf.tool.isLeftSideInHeadland && mf.tool.isRightSideInHeadland;
                }
                else
                {
                    //set all to true;
                    isToolOuterPointsInHeadland = true;
                }
            }
        }

        public void WhereAreToolLookOnPoints()
        {
            if (bndList.Count > 0 && bndList[0].hdLine.Count > 0)
            {
                vec3 toolFix = mf.toolPos;
                double sinAB = Math.Sin(toolFix.heading);
                double cosAB = Math.Cos(toolFix.heading);

                double pos = mf.section[0].rpSectionWidth;
                double mOn = (mf.tool.lookAheadDistanceOnPixelsRight - mf.tool.lookAheadDistanceOnPixelsLeft) / mf.tool.rpWidth;
                double endHeight = (mf.tool.lookAheadDistanceOnPixelsLeft + (mOn * pos)) * 0.1;

                for (int j = 0; j < mf.tool.numOfSections; j++)
                {
                    if (j == 0)
                    {
                        downL.easting = mf.section[j].leftPoint.easting + (sinAB * mf.tool.lookAheadDistanceOnPixelsLeft * 0.1);
                        downL.northing = mf.section[j].leftPoint.northing + (cosAB * mf.tool.lookAheadDistanceOnPixelsLeft * 0.1);

                        downR.easting = mf.section[j].rightPoint.easting + (sinAB * endHeight);
                        downR.northing = mf.section[j].rightPoint.northing + (cosAB * endHeight);

                        isLookLeftIn = IsPointInsideHeadLine(downL);
                        isLookRightIn = IsPointInsideHeadLine(downR);

                        mf.section[j].isLookOnInHeadland = !isLookLeftIn && !isLookRightIn;
                        isLookLeftIn = isLookRightIn;
                    }
                    else
                    {
                        pos += mf.section[j].rpSectionWidth;
                        endHeight = (mf.tool.lookAheadDistanceOnPixelsLeft + (mOn * pos)) * 0.1;

                        downR.easting = mf.section[j].rightPoint.easting + (sinAB * endHeight);
                        downR.northing = mf.section[j].rightPoint.northing + (cosAB * endHeight);

                        isLookRightIn = IsPointInsideHeadLine(downR);
                        mf.section[j].isLookOnInHeadland = !isLookLeftIn && !isLookRightIn;
                        isLookLeftIn = isLookRightIn;
                    }
                }
            }
        }

        public bool IsPointInsideHeadLine(vec2 pt)
        {
            //if inside outer boundary, then potentially add
            if (bndList.Count > 0 && bndList[0].IsPointInPolygon(pt, ref bndList[0].hdLine))
            {
                for (int b = 1; b < bndList.Count; b++)
                {
                    if (bndList[b].IsPointInPolygon(pt, ref bndList[b].hdLine))
                    {
                        //point is in an inner turn area but inside outer
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}