using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace AgIO
{

    public partial class FormLoop
    {
        public void TimedMessageBox(int timeout, string s1, string s2)
        {
            var form = new FormTimedMessage(timeout, s1, s2);
            form.Show();
        }

        private void SettingsCommunicationGPS()
        {
            isGPSCommOpen = true;
            using (FormCommSetGPS form = new FormCommSetGPS(this))
            {
                form.ShowDialog(this);
            }
            isGPSCommOpen = false;
        }

        private void DoNTRIPSecondRoutine()
        {
            //count up the ntrip clock only if everything is alive
            if (isNTRIP_RequiredOn || isRadio_RequiredOn)
            {
                IncrementNTRIPWatchDog();
            }

            //Have we NTRIP connection
            if (isNTRIP_RequiredOn  && !isNTRIP_Connected && !isNTRIP_Connecting)
            {
                if (!isNTRIP_Starting && ntripCounter > 20)
                {
                    StartNTRIP();
                }
            }

            if (isRadio_RequiredOn && !isNTRIP_Connected && !isNTRIP_Connecting)
            {
                if (!isNTRIP_Starting)
                {
                    StartNTRIP();
                }
            }

            if (isNTRIP_Connecting)
            {
                if (ntripCounter > 28)
                {
                    TimedMessageBox(2000, "Connection Problem", "Not Connecting To Caster");
                    ReconnectRequest();
                }
                if (clientSocket != null && clientSocket.Connected)
                {
                    //TimedMessageBox(2000, "NTRIP Not Connected", " At the StartNTRIP() ");
                    //ReconnectRequest();
                    //return;
                    SendAuthorization();
                }

            }

            if (isNTRIP_RequiredOn || isRadio_RequiredOn)
            {
                //update byte counter and up counter
                if (ntripCounter > 59) btnStartStopNtrip.Text = (ntripCounter / 60) + " Mins";
                else if (ntripCounter < 60 && ntripCounter > 22) btnStartStopNtrip.Text = ntripCounter + " Secs";
                else btnStartStopNtrip.Text = "In " + (Math.Abs(ntripCounter - 22)) + " secs";


                btnStartStopNtrip.Text = ntripCounter + " Secs";

                //pbarNtripMenu.Value = unchecked((byte)(tripBytes * 0.02));
                lblNTRIPBytes.Text = ((tripBytes) * 0.001).ToString("###,###,###") + " kb";

                //watchdog for Ntrip
                if (isNTRIP_Connecting)
                { 
                    lblWatch.Text = gStr.gsAuthourizing; 
                }
                else
                {
                    if (isNTRIP_RequiredOn && NTRIP_Watchdog > 10)
                    {
                        lblWatch.Text = gStr.gsWaiting;
                    }
                    else
                    {
                        lblWatch.Text = gStr.gsListening;

                        if (isNTRIP_RequiredOn)
                        {
                            lblWatch.Text += " NTRIP";
                        }
                        else if (isRadio_RequiredOn)
                        {
                            lblWatch.Text += " Radio";
                        }
                    }
                }

                if (sendGGAInterval > 0 && isNTRIP_Sending)
                {
                    lblWatch.Text = "Send GGA";
                    isNTRIP_Sending = false;
                }
            }
        }

        private void SettingsNTRIP()
        {
            using (var form = new FormNtrip(this))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (isNTRIP_Connected)
                    {
                        SettingsShutDownNTRIP();
                    }
                }
            }
        }

        private void SettingsRadio()
        {
            if (isRadio_RequiredOn && isNTRIP_Connected)
            {
                ShutDownNTRIP();
                lblWatch.Text = "Stopped";
                btnStartStopNtrip.Text = "OffLine";
                isRadio_RequiredOn = false;
            }

            using (var form = new FormRadio(this))
            {
                form.ShowDialog(this);
            }
        }

        private void SettingsUDP()
        {
            using (var form = new FormUDP(this))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    //Clicked Save
                    Application.Restart();
                    Environment.Exit(0);
                }
            }
        }

        private void StartAOG()
        {
            Process[] processName = Process.GetProcessesByName("AgOpenGPS");
            if (processName.Length == 0)
            {
                //Start application here
                DirectoryInfo di = new DirectoryInfo(Application.StartupPath);
                string strPath = di.ToString();
                strPath += "\\AgOpenGPS.exe";
                //TimedMessageBox(8000, "No File Found", strPath);

                try
                {
                    ProcessStartInfo processInfo = new ProcessStartInfo();
                    processInfo.FileName = strPath;
                    //processInfo.ErrorDialog = true;
                    //processInfo.UseShellExecute = false;
                    processInfo.WorkingDirectory = Path.GetDirectoryName(strPath);
                    Process proc = Process.Start(processInfo);
                }
                catch
                {
                    TimedMessageBox(2000, "No File Found", "Can't Find AgOpenGPS");
                }
            }
            else
            {
                //Set foreground window

                ShowWindow(processName[0].MainWindowHandle, 9);
                SetForegroundWindow(processName[0].MainWindowHandle);

            }
        }

        private void StartDrive()
        {

            DirectoryInfo di = new DirectoryInfo(Application.StartupPath);
            string strPath = di.ToString();
            try
            {
                strPath += "\\Drive.exe";
                Process.Start(strPath);
            }
            catch
            {
                TimedMessageBox(2000, "No File Found", "Can't Find Drive");
            }

        }

        private void btnStartStopNtrip_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.setNTRIP_isOn || Properties.Settings.Default.setRadio_isOn)
            {
                if (isNTRIP_RequiredOn || isRadio_RequiredOn)
                {
                    ShutDownNTRIP();
                    lblWatch.Text = "Stopped";
                    btnStartStopNtrip.Text = "OffLine";
                    isNTRIP_RequiredOn = false;
                    isRadio_RequiredOn = false;
                }
                else
                {
                    isNTRIP_RequiredOn = Properties.Settings.Default.setNTRIP_isOn;
                    isRadio_RequiredOn = Properties.Settings.Default.setRadio_isOn;
                    lblWatch.Text = "Waiting";
                }
            }
            else
            {
                TimedMessageBox(2000, "Turn on NTRIP", "NTRIP Client Not Set Up");
            }
        }

        private void stripRunDrive_Click(object sender, EventArgs e)
        {
        }

        private void nTRIPToolStrip_Click(object sender, EventArgs e)
        {
            SettingsNTRIP();
        }

        private void loadToolStrip_Click(object sender, EventArgs e)
        {
            using (FormCommPicker form = new FormCommPicker(this))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        private void stripGPSPortsConfig_Click(object sender, EventArgs e)
        {
            SettingsCommunicationGPS();
        }

        private void uDPToolStripMenu_Click(object sender, EventArgs e)
        {
            SettingsUDP();
        }

        private void saveToolStrip_Click(object sender, EventArgs e)
        {
            using (FormCommSaver form = new FormCommSaver(this))
            {
                form.ShowDialog(this);
            }
        }

        public void KeypadToNUD(NumericUpDown sender, Form owner)
        {
            sender.BackColor = System.Drawing.Color.Red;
            using (var form = new FormNumeric((double)sender.Minimum, (double)sender.Maximum, (double)sender.Value))
            {
                if (form.ShowDialog(owner) == DialogResult.OK)
                {
                    sender.Value = (decimal)form.ReturnValue;
                }
            }
            sender.BackColor = System.Drawing.Color.AliceBlue;
        }

        public void KeyboardToText(TextBox sender, Form owner)
        {
            TextBox tbox = (TextBox)sender;
            tbox.BackColor = System.Drawing.Color.Red;
            using (var form = new FormKeyboard((string)tbox.Text))
            {
                if (form.ShowDialog(owner) == DialogResult.OK)
                {
                    tbox.Text = (string)form.ReturnString;
                }
            }
            tbox.BackColor = System.Drawing.Color.AliceBlue;
        }

    }
}
