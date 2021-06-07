using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormTouchPick : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf = null;

        private double maxFieldX, maxFieldY, minFieldX, minFieldY, fieldCenterX, fieldCenterY, maxFieldDistance;
        private Point fixPt;

        public double low = 0, high = 1;

        //list of coordinates of boundary line
        //public List<vec2> bndLine = new List<vec2>();
        //public List<List<vec2>> bndArr = new List<List<vec2>>();

        public vec3 pint = new vec3(0.0, 1.0, 0.0);

        public FormTouchPick(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();
            //lblPick.Text = gStr.gsSelectALine;
            //nudDistance.Controls[0].Enabled = false;
        }

        private void TouchPick_Load(object sender, EventArgs e)
        {
            string[] dirs = Directory.GetDirectories(mf.fieldsDirectory);

            foreach (string dir in dirs)
            {
                string fieldDirectory = Path.GetFileName(dir);
                string filename = dir + "\\Field.txt";
                string line;

                //make sure directory has a field.txt in it
                if (File.Exists(filename))
                {
                    using (StreamReader reader = new StreamReader(filename))
                    {
                        try
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                line = reader.ReadLine();
                            }

                            //start positions
                            if (!reader.EndOfStream)
                            {
                                line = reader.ReadLine();
                                string[] offs = line.Split(',');

                                mf.bnd.bndArr.Add(new CBoundaryLines());
                                mf.turn.turnArr.Add(new CTurnLines());
                            }
                        }
                        catch (Exception)
                        {
                            FormTimedMessage form = new FormTimedMessage(2000, gStr.gsFieldFileIsCorrupt, gStr.gsChooseADifferentField);
                        }
                    }
                }
            }

            //int cnt = mf.bnd.bndArr[0].bndLine.Count;
            //arr = new vec3[cnt * 2];

            //for (int i = 0; i < cnt; i++)
            //{
            //    arr[i].easting = mf.bnd.bndArr[0].bndLine[i].easting;
            //    arr[i].northing = mf.bnd.bndArr[0].bndLine[i].northing;
            //    arr[i].heading = mf.bnd.bndArr[0].bndLine[i].northing;
            //}

        }

        private void oglSelf_MouseDown(object sender, MouseEventArgs e)
        {
            btnCancelTouch.Enabled = true;

            Point pt = oglSelf.PointToClient(Cursor.Position);

            //Convert to Origin in the center of window, 800 pixels
            fixPt.X = pt.X - 350;
            fixPt.Y = (700 - pt.Y - 350);
            vec3 plotPt = new vec3
            {
                //convert screen coordinates to field coordinates
                easting = fixPt.X * maxFieldDistance / 632.0,
                northing = fixPt.Y * maxFieldDistance / 632.0,
                heading = 0
            };

            plotPt.easting += fieldCenterX;
            plotPt.northing += fieldCenterY;

            pint.easting = plotPt.easting;
            pint.northing = plotPt.northing;

        }


        private void oglSelf_Paint(object sender, PaintEventArgs e)
        {
            oglSelf.MakeCurrent();

            GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();                  // Reset The View

            CalculateMinMax();

            //back the camera up
            GL.Translate(0, 0, -maxFieldDistance);

            //translate to that spot in the world
            GL.Translate(-fieldCenterX, -fieldCenterY, 0);

            GL.Color3(1, 1, 1);

            //draw all the boundaries
            mf.bnd.DrawBoundaryLines();

            GL.Flush();
            oglSelf.SwapBuffers();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            oglSelf.Refresh();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            Close();
        }

        private void oglSelf_Resize(object sender, EventArgs e)
        {
            oglSelf.MakeCurrent();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            //58 degrees view
            Matrix4 mat = Matrix4.CreatePerspectiveFieldOfView(1.01f, 1.0f, 1.0f, 20000);
            GL.LoadMatrix(ref mat);

            GL.MatrixMode(MatrixMode.Modelview);
        }

        private void oglSelf_Load(object sender, EventArgs e)
        {
            oglSelf.MakeCurrent();
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
            GL.ClearColor(0.23122f, 0.2318f, 0.2315f, 1.0f);
        }

        //determine mins maxs of patches and whole field.
        private void CalculateMinMax()
        {
            minFieldX = 9999999; minFieldY = 9999999;
            maxFieldX = -9999999; maxFieldY = -9999999;

            //draw patches j= # of sections
            for (int j = 0; j < mf.tool.numSuperSection; j++)
            {
                //every time the section turns off and on is a new patch
                int patchCount = mf.section[j].patchList.Count;

                if (patchCount > 0)
                {
                    //for every new chunk of patch
                    foreach (List<vec3> triList in mf.section[j].patchList)
                    {
                        int count2 = triList.Count;
                        for (int i = 0; i < count2; i += 3)
                        {
                            double x = triList[i].easting;
                            double y = triList[i].northing;

                            //also tally the max/min of field x and z
                            if (minFieldX > x) minFieldX = x;
                            if (maxFieldX < x) maxFieldX = x;
                            if (minFieldY > y) minFieldY = y;
                            if (maxFieldY < y) maxFieldY = y;
                        }
                    }
                }

                //min max of the boundary
                if (mf.bnd.bndArr.Count > 0)
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
                    //the largest distancew across field
                    double dist = Math.Abs(minFieldX - maxFieldX);
                    double dist2 = Math.Abs(minFieldY - maxFieldY);

                    if (dist > dist2) maxFieldDistance = dist;
                    else maxFieldDistance = dist2;

                    if (maxFieldDistance < 100) maxFieldDistance = 100;
                    if (maxFieldDistance > 19900) maxFieldDistance = 19900;
                    //lblMax.Text = ((int)maxFieldDistance).ToString();

                    fieldCenterX = (maxFieldX + minFieldX) / 2.0;
                    fieldCenterY = (maxFieldY + minFieldY) / 2.0;
                }

                //if (isMetric)
                //{
                //    lblFieldWidthEastWest.Text = Math.Abs((maxFieldX - minFieldX)).ToString("N0") + " m";
                //    lblFieldWidthNorthSouth.Text = Math.Abs((maxFieldY - minFieldY)).ToString("N0") + " m";
                //}
                //else
                //{
                //    lblFieldWidthEastWest.Text = Math.Abs((maxFieldX - minFieldX) * glm.m2ft).ToString("N0") + " ft";
                //    lblFieldWidthNorthSouth.Text = Math.Abs((maxFieldY - minFieldY) * glm.m2ft).ToString("N0") + " ft";
                //}
            }
        }
    }
}