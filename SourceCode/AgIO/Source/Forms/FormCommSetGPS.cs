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


            //load the port box with valid port names
            cboxPort.Items.Clear();
            cboxPort2.Items.Clear();
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                cboxPort.Items.Add(s);
                cboxPort2.Items.Add(s);
            }

            lblCurrentBaud.Text = mf.spGPS.BaudRate.ToString();
            lblCurrentPort.Text = mf.spGPS.PortName;

            lblCurrentBaud2.Text = mf.spGPS2.BaudRate.ToString();
            lblCurrentPort2.Text = mf.spGPS2.PortName;

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

            if (mf.spModule1.IsOpen)
            {
                cboxModule1Port.Enabled = false;
                btnCloseSerialModule1.Enabled = true;
                btnOpenSerialModule1.Enabled = false;
            }
            else
            {
                cboxModule1Port.Enabled = true;
                btnCloseSerialModule1.Enabled = false;
                btnOpenSerialModule1.Enabled = true;
            }

            //check if AutoSteer port is open or closed and set buttons accordingly
            if (mf.spModule2.IsOpen)
            {
                cboxModule2Port.Enabled = false;
                btnCloseSerialModule2.Enabled = true;
                btnOpenSerialModule2.Enabled = false;
            }
            else
            {
                cboxModule2Port.Enabled = true;
                btnCloseSerialModule2.Enabled = false;
                btnOpenSerialModule2.Enabled = true;
            }

            if (mf.spModule3.IsOpen)
            {
                cboxModule3Port.Enabled = false;
                btnCloseSerialModule3.Enabled = true;
                btnOpenSerialModule3.Enabled = false;
            }
            else
            {
                cboxModule3Port.Enabled = true;
                btnCloseSerialModule3.Enabled = false;
                btnOpenSerialModule3.Enabled = true;
            }

            //load the port box with valid port names
            cboxModule1Port.Items.Clear();
            cboxModule2Port.Items.Clear();
            cboxModule3Port.Items.Clear();
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                cboxModule1Port.Items.Add(s);
                cboxModule2Port.Items.Add(s);
                cboxModule3Port.Items.Add(s);
            }

            lblCurrentModule1Port.Text = mf.spModule1.PortName;
            lblCurrentModule2Port.Text = mf.spModule2.PortName;
            lblCurrentModule3Port.Text = mf.spModule3.PortName;
        }

        #region PortSettings //----------------------------------------------------------------

        //AutoSteer

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
            lblSteer.Text = mf.spModule1.PortName;
            lblGPS.Text = mf.spGPS.PortName;
            lblIMU.Text = mf.spIMU.PortName;
            lblMachine.Text = mf.spModule2.PortName;

            lblFromGPS.Text = mf.traffic.cntrGPSIn == 0 ? "--" : (mf.traffic.cntrGPSIn).ToString();

            lblFromModule1.Text = mf.traffic.cntrModule1In == 0 ? "--" : (mf.traffic.cntrModule1In).ToString();

            lblFromModule2.Text = mf.traffic.cntrModule2In == 0 ? "--" : (mf.traffic.cntrModule2In).ToString();

            lblFromMU.Text = mf.traffic.cntrIMUIn == 0 ? "--" : (mf.traffic.cntrIMUIn).ToString();

        }

        private void btnSerialOK_Click(object sender, EventArgs e)
        {
            //save
            //DialogResult = DialogResult.OK;
            Close();
        }

        private void btnRescan_Click(object sender, EventArgs e)
        {
            cboxPort.Items.Clear();
            cboxPort2.Items.Clear();
            cboxIMU.Items.Clear();
            cboxModule3Port.Items.Clear();
            cboxModule1Port.Items.Clear();
            cboxModule2Port.Items.Clear();

            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                cboxPort.Items.Add(s);
                cboxPort2.Items.Add(s);
                cboxIMU.Items.Add(s);
                cboxModule1Port.Items.Add(s);
                cboxModule2Port.Items.Add(s);
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

        private void btnOpenSerialModule1_Click(object sender, EventArgs e)
        {
            mf.OpenModule1Port();
            if (mf.spModule1.IsOpen)
            {
                cboxModule1Port.Enabled = false;
                btnCloseSerialModule1.Enabled = true;
                btnOpenSerialModule1.Enabled = false;
                lblCurrentModule1Port.Text = mf.spModule1.PortName;
            }
            else
            {
                cboxModule1Port.Enabled = true;
                btnCloseSerialModule1.Enabled = false;
                btnOpenSerialModule1.Enabled = true;
            }
        }

        private void btnCloseSerialModule1_Click(object sender, EventArgs e)
        {
            mf.CloseModule1Port();
            if (mf.spModule1.IsOpen)
            {
                cboxModule1Port.Enabled = false;
                btnCloseSerialModule1.Enabled = true;
                btnOpenSerialModule1.Enabled = false;
            }
            else
            {
                cboxModule1Port.Enabled = true;
                btnCloseSerialModule1.Enabled = false;
                btnOpenSerialModule1.Enabled = true;
            }
        }

        private void cboxModule1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.spModule1.PortName = cboxModule1Port.Text;
            FormLoop.portNameModule1 = cboxModule1Port.Text;
            lblCurrentModule1Port.Text = cboxModule1Port.Text;
        }

        private void cboxModule2Port_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.spModule2.PortName = cboxModule2Port.Text;
            FormLoop.portNameModule2 = cboxModule2Port.Text;
            lblCurrentModule2Port.Text = cboxModule2Port.Text;
        }

        private void btnOpenSerialModule2_Click(object sender, EventArgs e)
        {
            mf.OpenModule2Port();
            if (mf.spModule2.IsOpen)
            {
                cboxModule2Port.Enabled = false;
                btnCloseSerialModule2.Enabled = true;
                btnOpenSerialModule2.Enabled = false;
                lblCurrentModule2Port.Text = mf.spModule2.PortName;
            }
            else
            {
                cboxModule2Port.Enabled = true;
                btnCloseSerialModule2.Enabled = false;
                btnOpenSerialModule2.Enabled = true;
            }
        }

        private void btnCloseSerialModule2_Click(object sender, EventArgs e)
        {
            mf.CloseModule2Port();
            if (mf.spModule2.IsOpen)
            {
                cboxModule2Port.Enabled = false;
                btnCloseSerialModule2.Enabled = true;
                btnOpenSerialModule2.Enabled = false;
            }
            else
            {
                cboxModule2Port.Enabled = true;
                btnCloseSerialModule2.Enabled = false;
                btnOpenSerialModule2.Enabled = true;
            }
        }

        private void cboxModule3Port_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.spModule3.PortName = cboxModule3Port.Text;
            FormLoop.portNameModule3 = cboxModule3Port.Text;
            lblCurrentModule3Port.Text = cboxModule3Port.Text;
        }

        private void btnOpenSerialModule3_Click(object sender, EventArgs e)
        {
            mf.OpenModule3Port();
            if (mf.spModule3.IsOpen)
            {
                cboxModule3Port.Enabled = false;
                btnCloseSerialModule3.Enabled = true;
                btnOpenSerialModule3.Enabled = false;
                lblCurrentModule3Port.Text = mf.spModule3.PortName;
            }
            else
            {
                cboxModule3Port.Enabled = true;
                btnCloseSerialModule3.Enabled = false;
                btnOpenSerialModule3.Enabled = true;
            }
        }

        private void btnCloseSerialModule3_Click(object sender, EventArgs e)
        {
            mf.CloseModule3Port();
            if (mf.spModule3.IsOpen)
            {
                cboxModule3Port.Enabled = false;
                btnCloseSerialModule3.Enabled = true;
                btnOpenSerialModule3.Enabled = false;
            }
            else
            {
                cboxModule3Port.Enabled = true;
                btnCloseSerialModule3.Enabled = false;
                btnOpenSerialModule3.Enabled = true;
            }
        }
    } //class
} //namespace
