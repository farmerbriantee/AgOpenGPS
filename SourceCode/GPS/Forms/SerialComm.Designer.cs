//Please, if you use this, share the improvements

using System.IO.Ports;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;

namespace AgOpenGPS
{
    public partial class FormGPS
    {
        public static string portNameGPS = "COM GPS";
        public static int baudRateGPS = 4800;

        public static string portNameRelaySection = "COM Sect";
        public static int baudRateRelaySection = 38400;

        public static string portNameAutoSteer = "COM AS";
        public static int baudRateAutoSteer = 38400;

        //private string[] words;

        public string NMEASentence = "No Data";

        //used to decide to autoconnect section arduino this run
        public bool wasRateRelayConnectedLastRun = false;
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

        public void AutoSteerDataOutToPort()
        {
            //Tell Arduino the steering parameter values
            if (spAutoSteer.IsOpen)
            {
                try { spAutoSteer.Write(mc.autoSteerData, 0, CModuleComm.numSteerDataItems); }
                catch (Exception e)
                {
                    WriteErrorLog("Out Data to Steering Port " + e.ToString());
                    SerialPortAutoSteerClose();
                }
            }
 
        }

        public void AutoSteerSettingsOutToPort()
        {
            //Tell Arduino autoSteer settings
            if (spAutoSteer.IsOpen)
            {
                try { spAutoSteer.Write(mc.autoSteerSettings, 0, CModuleComm.numSteerSettingItems ); }
                catch (Exception e)
                {
                    WriteErrorLog("Out Settings to Steer Port " + e.ToString());
                    SerialPortAutoSteerClose();
                }
            }
        }

