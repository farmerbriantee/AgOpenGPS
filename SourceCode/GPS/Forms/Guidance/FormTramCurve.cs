using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormTramCurve : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf = null;

        public FormTramCurve(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();

            this.Text = gStr.gsTramLines;
            label3.Text = gStr.gsPasses;
            lblTramWidth.Text = (mf.tram.tramWidth * mf.m2FtOrM).ToString("N2") + mf.unitsFtM;
            label2.Text = ((int)(0.1 * mf.m2InchOrCm)).ToString() + mf.unitsInCm;

            nudPasses.Controls[0].Enabled = false;

            mf.tool.halfToolWidth = (mf.tool.toolWidth - mf.tool.toolOverlap) / 2.0;

        }

        private void FormTram_Load(object sender, EventArgs e)
        {
            nudPasses.ValueChanged -= nudPasses_ValueChanged;
            nudPasses.Value = Properties.Settings.Default.setTram_passes;
            nudPasses.ValueChanged += nudPasses_ValueChanged;

            mf.panelRight.Enabled = false;

            lblTrack.Text = (mf.vehicle.trackWidth * mf.m2FtOrM).ToString("N2") + mf.unitsFtM;
            mf.tool.halfToolWidth = (mf.tool.toolWidth - mf.tool.toolOverlap) / 2.0;
            lblToolWidthHalf.Text = (mf.tool.halfToolWidth * mf.m2FtOrM).ToString("N2") + mf.unitsFtM;

            if (mf.tram.displayMode == 0) mf.tram.displayMode = 1;
            switch (mf.tram.displayMode)
            {
                case 0:
                    btnMode.Image = Properties.Resources.TramOff;
                    break;
                case 1:
                    btnMode.Image = Properties.Resources.TramAll;
                    break;
                case 2:
                    btnMode.Image = Properties.Resources.TramLines;
                    break;
                case 3:
                    btnMode.Image = Properties.Resources.TramOuter;
                    break;

                default:
                    break;
            }
            mf.CloseTopMosts();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //mf.ABLine.moveDistance = 0;
            mf.panelRight.Enabled = true;
            mf.panelDrag.Visible = false;

            mf.offX = 0;
            mf.offY = 0;
            if (mf.curve.refList.Count > 0)
            {
                //array number is 1 less since it starts at zero
                int idx = mf.curve.numCurveLineSelected - 1;

                //mf.curve.curveArr[idx].Name = textBox1.Text.Trim();
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
            }

            mf.FileSaveTram();
            mf.FixTramModeButton();

            Close();

        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            double dist = -0.1;
            mf.curve.MoveABCurve(dist);
            mf.curve.BuildTram();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            double dist = 0.1;
            mf.curve.MoveABCurve(dist);
            mf.curve.BuildTram();
        }

        private void btnAdjLeft_Click(object sender, EventArgs e)
        {
            mf.curve.MoveABCurve(-mf.tool.halfToolWidth);
            mf.curve.BuildTram();
        }

        private void btnAdjRight_Click(object sender, EventArgs e)
        {
            mf.curve.MoveABCurve(mf.tool.halfToolWidth);
            mf.curve.BuildTram();
        }

        private void nudPasses_ValueChanged(object sender, EventArgs e)
        {
            mf.tram.passes = (int)nudPasses.Value;
            Properties.Settings.Default.setTram_passes = mf.tram.passes;
            Properties.Settings.Default.Save();
            mf.curve.BuildTram();
        }

        private void nudPasses_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
            btnCancel.Focus();
        }

        private void btnSwapAB_Click(object sender, EventArgs e)
        {
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
            mf.curve.BuildTram();
        }

        private void btnTriggerDistanceUp_MouseDown(object sender, MouseEventArgs e)
        {
            nudPasses.UpButton();
            //mf.curve.BuildTram();
        }

        private void btnTriggerDistanceDn_MouseDown(object sender, MouseEventArgs e)
        {
            nudPasses.DownButton();
            //mf.curve.BuildTram();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mf.tram.tramArr?.Clear();
            mf.tram.tramList?.Clear();
            mf.tram.tramBndOuterArr?.Clear();
            mf.tram.tramBndInnerArr?.Clear();

            mf.panelRight.Enabled = true;
            mf.panelDrag.Visible = false;
            mf.offX = 0;
            mf.offY = 0;

            mf.tram.displayMode = 0;
            mf.FileSaveTram();
            mf.FixTramModeButton();
            Close();
        }

        private void btnMode_Click(object sender, EventArgs e)
        {
            mf.tram.displayMode++;
            if (mf.tram.displayMode > 3) mf.tram.displayMode = 0;

            switch (mf.tram.displayMode)
            {
                case 0:
                    btnMode.Image = Properties.Resources.TramOff;
                    break;
                case 1:
                    btnMode.Image = Properties.Resources.TramAll;
                    break;
                case 2:
                    btnMode.Image = Properties.Resources.TramLines;
                    break;
                case 3:
                    btnMode.Image = Properties.Resources.TramOuter;
                    break;

                default:
                    break;
            }
        }
    }
}