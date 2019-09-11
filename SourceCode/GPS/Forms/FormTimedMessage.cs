using System;
using System.Drawing;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormTimedMessage : Form
    {
        //class variables
        //private FormGPS mf = null;

        public FormTimedMessage(int timeInMsec, string str, string str2)
        {
            InitializeComponent();

            //get copy of the calling main form
            //mf = callingForm as FormGPS;

            lblMessage.Text = str;
            lblMessage2.Text = str2;

            timer1.Interval = timeInMsec;

            int messWidth = str.Length;
            int mess = str2.Length;
            if (messWidth > mess)
            {
                Size size = TextRenderer.MeasureText(str, lblMessage.Font);
                Width = size.Width + 75;
            }
            else
            {
                Size size = TextRenderer.MeasureText(str2, lblMessage2.Font);
                Width = size.Width + 75;
                //Width = mess * 15 + 75;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
