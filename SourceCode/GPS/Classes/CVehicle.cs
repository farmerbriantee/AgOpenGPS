//Please, if you use this, share the improvements

using OpenTK.Graphics.OpenGL;
using System;

namespace AgOpenGPS
{
    public class CVehicle
    {
        private readonly FormGPS mf;

        public double toolWidth;
        public double toolFarLeftPosition = 0;
        public double toolFarLeftSpeed = 0;
        public double toolFarRightPosition = 0;
        public double toolFarRightSpeed = 0;
        //public double toolFarLeftContourSpeed = 0, toolFarRightContourSpeed = 0;

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
        public double minTurningRadius;
        public double antennaOffset;

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
        public double goalPointLookAheadSeconds, goalPointLookAheadMinimumDistance, goalPointDistanceMultiplier, goalPointLookAheadUturnMult;
        public double stanleyGain, stanleyHeadingErrorGain;
        public double minLookAheadDistance = 2.0;
        public double maxSteerAngle;
        public double maxAngularVelocity;
        public double treeSpacing;

        public CVehicle(FormGPS _f)
        {
            //constructor
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
            antennaOffset = Properties.Vehicle.Default.setVehicle_antennaOffset;

            wheelbase = Properties.Vehicle.Default.setVehicle_wheelbase;
            minTurningRadius = Properties.Vehicle.Default.setVehicle_minTurningRadius;
            isSteerAxleAhead = Properties.Vehicle.Default.setVehicle_isSteerAxleAhead;

            toolLookAhead = Properties.Vehicle.Default.setVehicle_lookAhead;
            toolTurnOffDelay = Properties.Vehicle.Default.setVehicle_turnOffDelay;

            numOfSections = Properties.Vehicle.Default.setVehicle_numSections;
            numSuperSection = numOfSections + 1;

            slowSpeedCutoff = Properties.Vehicle.Default.setVehicle_slowSpeedCutoff;
            toolMinUnappliedPixels = Properties.Vehicle.Default.setVehicle_minApplied;

            goalPointLookAheadSeconds = Properties.Vehicle.Default.setVehicle_goalPointLookAhead;
            goalPointLookAheadMinimumDistance = Properties.Vehicle.Default.setVehicle_lookAheadMinimum;
            goalPointDistanceMultiplier = Properties.Vehicle.Default.setVehicle_lookAheadDistanceFromLine;
            goalPointLookAheadUturnMult = Properties.Vehicle.Default.setVehicle_goalPointLookAheadUturnMult;

            stanleyGain = Properties.Vehicle.Default.setVehicle_stanleyGain;
            stanleyHeadingErrorGain = Properties.Vehicle.Default.setVehicle_stanleyHeadingErrorGain;

            maxAngularVelocity = Properties.Vehicle.Default.setVehicle_maxAngularVelocity;
            maxSteerAngle = Properties.Vehicle.Default.setVehicle_maxSteerAngle;

            treeSpacing = Properties.Settings.Default.setDistance_TreeSpacing;
        }

        public double UpdateGoalPointDistance(double distanceFromCurrentLine)
        {
            //how far should goal point be away  - speed * seconds * kmph -> m/s then limit min value
            double goalPointDistance = mf.pn.speed * goalPointLookAheadSeconds * 0.27777777;

            if (distanceFromCurrentLine < 1.0)
                goalPointDistance += distanceFromCurrentLine * goalPointDistance * mf.vehicle.goalPointDistanceMultiplier;
            else
                goalPointDistance += goalPointDistance * mf.vehicle.goalPointDistanceMultiplier;

            if (goalPointDistance < mf.vehicle.goalPointLookAheadMinimumDistance) goalPointDistance = mf.vehicle.goalPointLookAheadMinimumDistance;

            mf.lookaheadActual = goalPointDistance;

            return goalPointDistance;
        }

        public void DrawVehicle()
        {
#pragma warning disable CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception
            //translate and rotate at pivot axle
            GL.Translate(mf.pivotAxlePos.easting, mf.pivotAxlePos.northing, 0);
            GL.PushMatrix();

            //translate down to the hitch pin
            GL.Translate(Math.Sin(mf.fixHeading) * hitchLength,
                            Math.Cos(mf.fixHeading) * hitchLength, 0);

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
                //rotate to tank heading
                GL.Rotate(glm.toDegrees(-mf.tankPos.heading), 0.0, 0.0, 1.0);

                //draw the tank hitch
                GL.LineWidth(2f);
                GL.Color3(0.7f, 0.7f, 0.97f);
                GL.Begin(PrimitiveType.Lines);
                GL.Vertex3(0.0, trailingTank, 0.0);
                GL.Vertex3(0, 0, 0);
                GL.End();

                //section markers
                GL.Color3(0.95f, 0.95f, 0f);
                GL.PointSize(6f);
                GL.Begin(PrimitiveType.Points);
                GL.Vertex3(0.0, trailingTank, 0.0);
                GL.End();

                //move down the tank hitch, unwind, rotate to section heading
                GL.Translate(0.0, trailingTank, 0.0);
                GL.Rotate(glm.toDegrees(mf.tankPos.heading), 0.0, 0.0, 1.0);
                GL.Rotate(glm.toDegrees(-mf.toolPos.heading), 0.0, 0.0, 1.0);
            }

            //no tow between hitch
            else
            {
                GL.Rotate(glm.toDegrees(-mf.toolPos.heading), 0.0, 0.0, 1.0);
            }
#pragma warning restore CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception

