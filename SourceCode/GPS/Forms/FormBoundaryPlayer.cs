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
            if (mf.bnd.bndBeingMadePts.Count > 5)
            {
                mf.bnd.bndArr.Add(new CBoundaryLines());
                mf.turn.turnArr.Add(new CTurnLines());
                mf.gf.geoFenceArr.Add(new CGeoFenceLines());

                for (int i = 0; i < mf.bnd.bndBeingMadePts.Count; i++)
                {
                    mf.bnd.bndArr[mf.bnd.boundarySelected].bndLine.Add(mf.bnd.bndBeingMadePts[i]);
                }

                mf.bnd.bndArr[mf.bnd.boundarySelected].PreCalcBoundaryLines();
                mf.bnd.bndArr[mf.bnd.boundarySelected].FixBoundaryLine(mf.bnd.boundarySelected, mf.vehicle.toolWidth);
                mf.bnd.bndArr[mf.bnd.boundarySelected].PreCalcBoundaryLines();
                mf.bnd.bndArr[mf.bnd.boundarySelected].isSet = true;
                mf.bnd.bndArr[mf.bnd.boundarySelected].CalculateBoundaryArea();
                mf.fd.UpdateFieldBoundaryGUIAreas();
            }

            //stop it all for adding
            mf.bnd.isOkToAddPoints = false;

            //turn lines made from boundaries
            mf.CalculateMinMax();
            mf.FileSaveBoundary();
            mf.turn.BuildTurnLines();
            mf.gf.BuildGeoFenceLines();

            //Task.Run(() => mf.mazeGrid.BuildMazeGridArray());
            mf.mazeGrid.BuildMazeGridArray();

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
                btnPausePlay.Text = gStr.gsRecord;
            }
            else
            {
                mf.bnd.isOkToAddPoints = true;
                btnPausePlay.Image = Properties.Resources.boundaryPause;
                btnPausePlay.Text = gStr.gsPause;
            }
        }

        private void FormBoundaryPlayer_Load(object sender, EventArgs e)
        {
            mf.bnd.isOkToAddPoints = false;
            btnPausePlay.Image = Properties.Resources.BoundaryRecord;
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
        }
    }
}