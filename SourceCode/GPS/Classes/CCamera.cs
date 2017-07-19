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
            gl.Translate(0, 0, camSetDistance * 0.5);

            ////draw the guide
            //gl.Begin(OpenGL.GL_TRIANGLES);

            //gl.Color(0.98f, 0.0f, 0.0f);
            //gl.Vertex(0.0f, -2.0f, 0.0f);

            //gl.Color(0.0f, 0.98f, 0.0f);
            //gl.Vertex(-2.0f, -3.0f, 0.0f);

            //gl.Color(0.98f, 0.98f, 0.0f);
            //gl.Vertex(2.0f, -3.0f, 0.0f);

            //gl.End();						// Done Drawing Reticle

            //rotate the camera down to look at fix
            gl.Rotate(camPitch, 1, 0, 0);

            gl.Rotate(camYaw, 0, 0, 1);

            //gl.Translate(-camPosX,-camPosY,-camPosZ);

            if (camPitch > -45)
            {
                offset = (45.0 + camPitch) / 45.0;

                offset = offset * offset * offset * offset * 0.015 + 0.02;

                gl.Translate(-camPosX + (offset * camSetDistance * Math.Sin(glm.toRadians(fixHeading))),
                    -camPosY + (offset * camSetDistance * Math.Cos(glm.toRadians(fixHeading))), -camPosZ);

            }

            else gl.Translate(-camPosX + (0.02 * camSetDistance * Math.Sin(glm.toRadians(fixHeading))),
                           -camPosY + (0.02 * camSetDistance * Math.Cos(glm.toRadians(fixHeading))), -camPosZ);

        }

    }
}
