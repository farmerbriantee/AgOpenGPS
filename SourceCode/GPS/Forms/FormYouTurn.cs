using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
//using Keypad;

namespace AgOpenGPS
{
    public partial class FormYouTurn : Form
    {
        //properties
        private readonly FormGPS mf = null;

        public FormYouTurn(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void btnYouTurnKeyHole_Click(object sender, EventArgs e)
        {
            mf.yt.LoadYouTurnShapeFromFile(@".\YouTurnShapes\KeyHole.txt");
            Properties.Settings.Default.setAS_youTurnShape = "KeyHole.txt";
            Properties.Settings.Default.Save();
            btnYouTurnKeyHole.BackColor = Color.Yellow;
            btnYouTurnSemiCircle.BackColor = Color.LimeGreen;
            btnYouTurnCustom.BackColor = Color.LimeGreen;

            //back to FormGPS
            //DialogResult = DialogResult.OK;
        }

        private void btnYouTurnSemiCircle_Click(object sender, EventArgs e)
        {
            mf.yt.LoadYouTurnShapeFromFile(@".\YouTurnShapes\SemiCircle.txt");
            Properties.Settings.Default.setAS_youTurnShape = "SemiCircle.txt";
            Properties.Settings.Default.Save();
            btnYouTurnKeyHole.BackColor = Color.LimeGreen;
            btnYouTurnSemiCircle.BackColor = Color.Yellow;
            btnYouTurnCustom.BackColor = Color.LimeGreen;

            //back to FormGPS
            //DialogResult = DialogResult.OK;
        }

        private void btnYouTurnCustom_Click(object sender, EventArgs e)
        {
            mf.yt.LoadYouTurnShapeFromFile(@".\YouTurnShapes\Custom.txt");
            Properties.Settings.Default.setAS_youTurnShape = "Custom.txt";
            Properties.Settings.Default.Save();
            btnYouTurnKeyHole.BackColor = Color.LimeGreen;
            btnYouTurnSemiCircle.BackColor = Color.LimeGreen;
            btnYouTurnCustom.BackColor = Color.Yellow;

            //back to FormGPS
            //DialogResult = DialogResult.OK;
        }

        private void btnYouTurnRecord_Click(object sender, EventArgs e)
        {
            if (mf.ABLine.isABLineSet)
            {
                var form = new FormYouTurnRecord(mf);
                form.Show();
                Properties.Settings.Default.setAS_startYouTurnAt = mf.yt.startYouTurnAt;
                Properties.Settings.Default.Save();
                Close();
            }
            else { mf.TimedMessageBox(3000, "No AB Lines", "Start AB Line Guidance"); }
        }

        private void FormYouTurn_Load(object sender, EventArgs e)
        {
            lblDistance.Text = mf.yt.startYouTurnAt.ToString();
            if (mf.yt.isAutoYouTurnEnabled)
            {
                btnEnableAutoYouTurn.BackColor = Color.LightGreen;
                btnEnableAutoYouTurn.Text = "Auto YouTurn On";
                lblDistance.Text = Math.Abs(mf.yt.startYouTurnAt).ToString() + " m";
                if (mf.yt.startYouTurnAt < 0) lblWhenTrig.Text = "Before boundary line";
                else lblWhenTrig.Text = "After boundary line";
            }
            else
            {
                btnEnableAutoYouTurn.BackColor = SystemColors.ButtonFace;
                btnEnableAutoYouTurn.Text = "Auto YouTurn Off";
                lblDistance.Text = Math.Abs(mf.yt.startYouTurnAt).ToString() + " m";
                if (mf.yt.startYouTurnAt < 0) lblWhenTrig.Text = "Before boundary line";
                else lblWhenTrig.Text = "After boundary line";
            }

            if (Properties.Settings.Default.setAS_youTurnShape == "KeyHole.txt")
            {
                btnYouTurnKeyHole.BackColor = Color.Yellow;
                btnYouTurnSemiCircle.BackColor = Color.LimeGreen;
                btnYouTurnCustom.BackColor = Color.LimeGreen;
            }

            if (Properties.Settings.Default.setAS_youTurnShape == "SemiCircle.txt")
            {
                btnYouTurnKeyHole.BackColor = Color.LimeGreen;
                btnYouTurnSemiCircle.BackColor = Color.Yellow;
                btnYouTurnCustom.BackColor = Color.LimeGreen;
            }

            if (Properties.Settings.Default.setAS_youTurnShape == "Custom.txt")
            {
                btnYouTurnKeyHole.BackColor = Color.LimeGreen;
                btnYouTurnSemiCircle.BackColor = Color.LimeGreen;
                btnYouTurnCustom.BackColor = Color.Yellow;
            }

        }

        private void btnEnableAutoYouTurn_Click(object sender, EventArgs e)
        {
            if (!mf.yt.isAutoYouTurnEnabled)
            {
                mf.yt.isAutoYouTurnEnabled = true;
                btnEnableAutoYouTurn.BackColor = Color.LightGreen;
                btnEnableAutoYouTurn.Text = "Auto YouTurn On";
            }
            else
            {
                mf.yt.isAutoYouTurnEnabled = false;
                btnEnableAutoYouTurn.BackColor = SystemColors.ButtonFace;
                btnEnableAutoYouTurn.Text = "Auto YouTurn Off";
            }
        }

        private void btnDistanceDn_MouseDown(object sender, MouseEventArgs e)
        {
            if (mf.yt.startYouTurnAt-- < -48) mf.yt.startYouTurnAt = -49;
            lblDistance.Text = Math.Abs(mf.yt.startYouTurnAt).ToString() + " m";
            if (mf.yt.startYouTurnAt < 0) lblWhenTrig.Text = "Before boundary line";
            else lblWhenTrig.Text = "After boundary line";
        }

        private void btnDistanceUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (mf.yt.startYouTurnAt++ > 49) mf.yt.startYouTurnAt = 50;
            lblDistance.Text = Math.Abs(mf.yt.startYouTurnAt).ToString() + " m";
            if (mf.yt.startYouTurnAt < 0) lblWhenTrig.Text = "Before boundary line";
            else lblWhenTrig.Text = "After boundary line";
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.setAS_startYouTurnAt = mf.yt.startYouTurnAt;
            Properties.Settings.Default.Save();
            Close();
        }

        //private void numKeypad1_ButtonPressed(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 'O') bntOK.PerformClick();
        //}
    }
}
