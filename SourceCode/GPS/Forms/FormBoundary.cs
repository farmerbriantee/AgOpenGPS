using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormBoundary : Form
    {
        private readonly FormGPS mf = null;

        public FormBoundary(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void FormBoundary_Load(object sender, EventArgs e)
        {
            btnLeftRight.Image = mf.boundz.isDrawRightSide ? Properties.Resources.BoundaryRight
                            : Properties.Resources.BoundaryLeft;
            btnLeftRight.Enabled = false;

            if (mf.boundz.isSet)
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
            mf.boundz.ResetBoundary();
        }

        private void btnSerialCancel_Click(object sender, EventArgs e)
        {
            mf.boundz.isOkToAddPoints = false;
        }

        private void btnLeftRight_Click(object sender, EventArgs e)
        {
            mf.boundz.isDrawRightSide = !mf.boundz.isDrawRightSide;

            btnLeftRight.Image = mf.boundz.isDrawRightSide ? Properties.Resources.BoundaryRight : Properties.Resources.BoundaryLeft;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnLeftRight.Enabled = false;
            btnOuter.Enabled = true;
            btnSerialOK.Enabled = false;
            btnDelete.Enabled = false;

            mf.boundz.ResetBoundary();
            mf.FileSaveOuterBoundary();

            btnLeftRight.Image = mf.boundz.isDrawRightSide ? Properties.Resources.BoundaryRight : Properties.Resources.BoundaryLeft;
        }
    }
}
