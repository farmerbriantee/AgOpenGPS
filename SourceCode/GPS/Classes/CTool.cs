using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;


namespace AgOpenGPS
{
    public class CTool
    {
        private readonly FormGPS mf;

        public double toolWidth, halfToolWidth;
        public double toolFarLeftPosition = 0;
        public double toolFarLeftSpeed = 0;
        public double toolFarRightPosition = 0;
        public double toolFarRightSpeed = 0;
        //public double toolFarLeftContourSpeed = 0, toolFarRightContourSpeed = 0;

        public double toolOverlap;
        public double toolTrailingHitchLength, toolTankTrailingHitchLength;
        public double toolOffset;

        public double lookAheadOffSetting, lookAheadOnSetting;
        public double turnOffDelay;

        public double lookAheadDistanceOnPixelsLeft, lookAheadDistanceOnPixelsRight;
        public double lookAheadDistanceOffPixelsLeft, lookAheadDistanceOffPixelsRight;

        public bool isToolTrailing, isToolTBT;
        public bool isToolRearFixed, isToolFrontFixed;

        public bool isMultiColoredSections;
        public string toolAttachType;

        public double hitchLength;


        //how many individual sections
        public int numOfSections;

        public int numSuperSection;

        //used for super section off on
        public int minCoverage;

        public bool isSuperSectionAllowedOn;
        public bool areAllSectionBtnsOn = true;

        public bool isLeftSideInHeadland = true, isRightSideInHeadland = true;

        //read pixel values
        public int rpXPosition;
        public int rpWidth;

        public Color[] secColors = new Color[16];

        //Constructor called by FormGPS
        public CTool(FormGPS _f)
        {

            mf = _f;

            //from settings grab the vehicle specifics
            toolWidth = Properties.Vehicle.Default.setVehicle_toolWidth;
            toolOverlap = Properties.Vehicle.Default.setVehicle_toolOverlap;

            toolOffset = Properties.Vehicle.Default.setVehicle_toolOffset;

            toolTrailingHitchLength = Properties.Vehicle.Default.setTool_toolTrailingHitchLength;
            toolTankTrailingHitchLength = Properties.Vehicle.Default.setVehicle_tankTrailingHitchLength;
            hitchLength = Properties.Vehicle.Default.setVehicle_hitchLength;

            isToolRearFixed = Properties.Vehicle.Default.setTool_isToolRearFixed;
            isToolTrailing = Properties.Vehicle.Default.setTool_isToolTrailing;
            isToolTBT = Properties.Vehicle.Default.setTool_isToolTBT;
            isToolFrontFixed = Properties.Vehicle.Default.setTool_isToolFront;

            lookAheadOnSetting = Properties.Vehicle.Default.setVehicle_toolLookAheadOn;
            lookAheadOffSetting = Properties.Vehicle.Default.setVehicle_toolLookAheadOff;
            turnOffDelay = Properties.Vehicle.Default.setVehicle_toolOffDelay;

            numOfSections = Properties.Vehicle.Default.setVehicle_numSections;
            numSuperSection = numOfSections + 1;

            minCoverage = Properties.Vehicle.Default.setVehicle_minCoverage;
            isMultiColoredSections = Properties.Settings.Default.setColor_isMultiColorSections;

            secColors[0] =  Properties.Settings.Default.setColor_sec01;
            secColors[1] =  Properties.Settings.Default.setColor_sec02;
            secColors[2] =  Properties.Settings.Default.setColor_sec03;
            secColors[3] =  Properties.Settings.Default.setColor_sec04;
            secColors[4] =  Properties.Settings.Default.setColor_sec05;
            secColors[5] =  Properties.Settings.Default.setColor_sec06;
            secColors[6] =  Properties.Settings.Default.setColor_sec07;
            secColors[7] =  Properties.Settings.Default.setColor_sec08;
            secColors[8] =  Properties.Settings.Default.setColor_sec09;
            secColors[9] =  Properties.Settings.Default.setColor_sec10;
            secColors[10] = Properties.Settings.Default.setColor_sec11;
            secColors[11] = Properties.Settings.Default.setColor_sec12;
            secColors[12] = Properties.Settings.Default.setColor_sec13;
            secColors[13] = Properties.Settings.Default.setColor_sec14;
            secColors[14] = Properties.Settings.Default.setColor_sec15;
            secColors[15] = Properties.Settings.Default.setColor_sec16;
        }

        public void DrawTool()
        {

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
                trailingTank = toolTankTrailingHitchLength;
                trailingTool = toolTrailingHitchLength;
            }
            else { trailingTank = 0; trailingTool = 0; }

