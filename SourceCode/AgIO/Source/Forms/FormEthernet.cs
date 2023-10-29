using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AgIO
{
    public partial class FormEthernet : Form
    {
        //class variables
        private readonly FormLoop mf = null;

        public FormEthernet(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormLoop;
            InitializeComponent();

            nudFirstIP.Controls[0].Enabled = false;
            nudSecndIP.Controls[0].Enabled = false;
            nudThirdIP.Controls[0].Enabled = false;
        }

        private void FormUDp_Load(object sender, EventArgs e)
        {

            cboxIsUDPOn.Checked = Properties.Settings.Default.setUDP_isOn;
            cboxPlugin.Checked = Properties.Settings.Default.setUDP_isUsePluginApp;
            cboxIsSendNMEAToUDP.Checked = Properties.Settings.Default.setUDP_isSendNMEAToUDP;

            //nudSub1.Value = Properties.Settings.Default.etIP_SubnetOne;
            //nudSub2.Value = Properties.Settings.Default.etIP_SubnetTwo;
            //nudSub3.Value = Properties.Settings.Default.etIP_SubnetThree;

            nudFirstIP.Value = Properties.Settings.Default.eth_loopOne;
            nudSecndIP.Value = Properties.Settings.Default.eth_loopTwo;
            nudThirdIP.Value = Properties.Settings.Default.eth_loopThree;
            nudFourthIP.Value= Properties.Settings.Default.eth_loopFour;

            if (!cboxIsUDPOn.Checked) cboxIsUDPOn.BackColor = System.Drawing.Color.Salmon;
        }

        private void nudFirstIP_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
        }

        private void btnSerialCancel_Click(object sender, EventArgs e)
        {
            //Properties.Settings.Default.etIP_SubnetOne = (byte)nudSub1.Value;
            //Properties.Settings.Default.etIP_SubnetTwo = (byte)nudSub2.Value;
            //Properties.Settings.Default.etIP_SubnetThree = (byte)nudSub3.Value;

            Properties.Settings.Default.eth_loopOne = (byte)nudFirstIP.Value;
            Properties.Settings.Default.eth_loopTwo = (byte)nudSecndIP.Value;
            Properties.Settings.Default.eth_loopThree = (byte)nudThirdIP.Value;
            Properties.Settings.Default.eth_loopFour = (byte)nudFourthIP.Value;

            Properties.Settings.Default.setUDP_isOn = cboxIsUDPOn.Checked;
            Properties.Settings.Default.setUDP_isUsePluginApp = cboxPlugin.Checked;
            Properties.Settings.Default.setUDP_isSendNMEAToUDP = cboxIsSendNMEAToUDP.Checked;

            Properties.Settings.Default.Save();

            mf.YesMessageBox("AgIO will Restart to Enable UDP Networking Features");

            Application.Restart();
            Environment.Exit(0);
            Close();

        }

        ////get the ipv4 address only
        //public void GetIP4AddressList()
        //{
        //    tboxNets.Text = "";
        //    foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
        //    {
        //        if (IPA.AddressFamily == AddressFamily.InterNetwork)
        //        {
        //            tboxNets.Text += IPA.ToString() + "\r\n";
        //        }
        //    }
        //}

        //public void IsValidNetworkFound()
        //{
        //    foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
        //    {
        //        if (IPA.AddressFamily == AddressFamily.InterNetwork)
        //        {
        //            byte[] data = IPA.GetAddressBytes();
        //            //  Split string by ".", check that array length is 3
        //            if (data[0] == 192 && data[1] == 168 && data[2] == 1)
        //            {
        //                if (data[3] < 255 && data[3] > 1)
        //                {
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
