using System;
using System.Windows.Forms;

namespace AgIO
{
    public partial class FormCommSetGPS : Form
    {
        //class variables
        private readonly FormLoop mf = null;

        //constructor
        public FormCommSetGPS(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormLoop;
            InitializeComponent();
        }

        private void FormCommSet_Load(object sender, EventArgs e)
        {
            //check if GPS port is open or closed and set buttons accordingly
            if (mf.spGPS.IsOpen)
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

            if (mf.spGPS2.IsOpen)
            {
                cboxBaud2.Enabled = false;
                cboxPort2.Enabled = false;
                btnCloseSerial2.Enabled = true;
                btnOpenSerial2.Enabled = false;
            }
            else
            {
                cboxBaud2.Enabled = true;
                cboxPort2.Enabled = true;
                btnCloseSerial2.Enabled = false;
                btnOpenSerial2.Enabled = true;
            }

            if (mf.spRtcm.IsOpen)
            {
                cboxRtcmBaud.Enabled = false;
                cboxRtcmPort.Enabled = false;
                btnCloseRTCM.Enabled = true;
                btnOpenRTCM.Enabled = false;
                labelRtcmBaud.Text = mf.spGPS.BaudRate.ToString();
                labelRtcmPort.Text = mf.spGPS.PortName;

            }
            else
            {
                cboxRtcmBaud.Enabled = true;
                cboxRtcmPort.Enabled = true;
                btnCloseRTCM.Enabled = false;
                btnOpenRTCM.Enabled = true;
                labelRtcmBaud.Text = "-";
                labelRtcmPort.Text = "-";

            }

            //load the port box with valid port names
            cboxPort.Items.Clear();
            cboxPort2.Items.Clear();
            cboxRtcmPort.Items.Clear();

            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                cboxPort.Items.Add(s);
                cboxPort2.Items.Add(s);
                cboxRtcmPort.Items.Add(s);
            }

            lblCurrentBaud.Text = mf.spGPS.BaudRate.ToString();
            lblCurrentPort.Text = mf.spGPS.PortName;

            lblCurrentBaud2.Text = mf.spGPS2.BaudRate.ToString();
            lblCurrentPort2.Text = mf.spGPS2.PortName;

            labelRtcmBaud.Text = mf.spRtcm.BaudRate.ToString();
            labelRtcmPort.Text = mf.spRtcm.PortName.ToString();

            if (mf.spIMU.IsOpen)
            {
                cboxIMU.Enabled = false;
                btnCloseIMU.Enabled = true;
                btnOpenIMU.Enabled = false;
            }
            else
            {
                cboxIMU.Enabled = true;
                btnCloseIMU.Enabled = false;
                btnOpenIMU.Enabled = true;
            }

            //load the port box with valid port names
            cboxIMU.Items.Clear();
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                cboxIMU.Items.Add(s);
            }

            lblCurrentIMU.Text = mf.spIMU.PortName;

            if (mf.spSteerModule.IsOpen)
            {
                cboxSteerModulePort.Enabled = false;
                btnCloseSerialSteerModule.Enabled = true;
                btnOpenSerialSteerModule.Enabled = false;
            }
            else
            {
                cboxSteerModulePort.Enabled = true;
                btnCloseSerialSteerModule.Enabled = false;
                btnOpenSerialSteerModule.Enabled = true;
            }

            //check if AutoSteer port is open or closed and set buttons accordingly
            if (mf.spMachineModule.IsOpen)
            {
                cboxMachineModulePort.Enabled = false;
                btnCloseSerialMachineModule.Enabled = true;
                btnOpenSerialMachineModule.Enabled = false;
            }
            else
            {
                cboxMachineModulePort.Enabled = true;
                btnCloseSerialMachineModule.Enabled = false;
                btnOpenSerialMachineModule.Enabled = true;
            }

            //if (mf.spModule3.IsOpen)
            //{
            //    cboxModule3Port.Enabled = false;
            //    btnCloseSerialModule3.Enabled = true;
            //    btnOpenSerialModule3.Enabled = false;
            //}
            //else
            //{
            //    cboxModule3Port.Enabled = true;
            //    btnCloseSerialModule3.Enabled = false;
            //    btnOpenSerialModule3.Enabled = true;
            //}

