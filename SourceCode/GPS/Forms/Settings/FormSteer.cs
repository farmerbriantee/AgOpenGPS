using AgOpenGPS.Properties;
using System;
using System.Drawing;
using System.Windows.Forms; 

namespace AgOpenGPS
{
    public partial class FormSteer : Form
    {

        private readonly FormGPS mf = null;

        private bool toSend = false, isSA = false;
        private int counter = 0, cntr;
        private vec3 startFix;
        private double diameter, steerAngleRight, dist;
        private int windowSizeState = 0;

        //Form stuff
        public FormSteer(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
            nudMaxCounts.Controls[0].Enabled = false;
            nudPanicStopSpeed.Controls[0].Enabled = false;

            this.label3.Text = gStr.gsAgressiveness;
            this.label5.Text = gStr.gsOvershootReduction;
            this.Text = gStr.gsAutoSteerConfiguration;
            this.Width = 388;
            this.Height = 480;

        }

        private void FormSteer_Load(object sender, EventArgs e)
        {
            //WAS Zero, CPD
            hsbarWasOffset.ValueChanged -= hsbarSteerAngleSensorZero_ValueChanged;
            hsbarCountsPerDegree.ValueChanged -= hsbarCountsPerDegree_ValueChanged;

            hsbarWasOffset.Value = Properties.Settings.Default.setAS_wasOffset;
            hsbarCountsPerDegree.Value = Properties.Settings.Default.setAS_countsPerDegree;

            lblCountsPerDegree.Text = hsbarCountsPerDegree.Value.ToString();
            lblSteerAngleSensorZero.Text = (hsbarWasOffset.Value / (double)(hsbarCountsPerDegree.Value)).ToString("N2");

            hsbarWasOffset.ValueChanged += hsbarSteerAngleSensorZero_ValueChanged;
            hsbarCountsPerDegree.ValueChanged += hsbarCountsPerDegree_ValueChanged;

            hsbarAckerman.ValueChanged -= hsbarAckerman_ValueChanged;
            hsbarAckerman.Value = Properties.Settings.Default.setAS_ackerman;
            lblAckerman.Text = hsbarAckerman.Value.ToString();
            hsbarAckerman.ValueChanged += hsbarAckerman_ValueChanged;

            //min pwm, kP
            hsbarMinPWM.ValueChanged -= hsbarMinPWM_ValueChanged;
            hsbarProportionalGain.ValueChanged -= hsbarProportionalGain_ValueChanged;

            hsbarMinPWM.Value = Properties.Settings.Default.setAS_minSteerPWM;
            lblMinPWM.Text = hsbarMinPWM.Value.ToString();

            hsbarProportionalGain.Value = Properties.Settings.Default.setAS_Kp;
            lblProportionalGain.Text = hsbarProportionalGain.Value.ToString();

            hsbarMinPWM.ValueChanged += hsbarMinPWM_ValueChanged;
            hsbarProportionalGain.ValueChanged += hsbarProportionalGain_ValueChanged;

            //low steer, high steer
            //hsbarLowSteerPWM.ValueChanged -= hsbarLowSteerPWM_ValueChanged;
            hsbarHighSteerPWM.ValueChanged -= hsbarHighSteerPWM_ValueChanged;

            //hsbarLowSteerPWM.Value = Properties.Settings.Default.setAS_lowSteerPWM;
            //lblLowSteerPWM.Text = hsbarLowSteerPWM.Value.ToString();

            hsbarHighSteerPWM.Value = Properties.Settings.Default.setAS_highSteerPWM;
            lblHighSteerPWM.Text = hsbarHighSteerPWM.Value.ToString();

            //hsbarLowSteerPWM.ValueChanged += hsbarLowSteerPWM_ValueChanged;
            hsbarHighSteerPWM.ValueChanged += hsbarHighSteerPWM_ValueChanged;

            hsbarMaxSteerAngle.Value = (Int16)Properties.Settings.Default.setVehicle_maxSteerAngle;
            lblMaxSteerAngle.Text = hsbarMaxSteerAngle.Value.ToString();

            mf.vehicle.stanleyDistanceErrorGain = Properties.Settings.Default.stanleyDistanceErrorGain;
            hsbarStanleyGain.Value = (Int16)(mf.vehicle.stanleyDistanceErrorGain * 10);
            lblStanleyGain.Text = mf.vehicle.stanleyDistanceErrorGain.ToString();

            mf.vehicle.stanleyHeadingErrorGain = Properties.Settings.Default.stanleyHeadingErrorGain;
            hsbarHeadingErrorGain.Value = (Int16)(mf.vehicle.stanleyHeadingErrorGain * 10);
            lblHeadingErrorGain.Text = mf.vehicle.stanleyHeadingErrorGain.ToString();

            mf.vehicle.stanleyIntegralGainAB = Properties.Settings.Default.stanleyIntegralGainAB;
            hsbarIntegral.Value = (int)(Properties.Settings.Default.stanleyIntegralGainAB * 100);
            lblIntegralPercent.Text = ((int)(mf.vehicle.stanleyIntegralGainAB * 100)).ToString();

            mf.vehicle.purePursuitIntegralGain = Properties.Settings.Default.purePursuitIntegralGainAB;
            hsbarIntegralPurePursuit.Value = (int)(Properties.Settings.Default.purePursuitIntegralGainAB * 100);
            lblPureIntegral.Text = ((int)(mf.vehicle.purePursuitIntegralGain * 100)).ToString();

            mf.gyd.sideHillCompFactor = Properties.Settings.Default.setAS_sideHillComp;
            hsbarSideHillComp.Value = (int)(Properties.Settings.Default.setAS_sideHillComp * 100);

            mf.vehicle.goalPointLookAhead = Properties.Settings.Default.setVehicle_goalPointLookAhead;
            hsbarLookAhead.Value = (Int16)(mf.vehicle.goalPointLookAhead * 10);
            lblLookAhead.Text = mf.vehicle.goalPointLookAhead.ToString();

            mf.vehicle.goalPointLookAheadHold = Properties.Settings.Default.setVehicle_goalPointLookAheadHold;
            hsbarHoldLookAhead.Value = (Int16)(mf.vehicle.goalPointLookAheadHold * 10);
            lblHoldLookAhead.Text = mf.vehicle.goalPointLookAheadHold.ToString();

            hsbarLookAheadMult.Value = (Int16)(Properties.Settings.Default.setVehicle_goalPointLookAheadMult * 10);
            lblLookAheadMult.Text = mf.vehicle.goalPointLookAheadMult.ToString();

            //make sure free drive is off
            btnFreeDrive.Image = Properties.Resources.SteerDriveOff;
            mf.vehicle.isInFreeDriveMode = false;
            btnSteerAngleDown.Enabled = false;
            btnSteerAngleUp.Enabled = false;
            mf.vehicle.driveFreeSteerAngle = 0;

            nudPanicStopSpeed.Value = (decimal)mf.vehicle.panicStopSpeed;

            //Stanley guidance

            if (mf.isStanleyUsed)
            {
                btnStanleyPure.Image = Resources.ModeStanley;
            }
            else
            {
                btnStanleyPure.Image = Resources.ModePurePursuit;
            }

            toSend = false;

            int sett = Properties.Settings.Default.setArdSteer_setting0;

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

            nudMaxCounts.Value = (decimal)Properties.Settings.Default.setArdSteer_maxPulseCounts;
            hsbarSensor.Value = (int)Properties.Settings.Default.setArdSteer_maxPulseCounts;
            lblhsbarSensor.Text = ((int)((double)hsbarSensor.Value * 0.3921568627)).ToString() + "%";

            sett = Properties.Settings.Default.setArdSteer_setting1;

            if ((sett & 1) == 0) cboxDanfoss.Checked = false;
            else cboxDanfoss.Checked = true;

            if ((sett & 8) == 0) cboxXY.Text = "X";
            else cboxXY.Text = "Y";

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

        private void Timer1_Tick(object sender, EventArgs e)
        {

            if (isSA)
            {
                //bool isSame = Math.PI - Math.Abs(Math.Abs(cH - mf.gpsHeading) - Math.PI) < (glm.PIBy2+0.1);
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
                    steerAngleRight = Math.Atan(mf.vehicle.wheelbase / ((diameter - mf.vehicle.trackWidth * 0.5) / 2));
                    steerAngleRight = glm.toDegrees(steerAngleRight);
                    //steerAngleLeft = Math.Atan(mf.vehicle.wheelbase / (diameter / 2 ));
                    //steerAngleLeft = glm.toDegrees(steerAngleLeft);

                    lblCalcSteerAngleInner.Text = steerAngleRight.ToString("N1") + "\u00B0";
                    //lblCalcSteerAngleOuter.Text = steerAngleLeft.ToString("N1") + "\u00B0";
                    lblDiameter.Text = diameter.ToString("N2") + " m";
                    btnStartSA.Image = Properties.Resources.BoundaryRecord;
                    isSA = false;
                }
            }

            double actAng = mf.mc.actualSteerAngleDegrees * 5;
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

            lblSteerAngle.Text = mf.SetSteerAngle;
            lblSteerAngleActual.Text = mf.mc.actualSteerAngleDegrees.ToString("N1") + "\u00B0";
            lblActualSteerAngleUpper.Text = lblSteerAngleActual.Text;
            double err = (mf.mc.actualSteerAngleDegrees - mf.guidanceLineSteerAngle * 0.01);
            lblError.Text = Math.Abs(err).ToString("N1") + "\u00B0";
            if (err > 0) lblError.ForeColor = Color.Red;
            else lblError.ForeColor = Color.DarkGreen;

            lblAV_Act.Text = mf.actAngVel.ToString("N1");
            lblAV_Set.Text = mf.setAngVel.ToString("N1");

            lblPWMDisplay.Text = mf.mc.pwmDisplay.ToString();
            counter++;
            if (toSend && counter > 4)
            {
                Properties.Settings.Default.setAS_countsPerDegree = mf.p_252.pgn[mf.p_252.countsPerDegree] = unchecked((byte)hsbarCountsPerDegree.Value);
                Properties.Settings.Default.setAS_ackerman = mf.p_252.pgn[mf.p_252.ackerman] = unchecked((byte)hsbarAckerman.Value);

                Properties.Settings.Default.setAS_wasOffset = hsbarWasOffset.Value;
                mf.p_252.pgn[mf.p_252.wasOffsetHi] = unchecked((byte)(hsbarWasOffset.Value >> 8));
                mf.p_252.pgn[mf.p_252.wasOffsetLo] = unchecked((byte)(hsbarWasOffset.Value));

                Properties.Settings.Default.setAS_highSteerPWM = mf.p_252.pgn[mf.p_252.highPWM] = unchecked((byte)hsbarHighSteerPWM.Value);
                Properties.Settings.Default.setAS_lowSteerPWM = mf.p_252.pgn[mf.p_252.lowPWM] = unchecked((byte)(hsbarHighSteerPWM.Value/3));
                Properties.Settings.Default.setAS_Kp = mf.p_252.pgn[mf.p_252.gainProportional] = unchecked((byte)hsbarProportionalGain.Value);
                Properties.Settings.Default.setAS_minSteerPWM = mf.p_252.pgn[mf.p_252.minPWM] = unchecked((byte)hsbarMinPWM.Value);

                Properties.Settings.Default.Save();

                mf.SendPgnToLoop(mf.p_252.pgn);
                toSend = false;
                counter = 0;
            }

            //if (hsbarMinPWM.Value > hsbarLowSteerPWM.Value) lblMinPWM.ForeColor = Color.OrangeRed;
            //else lblMinPWM.ForeColor = SystemColors.ControlText;

            
            if (mf.mc.sensorData != -1)
            {
                if (mf.mc.sensorData < 0 || mf.mc.sensorData > 255) mf.mc.sensorData = 0;
                CExtensionMethods.SetProgressNoAnimation(pbarSensor, mf.mc.sensorData);
                lblPercentFS.Text = ((int)((double)mf.mc.sensorData * 0.3921568627)).ToString() + "%";
            }
        }

