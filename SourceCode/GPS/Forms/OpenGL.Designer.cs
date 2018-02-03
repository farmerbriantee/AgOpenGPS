
using System;
using System.Drawing;
using SharpGL;


namespace AgOpenGPS
{
    public partial class FormGPS
    {
        //extracted Near, Far, Right, Left clipping planes of frustum
        public double[] frustum = new double[24];

        double fovy = 45;
        double camDistanceFactor = -2;
        int mouseX = 0, mouseY = 0;

        //data buffer for pixels read from off screen buffer
        byte[] grnPixels = new byte[80001];

        /// Handles the OpenGLDraw event of the openGLControl control.
        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {
            if (isGPSPositionInitialized)
            {

                //  Get the OpenGL object.
                OpenGL gl = openGLControl.OpenGL;
                //System.Threading.Thread.Sleep(500);

                //  Clear the color and depth buffer.
                gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
                gl.LoadIdentity();

                //camera does translations and rotations
                camera.SetWorldCam(gl, pivotAxlePos.easting, pivotAxlePos.northing, camHeading);

                //calculate the frustum planes for culling
                CalcFrustum(gl);

                //draw the field ground images
                worldGrid.DrawFieldSurface();
                
                ////Draw the world grid based on camera position
                gl.Disable(OpenGL.GL_DEPTH_TEST);
                gl.Disable(OpenGL.GL_TEXTURE_2D);


                gl.Enable(OpenGL.GL_LINE_SMOOTH);
                gl.Enable(OpenGL.GL_BLEND);

                gl.Hint(OpenGL.GL_LINE_SMOOTH_HINT, OpenGL.GL_FASTEST);
                gl.Hint(OpenGL.GL_POINT_SMOOTH_HINT, OpenGL.GL_FASTEST);
                gl.Hint(OpenGL.GL_POLYGON_SMOOTH_HINT, OpenGL.GL_FASTEST);

                ////if grid is on draw it
                if (isGridOn) worldGrid.DrawWorldGrid(camera.gridZoom);

                //turn on blend for paths
                gl.Enable(OpenGL.GL_BLEND);

                //section patch color
                gl.Color(redSections, grnSections, bluSections, (byte)160);
                if (isDrawPolygons) gl.PolygonMode(OpenGL.GL_FRONT, OpenGL.GL_LINE);

                //draw patches of sections
                for (int j = 0; j < vehicle.numSuperSection; j++)
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
                            for (int i = 0; i < count2; i += 3)
                            {
                                //determine if point is in frustum or not, if < 0, its outside so abort, z always is 0                            
                                if (frustum[0] * triList[i].easting + frustum[1] * triList[i].northing + frustum[3] <= 0)
                                    continue;//right
                                if (frustum[4] * triList[i].easting + frustum[5] * triList[i].northing + frustum[7] <= 0)
                                    continue;//left
                                if (frustum[16] * triList[i].easting + frustum[17] * triList[i].northing + frustum[19] <= 0)
                                    continue;//bottom
                                if (frustum[20] * triList[i].easting + frustum[21] * triList[i].northing + frustum[23] <= 0)
                                    continue;//top
                                if (frustum[8] * triList[i].easting + frustum[9] * triList[i].northing + frustum[11] <= 0)
                                    continue;//far
                                if (frustum[12] * triList[i].easting + frustum[13] * triList[i].northing + frustum[15] <= 0)
                                    continue;//near

                                //point is in frustum so draw the entire patch. The downside of triangle strips.
                                isDraw = true;
                                break;
                            }

                            if (isDraw)
                            {
                                //draw the triangle in each triangle strip
                                gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
                                count2 = triList.Count;

                                //if large enough patch and camera zoomed out, fake mipmap the patches, skip triangles
                                if (count2 >= (mipmap + 2))
                                {
                                    int step = mipmap;
                                    for (int i = 0; i < count2; i += step)
                                    {
                                        gl.Vertex(triList[i].easting, triList[i].northing, 0); i++;
                                        gl.Vertex(triList[i].easting, triList[i].northing, 0); i++;

                                        //too small to mipmap it
                                        if (count2 - i <= (mipmap + 2)) step = 0;
                                    }
                                }

                                else { for (int i = 0; i < count2; i++)  gl.Vertex(triList[i].easting, triList[i].northing, 0); }
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
                else { if (ABLine.isABLineSet | ABLine.isABLineBeingSet) ABLine.DrawABLines(); }

                //draw the flags if there are some
                int flagCnt = flagPts.Count;
                if (flagCnt > 0)
                {
                    for (int f = 0; f < flagCnt; f++)
                    {
                        gl.PointSize(8.0f);
                        gl.Begin(OpenGL.GL_POINTS);
                        if (flagPts[f].color == 0) gl.Color((byte)255, (byte)0, (byte)flagPts[f].ID);
                        if (flagPts[f].color == 1) gl.Color((byte)0, (byte)255, (byte)flagPts[f].ID);
                        if (flagPts[f].color == 2) gl.Color((byte)255, (byte)255, (byte)flagPts[f].ID);
                        gl.Vertex(flagPts[f].easting, flagPts[f].northing, 0);
                        gl.End();
                    }

                    if (flagNumberPicked != 0)
                    {
                        ////draw the box around flag
                        gl.LineWidth(4);
                        gl.Color(0.980f, 0.0f, 0.980f);
                        gl.Begin(OpenGL.GL_LINE_STRIP);

                        double offSet = (camera.zoomValue * camera.zoomValue * 0.01);
                        gl.Vertex(flagPts[flagNumberPicked - 1].easting, flagPts[flagNumberPicked - 1].northing + offSet, 0);
                        gl.Vertex(flagPts[flagNumberPicked - 1].easting - offSet, flagPts[flagNumberPicked - 1].northing, 0);
                        gl.Vertex(flagPts[flagNumberPicked - 1].easting, flagPts[flagNumberPicked - 1].northing - offSet, 0);
                        gl.Vertex(flagPts[flagNumberPicked - 1].easting + offSet, flagPts[flagNumberPicked - 1].northing, 0);
                        gl.Vertex(flagPts[flagNumberPicked - 1].easting, flagPts[flagNumberPicked - 1].northing + offSet, 0);

                        gl.End();

                        //draw the flag with a black dot inside
                        gl.PointSize(4.0f);
                        gl.Color(0, 0, 0);
                        gl.Begin(OpenGL.GL_POINTS);
                        gl.Vertex(flagPts[flagNumberPicked - 1].easting, flagPts[flagNumberPicked - 1].northing, 0);
                        gl.End();
                    }
                }

                //draw the perimter line, returns if no line to draw
                periArea.DrawPerimeterLine();

                //draw the boundary
                boundz.DrawBoundaryLine();

                //draw the Headland line
                hl.DrawHeadlandLine();

                //screen text for debug
                //gl.DrawText(120, 10, 1, 1, 1, "Courier Bold", 18, "Head: " + saveCounter.ToString("N1"));
                //gl.DrawText(120, 40, 1, 1, 1, "Courier Bold", 18, "Tool: " + distTool.ToString("N1"));
                //gl.DrawText(120, 70, 1, 1, 1, "Courier Bold", 18, "Where: " + yt.whereAmI.ToString());
                //gl.DrawText(120, 100, 1, 1, 1, "Courier Bold", 18, "Seq: " + yt.isSequenceTriggered.ToString());
                //gl.DrawText(120, 40, 1, 1, 1, "Courier Bold", 18, "  GPS: " + Convert.ToString(Math.Round(glm.toDegrees(gpsHeading), 2)));
                //gl.DrawText(120, 70, 1, 1, 1, "Courier Bold", 18, "Fixed: " + Convert.ToString(Math.Round(glm.toDegrees(gyroCorrected), 2)));
                //gl.DrawText(120, 100, 1, 1, 1, "Courier Bold", 18, "L/Min: " + Convert.ToString(rc.CalculateRateLitersPerMinute()));
                //gl.DrawText(120, 130, 1, 1, 1, "Courier", 18, "       Roll: " + Convert.ToString(glm.toDegrees(rollDistance)));
                //gl.DrawText(120, 160, 1, 1, 1, "Courier", 18, "       Turn: " + Convert.ToString(Math.Round(turnDelta, 4)));
                //gl.DrawText(40, 120, 1, 0.5, 1, "Courier", 12, " frame msec " + Convert.ToString((int)(frameTime)));

                //draw the vehicle/implement
                vehicle.DrawVehicle();

                //Back to normal
                gl.Color(0.98f, 0.98f, 0.98f);
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

                if (isSkyOn)
                {
                    ////draw the background when in 3D
                    if (camera.camPitch < -60)
                    {
                        //-10 to -32 (top) is camera pitch range. Set skybox to line up with horizon 
                        double hite = (camera.camPitch + 60) / -20 * 0.34;
                        //hite = 0.001;

                        //the background
                        double winLeftPos = -(double)Width / 2;
                        double winRightPos = -winLeftPos;
                        gl.Enable(OpenGL.GL_TEXTURE_2D);
                        gl.BindTexture(OpenGL.GL_TEXTURE_2D, texture[0]);		// Select Our Texture

                        gl.Begin(OpenGL.GL_TRIANGLE_STRIP);				// Build Quad From A Triangle Strip
                        gl.TexCoord(0, 0); gl.Vertex(winRightPos, 0.0); // Top Right
                        gl.TexCoord(1, 0); gl.Vertex(winLeftPos, 0.0); // Top Left
                        gl.TexCoord(0, 1); gl.Vertex(winRightPos, hite * (double)Height); // Bottom Right
                        gl.TexCoord(1, 1); gl.Vertex(winLeftPos, hite * (double)Height); // Bottom Left
                        gl.End();						// Done Building Triangle Strip

                        //disable, straight color
                        gl.Disable(OpenGL.GL_TEXTURE_2D);
                    }
                }

                //LightBar if AB Line is set and turned on or contour
                if (isLightbarOn)
                {
                    if (ct.isContourBtnOn)
                    {
                        string dist;
                        txtDistanceOffABLine.Visible = true;
                        //lblDelta.Visible = true;
                        if (ct.distanceFromCurrentLine == 32000) ct.distanceFromCurrentLine = 0;

                        DrawLightBar(openGLControl.Width, openGLControl.Height, ct.distanceFromCurrentLine * 0.1);
                        if ((ct.distanceFromCurrentLine) < 0.0)
                        {
                            txtDistanceOffABLine.ForeColor = Color.Green;
                            if (isMetric) dist = ((int)Math.Abs(ct.distanceFromCurrentLine * 0.1)) + " ->";
                            else dist = ((int)Math.Abs(ct.distanceFromCurrentLine / 2.54 * 0.1)) + " ->";
                            txtDistanceOffABLine.Text = dist;
                        }

                        else
                        {
                            txtDistanceOffABLine.ForeColor = Color.Red;
                            if (isMetric) dist = "<- " + ((int)Math.Abs(ct.distanceFromCurrentLine * 0.1));
                            else dist = "<- " + ((int)Math.Abs(ct.distanceFromCurrentLine / 2.54 * 0.1));
                            txtDistanceOffABLine.Text = dist;
                        }

                        //if (guidanceLineHeadingDelta < 0) lblDelta.ForeColor = Color.Red;
                        //else lblDelta.ForeColor = Color.Green;

                        if (guidanceLineDistanceOff == 32020 | guidanceLineDistanceOff == 32000) btnAutoSteer.Text = "-";
                        else btnAutoSteer.Text = "Y";
                    }

                    else
                    {
                        if (ABLine.isABLineSet | ABLine.isABLineBeingSet)
                        {
                            string dist;

                            txtDistanceOffABLine.Visible = true;
                            //lblDelta.Visible = true;
                            DrawLightBar(openGLControl.Width, openGLControl.Height, ABLine.distanceFromCurrentLine * 0.1);
                            if ((ABLine.distanceFromCurrentLine) < 0.0)
                            {
                                // --->
                                txtDistanceOffABLine.ForeColor = Color.Green;
                                if (isMetric) dist = ((int)Math.Abs(ABLine.distanceFromCurrentLine * 0.1)) + " ->";
                                else dist = ((int)Math.Abs(ABLine.distanceFromCurrentLine / 2.54 * 0.1)) + " ->";
                                txtDistanceOffABLine.Text = dist;
                            }

                            else
                            {
                                // <----
                                txtDistanceOffABLine.ForeColor = Color.Red;
                                if (isMetric) dist = "<- " + ((int)Math.Abs(ABLine.distanceFromCurrentLine * 0.1));
                                else dist = "<- " + ((int)Math.Abs(ABLine.distanceFromCurrentLine / 2.54 * 0.1));
                                txtDistanceOffABLine.Text = dist;
                            }

                            //if (guidanceLineHeadingDelta < 0) lblDelta.ForeColor = Color.Red;
                            //else lblDelta.ForeColor = Color.Green;
                            if (guidanceLineDistanceOff == 32020 | guidanceLineDistanceOff == 32000) btnAutoSteer.Text = "-";
                            else btnAutoSteer.Text = "Y";
                        }
                    }

                    //AB line is not set so turn off numbers
                    if (!ABLine.isABLineSet & !ABLine.isABLineBeingSet & !ct.isContourBtnOn)
                    {
                        txtDistanceOffABLine.Visible = false;
                        btnAutoSteer.Text = "-";
                    }
                }
                else
                {
                    txtDistanceOffABLine.Visible = false;
                    btnAutoSteer.Text = "-";
                }

                gl.Flush();//finish openGL commands
                gl.PopMatrix();//  Pop the modelview.

                //  back to the projection and pop it, then back to the model view.
                gl.MatrixMode(OpenGL.GL_PROJECTION);
                gl.PopMatrix();
                gl.MatrixMode(OpenGL.GL_MODELVIEW);

                //reset point size
                gl.PointSize(1.0f);
                gl.Flush();

                if (leftMouseDownOnOpenGL)
                {
                    leftMouseDownOnOpenGL = false;
                    byte[] data1 = new byte[192];

                    //scan the center of click and a set of square points around
                    gl.ReadPixels(mouseX - 4, mouseY - 4, 8, 8, OpenGL.GL_RGB, OpenGL.GL_UNSIGNED_BYTE, data1);

                    //made it here so no flag found
                    flagNumberPicked = 0;

                    for (int ctr = 0; ctr < 192; ctr += 3)
                    {
                        if (data1[ctr] == 255 | data1[ctr + 1] == 255)
                        {
                            flagNumberPicked = data1[ctr + 2];
                            break;
                        }
                    }
                }

                //draw the section control window off screen buffer
                openGLControlBack.DoRender();

                //draw the zoom window off screen buffer in the second tab
                if (tabControl1.SelectedIndex == 1)
                openGLControlZoom.DoRender();


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
            gl.ClearColor(0.22f, 0.2858f, 0.16f, 1.0f);

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

        //main openGL draw function
        private void openGLControlBack_OpenGLDraw(object sender, RenderEventArgs args)
        {
            OpenGL gl = openGLControlBack.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);	// Clear The Screen And The Depth Buffer
            gl.LoadIdentity();					// Reset The View

            //back the camera up
            gl.Translate(0, 0, -390);

            //rotate camera so heading matched fix heading in the world
            gl.Rotate(glm.toDegrees(fixHeadingSection), 0, 0, 1);

            //translate to that spot in the world 
            gl.Translate(-toolPos.easting, -toolPos.northing, -fixZ);

            //patch color
            gl.Color(0.0f, 0.5f, 0.0f);

            //calculate the frustum for the section control window
            CalcFrustum(gl);

            //to draw or not the triangle patch
            bool isDraw;

            //draw patches j= # of sections
            for (int j = 0; j < vehicle.numSuperSection; j++)
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
                            if (frustum[0] * triList[i].easting + frustum[1] * triList[i].northing + frustum[3] <= 0)
                                continue;//right
                            if (frustum[4] * triList[i].easting + frustum[5] * triList[i].northing + frustum[7] <= 0)
                                continue;//left
                           if (frustum[16] * triList[i].easting + frustum[17] * triList[i].northing + frustum[19] <= 0)
                                continue;//bottom
                            if (frustum[20] * triList[i].easting + frustum[21] * triList[i].northing + frustum[23] <= 0)
                                continue;//top
 
                            //point is in frustum so draw the entire patch
                            isDraw = true;
                            break;
                        }

                        if (isDraw)
                        {
                            //draw the triangles in each triangle strip
                            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
                            for (int i = 0; i < count2; i++) gl.Vertex(triList[i].easting, triList[i].northing, 0);
                            gl.End();
                        }
                    }
                }
            }

