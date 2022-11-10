using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormSaveOrNot : Form
    {
        //class variables

        public FormSaveOrNot(bool closing)
        {
            InitializeComponent();

            if (closing)
            {
                btnOk.Image = Properties.Resources.ExitAOG;
            }
            else
            {
                btnOk.Image = Properties.Resources.FieldClose;
                label3.Text = "Close";
            }

            if (closing)
            {
                btnSaveAs.Visible = false;
                label4.Visible = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //back to FormGPS
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore;
            Close();
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }
    }
}
