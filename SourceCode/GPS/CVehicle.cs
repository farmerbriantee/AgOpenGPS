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
        private FormGPS mf;

        public double toolWidth;
        public double toolFarLeftPosition = 0;
        public double toolFarRightPosition = 0;

        public double toolOverlap;
        public double toolTrailingHitchLength;
        public double toolOffset;

        public double toolTurnOffDelay;
        public double toolLookAhead;
 
        public bool isToolTrailing;        
        public bool isToolBehindPivot;
        public bool isSteerAxleAhead;

        //vehicle specific
        public bool isPivotBehindAntenna;

        public double antennaHeight;
        public double antennaPivot;
        public double wheelbase;
        public double hitchLength;

        //how many individual sections
        public int numberOfSections;

        public CVehicle(OpenGL gl, FormGPS f)
        {
            //constructor
            this.gl = gl;
            this.mf = f;

            //from settings grab the vehicle specifics
            toolWidth = Properties.Settings.Default.setVehicle_toolWidth;
            toolOverlap = Properties.Settings.Default.setVehicle_toolOverlap;
            toolTrailingHitchLength = Properties.Settings.Default.setVehicle_toolTrailingHitchLength;
            toolOffset = Properties.Settings.Default.setVehicle_toolOffset;

            isToolBehindPivot = Properties.Settings.Default.setVehicle_isToolBehindPivot;            
            isToolTrailing = Properties.Settings.Default.setVehicle_isToolTrailing;

            isPivotBehindAntenna = Properties.Settings.Default.setVehicle_isPivotBehindAntenna;
            antennaHeight = Properties.Settings.Default.setVehicle_antennaHeight;
            antennaPivot = Properties.Settings.Default.setVehicle_antennaPivot;
            hitchLength = Properties.Settings.Default.setVehicle_hitchLength;

            wheelbase = Properties.Settings.Default.setVehicle_wheelbase;
            isSteerAxleAhead = Properties.Settings.Default.setVehicle_isSteerAxleAhead;

            toolLookAhead = Properties.Settings.Default.setVehicle_lookAhead;
            toolTurnOffDelay = Properties.Settings.Default.setVehicle_turnOffDelay;

            numberOfSections = Properties.Settings.Default.setVehicle_numSections;
        }

        public void DrawVehicle()
        {
            //translate and rotate at pivot axle
            gl.Translate(mf.fixPosX, 0, mf.fixPosZ);
            gl.PushMatrix();
            
            //most complicated translate ever!
            gl.Translate((Math.Sin(mf.fixHeading) * (hitchLength - antennaPivot)),0,(Math.Cos(mf.fixHeading) * (hitchLength - antennaPivot)));
            gl.Rotate(glm.degrees(mf.fixHeadingSection), 0.0, 1.0, 0.0);
            
            //settings doesn't change trailing hitch length if set to rigid, so do it here
            double trailing;
            if (isToolTrailing) trailing = toolTrailingHitchLength;
            else trailing = 0;
            
            //draw the sections
            gl.LineWidth(8);
            gl.Begin(OpenGL.GL_LINES);
            for (int j = 0; j < mf.vehicle.numberOfSections; j++)
            {
                //if section is on green, if off red color
                if (mf.section[j].isSectionOn)
                {
                    if (mf.section[j].manBtnState == AgOpenGPS.FormGPS.manBtn.Auto) gl.Color(0.0f, 0.99f, 0.0f);
                    else gl.Color(0.99, 0.99, 0);
                }
                else gl.Color(0.99f, 0.2f, 0.2f);

                //draw section line
                gl.Vertex(mf.section[j].positionLeft, 0, trailing);
                gl.Vertex(mf.section[j].positionRight, 0, trailing);
            }
            gl.End();

            //draw the hitch
            gl.LineWidth(2);
            gl.Color(0.0f, 0.0f, 0.0f);

            gl.Begin(OpenGL.GL_LINES);
                gl.Vertex(0, 0, trailing);
                gl.Vertex(0, 0, 0);
            gl.End();

            //section markers
            gl.PointSize(4.0f);
            gl.Begin(OpenGL.GL_POINTS);
                for (int j = 0; j < mf.vehicle.numberOfSections - 1; j++)
                    gl.Vertex(mf.section[j].positionRight, 0, trailing);
            gl.End();
 
            //draw vehicle
            gl.PopMatrix();
            gl.Rotate(glm.degrees(mf.fixHeading), 0.0, 1.0, 0.0);
                        
            //draw the vehicle Body
            gl.Color(1.0, 0.5, 0.30);
            gl.Begin(OpenGL.GL_TRIANGLE_FAN);

                gl.Vertex(0, -1.0, 0);
                gl.Vertex(1.8, 0.0, -antennaPivot);
                gl.Vertex(0, 0.0, -antennaPivot+wheelbase);
                gl.Color(0.20, 0.0, 1.0);
                gl.Vertex(-1.8, 0.0, -antennaPivot);
                gl.Vertex(1.8, 0.0, -antennaPivot);

            gl.End();
            
            //draw the points
            gl.PointSize(8.0f);
            gl.Begin(OpenGL.GL_POINTS);

            ////antenna
            //gl.Color(0.0f, 1.0f, 0.0f);
            //gl.Vertex(0, 0, 0);

            ////hitch pin
            //gl.Color(0.99f, 0.99f, 0.0f);
            //gl.Vertex(0, 0, mf.vehicle.hitchLength - antennaPivot);

            //rear Tires
            //gl.PointSize(12.0f);
            gl.Color(0, 0, 0);
            gl.Vertex(-1.8, 0, -antennaPivot);
            gl.Vertex(1.8, 0, -antennaPivot);

            gl.End();



            gl.LineWidth(1);

        }
    }
}


//gl.Color(0.0f, 0.99f, 0.0f);
//gl.Begin(OpenGL.GL_LINES);
//gl.Vertex(-1.8, 0, -antennaPivot);
//gl.Vertex(1.8, 0, -antennaPivot);
//gl.Vertex(-1.2, 0, -antennaPivot+wheelbase);
//gl.Vertex(1.2, 0, -antennaPivot+wheelbase);
//gl.End();

// Enable Texture Mapping and set color to white
//gl.Enable(OpenGL.GL_TEXTURE_2D);		
////the vehicle
//gl.BindTexture(OpenGL.GL_TEXTURE_2D, mf.texture[0]);	// Select Our Texture
//gl.Begin(OpenGL.GL_TRIANGLE_STRIP);				            // Build Quad From A Triangle Strip
//gl.TexCoord(0, 0); gl.Vertex(2.0, 0.0, 2.0);                // Top Right
//gl.TexCoord(1, 0); gl.Vertex(-2.0, 0.0, 2.0);               // Top Left
//gl.TexCoord(0, 1); gl.Vertex(2.0, 0.0, -2.0);               // Bottom Right
//gl.TexCoord(1, 1); gl.Vertex(-2.0, 0.0, -2.0);              // Bottom Left
//gl.End();						// Done Building Triangle Strip

////axle pivot
//gl.Color(0.0f, 0.99f, 0.5f);
//gl.Vertex(0, 0, -antennaPivot);

////steering Tires
//gl.Vertex(-1.2, 0, -antennaPivot+wheelbase);
//gl.Vertex(1.2, 0, -antennaPivot+wheelbase);

 
