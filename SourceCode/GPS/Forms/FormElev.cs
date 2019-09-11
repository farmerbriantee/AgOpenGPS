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

        private double maxFieldX, maxFieldY, minFieldX, minFieldY, fieldCenterX, fieldCenterY, maxFieldDistance, zoomGain = 1;
        private double minElevation, maxElevation;
        private double deltaElevation, baseElevation, waterLevel;

        private int fieldWidth, fieldHeight;

        private bool isLoaded;

        //list of recorded elevation points
        private List<vec3> elevRecPts = new List<vec3>();

        private void NudZoomGain_ValueChanged(object sender, EventArgs e)
        {
            zoomGain = (double)nudZoomGain.Value;
        }

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
                for (int j = 0; j < fieldWidth; j+=8)
                {
                    for (int k = 0; k < fieldHeight; k+=8)
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

                //CalculateMinMax();

                //back the camera up
                GL.Translate(0, 0, -maxFieldDistance * zoomGain);

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

                //draw points
                double elevColor, bas;
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
                        elevColor /= (deltaElevation * 2);
                        elevColor += 0.5;
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
                100.0f, 1000.0f);
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
            deltaElevation = maxElevation - minElevation;

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

                lblMinElev.Text = minElevation.ToString("N2");
                lblMaxElev.Text = maxElevation.ToString("N2");
                lblDeltaElev.Text = (deltaElevation).ToString("N2");
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
                        var form = new FormTimedMessage(2000, "Elevation File is Corrupt", "This is bad");
                        form.Show();
                        mf.WriteErrorLog("Load Elevation Points" + e.ToString());
                    }


                }
                if (elevRecPts.Count < 10)
                {
                    var form2 = new FormTimedMessage(2000, "Elevation File is Empty", "Nothing to Generate Terrain From");
                    form2.Show();
                    Close();
                    return false;
                }
                else return true;
            }
            else
            {
                var form = new FormTimedMessage(2000, "Elevation File is Missing", "Going to exit back");
                form.Show();
                Close();
                return false;
            }
        }



        /// <summary>
        /// Convert HSV to RGB
        /// h is from 0-360
        /// s,v values are 0-1
        /// r,g,b values are 0-255
        /// Based upon http://ilab.usc.edu/wiki/index.php/HSV_And_H2SV_Color_Space#HSV_Transformation_C_.2F_C.2B.2B_Code_2
        /// </summary>
        void HsvToRgb(double h, double S, double V, out int r, out int g, out int b)
        {
            // ######################################################################
            // T. Nathan Mundhenk
            // mundhenk@usc.edu
            // C/C++ Macro HSV to RGB

            double H = h;
            while (H < 0) { H += 360; };
            while (H >= 360) { H -= 360; };
            double R, G, B;
            if (V <= 0)
            { R = G = B = 0; }
            else if (S <= 0)
            {
                R = G = B = V;
            }
            else
            {
                double hf = H / 60.0;
                int i = (int)Math.Floor(hf);
                double f = hf - i;
                double pv = V * (1 - S);
                double qv = V * (1 - S * f);
                double tv = V * (1 - S * (1 - f));
                switch (i)
                {

                    // Red is the dominant color

                    case 0:
                        R = V;
                        G = tv;
                        B = pv;
                        break;

                    // Green is the dominant color

                    case 1:
                        R = qv;
                        G = V;
                        B = pv;
                        break;
                    case 2:
                        R = pv;
                        G = V;
                        B = tv;
                        break;

                    // Blue is the dominant color

                    case 3:
                        R = pv;
                        G = qv;
                        B = V;
                        break;
                    case 4:
                        R = tv;
                        G = pv;
                        B = V;
                        break;

                    // Red is the dominant color

                    case 5:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // Just in case we overshoot on our math by a little, we put these here. Since its a switch it won't slow us down at all to put these here.

                    case 6:
                        R = V;
                        G = tv;
                        B = pv;
                        break;
                    case -1:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // The color is not defined, we should throw an error.

                    default:
                        //LFATAL("i Value error in Pixel conversion, Value is %d", i);
                        R = G = B = V; // Just pretend its black/white
                        break;
                }
            }
            r = Clamp((int)(R * 255.0));
            g = Clamp((int)(G * 255.0));
            b = Clamp((int)(B * 255.0));
        }

        /// <summary>
        /// Clamp a value to 0-255
        /// </summary>
        int Clamp(int i)
        {
            if (i < 0) return 0;
            if (i > 255) return 255;
            return i;
        }

//        And here's how you'd use it:

//int r, g, b;
//        HsvToRgb(110, 1, 1, out r, out g, out b);




    }
}
