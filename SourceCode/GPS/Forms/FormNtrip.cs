using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormNtrip : Form
    {
        //class variables
        private readonly FormGPS mf;

        public FormNtrip(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();

            this.groupBox2.Text = gStr.gsNetworking;
            this.cboxIsNTRIPOn.Text = gStr.gsNTRIPOn;
            this.label6.Text = gStr.gsPort;
            this.label4.Text = gStr.gsEnterBroadcasterURLOrIP;
            this.label7.Text = gStr.gsToUDPPort;

            this.label3.Text = gStr.gsUsername;
            this.label12.Text = gStr.gsPassword;
            this.label13.Text = gStr.gsMount;
            this.label15.Text = gStr.gsGGAIntervalSecs;
            this.btnGetIP.Text = gStr.gsConfirmIP;

            this.label9.Text = gStr.gsCurrentGPSFix;
            this.label17.Text = gStr.gsSendToManualFix;
            this.btnSetManualPosition.Text = gStr.gsSendToManualFix;
            this.label18.Text = gStr.gsSetToZeroForSerial;
            this.btnGetSourceTable.Text = gStr.gsGetSourceTable;

            this.label1.Text = gStr.gsRestartRequired;
            this.label19.Text = gStr.gsZeroEqualsOff;

            this.Text = gStr.gsNTRIPClientSettings;

            //turn off the little arrows
            nudCasterPort.Controls[0].Enabled = false;
            nudGGAInterval.Controls[0].Enabled = false;
            nudLatitude.Controls[0].Enabled = false;
            nudLongitude.Controls[0].Enabled = false;
            nudSendToUDPPort.Controls[0].Enabled = false;
        }

        private void FormNtrip_Load(object sender, EventArgs e)
        {
            string hostName = Dns.GetHostName(); // Retrieve the Name of HOST
            tboxHostName.Text = hostName;

            //IPAddress[] ipaddress = Dns.GetHostAddresses(hostName);
            tboxThisIP.Text = GetIP4Address();

            tboxEnterURL.Text = Properties.Settings.Default.setNTRIP_casterURL;

            tboxCasterIP.Text = Properties.Settings.Default.setNTRIP_casterIP;
            nudCasterPort.Value = Properties.Settings.Default.setNTRIP_casterPort;
            nudSendToUDPPort.Value = Properties.Settings.Default.setNTRIP_sendToUDPPort;

            cboxIsNTRIPOn.CheckedChanged -= cboxIsNTRIPOn_CheckedChanged;
            cboxIsNTRIPOn.Checked = Properties.Settings.Default.setNTRIP_isOn;
            cboxIsNTRIPOn.CheckedChanged += cboxIsNTRIPOn_CheckedChanged;

            tboxUserName.Text = Properties.Settings.Default.setNTRIP_userName;
            tboxUserPassword.Text = Properties.Settings.Default.setNTRIP_userPassword;
            tboxMount.Text = Properties.Settings.Default.setNTRIP_mount;

            nudGGAInterval.ValueChanged -= nudGGAInterval_ValueChanged;
            nudGGAInterval.Value = Properties.Settings.Default.setNTRIP_sendGGAInterval;
            nudGGAInterval.ValueChanged += nudGGAInterval_ValueChanged;

            nudSendToUDPPort.ValueChanged -= nudSendToUDPPort_ValueChanged;
            nudSendToUDPPort.Value = Properties.Settings.Default.setNTRIP_sendToUDPPort;
            nudSendToUDPPort.ValueChanged += nudSendToUDPPort_ValueChanged;

            nudLatitude.Value = (decimal)Properties.Settings.Default.setNTRIP_manualLat;
            nudLongitude.Value = (decimal)Properties.Settings.Default.setNTRIP_manualLon;
            tboxCurrentLat.Text = mf.pn.latitude.ToString();
            tboxCurrentLon.Text = mf.pn.longitude.ToString();

            checkBoxusetcp.Checked = Properties.Settings.Default.setNTRIP_isTCP;

            if (Properties.Settings.Default.setNTRIP_isGGAManual) cboxGGAManual.Text = "Use Manual Fix";
            else cboxGGAManual.Text = "Use GPS Fix";
        }

        //get the ipv4 address only
        public static string GetIP4Address()
        {
            string IP4Address = String.Empty;

            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily == AddressFamily.InterNetwork)
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            return IP4Address;
        }

        private void btnGetIP_Click(object sender, EventArgs e)
        {
            string actualIP = tboxEnterURL.Text.Trim();
            try
            {
                IPAddress[] addresslist = Dns.GetHostAddresses(actualIP);
                tboxCasterIP.Text = "";
                tboxCasterIP.Text = addresslist[0].ToString().Trim();
            }
            catch (Exception)
            {
                mf.TimedMessageBox(1500, "No IP Located", "Can't Find: " + actualIP);
            }
        }

        public Boolean CheckIPValid(String strIP)
        {
            //  Split string by ".", check that array length is 3
            string[] arrOctets = strIP.Split('.');

            //at least 4 groups in the IP
            if (arrOctets.Length != 4) return false;

            //  Check each substring checking that the int value is less than 255 and that is char[] length is !> 2
            const Int16 MAXVALUE = 255;
            Int32 temp; // Parse returns Int32
            foreach (String strOctet in arrOctets)
            {
                //check if at least 3 digits but not more OR 0 length
                if (strOctet.Length > 3 || strOctet.Length == 0) return false;

                //make sure all digits
                if (!int.TryParse(strOctet, out int temp2)) return false;

                //make sure not more then 255
                temp = int.Parse(strOctet);
                if (temp > MAXVALUE || temp < 0) return false;
            }
            return true;
        }

        private void tboxCasterIP_Validating(object sender, CancelEventArgs e)
        {
            if (!CheckIPValid(tboxCasterIP.Text))
            {
                tboxCasterIP.Text = "127.0.0.1";
                tboxCasterIP.Focus();
                mf.TimedMessageBox(2000, "Invalid IP Address", "Set to Default Local 127.0.0.1");
            }
        }

        private void btnSerialOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.setNTRIP_casterIP = tboxCasterIP.Text;
            Properties.Settings.Default.setNTRIP_casterPort = (int)nudCasterPort.Value;
            Properties.Settings.Default.setNTRIP_sendToUDPPort = (int)nudSendToUDPPort.Value;

            Properties.Settings.Default.setNTRIP_isOn = cboxIsNTRIPOn.Checked;
            Properties.Settings.Default.setNTRIP_userName = tboxUserName.Text;
            Properties.Settings.Default.setNTRIP_userPassword = tboxUserPassword.Text;
            Properties.Settings.Default.setNTRIP_mount = tboxMount.Text;

            Properties.Settings.Default.setNTRIP_sendGGAInterval = (int)nudGGAInterval.Value;
            Properties.Settings.Default.setNTRIP_sendToUDPPort = (int)nudSendToUDPPort.Value;
            Properties.Settings.Default.setNTRIP_manualLat = (double)nudLatitude.Value;
            Properties.Settings.Default.setNTRIP_manualLon = (double)nudLongitude.Value;

            Properties.Settings.Default.setNTRIP_casterURL = tboxEnterURL.Text;
            Properties.Settings.Default.setNTRIP_isGGAManual = cboxGGAManual.Text == "Use Manual Fix";
            Properties.Settings.Default.setNTRIP_isTCP = checkBoxusetcp.Checked;

            Properties.Settings.Default.Save();
            Close();
        }

        private void btnSetManualPosition_Click(object sender, EventArgs e)
        {
            nudLatitude.Value = (decimal)mf.pn.latitude;
            nudLongitude.Value = (decimal)mf.pn.longitude;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tboxCurrentLat.Text = mf.pn.latitude.ToString();
            tboxCurrentLon.Text = mf.pn.longitude.ToString();
        }

        private void btnGetSourceTable_Click(object sender, EventArgs e)
        {
            string syte = "http://monitor.use-snip.com/?hostUrl=" + tboxCasterIP.Text + "&port=" + nudCasterPort.Value.ToString();
            Process.Start(syte);
        }

        private void cboxIsNTRIPOn_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void nudGGAInterval_ValueChanged(object sender, EventArgs e)
        {
        }

        private void nudSendToUDPPort_ValueChanged(object sender, EventArgs e)
        {
        }

        private void NudCasterPort_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnSerialCancel.Focus();
        }

        private void NudGGAInterval_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnSerialCancel.Focus();
        }

        private void NudLatitude_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnSerialCancel.Focus();
        }

        private void NudLongitude_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnSerialCancel.Focus();
        }

        private void NudSendToUDPPort_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnSerialCancel.Focus();
        }
    }
}