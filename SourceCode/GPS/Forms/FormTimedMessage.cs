using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormTimedMessage : Form
    {
        //class variables
        //private FormGPS mf = null;

        public FormTimedMessage(int timeInMsec, string titleString, string messageString)
        {
            InitializeComponent();

            //get copy of the calling main form
            //mf = callingForm as FormGPS;

            lblMessage.Text = titleString;
            lblMessage2.Text = messageString;

            timer1.Interval = timeInMsec;

            int messWidth = messageString.Length;
            Width = messWidth * 15 + 120;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Dispose();
            Dispose();
            Close();
        }
    }
}