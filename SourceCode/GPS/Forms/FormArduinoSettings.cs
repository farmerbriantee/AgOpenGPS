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
            label1.Text = gStr.gsMotorDriver;
            label7.Text = gStr.gsRelayType;
            label6.Text = gStr.gsMMAAxis;
            label3.Text = gStr.gsA2DConvertor;
            label5.Text = gStr.gsSteerEnable;
            label8.Text = gStr.gsMinSpeed;
            label4.Text = gStr.gsMaxSpeed;
            chkInvertWAS.Text = gStr.gsInvertWAS;
            chkEthernet.Text = gStr.gsEthernet;
            chkInvertSteer.Text = gStr.gsInvertSteerDirection;
            chkInvertRoll.Text = gStr.gsInvertRoll;
            chkBNOInstalled.Text = gStr.gsBNOInstalled;
            checkBox1.Text = gStr.gsEncoder;

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