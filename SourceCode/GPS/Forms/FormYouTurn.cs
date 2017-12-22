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
        private readonly FormGPS mf;

        //strings for comboboxes past auto and manual choices
        //pos0 is "-" no matter what

        public FormYouTurn(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void FormYouTurn_Load(object sender, EventArgs e)
        {
            //Fill in the strings for comboboxes - editable
            string line = Properties.Vehicle.Default.seq_FunctionList;
            string[] words = line.Split(',');

            mf.yt.pos3 = words[0];
            mf.yt.pos4 = words[1];
            mf.yt.pos5 = words[2];
            mf.yt.pos6 = words[3];
            mf.yt.pos7 = words[4];
            mf.yt.pos8 = words[5];

            //set button text and background color
            btnToggle3.Text = mf.yt.pos3;
            btnToggle4.Text = mf.yt.pos4;
            btnToggle5.Text = mf.yt.pos5;
            btnToggle6.Text = mf.yt.pos6;
            btnToggle7.Text = mf.yt.pos7;
            btnToggle8.Text = mf.yt.pos8;
            FunctionButtonsOnOff();

            //the drop down lists
            LoadComboStrings();

            //the edit page of text boxes
            LoadEditFunctionNames();

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

            cboxRowHeight.SelectedIndex = mf.yt.rowSkipsHeight - 1;
            cboxRowWidth.SelectedIndex = mf.yt.rowSkipsWidth - 1;

            //populate the Enter and Exit pages.
            PopulateSequencePages();

            lblDistance.Text = mf.yt.youTurnStartOffset.ToString();
            if (mf.yt.isYouTurnBtnOn)
            {
                lblDistance.Text = Math.Abs(mf.yt.youTurnStartOffset).ToString() + " m";
                if (mf.yt.youTurnStartOffset < 0) lblWhenTrig.Text = "Before";
                else lblWhenTrig.Text = "After";
            }
            else
            {
                lblDistance.Text = Math.Abs(mf.yt.youTurnStartOffset).ToString() + " m";
                if (mf.yt.youTurnStartOffset < 0) lblWhenTrig.Text = "Before";
                else lblWhenTrig.Text = "After";
            }
        }

        #region Procedures

        private void PopulateSequencePages()
        {
            if (mf.seq.seqEnter[0].function == 0)
            {
                cboxEnterFunc0.SelectedIndex = mf.seq.seqEnter[0].function;
                cboxEnterAction0.SelectedIndex = -1;
            }
            else
            {
                cboxEnterFunc0.SelectedIndex = mf.seq.seqEnter[0].function;
                cboxEnterAction0.SelectedIndex = mf.seq.seqEnter[0].action;
                nudEnter0.Value = (decimal)mf.seq.seqEnter[0].distance;
            }

            if (mf.seq.seqEnter[1].function == 0)
            {
                cboxEnterFunc1.SelectedIndex = mf.seq.seqEnter[1].function;
                cboxEnterAction1.SelectedIndex = -1;
            }
            else
            {
                cboxEnterFunc1.SelectedIndex = mf.seq.seqEnter[1].function;
                cboxEnterAction1.SelectedIndex = mf.seq.seqEnter[1].action;
                nudEnter1.Value = (decimal)mf.seq.seqEnter[1].distance;
            }

            if (mf.seq.seqEnter[2].function == 0)
            {
                cboxEnterFunc2.SelectedIndex = mf.seq.seqEnter[2].function;
                cboxEnterAction2.SelectedIndex = -1;
            }
            else
            {
                cboxEnterFunc2.SelectedIndex = mf.seq.seqEnter[2].function;
                cboxEnterAction2.SelectedIndex = mf.seq.seqEnter[2].action;
                nudEnter2.Value = (decimal)mf.seq.seqEnter[2].distance;
            }

            if (mf.seq.seqEnter[3].function == 0)
            {
                cboxEnterFunc3.SelectedIndex = mf.seq.seqEnter[3].function;
                cboxEnterAction3.SelectedIndex = -1;
            }
            else
            {
                cboxEnterFunc3.SelectedIndex = mf.seq.seqEnter[3].function;
                cboxEnterAction3.SelectedIndex = mf.seq.seqEnter[3].action;
                nudEnter3.Value = (decimal)mf.seq.seqEnter[3].distance;
            }

            if (mf.seq.seqEnter[4].function == 0)
            {
                cboxEnterFunc4.SelectedIndex = mf.seq.seqEnter[4].function;
                cboxEnterAction4.SelectedIndex = -1;
            }
            else
            {
                cboxEnterFunc4.SelectedIndex = mf.seq.seqEnter[4].function;
                cboxEnterAction4.SelectedIndex = mf.seq.seqEnter[4].action;
                nudEnter4.Value = (decimal)mf.seq.seqEnter[4].distance;
            }

            if (mf.seq.seqEnter[5].function == 0)
            {
                cboxEnterFunc5.SelectedIndex = mf.seq.seqEnter[5].function;
                cboxEnterAction5.SelectedIndex = -1;
            }
            else
            {
                cboxEnterFunc5.SelectedIndex = mf.seq.seqEnter[5].function;
                cboxEnterAction5.SelectedIndex = mf.seq.seqEnter[5].action;
                nudEnter5.Value = (decimal)mf.seq.seqEnter[5].distance;
            }

            if (mf.seq.seqEnter[6].function == 0)
            {
                cboxEnterFunc6.SelectedIndex = mf.seq.seqEnter[6].function;
                cboxEnterAction6.SelectedIndex = -1;
            }
            else
            {
                cboxEnterFunc6.SelectedIndex = mf.seq.seqEnter[6].function;
                cboxEnterAction6.SelectedIndex = mf.seq.seqEnter[6].action;
                nudEnter6.Value = (decimal)mf.seq.seqEnter[6].distance;
            }

            if (mf.seq.seqEnter[7].function == 0)
            {
                cboxEnterFunc7.SelectedIndex = mf.seq.seqEnter[7].function;
                cboxEnterAction7.SelectedIndex = -1;
            }
            else
            {
                cboxEnterFunc7.SelectedIndex = mf.seq.seqEnter[7].function;
                cboxEnterAction7.SelectedIndex = mf.seq.seqEnter[7].action;
                nudEnter7.Value = (decimal)mf.seq.seqEnter[7].distance;
            }

            //Exit page

            if (mf.seq.seqExit[0].function == 0)
            {
                cboxExitFunc0.SelectedIndex = mf.seq.seqExit[0].function;
                cboxExitAction0.SelectedIndex = -1;
            }
            else
            {
                cboxExitFunc0.SelectedIndex = mf.seq.seqExit[0].function;
                cboxExitAction0.SelectedIndex = mf.seq.seqExit[0].action;
                nudExit0.Value = (decimal)mf.seq.seqExit[0].distance;
            }

            if (mf.seq.seqExit[1].function == 0)
            {
                cboxExitFunc1.SelectedIndex = mf.seq.seqExit[1].function;
                cboxExitAction1.SelectedIndex = -1;
            }
            else
            {
                cboxExitFunc1.SelectedIndex = mf.seq.seqExit[1].function;
                cboxExitAction1.SelectedIndex = mf.seq.seqExit[1].action;
                nudExit1.Value = (decimal)mf.seq.seqExit[1].distance;
            }

            if (mf.seq.seqExit[2].function == 0)
            {
                cboxExitFunc2.SelectedIndex = mf.seq.seqExit[2].function;
                cboxExitAction2.SelectedIndex = -1;
            }
            else
            {
                cboxExitFunc2.SelectedIndex = mf.seq.seqExit[2].function;
                cboxExitAction2.SelectedIndex = mf.seq.seqExit[2].action;
                nudExit2.Value = (decimal)mf.seq.seqExit[2].distance;
            }

            if (mf.seq.seqExit[3].function == 0)
            {
                cboxExitFunc3.SelectedIndex = mf.seq.seqExit[3].function;
                cboxExitAction3.SelectedIndex = -1;
            }
            else
            {
                cboxExitFunc3.SelectedIndex = mf.seq.seqExit[3].function;
                cboxExitAction3.SelectedIndex = mf.seq.seqExit[3].action;
                nudExit3.Value = (decimal)mf.seq.seqExit[3].distance;
            }

            if (mf.seq.seqExit[4].function == 0)
            {
                cboxExitFunc4.SelectedIndex = mf.seq.seqExit[4].function;
                cboxExitAction4.SelectedIndex = -1;
            }
            else
            {
                cboxExitFunc4.SelectedIndex = mf.seq.seqExit[4].function;
                cboxExitAction4.SelectedIndex = mf.seq.seqExit[4].action;
                nudExit4.Value = (decimal)mf.seq.seqExit[4].distance;
            }

            if (mf.seq.seqExit[5].function == 0)
            {
                cboxExitFunc5.SelectedIndex = mf.seq.seqExit[5].function;
                cboxExitAction5.SelectedIndex = -1;
            }
            else
            {
                cboxExitFunc5.SelectedIndex = mf.seq.seqExit[5].function;
                cboxExitAction5.SelectedIndex = mf.seq.seqExit[5].action;
                nudExit5.Value = (decimal)mf.seq.seqExit[5].distance;
            }

            if (mf.seq.seqExit[6].function == 0)
            {
                cboxExitFunc6.SelectedIndex = mf.seq.seqExit[6].function;
                cboxExitAction6.SelectedIndex = -1;
            }
            else
            {
                cboxExitFunc6.SelectedIndex = mf.seq.seqExit[6].function;
                cboxExitAction6.SelectedIndex = mf.seq.seqExit[6].action;
                nudExit6.Value = (decimal)mf.seq.seqExit[6].distance;
            }

            if (mf.seq.seqExit[7].function == 0)
            {
                cboxExitFunc7.SelectedIndex = mf.seq.seqExit[7].function;
                cboxExitAction7.SelectedIndex = -1;
            }
            else
            {
                cboxExitFunc7.SelectedIndex = mf.seq.seqExit[7].function;
                cboxExitAction7.SelectedIndex = mf.seq.seqExit[7].action;
                nudExit7.Value = (decimal)mf.seq.seqExit[7].distance;
            }
        }

        private void SaveSequences()
        {
            //first the entry save
            if (cboxEnterFunc0.SelectedIndex == 0)
            {
                mf.seq.DisableSeqEvent(0, true);
            }
            else
            {
                mf.seq.seqEnter[0].function = cboxEnterFunc0.SelectedIndex;
                mf.seq.seqEnter[0].action = cboxEnterAction0.SelectedIndex;
                mf.seq.seqEnter[0].isTrig = false;
                mf.seq.seqEnter[0].distance = (int)nudEnter0.Value;
            }

            if (cboxEnterFunc1.SelectedIndex == 0)
            {
                mf.seq.DisableSeqEvent(1, true);
            }
            else
            {
                mf.seq.seqEnter[1].function = cboxEnterFunc1.SelectedIndex;
                mf.seq.seqEnter[1].action = cboxEnterAction1.SelectedIndex;
                mf.seq.seqEnter[1].isTrig = false;
                mf.seq.seqEnter[1].distance = (int)nudEnter1.Value;
            }

            if (cboxEnterFunc2.SelectedIndex == 0)
            {
                mf.seq.DisableSeqEvent(2, true);
            }
            else
            {
                mf.seq.seqEnter[2].function = cboxEnterFunc2.SelectedIndex;
                mf.seq.seqEnter[2].action = cboxEnterAction2.SelectedIndex;
                mf.seq.seqEnter[2].isTrig = false;
                mf.seq.seqEnter[2].distance = (int)nudEnter2.Value;
            }

            if (cboxEnterFunc3.SelectedIndex == 0)
            {
                mf.seq.DisableSeqEvent(3, true);
            }
            else
            {
                mf.seq.seqEnter[3].function = cboxEnterFunc3.SelectedIndex;
                mf.seq.seqEnter[3].action = cboxEnterAction3.SelectedIndex;
                mf.seq.seqEnter[3].isTrig = false;
                mf.seq.seqEnter[3].distance = (int)nudEnter3.Value;
            }

            if (cboxEnterFunc4.SelectedIndex == 0)
            {
                mf.seq.DisableSeqEvent(4, true);
            }
            else
            {
                mf.seq.seqEnter[4].function = cboxEnterFunc4.SelectedIndex;
                mf.seq.seqEnter[4].action = cboxEnterAction4.SelectedIndex;
                mf.seq.seqEnter[4].isTrig = false;
                mf.seq.seqEnter[4].distance = (int)nudEnter4.Value;
            }

            if (cboxEnterFunc5.SelectedIndex == 0)
            {
                mf.seq.DisableSeqEvent(5, true);
            }
            else
            {
                mf.seq.seqEnter[5].function = cboxEnterFunc5.SelectedIndex;
                mf.seq.seqEnter[5].action = cboxEnterAction5.SelectedIndex;
                mf.seq.seqEnter[5].isTrig = false;
                mf.seq.seqEnter[5].distance = (int)nudEnter5.Value;
            }

            if (cboxEnterFunc6.SelectedIndex == 0)
            {
                mf.seq.DisableSeqEvent(6, true);
            }
            else
            {
                mf.seq.seqEnter[6].function = cboxEnterFunc6.SelectedIndex;
                mf.seq.seqEnter[6].action = cboxEnterAction6.SelectedIndex;
                mf.seq.seqEnter[6].isTrig = false;
                mf.seq.seqEnter[6].distance = (int)nudEnter6.Value;
            }

            if (cboxEnterFunc7.SelectedIndex == 0)
            {
                mf.seq.DisableSeqEvent(7, true);
            }
            else
            {
                mf.seq.seqEnter[7].function = cboxEnterFunc7.SelectedIndex;
                mf.seq.seqEnter[7].action = cboxEnterAction7.SelectedIndex;
                mf.seq.seqEnter[7].isTrig = false;
                mf.seq.seqEnter[7].distance = (int)nudEnter7.Value;
            }

            //save the exit fields
            if (cboxExitFunc0.SelectedIndex == 0)
            {
                mf.seq.DisableSeqEvent(0, false);
            }
            else
            {
                mf.seq.seqExit[0].function = cboxExitFunc0.SelectedIndex;
                mf.seq.seqExit[0].action = cboxExitAction0.SelectedIndex;
                mf.seq.seqExit[0].isTrig = false;
                mf.seq.seqExit[0].distance = (int)nudExit0.Value;
            }

            if (cboxExitFunc1.SelectedIndex == 0)
            {
                mf.seq.DisableSeqEvent(1, false);
            }
            else
            {
                mf.seq.seqExit[1].function = cboxExitFunc1.SelectedIndex;
                mf.seq.seqExit[1].action = cboxExitAction1.SelectedIndex;
                mf.seq.seqExit[1].isTrig = false;
                mf.seq.seqExit[1].distance = (int)nudExit1.Value;
            }

            if (cboxExitFunc2.SelectedIndex == 0)
            {
                mf.seq.DisableSeqEvent(2, false);
            }
            else
            {
                mf.seq.seqExit[2].function = cboxExitFunc2.SelectedIndex;
                mf.seq.seqExit[2].action = cboxExitAction2.SelectedIndex;
                mf.seq.seqExit[2].isTrig = false;
                mf.seq.seqExit[2].distance = (int)nudExit2.Value;
            }

            if (cboxExitFunc3.SelectedIndex == 0)
            {
                mf.seq.DisableSeqEvent(3, false);
            }
            else
            {
                mf.seq.seqExit[3].function = cboxExitFunc3.SelectedIndex;
                mf.seq.seqExit[3].action = cboxExitAction3.SelectedIndex;
                mf.seq.seqExit[3].isTrig = false;
                mf.seq.seqExit[3].distance = (int)nudExit3.Value;
            }

            if (cboxExitFunc4.SelectedIndex == 0)
            {
                mf.seq.DisableSeqEvent(4, false);
            }
            else
            {
                mf.seq.seqExit[4].function = cboxExitFunc4.SelectedIndex;
                mf.seq.seqExit[4].action = cboxExitAction4.SelectedIndex;
                mf.seq.seqExit[4].isTrig = false;
                mf.seq.seqExit[4].distance = (int)nudExit4.Value;
            }

            if (cboxExitFunc5.SelectedIndex == 0)
            {
                mf.seq.DisableSeqEvent(5, false);
            }
            else
            {
                mf.seq.seqExit[5].function = cboxExitFunc5.SelectedIndex;
                mf.seq.seqExit[5].action = cboxExitAction5.SelectedIndex;
                mf.seq.seqExit[5].isTrig = false;
                mf.seq.seqExit[5].distance = (int)nudExit5.Value;
            }

            if (cboxExitFunc6.SelectedIndex == 0)
            {
                mf.seq.DisableSeqEvent(6, false);
            }
            else
            {
                mf.seq.seqExit[6].function = cboxExitFunc6.SelectedIndex;
                mf.seq.seqExit[6].action = cboxExitAction6.SelectedIndex;
                mf.seq.seqExit[6].isTrig = false;
                mf.seq.seqExit[6].distance = (int)nudExit6.Value;
            }

            if (cboxExitFunc7.SelectedIndex == 0)
            {
                mf.seq.DisableSeqEvent(7, false);
            }
            else
            {
                mf.seq.seqExit[7].function = cboxExitFunc7.SelectedIndex;
                mf.seq.seqExit[7].action = cboxExitAction7.SelectedIndex;
                mf.seq.seqExit[7].isTrig = false;
                mf.seq.seqExit[7].distance = (int)nudExit7.Value;
            }
        }

        private void LoadComboStrings()
        {
            cboxEnterFunc0.Items.Add(mf.yt.pos1);
            cboxEnterFunc0.Items.Add(mf.yt.pos2);
            cboxEnterFunc0.Items.Add(mf.yt.pos3);
            cboxEnterFunc0.Items.Add(mf.yt.pos4);
            cboxEnterFunc0.Items.Add(mf.yt.pos5);
            cboxEnterFunc0.Items.Add(mf.yt.pos6);
            cboxEnterFunc0.Items.Add(mf.yt.pos7);
            cboxEnterFunc0.Items.Add(mf.yt.pos8);
            cboxExitFunc0.Items.Add(mf.yt.pos1);
            cboxExitFunc0.Items.Add(mf.yt.pos2);
            cboxExitFunc0.Items.Add(mf.yt.pos3);
            cboxExitFunc0.Items.Add(mf.yt.pos4);
            cboxExitFunc0.Items.Add(mf.yt.pos5);
            cboxExitFunc0.Items.Add(mf.yt.pos6);
            cboxExitFunc0.Items.Add(mf.yt.pos7);
            cboxExitFunc0.Items.Add(mf.yt.pos8);

            cboxEnterFunc1.Items.Add(mf.yt.pos1);
            cboxEnterFunc1.Items.Add(mf.yt.pos2);
            cboxEnterFunc1.Items.Add(mf.yt.pos3);
            cboxEnterFunc1.Items.Add(mf.yt.pos4);
            cboxEnterFunc1.Items.Add(mf.yt.pos5);
            cboxEnterFunc1.Items.Add(mf.yt.pos6);
            cboxEnterFunc1.Items.Add(mf.yt.pos7);
            cboxEnterFunc1.Items.Add(mf.yt.pos8);
            cboxExitFunc1.Items.Add(mf.yt.pos1);
            cboxExitFunc1.Items.Add(mf.yt.pos2);
            cboxExitFunc1.Items.Add(mf.yt.pos3);
            cboxExitFunc1.Items.Add(mf.yt.pos4);
            cboxExitFunc1.Items.Add(mf.yt.pos5);
            cboxExitFunc1.Items.Add(mf.yt.pos6);
            cboxExitFunc1.Items.Add(mf.yt.pos7);
            cboxExitFunc1.Items.Add(mf.yt.pos8);

            cboxEnterFunc2.Items.Add(mf.yt.pos1);
            cboxEnterFunc2.Items.Add(mf.yt.pos2);
            cboxEnterFunc2.Items.Add(mf.yt.pos3);
            cboxEnterFunc2.Items.Add(mf.yt.pos4);
            cboxEnterFunc2.Items.Add(mf.yt.pos5);
            cboxEnterFunc2.Items.Add(mf.yt.pos6);
            cboxEnterFunc2.Items.Add(mf.yt.pos7);
            cboxEnterFunc2.Items.Add(mf.yt.pos8);
            cboxExitFunc2.Items.Add(mf.yt.pos1);
            cboxExitFunc2.Items.Add(mf.yt.pos2);
            cboxExitFunc2.Items.Add(mf.yt.pos3);
            cboxExitFunc2.Items.Add(mf.yt.pos4);
            cboxExitFunc2.Items.Add(mf.yt.pos5);
            cboxExitFunc2.Items.Add(mf.yt.pos6);
            cboxExitFunc2.Items.Add(mf.yt.pos7);
            cboxExitFunc2.Items.Add(mf.yt.pos8);

            cboxEnterFunc3.Items.Add(mf.yt.pos1);
            cboxEnterFunc3.Items.Add(mf.yt.pos2);
            cboxEnterFunc3.Items.Add(mf.yt.pos3);
            cboxEnterFunc3.Items.Add(mf.yt.pos4);
            cboxEnterFunc3.Items.Add(mf.yt.pos5);
            cboxEnterFunc3.Items.Add(mf.yt.pos6);
            cboxEnterFunc3.Items.Add(mf.yt.pos7);
            cboxEnterFunc3.Items.Add(mf.yt.pos8);
            cboxExitFunc3.Items.Add(mf.yt.pos1);
            cboxExitFunc3.Items.Add(mf.yt.pos2);
            cboxExitFunc3.Items.Add(mf.yt.pos3);
            cboxExitFunc3.Items.Add(mf.yt.pos4);
            cboxExitFunc3.Items.Add(mf.yt.pos5);
            cboxExitFunc3.Items.Add(mf.yt.pos6);
            cboxExitFunc3.Items.Add(mf.yt.pos7);
            cboxExitFunc3.Items.Add(mf.yt.pos8);

            cboxEnterFunc4.Items.Add(mf.yt.pos1);
            cboxEnterFunc4.Items.Add(mf.yt.pos2);
            cboxEnterFunc4.Items.Add(mf.yt.pos3);
            cboxEnterFunc4.Items.Add(mf.yt.pos4);
            cboxEnterFunc4.Items.Add(mf.yt.pos5);
            cboxEnterFunc4.Items.Add(mf.yt.pos6);
            cboxEnterFunc4.Items.Add(mf.yt.pos7);
            cboxEnterFunc4.Items.Add(mf.yt.pos8);
            cboxExitFunc4.Items.Add(mf.yt.pos1);
            cboxExitFunc4.Items.Add(mf.yt.pos2);
            cboxExitFunc4.Items.Add(mf.yt.pos3);
            cboxExitFunc4.Items.Add(mf.yt.pos4);
            cboxExitFunc4.Items.Add(mf.yt.pos5);
            cboxExitFunc4.Items.Add(mf.yt.pos6);
            cboxExitFunc4.Items.Add(mf.yt.pos7);
            cboxExitFunc4.Items.Add(mf.yt.pos8);

            cboxEnterFunc5.Items.Add(mf.yt.pos1);
            cboxEnterFunc5.Items.Add(mf.yt.pos2);
            cboxEnterFunc5.Items.Add(mf.yt.pos3);
            cboxEnterFunc5.Items.Add(mf.yt.pos4);
            cboxEnterFunc5.Items.Add(mf.yt.pos5);
            cboxEnterFunc5.Items.Add(mf.yt.pos6);
            cboxEnterFunc5.Items.Add(mf.yt.pos7);
            cboxEnterFunc5.Items.Add(mf.yt.pos8);
            cboxExitFunc5.Items.Add(mf.yt.pos1);
            cboxExitFunc5.Items.Add(mf.yt.pos2);
            cboxExitFunc5.Items.Add(mf.yt.pos3);
            cboxExitFunc5.Items.Add(mf.yt.pos4);
            cboxExitFunc5.Items.Add(mf.yt.pos5);
            cboxExitFunc5.Items.Add(mf.yt.pos6);
            cboxExitFunc5.Items.Add(mf.yt.pos7);
            cboxExitFunc5.Items.Add(mf.yt.pos8);

            cboxEnterFunc6.Items.Add(mf.yt.pos1);
            cboxEnterFunc6.Items.Add(mf.yt.pos2);
            cboxEnterFunc6.Items.Add(mf.yt.pos3);
            cboxEnterFunc6.Items.Add(mf.yt.pos4);
            cboxEnterFunc6.Items.Add(mf.yt.pos5);
            cboxEnterFunc6.Items.Add(mf.yt.pos6);
            cboxEnterFunc6.Items.Add(mf.yt.pos7);
            cboxEnterFunc6.Items.Add(mf.yt.pos8);
            cboxExitFunc6.Items.Add(mf.yt.pos1);
            cboxExitFunc6.Items.Add(mf.yt.pos2);
            cboxExitFunc6.Items.Add(mf.yt.pos3);
            cboxExitFunc6.Items.Add(mf.yt.pos4);
            cboxExitFunc6.Items.Add(mf.yt.pos5);
            cboxExitFunc6.Items.Add(mf.yt.pos6);
            cboxExitFunc6.Items.Add(mf.yt.pos7);
            cboxExitFunc6.Items.Add(mf.yt.pos8);

            cboxEnterFunc7.Items.Add(mf.yt.pos1);
            cboxEnterFunc7.Items.Add(mf.yt.pos2);
            cboxEnterFunc7.Items.Add(mf.yt.pos3);
            cboxEnterFunc7.Items.Add(mf.yt.pos4);
            cboxEnterFunc7.Items.Add(mf.yt.pos5);
            cboxEnterFunc7.Items.Add(mf.yt.pos6);
            cboxEnterFunc7.Items.Add(mf.yt.pos7);
            cboxEnterFunc7.Items.Add(mf.yt.pos8);
            cboxExitFunc7.Items.Add(mf.yt.pos1);
            cboxExitFunc7.Items.Add(mf.yt.pos2);
            cboxExitFunc7.Items.Add(mf.yt.pos3);
            cboxExitFunc7.Items.Add(mf.yt.pos4);
            cboxExitFunc7.Items.Add(mf.yt.pos5);
            cboxExitFunc7.Items.Add(mf.yt.pos6);
            cboxExitFunc7.Items.Add(mf.yt.pos7);
            cboxExitFunc7.Items.Add(mf.yt.pos8);

        }

        private void LoadEditFunctionNames()
        {
            tboxPos1.Text = mf.yt.pos1;
            tboxPos2.Text = mf.yt.pos2;
            tboxPos3.Text = mf.yt.pos3;
            tboxPos4.Text = mf.yt.pos4;

            tboxPos5.Text = mf.yt.pos5;
            tboxPos6.Text = mf.yt.pos6;
            tboxPos7.Text = mf.yt.pos7;
            tboxPos8.Text = mf.yt.pos8;
        }

        #endregion Procedures

        #region YouTurn

        // YouTurn Tab
        private void btnDistanceDn_Click(object sender, EventArgs e)
        {
            if (mf.yt.youTurnStartOffset-- < -48) mf.yt.youTurnStartOffset = -49;
            lblDistance.Text = Math.Abs(mf.yt.youTurnStartOffset).ToString() + " m";
            if (mf.yt.youTurnStartOffset < 0) lblWhenTrig.Text = "Before";
            else lblWhenTrig.Text = "After";
        }

        private void btnDistanceUp_Click(object sender, EventArgs e)
        {
            if (mf.yt.youTurnStartOffset++ > 49) mf.yt.youTurnStartOffset = 50;
            lblDistance.Text = Math.Abs(mf.yt.youTurnStartOffset).ToString() + " m";
            if (mf.yt.youTurnStartOffset < 0) lblWhenTrig.Text = "Before";
            else lblWhenTrig.Text = "After";
        }

        private void btnYouTurnKeyHole_Click(object sender, EventArgs e)
        {
            mf.yt.LoadYouTurnShapeFromFile(@".\YouTurnShapes\KeyHole.txt");
            Properties.Settings.Default.setAS_youTurnShape = "KeyHole.txt";
            Properties.Settings.Default.Save();
            btnYouTurnKeyHole.BackColor = Color.Yellow;
            btnYouTurnSemiCircle.BackColor = Color.LimeGreen;
            btnYouTurnCustom.BackColor = Color.LimeGreen;
            btnYouTurnWideReturn.BackColor = Color.LimeGreen;
        }

        private void btnYouTurnSemiCircle_Click(object sender, EventArgs e)
        {
            mf.yt.LoadYouTurnShapeFromFile(@".\YouTurnShapes\SemiCircle.txt");
            Properties.Settings.Default.setAS_youTurnShape = "SemiCircle.txt";
            Properties.Settings.Default.Save();
            btnYouTurnKeyHole.BackColor = Color.LimeGreen;
            btnYouTurnSemiCircle.BackColor = Color.Yellow;
            btnYouTurnCustom.BackColor = Color.LimeGreen;
            btnYouTurnWideReturn.BackColor = Color.LimeGreen;
        }

        private void btnYouTurnWideReturn_Click(object sender, EventArgs e)
        {
            mf.yt.LoadYouTurnShapeFromFile(@".\YouTurnShapes\WideReturn.txt");
            Properties.Settings.Default.setAS_youTurnShape = "WideReturn.txt";
            Properties.Settings.Default.Save();
            btnYouTurnKeyHole.BackColor = Color.LimeGreen;
            btnYouTurnSemiCircle.BackColor = Color.LimeGreen;
            btnYouTurnCustom.BackColor = Color.LimeGreen;
            btnYouTurnWideReturn.BackColor = Color.Yellow;
        }

        private void btnYouTurnCustom_Click(object sender, EventArgs e)
        {
            mf.yt.LoadYouTurnShapeFromFile(@".\YouTurnShapes\Custom.txt");
            Properties.Settings.Default.setAS_youTurnShape = "Custom.txt";
            Properties.Settings.Default.Save();
            btnYouTurnKeyHole.BackColor = Color.LimeGreen;
            btnYouTurnSemiCircle.BackColor = Color.LimeGreen;
            btnYouTurnCustom.BackColor = Color.Yellow;
            btnYouTurnWideReturn.BackColor = Color.LimeGreen;
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

        private void cboxRowWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.yt.rowSkipsWidth = cboxRowWidth.SelectedIndex + 1;
        }

        private void cboxRowHeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.yt.rowSkipsHeight = cboxRowHeight.SelectedIndex + 1;
        }

        #endregion Youturn

        #region Sequence select
        private void cboxEnterFunc0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxEnterFunc0.SelectedIndex == 0)
            {
                cboxEnterAction0.SelectedIndex = -1;
                nudEnter0.Value = 0;
            }
        }
        private void cboxEnterFunc1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxEnterFunc1.SelectedIndex == 0)
            {
                cboxEnterAction1.SelectedIndex = -1;
                nudEnter1.Value = 0;
            }
        }
        private void cboxEnterFunc2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxEnterFunc2.SelectedIndex == 0)
            {
                cboxEnterAction2.SelectedIndex = -1;
                nudEnter2.Value = 0;
            }
        }
        private void cboxEnterFunc3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxEnterFunc3.SelectedIndex == 0)
            {
                cboxEnterAction3.SelectedIndex = -1;
                nudEnter3.Value = 0;
            }
        }
        private void cboxEnterFunc4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxEnterFunc4.SelectedIndex == 0)
            {
                cboxEnterAction4.SelectedIndex = -1;
                nudEnter4.Value = 0;
            }
        }
        private void cboxEnterFunc5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxEnterFunc5.SelectedIndex == 0)
            {
                cboxEnterAction5.SelectedIndex = -1;
                nudEnter5.Value = 0;
            }
        }
        private void cboxEnterFunc6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxEnterFunc6.SelectedIndex == 0)
            {
                cboxEnterAction6.SelectedIndex = -1;
                nudEnter6.Value = 0;
            }
        }
        private void cboxEnterFunc7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxEnterFunc7.SelectedIndex == 0)
            {
                cboxEnterAction7.SelectedIndex = -1;
                nudEnter7.Value = 0;
            }
        }

        private void cboxExitFunc0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxExitFunc0.SelectedIndex == 0)
            {
                cboxExitAction0.SelectedIndex = -1;
                nudExit0.Value = 0;
            }
        }
        private void cboxExitFunc1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxExitFunc1.SelectedIndex == 0)
            {
                cboxExitAction1.SelectedIndex = -1;
                nudExit1.Value = 0;
            }
        }
        private void cboxExitFunc2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxExitFunc2.SelectedIndex == 0)
            {
                cboxExitAction2.SelectedIndex = -1;
                nudExit2.Value = 0;
            }
        }
        private void cboxExitFunc3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxExitFunc3.SelectedIndex == 0)
            {
                cboxExitAction3.SelectedIndex = -1;
                nudExit3.Value = 0;
            }
        }
        private void cboxExitFunc4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxExitFunc4.SelectedIndex == 0)
            {
                cboxExitAction4.SelectedIndex = -1;
                nudExit4.Value = 0;
            }
        }
        private void cboxExitFunc5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxExitFunc5.SelectedIndex == 0)
            {
                cboxExitAction5.SelectedIndex = -1;
                nudExit5.Value = 0;
            }
        }
        private void cboxExitFunc6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxExitFunc6.SelectedIndex == 0)
            {
                cboxExitAction6.SelectedIndex = -1;
                nudExit6.Value = 0;
            }
        }
        private void cboxExitFunc7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxExitFunc7.SelectedIndex == 0)
            {
                cboxExitAction7.SelectedIndex = -1;
                nudExit7.Value = 0;
            }
        }
        #endregion Sequence select

        #region Edit names
        private void btnSaveNames_Click(object sender, EventArgs e)
        {
            //pos1 = tboxPos1.Text; pos2 = tboxPos2.Text; auto manual buttons are read only
            mf.yt.pos3 = tboxPos3.Text;
            mf.yt.pos4 = tboxPos4.Text;

            mf.yt.pos5 = tboxPos5.Text;
            mf.yt.pos6 = tboxPos6.Text;
            mf.yt.pos7 = tboxPos7.Text;
            mf.yt.pos8 = tboxPos8.Text;

            //clear everything out
            cboxEnterFunc0.Items.Clear();
            cboxEnterFunc1.Items.Clear();
            cboxEnterFunc2.Items.Clear();
            cboxEnterFunc3.Items.Clear();
            cboxEnterFunc4.Items.Clear();
            cboxEnterFunc5.Items.Clear();
            cboxEnterFunc6.Items.Clear();
            cboxEnterFunc7.Items.Clear();
            cboxExitFunc0.Items.Clear();
            cboxExitFunc1.Items.Clear();
            cboxExitFunc2.Items.Clear();
            cboxExitFunc3.Items.Clear();
            cboxExitFunc4.Items.Clear();
            cboxExitFunc5.Items.Clear();
            cboxExitFunc6.Items.Clear();
            cboxExitFunc7.Items.Clear();

            //add the dash, item 0
            cboxEnterFunc0.Items.Add("-");
            cboxEnterFunc1.Items.Add("-");
            cboxEnterFunc2.Items.Add("-");
            cboxEnterFunc3.Items.Add("-");
            cboxEnterFunc4.Items.Add("-");
            cboxEnterFunc5.Items.Add("-");
            cboxEnterFunc6.Items.Add("-");
            cboxEnterFunc7.Items.Add("-");
            cboxExitFunc0.Items.Add("-");
            cboxExitFunc1.Items.Add("-");
            cboxExitFunc2.Items.Add("-");
            cboxExitFunc3.Items.Add("-");
            cboxExitFunc4.Items.Add("-");
            cboxExitFunc5.Items.Add("-");
            cboxExitFunc6.Items.Add("-");
            cboxExitFunc7.Items.Add("-");

            //reload the comboboxes with updated strings
            LoadComboStrings();

            //populate boxes again with updated names
            PopulateSequencePages();

            //save in settings
            Properties.Vehicle.Default.seq_FunctionList = mf.yt.pos3 + "," + mf.yt.pos4 + "," + mf.yt.pos5 + "," + mf.yt.pos6 + "," + mf.yt.pos7 + "," + mf.yt.pos8;
            Properties.Vehicle.Default.Save();

            //reload buttons text
            btnToggle3.Text = mf.yt.pos3;
            btnToggle4.Text = mf.yt.pos4;
            btnToggle5.Text = mf.yt.pos5;
            btnToggle6.Text = mf.yt.pos6;
            btnToggle7.Text = mf.yt.pos7;
            btnToggle8.Text = mf.yt.pos8;

            //select entry tab page 1
            tabControl1.SelectTab(1);

            //flash that they have been saved
            mf.TimedMessageBox(1500, "Function Names", "Saved to Settings.....");

        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            //select entry tab page 1
            tabControl1.SelectTab(1);
        }

        private void tabEdit_Enter(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
            btnCancel.Enabled = false;

            //Fill in the strings for comboboxes - editable
            string line = Properties.Vehicle.Default.seq_FunctionList;
            string[] words = line.Split(',');

            mf.yt.pos3 = words[0];
            mf.yt.pos4 = words[1];
            mf.yt.pos5 = words[2];
            mf.yt.pos6 = words[3];
            mf.yt.pos7 = words[4];
            mf.yt.pos8 = words[5];

            //the edit page of text boxes
            LoadEditFunctionNames();
        }

        private void tabEdit_Leave(object sender, EventArgs e)
        {
            btnOK.Enabled = true;
            btnCancel.Enabled = true;
        }
        #endregion edit names

        //private void btnResetAll_Click(object sender, EventArgs e)
        //{
        //    mf.seq.ResetAllSequences();
        //    PopulateSequencePages();
        //    mf.mc.relayRateData[mf.mc.rdYouTurnControlByte] = 0;
        //}

        private void btnOK_Click(object sender, EventArgs e)
        {
            //save all the sequences and events
            SaveSequences();

            Properties.Vehicle.Default.set_youSkipHeight = mf.yt.rowSkipsHeight;
            Properties.Vehicle.Default.set_youSkipWidth = mf.yt.rowSkipsWidth;

            Properties.Vehicle.Default.set_youStartYouTurnAt = mf.yt.youTurnStartOffset;

            StringBuilder sbEntry = new StringBuilder();
            StringBuilder sbExit = new StringBuilder();

            //Sequence functions 0,0,0,0,0
            for (int i = 0; i < FormGPS.MAXFUNCTIONS - 1; i++)
            {
                sbEntry.Append(mf.seq.seqEnter[i].function.ToString());
                sbEntry.Append(",");
                sbExit.Append(mf.seq.seqExit[i].function.ToString());
                sbExit.Append(",");
            }
            sbEntry.Append(mf.seq.seqEnter[FormGPS.MAXFUNCTIONS - 1].function.ToString());
            sbExit.Append(mf.seq.seqExit[FormGPS.MAXFUNCTIONS - 1].function.ToString());

            Properties.Vehicle.Default.seq_FunctionEnter = sbEntry.ToString();
            Properties.Vehicle.Default.seq_FunctionExit = sbExit.ToString();
            sbEntry.Clear(); sbExit.Clear();

            //Sequence actions
            for (int i = 0; i < FormGPS.MAXFUNCTIONS - 1; i++)
            {
                sbEntry.Append(mf.seq.seqEnter[i].action.ToString());
                sbEntry.Append(",");
                sbExit.Append(mf.seq.seqExit[i].action.ToString());
                sbExit.Append(",");
            }
            sbEntry.Append(mf.seq.seqEnter[FormGPS.MAXFUNCTIONS - 1].action.ToString());
            sbExit.Append(mf.seq.seqExit[FormGPS.MAXFUNCTIONS - 1].action.ToString());

            Properties.Vehicle.Default.seq_ActionEnter = sbEntry.ToString();
            Properties.Vehicle.Default.seq_ActionExit = sbExit.ToString();
            sbEntry.Clear(); sbExit.Clear();

            //Sequence Distances
            for (int i = 0; i < FormGPS.MAXFUNCTIONS - 1; i++)
            {
                sbEntry.Append(mf.seq.seqEnter[i].distance.ToString());
                sbEntry.Append(",");
                sbExit.Append(mf.seq.seqExit[i].distance.ToString());
                sbExit.Append(",");
            }
            sbEntry.Append(mf.seq.seqEnter[FormGPS.MAXFUNCTIONS - 1].distance.ToString());
            sbExit.Append(mf.seq.seqExit[FormGPS.MAXFUNCTIONS - 1].distance.ToString());

            Properties.Vehicle.Default.seq_DistanceEnter = sbEntry.ToString();
            Properties.Vehicle.Default.seq_DistanceExit = sbExit.ToString();

            //save it all
            Properties.Vehicle.Default.Save();
            Close();
        }

        private void btnTurnAllOff_Click(object sender, EventArgs e)
        {
            mf.mc.relayRateData[mf.mc.rdYouTurnControlByte] = 0;
            FunctionButtonsOnOff();
        }

        bool IsBitSet(byte b, int pos)
        {
            return (b & (1 << pos)) != 0;
        }

        private void btnToggle3_Click(object sender, EventArgs e)
        {
            if ( IsBitSet(mf.mc.relayRateData[mf.mc.rdYouTurnControlByte],0))
                mf.mc.relayRateData[mf.mc.rdYouTurnControlByte] &= 0b11111110;

            else mf.mc.relayRateData[mf.mc.rdYouTurnControlByte]|= 0b00000001;
            FunctionButtonsOnOff();
        }

        private void btnToggle4_Click(object sender, EventArgs e)
        {
            if (IsBitSet(mf.mc.relayRateData[mf.mc.rdYouTurnControlByte], 1))
                mf.mc.relayRateData[mf.mc.rdYouTurnControlByte] &= 0b11111101;

            else mf.mc.relayRateData[mf.mc.rdYouTurnControlByte] |= 0b00000010;
            FunctionButtonsOnOff();
        }

        private void btnToggle5_Click(object sender, EventArgs e)
        {
            if (IsBitSet(mf.mc.relayRateData[mf.mc.rdYouTurnControlByte], 2))
                mf.mc.relayRateData[mf.mc.rdYouTurnControlByte] &= 0b11111011;

            else mf.mc.relayRateData[mf.mc.rdYouTurnControlByte] |= 0b00000100;
            FunctionButtonsOnOff();
        }

        private void btnToggle6_Click(object sender, EventArgs e)
        {
            if (IsBitSet(mf.mc.relayRateData[mf.mc.rdYouTurnControlByte], 3))
                mf.mc.relayRateData[mf.mc.rdYouTurnControlByte] &= 0b11110111;

            else mf.mc.relayRateData[mf.mc.rdYouTurnControlByte] |= 0b00001000;
            FunctionButtonsOnOff();
        }

        private void btnToggle7_Click(object sender, EventArgs e)
        {
            if (IsBitSet(mf.mc.relayRateData[mf.mc.rdYouTurnControlByte], 4))
                mf.mc.relayRateData[mf.mc.rdYouTurnControlByte] &= 0b11101111;

            else mf.mc.relayRateData[mf.mc.rdYouTurnControlByte] |= 0b00010000;
            FunctionButtonsOnOff();
        }

        private void btnToggle8_Click(object sender, EventArgs e)
        {
            if (IsBitSet(mf.mc.relayRateData[mf.mc.rdYouTurnControlByte], 5))
                mf.mc.relayRateData[mf.mc.rdYouTurnControlByte] &= 0b11011111;

            else mf.mc.relayRateData[mf.mc.rdYouTurnControlByte] |= 0b00100000;
            FunctionButtonsOnOff();
        }

        private void FunctionButtonsOnOff()
        {
            if (IsBitSet(mf.mc.relayRateData[mf.mc.rdYouTurnControlByte], 0)) btnToggle3.BackColor = Color.LightGreen;
            else btnToggle3.BackColor = Color.LightSalmon;

            if (IsBitSet(mf.mc.relayRateData[mf.mc.rdYouTurnControlByte], 1)) btnToggle4.BackColor = Color.LightGreen;
            else btnToggle4.BackColor = Color.LightSalmon;

            if (IsBitSet(mf.mc.relayRateData[mf.mc.rdYouTurnControlByte], 2)) btnToggle5.BackColor = Color.LightGreen;
            else btnToggle5.BackColor = Color.LightSalmon;

            if (IsBitSet(mf.mc.relayRateData[mf.mc.rdYouTurnControlByte], 3)) btnToggle6.BackColor = Color.LightGreen;
            else btnToggle6.BackColor = Color.LightSalmon;

            if (IsBitSet(mf.mc.relayRateData[mf.mc.rdYouTurnControlByte], 4)) btnToggle7.BackColor = Color.LightGreen;
            else btnToggle7.BackColor = Color.LightSalmon;

            if (IsBitSet(mf.mc.relayRateData[mf.mc.rdYouTurnControlByte], 5)) btnToggle8.BackColor = Color.LightGreen;
            else btnToggle8.BackColor = Color.LightSalmon;
        }
    }
}
