using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormToolPivot : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        public FormToolPivot(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void FormToolPivot_Load(object sender, EventArgs e)
        {
            nudTrailingToolToPivotLength.Value = (decimal)(Math.Abs(Properties.Settings.Default.setTool_trailingToolToPivotLength) * mf.m2InchOrCm);
            nudTrailingToolToPivotLength.Controls[0].Enabled = false;

            if (!mf.isMetric)
            {
                nudTrailingToolToPivotLength.Maximum = Math.Round(nudTrailingToolToPivotLength.Maximum / 2.54M);
                nudTrailingToolToPivotLength.Minimum = Math.Round(nudTrailingToolToPivotLength.Minimum / 2.54M);
            }

            rbtnPivotBehindPos.Checked = Properties.Settings.Default.setTool_trailingToolToPivotLength >= 0;
            rbtnPivotAheadNeg.Checked = !(Properties.Settings.Default.setTool_trailingToolToPivotLength >= 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nudTrailingToolToPivotLength_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                if (rbtnPivotBehindPos.Checked)
                    mf.tool.trailingToolToPivotLength = (double)nudTrailingToolToPivotLength.Value * mf.inchOrCm2m;
                else
                    mf.tool.trailingToolToPivotLength = (double)nudTrailingToolToPivotLength.Value * -mf.inchOrCm2m;

                Properties.Settings.Default.setTool_trailingToolToPivotLength = mf.tool.trailingToolToPivotLength;
                Properties.Settings.Default.Save();
            }
        }

        private void rbtnPivotBehindPos_Click(object sender, EventArgs e)
        {
            if (rbtnPivotBehindPos.Checked)
                mf.tool.trailingToolToPivotLength = (double)nudTrailingToolToPivotLength.Value * mf.inchOrCm2m;
            else
                mf.tool.trailingToolToPivotLength = (double)nudTrailingToolToPivotLength.Value * -mf.inchOrCm2m;
            Properties.Settings.Default.setTool_trailingToolToPivotLength = mf.tool.trailingToolToPivotLength;
            Properties.Settings.Default.Save();
        }
    }
}