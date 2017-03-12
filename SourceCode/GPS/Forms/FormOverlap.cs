using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpGL;
using System.IO;


namespace AgOpenGPS
{
    public partial class FormOverlap : Form
    {
        //access to the main GPS form and all its variables
        private FormGPS mf = null;

        int curPatch = 0;
        int totalPatches = 0;
        int progressPatches = 0;

        int pz = 0; //patch compare
        double aveX = 0, aveZ = 0, area = 0;
        double x, z, dist = 0, maxDist = 0;

        bool isOverlapRender = false;
        bool isCalculating = false;

        //buffers for green values read
        byte[] grnBuff = new byte[250000];
        int basePix = 0;
        int overlapPix = 0;

        //calculate patch sizes to zoom accordingly
        double maxX, maxZ, minX, minZ;

        //list of patch data individual triangles
        public List<vec2> triangleList = new List<vec2>();

        //list of the list of patch data individual triangles for that entire section activity
        public List<List<vec2>> patchList = new List<List<vec2>>();


        public FormOverlap(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();
        }

        //copy all the sections and patches into 1 list
        private void FormOverlap_Load(object sender, EventArgs e)
        {
            vec2 point = new vec2();

            double area = mf.totalSquareMeters * 0.001;
            if (!mf.isMetric) area = mf.totalSquareMeters * 0.00024710499815078974633856493327535;
 
            for (int j = 0; j < mf.vehicle.numOfSections; j++)
            {
                //every time the section turns off and on is a new patch
                int patchC = mf.section[j].patchList.Count;
                if (patchC > 0)
                {
                    for (int k = 0; k < patchC; k++)
                    {
                        //calculate the center of the patch
                        int cnt2 = mf.section[j].patchList[k].Count;
                        triangleList = new List<vec2>();
                        patchList.Add(triangleList);

                        for (int t = 0; t < cnt2; t++)
                        {
                            point.x = mf.section[j].patchList[k][t].x;
                            point.z = mf.section[j].patchList[k][t].z;
                            triangleList.Add(point);
                        }                        
                    }                    
                }
            }
        } 

        //do the overlap calcs
        private void btnStart_Click(object sender, EventArgs e)
        {
            // Calculate the largest patch and set the zoom accordingly
            isCalculating = true;
            totalPatches = 0;
            progressPatches = 0;

            int paCnt = patchList.Count;
            if (paCnt > 0)
            {
                for (int k = 0; k < paCnt; k++)
                {
                    //calculate the center of the patch
                    int cnt2 = patchList[k].Count;

                    //calulate the largest patch
                    minX = 99999999999; minZ = 99999999999;
                    maxX = -99999999999; maxZ = -99999999999;

                    for (int t = 0; t < cnt2; t++)
                    {
                        x = patchList[k][t].x;
                        z = patchList[k][t].z;

                        if (minX > x) minX = x;
                        if (maxX < x) maxX = x;
                        if (minZ > z) minZ = z;
                        if (maxZ < z) maxZ = z;
                    }

                    totalPatches++;

                    dist = (minX - maxX) * (minX - maxX) +
                            (minZ - maxZ) * (minZ - maxZ);

                    if (maxDist < dist) maxDist = dist;
                }
                    //for every new chunk of patch
            }
            
            maxDist = Math.Sqrt(maxDist); //how far to move on the Z axis

            //flags for which type of rendering
            isOverlapRender = false;

            //reset the pixel counters
            basePix = 0;
            overlapPix = 0;
 
            for (curPatch = 0; curPatch < paCnt; curPatch++)
            {
                //calculate the center of the patch
                int cnt2 = patchList[curPatch].Count;
                aveX = 0; aveZ = 0;

                for (int t = 0; t < cnt2; t++)
                {
                    aveX += patchList[curPatch][t].x;
                    aveZ += patchList[curPatch][t].z;
                }

                aveX /= (double)cnt2;
                aveZ /= (double)cnt2;

                //start the counting of pixels of base patches
                progressPatches++;
                isOverlapRender = false;
                openGLWin.DoRender();
                //System.Threading.Thread.Sleep(1500);

                int patchCount = patchList.Count;
                for (pz = 0; pz < patchCount; pz++)
                {
                    if (curPatch == pz) { }
                    else
                    {
                        //start the comparing for overlap
                        isOverlapRender = true;                                
                        openGLWin.DoRender();
                        //System.Threading.Thread.Sleep(1000);
                    }
                }                             
            }//end of overlap render

            isCalculating = false;
            overlapPix /= 2;

            tboxBase.Text = basePix.ToString();
            tboxOverlap.Text = overlapPix.ToString();

            double percentOverlap = (double)overlapPix / (double)basePix;
            tboxPercentOverlap.Text = Math.Round((percentOverlap * 100), 2).ToString();

            if (mf.isMetric) area = mf.totalSquareMeters*0.0001;
            else area = mf.totalSquareMeters * 0.00024710499815078974633856493327535;

            tboxRecordedArea.Text = Math.Round(area,4).ToString();
            tboxActualArea.Text = Math.Round(((1.0 - percentOverlap) * area), 4).ToString();
            openGLWin.DoRender();
        
         }


