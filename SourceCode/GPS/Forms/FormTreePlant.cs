using System;
using System.Drawing;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormTreePlant : Form
    {
        private readonly FormGPS mf = null;
        private double lastDist;
        private bool wasRed, isRunning;
        private int trees;

        public FormTreePlant(Form callingForm)
        {
            mf = callingForm as FormGPS;

            InitializeComponent();
            nudTreeSpacing.Controls[0].Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (mf.manualBtnState != AgOpenGPS.FormGPS.btnStates.Off)
            {
                mf.btnManualOffOn.PerformClick();
            }
            Properties.Settings.Default.setDistance_TreeSpacing = mf.vehicle.treeSpacing;
            Properties.Settings.Default.Save();
            mf.vehicle.treeSpacing = 0;
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isRunning)
            {
                lblDistanceTree.Text = ((UInt16)mf.treeSpacingCounter).ToString();
                if (lastDist > mf.treeSpacingCounter)
                {
                    //lblSpacing.Text = mf.vehicle.treeSpacing.ToString();
                    wasRed = !wasRed;
                    trees++;
                    if (wasRed) btnZeroDistance.BackColor = Color.DarkSeaGreen;
                    else btnZeroDistance.BackColor = Color.LightGreen;
                }
                btnZeroDistance.Text = gStr.gsStop;
            }
            else
            {
                btnZeroDistance.Text = gStr.gsStart;
            }

            lblStepDistance.Text = (mf.distanceCurrentStepFix * 100).ToString("N1");
            lblSpeed.Text = mf.pn.speed.ToString("N1");
            lblTrees.Text = trees.ToString();
            lastDist = mf.treeSpacingCounter;
        }

        private void btnZeroDistance_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                lastDist = 0;
                mf.treeSpacingCounter = 0;
                if (mf.manualBtnState != AgOpenGPS.FormGPS.btnStates.Off)
                {
                    mf.btnManualOffOn.PerformClick();
                }

                mf.distanceCurrentStepFix = 0;
                lblDistanceTree.Text = ((UInt16)mf.treeSpacingCounter).ToString();
                lblStepDistance.Text = (mf.distanceCurrentStepFix * 100).ToString("N1");
                btnZeroDistance.BackColor = Color.OrangeRed;
                //mf.vehicle.treeSpacing = Properties.Settings.Default.setDistance_TreeSpacing;
            }
            else
            {
                lastDist = 0;
                trees = 0;
                mf.treeSpacingCounter = 0;
                if (mf.manualBtnState == AgOpenGPS.FormGPS.btnStates.Off)
                {
                    mf.btnManualOffOn.PerformClick();
                }

                mf.distanceCurrentStepFix = 0;
                lblDistanceTree.Text = ((UInt16)mf.treeSpacingCounter).ToString();
                lblStepDistance.Text = (mf.distanceCurrentStepFix * 100).ToString("N1");
                btnZeroDistance.BackColor = Color.LightGreen;
                //mf.vehicle.treeSpacing = Properties.Settings.Default.setDistance_TreeSpacing;
            }

            isRunning = !isRunning;
        }

        private void NudTreeSpacing_ValueChanged(object sender, EventArgs e)
        {
            mf.vehicle.treeSpacing = (double)nudTreeSpacing.Value;
        }

        private void NudTreeSpacing_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnStop.Focus();
        }

        private void FormTreePlant_Load(object sender, EventArgs e)
        {
            //Set Language
            label12.Text = gStr.gsSpacing;
            label1.Text = gStr.gsStep;
            btnZeroDistance.Text = gStr.gsBegin;
            btnStop.Text = gStr.gsDone;
            label3.Text = gStr.gsTrees;
            this.Text = gStr.gsTree_Plant_Control;

            if (mf.manualBtnState != AgOpenGPS.FormGPS.btnStates.Off)
            {
                mf.btnManualOffOn.PerformClick();
            }

            //mf.vehicle.treeSpacing = Properties.Settings.Default.setDistance_TreeSpacing;

            nudTreeSpacing.Value = (decimal)mf.vehicle.treeSpacing;
            lastDist = 0;
            mf.treeSpacingCounter = 0;
            trees = 0;
            isRunning = false;
            btnZeroDistance.Text = gStr.gsStart;
            btnZeroDistance.BackColor = Color.OrangeRed;
        }
    }
}