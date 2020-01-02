using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;


namespace AgOpenGPS
{
    public class CTool
    {
        private readonly FormGPS mf;

        public double toolWidth;
        public double toolFarLeftPosition = 0;
        public double toolFarLeftSpeed = 0;
        public double toolFarRightPosition = 0;
        public double toolFarRightSpeed = 0;
        //public double toolFarLeftContourSpeed = 0, toolFarRightContourSpeed = 0;

        public double toolOverlap;
        public double toolTrailingHitchLength, toolTankTrailingHitchLength;
        public double toolOffset;

        public double toolTurnOffDelay;
        public double toolLookAhead;

        public bool isToolTrailing, isToolTBT;
        public bool isToolBehindPivot;
        public string toolAttachType;

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

            isToolBehindPivot = Properties.Vehicle.Default.setTool_isToolBehindPivot;
            isToolTrailing = Properties.Vehicle.Default.setTool_isToolTrailing;
            isToolTBT = Properties.Vehicle.Default.setTool_isToolTBT;

            toolLookAhead = Properties.Vehicle.Default.setVehicle_lookAhead;
            toolTurnOffDelay = Properties.Vehicle.Default.setVehicle_toolTurnOffDelay;

            numOfSections = Properties.Vehicle.Default.setVehicle_numSections;
            numSuperSection = numOfSections + 1;

            toolMinUnappliedPixels = Properties.Vehicle.Default.setVehicle_minApplied;

        }

        public void DrawTool()
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
                for (int j = 0; j < numOfSections; j++)
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
            if (mf.camera.camSetDistance > -250)
            {
                GL.Color3(0.0f, 0.0f, 0.0f);
                //section markers
                GL.PointSize(3.0f);
                GL.Begin(PrimitiveType.Points);
                for (int j = 0; j < numOfSections - 1; j++)
                    GL.Vertex3(mf.section[j].positionRight, trailingTool, 0);
                GL.End();
            }
            
            GL.PopMatrix();
        }
    }
}