            //draw boundary line
            boundz.DrawBoundaryLineOnBackBuffer();
            
            //determine farthest ahead lookahead - is the height of the readpixel line
            double rpHeight = 0;

            //assume all sections are on and super can be on, if not set false to turn off.
            vehicle.isSuperSectionAllowedOn = true;

            //find any off buttons, any outside of boundary, going backwards, and the farthest lookahead
            for (int j = 0; j < vehicle.numOfSections; j++)
            {
                if (section[j].sectionLookAhead > rpHeight) rpHeight = section[j].sectionLookAhead;
                if (section[j].manBtnState == manBtn.Off) vehicle.isSuperSectionAllowedOn = false;
                if (!section[j].isInsideBoundary) vehicle.isSuperSectionAllowedOn = false;

                //check if any sections going backwards
                if (section[j].sectionLookAhead < 0) vehicle.isSuperSectionAllowedOn = false;
            }

            //if only one section, or going slow no need for super section 
            if (vehicle.numOfSections == 1 | pn.speed < vehicle.slowSpeedCutoff) 
                    vehicle.isSuperSectionAllowedOn = false;

            //clamp the height after looking way ahead, this is for switching off super section only
            rpHeight = Math.Abs(rpHeight) * 2.0;
            if (rpHeight > 195) rpHeight = 195;
            if (rpHeight < 8) rpHeight = 8;

