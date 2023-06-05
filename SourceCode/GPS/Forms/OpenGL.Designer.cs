using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Windows.Forms;
using System.Text;

namespace AgOpenGPS
{
    public partial class FormGPS
    {
        //extracted Near, Far, Right, Left clipping planes of frustum
        public double[] frustum = new double[24];

        private bool isInit = false;
        private double fovy = 0.7;
        private double camDistanceFactor = -4;

        int mouseX = 0, mouseY = 0;
        private int zoomUpdateCounter = 0;
        public int steerModuleConnectedCounter = 0;

        public bool isTramOnBackBuffer = false;

        //data buffer for pixels read from off screen buffer
        byte[] grnPixels = new byte[150001];

        // When oglMain is created
        private void oglMain_Load(object sender, EventArgs e)
        {
            oglMain.MakeCurrent();
            LoadGLTextures();
            GL.ClearColor(0.27f, 0.4f, 0.7f, 1.0f);
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
                1.0f, (float)(camDistanceFactor * camera.camSetDistance));
            GL.LoadMatrix(ref mat);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        //oglMain rendering, Draw

        int deadCam = 0;

        StringBuilder sb = new StringBuilder();
        private void oglMain_Paint(object sender, PaintEventArgs e)
        {
            if (sentenceCounter > 299)
            {
                //sentenceCounter = 0;
                GL.Enable(EnableCap.Blend);
                GL.ClearColor(0.122f, 0.1258f, 0.1275f, 1.0f);

                GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
                GL.LoadIdentity();

                //match grid to cam distance and redo perspective
                oglMain.MakeCurrent();
                //GL.MatrixMode(MatrixMode.Projection);
                //GL.LoadIdentity();
                //Matrix4 mat = Matrix4.CreatePerspectiveFieldOfView(0.7f, oglMain.AspectRatio, 1f, 100);
                //GL.LoadMatrix(ref mat);
                //GL.MatrixMode(MatrixMode.Modelview);
                GL.Translate(0.0, 0.3, -10);
                //rotate the camera down to look at fix
                //GL.Rotate(20, 1.0, 0.0, 0.0);
                GL.Rotate(deadCam, 0.0, 1.0, 0.0);

                deadCam += 5;

                GL.Enable(EnableCap.Texture2D);
                GL.Color4(1.25f, 1.25f, 1.275f, 0.75);
                GL.BindTexture(TextureTarget.Texture2D, texture[21]);        // Select Our Texture
                GL.Begin(PrimitiveType.TriangleStrip);              // Build Quad From A Triangle Strip
                GL.TexCoord2(1, 0); GL.Vertex2(2.5, 2.5); // Top Right
                GL.TexCoord2(0, 0); GL.Vertex2(-2.5, 2.5); // Top Left
                GL.TexCoord2(1, 1); GL.Vertex2(2.5, -2.5); // Bottom Right
                GL.TexCoord2(0, 1); GL.Vertex2(-2.5, -2.5); // Bottom Left
                GL.End();                       // Done Building Triangle Strip

                GL.Disable(EnableCap.Texture2D);


                //camHeading = 0;

                //GL.Rotate(deadCam, 0.0, 0.0, 1.0);
                //////draw the guide
                //GL.Begin(PrimitiveType.Triangles);
                //GL.Color3(0.2f, 0.10f, 0.98f);
                //GL.Vertex3(0.0f, -1.0f, 0.0f);
                //GL.Color3(0.0f, 0.98f, 0.0f);
                //GL.Vertex3(-1.0f, 1.0f, 0.0f);
                //GL.Color3(0.98f, 0.02f, 0.40f);
                //GL.Vertex3(1.0f, -0.0f, 0.0f);
                //GL.End();                       // Done Drawing Reticle


                //font.DrawText3DNoGPS(0, 0, " I'm Lost  ", 1);
                //GL.Color3(0.98f, 0.98f, 0.270f);

                //GL.Rotate(deadCam + 180, 0.0, 0.0, 1.0);
                //font.DrawText3DNoGPS(0, 0, "  No GPS!", 1);

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

                GL.Color3(0.98f, 0.98f, 0.70f);

                int edge = -oglMain.Width / 2 + 10;

                font.DrawText(edge, oglMain.Height - 240, "<-- AgIO ?");

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

                lblSpeed.Text = "???";
                lblHz.Text = " ???? \r\n Not Connected";

            }
            else
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

                    if (isDay) GL.ClearColor(0.27f, 0.4f, 0.7f, 1.0f);
                    else GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);

                    GL.LoadIdentity();

                    //position the camera
                    camera.SetWorldCam(pivotAxlePos.easting, pivotAxlePos.northing, camHeading);

                    //the bounding box of the camera for cullling.
                    CalcFrustum();
                    worldGrid.DrawFieldSurface();

                    ////if grid is on draw it
                    if (isGridOn) worldGrid.DrawWorldGrid(camera.gridZoom);

                    if (isDrawPolygons) GL.PolygonMode(MaterialFace.Front, PolygonMode.Line);

                    GL.Enable(EnableCap.Blend);
                    //draw patches of sections

                    for (int j = 0; j < triStrip.Count; j++)
                    {
                        //every time the section turns off and on is a new patch //check if in frustum or not
                        bool isDraw;

                        int patches = triStrip[j].patchList.Count;

                        if (patches > 0)
                        {
                            //initialize the steps for mipmap of triangles (skipping detail while zooming out)
                            int mipmap = 0;
                            if (camera.camSetDistance < -800) mipmap = 2;
                            if (camera.camSetDistance < -1500) mipmap = 4;
                            if (camera.camSetDistance < -2400) mipmap = 8;
                            if (camera.camSetDistance < -5000) mipmap = 16;

                            //for every new chunk of patch
                            foreach (var triList in triStrip[j].patchList)
                            {
                                isDraw = false;
                                int count2 = triList.Count;
                                for (int i = 1; i < count2; i += 3)
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

                                    count2 = triList.Count;
                                    //GL.Color4((byte)(count2), (byte)(count2*2), (byte)(count2*4), (byte)152);
                                    //draw the triangle in each triangle strip
                                    GL.Begin(PrimitiveType.TriangleStrip);

                                    if (isDay) GL.Color4((byte)triList[0].easting, (byte)triList[0].northing, (byte)triList[0].heading, (byte)152);
                                    else GL.Color4((byte)triList[0].easting, (byte)triList[0].northing, (byte)triList[0].heading, (byte)(152 * 0.5));

                                    //if large enough patch and camera zoomed out, fake mipmap the patches, skip triangles
                                    if (count2 >= (mipmap + 2))
                                    {
                                        int step = mipmap;
                                        for (int i = 1; i < count2; i += step)
                                        {
                                            GL.Vertex3(triList[i].easting, triList[i].northing, 0); i++;
                                            GL.Vertex3(triList[i].easting, triList[i].northing, 0); i++;
                                            if (count2 - i <= (mipmap + 2)) step = 0;//too small to mipmap it
                                        }
                                    }
                                    else { for (int i = 1; i < count2; i++) GL.Vertex3(triList[i].easting, triList[i].northing, 0); }
                                    GL.End();
                                }
                            }
                        }
                    }

                    // the follow up to sections patches
                    int patchCount = 0;

                    if (patchCounter > 0)
                    {
                        if (isDay) GL.Color4(sectionColorDay.R, sectionColorDay.G, sectionColorDay.B, (byte)152);
                        else GL.Color4(sectionColorDay.R, sectionColorDay.G, sectionColorDay.B, (byte)(76));

                        for (int j = 0; j < triStrip.Count; j++)
                        {
                            if (triStrip[j].isDrawing)
                            {
                                if (tool.isMultiColoredSections)
                                {
                                    if (isDay) GL.Color4(tool.secColors[j].R, tool.secColors[j].G, tool.secColors[j].B, (byte)152);
                                    else GL.Color4(tool.secColors[j].R, tool.secColors[j].G, tool.secColors[j].B, (byte)(152 * 0.5));
                                }
                                patchCount = triStrip[j].patchList.Count;

                                //draw the triangle in each triangle strip
                                GL.Begin(PrimitiveType.TriangleStrip);

                                //left side of triangle
                                vec2 pt = new vec2((cosSectionHeading * section[triStrip[j].currentStartSectionNum].positionLeft) + toolPos.easting,
                                        (sinSectionHeading * section[triStrip[j].currentStartSectionNum].positionLeft) + toolPos.northing);

                                GL.Vertex3(pt.easting, pt.northing, 0);

                                //Right side of triangle
                                pt = new vec2((cosSectionHeading * section[triStrip[j].currentEndSectionNum].positionRight) + toolPos.easting,
                                   (sinSectionHeading * section[triStrip[j].currentEndSectionNum].positionRight) + toolPos.northing);

                                GL.Vertex3(pt.easting, pt.northing, 0);

                                int last = triStrip[j].patchList[patchCount - 1].Count;
                                //antenna
                                GL.Vertex3(triStrip[j].patchList[patchCount - 1][last - 2].easting, triStrip[j].patchList[patchCount - 1][last - 2].northing, 0);
                                GL.Vertex3(triStrip[j].patchList[patchCount - 1][last - 1].easting, triStrip[j].patchList[patchCount - 1][last - 1].northing, 0);
                                GL.End();
                            }
                        }
                    }

