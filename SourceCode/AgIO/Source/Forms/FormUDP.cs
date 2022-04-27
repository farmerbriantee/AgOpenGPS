using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AgIO
{
    public partial class FormUDP : Form
    {
        //class variables
        private readonly FormLoop mf = null;

        bool isFound = false;

        public FormUDP(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormLoop;
            InitializeComponent();
        }

        private void btnSerialOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.setUDP_isOn = cboxIsUDPOn.Checked;
            Properties.Settings.Default.setUDP_isUsePluginApp = cboxPlugin.Checked;
            Properties.Settings.Default.setUDP_isSendNMEAToUDP = cboxIsSendNMEAToUDP.Checked;

            Properties.Settings.Default.Save();
            Application.Restart();
            Environment.Exit(0);
            Close();
        }

        private void FormUDp_Load(object sender, EventArgs e)
        {
            string hostName = Dns.GetHostName(); // Retrieve the Name of HOST
            tboxHostName.Text = hostName;
            
            cboxIsUDPOn.Checked = Properties.Settings.Default.setUDP_isOn;
            cboxPlugin.Checked = Properties.Settings.Default.setUDP_isUsePluginApp;
            cboxIsSendNMEAToUDP.Checked = Properties.Settings.Default.setUDP_isSendNMEAToUDP;
        }

        //get the ipv4 address only
        public void GetIP4AddressList()
        {
            listboxIP.Items.Clear();

            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily == AddressFamily.InterNetwork)
                {
                    listboxIP.Items.Add(IPA.ToString());
                }
            }
        }

        public void IsValidNetworkFound()
        {
            isFound = false;

            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily == AddressFamily.InterNetwork)
                {
                    byte[] data = IPA.GetAddressBytes();
                    //  Split string by ".", check that array length is 3
                    if (data[0] == 192 && data[1] == 168 && data[2] == 5)
                    {
                        if (data[3] < 255 && data[3] > 1)
                        {
                            isFound = true;
                            break;
                        }
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetIP4AddressList();
            IsValidNetworkFound();
            if (cboxIsUDPOn.Checked)
            {
                pboxNetwork.Visible = true;
                if (isFound)
                {
                    pboxNetwork.Image = Properties.Resources.Check_OK;
                }
                else
                {
                    pboxNetwork.Image = Properties.Resources.Check_Error;
                }

                cboxIsSendNMEAToUDP.Enabled = true;
                cboxPlugin.Enabled = true;
            }
            else
            {
                pboxNetwork.Visible = false;
                cboxIsSendNMEAToUDP.Enabled = false;
                cboxPlugin.Enabled = false;
                cboxIsSendNMEAToUDP.Checked = false;
                cboxPlugin.Checked = false;
            }
        }

        private void cboxIsUDPOn_Click(object sender, EventArgs e)
        {
        }
    }
}