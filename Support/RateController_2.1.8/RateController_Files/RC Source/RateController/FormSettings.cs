using AgOpenGPS;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RateController
{
    public partial class FormSettings : Form
    {
        public FormStart mf;
        private double CalculatedCPU;
        private int CurrentProduct;
        private int ErrorCount;
        private bool Initializing = false;
        private double[] MaxError = new double[5];
        private TextBox[] PIDs;
        private Label[] Sec;
        private CheckBox[] SecCK;
        private SimType SelectedSimulation;
        private TabPage[] tbs;

        public FormSettings(FormStart CallingForm, int Page)
        {
            InitializeComponent();
            #region // language

            lbProduct.Text = Lang.lgProduct;
            tc.TabPages[0].Text = Lang.lgRate;
            tc.TabPages[3].Text = Lang.lgOptions;
            tc.TabPages[4].Text = Lang.lgDiagnostics;
            tc.TabPages[5].Text = Lang.lgCalibrate;
            btnCancel.Text = Lang.lgCancel;
            bntOK.Text = Lang.lgClose;

            lb0.Text = Lang.lgProductName;
            lb5.Text = Lang.lgControlType;
            lb1.Text = Lang.lgQuantity;
            lb2.Text = Lang.lgCoverage;
            lb4.Text = Lang.lgSensorCounts;
            lb3.Text = Lang.lgTargetRate;
            lb6.Text = Lang.lgTankSize;
            lb7.Text = Lang.lgTank_Remaining;
            rbVCN.Text = Lang.lgUseVCN;
            rbPID.Text = Lang.lgUsePID;
            btnResetCoverage.Text = Lang.lgCoverage;
            btnResetTank.Text = Lang.lgTank;
            btnResetQuantity.Text = Lang.lgQuantity;

            groupBox1.Text = Lang.lgCalValues;
            lb14.Text = Lang.lgMinPWM;
            lb11.Text = Lang.lgSendTime;
            lb12.Text = Lang.lgWaitTime;
            btnLoadDefaults.Text = Lang.lgLoad_Defaults;
            tbVCNdescription.Text = Lang.lgVCNexplination;

            label7.Text = Lang.lgHighMax;
            label5.Text = Lang.lgBrakePoint;
            label4.Text = Lang.lgLowMax;
            label3.Text = Lang.lgMinPWM;
            label6.Text = Lang.lgDeadband;
            btnPIDloadDefaults.Text = Lang.lgLoad_Defaults;

            grpSections.Text = Lang.lgSections;
            grpSensor.Text = Lang.lgSensorLocation;
            lbConID.Text = Lang.lgModuleID;
            label26.Text = Lang.lgSensorID;
            grpSimulate.Text = Lang.lgSimulate;
            rbNone.Text = Lang.lgSimulationOff;
            rbVirtual.Text = Lang.lgVirtualNano;
            rbReal.Text = Lang.lgRealNano;

            lb32.Text = Lang.lgUPMTarget;
            lb33.Text = Lang.lgUPMApplied;
            label15.Text = Lang.lgUPMerror;
            label24.Text = Lang.lgCountsRev;
            label23.Text = Lang.lgRPM;
            lbSpeed.Text = Lang.lgSpeed;
            lbWidth.Text = Lang.lgWorkingWidthFT;
            lbWorkRate.Text = Lang.lgHectares_Hr;
            label1.Text = Lang.lgSection;

            label14.Text = Lang.lgSensorTotalCounts;
            label21.Text = Lang.lgQuantityMeasured;
            label16.Text = Lang.lgSensorCounts;
            btnCalStart.Text = Lang.lgResetStart;
            btnCalStop.Text = Lang.lgStop;
            btnCalCalculate.Text = Lang.lgCalculate;
            btnCalCopy.Text = Lang.lgCalCopy;

            ValveType.Items[0] = Lang.lgStandard;
            ValveType.Items[1] = Lang.lgComboClose;
            ValveType.Items[2] = Lang.lgMotor;

            AreaUnits.Items[0] = Lang.lgAcres;
            AreaUnits.Items[1] = Lang.lgHectares;
            AreaUnits.Items[2] = Lang.lgHour;
            AreaUnits.Items[3] = Lang.lgMinute;

            #endregion // language

            mf = CallingForm;
            Initializing = true;
            tbs = new TabPage[] { tbs0, tbs1, tbs3, tbs4 };
            CurrentProduct = Page - 1;
            if (CurrentProduct < 0) CurrentProduct = 0;

            openFileDialog1.InitialDirectory = mf.Tls.SettingsDir();
            saveFileDialog1.InitialDirectory = mf.Tls.SettingsDir();

            Sec = new Label[] { sec0, sec1, sec2, sec3, sec4, sec5, sec6, sec7, sec8, sec9, sec10, sec11, sec12, sec13, sec14, sec15 };

            PIDs = new TextBox[] { tbPIDkp, tbPIDMinPWM, tbPIDLowMax, tbPIDHighMax, tbPIDDeadBand, tbPIDBrakePoint };
            for (int i = 0; i < 6; i++)
            {
                PIDs[i].Tag = i;

                PIDs[i].Enter += tbPID_Enter;
                PIDs[i].TextChanged += tbPID_TextChanged;
                PIDs[i].Validating += tbPID_Validating;
            }

            SecCK = new CheckBox[] { ck0, ck1, ck2, ck3, ck4, ck5, ck6, ck7, ck8, ck9, ck10, ck11, ck12, ck13, ck14, ck15 };
            for (int i = 0; i < 16; i++)
            {
                SecCK[i].CheckedChanged += ck0_CheckedChanged;
            }
        }

        private void AreaUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            Button ButtonClicked = (Button)sender;
            if (ButtonClicked.Text == Lang.lgClose)
            {
                this.Close();
            }
            else
            {
                if (CheckModSen())
                {
                    // save changes
                    SaveSettings();
                    mf.Sections.CheckSwitchDefinitions();

                    string Title = "RC [" + Path.GetFileNameWithoutExtension(Properties.Settings.Default.FileName) + "]";

                    switch (SelectedSimulation)
                    {
                        case SimType.VirtualNano:
                            break;

                        case SimType.RealNano:
                        default:
                            break;
                    }

                    SetButtons(false);
                    UpdateForm();
                }
                else
                {
                    mf.Tls.TimedMessageBox("Module ID / Sensor ID pair must be unique.");
                }
            }
        }

        private void btnCalCalculate_Click(object sender, EventArgs e)
        {
            CalculatedCPU = 0;
            double Measured;
            if (double.TryParse(tbCalMeasured.Text, out Measured))
            {
                if (Measured > 0)
                {
                    CalculatedCPU = CalCounts() / Measured;
                }
            }
            lbCalCPU.Text = CalculatedCPU.ToString("N1");
        }

        private void btnCalCopy_Click(object sender, EventArgs e)
        {
            FlowCal.Text = CalculatedCPU.ToString("N1");
        }

        private void btnCalStart_Click(object sender, EventArgs e)
        {
            mf.DoCal = true;
            mf.CalCounterStart = mf.Products.Item(CurrentProduct).QuantityApplied();
            SetCalButtons();
        }

        private void btnCalStop_Click(object sender, EventArgs e)
        {
            mf.DoCal = false;
            SetCalButtons();
            mf.CalCounterEnd = mf.Products.Item(CurrentProduct).QuantityApplied();
            lbCalCounts.Text = CalCounts().ToString("N0");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UpdateForm();
            SetButtons(false);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (CurrentProduct > 0)
            {
                CurrentProduct--;
                UpdateForm();
            }
        }

        private void btnLoadDefaults_Click(object sender, EventArgs e)
        {
            tbVCN.Text = "743";
            tbSend.Text = "200";
            tbWait.Text = "750";
            tbMinPWM.Text = "145";
        }

        private void btnLoadSettings_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                mf.Tls.PropertiesFile = openFileDialog1.FileName;
                mf.Products.Load();
                UpdateForm();
                mf.LoadSettings();
            }
        }

        private void btnPIDloadDefaults_Click(object sender, EventArgs e)
        {
            tbPIDkp.Text = "40";
            tbPIDMinPWM.Text = "5";
            tbPIDLowMax.Text = "125";
            tbPIDHighMax.Text = "200";
            tbPIDDeadBand.Text = "3";
            tbPIDBrakePoint.Text = "20";
        }

        private void btnResetCoverage_Click(object sender, EventArgs e)
        {
            mf.Products.Item(CurrentProduct).ResetCoverage();
        }

        private void btnResetQuantity_Click(object sender, EventArgs e)
        {
            mf.Products.Item(CurrentProduct).ResetApplied();
        }

        private void btnResetTank_Click(object sender, EventArgs e)
        {
            mf.Products.Item(CurrentProduct).ResetTank();
            TankRemain.Text = mf.Products.Item(CurrentProduct).CurrentTankRemaining().ToString("N0");
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (CurrentProduct < 4)
            {
                CurrentProduct++;
                UpdateForm();
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != "")
                {
                    mf.Tls.SaveFile(saveFileDialog1.FileName);
                    mf.LoadSettings();
                }
            }
        }

        private void btnSections_Click(object sender, EventArgs e)
        {
        }

        private double CalCounts()
        {
            double Result = 0;
            if (mf.Products.Item(CurrentProduct).FlowCal > 0)
            {
                Result = (mf.CalCounterEnd - mf.CalCounterStart) * mf.Products.Item(CurrentProduct).FlowCal;
            }
            return Result;
        }

        private bool CheckModSen()
        {
            byte ModID = 0;
            byte SenID = 0;
            byte.TryParse(tbConID.Text, out ModID);
            byte.TryParse(tbSenID.Text, out SenID);
            bool Unique = false;

            if (mf.Products.UniqueModSen(ModID, SenID, CurrentProduct))
            {
                Unique = true;
            }
            else
            {
                // set unique pair
                for (int i = 0; i < 16; i++)
                {
                    Unique = mf.Products.UniqueModSen(i, SenID, CurrentProduct);
                    if (Unique)
                    {
                        Initializing = true;
                        tbConID.Text = i.ToString();
                        Initializing = false;

                        mf.Tls.TimedMessageBox("Module set to " + i.ToString(), "Module/Sensor pair must be unique. Change as necessary.");

                        break;
                    }
                }
            }
            return Unique;
        }

        private void ck0_CheckedChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void FlowCal_Enter(object sender, EventArgs e)
        {
            double tempD;
            double.TryParse(FlowCal.Text, out tempD);
            using (var form = new FormNumeric(0, 10000, tempD))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    FlowCal.Text = form.ReturnValue.ToString();
                }
            }
        }

        private void FlowCal_TextChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void FlowCal_Validating(object sender, CancelEventArgs e)
        {
            double tempD;
            double.TryParse(FlowCal.Text, out tempD);
            if (tempD < 0 || tempD > 10000)
            {
                System.Media.SystemSounds.Exclamation.Play();
                e.Cancel = true;
            }
        }

        private void FormSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                mf.Tls.SaveFormData(this);
            }
            timer1.Enabled = false;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            mf.Tls.LoadFormData(this);
            timer1.Enabled = true;

            UpdateForm();
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            mf.Tls.DrawGroupBox(box, e.Graphics, this.BackColor, Color.Black, Color.Blue);
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            mf.Tls.DrawGroupBox(box, e.Graphics, this.BackColor, Color.Black, Color.Blue);
        }

        private void groupBox3_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            mf.Tls.DrawGroupBox(box, e.Graphics, this.BackColor, Color.Black, Color.Blue);
        }

        private void groupBox4_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            mf.Tls.DrawGroupBox(box, e.Graphics, this.BackColor, Color.Black, Color.Blue);
        }

        private void grpSections_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            mf.Tls.DrawGroupBox(box, e.Graphics, this.BackColor, Color.Black, Color.Blue);
        }

        private void LoadSecCK()
        {
            for (int i = 0; i < 16; i++)
            {
                if (mf.Sections.Item(i).Enabled)
                {
                    SecCK[i].Enabled = true;
                    SecCK[i].Checked = mf.Products.Item(CurrentProduct).IsSectionAssigned((byte)i);
                }
                else
                {
                    SecCK[i].Enabled = false;

                    SecCK[i].Checked = false;
                    mf.Products.Item(CurrentProduct).AssignSection((byte)i, false);
                }
            }
        }

        private void LoadSettings()
        {
            tbProduct.Text = mf.Products.Item(CurrentProduct).ProductName;
            VolumeUnits.SelectedIndex = mf.Products.Item(CurrentProduct).QuantityUnits;
            AreaUnits.SelectedIndex = mf.Products.Item(CurrentProduct).CoverageUnits;
            RateSet.Text = mf.Products.Item(CurrentProduct).RateSet.ToString("N1");
            FlowCal.Text = mf.Products.Item(CurrentProduct).FlowCal.ToString("N1");
            TankSize.Text = mf.Products.Item(CurrentProduct).TankSize.ToString("N0");
            ValveType.SelectedIndex = mf.Products.Item(CurrentProduct).ValveType;
            TankRemain.Text = mf.Products.Item(CurrentProduct).CurrentTankRemaining().ToString("N0");
            tbVCN.Text = (mf.Products.Item(CurrentProduct).VCN).ToString("G0");
            tbSend.Text = (mf.Products.Item(CurrentProduct).SendTime).ToString("N0");
            tbWait.Text = (mf.Products.Item(CurrentProduct).WaitTime).ToString("N0");
            tbMinPWM.Text = (mf.Products.Item(CurrentProduct).MinPWM).ToString("N0");

            tbCountsRev.Text = (mf.Products.Item(CurrentProduct).CountsRev.ToString("N0"));

            string tmp = mf.Products.Item(CurrentProduct).ModuleID.ToString();
            if (tmp == "99") tmp = "";
            tbConID.Text = tmp;

            SelectedSimulation = mf.Products.Item(CurrentProduct).SimulationType;
            switch (SelectedSimulation)
            {
                case SimType.VirtualNano:
                    rbVirtual.Checked = true;
                    break;

                case SimType.RealNano:
                    rbReal.Checked = true;
                    break;

                default:
                    rbNone.Checked = true;
                    break;
            }

            // VCN
            rbVCN.Checked = (mf.Products.Item(CurrentProduct).UseVCN);
            rbPID.Checked = !(mf.Products.Item(CurrentProduct).UseVCN);

            // PID
            tbPIDkp.Text = mf.Products.Item(CurrentProduct).PIDkp.ToString("N0");
            tbPIDMinPWM.Text = mf.Products.Item(CurrentProduct).PIDminPWM.ToString("N0");
            tbPIDLowMax.Text = mf.Products.Item(CurrentProduct).PIDLowMax.ToString("N0");

            tbPIDHighMax.Text = mf.Products.Item(CurrentProduct).PIDHighMax.ToString("N0");
            tbPIDDeadBand.Text = mf.Products.Item(CurrentProduct).PIDdeadband.ToString("N0");
            tbPIDBrakePoint.Text = mf.Products.Item(CurrentProduct).PIDbrakepoint.ToString("N0");

            LoadSecCK();
            tbSenID.Text = mf.Products.Item(CurrentProduct).SensorID.ToString();
        }

        private void RadioButtonChanged(object sender, EventArgs e)
        {
            int Result;
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    int.TryParse(rb.Tag.ToString(), out Result);
                    if (SelectedSimulation != (SimType)Result) SetButtons(true);
                    SelectedSimulation = (SimType)Result;
                }
            }
        }

        private void RateSet_Enter(object sender, EventArgs e)
        {
            double tempD;
            double.TryParse(RateSet.Text, out tempD);
            using (var form = new FormNumeric(0, 500, tempD))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    RateSet.Text = form.ReturnValue.ToString();
                }
            }
        }

        private void RateSet_TextChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void RateSet_Validating(object sender, CancelEventArgs e)
        {
            double tempD;
            double.TryParse(RateSet.Text, out tempD);
            if (tempD < 0 || tempD > 10000)
            {
                System.Media.SystemSounds.Exclamation.Play();
                e.Cancel = true;
            }
        }

        private void rbPID_CheckedChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void rbVCN_CheckedChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private double RunningCounts()
        {
            double Result = 0;
            if (mf.Products.Item(CurrentProduct).FlowCal > 0)
            {
                Result = (mf.Products.Item(CurrentProduct).QuantityApplied() - mf.CalCounterStart) * mf.Products.Item(CurrentProduct).FlowCal;
            }
            return Result;
        }

        private void SaveSecCK()
        {
            for (int i = 0; i < 16; i++)
            {
                if (SecCK[i].Enabled & SecCK[i].Checked)
                {
                    mf.Products.Item(CurrentProduct).AssignSection((byte)i);
                }
                else
                {
                    mf.Products.Item(CurrentProduct).AssignSection((byte)i, false);
                }
            }
        }

        private void SaveSettings()
        {
            double tempD;
            int tempInt;
            byte tempB;

            mf.Products.Item(CurrentProduct).QuantityUnits = Convert.ToByte(VolumeUnits.SelectedIndex);
            mf.Products.Item(CurrentProduct).CoverageUnits = Convert.ToByte(AreaUnits.SelectedIndex);

            double.TryParse(RateSet.Text, out tempD);
            mf.Products.Item(CurrentProduct).RateSet = tempD;

            double.TryParse(FlowCal.Text, out tempD);
            mf.Products.Item(CurrentProduct).FlowCal = tempD;

            double.TryParse(TankSize.Text, out tempD);
            mf.Products.Item(CurrentProduct).TankSize = tempD;

            mf.Products.Item(CurrentProduct).ValveType = Convert.ToByte(ValveType.SelectedIndex);

            double.TryParse(TankRemain.Text, out tempD);
            mf.Products.Item(CurrentProduct).SetTankRemaining(tempD);

            int.TryParse(tbVCN.Text, out tempInt);
            mf.Products.Item(CurrentProduct).VCN = tempInt;

            int.TryParse(tbSend.Text, out tempInt);
            mf.Products.Item(CurrentProduct).SendTime = tempInt;

            int.TryParse(tbWait.Text, out tempInt);
            mf.Products.Item(CurrentProduct).WaitTime = tempInt;

            byte.TryParse(tbMinPWM.Text, out tempB);
            mf.Products.Item(CurrentProduct).MinPWM = tempB;

            mf.Products.Item(CurrentProduct).SimulationType = SelectedSimulation;
            mf.Products.Item(CurrentProduct).ProductName = tbProduct.Text;

            byte.TryParse(tbConID.Text, out tempB);
            mf.Products.Item(CurrentProduct).ModuleID = tempB;

            // VCN
            mf.Products.Item(CurrentProduct).UseVCN = (rbVCN.Checked);

            // PID
            byte.TryParse(tbPIDkp.Text, out tempB);
            mf.Products.Item(CurrentProduct).PIDkp = tempB;

            byte.TryParse(tbPIDMinPWM.Text, out tempB);
            mf.Products.Item(CurrentProduct).PIDminPWM = tempB;

            byte.TryParse(tbPIDLowMax.Text, out tempB);
            mf.Products.Item(CurrentProduct).PIDLowMax = tempB;

            byte.TryParse(tbPIDHighMax.Text, out tempB);
            mf.Products.Item(CurrentProduct).PIDHighMax = tempB;

            byte.TryParse(tbPIDDeadBand.Text, out tempB);
            mf.Products.Item(CurrentProduct).PIDdeadband = tempB;

            byte.TryParse(tbPIDBrakePoint.Text, out tempB);
            mf.Products.Item(CurrentProduct).PIDbrakepoint = tempB;

            int.TryParse(tbCountsRev.Text, out tempInt);
            mf.Products.Item(CurrentProduct).CountsRev = tempInt;

            SaveSecCK();
            byte.TryParse(tbSenID.Text, out tempB);
            mf.Products.Item(CurrentProduct).SensorID = tempB;

            mf.Products.Item(CurrentProduct).Save();
        }

        private void SetButtons(bool Edited)
        {
            if (!Initializing)
            {
                if (Edited)
                {
                    btnCancel.Enabled = true;
                    this.bntOK.Text = Lang.lgSave;
                    btnLeft.Enabled = false;
                    btnRight.Enabled = false;
                }
                else
                {
                    btnCancel.Enabled = false;
                    this.bntOK.Text = Lang.lgClose;
                    btnLeft.Enabled = true;
                    btnRight.Enabled = true;
                }
            }
        }

        private void SetCalButtons()
        {
            btnCalStart.Enabled = !mf.DoCal;
            btnCalStop.Enabled = mf.DoCal;
            btnCalCalculate.Enabled = !mf.DoCal;
            btnCalCopy.Enabled = !mf.DoCal;
        }

        private void SetDayMode()
        {
            if (Properties.Settings.Default.IsDay)
            {
                this.BackColor = Properties.Settings.Default.DayColour;

                for (int i = 0; i < 4; i++)
                {
                    tbs[i].BackColor = Properties.Settings.Default.DayColour;
                }

                ModuleIndicator.BackColor = Properties.Settings.Default.DayColour;
                lbProduct.BackColor = Properties.Settings.Default.DayColour;

                foreach (Control c in this.Controls)
                {
                    c.ForeColor = Color.Black;
                }

                for (int i = 0; i < 16; i++)
                {
                    Sec[i].BackColor = Properties.Settings.Default.DayColour;
                }
            }
            else
            {
                this.BackColor = Properties.Settings.Default.NightColour;

                for (int i = 0; i < 4; i++)
                {
                    tbs[i].BackColor = Properties.Settings.Default.NightColour;
                }

                foreach (Control c in this.Controls)
                {
                    c.ForeColor = Color.White;
                }

                for (int i = 0; i < 16; i++)
                {
                    Sec[i].BackColor = Properties.Settings.Default.NightColour;
                }
            }

            // fix backcolor
            this.BackColor = Properties.Settings.Default.DayColour;
            for (int i = 0; i < tc.TabCount; i++)
            {
                tc.TabPages[i].BackColor = Properties.Settings.Default.DayColour;
            }
            tbVCNdescription.BackColor = Properties.Settings.Default.DayColour;
        }

        private void SetModuleIndicator()
        {
            if (mf.Products.Item(CurrentProduct).ArduinoModule.Connected())
            {
                ModuleIndicator.Image = Properties.Resources.On;
            }
            else
            {
                ModuleIndicator.Image = Properties.Resources.Off;
            }
        }

        private void SetVCNpid()
        {
            if (rbVCN.Checked)
            {
                tbVCN.Enabled = true;
                tbSend.Enabled = true;
                tbWait.Enabled = true;
                tbMinPWM.Enabled = true;
                btnLoadDefaults.Enabled = true;

                for (int i = 0; i < 6; i++)
                {
                    PIDs[i].Enabled = false;
                }
                btnPIDloadDefaults.Enabled = false;
            }
            else
            {
                tbVCN.Enabled = false;
                tbSend.Enabled = false;
                tbWait.Enabled = false;
                tbMinPWM.Enabled = false;
                btnLoadDefaults.Enabled = false;

                tbPIDBrakePoint.Enabled = true;
                tbPIDLowMax.Enabled = true;

                for (int i = 0; i < 6; i++)
                {
                    PIDs[i].Enabled = true;
                }
                btnPIDloadDefaults.Enabled = true;
            }

            switch (ValveType.SelectedIndex)
            {
                case 2:
                    // motor
                    rbPID.Checked = true;
                    rbPID.Enabled = false;
                    rbVCN.Enabled = false;
                    tbPIDBrakePoint.Enabled = false;
                    tbPIDLowMax.Enabled = false;
                    tbPIDBrakePoint.Text = "0";
                    tbPIDLowMax.Text = "0";
                    break;

                default:
                    // 0 standard valve, 1 fast close valve
                    rbVCN.Enabled = true;
                    rbPID.Enabled = true;
                    break;
            }
        }

        private void TankRemain_Enter(object sender, EventArgs e)
        {
            double tempD;
            double.TryParse(TankRemain.Text, out tempD);
            using (var form = new FormNumeric(0, 100000, tempD))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    TankRemain.Text = form.ReturnValue.ToString();
                }
            }
        }

        private void TankRemain_TextChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void TankRemain_Validating(object sender, CancelEventArgs e)
        {
            double tempD;
            double.TryParse(TankRemain.Text, out tempD);
            if (tempD < 0 || tempD > 100000)
            {
                System.Media.SystemSounds.Exclamation.Play();
                e.Cancel = true;
            }
        }

        private void TankSize_Enter(object sender, EventArgs e)
        {
            double tempD;
            double.TryParse(TankSize.Text, out tempD);
            using (var form = new FormNumeric(0, 100000, tempD))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    TankSize.Text = form.ReturnValue.ToString();
                }
            }
        }

        private void TankSize_TextChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void TankSize_Validating(object sender, CancelEventArgs e)
        {
            double tempD;
            double.TryParse(TankSize.Text, out tempD);
            if (tempD < 0 || tempD > 100000)
            {
                System.Media.SystemSounds.Exclamation.Play();
                e.Cancel = true;
            }
        }

        private void tbConID_Enter(object sender, EventArgs e)
        {
            int tempInt;
            int.TryParse(tbConID.Text, out tempInt);
            using (var form = new FormNumeric(0, 15, tempInt))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tbConID.Text = form.ReturnValue.ToString();
                }
            }
        }

        private void tbConID_TextChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void tbConID_Validating(object sender, CancelEventArgs e)
        {
            int tempInt;
            int.TryParse(tbConID.Text, out tempInt);
            if (tempInt < 0 || tempInt > 15)
            {
                System.Media.SystemSounds.Exclamation.Play();
                e.Cancel = true;
            }
        }

        private void tbCountsRev_TextChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void tbCountsRev_Validating(object sender, CancelEventArgs e)
        {
            int Tmp;
            int.TryParse(tbCountsRev.Text, out Tmp);
            if (Tmp < 0 || Tmp > 10000)
            {
                System.Media.SystemSounds.Exclamation.Play();
                e.Cancel = true;
            }
        }

        private void tbMinPWM_Enter(object sender, EventArgs e)
        {
            double tempD;
            double.TryParse(tbMinPWM.Text, out tempD);
            using (var form = new FormNumeric(0, 255, tempD))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tbMinPWM.Text = form.ReturnValue.ToString();
                }
            }
        }

        private void tbMinPWM_TextChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void tbMinPWM_Validating(object sender, CancelEventArgs e)
        {
            double tempD;
            double.TryParse(tbMinPWM.Text, out tempD);
            if (tempD < 0 || tempD > 255)
            {
                System.Media.SystemSounds.Exclamation.Play();
                e.Cancel = true;
            }
        }

        private void tbPID_Enter(object sender, EventArgs e)
        {
            int index = (int)((TextBox)sender).Tag;
            int tmp;
            int max;

            switch (index)
            {
                case 5:
                    max = 90;
                    break;

                case 4:
                    max = 10;
                    break;

                default:
                    max = 255;
                    break;
            }

            int.TryParse(PIDs[index].Text, out tmp);
            using (var form = new FormNumeric(0, max, tmp))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    PIDs[index].Text = form.ReturnValue.ToString();
                }
            }
        }

        private void tbPID_TextChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void tbPID_Validating(object sender, CancelEventArgs e)
        {
            int index = (int)((TextBox)sender).Tag;
            int tmp;
            int max;

            switch (index)
            {
                case 5:
                    max = 90;
                    break;

                case 4:
                    max = 10;
                    break;

                default:
                    max = 255;
                    break;
            }

            int.TryParse(PIDs[index].Text, out tmp);
            if (tmp < 0 || tmp > max)
            {
                System.Media.SystemSounds.Exclamation.Play();
                e.Cancel = true;
            }
        }

        private void tbProduct_TextChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void tbSectionCount_TextChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void tbSend_Enter(object sender, EventArgs e)
        {
            int tempInt;
            int.TryParse(tbSend.Text, out tempInt);
            using (var form = new FormNumeric(20, 2000, tempInt))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tbSend.Text = form.ReturnValue.ToString();
                }
            }
        }

        private void tbSend_TextChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void tbSend_Validating(object sender, CancelEventArgs e)
        {
            int tempInt;
            int.TryParse(tbSend.Text, out tempInt);
            if (tempInt < 20 || tempInt > 2000)
            {
                System.Media.SystemSounds.Exclamation.Play();
                e.Cancel = true;
            }
        }

        private void tbSenID_Enter(object sender, EventArgs e)
        {
            int tempInt;
            int.TryParse(tbSenID.Text, out tempInt);
            using (var form = new FormNumeric(0, 15, tempInt))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tbSenID.Text = form.ReturnValue.ToString();
                }
            }
        }

        private void tbSenID_TextChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void tbSenID_Validating(object sender, CancelEventArgs e)
        {
            int tempInt;
            int.TryParse(tbSenID.Text, out tempInt);
            if (tempInt < 0 || tempInt > 15)
            {
                System.Media.SystemSounds.Exclamation.Play();
                e.Cancel = true;
            }
        }

        private void tbVCN_Enter(object sender, EventArgs e)
        {
            int tempInt;
            int.TryParse(tbVCN.Text, out tempInt);
            using (var form = new FormNumeric(0, 9999, tempInt))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tbVCN.Text = form.ReturnValue.ToString();
                }
            }
        }

        private void tbVCN_TextChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void tbVCN_Validating(object sender, CancelEventArgs e)
        {
            int tempInt;
            int.TryParse(tbVCN.Text, out tempInt);
            if (tempInt < 0 || tempInt > 9999)
            {
                System.Media.SystemSounds.Exclamation.Play();
                e.Cancel = true;
            }
        }

        private void tbWait_Enter(object sender, EventArgs e)
        {
            int tempInt;
            int.TryParse(tbWait.Text, out tempInt);
            using (var form = new FormNumeric(20, 2000, tempInt))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tbWait.Text = form.ReturnValue.ToString();
                }
            }
        }

        private void tbWait_TextChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void tbWait_Validating(object sender, CancelEventArgs e)
        {
            int tempInt;
            int.TryParse(tbWait.Text, out tempInt);
            if (tempInt < 20 || tempInt > 2000)
            {
                System.Media.SystemSounds.Exclamation.Play();
                e.Cancel = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateDiags();
            if (mf.DoCal) lbCalCounts.Text = RunningCounts().ToString("N0");
            SetModuleIndicator();
        }

        private void UpdateDiags()
        {
            if (mf.Products.Item(CurrentProduct).CoverageUnits == 0)
            {
                lbWorkRate.Text = Lang.lgAcresHr;
            }
            else
            {
                lbWorkRate.Text = Lang.lgHectares_Hr;
            }

            double Target = mf.Products.Item(CurrentProduct).TargetUPM();
            double Applied = mf.Products.Item(CurrentProduct).UPMapplied();
            double RateError = 0;

            lbRateSetData.Text = Target.ToString("N1");
            lbRateAppliedData.Text = Applied.ToString("N1");

            if (Target > 0)
            {
                RateError = ((Applied - Target) / Target) * 100;

                if (Math.Abs(RateError) > MaxError[CurrentProduct]) MaxError[CurrentProduct] = Math.Abs(RateError);
                ErrorCount++;
                if (ErrorCount > 10)
                {
                    lbMaxError.Text = MaxError[CurrentProduct].ToString("N1");
                    ErrorCount = 0;
                    MaxError[CurrentProduct] = 0;
                }
            }
            lbErrorPercent.Text = RateError.ToString("N1");

            lbPWMdata.Text = mf.Products.Item(CurrentProduct).PWM().ToString("N0");

            lbWidthData.Text = mf.Products.Item(CurrentProduct).Width().ToString("N1");
            lbWorkRateData.Text = mf.Products.Item(CurrentProduct).WorkRate().ToString("N1");

            if (mf.Products.Item(CurrentProduct).CoverageUnits == 0)
            {
                lbWidth.Text = Lang.lgWorkingWidthFT;
            }
            else
            {
                lbWidth.Text = Lang.lgWorkingWidthM;
            }

            lbSpeedData.Text = mf.Products.Item(CurrentProduct).Speed().ToString("N1");
            if (mf.Products.Item(CurrentProduct).CoverageUnits == 0)
            {
                lbSpeed.Text = Lang.lgMPH;
            }
            else
            {
                lbSpeed.Text = Lang.lgKPH;
            }

            // update sections
            for (int i = 0; i < 16; i++)
            {
                Sec[i].Enabled = (mf.Sections.Item(i).Enabled) & (mf.Products.Item(CurrentProduct).IsSectionAssigned((byte)i));
                if (mf.Sections.IsSectionOn(i) & mf.Products.Item(CurrentProduct).IsSectionAssigned((byte)i))
                {
                    Sec[i].Image = Properties.Resources.OnSmall;
                }
                else
                {
                    Sec[i].Image = Properties.Resources.OffSmall;
                }
            }

            // RPM
            if (mf.Products.Item(CurrentProduct).CountsRev > 0)
            {
                float RPM = (float)((mf.Products.Item(CurrentProduct).FlowCal * Applied) / mf.Products.Item(CurrentProduct).CountsRev);
                lbRPM.Text = RPM.ToString("N0");
            }
            else
            {
                lbRPM.Text = "0";
            }
        }

        private void UpdateForm()
        {
            Initializing = true;

            UpdateDiags();
            LoadSettings();
            SetVCNpid();
            SetModuleIndicator();
            SetCalButtons();
            SetDayMode();

            lbProduct.Text = (CurrentProduct + 1).ToString() + ". " + mf.Products.Item(CurrentProduct).ProductName;
            if (mf.Products.Item(CurrentProduct).SimulationType != SimType.None)
            {
                lbProduct.Text = lbProduct.Text + "   Simulation";
                //lbProduct.ForeColor = mf.SimColor;
                lbProduct.BackColor = mf.SimColor;
                lbProduct.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                lbProduct.ForeColor = SystemColors.ControlText;
                lbProduct.BackColor = Properties.Settings.Default.DayColour;
                lbProduct.BorderStyle = BorderStyle.None;
            }

            Initializing = false;
        }

        private void ValveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void VolumeUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void tbCountsRev_Click(object sender, EventArgs e)
        {
            int tempInt;
            int.TryParse(tbCountsRev.Text, out tempInt);
            using (var form = new FormNumeric(0, 10000, tempInt))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tbCountsRev.Text = form.ReturnValue.ToString();
                }
            }
        }

        private void tbCalMeasured_Click(object sender, EventArgs e)
        {
            int tempInt;
            int.TryParse(tbCalMeasured.Text, out tempInt);
            using (var form = new FormNumeric(0, 10000, tempInt))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tbCalMeasured.Text = form.ReturnValue.ToString();
                }
            }
        }
    }
}