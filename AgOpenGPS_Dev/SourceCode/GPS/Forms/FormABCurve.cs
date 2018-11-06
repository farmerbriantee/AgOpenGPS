using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormABCurve : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf;

        public FormABCurve(Form _mf)
        {
            mf = _mf as FormGPS;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
            mf.btnCurve.PerformClick();
            mf.curve.ResetCurveLine();
            mf.FileSaveCurveLine();
            mf.DisableYouTurnButtons();
        }

        private void btnABLineOk_Click(object sender, System.EventArgs e)
        {
            if (mf.curve.refList.Count < 3)
            {
                Close();
                mf.btnCurve.PerformClick();
                mf.curve.ResetCurveLine();
                mf.DisableYouTurnButtons();
            }
            else
            {
                mf.curve.isCurveSet = true;
                mf.EnableYouTurnButtons();
                Close();
            }
        }

        private void btnAPoint_Click(object sender, System.EventArgs e)
        {
            //clear out the reference list
            mf.curve.refList?.Clear();
            mf.curve.isOkToAddPoints = true;
            btnBPoint.Enabled = true;
            btnAPoint.Enabled = false;
            btnABLineOk.Enabled = false;
        }

        private void btnBPoint_Click(object sender, System.EventArgs e)
        {
            mf.curve.aveLineHeading = 0;
            mf.curve.isOkToAddPoints = false;
            btnBPoint.Enabled = false;
            btnAPoint.Enabled = false;
            btnABLineOk.Enabled = true;

            if (mf.curve.refList.Count > 3)
            {
                //calculate average heading of line
                double x = 0, y = 0;
                mf.curve.isCurveSet = true;
                foreach (var pt in mf.curve.refList)
                {
                    x += Math.Cos(pt.heading);
                    y += Math.Sin(pt.heading);
                }
                x /= mf.curve.refList.Count;
                y /= mf.curve.refList.Count;
                mf.curve.aveLineHeading = Math.Atan2(y, x);

                //build the tail extensions
                mf.curve.AddFirstLastPoints();
                mf.EnableYouTurnButtons();
            }
            else
            {
                mf.curve.isCurveSet = false;
                mf.curve.refList?.Clear();
            }
            mf.FileSaveCurveLine();
            Close();
        }

        private void FormABCurve_Load(object sender, EventArgs e)
        {
            if (mf.curve.refList.Count > 3)
            {
                btnBPoint.Enabled = false;
                btnAPoint.Enabled = false;
            }
        }
    }
}