using AgIO.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace AgIO
{
    public partial class FormLoop : Form
    {
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr hWind, int nCmdShow);

        public FormLoop()
        {
            InitializeComponent();
        }

        public StringBuilder logNMEASentence = new StringBuilder();

        public bool isKeyboardOn = true;

        public bool isGPSSentencesOn = false;

        public double secondsSinceStart, lastSecond;

        //The base directory where Drive will be stored and fields and vehicles branch from
        public string baseDirectory;

        //First run
        private void FormLoop_Load(object sender, EventArgs e)
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

            lblGPS1Comm.Text = "---";
            lblIMUComm.Text = "---";
            lblMod1Comm.Text = "---";
            lblMod2Comm.Text = "---";
            //lblMod3Comm.Text = "---";

            //set baud and port from last time run
            baudRateGPS = Settings.Default.setPort_baudRateGPS;
            portNameGPS = Settings.Default.setPort_portNameGPS;
            wasGPSConnectedLastRun = Settings.Default.setPort_wasGPSConnected;
            if (wasGPSConnectedLastRun)
            {
                OpenGPSPort();
                if (spGPS.IsOpen) lblGPS1Comm.Text = portNameGPS;
            }

            //Open IMU
            portNameIMU = Settings.Default.setPort_portNameIMU;
            wasIMUConnectedLastRun = Settings.Default.setPort_wasIMUConnected;
            if (wasIMUConnectedLastRun)
            {
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
            wasModule2ConnectedLastRun = Settings.Default.setPort_wasModule2Connected;
            if (wasModule2ConnectedLastRun)
            {
                OpenModule2Port();
                if (spModule2.IsOpen) lblMod2Comm.Text = portNameModule2;
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

            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            listBox1.Items.Clear();

            if (ports.Length == 0)
            {
                listBox1.Items.Add("None");
            }
            else
            {
                for (int i = 0; i < ports.Length; i++)
                {
                    listBox1.Items.Add(ports[i]);
                }
            }

            timer1.Enabled = true;
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
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            listBox1.Items.Clear();

            if (ports.Length == 0)
            {
                listBox1.Items.Add("None");
                return;
            }
            else
            {
                for (int i = 0; i < ports.Length; i++)
                {
                    listBox1.Items.Add(ports[i]);
                }
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

            lblCurentLon.Text = longitude.ToString("N7");
            lblCurrentLat.Text = latitude.ToString("N7");

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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void ConfigureNTRIP()
        {
            lblWatch.Text = "Wait GPS";

            //start NTRIP if required
            isNTRIP_RequiredOn = Settings.Default.setNTRIP_isOn;

            if (isNTRIP_RequiredOn)
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

            lblFromModule1.Text = traffic.cntrModule1In == 0 ? "--" : (traffic.cntrModule1In).ToString();
            lblToModule1.Text = traffic.cntrModule1Out == 0 ? "--" : (traffic.cntrModule1Out).ToString();

            lblFromModule2.Text = traffic.cntrModule2In == 0 ? "--" : (traffic.cntrModule2In).ToString();
            lblToModule2.Text = traffic.cntrModule2Out == 0 ? "--" : (traffic.cntrModule2Out).ToString();

            lblFromMU.Text = traffic.cntrIMUIn == 0 ? "--" : (traffic.cntrIMUIn).ToString();
            lblToIMU.Text = traffic.cntrIMUOut == 0 ? "--" : (traffic.cntrIMUOut).ToString();

            traffic.cntrPGNToAOG = traffic.cntrPGNFromAOG = traffic.cntrUDPIn = traffic.cntrUDPOut =
                traffic.cntrGPSIn = traffic.cntrGPSOut = traffic.cntrGPS2In = traffic.cntrGPS2Out =
                traffic.cntrIMUIn = traffic.cntrIMUOut =
                traffic.cntrModule3In = traffic.cntrModule3Out =
                traffic.cntrModule1In = traffic.cntrModule1Out =
                traffic.cntrModule2Out = traffic.cntrModule2In = 0;

            lblCurentLon.Text = longitude.ToString("N7");
            lblCurrentLat.Text = latitude.ToString("N7");
        }
    }
}

