using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormConfig
    {

        #region Module Steer
        private void tabASteer_Enter(object sender, EventArgs e)
        {
            nudMaxCounts.Controls[0].Enabled = false;

            int sett = Properties.Vehicle.Default.setArdSteer_setting0;

            if ((sett & 1) == 0) chkInvertWAS.Checked = false;
            else chkInvertWAS.Checked = true;

            if ((sett & 2) == 0) chkSteerInvertRelays.Checked = false;
            else chkSteerInvertRelays.Checked = true;

            if ((sett & 4) == 0) chkInvertSteer.Checked = false;
            else chkInvertSteer.Checked = true;

            if ((sett & 8) == 0) cboxConv.Text = "Differential";
            else cboxConv.Text = "Single";

            if ((sett & 16) == 0) cboxMotorDrive.Text = "IBT2";
            else cboxMotorDrive.Text = "Cytron";

            if ((sett & 32) == 32) cboxSteerEnable.Text = "Switch";
            else if ((sett & 64) == 64) cboxSteerEnable.Text = "Button";
            else cboxSteerEnable.Text = "None";

            if ((sett & 128) == 0) cboxEncoder.Checked = false;
            else cboxEncoder.Checked = true;

            nudMaxCounts.Value = (decimal)Properties.Vehicle.Default.setArdSteer_maxPulseCounts;

            sett = Properties.Vehicle.Default.setArdSteer_setting1;

            if ((sett & 1) == 0) cboxDanfoss.Checked = false;
            else cboxDanfoss.Checked = true;

            if ((sett & 2) == 0) cboxPressureSensor.Checked = false;
            else cboxPressureSensor.Checked = true;

            if ((sett & 4) == 0) cboxCurrentSensor.Checked = false;
            else cboxCurrentSensor.Checked = true;

            if (cboxEncoder.Checked)
            {
                cboxPressureSensor.Checked = false;
                cboxCurrentSensor.Checked = false;
                label61.Visible = true;
                nudMaxCounts.Visible = true;

                label61.Text = gStr.gsEncoderCounts;
            }
            else if (cboxPressureSensor.Checked)
            {
                cboxEncoder.Checked = false;
                cboxCurrentSensor.Checked = false;
                label61.Visible = true;
                nudMaxCounts.Visible = true;

                label61.Text = gStr.gsPressureSensorValueLabel;
            }
            else if (cboxCurrentSensor.Checked)
            {
                cboxPressureSensor.Checked = false;
                cboxEncoder.Checked = false;
                label61.Visible = true;
                nudMaxCounts.Visible = true;

                label61.Text = gStr.gsCurrentSensorValueLabel;
            }
            else
            {
                cboxPressureSensor.Checked = false;
                cboxCurrentSensor.Checked = false;
                cboxEncoder.Checked = false;
                label61.Visible = false;
                nudMaxCounts.Visible = false;
            }
        }

        private void tabASteer_Leave(object sender, EventArgs e)
        {
            pboxSendSteer.Visible = false;
        }

        private void btnSendToSteerArduino_Click(object sender, EventArgs e)
        {
            SaveSettings();
            mf.SendPgnToLoop(mf.p_251.pgn);
            pboxSendSteer.Visible = false;

            mf.TimedMessageBox(1000, gStr.gsAutoSteerPort, "Settings Sent To Steer Module");
        }

        private void nudMaxCounts_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                pboxSendSteer.Visible = true;
            }
        }

        private void EnableAlert_Click(object sender, EventArgs e)
        {
            pboxSendSteer.Visible = true;

            if (sender is CheckBox)
            {
                var checkbox = (CheckBox)sender;

                if (!checkbox.Checked)
                {
                    cboxPressureSensor.Checked = false;
                    cboxCurrentSensor.Checked = false;
                    cboxEncoder.Checked = false;
                    label61.Visible = false;
                    nudMaxCounts.Visible = false;
                    return;
                }

                if (checkbox == cboxPressureSensor)
                {
                    cboxEncoder.Checked = false;
                    cboxCurrentSensor.Checked = false;
                    label61.Visible = true;
                    nudMaxCounts.Visible = true;
                    label61.Text = gStr.gsPressureSensorValueLabel;
                }

                else if (checkbox == cboxCurrentSensor)
                {
                    cboxPressureSensor.Checked = false;
                    cboxEncoder.Checked = false;
                    label61.Visible = true;
                    nudMaxCounts.Visible = true;
                    label61.Text = gStr.gsCurrentSensorValueLabel;
                }
                else if (checkbox == cboxEncoder)
                {
                    cboxPressureSensor.Checked = false;
                    cboxCurrentSensor.Checked = false;
                    label61.Visible = true;
                    nudMaxCounts.Visible = true;

                    label61.Text = gStr.gsEncoderCounts;
                }
            }
        }     
        
        private void SaveSettings()
        {

            int set = 1;
            int reset = 2046;
            int sett = 0;

            if (chkInvertWAS.Checked) sett |= set;
            else sett &= reset;

            set <<= 1;
            reset <<= 1;
            reset += 1;
            if (chkSteerInvertRelays.Checked) sett |= set;
            else sett &= reset;

            set <<= 1;
            reset <<= 1;
            reset += 1;
            if (chkInvertSteer.Checked) sett |= set;
            else sett &= reset;

            set <<= 1;
            reset <<= 1;
            reset += 1;
            if (cboxConv.Text == "Single") sett |= set;
            else sett &= reset;

            set <<= 1;
            reset <<= 1;
            reset += 1;
            if (cboxMotorDrive.Text == "Cytron") sett |= set;
            else sett &= reset;

            set <<= 1;
            reset <<= 1;
            reset += 1;
            if (cboxSteerEnable.Text == "Switch") sett |= set;
            else sett &= reset;

            set <<= 1;
            reset <<= 1;
            reset += 1;
            if (cboxSteerEnable.Text == "Button") sett |= set;
            else sett &= reset;

            set <<= 1;
            reset <<= 1;
            reset += 1;
            if (cboxEncoder.Checked) sett |= set;
            else sett &= reset;

            //set = (set << 1);
            //reset = (reset << 1);
            //reset = (reset + 1);
            //if ( ) sett |= set;
            //else sett &= reset;

            Properties.Vehicle.Default.setArdSteer_setting0 = (byte)sett;
            Properties.Vehicle.Default.setArdSteer_maxPulseCounts = (byte)nudMaxCounts.Value;
            Properties.Vehicle.Default.setArdMac_isDanfoss = cboxDanfoss.Checked;

            // Settings1
            set = 1;
            reset = 2046;
            sett = 0;

            if (cboxDanfoss.Checked) sett |= set;
            else sett &= reset;

            set <<= 1;
            reset <<= 1;
            reset += 1;
            if (cboxPressureSensor.Checked) sett |= set;
            else sett &= reset;

            set <<= 1;
            reset <<= 1;
            reset += 1;
            if (cboxCurrentSensor.Checked) sett |= set;
            else sett &= reset;

            Properties.Vehicle.Default.setArdSteer_setting1 = (byte)sett;

            Properties.Vehicle.Default.Save();

            mf.p_251.pgn[mf.p_251.set0] = Properties.Vehicle.Default.setArdSteer_setting0;
            mf.p_251.pgn[mf.p_251.set1] = Properties.Vehicle.Default.setArdSteer_setting1;
            mf.p_251.pgn[mf.p_251.maxPulse] = Properties.Vehicle.Default.setArdSteer_maxPulseCounts;
            mf.p_251.pgn[mf.p_251.minSpeed] = 5; //0.5 kmh

            if (Properties.Settings.Default.setAS_isAngVelGuidance)
                mf.p_251.pgn[mf.p_251.angVel] = 1;
            else mf.p_251.pgn[mf.p_251.angVel] = 0;

            pboxSendSteer.Visible = false;
        }

        #endregion
        private void Enable_AlertM_Click(object sender, EventArgs e)
        {
            pboxSendMachine.Visible = true;
        }

        #region Module MAchine

        private void tabAMachine_Enter(object sender, EventArgs e)
        {

            int sett = Properties.Vehicle.Default.setArdMac_setting0;

            if ((sett & 1) == 0) cboxMachInvertRelays.Checked = false;
            else cboxMachInvertRelays.Checked = true;

            if ((sett & 2) == 0) cboxIsHydOn.Checked = false;
            else cboxIsHydOn.Checked = true;

            if (cboxIsHydOn.Checked)
            {
                cboxIsHydOn.Image = Properties.Resources.SwitchOn;
                nudHydLiftLookAhead.Enabled = true;
                nudLowerTime.Enabled = true;
                nudRaiseTime.Enabled = true;
            }
            else
            {
                cboxIsHydOn.Image = Properties.Resources.SwitchOff;
                nudHydLiftLookAhead.Enabled = false;
                nudLowerTime.Enabled = false;
                nudRaiseTime.Enabled = false;
            }

            nudRaiseTime.Value = (decimal)Properties.Vehicle.Default.setArdMac_hydRaiseTime;
            nudLowerTime.Value = (decimal)Properties.Vehicle.Default.setArdMac_hydLowerTime;
            btnSendMachinePGN.Focus();

            nudHydLiftLookAhead.Value = (decimal)Properties.Vehicle.Default.setVehicle_hydraulicLiftLookAhead;
        }
        private void tabAMachine_Leave(object sender, EventArgs e)
        {
            pboxSendMachine.Visible = false;
        }

        private void nudHydLiftSecs_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                pboxSendMachine.Visible = true;
            }
        }

        private void nudRaiseTime_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                pboxSendMachine.Visible = true;
            }
        }

        private void nudLowerTime_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                pboxSendMachine.Visible = true;
            }
        }

        private void cboxIsHydOn_CheckStateChanged(object sender, EventArgs e)
        {
            if (cboxIsHydOn.Checked)
            {
                cboxIsHydOn.Image = Properties.Resources.SwitchOn;
                nudHydLiftLookAhead.Enabled = true;
                nudLowerTime.Enabled = true;
                nudRaiseTime.Enabled = true;
            }
            else
            {
                cboxIsHydOn.Image = Properties.Resources.SwitchOff;
                nudHydLiftLookAhead.Enabled = false;
                nudLowerTime.Enabled = false;
                nudRaiseTime.Enabled = false;
            }
            //pboxSendMachine.Visible = true;
        }

        private void SaveSettingsMachine()
        {
            int set = 1;
            int reset = 2046;
            int sett = 0;

            if (cboxMachInvertRelays.Checked) sett |= set;
            else sett &= reset;

            set <<= 1;
            reset <<= 1;
            reset += 1;
            if (cboxIsHydOn.Checked) sett |= set;
            else sett &= reset;

            Properties.Vehicle.Default.setArdMac_setting0 = (byte)sett;
            Properties.Vehicle.Default.setArdMac_hydRaiseTime = (byte)nudRaiseTime.Value;
            Properties.Vehicle.Default.setArdMac_hydLowerTime = (byte)nudLowerTime.Value;

            mf.p_238.pgn[mf.p_238.set0] = (byte)sett;
            mf.p_238.pgn[mf.p_238.raiseTime] = (byte)nudRaiseTime.Value;
            mf.p_238.pgn[mf.p_238.lowerTime] = (byte)nudLowerTime.Value;

            mf.SendPgnToLoop(mf.p_238.pgn);
            pboxSendMachine.Visible = false;
        }

        private void btnSendMachinePGN_Click(object sender, EventArgs e)
        {
            SaveSettingsMachine();

            mf.TimedMessageBox(1000, gStr.gsMachinePort, gStr.gsSentToMachineModule);

            pboxSendMachine.Visible = false;
        }

        #endregion

        #region Uturn Enter-Leave

        private void tabUTurn_Enter(object sender, EventArgs e)
        {
            UpdateUturnText();

            lblSmoothing.Text = mf.yt.uTurnSmoothing.ToString();

            double bob = Properties.Vehicle.Default.set_youTurnDistanceFromBoundary * mf.m2FtOrM;
            if (bob < 0.2) bob = 0.2;
            nudTurnDistanceFromBoundary.Value = (decimal)(Math.Round(bob, 2));

            lblFtMUTurn.Text = mf.unitsFtM;
        }

        private void tabUTurn_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.setAS_uTurnSmoothing = mf.yt.uTurnSmoothing;
            Properties.Vehicle.Default.set_youTurnExtensionLength = mf.yt.youTurnStartOffset;

            Properties.Settings.Default.Save();
            Properties.Vehicle.Default.Save();

            mf.bnd.BuildTurnLines();
            mf.yt.ResetCreatedYouTurn();
        }

        #endregion

        #region Uturn controls
        private void UpdateUturnText()
        {
            if (mf.isMetric)
            {
                lblDistance.Text = Math.Abs(mf.yt.youTurnStartOffset).ToString() + " m";
            }
            else
            {
                lblDistance.Text = Math.Abs((int)(mf.yt.youTurnStartOffset * glm.m2ft)).ToString() + " ft";
            }
        }

        private void nudTurnDistanceFromBoundary_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                mf.yt.uturnDistanceFromBoundary = (double)nudTurnDistanceFromBoundary.Value * mf.ftOrMtoM;
                Properties.Vehicle.Default.set_youTurnDistanceFromBoundary = mf.yt.uturnDistanceFromBoundary;
            }
        }

        private void btnTriggerDistanceDn_Click(object sender, EventArgs e)
        {
            mf.yt.uturnDistanceFromBoundary--;
            if (mf.yt.uturnDistanceFromBoundary < 0.1) mf.yt.uturnDistanceFromBoundary = 0.1;
            UpdateUturnText();
        }

        private void btnTriggerDistanceUp_Click(object sender, EventArgs e)
        {
            if (mf.yt.uturnDistanceFromBoundary++ > 50) mf.yt.uturnDistanceFromBoundary = 50;
            UpdateUturnText();
        }

        private void btnDistanceDn_Click(object sender, EventArgs e)
        {
            if (mf.yt.youTurnStartOffset-- < 4) mf.yt.youTurnStartOffset = 3;
            UpdateUturnText();
        }

        private void btnDistanceUp_Click(object sender, EventArgs e)
        {
            if (mf.yt.youTurnStartOffset++ > 49) mf.yt.youTurnStartOffset = 50;
            UpdateUturnText();
        }
        private void btnTurnSmoothingDown_Click(object sender, EventArgs e)
        {
            mf.yt.uTurnSmoothing -= 2;
            if (mf.yt.uTurnSmoothing < 4) mf.yt.uTurnSmoothing = 4;
            lblSmoothing.Text = mf.yt.uTurnSmoothing.ToString();
        }

        private void btnTurnSmoothingUp_Click(object sender, EventArgs e)
        {
            mf.yt.uTurnSmoothing += 2;
            if (mf.yt.uTurnSmoothing > 18) mf.yt.uTurnSmoothing = 18;
            lblSmoothing.Text = mf.yt.uTurnSmoothing.ToString();
        }

        #endregion

        #region Tram
        private void tabTram_Enter(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.setTool_isTramOuter)
            {
                rbtnTramOuter.Checked = true;
                rbtnTramInner.Checked = false;
            }
            else
            {
                rbtnTramOuter.Checked = false;
                rbtnTramInner.Checked = true;
            }
            lblTramWidthUnits.Text = mf.unitsInCm;

            nudTramWidth.Value = (int)(Math.Abs(Properties.Settings.Default.setTram_tramWidth) * mf.m2InchOrCm);

            cboxTramOnBackBuffer.Checked = Properties.Settings.Default.setTram_isTramOnBackBuffer;
        }

        private void tabTram_Leave(object sender, EventArgs e)
        {
            if (rbtnTramOuter.Checked) Properties.Settings.Default.setTool_isTramOuter = true;
            else Properties.Settings.Default.setTool_isTramOuter = false;

            if (cboxTramOnBackBuffer.Checked) Properties.Settings.Default.setTram_isTramOnBackBuffer = true;
            else Properties.Settings.Default.setTram_isTramOnBackBuffer = false;
            mf.isTramOnBackBuffer = Properties.Settings.Default.setTram_isTramOnBackBuffer;

            mf.tram.isOuter = Properties.Settings.Default.setTool_isTramOuter;

            Properties.Settings.Default.Save();
            
        }
        private void nudTramWidth_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                mf.tram.tramWidth = (double)nudTramWidth.Value * mf.inchOrCm2m;
                Properties.Settings.Default.setTram_tramWidth = mf.tram.tramWidth;
            }
        }

        #endregion

    }
}
