
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpGL;
using System.IO.Ports;
using System.IO;
using System.Diagnostics;
using System.Media;
using SharpGL.SceneGraph.Assets;


namespace AgOpenGPS
{
    public partial class FormGPS
    {
 
        #region OpenGL //-------------------------------------------------------------------

        //extracted Near, Far, Right, Left clipping planes of frustum
        double[] frustum = new double[24];

        int triDrawn = 0;

        /// Handles the OpenGLDraw event of the openGLControl control.
        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //start the watch and time till it gets back here
            sw.Start();

            //if there is new data go update everything first.
            UpdateFixPosition();

            //Update the port counter
            recvCounter++;

            //Determine if sections want to be on or off
            ProcessSectionOnOffRequests();

            //send the byte out to section relays
            SectionControlOutToArduino();


            //  Clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            
            //camera does translations and rotations
            camera.SetWorldCam(gl, pivotAxleEasting, fixPosY, pivotAxleNorthing, fixHeadingCam);

            CalcFrustum(gl);


            //turn on blend for paths
            gl.Enable(OpenGL.GL_BLEND);
            gl.Disable(OpenGL.GL_DEPTH_TEST);

            //section patch color
            gl.Color(0.85f, 0.85f, 0.0f, 0.6f);
            if (isDrawPolygons) gl.PolygonMode(OpenGL.GL_FRONT, OpenGL.GL_LINE);
 
            triDrawn = 0;

            //draw patches of sections
            for (int j = 0; j < vehicle.numberOfSections; j++)
            {
                //every time the section turns off and on is a new patch
                int patchCount = section[j].patchList.Count();

                bool isDraw;

                if (patchCount > 0)
                {
                    //for every new chunk of patch
                    foreach (var triList in section[j].patchList)
                    {
                        isDraw = false;
                        int count2 = triList.Count();
                        for (int i = 0; i < count2; i+=4)
                        {
                            //determine if point is in frustum or not
                            if (frustum[0] * triList[i].x + frustum[2] * triList[i].z + frustum[3] <= 0)
                                continue;//right
                            if (frustum[4] * triList[i].x + frustum[6] * triList[i].z + frustum[7] <= 0)
                                continue;//left
                           if (frustum[16] * triList[i].x + frustum[18] * triList[i].z + frustum[19] <= 0)
                                continue;//bottom
                            if (frustum[20] * triList[i].x + frustum[22] * triList[i].z + frustum[23] <= 0)
                                continue;//top
                            if (frustum[8] * triList[i].x + frustum[10] * triList[i].z + frustum[11] <= 0)
                                continue;//far
                            if (frustum[12] * triList[i].x + frustum[14] * triList[i].z + frustum[15] <= 0)
                                continue;//near
 
                            //point is in frustum so draw the entire patch
                            isDraw = true;
                            break;

                        }

                        if (isDraw)
                        {
                            //draw the triangle strip in each triangle strip
                            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
                            count2 = triList.Count();
                            for (int i = 0; i < count2; i++)
                            {
                                gl.Vertex(triList[i].x, 0, triList[i].z);
                                triDrawn++;
                            }
                            gl.End();
                        }
                    }
                }
            }

            gl.PolygonMode(OpenGL.GL_FRONT, OpenGL.GL_FILL);

            gl.Color(1,1,1);

            // draw the current and reference AB Lines
            if (ABLine.isABLineSet | ABLine.isABLineBeingSet) ABLine.DrawABLines();

            //Draw vehicle track
            if (isDrawVehicleTrack)
            {
                //GPS Antenna
                gl.Color(0.9f, 0.45f, 0.9f, 0.6f);
                gl.Begin(OpenGL.GL_LINE_STRIP);//for every point in pointData
                foreach (var triList in pointAntenna) gl.Vertex(triList.easting, 0, triList.northing);
                gl.End();

                ////Pivot Axle
                //gl.Color(0.45f, 0.9f, 0.9f, 0.6f);
                //gl.Begin(OpenGL.GL_LINE_STRIP);//for every point in pointData
                //foreach (var triList2 in pointPivot) gl.Vertex(triList2.easting, 0, triList2.northing);
                //gl.End();

                ////tool
                //gl.Color(0.9f, 0.1f, 0.25f, 0.6f);
                //gl.Begin(OpenGL.GL_LINE_STRIP);//for every point in pointData
                //foreach (var triList4 in pointTool) gl.Vertex(triList4.easting, 0, triList4.northing);
                //gl.End();
            }


