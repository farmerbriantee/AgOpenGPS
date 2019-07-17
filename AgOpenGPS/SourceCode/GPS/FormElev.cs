using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormElev : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf = null;

        private double maxFieldX, maxFieldY, minFieldX, minFieldY, fieldCenterX, fieldCenterY, maxFieldDistance, gain = 1;
        private double minElevation, maxElevation;
        private double peakElevation, baseElevation, waterLevel;
        private int fieldWidth, fieldHeight;

        private bool isLoaded;

        //list of recorded elevation points
        private List<vec3> elevRecPts = new List<vec3>();

        //list of strip data individual points
        private vec3 [,] elevGrid;

        public FormElev(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            elevGrid = new vec3[0,0];

            InitializeComponent();
        }
          
        private void NudWaterLevel_ValueChanged(object sender, EventArgs e)
        {
            waterLevel = (double)nudWaterLevel.Value;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            oglElev.Refresh();
            if (isLoaded)
            {
                progressBar1.Visible = false;
                lblBuildMap.Visible = false;
            }

        }

        private void FormElev_Load(object sender, EventArgs e)
        {

            if (LoadElevationPoints())
            {
                CalculateMinMax();
                //MakeElevationGrid();
                var progress = new Progress<int>(value => { progressBar1.Value = value; });
                Task.Run(() => MakeElevationGrid(progress));
            }
        }


        private void MakeElevationGrid(IProgress<int> progress)
        {
            if (fieldWidth > 1 && fieldHeight > 1)
            {
                elevGrid = new vec3[fieldWidth, fieldHeight];
                int ptCount = elevRecPts.Count;
                if (ptCount < 10)
                {
                    return;
                }

                double minDistance;
                int closestPt = 0;
                for (int j = 0; j < fieldWidth; j++)
                {
                    for (int k = 0; k < fieldHeight; k++)
                    {
                        minDistance = 99999;
                        for (int i = 0; i < ptCount; i++)
                        {
                            double dist = ((elevRecPts[i].easting - (j+minFieldX)) * (elevRecPts[i].easting - (j + minFieldX)))
                                            + ((elevRecPts[i].northing - (k + minFieldY)) * (elevRecPts[i].northing - (k + minFieldY)));
                            if (minDistance >= dist)
                            {
                                minDistance = dist;
                                closestPt = i;
                            }
                        }

                        elevGrid[j, k].heading = elevRecPts[closestPt].heading;
                        elevGrid[j, k].easting = j + minFieldX;
                        elevGrid[j, k].northing = k + minFieldY;
                    }
                    progress?.Report(((j*100)/fieldWidth));
                }
                isLoaded = true;
            }
        }

        private void OglElev_Load(object sender, EventArgs e)
        {
            oglElev.MakeCurrent();
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            //GL.Enable(EnableCap.CullFace);
            //GL.CullFace(CullFaceMode.Back);
            GL.ClearColor(0.23122f, 0.2318f, 0.2315f, 1.0f);
        }

        private void OglElev_Paint(object sender, PaintEventArgs e)
        {
            if (isLoaded)
            {
                oglElev.MakeCurrent();

                GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
                GL.LoadIdentity();                  // Reset The View

                CalculateMinMax();

                //back the camera up
                GL.Translate(0, 0, -maxFieldDistance * gain);

                //GL.Rotate(-170, 1.0, 0.0, 0.0);

                //translate to that spot in the world
                GL.Translate(-fieldCenterX, -fieldCenterY, 0);

                GL.Color3(0, 0.6, 0.4);

                //GL.Enable(EnableCap.Texture2D);
                //GL.BindTexture(TextureTarget.Texture2D, mf.texture[1]);
                GL.Begin(PrimitiveType.TriangleStrip);
                GL.Color3(0.0f, 0.25f, 0.5f);
                //GL.TexCoord2(0, 0);
                GL.Vertex3(minFieldX, maxFieldY, waterLevel);
                //GL.TexCoord2(1, 0.0);
                GL.Vertex3(maxFieldX, maxFieldY, waterLevel);
                //GL.TexCoord2(0.0, 1);
                GL.Vertex3(minFieldX, minFieldY, waterLevel);
                //GL.TexCoord2(1, 1);
                GL.Vertex3(maxFieldX, minFieldY, waterLevel);
                GL.End();
                //GL.Disable(EnableCap.Texture2D);

                double elevColor, bas;
                //draw points
                //raw current AB Line
                GL.PointSize(8.0f);
                GL.Begin(PrimitiveType.Points);

                //foreach (var ptList in elevRecPts)
                //{
                //    elevColor = bas = ptList.heading - baseElevation;
                //    elevColor /= peakElevation;
                //    GL.Color3(elevColor, 0.0, 0.0);
                //    GL.Vertex3(ptList.easting, ptList.northing, bas);
                //}

                for (int j = 0; j < fieldWidth; j++)
                {
                    for (int k = 0; k < fieldHeight; k++)
                    {
                        elevColor = bas = elevGrid[j, k].heading - baseElevation;
                        elevColor /= peakElevation;
                        GL.Color3(elevColor, 0.0, 0.0);
                        GL.Vertex3(elevGrid[j, k].easting, elevGrid[j, k].northing, bas);

                    }
                }


                GL.End();



                ////draw the ABLine
                //if (mf.ABLine.isABLineSet || mf.ABLine.isABLineBeingSet)
                //{
                //    //Draw AB Ref Line Points
                //    GL.PointSize(8.0f);
                //    GL.Begin(PrimitiveType.Points);

                //    GL.Color3(0.95f, 0.0f, 0.0f);
                //    GL.Vertex3(mf.ABLine.refPoint1.easting, mf.ABLine.refPoint1.northing, 0.0);
                //    GL.Color3(0.0f, 0.90f, 0.95f);
                //    GL.Vertex3(mf.ABLine.refPoint2.easting, mf.ABLine.refPoint2.northing, 0.0);
                //    GL.End();

                //    //Draw reference AB line ref
                //    GL.LineWidth(2);
                //    GL.Enable(EnableCap.LineStipple);
                //    GL.LineStipple(1, 0x00F0);
                //    GL.Begin(PrimitiveType.Lines);
                //    GL.Color3(0.9f, 0.15f, 0.17f);
                //    GL.Vertex3(mf.ABLine.refABLineP1.easting, mf.ABLine.refABLineP1.northing, 0);
                //    GL.Color3(0.2f, 0.95f, 0.17f);
                //    GL.Vertex3(mf.ABLine.refABLineP2.easting, mf.ABLine.refABLineP2.northing, 0);
                //    GL.End();
                //    GL.Disable(EnableCap.LineStipple);

                //    //raw current AB Line
                //    GL.PointSize(2.0f);
                //    GL.Begin(PrimitiveType.Points);
                //    //GL.Color3(0.9f, 0.0f, 0.0f);
                //    //GL.Vertex3(mf.ABLine.currentABLineP1.easting, mf.ABLine.currentABLineP1.northing, 0.0);
                //    //GL.Vertex3(mf.ABLine.currentABLineP2.easting, mf.ABLine.currentABLineP2.northing, 0.0);
                //    //GL.Color3(0.9f, 0.5f, 0.0f);
                //    //GL.Vertex3(lastABLineP1.easting, lastABLineP1.northing, 0);
                //    //GL.Vertex3(lastABLineP2.easting, lastABLineP2.northing, 0);

                //    foreach (var ptList in mf.self.lineList)
                //    {
                //        int count2 = ptList.Count;

                //        for (int i = 0; i < count2; i++) GL.Vertex3(ptList[i].easting, ptList[i].northing, 0);
                //    }

                //    GL.End();
                //}

                ////draw all the boundaries
                //mf.bnd.DrawBoundaryLines();
                //mf.turn.DrawTurnLines();

                //GL.PointSize(8.0f);
                //GL.Begin(PrimitiveType.Points);
                //GL.Color3(0.95f, 0.90f, 0.0f);
                //GL.Vertex3(mf.self.pint.easting, mf.self.pint.northing, 0.0);
                //GL.End();
                //GL.PointSize(1.0f);

                GL.Flush();
                oglElev.SwapBuffers();
            }
        }

        private void OglElev_Resize(object sender, EventArgs e)
        {
            oglElev.MakeCurrent();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            //

            GL.Viewport(0, 0, oglElev.Width, oglElev.Height);
            Matrix4 mat = Matrix4.CreatePerspectiveFieldOfView(1.01f, (float)oglElev.Width / (float)oglElev.Height,
                100.0f, 500.0f);
            GL.LoadMatrix(ref mat);
            GL.MatrixMode(MatrixMode.Modelview);


        }

        private void CalculateMinMax()
        {
            minFieldX = 9999999; minFieldY = 9999999;
            maxFieldX = -9999999; maxFieldY = -9999999;
            maxElevation = -999999;
            minElevation = 999999;

            //every time the section turns off and on is a new patch
            int patchCount = elevRecPts.Count;

            if (patchCount > 0)
            {
                //for every new chunk of patch
                foreach (var triList in elevRecPts)
                {
                    double x = triList.heading;

                    //also tally the max/min of field elevation
                    if (minElevation > x) minElevation = x;
                    if (maxElevation < x) maxElevation = x;
                }
            }

            baseElevation = minElevation;
            peakElevation = maxElevation - minElevation;

            //min max of the boundary
            if (mf.bnd.bndArr[0].isSet)
            {
                int bndCnt = mf.bnd.bndArr[0].bndLine.Count;
                for (int i = 0; i < bndCnt; i++)
                {
                    double x = mf.bnd.bndArr[0].bndLine[i].easting;
                    double y = mf.bnd.bndArr[0].bndLine[i].northing;

                    //also tally the max/min of field x and z
                    if (minFieldX > x) minFieldX = x;
                    if (maxFieldX < x) maxFieldX = x;
                    if (minFieldY > y) minFieldY = y;
                    if (maxFieldY < y) maxFieldY = y;
                }
            }

            if (maxFieldX == -9999999 || minFieldX == 9999999 || maxFieldY == -9999999 || minFieldY == 9999999)
            {
                maxFieldX = 0; minFieldX = 0; maxFieldY = 0; minFieldY = 0;
            }
            else
            {
                //the largest distance across field
                fieldWidth = (int)Math.Abs(minFieldX - maxFieldX);
                fieldHeight = (int)Math.Abs(minFieldY - maxFieldY);

                if (fieldWidth > fieldHeight) maxFieldDistance = fieldWidth;
                else maxFieldDistance = fieldHeight;

                if (maxFieldDistance < 100) maxFieldDistance = 100;
                if (maxFieldDistance > 19900) maxFieldDistance = 19900;
                //lblMax.Text = ((int)maxFieldDistance).ToString();

                fieldCenterX = (maxFieldX + minFieldX) / 2.0;
                fieldCenterY = (maxFieldY + minFieldY) / 2.0;
            }
        }

        private bool LoadElevationPoints()
        {
            string fileAndDirectory = mf.fieldsDirectory + mf.currentFieldDirectory + "\\Elevation.txt";
            if (File.Exists(fileAndDirectory))
            {
                string line;
                using (StreamReader reader = new StreamReader(fileAndDirectory))
                {
                    try
                    {
                        //read header
                        for (int i = 0; i < 9; i++) line = reader.ReadLine();
                        elevRecPts.Clear();

                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();
                            string[] words = line.Split(',');
                            vec3 point = new vec3(
                                double.Parse(words[0], CultureInfo.InvariantCulture),
                                double.Parse(words[1], CultureInfo.InvariantCulture),
                                double.Parse(words[2], CultureInfo.InvariantCulture));
                            //add the point
                            elevRecPts.Add(point);
                        }
                    }

                    catch (Exception e)
                    {
                        var form = new FormTimedMessage(4000, "Elevation File is Corrupt", "This is bad");
                        form.Show();
                        mf.WriteErrorLog("Load Elevation Points" + e.ToString());
                    }


                }
                if (elevRecPts.Count < 10)
                {
                    var form2 = new FormTimedMessage(4000, "Elevation File is Empty", "Nothing to Generate Terrain From");
                    form2.Show();
                    Close();
                    return false;
                }
                else return true;
            }
            else
            {
                var form = new FormTimedMessage(4000, "Elevation File is Missing", "Going to exit back");
                form.Show();
                Close();
                return false;
            }
        }
    }
}
