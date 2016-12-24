//Please, if you use this, share the improvements

using System.IO.Ports;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SharpGL;
using System.Drawing;
using System.Text;
using System.Diagnostics;

namespace AgOpenGPS
{
    public partial class FormGPS
    {
        public static string portName = "COM GPS...";
        public static int baudRate = 4800;

        public static string portNameArduino = "COM SectionControl...";
        public static int baudRateArduino = 9600;

        //used to decide to autoconnect arduino this run
        public bool wasArduinoConnectedLastRun = false;

        public StringBuilder recvSentence = new StringBuilder();
        public StringBuilder recvSentenceArduino = new StringBuilder("SectionControl");

        public string recvSentenceSettings = "InitalSetting";
        public string recvSentenceSettingsArduino = "Section Control";

        //serial port gps is connected to
        public SerialPort sp = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);

        //serial port Arduino is connected to
        public SerialPort spArduino = new SerialPort(portNameArduino, baudRateArduino, Parity.None, 8, StopBits.One);

        //Send relay info out to relay board
        private void SectionControlOutToArduino()
        {
            if (!spArduino.IsOpen) return;

            byte set = 1;
            byte reset = 254;
            bufferArd[0] = 0;

            for (int j = 0; j < MAXSECTIONS; j++)
            {
                if (section[j].isSectionOn) bufferArd[0] = (byte)(bufferArd[0] | set);
                else bufferArd[0] = (byte)(bufferArd[0] & reset);

                set = (byte)(set << 1);

                reset = (byte)(reset << 1);
                reset = (byte)(reset + 1);
            }

            //Tell Arduino to turn section on or off accordingly
            if (spArduino.IsOpen)
            {
                try { spArduino.Write(bufferArd, 0, 1); }
                catch (Exception) { SerialPortCloseArduino(); }
            }
            else
            {
                bufferArd[0] = 0;

                try { spArduino.Write(bufferArd, 0, 1); }
                catch (Exception)
                {
                    SerialPortCloseArduino();
                }
                return;
            }


        }

        //called by the delegate every time a chunk is rec'd
        private void SerialLineReceived(string sentence)
        {
            //spit it out no matter what it says
            pn.rawBuffer += sentence;
            recvSentenceSettings = pn.rawBuffer;
        }

        //Arduino port called by the delegate every time
        private void SerialLineReceivedArduino(string sentence)
        {
            //spit it out no matter what it says
            recvSentenceArduino.Append(sentence);
            recvSentenceSettingsArduino = sentence;

            if (txtBoxRecvArduino.TextLength > 10) txtBoxRecvArduino.Text = "";
            txtBoxRecvArduino.Text += recvSentenceArduino;
        }

        #region ArduinoSerialPort //--------------------------------------------------------------------

        //the delegate for thread
        private delegate void LineReceivedEventHandlerArduino(string sentence);

        //Arduino serial port receive in its own thread
        private void sp_DataReceivedArduino(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (spArduino.IsOpen)
            {
                try
                {
                    System.Threading.Thread.Sleep(100);
                    string sentence = spArduino.ReadExisting();
                    this.BeginInvoke(new LineReceivedEventHandlerArduino(SerialLineReceivedArduino), sentence);
                }
                //this is bad programming, it just ignores errors until its hooked up again.
                catch (Exception) { }

            }
        }

        //open the Arduino serial port
        public void SerialPortOpenArduino()
        {
            if (!spArduino.IsOpen)
            {
                spArduino.PortName = portNameArduino;
                spArduino.BaudRate = baudRateArduino;
                spArduino.DataReceived += sp_DataReceivedArduino;
            }

            try { spArduino.Open(); }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message + "\n\r" + "\n\r" + "Go to Settings -> COM Ports to Fix", "No Arduino Port Active");

                //update port status label
                stripPortArduino.Text = "* *";
                stripOnlineArduino.Value = 1;
                stripPortArduino.ForeColor = Color.Red;