            //there is a trailing tow between hitch
            if (isToolTBT && isToolTrailing)
            {
                //rotate to tank heading
                GL.Rotate(glm.toDegrees(-mf.tankPos.heading), 0.0, 0.0, 1.0);

                //draw the tank hitch
                GL.LineWidth(6);
                //draw the rigid hitch
                GL.Color3(0, 0, 0);
                GL.Begin(PrimitiveType.LineLoop);
                GL.Vertex3(-0.57, trailingTank, 0);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0.57, trailingTank, 0);

                GL.End();

                GL.LineWidth(1);
                //draw the rigid hitch
                GL.Color3(0.765f, 0.76f, 0.32f);
                GL.Begin(PrimitiveType.LineLoop);
                GL.Vertex3(-0.57, trailingTank, 0);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0.57, trailingTank, 0);

                GL.End();

                //GL.LineWidth(4);
                //GL.Color3(0.937f, 0.537f, 0.397f);
                //GL.Begin(PrimitiveType.Lines);
                //GL.Vertex3(0, trailingTank, 0);
                //GL.Vertex3(0, 0, 0);
                //GL.End();

                //GL.Color3(0.937f, 0.537f, 0.397f);
                //GL.Begin(PrimitiveType.Lines);
                //GL.Vertex3(-1, trailingTank, 0);
                //GL.Vertex3(1, trailingTank, 0);
                //GL.End();

                //pivot markers
                //GL.Color3(0,0,0);
                //GL.PointSize(8);
                //GL.Begin(PrimitiveType.Points);
                //GL.Vertex3(-1, trailingTank, 0.0);
                //GL.Vertex3(1, trailingTank, 0.0);
                //GL.End();

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

            //draw the hitch if trailing
            if (isToolTrailing)
            {
                GL.LineWidth(6);
                GL.Color3(0, 0, 0);
                GL.Begin(PrimitiveType.LineStrip);
                GL.Vertex3(-0.4 + mf.tool.toolOffset, trailingTool, 0);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0.4 + mf.tool.toolOffset, trailingTool, 0);

                GL.End();

