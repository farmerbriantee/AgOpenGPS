//Please, if you use this, share the improvements

using System;
using System.Drawing;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormArduinoSettings : Form
    {
        //class variables
        private readonly FormGPS mf = null;


        //constructor
        public FormArduinoSettings(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();

            //Language keys
            this.Text = gStr.gsModuleConfiguration;

            //Steer Tab
            tabAutoSteer.Text = gStr.gsAutoSteer;
            label1.Text = gStr.gsMotorDriver;
            label6.Text = gStr.gsMMAAxis;
            label3.Text = gStr.gsA2DConvertor;
            label5.Text = gStr.gsSteerEnable;
            label8.Text = gStr.gsMinSpeed;
            label4.Text = gStr.gsMaxSpeed;
            label2.Text = gStr.gsInclinometer;
            chkInvertWAS.Text = gStr.gsInvertWAS;
            chkInvertSteer.Text = gStr.gsInvertSteerDirection;
            chkInvertRoll.Text = gStr.gsInvertRoll;
            chkBNOInstalled.Text = gStr.gsBNOInstalled;
            cboxEncoder.Text = gStr.gsEncoder;
            label7.Text = gStr.gsEncoderCounts;
            label9.Text = gStr.gsSendToModule;
            groupBox5.Text = gStr.gsToAutoSteer;
            cboxIsSendMachineControlToAutoSteer.Text = gStr.gsMachinePGN;
            groupBox1.Text = gStr.gsHydraulicToolLift;

            //Machine tab
            label10.Text = gStr.gsRaiseTime;
            label11.Text = gStr.gsLowerTime;
            cboxIsHydOn.Text = gStr.gsEnableHydraulics;
            tabMachine.Text = gStr.gsMachine;

             nudMaxSpeed.Controls[0].Enabled = false;
             nudMinSpeed.Controls[0].Enabled = false;
            nudMaxCounts.Controls[0].Enabled = false;
            nudRaiseTime.Controls[0].Enabled = false;
            nudLowerTime.Controls[0].Enabled = false;
             nudAckerman.Controls[0].Enabled = false;


            //select the page as per calling menu or button from mainGPS form
            //tabControl1.SelectedIndex = page;
        }

        //do any field initializing for form here
        private void FormToolSettings_Load(object sender, EventArgs e)
        {
            int sett = Properties.Vehicle.Default.setArdSteer_setting0;

            if ((sett & 1) == 0) chkInvertWAS.Checked = false;
            else chkInvertWAS.Checked = true;

            if ((sett & 2) == 0) chkInvertRoll.Checked = false;
            else chkInvertRoll.Checked = true;

            if ((sett & 4) == 0) chkInvertSteer.Checked = false;
            else chkInvertSteer.Checked = true;

            if ((sett & 8) == 0) cboxConv.Text = "Differential";
            else cboxConv.Text = "Single";

            if ((sett & 16) == 0) cboxMotorDrive.Text = "IBT2";
            else cboxMotorDrive.Text = "Cytron";

            if ((sett & 32) == 0) cboxSteerEnable.Text = "Button";
            else cboxSteerEnable.Text = "Switch";

            if ((sett & 64) == 0) cboxMMAAxis.Text = "Y Axis";
            else cboxMMAAxis.Text = "X Axis";

            if ((sett & 128) == 0) cboxEncoder.Checked = false;
            else cboxEncoder.Checked = true;

            sett = Properties.Vehicle.Default.setArdSteer_setting1;

            if ((sett & 1) == 0) chkBNOInstalled.Checked = false;
            else chkBNOInstalled.Checked = true;

            if ((sett & 2) == 0) cboxSteerInvertRelays.Checked = false;
            else cboxSteerInvertRelays.Checked = true;

            //inclinometer
            byte inc = Properties.Vehicle.Default.setArdSteer_inclinometer;
            switch (inc)
            {
                case 0:
                    cboxInclinometer.Text = "None";
                    break;
                case 1:
                    cboxInclinometer.Text = "DOGS2";
                    break;
                case 2:
                    cboxInclinometer.Text = "MMA (1C)";
                    break;
                case 3:
                    cboxInclinometer.Text = "MMA (1D)";
                    break;

                default:
                    cboxInclinometer.Text = "Error";
                    break;
            }

            nudMaxSpeed.Value = (decimal)(Properties.Vehicle.Default.setArdSteer_maxSpeed);
            nudMinSpeed.Value = (decimal)(Properties.Vehicle.Default.setArdSteer_minSpeed);
            nudMaxCounts.Value = (decimal)Properties.Vehicle.Default.setArdSteer_maxPulseCounts;
            nudAckerman.Value = (decimal)Properties.Vehicle.Default.setArdSteer_ackermanFix;


            //Machine --------------------------------------------------------------------------------------------
            sett = Properties.Vehicle.Default.setArdMac_setting0;

            if ((sett & 1) == 0) cboxMachInvertRelays.Checked = false;
            else cboxMachInvertRelays.Checked = true;


            nudRaiseTime.Value = (decimal)Properties.Vehicle.Default.setArdMac_hydRaiseTime;
            nudLowerTime.Value = (decimal)Properties.Vehicle.Default.setArdMac_hydLowerTime;
            cboxIsHydOn.Checked = Properties.Vehicle.Default.setArdMac_isHydEnabled > 0;

            cboxIsSendMachineControlToAutoSteer.Checked = Properties.Vehicle.Default.setVehicle_isMachineControlToAutoSteer;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveSettings();
            //mf.SendArduinoSettingsOutToAutoSteerPort();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void SaveSettings()
        {
            switch (cboxInclinometer.Text)
            {
                case "None":
                    Properties.Vehicle.Default.setArdSteer_inclinometer = 0;
                    break;

                case "DOGS2":
                    Properties.Vehicle.Default.setArdSteer_inclinometer = 1;
                    break;

                case "MMA (1C)":
                    Properties.Vehicle.Default.setArdSteer_inclinometer = 2;
                    break;

                case "MMA (1D)":
                    Properties.Vehicle.Default.setArdSteer_inclinometer = 3;
                    break;

                default:
                    Properties.Vehicle.Default.setArdSteer_inclinometer = 0;
                    break;
            }



            int set = 1;
            int reset = 2046;
            int sett = 0;

            if (chkInvertWAS.Checked) sett |= set;
            else sett &= reset;

            set = (set << 1);
            reset = (reset << 1);
            reset = (reset + 1);
            if (chkInvertRoll.Checked) sett |= set;
            else sett &= reset;

            set = (set << 1);
            reset = (reset << 1);
            reset = (reset + 1);
            if (chkInvertSteer.Checked) sett |= set;
            else sett &= reset;

            set = (set << 1);
            reset = (reset << 1);
            reset = (reset + 1);
            if (cboxConv.Text == "Single") sett |= set;
            else sett &= reset;

            set = (set << 1);
            reset = (reset << 1);
            reset = (reset + 1);
            if (cboxMotorDrive.Text == "Cytron") sett |= set;
            else sett &= reset;

            set = (set << 1);
            reset = (reset << 1);
            reset = (reset + 1);
            if (cboxSteerEnable.Text == "Switch") sett |= set;
            else sett &= reset;

            set = (set << 1);
            reset = (reset << 1);
            reset = (reset + 1);
            if (cboxMMAAxis.Text == "X Axis") sett |= set;
            else sett &= reset;

            set = (set << 1);
            reset = (reset << 1);
            reset = (reset + 1);
            if (cboxEncoder.Checked) sett |= set;
            else sett &= reset;

            Properties.Vehicle.Default.setArdSteer_setting0 = (byte)sett;

            //set1
            set = 1;
            reset = 2046;
            sett = 0;

            if (chkBNOInstalled.Checked) sett |= set;
            else sett &= reset;

            set = (set << 1);
            reset = (reset << 1);
            reset = (reset + 1);
            if (cboxSteerInvertRelays.Checked) sett = sett | set;
            else sett &= reset;


            Properties.Vehicle.Default.setArdSteer_setting1 = (byte)sett;

            Properties.Vehicle.Default.setArdSteer_maxSpeed = (byte)nudMaxSpeed.Value;
            Properties.Vehicle.Default.setArdSteer_minSpeed = (byte)nudMinSpeed.Value;
            Properties.Vehicle.Default.setArdSteer_maxPulseCounts = (byte)nudMaxCounts.Value;
            Properties.Vehicle.Default.setArdSteer_ackermanFix = (byte)nudAckerman.Value;

            mf.mc.isMachineDataSentToAutoSteer = cboxIsSendMachineControlToAutoSteer.Checked;
            Properties.Vehicle.Default.setVehicle_isMachineControlToAutoSteer = mf.mc.isMachineDataSentToAutoSteer;

            Properties.Vehicle.Default.Save();

            mf.mc.ardSteerConfig[mf.mc.arSet0] = Properties.Vehicle.Default.setArdSteer_setting0;
            mf.mc.ardSteerConfig[mf.mc.arSet1] = Properties.Vehicle.Default.setArdSteer_setting1;
            mf.mc.ardSteerConfig[mf.mc.arMaxSpd] = Properties.Vehicle.Default.setArdSteer_maxSpeed;
            mf.mc.ardSteerConfig[mf.mc.arMinSpd] = Properties.Vehicle.Default.setArdSteer_minSpeed;
            mf.mc.ardSteerConfig[mf.mc.arAckermanFix] = Properties.Vehicle.Default.setArdSteer_ackermanFix;

            byte inc = (byte)(Properties.Vehicle.Default.setArdSteer_inclinometer << 6);            
            mf.mc.ardSteerConfig[mf.mc.arIncMaxPulse] = (byte)(inc + (byte)Properties.Vehicle.Default.setArdSteer_maxPulseCounts);

            //Machine ---------------------------------------------------------------------------------------------------

            //set1
            set = 1;
            reset = 2046;
            sett = 0;

            if (cboxMachInvertRelays.Checked) sett |= set;
            else sett &= reset;

            Properties.Vehicle.Default.setArdMac_setting0 = (byte)sett;
            mf.mc.ardMachineConfig[mf.mc.amSet0] = (byte)sett;

            Properties.Vehicle.Default.setArdMac_hydRaiseTime = (byte)nudRaiseTime.Value;
            mf.mc.ardMachineConfig[mf.mc.amRaiseTime] = (byte)nudRaiseTime.Value;

            Properties.Vehicle.Default.setArdMac_hydLowerTime = (byte)nudLowerTime.Value;
            mf.mc.ardMachineConfig[mf.mc.amLowerTime] = (byte)nudLowerTime.Value;

            if (cboxIsHydOn.Checked) Properties.Vehicle.Default.setArdMac_isHydEnabled = (byte)1;
            else Properties.Vehicle.Default.setArdMac_isHydEnabled = (byte)0;
            mf.mc.ardMachineConfig[mf.mc.amEnableHyd] = Properties.Vehicle.Default.setArdMac_isHydEnabled;
        }

        private void btnSendToMachineArduino_Click(object sender, EventArgs e)
        {
            SaveSettings();
            
            mf.TimedMessageBox(1000, gStr.gsMachinePort, gStr.gsModuleConfiguration);
            mf.SendArduinoSettingsOutMachinePort();
        }

        private void btnSendToSteerArduino_Click(object sender, EventArgs e)
        {
            SaveSettings();

            if (tabcArduino.SelectedTab.Name == "tabAutoSteer")
            {
                mf.TimedMessageBox(1000, gStr.gsAutoSteerPort, gStr.gsModuleConfiguration);
                mf.SendArduinoSettingsOutToAutoSteerPort();
            }
            else if (tabcArduino.SelectedTab.Name == "tabMachine")
            {
                mf.TimedMessageBox(1000, gStr.gsMachinePort, gStr.gsModuleConfiguration);
                mf.SendArduinoSettingsOutMachinePort();
            }
        }

        private void nudMaxSpeed_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void nudMinSpeed_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void nudMaxCounts_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tboxSerialFromAutoSteer.Text = mf.mc.serialRecvAutoSteerStr;
            tboxSerialFromMachine.Text = mf.mc.serialRecvMachineStr;
            if (Properties.Settings.Default.setUDP_isOn)
            {
                tboxSerialFromAutoSteer.Text = "UDP";
                tboxSerialFromMachine.Text = "UDP";
            }

            if (mf.checksumSent - mf.checksumRecd == 0)
            {
                lblSent.BackColor = Color.LightGreen;
                lblRecd.BackColor = Color.LightGreen;
            }
            else
            {
                lblSent.BackColor = Color.Salmon;
                lblRecd.BackColor = Color.Salmon;
            }

            lblSent.Text = mf.checksumSent.ToString();
            lblRecd.Text = mf.checksumRecd.ToString();
        }

        private void nudRaiseTime_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void nudLowerTime_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void nudAckerman_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }
    }
}