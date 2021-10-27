using OpenTK.Graphics.OpenGL;
using System;

namespace AgOpenGPS
{
    public partial class CBoundaryList
    {
        public void CalculateTurnHeadings()
        {
            //to calc heading based on next and previous points to give an average heading.
            int cnt = turnLine.Count;
            vec3[] arr = new vec3[cnt];
            cnt--;
            turnLine.CopyTo(arr);
            turnLine.Clear();

            //first point needs last, first, second points
            vec3 pt3 = arr[0];
            pt3.heading = Math.Atan2(arr[1].easting - arr[cnt].easting, arr[1].northing - arr[cnt].northing);
            if (pt3.heading < 0) pt3.heading += glm.twoPI;
            turnLine.Add(pt3);

            //middle points
            for (int i = 1; i < cnt; i++)
            {
                pt3 = arr[i];
                pt3.heading = Math.Atan2(arr[i + 1].easting - arr[i - 1].easting, arr[i + 1].northing - arr[i - 1].northing);
                if (pt3.heading < 0) pt3.heading += glm.twoPI;
                turnLine.Add(pt3);
            }

            //last and first point
            pt3 = arr[cnt];
            pt3.heading = Math.Atan2(arr[0].easting - arr[cnt - 1].easting, arr[0].northing - arr[cnt - 1].northing);
            if (pt3.heading < 0) pt3.heading += glm.twoPI;
            turnLine.Add(pt3);
        }

        public void FixTurnLine(double totalHeadWidth, double spacing)
        {
            //count the points from the boundary
            int lineCount = turnLine.Count;

            totalHeadWidth *= totalHeadWidth;
            spacing *= spacing;

            //int headCount = mf.bndArr[inTurnNum].bndLine.Count;
            double distance;

            //remove the points too close to boundary
            for (int i = 0; i < fenceLine.Count; i++)
            {
                for (int j = 0; j < lineCount; j++)
                {
                    //make sure distance between headland and boundary is not less then width
                    distance = glm.DistanceSquared(fenceLine[i], turnLine[j]);
                    if (distance < (totalHeadWidth * 0.99))
                    {
                        turnLine.RemoveAt(j);
                        lineCount = turnLine.Count;
                        j = -1;
                    }
                }
            }


            //make sure distance isn't too big between points on Turn
            int bndCount = turnLine.Count;
            for (int i = 0; i < bndCount; i++)
            {
                int j = i + 1;
                if (j == bndCount) j = 0;
                distance = glm.DistanceSquared(turnLine[i], turnLine[j]);
                if (distance > (spacing * 1.8))
                {
                    vec3 pointB = new vec3((turnLine[i].easting + turnLine[j].easting) / 2.0, (turnLine[i].northing + turnLine[j].northing) / 2.0, turnLine[i].heading);

                    turnLine.Insert(j, pointB);
                    bndCount = turnLine.Count;
                    i--;
                }
            }

            //make sure distance isn't too small between points on turnLine
            bndCount = turnLine.Count;
            for (int i = 0; i < bndCount - 1; i++)
            {
                distance = glm.DistanceSquared(turnLine[i], turnLine[i + 1]);
                if (distance < spacing)
                {
                    turnLine.RemoveAt(i + 1);
                    bndCount = turnLine.Count;
                    i--;
                }
            }

            //make sure headings are correct for calculated points
            if (turnLine.Count > 0)
            {
                CalculateTurnHeadings();
            }

            //int cnt = turnLine.Count;
            //vec3[] arr = new vec3[cnt];
            //turnLine.CopyTo(arr);
            //turnLine.Clear();

            //double delta = 0;
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (i == 0)
            //    {
            //        turnLine.Add(new vec3(arr[i].easting, arr[i].northing, arr[i].heading));
            //        continue;
            //    }
            //    delta += (arr[i - 1].heading - arr[i].heading);

            //    if (Math.Abs(delta) > 0.1)
            //    {
            //        vec3 pt = new vec3(arr[i].easting, arr[i].northing, arr[i].heading);

            //        turnLine.Add(pt);
            //        delta = 0;
            //    }
            //}
        }

        public void DrawTurnLine()
        {
            ////draw the turn line oject
            int ptCount = turnLine.Count;
            if (ptCount < 1) return;
            GL.LineWidth(1);
            GL.Color3(0.8555f, 0.9232f, 0.60f);
            GL.PointSize(2);
            GL.Begin(PrimitiveType.LineLoop);
            for (int h = 0; h < ptCount; h++) GL.Vertex3(turnLine[h].easting, turnLine[h].northing, 0);
            GL.Vertex3(turnLine[0].easting, turnLine[0].northing, 0);
            GL.End();
        }
    }
}