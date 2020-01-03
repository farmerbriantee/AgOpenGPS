//Please, if you use this, share the improvements

using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormArduinoSettings : Form
    {
        //class variables
        private readonly FormGPS mf = null;


        //constructor
        public FormArduinoSettings(Form callingForm, int page)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();

            //Language keys

            nudMaxSpeed.Controls[0].Enabled = false;

            //select the page as per calling menu or button from mainGPS form
            tabControl1.SelectedIndex = page;
        }

        //do any field initializing for form here
        private void FormToolSettings_Load(object sender, EventArgs e)
        {


        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Tool  ------------------------------------------------------------------------------------------


            //back to FormGPS
            DialogResult = DialogResult.OK;
            Close();
        }

        private void NudHitchLength_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void chkInvertWAS_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}