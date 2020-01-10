//Please, if you use this, share the improvements

using System.IO.Ports;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using AgOpenGPS.Properties;

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

        public bool isJRK;

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

        #region AutoSteerPort // --------------------------------------------------------------------

        public void AutoSteerDataOutToPort()
        {
            //default to a stop initially
            //mc.machineControlData[mc.cnPedalControl] &= 0b00111111;

            //if (isInAutoDrive) //Is in Auto Drive Mode enabled
            //{
            //    if (!ast.isInFreeDriveMode)
            //    {
            //        //make it go - or with 1
            //        if (recPath.isDrivingRecordedPath)
            //        {
            //            mc.machineControlData[mc.cnPedalControl] |= 0b11000000;
            //        }

            //        if (self.isSelfDriving)
            //        {
            //            mc.machineControlData[mc.cnPedalControl] |= 0b11000000;
            //        }
            //    }
            //    else //in AutoDrive and FreeDrive
            //    {
            //        mc.machineControlData[mc.cnPedalControl] |= 0b11000000;
            //    }

            //    ////Is there something in the way?
            //    //if (isLidarBtnOn && (mc.lidarDistance > 200 && mc.lidarDistance < 1000))
            //    //{
            //    //    mc.machineControlData[mc.cnPedalControl] &= 0b00111111;
            //    //}
            //}
            //else // Auto/Manual is in Manual so release the clutch only
            //{
            //    //release the clutch for manual driving
            //    mc.machineControlData[mc.cnPedalControl] |= 0b01000000;
            //    mc.machineControlData[mc.cnPedalControl] &= 0b01111111;
            //}

            ////pause the thing if paused. Duh.
            //if (recPath.isPausedDrivingRecordedPath)
            //{
            //    mc.machineControlData[mc.cnPedalControl] &= 0b00111111;
            //}

            ////gone out of bounds so full stop.
            //if (mc.isOutOfBounds)
            //{
            //    mc.machineControlData[mc.cnPedalControl] &= 0b00111111;
            //}

            //add the out of bounds bit to uturn byte bit 7
            if (mc.isOutOfBounds) 
                mc.autoSteerData[mc.sdYouTurnByte] |= 0b10000000;            
            else 
                mc.autoSteerData[mc.sdYouTurnByte] &= 0b01111111;

            //send out to network
            if (Properties.Settings.Default.setUDP_isOn)
            {
                //machine control
                //SendUDPMessage(mc.machineControlData);

                //send autosteer since it never is logic controlled
                SendUDPMessage(mc.autoSteerData);

                //rate control
                SendUDPMessage(mc.relayData);
            }

            //Tell Arduino the steering parameter values
            if (spAutoSteer.IsOpen)
            {
                if (isJRK)
                {
                    byte[] command = new byte[2];
                    int target;
                    target = guidanceLineSteerAngle * Properties.Settings.Default.setAS_countsPerDegree;
                    target /= 100;
                    target += ((Properties.Settings.Default.setAS_steerAngleOffset - 127) * 5); //steeroffstet                   
                    target += 2047; //steerangle center
                    
                    if (target > 4075) target = 4075;
                    if (target < 0) target = 0;
                    command[0] = unchecked((byte)(0xC0 + (target & 0x1F)));
                    command[1] = unchecked((byte)((target >> 5) & 0x7F));
                    spAutoSteer.Write(command, 0, 2);

                    ////send get scaledfeedback command
                    byte[] command2 = new byte[1];
                    command2[0] = 0xA7;

                    spAutoSteer.Write(command2, 0, 1);

                }
                else
                {
                    try { spAutoSteer.Write(mc.autoSteerData, 0, CModuleComm.pgnSentenceLength); }
                    catch (Exception e)
                    {
                        WriteErrorLog("Out Data to Steering Port " + e.ToString());
                        SerialPortAutoSteerClose();
                    }
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
                try { spAutoSteer.Write(mc.autoSteerSettings, 0, CModuleComm.pgnSentenceLength ); }
                catch (Exception e)
                {
                    WriteErrorLog("Out Settings to Steer Port " + e.ToString());
                    SerialPortAutoSteerClose();
                }
            }
        }

        //called by the AutoSteer module delegate every time a chunk is rec'd
        public double actualSteerAngleDisp = 0;

        private void SerialLineReceivedAutoSteer(string sentence)
        {
            //spit it out no matter what it says
            mc.serialRecvAutoSteerStr = sentence;

            //0 - actual steer angle*100, 1 - setpoint steer angle*100, 2 - heading in degrees * 16, 3 - roll in degrees * 16, 4 - steerSwitch position

            string[] words = mc.serialRecvAutoSteerStr.Split(',');
            if (words.Length == 5)
            {
                //update the progress bar for autosteer.
                if (pbarSteer++ > 99) pbarSteer=0;

                double.TryParse(words[0], NumberStyles.Float, CultureInfo.InvariantCulture, out actualSteerAngleDisp);
               

                //first 2 used for display mainly in autosteer window chart as strings
                //parse the values
                if (ahrs.isHeadingFromAutoSteer)
                {
                    int.TryParse(words[2], NumberStyles.Float, CultureInfo.InvariantCulture, out ahrs.correctionHeadingX16);
                }

                if (ahrs.isRollFromAutoSteer) int.TryParse(words[3], NumberStyles.Float, CultureInfo.InvariantCulture, out ahrs.rollX16);

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
                


                if (!Properties.Settings.Default.setAS_isJRK)
                {
                    try
                    {
                        //System.Threading.Thread.Sleep(25);
                        string sentence = spAutoSteer.ReadLine();
                        this.BeginInvoke(new LineReceivedEventHandlerAutoSteer(SerialLineReceivedAutoSteer), sentence);
                    }
                    //this is bad programming, it just ignores errors until its hooked up again.
                    catch (Exception ex)
                    {
                        WriteErrorLog("AutoSteer Recv" + ex.ToString());
                    }

                }
                else   //get 2 byte feedback from pololu

                {


                    byte[] buffer = new byte[2];
                    spAutoSteer.Read(buffer, 0, 2);
                    int feedback = buffer[0] + 256 * buffer[1];

                    actualSteerAngleDisp = feedback - 2047;
                    actualSteerAngleDisp += (Properties.Settings.Default.setAS_steerAngleOffset - 127) * 5;
                    actualSteerAngleDisp /= Properties.Settings.Default.setAS_countsPerDegree;
                    actualSteerAngleDisp *= 100;                               
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
            mc.relayData[mc.rdSectionControlByteHi] = (byte)0;
            mc.relayData[mc.rdSectionControlByteLo] = (byte)0;

            int relay = 0;

            //check if super section is on
            if (section[tool.numOfSections].isSectionOn)
            {
                for (int j = 0; j < tool.numOfSections; j++)
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
            mc.relayData[mc.rdSectionControlByteHi] = unchecked((byte)(relay >> 8));
            mc.relayData[mc.rdSectionControlByteLo] = unchecked((byte)relay);


            //autosteer gets only the first 8 sections
            mc.autoSteerData[mc.sdRelayLo] = unchecked((byte)(mc.relayData[mc.rdSectionControlByteLo]));
        }

        //Send relay info out to relay board
        public void RelayOutToPort(byte[] items, int numItems)
        {
            //load the uturn byte with the accumulated spacing
            if (vehicle.treeSpacing != 0) mc.relayData[mc.rdTree] = unchecked((byte)treeTrigger);

            //grab the youturn byte
            mc.relayData[mc.rdUTurn] = mc.machineControlData[mc.cnYouTurn];

            //speed
            mc.relayData[mc.rdSpeedXFour] = unchecked((byte)(pn.speed * 4));

            if (Properties.Settings.Default.setUDP_isOn)
            {
                SendUDPMessage(mc.relayData);
            }
            
            //Tell Arduino to turn section on or off accordingly
            if (spRelay.IsOpen)
            {
                try { spRelay.Write(items, 0, numItems); }
                catch (Exception e)
                {
                    WriteErrorLog("Out to Section relays" + e.ToString());
                    SerialPortRelayClose();
                }
            }
        }

        private void SerialLineReceivedRelay(string sentence)
        {
            mc.serialRecvRelayStr = sentence;
            int end;

            // Find end of sentence, if not a CR, return
            end = sentence.IndexOf("\r");
            if (end == -1) return;

            if (pbarRelay++ > 99) pbarRelay = 0;

            //the ArdRelay sentence to be parsed
            sentence = sentence.Substring(0, end);
            string[] words = sentence.Split(',');
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
                    //System.Threading.Thread.Sleep(25);
                    string sentence = spRelay.ReadLine();
                    this.BeginInvoke(new LineReceivedEventHandlerRelay(SerialLineReceivedRelay), sentence);                    
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
        public void SerialPortRelayOpen()
        {
            if (!spRelay.IsOpen)
            {
                spRelay.PortName = portNameRelaySection;
                spRelay.BaudRate = baudRateRelaySection;
                spRelay.DataReceived += sp_DataReceivedRelay;
            }

            try { spRelay.Open(); }
            catch (Exception e)
            {
                WriteErrorLog("Opening Relay Port" + e.ToString());

                MessageBox.Show(e.Message + "\n\r" + "\n\r" + "Go to Settings -> COM Ports to Fix", "No Arduino Port Active");


                Properties.Settings.Default.setPort_wasRelayConnected = false;
                Properties.Settings.Default.Save();
            }

            if (spRelay.IsOpen)
            {
                spRelay.DiscardOutBuffer();
                spRelay.DiscardInBuffer();

                Properties.Settings.Default.setPort_portNameRelay = portNameRelaySection;
                Properties.Settings.Default.setPort_wasRelayConnected = true;
                Properties.Settings.Default.Save();
            }
        }

        //close the relay port
        public void SerialPortRelayClose()
        {
            if (spRelay.IsOpen)
            {
                spRelay.DataReceived -= sp_DataReceivedRelay;
                try { spRelay.Close(); }
                catch (Exception e)
                {
                    WriteErrorLog("Closing Relay Serial Port" + e.ToString());
                    MessageBox.Show(e.Message, "Connection already terminated??");
                }

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
            //recvSentenceSettings = sbNMEAFromGPS.ToString();
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
                    //System.Threading.Thread.Sleep(2000);

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

            if (sp.IsOpen)
            {
                simulatorOnToolStripMenuItem.Checked = false;
                panelSim.Visible = false;
                timerSim.Enabled = false;

                Settings.Default.setMenu_isSimulatorOn = simulatorOnToolStripMenuItem.Checked;
                Settings.Default.Save();
            }


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
                //stripOnlineGPS.Value = 1;

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
                //stripOnlineGPS.Value = 1;
                sp.Dispose();
            }
        }

        #endregion SerialPortGPS

    }//end class
}//end namespace