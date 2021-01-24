using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public class CGeoFence
    {
        //copy of the mainform address
        private readonly FormGPS mf;

        /// <summary>
        /// array of turns
        /// </summary>
        public List<CGeoFenceLines> geoFenceArr = new List<CGeoFenceLines>();

        //constructor
        public CGeoFence(FormGPS _f)
        {
            mf = _f;
        }




        public bool IsPointInsideGeoFences(vec2 pt)
        {
            //if inside outer boundary, then potentially add
            if (geoFenceArr.Count > 0 && geoFenceArr[0].IsPointInGeoFenceArea(pt))
            {
                for (int b = 1; b < mf.bnd.bndArr.Count; b++)
                {
                    if (mf.bnd.bndArr[b].isSet)
                    {
                        if (geoFenceArr[b].IsPointInGeoFenceArea(pt))
                        {
                            //point is in an inner turn area but inside outer
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void BuildGeoFenceLines()
        {
            //update the GUI values for boundaries
            //mf.fd.UpdateFieldBoundaryGUIAreas();

            if (mf.bnd.bndArr.Count == 0)
            {
                //mf.TimedMessageBox(1500, " No Boundary ", "No GeoFence Made");
                return;
            }

            //to fill the list of line points
            vec3 point = new vec3();

            //determine how wide a headland space
            double totalHeadWidth = mf.yt.geoFenceDistance;

            //outside boundary - count the points from the boundary
            geoFenceArr[0].geoFenceLine.Clear();
            int ptCount = mf.bnd.bndArr[0].bndLine.Count;
            for (int i = ptCount - 1; i >= 0; i--)
            {
                //calculate the point inside the boundary
                point.easting = mf.bnd.bndArr[0].bndLine[i].easting + (-Math.Sin(glm.PIBy2 + mf.bnd.bndArr[0].bndLine[i].heading) * totalHeadWidth);
                point.northing = mf.bnd.bndArr[0].bndLine[i].northing + (-Math.Cos(glm.PIBy2 + mf.bnd.bndArr[0].bndLine[i].heading) * totalHeadWidth);
                point.heading = mf.bnd.bndArr[0].bndLine[i].heading;
                if (point.heading < -glm.twoPI) point.heading += glm.twoPI;

                //only add if inside actual field boundary
                if (mf.bnd.bndArr[0].IsPointInsideBoundary(point))
                {
                    vec2 tPnt = new vec2(point.easting, point.northing);
                    geoFenceArr[0].geoFenceLine.Add(tPnt);
                }
            }
            geoFenceArr[0].FixGeoFenceLine(totalHeadWidth, mf.bnd.bndArr[0].bndLine, mf.tool.toolWidth);
            geoFenceArr[0].PreCalcTurnLines();

            //inside boundaries
            for (int j = 1; j < mf.bnd.bndArr.Count; j++)
            {
                geoFenceArr[j].geoFenceLine.Clear();
                if (!mf.bnd.bndArr[j].isSet || mf.bnd.bndArr[j].isDriveThru) continue;

                ptCount = mf.bnd.bndArr[j].bndLine.Count;

                for (int i = ptCount - 1; i >= 0; i--)
                {
                    //calculate the point outside the boundary
                    point.easting = mf.bnd.bndArr[j].bndLine[i].easting + (-Math.Sin(glm.PIBy2 + mf.bnd.bndArr[j].bndLine[i].heading) * totalHeadWidth);
                    point.northing = mf.bnd.bndArr[j].bndLine[i].northing + (-Math.Cos(glm.PIBy2 + mf.bnd.bndArr[j].bndLine[i].heading) * totalHeadWidth);
                    point.heading = mf.bnd.bndArr[j].bndLine[i].heading;
                    if (point.heading < -glm.twoPI) point.heading += glm.twoPI;

                    //only add if outside actual field boundary
                    if (!mf.bnd.bndArr[j].IsPointInsideBoundary(point))
                    {
                        vec2 tPnt = new vec2(point.easting, point.northing);
                        geoFenceArr[j].geoFenceLine.Add(tPnt);
                    }
                }
                geoFenceArr[j].FixGeoFenceLine(totalHeadWidth, mf.bnd.bndArr[j].bndLine, mf.tool.toolWidth * 0.5);
                geoFenceArr[j].PreCalcTurnLines();
            }

            //mf.TimedMessageBox(800, "Turn Lines", "Turn limits Created");
        }

        public void DrawGeoFenceLines()
        {
            for (int i = 0; i < mf.bnd.bndArr.Count; i++)
            {
                if (mf.bnd.bndArr[i].isSet)
                    geoFenceArr[i].DrawGeoFenceLine();
            }
        }
    }
}