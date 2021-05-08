using AgOpenGPS;
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace RateController
{
    public partial class FormAbout : Form
    {
        private FormStart mf;
        private bool Initializing = false;

        public FormAbout(FormStart CallingForm)
        {
            InitializeComponent();
            #region // language

            groupBox3.Text = Lang.lgNetworkConnections;
            label27.Text = Lang.lgDestinationIP;
            label18.Text = Lang.lgSendPort;
            label19.Text = Lang.lgReceivePort;
            btnCancel.Text = Lang.lgCancel;
            bntOK.Text = Lang.lgClose;

            #endregion  // language

            mf = CallingForm;
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            Button ButtonClicked = (Button)sender;
            if (ButtonClicked.Text == Lang.lgClose)
            {
                this.Close();
            }
            else
            {
                string tmp = IPA1.Text + "." + IPA2.Text + "." + IPA3.Text + ".255";

                mf.UDPnetwork.BroadCastIP = tmp;
                mf.Tls.SaveProperty("BroadCastIP", mf.UDPnetwork.BroadCastIP);
                SetButtons(false);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Initializing = true;
            LoadIP();
            Initializing = false;

            SetButtons(false);
        }

        private void FormAbout_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                mf.Tls.SaveFormData(this);
            }
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            mf.Tls.LoadFormData(this);

            lbVersion.Text = Lang.lgVersionDate + "   " + mf.Tls.VersionDate();

            Initializing = true;
            LoadIP();
            Initializing = false;
            SetDayMode();
        }

        private void groupBox3_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            mf.Tls.DrawGroupBox(box, e.Graphics, this.BackColor, Color.Black, Color.Blue);
        }

        private void groupBox4_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            mf.Tls.DrawGroupBox(box, e.Graphics, this.BackColor, Color.Black, Color.Blue);
        }

        private void IPA1_Click(object sender, EventArgs e)
        {
            double tempD;
            double.TryParse(IPA1.Text, out tempD);
            using (var form = new FormNumeric(0, 255, tempD))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    IPA1.Text = form.ReturnValue.ToString();
                }
            }
        }

        private void IPA1_TextChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void IPA2_Click(object sender, EventArgs e)
        {
            double tempD;
            double.TryParse(IPA2.Text, out tempD);
            using (var form = new FormNumeric(0, 255, tempD))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    IPA2.Text = form.ReturnValue.ToString();
                }
            }
        }

        private void IPA2_TextChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void IPA3_Click(object sender, EventArgs e)
        {
            double tempD;
            double.TryParse(IPA3.Text, out tempD);
            using (var form = new FormNumeric(0, 255, tempD))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    IPA3.Text = form.ReturnValue.ToString();
                }
            }
        }

        private void IPA3_TextChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void LoadIP()
        {
            IPAddress tmp = mf.UDPnetwork.GetBroadCastIP;
            byte[] Parts = tmp.GetAddressBytes();
            IPA1.Text = Parts[0].ToString();
            IPA2.Text = Parts[1].ToString();
            IPA3.Text = Parts[2].ToString();
        }

        private void SetButtons(bool Edited)
        {
            if (!Initializing)
            {
                if (Edited)
                {
                    btnCancel.Enabled = true;
                    this.bntOK.Text = Lang.lgSave;
                }
                else
                {
                    btnCancel.Enabled = false;
                    this.bntOK.Text = Lang.lgClose;
                }
            }
        }

        private void SetDayMode()
        {
            this.BackColor = Properties.Settings.Default.DayColour;
        }
    }
}