        private void FormSteer_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.vehicle.isInFreeDriveMode = false;

            Properties.Settings.Default.setVehicle_goalPointLookAhead = mf.vehicle.goalPointLookAhead;
            Properties.Settings.Default.setVehicle_goalPointLookAheadHold = mf.vehicle.goalPointLookAheadHold;
            Properties.Settings.Default.setVehicle_goalPointLookAheadMult = mf.vehicle.goalPointLookAheadMult;

            Properties.Settings.Default.stanleyHeadingErrorGain = mf.vehicle.stanleyHeadingErrorGain;
            Properties.Settings.Default.stanleyDistanceErrorGain = mf.vehicle.stanleyDistanceErrorGain;
            Properties.Settings.Default.stanleyIntegralGainAB = mf.vehicle.stanleyIntegralGainAB;
            Properties.Settings.Default.purePursuitIntegralGainAB = mf.vehicle.purePursuitIntegralGain;
            Properties.Settings.Default.setVehicle_maxSteerAngle = mf.vehicle.maxSteerAngle;

            Properties.Settings.Default.setAS_countsPerDegree = mf.p_252.pgn[mf.p_252.countsPerDegree] = unchecked((byte)hsbarCountsPerDegree.Value);
            Properties.Settings.Default.setAS_ackerman = mf.p_252.pgn[mf.p_252.ackerman] = unchecked((byte)hsbarAckerman.Value);

