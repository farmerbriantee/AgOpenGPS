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
            //load the uturn byte with the accumulated spacing
            if (vehicle.treeSpacing != 0) mc.autoSteerData[mc.sdYouTurnByte] = (byte)treeSpacingCounter;

            //default to a stop initially
            mc.machineControlData[mc.cnPedalControl] &= 0b00111111;

            if (isInAutoDrive) //Is in Auto Drive Mode enabled
            {
                if (!ast.isInFreeDriveMode)
                {
                    //make it go - or with 1
                    if (recPath.isDrivingRecordedPath)
                    {
                        mc.machineControlData[mc.cnPedalControl] |= 0b11000000;
                    }

                    if (self.isSelfDriving)
                    {
                        mc.machineControlData[mc.cnPedalControl] |= 0b11000000;
                    }
                }
                else //in AutoDrive and FreeDrive
                {
                    mc.machineControlData[mc.cnPedalControl] |= 0b11000000;
                }

                //Is there something in the way?
                if (isLidarBtnOn && (mc.lidarDistance > 200 && mc.lidarDistance < 1000))
                {
                    mc.machineControlData[mc.cnPedalControl] &= 0b00111111;
                }
            }
            else // Auto/Manual is in Manual so release the clutch only
            {
                //release the clutch for manual driving
                mc.machineControlData[mc.cnPedalControl] |= 0b01000000;
                mc.machineControlData[mc.cnPedalControl] &= 0b01111111;
            }

            //pause the thing if paused. Duh.
            if (recPath.isPausedDrivingRecordedPath)
            {
                mc.machineControlData[mc.cnPedalControl] &= 0b00111111;
            }

            //gone out of bounds so full stop.
            if (mc.isOutOfBounds)
            {
                mc.machineControlData[mc.cnPedalControl] &= 0b00111111;
            }

            //send out to network
            if (Properties.Settings.Default.setUDP_isOn)
            {
                //machine control
                SendUDPMessage(mc.machineControlData);

                //send autosteer since it never is logic controlled
                SendUDPMessage(mc.autoSteerData);

                //rate control
                if (rcd.isRateControlOn) SendUDPMessage(mc.relayRateData);
            }

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
            //send out the settings
            //send out to network
            if (Properties.Settings.Default.setUDP_isOn)
            {
                SendUDPMessage(mc.autoSteerSettings);
            }

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

        private double actualSteerAngleDisp = 0;

        private void SerialLineReceivedAutoSteer(string sentence)
        {
            //spit it out no matter what it says
            mc.serialRecvAutoSteerStr = sentence;

            //0 - actual steer angle*100, 1 - setpoint steer angle*100, 2 - heading in degrees * 16, 3 - roll in degrees * 16, 4 - steerSwitch position

            string[] words = mc.serialRecvAutoSteerStr.Split(',');
            if (words.Length == 5)
            {
                double.TryParse(words[0], out actualSteerAngleDisp);
               

                //first 2 used for display mainly in autosteer window chart as strings
                //parse the values
                if (ahrs.isHeadingBNO)
                {
                    mc.prevGyroHeading = mc.gyroHeading;
                    int.TryParse(words[2], out mc.gyroHeading);
                }

                if (ahrs.isRollDogs) int.TryParse(words[3], out mc.rollRaw);

                int.TryParse(words[4], out mc.steerSwitchValue);
                mc.workSwitchValue = mc.steerSwitchValue & 1;
                mc.steerSwitchValue = mc.steerSwitchValue & 2;
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

                Properties.Settings.Default.setPort_wasAutoSteerConnected = false;
                Properties.Settings.Default.Save();
            }

            if (spAutoSteer.IsOpen)
            {
                spAutoSteer.DiscardOutBuffer();
                spAutoSteer.DiscardInBuffer();

                //update port status label

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
            int set = 1;
            int reset = 2046;
            mc.relayRateData[mc.rdSectionControlByteHi] = (byte)0;
            mc.relayRateData[mc.rdSectionControlByteLo] = (byte)0;

            int relay = 0;

            //check if super section is on
            if (section[vehicle.numOfSections].isSectionOn)
            {
                for (int j = 0; j < vehicle.numOfSections; j++)
                {
                    //all the sections are on, so set them
                    relay = relay | set;
                    set = (set << 1);
                }
            }

            else
            {
                for (int j = 0; j < MAXSECTIONS; j++)
                {
                    //set if on, reset bit if off
                    if (section[j].isSectionOn) relay = relay | set;
                    else relay = relay & reset;

                    //move set and reset over 1 bit left
                    set = (set << 1);
                    reset = (reset << 1);
                    reset = (reset + 1);
                }
            }

            //rate port gets high and low byte
            mc.relayRateData[mc.rdSectionControlByteHi] = (byte)(relay >> 8);
            mc.relayRateData[mc.rdSectionControlByteLo] = (byte)relay;

            //autosteer gets only the first 8 sections
            mc.autoSteerData[mc.sdRelayLo] = (byte)(mc.relayRateData[mc.rdSectionControlByteLo]);
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

            //changed by MTZ8302
            if (words.Length != 8) return;

            //left or single actual rate
            int.TryParse(words[0], out mc.incomingInt);
            rcd.rateActualLeft = (double)mc.incomingInt * 0.01;

            //right actual rate
            int.TryParse(words[1], out mc.incomingInt);
            rcd.rateActualRight = (double)mc.incomingInt * 0.01;

            //Volume for dual and single
            int.TryParse(words[2], out mc.incomingInt);
            rcd.dualVolumeActual = mc.incomingInt;

            //added by MTZ8302 - Matthias Hammer Marbach a.N. Germany ---------------------------------------------------------
            //MTZ8302 April 2018
            //read RelayToAOG from Arduino
            int.TryParse(words[3], out mc.incomingInt);
            rcd.RelayFromArduinoHi = (byte)mc.incomingInt;
            int.TryParse(words[4], out mc.incomingInt);
            rcd.RelayFromArduinoLo = (byte)mc.incomingInt;
            //read SectSWOffToAOG from Arduino
            int.TryParse(words[5], out mc.incomingInt);
            rcd.SectSWOffFromArduinoHi = (byte)mc.incomingInt;
            int.TryParse(words[6], out mc.incomingInt);
            rcd.SectSWOffFromArduinoLo = (byte)mc.incomingInt;
            //read MainSW+RateSW
            int.TryParse(words[7], out mc.incomingInt);
            rcd.SectMainSWFromArduino = (byte)mc.incomingInt;
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
                    if (spRelay.BytesToRead > 32) spRelay.DiscardInBuffer();
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


                Properties.Settings.Default.setPort_wasRateRelayConnected = false;
                Properties.Settings.Default.Save();
            }

            if (spRelay.IsOpen)
            {
                spRelay.DiscardOutBuffer();
                spRelay.DiscardInBuffer();

                Properties.Settings.Default.setPort_portNameRateRelay = portNameRelaySection;
                Properties.Settings.Default.setPort_wasRateRelayConnected = true;
                Properties.Settings.Default.Save();
            }
        }

        //close the relay port
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
                    WriteErrorLog("GPS Data Recv" + ex.ToString());

                    //MessageBox.Show(ex.Message + "\n\r" + "\n\r" + "Go to Settings -> COM Ports to Fix", "ComPort Failure!");
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
                //WriteErrorLog("Open GPS Port " + e.ToString());

                //update port status labels
                //stripPortGPS.Text = " * * ";
                //stripPortGPS.ForeColor = Color.Red;
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
                //stripPortGPS.Text = portNameGPS + " " + baudRateGPS.ToString();
                //stripPortGPS.ForeColor = Color.ForestGreen;

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
                //stripPortGPS.Text = " * * " + baudRateGPS.ToString();
                //stripPortGPS.ForeColor = Color.ForestGreen;
                stripOnlineGPS.Value = 1;

                sp.Dispose();
            }

        }

        #endregion SerialPortGPS

    }//end class
}//end namespace