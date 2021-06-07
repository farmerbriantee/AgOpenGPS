using System;
using System.Diagnostics;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AgDiag
{
    public partial class FormLoop : Form
    {
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr hWind, int nCmdShow);

        public FormLoop()
        {
            InitializeComponent();

        }

        public double secondsSinceStart, lastSecond, currentLat, currentLon;

        private static string ByteArrayToHex(byte[] barray)
        {
            char[] c = new char[barray.Length * 3];
            byte b;
            for (int i = 0; i < barray.Length; ++i)
            {
                b = ((byte)(barray[i] >> 4));
                c[i * 3] = (char)(b > 9 ? b + 0x37 : b + 0x30);
                b = ((byte)(barray[i] & 0xF));
                c[i * 3 + 1] = (char)(b > 9 ? b + 0x37 : b + 0x30);
                c[i * 3 + 2] = (char)0x2D;
            }
            return new string(c);
        }

        private void btnDeviceManager_Click(object sender, EventArgs e)
        {
            Process.Start("devmgmt.msc");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            secondsSinceStart = (DateTime.Now - Process.GetCurrentProcess().StartTime).TotalSeconds;

            DoTraffic();

            if ((asData.pgn[asData.sc1to8] & 1) == 1) lblSection1.BackColor = Color.Green;
            else lblSection1.BackColor = Color.Red;
            if ((asData.pgn[asData.sc1to8] & 2) == 2) lblSection2.BackColor = Color.Green;
            else lblSection2.BackColor = Color.Red;
            if ((asData.pgn[asData.sc1to8] & 4) == 4) lblSection3.BackColor = Color.Green;
            else lblSection3.BackColor = Color.Red;
            if ((asData.pgn[asData.sc1to8] & 8) == 8) lblSection4.BackColor = Color.Green;
            else lblSection4.BackColor = Color.Red;

            if ((asData.pgn[asData.sc1to8] & 16) == 16) lblSection5.BackColor = Color.Green;
            else lblSection5.BackColor = Color.Red;
            if ((asData.pgn[asData.sc1to8] & 32) == 32) lblSection6.BackColor = Color.Green;
            else lblSection6.BackColor = Color.Red;
            if ((asData.pgn[asData.sc1to8] & 64) == 64) lblSection7.BackColor = Color.Green;
            else lblSection7.BackColor = Color.Red;
            if ((asData.pgn[asData.sc1to8] & 128) == 128) lblSection8.BackColor = Color.Green;
            else lblSection8.BackColor = Color.Red;

            lblSpeed.Text = (asData.pgn[asData.speedHi] << 8 | asData.pgn[asData.speedLo]).ToString();
            lblSetSteerAngle.Text = (asData.pgn[asData.steerAngleHi] << 8 | asData.pgn[asData.steerAngleLo]).ToString();
            lblStatus.Text = asData.pgn[asData.status].ToString();

            lblSteerDataPGN.Text = ByteArrayToHex(asData.pgn);

            //from autosteer  module
            lblSteerAngleActual.Text = ((Int16)((asModule.pgn[asModule.actualHi] << 8)
                + asModule.pgn[asModule.actualLo])).ToString();

            lblHeading.Text = ((Int16)((asModule.pgn[asModule.headHi] << 8)
                + asModule.pgn[asModule.headLo])).ToString();

            lblRoll.Text = ((Int16)((asModule.pgn[asModule.rollHi] << 8)
                + asModule.pgn[asModule.rollLo])).ToString();

            lblPWM.Text = (asModule.pgn[asModule.pwm]).ToString();

            if ((asModule.pgn[asModule.switchStatus] & 1) == 1)
                lblWorkSwitch.BackColor = Color.Red;
            else lblWorkSwitch.BackColor = Color.Green;

            if ((asModule.pgn[asModule.switchStatus] & 2) == 2)
                lblSteerSwitch.BackColor = Color.Red;
            else lblSteerSwitch.BackColor = Color.Green;

            lblPGNFromAutosteerModule.Text = ByteArrayToHex(asModule.pgn);

            //Autosteer settings
            lblPGNSteerSettings.Text = ByteArrayToHex(asSet.pgn);
            lblP.Text = asSet.pgn[asSet.gainProportional].ToString();
            lblHiPWM.Text = asSet.pgn[asSet.highPWM].ToString();
            lblLoPWM.Text = asSet.pgn[asSet.lowPWM].ToString();
            lblMinPWM.Text = asSet.pgn[asSet.minPWM].ToString();
            lblCPD.Text = asSet.pgn[asSet.countsPerDegree].ToString();
            lblAckerman.Text = asSet.pgn[asSet.ackerman].ToString();
            lblOffset.Text = (asSet.pgn[asSet.wasOffsetHi] << 8 | asSet.pgn[asSet.wasOffsetLo]).ToString();


            //autosteer config bytes
            lblPGNAutoSteerConfig.Text = ByteArrayToHex(asConfig.pgn);
            lblSet0.Text = asConfig.pgn[asConfig.set0].ToString();
            lblPulseCount.Text = asConfig.pgn[asConfig.maxPulse].ToString();
            lblMinSpeed.Text = asConfig.pgn[asConfig.minSpeed].ToString();
        }

        private void FormLoop_Load(object sender, EventArgs e)
        {

            timer1.Enabled = true;
            LoadLoopback();
        }

        private void FormLoop_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (recvFromLoopBackSocket != null)
            {
                try
                {
                    recvFromLoopBackSocket.Shutdown(SocketShutdown.Both);
                }
                finally { recvFromLoopBackSocket.Close(); }
            }


            if (sendToLoopBackSocket != null)
            {
                try
                {
                    sendToLoopBackSocket.Shutdown(SocketShutdown.Both);
                }
                finally { sendToLoopBackSocket.Close(); }
            }

            if (sendSocket != null)
            {
                try
                {
                    sendSocket.Shutdown(SocketShutdown.Both);
                }
                finally { sendSocket.Close(); }
            }

            if (recvSocket != null)
            {
                try
                {
                    recvSocket.Shutdown(SocketShutdown.Both);
                }
                finally { recvSocket.Close(); }
            }
        }

        private void DoTraffic()
        {
        }



    }
}

