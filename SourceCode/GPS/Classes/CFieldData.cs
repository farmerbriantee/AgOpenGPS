using System;

namespace AgOpenGPS
{
    public class CFieldData
    {
        private readonly FormGPS mf;

        //all the section area added up;
        public double workedAreaTotal;

        //just a cumulative tally based on distance and eq width.
        public double workedAreaTotalUser;

        //accumulated user distance
        public double distanceUser;

        public double barPercent = 0;

        public double overlapPercent = 0;

        //Outside area minus inner boundaries areas (m)
        public double areaBoundaryOuterLessInner;

        //used for overlap calcs - total done minus overlap
        public double actualAreaCovered;

        //Inner area of outer boundary(m)
        public double areaOuterBoundary;

        //not really used - but if needed
        public double userSquareMetersAlarm;

        //Area inside Boundary less inside boundary areas
        public string AreaBoundaryLessInnersHectares
        {
            get
            {
                if (areaBoundaryOuterLessInner < 404048) return (areaBoundaryOuterLessInner * glm.m2ha).ToString("N2") + " ha";
                else return (areaBoundaryOuterLessInner * glm.m2ha).ToString("N1") + " ha";
            }
        }

        public string AreaBoundaryLessInnersAcres
        {
            get
            {
                if ((areaBoundaryOuterLessInner) < 404048) return (areaBoundaryOuterLessInner * glm.m2ac).ToString("N2") + " ac";
                else return (areaBoundaryOuterLessInner * glm.m2ac).ToString("N1") + " ac";
            }
        }

        //USer tally string
        public string WorkedUserHectares => (workedAreaTotalUser * glm.m2ha).ToString("N2");

        //user tally string
        public string WorkedUserAcres => (workedAreaTotalUser * glm.m2ac).ToString("N2");

        //String of Area worked
        public string WorkedAcres
        {
            get
            {
                if (workedAreaTotal < 404048) return (workedAreaTotal * 0.000247105).ToString("N2") + " ac";
                else return (workedAreaTotal * 0.000247105).ToString("N1") + " ac";
            }
        }

        public string WorkedHectares
        {
            get
            {
                if (workedAreaTotal < 99000) return (workedAreaTotal * 0.0001).ToString("N2") + " ha";
                else return (workedAreaTotal * 0.0001).ToString("N1") + " ha";
            }
        }

        //User Distance strings
        public string DistanceUserMeters => Convert.ToString((ushort)distanceUser) + " m";

        public string DistanceUserFeet => Convert.ToString((ushort)(distanceUser * glm.m2ft)) + " ft";

        //remaining area to be worked
        public string WorkedAreaRemainHectares => ((areaBoundaryOuterLessInner - workedAreaTotal) * glm.m2ha).ToString("N2") + " ha";

        public string WorkedAreaRemainAcres => ((areaBoundaryOuterLessInner - workedAreaTotal) * glm.m2ac).ToString("N2") + " ac";

        //overlap strings          

        public string WorkedAreaRemainPercentage
        {
            get
            {
                if (areaBoundaryOuterLessInner > 10)
                {
                    barPercent = 100 - ((areaBoundaryOuterLessInner - workedAreaTotal) * 100 / areaBoundaryOuterLessInner);
                    return barPercent.ToString("N1") + "%";
                }
                else
                {
                    barPercent = 0;
                    return "0%";
                }
            }
        }

        public string TimeTillFinished
        {
            get
            {
                if (mf.avgSpeed > 2)
                {
                    TimeSpan timeSpan = TimeSpan.FromHours(((areaBoundaryOuterLessInner - workedAreaTotal) * glm.m2ha
                        / (mf.tool.width * mf.avgSpeed * 0.1)));
                    return timeSpan.Hours.ToString("00") + ":" + timeSpan.Minutes.ToString("00");
                }
                else return "\u221E Hrs";
            }
        }

        public string WorkRateHectares => (mf.tool.width * mf.avgSpeed * 0.1).ToString("N1");
        public string WorkRateAcres => (mf.tool.width * mf.avgSpeed * 0.2471).ToString("N1");

        //constructor
        public CFieldData(FormGPS _f)
        {
            mf = _f;
            workedAreaTotal = 0;
            workedAreaTotalUser = 0;
            userSquareMetersAlarm = 0;
        }

        public void UpdateFieldBoundaryGUIAreas()
        {
            if (mf.bnd.bndList.Count > 0)
            {
                areaOuterBoundary = mf.bnd.bndList[0].area;
                areaBoundaryOuterLessInner = areaOuterBoundary;

                for (int i = 1; i < mf.bnd.bndList.Count; i++)
                {
                    areaBoundaryOuterLessInner -= mf.bnd.bndList[i].area;
                }
            }
            else
            {
                areaOuterBoundary = 0;
                areaBoundaryOuterLessInner = 0;
            }
            //if (mf.isMetric) mf.btnManualOffOn.Text = AreaBoundaryLessInnersHectares;
            //else mf.btnManualOffOn.Text = AreaBoundaryLessInnersAcres;
        }
    }
}