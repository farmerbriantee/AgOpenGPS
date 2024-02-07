//Please, if you use this give me some credit
//Copyright BrianTee, copy right out of it.

using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormPan : Form
    {
        private readonly FormGPS mf = null;

        public FormPan(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }
        private void btnPanUp_Click(object sender, EventArgs e)
        {
            mf.camera.panY += (mf.camera.camSetDistance / 25);
        }

        private void btnPanDn_Click(object sender, EventArgs e)
        {
            mf.camera.panY -= (mf.camera.camSetDistance / 25);
        }

        private void btnPanRight_Click(object sender, EventArgs e)
        {
            mf.camera.panX += (mf.camera.camSetDistance / 25);
        }

        private void btnPanLeft_Click(object sender, EventArgs e)
        {
            mf.camera.panX -= (mf.camera.camSetDistance / 25);
        }

        private void btnUpLeft_Click(object sender, EventArgs e)
        {
            mf.camera.panY += (mf.camera.camSetDistance / 25);
            mf.camera.panX -= (mf.camera.camSetDistance / 25);
        }
        private void btnDownRight_Click(object sender, EventArgs e)
        {
            mf.camera.panY -= (mf.camera.camSetDistance / 25);
            mf.camera.panX += (mf.camera.camSetDistance / 25);
        }

        private void btnUpRight_Click(object sender, EventArgs e)
        {
            mf.camera.panY += (mf.camera.camSetDistance / 25);
            mf.camera.panX += (mf.camera.camSetDistance / 25);
        }

        private void btnDownLeft_Click(object sender, EventArgs e)
        {
            mf.camera.panY -= (mf.camera.camSetDistance / 25);
            mf.camera.panX -= (mf.camera.camSetDistance / 25);
        }

        private void btnPanCancel_Click(object sender, EventArgs e)
        {
            mf.camera.panX = 0;
            mf.camera.panY = 0;
            mf.isPanFormVisible = false;
            Close();
        }

        private void FormPan_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.isPanFormVisible = false;
        }
    }
}