            //read the whole block of pixels up to max lookahead, one read only
            gl.ReadPixels(vehicle.rpXPosition, 202, vehicle.rpWidth, (int)rpHeight,
                                OpenGL.GL_GREEN, OpenGL.GL_UNSIGNED_BYTE, grnPixels);

            //10 % min is required for overlap, otherwise it never would be on.
            int pixLimit = (int)((double)(vehicle.rpWidth * rpHeight)/(double)(vehicle.numOfSections*1.5)); 

            //is applied area coming up?
            int totalPixs = 0;
            if (vehicle.isSuperSectionAllowedOn)
            {
                //look for anything applied coming up
                for (int a = 0; a < (vehicle.rpWidth * rpHeight); a++)
                {
                    if (grnPixels[a] != 0 )
                    {
                        if (totalPixs++ > pixLimit)
                        {
                            vehicle.isSuperSectionAllowedOn = false;
                            break;
                        }

                        //check for a boundary line
                        if (grnPixels[a] > 200)
                            {
                                vehicle.isSuperSectionAllowedOn = false;
                                break;
                            }
                    }
                }
            }


            // If ALL sections are required on, No buttons are off, within boundary, turn super section on, normal sections off
            if (vehicle.isSuperSectionAllowedOn)
            {
                for (int j = 0; j < vehicle.numOfSections; j++)
                {
                    if (section[j].isSectionOn)
                    {
                        section[j].sectionOffRequest = true;
                        section[j].sectionOnRequest = false;
                        section[j].sectionOffTimer = 0;
                        section[j].sectionOnTimer = 0;
                    }
                }

                //turn on super section
                section[vehicle.numOfSections].sectionOnRequest = true;
                section[vehicle.numOfSections].sectionOffRequest = false;
            }

