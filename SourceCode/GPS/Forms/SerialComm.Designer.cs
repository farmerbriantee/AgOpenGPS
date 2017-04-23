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
        public static string portNameGPS = "COM GPS";
        public static int baudRateGPS = 4800;

        public static string portNameRelaySection = "COM Sect";
        public static int baudRateRelaySection = 19200;

        public static string portNameAutoSteer = "COM AS";
        public static int baudRateAutoSteer = 19200;

        private string[] words;

        //used to decide to autoconnect section arduino this run
        public bool wasSectionRelayConnectedLastRun = false;
        public string recvSentenceSettings = "InitalSetting";

        //used to decide to autoconnect autosteer arduino this run
        public bool wasAutoSteerConnectedLastRun = false;

        //serial port gps is connected to
        public SerialPort sp = new SerialPort(portNameGPS, baudRateGPS, Parity.None, 8, StopBits.One);

        //serial port Arduino is connected to
        public SerialPort spRelay = new SerialPort(portNameRelaySection, baudRateRelaySection, Parity.None, 8, StopBits.One);

        //serial port AutoSteer is connected to
        public SerialPort spAutoSteer = new SerialPort(portNameAutoSteer, baudRateAutoSteer, Parity.None, 8, StopBits.One);

        #region AutoSteerPort //--------------------------------------------------------------------

        public void AutoSteerControlOutToPort()
        {
            //Tell Arduino the steering parameter values
            if (spAutoSteer.IsOpen)
            {
                try { spAutoSteer.Write(modcom.autoSteerControl, 0, CModuleComm.numSteerControls); }
                catch (Exception) { SerialPortAutoSteerClose(); }
            }
 
        }

        public void AutoSteerSettingsOutToPort()
        {
            //Tell Arduino autoSteer settings
            if (spAutoSteer.IsOpen)
            {
                try { spAutoSteer.Write(modcom.autoSteerSettings, 0, CModuleComm.numSteerSettings ); }
                catch (Exception) { SerialPortAutoSteerClose(); }
            }
        }

        //called by the AutoSteer module delegate every time a chunk is rec'd
        private void SerialLineReceivedAutoSteer(string sentence)
        {
            //spit it out no matter what it says
            modcom.serialRecvAutoSteerStr = sentence;
        }

        //the delegate for thread
        private delegate void LineReceivedEventHandlerAutoSteer(string sentence);

        //Arduino serial port receive in its own thread
        private void sp_DataReceivedAutoSteer(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (spAutoSteer.IsOpen)
            {
                try
                {
                    System.Threading.Thread.Sleep(50);
                    string sentence = spAutoSteer.ReadLine();
                    this.BeginInvoke(new LineReceivedEventHandlerAutoSteer(SerialLineReceivedAutoSteer), sentence);
                }
                //this is bad programming, it just ignores errors until its hooked up again.
                catch (Exception) { }

            }
        }

        //open the Arduino serial port
        public void SerialPortAutoSteerOpen()
        {
            if (!spAutoSteer.IsOpen)
            {
                spAutoSteer.PortName = portNameAutoSteer;
                spAutoSteer.BaudRate = baudRateAutoSteer;
                spAutoSteer.DataReceived += sp_DataReceivedAutoSteer;
            }

            try { spAutoSteer.Open(); }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message + "\n\r" + "\n\r" + "Go to Settings -> COM Ports to Fix", "No AutoSteer Port Active");

                //update port status label
                stripPortAutoSteer.Text = "* *";
                stripOnlineAutoSteer.Value = 1;
                stripPortAutoSteer.ForeColor = Color.Red;

                Properties.Settings.Default.setPort_wasAutoSteerConnected = false;
                Properties.Settings.Default.Save();
            }

            if (spAutoSteer.IsOpen)
            {
                spAutoSteer.DiscardOutBuffer();
                spAutoSteer.DiscardInBuffer();

                //update port status label
                stripPortAutoSteer.Text = portNameAutoSteer;
                stripPortAutoSteer.ForeColor = Color.ForestGreen;
                stripOnlineAutoSteer.Value = 100;


                Properties.Settings.Default.setPort_portNameAutoSteer = portNameAutoSteer;
                Properties.Settings.Default.setPort_wasAutoSteerConnected = true;
                Properties.Settings.Default.Save();
            }
        }

        public void SerialPortAutoSteerClose()
        {
            if (spAutoSteer.IsOpen)
            {
                spAutoSteer.DataReceived -= sp_DataReceivedAutoSteer;
                try { spAutoSteer.Close(); }
                catch (Exception exc) { MessageBox.Show(exc.Message, "Connection already terminated??"); }

                //update port status label
                stripPortAutoSteer.Text = "* *";
                stripOnlineAutoSteer.Value = 1;
                stripPortAutoSteer.ForeColor = Color.Red;

                Properties.Settings.Default.setPort_wasAutoSteerConnected = false;
                Properties.Settings.Default.Save();

                spAutoSteer.Dispose();
            }

        }

        #endregion

        #region RelaySerialPort //--------------------------------------------------------------------

        //build the byte for individual realy control
        private void BuildSectionRelayByte()
        {
            byte set = 1;
            byte reset = 254;
            modcom.relaySectionControl[0] = (byte)0;

            if (section[vehicle.numOfSections].isSectionOn)
            {
                modcom.relaySectionControl[0] = (byte)0;
                for (int j = 0; j < vehicle.numOfSections; j++)
                {
                    //all the sections are on, so set them
                    modcom.relaySectionControl[0] = (byte)(modcom.relaySectionControl[0] | set);

                    //move set and reset over 1 bit left
                    set = (byte)(set << 1);
                    reset = (byte)(reset << 1);
                    reset = (byte)(reset + 1);
                }
            }

            else
            {
                for (int j = 0; j < MAXSECTIONS; j++)
                {
                    //set if on, reset bit if off
                    if (section[j].isSectionOn) modcom.relaySectionControl[0] = (byte)(modcom.relaySectionControl[0] | set);
                    else modcom.relaySectionControl[0] = (byte)(modcom.relaySectionControl[0] & reset);

                    //move set and reset over 1 bit left
                    set = (byte)(set << 1);
                    reset = (byte)(reset << 1);
                    reset = (byte)(reset + 1);
                }
            }

            modcom.autoSteerControl[2] = (byte)(modcom.relaySectionControl[0]);
        }

        //Send relay info out to relay board
        private void SectionControlOutToPort()
        {
            //Tell Arduino to turn section on or off accordingly
            if (spRelay.IsOpen)
            {
                try { spRelay.Write(modcom.relaySectionControl, 0, CModuleComm.numRelayControls ); }
                catch (Exception) { SerialPortRelayClose(); }
            }
        }

        //Arduino port called by the Relay delegate every time
        private void SerialLineReceivedRelay(string sentence)
        {
            modcom.serialRecvRelayStr = sentence;
            int end;
            //spit it out no matter what it says
            //modcom.serialRecvRelayStr = sentence;
            //if (sentence.Length < 8 ) return;


            // Find end of sentence
            end = sentence.IndexOf("\r\n");
            if (end == -1) return;

            //the ArdRelay sentence to be parsed
            sentence = sentence.Substring(0, end);

            words = sentence.Split(',');
            if (words.Length < 1) return;

                
            int.TryParse(words[0], out modcom.workSwitchValue);

            //double.TryParse(words[1], out modcom.rollAngle);
            //modcom.rollAngle *= 0.0625;

            //double.TryParse(words[2], out modcom.pitchAngle);
            //modcom.pitchAngle *= 0.0625;

            //double.TryParse(words[3], out modcom.angularVelocity);

            //if (modcom.pitchAngle > 10) modcom.pitchAngle = 10;
            //if (modcom.pitchAngle < -10) modcom.pitchAngle = -10;

            //if (modcom.rollAngle > 12) modcom.rollAngle = 12;
            //if (modcom.rollAngle < -12) modcom.rollAngle = -12;

            //double.TryParse(words[4], out modcom.imuHeading);
            //modcom.imuHeading *= 0.0625;

                

        }

        //the delegate for thread
        private delegate void LineReceivedEventHandlerRelay(string sentence);

        //Arduino serial port receive in its own thread
        private void sp_DataReceivedRelay(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (spRelay.IsOpen)
            {
                try
                {
                    System.Threading.Thread.Sleep(50);
                    string sentence = spRelay.ReadLine();
                    this.BeginInvoke(new LineReceivedEventHandlerRelay(SerialLineReceivedRelay), sentence);
                }
                //this is bad programming, it just ignores errors until its hooked up again.
                catch (Exception) { }

            }
        }

        //open the Arduino serial port
        public void SerialPortRelayOpen()
        {
            if (!spRelay.IsOpen)
            {
                spRelay.PortName = portNameRelaySection;
                spRelay.BaudRate = baudRateRelaySection;
                spRelay.DataReceived += sp_DataReceivedRelay;
            }

            try { spRelay.Open(); }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message + "\n\r" + "\n\r" + "Go to Settings -> COM Ports to Fix", "No Arduino Port Active");

                //update port status label
                stripPortArduino.Text = "* *";
                stripOnlineArduino.Value = 1;
                stripPortArduino.ForeColor = Color.Red;

                Properties.Settings.Default.setPort_wasRelayConnected = false;
                Properties.Settings.Default.Save();
            }

            if (spRelay.IsOpen)
            {
                spRelay.DiscardOutBuffer();
                spRelay.DiscardInBuffer();

                //update port status label
                stripPortArduino.Text = portNameRelaySection;
                stripPortArduino.ForeColor = Color.ForestGreen;
                stripOnlineArduino.Value = 100;


                Properties.Settings.Default.setPort_portNameRelay = portNameRelaySection;
                Properties.Settings.Default.setPort_wasRelayConnected = true;
                Properties.Settings.Default.Save();
            }
        }

        public void SerialPortRelayClose()
        {
            if (spRelay.IsOpen)
            {
                spRelay.DataReceived -= sp_DataReceivedRelay;
                try { spRelay.Close(); }
                catch (Exception exc) { MessageBox.Show(exc.Message, "Connection already terminated??"); }

                //update port status label
                stripPortArduino.Text = "* *";
                stripOnlineArduino.Value = 1;
                stripPortArduino.ForeColor = Color.Red;

                Properties.Settings.Default.setPort_wasRelayConnected = false;
                Properties.Settings.Default.Save();

                spRelay.Dispose();
            }

        }
        #endregion

        #region GPS SerialPort //--------------------------------------------------------------------------

        //called by the GPS delegate every time a chunk is rec'd
        private void SerialLineReceived(string sentence)
        {
            //spit it out no matter what it says
            pn.rawBuffer += sentence;
            recvSentenceSettings = pn.rawBuffer;
        }

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

        public void SerialPortOpenGPS()
        {
            //close it first
            SerialPortCloseGPS();

            if (!sp.IsOpen)
            {
                sp.PortName = portNameGPS;
                sp.BaudRate = baudRateGPS;
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
                stripPortGPS.Text = portNameGPS + " " + baudRateGPS.ToString();
                stripPortGPS.ForeColor = Color.ForestGreen;

                Properties.Settings.Default.setPort_portNameGPS = portNameGPS;
                Properties.Settings.Default.setPort_baudRate = baudRateGPS;
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
                stripPortGPS.Text = " * * " + baudRateGPS.ToString();
                stripPortGPS.ForeColor = Color.ForestGreen;
                stripOnlineGPS.Value = 1;

                sp.Dispose();
            }

        }

        #endregion SerialPortGPS

    }//end class
}//end namespace