            //draw the hitch if trailing
            if (isToolTrailing)
            {
                GL.LineWidth(2f);
                GL.Color3(0.7f, 0.7f, 0.97f);
                GL.Begin(PrimitiveType.Lines);
                GL.Vertex3(0.0, trailingTool, 0.0);
                GL.Vertex3(0, 0, 0);
                GL.End();
            }

            //draw the sections
            GL.LineWidth(8);
            GL.Begin(PrimitiveType.Lines);

            //draw section line
            if (mf.section[numOfSections].isSectionOn)
            {
                if (mf.section[0].manBtnState == FormGPS.manBtn.Auto) GL.Color3(0.0f, 0.97f, 0.0f);
                else GL.Color3(0.99, 0.99, 0);
                GL.Vertex3(mf.section[numOfSections].positionLeft, trailingTool, 0);
                GL.Vertex3(mf.section[numOfSections].positionRight, trailingTool, 0);
            }
            else
            {
                for (int j = 0; j < mf.vehicle.numOfSections; j++)
                {
                    //if section is on, green, if off, red color
                    if (mf.section[j].isSectionOn)
                    {
                        if (mf.section[j].manBtnState == FormGPS.manBtn.Auto) GL.Color3(0.0f, 0.97f, 0.0f);
                        else GL.Color3(0.97, 0.97, 0);
                    }
                    else
                    {
                        GL.Color3(0.97f, 0.2f, 0.2f);
                    }

                    //draw section line
                    GL.Vertex3(mf.section[j].positionLeft, trailingTool, 0);
                    GL.Vertex3(mf.section[j].positionRight, trailingTool, 0);
                }
            }

            GL.End();

            //draw section markers if close enough
            if (mf.camera.camSetDistance > -1500)
            {
                GL.Color3(0.0f, 0.0f, 0.0f);
                //section markers
                GL.PointSize(4.0f);
                GL.Begin(PrimitiveType.Points);
                for (int j = 0; j < mf.vehicle.numOfSections - 1; j++)
                    GL.Vertex3(mf.section[j].positionRight, trailingTool, 0);
                GL.End();
            }

            //draw vehicle

            GL.PopMatrix();
            GL.Rotate(glm.toDegrees(-mf.fixHeading), 0.0, 0.0, 1.0);

            //if (mf.camera.camFollowing)
            //GL.Rotate(mf.camera.camPitch * -0.15, 1, 0, 0);

            ////draw the vehicle Body
            //GL.Color3(0.95f, 0.95f, 0.95f);
            //GL.Enable(EnableCap.Texture2D);
            //GL.BindTexture(TextureTarget.Texture2D, mf.texture[2]);        // Select Our Texture
            //GL.Begin(PrimitiveType.TriangleStrip);              // Build Quad From A Triangle Strip
            //GL.TexCoord2(0, 0); GL.Vertex2(2.8, 4); // Top Right
            //GL.TexCoord2(1, 0); GL.Vertex2(-2.8, 4); // Top Left
            //GL.TexCoord2(0, 1); GL.Vertex2(2.8, -antennaHeight + wheelbase); // Bottom Right
            //GL.TexCoord2(1, 1); GL.Vertex2(-2.8, -antennaHeight + wheelbase); // Bottom Left
            //GL.End();                       // Done Building Triangle Strip
            ////disable, straight color
            //GL.Disable(EnableCap.Texture2D);

            //draw the area side marker
            //GL.Color3(0.95f, 0.90f, 0.0f);
            GL.PointSize(6.0f);
            GL.Begin(PrimitiveType.Points);
            //if (mf.isAreaOnRight) GL.Vertex3(2.0, -antennaPivot, 0);
            //else GL.Vertex3(-2.0, -antennaPivot, 0);

            //antenna
            GL.Color3(0.0f, 0.95f, 0.95f);
            GL.Vertex3(0, antennaPivot, 0);

            //hitch pin
            GL.Color3(0.95f, 0.0f, 0.0f);
            GL.Vertex3(0, mf.vehicle.hitchLength, 0);

            ////rear Tires
            //GL.PointSize(12.0f);
            //GL.Color3(0, 0, 0);
            //GL.Vertex3(-1.8, 0, 0);
            //GL.Vertex3(1.8, 0, 0);
            GL.End();


            ////draw the vehicle Body
            GL.Color3(0.9, 0.90, 0.0);
            GL.Begin(PrimitiveType.TriangleFan);

            GL.Vertex3(0, antennaPivot, -0.2);
            GL.Vertex3(1.2, -0, 0.0);
            GL.Color3(0.0, 0.90, 0.92);
            GL.Vertex3(0, wheelbase, 0.0);
            GL.Color3(0.920, 0.0, 0.9);
            GL.Vertex3(-1.2, -0, 0.0);

            GL.Vertex3(1.2, -0, 0.0);
            GL.End();

            GL.LineWidth(3);
            GL.Color3(0.0, 0.0, 0.0);
            GL.Begin(PrimitiveType.LineLoop);
            {
                GL.Vertex3(-1.2, 0, 0);
                GL.Vertex3(1.2, 0, 0);
                GL.Vertex3(0, wheelbase, 0);
            }
            GL.End();
            GL.LineWidth(2);

            //Svenn Arrow
            GL.Color3(0.9, 0.95, 0.10);
            GL.Begin(PrimitiveType.LineStrip);
            {
                GL.Vertex3(0.8,  wheelbase + 6, 0.0);
                GL.Vertex3(0, wheelbase + 8, 0.0);
                GL.Vertex3(-0.8, wheelbase + 6, 0.0);
            }
            GL.End();

            //draw the rigid hitch
            GL.Color3(0.37f, 0.37f, 0.97f);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0, hitchLength, 0);
            GL.Vertex3(0, 0, 0);
            GL.End();

            GL.LineWidth(1);
        }
    }
}