            /* Below is priority based. The last if statement is the one that is
                * applied and takes the highest priority. Digital input controls
                * have the highest priority and overide all buttons except
                * the manual button which exits the loop and just turns sections on....
                * Because isn't that what manual means! */

            //turn on indivdual sections as super section turn off
            else
            {
                //Read the pixels ahead of tool a normal section at a time. Each section can have its own lookahead manipulated. 

                for (int j = 0; j < vehicle.numOfSections; j++)
                {
                    //is section going backwards?
                    if (section[j].sectionLookAhead > 0)
                    {
                        //If any nowhere applied, send OnRequest, if its all green send an offRequest
                        section[j].isSectionRequiredOn = false;

                        if (boundz.isSet)
                        {

                            int start = 0, end = 0, skip = 0;
                            start = section[j].rpSectionPosition - section[0].rpSectionPosition;
                            end = section[j].rpSectionWidth - 1 + start;
                            if (end > vehicle.rpWidth - 1) end = vehicle.rpWidth - 1;
                            skip = vehicle.rpWidth - (end - start);


                            int tagged = 0;
                            for (int h = 0; h < (int)section[j].sectionLookAhead; h++)
                            {
                                for (int a = start; a < end; a++)
                                {
                                    if (grnPixels[a] == 0)
                                    {
                                        if (tagged++ > vehicle.toolMinUnappliedPixels)
                                        {
                                            section[j].isSectionRequiredOn = true;
                                            goto GetMeOutaHere;
                                        }
                                    }
                                }

                                start += vehicle.rpWidth;
                                end += vehicle.rpWidth;
                            }

                            //minimum apllied conditions met
                            GetMeOutaHere:

                            start = 0; end = 0; skip = 0;
                            start = section[j].rpSectionPosition - section[0].rpSectionPosition;
                            end = section[j].rpSectionWidth - 1 + start;
                            if (end > vehicle.rpWidth - 1) end = vehicle.rpWidth - 1;
                            skip = vehicle.rpWidth - (end - start);

                            //looking for boundary line color, bright green
                            for (int h = 0; h < (int)section[j].sectionLookAhead; h++)
                            {
                                for (int a = start; a < end; a++)
                                {
                                    if (grnPixels[a] > 240) //&& )
                                    {
                                        section[j].isSectionRequiredOn = false;
                                        section[j].sectionOffRequest = true;
                                        section[j].sectionOnRequest = false;
                                        section[j].sectionOffTimer = 0;
                                        section[j].sectionOnTimer = 0;

                                        goto GetMeOutaHereNow;
                                    }
                                }

                                start += vehicle.rpWidth;
                                end += vehicle.rpWidth;
                            }

                            GetMeOutaHereNow:

                            //if out of boundary, turn it off
                            if (!section[j].isInsideBoundary)
                            {
                                section[j].isSectionRequiredOn = false;
                                section[j].sectionOffRequest = true;
                                section[j].sectionOnRequest = false;
                                section[j].sectionOffTimer = 0;
                                section[j].sectionOnTimer = 0;
                            }
                        }

                        //no boundary set so ignore
                        else
                        {
                            section[j].isSectionRequiredOn = false;

                            int start = 0, end = 0, skip = 0;
                            start = section[j].rpSectionPosition - section[0].rpSectionPosition;
                            end = section[j].rpSectionWidth - 1 + start;
                            if (end > vehicle.rpWidth - 1) end = vehicle.rpWidth - 1;
                            skip = vehicle.rpWidth - (end - start);


                            int tagged = 0;
                            for (int h = 0; h < (int)section[j].sectionLookAhead; h++)
                            {
                                for (int a = start; a < end; a++)
                                {
                                    if (grnPixels[a] == 0)
                                    {
                                        if (tagged++ > vehicle.toolMinUnappliedPixels)
                                        {
                                            section[j].isSectionRequiredOn = true;
                                            goto GetMeOutaHere;
                                        }
                                    }
                                }

                                start += vehicle.rpWidth;
                                end += vehicle.rpWidth;
                            }

                            //minimum apllied conditions met
                            GetMeOutaHere:
                            start = 0;
                        }
                    }

                    //if section going backwards turn it off
                    else section[j].isSectionRequiredOn = false;

                }

                //if the superSection is on, turn it off
                if (section[vehicle.numOfSections].isSectionOn)
                {
                    section[vehicle.numOfSections].sectionOffRequest = true;
                    section[vehicle.numOfSections].sectionOnRequest = false;
                    section[vehicle.numOfSections].sectionOffTimer = 0;
                    section[vehicle.numOfSections].sectionOnTimer = 0;
                }

                //if Master Auto is on
                for (int j = 0; j < vehicle.numOfSections; j++)
                {
                    if (section[j].isSectionRequiredOn && section[j].isAllowedOn)
                    {
                        //global request to turn on section
                        section[j].sectionOnRequest = true;
                        section[j].sectionOffRequest = false;
                    }

                    else if (!section[j].isSectionRequiredOn)
                    {
                        //global request to turn off section
                        section[j].sectionOffRequest = true;
                        section[j].sectionOnRequest = false;
                    }

                    // Manual on, force the section On and exit loop so digital is also overidden
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

                    //if going too slow turn off sections
                    if (pn.speed < vehicle.slowSpeedCutoff)
                    {
                        section[j].sectionOnRequest = false;
                        section[j].sectionOffRequest = true;
                    }  

                    //digital input Master control (WorkSwitch)
                    if (isJobStarted && mc.isWorkSwitchEnabled)
                    {
                        //check condition of work switch
                        if (mc.isWorkSwitchActiveLow)
                        {
                            if (mc.workSwitchValue == 0)
                                { section[j].sectionOnRequest = true; section[j].sectionOffRequest = false; }
                            else { section[j].sectionOnRequest = false; section[j].sectionOffRequest = true; }
                        }
                        else
                        {
                            if (mc.workSwitchValue == 1)
                                { section[j].sectionOnRequest = true; section[j].sectionOffRequest = false; }
                            else { section[j].sectionOnRequest = false; section[j].sectionOffRequest = true; }
                        }
                    }                                      
                }
            }

