using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AgIO
{
    public partial class FormUDPMonitor : Form
    {
        //class variables
        private readonly FormLoop mf = null;

        private bool logOn = false;

        public FormUDPMonitor(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormLoop;
            InitializeComponent();
        }

        private void FormUDp_Load(object sender, EventArgs e)
        {
            mf.isUDPMonitorOn = true;
            timer1.Enabled = true;
            logOn = true;
        }


        private void btnSerialCancel_Click(object sender, EventArgs e)
        {
            mf.isUDPMonitorOn = false;
            Close();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            logOn = !logOn;
            if (logOn)
            {
                btnLog.BackColor = Color.LightGreen;
                mf.isUDPMonitorOn = true;
                timer1.Enabled = true;
            }
            else
            {
                btnLog.BackColor = Color.Salmon;
                mf.isUDPMonitorOn = false;
                timer1.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBoxRcv.AppendText(mf.logUDPSentence.ToString());
            mf.logUDPSentence.Clear();
        }

        private void btnFileSave_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("zAgIO_UDP_log.txt", false))
            {
                writer.Write(textBoxRcv.Text);
            }

            mf.TimedMessageBox(2000, "File Saved", "To zAgIO_UDP_Log.Txt");
        }

        private void FormUDPMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.isUDPMonitorOn = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxRcv.Text = "";
        }

        private void btnLogNMEA_Click(object sender, EventArgs e)
        {

            mf.isGPSLogOn = !mf.isGPSLogOn;

            if (mf.isGPSLogOn) btnLogNMEA.BackColor = Color.LightGreen;
            else btnLogNMEA.BackColor = Color.Salmon;
        }

        private void btnLogNTRIP_Click(object sender, EventArgs e)
        {

            mf.isNTRIPLogOn = !mf.isNTRIPLogOn;

            if (mf.isNTRIPLogOn) btnLogNTRIP.BackColor = Color.LightGreen;
            else btnLogNTRIP.BackColor = Color.Salmon;
        }

        private void lblPGNGuide_Click(object sender, EventArgs e)
        {
            var form = new FormPGN();
                form.Show(this);

        }
    }
}