            //load the port box with valid port names
            cboxSteerModulePort.Items.Clear();
            cboxMachineModulePort.Items.Clear();
            //cboxModule3Port.Items.Clear();
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                cboxSteerModulePort.Items.Add(s);
                cboxMachineModulePort.Items.Add(s);
                //cboxModule3Port.Items.Add(s);
            }

            lblCurrentSteerModulePort.Text = mf.spSteerModule.PortName;
            lblCurrentMachineModulePort.Text = mf.spMachineModule.PortName;
            //lblCurrentModule3Port.Text = mf.spModule3.PortName;
        }

        #region PortSettings //----------------------------------------------------------------

        // GPS Serial Port
        private void cboxBaud_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            mf.spGPS.BaudRate = Convert.ToInt32(cboxBaud.Text);
            FormLoop.baudRateGPS = Convert.ToInt32(cboxBaud.Text);
        }
        private void cboxBaud2_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.spGPS2.BaudRate = Convert.ToInt32(cboxBaud2.Text);
            FormLoop.baudRateGPS2 = Convert.ToInt32(cboxBaud2.Text);
        }

        private void cboxPort_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            mf.spGPS.PortName = cboxPort.Text;
            FormLoop.portNameGPS = cboxPort.Text;
        }

        private void cboxPort2_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.spGPS2.PortName = cboxPort2.Text;
            FormLoop.portNameGPS2 = cboxPort2.Text;
        }

        private void btnOpenSerial_Click(object sender, EventArgs e)
        {
            mf.OpenGPSPort();
            if (mf.spGPS.IsOpen)
            {
                cboxBaud.Enabled = false;
                cboxPort.Enabled = false;
                btnCloseSerial.Enabled = true;
                btnOpenSerial.Enabled = false;
                lblCurrentBaud.Text = mf.spGPS.BaudRate.ToString();
                lblCurrentPort.Text = mf.spGPS.PortName;
            }
            else
            {
                cboxBaud.Enabled = true;
                cboxPort.Enabled = true;
                btnCloseSerial.Enabled = false;
                btnOpenSerial.Enabled = true;
                MessageBox.Show("Unable to connect to Port");
            }
        }

        private void btnCloseSerial_Click(object sender, EventArgs e)
        {
            mf.CloseGPSPort();
            if (mf.spGPS.IsOpen)
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

        private void btnOpenRTCM_Click(object sender, EventArgs e)
        {
            mf.OpenRtcmPort();
            if (mf.spRtcm.IsOpen)
            {
                cboxRtcmBaud.Enabled = false;
                cboxRtcmPort.Enabled = false;
                btnCloseRTCM.Enabled = true;
                btnOpenRTCM.Enabled = false;
                labelRtcmBaud.Text = mf.spRtcm.BaudRate.ToString();
                labelRtcmPort.Text = mf.spRtcm.PortName;
            }
            else
            {
                cboxRtcmBaud.Enabled = true;
                cboxRtcmPort.Enabled = true;
                btnCloseRTCM.Enabled = false;
                btnOpenRTCM.Enabled = true;
                MessageBox.Show("Unable to connect to Port");
            }
        }

        private void btnCloseRTCM_Click(object sender, EventArgs e)
        {
            mf.CloseRtcmPort();

            if (mf.spRtcm.IsOpen)
            {
                cboxRtcmBaud.Enabled = false;
                cboxRtcmPort.Enabled = false;
                btnCloseRTCM.Enabled = true;
                btnOpenRTCM.Enabled = false;
            }
            else
            {
                cboxRtcmBaud.Enabled = true;
                cboxRtcmPort.Enabled = true;
                btnCloseRTCM.Enabled = false;
                btnOpenRTCM.Enabled = true;
            }
        }

        private void btnOpenSerial2_Click(object sender, EventArgs e)
        {
            mf.OpenGPS2Port();
            if (mf.spGPS2.IsOpen)
            {
                cboxBaud2.Enabled = false;
                cboxPort2.Enabled = false;
                btnCloseSerial2.Enabled = true;
                btnOpenSerial2.Enabled = false;
                lblCurrentBaud2.Text = mf.spGPS.BaudRate.ToString();
                lblCurrentPort2.Text = mf.spGPS.PortName;
            }
            else
            {
                cboxBaud2.Enabled = true;
                cboxPort2.Enabled = true;
                btnCloseSerial2.Enabled = false;
                btnOpenSerial2.Enabled = true;
                MessageBox.Show("Unable to connect to Port");
            }
        }

        private void btnCloseSerial2_Click(object sender, EventArgs e)
        {
            mf.CloseGPS2Port();
            if (mf.spGPS2.IsOpen)
            {
                cboxBaud2.Enabled = false;
                cboxPort2.Enabled = false;
                btnCloseSerial2.Enabled = true;
                btnOpenSerial2.Enabled = false;
            }
            else
            {
                cboxBaud2.Enabled = true;
                cboxPort2.Enabled = true;
                btnCloseSerial2.Enabled = false;
                btnOpenSerial2.Enabled = true;
            }
        }

        #endregion PortSettings //----------------------------------------------------------------

        private void timer1_Tick(object sender, EventArgs e)
        {
            //GPS phrase
            textBoxRcv.Text = mf.recvGPSSentence;
            textBoxRcv2.Text = mf.recvGPS2Sentence;
            lblSteer.Text = mf.spSteerModule.PortName;
            lblGPS.Text = mf.spGPS.PortName;
            lblIMU.Text = mf.spIMU.PortName;
            lblMachine.Text = mf.spMachineModule.PortName;

            lblFromGPS.Text = mf.traffic.cntrGPSIn == 0 ? "--" : (mf.traffic.cntrGPSIn).ToString();
        }

        private void btnSerialOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRescan_Click(object sender, EventArgs e)
        {
            cboxPort.Items.Clear();
            cboxRtcmPort.Items.Clear();
            cboxPort2.Items.Clear();
            cboxIMU.Items.Clear();
            cboxSteerModulePort.Items.Clear();
            cboxMachineModulePort.Items.Clear();
            cboxModule3Port.Items.Clear();

            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                cboxPort.Items.Add(s);
                cboxPort2.Items.Add(s);
                cboxIMU.Items.Add(s);
                cboxRtcmPort.Items.Add(s);
                cboxSteerModulePort.Items.Add(s);
                cboxMachineModulePort.Items.Add(s);
                cboxModule3Port.Items.Add(s);
            }
        }

        private void btnClrGPS_Click(object sender, EventArgs e)
        {
            mf.CloseGPSPort();
            FormLoop.portNameGPS = "GPS 1";
            Properties.Settings.Default.setPort_portNameGPS = FormLoop.portNameGPS;
            Properties.Settings.Default.Save();
        }

        private void btnOpenIMU_Click(object sender, EventArgs e)
        {
            mf.OpenIMUPort();
            if (mf.spIMU.IsOpen)
            {
                cboxIMU.Enabled = false;
                btnCloseIMU.Enabled = true;
                btnOpenIMU.Enabled = false;
                lblCurrentIMU.Text = mf.spIMU.PortName;
            }
            else
            {
                cboxIMU.Enabled = true;
                btnCloseIMU.Enabled = false;
                btnOpenIMU.Enabled = true;
            }
        }

        private void btnCloseIMU_Click(object sender, EventArgs e)
        {
            mf.CloseIMUPort();
            if (mf.spIMU.IsOpen)
            {
                cboxIMU.Enabled = false;
                btnCloseIMU.Enabled = true;
                btnOpenIMU.Enabled = false;
            }
            else
            {
                cboxIMU.Enabled = true;
                btnCloseIMU.Enabled = false;
                btnOpenIMU.Enabled = true;
            }
        }

        private void cboxIMU_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.spIMU.PortName = cboxIMU.Text;
            FormLoop.portNameIMU = cboxIMU.Text;
            lblCurrentIMU.Text = cboxIMU.Text;
        }

        private void btnOpenSerialSteerModule_Click(object sender, EventArgs e)
        {
            mf.OpenSteerModulePort();
            if (mf.spSteerModule.IsOpen)
            {
                cboxSteerModulePort.Enabled = false;
                btnCloseSerialSteerModule.Enabled = true;
                btnOpenSerialSteerModule.Enabled = false;
                lblCurrentSteerModulePort.Text = mf.spSteerModule.PortName;
            }
            else
            {
                cboxSteerModulePort.Enabled = true;
                btnCloseSerialSteerModule.Enabled = false;
                btnOpenSerialSteerModule.Enabled = true;
            }
        }

        private void btnCloseSerialSteerModule_Click(object sender, EventArgs e)
        {
            mf.CloseSteerModulePort();
            if (mf.spSteerModule.IsOpen)
            {
                cboxSteerModulePort.Enabled = false;
                btnCloseSerialSteerModule.Enabled = true;
                btnOpenSerialSteerModule.Enabled = false;
            }
            else
            {
                cboxSteerModulePort.Enabled = true;
                btnCloseSerialSteerModule.Enabled = false;
                btnOpenSerialSteerModule.Enabled = true;
            }
        }

        private void cboxSteerModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.spSteerModule.PortName = cboxSteerModulePort.Text;
            FormLoop.portNameSteerModule = cboxSteerModulePort.Text;
            lblCurrentSteerModulePort.Text = cboxSteerModulePort.Text;
        }

        private void cboxMachineModulePort_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.spMachineModule.PortName = cboxMachineModulePort.Text;
            FormLoop.portNameMachineModule = cboxMachineModulePort.Text;
            lblCurrentMachineModulePort.Text = cboxMachineModulePort.Text;
        }

        private void btnOpenSerialMachineModule_Click(object sender, EventArgs e)
        {
            mf.OpenMachineModulePort();
            if (mf.spMachineModule.IsOpen)
            {
                cboxMachineModulePort.Enabled = false;
                btnCloseSerialMachineModule.Enabled = true;
                btnOpenSerialMachineModule.Enabled = false;
                lblCurrentMachineModulePort.Text = mf.spMachineModule.PortName;
            }
            else
            {
                cboxMachineModulePort.Enabled = true;
                btnCloseSerialMachineModule.Enabled = false;
                btnOpenSerialMachineModule.Enabled = true;
            }
        }

        private void btnCloseSerialMachineModule_Click(object sender, EventArgs e)
        {
            mf.CloseMachineModulePort();
            if (mf.spMachineModule.IsOpen)
            {
                cboxMachineModulePort.Enabled = false;
                btnCloseSerialMachineModule.Enabled = true;
                btnOpenSerialMachineModule.Enabled = false;
            }
            else
            {
                cboxMachineModulePort.Enabled = true;
                btnCloseSerialMachineModule.Enabled = false;
                btnOpenSerialMachineModule.Enabled = true;
            }
        }

        private void cboxModule3Port_SelectedIndexChanged(object sender, EventArgs e)
        {
            //mf.spModule3.PortName = cboxModule3Port.Text;
            //FormLoop.portNameModule3 = cboxModule3Port.Text;
            //lblCurrentModule3Port.Text = cboxModule3Port.Text;
        }

        private void btnOpenSerialModule3_Click(object sender, EventArgs e)
        {
            //mf.OpenModule3Port();
            //if (mf.spModule3.IsOpen)
            //{
            //    cboxModule3Port.Enabled = false;
            //    btnCloseSerialModule3.Enabled = true;
            //    btnOpenSerialModule3.Enabled = false;
            //    lblCurrentModule3Port.Text = mf.spModule3.PortName;
            //}
            //else
            //{
            //    cboxModule3Port.Enabled = true;
            //    btnCloseSerialModule3.Enabled = false;
            //    btnOpenSerialModule3.Enabled = true;
            //}
        }

        private void btnCloseSerialModule3_Click(object sender, EventArgs e)
        {
            //mf.CloseModule3Port();
            //if (mf.spModule3.IsOpen)
            //{
            //    cboxModule3Port.Enabled = false;
            //    btnCloseSerialModule3.Enabled = true;
            //    btnOpenSerialModule3.Enabled = false;
            //}
            //else
            //{
            //    cboxModule3Port.Enabled = true;
            //    btnCloseSerialModule3.Enabled = false;
            //    btnOpenSerialModule3.Enabled = true;
            //}
        }

        private void cboxRtcmPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.spRtcm.PortName = cboxRtcmPort.Text;
            FormLoop.portNameRtcm = cboxRtcmPort.Text;
        }

        private void cboxRtcmBaud_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.spRtcm.BaudRate = Convert.ToInt32(cboxRtcmBaud.Text);
            FormLoop.baudRateRtcm = Convert.ToInt32(cboxRtcmBaud.Text);
        }
    } //class
} //namespace
