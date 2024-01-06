using System;
using System.Drawing;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormRefNudge : Form
    {
        private readonly FormGPS mf = null;

        private double snapAdj = 0;
        public FormRefNudge(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();

            this.Text = "";
        }

        private void FormEditTrack_Load(object sender, EventArgs e)
        {
            if (mf.isMetric)
            {
                nudSnapDistance.DecimalPlaces = 0;
                nudSnapDistance.Value = (int)((double)Properties.Settings.Default.setAS_snapDistanceRef);
            }
            else
            {
                nudSnapDistance.DecimalPlaces = 1;
                nudSnapDistance.Value = (decimal)Math.Round(((double)Properties.Settings.Default.setAS_snapDistanceRef * mf.cm2CmOrIn), 1);
            }

            snapAdj = Properties.Settings.Default.setAS_snapDistanceRef * 0.01;

            Location = Properties.Settings.Default.setWindow_formNudgeLocation;
            Size = Properties.Settings.Default.setWindow_formNudgeSize;
        }

        private void FormEditTrack_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void nudSnapDistance_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NudlessNumericUpDown)sender, this);
            snapAdj = (double)nudSnapDistance.Value * mf.inchOrCm2m;
            Properties.Settings.Default.setAS_snapDistanceRef = snapAdj*100;
            Properties.Settings.Default.Save();
        }

        private void btnAdjRight_Click(object sender, EventArgs e)
        {
            mf.trk.NudgeRefTrack(snapAdj);
        }

        private void btnAdjLeft_Click(object sender, EventArgs e)
        {
            mf.trk.NudgeRefTrack(-snapAdj);
        }


        private void btnHalfToolRight_Click(object sender, EventArgs e)
        {
            mf.trk.NudgeRefTrack((mf.tool.width-mf.tool.overlap) * 0.5);
        }

        private void btnHalfToolLeft_Click(object sender, EventArgs e)
        {
            mf.trk.NudgeRefTrack((mf.tool.width - mf.tool.overlap) * -0.5);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //if (mf.trk.gArr.Count > 0)
            {
                //save entire list
                mf.FileSaveTracks();
            }
            Close();

        }
    }
}
