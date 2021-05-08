using System;
using System.Windows.Forms;

namespace RateController
{
    public partial class FormTimedMessage : Form
    {
        public FormTimedMessage(string str1, string str2 = "", int timeInMsec = 3000)
        {
            InitializeComponent();

            lblMessage.Text = str1;
            lblMessage2.Text = str2;

            timer1.Interval = timeInMsec;

            int messWidth = str1.Length;
            if (str2.Length > messWidth) messWidth = str2.Length;
            Width = messWidth * 15 + 50;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Dispose();
            Dispose();
            Close();
        }

        private void FormTimedMessage_Load(object sender, EventArgs e)
        {

        }
    }
}