        //called by the AutoSteer module delegate every time a chunk is rec'd
        private void SerialLineReceivedAutoSteer(string sentence)
        {
            //spit it out no matter what it says
            mc.serialRecvAutoSteerStr = sentence;

            //0 - steer angle, 1 - pwm, 2 - heading in degrees * 16, 3 - roll in degrees * 16, 4 - steerSwitch position

            string[] words = mc.serialRecvAutoSteerStr.Split(',');
            if (words.Length == 5)
            {
                //first 2 used for display mainly in autosteer window chart as strings
                //parse the values
                mc.prevGyroHeading = mc.gyroHeading;
                int.TryParse(words[2], out mc.gyroHeading);
                int.TryParse(words[3], out mc.rollRaw);
                int.TryParse(words[4], out mc.steerSwitchValue);
            }
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
                    System.Threading.Thread.Sleep(25);
                    string sentence = spAutoSteer.ReadLine();
                    this.BeginInvoke(new LineReceivedEventHandlerAutoSteer(SerialLineReceivedAutoSteer), sentence);
                }
                //this is bad programming, it just ignores errors until its hooked up again.
                catch (Exception ex)
                {
                    WriteErrorLog("AutoSteer Recv" + ex.ToString());
                }

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
            catch (Exception e)
            {
                WriteErrorLog("Opening Steer Port" + e.ToString());

                MessageBox.Show(e.Message + "\n\r" + "\n\r" + "Go to Settings -> COM Ports to Fix", "No AutoSteer Port Active");

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
                catch (Exception e)
                {
                    WriteErrorLog("Closing steer Port" + e.ToString());
                    MessageBox.Show(e.Message, "Connection already terminated??");
                }

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
        private void BuildRelayByte()
        {
            byte set = 1;
            byte reset = 254;
            mc.relayRateData[mc.rdSectionControlByte] = (byte)0;

            //check if super section is on
            if (section[vehicle.numOfSections].isSectionOn)
            {
                mc.relayRateData[mc.rdSectionControlByte] = (byte)0;
                for (int j = 0; j < vehicle.numOfSections; j++)
                {
                    //all the sections are on, so set them
                    mc.relayRateData[mc.rdSectionControlByte] 
                        = (byte)(mc.relayRateData[mc.rdSectionControlByte] | set);

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
                    if (section[j].isSectionOn) mc.relayRateData[mc.rdSectionControlByte] 
                            = (byte)(mc.relayRateData[mc.rdSectionControlByte] | set);
                    else mc.relayRateData[mc.rdSectionControlByte] = (byte)(mc.relayRateData[mc.rdSectionControlByte] & reset);

                    //move set and reset over 1 bit left
                    set = (byte)(set << 1);
                    reset = (byte)(reset << 1);
                    reset = (byte)(reset + 1);
                }
            }

            mc.autoSteerData[mc.sdRelay] = (byte)(mc.relayRateData[mc.rdSectionControlByte]);
        }

        //Send relay info out to relay board
        public void RateRelayOutToPort(byte[] items, int numItems)
        {
            //Tell Arduino to turn section on or off accordingly
            if (spRelay.IsOpen)
            {
                try { spRelay.Write(items, 0, numItems ); }
                catch (Exception e)
                {
                    WriteErrorLog("Out to Section relays" + e.ToString());
                    SerialPortRateRelayClose();
                }
            }
        }

        //Arduino port called by the Relay delegate every time
        private void SerialLineReceivedRateRelay(string sentence)
        {
            mc.serialRecvRelayRateStr = sentence;
            int end;

            // Find end of sentence, if not a CR, return
            end = sentence.IndexOf("\r");
            if (end == -1) return;

            //the ArdRelay sentence to be parsed
            sentence = sentence.Substring(0, end);
            string[] words = sentence.Split(',');
            if (words.Length < 4) return;

            //fill in the holes
            //int.TryParse(words[0], out mc);
            int.TryParse(words[1], out mc.incomingInt);
            rc.rateActual = (double)mc.incomingInt/100.0;

            int.TryParse(words[2], out mc.incomingInt);
            rc.volumeActual = mc.incomingInt;

            //int.TryParse(words[3], out mc.);

        }

        //the delegate for thread
        private delegate void LineReceivedEventHandlerRelay(string sentence);

        //Arduino serial port receive in its own thread
        private void sp_DataReceivedRateRelay(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (spRelay.IsOpen)
            {
                try
                {
                    System.Threading.Thread.Sleep(25);
                    string sentence = spRelay.ReadLine();
                    this.BeginInvoke(new LineReceivedEventHandlerRelay(SerialLineReceivedRateRelay), sentence);                    
                    if (spRelay.BytesToRead > 8) spRelay.DiscardInBuffer();
                }
                //this is bad programming, it just ignores errors until its hooked up again.
                catch (Exception ex)
                {
                    WriteErrorLog("Relay Data Recvd " + ex.ToString());
                }

            }
        }

        //open the Arduino serial port
        public void SerialPortRateRelayOpen()
        {
            if (!spRelay.IsOpen)
            {
                spRelay.PortName = portNameRelaySection;
                spRelay.BaudRate = baudRateRelaySection;
                spRelay.DataReceived += sp_DataReceivedRateRelay;
            }

            try { spRelay.Open(); }
            catch (Exception e)
            {
                WriteErrorLog("Opening Relay Port" + e.ToString());

                MessageBox.Show(e.Message + "\n\r" + "\n\r" + "Go to Settings -> COM Ports to Fix", "No Arduino Port Active");

                //update port status label
                stripPortArduino.Text = "* *";
                stripOnlineArduino.Value = 1;
                stripPortArduino.ForeColor = Color.Red;

                Properties.Settings.Default.setPort_wasRateRelayConnected = false;
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


                Properties.Settings.Default.setPort_portNameRateRelay = portNameRelaySection;
                Properties.Settings.Default.setPort_wasRateRelayConnected = true;
                Properties.Settings.Default.Save();
            }
        }

        public void SerialPortRateRelayClose()
        {
            if (spRelay.IsOpen)
            {
                spRelay.DataReceived -= sp_DataReceivedRateRelay;
                try { spRelay.Close(); }
                catch (Exception e)
                {
                    WriteErrorLog("Closing Relay Serial Port" + e.ToString());
                    MessageBox.Show(e.Message, "Connection already terminated??");
                }

                //update port status label
                stripPortArduino.Text = "* *";
                stripOnlineArduino.Value = 1;
                stripPortArduino.ForeColor = Color.Red;

                Properties.Settings.Default.setPort_wasRateRelayConnected = false;
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
                catch (Exception ex)
                {
                    WriteErrorLog("GPS Data Recv" + e.ToString());

                    MessageBox.Show(ex.Message + "\n\r" + "\n\r" + "Go to Settings -> COM Ports to Fix", "ComPort Failure!");
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
            catch (Exception e)
            {
                //MessageBox.Show(exc.Message + "\n\r" + "\n\r" + "Go to Settings -> COM Ports to Fix", "No Serial Port Active");
                WriteErrorLog("Open GPS Port " + e.ToString());

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
                catch (Exception e)
                {
                    WriteErrorLog("Closing GPS Port" + e.ToString());
                    MessageBox.Show(e.Message, "Connection already terminated?");
                }

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