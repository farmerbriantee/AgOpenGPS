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
                btnOpenField.Visible = false;
                label1.Visible = false; 

            }
            else
            {
                btnOk.Image = Properties.Resources.FieldClose;
                label3.Text = "Close";
                label1.Text = gStr.gsField;
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

        private void btnOpenField_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }
    }
}
