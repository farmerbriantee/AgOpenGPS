using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormBoundary : Form
    {
        private FormGPS mf = null;

        public FormBoundary(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void FormBoundary_Load(object sender, EventArgs e)
        {
            if (mf.boundary.isDrawRightSide) btnLeftRight.Image = global::AgOpenGPS.Properties.Resources.BoundaryRight;
            else btnLeftRight.Image = global::AgOpenGPS.Properties.Resources.BoundaryLeft;
            btnLeftRight.Enabled = false;

            if (mf.boundary.isSet)
            {
                btnOuter.Enabled = false;
                btnSerialOK.Enabled = false;
                btnDelete.Enabled = true;
            }

            else
            {
                btnOuter.Enabled = true;
                btnSerialOK.Enabled = false;
                btnDelete.Enabled = false;
            }

        }

        private void btnOuter_Click(object sender, EventArgs e)
        {
            btnLeftRight.Enabled = true;
            btnOuter.Enabled = false;
            btnSerialOK.Enabled = true;
            mf.boundary.ResetBoundary();
        }

        private void btnSerialCancel_Click(object sender, EventArgs e)
        {
            mf.boundary.isOkToAddPoints = false;
        }

        private void btnLeftRight_Click(object sender, EventArgs e)
        {
            mf.boundary.isDrawRightSide = !mf.boundary.isDrawRightSide;

            if (mf.boundary.isDrawRightSide) btnLeftRight.Image = global::AgOpenGPS.Properties.Resources.BoundaryRight;
            else btnLeftRight.Image = global::AgOpenGPS.Properties.Resources.BoundaryLeft;
 
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnLeftRight.Enabled = false;
            btnOuter.Enabled = true;
            btnSerialOK.Enabled = false;
            btnDelete.Enabled = false;

            mf.boundary.ResetBoundary();
            mf.FileSaveOuterBoundary();

            if (mf.boundary.isDrawRightSide) btnLeftRight.Image = global::AgOpenGPS.Properties.Resources.BoundaryRight;
            else btnLeftRight.Image = global::AgOpenGPS.Properties.Resources.BoundaryLeft;

        }




    }
}
