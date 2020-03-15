using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RateApp
{
    public partial class FormRate : Form
    {

        public FormRate()
        {
            InitializeComponent();
        }

        private void serialPortsMenu_Click(object sender, EventArgs e)
        {
            SettingsCommunications();
        }



        private void SettingsCommunications()
        {
            using (var form = new FormCommSet(this))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                }
            }
        }

        private void FormRate_Load(object sender, EventArgs e)
        {
            //set baud and port from last time run
            baudRate = Properties.Settings.Default.setPort_baudRate;
            portName = Properties.Settings.Default.setPort_portName;

            //try and open
            SerialPortOpen();

            //start udp Comms
            LoadUDP();
        }
    }
}
