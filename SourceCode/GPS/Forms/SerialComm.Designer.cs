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

        public static string portNameMachine = "COM Sect";
        public static int baudRateMachine = 38400;

        public static string portNameAutoSteer = "COM AS";
        public static int baudRateAutoSteer = 38400;

        public string NMEASentence = "No Data";

        //used to decide to autoconnect section arduino this run
        public bool wasRateMachineConnectedLastRun = false;
        public string recvSentenceSettings = "InitalSetting", lastRecvd = "";

        public byte checksumSent = 0;
        public byte checksumRecd = 0;

        //used to decide to autoconnect autosteer arduino this run
        public bool wasAutoSteerConnectedLastRun = false;

        //serial port gps is connected to
        public SerialPort spGPS = new SerialPort(portNameGPS, baudRateGPS, Parity.None, 8, StopBits.One);

        //serial port Arduino is connected to
        public SerialPort spMachine = new SerialPort(portNameMachine, baudRateMachine, Parity.None, 8, StopBits.One);

        //serial port AutoSteer is connected to
        public SerialPort spAutoSteer = new SerialPort(portNameAutoSteer, baudRateAutoSteer, Parity.None, 8, StopBits.One);

        #region AutoSteerPort // --------------------------------------------------------------------
        private void SerialLineReceivedAutoSteer(string sentence)
        {
            //spit it out no matter what it says
            mc.serialRecvAutoSteerStr = sentence;
            if (pbarSteer++ > 98) pbarSteer=0;

            // Find end of sentence and a comma, if not a CR, return
            int end = sentence.IndexOf("\r");
            if (end == -1) return;
            end = sentence.IndexOf(",", StringComparison.Ordinal);
            if (end == -1) return;

            //the sentence to be parsed
            string[] words = sentence.Split(',');

            if (words.Length != 10) return; // check lenght: 2 byte header + 8 byte data

            int incomingInt = 0;
            int.TryParse(words[0], out incomingInt);

            if (incomingInt == 127)
            {
                int.TryParse(words[1], out incomingInt);

                switch (incomingInt)
                {
                    // 127,253, 2 - actual steer angle*100, 3 - setpoint steer angle*100, 4 - heading in degrees * 16, 
                    //5 - roll in degrees * 16, 6 - steerSwitch position,pwmDisplay,,;
                    case 253:  //PGN 127 253: AutoSteer main sentence 

                        double.TryParse(words[2], NumberStyles.Float, CultureInfo.InvariantCulture, out actualSteerAngleDisp);

                        //first 2 used for display mainly in autosteer window chart as strings
                        //parse the values
                        if (ahrs.isHeadingCorrectionFromAutoSteer)
                        {
                            int.TryParse(words[4], NumberStyles.Float, CultureInfo.InvariantCulture, out ahrs.correctionHeadingX16);
                        }

                        if (ahrs.isRollFromAutoSteer) int.TryParse(words[5], NumberStyles.Float, CultureInfo.InvariantCulture, out ahrs.rollX16);

                        int.TryParse(words[6], out mc.steerSwitchValue);
                        mc.workSwitchValue = mc.steerSwitchValue & 1;
                        mc.steerSwitchValue = mc.steerSwitchValue & 2;

                        int.TryParse(words[7], out mc.pwmDisplay);

                        break;

                    // 127,230, 2=checksum, 8 = ino version
                    case 230: 

                        byte.TryParse(words[2], out checksumRecd);

                        if (checksumRecd != checksumSent)
                        {
                            MessageBox.Show(
                                "Sent: " + checksumSent + "\r\n Recieved: " + checksumRecd,
                                    "Checksum Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }

                        if (words[3] != inoVersionStr)
                        {
                            Form af = Application.OpenForms["FormSteer"];

                            if (af != null)
                            {
                                af.Focus();
                                af.Close();
                            }

                            af = Application.OpenForms["FormArduinoSettings"];

                            if (af != null)
                            {
                                af.Focus();
                                af.Close();
                            }

                            //spAutoSteer.Close();
                            MessageBox.Show("Arduino INO Is Wrong Version \r\n Upload AutoSteer_USB_" + currentVersionStr + ".ino", gStr.gsFileError,
                                                MessageBoxButtons.OK, MessageBoxIcon.Question);
                            Close();
                        }

                        break;
                }
            }
        }

        //Arduino serial port receive in its own thread
        private void sp_DataReceivedAutoSteer(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (spAutoSteer.IsOpen)
            {
                //if (!Properties.Settings.Default.setAS_isJRK)
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
                //else   //get 2 byte feedback from pololu

                //{


                //    byte[] buffer = new byte[2];
                //    spAutoSteer.Read(buffer, 0, 2);
                //    int feedback = buffer[0] + 256 * buffer[1];

                //    actualSteerAngleDisp = feedback - 2047;
                //    actualSteerAngleDisp += (Properties.Settings.Default.setAS_steerAngleOffset - 127) * 5;
                //    actualSteerAngleDisp /= Properties.Settings.Default.setAS_countsPerDegree;
                //    actualSteerAngleDisp *= 100;                               
                //}
            }
        }

        public void SendOutUSBAutoSteerPort(byte[] items, int numItems)
        {
            //add the out of bounds bit to uturn byte bit 7
            if (mc.isOutOfBounds)
                mc.machineData[mc.mdUTurn] |= 0b10000000;
            else
                mc.machineData[mc.mdUTurn] &= 0b01111111;

            if (spAutoSteer.IsOpen)
            {
                try { spAutoSteer.Write(items, 0, numItems); }
                catch (Exception e)
                {
                    WriteErrorLog("Out Data to Steering Port " + e.ToString());
                    SerialPortAutoSteerClose();
                }
            }
        }

        public void SendSteerSettingsOutAutoSteerPort()
        {
            //Tell Arduino autoSteer settings
            if (spAutoSteer.IsOpen)
            {
                try { spAutoSteer.Write(mc.autoSteerSettings, 0, CModuleComm.pgnSentenceLength); }
                catch (Exception e)
                {
                    WriteErrorLog("Out Settings to Steer Port " + e.ToString());
                    SerialPortAutoSteerClose();
                }
            }

            //send out to udp network
            else if (Properties.Settings.Default.setUDP_isOn)
            {
                SendUDPMessage(mc.autoSteerSettings);
            }


            checksumSent = 0;
            for (int i = 2; i < 10; i++)
            {
                checksumSent += mc.autoSteerSettings[i];
            }
        }

        public void SendArduinoSettingsOutToAutoSteerPort()
        {
            //Tell Arduino autoSteer settings
            if (spAutoSteer.IsOpen)
            {
                try { spAutoSteer.Write(mc.ardSteerConfig, 0, CModuleComm.pgnSentenceLength); }
                catch (Exception e)
                {
                    WriteErrorLog("Out Arduino Settings to Steer Port " + e.ToString());
                    SerialPortAutoSteerClose();
                }
            }

            //send out to udp network
            else if (Properties.Settings.Default.setUDP_isOn)
            {
                SendUDPMessage(mc.ardSteerConfig);
            }

            checksumSent = 0;
            for (int i = 2; i < 10; i++)
            {
                checksumSent += mc.ardSteerConfig[i];
            }
        }

        //called by the AutoSteer module delegate every time a chunk is rec'd
        public double actualSteerAngleDisp = 0;

        //the delegate for thread
        private delegate void LineReceivedEventHandlerAutoSteer(string sentence);

        //open the Arduino serial port
        public void SerialPortAutoSteerOpen()
        {
            if (!spAutoSteer.IsOpen)
            {
                spAutoSteer.PortName = portNameAutoSteer;
                spAutoSteer.BaudRate = baudRateAutoSteer;
                spAutoSteer.DataReceived += sp_DataReceivedAutoSteer;
                spAutoSteer.DtrEnable = true;
                spAutoSteer.RtsEnable = true;
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

        #region MachineSerialPort //--------------------------------------------------------------------

        //build the byte for individual realy control
        private void BuildMachineByte()
        {
            int set = 1;
            int reset = 2046;
            mc.machineData[mc.mdSectionControlByteHi] = (byte)0;
            mc.machineData[mc.mdSectionControlByteLo] = (byte)0;

            int machine = 0;

            //check if super section is on
            if (section[tool.numOfSections].isSectionOn)
            {
                for (int j = 0; j < tool.numOfSections; j++)
                {
                    //all the sections are on, so set them
                    machine = machine | set;
                    set = (set << 1);
                }
            }

            else
            {
                for (int j = 0; j < MAXSECTIONS; j++)
                {
                    //set if on, reset bit if off
                    if (section[j].isSectionOn) machine = machine | set;
                    else machine = machine & reset;

                    //move set and reset over 1 bit left
                    set = (set << 1);
                    reset = (reset << 1);
                    reset = (reset + 1);
                }
            }

            //rate port gets high and low byte
            mc.machineData[mc.mdSectionControlByteHi] = unchecked((byte)(machine >> 8));
            mc.machineData[mc.mdSectionControlByteLo] = unchecked((byte)machine);

            //autosteer gets only the first 8 sections
            //mc.autoSteerData[mc.sdMachineLo] = unchecked((byte)(mc.machineData[mc.rdSectionControlByteLo]));
        }

        //Send machine info out to machine board
        public void SendOutUSBMachinePort(byte[] items, int numItems)
        {
            //load the uturn byte with the accumulated spacing
            if (vehicle.treeSpacing != 0) mc.machineData[mc.mdTree] = unchecked((byte)treeTrigger);

            //speed
            mc.machineData[mc.mdSpeedXFour] = unchecked((byte)(pn.speed * 4));
            
            //Tell Arduino to turn section on or off accordingly
            if (spMachine.IsOpen)
            {
                try { spMachine.Write(items, 0, numItems); }
                catch (Exception e)
                {
                    WriteErrorLog("Out to Section machines" + e.ToString());
                    SerialPortMachineClose();
                }
            }
        }

        public void SendArduinoSettingsOutMachinePort()
        {
            //Tell Arduino autoSteer settings
            if (spMachine.IsOpen)
            {
                try { spMachine.Write(mc.ardMachineConfig, 0, CModuleComm.pgnSentenceLength); }
                catch (Exception e)
                {
                    WriteErrorLog("Out Settings to Machine Port " + e.ToString());
                    SerialPortAutoSteerClose();
                }
            }

            //send out to udp network
            else if (Properties.Settings.Default.setUDP_isOn)
            {
                SendUDPMessage(mc.ardMachineConfig);
            }
        }

        private void SerialLineReceivedMachine(string sentence)
        {
            mc.serialRecvMachineStr = sentence;
            if (pbarMachine++ > 99) pbarMachine = 0;

            // Find end of sentence, if not a CR, return
            int end = sentence.IndexOf("\r");
            if (end == -1) return;
            end = sentence.IndexOf(",", StringComparison.Ordinal);
            if (end == -1) return;

            //the ArdMachine sentence to be parsed
            //sentence = sentence.Substring(0, end);
            string[] words = sentence.Split(',');

            if (words.Length != 10) return; // check lenght: 2 byte header + 8 byte data

            // MTZ8302 Feb 2020
            int incomingInt = 0;

            int.TryParse(words[0], out incomingInt);

            if (incomingInt == 127)
            {
                int.TryParse(words[1], out incomingInt);

                switch (incomingInt)
                {
                    case 249:  //PGN 127 249: Switch status from Section Control 

                        mc.ss[mc.swHeaderLo] = 249;

                        int.TryParse(words[5], out incomingInt);
                        mc.ss[mc.swONHi] = (byte)incomingInt;

                        int.TryParse(words[6], out incomingInt);
                        mc.ss[mc.swONLo] = (byte)incomingInt;

                        //read SectSWOffToAOG from Arduino
                        int.TryParse(words[7], out incomingInt);
                        mc.ss[mc.swOFFHi] = (byte)incomingInt;

                        int.TryParse(words[8], out incomingInt);
                        mc.ss[mc.swOFFLo] = (byte)incomingInt;

                        //read MainSW+RateSW
                        int.TryParse(words[9], out incomingInt);
                        mc.ss[mc.swMain] = (byte)incomingInt;

                        break;

                    case 224:    //PGN 127 224 F7E0: Back From MAchine Module
                        break;
                }
            }
        }

        //the delegate for thread
        private delegate void LineReceivedEventHandlerMachine(string sentence);

        //Arduino serial port receive in its own thread
        private void sp_DataReceivedMachine(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (spMachine.IsOpen)
            {
                try
                {
                    //System.Threading.Thread.Sleep(25);
                    string sentence = spMachine.ReadLine();
                    this.BeginInvoke(new LineReceivedEventHandlerMachine(SerialLineReceivedMachine), sentence);                    
                    if (spMachine.BytesToRead > 32) spMachine.DiscardInBuffer();
                }
                //this is bad programming, it just ignores errors until its hooked up again.
                catch (Exception ex)
                {
                    WriteErrorLog("Machine Data Recvd " + ex.ToString());
                }

            }
        }

        //open the Arduino serial port
        public void SerialPortMachineOpen()
        {
            if (!spMachine.IsOpen)
            {
                spMachine.PortName = portNameMachine;
                spMachine.BaudRate = baudRateMachine;
                spMachine.DataReceived += sp_DataReceivedMachine;
                spMachine.DtrEnable = true;
                spMachine.RtsEnable = true;
            }

            try { spMachine.Open(); }
            catch (Exception e)
            {
                WriteErrorLog("Opening Machine Port" + e.ToString());

                MessageBox.Show(e.Message + "\n\r" + "\n\r" + "Go to Settings -> COM Ports to Fix", "No Arduino Port Active");


                Properties.Settings.Default.setPort_wasMachineConnected = false;
                Properties.Settings.Default.Save();
            }

            if (spMachine.IsOpen)
            {
                spMachine.DiscardOutBuffer();
                spMachine.DiscardInBuffer();

                Properties.Settings.Default.setPort_portNameMachine = portNameMachine;
                Properties.Settings.Default.setPort_wasMachineConnected = true;
                Properties.Settings.Default.Save();
            }
        }

        //close the machine port
        public void SerialPortMachineClose()
        {
            if (spMachine.IsOpen)
            {
                spMachine.DataReceived -= sp_DataReceivedMachine;
                try { spMachine.Close(); }
                catch (Exception e)
                {
                    WriteErrorLog("Closing Machine Serial Port" + e.ToString());
                    MessageBox.Show(e.Message, "Connection already terminated??");
                }

                Properties.Settings.Default.setPort_wasMachineConnected = false;
                Properties.Settings.Default.Save();

                spMachine.Dispose();
            }
        }
        #endregion

        #region GPS SerialPort //--------------------------------------------------------------------------

        //called by the GPS delegate every time a chunk is rec'd
        private void SerialLineReceived(string sentence)
        {
            //spit it out no matter what it says
            pn.rawBuffer += sentence;
            if (isLogNMEA)
            {
                pn.logNMEASentence.Append(sentence);
            }
            
            //recvSentenceSettings = sbNMEAFromGPS.ToString();
        }

        private delegate void LineReceivedEventHandler(string sentence);

        //serial port receive in its own thread
        private void sp_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (spGPS.IsOpen)
            {
                try
                {
                    //give it a sec to spit it out
                    //System.Threading.Thread.Sleep(2000);

                    //read whatever is in port
                    string sentence = spGPS.ReadExisting();
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

            if (spGPS.IsOpen)
            {
                simulatorOnToolStripMenuItem.Checked = false;
                panelSim.Visible = false;
                timerSim.Enabled = false;

                Settings.Default.setMenu_isSimulatorOn = simulatorOnToolStripMenuItem.Checked;
                Settings.Default.Save();
            }


            if (!spGPS.IsOpen)
            {
                spGPS.PortName = portNameGPS;
                spGPS.BaudRate = baudRateGPS;
                spGPS.DataReceived += sp_DataReceived;
                spGPS.WriteTimeout = 1000;
            }

            try { spGPS.Open(); }
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

            if (spGPS.IsOpen)
            {
                //btnOpenSerial.Enabled = false;

                //discard any stuff in the buffers
                spGPS.DiscardOutBuffer();
                spGPS.DiscardInBuffer();

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
                spGPS.DataReceived -= sp_DataReceived;
                try { spGPS.Close(); }
                catch (Exception e)
                {
                    WriteErrorLog("Closing GPS Port" + e.ToString());
                    MessageBox.Show(e.Message, "Connection already terminated?");
                }

                //update port status labels
                //stripPortGPS.Text = " * * " + baudRateGPS.ToString();
                //stripPortGPS.ForeColor = Color.ForestGreen;
                //stripOnlineGPS.Value = 1;
                spGPS.Dispose();
            }
        }

        #endregion SerialPortGPS

    }//end class
}//end namespace