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
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
           mf.boundary.isOkToAddPoints = false;

           if (mf.boundary.ptList.Count > 5)
           {
               mf.boundary.PreCalcBoundaryLines();
               mf.boundary.isSet = true;
               mf.FileSaveOuterBoundary();
           }
           else
           {
               mf.boundary.calcList.Clear();
               mf.boundary.ptList.Clear();
               mf.boundary.area = 0;
               mf.boundary.isSet = false;
           }

            //close window
            Close();
    }

        //ctually the record button
        private void btnPausePlay_Click(object sender, EventArgs e)
        {
            if (mf.boundary.isOkToAddPoints)
            {
                mf.boundary.isOkToAddPoints = false;
                btnPausePlay.Image = Properties.Resources.BoundaryRecord;
                btnPausePlay.Text = "Record";
            }
            else
            {
                mf.boundary.isOkToAddPoints = true;
                btnPausePlay.Image = Properties.Resources.boundaryPause;
                btnPausePlay.Text = "Pause";
            }
        }

        private void FormBoundaryPlayer_Load(object sender, EventArgs e)
        {
            mf.boundary.isOkToAddPoints = false;
            btnPausePlay.Image = Properties.Resources.BoundaryRecord;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            mf.boundary.CalculateBoundaryArea();

            if (mf.isMetric)
            {
                lblArea.Text = Math.Round(mf.boundary.area * 0.0001, 2) + " Ha";
            }
            else
            {
                lblArea.Text = Math.Round(mf.boundary.area * 0.000247105, 2) + " Acre";
            }
        }
    }
}
