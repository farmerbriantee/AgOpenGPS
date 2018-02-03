using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormABCurve : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf = null;

        public FormABCurve(Form _mf)
        {
            mf = _mf as FormGPS;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnABLineOk_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            mf.curve.refList?.Clear();
            btnBPoint.Enabled = false;
            btnAPoint.Enabled = true;
            mf.curve.isCurveSet = false;
        }

        private void btnAPoint_Click(object sender, System.EventArgs e)
        {
            //clear out the reference list
            mf.curve.refList?.Clear();

            mf.curve.isOkToAddPoints = true;
            btnBPoint.Enabled = true;
            btnAPoint.Enabled = false;
        }

        private void btnBPoint_Click(object sender, System.EventArgs e)
        {
            mf.curve.isOkToAddPoints = false;
            btnBPoint.Enabled = false;
            btnAPoint.Enabled = false;
            if (mf.curve.refList.Count > 3)
            {
                mf.curve.isCurveSet = true;
            }
            else
            {
                mf.curve.isCurveSet = false;
                mf.curve.refList?.Clear();
            }
        }
    }
}