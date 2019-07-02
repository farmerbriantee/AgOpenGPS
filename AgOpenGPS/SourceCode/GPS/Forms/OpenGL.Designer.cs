
using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Windows.Forms;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public partial class FormGPS
    {
        //extracted Near, Far, Right, Left clipping planes of frustum
        public double[] frustum = new double[24];

        private bool isInit = false;

        double fovy = 0.7;
        double camDistanceFactor = -2;
        int mouseX = 0, mouseY = 0;

        public double lookaheadActual, test2;

        //data buffer for pixels read from off screen buffer
        byte[] grnPixels = new byte[125001];

        // When oglMain is created
        private void oglMain_Load(object sender, EventArgs e)
        {
            oglMain.MakeCurrent();
            LoadGLTextures();
            GL.ClearColor(0.5122f, 0.58f, 0.75f, 1.0f);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.CullFace(CullFaceMode.Back);
            SetZoom();
            tmrWatchdog.Enabled = true;
        }

        //oglMain needs a resize
        private void oglMain_Resize(object sender, EventArgs e)
        {
            oglMain.MakeCurrent();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Viewport(0, 0, oglMain.Width, oglMain.Height);
            Matrix4 mat = Matrix4.CreatePerspectiveFieldOfView((float)fovy, (float)oglMain.Width / (float)oglMain.Height, 
                1f, (float)(camDistanceFactor * camera.camSetDistance));
            GL.LoadMatrix(ref mat);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        //oglMain rendering, Draw
        private void oglMain_Paint(object sender, PaintEventArgs e)
        {
            if (isGPSPositionInitialized)
            {
                oglMain.MakeCurrent();
                if (!isInit)
                {
                    oglMain_Resize(oglMain, EventArgs.Empty);
                }
                isInit = true;

                //  Clear the color and depth buffer.
                GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
                GL.LoadIdentity();
                camera.SetWorldCam(pivotAxlePos.easting, pivotAxlePos.northing, camHeading);
                CalcFrustum();
                worldGrid.DrawFieldSurface();
                //GL.Disable(EnableCap.DepthTest);
                GL.Enable(EnableCap.Blend);

                rateMap.DrawArr();
                //GL.Disable(EnableCap.Texture2D);

                ////if grid is on draw it
                if (isGridOn) worldGrid.DrawWorldGrid(camera.gridZoom);

                //section patch color
                GL.Color4(redSections, grnSections, bluSections, (byte)160);
                if (isDrawPolygons) GL.PolygonMode(MaterialFace.Front, PolygonMode.Line);

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
                                GL.Begin(PrimitiveType.TriangleStrip);
                                count2 = triList.Count;

                                //if large enough patch and camera zoomed out, fake mipmap the patches, skip triangles
                                if (count2 >= (mipmap + 2))
                                {
                                    int step = mipmap;
                                    for (int i = 0; i < count2; i += step)
                                    {
                                        GL.Vertex3(triList[i].easting, triList[i].northing, 0); i++;
                                        GL.Vertex3(triList[i].easting, triList[i].northing, 0); i++;                                        
                                        if (count2 - i <= (mipmap + 2)) step = 0;//too small to mipmap it
                                    }
                                }
                                else { for (int i = 0; i < count2; i++) GL.Vertex3(triList[i].easting, triList[i].northing, 0); }
                                GL.End();
                            }
                        }
                    }
                }

                GL.PolygonMode(MaterialFace.Front, PolygonMode.Fill);
                GL.Color3(1, 1, 1);

                //draw contour line if button on 
                if (ct.isContourBtnOn)
                {
                    ct.DrawContourLine();
                }
                else// draw the current and reference AB Lines or CurveAB Ref and line
                {
                    if (ABLine.isABLineSet | ABLine.isABLineBeingSet) ABLine.DrawABLines();
                    if (curve.isCurveBtnOn) curve.DrawCurve();
                }

                //if (recPath.isRecordOn)
                recPath.DrawRecordedLine();
                recPath.DrawDubins();

                //draw Boundaries
                bnd.DrawBoundaryLines();

                //draw the turnLines
                turn.DrawTurnLines();
                gf.DrawGeoFenceLines();
                turn.DrawClosestPoint();

                //draw generated path
                //genPath.DrawGeneratedPath();
                self.DrawDubins();

                //draw the flags if there are some
                int flagCnt = flagPts.Count;
                if (flagCnt > 0)
                {
                    for (int f = 0; f < flagCnt; f++)
                    {
                        GL.PointSize(8.0f);
                        GL.Begin(PrimitiveType.Points);
                        if (flagPts[f].color == 0) GL.Color3((byte)255, (byte)0, (byte)flagPts[f].ID);
                        if (flagPts[f].color == 1) GL.Color3((byte)0, (byte)255, (byte)flagPts[f].ID);
                        if (flagPts[f].color == 2) GL.Color3((byte)255, (byte)255, (byte)flagPts[f].ID);
                        GL.Vertex3(flagPts[f].easting, flagPts[f].northing, 0);
                        GL.End();
                    }

                    if (flagNumberPicked != 0)
                    {
                        ////draw the box around flag
                        double offSet = (camera.zoomValue * camera.zoomValue * 0.01);
                        GL.LineWidth(4);
                        GL.Color3(0.980f, 0.0f, 0.980f);
                        GL.Begin(PrimitiveType.LineStrip);
                        GL.Vertex3(flagPts[flagNumberPicked - 1].easting, flagPts[flagNumberPicked - 1].northing + offSet, 0);
                        GL.Vertex3(flagPts[flagNumberPicked - 1].easting - offSet, flagPts[flagNumberPicked - 1].northing, 0);
                        GL.Vertex3(flagPts[flagNumberPicked - 1].easting, flagPts[flagNumberPicked - 1].northing - offSet, 0);
                        GL.Vertex3(flagPts[flagNumberPicked - 1].easting + offSet, flagPts[flagNumberPicked - 1].northing, 0);
                        GL.Vertex3(flagPts[flagNumberPicked - 1].easting, flagPts[flagNumberPicked - 1].northing + offSet, 0);
                        GL.End();

                        //draw the flag with a black dot inside
                        GL.PointSize(4.0f);
                        GL.Color3(0, 0, 0);
                        GL.Begin(PrimitiveType.Points);
                        GL.Vertex3(flagPts[flagNumberPicked - 1].easting, flagPts[flagNumberPicked - 1].northing, 0);
                        GL.End();
                    }
                }

                //draw the perimter line, returns if no line to draw
                if (periArea.isBtnPerimeterOn) periArea.DrawPerimeterLine();

                ////Draw closest headland point if youturn on
                //if (yt.isYouTurnBtnOn)
                //{
                //    //hl.DrawClosestPoint();
                //    bnd.DrawClosestPoint();
                //}

                //draw the vehicle/implement
                vehicle.DrawVehicle();

                //Back to normal
                GL.Color3(0.498f, 0.498f, 0.698f);
                GL.Enable(EnableCap.Blend);
                //GL.Enable(EnableCap.DepthTest);

                // 2D Ortho --------------------------
                GL.MatrixMode(MatrixMode.Projection);
                GL.PushMatrix();
                GL.LoadIdentity();

                //negative and positive on width, 0 at top to bottom ortho view
                GL.Ortho(-(double)oglMain.Width / 2, (double)oglMain.Width / 2,  (double)oglMain.Height, 0, -1, 1);
                //GL.Viewport(0, 0, Width, Height);

                //  Create the appropriate modelview matrix.
                GL.MatrixMode(MatrixMode.Modelview);
                GL.PushMatrix();
                GL.LoadIdentity();

                if (isSkyOn)
                {
                    //GL.Translate(0, 0, 0.9);
                    ////draw the background when in 3D
                    if (camera.camPitch < -60)
                    {
                        //-10 to -32 (top) is camera pitch range. Set skybox to line up with horizon 
                        double hite = (camera.camPitch + 63) * -0.026;

                        //the background
                        double winLeftPos = -(double)oglMain.Width / 2;
                        double winRightPos = -winLeftPos;
                        GL.Enable(EnableCap.Texture2D);
                        GL.BindTexture(TextureTarget.Texture2D, texture[0]);		// Select Our Texture

                        GL.Begin(PrimitiveType.TriangleStrip);				// Build Quad From A Triangle Strip
                        GL.TexCoord2(0, 0); GL.Vertex2(winRightPos, 0.0); // Top Right
                        GL.TexCoord2(1, 0); GL.Vertex2(winLeftPos, 0.0); // Top Left
                        GL.TexCoord2(0, 1); GL.Vertex2(winRightPos, hite * oglMain.Height); // Bottom Right
                        GL.TexCoord2(1, 1); GL.Vertex2(winLeftPos, hite * oglMain.Height); // Bottom Left
                        GL.End();						// Done Building Triangle Strip

                        //GL.BindTexture(TextureTarget.Texture2D, texture[3]);		// Select Our Texture
                        // GL.Translate(400, 200, 0);
                        //GL.Rotate(camHeading, 0, 0, 1);
                        //GL.Begin(PrimitiveType.TriangleStrip);				// Build Quad From A Triangle Strip
                        //GL.TexCoord2(1, 0); GL.Vertex2(0.1 * winRightPos, -0.1 * Height); // Top Right
                        //GL.TexCoord2(0, 0); GL.Vertex2(0.1 * winLeftPos, -0.1 * Height); // Top Left
                        //GL.TexCoord2(1, 1); GL.Vertex2(0.1 * winRightPos, 0.1 * Height); // Bottom Right
                        //GL.TexCoord2(0, 1); GL.Vertex2(0.1 * winLeftPos,  0.1 * Height); // Bottom Left
                        //GL.End();						// Done Building Triangle Strip

                        //disable, straight color
                        GL.Disable(EnableCap.Texture2D);
                    }
                }



                if (guidanceLineDistanceOff == 32020 || guidanceLineDistanceOff == 32000 || !isLightbarOn)
                { }
                else
                {
                    double set = guidanceLineSteerAngle * 0.01 * (100/vehicle.maxSteerAngle);
                    double actual = actualSteerAngleDisp * 0.01 * (100 / vehicle.maxSteerAngle);
                    double hiit = 0;

                    GL.PushMatrix();
                    GL.Translate(0, 120, 0);

                    //If roll is used rotate graphic based on roll angle
                    if ((ahrs.isRollBrick | ahrs.isRollDogs | ahrs.isRollPAOGI) && mc.rollRaw != 9999)
                        GL.Rotate(((mc.rollRaw - ahrs.rollZero) * 0.0625f), 0.0f, 0.0f, 1.0f);

                    GL.LineWidth(2);
                    GL.Color3(0.54f, 0.54f, 0.54f);
                    double wiid = 100;

                    GL.Begin(PrimitiveType.LineStrip);
                    GL.Vertex2(-wiid, 25);
                    GL.Vertex2(-wiid, 0);
                    GL.Vertex2(wiid, 0);
                    GL.Vertex2(wiid, 25);
                    GL.End();

                    GL.Translate(0, 10, 0);

                    if (!simulatorOnToolStripMenuItem.Checked)
                    {
                        if (actualSteerAngleDisp > 0)
                        {
                            GL.LineWidth(3);
                            GL.Begin(PrimitiveType.LineStrip);

                            GL.Color3(0.75930f, 0.75930f, 0.0f);
                            GL.Vertex2(0, hiit);
                            GL.Vertex2(actual, hiit + 15);
                            GL.Vertex2(0, hiit + 30);
                            GL.Vertex2(0, hiit);

                            GL.End();
                        }
                        else
                        {
                            //actual
                            GL.LineWidth(3);
                            GL.Begin(PrimitiveType.LineStrip);

                            GL.Color3(0.75930f, 0.75930f, 0.0f);
                            GL.Vertex2(-0, hiit);
                            GL.Vertex2(actual, hiit + 15);
                            GL.Vertex2(-0, hiit + 30);
                            GL.Vertex2(-0, hiit);

                            GL.End();
                        }
                    }

                    if (guidanceLineSteerAngle > 0)
                    {
                        GL.LineWidth(3);
                        GL.Begin(PrimitiveType.LineStrip);

                        GL.Color3(0.0f, 0.930f, 0.0f);
                        GL.Vertex2(0, hiit);
                        GL.Vertex2(set, hiit + 15);
                        GL.Vertex2(0, hiit + 30);
                        GL.Vertex2(0, hiit);

                        GL.End();
                    }
                    else
                    {
                        GL.LineWidth(3);
                        GL.Begin(PrimitiveType.LineStrip);

                        GL.Color3(0.930f, 0.50f, 0.930f);
                        GL.Vertex2(-0, hiit);
                        GL.Vertex2(set, hiit + 15);
                        GL.Vertex2(-0, hiit + 30);
                        GL.Vertex2(-0, hiit);

                        GL.End();
                    }

                    //return back
                    GL.PopMatrix();
                    GL.LineWidth(1);

                }



                //LightBar if AB Line is set and turned on or contour
                if (isLightbarOn)
                {
                    GL.Disable(EnableCap.DepthTest);
                    if (ct.isContourBtnOn)
                    {
                        string dist;
                        txtDistanceOffABLine.Visible = true;
                        //lblDelta.Visible = true;
                        if (ct.distanceFromCurrentLine == 32000) ct.distanceFromCurrentLine = 0;

                        DrawLightBar(oglMain.Width, oglMain.Height, ct.distanceFromCurrentLine * 0.1);
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
                    }

                    else if (ABLine.isABLineSet | ABLine.isABLineBeingSet)
                    {
                        string dist;
                        txtDistanceOffABLine.Visible = true;
                        //lblDelta.Visible = true;
                        DrawLightBar(oglMain.Width, oglMain.Height, ABLine.distanceFromCurrentLine * 0.1);
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
                    }

                    else if (curve.isCurveBtnOn)
                    {
                        string dist;
                        txtDistanceOffABLine.Visible = true;
                        //lblDelta.Visible = true;
                        if (curve.distanceFromCurrentLine == 32000) curve.distanceFromCurrentLine = 0;

                        DrawLightBar(oglMain.Width, oglMain.Height, curve.distanceFromCurrentLine * 0.1);
                        if ((curve.distanceFromCurrentLine) < 0.0)
                        {
                            txtDistanceOffABLine.ForeColor = Color.Green;
                            if (isMetric) dist = ((int)Math.Abs(curve.distanceFromCurrentLine * 0.1)) + " ->";
                            else dist = ((int)Math.Abs(curve.distanceFromCurrentLine / 2.54 * 0.1)) + " ->";
                            txtDistanceOffABLine.Text = dist;
                        }
                        else
                        {
                            txtDistanceOffABLine.ForeColor = Color.Red;
                            if (isMetric) dist = "<- " + ((int)Math.Abs(curve.distanceFromCurrentLine * 0.1));
                            else dist = "<- " + ((int)Math.Abs(curve.distanceFromCurrentLine / 2.54 * 0.1));
                            txtDistanceOffABLine.Text = dist;
                        }
                    }

                    else
                    {
                        txtDistanceOffABLine.Visible = false;
                    }
                }
                else
                {
                    txtDistanceOffABLine.Visible = false;
                }

                GL.Flush();//finish openGL commands
                GL.PopMatrix();//  Pop the modelview.

                //  back to the projection and pop it, then back to the model view.
                GL.MatrixMode(MatrixMode.Projection);
                GL.PopMatrix();
                GL.MatrixMode(MatrixMode.Modelview);

                //reset point size
                GL.PointSize(1.0f);
                GL.Flush();
                oglMain.SwapBuffers();

                if (leftMouseDownOnOpenGL)
                {
                    leftMouseDownOnOpenGL = false;
                    byte[] data1 = new byte[192];

                    //scan the center of click and a set of square points around
                    GL.ReadPixels(mouseX - 4, mouseY - 4, 8, 8, PixelFormat.Rgb, PixelType.UnsignedByte, data1);

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
                oglBack.Refresh();

                //draw the zoom window
                if (threeSeconds != zoomUpdateCounter && !tabControl1.Visible)
                {
                    zoomUpdateCounter = threeSeconds;
                    oglZoom.Refresh();
                }
            }
        }

        //Draw section OpenGL window, not visible
        private void oglBack_Load(object sender, EventArgs e)
        {
            oglBack.MakeCurrent();
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
            GL.PixelStore(PixelStoreParameter.PackAlignment, 1);
        }

        private void oglBack_Resize(object sender, EventArgs e)
        {
            oglBack.MakeCurrent();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            //gls.Perspective(6.0f, 1, 1, 6000);
            Matrix4 mat = Matrix4.CreatePerspectiveFieldOfView(0.104719758f, 1f, 1f, 6000f);
            GL.LoadMatrix(ref mat);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        private void oglBack_Paint(object sender, PaintEventArgs e)
        {
            oglBack.MakeCurrent();

            GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();					// Reset The View

            //back the camera up
            GL.Translate(0, 0, -480);

            //rotate camera so heading matched fix heading in the world
            GL.Rotate(glm.toDegrees(toolPos.heading), 0, 0, 1);

            //translate to that spot in the world 
            GL.Translate(-toolPos.easting, -toolPos.northing, 0);

            //patch color
            GL.Color3(0.0f, 0.5f, 0.0f);

            //calculate the frustum for the section control window
            CalcFrustum();

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
                            //draw the triangles in each triangle strip
                            GL.Begin(PrimitiveType.TriangleStrip);
                            for (int i = 0; i < count2; i++) GL.Vertex3(triList[i].easting, triList[i].northing, 0);
                            GL.End();
                        }
                    }
                }
            }

            //draw bright green on back buffer
            if (bnd.bndArr[0].isSet)
            {
                ////draw the perimeter line so far
                int ptCount = bnd.bndArr[0].bndLine.Count;
                if (ptCount > 1)
                {
                    GL.LineWidth(2);                
                    GL.Color3(0.0f, 0.99f, 0.0f);
                    GL.Begin(PrimitiveType.LineStrip);
                    for (int h = 0; h < ptCount; h++) GL.Vertex3(bnd.bndArr[0].bndLine[h].easting, bnd.bndArr[0].bndLine[h].northing, 0);
                    GL.End();
                }
            }

            GL.Flush();

            //Paint to context
            oglBack.SwapBuffers();

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
            if (rpHeight > 245) rpHeight = 245;
            if (rpHeight < 8) rpHeight = 8;

            //read the whole block of pixels up to max lookahead, one read only
            GL.ReadPixels(vehicle.rpXPosition, 252, vehicle.rpWidth, (int)rpHeight, OpenTK.Graphics.OpenGL.PixelFormat.Green, PixelType.UnsignedByte, grnPixels);
            
            //10 % min is required for overlap, otherwise it never would be on.
            int pixLimit = (int)((double)(vehicle.rpWidth * rpHeight) / (double)(vehicle.numOfSections * 1.5));

            //is applied area coming up?
            int totalPixs = 0;
            if (vehicle.isSuperSectionAllowedOn)
            {
                //look for anything applied coming up
                for (int a = 0; a < (vehicle.rpWidth * rpHeight); a++)
                {
                    if (grnPixels[a] != 0)
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

                        if (bnd.bndArr[0].isSet)
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
                    if (pn.speed < vehicle.slowSpeedCutoff )
                    {
                        section[j].sectionOnRequest = false;
                        section[j].sectionOffRequest = true;
                    }
                }
            }

        //Checks the workswitch if required
	    if (isJobStarted && mc.isWorkSwitchEnabled) { workSwitch.CheckWorkSwitch(); }

            //Determine if sections want to be on or off
            ProcessSectionOnOffRequests();

            //send the byte out to section relays
            BuildRelayByte();

            //if a couple minute has elapsed save the field in case of crash and to be able to resume            
            if (saveCounter > 59)       //2 counts per second X 60 seconds = 120 counts per minute.
            {
                if (isJobStarted && stripOnlineGPS.Value != 1)
                {
                    //auto save the field patches, contours accumulated so far
                    FileSaveSections();
                    FileSaveContour();

                    //NMEA log file
                    if (isLogNMEA) FileSaveNMEA();
                }
                saveCounter = 0;
            }
            //this is the end of the "frame". Now we wait for next NMEA sentence. 
        }

        private void oglZoom_Load(object sender, EventArgs e)
        {
            oglZoom.MakeCurrent();
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
            GL.ClearColor(0.23122f, 0.2318f, 0.2315f, 1.0f);
        }

        private void oglZoom_Resize(object sender, EventArgs e)
        {
            oglZoom.MakeCurrent();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            //58 degrees view
            Matrix4 mat = Matrix4.CreatePerspectiveFieldOfView(1.01f, 1.0f, 1.0f, 20000);
            GL.LoadMatrix(ref mat);

            GL.MatrixMode(MatrixMode.Modelview);
        }

        private int zoomUpdateCounter = 0;

        private void oglZoom_Paint(object sender, PaintEventArgs e)
        {
            oglZoom.MakeCurrent();

            GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();                  // Reset The View

            CalculateMinMax();

            //back the camera up
            GL.Translate(0, 0, -maxFieldDistance);

            //translate to that spot in the world 
            GL.Translate(-fieldCenterX, -fieldCenterY, 0);

            GL.Color3(redSections, grnSections, bluSections);

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
                        //draw the triangle in each triangle strip
                        GL.Begin(PrimitiveType.TriangleStrip);
                        int count2 = triList.Count;
                        int mipmap = 16;

                        //if large enough patch and camera zoomed out, fake mipmap the patches, skip triangles
                        if (count2 >= (mipmap))
                        {
                            int step = mipmap;
                            for (int i = 0; i < count2; i += step)
                            {
                                GL.Vertex3(triList[i].easting, triList[i].northing, 0); i++;
                                GL.Vertex3(triList[i].easting, triList[i].northing, 0); i++;

                                //too small to mipmap it
                                if (count2 - i <= (mipmap + 2))
                                    step = 0;
                            }
                        }

                        else { for (int i = 0; i < count2; i++) GL.Vertex3(triList[i].easting, triList[i].northing, 0); }
                        GL.End();

                    }
                }
            } //end of section patches

            //draw the ABLine
            if (ABLine.isABLineSet | ABLine.isABLineBeingSet)
            {
                //Draw reference AB line
                GL.LineWidth(1);
                GL.Enable(EnableCap.LineStipple);
                GL.LineStipple(1, 0x00F0);

                GL.Begin(PrimitiveType.Lines);
                GL.Color3(0.9f, 0.5f, 0.7f);
                GL.Vertex3(ABLine.refABLineP1.easting, ABLine.refABLineP1.northing, 0);
                GL.Vertex3(ABLine.refABLineP2.easting, ABLine.refABLineP2.northing, 0);
                GL.End();
                GL.Disable(EnableCap.LineStipple);

                //raw current AB Line
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(0.9f, 0.0f, 0.0f);
                GL.Vertex3(ABLine.currentABLineP1.easting, ABLine.currentABLineP1.northing, 0.0);
                GL.Vertex3(ABLine.currentABLineP2.easting, ABLine.currentABLineP2.northing, 0.0);
                GL.End();
            }

            //draw curve if there is one
            if (curve.isCurveSet)
            {
                int ptC = curve.curList.Count;
                if (ptC > 0)
                {
                    GL.LineWidth(2);
                    GL.Color3(0.95f, 0.2f, 0.0f);
                    GL.Begin(PrimitiveType.LineStrip);
                    for (int h = 0; h < ptC; h++) GL.Vertex3(curve.curList[h].easting, curve.curList[h].northing, 0);
                    GL.End();
                }
            }

            //draw all the boundaries
            bnd.DrawBoundaryLines();

            GL.PointSize(8.0f);
            GL.Begin(PrimitiveType.Points);
            GL.Color3(0.95f, 0.90f, 0.0f);
            GL.Vertex3(pivotAxlePos.easting, pivotAxlePos.northing, 0.0);
            GL.End();
            GL.PointSize(1.0f);

            GL.Flush();
            oglZoom.SwapBuffers();
        }    

        public void DrawLightBar(double Width, double Height, double offlineDistance)
        {
            double down = 20;
            GL.LineWidth(1);
            //GL.Translate(0, 0, 0.01);
            
            //  Dot distance is representation of how far from AB Line
            int dotDistance = (int)(offlineDistance);
            int limit = (int)lightbarCmPerPixel * 13;
            if (dotDistance < -limit) dotDistance = -limit;
            if (dotDistance > limit) dotDistance = limit;

            //if (dotDistance < -10) dotDistance -= 30;
            //if (dotDistance > 10) dotDistance += 30;

            // dot background
            GL.PointSize(8.0f);
            GL.Color3(0.00f, 0.0f, 0.0f);
            GL.Begin(PrimitiveType.Points);
            for (int i = -13; i < 0; i++) GL.Vertex2((i * 32), down);
            for (int i = 1; i < 14; i++) GL.Vertex2((i * 32), down);
            GL.End();

            GL.PointSize(4.0f);

            //GL.Translate(0, 0, 0.01);
            //red left side
            GL.Color3(0.9750f, 0.0f, 0.0f);
            GL.Begin(PrimitiveType.Points);
            for (int i = -13; i < 0; i++) GL.Vertex2((i * 32), down);

            //green right side
            GL.Color3(0.0f, 0.9750f, 0.0f);
            for (int i = 1; i < 14; i++) GL.Vertex2((i * 32), down);
            GL.End();

            //Are you on the right side of line? So its green.
            //GL.Translate(0, 0, 0.01);
            if ((offlineDistance) < 0.0)
                {
                    int dots = (dotDistance * -1 / lightbarCmPerPixel);

                    GL.PointSize(24.0f);
                    GL.Color3(0.0f, 0.0f, 0.0f);
                    GL.Begin(PrimitiveType.Points);
                    for (int i = 1; i < dots + 1; i++) GL.Vertex2((i * 32), down);
                    GL.End();

                    GL.PointSize(16.0f);
                    GL.Color3(0.0f, 0.980f, 0.0f);
                    GL.Begin(PrimitiveType.Points);
                    for (int i = 0; i < dots; i++) GL.Vertex2((i * 32 + 32), down);
                    GL.End();
                    //return;
                }

                else
                {
                    int dots = (int)(dotDistance / lightbarCmPerPixel);

                    GL.PointSize(24.0f);
                    GL.Color3(0.0f, 0.0f, 0.0f);
                    GL.Begin(PrimitiveType.Points);
                    for (int i = 1; i < dots + 1; i++) GL.Vertex2((i * -32), down);
                    GL.End();

                    GL.PointSize(16.0f);
                    GL.Color3(0.980f, 0.30f, 0.0f);
                    GL.Begin(PrimitiveType.Points);
                    for (int i = 0; i < dots; i++) GL.Vertex2((i * -32 - 32), down);
                    GL.End();
                    //return;
                }
            
            //yellow center dot
            if (dotDistance >= -lightbarCmPerPixel && dotDistance <= lightbarCmPerPixel)
            {
                GL.PointSize(32.0f);                
                GL.Color3(0.0f, 0.0f, 0.0f);
                GL.Begin(PrimitiveType.Points);
                GL.Vertex2(0, down);
                //GL.Vertex(0, down + 50);
                GL.End();

                GL.PointSize(24.0f);
                GL.Color3(0.980f, 0.98f, 0.0f);
                GL.Begin(PrimitiveType.Points);
                GL.Vertex2(0, down);
                //GL.Vertex(0, down + 50);
                GL.End();
            }

            else
            {

                GL.PointSize(8.0f);
                GL.Color3(0.00f, 0.0f, 0.0f);
                GL.Begin(PrimitiveType.Points);
                GL.Vertex2(-0, down);
                //GL.Vertex(0, down + 30);
                //GL.Vertex(0, down + 60);
                GL.End();

                //gl.PointSize(4.0f);
                //gl.Color3(0.9250f, 0.9250f, 0.250f);
                //gl.Begin(PrimitiveType.Points);
                //gl.Vertex(0, down);
                //gl.Vertex(0, down + 30);
                //gl.Vertex(0, down + 60);
                //gl.End();
            }
        }

        public void CalcFrustum()
        {
            float[] proj = new float[16];							// For Grabbing The PROJECTION Matrix
            float[] modl = new float[16];							// For Grabbing The MODELVIEW Matrix
            float[] clip = new float[16];							// Result Of Concatenating PROJECTION and MODELVIEW

            GL.GetFloat(GetPName.ProjectionMatrix, proj);	// Grab The Current PROJECTION Matrix
            GL.GetFloat(GetPName.Modelview0MatrixExt, modl);   // Grab The Current MODELVIEW Matrix  
            
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

            // Extract the LEFT clipping plane
            frustum[4] = clip[3] + clip[0];
            frustum[5] = clip[7] + clip[4];
            frustum[6] = clip[11] + clip[8];
            frustum[7] = clip[15] + clip[12];

            // Extract the FAR clipping plane
            frustum[8] = clip[3] - clip[2];
            frustum[9] = clip[7] - clip[6];
            frustum[10] = clip[11] - clip[10];
            frustum[11] = clip[15] - clip[14];


            // Extract the NEAR clipping plane.  This is last on purpose (see pointinfrustum() for reason)
            frustum[12] = clip[3] + clip[2];
            frustum[13] = clip[7] + clip[6];
            frustum[14] = clip[11] + clip[10];
            frustum[15] = clip[15] + clip[14];

            // Extract the BOTTOM clipping plane
            frustum[16] = clip[3] + clip[1];
            frustum[17] = clip[7] + clip[5];
            frustum[18] = clip[11] + clip[9];
            frustum[19] = clip[15] + clip[13];

            // Extract the TOP clipping plane
            frustum[20] = clip[3] - clip[1];
            frustum[21] = clip[7] - clip[5];
            frustum[22] = clip[11] - clip[9];
            frustum[23] = clip[15] - clip[13];
        }

        public double maxFieldX, maxFieldY, minFieldX, minFieldY, fieldCenterX, fieldCenterY, maxFieldDistance;
        //determine mins maxs of patches and whole field.
        public void CalculateMinMax()
        {

            minFieldX = 9999999; minFieldY = 9999999;
            maxFieldX = -9999999; maxFieldY = -9999999;


            //min max of the boundary
            //min max of the boundary
            if (bnd.bndArr[0].isSet)
            {
                int bndCnt = bnd.bndArr[0].bndLine.Count;
                for (int i = 0; i < bndCnt; i++)
                {
                    double x = bnd.bndArr[0].bndLine[i].easting;
                    double y = bnd.bndArr[0].bndLine[i].northing;

                    //also tally the max/min of field x and z
                    if (minFieldX > x) minFieldX = x;
                    if (maxFieldX < x) maxFieldX = x;
                    if (minFieldY > y) minFieldY = y;
                    if (maxFieldY < y) maxFieldY = y;
                }

            }
            else
            {
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

            //minFieldX -= 8;
            //minFieldY -= 8;
            //maxFieldX += 8;
            //maxFieldY += 8;

            if (isMetric)
            {
                lblFieldWidthEastWest.Text = Math.Abs((maxFieldX - minFieldX)).ToString("N0") + " m";
                lblFieldWidthNorthSouth.Text = Math.Abs((maxFieldY - minFieldY)).ToString("N0") + " m";
            }
            else
            {
                lblFieldWidthEastWest.Text = Math.Abs((maxFieldX - minFieldX) * glm.m2ft).ToString("N0") + " ft";
                lblFieldWidthNorthSouth.Text = Math.Abs((maxFieldY - minFieldY) * glm.m2ft).ToString("N0") + " ft";
            }

            //lblZooom.Text = ((int)(maxFieldDistance)).ToString();

        }
    }
}
