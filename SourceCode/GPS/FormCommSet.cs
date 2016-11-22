using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormCommSet : Form
    {
      //class variables
        private FormGPS mf = null;

        //constructor
        public FormCommSet(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void FormCommSet_Load(object sender, EventArgs e)
        {
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
            if (mf.spArduino.IsOpen)
            {
                cboxPortArduino.Enabled = false;
                btnCloseSerialArduino.Enabled = true;
                btnOpenSerialArduino.Enabled = false;
            }

            else
            {
                cboxPortArduino.Enabled = true;
                btnCloseSerialArduino.Enabled = false;
                btnOpenSerialArduino.Enabled = true;
            }

            //load the port box with valid port names
            cboxPort.Items.Clear();
            cboxPortArduino.Items.Clear();
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames())
            {
                cboxPort.Items.Add(s);
                cboxPortArduino.Items.Add(s);
            }
        

            lblCurrentBaud.Text = mf.sp.BaudRate.ToString();
            lblCurrentPort.Text = mf.sp.PortName;
            lblCurrentArduinoPort.Text = mf.spArduino.PortName;
            nudNMEAHz.Value = Properties.Settings.Default.setPort_NMEAHz;

        }


        #region PortSettings //----------------------------------------------------------------

        private void nudNMEAHz_ValueChanged(object sender, EventArgs e)
        {
            mf.rmcUpdateHz = (int)nudNMEAHz.Value;
        }

        // Arduino 
        private void btnRescanArduino_Click(object sender, EventArgs e)
        {
            cboxPortArduino.Items.Clear();
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames()) { cboxPortArduino.Items.Add(s); }

        }

        private void btnOpenSerialArduino_Click(object sender, EventArgs e)
        {
            mf.SerialPortOpenArduino();
            if (mf.spArduino.IsOpen)
            {
                cboxPortArduino.Enabled = false;
                btnCloseSerialArduino.Enabled = true;
                btnOpenSerialArduino.Enabled = false;
                lblCurrentArduinoPort.Text = mf.spArduino.PortName;
            }

            else
            {
                cboxPortArduino.Enabled = true;
                btnCloseSerialArduino.Enabled = false;
                btnOpenSerialArduino.Enabled = true;
            }

        }

        private void btnCloseSerialArduino_Click(object sender, EventArgs e)
        {
            mf.SerialPortCloseArduino();
            if (mf.spArduino.IsOpen)
            {
                cboxPortArduino.Enabled = false;
                btnCloseSerialArduino.Enabled = true;
                btnOpenSerialArduino.Enabled = false;
            }

            else
            {
                cboxPortArduino.Enabled = true;
                btnCloseSerialArduino.Enabled = false;
                btnOpenSerialArduino.Enabled = true;
            }

        }

        private void cboxPortArduino_SelectedIndexChanged(object sender, EventArgs e)
        {

            mf.spArduino.PortName = cboxPortArduino.Text;
            FormGPS.portNameArduino = cboxPortArduino.Text;

        }

        // GPS Serial Port

         private void cboxBaud_SelectedIndexChanged_1(object sender, EventArgs e)
        {
             mf.sp.BaudRate = Convert.ToInt32(cboxBaud.Text);
            FormGPS.baudRate = Convert.ToInt32(cboxBaud.Text);
       
        }

        private void cboxPort_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            mf.sp.PortName = cboxPort.Text;
            FormGPS.portName = cboxPort.Text;
        }

        private void btnOpenSerial_Click(object sender, EventArgs e)
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
            cboxPort.Items.Clear();
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames()) { cboxPort.Items.Add(s); }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //GPS phrase
            textBoxRcv.Text = mf.recvSentenceSettings;
            mf.recvSentenceSettings = "";

            //Arduino phrase
            txtBoxRecvArduino.Text += mf.recvSentenceSettingsArduino;
            mf.recvSentenceSettingsArduino = "";

            if (txtBoxRecvArduino.TextLength > 40) txtBoxRecvArduino.Text = "";

        }

        #endregion PortSettings

        private void btnSerialOK_Click(object sender, EventArgs e)
        {
            //serial Ports  -  mostly done directly-------------------
            Properties.Settings.Default.setPort_NMEAHz = mf.rmcUpdateHz;

            //save
            Properties.Settings.Default.Save();

            //back to FormGPS
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnSerialCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }





    }
}
