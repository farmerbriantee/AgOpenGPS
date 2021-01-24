using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//using Keypad;

namespace AgOpenGPS
{
    public partial class FormYouTurn : Form
    {
        //properties
        private readonly FormGPS mf;

        //strings for comboboxes past auto and manual choices
        //pos0 is "-" no matter what

        public FormYouTurn(Form callingForm)
        {
            mf = callingForm as FormGPS;

            //winform initialization
            InitializeComponent();


            this.Text = gStr.gsUTurn;

            // U Turn tab
            btnYouTurnCustom.Text = gStr.gsCustom;
            label46.Text = gStr.gsDubins + " " + gStr.gsPattern;
            label1.Text = gStr.gsSkips;
            btnIsUsingDubins.Text = gStr.gsDubins;
            label48.Text = gStr.gsUTurnDistance + " " + gStr.gsFromBounds;
            groupBox1.Text = gStr.gsTurnPatterns;
            lblWhenTrig.Text = gStr.gsUTurnLength;
            btnYouTurnRecord.Text = gStr.gsRecord;
        }

            // Entry tab
        private void FormYouTurn_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.setAS_youTurnShape == "KeyHole.txt")
            {
                btnYouTurnKeyHole.BackColor = Color.LimeGreen;
                btnYouTurnSemiCircle.BackColor = Color.Silver;
                btnYouTurnCustom.BackColor = Color.Silver;
            }

            if (Properties.Settings.Default.setAS_youTurnShape == "SemiCircle.txt")
            {
                btnYouTurnKeyHole.BackColor = Color.Silver;
                btnYouTurnSemiCircle.BackColor = Color.LimeGreen;
                btnYouTurnCustom.BackColor = Color.Silver;
            }

            if (Properties.Settings.Default.setAS_youTurnShape == "Custom.txt")
            {
                btnYouTurnKeyHole.BackColor = Color.Silver;
                btnYouTurnSemiCircle.BackColor = Color.Silver;
                btnYouTurnCustom.BackColor = Color.LimeGreen;
            }

            cboxRowWidth.SelectedIndex = mf.yt.rowSkipsWidth - 1;

            lblDistance.Text = mf.yt.youTurnStartOffset.ToString();
            if (mf.yt.isYouTurnBtnOn)
            {
                lblDistance.Text = Math.Abs(mf.yt.youTurnStartOffset).ToString() + " m";
            }
            else
            {
                lblDistance.Text = Math.Abs(mf.yt.youTurnStartOffset).ToString() + " m";
            }

            lblTriggerDistance.Text = mf.yt.triggerDistanceOffset.ToString() + "m";