                Properties.Settings.Default.setPort_wasArduinoConnected = false;
                Properties.Settings.Default.Save();
            }

            if (spArduino.IsOpen)
            {
                spArduino.DiscardOutBuffer();
                spArduino.DiscardInBuffer();

                //update port status label
                stripPortArduino.Text = portNameArduino;
                stripPortArduino.ForeColor = Color.ForestGreen;
                stripOnlineArduino.Value = 100;


                Properties.Settings.Default.setPort_portNameArduino = portNameArduino;
                Properties.Settings.Default.setPort_wasArduinoConnected = true;
                Properties.Settings.Default.Save();
            }
        }

        public void SerialPortCloseArduino()
        {
            if (spArduino.IsOpen)
            {
                spArduino.DataReceived -= sp_DataReceivedArduino;
                try { spArduino.Close(); }
                catch (Exception exc) { MessageBox.Show(exc.Message, "Connection already terminated??"); }

                //update port status label
                stripPortArduino.Text = "* *";
                stripOnlineArduino.Value = 1;
                stripPortArduino.ForeColor = Color.Red;

                Properties.Settings.Default.setPort_wasArduinoConnected = false;
                Properties.Settings.Default.Save();

                spArduino.Dispose();
            }

        }
        #endregion


        #region GPS SerialPort //--------------------------------------------------------------------------

        private delegate void LineReceivedEventHandler(string sentence);

        //serial port receive in its own thread
        private void sp_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (sp.IsOpen)
            {
                try
                {
                    //give it a sec to spit it out
                    System.Threading.Thread.Sleep(50);

                    //read whatever is in port
                    string sentence = sp.ReadExisting();
                    this.BeginInvoke(new LineReceivedEventHandler(SerialLineReceived), sentence);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message + "\n\r" + "\n\r" + "Go to Settings -> COM Ports to Fix", "ComPort Failure!");
                }

            }

        }

        //Event Handlers
        //private void btnExit_Click(object sender, EventArgs e) { this.Exit(); }


        public void SerialPortOpenGPS()
        {
            //close it first
            SerialPortCloseGPS();

            if (!sp.IsOpen)
            {
                sp.PortName = portName;
                sp.BaudRate = baudRate;
                sp.DataReceived += sp_DataReceived;
                sp.WriteTimeout = 1000;
            }

            try { sp.Open(); }
            catch (Exception)
            {
                //MessageBox.Show(exc.Message + "\n\r" + "\n\r" + "Go to Settings -> COM Ports to Fix", "No Serial Port Active");

                //update port status labels
                stripPortGPS.Text = " * * ";
                stripPortGPS.ForeColor = Color.Red;
                stripOnlineGPS.Value = 1;

                //SettingsPageOpen(0);
            }

            if (sp.IsOpen)
            {
                //btnOpenSerial.Enabled = false;

                //discard any stuff in the buffers
                sp.DiscardOutBuffer();
                sp.DiscardInBuffer();

                //update port status label
                stripPortGPS.Text = portName + " " + baudRate.ToString();
                stripPortGPS.ForeColor = Color.ForestGreen;

                Properties.Settings.Default.setPort_portName = portName;
                Properties.Settings.Default.setPort_baudRate = baudRate;
                Properties.Settings.Default.Save();
            }
        }

        public void SerialPortCloseGPS()
        {
            //if (sp.IsOpen)
            {
                sp.DataReceived -= sp_DataReceived;
                try { sp.Close(); }
                catch (Exception exc) { MessageBox.Show(exc.Message, "Connection already terminated?"); }

                //update port status labels
                stripPortGPS.Text = " * * " + baudRate.ToString();
                stripPortGPS.ForeColor = Color.ForestGreen;
                stripOnlineGPS.Value = 1;

                sp.Dispose();
            }

        }

        #endregion SerialPortGPS

    }//end class
}//end namespace