                    if (tram.displayMode != 0) tram.DrawTram();

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

                    recPath.DrawRecordedLine();
                    recPath.DrawDubins();

                    if (bnd.bndList.Count > 0 || bnd.isBndBeingMade == true)
                    {
                        //draw Boundaries
                        bnd.DrawFenceLines();

                        GL.LineWidth(ABLine.lineWidth);

                        //draw the turnLines
                        if (yt.isYouTurnBtnOn && !ct.isContourBtnOn)
                        {
                            GL.Color3(0.3555f, 0.6232f, 0.20f);
                            for (int i = 0; i < bnd.bndList.Count; i++)
                            {
                                bnd.bndList[i].turnLine.DrawPolygon();
                            }
                        }

                        //Draw headland
                        if (bnd.isHeadlandOn)
                        {
                            GL.Color3(0.960f, 0.96232f, 0.30f);
                                bnd.bndList[0].hdLine.DrawPolygon();
                        }
                    }

                    if (flagPts.Count > 0) DrawFlags();

                    //Direct line to flag if flag selected
                    try
                    {
                        if (flagNumberPicked > 0)
                        {
                            GL.LineWidth(ABLine.lineWidth);
                            GL.Enable(EnableCap.LineStipple);
                            GL.LineStipple(1, 0x0707);
                            GL.Begin(PrimitiveType.Lines);
                            GL.Color3(0.930f, 0.72f, 0.32f);
                            GL.Vertex3(pivotAxlePos.easting, pivotAxlePos.northing, 0);
                            GL.Vertex3(flagPts[flagNumberPicked - 1].easting, flagPts[flagNumberPicked - 1].northing, 0);
                            GL.End();
                            GL.Disable(EnableCap.LineStipple);
                        }
                    }
                    catch { }

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
                        DrawLightBarText();
                    }

                    if (bnd.bndList.Count > 0 && yt.isYouTurnBtnOn) DrawUTurnBtn();

                    if ((isAutoSteerBtnOn || yt.isYouTurnBtnOn) && !ct.isContourBtnOn) DrawManUTurnBtn();

                    //if (isCompassOn) DrawCompass();
                    DrawCompassText();

                    if (isSpeedoOn) DrawSpeedo();

                    DrawSteerCircle();

                    if (vehicle.isHydLiftOn) DrawLiftIndicator();

                    if (isReverse || isChangingDirection)
                        DrawReverse();

                    if (isRTK)
                    {
                        if (pn.fixQuality != 4)
                        {
                            if (!sounds.isRTKAlarming) sounds.sndRTKAlarm.Play();
                            sounds.isRTKAlarming = true;
                            DrawLostRTK();
                            if (isRTK_KillAutosteer && isAutoSteerBtnOn) btnAutoSteer.PerformClick();
                        }
                        else
                            sounds.isRTKAlarming = false;
                    }

                    if (pn.age > pn.ageAlarm) DrawAge();

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

                    //5 hz sections
                    if (bbCounter++ > 0) 
                        bbCounter = 0;
                   
                    //draw the section control window off screen buffer
                    if (isJobStarted && (bbCounter == 0))
                    {
                        oglBack.Refresh();

                        p_239.pgn[p_239.geoStop] = mc.isOutOfBounds ? (byte)1 : (byte)0;

                        SendPgnToLoop(p_239.pgn);
                        if (!tool.isSectionsNotZones)
                            SendPgnToLoop(p_229.pgn);
                    }

                    //draw the zoom window
                    if (isJobStarted && oglZoom.Width != 400)
                    {
                        if (threeSeconds != zoomUpdateCounter)
                        {
                            zoomUpdateCounter = threeSeconds;
                            oglZoom.Refresh();
                        }
                    }
                }
            }
        }

        private int bbCounter = 0;

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
            GL.Viewport(0, 0, 500, 300);
            Matrix4 mat = Matrix4.CreatePerspectiveFieldOfView(0.06f, 1.6666666666f, 50.0f, 520.0f);
            GL.LoadMatrix(ref mat);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        private bool isHeadlandClose = false;

        private void oglBack_Paint(object sender, PaintEventArgs e)
        {
            oglBack.MakeCurrent();

            GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();					// Reset The View

            //back the camera up
            GL.Translate(0, 0, -500);

            //rotate camera so heading matched fix heading in the world
            GL.Rotate(glm.toDegrees(toolPos.heading), 0, 0, 1);

            GL.Translate(-toolPos.easting - Math.Sin(toolPos.heading) * 15,
                -toolPos.northing - Math.Cos(toolPos.heading) * 15,
                0);

            #region Draw to Back Buffer

            //patch color
            GL.Color3(0.0f, 0.5f, 0.0f);

            //to draw or not the triangle patch
            bool isDraw;

            double pivEplus = pivotAxlePos.easting + 50;
            double pivEminus = pivotAxlePos.easting - 50;
            double pivNplus = pivotAxlePos.northing + 50;
            double pivNminus = pivotAxlePos.northing - 50;

            //draw patches j= # of sections
            for (int j = 0; j < triStrip.Count; j++)
            {
                //every time the section turns off and on is a new patch
                int patchCount = triStrip[j].patchList.Count;

                if (patchCount > 0)
                {
                    //for every new chunk of patch
                    foreach (var triList in triStrip[j].patchList)
                    {
                        isDraw = false;
                        int count2 = triList.Count;
                        for (int i = 1; i < count2; i += 3)
                        {
                            //determine if point is in frustum or not
                            if (triList[i].easting > pivEplus)
                                continue;
                            if (triList[i].easting < pivEminus)
                                continue;
                            if (triList[i].northing > pivNplus)
                                continue;
                            if (triList[i].northing < pivNminus)
                                continue;

                            //point is in frustum so draw the entire patch
                            isDraw = true;
                            break;
                        }

                        if (isDraw)
                        {
                            //draw the triangles in each triangle strip
                            GL.Begin(PrimitiveType.TriangleStrip);
                            for (int i = 1; i < count2; i++) GL.Vertex3(triList[i].easting, triList[i].northing, 0);
                            GL.End();
                        }
                    }
                }
            }

            //draw 245 green for the tram tracks
            if (isTramOnBackBuffer)
            {
                if (tram.displayMode != 0 && (curve.isBtnCurveOn || ABLine.isBtnABLineOn))
                {
                    GL.Color3((byte)0, (byte)245, (byte)0);
                    GL.LineWidth(8);

                    if ((tram.displayMode == 1 || tram.displayMode == 2))
                    {
                        for (int i = 0; i < tram.tramList.Count; i++)
                        {
                            GL.Begin(PrimitiveType.LineStrip);
                            for (int h = 0; h < tram.tramList[i].Count; h++)
                                GL.Vertex3(tram.tramList[i][h].easting, tram.tramList[i][h].northing, 0);
                            GL.End();
                        }
                    }

                    if (tram.displayMode == 1 || tram.displayMode == 3)
                    {
                        //boundary tram list
                        GL.Begin(PrimitiveType.LineStrip);
                        for (int h = 0; h < tram.tramBndOuterArr.Count; h++)
                            GL.Vertex3(tram.tramBndOuterArr[h].easting, tram.tramBndOuterArr[h].northing, 0);
                        for (int h = 0; h < tram.tramBndInnerArr.Count; h++)
                            GL.Vertex3(tram.tramBndInnerArr[h].easting, tram.tramBndInnerArr[h].northing, 0);
                        GL.End();
                    }
                }
            }

            //draw 240 green for boundary
            if (bnd.bndList.Count > 0)
            {
                ////draw the bnd line 
                if (bnd.bndList[0].fenceLine.Count > 3)
                {
                    GL.LineWidth(3);
                    GL.Color3((byte)0, (byte)240, (byte)0);
                    bnd.bndList[0].fenceLine.DrawPolygon();
                }


                //draw 250 green for the headland
                if (bnd.isHeadlandOn && bnd.isSectionControlledByHeadland)
                {
                    GL.LineWidth(3);
                    GL.Color3((byte)0, (byte)250, (byte)0);
                    bnd.bndList[0].hdLine.DrawPolygon();
                }
            }

            //finish it up - we need to read the ram of video card
            GL.Flush();

            #endregion

            //determine where the tool is wrt to headland
            if (bnd.isHeadlandOn) bnd.WhereAreToolCorners();

            //set the look ahead for hyd Lift in pixels per second
            vehicle.hydLiftLookAheadDistanceLeft = tool.farLeftSpeed * vehicle.hydLiftLookAheadTime * 10;
            vehicle.hydLiftLookAheadDistanceRight = tool.farRightSpeed * vehicle.hydLiftLookAheadTime * 10;

            if (vehicle.hydLiftLookAheadDistanceLeft > 200) vehicle.hydLiftLookAheadDistanceLeft = 200;
            if (vehicle.hydLiftLookAheadDistanceRight > 200) vehicle.hydLiftLookAheadDistanceRight = 200;

            tool.lookAheadDistanceOnPixelsLeft = tool.farLeftSpeed * tool.lookAheadOnSetting * 10;
            tool.lookAheadDistanceOnPixelsRight = tool.farRightSpeed * tool.lookAheadOnSetting * 10;

            if (tool.lookAheadDistanceOnPixelsLeft > 200) tool.lookAheadDistanceOnPixelsLeft = 200;
            if (tool.lookAheadDistanceOnPixelsRight > 200) tool.lookAheadDistanceOnPixelsRight = 200;

            tool.lookAheadDistanceOffPixelsLeft = tool.farLeftSpeed * tool.lookAheadOffSetting * 10;
            tool.lookAheadDistanceOffPixelsRight = tool.farRightSpeed * tool.lookAheadOffSetting * 10;

            if (tool.lookAheadDistanceOffPixelsLeft > 160) tool.lookAheadDistanceOffPixelsLeft = 160;
            if (tool.lookAheadDistanceOffPixelsRight > 160) tool.lookAheadDistanceOffPixelsRight = 160;

            //determine if section is in boundary and headland using the section left/right positions
            bool isLeftIn = true, isRightIn = true;

            if (bnd.bndList.Count > 0)
            {
                for (int j = 0; j < tool.numOfSections; j++)
                {
                    //only one first left point, the rest are all rights moved over to left
                    isLeftIn = j == 0 ? bnd.IsPointInsideFenceArea(section[j].leftPoint) : isRightIn;
                    isRightIn = bnd.IsPointInsideFenceArea(section[j].rightPoint);

                    if (tool.isSectionOffWhenOut)
                    {
                        //merge the two sides into in or out
                        if (isLeftIn || isRightIn) section[j].isInBoundary = true;
                        else section[j].isInBoundary = false;
                    }
                    else
                    {
                        //merge the two sides into in or out
                        if (!isLeftIn || !isRightIn) section[j].isInBoundary = false;
                        else section[j].isInBoundary = true;
                    }
                }
            }

            //determine farthest ahead lookahead - is the height of the readpixel line
            double rpHeight = 0;
            double rpOnHeight = 0;
            double rpToolHeight = 0;

            //pick the larger side
            if (vehicle.hydLiftLookAheadDistanceLeft > vehicle.hydLiftLookAheadDistanceRight) rpToolHeight = vehicle.hydLiftLookAheadDistanceLeft;
            else rpToolHeight = vehicle.hydLiftLookAheadDistanceRight;

            if (tool.lookAheadDistanceOnPixelsLeft > tool.lookAheadDistanceOnPixelsRight) rpOnHeight = tool.lookAheadDistanceOnPixelsLeft;
            else rpOnHeight = tool.lookAheadDistanceOnPixelsRight;

            isHeadlandClose = false;

            //clamp the height after looking way ahead, this is for switching off super section only
            rpOnHeight = Math.Abs(rpOnHeight);
            rpToolHeight = Math.Abs(rpToolHeight);

            //10 % min is required for overlap, otherwise it never would be on.
            int pixLimit = (int)((double)(section[0].rpSectionWidth * rpOnHeight) / (double)(5.0));

            if ((rpOnHeight < rpToolHeight && bnd.isHeadlandOn && bnd.isSectionControlledByHeadland)) rpHeight = rpToolHeight + 2;
            else rpHeight = rpOnHeight + 2;

            if (rpHeight > 290) rpHeight = 290;
            if (rpHeight < 8) rpHeight = 8;

            //read the whole block of pixels up to max lookahead, one read only
            GL.ReadPixels(tool.rpXPosition, 0, tool.rpWidth, (int)rpHeight, OpenTK.Graphics.OpenGL.PixelFormat.Green, PixelType.UnsignedByte, grnPixels);

            //Paint to context for troubleshooting
            //oglBack.MakeCurrent();
            //oglBack.SwapBuffers();

            //determine if headland is in read pixel buffer left middle and right. 
            int start = 0, end = 0, tagged = 0, totalPixel = 0;

            //slope of the look ahead line
            double mOn = 0, mOff = 0;

            //tram and hydraulics
            if (isTramOnBackBuffer && tool.width > vehicle.trackWidth)
            {
                tram.controlByte = 0;
                //1 pixels in is there a tram line?
                if (tram.isOuter)
                {
                    if (grnPixels[(int)(tram.halfWheelTrack * 10)] == 245) tram.controlByte += 2;
                    if (grnPixels[tool.rpWidth - (int)(tram.halfWheelTrack * 10)] == 245) tram.controlByte += 1;
                }
                else
                {
                    if (grnPixels[tool.rpWidth / 2 - (int)(tram.halfWheelTrack * 10)] == 245) tram.controlByte += 2;
                    if (grnPixels[tool.rpWidth / 2 + (int)(tram.halfWheelTrack * 10)] == 245) tram.controlByte += 1;
                }
            }

            //determine if in or out of headland, do hydraulics if on
            if (bnd.isHeadlandOn)
            {
                //calculate the slope
                double m = (vehicle.hydLiftLookAheadDistanceRight - vehicle.hydLiftLookAheadDistanceLeft) / tool.rpWidth;
                int height = 1;

                for (int pos = 0; pos < tool.rpWidth; pos++)
                {
                    height = (int)(vehicle.hydLiftLookAheadDistanceLeft + (m * pos)) - 1;
                    for (int a = pos; a < height * tool.rpWidth; a += tool.rpWidth)
                    {
                        if (grnPixels[a] == 250)
                        {
                            isHeadlandClose = true;
                            goto GetOutTool;
                        }
                    }
                }

            GetOutTool: //goto

                //is the tool completely in the headland or not
                bnd.isToolInHeadland = bnd.isToolOuterPointsInHeadland && !isHeadlandClose;

                //set hydraulics based on tool in headland or not
                bnd.SetHydPosition();
            }

            ///////////////////////////////////////////   Section control        ssssssssssssssssssssss

            int endHeight = 1, startHeight = 1;

            if (bnd.isHeadlandOn && bnd.isSectionControlledByHeadland) bnd.WhereAreToolLookOnPoints();

            for (int j = 0; j < tool.numOfSections; j++)
            {
                //Off or too slow or going backwards
                if (section[j].sectionBtnState == btnStates.Off || avgSpeed < vehicle.slowSpeedCutoff || section[j].speedPixels < 0)
                {
                    section[j].sectionOnRequest = false;
                    section[j].sectionOffRequest = true;

                    // Manual on, force the section On
                    if (section[j].sectionBtnState == btnStates.On)
                    {
                        section[j].sectionOnRequest = true;
                        section[j].sectionOffRequest = false;
                        continue;
                    }
                    continue;
                }

                // Manual on, force the section On
                if (section[j].sectionBtnState == btnStates.On)
                {
                    section[j].sectionOnRequest = true;
                    section[j].sectionOffRequest = false;
                    continue;
                }


                //AutoSection - If any nowhere applied, send OnRequest, if its all green send an offRequest
                section[j].isSectionRequiredOn = false;

                //calculate the slopes of the lines
                mOn = (tool.lookAheadDistanceOnPixelsRight - tool.lookAheadDistanceOnPixelsLeft) / tool.rpWidth;
                mOff = (tool.lookAheadDistanceOffPixelsRight - tool.lookAheadDistanceOffPixelsLeft) / tool.rpWidth;

                start = section[j].rpSectionPosition - section[0].rpSectionPosition;
                end = section[j].rpSectionWidth - 1 + start;

                if (end >= tool.rpWidth)
                    end = tool.rpWidth - 1;

                totalPixel = 1;
                tagged = 0;

                for (int pos = start; pos <= end; pos++)
                {
                    startHeight = (int)(tool.lookAheadDistanceOffPixelsLeft + (mOff * pos)) * tool.rpWidth + pos;
                    endHeight = (int)(tool.lookAheadDistanceOnPixelsLeft + (mOn * pos)) * tool.rpWidth + pos;

                    for (int a = startHeight; a <= endHeight; a += tool.rpWidth)
                    {
                        totalPixel++;
                        if (grnPixels[a] == 0) tagged++;
                    }
                }

                //determine if meeting minimum coverage
                section[j].isSectionRequiredOn = ((tagged * 100) / totalPixel > (100 - tool.minCoverage));

                //logic if in or out of boundaries or headland
                if (bnd.bndList.Count > 0)
                {
                    //if out of boundary, turn it off
                    if (!section[j].isInBoundary)
                    {
                        section[j].isSectionRequiredOn = false;
                        section[j].sectionOffRequest = true;
                        section[j].sectionOnRequest = false;
                        section[j].sectionOffTimer = 0;
                        section[j].sectionOnTimer = 0;
                        continue;
                    }
                    else
                    {
                        //is headland coming up
                        if (bnd.isHeadlandOn && bnd.isSectionControlledByHeadland)
                        {
                            bool isHeadlandInLookOn = false;

                            //is headline in off to on area
                            mOn = (tool.lookAheadDistanceOnPixelsRight - tool.lookAheadDistanceOnPixelsLeft) / tool.rpWidth;
                            mOff = (tool.lookAheadDistanceOffPixelsRight - tool.lookAheadDistanceOffPixelsLeft) / tool.rpWidth;

                            start = section[j].rpSectionPosition - section[0].rpSectionPosition;

                            end = section[j].rpSectionWidth - 1 + start;

                            if (end >= tool.rpWidth)
                                end = tool.rpWidth - 1;

                            tagged = 0;

                            for (int pos = start; pos <= end; pos++)
                            {
                                startHeight = (int)(tool.lookAheadDistanceOffPixelsLeft + (mOff * pos)) * tool.rpWidth + pos;
                                endHeight = (int)(tool.lookAheadDistanceOnPixelsLeft + (mOn * pos)) * tool.rpWidth + pos;

                                for (int a = startHeight; a <= endHeight; a += tool.rpWidth)
                                {
                                    if (a < 0)
                                        mOn = 0;
                                    if (grnPixels[a] == 250)
                                    {
                                        isHeadlandInLookOn = true;
                                        goto GetOutHdOn;
                                    }
                                }
                            }
                        GetOutHdOn:

                            //determine if look ahead points are completely in headland
                            if (section[j].isSectionRequiredOn && section[j].isLookOnInHeadland && !isHeadlandInLookOn)
                            {
                                section[j].isSectionRequiredOn = false;
                                section[j].sectionOffRequest = true;
                                section[j].sectionOnRequest = false;
                            }

                            if (section[j].isSectionRequiredOn && !section[j].isLookOnInHeadland && isHeadlandInLookOn)
                            {
                                section[j].isSectionRequiredOn = true;
                                section[j].sectionOffRequest = false;
                                section[j].sectionOnRequest = true;
                            }
                        }
                    }
                }


                //global request to turn on section
                section[j].sectionOnRequest = section[j].isSectionRequiredOn;
                section[j].sectionOffRequest = !section[j].sectionOnRequest;

            }  // end of go thru all sections "for"

            //Set all the on and off times based from on off section requests
            for (int j = 0; j < tool.numOfSections; j++)
            {
                //SECTION timers

                if (section[j].sectionOnRequest)
                    section[j].isSectionOn = true;

                //turn off delay
                if (tool.turnOffDelay > 0)
                {
                    if (!section[j].sectionOffRequest) section[j].sectionOffTimer = (int)(gpsHz / 2.0 * tool.turnOffDelay);

                    if (section[j].sectionOffTimer > 0) section[j].sectionOffTimer--;

                    if (section[j].sectionOffRequest && section[j].sectionOffTimer == 0)
                    {
                        if (section[j].isSectionOn) section[j].isSectionOn = false;
                    }
                }
                else
                {
                    if (section[j].sectionOffRequest)
                        section[j].isSectionOn = false;
                }

                //Mapping timers
                if (section[j].sectionOnRequest && !section[j].isMappingOn && section[j].mappingOnTimer == 0)
                {
                    section[j].mappingOnTimer = (int)(tool.lookAheadOnSetting * (gpsHz/2) - 1);
                }
                else if (section[j].sectionOnRequest && section[j].isMappingOn && section[j].mappingOffTimer > 1)
                {
                    section[j].mappingOffTimer = 0;
                    section[j].mappingOnTimer = (int)(tool.lookAheadOnSetting * (gpsHz/2) - 1);
                }

                if (tool.lookAheadOffSetting > 0)
                {
                    if (section[j].sectionOffRequest && section[j].isMappingOn && section[j].mappingOffTimer == 0)
                    {
                        section[j].mappingOffTimer = (int)(tool.lookAheadOffSetting * (gpsHz/2) + 4);
                    }
                }
                else if (tool.turnOffDelay > 0)
                {
                    if (section[j].sectionOffRequest && section[j].isMappingOn && section[j].mappingOffTimer == 0)
                        section[j].mappingOffTimer = (int)(tool.turnOffDelay * gpsHz / 2);
                }
                else
                {
                    section[j].mappingOffTimer = 0;
                }

                //MAPPING - Not the making of triangle patches - only status - on or off
                if (section[j].sectionOnRequest)
                {
                    section[j].mappingOffTimer = 0;
                    if (section[j].mappingOnTimer > 1)
                        section[j].mappingOnTimer--;
                    else
                    {
                        section[j].isMappingOn = true;
                    }
                }

                if (section[j].sectionOffRequest)
                {
                    section[j].mappingOnTimer = 0;
                    if (section[j].mappingOffTimer > 1)
                        section[j].mappingOffTimer--;
                    else
                    {
                        section[j].isMappingOn = false;
                    }
                }
            }

            //Checks the workswitch or steerSwitch if required
            if (ahrs.isAutoSteerAuto || mc.isRemoteWorkSystemOn)
                mc.CheckWorkAndSteerSwitch();

            // check if any sections have changed status
            number = 0;

            for (int j = 0; j < tool.numOfSections; j++)
            {
                if (section[j].isMappingOn)
                {
                    number |= 1ul << j;
                }
            }

            //there has been a status change of section on/off
            if (number != lastNumber)
            {
                int sectionOnOffZones = 0, patchingZones=0;

                //everything off
                if (number == 0)
                {
                    for (int j = 0; j < triStrip.Count; j++)
                    {
                        if (triStrip[j].isDrawing)
                            triStrip[j].TurnMappingOff();
                    }
                }
                else if (!tool.isMultiColoredSections)
                {
                    //set the start and end positions from section points
                    for (int j = 0; j < tool.numOfSections; j++)
                    {
                        //skip till first mapping section
                        if (!section[j].isMappingOn) continue;

                        //do we need more patches created
                        if (triStrip.Count < sectionOnOffZones + 1)
                            triStrip.Add(new CPatches(this));

                        //set this strip start edge to edge of this section
                        triStrip[sectionOnOffZones].newStartSectionNum = j;

                        while ((j + 1) < tool.numOfSections && section[j + 1].isMappingOn)
                        {
                            j++;
                        }

                        //set the edge of this section to be end edge of strp
                        triStrip[sectionOnOffZones].newEndSectionNum = j;
                        sectionOnOffZones++;
                    }

                    //count current patch strips being made
                    for (int j = 0; j < triStrip.Count; j++)
                    {
                        if (triStrip[j].isDrawing) patchingZones++;
                    }

                    //tests for creating new strips or continuing
                    bool isOk = (patchingZones == sectionOnOffZones && sectionOnOffZones < 3);

                    if (isOk)
                    {
                        for (int j = 0; j < sectionOnOffZones; j++)
                        {
                            if (triStrip[j].newStartSectionNum > triStrip[j].currentEndSectionNum
                                || triStrip[j].newEndSectionNum < triStrip[j].currentStartSectionNum)
                                isOk = false;
                        }
                    }

                    if (isOk)
                    {
                        for (int j = 0; j < sectionOnOffZones; j++)
                        {
                            if (triStrip[j].newStartSectionNum != triStrip[j].currentStartSectionNum
                                || triStrip[j].newEndSectionNum != triStrip[j].currentEndSectionNum)
                            {
                                //if (tool.isSectionsNotZones)
                                {
                                    triStrip[j].AddMappingPoint(0);
                                }

                                triStrip[j].currentStartSectionNum = triStrip[j].newStartSectionNum;
                                triStrip[j].currentEndSectionNum = triStrip[j].newEndSectionNum;
                                triStrip[j].AddMappingPoint(0);
                            }
                        }
                    }
                    else
                    {
                        //too complicated, just make new strips
                        for (int j = 0; j < triStrip.Count; j++)
                        {
                            if (triStrip[j].isDrawing)
                                triStrip[j].TurnMappingOff();
                        }

                        for (int j = 0; j < sectionOnOffZones; j++)
                        {
                            triStrip[j].currentStartSectionNum = triStrip[j].newStartSectionNum;
                            triStrip[j].currentEndSectionNum = triStrip[j].newEndSectionNum;
                            triStrip[j].TurnMappingOn(0);
                        }
                    }
                }
                else if (tool.isMultiColoredSections) //could be else only but this is more clear
                {
                    //set the start and end positions from section points
                    for (int j = 0; j < tool.numOfSections; j++)
                    {
                        //do we need more patches created
                        if (triStrip.Count < sectionOnOffZones + 1)
                            triStrip.Add(new CPatches(this));

                        //set this strip start edge to edge of this section
                        triStrip[sectionOnOffZones].newStartSectionNum = j;

                        //set the edge of this section to be end edge of strp
                        triStrip[sectionOnOffZones].newEndSectionNum = j;
                        sectionOnOffZones++;

                        if (!section[j].isMappingOn)
                        {
                            if (triStrip[j].isDrawing)
                                triStrip[j].TurnMappingOff();
                        }
                        else
                        {
                            triStrip[j].currentStartSectionNum = triStrip[j].newStartSectionNum;
                            triStrip[j].currentEndSectionNum = triStrip[j].newEndSectionNum;
                            triStrip[j].TurnMappingOn(j);
                        }
                    }
                }


                lastNumber = number;
            }        

            //send the byte out to section machines
            BuildMachineByte();

            //if a minute has elapsed save the field in case of crash and to be able to resume            
            if (minuteCounter > 30 && sentenceCounter < 20)
            {
                tmrWatchdog.Enabled = false;

                //don't save if no gps
                if (isJobStarted)
                {
                    //auto save the field patches, contours accumulated so far
                    FileSaveSections();
                    FileSaveContour();

                    //NMEA log file
                    if (isLogElevation) FileSaveElevation();
                    //FileSaveFieldKML();
                }

                if (isAutoDayNight && tenMinuteCounter > 600)
                {
                    tenMinuteCounter = 0;
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
                    }
                }

                //if its the next day, calc sunrise sunset for next day
                minuteCounter = 0;

                //set saving flag off
                isSavingFile = false;

                //go see if data ready for draw and position updates
                tmrWatchdog.Enabled = true;
            }
            //this is the end of the "frame". Now we wait for next NMEA sentence with a valid fix. 
        }

        //mapping change occured
        private ulong number = 0, lastNumber = 0;

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
            Matrix4 mat = Matrix4.CreatePerspectiveFieldOfView(1.0f, 1.0f, 100.0f, 5000.0f);
            GL.LoadMatrix(ref mat);

            GL.MatrixMode(MatrixMode.Modelview);
        }

        private void oglZoom_Paint(object sender, PaintEventArgs e)
        {

            if (isJobStarted)
            {
                //GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
                //GL.LoadIdentity();                  // Reset The View

                CalculateMinMax();
                ////back the camera up
                //GL.Translate(0, 0, -maxFieldDistance);
                //GL.Enable(EnableCap.Blend);

                ////translate to that spot in the world 
                //GL.Translate(-fieldCenterX, -fieldCenterY, 0);

                //GL.Color4(0.5, 0.5, 0.5, 0.5);
                ////draw patches j= # of sections
                //int count2;

                //for (int j = 0; j < tool.numSuperSection; j++)
                //{
                //    //every time the section turns off and on is a new patch
                //    int patchCount = section[j].patchList.Count;

                //    if (patchCount > 0)
                //    {
                //        //for every new chunk of patch
                //        foreach (var triList in section[j].patchList)
                //        {
                //            //draw the triangle in each triangle strip
                //            GL.Begin(PrimitiveType.TriangleStrip);
                //            count2 = triList.Count;
                //            //int mipmap = 2;

                //            ////if large enough patch and camera zoomed out, fake mipmap the patches, skip triangles
                //            //if (count2 >= (mipmap))
                //            //{
                //            //    int step = mipmap;
                //            //    for (int i = 0; i < count2; i += step)
                //            //    {
                //            //        GL.Vertex3(triList[i].easting, triList[i].northing, 0); i++;
                //            //        GL.Vertex3(triList[i].easting, triList[i].northing, 0); i++;

                //            //        //too small to mipmap it
                //            //        if (count2 - i <= (mipmap + 2))
                //            //            step = 0;
                //            //    }
                //            //}

                //            //else 
                //            //{
                //            for (int i = 1; i < count2; i++) GL.Vertex3(triList[i].easting, triList[i].northing, 0);
                //            //}
                //            GL.End();

                //        }
                //    }
                //} //end of section patches

                //GL.Flush();

                //int grnHeight = oglZoom.Height;
                //int grnWidth = oglZoom.Width;
                //byte[] overPix = new byte[grnHeight * grnWidth + 1];

                //GL.ReadPixels(0, 0, grnWidth, grnWidth, OpenTK.Graphics.OpenGL.PixelFormat.Green, PixelType.UnsignedByte, overPix);

                //int once = 0;
                //int twice = 0;
                //int more = 0;
                //int level = 0;
                //double total = 0;
                //double total2 = 0;

                ////50, 96, 112                
                //for (int i = 0; i < grnHeight * grnWidth; i++)
                //{

                //    if (overPix[i] > 105)
                //    {
                //        more++;
                //        level = overPix[i];
                //    }
                //    else if (overPix[i] > 85)
                //    {
                //        twice++;
                //        level = overPix[i];
                //    }
                //    else if (overPix[i] > 50)
                //    {
                //        once++;
                //    }
                //}
                //total = once + twice + more;
                //total2 = total + twice + more + more;

                //if (total2 > 0)
                //{
                //    fd.actualAreaCovered = (total / total2 * fd.workedAreaTotal);
                //    fd.overlapPercent = Math.Round(((1 - total / total2) * 100), 2);
                //}
                //else
                //{
                //    fd.actualAreaCovered = fd.overlapPercent = 0;
                //}

                ////GL.Flush();
                ////oglZoom.MakeCurrent();
                ////oglZoom.SwapBuffers();

                if (oglZoom.Width != 400)
                {
                    oglZoom.MakeCurrent();

                    GL.Disable(EnableCap.Blend);

                    GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
                    GL.LoadIdentity();                  // Reset The View

                    //back the camera up
                    GL.Translate(0, 0, -maxFieldDistance*0.92);

                    //translate to that spot in the world 
                    GL.Translate(-fieldCenterX, -fieldCenterY, 0);

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

                    //draw all the fences
                    bnd.DrawFenceLines();

                    GL.PointSize(8.0f);
                    GL.Begin(PrimitiveType.Points);
                    GL.Color3(0.95f, 0.90f, 0.0f);
                    GL.Vertex3(pivotAxlePos.easting, pivotAxlePos.northing, 0.0);
                    GL.End();

                    GL.PointSize(1.0f);

                    if (isDay) GL.Color3(sectionColorDay.R, sectionColorDay.G, sectionColorDay.B);
                    else GL.Color3(sectionColorDay.R, sectionColorDay.G, sectionColorDay.B);

                    //GL.Color3((byte)0, (byte)200, (byte)0);
                    int cnt, step, patchCount;
                    int mipmap = 8;

                    //draw patches j= # of sections
                    for (int j = 0; j < triStrip.Count; j++)
                    {
                        //every time the section turns off and on is a new patch
                        patchCount = triStrip[j].patchList.Count;

                        if (patchCount > 0)
                        {
                            //for every new chunk of patch
                            foreach (var triList in triStrip[j].patchList)
                            {
                                //draw the triangle in each triangle strip
                                GL.Begin(PrimitiveType.TriangleStrip);
                                cnt = triList.Count;

                                //if large enough patch and camera zoomed out, fake mipmap the patches, skip triangles
                                if (cnt >= (mipmap))
                                {
                                    step = mipmap;
                                    for (int i = 1; i < cnt; i += step)
                                    {
                                        GL.Vertex3(triList[i].easting, triList[i].northing, 0); i++;
                                        GL.Vertex3(triList[i].easting, triList[i].northing, 0); i++;

                                        //too small to mipmap it
                                        if (cnt - i <= (mipmap + 2))
                                            step = 0;
                                    }
                                }

                                else
                                {
                                    for (int i = 1; i < cnt; i++)
                                        GL.Vertex3(triList[i].easting, triList[i].northing, 0);
                                }
                                GL.End();

                            }
                        }
                    } //end of section patches

                    GL.Flush();

                    //byte[] overPix = new byte[oglZoom.Height * oglZoom.Width + 1];

                    //GL.ReadPixels(0, 0, oglZoom.Width, oglZoom.Width, OpenTK.Graphics.OpenGL.PixelFormat.Green, PixelType.UnsignedByte, overPix);

                    //int more = 0;

                    //for (int i = 0; i < oglZoom.Width * oglZoom.Width; i++)
                    //{

                    //    if (overPix[i] == 200)
                    //    {
                    //        more++;
                    //    }
                    //}

                    //double scale = ((maxFieldDistance * maxFieldDistance) / (oglZoom.Height * oglZoom.Width) * (double)more)/10000;

                    oglZoom.MakeCurrent();
                    oglZoom.SwapBuffers();
                }
            }
        }

        private void DrawManUTurnBtn()
        {
            GL.Enable(EnableCap.Texture2D);

            if (isUTurnOn)
            {
                GL.BindTexture(TextureTarget.Texture2D, texture[5]);        // Select Our Texture
                GL.Color3(0.90f, 0.90f, 0.293f);

                int two3 = oglMain.Width / 4;
                GL.Begin(PrimitiveType.Quads);              // Build Quad From A Triangle Strip
                {
                    GL.TexCoord2(0, 0); GL.Vertex2(-82 - two3, 30); // 
                    GL.TexCoord2(1, 0); GL.Vertex2(82 - two3, 30); // 
                    GL.TexCoord2(1, 1); GL.Vertex2(82 - two3, 90); // 
                    GL.TexCoord2(0, 1); GL.Vertex2(-82 - two3, 90); //
                }
                GL.End();
            }

            //lateral line move

            if (isLateralOn)
            {
                GL.BindTexture(TextureTarget.Texture2D, texture[19]);        // Select Our Texture
                GL.Color3(0.190f, 0.90f, 0.93f);
                int two3 = oglMain.Width / 4;
                GL.Begin(PrimitiveType.Quads);              // Build Quad From A Triangle Strip
                {
                    GL.TexCoord2(0, 0); GL.Vertex2(-82 - two3, 90); // 
                    GL.TexCoord2(1, 0); GL.Vertex2(82 - two3, 90); // 
                    GL.TexCoord2(1, 1); GL.Vertex2(82 - two3, 150); // 
                    GL.TexCoord2(0, 1); GL.Vertex2(-82 - two3, 150); //
                }
                GL.End();
            }

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
                GL.TexCoord2(0, 0); GL.Vertex2(-62 + two3, 40); // 
                GL.TexCoord2(1, 0); GL.Vertex2(62 + two3, 40); // 
                GL.TexCoord2(1, 1); GL.Vertex2(62 + two3, 110); // 
                GL.TexCoord2(0, 1); GL.Vertex2(-62 + two3, 110); //
            }
            else
            {
                GL.TexCoord2(1, 0); GL.Vertex2(-62 + two3, 40); // 
                GL.TexCoord2(0, 0); GL.Vertex2(62 + two3, 40); // 
                GL.TexCoord2(0, 1); GL.Vertex2(62 + two3, 110); // 
                GL.TexCoord2(1, 1); GL.Vertex2(-62 + two3, 110); //
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
                    font.DrawText(-40 + two3, 80, DistPivotFt);
                }
                else
                {
                    font.DrawText(-40 + two3, 80, yt.onA.ToString());
                }
            }
        }

        private void DrawSteerCircle()
        {
            int sizer = oglMain.Height/10;
            int center = oglMain.Width / 2 - sizer;
            int bottomSide = oglMain.Height - sizer/3;

            //draw the clock
            GL.Color4(0.9752f, 0.80f, 0.3f, 0.98);
            font.DrawText(center -210, oglMain.Height - 26, DateTime.Now.ToString("T"), 0.8);

            GL.PushMatrix();
            GL.Enable(EnableCap.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, texture[11]);        // Select Our Texture

            if (mc.steerSwitchHigh)
                GL.Color4(0.9752f, 0.0f, 0.03f, 0.98);
            else if (isAutoSteerBtnOn)
                GL.Color4(0.052f, 0.970f, 0.03f, 0.97);
            else
                GL.Color4(0.952f, 0.750f, 0.03f, 0.97);

            //we have lost connection to steer module
            if (steerModuleConnectedCounter++ > 30)
            {
                GL.Color4(0.952f, 0.093570f, 0.93f, 0.97);
            }

            GL.Translate(center, bottomSide, 0);
            GL.Rotate(ahrs.imuRoll, 0, 0, 1);

            GL.Begin(PrimitiveType.Quads);              // Build Quad From A Triangle Strip
            {
                GL.TexCoord2(0, 0); GL.Vertex2(-sizer, -sizer); // 
                GL.TexCoord2(1, 0); GL.Vertex2(sizer, -sizer); // 
                GL.TexCoord2(1, 1); GL.Vertex2(sizer, sizer); // 
                GL.TexCoord2(0, 1); GL.Vertex2(-sizer, sizer); //
            }
            GL.End();

            if ((ahrs.imuRoll != 88888))
            {
                string head = Math.Round(ahrs.imuRoll, 1).ToString();
                font.DrawText((int)(((head.Length) * -7)), -30, head, 0.8);
            }

            GL.PopMatrix();
            GL.Enable(EnableCap.Texture2D);

            // stationary part
            GL.BindTexture(TextureTarget.Texture2D, texture[12]);        // Select Our Pinion
            GL.PushMatrix();

            GL.Translate(center, bottomSide, 0);

            GL.Begin(PrimitiveType.Quads);              // Build Quad From A Triangle Strip
            {
                GL.TexCoord2(0, 0); GL.Vertex2(-sizer, -sizer); // 
                GL.TexCoord2(1, 0); GL.Vertex2(sizer, -sizer); // 
                GL.TexCoord2(1, 1); GL.Vertex2(sizer, sizer); // 
                GL.TexCoord2(0, 1); GL.Vertex2(-sizer, sizer); //
            }
            GL.End();

            GL.Disable(EnableCap.Texture2D);

            GL.PopMatrix();
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
                    form.Show(this);
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

                font.DrawText3D(flagPts[f].easting, flagPts[f].northing, "&" + flagPts[f].notes);
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
            double down = 13;
            GL.LineWidth(1);
            //GL.Translate(0, 0, 0.01);
            //offlineDistance *= -1;
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
            for (int i = -8; i < -1; i++) GL.Vertex2((i * 32), down);
            for (int i = 2; i < 9; i++) GL.Vertex2((i * 32), down);
            GL.End();

            GL.PointSize(4.0f);
            GL.Translate(0, 0, 0.01);

            //red left side
            GL.Color3(0.750f, 0.0f, 0.0f);
            GL.Begin(PrimitiveType.Points);
            for (int i = -8; i < -1; i++) GL.Vertex2((i * 32), down);

            //green right side
            GL.Color3(0.0f, 0.750f, 0.0f);
            for (int i = 2; i < 9; i++) GL.Vertex2((i * 32), down);
            GL.End();

            //Are you on the right side of line? So its green.
            if ((offlineDistance) < 0.0)
            {
                int dots = (dotDistance * -1 / lightbarCmPerPixel) + 1;

                GL.PointSize(24.0f);
                GL.Color3(0.0f, 0.0f, 0.0f);
                GL.Begin(PrimitiveType.Points);
                for (int i = 2; i < dots + 1; i++) GL.Vertex2((i * 32), down);
                GL.End();

                GL.PointSize(16.0f);
                GL.Color3(0.0f, 0.980f, 0.0f);
                GL.Begin(PrimitiveType.Points);
                for (int i = 1; i < dots; i++) GL.Vertex2((i * 32 + 32), down);
                GL.End();
                //return;
            }

            else //red side
            {
                int dots = (int)(dotDistance / lightbarCmPerPixel) + 1;

                GL.PointSize(24.0f);
                GL.Color3(0.0f, 0.0f, 0.0f);
                GL.Begin(PrimitiveType.Points);
                for (int i = 2; i < dots + 1; i++) GL.Vertex2((i * -32), down);
                GL.End();

                GL.PointSize(16.0f);
                GL.Color3(0.980f, 0.30f, 0.0f);
                GL.Begin(PrimitiveType.Points);
                for (int i = 1; i < dots; i++) GL.Vertex2((i * -32 - 32), down);
                GL.End();
                //return;
            }

            ////yellow center dot
            //if (dotDistance >= -lightbarCmPerPixel && dotDistance <= lightbarCmPerPixel)
            //{
            //    GL.PointSize(32.0f);                
            //    GL.Color3(0.0f, 0.0f, 0.0f);
            //    GL.Begin(PrimitiveType.Points);
            //    GL.Vertex2(0, down);
            //    //GL.Vertex(0, down + 50);
            //    GL.End();

            //    GL.PointSize(24.0f);
            //    GL.Color3(0.980f, 0.98f, 0.0f);
            //    GL.Begin(PrimitiveType.Points);
            //    GL.Vertex2(0, down);
            //    //GL.Vertex(0, down + 50);
            //    GL.End();
            //}

            //else
            //{

            //    GL.PointSize(12.0f);
            //    GL.Color3(0.0f, 0.0f, 0.0f);
            //    GL.Begin(PrimitiveType.Points);
            //    GL.Vertex2(0, down);
            //    //GL.Vertex(0, down + 50);
            //    GL.End();

            //    GL.PointSize(8.0f);
            //    GL.Color3(0.980f, 0.98f, 0.0f);
            //    GL.Begin(PrimitiveType.Points);
            //    GL.Vertex2(0, down);
            //    //GL.Vertex(0, down + 50);
            //    GL.End();
            //}
        }

        private double avgPivDistance, lightbarDistance;
        private void DrawLightBarText()
        {

            GL.Disable(EnableCap.DepthTest);

            if (ct.isContourBtnOn || ABLine.isBtnABLineOn || curve.isBtnCurveOn || recPath.isDrivingRecordedPath)
            {

                //if (guidanceLineDistanceOff != 32000 && guidanceLineDistanceOff != 32020)

                // in millimeters
                avgPivDistance = avgPivDistance * 0.5 + lightbarDistance * 0.5;

                double avgPivotDistance = avgPivDistance * (isMetric ? 0.1 : 0.03937);
                string hede;

                DrawLightBar(oglMain.Width, oglMain.Height, avgPivotDistance);

                if (avgPivotDistance > 0.0)
                {
                    GL.Color3(0.9752f, 0.50f, 0.3f);
                    hede = "< " + (Math.Abs(avgPivotDistance)).ToString("N0");
                }
                else
                {
                    GL.Color3(0.50f, 0.952f, 0.3f);
                    hede = (Math.Abs(avgPivotDistance)).ToString("N0") + " >";
                }

                int center = -(int)(((double)(hede.Length) * 0.5) * 16);
                font.DrawText(center, 0, hede, 1);

                ////draw the modeTimeCounter
                //if (!isStanleyUsed)
                //{
                //    if (vehicle.modeTimeCounter > vehicle.modeTime * 10)
                //    {
                //        GL.Color3(0.09752f, 0.950f, 0.743f);
                //        font.DrawText(-23, 67, vehicle.goalDistance.ToString("N1"), 0.8);
                //    }
                //    else
                //    {
                //        GL.Color3(0.9752f, 0.50f, 0.43f);
                //        font.DrawText(-23, 67, vehicle.goalDistance.ToString("N1"), 0.8);
                //    }
                //}
            }
        }

        private void DrawRollBar()
        {
            //double set = guidanceLineSteerAngle * 0.01 * (40 / vehicle.maxSteerAngle);
            //double actual = actualSteerAngleDisp * 0.01 * (40 / vehicle.maxSteerAngle);
            //double hiit = 0;

            GL.PushMatrix();
            GL.Translate(oglMain.Width / -2 + 70, oglMain.Height-30, 0);

            GL.LineWidth(1);
            GL.Color3(0.24f, 0.64f, 0.74f);
            double wiid = 42;

            //If roll is used rotate graphic based on roll angle
 
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(-wiid - 15,0);
            GL.Vertex2(-wiid-2, 0);
            GL.Vertex2(wiid+2, 0);
            GL.Vertex2(wiid + 15, 0);
            GL.End();

            GL.Rotate(ahrs.imuRoll, 0.0f, 0.0f, 1.0f);

            GL.Color3(0.74f, 0.74f, 0.14f);
            GL.LineWidth(2);

            GL.Begin(PrimitiveType.LineStrip);
            GL.Vertex2(-wiid + 10, 15);
            GL.Vertex2(-wiid, 0);
            GL.Vertex2(wiid, 0);
            GL.Vertex2(wiid - 10, 15);
            GL.End();

            string head = Math.Round(ahrs.imuRoll, 1).ToString();
            int center = -(int)(((head.Length) * 6));

            font.DrawText(center, 0, head, 0.8);

            //GL.Translate(0, 10, 0);

            //{
            //    if (actualSteerAngleDisp > 0)
            //    {
            //        GL.LineWidth(1);
            //        GL.Begin(PrimitiveType.LineStrip);

            //        GL.Color3(0.0f, 0.75930f, 0.0f);
            //        GL.Vertex2(0, hiit);
            //        GL.Vertex2(actual, hiit + 8);
            //        GL.Vertex2(0, hiit + 16);
            //        GL.Vertex2(0, hiit);

            //        GL.End();
            //    }
            //    else
            //    {
            //        //actual
            //        GL.LineWidth(1);
            //        GL.Begin(PrimitiveType.LineStrip);

            //        GL.Color3(0.75930f, 0.0f, 0.0f);
            //        GL.Vertex2(-0, hiit);
            //        GL.Vertex2(actual, hiit + 8);
            //        GL.Vertex2(-0, hiit + 16);
            //        GL.Vertex2(-0, hiit);

            //        GL.End();
            //    }
            //}

            //if (guidanceLineSteerAngle > 0)
            //{
            //    GL.LineWidth(1);
            //    GL.Begin(PrimitiveType.LineStrip);

            //    GL.Color3(0.75930f, 0.75930f, 0.0f);
            //    GL.Vertex2(0, hiit);
            //    GL.Vertex2(set, hiit + 8);
            //    GL.Vertex2(0, hiit + 16);
            //    GL.Vertex2(0, hiit);

            //    GL.End();
            //}
            //else
            //{
            //    GL.LineWidth(1);
            //    GL.Begin(PrimitiveType.LineStrip);

            //    GL.Color3(0.75930f, 0.75930f, 0.0f);
            //    GL.Vertex2(-0, hiit);
            //    GL.Vertex2(set, hiit + 8);
            //    GL.Vertex2(-0, hiit + 16);
            //    GL.Vertex2(-0, hiit);

            //    GL.End();
            //}

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
                double hite = (camera.camPitch + 66) * -0.025;

                //the background
                double winLeftPos = -(double)oglMain.Width / 2;
                double winRightPos = -winLeftPos;

                if (isDay)
                {
                    GL.Color3(0.75, 0.75, 0.75);
                    GL.BindTexture(TextureTarget.Texture2D, texture[0]);        // Select Our Texture
                }
                else
                {
                    GL.Color3(0.5, 0.5, 0.5);
                    GL.BindTexture(TextureTarget.Texture2D, texture[10]);        // Select Our Texture
                }

                GL.Enable(EnableCap.Texture2D);

                double u = (fixHeading)/glm.twoPI;
                GL.Begin(PrimitiveType.TriangleStrip);              // Build Quad From A Triangle Strip
                GL.TexCoord2(u+0.25,      0); GL.Vertex2(winRightPos, 0.0); // Top Right
                GL.TexCoord2(u, 0); GL.Vertex2(winLeftPos, 0.0); // Top Left
                GL.TexCoord2(u+0.25,      1); GL.Vertex2(winRightPos, hite * oglMain.Height); // Bottom Right
                GL.TexCoord2(u, 1); GL.Vertex2(winLeftPos, hite * oglMain.Height); // Bottom Left
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

        string strHeading = "-0-";
        int lenth = 4;
        private void DrawCompassText()
        {
            int center = oglMain.Width / -2 + 10;

            GL.LineWidth(6);
            GL.Color3(0, 0.0, 0);
            GL.Begin(PrimitiveType.Lines);
            //-
            GL.Vertex3(-center - 17, 170, 0);
            GL.Vertex3(-center - 39, 170, 0);

            //+
            GL.Vertex3(-center - 17, 85, 0);
            GL.Vertex3(-center - 39, 85, 0);

            GL.Vertex3(-center - 27, 74, 0);
            GL.Vertex3(-center - 27, 96, 0);

            GL.End();

            GL.LineWidth(2);
            GL.Color3(0, 0.9, 0);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(-center - 17, 170, 0);
            GL.Vertex3(-center - 39, 170, 0);

            GL.Vertex3(-center - 18, 85, 0);
            GL.Vertex3(-center - 38, 85, 0);

            GL.Vertex3(-center - 27, 74, 0);
            GL.Vertex3(-center - 27, 96, 0);
            GL.End();

            //center += 10;
            GL.Color3(0.9852f, 0.982f, 0.983f);
            strHeading = (fixHeading * 57.2957795).ToString("N1");
            lenth = 15 * strHeading.Length;
            font.DrawText(oglMain.Width / 2 - lenth, 5, strHeading, 0.8);

            //GPS Step
            if (distanceCurrentStepFixDisplay < 0.03*100)
                GL.Color3(0.98f, 0.82f, 0.653f);
            font.DrawText(center, 5, distanceCurrentStepFixDisplay.ToString("N1") + "cm", 0.8);

            if (isMaxAngularVelocity)
            {
                GL.Color3(0.98f, 0.4f, 0.4f);
                font.DrawText(center, 60, "&", 4);
            }



            //if (ahrs.imuHeading != 99999)
            //{
            //    if (!isSuperSlow) GL.Color3(0.98f, 0.972f, 0.59903f);
            //    else GL.Color3(0.298f, 0.972f, 0.99903f);

            //    font.DrawText(center, 75, "Fix:" + (gpsHeading * 57.2957795).ToString("N1"), 0.8);
            //    font.DrawText(center, 100, "IMU:" + Math.Round(ahrs.imuHeading, 1).ToString(), 0.8);
            //    //font.DrawText(center, 135, "Y:" + Math.Round(ahrs.imuYawRate, 1).ToString(), 0.8);
            //}

            //if (isConstantContourOn)
            //{
            //    GL.Color3(0.852f, 0.652f, 0.93f);
            //    font.DrawText(center, 130, "Set " + ((int)(setAngVel)).ToString(), 1);

            //    GL.Color3(0.952f, 0.952f, 0.3f);
            //    font.DrawText(center, 160, "Act " + ahrs.angVel.ToString(), 1);

            //    if (errorAngVel > 0)  GL.Color3(0.2f, 0.952f, 0.53f);
            //    else GL.Color3(0.952f, 0.42f, 0.53f);

            //    font.DrawText(center, 200, "Err " + errorAngVel.ToString(), 1);
            //}

            //GL.Color3(0.9652f, 0.9752f, 0.1f);
            //font.DrawText(center, 150, "BETA 5.0.0.5", 1);

            GL.Color3(0.9752f, 0.62f, 0.325f);
            if (timerSim.Enabled) font.DrawText(-110, oglMain.Height - 130, "Simulator On", 1);

            if (ct.isContourBtnOn)
            {
                if (isFlashOnOff && ct.isLocked)
                {
                    GL.Color3(0.9652f, 0.752f, 0.75f);
                    font.DrawText(-center - 100, oglMain.Height / 2.3, "Locked", 1);
                }
            }

            //GL.Color3(0.9752f, 0.52f, 0.23f);
            //font.DrawText(center, 180, "SlowPoke", 1.0);


            //if (isFixHolding) font.DrawText(center, 110, "Holding", 0.8);

            //GL.Color3(0.9752f, 0.952f, 0.0f);
            //font.DrawText(center, 130, "Beta v4.2.02", 1.0);
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

        private void DrawReverse()
        {
            GL.Color3(0.952f, 0.980f, 0.980f);
            int lenny = (gStr.gsIfWrongDirectionTapVehicle.Length * 12) / 2;
            font.DrawText(-lenny, 150, gStr.gsIfWrongDirectionTapVehicle, 0.8f);

            if (isReverse) GL.Color3(0.952f, 0.0f, 0.0f);
            else GL.Color3(0.952f, 0.0f, 0.0f);

            if (isChangingDirection) GL.Color3(0.952f, 0.990f, 0.0f);

            GL.PushMatrix();
            GL.Enable(EnableCap.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, texture[9]);        // Select Our Texture



            GL.Translate(-oglMain.Width / 12, oglMain.Height / 2 - 20, 0);

            if (isChangingDirection) GL.Rotate(90, 0, 0, 1);
            else GL.Rotate(180, 0, 0, 1);

            GL.Begin(PrimitiveType.Quads);              // Build Quad From A Triangle Strip
            {
                GL.TexCoord2(0, 0.15); GL.Vertex2(-32, -32); // 
                GL.TexCoord2(1, 0.15); GL.Vertex2(32, -32.0); // 
                GL.TexCoord2(1, 1); GL.Vertex2(32, 32); // 
                GL.TexCoord2(0, 1); GL.Vertex2(-32, 32); //
            }
            GL.End();

            GL.Disable(EnableCap.Texture2D);
            GL.PopMatrix();
        }

        private void DrawLiftIndicator()
        {
            GL.PushMatrix();
            GL.Enable(EnableCap.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, texture[9]);        // Select Our Texture

            GL.Translate(oglMain.Width / 2 - 35, oglMain.Height/2, 0);

            if (p_239.pgn[p_239.hydLift] == 2)
            {
                GL.Color3(0.0f, 0.950f, 0.0f);
            }
            else
            {
                GL.Rotate(180, 0, 0, 1);
                GL.Color3(0.952f, 0.40f, 0.0f);
            }

            GL.Begin(PrimitiveType.Quads);              // Build Quad From A Triangle Strip
            {
                GL.TexCoord2(0, 0); GL.Vertex2(-48, -64); // 
                GL.TexCoord2(1, 0); GL.Vertex2(48, -64.0); // 
                GL.TexCoord2(1, 1); GL.Vertex2(48, 64); // 
                GL.TexCoord2(0, 1); GL.Vertex2(-48, 64); //
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
            GL.Color4(0.952f, 0.980f, 0.98f, 0.99);

            GL.Translate(oglMain.Width / 2 - 130, 65, 0);

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
                double aveSpd = Math.Abs(avgSpeed);
                if (aveSpd > 20) aveSpd = 20;
                angle = (aveSpd - 10) * 15;
            }
            else
            {
                double aveSpd = Math.Abs(avgSpeed*0.62137);
                if (aveSpd > 20) aveSpd = 20;
                angle = (aveSpd - 10) * 15;
            }

            if (avgSpeed > -0.1) GL.Color3(0.850f, 0.950f, 0.30f);
            else GL.Color3(0.952f, 0.0f, 0.0f);

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
        private void DrawLostRTK()
        {
            GL.Color3(0.9752f, 0.752f, 0.40f);
            font.DrawText(-oglMain.Width / 6, 125, "LOST RTK", 2.0);
        }

        private void DrawAge()
        {
            GL.Color3(0.9752f, 0.52f, 0.0f);
            font.DrawText(oglMain.Width / 4, 60, "Age:" + pn.age.ToString("N1"), 1.5);
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

        public double maxFieldX, maxFieldY, minFieldX, minFieldY, fieldCenterX, fieldCenterY, maxFieldDistance, maxCrossFieldLength;

        //determine mins maxs of patches and whole field.
        public void CalculateMinMax()
        {

            minFieldX = 9999999; minFieldY = 9999999;
            maxFieldX = -9999999; maxFieldY = -9999999;


            //min max of the boundary
            //min max of the boundary
            if (bnd.bndList.Count > 0)
            {
                int bndCnt = bnd.bndList[0].fenceLine.Count;
                for (int i = 0; i < bndCnt; i++)
                {
                    double x = bnd.bndList[0].fenceLine[i].easting;
                    double y = bnd.bndList[0].fenceLine[i].northing;

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
                for (int j = 0; j < triStrip.Count; j++)
                {
                    //every time the section turns off and on is a new patch
                    int patchCount = triStrip[j].patchList.Count;

                    if (patchCount > 0)
                    {
                        //for every new chunk of patch
                        foreach (var triList in triStrip[j].patchList)
                        {
                            int count2 = triList.Count;
                            for (int i = 1; i < count2; i += 3)
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
                maxFieldX = 0; minFieldX = 0; maxFieldY = 0; minFieldY = 0; maxFieldDistance = 1500;
            }
            else
            {
                //the largest distancew across field
                double dist = Math.Abs(minFieldX - maxFieldX);
                double dist2 = Math.Abs(minFieldY - maxFieldY);

                maxCrossFieldLength = Math.Sqrt(dist * dist + dist2 * dist2) * 1.0;

                if (dist > dist2) maxFieldDistance = (dist);
                else maxFieldDistance = (dist2);

                if (maxFieldDistance < 100) maxFieldDistance = 100;
                if (maxFieldDistance > 5000) maxFieldDistance = 5000;
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
    }
}
