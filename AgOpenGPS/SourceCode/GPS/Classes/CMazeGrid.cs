using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public class CMazeGrid
    {
        private readonly FormGPS mf;

        public int[] mazeArr;
        public int mazeScale = 1;
        public int mazeRowYDim;
        public int mazeColXDim;
        //public List<vec3> mazePathList = new List<vec3>();

        public CMazeGrid(FormGPS _f)
        {
            mf = _f;
            mazeArr = new int[0];
        }

        public void BuildMazeGridArray()
        {
            //mf.CalculateMinMax();
            double mazeY = (mf.maxFieldY - mf.minFieldY);
            double mazeX = (mf.maxFieldX - mf.minFieldX);

            if (mazeY > mazeX) mazeScale = (int)(mazeY / 150);
            else mazeScale = (int)(mazeX / 150);

            if (mazeScale < 4) mazeScale = 4;
            //mazeScale = 4;

            mazeRowYDim = (int)mazeY / mazeScale;
            mazeColXDim = (int)mazeX / mazeScale;
            mazeArr = new int[mazeRowYDim * mazeColXDim];

            //row is Y, col is X   int[Y,X] [i,j] [row,col]
            vec3 pot = new vec3();

            //mf.yt.triggerDistanceOffset += mazeScale;
            //mf.turn.BuildTurnLines();

            int[,] arr = new int[mazeRowYDim, mazeColXDim];

            for (int i = 0; i < mazeRowYDim; i++)
            {
                for (int j = 0; j < mazeColXDim; j++)
                {
                    pot.easting = (j * mazeScale) + (int)mf.minFieldX;
                    pot.northing = (i * mazeScale) + (int)mf.minFieldY;
                    if (!mf.gf.IsPointInsideGeoFences(pot))
                    {
                        mazeArr[(i * mazeColXDim) + j] = 1;
                        arr[i, j] = 1;
                    }
                    else
                    {
                        mazeArr[(i * mazeColXDim) + j] = 0;
                        arr[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < mazeRowYDim; i++)
            {
                for (int j = 0; j < mazeColXDim; j++)
                {
                    if (i > 0 && i < mazeRowYDim - 1 && j > 0 && j < mazeColXDim - 1)
                    {
                        if (arr[i, j] == 1 && arr[i + 1, j] == 0) arr[i + 1, j] = 2;
                        if (arr[i, j] == 1 && arr[i - 1, j] == 0) arr[i - 1, j] = 2;
                        if (arr[i, j] == 1 && arr[i, j + 1] == 0) arr[i, j + 1] = 2;
                        if (arr[i, j] == 1 && arr[i, j - 1] == 0) arr[i, j - 1] = 2;
                    }
                }
            }

            for (int i = 0; i < mazeRowYDim; i++)
            {
                for (int j = 0; j < mazeColXDim; j++)
                {
                    if (arr[i, j] == 2)
                    {
                        mazeArr[(i * mazeColXDim) + j] = 1;
                        arr[i, j] = 1;
                    }
                }
            }

            //for (int i = 0; i < mazeRowYDim; i++)
            //{
            //    for (int j = 0; j < mazeColXDim; j++)
            //    {
            //        if (i > 0 && i < mazeRowYDim - 1 && j > 0 && j < mazeColXDim - 1)
            //        {
            //            if (arr[i, j] == 1 && arr[i + 1, j] == 0) arr[i + 1, j] = 2;
            //            if (arr[i, j] == 1 && arr[i - 1, j] == 0) arr[i - 1, j] = 2;
            //            if (arr[i, j] == 1 && arr[i, j + 1] == 0) arr[i, j + 1] = 2;
            //            if (arr[i, j] == 1 && arr[i, j - 1] == 0) arr[i, j - 1] = 2;
            //        }
            //    }
            //}

            //for (int i = 0; i < mazeRowYDim; i++)
            //{
            //    for (int j = 0; j < mazeColXDim; j++)
            //    {
            //        if (arr[i, j] == 2)
            //            mazeArr[(i * mazeColXDim) + j] = 1;
            //    }
            //}
        }

        public List<vec3> SearchForPath(vec3 start, vec3 stop)
        {
            CMazePath maze = new CMazePath(mazeRowYDim, mazeColXDim, mazeArr);

            List<vec3> mazeList = maze.Search((int)((start.northing - mf.minFieldY) / mf.mazeGrid.mazeScale),
                                                (int)((start.easting - mf.minFieldX) / mf.mazeGrid.mazeScale),
                                          (int)((stop.northing - mf.minFieldY) / mf.mazeGrid.mazeScale),
                                          (int)((stop.easting - mf.minFieldX) / mf.mazeGrid.mazeScale));

            if (mazeList == null) return mazeList;

            //we find our way back, we want to go forward, so reverse the list
            mazeList.Reverse();

            int cnt = mazeList.Count;

            if (cnt < 3)
            {
                mazeList?.Clear();
                return mazeList;
            }

            //the temp array
            vec3[] arr2 = new vec3[cnt];

            mazeList.CopyTo(arr2);
            mazeList.Clear();

            for (int h = 0; h < cnt; h++)
            {
                arr2[h].easting = (arr2[h].easting * mazeScale) + mf.minFieldX;
                arr2[h].northing = (arr2[h].northing * mazeScale) + mf.minFieldY;
                mazeList.Add(arr2[h]);
            }

            //fill in the gaps
            for (int i = 0; i < cnt; i++)
            {
                int j = i + 1;
                if (j == cnt)
                    j = i;
                double distance = glm.Distance(mazeList[i], mazeList[j]);
                if (distance > 2)
                {
                    vec3 pointB = new vec3((mazeList[i].easting + mazeList[j].easting) / 2.0,
                                        (mazeList[i].northing + mazeList[j].northing) / 2.0, 0);

                    mazeList.Insert(j, pointB);
                    cnt = mazeList.Count;
                    i--; //go back to original point again
                }
            }

            cnt = mazeList.Count;

            //the temp array
            vec3[] arr = new vec3[cnt];

            //how many samples
            int smPts = mazeScale;

            //read the points before and after the setpoint
            for (int s = 0; s < smPts; s++)
            {
                arr[s].easting = mazeList[s].easting;
                arr[s].northing = mazeList[s].northing;
                arr[s].heading = mazeList[s].heading;
            }

            for (int s = cnt - smPts; s < cnt; s++)
            {
                arr[s].easting = mazeList[s].easting;
                arr[s].northing = mazeList[s].northing;
                arr[s].heading = mazeList[s].heading;
            }

            //average them - center weighted average
            for (int i = smPts; i < cnt - smPts; i++)
            {
                for (int j = -smPts; j < smPts; j++)
                {
                    arr[i].easting += mazeList[j + i].easting;
                    arr[i].northing += mazeList[j + i].northing;
                }
                arr[i].easting /= (smPts * 2);
                arr[i].northing /= (smPts * 2);
                arr[i].heading = mazeList[i].heading;
            }

            //clear the list and reload with calc headings - first and last droppped
            mazeList?.Clear();

            for (int i = mazeScale; i < cnt - mazeScale; i++)
            {
                vec3 pt3 = arr[i];
                pt3.heading = Math.Atan2(arr[i + 1].easting - arr[i].easting, arr[i + 1].northing - arr[i].northing);
                if (pt3.heading < 0) pt3.heading += glm.twoPI;
                mazeList.Add(pt3);
            }

            return mazeList;
        }

        //public int ConvertToGrid(vec3 pt)
        //{
        //    pt.northing = (pt.northing - mf.minFieldY) / mazeScale;
        //    pt.easting = (pt.easting - mf.minFieldX) / mazeScale;
        //    return (int)((pt.northing * mazeColXDim) + pt.easting);
        //}

        public void DrawArr()
        {
            GL.PointSize(2.0f);
            GL.Begin(PrimitiveType.Points);
            int ptCount = mazeRowYDim * mazeColXDim;
            for (int h = 0; h < ptCount; h++)
            {
                if (mazeArr[h] == 1)
                {
                    GL.Color3(0.0095f, 0.007520f, 0.97530f);
                    int Y = h / mazeColXDim; //Y
                    int X = h - (h / mazeColXDim * mazeColXDim); //X
                    GL.Vertex3((X * mazeScale) + (int)mf.minFieldX, (Y * mazeScale) + (int)mf.minFieldY, 0);
                }
                else
                {
                    GL.Color3(0.95f, 0.7520f, 0.07530f);
                    int Y = h / mazeColXDim; //Y
                    int X = h - (h / mazeColXDim * mazeColXDim); //X
                    GL.Vertex3((X * mazeScale) + (int)mf.minFieldX, (Y * mazeScale) + (int)mf.minFieldY, 0);
                }
            }
            GL.End();
        }
    }
}