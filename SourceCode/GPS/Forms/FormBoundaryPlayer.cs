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

            btnStop.Text = gStr.gsDone;
            btnPausePlay.Text = gStr.gsRecord;
            label1.Text = gStr.gsArea + ":";
            this.Text = gStr.gsStopRecordPauseBoundary;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (mf.bnd.bndArr[mf.bnd.boundarySelected].bndLine.Count > 5)
            {
                mf.bnd.bndArr[mf.bnd.boundarySelected].PreCalcBoundaryLines();
                mf.bnd.bndArr[mf.bnd.boundarySelected].FixBoundaryLine(mf.bnd.boundarySelected, mf.vehicle.toolWidth);
                mf.bnd.bndArr[mf.bnd.boundarySelected].PreCalcBoundaryLines();
                mf.bnd.bndArr[mf.bnd.boundarySelected].isSet = true;
            }
            else
            {
                mf.bnd.bndArr[mf.bnd.boundarySelected].calcList.Clear();
                mf.bnd.bndArr[mf.bnd.boundarySelected].bndLine.Clear();
                mf.bnd.bndArr[mf.bnd.boundarySelected].area = 0;
                mf.bnd.bndArr[mf.bnd.boundarySelected].isSet = false;
            }

            //stop it all for adding
            for (int i = 0; i < FormGPS.MAXBOUNDARIES; i++) mf.bnd.bndArr[i].isOkToAddPoints = false;

            //turn lines made from boundaries
            mf.CalculateMinMax();
            mf.FileSaveBoundary();
            mf.turn.BuildTurnLines();
            mf.gf.BuildGeoFenceLines();
            //Task.Run(() => mf.mazeGrid.BuildMazeGridArray());
            mf.mazeGrid.BuildMazeGridArray();

            //close window
            Close();
        }

        //actually the record button
        private void btnPausePlay_Click(object sender, EventArgs e)
        {
            if (mf.bnd.bndArr[mf.bnd.boundarySelected].isOkToAddPoints)
            {
                for (int i = 0; i < FormGPS.MAXBOUNDARIES; i++) mf.bnd.bndArr[i].isOkToAddPoints = false;
                btnPausePlay.Image = Properties.Resources.BoundaryRecord;
                btnPausePlay.Text = gStr.gsRecord;
            }
            else
            {
                mf.bnd.bndArr[mf.bnd.boundarySelected].isOkToAddPoints = true;
                btnPausePlay.Image = Properties.Resources.boundaryPause;
                btnPausePlay.Text = gStr.gsPause;
            }
        }

        private void FormBoundaryPlayer_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < FormGPS.MAXBOUNDARIES; i++) mf.bnd.bndArr[i].isOkToAddPoints = false;
            btnPausePlay.Image = Properties.Resources.BoundaryRecord;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            {
                mf.bnd.bndArr[mf.bnd.boundarySelected].CalculateBoundaryArea();

                if (mf.isMetric)
                {
                    lblArea.Text = Math.Round(mf.bnd.bndArr[mf.bnd.boundarySelected].area * 0.0001, 2) + " Ha";
                }
                else
                {
                    lblArea.Text = Math.Round(mf.bnd.bndArr[mf.bnd.boundarySelected].area * 0.000247105, 2) + " Acre";
                }
            }
        }
    }
}