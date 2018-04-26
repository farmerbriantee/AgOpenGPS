using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormSmoothAB : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        public FormSmoothAB(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            mf.curve.isSmoothWindowOpen = false;
            mf.curve.SaveSmoothAsRefList();
            mf.curve.smooList?.Clear();
            Close();
        }

        private void FormSmoothAB_Load(object sender, EventArgs e)
        {
            mf.curve.isSmoothWindowOpen = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mf.curve.isSmoothWindowOpen = false;
            Close();
            mf.curve.smooList?.Clear();
        }

        private void btnNorth_MouseDown(object sender, MouseEventArgs e)
        {
            nudNorth.UpButton();
            mf.curve.SmoothAB((int)nudNorth.Value * 2);
        }

        private void btnSouth_MouseDown(object sender, MouseEventArgs e)
        {
            nudNorth.DownButton();
            mf.curve.SmoothAB((int)nudNorth.Value * 2);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mf.curve.isSmoothWindowOpen = false;
            mf.curve.SaveSmoothAsRefList();
            mf.curve.smooList?.Clear();
            mf.FileSaveCurveLine();
            Close();
        }
    }
}