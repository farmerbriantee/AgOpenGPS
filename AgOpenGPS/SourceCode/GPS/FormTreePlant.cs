using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (mf.manualBtnState != AgOpenGPS.FormGPS.btnStates.Off)
            {
                mf.btnManualOffOn.PerformClick();
            }

            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isRunning)
            {
                lblDistanceTree.Text = ((UInt16)mf.treeSpacingCounter).ToString();
                lblStepDistance.Text = (mf.distanceCurrentStepFix * 100).ToString("N1");
                if (lastDist > mf.treeSpacingCounter)
                {
                    //lblSpacing.Text = mf.vehicle.treeSpacing.ToString();
                    wasRed = !wasRed;
                    trees++;
                    if (wasRed) btnZeroDistance.BackColor = Color.DarkSeaGreen;
                    else btnZeroDistance.BackColor = Color.LightGreen;
                }
                btnZeroDistance.Text = "Stop";
            }
            else
            {
                btnZeroDistance.Text = "Start";
            }

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
            }

            isRunning = !isRunning;
        }

        private void FormTreePlant_Load(object sender, EventArgs e)
        {
            if (mf.manualBtnState != AgOpenGPS.FormGPS.btnStates.Off)
            {
                mf.btnManualOffOn.PerformClick();
            }

            lblSpacing.Text = mf.vehicle.treeSpacing.ToString();
            lastDist = 0;
            mf.treeSpacingCounter = 0;
            trees = 0;
            isRunning = false;
            btnZeroDistance.Text = "Start";
            btnZeroDistance.BackColor = Color.OrangeRed;
        }
    }
}
