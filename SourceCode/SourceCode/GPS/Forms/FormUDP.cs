using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormUDP : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        public FormUDP(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();
            groupBox4.Text = gStr.gsAgOpenGPSServer;
            label11.Text = gStr.gsAllmodulessendto;
            tboxHostName.Text = gStr.gsHostName;
            label14.Text = gStr.gsHost;
            label1.Text = gStr.gsThisComputer;
            label9.Text = gStr.gsPort;
            label7.Text = gStr.gsYoumustRESTARTAgOpenGPS + "\r\n";
            btnSerialOK.Text = gStr.gsSave;
            label4.Text = gStr.gsModulePort;
            label6.Text = gStr.gsPort;
            groupBox1.Text = gStr.gsModuleAdressandPorts;
            label8.Text = gStr.gsAllmodulesuse;
            cboxIsUDPOn.Text = gStr.gsUDPOn;
            groupBox2.Text = gStr.gsNetworking;
            this.Text = gStr.gsEthernetConfiguration;
        }

        private void btnSerialOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.setIP_thisPort = (int)nudThisPort.Value;

            Properties.Settings.Default.setIP_autoSteerIP = tboxAutoSteerIP.Text;
            Properties.Settings.Default.setIP_autoSteerPort = (int)nudAutoSteerPort.Value;

            //Properties.Settings.Default.setIP_rateRelayIP = tboxRateRelayIP.Text;
            //Properties.Settings.Default.setIP_rateRelayPort = (int)nudRateRelayPort.Value;

            Properties.Settings.Default.setUDP_isOn = cboxIsUDPOn.Checked;

            Properties.Settings.Default.Save();

            Close();
        }

        private void FormUDp_Load(object sender, EventArgs e)
        {
            string hostName = Dns.GetHostName(); // Retrieve the Name of HOST
            tboxHostName.Text = hostName;

            //IPAddress[] ipaddress = Dns.GetHostAddresses(hostName);
            tboxThisIP.Text = GetIP4Address();

            nudThisPort.Value = Properties.Settings.Default.setIP_thisPort;

            tboxAutoSteerIP.Text = Properties.Settings.Default.setIP_autoSteerIP;
            nudAutoSteerPort.Value = Properties.Settings.Default.setIP_autoSteerPort;

            //tboxRateRelayIP.Text = Properties.Settings.Default.setIP_rateRelayIP;
            //nudRateRelayPort.Value = Properties.Settings.Default.setIP_rateRelayPort;

            cboxIsUDPOn.CheckedChanged -= cboxIsUDPOn_CheckedChanged;
            cboxIsUDPOn.Checked = Properties.Settings.Default.setUDP_isOn;
            cboxIsUDPOn.CheckedChanged += cboxIsUDPOn_CheckedChanged;
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
                if (strOctet.Length > 3 | strOctet.Length == 0) return false;

                //make sure all digits
                if (!int.TryParse(strOctet, out int temp2)) return false;

                //make sure not more then 255
                temp = int.Parse(strOctet);
                if (temp > MAXVALUE | temp < 0) return false;
            }
            return true;
        }

        private void tboxAutoSteerIP_Validating(object sender, CancelEventArgs e)
        {
            if (!CheckIPValid(tboxAutoSteerIP.Text))
            {
                tboxAutoSteerIP.Text = "127.0.0.1";
                tboxAutoSteerIP.Focus();
                mf.TimedMessageBox(2000, "Invalid IP Address", "Set to Default Local 127.0.0.1");
            }
        }

        //private void tboxRateRelayIP_Validating(object sender, CancelEventArgs e)
        //{
        //    if (!CheckIPValid(tboxRateRelayIP.Text))
        //    {
        //        tboxRateRelayIP.Text = "127.0.0.1";
        //        tboxRateRelayIP.Focus();
        //        mf.TimedMessageBox(2000, "Invalid IP Address", "Set to Default Local 127.0.0.1");
        //    }
        //}

        private void cboxIsUDPOn_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}