                GL.LineWidth(1);
                //draw the rigid hitch
                GL.Color3(0.7f, 0.4f, 0.2f);
                GL.Begin(PrimitiveType.LineStrip);
                GL.Vertex3(-0.4 + mf.tool.toolOffset, trailingTool, 0);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0.4 + mf.tool.toolOffset, trailingTool, 0);

                GL.End();
            }

            if (mf.isJobStarted)
            {
                //look ahead lines
                GL.LineWidth(1);
                GL.Begin(PrimitiveType.Lines);

                //lookahead section on
                GL.Color3(0.20f, 0.7f, 0.2f);
                GL.Vertex3(mf.tool.toolFarLeftPosition, (mf.tool.lookAheadDistanceOnPixelsLeft) * 0.1 + trailingTool, 0);
                GL.Vertex3(mf.tool.toolFarRightPosition, (mf.tool.lookAheadDistanceOnPixelsRight) * 0.1 + trailingTool, 0);

                //lookahead section off
                GL.Color3(0.70f, 0.2f, 0.2f);
                GL.Vertex3(mf.tool.toolFarLeftPosition, (mf.tool.lookAheadDistanceOffPixelsLeft) * 0.1 + trailingTool, 0);
                GL.Vertex3(mf.tool.toolFarRightPosition, (mf.tool.lookAheadDistanceOffPixelsRight) * 0.1 + trailingTool, 0);

                if (mf.vehicle.isHydLiftOn)
                {
                    GL.Color3(0.70f, 0.2f, 0.72f);
                    GL.Vertex3(mf.section[0].positionLeft, (mf.vehicle.hydLiftLookAheadDistanceLeft * 0.1) + trailingTool, 0);
                    GL.Vertex3(mf.section[mf.tool.numOfSections - 1].positionRight, (mf.vehicle.hydLiftLookAheadDistanceRight * 0.1) + trailingTool, 0);
                }

                GL.End();
            }
            //draw the sections
            GL.LineWidth(2);

            double hite = mf.camera.camSetDistance / -150;
            if (hite > 0.7) hite = 0.7;
            if (hite < 0.5) hite = 0.5;

            {
                for (int j = 0; j < numOfSections; j++)
                {
                    //if section is on, green, if off, red color
                    if (mf.section[j].isSectionOn || mf.section[numOfSections].isSectionOn)
                    {
                        if (mf.section[j].manBtnState == FormGPS.manBtn.Auto)
                        {
                            GL.Color3(0.0f, 0.9f, 0.0f);
                            //if (mf.section[j].isMappingOn) GL.Color3(0.0f, 0.7f, 0.0f);
                            //else GL.Color3(0.70f, 0.0f, 0.90f);
                        }
                        else GL.Color3(0.97, 0.97, 0);
                    }
                    else
                    {
                        //if (!mf.section[j].isMappingOn) GL.Color3(0.70f, 0.2f, 0.2f);
                        //else GL.Color3(0.00f, 0.250f, 0.90f);
                        GL.Color3(0.7f, 0.2f, 0.2f);
                    }

                    double mid = (mf.section[j].positionRight - mf.section[j].positionLeft) / 2 + mf.section[j].positionLeft;

                    GL.Begin(PrimitiveType.TriangleFan);
                    {
                        GL.Vertex3(mf.section[j].positionLeft, trailingTool, 0);
                        GL.Vertex3(mf.section[j].positionLeft, trailingTool - hite, 0);

                        GL.Vertex3(mid, trailingTool - hite * 1.5, 0);

                        GL.Vertex3(mf.section[j].positionRight, trailingTool - hite, 0);
                        GL.Vertex3(mf.section[j].positionRight, trailingTool, 0);
                    }
                    GL.End();

                    GL.Begin(PrimitiveType.LineLoop);
                    {
                        GL.Color3(0.0, 0.0, 0.0);
                        GL.Vertex3(mf.section[j].positionLeft, trailingTool, 0);
                        GL.Vertex3(mf.section[j].positionLeft, trailingTool - hite, 0);

                        GL.Vertex3(mid, trailingTool - hite * 1.5, 0);

                        GL.Vertex3(mf.section[j].positionRight, trailingTool - hite, 0);
                        GL.Vertex3(mf.section[j].positionRight, trailingTool, 0);
                    }
                    GL.End();
                }

                //tram Dots
                if (mf.tram.displayMode != 0)
                {
                    if (mf.camera.camSetDistance > -200)
                    {
                        GL.PointSize(8);

                        if (mf.tram.isOuter)
                        {

                            //section markers
                            GL.Begin(PrimitiveType.Points);

                            //right side
                            if (((mf.tram.controlByte) & 1) == 1) GL.Color3(0.0f, 0.900f, 0.39630f);
                            else GL.Color3(0.90f, 0.00f, 0.0f);
                            GL.Vertex3(toolFarRightPosition - mf.tram.halfWheelTrack, trailingTool + 0.21, 0);

                            //left side
                            if (((mf.tram.controlByte >> 2) & 1) == 1) GL.Color3(0.0f, 0.900f, 0.3930f);
                            else GL.Color3(0.90f, 0.00f, 0.0f);
                            GL.Vertex3(toolFarLeftPosition + mf.tram.halfWheelTrack, trailingTool + 0.21, 0);
                            GL.End();

                        }
                        else
                        {
                            GL.Begin(PrimitiveType.Points);

                            //right side
                            if (((mf.tram.controlByte >> 1) & 1) == 1) GL.Color3(0.0f, 0.900f, 0.3930f);
                            else GL.Color3(0.90f, 0.00f, 0.0f);
                            GL.Vertex3(-mf.tram.halfWheelTrack, trailingTool + 0.21, 0);

                            //left side
                            GL.Vertex3(mf.tram.halfWheelTrack, trailingTool + 0.21, 0);
                            GL.End();

                        }
                    }
                }
            }

            //GL.End();

            //draw section markers if close enough
            //if (mf.camera.camSetDistance > -250)
            //{
            //    GL.Color3(0.0f, 0.0f, 0.0f);
            //    //section markers
            //    GL.PointSize(3.0f);
            //    GL.Begin(PrimitiveType.Points);
            //    for (int j = 0; j < numOfSections - 1; j++)
            //        GL.Vertex3(mf.section[j].positionRight, trailingTool, 0);
            //    GL.End();
            //}

            //GL.Color3(0.30f, 1.0f, 1.0f);
            ////section markers
            //GL.PointSize(4.0f);
            //GL.Begin(PrimitiveType.Points);
            ////for (int j = 0; j < numOfSections - 1; j++)
            //GL.Vertex3(mf.section[0].positionLeft, (mf.vehicle.hydLiftLookAheadDistanceLeft * 0.1) + trailingTool, 0);
            //GL.Vertex3(mf.section[mf.tool.numOfSections - 1].positionRight, (mf.vehicle.hydLiftLookAheadDistanceRight * 0.1) + trailingTool, 0);
            //GL.End();

            GL.PopMatrix();
        }
    }
}
