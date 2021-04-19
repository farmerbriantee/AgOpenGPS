using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormBoundaryPlayer : Form
    {
        //properties
        private readonly FormGPS mf = null;

        //constructor
        public FormBoundaryPlayer(Form callingForm)
        {
            mf = callingForm as FormGPS;


            InitializeComponent();

            //btnStop.Text = gStr.gsDone;
            //btnPausePlay.Text = gStr.gsRecord;
            label1.Text = gStr.gsArea + ":";
            this.Text = gStr.gsStopRecordPauseBoundary;
            nudOffset.Controls[0].Enabled = false;
            lblOffset.Text = gStr.gsOffset;

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (mf.bnd.bndBeingMadePts.Count > 2)
            {
                mf.bnd.bndArr.Add(new CBoundaryLines());
                mf.turn.turnArr.Add(new CTurnLines());

                for (int i = 0; i < mf.bnd.bndBeingMadePts.Count; i++)
                {
                    mf.bnd.bndArr[mf.bnd.boundarySelected].bndLine.Add(mf.bnd.bndBeingMadePts[i]);
                }

                //build the boundary, make sure is clockwise for outer counter clockwise for inner
                bool isCW = mf.bnd.bndArr[mf.bnd.boundarySelected].CalculateBoundaryArea();
                if (mf.bnd.boundarySelected == 0 && isCW)
                {
                    mf.bnd.bndArr[mf.bnd.boundarySelected].ReverseWinding();
                }

                //inner boundaries
                if (mf.bnd.boundarySelected > 0 && !isCW)
                {
                    mf.bnd.bndArr[mf.bnd.boundarySelected].ReverseWinding();
                }

                mf.bnd.bndArr[mf.bnd.boundarySelected].FixBoundaryLine(mf.bnd.boundarySelected);
                mf.bnd.bndArr[mf.bnd.boundarySelected].PreCalcBoundaryEarLines();
                mf.bnd.bndArr[mf.bnd.boundarySelected].PreCalcBoundaryLines();
                mf.bnd.bndArr[mf.bnd.boundarySelected].isSet = true;
                mf.fd.UpdateFieldBoundaryGUIAreas();
            }

            //stop it all for adding
            mf.bnd.isOkToAddPoints = false;
            mf.bnd.isBndBeingMade = false;

            //turn lines made from boundaries
            mf.CalculateMinMax();
            mf.FileSaveBoundary();
            mf.turn.BuildTurnLines();
            //mf.hd.BuildSingleSpaceHeadLines();
            mf.btnMakeLinesFromBoundary.Visible = true;

            mf.bnd.bndBeingMadePts.Clear();
            //close window
            Close();
        }

        //actually the record button
        private void btnPausePlay_Click(object sender, EventArgs e)
        {
            if (mf.bnd.isOkToAddPoints)
            {
                mf.bnd.isOkToAddPoints = false;
                btnPausePlay.Image = Properties.Resources.BoundaryRecord;
                //btnPausePlay.Text = gStr.gsRecord;
                btnAddPoint.Enabled = true;
                btnDeleteLast.Enabled = true;
            }
            else
            {
                mf.bnd.isOkToAddPoints = true;
                btnPausePlay.Image = Properties.Resources.boundaryPause;
                //btnPausePlay.Text = gStr.gsPause;
                btnAddPoint.Enabled = false;
                btnDeleteLast.Enabled = false;
            }
            mf.Focus();
        }

        private void FormBoundaryPlayer_Load(object sender, EventArgs e)
        {
            //mf.bnd.isOkToAddPoints = false;
            nudOffset.Value = (decimal)(mf.tool.toolWidth * 0.5);
            btnPausePlay.Image = Properties.Resources.BoundaryRecord;
            btnLeftRight.Image = mf.bnd.isDrawRightSide ? Properties.Resources.BoundaryRight : Properties.Resources.BoundaryLeft;
            mf.bnd.createBndOffset = (double)nudOffset.Value;
            mf.bnd.isBndBeingMade = true;
            mf.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int ptCount = mf.bnd.bndBeingMadePts.Count;
            double area = 0;

            if (ptCount > 0)
            {
                int j = ptCount - 1;  // The last vertex is the 'previous' one to the first

                for (int i = 0; i < ptCount; j = i++)
                {
                    area += (mf.bnd.bndBeingMadePts[j].easting + mf.bnd.bndBeingMadePts[i].easting) * (mf.bnd.bndBeingMadePts[j].northing - mf.bnd.bndBeingMadePts[i].northing);
                }
                area = Math.Abs(area / 2);
            }
            if (mf.isMetric)
            {
                lblArea.Text = Math.Round(area * 0.0001, 2) + " Ha";
            }
            else
            {
                lblArea.Text = Math.Round(area * 0.000247105, 2) + " Acre";
            }
            lblPoints.Text = mf.bnd.bndBeingMadePts.Count.ToString();

        }

        private void btnAddPoint_Click(object sender, EventArgs e)
        {

            mf.bnd.isOkToAddPoints = true;
            mf.AddBoundaryPoint();
            mf.bnd.isOkToAddPoints = false;
            lblPoints.Text = mf.bnd.bndBeingMadePts.Count.ToString();

            mf.Focus();
        }

        private void btnDeleteLast_Click(object sender, EventArgs e)
        {
            int ptCount = mf.bnd.bndBeingMadePts.Count;
            if (ptCount > 0)
                mf.bnd.bndBeingMadePts.RemoveAt(ptCount - 1);
            lblPoints.Text = mf.bnd.bndBeingMadePts.Count.ToString();
            mf.Focus();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            DialogResult result3 = MessageBox.Show(gStr.gsCompletelyDeleteBoundary,
                                    gStr.gsDeleteForSure,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button2);
            if (result3 == DialogResult.Yes)
            {
                mf.bnd.bndBeingMadePts?.Clear();
                lblPoints.Text = mf.bnd.bndBeingMadePts.Count.ToString();
            }
            mf.Focus();
        }

        private void nudOffset_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
            btnPausePlay.Focus();
            mf.bnd.createBndOffset = (double)nudOffset.Value;
        }

        private void btnLeftRight_Click(object sender, EventArgs e)
        {
            mf.bnd.isDrawRightSide = !mf.bnd.isDrawRightSide;
            btnLeftRight.Image = mf.bnd.isDrawRightSide ? Properties.Resources.BoundaryRight : Properties.Resources.BoundaryLeft;

        }
    }
}