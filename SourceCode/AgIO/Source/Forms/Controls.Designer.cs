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

        private void SettingsNTRIP()
        {
            if (isRadio_RequiredOn)
            {
                TimedMessageBox(2000, "Radio NTRIP ON", "Turn it off before using NTRIP");
                return;
            }

            if (isSerialPass_RequiredOn)
            {
                TimedMessageBox(2000, "Serial NTRIP ON", "Turn it off before using NTRIP");
                return;
            }


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
            if (isSerialPass_RequiredOn)
            {
                TimedMessageBox(2000, "Serial Pass NTRIP ON", "Turn it off before using Radio NTRIP");
                return;
            }

            if (isNTRIP_RequiredOn)
            {
                TimedMessageBox(2000, "Air NTRIP ON", "Turn it off before using Radio NTRIP");
                return;
            }

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

                try
                {
                    ProcessStartInfo processInfo = new ProcessStartInfo();
                    processInfo.FileName = strPath;
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
                    lblNTRIP_IP.Text = "--";
                    lblMount.Text = "--";
                }
                else
                {
                    isNTRIP_RequiredOn = Properties.Settings.Default.setNTRIP_isOn;
                    isRadio_RequiredOn = Properties.Settings.Default.setRadio_isOn;
                    lblWatch.Text = "Waiting";
                    lblNTRIP_IP.Text = "--";
                    lblMount.Text= "--";
                }
            }
            else
            {
                TimedMessageBox(2000, "Turn on NTRIP", "NTRIP Client Not Set Up");
            }
        }

        private void loadToolStrip_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStrip_Click(object sender, EventArgs e)
        {

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

        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem deviceManagerToolStripMenuItem;
    }
}