            //update dubins button
            if (!mf.yt.isUsingDubinsTurn)
            {
                btnIsUsingDubins.Text = gStr.gsPattern;
                btnIsUsingDubins.BackColor = Color.Salmon;
                btnYouTurnCustom.Enabled = true;
                btnYouTurnKeyHole.Enabled = true;
                btnYouTurnRecord.Enabled = true;
                btnYouTurnWideReturn.Enabled = true;
                btnYouTurnSemiCircle.Enabled = true;
            }
            else
            {
                btnIsUsingDubins.Text = gStr.gsDubins;
                btnIsUsingDubins.BackColor = Color.LightGreen;
                btnYouTurnCustom.Enabled = false;
                btnYouTurnKeyHole.Enabled = false;
                btnYouTurnRecord.Enabled = false;
                btnYouTurnWideReturn.Enabled = false;
                btnYouTurnSemiCircle.Enabled = false;
            }
        }

        #region Procedures

        #endregion Procedures

        #region YouTurn

        // YouTurn Tab

        private void btnYouTurnKeyHole_Click(object sender, EventArgs e)
        {
            mf.yt.LoadYouTurnShapeFromFile(@".\Dependencies/YouTurnShapes\KeyHole.txt");
            Properties.Settings.Default.setAS_youTurnShape = "KeyHole.txt";
            Properties.Settings.Default.Save();
            btnYouTurnKeyHole.BackColor = Color.LimeGreen;
            btnYouTurnSemiCircle.BackColor = Color.Silver;
            btnYouTurnCustom.BackColor = Color.Silver;
            btnYouTurnWideReturn.BackColor = Color.Silver;
        }

        private void btnYouTurnSemiCircle_Click(object sender, EventArgs e)
        {
            mf.yt.LoadYouTurnShapeFromFile(@".\Dependencies\YouTurnShapes\SemiCircle.txt");
            Properties.Settings.Default.setAS_youTurnShape = "SemiCircle.txt";
            Properties.Settings.Default.Save();
            btnYouTurnKeyHole.BackColor = Color.Silver;
            btnYouTurnSemiCircle.BackColor = Color.LimeGreen;
            btnYouTurnCustom.BackColor = Color.Silver;
            btnYouTurnWideReturn.BackColor = Color.Silver;
        }

        private void btnYouTurnWideReturn_Click(object sender, EventArgs e)
        {
            mf.yt.LoadYouTurnShapeFromFile(@".\Dependencies\YouTurnShapes\WideReturn.txt");
            Properties.Settings.Default.setAS_youTurnShape = "WideReturn.txt";
            Properties.Settings.Default.Save();
            btnYouTurnKeyHole.BackColor = Color.Silver;
            btnYouTurnSemiCircle.BackColor = Color.Silver;
            btnYouTurnCustom.BackColor = Color.Silver;
            btnYouTurnWideReturn.BackColor = Color.LimeGreen;
        }

        private void btnYouTurnCustom_Click(object sender, EventArgs e)
        {
            mf.yt.LoadYouTurnShapeFromFile(@".\Dependencies\YouTurnShapes\Custom.txt");
            Properties.Settings.Default.setAS_youTurnShape = "Custom.txt";
            Properties.Settings.Default.Save();
            btnYouTurnKeyHole.BackColor = Color.Silver;
            btnYouTurnSemiCircle.BackColor = Color.Silver;
            btnYouTurnCustom.BackColor = Color.LimeGreen;
            btnYouTurnWideReturn.BackColor = Color.Silver;
        }

        private void btnYouTurnRecord_Click(object sender, EventArgs e)
        {
            if (mf.ABLine.isABLineSet)
            {
                var form = new FormYouTurnRecord(mf);
                form.Show();
                Close();
            }
            else { mf.TimedMessageBox(3000, "No AB Lines", "Start AB Line Guidance"); }
        }

        private void btnIsUsingDubins_Click(object sender, EventArgs e)
        {
            if (mf.yt.isUsingDubinsTurn)
            {
                mf.yt.isUsingDubinsTurn = false;
                btnIsUsingDubins.Text = gStr.gsPattern;
                btnIsUsingDubins.BackColor = Color.Salmon;
                btnYouTurnCustom.Enabled = true;
                btnYouTurnKeyHole.Enabled = true;
                btnYouTurnRecord.Enabled = true;
                btnYouTurnWideReturn.Enabled = true;
                btnYouTurnSemiCircle.Enabled = true;
            }
            else
            {
                mf.yt.isUsingDubinsTurn = true;
                btnIsUsingDubins.Text = gStr.gsDubins;
                btnIsUsingDubins.BackColor = Color.LightGreen;
                btnYouTurnCustom.Enabled = false;
                btnYouTurnKeyHole.Enabled = false;
                btnYouTurnRecord.Enabled = false;
                btnYouTurnWideReturn.Enabled = false;
                btnYouTurnSemiCircle.Enabled = false;
            }
        }

        private void cboxRowWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.yt.rowSkipsWidth = cboxRowWidth.SelectedIndex + 1;
        }

        #endregion YouTurn

        #region distance

        private void btnDistanceDn_Click(object sender, EventArgs e)
        {
            if (mf.yt.youTurnStartOffset-- < 4) mf.yt.youTurnStartOffset = 3;
            lblDistance.Text = Math.Abs(mf.yt.youTurnStartOffset).ToString() + " m";
            if (mf.yt.youTurnStartOffset < 0) lblWhenTrig.Text = "Before";
            else lblWhenTrig.Text = gStr.gsAfter;
        }

        private void btnDistanceUp_Click(object sender, EventArgs e)
        {
            if (mf.yt.youTurnStartOffset++ > 49) mf.yt.youTurnStartOffset = 50;
            lblDistance.Text = Math.Abs(mf.yt.youTurnStartOffset).ToString() + " m";
            if (mf.yt.youTurnStartOffset < 0) lblWhenTrig.Text = "Before";
            else lblWhenTrig.Text = gStr.gsAfter;
        }

        private void btnTriggerDistanceUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (mf.yt.triggerDistanceOffset++ > 50) mf.yt.triggerDistanceOffset = 50;
            lblTriggerDistance.Text = mf.yt.triggerDistanceOffset.ToString() + "m";
        }

        private void btnTriggerDistanceDn_MouseDown(object sender, MouseEventArgs e)
        {
            mf.yt.triggerDistanceOffset--;
            if (mf.yt.triggerDistanceOffset < 0) mf.yt.triggerDistanceOffset = 0;
            lblTriggerDistance.Text = mf.yt.triggerDistanceOffset.ToString() + "m";
        }

        #endregion distance

        private void btnOK_Click(object sender, EventArgs e)
        {

            //Properties.Vehicle.Default.set_youSkipHeight = mf.yt.rowSkipsHeight;
            Properties.Vehicle.Default.set_youSkipWidth = mf.yt.rowSkipsWidth;
            Properties.Vehicle.Default.set_youUseDubins = mf.yt.isUsingDubinsTurn;

            Properties.Vehicle.Default.set_youTurnDistance = mf.yt.youTurnStartOffset;
            Properties.Vehicle.Default.set_youTriggerDistance = mf.yt.triggerDistanceOffset;

            StringBuilder sbEntry = new StringBuilder();
            StringBuilder sbExit = new StringBuilder();

            //save it all
            Properties.Vehicle.Default.Save();
            Close();
            mf.turn.BuildTurnLines();
            mf.yt.ResetCreatedYouTurn();
        }

    }
}
