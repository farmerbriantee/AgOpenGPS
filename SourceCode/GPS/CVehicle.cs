//Please, if you use this, share the improvements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;
using SharpGL.SceneGraph.Assets;

namespace AgOpenGPS
{
    public class CVehicle
    {
        private OpenGL gl;
        private FormGPS mainForm;

        public double toolWidth;
        public double toolOverlap;
        public double toolForeAft;
        public double antennaHeight;
        public double lookAhead;

        //is it flex hitch or rigidly attached
        public bool isHitched = true;

        //how many individual sections
        public int numberOfSections;

        public double toolFarLeftPosition = 0;
        public double toolFarRightPosition = 0;
 
        public CVehicle(OpenGL gl, FormGPS f)
        {
            //constructor
            this.gl = gl;
            this.mainForm = f;
        }

        public void DrawVehicle()
        {
            //translate to where the fix actually is
            gl.Translate(mainForm.fixPosX, mainForm.fixPosY, mainForm.fixPosZ);


            gl.Rotate(glm.degrees(mainForm.fixHeadingSection), 0.0, 1.0, 0.0);

            //draw the sections
            gl.LineWidth(6);
            gl.Begin(OpenGL.GL_LINES);
            for (int j = 0; j < mainForm.vehicle.numberOfSections; j++)
            {
                //if section is on green, if off puke red color
                if (mainForm.section[j].isSectionOn) gl.Color(0.0f, 0.99f, 0.0f);
                else gl.Color(0.8f, 0.3f, 0.3f);
                gl.Vertex(mainForm.section[j].positionLeft, 0, toolForeAft);
                gl.Vertex(mainForm.section[j].positionRight, 0, toolForeAft);
            gl.LineWidth(2);


            }            
            gl.End();
            gl.LineWidth(2);

            //draw the hitch
            gl.Color(0.0f, 0.0f, 0.0f);
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(0,0,toolForeAft); //hitch
            gl.Vertex(0, 0, toolForeAft+1.0);
            gl.End();

            //section markers
            gl.PointSize(4.0f);
            gl.Begin(OpenGL.GL_POINTS);

            for (int j = 1; j < mainForm.vehicle.numberOfSections - 1; j++)
            {
                gl.Vertex(mainForm.section[j].positionLeft, 0, toolForeAft);
                gl.Vertex(mainForm.section[j].positionRight, 0, toolForeAft);
            }
            gl.Vertex(0, 0, 0);
            gl.End();
            gl.LineWidth(1);

            //draw vehicle
            gl.Rotate(glm.degrees(-mainForm.fixHeadingSection), 0.0, 1.0, 0.0);
            gl.Rotate(glm.degrees(mainForm.fixHeading), 0.0, 1.0, 0.0);



            // Enable Texture Mapping and set color to white
            gl.Enable(OpenGL.GL_TEXTURE_2D);		
            gl.Color(1.0, 1.0, 1.0);

            //the vehicle
            gl.BindTexture(OpenGL.GL_TEXTURE_2D, mainForm.texture[0]);	// Select Our Texture
            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);				            // Build Quad From A Triangle Strip
            gl.TexCoord(0, 0); gl.Vertex(2.0, 0.0, 2.0);                // Top Right
            gl.TexCoord(1, 0); gl.Vertex(-2.0, 0.0, 2.0);               // Top Left
            gl.TexCoord(0, 1); gl.Vertex(2.0, 0.0, -2.0);               // Bottom Right
            gl.TexCoord(1, 1); gl.Vertex(-2.0, 0.0, -2.0);              // Bottom Left
            gl.End();						// Done Building Triangle Strip

        }
    }
}