            //double check the work switch to enable/disable auto section button
            if (isJobStarted)
            {
                if (!mc.isWorkSwitchEnabled) btnSectionOffAutoOn.Enabled = true;
                else btnSectionOffAutoOn.Enabled = false;
            }
            
            gl.Flush();

            //Determine if sections want to be on or off
            ProcessSectionOnOffRequests();

            //send the byte out to section relays
            BuildRelayByte();
            
            //stop the timer and calc how long it took to do calcs and draw
            frameTime = (double)swFrame.ElapsedTicks / (double)System.Diagnostics.Stopwatch.Frequency * 1000;

            //if a couple minute has elapsed save the field in case of crash and to be able to resume            
            if (saveCounter > 240)       //2 counts per second X 60 seconds = 120 counts per minute.
            {
                if (isJobStarted && stripOnlineGPS.Value != 1)
                {
                    //auto save the field patches, contours accumulated so far
                    FileSaveField();
                    FileSaveContour();

                    //NMEA log file
                    if (isLogNMEA) FileSaveNMEA();
                }
                saveCounter = 0;
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

        //Draw section OpenGL window, not visible
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
            double down = 20;

            gl.LineWidth(1);
            
            //  Dot distance is representation of how far from AB Line
            int dotDistance = (int)(offlineDistance);

            if (dotDistance < -320) dotDistance = -320;
            if (dotDistance > 320) dotDistance = 320;

            if (dotDistance < -10) dotDistance -= 30;
            if (dotDistance > 10) dotDistance += 30;

            // dot background
            gl.PointSize(8.0f);
            gl.Color(0.00f, 0.0f, 0.0f);
            gl.Begin(OpenGL.GL_POINTS);
            for (int i = -10; i < 0; i++) gl.Vertex((i * 40), down);
            for (int i = 1; i < 11; i++) gl.Vertex((i * 40), down);
            gl.End();

            gl.PointSize(4.0f);

            //red left side
            gl.Color(0.9750f, 0.0f, 0.0f);
            gl.Begin(OpenGL.GL_POINTS);
            for (int i = -10; i < 0; i++) gl.Vertex((i * 40), down);

            //green right side
            gl.Color(0.0f, 0.9750f, 0.0f);
            for (int i = 1; i < 11; i++) gl.Vertex((i * 40), down);
            gl.End();

                //Are you on the right side of line? So its green.
                if ((offlineDistance) < 0.0)
                {
                    int dots = dotDistance * -1 / 32;

                    gl.PointSize(32.0f);
                    gl.Color(0.0f, 0.0f, 0.0f);
                    gl.Begin(OpenGL.GL_POINTS);
                    for (int i = 1; i < dots + 1; i++) gl.Vertex((i * 40), down);
                    gl.End();

                    gl.PointSize(24.0f);
                    gl.Color(0.0f, 0.980f, 0.0f);
                    gl.Begin(OpenGL.GL_POINTS);
                    for (int i = 0; i < dots; i++) gl.Vertex((i * 40 + 40), down);
                    gl.End();
                    //return;
                }

                else
                {
                    int dots = dotDistance / 32;

                    gl.PointSize(32.0f);
                    gl.Color(0.0f, 0.0f, 0.0f);
                    gl.Begin(OpenGL.GL_POINTS);
                    for (int i = 1; i < dots + 1; i++) gl.Vertex((i * -40), down);
                    gl.End();

                    gl.PointSize(24.0f);
                    gl.Color(0.980f, 0.30f, 0.0f);
                    gl.Begin(OpenGL.GL_POINTS);
                    for (int i = 0; i < dots; i++) gl.Vertex((i * -40 - 40), down);
                    gl.End();
                    //return;
                }
            
            //yellow center dot
            if (dotDistance >= -10 && dotDistance <= 10)
            {
                gl.PointSize(32.0f);                
                gl.Color(0.0f, 0.0f, 0.0f);
                gl.Begin(OpenGL.GL_POINTS);
                gl.Vertex(0, down);
                //gl.Vertex(0, down + 50);
                gl.End();

                gl.PointSize(24.0f);
                gl.Color(0.980f, 0.98f, 0.0f);
                gl.Begin(OpenGL.GL_POINTS);
                gl.Vertex(0, down);
                //gl.Vertex(0, down + 50);
                gl.End();
            }

            else
            {

                gl.PointSize(8.0f);
                gl.Color(0.00f, 0.0f, 0.0f);
                gl.Begin(OpenGL.GL_POINTS);
                gl.Vertex(-0, down);
                //gl.Vertex(0, down + 30);
                //gl.Vertex(0, down + 60);
                gl.End();

                //gl.PointSize(4.0f);
                //gl.Color(0.9250f, 0.9250f, 0.250f);
                //gl.Begin(OpenGL.GL_POINTS);
                //gl.Vertex(0, down);
                //gl.Vertex(0, down + 30);
                //gl.Vertex(0, down + 60);
                //gl.End();
            }
        }