        int cnt = 0;
        private void openGLWin_OpenGLDraw(object sender, RenderEventArgs args)
        {
            cnt++;

            OpenGL gl = openGLWin.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);	// Clear The Screen And The Depth Buffer
            gl.LoadIdentity();					// Reset The View

            //back the camera up
            gl.Translate(0, 0, -maxDist*3);

            //translate to that spot in the world 
            gl.Translate(-aveX, -aveZ, 0);

            if (isCalculating)
            {
                if (isOverlapRender)
                {
                    //section patch color
                    gl.Color(0.0f, 0.5f, 0.00f, 0.5f);

                    //draw the base patch
                    gl.Disable(OpenGL.GL_BLEND);
                    int cnt2 = patchList[curPatch].Count;

                    gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
                    for (int t = 0; t < cnt2; t++)
                        gl.Vertex(patchList[curPatch][t].x, patchList[curPatch][t].z, 0);
                    gl.End();

                    //change color
                    gl.Color(0.0f, 0.5f, 0.00f, 0.98f);
                    gl.Enable(OpenGL.GL_BLEND);

                    //draw all the compare patch
                    int count2 = patchList[pz].Count;
                    {
                        //draw the triangle strip in ptch
                        gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
                        for (int tz = 0; tz < count2; tz++)
                            gl.Vertex(patchList[pz][tz].x, patchList[pz][tz].z, 0);
                        gl.End();
                    }

                    //flush all commands to screen
                    gl.Flush();

                    gl.ReadPixels(0, 0, 499, 499, OpenGL.GL_GREEN, OpenGL.GL_UNSIGNED_BYTE, grnBuff);

                    //count the overlapped pixels
                    for (int q = 0; q < 250000; q++)
                    {
                        if (grnBuff[q] > 140) overlapPix++;
                    }

                }

                else
                {

                    //section patch color
                    gl.Color(0.0f, 0.5f, 0.00f, 0.5f);
                    gl.Disable(OpenGL.GL_BLEND);

                    //draw the base patch
                    int cnt2 = patchList[curPatch].Count;

                    gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
                    for (int t = 0; t < cnt2; t++)
                        gl.Vertex(patchList[curPatch][t].x, patchList[curPatch][t].z, 0);
                    gl.End();

                    gl.ReadPixels(0, 0, 499, 499, OpenGL.GL_GREEN, OpenGL.GL_UNSIGNED_BYTE, grnBuff);

                    //count the base pixels
                    for (int q = 0; q < 250000; q++)
                    {
                        if (grnBuff[q] > 10) basePix++;
                    }
                }
            gl.DrawText(10, 15, 1,0, 1, "Courier", 18, "Current " + Convert.ToString((progressPatches)));
            gl.DrawText(10, 40, 1,0, 1, "Courier", 18, "  Total " + Convert.ToString(totalPatches));

            }

 
        }

        private void openGLWin_Resized(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = openGLWin.OpenGL;

            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  Load the identity.
            gl.LoadIdentity();

            // change these at your own peril!!!! Very critical
            //  Create a perspective transformation.
            //gl.Perspective(6.0f, 1, 1, 6000);
            gl.Perspective(20.0f, 1, 1, 1000);

            //  Set the modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);


        }

        private void openGLWin_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL gl = openGLWin.OpenGL;

            gl.Disable(OpenGL.GL_DEPTH_TEST);
            gl.Disable(OpenGL.GL_TEXTURE_2D);

            //turn on blend for paths
            gl.Enable(OpenGL.GL_BLEND);

            //Set The Blending Function For Translucency
            //gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE);

            gl.Enable(OpenGL.GL_CULL_FACE);
            gl.CullFace(OpenGL.GL_BACK);

            gl.PixelStore(OpenGL.GL_PACK_ALIGNMENT, 1);
        }



    }
 
}

