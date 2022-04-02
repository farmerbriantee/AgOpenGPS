using AgIO.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AgIO
{
    public partial class FormLoop : Form
    {
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr hWind, int nCmdShow);

        public string[] myCOMPorts = new string[0];

        // CH340B default:   VID_1A86 & PID_7523
        // Central Unit 2.0: VID_12D7 & PID_2001 => Espressif ESP32 via CH340B
        //                   VID_12D7 & PID_2002 => Atmel ATmega328P via CH340B ("Arduino Nano")
        //                   VID_12D7 & PID_2003 => Aux, e. g. via CH340B to Section & Rate Control Atmel ATmega328P  ("Arduino Nano") or Espressif ESP32 
        // Central Unit 3.0: VID_16C0 & PID_0483 => NXP i.MX RT1062 (Teensy V4.1)
        // u-blox F9P:       VID_1546 & PID_01A9 or (!!!) VID_0403 & PID_6015
        // prolific for IMU: VID_067B & PID_2303 => (fake) Prolific cable (mind https://indiaoncloud.com/prolific-pl2303-phased-out-since-2012-please-contact-your-supplier/)
        private const string F9PDeviceVIDa = "1546"; // u-blox F9P RTK receiver
        private const string F9PDevicePIDa = "01a9";
        private const string F9PDeviceVIDb = "0403"; // u-blox F9P RTK receiver
        private const string F9PDevicePIDb = "6015"; 
        private const string CU2DeviceVID  = "12D7"; // Central Unit 2.x, Atmel ATmega328P via CH340B ("Arduino Nano")
        private const string CU2DevicePID1 = "2001";
        private const string CU2DevicePID2 = "2002";
        private const string CU2DevicePID3 = "2003";
        private const string CU3DeviceVID  = "16C0"; // Central Unit 3.x, NXP i.MX RT1062 (Teensy V4.1)
        private const string CU3DevicePID  = "0483";
        private const string IMUDeviceVID  = "067b"; // (fake) Prolific cable to IMU
        private const string IMUDevicePID  = "2303";

        private byte ModbusRoundRobin = 0; // cyclic refresh of Modbus RTU relays

        private void doUSB()
        {
            string[] newscanports = System.IO.Ports.SerialPort.GetPortNames();

            if (myCOMPorts.Length < newscanports.Length)  // got new COM port
            {
                if (!spGPS.IsOpen)  // useful to look for GNSS??
                    foreach (string myport in ComPortNames(F9PDeviceVIDa, F9PDevicePIDa))
                        if (myport != portNameGPS2)  // if not already used for GNSS2..
                        {
                            portNameGPS = myport;
                            baudRateGPS = 460800;
                            OpenGPSPort();
                            //TimedMessageBox(2000, "Information", "First F9P connected with 460.8kBd as " + myport + " right now.");
                        }
                if (!spGPS.IsOpen)  // useful to look for GNSS??
                    foreach (string myport in ComPortNames(F9PDeviceVIDb, F9PDevicePIDb))
                        if (myport != portNameGPS2)  // if not already used for GNSS2..
                        {
                            portNameGPS = myport;
                            baudRateGPS = 460800;
                            OpenGPSPort();
                            //TimedMessageBox(2000, "Information", "First F9P connected with 460.8kBd as " + myport + " right now.");
                        }
                if (!spGPS2.IsOpen)  // useful to look for GNSS??
                    foreach (string myport in ComPortNames(F9PDeviceVIDa, F9PDevicePIDa))
                        if (myport != portNameGPS)  // if not already used for GNSS2..
                        {
                            portNameGPS2 = myport;
                            baudRateGPS = 460800;
                            OpenGPS2Port();
                            //TimedMessageBox(2000, "Information", "Second F9P connected with 460.8kBd as " + myport + " right now.");
                        }
                if (!spGPS2.IsOpen)  // useful to look for GNSS??
                    foreach (string myport in ComPortNames(F9PDeviceVIDb, F9PDevicePIDb))
                        if (myport != portNameGPS)  // if not already used for GNSS2..
                        {
                            portNameGPS2 = myport;
                            baudRateGPS = 460800;
                            OpenGPS2Port();
                            //TimedMessageBox(2000, "Information", "Second F9P connected with 460.8kBd as " + myport + " right now.");
                        }
                if (!spIMU.IsOpen)
                    foreach (string myport in ComPortNames(IMUDeviceVID, IMUDevicePID))
                    {
                        portNameIMU = myport;
                        baudRateIMU = 115200;
                        isRVC = true;
                        initRVC = false;  // needs initializations
                        OpenIMUPort();
                        //TimedMessageBox(2000, "Information", "IMU Unit BNO085 connected with 115.2kBd in RVC mode as " + myport + " right now.");
                    }
                if (!spModule1.IsOpen)
                    foreach (string myport in ComPortNames(CU2DeviceVID, CU2DevicePID2))
                    {
                        portNameModule1 = myport;
                        baudRateModule1 = 38400;
                        OpenModule1Port();
                        //TimedMessageBox(2000, "Information", "Central Unit V2.x connected with 38.4kBd as " + myport + " right now.");
                    }
                if (!spModule1.IsOpen)
                    foreach (string myport in ComPortNames(CU3DeviceVID, CU3DevicePID))
                    {
                        portNameModule1 = myport;
                        baudRateModule1 = 460800;
                        OpenModule1Port();
                        //TimedMessageBox(2000, "Information", "Central Unit V2.x connected with 38.4kBd as " + myport + " right now.");
                    }
                myCOMPorts = newscanports;
                RescanPorts();
            }

            if (myCOMPorts.Length > newscanports.Length)  // one COM gone
            {
                foreach (string thisport in myCOMPorts)
                {
                    bool isGone = true;
                    foreach (string oldport in newscanports)
                        if (thisport == oldport)
                            isGone = false;
                    if (isGone)
                    {
                        if (thisport == portNameGPS)
                        {
                            CloseGPSPort();
                            //TimedMessageBox(4000, "Warnung", "First F9P removed as " + thisport + " right now.");
                        }
                        if (thisport == portNameGPS2)
                        {
                            CloseGPS2Port();
                            //TimedMessageBox(4000, "Warning", "Second F9P removed as " + thisport + " right now.");
                        }
                        if (thisport == portNameIMU)
                        {
                            CloseIMUPort();
                            isRVC = false;
                            initRVC = false;  // needs initializations
                            //TimedMessageBox(4000, "Warning", "IMU Unit removed as " + thisport + " right now.");
                        }
                        if (thisport == portNameModule1)
                        {
                            CloseModule1Port();
                            //TimedMessageBox(4000, "Warning", "Central Unit removed as " + thisport + " right now.");
                        }
                        if (thisport == portNameModule2)
                        {
                            CloseModule2Port();
                            //TimedMessageBox(4000, "Warning", "Central Unit removed as " + thisport + " right now.");
                        }
                    }
                }
                myCOMPorts = newscanports;
                RescanPorts();
            }
        }

        public FormLoop()
        {
            InitializeComponent();
        }

        static List<string> ComPortNames(String VID, String PID)   // for any reason, doesn't seem to work with Win7 :(
        {
            List<string> comports = new List<string>();
            String pattern = String.Format("VID_{0}.PID_{1}", VID, PID);
            Regex _rx = new Regex(pattern, RegexOptions.IgnoreCase);
            RegistryKey rk1 = Microsoft.Win32.Registry.LocalMachine;
            RegistryKey rk2 = rk1.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum");

            foreach (String s3 in rk2.GetSubKeyNames())
            {
                RegistryKey rk3 = rk2.OpenSubKey(s3);
                foreach (String s in rk3.GetSubKeyNames())
                {
                    if (_rx.Match(s).Success)
                    {
                        RegistryKey rk4 = rk3.OpenSubKey(s);
                        foreach (String s2 in rk4.GetSubKeyNames())
                        {
                            try  // sometimes, Win has no "PortName"
                            {
                                RegistryKey rk5 = rk4.OpenSubKey(s2);
                                string location = (string)rk5.GetValue("LocationInformation");
                                RegistryKey rk6 = rk5.OpenSubKey("Device Parameters");
                                string portName = (string)rk6.GetValue("PortName");
                                if (!String.IsNullOrEmpty(portName) && SerialPort.GetPortNames().Contains(portName))
                                    comports.Add((string)rk6.GetValue("PortName"));
                            }
                            catch { }
                        }
                    }
                }
            }
            return comports;
        }

        public StringBuilder logNMEASentence = new StringBuilder();

        public bool isKeyboardOn = true;

        public bool isGPSSentencesOn = false, isSendNMEAToUDP;

        public double secondsSinceStart, lastSecond;

        public string lastSentence, lastSentenceCache = "";

        //The base directory where Drive will be stored and fields and vehicles branch from
        public string baseDirectory;

        //First run
        private void FormLoop_Load(object sender, EventArgs e)  // first run
        {
            if (Settings.Default.setF_workingDirectory == "Default")
                baseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AgOpenGPS\\";
            else baseDirectory = Settings.Default.setF_workingDirectory + "\\AgOpenGPS\\";

            //get the fields directory, if not exist, create
            commDirectory = baseDirectory + "AgIO\\";
            string dir = Path.GetDirectoryName(commDirectory);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir)) { Directory.CreateDirectory(dir); }

            if (Settings.Default.setUDP_isOn) LoadUDPNetwork();
            LoadLoopback();

            isSendNMEAToUDP = Properties.Settings.Default.setUDP_isSendNMEAToUDP;

            lblGPS1Comm.Text = "---";
            lblGPS2Comm.Text = "---";
            lblIMUComm.Text = "---";
            lblMod1Comm.Text = "---";
            lblMod2Comm.Text = "---";
            //lblMod3Comm.Text = "---";

            //set baud and port from last time run
            baudRateGPS = Settings.Default.setPort_baudRateGPS;
            portNameGPS = Settings.Default.setPort_portNameGPS;
            portNameGPS2 = Settings.Default.setPort_portNameGPS2;
            wasGPSConnectedLastRun = Settings.Default.setPort_wasGPSConnected;
            wasGPS2ConnectedLastRun = Settings.Default.setPort_wasGPS2Connected;
            if (wasGPSConnectedLastRun)
            {
                OpenGPSPort();
                if (spGPS.IsOpen) lblGPS1Comm.Text = portNameGPS;
            }
            if (wasGPS2ConnectedLastRun)
            {
                OpenGPS2Port();
                if (spGPS2.IsOpen) lblGPS2Comm.Text = portNameGPS2;
            }

            // set baud and port for rtcm from last time run
            baudRateRtcm = Settings.Default.setPort_baudRateRtcm;
            portNameRtcm = Settings.Default.setPort_portNameRtcm;
            wasRtcmConnectedLastRun = Settings.Default.setPort_wasRtcmConnected;
            
            if (wasRtcmConnectedLastRun)
            {
                OpenRtcmPort();
            }

            //Open IMU
            portNameIMU = Settings.Default.setPort_portNameIMU;
            baudRateIMU = 115200; // changed to autobaud       baudRateIMU = Settings.Default.setPort_baudRateIMU;
            wasIMUConnectedLastRun = Settings.Default.setPort_wasIMUConnected;
            if (wasIMUConnectedLastRun)
            {
                isRVC = true;  // try BNO085 in RVC mode first; auto-fallback to 38400Bd after 2sec on fail
                OpenIMUPort();
                if (spIMU.IsOpen) lblIMUComm.Text = portNameIMU;
            }

            //same for Module1 port
            portNameModule1 = Settings.Default.setPort_portNameModule1;
            wasModule1ConnectedLastRun = Settings.Default.setPort_wasModule1Connected;
            if (wasModule1ConnectedLastRun)
            {
                OpenModule1Port();
                if (spModule1.IsOpen) lblMod1Comm.Text = portNameModule1;
            }

            //same for Module2 port
            portNameModule2 = Settings.Default.setPort_portNameModule2;
            portProtocolModule2 = Settings.Default.setPort_portProtocolModule2;
            wasModule2ConnectedLastRun = Settings.Default.setPort_wasModule2Connected;
            if (wasModule2ConnectedLastRun)
            {
                OpenModule2Port();
                if (spModule2.IsOpen)
                {
                    lblMod2Comm.Text = portNameModule2;
                }
            }

            //same for Module3 port
            portNameModule3 = Settings.Default.setPort_portNameModule3;
            wasModule3ConnectedLastRun = Settings.Default.setPort_wasModule3Connected;
            if (wasModule3ConnectedLastRun)
            {
                OpenModule3Port();
                //if (spModule3.IsOpen) lblMod3Comm.Text = portNameModule3;
            }

            ConfigureNTRIP();

            RescanPorts();

            lastSentence = Properties.Settings.Default.setGPS_lastSentence;

            timer1.Enabled = true;
            timer2.Enabled = true;
            panel1.Visible = false;
            pictureBox1.BringToFront();
            pictureBox1.Dock = DockStyle.Fill;
        }

        //current directory of Comm storage
        public string commDirectory, commFileName = "";

        private void btnDeviceManager_Click(object sender, EventArgs e)
        {
            Process.Start("devmgmt.msc");
        }
        private void btnRescanPorts_Click(object sender, EventArgs e)
        {

        }
        private void RescanPorts()
        {
            listBoxSerialPorts.Items.Clear();
            if (myCOMPorts.Length == 0)
                listBoxSerialPorts.Items.Add("None");
            else
                foreach (string comPort in myCOMPorts)
                    listBoxSerialPorts.Items.Add(comPort);
        }

        /**************************************************************************/
        /*!
            @brief  Calculate 16-bit CRC for Modbus RTU
        */
        /**************************************************************************/
        private ushort generateCRC(byte[] pData)   
        {
            ushort crc = 0xFFFF;
            if ((pData != null) && (pData.Length >= 2))
            {
                for (byte i = 0; i < ((pData.Length - 2) & 0xFFFF); i++)
                {
                    crc ^= (ushort)pData[i];
                    for (byte j = 8; j != 0; j--)
                    {
                        if ((crc & 0x0001) != 0)
                        {
                            crc >>= 1;
                            crc ^= 0xA001;  // generator polynom: 0xA001
                        }
                        else
                        {
                            crc >>= 1;
                        }
                    }
                }
            }
            return crc;
        }

        /**************************************************************************/
        /*!
            @brief  Writes 16-bits to the specified Modbus RTU destination register
        */
        /**************************************************************************/
        private void RTUSnd06(byte MB_ID, byte MBAddr, ushort MBData)
        {
            byte[] command = new byte[8];

            command[0] = MB_ID;
            command[1] = 6;
            command[2] = 0;
            command[3] = MBAddr;
            command[4] = (byte)((MBData >> 8) & 0xff);
            command[5] = (byte)(MBData & 0xff);
            ushort CRC = generateCRC(command);
            command[6] = (byte)(CRC & 0xff);
            command[7] = (byte)((CRC >> 8) & 0xff);

            spModule2.Write(command, 0, command.Length);
        }


        /**************************************************************************/
        /*!
            @brief  switches on Modbus relay on 
        */
        /**************************************************************************/
        private void RTURelOn(byte address, byte NoRel)
        {
            RTUSnd06(address, NoRel, 0x0100);
        }


        /**************************************************************************/
        /*!
            @brief  switches on Modbus relay off
        */
        /**************************************************************************/
        private void RTURelOff(byte address, byte NoRel)
        {
            RTUSnd06(address, NoRel, 0x0200);
        }

        /**************************************************************************/
        /*!
            @brief  momentary function of Modbus relay
        */
        /**************************************************************************/
        private void RTURelMom(byte address, byte NoRel)
        {
            RTUSnd06(address, NoRel, 0x0500);
        }


        /**************************************************************************/
        /*!
            @brief  delay function of Modbus relay
        */
        /**************************************************************************/
        private void RTURelDly(byte address, byte NoRel, ushort mytime)
        {
            RTUSnd06(address, NoRel, (ushort)(0x0600 + mytime));
        }

        /**************************************************************************/
        /*!
            @brief  Modbus timer int: one command every 40ms
        */
        /**************************************************************************/
        private void ModbusTimer_Tick(object sender, EventArgs e)  // Modbus RTU send loop
        {
            if (spModule2.IsOpen && portProtocolModule2 != "PGN")
            {
                bool isNew = false;  // new relay status?

                for (int j = 0; j < 2; j++)
                for (int i = 0; i < 16; i++)
                {
                    if (!isNew &&                                                                       // one command per Modbus time slot
                        ((j != 0 && (ModbusRoundRobin == i) ||                                          // either round robin update or
                         (j == 0 && (SectionRelaysAOG & (1 << i)) != (ModbusRelays & (1 << i))))))      // new relay to set or to reset
                    {
                        byte NumberOfRelay = 0;
                        byte MBaddress = 0;
                        if (portProtocolModule2 == "Modbus 4 Relay")                //  4 relays per board => 4 boards (1..4)
                        {
                            MBaddress = (byte)((i >> 2) + 1);
                            NumberOfRelay = (byte)((i & 0x03) + 1);
                        }
                        if (portProtocolModule2 == "Modbus 8 Relay")
                        {
                            MBaddress = (byte)((i >> 3) + 1);               //  8 relays per board => 2 boards (1..2)
                            NumberOfRelay = (byte)((i & 0x07) + 1);
                        }
                        if (portProtocolModule2 == "Modbus 16 Relay")
                        {
                            MBaddress = (byte)((i >> 4) + 1);               // 16 relays per board => 1 board (1)
                            NumberOfRelay = (byte)((i & 0x0f) + 1);
                        }
                        if ((SectionRelaysAOG & (1 << i)) != 0)             // to set active?
                        {
                            RTURelOn(MBaddress, NumberOfRelay);
                            ModbusRelays |= (uint)(1 << i);
                        }
                        else
                        {
                            RTURelOff(MBaddress, NumberOfRelay);
                            ModbusRelays &= (uint)(0xffff ^ (1 << i));
                        }
                        isNew = true;
                        ModbusRoundRobin++;
                        ModbusRoundRobin &= 0x0f;
                    }
                }
                timer2.Interval = 40;
            }
            else
            {
                timer2.Interval = 3000;
                // TimedMessageBox(1000, "No", "Modbus");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Interval > 1000)
            {
                Controls.Remove(pictureBox1);
                pictureBox1.Dispose();
                panel1.Visible = true;
                timer1.Interval = 1000;
                return;
            }

            secondsSinceStart = (DateTime.Now - Process.GetCurrentProcess().StartTime).TotalSeconds;

            DoTraffic();

            doUSB();

            if (spGPS.IsOpen && GPSAutoBaud[0] < 2)  // GPS autobaud detection
            {
                GPSAutoBaud[0]++;
                if (GPSAutoBaud[0] == 3)
                {
                    baudRateGPS = baudRateGPS / 2;
                    if (baudRateGPS == 57600 / 2) baudRateGPS = 38400;
                    if (baudRateGPS == 1200) baudRateGPS = 460800; 
                    CloseGPSPort();
                    OpenGPSPort();
                    //TimedMessageBox(1000, "GPS Autobaud", "Testing with Baudrate = " + baudRateGPS);
                }
            }

            if (spGPS2.IsOpen && !spGPS.IsOpen && GPSAutoBaud[1] < 2)  // GPS2 autobaud detection
            {
                GPSAutoBaud[1]++;
                if (GPSAutoBaud[1] == 5)
                {
                    baudRateGPS = baudRateGPS / 2;
                    if (baudRateGPS == 57600 / 2) baudRateGPS = 38400;
                    if (baudRateGPS == 1200) baudRateGPS = 460800;
                    CloseGPS2Port();
                    OpenGPS2Port();
                    //TimedMessageBox(1000, "GPS Autobaud", "Testing with Baudrate = " + baudRateGPS);
                }
            }

            if (spIMU.IsOpen && isRVC && IMUAutoBaud < 2 && (spGPS.IsOpen || spGPS2.IsOpen))  // IMU autobaud detection
            {
                IMUAutoBaud++;
                if (IMUAutoBaud == 2)
                {
                    baudRateIMU = 38400;
                    isRVC = false;
                    CloseIMUPort();
                    OpenIMUPort();
                    //TimedMessageBox(1000, "IMU Message", "No BNO085 in RVC mode found. Switching back to 38.400 Baud.");
                }
            }

            //do all the NTRIP routines
            DoNTRIPSecondRoutine();

            //send back to Drive proof of life
            //every 3 seconds
            if ((secondsSinceStart - lastSecond) > 2)
            {
                if (isLogNMEA)
                {
                    using (StreamWriter writer = new StreamWriter("zAgIO_log.txt", true))
                    {
                        writer.Write(logNMEASentence.ToString());
                    }
                    logNMEASentence.Clear();
                }

                lastSecond = secondsSinceStart;

                if (wasIMUConnectedLastRun)
                {
                    if (!spIMU.IsOpen)
                    {
                        byte[] imuClose = new byte[] { 0x80, 0x81, 0x7C, 0xD4, 2, 1, 0, 83 };

                        //tell AOG IMU is disconnected
                        SendToLoopBackMessageAOG(imuClose);
                        wasIMUConnectedLastRun = false;
                        lblIMUComm.Text = "---";
                    }
                }

                if (wasGPSConnectedLastRun)
                {
                    if (!spGPS.IsOpen)
                    {
                        wasGPSConnectedLastRun = false;
                        lblGPS1Comm.Text = "---";
                    }
                }

                if (wasModule1ConnectedLastRun)
                {
                    if (!spModule1.IsOpen)
                    {
                        wasModule1ConnectedLastRun = false;
                        lblMod1Comm.Text = "---";
                    }
                }

                if (wasModule2ConnectedLastRun)
                {
                    if (!spModule2.IsOpen)
                    {
                        wasModule2ConnectedLastRun = false;
                        lblMod2Comm.Text = "---";
                    }
                }

                if (wasModule3ConnectedLastRun)
                {
                    if (!spModule3.IsOpen)
                    {
                        wasModule3ConnectedLastRun = false;
                    }
                }
            }
        }

        private void deviceManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("devmgmt.msc");
        }

        private void btnBringUpCommSettings_Click(object sender, EventArgs e)
        {
            SettingsCommunicationGPS();
        }

        private void btnBringUpSteerSettings_Click(object sender, EventArgs e)
        {
            SettingsSteering();
        }

        private void btnUDP_Click(object sender, EventArgs e)
        {
            SettingsUDP();
        }

        private void btnRunAOG_Click(object sender, EventArgs e)
        {
            StartAOG();
        }

        private void btnNTRIP_Click(object sender, EventArgs e)
        {
            SettingsNTRIP();
        }

        private void btnRadio_Click(object sender, EventArgs e)
        {
            SettingsRadio();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void ConfigureNTRIP()
        {
            lblWatch.Text = "Wait GPS";

            //start NTRIP if required
            isNTRIP_RequiredOn = Settings.Default.setNTRIP_isOn;
            isRadio_RequiredOn = Settings.Default.setRadio_isOn;

            if (isRadio_RequiredOn)
            {
                // Immediatly connect radio
                ntripCounter = 20;
            }

            if (isNTRIP_RequiredOn || isRadio_RequiredOn)
            {
                btnStartStopNtrip.Visible = true;
                btnStartStopNtrip.Visible = true;
                lblWatch.Visible = true;
                lblNTRIPBytes.Visible = true;
                lblBytes.Visible = true;
            }
            else
            {
                btnStartStopNtrip.Visible = false;
                btnStartStopNtrip.Visible = false;
                lblWatch.Visible = false;
                lblNTRIPBytes.Visible = false;
                lblBytes.Visible = false;
            }

            btnStartStopNtrip.Text = "Off";
        }

        private void uDPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsUDP();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormGPSData"];

            if (f != null)
            {
                f.Focus();
                f.Close();
                isGPSSentencesOn = false;
                return;
            }

            isGPSSentencesOn = true;

            Form form = new FormGPSData(this);
            form.Show(this);
        }

        private void toolStripGPSData_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormGPSData"];

            if (f != null)
            {
                f.Focus();
                f.Close();
                isGPSSentencesOn = false;
                return;
            }

            isGPSSentencesOn = true;

            Form form = new FormGPSData(this);
            form.Show(this);
        }

        private void toolStripAgDiag_Click(object sender, EventArgs e)
        {
            Process[] processName = Process.GetProcessesByName("AgDiag");
            if (processName.Length == 0)
            {
                //Start application here
                DirectoryInfo di = new DirectoryInfo(Application.StartupPath);
                string strPath = di.ToString();
                strPath += "\\AgDiag.exe";
                //TimedMessageBox(8000, "No File Found", strPath);

                try
                {
                    ProcessStartInfo processInfo = new ProcessStartInfo
                    {
                        FileName = strPath,
                        //processInfo.ErrorDialog = true;
                        //processInfo.UseShellExecute = false;
                        WorkingDirectory = Path.GetDirectoryName(strPath)
                    };
                    Process proc = Process.Start(processInfo);
                }
                catch
                {
                    TimedMessageBox(2000, "No File Found", "Can't Find AgDiag");
                }
            }
            else
            {
                //Set foreground window

                ShowWindow(processName[0].MainWindowHandle, 9);
                SetForegroundWindow(processName[0].MainWindowHandle);

            }

        }

        public bool isLogNMEA;

        public static string portNameGPS1 { get; internal set; }
        public object spGPS1 { get; internal set; }

        private void lblCurrentLat_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblGPS1Comm_Click(object sender, EventArgs e)
        {

        }

        private void lblToGPS_Click(object sender, EventArgs e)
        {

        }

        private void btnGPS2_Click(object sender, EventArgs e)
        {
            SettingsCommunicationGPS();
        }

        private void lblGPSheading_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblFromMU_Click(object sender, EventArgs e)
        {

        }

        private void lblCurentLon_Click(object sender, EventArgs e)
        {

        }

        private void lblNTRIPBytes_Click(object sender, EventArgs e)
        {

        }

        private void lblMod2Comm_Click(object sender, EventArgs e)
        {

        }

        private void lblToModule2_Click(object sender, EventArgs e)
        {

        }

        private void lblIMUComm_Click(object sender, EventArgs e)
        {

        }

        private void cboxLogNMEA_CheckedChanged(object sender, EventArgs e)
        {
            isLogNMEA = cboxLogNMEA.Checked;
        }

        private void FormLoop_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (recvFromAOGLoopBackSocket != null)
            {
                try
                {
                    recvFromAOGLoopBackSocket.Shutdown(SocketShutdown.Both);
                }
                finally { recvFromAOGLoopBackSocket.Close(); }
            }

            if (sendToAOGLoopBackSocket != null)
            {
                try
                {
                    sendToAOGLoopBackSocket.Shutdown(SocketShutdown.Both);
                }
                finally { sendToAOGLoopBackSocket.Close(); }
            }

            if (sendToUDPSocket != null)
            {
                try
                {
                    sendToUDPSocket.Shutdown(SocketShutdown.Both);
                }
                finally { sendToUDPSocket.Close(); }
            }

            if (recvFromUDPSocket != null)
            {
                try
                {
                    recvFromUDPSocket.Shutdown(SocketShutdown.Both);
                }
                finally { recvFromUDPSocket.Close(); }
            }
        }

        private void DoTraffic()
        {
            lblToAOG.Text = traffic.cntrPGNToAOG == 0 ? "--" : (traffic.cntrPGNToAOG).ToString();
            lblFromAOG.Text = traffic.cntrPGNFromAOG == 0 ? "--" : (traffic.cntrPGNFromAOG).ToString();

            lblFromUDP.Text = traffic.cntrUDPIn == 0 ? "--" : (traffic.cntrUDPIn).ToString();
            lblToUDP.Text = traffic.cntrUDPOut == 0 ? "--" : (traffic.cntrUDPOut).ToString();

            lblFromGPS.Text = traffic.cntrGPSIn == 0 ? "--" : (traffic.cntrGPSIn).ToString();
            lblToGPS.Text = traffic.cntrGPSOut == 0 ? "--" : (traffic.cntrGPSOut).ToString();

            lblFromGPS2.Text = traffic.cntrGPS2In == 0 ? "--" : (traffic.cntrGPS2In).ToString();
            lblToGPS2.Text = traffic.cntrGPS2Out == 0 ? "--" : (traffic.cntrGPS2Out).ToString();

            lblFromModule1.Text = traffic.cntrModule1In == 0 ? "--" : (traffic.cntrModule1In).ToString();
            lblToModule1.Text = traffic.cntrModule1Out == 0 ? "--" : (traffic.cntrModule1Out).ToString();

            if (spModule2.IsOpen && portProtocolModule2 != "PGN")
            {
                lblFromModule2.Text = "Modbus";
                lblToModule2.Text = "200";  // fixed rate: 8 bytes per 40ms
            }
            else
            {
                lblFromModule2.Text = traffic.cntrModule2In == 0 ? "--" : (traffic.cntrModule2In).ToString();
                lblToModule2.Text = traffic.cntrModule2Out == 0 ? "--" : (traffic.cntrModule2Out).ToString();
            }

            lblFromMU.Text = traffic.cntrIMUIn == 0 ? "--" : (traffic.cntrIMUIn).ToString();
            lblToIMU.Text = traffic.cntrIMUOut == 0 ? "--" : (traffic.cntrIMUOut).ToString();
            if (isRVC && traffic.cntrIMUIn != 0) lblToIMU.Text = "RVC";  // robot vacuum cleaner mode

            traffic.cntrPGNToAOG = traffic.cntrPGNFromAOG = traffic.cntrUDPIn = traffic.cntrUDPOut =
                traffic.cntrGPSIn = traffic.cntrGPSOut = traffic.cntrGPS2In = traffic.cntrGPS2Out =
                traffic.cntrIMUIn = traffic.cntrIMUOut =
                traffic.cntrModule3In = traffic.cntrModule3Out =
                traffic.cntrModule1In = traffic.cntrModule1Out =
                traffic.cntrModule2Out = traffic.cntrModule2In = 0;

            lblCurentLon.Text = longitude.ToString("N7");
            lblCurrentLat.Text = latitude.ToString("N7");
            lblCurrentHeading.Text = GPSheading.ToString("N7");
            lblCurrentRoll.Text = GPSroll.ToString("N7");
        }
    }
}

