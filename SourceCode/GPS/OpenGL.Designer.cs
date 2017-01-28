
using System;
using System.Drawing;
using System.Linq;
using SharpGL;


namespace AgOpenGPS
{
    public partial class FormGPS
    {

        //extracted Near, Far, Right, Left clipping planes of frustum
        double[] frustum = new double[24];

        double fovy = 30;
        double camDistanceFactor = -2;

        //how many culled triangles are drawn
        int triDrawn = 0;
        int patchesDrawn = 0;
        int totalTri = 0;

        /// Handles the OpenGLDraw event of the openGLControl control.
        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {
            if (isGPSPositionInitialized)
            {

                //  Get the OpenGL object.
                OpenGL gl = openGLControl.OpenGL;

                //  Clear the color and depth buffer.
                gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
                gl.LoadIdentity();

                //camera does translations and rotations
                camera.SetWorldCam(gl, pivotAxleEasting, fixPosY, pivotAxleNorthing, fixHeadingCam);

                //calculate the frustum planes for culling
                CalcFrustum(gl);

                worldGrid.DrawFieldSurface();
                
                //Draw the world grid based on camera position
                gl.Disable(OpenGL.GL_DEPTH_TEST);
                gl.Disable(OpenGL.GL_TEXTURE_2D);

                //if grid is on draw it
                if (isGridOn) worldGrid.DrawWorldGrid(gridZoom);

                //turn on blend for paths
                gl.Enable(OpenGL.GL_BLEND);

                //section patch color
                gl.Color(0.99f, 1.0f, 0.50f, 0.4f);
                if (isDrawPolygons) gl.PolygonMode(OpenGL.GL_FRONT, OpenGL.GL_LINE);

                triDrawn = 0;
                patchesDrawn = 0;
                totalTri = 0;

                //draw patches of sections
                for (int j = 0; j < vehicle.numberOfSections; j++)
                {
                    //every time the section turns off and on is a new patch
                    int patchCount = section[j].patchList.Count;

                    //check if in frustum or not
                    bool isDraw;

                    if (patchCount > 0)
                    {
                        //initialize the steps for mipmap of triangles (skipping detail while zooming out)
                        int mipmap = 0;
                        if (camera.camSetDistance < -800) mipmap = 2;
                        if (camera.camSetDistance < -1500) mipmap = 4;
                        if (camera.camSetDistance < -2400) mipmap = 8;
                        if (camera.camSetDistance < -4800) mipmap = 16;

                        //for every new chunk of patch
                        foreach (var triList in section[j].patchList)
                        {
                            isDraw = false;
                            int count2 = triList.Count;
                            totalTri += count2;
                            for (int i = 0; i < count2; i += 3)
                            {
                                //determine if point is in frustum or not, if < 0, its outside so abort                            
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

                                //point is in frustum so draw the entire patch. The downside of triangle strips.
                                isDraw = true;
                                break;
                            }

                            if (isDraw)
                            {
                                patchesDrawn++;

                                //draw the triangle strip in each triangle strip
                                gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
                                count2 = triList.Count;

                                //if large enough patch and camera zoomed out, fake mipmap the patches, skip triangles
                                if (count2 >= (mipmap + 2))
                                {
                                    int step = mipmap;
                                    for (int i = 0; i < count2; i += step)
                                    {
                                        gl.Vertex(triList[i].x, 0, triList[i].z);
                                        triDrawn++; i++;
                                        gl.Vertex(triList[i].x, 0, triList[i].z);
                                        triDrawn++; i++;

                                        //too small to mipmap it
                                        if (count2 - i <= (mipmap + 2)) step = 0;
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < count2; i++)
                                    {
                                        gl.Vertex(triList[i].x, 0, triList[i].z);
                                        triDrawn++;
                                    }
                                }
                                gl.End();
                            }
                        }
                    }
                }


                gl.PolygonMode(OpenGL.GL_FRONT, OpenGL.GL_FILL);
                gl.Color(1, 1, 1);

                //draw contour line if button on 
                if (ct.isContourBtnOn) ct.DrawContourLine();

                // draw the current and reference AB Lines
                else
                {
                    if (ABLine.isABLineSet | ABLine.isABLineBeingSet) ABLine.DrawABLines();
                }                

                //draw the perimter line, returns if no line to draw
                periArea.DrawPerimeterLine();

                //screen text for debug
                 //gl.DrawText(10, 15, 1, 1, 1, "Courier", 14, " frame msec " + Convert.ToString((int)(frameTime)));
                 // gl.DrawText(10, 30, 1, 1, 1, "Courier", 14, "recvC " + Convert.ToString(recvCounter));
                //  gl.DrawText(10, 45, 1, 1, 1, "Courier", 14, "   Set Head " + Convert.ToString(modcom.autosteerSetpointHeading));
                //  gl.DrawText(10, 60, 1, 1, 1, "Courier", 14, "     Actual " + Convert.ToString(modcom.autosteerActualHeading));
                ////gl.DrawText(10, 75, 1, 0.5f, 1, "Courier", 12, "refHeading  " + Convert.ToString(Math.Round(ct.refHeading, 2)));
                //gl.DrawText(10, 90, 1, 0.5f, 1, "Courier", 12, "Lookahead[0] (m) " + Convert.ToString(Math.Round(section[0].sectionLookAhead*0.1)));
               //gl.DrawText(10, 105, 1, 0.5f, 1, "Courier", 12, " TrigDistance(m) " + Convert.ToString(Math.Round(sectionTriggerStepDistance, 2)));
                 //gl.DrawText(10, 120, 1, 0.5, 1, "Courier", 12, " frame msec " + Convert.ToString((int)(frameTime)));

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
                if (isIn3D && camera.camPitch > -16)
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

                    //disable, straight color
                    gl.Disable(OpenGL.GL_TEXTURE_2D);
                }

                //LightBar if AB Line is set and turned on
                if (isLightbarOn)
                {

                    if (ct.isContourBtnOn)
                    {
                        txtDistanceOffABLine.Visible = true;
                        DrawLightBar(openGLControl.Width, openGLControl.Height, ct.distanceFromCurrentLine);
                        txtDistanceOffABLine.Text = " " + Convert.ToString(Math.Abs(ct.distanceFromCurrentLine)) + " ";
                        if (Math.Abs(ABLine.distanceFromCurrentLine) > 15.0) txtDistanceOffABLine.ForeColor = Color.Yellow;
                        else txtDistanceOffABLine.ForeColor = Color.LightGreen;
                    }

                    else
                    {
                        if (ABLine.isABLineSet | ABLine.isABLineBeingSet)
                        {
                            txtDistanceOffABLine.Visible = true;
                            DrawLightBar(openGLControl.Width, openGLControl.Height, ABLine.distanceFromCurrentLine);
                            txtDistanceOffABLine.Text = " " + Convert.ToString(Math.Abs(ABLine.distanceFromCurrentLine)) + " ";
                            if (Math.Abs(ABLine.distanceFromCurrentLine) > 15.0) txtDistanceOffABLine.ForeColor = Color.Yellow;
                            else txtDistanceOffABLine.ForeColor = Color.LightGreen;
                        }
                    }

                    //AB line is not set so turn off numbers
                    if (!ABLine.isABLineSet & !ABLine.isABLineBeingSet & !ct.isContourBtnOn)
                        txtDistanceOffABLine.Visible = false;
                }

                else txtDistanceOffABLine.Visible = false;                
                gl.Flush();//finish openGL commands                
                gl.PopMatrix();//  Pop the modelview.

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
        }

