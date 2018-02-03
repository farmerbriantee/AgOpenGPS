//Please, if you use this, share the improvements

using System;
using SharpGL;

namespace AgOpenGPS
{
    public class CVehicle
    {
        private readonly OpenGL gl;
        private readonly FormGPS mf;

        public double toolWidth;
        public double toolFarLeftPosition = 0;
        public double toolFarLeftSpeed = 0;
        public double toolFarRightPosition = 0;
        public double toolFarRightSpeed = 0;

        public double toolOverlap;
        public double toolTrailingHitchLength, tankTrailingHitchLength;
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
        public int numOfSections;
        public int numSuperSection;

        //used for super section off on
        public int toolMinUnappliedPixels;
        public bool isSuperSectionAllowedOn;
        public bool areAllSectionBtnsOn = true;

        //read pixel values
        public int rpXPosition;
        public int rpWidth;

        //min vehicle speed allowed before turning shit off
        public double slowSpeedCutoff = 0;

        //autosteer values
        public double goalPointLookAhead;
        public double minLookAheadDistance = 6.0;
        public double maxSteerAngle;
        public double maxAngularVelocity;

        public CVehicle(OpenGL _gl, FormGPS _f)
        {
            //constructor
            gl = _gl;
            mf = _f;

            //from settings grab the vehicle specifics
            toolWidth = Properties.Vehicle.Default.setVehicle_toolWidth;
            toolOverlap = Properties.Vehicle.Default.setVehicle_toolOverlap;
            toolTrailingHitchLength = Properties.Vehicle.Default.setVehicle_toolTrailingHitchLength;
            tankTrailingHitchLength = Properties.Vehicle.Default.setVehicle_tankTrailingHitchLength;
            toolOffset = Properties.Vehicle.Default.setVehicle_toolOffset;

            isToolBehindPivot = Properties.Vehicle.Default.setVehicle_isToolBehindPivot;
            isToolTrailing = Properties.Vehicle.Default.setVehicle_isToolTrailing;

            isPivotBehindAntenna = Properties.Vehicle.Default.setVehicle_isPivotBehindAntenna;
            antennaHeight = Properties.Vehicle.Default.setVehicle_antennaHeight;
            antennaPivot = Properties.Vehicle.Default.setVehicle_antennaPivot;
            hitchLength = Properties.Vehicle.Default.setVehicle_hitchLength;

            wheelbase = Properties.Vehicle.Default.setVehicle_wheelbase;
            isSteerAxleAhead = Properties.Vehicle.Default.setVehicle_isSteerAxleAhead;

            toolLookAhead = Properties.Vehicle.Default.setVehicle_lookAhead;
            toolTurnOffDelay = Properties.Vehicle.Default.setVehicle_turnOffDelay;

            numOfSections = Properties.Vehicle.Default.setVehicle_numSections;
            numSuperSection = numOfSections+1;

            slowSpeedCutoff = Properties.Vehicle.Default.setVehicle_slowSpeedCutoff;
            toolMinUnappliedPixels = Properties.Vehicle.Default.setVehicle_minApplied;

            goalPointLookAhead = Properties.Vehicle.Default.setVehicle_goalPointLookAhead;
            maxAngularVelocity = Properties.Vehicle.Default.setVehicle_maxAngularVelocity;
            maxSteerAngle = Properties.Vehicle.Default.setVehicle_maxSteerAngle;
        }

