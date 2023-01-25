using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AgIO
{
    public partial class FormUDP : Form
    {
        //class variables
        private readonly FormLoop mf = null;

        //used to send communication check pgn= C8 or 200
        private byte[] sendIPToModules = { 0x80, 0x81, 0x7F, 201, 5, 201, 201, 192, 168, 5, 0x47 };
        private byte[] ipToSend = { 192,168,5 };


        public FormUDP(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormLoop;
            InitializeComponent();

            nudFirstIP.Controls[0].Enabled = false;
            nudSecondIP.Controls[0].Enabled = false;
            nudThirdIP.Controls[0].Enabled = false;
        }

        private void btnSerialOK_Click(object sender, EventArgs e)
        {
        }

        private void FormUDp_Load(object sender, EventArgs e)
        {
            lblHostname.Text = Dns.GetHostName(); // Retrieve the Name of HOST
            tboxModules.Text = "Scanning";

            cboxIsUDPOn.Checked = Properties.Settings.Default.setUDP_isOn;
            cboxPlugin.Checked = Properties.Settings.Default.setUDP_isUsePluginApp;
            cboxIsSendNMEAToUDP.Checked = Properties.Settings.Default.setUDP_isSendNMEAToUDP;

            lblNetworkHelp.Text =
                Properties.Settings.Default.etIP_SubnetOne.ToString() + "." +
                Properties.Settings.Default.etIP_SubnetTwo.ToString() + "." +
                Properties.Settings.Default.etIP_SubnetThree.ToString();

            nudFirstIP.Value = ipToSend[0] = Properties.Settings.Default.etIP_SubnetOne;
            nudSecondIP.Value = ipToSend[1] = Properties.Settings.Default.etIP_SubnetTwo;
            nudThirdIP.Value = ipToSend[2] = Properties.Settings.Default.etIP_SubnetThree;

            if (!cboxIsUDPOn.Checked)
            {
                nudFirstIP.Enabled = false;
                nudSecondIP.Enabled = false;
                nudThirdIP.Enabled = false;
                btnSendSubnet.Enabled = false;
            }

            if (!cboxIsUDPOn.Checked) cboxIsUDPOn.BackColor = System.Drawing.Color.Salmon;

            ScanNetwork();
            //GetIP4AddressList();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //GetIP4AddressList();
            //IsValidNetworkFound();
            if (cboxIsUDPOn.Checked)
            {
                cboxIsSendNMEAToUDP.Enabled = true;
                cboxPlugin.Enabled = true;
            }
            else
            {
                cboxIsSendNMEAToUDP.Enabled = false;
                cboxPlugin.Enabled = false;
                cboxIsSendNMEAToUDP.Checked = false;
                cboxPlugin.Checked = false;
            }

            ScanNetwork();

            tboxModules.Text = mf.scanReturn;
        }

        private void ScanNetwork()
        {
            mf.scanReturn = "";
            tboxNets.Text = "";

            byte[] scanModules = { 0x80, 0x81, 0x7F, 202, 3, 202, 202, 5, 0x47 };
            //mf.SendUDPMessage(scanModules, mf.epModuleSet);

            foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
            {


                if (nic.Supports(NetworkInterfaceComponent.IPv4) )
                {
                    foreach (var info in nic.GetIPProperties().UnicastAddresses)
                    {
                        // Only InterNetwork and not loopback which have a subnetmask
                        if (info.Address.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(info.Address))
                        {
                            Socket scanSocket;
                            try
                            {
                                var properties = nic.GetIPStatistics();
                                tboxNets.Text +=
                                        info.Address + "    Status - " + nic.OperationalStatus + "\r\n";

                                tboxNets.Text += nic.Name.ToString() + "\r\n";
                                tboxNets.Text += "Sent: " + (properties.NonUnicastPacketsSent + properties.UnicastPacketsSent).ToString() 
                                    + "   Recd: " + (properties.NonUnicastPacketsReceived + properties.UnicastPacketsReceived).ToString() + "\r\n\r\n";

                                if ( nic.OperationalStatus == OperationalStatus.Up 
                                    && info.IPv4Mask != null)
                                {
                                    scanSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                                    scanSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
                                    scanSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                                    scanSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontRoute, true);
                                    scanSocket.Bind(new IPEndPoint(info.Address, 9999));

                                    scanSocket.SendTo(scanModules, 0, scanModules.Length, SocketFlags.None, mf.epModuleSet);
                                    scanSocket.Dispose();
                                }
                            }
                            finally
                            {
                            }
                        }
                    }
                }
            }
        }

        private void btnSendSubnet_Click(object sender, EventArgs e)
        {
            {
                DialogResult result3 = MessageBox.Show(
                    "Change Modules and AgIO Subnet To: \r\n\r\n" +
                    ipToSend[0].ToString() + "." +
                    ipToSend[1].ToString() + "." +
                    ipToSend[2].ToString() + " ?",
                    "Are you sure ?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (result3 == DialogResult.Yes)
                {

                    sendIPToModules[7] = ipToSend[0];
                    sendIPToModules[8] = ipToSend[1];
                    sendIPToModules[9] = ipToSend[2];

                    //mf.SendUDPMessage(sendIPToModules, mf.epModuleSet);

                    foreach (var nic in NetworkInterface.GetAllNetworkInterfaces())
                    {
                        if (nic.Supports(NetworkInterfaceComponent.IPv4) && nic.OperationalStatus == OperationalStatus.Up)
                        {
                            foreach (var info in nic.GetIPProperties().UnicastAddresses)
                            {
                                // Only InterNetwork and not loopback which have a subnetmask
                                if (info.Address.AddressFamily == AddressFamily.InterNetwork &&
                                    !IPAddress.IsLoopback(info.Address) &&
                                    info.IPv4Mask != null)
                                {

                                    var scanSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                                    try
                                    {
                                        scanSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
                                        scanSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                                        scanSocket.Bind(new IPEndPoint(info.Address, 9999));

                                        scanSocket.SendTo(sendIPToModules, 0, sendIPToModules.Length, SocketFlags.None, mf.epModuleSet);
                                    }
                                    finally
                                    {
                                        scanSocket.Dispose();
                                    }
                                }
                            }
                        }
                    }

                    Properties.Settings.Default.etIP_SubnetOne = ipToSend[0];
                    Properties.Settings.Default.etIP_SubnetTwo = ipToSend[1];
                    Properties.Settings.Default.etIP_SubnetThree = ipToSend[2];

                    //lblNetworkHelp.Text =
                    //    ipToSend[0].ToString() + "." +
                    //    ipToSend[1].ToString() + "." +
                    //    ipToSend[2].ToString();

                    //counter = 0;

                    Properties.Settings.Default.setUDP_isOn = cboxIsUDPOn.Checked;
                    Properties.Settings.Default.setUDP_isUsePluginApp = cboxPlugin.Checked;
                    Properties.Settings.Default.setUDP_isSendNMEAToUDP = cboxIsSendNMEAToUDP.Checked;

                    Properties.Settings.Default.Save();
                    Application.Restart();
                    Environment.Exit(0);
                    Close();
                }
                else
                {
                    btnSendSubnet.Enabled = false;
                    nudFirstIP.Value = ipToSend[0] = Properties.Settings.Default.etIP_SubnetOne;
                    nudSecondIP.Value = ipToSend[1] = Properties.Settings.Default.etIP_SubnetTwo;
                    nudThirdIP.Value = ipToSend[2] = Properties.Settings.Default.etIP_SubnetThree;
                }
            }
        }

        private void nudFirstIP_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
            ipToSend[0] = (byte)nudFirstIP.Value;
            btnSendSubnet.Enabled = true;
        }

        private void nudSecondIP_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
            ipToSend[1] = (byte)nudSecondIP.Value;
            btnSendSubnet.Enabled = true;
        }

        private void nudThirdIP_Click(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender, this);
            ipToSend[2] = (byte)nudThirdIP.Value;
            btnSendSubnet.Enabled = true;
        }


        private void cboxPlugin_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.setUDP_isOn = cboxIsUDPOn.Checked;
            Properties.Settings.Default.setUDP_isUsePluginApp = cboxPlugin.Checked;
            Properties.Settings.Default.setUDP_isSendNMEAToUDP = cboxIsSendNMEAToUDP.Checked;

            Properties.Settings.Default.Save();
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
