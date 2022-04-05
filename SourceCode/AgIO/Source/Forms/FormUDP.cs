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

        public FormUDP(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormLoop;
            InitializeComponent();
            //groupBox4.Text = gStr.gsDriveServer;
            //label11.Text = gStr.gsAllmodulessendto;
            //tboxHostName.Text = gStr.gsHostName;
            //label14.Text = gStr.gsHost;
            //label1.Text = gStr.gsThisComputer;
            //label9.Text = gStr.gsPort;
            //label7.Text = gStr.gsYoumustRESTARTDrive + "\r\n";
            //btnSerialOK.Text = gStr.gsSave;
            //label4.Text = gStr.gsModulePort;
            //label6.Text = gStr.gsPort;
            //groupBox1.Text = gStr.gsModuleAdressandPorts;
            //label8.Text = gStr.gsAllmodulesuse;
            //cboxIsUDPOn.Text = gStr.gsUDPOn;
            //groupBox2.Text = gStr.gsNetworking;
            //this.Text = gStr.gsEthernetConfiguration;
        }

        private void btnSerialOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.setUDP_isOn = cboxIsUDPOn.Checked;
            Properties.Settings.Default.setUDP_isUsePluginApp = cboxPlugin.Checked;
            Properties.Settings.Default.setUDP_isSendNMEAToUDP = cboxIsSendNMEAToUDP.Checked;

            Properties.Settings.Default.Save();

            Close();
        }

        private void FormUDp_Load(object sender, EventArgs e)
        {
            string hostName = Dns.GetHostName(); // Retrieve the Name of HOST
            tboxHostName.Text = hostName;

            GetIP4AddressList();

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
    }
}