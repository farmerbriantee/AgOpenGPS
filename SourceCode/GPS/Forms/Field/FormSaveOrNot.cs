using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormSaveOrNot : Form
    {
        //class variables

        int count = 4;

        public FormSaveOrNot(bool closing)
        {
            InitializeComponent();
        }

        //exit to windows
        private void btnOk_Click(object sender, EventArgs e)
        {
            //back to FormGPS
            DialogResult = DialogResult.OK;
            Close();
        }

        //just cancel and return to aog
        private void btnReturn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore;
            Close();
        }

        //turn off computer
        private void btnShutDown_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count--;
            label1.Text = count.ToString();
            if (count < 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }


        }
    }
}