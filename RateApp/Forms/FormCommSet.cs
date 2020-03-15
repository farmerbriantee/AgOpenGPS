using System;
using System.Linq;
using System.Windows.Forms;

namespace RateApp
{
    public partial class FormCommSet : Form
    {
        //class variables
        private readonly FormRate mf = null;

        //constructor
        public FormCommSet(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormRate;
            InitializeComponent();

            //btnOpenSerial.Text = gStr.gsConnect;
            //btnOpenSerialArduino.Text = gStr.gsConnect;
            //btnOpenSerialAutoSteer.Text = gStr.gsConnect;
            //btnCloseSerial.Text = gStr.gsDisconnect;
            //btnCloseSerialArduino.Text = gStr.gsDisconnect;
            //btnCloseSerialAutoSteer.Text = gStr.gsDisconnect;
            //btnRescan.Text = gStr.gsRescanPorts;

            //label3.Text = gStr.gsToAutoSteer;
            //label6.Text = gStr.gsFromAutoSteer;
            //label2.Text = gStr.gsToMachinePort;
            //label15.Text = gStr.gsFromMachinePort;

            //groupBox1.Text = gStr.gsGPSPort;
            //groupBox3.Text = gStr.gsAutoSteerPort;
            //groupBox2.Text = gStr.gsMachinePort;

            //lblCurrentArduinoPort.Text = gStr.gsPort;
            //lblCurrentPort.Text = gStr.gsPort;
            //lblCurrentAutoSteerPort.Text = gStr.gsPort;
            //lblCurrentBaud.Text = gStr.gsBaud;

        }

        private void FormCommSet_Load(object sender, EventArgs e)
        {
            //check if port is open or closed and set buttons accordingly
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

            //load the port box with valid port names
            cboxPort.Items.Clear();
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames())
            {
                cboxPort.Items.Add(s);
            }

            lblCurrentBaud.Text = mf.sp.BaudRate.ToString();
            lblCurrentPort.Text = mf.sp.PortName;
        }

        #region PortSettings //----------------------------------------------------------------

        // Serial Port
        private void cboxBaud_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            mf.sp.BaudRate = Convert.ToInt32(cboxBaud.Text);
            FormRate.baudRate = Convert.ToInt32(cboxBaud.Text);
        }

        private void cboxPort_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            mf.sp.PortName = cboxPort.Text;
            FormRate.portName = cboxPort.Text;
        }

        private void btnOpenSerial_Click(object sender, EventArgs e)
        {
            {
                mf.SerialPortOpen();
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
            mf.SerialPortClose();
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
            cboxPort.Items.Clear();
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames()) { cboxPort.Items.Add(s); }
        }

        #endregion PortSettings //----------------------------------------------------------------

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBoxRcv.Text = mf.recvSentenceSettings;
            //mf.recvSentenceSettings = "";
        }

        private void btnSerialOK_Click(object sender, EventArgs e)
        {
            //save
            DialogResult = DialogResult.OK;
            Close();
        }

    } //class
} //namespace