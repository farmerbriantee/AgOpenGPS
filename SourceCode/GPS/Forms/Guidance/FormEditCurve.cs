using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormEditCurve : Form
    {
        private readonly FormGPS mf = null;

        private double snapAdj = 0;

        public FormEditCurve(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();

            this.Text = gStr.gsEditABCurve;
            nudMinTurnRadius.Controls[0].Enabled = false;
        }

        private void FormEditAB_Load(object sender, EventArgs e)
        {
            label1.Text = mf.unitsInCm;
            label2.Text = mf.unitsFtM;

            //btnLeft.Text = "-"+Properties.Settings.Default.setDisplay_snapDistanceSmall.ToString() + "cm";
            lblHalfWidth.Text = (mf.tool.toolWidth * 0.5 * mf.m2FtOrM).ToString("N2");

            if (mf.isMetric)
            {
                nudMinTurnRadius.DecimalPlaces = 0;
                nudMinTurnRadius.Value = (int)((double)Properties.Settings.Default.setAS_snapDistance * mf.cm2CmOrIn);
            }
            else
            {
                nudMinTurnRadius.DecimalPlaces = 1;
                nudMinTurnRadius.Value = (decimal)Math.Round(((double)Properties.Settings.Default.setAS_snapDistance * mf.cm2CmOrIn), 1);
            }


            btnCancel.Focus();
        }

        private void nudMinTurnRadius_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
            btnCancel.Focus();
        }

        private void nudMinTurnRadius_ValueChanged(object sender, EventArgs e)
        {
            snapAdj = (double)nudMinTurnRadius.Value * mf.inOrCm2Cm * 0.01;
        }

        private void btnAdjRight_Click(object sender, EventArgs e)
        {
            mf.curve.MoveABCurve(snapAdj);
        }

        private void btnAdjLeft_Click(object sender, EventArgs e)
        {
            mf.curve.MoveABCurve(-snapAdj);
        }

        private void bntOk_Click(object sender, EventArgs e)
        {
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
                mf.curve.isCurveValid = false;

                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            int last = mf.curve.numCurveLineSelected;
            mf.FileLoadCurveLines();
            if (mf.curve.curveArr.Count > 0)
            {
                mf.curve.numCurveLineSelected = last;
                int idx = mf.curve.numCurveLineSelected - 1;
                mf.curve.aveLineHeading = mf.curve.curveArr[idx].aveHeading;

                mf.curve.refList?.Clear();
                for (int i = 0; i < mf.curve.curveArr[idx].curvePts.Count; i++)
                {
                    mf.curve.refList.Add(mf.curve.curveArr[idx].curvePts[i]);
                }
                mf.curve.isCurveSet = true;
            }

            mf.curve.isCurveValid = false;
            Close();
        }

        private void btnSwapAB_Click(object sender, EventArgs e)
        {
            mf.curve.isCurveValid = false;
            mf.curve.lastSecond = 0;
            int cnt = mf.curve.refList.Count;
            if (cnt > 0)
            {
                mf.curve.refList.Reverse();

                vec3[] arr = new vec3[cnt];
                cnt--;
                mf.curve.refList.CopyTo(arr);
                mf.curve.refList.Clear();

                mf.curve.aveLineHeading += Math.PI;
                if (mf.curve.aveLineHeading < 0) mf.curve.aveLineHeading += glm.twoPI;
                if (mf.curve.aveLineHeading > glm.twoPI) mf.curve.aveLineHeading -= glm.twoPI;

                for (int i = 1; i < cnt; i++)
                {
                    vec3 pt3 = arr[i];
                    pt3.heading += Math.PI;
                    if (pt3.heading > glm.twoPI) pt3.heading -= glm.twoPI;
                    if (pt3.heading < 0) pt3.heading += glm.twoPI;
                    mf.curve.refList.Add(pt3);
                }
            }
        }

        private void btnContourPriority_Click(object sender, EventArgs e)
        {
            if (mf.curve.isBtnCurveOn)
                mf.curve.MoveABCurve(mf.isStanleyUsed ? mf.gyd.distanceFromCurrentLinePivot : mf.curve.distanceFromCurrentLinePivot);
        }

        private void btnRightHalfWidth_Click(object sender, EventArgs e)
        {
            double dist = mf.tool.toolWidth;

            mf.curve.MoveABCurve(dist * 0.5);

        }

        private void btnLeftHalfWidth_Click(object sender, EventArgs e)
        {
            double dist = mf.tool.toolWidth;

            mf.curve.MoveABCurve(-dist * 0.5);

        }

        private void btnNosave_Click(object sender, EventArgs e)
        {
            mf.curve.isCurveValid = false;
            Close();
        }
    }
}
