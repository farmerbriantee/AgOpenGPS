using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormSmoothAB : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        private int smoothCount = 20;

        public FormSmoothAB(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();

            this.bntOK.Text = gStr.gsForNow;
            this.btnSave.Text = gStr.gsToFile;

            this.Text = gStr.gsSmoothABCurve;
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
            smoothCount = 20;
            lblSmooth.Text = "**";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mf.curve.isSmoothWindowOpen = false;
            mf.curve.smooList?.Clear();
            Close();
        }

        private void btnNorth_MouseDown(object sender, MouseEventArgs e)
        {
            if (smoothCount++ > 100) smoothCount = 100;
            mf.curve.SmoothAB(smoothCount * 2);
            lblSmooth.Text = smoothCount.ToString();
        }

        private void btnSouth_MouseDown(object sender, MouseEventArgs e)
        {
            smoothCount--;
            if (smoothCount < 2) smoothCount = 2;
            mf.curve.SmoothAB(smoothCount * 2);
            lblSmooth.Text = smoothCount.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mf.curve.isSmoothWindowOpen = false;
            mf.curve.SaveSmoothAsRefList();
            mf.curve.smooList?.Clear();

            if (mf.curve.refList.Count > 0)
            {
                //array number is 1 less since it starts at zero
                int idx = mf.curve.numCurveLineSelected - 1;

                if (idx >= 0)
                {
                    mf.curve.curveArr[idx].aveHeading = mf.curve.aveLineHeading;
                    mf.curve.curveArr[idx].curvePts.Clear();
                    //write out the Curve Points
                    foreach (vec3 item in mf.curve.refList)
                    {
                        mf.curve.curveArr[idx].curvePts.Add(item);
                    }
                }

                //save entire list
                mf.FileSaveCurveLines();
                mf.curve.moveDistance = 0;

                //mf.layoutPanelRight.Enabled = true;
                //Close();
            }

            //mf.FileSaveCurveLines();
            Close();
        }
    }
}