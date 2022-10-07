using System;
using System.Drawing;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormSteerWiz : Form
    {
        private readonly FormGPS mf = null;

        private bool toSend252 = false, toSend251 = false, isSA = false;
        private int counter252 = 0, counter251 = 0, cntr;
        private vec3 startFix;
        private double diameter, steerAngleRight, dist;
        private bool isWizardStarted = false;
        private double ackermannLeft = 1, ackermannRight = 1;

        //Form stuff
        public FormSteerWiz(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
            nudMaxCounts.Controls[0].Enabled = false;
            nudPanicStopSpeed.Controls[0].Enabled = false;

            this.label3.Text = gStr.gsAgressiveness;
            this.label5.Text = gStr.gsOvershootReduction;
            this.Text = gStr.gsAutoSteerConfiguration;
            //this.Width = 378;
            //this.Height = 462;

        }

        private void FormSteer_Load(object sender, EventArgs e)
        {
            tabWiz.Appearance = TabAppearance.FlatButtons;
            tabWiz.ItemSize = new Size(0, 1);
            tabWiz.SizeMode = TabSizeMode.Fixed;

            pbarProgress.Maximum = tabWiz.TabCount - 1;

            hsbarWasOffset.Value = Properties.Settings.Default.setAS_wasOffset;
            hsbarCountsPerDegree.Value = Properties.Settings.Default.setAS_countsPerDegree;

            lblCountsPerDegree.Text = hsbarCountsPerDegree.Value.ToString();
            lblSteerAngleSensorZero.Text = (hsbarWasOffset.Value / (double)(hsbarCountsPerDegree.Value)).ToString("N2");

            hsbarAckerman.Value = Properties.Settings.Default.setAS_ackerman;
            lblAckerman.Text = hsbarAckerman.Value.ToString();

            //min pwm, kP
            hsbarMinPWM.Value = Properties.Settings.Default.setAS_minSteerPWM;
            lblMinPWM.Text = hsbarMinPWM.Value.ToString();

            hsbarProportionalGain.Value = Properties.Settings.Default.setAS_Kp;
            lblProportionalGain.Text = hsbarProportionalGain.Value.ToString();

            //low steer, high steer
            hsbarLowSteerPWM.Value = Properties.Settings.Default.setAS_lowSteerPWM;
            lblLowSteerPWM.Text = hsbarLowSteerPWM.Value.ToString();

            hsbarHighSteerPWM.Value = Properties.Settings.Default.setAS_highSteerPWM;
            lblHighSteerPWM.Text = hsbarHighSteerPWM.Value.ToString();

            hsbarMaxSteerAngle.Value = (Int16)Properties.Vehicle.Default.setVehicle_maxSteerAngle;
            lblMaxSteerAngle.Text = hsbarMaxSteerAngle.Value.ToString();

            mf.vehicle.stanleyDistanceErrorGain = Properties.Vehicle.Default.stanleyDistanceErrorGain;
            hsbarStanleyGain.Value = (Int16)(mf.vehicle.stanleyDistanceErrorGain * 10);
            lblStanleyGain.Text = mf.vehicle.stanleyDistanceErrorGain.ToString();

            mf.vehicle.stanleyHeadingErrorGain = Properties.Vehicle.Default.stanleyHeadingErrorGain;
            hsbarHeadingErrorGain.Value = (Int16)(mf.vehicle.stanleyHeadingErrorGain * 10);
            lblHeadingErrorGain.Text = mf.vehicle.stanleyHeadingErrorGain.ToString();

            hsbarIntegral.Value = (int)(Properties.Vehicle.Default.stanleyIntegralGainAB * 100);
            lblIntegralPercent.Text = ((int)(mf.vehicle.stanleyIntegralGainAB * 100)).ToString();

            hsbarIntegralPurePursuit.Value = (int)(Properties.Vehicle.Default.purePursuitIntegralGainAB * 100);
            lblPureIntegral.Text = ((int)(mf.vehicle.purePursuitIntegralGain * 100)).ToString();

            hsbarSideHillComp.Value = (int)(Properties.Settings.Default.setAS_sideHillComp * 100);
            mf.gyd.sideHillCompFactor = Properties.Settings.Default.setAS_sideHillComp;

            mf.vehicle.goalPointLookAhead = Properties.Vehicle.Default.setVehicle_goalPointLookAhead;
            hsbarLookAhead.Value = (Int16)(mf.vehicle.goalPointLookAhead * 10);
            lblLookAhead.Text = mf.vehicle.goalPointLookAhead.ToString();

            mf.vehicle.goalPointLookAheadMult = Properties.Vehicle.Default.setVehicle_goalPointLookAheadMult;
            hsbarLookAheadMult.Value = (Int16)(mf.vehicle.goalPointLookAheadMult * 10);
            lblLookAheadMult.Text = mf.vehicle.goalPointLookAheadMult.ToString();

            //make sure free drive is off
            btnFreeDrive.Image = Properties.Resources.SteerDriveOff;
            mf.vehicle.ast.isInFreeDriveMode = false;
            btnSteerAngleDown.Enabled = false;
            btnSteerAngleUp.Enabled = false;
            btnFreeDriveZero.Enabled = false;
            //hSBarFreeDrive.Value = 0;
            mf.vehicle.ast.driveFreeSteerAngle = 0;

            nudPanicStopSpeed.Value = (decimal)mf.vehicle.panicStopSpeed;

            toSend252 = false;
            toSend251 = false;

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
            hsbarSensor.Value = (int)Properties.Vehicle.Default.setArdSteer_maxPulseCounts;
            lblhsbarSensor.Text = ((int)((double)hsbarSensor.Value * 0.3921568627)).ToString() + "%";

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
                lblPercentFS.Visible = true;
                nudMaxCounts.Visible = true;
                pbarSensor.Visible = false;
                hsbarSensor.Visible = false;
                lblhsbarSensor.Visible = false;
                label61.Text = gStr.gsEncoderCounts;
            }
            else if (cboxPressureSensor.Checked)
            {
                cboxEncoder.Checked = false;
                cboxCurrentSensor.Checked = false;
                label61.Visible = true;
                lblPercentFS.Visible = true;
                nudMaxCounts.Visible = false;
                pbarSensor.Visible = true;
                hsbarSensor.Visible = true;
                lblhsbarSensor.Visible = true;

                label61.Text = "Off at %";
            }
            else if (cboxCurrentSensor.Checked)
            {
                cboxPressureSensor.Checked = false;
                cboxEncoder.Checked = false;
                label61.Visible = true;
                lblPercentFS.Visible = true;
                nudMaxCounts.Visible = false;
                pbarSensor.Visible = true;
                hsbarSensor.Visible = true;
                lblhsbarSensor.Visible = true;

                label61.Text = "Off at %";
            }
            else
            {
                cboxPressureSensor.Checked = false;
                cboxCurrentSensor.Checked = false;
                cboxEncoder.Checked = false;
                label61.Visible = false;
                lblPercentFS.Visible = false;
                nudMaxCounts.Visible = false;
                pbarSensor.Visible = false;
                hsbarSensor.Visible = false;
                lblhsbarSensor.Visible = false;
                return;
            }
        }

        private void FormSteer_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.vehicle.ast.isInFreeDriveMode = false;

            Properties.Vehicle.Default.stanleyHeadingErrorGain = mf.vehicle.stanleyHeadingErrorGain;
            Properties.Vehicle.Default.stanleyDistanceErrorGain = mf.vehicle.stanleyDistanceErrorGain;
            Properties.Vehicle.Default.stanleyIntegralGainAB = mf.vehicle.stanleyIntegralGainAB;

            Properties.Vehicle.Default.purePursuitIntegralGainAB = mf.vehicle.purePursuitIntegralGain;
            Properties.Vehicle.Default.setVehicle_goalPointLookAhead = mf.vehicle.goalPointLookAhead;
            Properties.Vehicle.Default.setVehicle_goalPointLookAheadMult = mf.vehicle.goalPointLookAheadMult;

            Properties.Vehicle.Default.setVehicle_maxSteerAngle = mf.vehicle.maxSteerAngle;

            Properties.Settings.Default.setAS_countsPerDegree = mf.p_252.pgn[mf.p_252.countsPerDegree] = unchecked((byte)hsbarCountsPerDegree.Value);
            Properties.Settings.Default.setAS_ackerman = mf.p_252.pgn[mf.p_252.ackerman] = unchecked((byte)hsbarAckerman.Value);

            Properties.Settings.Default.setAS_wasOffset = hsbarWasOffset.Value;
            mf.p_252.pgn[mf.p_252.wasOffsetHi] = unchecked((byte)(hsbarWasOffset.Value >> 8));
            mf.p_252.pgn[mf.p_252.wasOffsetLo] = unchecked((byte)(hsbarWasOffset.Value));

            Properties.Settings.Default.setAS_highSteerPWM = mf.p_252.pgn[mf.p_252.highPWM] = unchecked((byte)hsbarHighSteerPWM.Value);
            Properties.Settings.Default.setAS_lowSteerPWM = mf.p_252.pgn[mf.p_252.lowPWM] = unchecked((byte)hsbarLowSteerPWM.Value);
            Properties.Settings.Default.setAS_Kp = mf.p_252.pgn[mf.p_252.gainProportional] = unchecked((byte)hsbarProportionalGain.Value);
            Properties.Settings.Default.setAS_minSteerPWM = mf.p_252.pgn[mf.p_252.minPWM] = unchecked((byte)hsbarMinPWM.Value);

            Properties.Vehicle.Default.setVehicle_panicStopSpeed = mf.vehicle.panicStopSpeed;
            hsbarSideHillComp.Value = (int)(Properties.Settings.Default.setAS_sideHillComp * 100);

            Properties.Settings.Default.Save();
            Properties.Vehicle.Default.Save();

            //save current vehicle
            SettingsIO.ExportAll(mf.vehiclesDirectory + mf.vehicleFileName + ".XML");
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

            if (isSA)
            {
                dist = glm.Distance(startFix, mf.pivotAxlePos);
                cntr++;
                if (dist > diameter)
                {
                    diameter = dist;
                    cntr = 0;
                }
                lblDiameter.Text = diameter.ToString("N2") + " m";

                if (cntr > 9)
                {
                    steerAngleRight = Math.Atan(mf.vehicle.wheelbase / (diameter / 2));
                    steerAngleRight = glm.toDegrees(steerAngleRight);

                    lblCalcSteerAngleInner.Text = steerAngleRight.ToString("N1") + "\u00B0";
                    lblDiameter.Text = diameter.ToString("N2") + " m";
                    btnStartSA.Image = Properties.Resources.BoundaryRecord;
                    isSA = false;

                    try
                    {
                        hsbarCountsPerDegree.Value = (int)(mf.mc.actualSteerAngleDegrees / steerAngleRight * hsbarCountsPerDegree.Value);
                    }
                    catch (Exception)
                    {
                        hsbarCountsPerDegree.Value = 100;
                        lblCPDError.Text = "Error, CPD set to 100";
                    }
                }
            }

            //steering bar
            double actAng = mf.mc.actualSteerAngleDegrees;
            if (actAng > 0)
            {
                if (actAng > 49) actAng = 49;
                CExtensionMethods.SetProgressNoAnimation(pbarRight, (int)actAng);
                pbarLeft.Value = 0;
            }
            else
            {
                if (actAng < -49) actAng = -49;
                pbarRight.Value = 0;
                CExtensionMethods.SetProgressNoAnimation(pbarLeft, (int)-actAng);
            }

            //wizard progress bar
            CExtensionMethods.SetProgressNoAnimation(pbarProgress, tabWiz.SelectedIndex);

            lblSteerAngle.Text = mf.SetSteerAngle;
            lblSteerAngleActual.Text = mf.mc.actualSteerAngleDegrees.ToString("N1") + "\u00B0";
            //lblActualSteerAngleUpper.Text = lblSteerAngleActual.Text;
            double err = (mf.mc.actualSteerAngleDegrees - mf.guidanceLineSteerAngle * 0.01);
            lblError.Text = Math.Abs(err).ToString("N1") + "\u00B0";
            if (err > 0) lblError.ForeColor = Color.Red;
            else lblError.ForeColor = Color.DarkGreen;

            lblPWMDisplay.Text = mf.mc.pwmDisplay.ToString();
            counter252++;
            counter251++;

            if (toSend252 && counter252 > 4)
            {
                Properties.Settings.Default.setAS_countsPerDegree = mf.p_252.pgn[mf.p_252.countsPerDegree] = unchecked((byte)hsbarCountsPerDegree.Value);
                Properties.Settings.Default.setAS_ackerman = mf.p_252.pgn[mf.p_252.ackerman] = unchecked((byte)hsbarAckerman.Value);

                Properties.Settings.Default.setAS_wasOffset = hsbarWasOffset.Value;
                mf.p_252.pgn[mf.p_252.wasOffsetHi] = unchecked((byte)(hsbarWasOffset.Value >> 8));
                mf.p_252.pgn[mf.p_252.wasOffsetLo] = unchecked((byte)(hsbarWasOffset.Value));

                Properties.Settings.Default.setAS_highSteerPWM = mf.p_252.pgn[mf.p_252.highPWM] = unchecked((byte)hsbarHighSteerPWM.Value);
                Properties.Settings.Default.setAS_lowSteerPWM = mf.p_252.pgn[mf.p_252.lowPWM] = unchecked((byte)hsbarLowSteerPWM.Value);
                Properties.Settings.Default.setAS_Kp = mf.p_252.pgn[mf.p_252.gainProportional] = unchecked((byte)hsbarProportionalGain.Value);
                Properties.Settings.Default.setAS_minSteerPWM = mf.p_252.pgn[mf.p_252.minPWM] = unchecked((byte)hsbarMinPWM.Value);

                Properties.Settings.Default.Save();
                Properties.Vehicle.Default.Save();

                mf.SendPgnToLoop(mf.p_252.pgn);
                toSend252 = false;
                counter252 = 0;
            }
            //*************************************************************
            else if (toSend251 && counter251 > 5)
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
                Properties.Vehicle.Default.setArdMac_isDanfoss = cboxDanfoss.Checked;

                if (cboxCurrentSensor.Checked || cboxPressureSensor.Checked)
                {
                    Properties.Vehicle.Default.setArdSteer_maxPulseCounts = (byte)hsbarSensor.Value;
                }
                else
                {
                    Properties.Vehicle.Default.setArdSteer_maxPulseCounts = (byte)nudMaxCounts.Value;
                }

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

                mf.SendPgnToLoop(mf.p_251.pgn);

                toSend251 = false;
                counter251 = 0;
            }

            if (hsbarMinPWM.Value > hsbarLowSteerPWM.Value) lblMinPWM.ForeColor = Color.OrangeRed;
            else lblMinPWM.ForeColor = SystemColors.ControlText;

            if (mf.mc.sensorData != -1)
            {
                if (mf.mc.sensorData < 0 || mf.mc.sensorData > 255) mf.mc.sensorData = 0;
                CExtensionMethods.SetProgressNoAnimation(pbarSensor, mf.mc.sensorData);
                lblPercentFS.Text = ((int)((double)mf.mc.sensorData * 0.3921568627)).ToString() + "%";
            }


            // Emulate the OGL Steer circle
            if (mf.mc.steerSwitchHigh)
                btnSteerStatus.BackColor = Color.Red;
            else if (mf.isAutoSteerBtnOn)
                btnSteerStatus.BackColor = Color.Green;
            else
                btnSteerStatus.BackColor = Color.Yellow;

            //we have lost connection to steer module
            if (mf.steerModuleConnectedCounter > 30)
            {
                btnSteerStatus.BackColor = Color.Magenta;
            }

        }

        private void sideBarTimer_Tick(object sender, EventArgs e)
        {
            lblBarAck.Text = hsbarAckerman.Value.ToString();
            lblBarWasOffset.Text = hsbarWasOffset.Value.ToString();
            lblBarCPD.Text = hsbarCountsPerDegree.Value.ToString();
        }

        #region ButtonControl

        private void btnLoadDefaults_Click(object sender, EventArgs e)
        {
            Properties.Vehicle.Default.setVehicle_maxSteerAngle = mf.vehicle.maxSteerAngle
                = 45;

            Properties.Settings.Default.setAS_countsPerDegree = 100;

            Properties.Settings.Default.setAS_ackerman = 100;

            Properties.Settings.Default.setAS_wasOffset = 0;

            Properties.Settings.Default.setAS_highSteerPWM = 150;
            Properties.Settings.Default.setAS_lowSteerPWM = 30;
            Properties.Settings.Default.setAS_Kp = 120;
            Properties.Settings.Default.setAS_minSteerPWM = 25;

            Properties.Vehicle.Default.setVehicle_panicStopSpeed = mf.vehicle.panicStopSpeed
                = 0;

            Properties.Vehicle.Default.setArdSteer_setting0 = 56;
            Properties.Vehicle.Default.setArdSteer_setting1 = 0;
            Properties.Vehicle.Default.setArdMac_isDanfoss = false;

            Properties.Vehicle.Default.setArdSteer_maxPulseCounts = 0;

            Properties.Vehicle.Default.setVehicle_goalPointLookAhead = 2.5;
            Properties.Vehicle.Default.setVehicle_goalPointLookAheadMult = 1;

            Properties.Vehicle.Default.stanleyHeadingErrorGain = 1;
            Properties.Vehicle.Default.stanleyDistanceErrorGain = 1;
            Properties.Vehicle.Default.stanleyIntegralGainAB = 0.15;

            Properties.Vehicle.Default.purePursuitIntegralGainAB = 0.15;

            Properties.Settings.Default.setAS_sideHillComp = 0;

            Properties.Settings.Default.Save();
            Properties.Vehicle.Default.Save();

            toSend252 = true;
            counter252 = 3;
            toSend251 = true;
            counter251 = 2;

            //save current vehicle
            SettingsIO.ExportAll(mf.vehiclesDirectory + mf.vehicleFileName + ".XML");

            FormSteer_Load(this, e);
        }

        private void btnStartWizard_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            isWizardStarted = true;
            tabWiz.SelectedIndex = 1;
        }

        private void btnStopWizard_Click(object sender, EventArgs e)
        {
            isWizardStarted = false;
            FreeDrive(false);
            tabWiz.SelectedIndex = 0;
            panel1.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Wizard
        private void nudMaxCounts_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                if (isWizardStarted)
                {
                    toSend251 = true;
                    counter251 = 0;
                }
            }
        }

        private void nudPanicStopSpeed_Click(object sender, EventArgs e)
        {
            //saved on close
            mf.KeypadToNUD((NumericUpDown)sender, this);
            mf.vehicle.panicStopSpeed = (double)nudPanicStopSpeed.Value;
        }

        private void cboxMotorDrive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isWizardStarted)
            {
                toSend251 = true;
                counter251 = 0;
            }
        }

        private void cboxConv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isWizardStarted)
            {
                toSend251 = true;
                counter251 = 0;
            }
        }

        private void chkInvertWAS_CheckedChanged(object sender, EventArgs e)
        {
            if (isWizardStarted)
            {
                toSend251 = true;
                counter251 = 0;
            }
        }

        private void chkInvertSteer_CheckedChanged(object sender, EventArgs e)
        {
            if (isWizardStarted)
            {
                toSend251 = true;
                counter251 = 0;
            }

        }

        private void cboxSteerEnable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isWizardStarted)
            {
                toSend251 = true;
                counter251 = 0;
            }

        }

        private void cboxDanfoss_CheckedChanged(object sender, EventArgs e)
        {
            if (isWizardStarted)
            {
                toSend251 = true;
                counter251 = 0;
            }
        }

        private void chkSteerInvertRelays_CheckedChanged(object sender, EventArgs e)
        {
            if (isWizardStarted)
            {
                toSend251 = true;
                counter251 = 0;
            }
        }

        private void cboxCancelGuidance_Click(object sender, EventArgs e)
        {
            if (sender is CheckBox)
            {
                var checkbox = (CheckBox)sender;

                if (checkbox.Name == "cboxEncoder" || checkbox.Name == "cboxPressureSensor"
                    || checkbox.Name == "cboxCurrentSensor")
                {
                    if (!checkbox.Checked)
                    {
                        cboxPressureSensor.Checked = false;
                        cboxCurrentSensor.Checked = false;
                        cboxEncoder.Checked = false;
                        label61.Visible = false;
                        lblPercentFS.Visible = false;
                        nudMaxCounts.Visible = false;
                        pbarSensor.Visible = false;
                        hsbarSensor.Visible = false;
                        lblhsbarSensor.Visible = false;
                        if (isWizardStarted)
                        {
                            toSend251 = true;
                            counter251 = 0;
                        }
                        return;
                    }

                    if (checkbox == cboxPressureSensor)
                    {
                        cboxEncoder.Checked = false;
                        cboxCurrentSensor.Checked = false;
                        label61.Visible = true;
                        lblPercentFS.Visible = true;
                        nudMaxCounts.Visible = false;
                        pbarSensor.Visible = true;
                        label61.Text = "Off at %";
                        hsbarSensor.Visible = true;
                        lblhsbarSensor.Visible = true;

                    }

                    else if (checkbox == cboxCurrentSensor)
                    {
                        cboxPressureSensor.Checked = false;
                        cboxEncoder.Checked = false;
                        label61.Visible = true;
                        lblPercentFS.Visible = true;
                        nudMaxCounts.Visible = false;
                        hsbarSensor.Visible = true;
                        pbarSensor.Visible = true;
                        label61.Text = "Off at %";
                        lblhsbarSensor.Visible = true;
                    }
                    else if (checkbox == cboxEncoder)
                    {
                        cboxPressureSensor.Checked = false;
                        cboxCurrentSensor.Checked = false;
                        label61.Visible = true;
                        lblPercentFS.Visible = false;
                        nudMaxCounts.Visible = true;
                        pbarSensor.Visible = false;
                        hsbarSensor.Visible = false;
                        lblhsbarSensor.Visible = false;
                        label61.Text = gStr.gsEncoderCounts;
                    }
                }
            }

            if (isWizardStarted)
            {
                toSend251 = true;
                counter251 = 0;
            }
        }

        private void btnOkNextCancelGuidance_Click(object sender, EventArgs e)
        {
            //btnSendSteerConfigPGN.PerformClick();
            tabWiz.SelectedIndex = (tabWiz.SelectedIndex + 1 < tabWiz.TabCount) ?
                tabWiz.SelectedIndex + 1 : tabWiz.SelectedIndex;
        }

        private void hsbarSensor_Scroll(object sender, ScrollEventArgs e)
        {
            lblhsbarSensor.Text = ((int)((double)hsbarSensor.Value * 0.3921568627)).ToString() + "%";
            if (isWizardStarted)
            {
                toSend251 = true;
                counter251 = 0;
            }
        }

        private void btnOkNext_Click(object sender, EventArgs e)
        {
            tabWiz.SelectedIndex = (tabWiz.SelectedIndex + 1 < tabWiz.TabCount) ?
                 tabWiz.SelectedIndex + 1 : tabWiz.SelectedIndex;
            lblAckError.Text = "...";
            lblCPDError.Text = "...";
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (tabWiz.SelectedTab == tabWiz.TabPages["tabMaxSteerAngle"])
            {
                tabWiz.SelectedIndex = (tabWiz.SelectedIndex - 6 < tabWiz.TabCount) ?
                                 tabWiz.SelectedIndex - 6 : tabWiz.SelectedIndex;
            }
            else
            {
                tabWiz.SelectedIndex = (tabWiz.SelectedIndex - 1 < tabWiz.TabCount) ?
                                 tabWiz.SelectedIndex - 1 : tabWiz.SelectedIndex;
            }
        }

        private void btnSkipCPD_Setup_Click(object sender, EventArgs e)
        {
            tabWiz.SelectedIndex = (tabWiz.SelectedIndex + 6 < tabWiz.TabCount) ?
                tabWiz.SelectedIndex + 6 : tabWiz.SelectedIndex;

        }

        private void btnOKNext_CPDSetup_Click(object sender, EventArgs e)
        {
            hsbarCountsPerDegree.Value = 100;
            hsbarAckerman.Value = 100;
            hsbarWasOffset.Value = 0;

            tabWiz.SelectedIndex = (tabWiz.SelectedIndex + 1 < tabWiz.TabCount) ?
             tabWiz.SelectedIndex + 1 : tabWiz.SelectedIndex;
        }

        private void btnRemoveWasOffset_Click(object sender, EventArgs e)
        {
            hsbarWasOffset.Value = 0;
        }

        private void btnRestartWizard_Click(object sender, EventArgs e)
        {
            isWizardStarted = false;
            FreeDrive(false);
            tabWiz.SelectedIndex = 0;
        }

        private void btnOkLockRightCalc_Click(object sender, EventArgs e)
        {
            ackermannRight = Math.Abs(mf.mc.actualSteerAngleDegrees);
            tabWiz.SelectedIndex = (tabWiz.SelectedIndex + 1 < tabWiz.TabCount) ?
             tabWiz.SelectedIndex + 1 : tabWiz.SelectedIndex;
        }

        private void btnOkLockLeftCalc_Click(object sender, EventArgs e)
        {
            tabWiz.SelectedIndex = (tabWiz.SelectedIndex + 1 < tabWiz.TabCount) ?
             tabWiz.SelectedIndex + 1 : tabWiz.SelectedIndex;

            //ackermann calc page
            ackermannLeft = Math.Abs(mf.mc.actualSteerAngleDegrees);
            if (ackermannRight < 20 || ackermannLeft < 20)
            {
                ackermannRight = 1;
                ackermannLeft = 1;
            }
            hsbarAckerman.Value = (int)((ackermannRight / ackermannLeft) * 100);

            lblAckLeft.Text = ackermannLeft.ToString();
            lblAckRight.Text = ackermannRight.ToString();

            if (ackermannLeft == 1)
            {
                lblAckLeft.Text = "Error";
                lblAckRight.Text = "Error";
                lblAckError.Text = "Error: One of the angles was < 20 degrees.";
            }

        }

        private void tabMotorDirection_Enter(object sender, EventArgs e)
        {
            FreeDrive(true);
        }

        private void tabMotorDirection_Leave(object sender, EventArgs e)
        {
            FreeDrive(false);
        }

        private void FreeDrive(bool isOn)
        {
            if (isOn)
            {
                mf.vehicle.ast.isInFreeDriveMode = true;
                mf.vehicle.ast.driveFreeSteerAngle = 0;
                lblSteerAngle.Text = "0";
            }
            else
            {
                mf.vehicle.ast.isInFreeDriveMode = false;
                mf.vehicle.ast.driveFreeSteerAngle = 0;
                lblSteerAngle.Text = "0";
            }
        }

        #endregion

        #region Gain
        private void hsbarMinPWM_ValueChanged(object sender, EventArgs e)
        {
            lblMinPWM.Text = unchecked((byte)hsbarMinPWM.Value).ToString();
            hsbarLowSteerPWM.Value = hsbarMinPWM.Value + 2;
            if (isWizardStarted)
            {
                toSend252 = true;
                counter252 = 0;
            }
        }

        private void hsbarProportionalGain_ValueChanged(object sender, EventArgs e)
        {
            lblProportionalGain.Text = unchecked((byte)hsbarProportionalGain.Value).ToString();
            if (isWizardStarted)
            {
                toSend252 = true;
                counter252 = 0;
            }
        }

        private void hsbarLowSteerPWM_ValueChanged(object sender, EventArgs e)
        {
            if (hsbarLowSteerPWM.Value > hsbarHighSteerPWM.Value) hsbarHighSteerPWM.Value = hsbarLowSteerPWM.Value;
            lblLowSteerPWM.Text = unchecked((byte)hsbarLowSteerPWM.Value).ToString();
            if (isWizardStarted)
            {
                toSend252 = true;
                counter252 = 0;
            }
        }

        private void hsbarHighSteerPWM_ValueChanged(object sender, EventArgs e)
        {
            if (hsbarLowSteerPWM.Value > hsbarHighSteerPWM.Value) hsbarLowSteerPWM.Value = hsbarHighSteerPWM.Value;
            lblHighSteerPWM.Text = unchecked((byte)hsbarHighSteerPWM.Value).ToString();
            if (isWizardStarted)
            {
                toSend252 = true;
                counter252 = 0;
            }
        }
        #endregion

        #region WAS

        private void hsbarAckerman_ValueChanged(object sender, EventArgs e)
        {
            lblAckerman.Text = unchecked((byte)hsbarAckerman.Value).ToString();

            if (isWizardStarted)
            {
                toSend252 = true;
                counter252 = 0;
            }
        }

        private void hsbarMaxSteerAngle_ValueChanged(object sender, EventArgs e)
        {
            mf.vehicle.maxSteerAngle = hsbarMaxSteerAngle.Value;
            lblMaxSteerAngle.Text = hsbarMaxSteerAngle.Value.ToString();
        }

        private void hsbarCountsPerDegree_ValueChanged(object sender, EventArgs e)
        {
            lblCountsPerDegree.Text = unchecked((byte)hsbarCountsPerDegree.Value).ToString();
            lblSteerAngleSensorZero.Text = (hsbarWasOffset.Value / (double)(hsbarCountsPerDegree.Value)).ToString("N2");
            if (isWizardStarted)
            {
                toSend252 = true;
                counter252 = 0;
            }
        }

        private void hsbarSteerAngleSensorZero_ValueChanged(object sender, EventArgs e)
        {
            lblSteerAngleSensorZero.Text = (hsbarWasOffset.Value / (double)(hsbarCountsPerDegree.Value)).ToString("N2");
            if (isWizardStarted)
            {
                toSend252 = true;
                counter252 = 0;
            }
        }

        private void btnZeroWAS_Click(object sender, EventArgs e)
        {
            int offset = (int)(hsbarCountsPerDegree.Value * -mf.mc.actualSteerAngleDegrees + hsbarWasOffset.Value);
            if (Math.Abs(offset) > 3900) mf.TimedMessageBox(2000, "Exceeded Range", "Excessive Steer Angle - Cannot Zero");
            else
            {
                hsbarWasOffset.Value += (int)(hsbarCountsPerDegree.Value * -mf.mc.actualSteerAngleDegrees);
            }
            if (isWizardStarted)
            {
                toSend252 = true;
                counter252 = 0;
            }
        }

        private void btnStartSA_Click(object sender, EventArgs e)
        {
            if (!isSA)
            {
                isSA = true;
                startFix = mf.pivotAxlePos;
                dist = 0;
                diameter = 0;
                cntr = 0;
                btnStartSA.Image = Properties.Resources.boundaryStop;
                lblDiameter.Text = "0";
                lblCalcSteerAngleInner.Text = "Drive Steady";
            }
            else
            {
                isSA = false;
                lblCalcSteerAngleInner.Text = "0.0" + "\u00B0";
                btnStartSA.Image = Properties.Resources.BoundaryRecord;
            }

            lblCPDError.Text = "...";

        }

        #endregion

        #region Stanley

        private void hsbarStanleyGain_ValueChanged(object sender, EventArgs e)
        {
            mf.vehicle.stanleyDistanceErrorGain = hsbarStanleyGain.Value * 0.1;
            lblStanleyGain.Text = mf.vehicle.stanleyDistanceErrorGain.ToString();
        }

        private void hsbarHeadingErrorGain_ValueChanged(object sender, EventArgs e)
        {
            mf.vehicle.stanleyHeadingErrorGain = hsbarHeadingErrorGain.Value * 0.1;
            lblHeadingErrorGain.Text = mf.vehicle.stanleyHeadingErrorGain.ToString();
        }

        private void hsbarIntegral_ValueChanged(object sender, EventArgs e)
        {
            mf.vehicle.stanleyIntegralGainAB = hsbarIntegral.Value * 0.01;
            lblIntegralPercent.Text = hsbarIntegral.Value.ToString();
        }

        #endregion

        #region Pure
        private void hsbarIntegralPurePursuit_ValueChanged(object sender, EventArgs e)
        {
            mf.vehicle.purePursuitIntegralGain = hsbarIntegralPurePursuit.Value * 0.01;
            lblPureIntegral.Text = hsbarIntegralPurePursuit.Value.ToString();
        }

        private void hsbarSideHillComp_ValueChanged(object sender, EventArgs e)
        {
            double deg = hsbarSideHillComp.Value;
            deg *= 0.01;
            lblSideHillComp.Text = (deg.ToString("N2") + "\u00B0");
            Properties.Settings.Default.setAS_sideHillComp = deg;
            mf.gyd.sideHillCompFactor = deg;
        }

        private void hsbarLookAhead_ValueChanged(object sender, EventArgs e)
        {
            mf.vehicle.goalPointLookAhead = hsbarLookAhead.Value * 0.1;
            lblLookAhead.Text = mf.vehicle.goalPointLookAhead.ToString();
            //mf.AutoSteerSettingsOutToPort();
        }

        private void btnOkSetMaximumSteerAngle_Click(object sender, EventArgs e)
        {
            if (Math.Abs((int)mf.mc.actualSteerAngleDegrees) < 10)
            {
                mf.TimedMessageBox(1500, "Steer Angle Too Low", "Must be Greater the 10 degrees");
                return;
            }

            hsbarMaxSteerAngle.Value = Math.Abs((int)(mf.mc.actualSteerAngleDegrees));
        }


        private void hsbarLookAheadMult_ValueChanged(object sender, EventArgs e)
        {
            mf.vehicle.goalPointLookAheadMult = hsbarLookAheadMult.Value * 0.1;
            lblLookAheadMult.Text = mf.vehicle.goalPointLookAheadMult.ToString();
        }

        #endregion

        #region MinMovement
        private void btnMinGainLeft_Click(object sender, EventArgs e)
        {
            if (CheckSteerSwitch())
                mf.vehicle.ast.driveFreeSteerAngle = mf.mc.actualSteerAngleDegrees - 2;
            else
                mf.TimedMessageBox(1500, "Steering Disabled", "Enable Steer Switch");
        }

        private void btnMinGainRight_Click(object sender, EventArgs e)
        {
            if (CheckSteerSwitch())
                mf.vehicle.ast.driveFreeSteerAngle = mf.mc.actualSteerAngleDegrees + 2;
            else
                mf.TimedMessageBox(1500, "Steering Disabled", "Enable Steer Switch");
        }

        private void btnZeroMinMovementSetting_Click(object sender, EventArgs e)
        {
            if (CheckSteerSwitch())
                mf.vehicle.ast.driveFreeSteerAngle = mf.mc.actualSteerAngleDegrees;
            else
                mf.TimedMessageBox(1500, "Steering Disabled", "Enable Steer Switch");
        }

        private void tab_MinimumGain_Enter(object sender, EventArgs e)
        {
            hsbarProportionalGain.Value = 1;
            FreeDrive(true);
        }

        private void tab_MinimumGain_Leave(object sender, EventArgs e)
        {
            FreeDrive(false);
            hsbarProportionalGain.Value = Properties.Settings.Default.setAS_Kp;

        }

        private void tabPGain_Enter(object sender, EventArgs e)
        {
            FreeDrive(true);
        }

        private void tabPGain_Leave(object sender, EventArgs e)
        {
            FreeDrive(false);
        }

        private void btnZeroPGain_Click(object sender, EventArgs e)
        {
            if (mf.vehicle.ast.driveFreeSteerAngle == 0)
                mf.vehicle.ast.driveFreeSteerAngle = 5;
            else mf.vehicle.ast.driveFreeSteerAngle = 0;
        }

        private void btnLeftPGain_Click(object sender, EventArgs e)
        {
            mf.vehicle.ast.driveFreeSteerAngle--;
            if (mf.vehicle.ast.driveFreeSteerAngle < -40) mf.vehicle.ast.driveFreeSteerAngle = -40;
        }

        private void btnRightPGain_Click(object sender, EventArgs e)
        {
            mf.vehicle.ast.driveFreeSteerAngle++;
            if (mf.vehicle.ast.driveFreeSteerAngle > 40) mf.vehicle.ast.driveFreeSteerAngle = 40;
        }

        private bool CheckSteerSwitch()
        {
            return (btnSteerStatus.BackColor == Color.Yellow);
        }

        #endregion

        #region Free Drive
        private void btnFreeDrive_Click(object sender, EventArgs e)
        {
            if (mf.vehicle.ast.isInFreeDriveMode)
            {
                //turn OFF free drive mode
                btnFreeDrive.Image = Properties.Resources.SteerDriveOff;
                btnFreeDrive.BackColor = Color.FromArgb(50, 50, 70);
                mf.vehicle.ast.isInFreeDriveMode = false;
                btnSteerAngleDown.Enabled = false;
                btnSteerAngleUp.Enabled = false;
                btnFreeDriveZero.Enabled = false;
                mf.vehicle.ast.driveFreeSteerAngle = 0;
            }
            else
            {
                //turn ON free drive mode
                btnFreeDrive.Image = Properties.Resources.SteerDriveOn;
                btnFreeDrive.BackColor = Color.LightGreen;
                mf.vehicle.ast.isInFreeDriveMode = true;
                btnSteerAngleDown.Enabled = true;
                btnSteerAngleUp.Enabled = true;
                btnFreeDriveZero.Enabled = true;
                mf.vehicle.ast.driveFreeSteerAngle = 0;
                lblSteerAngle.Text = "0";
            }
        }

        private void btnSteerLeft_Click(object sender, EventArgs e)
        {
            mf.vehicle.ast.driveFreeSteerAngle--;
            if (mf.vehicle.ast.driveFreeSteerAngle < -40) mf.vehicle.ast.driveFreeSteerAngle = -40;

        }

        private void btnSteerRight_Click(object sender, EventArgs e)
        {
            mf.vehicle.ast.driveFreeSteerAngle++;
            if (mf.vehicle.ast.driveFreeSteerAngle > 40) mf.vehicle.ast.driveFreeSteerAngle = 40;
        }

        private void btnFreeDriveZero_Click(object sender, EventArgs e)
        {
            if (mf.vehicle.ast.driveFreeSteerAngle == 0)
                mf.vehicle.ast.driveFreeSteerAngle = 5;
            else mf.vehicle.ast.driveFreeSteerAngle = 0;
            //hSBarFreeDrive.Value = mf.ast.driveFreeSteerAngle;
        }

        private void btnSteerAngleUp_MouseDown(object sender, MouseEventArgs e)
        {
            mf.vehicle.ast.driveFreeSteerAngle++;
            if (mf.vehicle.ast.driveFreeSteerAngle > 40) mf.vehicle.ast.driveFreeSteerAngle = 40;
        }

        private void btnSteerAngleDown_MouseDown(object sender, MouseEventArgs e)
        {
            mf.vehicle.ast.driveFreeSteerAngle--;
            if (mf.vehicle.ast.driveFreeSteerAngle < -40) mf.vehicle.ast.driveFreeSteerAngle = -40;
        }
        #endregion
    }
}


