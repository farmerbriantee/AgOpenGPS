using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public partial class CBoundaryLines
    {
        //list of coordinates of boundary line
        public List<vec3> bndLine = new List<vec3>(128);
        public List<vec2> bndLineEar = new List<vec2>(128);
        public List<vec3> hdLine = new List<vec3>(128);
        public List<vec3> turnLine = new List<vec3>(128);

        //area variable
        public double area;

        //boundary variables
        public bool isDriveAround, isDriveThru;

        //constructor
        public CBoundaryLines()
        {
            area = 0;
            isDriveAround = false;
            isDriveThru = false;
        }

        public void CalculateBoundaryHeadings()
        {
            //to calc heading based on next and previous points to give an average heading.
            int cnt = bndLine.Count;
            vec3[] arr = new vec3[cnt];
            cnt--;
            bndLine.CopyTo(arr);
            bndLine.Clear();

            //first point needs last, first, second points
            vec3 pt3 = arr[0];
            pt3.heading = Math.Atan2(arr[1].easting - arr[cnt].easting, arr[1].northing - arr[cnt].northing);
            if (pt3.heading < 0) pt3.heading += glm.twoPI;
            bndLine.Add(pt3);

            //middle points
            for (int i = 1; i < cnt; i++)
            {
                pt3 = arr[i];
                pt3.heading = Math.Atan2(arr[i + 1].easting - arr[i - 1].easting, arr[i + 1].northing - arr[i - 1].northing);
                if (pt3.heading < 0) pt3.heading += glm.twoPI;
                bndLine.Add(pt3);
            }

            //last and first point
            pt3 = arr[cnt];
            pt3.heading = Math.Atan2(arr[0].easting - arr[cnt - 1].easting, arr[0].northing - arr[cnt - 1].northing);
            if (pt3.heading < 0) pt3.heading += glm.twoPI;
            bndLine.Add(pt3);
        }

        public void FixBoundaryLine(int bndNum)
        {
            double spacing;
            //boundary point spacing based on eq width
            //close if less then 30 ha, 60ha, more then 60
            if (area < 200000) spacing = 1.1;
            else if (area < 400000) spacing = 2.2;
            else spacing = 3.3;

            if (bndNum > 0) spacing *= 0.5;

            int bndCount = bndLine.Count;
            double distance;

            //make sure distance isn't too big between points on boundary
            for (int i = 0; i < bndCount; i++)
            {
                int j = i + 1;

                if (j == bndCount) j = 0;
                distance = glm.Distance(bndLine[i], bndLine[j]);
                if (distance > spacing * 1.5)
                {
                    vec3 pointB = new vec3((bndLine[i].easting + bndLine[j].easting) / 2.0,
                        (bndLine[i].northing + bndLine[j].northing) / 2.0, bndLine[i].heading);

                    bndLine.Insert(j, pointB);
                    bndCount = bndLine.Count;
                    i--;
                }
            }

            //make sure distance isn't too big between points on boundary
            bndCount = bndLine.Count;

            for (int i = 0; i < bndCount; i++)
            {
                int j = i + 1;

                if (j == bndCount) j = 0;
                distance = glm.Distance(bndLine[i], bndLine[j]);
                if (distance > spacing * 1.6)
                {
                    vec3 pointB = new vec3((bndLine[i].easting + bndLine[j].easting) / 2.0,
                        (bndLine[i].northing + bndLine[j].northing) / 2.0, bndLine[i].heading);

                    bndLine.Insert(j, pointB);
                    bndCount = bndLine.Count;
                    i--;
                }
            }

            //make sure distance isn't too small between points on headland
            spacing *= 1.2;
            bndCount = bndLine.Count;
            for (int i = 0; i < bndCount - 1; i++)
            {
                distance = glm.Distance(bndLine[i], bndLine[i + 1]);
                if (distance < spacing)
                {
                    bndLine.RemoveAt(i + 1);
                    bndCount = bndLine.Count;
                    i--;
                }
            }

            //make sure headings are correct for calculated points
            CalculateBoundaryHeadings();

            double delta = 0;
            bndLineEar?.Clear();

            for (int i = 0; i < bndLine.Count; i++)
            {
                if (i == 0)
                {
                    bndLineEar.Add(new vec2(bndLine[i].easting, bndLine[i].northing));
                    continue;
                }
                delta += (bndLine[i - 1].heading - bndLine[i].heading);
                if (Math.Abs(delta) > 0.01)
                {
                    bndLineEar.Add(new vec2(bndLine[i].easting, bndLine[i].northing));
                    delta = 0;
                }
            }
        }

        public void ReverseWinding()
        {
            //reverse the boundary
            int cnt = bndLine.Count;
            vec3[] arr = new vec3[cnt];
            cnt--;
            bndLine.CopyTo(arr);
            bndLine.Clear();
            for (int i = cnt; i >= 0; i--)
            {
                arr[i].heading -= Math.PI;
                if (arr[i].heading < 0) arr[i].heading += glm.twoPI;
                bndLine.Add(arr[i]);
            }
        }

        public bool IsPointInsideBoundaryArea(vec3 testPoint)
        {
            bool result = false;
            int j = bndLine.Count - 1;
            for (int i = 0; i < bndLine.Count; i++)
            {
                if ((bndLine[i].easting < testPoint.easting && bndLine[j].easting >= testPoint.easting) || (bndLine[j].easting < testPoint.easting && bndLine[i].easting >= testPoint.easting))
                {
                    if (bndLine[i].northing + (testPoint.easting - bndLine[i].easting) / (bndLine[j].easting - bndLine[i].easting) * (bndLine[j].northing - bndLine[i].northing) < testPoint.northing)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }

        public bool IsPointInBoundaryEar(vec2 testPoint)
        {
            bool result = false;
            int j = bndLineEar.Count - 1;
            for (int i = 0; i < bndLineEar.Count; i++)
            {
                if ((bndLineEar[i].easting < testPoint.easting && bndLineEar[j].easting >= testPoint.easting) || (bndLineEar[j].easting < testPoint.easting && bndLineEar[i].easting >= testPoint.easting))
                {
                    if (bndLineEar[i].northing + (testPoint.easting - bndLineEar[i].easting) / (bndLineEar[j].easting - bndLineEar[i].easting) * (bndLineEar[j].northing - bndLineEar[i].northing) < testPoint.northing)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }

        public bool IsPointInsideBoundaryEar(vec3 testPoint)
        {
            bool result = false;
            int j = bndLineEar.Count - 1;
            for (int i = 0; i < bndLineEar.Count; i++)
            {
                if ((bndLineEar[i].easting < testPoint.easting && bndLineEar[j].easting >= testPoint.easting) || (bndLineEar[j].easting < testPoint.easting && bndLineEar[i].easting >= testPoint.easting))
                {
                    if (bndLineEar[i].northing + (testPoint.easting - bndLineEar[i].easting) / (bndLineEar[j].easting - bndLineEar[i].easting) * (bndLineEar[j].northing - bndLineEar[i].northing) < testPoint.northing)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }

        public void DrawBoundaryLine(int lw, bool outOfBounds)
        {
            ////draw the perimeter line so far
            if (bndLine.Count < 1) return;
            //GL.PointSize(8);
            //int ptCount = bndLine.Count;
            //GL.Color3(0.925f, 0.752f, 0.860f);
            ////else 
            //GL.Begin(PrimitiveType.Points);
            //for (int h = 0; h < ptCount; h++) GL.Vertex3(bndLine[h].easting, bndLine[h].northing, 0);
            ////GL.Color3(0.95f, 0.972f, 0.90f);
            ////GL.Vertex3(bndLine[0].easting, bndLine[0].northing, 0);
            //GL.End();

            //ptCount = bdList.Count;
            //if (ptCount < 1) return;
            if (!outOfBounds)
            {
                GL.Color3(0.95f, 0.75f, 0.50f);
                GL.LineWidth(lw);
            }
            else
            {
                GL.LineWidth(lw * 3);
                GL.Color3(0.95f, 0.25f, 0.250f);
            }

            GL.Begin(PrimitiveType.LineLoop);
            for (int i = 0; i < bndLineEar.Count; i++)
            {
                GL.Vertex3(bndLineEar[i].easting, bndLineEar[i].northing, 0);
            }
            GL.End();
        }

        //obvious
        public bool CalculateBoundaryArea(int idx)
        {
            int ptCount = bndLine.Count;
            if (ptCount < 1) return false;
            bool isClockwise = true;

            area = 0;         // Accumulates area in the loop
            int j = ptCount - 1;  // The last vertex is the 'previous' one to the first

            for (int i = 0; i < ptCount; j = i++)
            {
                area += (bndLine[j].easting + bndLine[i].easting) * (bndLine[j].northing - bndLine[i].northing);
            }
            if (area < 0) isClockwise = false;

            area = Math.Abs(area / 2);

            //make sure is clockwise for outer counter clockwise for inner
            if ((idx == 0 && isClockwise) || (idx > 0 && !isClockwise))
            {
                ReverseWinding();
            }

            return isClockwise;
        }
    }
}