            gl.DrawText(10, 15, 1, 0.8f, 0, "Verdana", 16, " FPS " + Convert.ToString(FPS));
            gl.DrawText(10, 45, 1, 0.8f, 0, "Verdana", 16, " Triangles " + Convert.ToString(triDrawn));
            //gl.DrawText(10, 60, 1, 0.8f, 1, "Verdana", 16, " zoomValue " + Convert.ToString(zoomValue));
            //gl.DrawText(10, 75, 1, 0.8f, 1, "Verdana", 16, " gridZoom " + Convert.ToString(gridZoom));

            //draw the tractor/implement
            vehicle.DrawVehicle();

            //Back to normal
            gl.Color(1.0f, 1.0f, 1.0f);
            gl.Disable(OpenGL.GL_BLEND);
            gl.Enable(OpenGL.GL_DEPTH_TEST);

            //// 2D Ortho --------------------------
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.PushMatrix();
            gl.LoadIdentity();

            //negative and positive on width, 0 at top to bottom ortho view
            gl.Ortho2D(-(double)Width / 2, (double)Width / 2, (double)Height, 0);

            //  Create the appropriate modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.PushMatrix();
            gl.LoadIdentity();

            //draw the background when in 3D
            if (isIn3D)
            {
                //the background
                double winLeftPos = -(double)Width / 2;
                double winRightPos = -winLeftPos;

                gl.Enable(OpenGL.GL_TEXTURE_2D);
                gl.BindTexture(OpenGL.GL_TEXTURE_2D, texture[1]);		// Select Our Texture
                gl.Begin(OpenGL.GL_TRIANGLE_STRIP);				// Build Quad From A Triangle Strip
                gl.TexCoord(0, 0); gl.Vertex(winRightPos, 0.0); // Top Right
                gl.TexCoord(1, 0); gl.Vertex(winLeftPos, 0.0); // Top Left
                gl.TexCoord(0, 1); gl.Vertex(winRightPos, 0.15 * (double)Height); // Bottom Right
                gl.TexCoord(1, 1); gl.Vertex(winLeftPos, 0.15 * (double)Height); // Bottom Left
                gl.End();						// Done Building Triangle Strip
            }
            
            //disable, straight color
            gl.Disable(OpenGL.GL_TEXTURE_2D);
 
            //LightBar if AB Line is set
            if (ABLine.isABLineSet | ABLine.isABLineBeingSet)
            {
                txtDistanceOffABLine.Visible = true;
                ABLine.DrawLightBar(openGLControl.Width, openGLControl.Height);
                txtDistanceOffABLine.Text = " "+Convert.ToString(Math.Abs(ABLine.distanceFromCurrentLine))+" ";
                if (Math.Abs(ABLine.distanceFromCurrentLine) > 15.0) txtDistanceOffABLine.ForeColor = Color.Yellow;
                else txtDistanceOffABLine.ForeColor = Color.LightGreen;
            }

            //AB line is not set
            else txtDistanceOffABLine.Visible = false;

            //finish openGL commands
            gl.Flush();

            //  Pop the modelview.
            gl.PopMatrix();

            //  back to the projection and pop it, then back to the model view.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.PopMatrix();
            gl.MatrixMode(OpenGL.GL_MODELVIEW);

            //reset point size
            gl.PointSize(1.0f);

            gl.Flush();

            //draw the section control window off screen buffer
            openGLControlBack.DoRender();
        }

        /// Handles the OpenGLInitialized event of the openGLControl control.
        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //Load all the textures
            LoadGLTextures();

            //  Set the clear color.
            gl.ClearColor(0.5f, 0.5f, 0.5f, 1.0f);