            Properties.Settings.Default.setAS_wasOffset = hsbarWasOffset.Value;
            mf.p_252.pgn[mf.p_252.wasOffsetHi] = unchecked((byte)(hsbarWasOffset.Value >> 8));
            mf.p_252.pgn[mf.p_252.wasOffsetLo] = unchecked((byte)(hsbarWasOffset.Value));

            Properties.Settings.Default.setAS_highSteerPWM = mf.p_252.pgn[mf.p_252.highPWM] = unchecked((byte)hsbarHighSteerPWM.Value);
            Properties.Settings.Default.setAS_lowSteerPWM = mf.p_252.pgn[mf.p_252.lowPWM] = unchecked((byte)(hsbarHighSteerPWM.Value/3));
            Properties.Settings.Default.setAS_Kp = mf.p_252.pgn[mf.p_252.gainProportional] = unchecked((byte)hsbarProportionalGain.Value);
            Properties.Settings.Default.setAS_minSteerPWM = mf.p_252.pgn[mf.p_252.minPWM] = unchecked((byte)hsbarMinPWM.Value);

            Properties.Settings.Default.setVehicle_panicStopSpeed = mf.vehicle.panicStopSpeed;

            Properties.Settings.Default.setAS_ModeXTE = mf.vehicle.modeXTE;
            Properties.Settings.Default.setAS_ModeTime = mf.vehicle.modeTime;

