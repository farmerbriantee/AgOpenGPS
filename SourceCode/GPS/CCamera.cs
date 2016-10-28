using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpGL;

namespace AgOpenGPS
{
    public class CCamera
    {
        public double camPitch = 95;

        private double camYaw = 0;
        private double camPosX = 0;
        private double camPosY = 0;
        private double camPosZ = 0;
        private double fixHeading = 0;

        public double camSetDistance = -100;

        //private double camDelta = 0;

        public CCamera()
        {
            camPosY = 0;
        }

        public void PositionCam()
        {
            //the angle of camera looking down at fix
            //camPitch = -80;

            //correct overun of 360 to 0 problem TODO

            //Get the camera position filled with the fix coordinates
       }

        public void SetWorldCam(OpenGL gl, double _fixPosX, double _fixPosY, double _fixPosZ, double _fixHeading)
        {
            camPosX = _fixPosX;
            camPosY = _fixPosY;
            camPosZ = _fixPosZ;
            this.fixHeading = _fixHeading;
            camYaw = _fixHeading;

            //back the camera up
            gl.Translate(0, 0, camSetDistance*0.5);

            //flip the world over so positive z aka north goes into screen
            gl.Rotate(180, 0, 0, 1);

            //rotate the camera down to look at fix
            gl.Rotate(camPitch, 1, 0, 0);

            //rotate camera so heading matched fix heading in the world
            gl.Rotate(-camYaw + 180, 0, 1, 0);

            //translate to that spot in the world 


            //move the implement down slightly in the view so more is above or ahead of vehicle
            if (camPitch < -50.0)
            
                //its in 2D mode
            gl.Translate(-camPosX + (camSetDistance * 0.051 * Math.Sin(glm.radians(fixHeading))), -camPosY, 
                            -camPosZ + (camSetDistance * 0.051 * Math.Cos(glm.radians(fixHeading))));
            else 
                //its in 3D mode
                        gl.Translate(-camPosX + (camSetDistance * 0.12 * Math.Sin(glm.radians(fixHeading))), -camPosY, 
                            -camPosZ + (camSetDistance * 0.12 * Math.Cos(glm.radians(fixHeading))));
 
        }
        
    }
}