            // Set The Blending Function For Translucency
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);

            //gl.Disable(OpenGL.GL_CULL_FACE);
            gl.CullFace(OpenGL.GL_BACK);
            
            //set the camera to right distance
            SetZoom();
        }

        /// Handles the Resized event of the openGLControl control.
        private void openGLControl_Resized(object sender, EventArgs e)
        {
            //  TODO: Set the projection matrix here.

            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  Load the identity.
            gl.LoadIdentity();

            //  Create a perspective transformation.
            gl.Perspective(45.0f, (double)openGLControl.Width / (double)openGLControl.Height, 1, -3 * camera.camSetDistance);

            //  Set the modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        #endregion

        private void CalcFrustum(OpenGL gl)
        {
            float[] proj = new float[16];							// For Grabbing The PROJECTION Matrix
            float[] modl = new float[16];							// For Grabbing The MODELVIEW Matrix
            float[] clip = new float[16];							// Result Of Concatenating PROJECTION and MODELVIEW
            float t;											    // Temporary Work Variable

            gl.GetFloat(OpenGL.GL_PROJECTION_MATRIX, proj);		// Grab The Current PROJECTION Matrix
            gl.GetFloat(OpenGL.GL_MODELVIEW_MATRIX, modl);		// Grab The Current MODELVIEW Matrix

            // Concatenate (Multiply) The Two Matricies
            clip[0] = modl[0] * proj[0] + modl[1] * proj[4] + modl[2] * proj[8] + modl[3] * proj[12];
            clip[1] = modl[0] * proj[1] + modl[1] * proj[5] + modl[2] * proj[9] + modl[3] * proj[13];
            clip[2] = modl[0] * proj[2] + modl[1] * proj[6] + modl[2] * proj[10] + modl[3] * proj[14];
            clip[3] = modl[0] * proj[3] + modl[1] * proj[7] + modl[2] * proj[11] + modl[3] * proj[15];

            clip[4] = modl[4] * proj[0] + modl[5] * proj[4] + modl[6] * proj[8] + modl[7] * proj[12];
            clip[5] = modl[4] * proj[1] + modl[5] * proj[5] + modl[6] * proj[9] + modl[7] * proj[13];
            clip[6] = modl[4] * proj[2] + modl[5] * proj[6] + modl[6] * proj[10] + modl[7] * proj[14];
            clip[7] = modl[4] * proj[3] + modl[5] * proj[7] + modl[6] * proj[11] + modl[7] * proj[15];

            clip[8] = modl[8] * proj[0] + modl[9] * proj[4] + modl[10] * proj[8] + modl[11] * proj[12];
            clip[9] = modl[8] * proj[1] + modl[9] * proj[5] + modl[10] * proj[9] + modl[11] * proj[13];
            clip[10] = modl[8] * proj[2] + modl[9] * proj[6] + modl[10] * proj[10] + modl[11] * proj[14];
            clip[11] = modl[8] * proj[3] + modl[9] * proj[7] + modl[10] * proj[11] + modl[11] * proj[15];

            clip[12] = modl[12] * proj[0] + modl[13] * proj[4] + modl[14] * proj[8] + modl[15] * proj[12];
            clip[13] = modl[12] * proj[1] + modl[13] * proj[5] + modl[14] * proj[9] + modl[15] * proj[13];
            clip[14] = modl[12] * proj[2] + modl[13] * proj[6] + modl[14] * proj[10] + modl[15] * proj[14];
            clip[15] = modl[12] * proj[3] + modl[13] * proj[7] + modl[14] * proj[11] + modl[15] * proj[15];


            // Extract the RIGHT clipping plane
            frustum[0] = clip[3] - clip[0];
            frustum[1] = clip[7] - clip[4];
            frustum[2] = clip[11] - clip[8];
            frustum[3] = clip[15] - clip[12];

            // Normalize it
            t = (float)Math.Sqrt(frustum[0] * frustum[0] + frustum[1] * frustum[1] + frustum[2] * frustum[2]);
            frustum[0] /= t;
            frustum[1] /= t;
            frustum[2] /= t;
            frustum[3] /= t;


            // Extract the LEFT clipping plane
            frustum[4] = clip[3] + clip[0];
            frustum[5] = clip[7] + clip[4];
            frustum[6] = clip[11] + clip[8];
            frustum[7] = clip[15] + clip[12];

            // Normalize it
            t = (float)Math.Sqrt(frustum[4] * frustum[4] + frustum[5] * frustum[5] + frustum[6] * frustum[6]);
            frustum[4] /= t;
            frustum[5] /= t;
            frustum[6] /= t;
            frustum[7] /= t;

            // Extract the FAR clipping plane
            frustum[8] = clip[3] - clip[2];
            frustum[9] = clip[7] - clip[6];
            frustum[10] = clip[11] - clip[10];
            frustum[11] = clip[15] - clip[14];

            // Normalize it
            t = (float)Math.Sqrt(frustum[8] * frustum[8] + frustum[9] * frustum[9] + frustum[10] * frustum[10]);
            frustum[8] /= t;
            frustum[9] /= t;
            frustum[10] /= t;
            frustum[11] /= t;

            // Extract the NEAR clipping plane.  This is last on purpose (see pointinfrustum() for reason)
            frustum[12] = clip[3] + clip[2];
            frustum[13] = clip[7] + clip[6];
            frustum[14] = clip[11] + clip[10];
            frustum[15] = clip[15] + clip[14];

            // Normalize it
            t = (float)Math.Sqrt(frustum[12] * frustum[12] + frustum[13] * frustum[13] + frustum[14] * frustum[14]);
            frustum[12] /= t;
            frustum[13] /= t;
            frustum[14] /= t;
            frustum[15] /= t;

            // Extract the BOTTOM clipping plane
            frustum[16] = clip[3] + clip[1];
            frustum[17] = clip[7] + clip[5];
            frustum[18] = clip[11] + clip[9];
            frustum[19] = clip[15] + clip[13];

            // Normalize it
            t = (float)Math.Sqrt(frustum[16] * frustum[16] + frustum[17] * frustum[17] + frustum[18] * frustum[18]);
            frustum[16] /= t;
            frustum[17] /= t;
            frustum[18] /= t;
            frustum[19] /= t;


            // Extract the TOP clipping plane
            frustum[20] = clip[3] - clip[1];
            frustum[21] = clip[7] - clip[5];
            frustum[22] = clip[11] - clip[9];
            frustum[23] = clip[15] - clip[13];

            // Normalize it
            t = (float)Math.Sqrt(frustum[20] * frustum[20] + frustum[21] * frustum[21] + frustum[22] * frustum[22]);
            frustum[20] /= t;
            frustum[21] /= t;
            frustum[22] /= t;
            frustum[23] /= t;

            //Draw the world grid based on camera position
            gl.Disable(OpenGL.GL_DEPTH_TEST);
            gl.Disable(OpenGL.GL_TEXTURE_2D);
            worldGrid.DrawWorldGrid(gridZoom);
        }

        #region SectionControl // ----------------------------------------------------------------

        //data buffer for pixels read from off screen buffer
        byte[] pixelsTop = new byte[401];
        byte[] pixelsMiddle = new byte[401];
        byte[] pixelsBottom = new byte[401];
        byte[] pixelsAtTool = new byte[401];

        //main openGL draw function
        private void openGLControlBack_OpenGLDraw(object sender, RenderEventArgs args)
        {
            OpenGL gl = openGLControlBack.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);	// Clear The Screen And The Depth Buffer
            gl.LoadIdentity();					// Reset The View

            //back the camera up
            gl.Translate(0, 0, -384);

            //flip the world over so positive z aka north goes into screen
            gl.Rotate(180, 0, 0, 1);

            //rotate the camera down to look at fix
            gl.Rotate(-90, 1, 0, 0);

            //rotate camera so heading matched fix heading in the world
            gl.Rotate(-glm.degrees(fixHeadingSection) + 180, 0, 1, 0);

            //translate to that spot in the world 
            gl.Translate(-toolEasting, -fixPosY, -toolNorthing);

            //patch color
            gl.Color(0.0f, 1.0f, 0.0f);

            //calculate the frustum for the section control window
            CalcFrustum(gl);

            //to draw or not the triangle patch
            bool isDraw;

            //draw patches j= # of sections
            for (int j = 0; j < vehicle.numberOfSections; j++)
            {
                //every time the section turns off and on is a new patch
                int patchCount = section[j].patchList.Count();

                if (patchCount > 0)
                {
                    //for every new chunk of patch
                    foreach (var triList in section[j].patchList)
                    {
                        isDraw = false;
                        int count2 = triList.Count();
                        for (int i = 0; i < count2; i+=4)
                        {
                            //determine if point is in frustum or not
                            if (frustum[0] * triList[i].x + frustum[2] * triList[i].z + frustum[3] <= 0)
                                continue;//right
                            if (frustum[4] * triList[i].x + frustum[6] * triList[i].z + frustum[7] <= 0)
                                continue;//left
                           if (frustum[16] * triList[i].x + frustum[18] * triList[i].z + frustum[19] <= 0)
                                continue;//bottom
                            if (frustum[20] * triList[i].x + frustum[22] * triList[i].z + frustum[23] <= 0)
                                continue;//top

                            //near and far not required since its always 2D looking down
                            //if (frustum[8] * triList[i].x + frustum[10] * triList[i].z + frustum[11] <= 0)
                            //    continue;//far
                            //if (frustum[12] * triList[i].x + frustum[14] * triList[i].z + frustum[15] <= 0)
                            //    continue;//near
 
                            //point is in frustum so draw the entire patch
                            isDraw = true;
                            break;
                        }

                        if (isDraw)
                        {
                            //draw the triangle strip in each triangle strip
                            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
                            for (int i = 0; i < count2; i++) gl.Vertex(triList[i].x, 0, triList[i].z);
                            gl.End();
                        }
                    }
                }
            }

      
            //Read the pixels ahead of tool a section at a time. Each section can have its own lookahead manipulated. 
            for (int j = 0; j < vehicle.numberOfSections; j++)
            {
                // *** Torriem
 
                //here is where you can manipulate individual section times
                //delete this if setting externally outside this loop
                section[j].sectionLookAhead = (pn.speed * vehicle.toolLookAhead * 2.0); //how far ahead ie up the screen  
                
                //*** Torriem

                //keep in as safety
                if (section[j].sectionLookAhead > 80) section[j].sectionLookAhead = 80;

                //10 pixels to a meter or 1 pixel is 10cm - simple math
                //find the left side pixel position
                int rpXPosition = 200 + (int)(section[j].positionLeft * 10);

                //find the right side pixel position
                int rpWidth = (int)(section[j].sectionWidth * 10);

                //scan 3 different spots, 1/3, 2/3 and full lookahead positions
                gl.ReadPixels(rpXPosition, 200 + (int)(section[j].sectionLookAhead * 0.6), rpWidth, 1,
                                    OpenGL.GL_GREEN, OpenGL.GL_UNSIGNED_BYTE, pixelsBottom);
                gl.ReadPixels(rpXPosition, 200 + (int)(section[j].sectionLookAhead * 0.8), rpWidth, 1,
                                    OpenGL.GL_GREEN, OpenGL.GL_UNSIGNED_BYTE, pixelsMiddle);
                gl.ReadPixels(rpXPosition, 200 + (int)section[j].sectionLookAhead, rpWidth, 1,
                                    OpenGL.GL_GREEN, OpenGL.GL_UNSIGNED_BYTE, pixelsTop);

                //scan just ahead of the tool otherwise its too fussy and keep turning on section
                gl.ReadPixels(rpXPosition, 202, rpWidth, 1,
                                    OpenGL.GL_GREEN, OpenGL.GL_UNSIGNED_BYTE, pixelsAtTool);

                //used in this loop only, reset to false for next iteration
                bool isSectionRequiredOn = false;

                ////OR them together, if nowhere applied, send OnRequest, if its all green send an offRequest
                for (int a = 0; a < rpWidth; a++)
                {
                    if (pixelsMiddle[a] == 0 | pixelsTop[a] == 0 | pixelsAtTool[a] == 0 | pixelsBottom[a] == 0)
                    {
                        isSectionRequiredOn = true;
                        break;                        
                    }
                }

                //if (isSectionRequiredOn && isMasterSectionOn)
                if (isSectionRequiredOn && section[j].isAllowedOn)
                {
                    //global request to turn on section
                    section[j].sectionOnRequest = true;
                    section[j].sectionOffRequest = false;
                }

                else if (!isSectionRequiredOn)
                {
                    //global request to turn off section
                    section[j].sectionOffRequest = true;
                    section[j].sectionOnRequest = false;
                }

                // Manual on, force the section On and exit loop
                if (section[j].manBtnState == manBtn.On)
                {
                    section[j].sectionOnRequest = true;
                    section[j].sectionOffRequest = false;
                    continue;
                }

                if (section[j].manBtnState == manBtn.Off)
                {
                    section[j].sectionOnRequest = false;
                    section[j].sectionOffRequest = true;
                }


            }
            gl.Flush();

            //stop the timer and calc how long it took to do calcs and derive FPS
            sw.Stop();
            frameTime = (sw.Elapsed.TotalMilliseconds/1000);
            sw.Reset();

            frames += frameTime;
            if ( frameCounter++ > 10)
            {
                FPS =  frames * 0.1;
                FPS = (int)(1 / FPS);
                frames = 0;
                frameCounter = 0;
            }

            //if a mninute has elapsed save the field in case of crash to be able to resume
            if (saveCounter++ > 600)
            {
                if (isJobStarted) FileSaveField("Resume");
                saveCounter = 1;
            }
        }

        double frames, FPS = 0;
        //Resize is called upn window creation
        private void openGLControlBack_Resized(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gls = openGLControlBack.OpenGL;

            gls.MatrixMode(OpenGL.GL_PROJECTION);

            //  Load the identity.
            gls.LoadIdentity();

            //  Create a perspective transformation.
            gls.Perspective(6.0f, 1, 1, 6000);

            //  Set the modelview matrix.
            gls.MatrixMode(OpenGL.GL_MODELVIEW);

        }

        private void openGLControlBack_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL gls = openGLControlBack.OpenGL;

            gls.Disable(OpenGL.GL_CULL_FACE);
            //gl.CullFace(OpenGL.GL_BACK);

            gls.PixelStore(OpenGL.GL_PACK_ALIGNMENT, 1);

        }
 

        #endregion


    }
}