            Properties.Settings.Default.Save();

            //save current vehicle
            SettingsIO.ExportAll(mf.vehiclesDirectory + mf.vehicleFileName + ".XML");
        }

        private void btnVehicleReset_Click(object sender, EventArgs e)
        {
            DialogResult result3 = MessageBox.Show("Reset This Page to Defaults",
                "Are you Sure",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (result3 == DialogResult.Yes)
            {


                mf.TimedMessageBox(2000, "Reset To Default", "Values Set to Inital Default");
                Properties.Settings.Default.setVehicle_maxSteerAngle = mf.vehicle.maxSteerAngle
                    = 45;

                Properties.Settings.Default.setAS_countsPerDegree = 100;

                Properties.Settings.Default.setAS_ackerman = 100;

                Properties.Settings.Default.setAS_wasOffset = 0;

                Properties.Settings.Default.setAS_highSteerPWM = 150;
                Properties.Settings.Default.setAS_Kp = 120;
                Properties.Settings.Default.setAS_minSteerPWM = 25;

                Properties.Settings.Default.setVehicle_panicStopSpeed = mf.vehicle.panicStopSpeed
                    = 0;

                Properties.Settings.Default.setArdSteer_setting0 = 56;
                Properties.Settings.Default.setArdSteer_setting1 = 0;
                Properties.Settings.Default.setArdMac_isDanfoss = false;

                Properties.Settings.Default.setArdSteer_maxPulseCounts = 0;

                Properties.Settings.Default.setVehicle_goalPointLookAhead = 3;
                Properties.Settings.Default.setVehicle_goalPointLookAheadHold = 3;
                Properties.Settings.Default.setVehicle_goalPointLookAheadMult = 1;

                Properties.Settings.Default.stanleyHeadingErrorGain = 1;
                Properties.Settings.Default.stanleyDistanceErrorGain = 1;
                Properties.Settings.Default.stanleyIntegralGainAB = 0.15;

                Properties.Settings.Default.purePursuitIntegralGainAB = 0.15;

                Properties.Settings.Default.setAS_sideHillComp = 0;

                //Properties.Settings.Default.setVehicle_wheelbase = 2.8;

                //Properties.Settings.Default.setVehicle_trackWidth = 1.9;

                //Properties.Settings.Default.setVehicle_antennaPivot = 0.1;

                //Properties.Settings.Default.setVehicle_antennaHeight = 3;

                //Properties.Settings.Default.setVehicle_antennaOffset = 0;

                Properties.Settings.Default.setIMU_invertRoll = false;

                Properties.Settings.Default.setIMU_rollZero = mf.ahrs.rollZero;

                Properties.Settings.Default.Save();

                //save current vehicle
                SettingsIO.ExportAll(mf.vehiclesDirectory + mf.vehicleFileName + ".XML");

                FormSteer_Load(this, e);

                toSend = true; counter = 6;

                pboxSendSteer.Visible = true;
                //btnSendSteerConfigPGN.PerformClick();
            }
        }

        #region Gain
        private void hsbarMinPWM_ValueChanged(object sender, EventArgs e)
        {
            lblMinPWM.Text = unchecked((byte)hsbarMinPWM.Value).ToString();
            toSend = true;
            counter = 0;
        }

        private void hsbarProportionalGain_ValueChanged(object sender, EventArgs e)
        {
            lblProportionalGain.Text = unchecked((byte)hsbarProportionalGain.Value).ToString();
            toSend = true;
            counter = 0;
        }

        //private void hsbarLowSteerPWM_ValueChanged(object sender, EventArgs e)
        //{
        //    if (hsbarLowSteerPWM.Value > hsbarHighSteerPWM.Value) hsbarHighSteerPWM.Value = hsbarLowSteerPWM.Value;
        //    lblLowSteerPWM.Text = unchecked((byte)hsbarLowSteerPWM.Value).ToString();
        //    toSend = true;
        //    counter = 0;
        //}

        private void hsbarHighSteerPWM_ValueChanged(object sender, EventArgs e)
        {
            //if (hsbarLowSteerPWM.Value > hsbarHighSteerPWM.Value) hsbarLowSteerPWM.Value = hsbarHighSteerPWM.Value;
            lblHighSteerPWM.Text = unchecked((byte)hsbarHighSteerPWM.Value).ToString();
            toSend = true;
            counter = 0;
        }
        #endregion

        #region Steer

        private void hsbarAckerman_ValueChanged(object sender, EventArgs e)
        {
            lblAckerman.Text = unchecked((byte)hsbarAckerman.Value).ToString();
            toSend = true;
            counter = 0;
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
            toSend = true;
            counter = 0;
        }

        private void hsbarSteerAngleSensorZero_ValueChanged(object sender, EventArgs e)
        {
            lblSteerAngleSensorZero.Text = (hsbarWasOffset.Value / (double)(hsbarCountsPerDegree.Value)).ToString("N2");
            toSend = true;
            counter = 0;
        }

        private void btnZeroWAS_Click(object sender, EventArgs e)
        {
            int offset = (int)(hsbarCountsPerDegree.Value * -mf.mc.actualSteerAngleDegrees + hsbarWasOffset.Value);
            if (Math.Abs(offset) > 3900) mf.TimedMessageBox(2000, "Exceeded Range", "Excessive Steer Angle - Cannot Zero");
            else
            {
                hsbarWasOffset.Value += (int)(hsbarCountsPerDegree.Value * -mf.mc.actualSteerAngleDegrees);
            }
        }

        private void btnWASZeroReset_Click(object sender, EventArgs e)
        {
            hsbarWasOffset.Value = 0;
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
                //lblCalcSteerAngleOuter.Text = "Consistent Steering Angle!!";
            }
            else
            {
                isSA = false;
                lblCalcSteerAngleInner.Text = "0.0" + "\u00B0";
                //lblCalcSteerAngleOuter.Text = "0.0" + "\u00B0";
                btnStartSA.Image = Properties.Resources.BoundaryRecord;
            }

        }