        public void CalcFrustum(OpenGL gl)
        {
            float[] proj = new float[16];							// For Grabbing The PROJECTION Matrix
            float[] modl = new float[16];							// For Grabbing The MODELVIEW Matrix
            float[] clip = new float[16];							// Result Of Concatenating PROJECTION and MODELVIEW
            //float t;											    // Temporary Work Variable

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
            //t = (float)Math.Sqrt(frustum[0] * frustum[0] + frustum[1] * frustum[1] + frustum[2] * frustum[2]);
            //frustum[0] /= t;
            //frustum[1] /= t;
            //frustum[2] /= t;
            //frustum[3] /= t;


            // Extract the LEFT clipping plane
            frustum[4] = clip[3] + clip[0];
            frustum[5] = clip[7] + clip[4];
            frustum[6] = clip[11] + clip[8];
            frustum[7] = clip[15] + clip[12];

            // Normalize it
            //t = (float)Math.Sqrt(frustum[4] * frustum[4] + frustum[5] * frustum[5] + frustum[6] * frustum[6]);
            //frustum[4] /= t;
            //frustum[5] /= t;
            //frustum[6] /= t;
            //frustum[7] /= t;

            // Extract the FAR clipping plane
            frustum[8] = clip[3] - clip[2];
            frustum[9] = clip[7] - clip[6];
            frustum[10] = clip[11] - clip[10];
            frustum[11] = clip[15] - clip[14];

            // Normalize it
            //t = (float)Math.Sqrt(frustum[8] * frustum[8] + frustum[9] * frustum[9] + frustum[10] * frustum[10]);
            //frustum[8] /= t;
            //frustum[9] /= t;
            //frustum[10] /= t;
            //frustum[11] /= t;

            // Extract the NEAR clipping plane.  This is last on purpose (see pointinfrustum() for reason)
            frustum[12] = clip[3] + clip[2];
            frustum[13] = clip[7] + clip[6];
            frustum[14] = clip[11] + clip[10];
            frustum[15] = clip[15] + clip[14];

            // Normalize it
            //t = (float)Math.Sqrt(frustum[12] * frustum[12] + frustum[13] * frustum[13] + frustum[14] * frustum[14]);
            //frustum[12] /= t;
            //frustum[13] /= t;
            //frustum[14] /= t;
            //frustum[15] /= t;

            // Extract the BOTTOM clipping plane
            frustum[16] = clip[3] + clip[1];
            frustum[17] = clip[7] + clip[5];
            frustum[18] = clip[11] + clip[9];
            frustum[19] = clip[15] + clip[13];

            // Normalize it
            //t = (float)Math.Sqrt(frustum[16] * frustum[16] + frustum[17] * frustum[17] + frustum[18] * frustum[18]);
            //frustum[16] /= t;
            //frustum[17] /= t;
            //frustum[18] /= t;
            //frustum[19] /= t;


            // Extract the TOP clipping plane
            frustum[20] = clip[3] - clip[1];
            frustum[21] = clip[7] - clip[5];
            frustum[22] = clip[11] - clip[9];
            frustum[23] = clip[15] - clip[13];

            // Normalize it
            //t = (float)Math.Sqrt(frustum[20] * frustum[20] + frustum[21] * frustum[21] + frustum[22] * frustum[22]);
            //frustum[20] /= t;
            //frustum[21] /= t;
            //frustum[22] /= t;
            //frustum[23] /= t;
        } 