        public void DrawVehicle()
        {
            //translate and rotate at pivot axle
            gl.Translate(mf.pn.easting, mf.pn.northing, 0);
            gl.PushMatrix();

            //most complicated translate ever!
            gl.Translate(Math.Sin(mf.fixHeading) * (hitchLength - antennaPivot),
                            Math.Cos(mf.fixHeading) * (hitchLength - antennaPivot), 0);

            //settings doesn't change trailing hitch length if set to rigid, so do it here
            double trailingTank, trailingTool;
            if (isToolTrailing)
            {
                trailingTank = tankTrailingHitchLength;
                trailingTool = toolTrailingHitchLength;
            }
            else { trailingTank = 0; trailingTool = 0; }

            //there is a trailing tow between hitch
            if (tankTrailingHitchLength < -2.0 && isToolTrailing)
            {
                gl.Rotate(glm.toDegrees(-mf.fixHeadingTank), 0.0, 0.0, 1.0);

                //draw the tank hitch
                gl.LineWidth(2);
                gl.Color(0.7f, 0.7f, 0.97f);

                gl.Begin(OpenGL.GL_LINES);
                gl.Vertex(0, trailingTank, 0);
                gl.Vertex(0, 0, 0);
                gl.End();

                //section markers
                gl.Color(0.95f, 0.950f, 0.0f);
                gl.PointSize(6.0f);
                gl.Begin(OpenGL.GL_POINTS);
                gl.Vertex(0, trailingTank, 0);
                gl.End();

                //move down the tank hitch, unwind, rotate to section heading
                gl.Translate(0, trailingTank, 0);
                gl.Rotate(glm.toDegrees(mf.fixHeadingTank), 0.0, 0.0, 1.0);
                gl.Rotate(glm.toDegrees(-mf.fixHeadingSection), 0.0, 0.0, 1.0);
            }

            //no tow between hitch
            else
            {
                gl.Rotate(glm.toDegrees(-mf.fixHeadingSection), 0.0, 0.0, 1.0);
            }

            //draw the hitch if trailing
            if (isToolTrailing)
            {
                gl.LineWidth(2);
                gl.Color(0.7f, 0.7f, 0.97f);

                gl.Begin(OpenGL.GL_LINES);
                gl.Vertex(0, trailingTool, 0);
                gl.Vertex(0, 0, 0);
                gl.End();
            }

            //draw the sections
            gl.LineWidth(8);
            gl.Begin(OpenGL.GL_LINES);

            //draw section line
            if (mf.section[numOfSections].isSectionOn)
            {
                if (mf.section[0].manBtnState == FormGPS.manBtn.Auto) gl.Color(0.0f, 0.97f, 0.0f);
                else gl.Color(0.99, 0.99, 0);
                gl.Vertex(mf.section[numOfSections].positionLeft, trailingTool, 0);
                gl.Vertex(mf.section[numOfSections].positionRight, trailingTool, 0);
            }
            else
            {
                for (int j = 0; j < mf.vehicle.numOfSections; j++)
                {
                    //if section is on, green, if off, red color
                    if (mf.section[j].isSectionOn)
                    {
                        if (mf.section[j].manBtnState == FormGPS.manBtn.Auto) gl.Color(0.0f, 0.97f, 0.0f);
                        else gl.Color(0.97, 0.97, 0);
                    }
                    else
                    {
                        gl.Color(0.97f, 0.2f, 0.2f);
                    }

                    //draw section line
                    gl.Vertex(mf.section[j].positionLeft, trailingTool, 0);
                    gl.Vertex(mf.section[j].positionRight, trailingTool, 0);
                }
            }

            gl.End();

            //draw section markers if close enough
            if (mf.camera.camSetDistance > -1500)
            {
                gl.Color(0.0f, 0.0f, 0.0f);
                //section markers
                gl.PointSize(4.0f);
                gl.Begin(OpenGL.GL_POINTS);
                for (int j = 0; j < mf.vehicle.numOfSections - 1; j++)
                    gl.Vertex(mf.section[j].positionRight, trailingTool, 0);
                gl.End();
            }

            //draw vehicle
            gl.PopMatrix();
            gl.Rotate(glm.toDegrees(-mf.fixHeading), 0.0, 0.0, 1.0);

            //draw the vehicle Body
            gl.Color(0.9, 0.5, 0.30);
            gl.Begin(OpenGL.GL_TRIANGLE_FAN);

            gl.Vertex(0, 0, -0.2);
            gl.Vertex(1.8, -antennaPivot, 0.0);
            gl.Vertex(0, -antennaPivot + wheelbase, 0.0);
            gl.Color(0.20, 0.0, 0.9);
            gl.Vertex(-1.8, -antennaPivot, 0.0);
            gl.Vertex(1.8, -antennaPivot, 0.0);
            gl.End();

            //draw the area side marker
            gl.Color(0.95f, 0.90f, 0.0f);
            gl.PointSize(4.0f);
            gl.Begin(OpenGL.GL_POINTS);
            if (mf.isAreaOnRight) gl.Vertex(2.0, -antennaPivot, 0);
            else gl.Vertex(-2.0, -antennaPivot, 0);

            //antenna
            gl.Color(0.0f, 0.98f, 0.0f);
            gl.Vertex(0, 0, 0);

            //hitch pin
            gl.Color(0.99f, 0.0f, 0.0f);
            gl.Vertex(0, mf.vehicle.hitchLength - antennaPivot, 0);

            ////rear Tires
            //gl.PointSize(12.0f);
            //gl.Color(0, 0, 0);
            //gl.Vertex(-1.8, 0, -antennaPivot);
            //gl.Vertex(1.8, 0, -antennaPivot);
            gl.End();

            gl.LineWidth(1);
            gl.Color(0.9, 0.95, 0.10);
            gl.Begin(OpenGL.GL_LINE_STRIP);
            {
                gl.Vertex(1.2, -antennaPivot + wheelbase + 8, 0.0);
                gl.Vertex(0, -antennaPivot + wheelbase + 10, 0.0);
                gl.Vertex(-1.2, -antennaPivot + wheelbase + 8, 0.0);
            }
            gl.End();

            //draw the rigid hitch
            gl.Color(0.37f, 0.37f, 0.97f);
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(0, mf.vehicle.hitchLength - antennaPivot, 0);
            gl.Vertex(0, -antennaPivot, 0);
            gl.End();

           gl.LineWidth(1);
        }
    }
}

