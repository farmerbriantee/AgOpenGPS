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

        private Point fixPt;

        public double low = 0, high = 1;

        public vec3 pint = new vec3(0.0, 1.0, 0.0);

        public FormTouchPick(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();
            //lblPick.Text = gStr.gsSelectALine;
            //nudDistance.Controls[0].Enabled = false;

            mf.CalculateMinMax();
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
                easting = fixPt.X * mf.maxFieldDistance / 632.0,
                northing = fixPt.Y * mf.maxFieldDistance / 632.0,
                heading = 0
            };

            plotPt.easting += mf.fieldCenterX;
            plotPt.northing += mf.fieldCenterY;

            pint.easting = plotPt.easting;
            pint.northing = plotPt.northing;

        }


        private void oglSelf_Paint(object sender, PaintEventArgs e)
        {
            oglSelf.MakeCurrent();

            GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();                  // Reset The View

            //back the camera up
            GL.Translate(0, 0, -mf.maxFieldDistance);

            //translate to that spot in the world
            GL.Translate(-mf.fieldCenterX, -mf.fieldCenterY, 0);

            GL.Color3(1, 1, 1);

            //draw all the boundaries
            mf.bnd.DrawFenceLines();

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
    }
}