/*
 * 
 *             ////draw patches j= # of sections
            //for (int j = 0; j < mf.vehicle.numberOfSections; j++)
            //{
            //    //every time the section turns off and on is a new patch
            //    int patchCount = mf.section[j].patchList.Count;

            //    if (patchCount > 0)
            //    {
            //        //for every new chunk of patch
            //        foreach (var triList in mf.section[j].patchList)
            //        {
            //            int count2 = triList.Count;
            //            {
            //                //draw the triangle strip in each triangle strip
            //                gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
            //                for (int i = 0; i < count2; i++) gl.Vertex(triList[i].x, triList[i].z,0);
            //                gl.End();
            //            }
            //        }
            //    }
            //}


            ////Read the pixels ahead of tool a section at a time. Each section can have its own lookahead manipulated. 
            //for (int j = 0; j < vehicle.numberOfSections; j++)
            //{
            //   //keep in as safety
            //    if (section[j].sectionLookAhead > 190) section[j].sectionLookAhead = 190;

            //    //10 pixels to a meter or 1 pixel is 10cm - simple math
            //    //find the left side pixel position
            //    int rpXPosition = 200 + (int)(section[j].positionLeft * 10);

            //    //find the right side pixel position
            //    int rpWidth = (int)(section[j].sectionWidth * 10);

            //    //scan 3 different spots, 1/3, 2/3 and full lookahead positions
            //    gl.ReadPixels(rpXPosition, 200 + (int)(section[j].sectionLookAhead * 0.6), rpWidth, 1,
            //                        OpenGL.GL_GREEN, OpenGL.GL_UNSIGNED_BYTE, pixelsBottom);
  
       private void openGLWindow_OpenGLDraw(object sender, RenderEventArgs args)
        {
            OpenGL gl = openGLWindow.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);	// Clear The Screen And The Depth Buffer
            gl.LoadIdentity();					// Reset The View

            //back the camera up
            //gl.Translate(0, -40, -40);

            //flip the world over so positive z aka north goes into screen
            //gl.Rotate(180, 0, 0, 1);

            //rotate the camera down to look at fix
            //gl.Rotate(-90, 1, 0, 0);

            //rotate camera so heading matched fix heading in the world
            //gl.Rotate(-glm.degrees(mf.fixHeadingSection) + 180, 0, 1, 0);

            //translate to that spot in the world 
            //gl.Translate(-mf.toolEasting, -mf.fixPosY, -mf.toolNorthing);
            gl.Translate(-1.5f, 0.0f, -7.0f);				// Move Left And Into The Screen
            gl.Rotate(rquad, 0.98f, 0.98f, 0.98f);			// Rotate The Cube On X, Y & Z


            ////draw the hitch
            gl.LineWidth(2);
            gl.Color(0.98f, 0.0f, 0.0f);

            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(2, 0, 0);
            gl.Vertex(-2, 0, 0);
            gl.End();


            ////draw the vehicle Body
            //gl.Color(1.0, 0.5, 0.30);
            //gl.Begin(OpenGL.GL_TRIANGLE_FAN);

            //gl.Vertex(0, 0.0, 0);
            //gl.Vertex(3.8, 0.0, -4);
            //gl.Vertex(0, 0.0, -4 + 5);
            //gl.Color(0.20, 0.0, 1.0);
            //gl.Vertex(-3.8, 0.0, -4);
            //gl.Vertex(3.8, 0.0, -4);

            //gl.End();

            //turn on blend for paths
            //gl.Enable(OpenGL.GL_BLEND);


            gl.Begin(OpenGL.GL_QUADS);					// Start Drawing The Cube

            gl.Color(0.0f, 0.98f, 0.0f);			// Set The Color To Green
            gl.Vertex(0.98f, 0.98f, -0.98f);			// Top Right Of The Quad (Top)
            gl.Vertex(-0.98f, 0.98f, -0.98f);			// Top Left Of The Quad (Top)
            gl.Vertex(-0.98f, 0.98f, 0.98f);			// Bottom Left Of The Quad (Top)
            gl.Vertex(0.98f, 0.98f, 0.98f);			// Bottom Right Of The Quad (Top)


            gl.Color(0.98f, 0.5f, 0.0f);			// Set The Color To Orange
            gl.Vertex(0.98f, -0.98f, 0.98f);			// Top Right Of The Quad (Bottom)
            gl.Vertex(-0.98f, -0.98f, 0.98f);			// Top Left Of The Quad (Bottom)
            gl.Vertex(-0.98f, -0.98f, -0.98f);			// Bottom Left Of The Quad (Bottom)
            gl.Vertex(0.98f, -0.98f, -0.98f);			// Bottom Right Of The Quad (Bottom)

            gl.Color(0.98f, 0.0f, 0.0f);			// Set The Color To Red
            gl.Vertex(0.98f, 0.98f, 0.98f);			// Top Right Of The Quad (Front)
            gl.Vertex(-0.98f, 0.98f, 0.98f);			// Top Left Of The Quad (Front)
            gl.Vertex(-0.98f, -0.98f, 0.98f);			// Bottom Left Of The Quad (Front)
            gl.Vertex(0.98f, -0.98f, 0.98f);			// Bottom Right Of The Quad (Front)

            gl.Color(0.98f, 0.98f, 0.0f);			// Set The Color To Yellow
            gl.Vertex(0.98f, -0.98f, -0.98f);			// Bottom Left Of The Quad (Back)
            gl.Vertex(-0.98f, -0.98f, -0.98f);			// Bottom Right Of The Quad (Back)
            gl.Vertex(-0.98f, 0.98f, -0.98f);			// Top Right Of The Quad (Back)
            gl.Vertex(0.98f, 0.98f, -0.98f);			// Top Left Of The Quad (Back)

            gl.Color(0.0f, 0.0f, 0.98f);			// Set The Color To Blue
            gl.Vertex(-0.98f, 0.98f, 0.98f);			// Top Right Of The Quad (Left)
            gl.Vertex(-0.98f, 0.98f, -0.98f);			// Top Left Of The Quad (Left)
            gl.Vertex(-0.98f, -0.98f, -0.98f);			// Bottom Left Of The Quad (Left)
            gl.Vertex(-0.98f, -0.98f, 0.98f);			// Bottom Right Of The Quad (Left)

            gl.Color(0.98f, 0.0f, 0.98f);			// Set The Color To Violet
            gl.Vertex(0.98f, 0.98f, -0.98f);			// Top Right Of The Quad (Right)
            gl.Vertex(0.98f, 0.98f, 0.98f);			// Top Left Of The Quad (Right)
            gl.Vertex(0.98f, -0.98f, 0.98f);			// Bottom Left Of The Quad (Right)
            gl.Vertex(0.98f, -0.98f, -0.98f);			// Bottom Right Of The Quad (Right)
            gl.End();						// Done Drawing The Q

            rquad += 0.4f;
    

            ////section patch color
            //gl.Color(0.99f, 0.98f, 0.50f, 0.4f);

            ////draw patches j= # of sections
            //for (int j = 0; j < mf.vehicle.numberOfSections; j++)
            //{
            //    //every time the section turns off and on is a new patch
            //    int patchCount = mf.section[j].patchList.Count;

            //    if (patchCount > 0)
            //    {
            //        //for every new chunk of patch
            //        foreach (var triList in mf.section[j].patchList)
            //        {
            //            int count2 = triList.Count;
            //            {
            //                //draw the triangle strip in each triangle strip
            //                gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
            //                for (int i = 0; i < count2; i++) gl.Vertex(triList[i].x, 0, triList[i].z);
            //                gl.End();
            //            }
            //        }
            //    }
            //}


            ////Read the pixels ahead of tool a section at a time. Each section can have its own lookahead manipulated. 
            //for (int j = 0; j < vehicle.numberOfSections; j++)
            //{
            //   //keep in as safety
            //    if (section[j].sectionLookAhead > 190) section[j].sectionLookAhead = 190;

            //    //10 pixels to a meter or 1 pixel is 10cm - simple math
            //    //find the left side pixel position
            //    int rpXPosition = 200 + (int)(section[j].positionLeft * 10);

            //    //find the right side pixel position
            //    int rpWidth = (int)(section[j].sectionWidth * 10);

            //    //scan 3 different spots, 1/3, 2/3 and full lookahead positions
            //    gl.ReadPixels(rpXPosition, 200 + (int)(section[j].sectionLookAhead * 0.6), rpWidth, 1,
            //                        OpenGL.GL_GREEN, OpenGL.GL_UNSIGNED_BYTE, pixelsBottom);
  
        }
        
        private void openGLWindow_Resized(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            //OpenGL gl = openGLWindow.OpenGL;

            //gl.MatrixMode(OpenGL.GL_PROJECTION);

            ////  Load the identity.
            //gl.LoadIdentity();

            //// change these at your own peril!!!! Very critical
            ////  Create a perspective transformation.
            ////gl.Perspective(6.0f, 1, 1, 6000);
            //gl.Perspective(30.0f, 1, 1, 6000);

            ////  Set the modelview matrix.
            //gl.MatrixMode(OpenGL.GL_MODELVIEW);

        }

        private void openGLWindow_OpenGLInitialized(object sender, EventArgs e)
        {
            //OpenGL gl = openGLWindow.OpenGL;

            // Set The Blending Function For Translucency
            //gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);

            //gl.Disable(OpenGL.GL_CULL_FACE);
            //gl.CullFace(OpenGL.GL_BACK);

            //gl.PixelStore(OpenGL.GL_PACK_ALIGNMENT, 1);

        }

        private void FormOverlap_Load(object sender, EventArgs e)
        {

        }


    }
*/