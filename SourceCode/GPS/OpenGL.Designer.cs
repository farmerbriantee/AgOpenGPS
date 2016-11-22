
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
        /// Handles the OpenGLDraw event of the openGLControl control.
        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {

            //sw.Stop();
            //int FPS = Convert.ToInt16(1 / (sw.Elapsed.TotalMilliseconds / 1000));
            //sw.Reset();
            ////start the watch and time till it gets back here
            //sw.Start();

            //if there is new data go update everything first.
            UpdateFixPosition();

            //Update the port counter
            recvCounter++;

            //Determine if sections want to be on or off
            ProcessSectionOnOffRequests();

            //send the byte out to section relays
            SectionControlOutToArduino();

            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();

            //camera does translations and rotations
            camera.SetWorldCam(gl, pivotAxleEasting, fixPosY, pivotAxleNorthing, fixHeadingCam);

            //Draw the world grid based on camera position
            gl.Disable(OpenGL.GL_DEPTH_TEST);
            gl.Disable(OpenGL.GL_TEXTURE_2D);
            worldGrid.DrawWorldGrid(gridZoom);

            // draw the current and reference AB Lines
            if (ABLine.isABLineSet | ABLine.isABLineBeingSet) ABLine.DrawABLines();

            //turn on blend for paths
            gl.Enable(OpenGL.GL_BLEND);
            gl.Disable(OpenGL.GL_DEPTH_TEST);

            //section patch color
            gl.Color(0.0f, 0.45f, 0.0f, 0.6f);
            if (isDrawPolygons) gl.PolygonMode(OpenGL.GL_FRONT, OpenGL.GL_LINE);

            //draw patches of sections
            for (int j = 0; j < vehicle.numberOfSections; j++)
            {
                //every time the section turns off and on is a new patch
                int patchCount = section[j].patchList.Count();

                if (patchCount > 0)
                {
                    //for every new chunk of patch
                    foreach (var triList in section[j].patchList)
                    {
                        //draw the triangle strip in each triangle strip
                        gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
                        int count2 = triList.Count();
                        for (int i = 0; i < count2; i++) gl.Vertex(triList[i].x, 0, triList[i].z);
                        gl.End();
                    }
                }
            }

            gl.PolygonMode(OpenGL.GL_FRONT, OpenGL.GL_FILL);

            //Draw vehicle track

            if (isDrawVehicleTrack)
            {
                //GPS Antenna
                gl.Color(0.9f, 0.45f, 0.9f, 0.6f);
                gl.Begin(OpenGL.GL_LINE_STRIP);//for every point in pointData
                foreach (var triList in pointAntenna) gl.Vertex(triList.easting, 0, triList.northing);
                gl.End();

                //Pivot Axle
                gl.Color(0.45f, 0.9f, 0.9f, 0.6f);
                gl.Begin(OpenGL.GL_LINE_STRIP);//for every point in pointData
                foreach (var triList2 in pointPivot) gl.Vertex(triList2.easting, 0, triList2.northing);
                gl.End();

                ////hitch
                //gl.Color(0.9f, 0.9f, 0.45f, 0.6f);
                //gl.Begin(OpenGL.GL_LINE_STRIP);//for every point in pointData
                //foreach (var triList3 in pointHitch) gl.Vertex(triList3.easting, 0, triList3.northing);
                //gl.End();

                //tool
                gl.Color(0.9f, 0.1f, 0.25f, 0.6f);
                gl.Begin(OpenGL.GL_LINE_STRIP);//for every point in pointData
                foreach (var triList4 in pointTool) gl.Vertex(triList4.easting, 0, triList4.northing);
                gl.End();
            }


            //gl.DrawText(100, 150, 1, 0, 0, "Verdana", 24, " fix " + Convert.ToString(fixHeading));
            //gl.DrawText(100, 180, 1, 0, 0, "Verdana", 24, " fixSection " + Convert.ToString(fixHeadingSection));
            //gl.DrawText(100, 210, 1, 1, 0, "Verdana", 24, " delta " + Convert.ToString(Math.Round(fixHeadingSection - fixHeading, 3)));
            //gl.DrawText(100, 240, 1, 1, 0, "Verdana", 24, " abs " + Convert.ToString(Math.Round(Math.PI - Math.Abs(Math.Abs(fixHeadingSection - fixHeading) - Math.PI),1)));

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
                gl.TexCoord(0, 1); gl.Vertex(winRightPos, 0.2 * (double)Height); // Bottom Right
                gl.TexCoord(1, 1); gl.Vertex(winLeftPos, 0.2 * (double)Height); // Bottom Left
                gl.End();						// Done Building Triangle Strip
                gl.Disable(OpenGL.GL_TEXTURE_2D);
            }

            //LightBar if AB Line is set
            if (ABLine.isABLineSet | ABLine.isABLineBeingSet)
            {
                txtDistanceOffABLine.Visible = true;
                ABLine.DrawLightBar(openGLControl.Width, openGLControl.Height);
                txtDistanceOffABLine.Text = Convert.ToString(Math.Abs(ABLine.distanceFromCurrentLine));
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

            gl.Disable(OpenGL.GL_CULL_FACE);
            //gl.CullFace(OpenGL.GL_BACK);


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
            gl.Perspective(50.0f, (double)openGLControl.Width / (double)openGLControl.Height, 1, -4 * camera.camSetDistance);

            //  Set the modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        #endregion


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
            gl.Rotate(-fixHeadingSection * 180.0 / Math.PI + 180, 0, 1, 0);

            //translate to that spot in the world 
            gl.Translate(-toolEasting, -fixPosY, -toolNorthing);

            //patch color
            gl.Color(0.0f, 1.0f, 0.0f);

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
                        //draw the triangle strip in each triangle strip
                        gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
                        int count2 = triList.Count();
                        for (int i = 0; i < count2; i++) gl.Vertex(triList[i].x, 0, triList[i].z);
                        gl.End();
                    }
                }
            }

            //10 pixels to a meter or 1 pixel is 10cm - simple math
            int rpXPosition = 200 - Math.Abs((int)(vehicle.toolFarLeftPosition * 10));
            int rpWidth = (int)(vehicle.toolWidth * 10);

            //read position for look ahead for turning on 
            double sectionLookAheadPosition = (pn.speed * vehicle.toolLookAhead * 2.0); //how far ahead ie up the screen
            if (sectionLookAheadPosition > 80) sectionLookAheadPosition = 80;

            //scan 3 different spots, one at 2 secs ahead and one at 1 sec and one at section
            gl.ReadPixels(rpXPosition, 200 + (int)(sectionLookAheadPosition * 0.6), rpWidth, 1,
                                OpenGL.GL_GREEN, OpenGL.GL_UNSIGNED_BYTE, pixelsBottom);
            gl.ReadPixels(rpXPosition, 200 + (int)(sectionLookAheadPosition * 0.8), rpWidth, 1,
                                OpenGL.GL_GREEN, OpenGL.GL_UNSIGNED_BYTE, pixelsMiddle);
            gl.ReadPixels(rpXPosition, 200 + (int)sectionLookAheadPosition, rpWidth, 1,
                                OpenGL.GL_GREEN, OpenGL.GL_UNSIGNED_BYTE, pixelsTop);

            //scan just ahead of the tool otherwise its too fussy and keep turning on section
            gl.ReadPixels(rpXPosition, 202, rpWidth, 1,
                                OpenGL.GL_GREEN, OpenGL.GL_UNSIGNED_BYTE, pixelsAtTool);


            ////OR them together, if anywhere isn't applied, turn on section
            for (int a = 0; a < 401; a++)
            {
                if (pixelsMiddle[a] < 10 | pixelsBottom[a] < 10 | pixelsAtTool[a] < 10
                    | pixelsTop[a] < 10) pixelsAtTool[a] = 0;
                else pixelsAtTool[a] = 255;
            }


            //if anywhere in the section is a 0, as in needs section turned on, turn on section and break out loop
            bool isSectionRequiredOn = false;
            int x = 0;
            for (int j = 0; j < vehicle.numberOfSections; j++)
            {
                //section width * 10 is measured in pixels
                for (int i = 0; i < (int)(section[j].sectionWidth * 10); i++)
                {
                    if (pixelsAtTool[x] < 50)
                    {
                        isSectionRequiredOn = true;
                        x += (int)(section[j].sectionWidth * 10) - i;
                        break;
                    }

                    x++;

                }

                if (isSectionRequiredOn && isMasterSectionOn)
                {
                    //global request to turn on section
                    section[j].sectionOnRequest = true;
                }

                else if (!isSectionRequiredOn)
                {
                    //global request to turn off section
                    section[j].sectionOffRequest = true;
                }

                //used in this loop only
                isSectionRequiredOn = false;
            }
            gl.Flush();

        }

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
