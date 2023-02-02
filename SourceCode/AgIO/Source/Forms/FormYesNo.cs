using System;
using System.Windows.Forms;

namespace AgIO
{
    public partial class FormYesNo : Form
    {
        public FormYesNo(string messageStr)
        {
            InitializeComponent();

            lblMessage2.Text = messageStr;

            int messWidth = messageStr.Length;
            Width = messWidth * 15 + 180;
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