        private void openGLControlZoom_OpenGLDraw(object sender, RenderEventArgs args)
        {
            OpenGL gl = openGLControlZoom.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);	// Clear The Screen And The Depth Buffer
            gl.LoadIdentity();					// Reset The View

            //how big is our field
            if (fiveSecondCounter > 85)
            {
                CalculateMinMax();
                fiveSecondCounter = 0;
            }

            //back the camera up
            gl.Translate(0, 0, -maxFieldDistance);

            //rotate camera so heading matched fix heading in the world
            //gl.Rotate(glm.toDegrees(fixHeadingSection), 0, 0, 1);

            //translate to that spot in the world 
            gl.Translate(-fieldCenterX, -fieldCenterY, -fixZ);

            //calculate the frustum for the section control window
            CalcFrustum(gl);

            //to draw or not the triangle patch
            bool isDraw;

            gl.Color(redSections, grnSections, bluSections, (byte)160);

            //draw patches j= # of sections
            for (int j = 0; j < vehicle.numSuperSection; j++)
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
                        for (int i = 0; i < count2; i += 3)
                        {
                            //determine if point is in frustum or not
                            if (frustum[0] * triList[i].easting + frustum[1] * triList[i].northing + frustum[3] <= 0)
                                continue;//right
                            if (frustum[4] * triList[i].easting + frustum[5] * triList[i].northing + frustum[7] <= 0)
                                continue;//left
                            if (frustum[16] * triList[i].easting + frustum[17] * triList[i].northing + frustum[19] <= 0)
                                continue;//bottom
                            if (frustum[20] * triList[i].easting + frustum[21] * triList[i].northing + frustum[23] <= 0)
                                continue;//top

                            //point is in frustum so draw the entire patch
                            isDraw = true;
                            break;
                        }

