using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormTimedMessage : Form
    {
        //class variables
        private FormGPS mf = null;

        public FormTimedMessage(Form callingForm, int timeInMsec, string str, string str2)
        {
            InitializeComponent();

            //get copy of the calling main form
            mf = callingForm as FormGPS;

            lblMessage.Text = str;
            lblMessage2.Text = str2;

            timer1.Interval = timeInMsec;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