        /// Handles the OpenGLInitialized event of the openGLControl control.
        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //Load all the textures
            LoadGLTextures();

            //  Set the clear color.
            gl.ClearColor(0.73f, 0.78f, 0.865f, 1.0f);

            // Set The Blending Function For Translucency
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);

            //gl.Disable(OpenGL.GL_CULL_FACE);
            gl.CullFace(OpenGL.GL_BACK);
            
            //set the camera to right distance
            SetZoom();

            //now start the timer assuming no errors, otherwise the program will not stop on errors.
            tmrWatchdog.Enabled = true;
        }

        /// Handles the Resized event of the openGLControl control.
        private void openGLControl_Resized(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  Load the identity.
            gl.LoadIdentity();

            //  Create a perspective transformation.
            gl.Perspective(fovy, (double)openGLControl.Width / (double)openGLControl.Height, 1, camDistanceFactor * camera.camSetDistance);

            //  Set the modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

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
                int patchCount = section[j].patchList.Count;

                if (patchCount > 0)
                {
                    //for every new chunk of patch
                    foreach (var triList in section[j].patchList)
                    {
                        isDraw = false;
                        int count2 = triList.Count;
                        for (int i = 0; i < count2; i+=3)
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
               //keep in as safety
                if (section[j].sectionLookAhead > 190) section[j].sectionLookAhead = 190;

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

                //calculated in CSection.CalculateSectionLookAhead, section is going backwards
                if (section[j].sectionLookAhead < 0)
                {
                    isSectionRequiredOn = false;
                }

                //if Master Auto is on
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

            //Determine if sections want to be on or off
            ProcessSectionOnOffRequests();

            //send the byte out to section relays
            BuildSectionRelayByte();
            SectionControlOutToArduino();

            //stop the timer and calc how long it took to do calcs and draw
            frameTime = (double)swFrame.ElapsedTicks / (double)System.Diagnostics.Stopwatch.Frequency * 1000;

            //if a minute has elapsed save the field in case of crash and to be able to resume            
            if (saveCounter++ > 120)       //2 counts per second X 60 seconds.
            {
                if (isJobStarted) FileSaveField("Resume");
                saveCounter = 1;
            }
            
            //this is the end of the "frame". Now we wait for next NMEA sentence. 
        }
                
        //Resize is called upn window creation
        private void openGLControlBack_Resized(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gls = openGLControlBack.OpenGL;

            gls.MatrixMode(OpenGL.GL_PROJECTION);

            //  Load the identity.
            gls.LoadIdentity();

            // change these at your own peril!!!! Very critical
            //  Create a perspective transformation.
            gls.Perspective(6.0f, 1, 1, 6000);

            //  Set the modelview matrix.
            gls.MatrixMode(OpenGL.GL_MODELVIEW);

        }


        private void openGLControlBack_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL gls = openGLControlBack.OpenGL;

            gls.Enable(OpenGL.GL_CULL_FACE);
            gls.CullFace(OpenGL.GL_BACK);

            gls.PixelStore(OpenGL.GL_PACK_ALIGNMENT, 1);

        }

        public void DrawLightBar(double Width, double Height, double offlineDistance)
        {
            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Dot distance is representation of how far from AB Line

            //width of lightbar
            double _width = 448;

            double down = 24;

            int dotDistance = (int)offlineDistance;
            //if (dotDistance < 0) dotDistance -= 20;
            //if (dotDistance > 0) dotDistance += 20;

            if (dotDistance < -370) dotDistance = -370;
            if (dotDistance > 370) dotDistance = 370;

            //the black background
            gl.Color(0, 0, 0);
            gl.PointSize(32.0f);
            gl.Begin(OpenGL.GL_POINTS);
            for (int x = (int)-_width - 32; x <= 0; x += 32) gl.Vertex((double)x, down);
            for (int x = 0; x <= (int)_width + 32; x += 32) gl.Vertex((double)x, down);
            gl.End();

            ////Big center green dots
            //gl.PointSize(40.0f);
            //gl.Begin(OpenGL.GL_POINTS);
            //gl.Color(0.0f, 0.7f, 0.0f);
            //gl.Vertex(8, down);
            //gl.Vertex(-8, down);
            //gl.End();


            ////2 off center green dots
            gl.PointSize(8.0f);
            gl.Begin(OpenGL.GL_POINTS);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(40, down);
            gl.Vertex(-40, down);
            gl.Vertex(60, down);
            gl.Vertex(-60, down);

            //yellow
            gl.Color(1.0f, 1.0f, 0.0f);
            gl.Vertex( 80, down);
            gl.Vertex(-80, down);
            gl.Vertex(100, down);
            gl.Vertex(-100, down);
            gl.Vertex(120, down);
            gl.Vertex(-120, down);

            //left red dots
            gl.Color(0.8f, 0.2f, 0.2f);
            for (int x = -24; x < -6; x++) gl.Vertex(x * 20, down);

            //right red dots
            gl.Color(0.8f, 0.2f, 0.2f);
            for (int x = 7; x < 25; x++) gl.Vertex(x * 20, down);
            gl.End();

            if (dotDistance >= -1 && dotDistance <= 1)
            {
                gl.PointSize(24.0f);
                gl.Color(0.0f, 1.0f, 0.0f);
                gl.Begin(OpenGL.GL_POINTS);
                gl.Vertex(-30, down);
                gl.Vertex( 25, down);
                gl.End();
                return;
            }
            if (dotDistance < -1) dotDistance -= 30;
            if (dotDistance > 1) dotDistance += 30;
            
            //else dotDistance += 30;
            //Are you on the right side of line?
            if (Math.Abs(offlineDistance) < 30.0)
            {
                gl.PointSize(24.0f);
                gl.Color(0.0f, 1.0f, 0.0f);
                gl.Begin(OpenGL.GL_POINTS);
                gl.Vertex(dotDistance * -1.2, down);
                gl.End();
                return;
            }

            if (Math.Abs(offlineDistance) < 100.0)
            {
                gl.PointSize(24.0f);
                gl.Color(1.0f, 1.0f, 0.0f);
                gl.Begin(OpenGL.GL_POINTS);
                gl.Vertex(dotDistance * -1.2, down);
                gl.End();
                return;
            }

            // more then 50 off ABLine so red
            gl.PointSize(24.0f);
            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Begin(OpenGL.GL_POINTS);
            gl.Vertex(dotDistance * -1.2, down);
            gl.End();



        }

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
        } 
    }
}