                        if (isDraw)
                        {
                            //draw the triangle in each triangle strip
                            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
                            count2 = triList.Count;
                            int mipmap = 8;

                            //if large enough patch and camera zoomed out, fake mipmap the patches, skip triangles
                            if (count2 >= (mipmap + 2))
                            {
                                int step = mipmap;
                                for (int i = 0; i < count2; i += step)
                                {
                                    gl.Vertex(triList[i].easting, triList[i].northing, 0); i++;
                                    gl.Vertex(triList[i].easting, triList[i].northing, 0); i++;

                                    //too small to mipmap it
                                    if (count2 - i <= (mipmap + 2)) step = 0;
                                }
                            }

                            else { for (int i = 0; i < count2; i++) gl.Vertex(triList[i].easting, triList[i].northing, 0); }
                            gl.End();
                        }
                    }
                }
            } //end of section patches

            //draw the ABLine
            if (ABLine.isABLineSet | ABLine.isABLineBeingSet)
            {
                //Draw reference AB line
                gl.LineWidth(1);
                gl.Enable(OpenGL.GL_LINE_STIPPLE);
                gl.LineStipple(1, 0x00F0);

                gl.Begin(OpenGL.GL_LINES);
                gl.Color(0.9f, 0.5f, 0.7f);
                gl.Vertex(ABLine.refABLineP1.easting, ABLine.refABLineP1.northing, 0);
                gl.Vertex(ABLine.refABLineP2.easting, ABLine.refABLineP2.northing, 0);
                gl.End();
                gl.Disable(OpenGL.GL_LINE_STIPPLE);

                //raw current AB Line
                gl.Begin(OpenGL.GL_LINES);
                gl.Color(0.9f, 0.0f, 0.0f);
                gl.Vertex(ABLine.currentABLineP1.easting, ABLine.currentABLineP1.northing, 0.0);
                gl.Vertex(ABLine.currentABLineP2.easting, ABLine.currentABLineP2.northing, 0.0);
                gl.End();
            }

                ////draw the perimeter line so far
            int ptCount = boundz.ptList.Count;
            if (ptCount > 0)
            {
                gl.LineWidth(2);
                gl.Color(0.98f, 0.2f, 0.60f);
                gl.Begin(OpenGL.GL_LINE_STRIP);
                for (int h = 0; h < ptCount; h++) gl.Vertex(boundz.ptList[h].easting, boundz.ptList[h].northing, 0);
                gl.End();

                //the "close the loop" line
                gl.Begin(OpenGL.GL_LINE_STRIP);
                gl.Vertex(boundz.ptList[ptCount - 1].easting, boundz.ptList[ptCount - 1].northing, 0);
                gl.Vertex(boundz.ptList[0].easting, boundz.ptList[0].northing, 0);
                gl.End();
            }

            ////draw the headland line
            if (hl.isSet)
            {
                int pts = hl.ptList.Count;
                if (pts > 0)
                {
                    gl.PointSize(4);
                    gl.Color(0.9298f, 0.9572f, 0.260f);
                    gl.Begin(OpenGL.GL_POINTS);
                    for (int h = 0; h < pts; h++) gl.Vertex(hl.ptList[h].easting, hl.ptList[h].northing, 0);
                    gl.End();
                }
            }

            gl.PointSize(8.0f);
            gl.Begin(OpenGL.GL_POINTS);

            gl.Color(0.95f, 0.90f, 0.0f);
            gl.Vertex(pivotAxlePos.easting, pivotAxlePos.northing, 0.0);


            gl.End();
            gl.PointSize(1.0f);

        }

        private void openGLControlZoom_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL glz = openGLControlZoom.OpenGL;

            glz.Enable(OpenGL.GL_CULL_FACE);
            glz.CullFace(OpenGL.GL_BACK);
        }

        private void openGLControlZoom_Resized(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL glz = openGLControlZoom.OpenGL;

            glz.MatrixMode(OpenGL.GL_PROJECTION);

            //  Load the identity.
            glz.LoadIdentity();

            // change these at your own peril!!!! Very critical
            //  Create a perspective transformation.
            glz.Perspective(58.0f, 1, 1, 20000);

            //  Set the modelview matrix.
            glz.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        double maxFieldX, maxFieldY, minFieldX, minFieldY, fieldCenterX, fieldCenterY, maxFieldDistance;
        //determine mins maxs of patches and whole field.
        private void CalculateMinMax()
        {

            minFieldX = 9999999; minFieldY = 9999999;
            maxFieldX = -9999999; maxFieldY = -9999999;

            //draw patches j= # of sections
            for (int j = 0; j < vehicle.numSuperSection; j++)
            {
                //every time the section turns off and on is a new patch
                int patchCount = section[j].patchList.Count;

                if (patchCount > 0)
                {
                    //for every new chunk of patch
                    foreach (var triList in section[j].patchList)
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

                if (maxFieldX == -9999999 | minFieldX == 9999999 | maxFieldY == -9999999 | minFieldY == 9999999)
                {
                    maxFieldX = 0; minFieldX = 0; maxFieldY = 0; minFieldY = 0;
                }
                else
                {
                    //the largest distancew across field
                    double dist = Math.Abs(minFieldX - maxFieldX);
                    double dist2 = Math.Abs(minFieldY - maxFieldY);

                    if (dist > dist2) maxFieldDistance = (dist);
                    else maxFieldDistance = (dist2);


                    if (maxFieldDistance < 200) maxFieldDistance = 200;
                    if (maxFieldDistance > 19900) maxFieldDistance = 19900;
                    //lblMax.Text = ((int)maxFieldDistance).ToString();

                    fieldCenterX = (maxFieldX + minFieldX) / 2.0;
                    fieldCenterY = (maxFieldY + minFieldY) / 2.0;
                }

                if (isMetric)
                {
                    lblFieldWidthEastWest.Text = Math.Abs((maxFieldX - minFieldX)).ToString("N0") + " m";
                    lblFieldWidthNorthSouth.Text = Math.Abs((maxFieldY - minFieldY)).ToString("N0") + " m";
                }
                else
                {
                    lblFieldWidthEastWest.Text = Math.Abs((maxFieldX - minFieldX)* glm.m2ft).ToString("N0") + " ft";
                    lblFieldWidthNorthSouth.Text = Math.Abs((maxFieldY - minFieldY)*glm.m2ft).ToString("N0") + " ft";
                }

                lblZooom.Text = ((int)(maxFieldDistance)).ToString();
            }
        }

        //endo of class
    }
}
