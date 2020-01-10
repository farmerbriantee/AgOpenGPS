
using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace AgOpenGPS
{
    public partial class FormGPS
    {
        //extracted Near, Far, Right, Left clipping planes of frustum
        public double[] frustum = new double[24];

        private bool isInit = false;
        private double fovy = 0.7;
        private double camDistanceFactor = -2;

        int mouseX = 0, mouseY = 0;
        public double offX, offY;
        public double lookaheadActual, test2;
        private int zoomUpdateCounter = 0;

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
                10.0f, (float)(camDistanceFactor * camera.camSetDistance));
            GL.LoadMatrix(ref mat);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        //oglMain rendering, Draw

        StringBuilder sb = new StringBuilder();
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

                //position the camera
                camera.SetWorldCam(pivotAxlePos.easting + offX, pivotAxlePos.northing + offY, camHeading);

                //the bounding box of the camera for cullling.
                CalcFrustum();
                worldGrid.DrawFieldSurface();

                ////if grid is on draw it
                if (isGridOn) worldGrid.DrawWorldGrid(camera.gridZoom);

                //section patch color
                if (isDay) GL.Color4(sectionColorDay.R, sectionColorDay.G, sectionColorDay.B, (byte)152);
                else GL.Color4(sectionColorNight.R, sectionColorNight.G, sectionColorNight.B, (byte)152);

                if (isDrawPolygons) GL.PolygonMode(MaterialFace.Front, PolygonMode.Line);

                GL.Enable(EnableCap.Blend);
                //draw patches of sections

                for (int j = 0; j < tool.numSuperSection; j++)
                {
                    //every time the section turns off and on is a new patch

                    //check if in frustum or not
                    bool isDraw;

                    int patches = section[j].patchList.Count;

                    if (patches > 0)
                    {
                        //initialize the steps for mipmap of triangles (skipping detail while zooming out)
                        int mipmap = 0;
                        if (camera.camSetDistance < -800) mipmap = 2;
                        if (camera.camSetDistance < -1500) mipmap = 4;
                        if (camera.camSetDistance < -2400) mipmap = 8;
                        if (camera.camSetDistance < -5000) mipmap = 16;

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


                // the follow up to sections patches
                int patchCount = 0;

                if (autoBtnState == btnStates.Auto || manualBtnState == btnStates.On)
                {
                    if (section[tool.numOfSections].isSectionOn && section[tool.numOfSections].patchList.Count> 0)
                    {
                        patchCount = section[tool.numOfSections].patchList.Count;
                        //draw the triangle in each triangle strip
                        GL.Begin(PrimitiveType.TriangleStrip);

                        //left side of triangle
                        vec2 pt = new vec2((cosSectionHeading * section[tool.numOfSections].positionLeft) + toolPos.easting,
                                (sinSectionHeading * section[tool.numOfSections].positionLeft) + toolPos.northing);

                        GL.Vertex3(pt.easting, pt.northing, 0);
                        label3.Text = pt.northing.ToString();

                        //Right side of triangle
                        pt = new vec2((cosSectionHeading * section[tool.numOfSections].positionRight) + toolPos.easting,
                           (sinSectionHeading * section[tool.numOfSections].positionRight) + toolPos.northing);

                        GL.Vertex3(pt.easting, pt.northing, 0);

                        int last = section[tool.numOfSections].patchList[patchCount - 1].Count;
                        //antenna
                        GL.Vertex3(section[tool.numOfSections].patchList[patchCount - 1][last - 2].easting, section[tool.numOfSections].patchList[patchCount - 1][last - 2].northing, 0);
                        GL.Vertex3(section[tool.numOfSections].patchList[patchCount - 1][last - 1].easting, section[tool.numOfSections].patchList[patchCount - 1][last - 1].northing, 0);
                        label4.Text = section[tool.numOfSections].patchList[patchCount - 1][last - 2].northing.ToString();
                        GL.End();
                    }
                    else
                    {
                        for (int j = 0; j < tool.numSuperSection; j++)
                        {
                            if (section[j].isSectionOn && section[j].patchList.Count > 0)
                            {
                                patchCount = section[j].patchList.Count;

                                //draw the triangle in each triangle strip
                                GL.Begin(PrimitiveType.TriangleStrip);

                                //left side of triangle
                                vec2 pt = new vec2((cosSectionHeading * section[j].positionLeft) + toolPos.easting,
                                        (sinSectionHeading * section[j].positionLeft) + toolPos.northing);

                                GL.Vertex3(pt.easting, pt.northing, 0);
                                label3.Text = pt.northing.ToString();

                                //Right side of triangle
                                pt = new vec2((cosSectionHeading * section[j].positionRight) + toolPos.easting,
                                   (sinSectionHeading * section[j].positionRight) + toolPos.northing);

                                GL.Vertex3(pt.easting, pt.northing, 0);

                                int last = section[j].patchList[patchCount - 1].Count;
                                //antenna
                                GL.Vertex3(section[j].patchList[patchCount - 1][last - 2].easting, section[j].patchList[patchCount - 1][last - 2].northing, 0);
                                GL.Vertex3(section[j].patchList[patchCount - 1][last - 1].easting, section[j].patchList[patchCount - 1][last - 1].northing, 0);
                                label4.Text = section[j].patchList[patchCount - 1][last - 2].northing.ToString();
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
                    if (curve.isBtnCurveOn) curve.DrawCurve();
                }

                //if (recPath.isRecordOn)
                recPath.DrawRecordedLine();
                recPath.DrawDubins();

                //draw Boundaries
                bnd.DrawBoundaryLines();

                //draw the turnLines
                if (yt.isYouTurnBtnOn)
                {
                    if (!ABLine.isEditing && !curve.isEditing && !ct.isContourBtnOn)
                    {
                        turn.DrawTurnLines();
                    }
                }
                else if (!yt.isYouTurnBtnOn && isUTurnAlwaysOn)
                {
                    if (!ABLine.isEditing && !curve.isEditing && !ct.isContourBtnOn)
                    {
                        turn.DrawTurnLines();
                    }
                }

                if (mc.isOutOfBounds) gf.DrawGeoFenceLines();

                if (hd.isOn) hd.DrawHeadLines();

                if (flagPts.Count > 0) DrawFlags();

                //Direct line to flag if flag selected
                if(flagNumberPicked > 0)
                {
                    GL.LineWidth(ABLine.lineWidth);
                    GL.Enable(EnableCap.LineStipple);
                    GL.LineStipple(1, 0x0707);
                    GL.Begin(PrimitiveType.Lines);
                    GL.Color3(0.930f, 0.72f, 0.32f);
                    GL.Vertex3(pivotAxlePos.easting, pivotAxlePos.northing, 0);
                    GL.Vertex3(flagPts[flagNumberPicked-1].easting, flagPts[flagNumberPicked-1].northing, 0);
                    GL.End();
                    GL.Disable(EnableCap.LineStipple);
                }

                //if (flagDubinsList.Count > 1)
                //{
                //    //GL.LineWidth(2);
                //    GL.PointSize(2);
                //    GL.Color3(0.298f, 0.96f, 0.2960f);
                //    GL.Begin(PrimitiveType.Points);
                //    for (int h = 0; h < flagDubinsList.Count; h++)
                //        GL.Vertex3(flagDubinsList[h].easting, flagDubinsList[h].northing, 0);
                //    GL.End();
                //}

                //draw the vehicle/implement
                tool.DrawTool();
                vehicle.DrawVehicle();

                // 2D Ortho ---------------------------------------////////-------------------------------------------------
                
                GL.MatrixMode(MatrixMode.Projection);
                GL.PushMatrix();
                GL.LoadIdentity();

                //negative and positive on width, 0 at top to bottom ortho view
                GL.Ortho(-(double)oglMain.Width / 2, (double)oglMain.Width / 2, (double)oglMain.Height, 0, -1, 1);

                //  Create the appropriate modelview matrix.
                GL.MatrixMode(MatrixMode.Modelview);
                GL.PushMatrix();
                GL.LoadIdentity();

                if (isSkyOn) DrawSky();

                //LightBar if AB Line is set and turned on or contour
                if (isLightbarOn)
                {
                    DrawRollBar();
                    DrawLightBarText();
                }

                if (bnd.bndArr.Count > 0 && yt.isYouTurnBtnOn) DrawUTurnBtn();

                if (isAutoSteerBtnOn && !ct.isContourBtnOn) DrawManUTurnBtn();

                if (isCompassOn) DrawCompass();

                DrawCompassText();

                if (isSpeedoOn) DrawSpeedo();

                //if (isJobStarted) DrawFieldText();

                GL.Flush();//finish openGL commands
                GL.PopMatrix();//  Pop the modelview.

                ////-------------------------------------------------ORTHO END---------------------------------------
                
                //  back to the projection and pop it, then back to the model view.
                GL.MatrixMode(MatrixMode.Projection);
                GL.PopMatrix();
                GL.MatrixMode(MatrixMode.Modelview);

                //reset point size
                GL.PointSize(1.0f);
                GL.Flush();
                oglMain.SwapBuffers();

                if (leftMouseDownOnOpenGL) MakeFlagMark();

                //draw the section control window off screen buffer
                oglBack.Refresh();

                //draw the zoom window
                if (isJobStarted)
                {
                    if (threeSeconds != zoomUpdateCounter)
                    {
                        zoomUpdateCounter = threeSeconds;
                        oglZoom.Refresh();
                    }
                }
                //else oglZoom.Refresh();
            }
        }

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
            //gls.Perspective(6.0f, 1, 1, 5200);
            Matrix4 mat = Matrix4.CreatePerspectiveFieldOfView(0.104719758f, 1f, 50.0f, 520f);
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
            for (int j = 0; j < tool.numSuperSection; j++)
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
            if (bnd.bndArr.Count > 0)
            {
                ////draw the bnd line 
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

            //int ptCount = hdArr.hdLine.Count;
            //GL.LineWidth(1);
            //GL.Color3(0.96555f, 0.9232f, 0.50f);
            ////GL.PointSize(4);
            //GL.Begin(PrimitiveType.LineStrip);
            //for (int h = 0; h < ptCount; h++) GL.Vertex3(hdLine[h].easting, hdLine[h].northing, 0);
            //GL.Vertex3(hdLine[0].easting, hdLine[0].northing, 0);
            //GL.End();

            GL.Flush();

            //determine farthest ahead lookahead - is the height of the readpixel line
            double rpHeight = 0;

            //assume all sections are on and super can be on, if not set false to turn off.
            tool.isSuperSectionAllowedOn = true;

            //find any off buttons, any outside of boundary, going backwards, and the farthest lookahead
            for (int j = 0; j < tool.numOfSections; j++)
            {
                if (section[j].sectionLookAhead > rpHeight) rpHeight = section[j].sectionLookAhead;
                if (section[j].manBtnState == manBtn.Off) tool.isSuperSectionAllowedOn = false;
                if (!section[j].isInsideBoundary) tool.isSuperSectionAllowedOn = false;

                //check if any sections going backwards
                if (section[j].sectionLookAhead < 0) tool.isSuperSectionAllowedOn = false;
            }

            //if only one section, or going slow no need for super section 
            if (tool.numOfSections == 1 | pn.speed < vehicle.slowSpeedCutoff)
                tool.isSuperSectionAllowedOn = false;

            //clamp the height after looking way ahead, this is for switching off super section only
            rpHeight = Math.Abs(rpHeight) * 2.0;
            if (rpHeight > 245) rpHeight = 245;
            if (rpHeight < 8) rpHeight = 8;

            //read the whole block of pixels up to max lookahead, one read only
            GL.ReadPixels(tool.rpXPosition, 252, tool.rpWidth, (int)rpHeight, OpenTK.Graphics.OpenGL.PixelFormat.Green, PixelType.UnsignedByte, grnPixels);

            //Paint to context
            //oglBack.MakeCurrent();
            //oglBack.SwapBuffers();

            //10 % min is required for overlap, otherwise it never would be on.
            int pixLimit = (int)((double)(tool.rpWidth * rpHeight) / (double)(tool.numOfSections * 1.5));

            //is applied area coming up?
            int totalPixs = 0;
            if (tool.isSuperSectionAllowedOn)
            {
                //look for anything applied coming up
                for (int a = 0; a < (tool.rpWidth * rpHeight); a++)
                {
                    if (grnPixels[a] != 0)
                    {
                        if (totalPixs++ > pixLimit)
                        {
                            tool.isSuperSectionAllowedOn = false;
                            break;
                        }

                        //check for a boundary line
                        if (grnPixels[a] > 200)
                        {
                            tool.isSuperSectionAllowedOn = false;
                            break;
                        }
                    }
                }
            }


            // If ALL sections are required on, No buttons are off, within boundary, turn super section on, normal sections off
            if (tool.isSuperSectionAllowedOn)
            {
                for (int j = 0; j < tool.numOfSections; j++)
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
                section[tool.numOfSections].sectionOnRequest = true;
                section[tool.numOfSections].sectionOffRequest = false;
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

                for (int j = 0; j < tool.numOfSections; j++)
                {
                    //is section going backwards?
                    if (section[j].sectionLookAhead > 0)
                    {
                        //If any nowhere applied, send OnRequest, if its all green send an offRequest
                        section[j].isSectionRequiredOn = false;

                        if (bnd.bndArr.Count > 0)
                        {

                            int start = 0, end = 0, skip = 0;
                            start = section[j].rpSectionPosition - section[0].rpSectionPosition;
                            end = section[j].rpSectionWidth - 1 + start;
                            if (end > tool.rpWidth - 1) end = tool.rpWidth - 1;
                            skip = tool.rpWidth - (end - start);


                            int tagged = 0;
                            for (int h = 0; h < (int)section[j].sectionLookAhead; h++)
                            {
                                for (int a = start; a < end; a++)
                                {
                                    if (grnPixels[a] == 0)
                                    {
                                        if (tagged++ > tool.toolMinUnappliedPixels)
                                        {
                                            section[j].isSectionRequiredOn = true;
                                            goto GetMeOutaHere;
                                        }
                                    }
                                }

                                start += tool.rpWidth;
                                end += tool.rpWidth;
                            }

                        //minimum apllied conditions met
                        GetMeOutaHere:

                            start = 0; end = 0; skip = 0;
                            start = section[j].rpSectionPosition - section[0].rpSectionPosition;
                            end = section[j].rpSectionWidth - 1 + start;
                            if (end > tool.rpWidth - 1) end = tool.rpWidth - 1;
                            skip = tool.rpWidth - (end - start);

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

                                start += tool.rpWidth;
                                end += tool.rpWidth;
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
                            if (end > tool.rpWidth - 1) end = tool.rpWidth - 1;
                            skip = tool.rpWidth - (end - start);


                            int tagged = 0;
                            for (int h = 0; h < (int)section[j].sectionLookAhead; h++)
                            {
                                for (int a = start; a < end; a++)
                                {
                                    if (grnPixels[a] == 0)
                                    {
                                        if (tagged++ > tool.toolMinUnappliedPixels)
                                        {
                                            section[j].isSectionRequiredOn = true;
                                            goto GetMeOutaHere;
                                        }
                                    }
                                }

                                start += tool.rpWidth;
                                end += tool.rpWidth;
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
                if (section[tool.numOfSections].isSectionOn)
                {
                    section[tool.numOfSections].sectionOffRequest = true;
                    section[tool.numOfSections].sectionOnRequest = false;
                    section[tool.numOfSections].sectionOffTimer = 0;
                    section[tool.numOfSections].sectionOnTimer = 0;
                }

                //if Master Auto is on
                for (int j = 0; j < tool.numOfSections; j++)
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
                }
            }

            //Checks the workswitch if required
            if (isJobStarted && mc.isWorkSwitchEnabled)
            {
                workSwitch.CheckWorkSwitch();
            }

            //Determine if sections want to be on or off
            ProcessSectionOnOffRequests();

            //send the byte out to section relays
            BuildRelayByte();

            //send the relay out to port
            RelayOutToPort(mc.relayData, CModuleComm.pgnSentenceLength);

            //if a couple minute has elapsed save the field in case of crash and to be able to resume            
            if (saveCounter > 59)       //2 counts per second X 52 seconds = 120 counts per minute.
            {
                tmrWatchdog.Enabled = false;

                if (isJobStarted && toolStripBtnGPSStength.Image.Height == 63)
                {
                    //auto save the field patches, contours accumulated so far
                    FileSaveSections();
                    FileSaveContour();

                    //NMEA log file
                    if (isLogNMEA) FileSaveNMEA();
                    if (isLogElevation) FileSaveElevation();
                }

                if (isAutoDayNight)
                {
                    isDayTime = (DateTime.Now.Ticks < sunset.Ticks && DateTime.Now.Ticks > sunrise.Ticks);

                    if (isDayTime != isDay)
                    {
                        isDay = isDayTime;
                        isDay = !isDay;
                        SwapDayNightMode();
                    }

                    if (sunrise.Date != DateTime.Today)
                    {
                        IsBetweenSunriseSunset(pn.latitude, pn.longitude);

                        //set display accordingly
                        isDayTime = (DateTime.Now.Ticks < sunset.Ticks && DateTime.Now.Ticks > sunrise.Ticks);

                        lblSunrise.Text = sunrise.ToString("HH:mm");
                        lblSunset.Text = sunset.ToString("HH:mm");
                    }

                }

                //if its the next day, calc sunrise sunset for next day
                saveCounter = 0;

                //set saving flag off
                isSavingFile = false;

                //go see if data ready for draw and position updates
                tmrWatchdog.Enabled = true;


            }
            //this is the end of the "frame". Now we wait for next NMEA sentence. 
        }

        private void oglZoom_Load(object sender, EventArgs e)
        {
            oglZoom.MakeCurrent();
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);
            GL.PixelStore(PixelStoreParameter.PackAlignment, 1);

            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.ClearColor(0, 0, 0, 1.0f);
        }

        private void oglZoom_Resize(object sender, EventArgs e)
        {
            oglZoom.MakeCurrent();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            GL.Viewport(0, 0, oglZoom.Width, oglZoom.Height);
            //58 degrees view
            Matrix4 mat = Matrix4.CreatePerspectiveFieldOfView(1.01f, 1.0f, 100.0f, 5000.0f);
            GL.LoadMatrix(ref mat);

            GL.MatrixMode(MatrixMode.Modelview);
        }

        private void oglZoom_Paint(object sender, PaintEventArgs e)
        {
            oglZoom.MakeCurrent();

            if (isJobStarted)
            {
                GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
                GL.LoadIdentity();                  // Reset The View

                CalculateMinMax();
                //back the camera up
                GL.Translate(0, 0, -maxFieldDistance);
                GL.Enable(EnableCap.Blend);

                //translate to that spot in the world 
                GL.Translate(-fieldCenterX, -fieldCenterY, 0);

                GL.Color4(0.5, 0.5, 0.5, 0.5);
                //draw patches j= # of sections
                int count2;

                for (int j = 0; j < tool.numSuperSection; j++)
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
                            count2 = triList.Count;
                            //int mipmap = 2;

                            ////if large enough patch and camera zoomed out, fake mipmap the patches, skip triangles
                            //if (count2 >= (mipmap))
                            //{
                            //    int step = mipmap;
                            //    for (int i = 0; i < count2; i += step)
                            //    {
                            //        GL.Vertex3(triList[i].easting, triList[i].northing, 0); i++;
                            //        GL.Vertex3(triList[i].easting, triList[i].northing, 0); i++;

                            //        //too small to mipmap it
                            //        if (count2 - i <= (mipmap + 2))
                            //            step = 0;
                            //    }
                            //}

                            //else 
                            //{
                                for (int i = 0; i < count2; i++) GL.Vertex3(triList[i].easting, triList[i].northing, 0); 
                            //}
                            GL.End();

                        }
                    }
                } //end of section patches

                GL.Flush();

                int grnHeight = oglZoom.Height;
                int grnWidth = oglZoom.Width;
                byte[] overPix = new byte[grnHeight * grnWidth + 1];

                GL.ReadPixels(0, 0, grnWidth, grnWidth, OpenTK.Graphics.OpenGL.PixelFormat.Green, PixelType.UnsignedByte, overPix);

                int once = 0;
                int twice = 0;
                int more = 0;
                int level = 0;
                double total = 0;
                double total2 = 0;

                //50, 96, 112                
                for (int i = 0; i < grnHeight * grnWidth; i++)
                {

                    if (overPix[i] > 105)
                    {
                        more++;
                        level = overPix[i];
                    }
                    else if (overPix[i] > 85)
                    {
                        twice++;
                        level = overPix[i];
                    }
                    else if (overPix[i] > 50)
                    {
                        once++;
                    }
                }
                total = once + twice + more;
                total2 = total + twice + more + more;

                if (total2 > 0)
                {
                    fd.actualAreaCovered = (total / total2 * fd.workedAreaTotal);
                    fd.overlapPercent = Math.Round(((1 - total / total2) * 100), 2);
                }
                else
                {
                    fd.actualAreaCovered = fd.overlapPercent = 0;
                }

                //GL.Flush();
                //oglZoom.MakeCurrent();
                //oglZoom.SwapBuffers();

                if (oglZoom.Width != 400)
                {
                    GL.Disable(EnableCap.Blend);

                    GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
                    GL.LoadIdentity();                  // Reset The View

                    //back the camera up
                    GL.Translate(0, 0, -maxFieldDistance);

                    //translate to that spot in the world 
                    GL.Translate(-fieldCenterX, -fieldCenterY, 0);

                    if (isDay) GL.Color3(fieldColorDay.R, fieldColorDay.G, fieldColorDay.B);
                    else GL.Color3(fieldColorNight.R, fieldColorNight.G, fieldColorNight.B);

                    int cnt, step, patchCount;
                    int mipmap = 8;

                    //draw patches j= # of sections
                    for (int j = 0; j < tool.numSuperSection; j++)
                    {
                        //every time the section turns off and on is a new patch
                        patchCount = section[j].patchList.Count;

                        if (patchCount > 0)
                        {
                            //for every new chunk of patch
                            foreach (var triList in section[j].patchList)
                            {
                                //draw the triangle in each triangle strip
                                GL.Begin(PrimitiveType.TriangleStrip);
                                cnt = triList.Count;

                                //if large enough patch and camera zoomed out, fake mipmap the patches, skip triangles
                                if (cnt >= (mipmap))
                                {
                                    step = mipmap;
                                    for (int i = 0; i < cnt; i += step)
                                    {
                                        GL.Vertex3(triList[i].easting, triList[i].northing, 0); i++;
                                        GL.Vertex3(triList[i].easting, triList[i].northing, 0); i++;

                                        //too small to mipmap it
                                        if (cnt - i <= (mipmap + 2))
                                            step = 0;
                                    }
                                }

                                else { for (int i = 0; i < cnt; i++) GL.Vertex3(triList[i].easting, triList[i].northing, 0); }
                                GL.End();

                            }
                        }
                    } //end of section patches

                    //draw the ABLine
                    if ((ABLine.isABLineSet | ABLine.isABLineBeingSet) && ABLine.isBtnABLineOn)
                    {
                        //Draw reference AB line
                        GL.LineWidth(1);
                        GL.Enable(EnableCap.LineStipple);
                        GL.LineStipple(1, 0x00F0);

                        GL.Begin(PrimitiveType.Lines);
                        GL.Color3(0.9f, 0.2f, 0.2f);
                        GL.Vertex3(ABLine.refABLineP1.easting, ABLine.refABLineP1.northing, 0);
                        GL.Vertex3(ABLine.refABLineP2.easting, ABLine.refABLineP2.northing, 0);
                        GL.End();
                        GL.Disable(EnableCap.LineStipple);

                        //raw current AB Line
                        GL.Begin(PrimitiveType.Lines);
                        GL.Color3(0.9f, 0.20f, 0.90f);
                        GL.Vertex3(ABLine.currentABLineP1.easting, ABLine.currentABLineP1.northing, 0.0);
                        GL.Vertex3(ABLine.currentABLineP2.easting, ABLine.currentABLineP2.northing, 0.0);
                        GL.End();
                    }

                    //draw curve if there is one
                    if (curve.isCurveSet && curve.isBtnCurveOn)
                    {
                        int ptC = curve.curList.Count;
                        if (ptC > 0)
                        {
                            GL.LineWidth(2);
                            GL.Color3(0.925f, 0.2f, 0.90f);
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
                    oglZoom.MakeCurrent();
                    oglZoom.SwapBuffers();
                }
            }
        }

        private void DrawManUTurnBtn()
        {
            GL.Enable(EnableCap.Texture2D);

                GL.BindTexture(TextureTarget.Texture2D, texture[5]);        // Select Our Texture
                GL.Color3(0.90f, 0.90f, 0.293f);

            int two3 = oglMain.Width / 4;
            GL.Begin(PrimitiveType.Quads);              // Build Quad From A Triangle Strip
            {
                GL.TexCoord2(0, 0); GL.Vertex2(-82 - two3, 45); // 
                GL.TexCoord2(1, 0); GL.Vertex2( 82 - two3, 45.0); // 
                GL.TexCoord2(1, 1); GL.Vertex2( 82 - two3, 120); // 
                GL.TexCoord2(0, 1); GL.Vertex2(-82 - two3, 120); //
            }
            GL.End();
            GL.Disable(EnableCap.Texture2D);

        }

        private void DrawUTurnBtn()
        {
            GL.Enable(EnableCap.Texture2D);

            if (!yt.isYouTurnTriggered)
            {
                GL.BindTexture(TextureTarget.Texture2D, texture[3]);        // Select Our Texture
                if (distancePivotToTurnLine > 0 && !yt.isOutOfBounds) GL.Color3(0.3f, 0.95f, 0.3f);
                else GL.Color3(0.97f, 0.635f, 0.4f);
            }
            else
            {
                GL.BindTexture(TextureTarget.Texture2D, texture[4]);        // Select Our Texture
                GL.Color3(0.90f, 0.90f, 0.293f);
            }

            int two3 = oglMain.Width / 5;
            GL.Begin(PrimitiveType.Quads);              // Build Quad From A Triangle Strip
            if (!yt.isYouTurnRight)
            {
                GL.TexCoord2(0, 0); GL.Vertex2(-62 + two3, 50); // 
                GL.TexCoord2(1, 0); GL.Vertex2(62 + two3,  50.0); // 
                GL.TexCoord2(1, 1); GL.Vertex2(62 + two3,  120); // 
                GL.TexCoord2(0, 1); GL.Vertex2(-62 + two3, 120); //
            }
            else
            {
                GL.TexCoord2(1, 0); GL.Vertex2(-62 + two3, 50); // 
                GL.TexCoord2(0, 0); GL.Vertex2(62 + two3,  50.0); // 
                GL.TexCoord2(0, 1); GL.Vertex2(62 + two3,  120); // 
                GL.TexCoord2(1, 1); GL.Vertex2(-62 + two3, 120); //
            }
            //
            GL.End();
            GL.Disable(EnableCap.Texture2D);
            // Done Building Triangle Strip
            if (isMetric)
            {
                if (!yt.isYouTurnTriggered)
                {
                    font.DrawText(-30 + two3, 80, DistPivotM);
                }
                else
                {
                    font.DrawText(-30 + two3, 80, yt.onA.ToString());
                }
            }
            else
            {

                if (!yt.isYouTurnTriggered)
                {
                    font.DrawText(-40 + two3, 85, DistPivotFt);
                }
                else
                {
                    font.DrawText(-40 + two3, 85, yt.onA.ToString());
                }
            }
        }

        private void MakeFlagMark()
        {
            leftMouseDownOnOpenGL = false;
            byte[] data1 = new byte[768];

            //scan the center of click and a set of square points around
            GL.ReadPixels(mouseX - 8, mouseY - 8, 16, 16, PixelFormat.Rgb, PixelType.UnsignedByte, data1);

            //made it here so no flag found
            flagNumberPicked = 0;

            for (int ctr = 0; ctr < 768; ctr += 3)
            {
                if (data1[ctr] == 255 | data1[ctr + 1] == 255)
                {
                    flagNumberPicked = data1[ctr + 2];
                    break;
                }
            }

            if (flagNumberPicked > 0)
            {
                Form fc = Application.OpenForms["FormFlags"];

                if (fc != null)
                {
                    fc.Focus();
                    return;
                }

                if (flagPts.Count > 0)
                {
                    Form form = new FormFlags(this);
                    form.Show();
                }
            }
        }

        private void DrawFlags()
        {
            int flagCnt = flagPts.Count;
            for (int f = 0; f < flagCnt; f++)
            {
                GL.PointSize(8.0f);
                GL.Begin(PrimitiveType.Points);
                if (flagPts[f].color == 0) GL.Color3((byte)255, (byte)0, (byte)flagPts[f].ID);
                if (flagPts[f].color == 1) GL.Color3((byte)0, (byte)255, (byte)flagPts[f].ID);
                if (flagPts[f].color == 2) GL.Color3((byte)255, (byte)255, (byte)flagPts[f].ID);
                GL.Vertex3(flagPts[f].easting, flagPts[f].northing, 0);
                GL.End();

                font.DrawText3D(flagPts[f].easting, flagPts[f].northing, "&" + (f+1).ToString());
                //else
                //    font.DrawText3D(flagPts[f].easting, flagPts[f].northing, "&");
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
                //GL.PointSize(4.0f);
                //GL.Color3(0, 0, 0);
                //GL.Begin(PrimitiveType.Points);
                //GL.Vertex3(flagPts[flagNumberPicked - 1].easting, flagPts[flagNumberPicked - 1].northing, 0);
                //GL.End();
            }
        }

        private void DrawLightBar(double Width, double Height, double offlineDistance)
        {
            double down = 20;
            GL.LineWidth(1);
            //GL.Translate(0, 0, 0.01);
            
            //  Dot distance is representation of how far from AB Line
            int dotDistance = (int)(offlineDistance);
            int limit = (int)lightbarCmPerPixel * 8;
            if (dotDistance < -limit) dotDistance = -limit;
            if (dotDistance > limit) dotDistance = limit;

            //if (dotDistance < -10) dotDistance -= 30;
            //if (dotDistance > 10) dotDistance += 30;

            // dot background
            GL.PointSize(8.0f);
            GL.Color3(0.00f, 0.0f, 0.0f);
            GL.Begin(PrimitiveType.Points);
            for (int i = -8; i < 0; i++) GL.Vertex2((i * 32), down);
            for (int i = 1; i < 9; i++) GL.Vertex2((i * 32), down);
            GL.End();

            GL.PointSize(4.0f);

            //GL.Translate(0, 0, 0.01);
            //red left side
            GL.Color3(0.9750f, 0.0f, 0.0f);
            GL.Begin(PrimitiveType.Points);
            for (int i = -8; i < 0; i++) GL.Vertex2((i * 32), down);

            //green right side
            GL.Color3(0.0f, 0.9750f, 0.0f);
            for (int i = 1; i < 9; i++) GL.Vertex2((i * 32), down);
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
                //GL.Vertex(0, down + 52);
                GL.End();

                //gl.PointSize(4.0f);
                //gl.Color3(0.9250f, 0.9250f, 0.250f);
                //gl.Begin(PrimitiveType.Points);
                //gl.Vertex(0, down);
                //gl.Vertex(0, down + 30);
                //gl.Vertex(0, down + 52);
                //gl.End();
            }
        }

        private void DrawLightBarText()
        {

            GL.Disable(EnableCap.DepthTest);

            if (ct.isContourBtnOn || ABLine.isBtnABLineOn || curve.isBtnCurveOn)
            {
                double dist = distanceDisplay * 0.1;

                DrawLightBar(oglMain.Width, oglMain.Height, dist);

                double size = 1.5;
                string hede;

                if (dist == 3200 || dist == 3202 )
                {
                    //lblDistanceOffLine.Text = "Lost";
                }
                else 
                {
                    if (dist < 0.0)
                    {
                        GL.Color3(0.50f, 0.952f, 0.3f);
                         hede = "< " + (Math.Abs(dist)).ToString("N1");
                    }
                    else
                    {
                        GL.Color3(0.9752f, 0.50f, 0.3f);
                         hede = (dist).ToString("N1") + " >" ;
                    }
                        int center = -(int)(((double)(hede.Length) * 0.5) * 16 * size);
                        font.DrawText(center, 38, hede, size);
                }
            }
            //if (ct.isContourBtnOn)
            //{
            //    string dist;
            //    lblDistanceOffLine.Visible = true;
            //    //lblDelta.Visible = true;
            //    if (ct.distanceFromCurrentLine == 32000) ct.distanceFromCurrentLine = 0;

            //    DrawLightBar(oglMain.Width, oglMain.Height, ct.distanceFromCurrentLine * 0.1);

            //    if ((ct.distanceFromCurrentLine) < 0.0)
            //    {
            //        lblDistanceOffLine.ForeColor = Color.Green;
            //        if (isMetric) dist = ((int)Math.Abs(ct.distanceFromCurrentLine * 0.1)) + " ->";
            //        else dist = ((int)Math.Abs(ct.distanceFromCurrentLine / 2.54 * 0.1)) + " ->";
            //        lblDistanceOffLine.Text = dist;
            //    }
            //    else
            //    {
            //        lblDistanceOffLine.ForeColor = Color.Red;
            //        if (isMetric) dist = "<- " + ((int)Math.Abs(ct.distanceFromCurrentLine * 0.1));
            //        else dist = "<- " + ((int)Math.Abs(ct.distanceFromCurrentLine / 2.54 * 0.1));
            //        lblDistanceOffLine.Text = dist;
            //    }
            //}

            //else if (ABLine.isABLineSet | ABLine.isABLineBeingSet)
            //{
            //    string dist;
            //    lblDistanceOffLine.Visible = true;
            //    //lblDelta.Visible = true;
            //    DrawLightBar(oglMain.Width, oglMain.Height, ABLine.distanceFromCurrentLine * 0.1);
            //    if ((ABLine.distanceFromCurrentLine) < 0.0)
            //    {
            //        // --->
            //        lblDistanceOffLine.ForeColor = Color.Green;
            //        if (isMetric) dist = ((int)Math.Abs(ABLine.distanceFromCurrentLine * 0.1)) + " ->";
            //        else dist = ((int)Math.Abs(ABLine.distanceFromCurrentLine / 2.54 * 0.1)) + " ->";
            //        lblDistanceOffLine.Text = dist;
            //    }
            //    else
            //    {
            //        // <----
            //        lblDistanceOffLine.ForeColor = Color.Red;
            //        if (isMetric) dist = "<- " + ((int)Math.Abs(ABLine.distanceFromCurrentLine * 0.1));
            //        else dist = "<- " + ((int)Math.Abs(ABLine.distanceFromCurrentLine / 2.54 * 0.1));
            //        lblDistanceOffLine.Text = dist;
            //    }
            //}

            //else if (curve.isBtnCurveOn)
            //{
            //    string dist;
            //    lblDistanceOffLine.Visible = true;
            //    //lblDelta.Visible = true;
            //    if (curve.distanceFromCurrentLine == 32000) curve.distanceFromCurrentLine = 0;

            //    DrawLightBar(oglMain.Width, oglMain.Height, curve.distanceFromCurrentLine * 0.1);
            //    if ((curve.distanceFromCurrentLine) < 0.0)
            //    {
            //        lblDistanceOffLine.ForeColor = Color.Green;
            //        if (isMetric) dist = ((int)Math.Abs(curve.distanceFromCurrentLine * 0.1)) + " ->";
            //        else dist = ((int)Math.Abs(curve.distanceFromCurrentLine / 2.54 * 0.1)) + " ->";
            //        lblDistanceOffLine.Text = dist;
            //    }
            //    else
            //    {
            //        lblDistanceOffLine.ForeColor = Color.Red;
            //        if (isMetric) dist = "<- " + ((int)Math.Abs(curve.distanceFromCurrentLine * 0.1));
            //        else dist = "<- " + ((int)Math.Abs(curve.distanceFromCurrentLine / 2.54 * 0.1));
            //        lblDistanceOffLine.Text = dist;
            //    }
            //}
        }

        private void DrawRollBar()
        {
            double set = guidanceLineSteerAngle * 0.01 * (50 / vehicle.maxSteerAngle);
            double actual = actualSteerAngleDisp * 0.01 * (50 / vehicle.maxSteerAngle);
            double hiit = 0;

            GL.PushMatrix();
            GL.Translate(0, 100, 0);

            //If roll is used rotate graphic based on roll angle
            if ((ahrs.isRollFromBrick | ahrs.isRollFromAutoSteer | ahrs.isRollFromGPS) && ahrs.rollX16 != 9999)
                GL.Rotate(((ahrs.rollX16 - ahrs.rollZeroX16) * 0.0625f), 0.0f, 0.0f, 1.0f);

            GL.LineWidth(1);
            GL.Color3(0.54f, 0.54f, 0.54f);
            double wiid = 50;

            GL.Begin(PrimitiveType.LineStrip);
            GL.Vertex2(-wiid, 25);
            GL.Vertex2(-wiid, 0);
            GL.Vertex2(wiid, 0);
            GL.Vertex2(wiid, 25);
            GL.End();

            GL.Translate(0, 10, 0);

            {
                if (actualSteerAngleDisp > 0)
                {
                    GL.LineWidth(1);
                    GL.Begin(PrimitiveType.LineStrip);

                    GL.Color3(0.0f, 0.75930f, 0.0f);
                    GL.Vertex2(0, hiit);
                    GL.Vertex2(actual, hiit + 8);
                    GL.Vertex2(0, hiit + 16);
                    GL.Vertex2(0, hiit);

                    GL.End();
                }
                else
                {
                    //actual
                    GL.LineWidth(1);
                    GL.Begin(PrimitiveType.LineStrip);

                    GL.Color3(0.75930f, 0.0f, 0.0f);
                    GL.Vertex2(-0, hiit);
                    GL.Vertex2(actual, hiit + 8);
                    GL.Vertex2(-0, hiit + 16);
                    GL.Vertex2(-0, hiit);

                    GL.End();
                }
            }

            if (guidanceLineSteerAngle > 0)
            {
                GL.LineWidth(1);
                GL.Begin(PrimitiveType.LineStrip);

                GL.Color3(0.75930f, 0.75930f, 0.0f);
                GL.Vertex2(0, hiit);
                GL.Vertex2(set, hiit + 8);
                GL.Vertex2(0, hiit + 16);
                GL.Vertex2(0, hiit);

                GL.End();
            }
            else
            {
                GL.LineWidth(1);
                GL.Begin(PrimitiveType.LineStrip);

                GL.Color3(0.75930f, 0.75930f, 0.0f);
                GL.Vertex2(-0, hiit);
                GL.Vertex2(set, hiit + 8);
                GL.Vertex2(-0, hiit + 16);
                GL.Vertex2(-0, hiit);

                GL.End();
            }

            //return back
            GL.PopMatrix();
            GL.LineWidth(1);
        }

        private void DrawSky()
        {
            //GL.Translate(0, 0, 0.9);
            ////draw the background when in 3D
            if (camera.camPitch < -52)
            {
                //-10 to -32 (top) is camera pitch range. Set skybox to line up with horizon 
                double hite = (camera.camPitch + 63) * -0.026;

                //the background
                double winLeftPos = -(double)oglMain.Width / 2;
                double winRightPos = -winLeftPos;
                GL.Color3(0.5, 0.5, 0.5);
                GL.Enable(EnableCap.Texture2D);
                GL.BindTexture(TextureTarget.Texture2D, texture[0]);        // Select Our Texture

                GL.Begin(PrimitiveType.TriangleStrip);              // Build Quad From A Triangle Strip
                GL.TexCoord2(0, 0); GL.Vertex2(winRightPos, 0.0); // Top Right
                GL.TexCoord2(1, 0); GL.Vertex2(winLeftPos, 0.0); // Top Left
                GL.TexCoord2(0, 1); GL.Vertex2(winRightPos, hite * oglMain.Height); // Bottom Right
                GL.TexCoord2(1, 1); GL.Vertex2(winLeftPos, hite * oglMain.Height); // Bottom Left
                GL.End();                       // Done Building Triangle Strip

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

        private void DrawCompassText()
        {
            string hede = camHeading.ToString("N1");
            int center = oglMain.Width / 2 - 45 - (int)(((double)(hede.Length) * 0.5) * 16);
            GL.Color3(0.9752f, 0.952f, 0.83f);

            if (isCompassOn)
            font.DrawText(center, 65, hede, 0.8);
            else font.DrawText(center, 65, hede, 1.2);

        }

        private void DrawCompass()
        {
            //Heading text
            int center = oglMain.Width / 2 - 55;
            font.DrawText(center-8, 40, "^", 0.8);


            GL.PushMatrix();
            GL.Enable(EnableCap.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, texture[6]);        // Select Our Texture
            GL.Color4(0.952f, 0.870f, 0.73f, 0.8);


            GL.Translate(center, 78, 0);

            GL.Rotate(-camHeading, 0, 0, 1);
            GL.Begin(PrimitiveType.Quads);              // Build Quad From A Triangle Strip
            {
                GL.TexCoord2(0, 0); GL.Vertex2(-52, -52); // 
                GL.TexCoord2(1, 0); GL.Vertex2(52, -52.0); // 
                GL.TexCoord2(1, 1); GL.Vertex2(52, 52); // 
                GL.TexCoord2(0, 1); GL.Vertex2(-52, 52); //
            }
            GL.End();
            GL.Disable(EnableCap.Texture2D);
            GL.PopMatrix();
        }

        private void DrawSpeedo()
        {
            GL.PushMatrix();
            GL.Enable(EnableCap.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, texture[7]);        // Select Our Texture
            GL.Color4(0.952f, 0.870f, 0.823f, 0.8);

            int bottomSide = oglMain.Height - 55;

            GL.Translate(oglMain.Width / 2 - 60, bottomSide, 0);

            GL.Begin(PrimitiveType.Quads);              // Build Quad From A Triangle Strip
            {
                GL.TexCoord2(0, 0); GL.Vertex2(-58, -58); // 
                GL.TexCoord2(1, 0); GL.Vertex2(58, -58.0); // 
                GL.TexCoord2(1, 1); GL.Vertex2(58, 58); // 
                GL.TexCoord2(0, 1); GL.Vertex2(-58, 58); //
            }
            GL.End();
            GL.BindTexture(TextureTarget.Texture2D, texture[8]);        // Select Our Texture

            double angle = 0;
            if (isMetric)
            {
                double aveSpd = 0;
                for (int c = 0; c < 10; c++) aveSpd += avgSpeed[c];
                aveSpd *= 0.1;
                if (aveSpd > 20) aveSpd = 20;
                angle = (aveSpd - 10) * 15;
            }
            else
            {
                double aveSpd = 0;
                for (int c = 0; c < 10; c++) aveSpd += avgSpeed[c];
                aveSpd *= 0.0621371;
                angle = (aveSpd - 10) * 15;
                if (aveSpd > 20) aveSpd = 20;
            }

            GL.Color3(0.952f, 0.70f, 0.23f);

            GL.Rotate(angle, 0, 0, 1);
            GL.Begin(PrimitiveType.Quads);              // Build Quad From A Triangle Strip
            {
                GL.TexCoord2(0, 0); GL.Vertex2(-48, -48); // 
                GL.TexCoord2(1, 0); GL.Vertex2(48, -48.0); // 
                GL.TexCoord2(1, 1); GL.Vertex2(48, 48); // 
                GL.TexCoord2(0, 1); GL.Vertex2(-48, 48); //
            }
            GL.End();

            GL.Disable(EnableCap.Texture2D);
            GL.PopMatrix();

        }

        private void DrawFieldText()
        {
            if (isMetric)
            {
                if (bnd.bndArr.Count > 0)
                {
                    sb.Clear();
                    sb.Append(((fd.workedAreaTotal - fd.actualAreaCovered) * glm.m2ha).ToString("N3"));
                    sb.Append("Ha ");
                    sb.Append(fd.overlapPercent.ToString("N2"));
                    sb.Append("%  ");
                    sb.Append((fd.areaBoundaryOuterLessInner * glm.m2ha).ToString("N2"));
                    sb.Append("-");
                    sb.Append((fd.actualAreaCovered * glm.m2ha).ToString("N2"));
                    sb.Append(" = ");
                    sb.Append(((fd.areaBoundaryOuterLessInner - fd.actualAreaCovered) * glm.m2ha).ToString("N2"));
                    sb.Append("Ha  ");
                    sb.Append(fd.TimeTillFinished);
                    GL.Color3(0.95, 0.95, 0.95);
                    font.DrawText(-sb.Length * 7, oglMain.Height - 32, sb.ToString());
                }
                else
                {
                    sb.Clear();
                    //sb.Append("Overlap ");
                    sb.Append(fd.overlapPercent.ToString("N3"));
                    sb.Append("%   ");
                    sb.Append((fd.actualAreaCovered * glm.m2ha).ToString("N3"));
                    sb.Append("Ha");
                    GL.Color3(0.95, 0.95, 0.95);
                    font.DrawText(0, oglMain.Height - 32, sb.ToString());
                }
            }
            else
            {
                if (bnd.bndArr.Count > 0)
                {
                    sb.Clear();
                    sb.Append(((fd.workedAreaTotal - fd.actualAreaCovered) * glm.m2ac).ToString("N3"));
                    sb.Append("Ac ");
                    sb.Append(fd.overlapPercent.ToString("N2"));
                    sb.Append("%  ");
                    sb.Append((fd.areaBoundaryOuterLessInner * glm.m2ac).ToString("N2"));
                    sb.Append("-");
                    sb.Append((fd.actualAreaCovered * glm.m2ac).ToString("N2"));
                    sb.Append(" = ");
                    sb.Append(((fd.areaBoundaryOuterLessInner - fd.actualAreaCovered) * glm.m2ac).ToString("N2"));
                    sb.Append("Ac  ");
                    sb.Append(fd.TimeTillFinished);
                    GL.Color3(0.95, 0.95, 0.95);
                    font.DrawText(-sb.Length * 7, oglMain.Height - 32, sb.ToString());
                }
                else
                {
                    sb.Clear();
                    //sb.Append("Overlap ");
                    sb.Append(fd.overlapPercent.ToString("N3"));
                    sb.Append("%   ");
                    sb.Append((fd.actualAreaCovered * glm.m2ac).ToString("N3"));
                    sb.Append("Ac");
                    GL.Color3(0.95, 0.95, 0.95);
                    font.DrawText(0, oglMain.Height - 32, sb.ToString());
                }
            }
        }

        private void CalcFrustum()
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
            if (bnd.bndArr.Count > 0)
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
                for (int j = 0; j < tool.numSuperSection; j++)
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

                if (maxFieldDistance < 100) maxFieldDistance = 100;
                if (maxFieldDistance > 19900) maxFieldDistance = 19900;
                //lblMax.Text = ((int)maxFieldDistance).ToString();

                fieldCenterX = (maxFieldX + minFieldX) / 2.0;
                fieldCenterY = (maxFieldY + minFieldY) / 2.0;
            }

            //minFieldX -= 8;
            //minFieldY -= 8;
            //maxFieldX += 8;
            //maxFieldY += 8;

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

            //lblZooom.Text = ((int)(maxFieldDistance)).ToString();

        }

        //else
        //{
        //    GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
        //    GL.LoadIdentity();

        //    //back the camera up
        //    GL.CullFace(CullFaceMode.Front);
        //    GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
        //    GL.Enable(EnableCap.Blend);

        //    GL.Translate(0, 0,-250);
        //    GL.Enable(EnableCap.Texture2D);

        //    GL.BindTexture(TextureTarget.Texture2D, texture[7]);        // Select Our Texture
        //    GL.Color4(0.952f, 0.70f, 0.23f, 0.6);

        //    GL.Begin(PrimitiveType.Quads);              // Build Quad From A Triangle Strip
        //    {
        //        GL.TexCoord2(0, 0);
        //        GL.Vertex2(-128, 128);

        //        GL.TexCoord2(1, 0);
        //        GL.Vertex2(128, 128);

        //        GL.TexCoord2(1, 1);
        //        GL.Vertex2(128, -128);

        //        GL.TexCoord2(0, 1);
        //        GL.Vertex2(-128, -128);
        //    }
        //    GL.End();

        //    GL.BindTexture(TextureTarget.Texture2D, texture[8]);        // Select Our Texture
        //    double angle = 0;
        //    if (isMetric)
        //    {
        //        double aveSpd = 0;
        //        for (int c = 0; c < 10; c++) aveSpd += avgSpeed[c];
        //        aveSpd *= 0.1;
        //        if (aveSpd > 20) aveSpd = 20;
        //        angle = (aveSpd - 10) * -15;
        //    }
        //    else
        //    {
        //        double aveSpd = 0;
        //        for (int c = 0; c < 10; c++) aveSpd += avgSpeed[c];
        //        aveSpd *= 0.0621371;
        //        angle = (aveSpd - 10) * -15;
        //        if (aveSpd > 20) aveSpd = 20;
        //    }

        //    GL.Color3(0.952f, 0.70f, 0.23f);

        //    GL.Rotate(angle, 0, 0, 1);
        //    GL.Begin(PrimitiveType.Quads);              // Build Quad From A Triangle Strip
        //    {
        //        GL.TexCoord2(0, 0);
        //        GL.Vertex2(-80, 80);

        //        GL.TexCoord2(1, 0);
        //        GL.Vertex2(80, 80);

        //        GL.TexCoord2(1, 1);
        //        GL.Vertex2(80, -80);

        //        GL.TexCoord2(0, 1);
        //        GL.Vertex2(-80, -80);
        //    }
        //    GL.End();

        //    GL.Disable(EnableCap.Texture2D);
        //    GL.CullFace(CullFaceMode.Back);
        //    GL.Disable(EnableCap.Blend);
        //}
    }
}
