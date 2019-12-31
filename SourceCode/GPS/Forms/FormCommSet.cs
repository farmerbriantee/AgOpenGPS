using System;
using System.Linq;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormCommSet : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        //constructor
        public FormCommSet(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();
            btnOpenSerial.Text = gStr.gsConnect;
            btnOpenSerialArduino.Text = gStr.gsConnect;
            btnOpenSerialAutoSteer.Text = gStr.gsConnect;
            btnCloseSerial.Text = gStr.gsDisconnect;
            btnCloseSerialArduino.Text = gStr.gsDisconnect;
            btnCloseSerialAutoSteer.Text = gStr.gsDisconnect;
            btnRescan.Text = gStr.gsRescanPorts;

            label3.Text = gStr.gsToAutoSteer;
            label6.Text = gStr.gsFromAutoSteer;
            label2.Text = gStr.gsToSectionPort;
            label15.Text = gStr.gsFromSectionPort;

            groupBox1.Text = gStr.gsGPSPort;
            groupBox3.Text = gStr.gsAutoSteerPort;
            groupBox2.Text = gStr.gsSectionPort;

            lblCurrentArduinoPort.Text = gStr.gsPort;
            lblCurrentPort.Text = gStr.gsPort;
            lblCurrentAutoSteerPort.Text = gStr.gsPort;
            lblCurrentBaud.Text = gStr.gsBaud;

        }

        private void FormCommSet_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.setGPS_fixFromWhichSentence == "GGA") rbtnGGA.Checked = true;
            else if (Properties.Settings.Default.setGPS_fixFromWhichSentence == "RMC") rbtnRMC.Checked = true;
            else if (Properties.Settings.Default.setGPS_fixFromWhichSentence == "OGI") rbtnOGI.Checked = true;

            cboxNMEAHz.Text = Properties.Settings.Default.setPort_NMEAHz.ToString();
            usejrk.Checked = Properties.Settings.Default.setAS_isJRK  ;

            //check if GPS port is open or closed and set buttons accordingly
            if (mf.sp.IsOpen)
            {
                cboxBaud.Enabled = false;
                cboxPort.Enabled = false;
                btnCloseSerial.Enabled = true;
                btnOpenSerial.Enabled = false;
            }
            else
            {
                cboxBaud.Enabled = true;
                cboxPort.Enabled = true;
                btnCloseSerial.Enabled = false;
                btnOpenSerial.Enabled = true;
            }

            //check if Arduino port is open or closed and set buttons accordingly
            if (mf.spRelay.IsOpen)
            {
                cboxArdPort.Enabled = false;
                btnCloseSerialArduino.Enabled = true;
                btnOpenSerialArduino.Enabled = false;
            }
            else
            {
                cboxArdPort.Enabled = true;
                btnCloseSerialArduino.Enabled = false;
                btnOpenSerialArduino.Enabled = true;
            }

            //check if AutoSteer port is open or closed and set buttons accordingly
            if (mf.spAutoSteer.IsOpen)
            {
                cboxASPort.Enabled = false;
                btnCloseSerialAutoSteer.Enabled = true;
                btnOpenSerialAutoSteer.Enabled = false;
            }
            else
            {
                cboxASPort.Enabled = true;
                btnCloseSerialAutoSteer.Enabled = false;
                btnOpenSerialAutoSteer.Enabled = true;
            }

            //load the port box with valid port names
            cboxPort.Items.Clear();
            cboxArdPort.Items.Clear();
            cboxASPort.Items.Clear();
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames())
            {
                cboxPort.Items.Add(s);
                cboxArdPort.Items.Add(s);
                cboxASPort.Items.Add(s);
            }

            lblCurrentBaud.Text = mf.sp.BaudRate.ToString();
            lblCurrentPort.Text = mf.sp.PortName;
            lblCurrentArduinoPort.Text = mf.spRelay.PortName;
            lblCurrentAutoSteerPort.Text = mf.spAutoSteer.PortName;
        }

        #region PortSettings //----------------------------------------------------------------

        //AutoSteer
        private void cboxASPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.spAutoSteer.PortName = cboxASPort.Text;
            FormGPS.portNameAutoSteer = cboxASPort.Text;
            lblCurrentAutoSteerPort.Text = cboxASPort.Text;
        }

        private void btnOpenSerialAutoSteer_Click(object sender, EventArgs e)
        {
            mf.SerialPortAutoSteerOpen();
            if (mf.spAutoSteer.IsOpen)
            {
                cboxASPort.Enabled = false;
                btnCloseSerialAutoSteer.Enabled = true;
                btnOpenSerialAutoSteer.Enabled = false;
                lblCurrentAutoSteerPort.Text = mf.spAutoSteer.PortName;
            }
            else
            {
                cboxASPort.Enabled = true;
                btnCloseSerialAutoSteer.Enabled = false;
                btnOpenSerialAutoSteer.Enabled = true;
            }
        }

        private void btnCloseSerialAutoSteer_Click(object sender, EventArgs e)
        {
            mf.SerialPortAutoSteerClose();
            if (mf.spAutoSteer.IsOpen)
            {
                cboxASPort.Enabled = false;
                btnCloseSerialAutoSteer.Enabled = true;
                btnOpenSerialAutoSteer.Enabled = false;
            }
            else
            {
                cboxASPort.Enabled = true;
                btnCloseSerialAutoSteer.Enabled = false;
                btnOpenSerialAutoSteer.Enabled = true;
            }
        }

        // Arduino
        private void btnOpenSerialArduino_Click(object sender, EventArgs e)
        {
            mf.SerialPortRelayOpen();
            if (mf.spRelay.IsOpen)
            {
                cboxArdPort.Enabled = false;
                btnCloseSerialArduino.Enabled = true;
                btnOpenSerialArduino.Enabled = false;
                lblCurrentArduinoPort.Text = mf.spRelay.PortName;
            }
            else
            {
                cboxArdPort.Enabled = true;
                btnCloseSerialArduino.Enabled = false;
                btnOpenSerialArduino.Enabled = true;
            }
        }

        private void btnCloseSerialArduino_Click(object sender, EventArgs e)
        {
            mf.SerialPortRelayClose();
            if (mf.spRelay.IsOpen)
            {
                cboxArdPort.Enabled = false;
                btnCloseSerialArduino.Enabled = true;
                btnOpenSerialArduino.Enabled = false;
            }
            else
            {
                cboxArdPort.Enabled = true;
                btnCloseSerialArduino.Enabled = false;
                btnOpenSerialArduino.Enabled = true;
            }
        }

        private void cboxArdPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.spRelay.PortName = cboxArdPort.Text;
            FormGPS.portNameRelaySection = cboxArdPort.Text;
            lblCurrentArduinoPort.Text = cboxArdPort.Text;
        }

        // GPS Serial Port
        private void cboxBaud_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            mf.sp.BaudRate = Convert.ToInt32(cboxBaud.Text);
            FormGPS.baudRateGPS = Convert.ToInt32(cboxBaud.Text);
        }

        private void cboxPort_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            mf.sp.PortName = cboxPort.Text;
            FormGPS.portNameGPS = cboxPort.Text;
        }

        private void cboxNMEAHz_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.setPort_NMEAHz = Convert.ToInt32(cboxNMEAHz.SelectedItem);
            Properties.Settings.Default.Save();
            mf.fixUpdateHz = Properties.Settings.Default.setPort_NMEAHz;
        }

        private void btnOpenSerial_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.setMenu_isSimulatorOn)
            {
                MessageBox.Show(gStr.gsGotoTopMenuDisplayTouchSimulator + "\n\r" + gStr.gsApplicationWillRestart, gStr.gsSimulatorOnMustbeOFF, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                mf.SerialPortOpenGPS();
                if (mf.sp.IsOpen)
                {
                    cboxBaud.Enabled = false;
                    cboxPort.Enabled = false;
                    btnCloseSerial.Enabled = true;
                    btnOpenSerial.Enabled = false;
                    lblCurrentBaud.Text = mf.sp.BaudRate.ToString();
                    lblCurrentPort.Text = mf.sp.PortName;
                }
                else
                {
                    cboxBaud.Enabled = true;
                    cboxPort.Enabled = true;
                    btnCloseSerial.Enabled = false;
                    btnOpenSerial.Enabled = true;
                }
            }
        }

        private void btnCloseSerial_Click(object sender, EventArgs e)
        {
            mf.SerialPortCloseGPS();
            if (mf.sp.IsOpen)
            {
                cboxBaud.Enabled = false;
                cboxPort.Enabled = false;
                btnCloseSerial.Enabled = true;
                btnOpenSerial.Enabled = false;
            }
            else
            {
                cboxBaud.Enabled = true;
                cboxPort.Enabled = true;
                btnCloseSerial.Enabled = false;
                btnOpenSerial.Enabled = true;
            }
        }

        private void btnRescan_Click(object sender, EventArgs e)
        {
            cboxASPort.Items.Clear();
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames()) { cboxASPort.Items.Add(s); }

            cboxArdPort.Items.Clear();
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames()) { cboxArdPort.Items.Add(s); }

            cboxPort.Items.Clear();
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames()) { cboxPort.Items.Add(s); }
        }

        #endregion PortSettings //----------------------------------------------------------------

        private void timer1_Tick(object sender, EventArgs e)
        {
            //GPS phrase
            textBoxRcv.Text = mf.recvSentenceSettings;
            //mf.recvSentenceSettings = "";

            //RateRelay phrases
            txtBoxRecvArduino.Text = mf.mc.serialRecvRelayStr;
            txtBoxSendArduino.Text = "32762, "
                 + mf.mc.relayData[2] + "," + mf.mc.relayData[3] + "," + mf.mc.relayData[4]//relay hi lo and speed x 4
                 + "," + mf.mc.relayData[5] + "," + mf.mc.relayData[6] + "," + mf.mc.relayData[7]; //setpoint hi lo
            //autoSteer phrases
            txtBoxRecvAutoSteer.Text = mf.mc.serialRecvAutoSteerStr;
            txtBoxSendAutoSteer.Text = "32766, " + mf.mc.autoSteerData[mf.mc.sdRelayLo] + ", " + mf.mc.autoSteerData[mf.mc.sdSpeed]
                                    + ", " + mf.guidanceLineDistanceOff + ", " + mf.guidanceLineSteerAngle + ", " + mf.mc.machineControlData[mf.mc.cnYouTurn];
        }

        private void btnSerialOK_Click(object sender, EventArgs e)
        {
            //save
            DialogResult = DialogResult.OK;
            Close();
        }

        private void rbtnGGA_CheckedChanged(object sender, EventArgs e)
        {
            var checkedButton = groupBox4.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            Properties.Settings.Default.setGPS_fixFromWhichSentence = checkedButton.Text;
            Properties.Settings.Default.Save();
            mf.pn.fixFrom = checkedButton.Text;
        }

        private void usejrk_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.setAS_isJRK = usejrk.Checked;
            Properties.Settings.Default.Save();
            mf.isJRK = Properties.Settings.Default.setAS_isJRK;
        }
    } //class
} //namespace