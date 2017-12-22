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
           mf.boundz.isOkToAddPoints = false;

           if (mf.boundz.ptList.Count > 5)
           {
               mf.boundz.PreCalcBoundaryLines();
               mf.boundz.isSet = true;
               mf.FileSaveOuterBoundary();
           }
           else
           {
               mf.boundz.calcList.Clear();
               mf.boundz.ptList.Clear();
               mf.boundz.area = 0;
               mf.boundz.isSet = false;
           }

            //close window
            Close();
    }

        //ctually the record button
        private void btnPausePlay_Click(object sender, EventArgs e)
        {
            if (mf.boundz.isOkToAddPoints)
            {
                mf.boundz.isOkToAddPoints = false;
                btnPausePlay.Image = Properties.Resources.BoundaryRecord;
                btnPausePlay.Text = "Record";
            }
            else
            {
                mf.boundz.isOkToAddPoints = true;
                btnPausePlay.Image = Properties.Resources.boundaryPause;
                btnPausePlay.Text = "Pause";
            }
        }

        private void FormBoundaryPlayer_Load(object sender, EventArgs e)
        {
            mf.boundz.isOkToAddPoints = false;
            btnPausePlay.Image = Properties.Resources.BoundaryRecord;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            mf.boundz.CalculateBoundaryArea();

            if (mf.isMetric)
            {
                lblArea.Text = Math.Round(mf.boundz.area * 0.0001, 2) + " Ha";
            }
            else
            {
                lblArea.Text = Math.Round(mf.boundz.area * 0.000247105, 2) + " Acre";
            }
        }
    }
}
