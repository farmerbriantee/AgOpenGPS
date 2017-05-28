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

        public double offset = 0;

        public double camSetDistance = -75;

        //private double camDelta = 0;

        public CCamera()
        {
            camPosY = 0;

            //get the pitch of camera from settings
            camPitch = Properties.Settings.Default.setCam_pitch;
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

            //move the implement down slightly in the view so more is above or ahead of vehicle
            //if (camPitch < -50.0)
            
            //    //its in 2D mode
            //gl.Translate(-camPosX + (camSetDistance * 0.031 * Math.Sin(glm.toRadians(fixHeading))), -camPosY, 
            //                -camPosZ + (camSetDistance * 0.031 * Math.Cos(glm.toRadians(fixHeading))));
            //else 
                //its in 3D mode

            if (camPitch > -45)
            {
               offset = (45.0 + camPitch) / 45.0;

                offset = offset * offset * offset * offset * 0.28 + 0.02;

                gl.Translate(-camPosX + ( offset*camSetDistance * Math.Sin(glm.toRadians(fixHeading))), -camPosY, 
                    -camPosZ + (offset*camSetDistance * Math.Cos(glm.toRadians(fixHeading))));
 
             }

            else  gl.Translate(-camPosX + ( 0.02 * camSetDistance * Math.Sin(glm.toRadians(fixHeading))), -camPosY, 
                            -camPosZ + (0.02 * camSetDistance * Math.Cos(glm.toRadians(fixHeading))));
 

         }
        
    }
}
