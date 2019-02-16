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

        //Outside area minus inner boundaries areas (m)
        public double areaBoundaryOuterLessInner;

        //Inner area of outer boundary(m)
        public double areaOuterBoundary;

        //not really used - but if needed
        public double userSquareMetersAlarm;

        //Area inside Boundary less inside boundary areas
        public string AreaBoundaryLessInnersHectares { get { return (areaBoundaryOuterLessInner * glm.m2ha).ToString("N2") + " Ha"; } }

        public string AreaBoundaryLessInnersAcres { get { return (areaBoundaryOuterLessInner * glm.m2ac).ToString("N2") + " Ac"; } }

        //USer tally string
        public string WorkedUserHectares { get { return (workedAreaTotalUser * glm.m2ha).ToString("N2") + " Ha"; } }

        public string WorkedUserHectares2 { get { return (workedAreaTotalUser * glm.m2ha).ToString("N2"); } }

        //user tally string
        public string WorkedUserAcres { get { return (workedAreaTotalUser * glm.m2ac).ToString("N2") + " Ac"; } }

        public string WorkedUserAcres2 { get { return (workedAreaTotalUser * glm.m2ac).ToString("N2"); } }

        //String of Area worked
        public string WorkedAcres
        {
            get
            {
                if (workedAreaTotal < 404048) return (workedAreaTotal * 0.000247105).ToString("N2");
                else return (workedAreaTotal * 0.000247105).ToString("N1");
            }
        }

        public string WorkedHectares
        {
            get
            {
                if (workedAreaTotal < 99000) return (workedAreaTotal * 0.0001).ToString("N2");
                else return (workedAreaTotal * 0.0001).ToString("N1");
            }
        }

        //User Distance strings
        public string DistanceUserMeters { get { return Convert.ToString((UInt16)(distanceUser)) + " m"; } }

        public string DistanceUserFeet { get { return Convert.ToString((UInt16)(distanceUser * glm.m2ft)) + " ft"; } }

        //remaining area to be worked
        public string WorkedAreaRemainHectares { get { return ((areaBoundaryOuterLessInner - workedAreaTotal) * glm.m2ha).ToString("N2") + " Ha"; } }

        public string WorkedAreaRemainAcres { get { return ((areaBoundaryOuterLessInner - workedAreaTotal) * glm.m2ac).ToString("N2") + " Ac"; } }

        public string WorkedAreaRemainPercentage
        {
            get
            {
                if (areaBoundaryOuterLessInner > 10)
                    return ((areaBoundaryOuterLessInner - workedAreaTotal) * 100 / areaBoundaryOuterLessInner).ToString("N2") + "%";
                else return "0.00%";
            }
        }

        public string TimeTillFinished
        {
            get
            {
                if (mf.pn.speed > 0.1)
                    return (((areaBoundaryOuterLessInner - workedAreaTotal) * glm.m2ha) / (mf.vehicle.toolWidth * mf.pn.speed * 0.1)).ToString("N1") + " Hours";
                else return "\u221E Hours";
            }
        }

        public string WorkRateHectares { get { return (mf.vehicle.toolWidth * mf.pn.speed * 0.1).ToString("N1") + "\r\nHa/hr"; } }
        public string WorkRateAcres { get { return (mf.vehicle.toolWidth * mf.pn.speed * 0.2471).ToString("N1") + "\r\rAc/hr"; } }

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
            areaOuterBoundary = mf.bnd.bndArr[0].area;
            areaBoundaryOuterLessInner = areaOuterBoundary;

            for (int i = 1; i < FormGPS.MAXBOUNDARIES; i++)
            {
                if (mf.bnd.bndArr[i].isSet) areaBoundaryOuterLessInner -= mf.bnd.bndArr[i].area;
            }
        }
    }
}