        #endregion

        # region Stanley

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
        private void hsbarHoldLookAhead_ValueChanged(object sender, EventArgs e)
        {
            mf.vehicle.goalPointLookAheadHold = hsbarHoldLookAhead.Value * 0.1;
            lblHoldLookAhead.Text = mf.vehicle.goalPointLookAheadHold.ToString();
        }

        private void hsbarLookAheadMult_ValueChanged(object sender, EventArgs e)
        {
            mf.vehicle.goalPointLookAheadMult = hsbarLookAheadMult.Value * 0.1;
            lblLookAheadMult.Text = mf.vehicle.goalPointLookAheadMult.ToString();
        }

        private void expandWindow_Click(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            if (windowSizeState++ > 0) windowSizeState = 0;
            if (windowSizeState == 1)
            {
                this.Size = new System.Drawing.Size(960, 720);
            }
            else if (windowSizeState == 0)
            {
                this.Size = new System.Drawing.Size(388, 480);
            }

        }

        private void nudMaxCounts_Click(object sender, EventArgs e)
        {
            if (mf.KeypadToNUD((NumericUpDown)sender, this))
            {
                pboxSendSteer.Visible = true;
            }
        }

        private void nudPanicStopSpeed_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
            mf.vehicle.panicStopSpeed = (double)nudPanicStopSpeed.Value;
        }

        private void EnableAlert_Click(object sender, EventArgs e)
        {
            pboxSendSteer.Visible = true;

            if (sender is CheckBox checkbox)
            {
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
        }

        private void btnSendSteerConfigPGN_Click(object sender, EventArgs e)
        {
            SaveSettings();
            mf.SendPgnToLoop(mf.p_251.pgn);
            pboxSendSteer.Visible = false;

            mf.TimedMessageBox(1000, gStr.gsAutoSteerPort, "Settings Sent To Steer Module");

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

            Properties.Settings.Default.setArdSteer_setting0 = (byte)sett;
            Properties.Settings.Default.setArdMac_isDanfoss = cboxDanfoss.Checked;

            if (cboxCurrentSensor.Checked || cboxPressureSensor.Checked)
            {
                Properties.Settings.Default.setArdSteer_maxPulseCounts = (byte)hsbarSensor.Value;
            }
            else
            {
                Properties.Settings.Default.setArdSteer_maxPulseCounts = (byte)nudMaxCounts.Value;
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

            //bit 2
            set <<= 1;
            reset <<= 1;
            reset += 1;
            if (cboxCurrentSensor.Checked) sett |= set;
            else sett &= reset;

            //bit 3
            set <<= 1;
            reset <<= 1;
            reset += 1;
            if (cboxXY.Text == "Y") sett |= set;
            else sett &= reset;

            Properties.Settings.Default.setArdSteer_setting1 = (byte)sett;

            Properties.Settings.Default.Save();

            mf.p_251.pgn[mf.p_251.set0] = Properties.Settings.Default.setArdSteer_setting0;
            mf.p_251.pgn[mf.p_251.set1] = Properties.Settings.Default.setArdSteer_setting1;
            mf.p_251.pgn[mf.p_251.maxPulse] = Properties.Settings.Default.setArdSteer_maxPulseCounts;
            mf.p_251.pgn[mf.p_251.minSpeed] = 5; //0.5 kmh

            if (Properties.Settings.Default.setAS_isConstantContourOn)
                mf.p_251.pgn[mf.p_251.angVel] = 1;
            else mf.p_251.pgn[mf.p_251.angVel] = 0;

            pboxSendSteer.Visible = false;
        }

        private void hsbarSensor_Scroll(object sender, ScrollEventArgs e)
        {
            pboxSendSteer.Visible = true;
            lblhsbarSensor.Text = ((int)((double)hsbarSensor.Value * 0.3921568627)).ToString() + "%";
        }

        #endregion

        #region Free Drive
        private void btnFreeDrive_Click(object sender, EventArgs e)
        {
            if (mf.vehicle.isInFreeDriveMode)
            {
                //turn OFF free drive mode
                btnFreeDrive.Image = Properties.Resources.SteerDriveOff;
                btnFreeDrive.BackColor = Color.FromArgb(50, 50, 70);
                mf.vehicle.isInFreeDriveMode = false;
                btnSteerAngleDown.Enabled = false;
                btnSteerAngleUp.Enabled = false;
                //hSBarFreeDrive.Value = 0;
                mf.vehicle.driveFreeSteerAngle = 0;
            }
            else
            {
                //turn ON free drive mode
                btnFreeDrive.Image = Properties.Resources.SteerDriveOn;
                btnFreeDrive.BackColor = Color.LightGreen;
                mf.vehicle.isInFreeDriveMode = true;
                btnSteerAngleDown.Enabled = true;
                btnSteerAngleUp.Enabled = true;
                //hSBarFreeDrive.Value = 0;
                mf.vehicle.driveFreeSteerAngle = 0;
                lblSteerAngle.Text = "0";
            }
        }

        private void btnFreeDriveZero_Click(object sender, EventArgs e)
        {
            if (mf.vehicle.driveFreeSteerAngle == 0)
                mf.vehicle.driveFreeSteerAngle = 5;
            else mf.vehicle.driveFreeSteerAngle = 0;
            //hSBarFreeDrive.Value = mf.driveFreeSteerAngle;
        }


        private void btnSteerAngleUp_MouseDown(object sender, MouseEventArgs e)
        {
            mf.vehicle.driveFreeSteerAngle++;
            if (mf.vehicle.driveFreeSteerAngle > 40) mf.vehicle.driveFreeSteerAngle = 40;
        }

        private void btnSteerAngleDown_MouseDown(object sender, MouseEventArgs e)
        {
            mf.vehicle.driveFreeSteerAngle--;
            if (mf.vehicle.driveFreeSteerAngle < -40) mf.vehicle.driveFreeSteerAngle = -40;
        }
        #endregion

        #region Help
        private void btnZeroWAS_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_btnZeroWAS, gStr.gsHelp);
        }

        private void hsbarWasOffset_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_hsbarWasOffset, gStr.gsHelp);
        }

        private void hsbarCountsPerDegree_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_hsbarCountsPerDegree, gStr.gsHelp);

        }

        private void hsbarAckerman_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_hsbarAckerman, gStr.gsHelp);
        }

        private void hsbarMaxSteerAngle_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_hsbarMaxSteerAngle, gStr.gsHelp);
        }

        private void hsbarProportionalGain_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_hsbarProportionalGain, gStr.gsHelp);
        }

        private void hsbarHighSteerPWM_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_hsbarHighSteerPWM, gStr.gsHelp);
        }

        private void hsbarLowSteerPWM_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_hsbarLowSteerPWM, gStr.gsHelp);
        }

        private void hsbarMinPWM_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_hsbarMinPWM, gStr.gsHelp);
        }

        private void hsbarStanleyGain_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_hsbarStanleyGain, gStr.gsHelp);
        }

        private void hsbarHeadingErrorGain_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_hsbarHeadingErrorGain, gStr.gsHelp);
        }

        private void hsbarIntegral_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_hsbarIntegral, gStr.gsHelp);
        }

        private void hsbarLookAhead_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_hsbarLookAhead, gStr.gsHelp);
        }

        private void hsbarLookAheadMult_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_hsbarLookAheadMult, gStr.gsHelp);
        }

        private void hsbarSideHillComp_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_hsbarSideHillComp, gStr.gsHelp);
        }

        private void hsbarHoldLookAhead_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_hsbarHoldLookAhead, gStr.gsHelp);
        }

        private void hsbarIntegralPurePursuit_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_hsbarIntegralPurePursuit, gStr.gsHelp);
        }

        private void btnFreeDrive_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_btnFreeDrive, gStr.gsHelp);
        }

        private void btnSteerAngleDown_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_btnSteerAngleDown, gStr.gsHelp);
        }

        private void btnSteerAngleUp_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_btnSteerAngleUp, gStr.gsHelp);
        }

        private void btnFreeDriveZero_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_btnFreeDriveZero, gStr.gsHelp);
        }

        private void btnStartSA_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.h_btnStartSA, gStr.gsHelp);
        }

        private void chkInvertWAS_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_chkInvertWAS, gStr.gsHelp);
        }

        private void chkInvertSteer_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_chkInvertSteer, gStr.gsHelp);
        }

        private void chkSteerInvertRelays_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_chkSteerInvertRelays, gStr.gsHelp);
        }

        private void cboxDanfoss_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxDanfoss, gStr.gsHelp);
        }

        private void cboxEncoder_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxEncoder, gStr.gsHelp);
        }

        private void cboxPressureSensor_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxPressureSensor, gStr.gsHelp);
        }

        private void cboxCurrentSensor_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxCurrentSensor, gStr.gsHelp);
        }

        private void nudMaxCounts_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_nudMaxCounts, gStr.gsHelp);
        }

        private void cboxMotorDrive_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxMotorDrive, gStr.gsHelp);
        }

        private void cboxXY_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxXY, gStr.gsHelp);
        }

        private void btnStanleyPure_Click(object sender, EventArgs e)
        {
            mf.isStanleyUsed = !mf.isStanleyUsed;

            if (mf.isStanleyUsed)
            {
                btnStanleyPure.Image = Resources.ModeStanley;
            }
            else
            {
                btnStanleyPure.Image = Resources.ModePurePursuit;
            }

            Properties.Settings.Default.setVehicle_isStanleyUsed = mf.isStanleyUsed;
            Properties.Settings.Default.Save();
        }

        private void cboxConv_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxConv, gStr.gsHelp);
        }

        private void cboxSteerEnable_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_cboxSteerEnable, gStr.gsHelp);
        }

        private void pboxSendSteer_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_pboxSendSteer, gStr.gsHelp);
        }

        private void btnSendSteerConfigPGN_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(gStr.hc_btnSendSteerConfigPGN, gStr.gsHelp);
        }

        #endregion

        //private void hsBarModeMultiplier_ValueChanged(object sender, EventArgs e)
        //{
        //    mf.vehicle.modeMultiplier = (hsBarModeMultiplier.Value * 0.1) - 1;
        //    lblModeMultiplier.Text = (mf.vehicle.modeMultiplier +1).ToString();
        //}

        //private void hsBarModeMultiplierStanley_ValueChanged(object sender, EventArgs e)
        //{
        //    mf.vehicle.modeMultiplierStanley = (hsBarModeMultiplierStanley.Value * 0.1);
        //    lblModeMultiplierStanley.Text = (mf.vehicle.modeMultiplierStanley).ToString();

        //}

        //private void hsbarModeXTE_ValueChanged(object sender, EventArgs e)
        //{
        //    mf.vehicle.modeXTE = hsbarModeXTE.Value * 0.01;
        //    lblModeXTE.Text = hsbarModeXTE.Value.ToString();

        //}

        //private void hsbarModeTime_ValueChanged(object sender, EventArgs e)
        //{
        //    mf.vehicle.modeTime = hsbarModeTime.Value;
        //    lblModeTime.Text = hsbarModeTime.Value.ToString();
        //}


    }
}
