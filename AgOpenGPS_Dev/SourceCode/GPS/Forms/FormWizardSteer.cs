using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormWizardSteer : Form
    {
        //parent form which is the steering form
        private readonly FormGPS mf = null;
        private double prevSteerCount = 1.0;
        private string[] words;
        private double countsPerDegree = 1;
        private double steerAngle = 0;

        private void FormWizardSteer_Load(object sender, EventArgs e)
        {
            //save a copy in case of cancel
            prevSteerCount = ((mf.mc.autoSteerSettings[mf.mc.ssCountsPerDegree]));
            mf.mc.autoSteerSettings[mf.mc.ssCountsPerDegree] = 1;
            mf.AutoSteerSettingsOutToPort();
            lblWheelbase.Text = Convert.ToString(Math.Round(mf.vehicle.wheelbase,2));
            nudRadius.Enabled = false;
            btnCalculate.Enabled = false;
        }

        public FormWizardSteer(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void btnSerialCancel_Click(object sender, EventArgs e)
        {
            //mf.mc.autoSteerSettings[mf.mc.ssCountsPerDegree] = (byte)(prevSteerCount*10);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            words = mf.mc.serialRecvAutoSteerStr.Split(',');
            if (words.Length == 5)
                lblRawSteer.Text = (words[0]);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //diameter entered so /2 for radius
            steerAngle = glm.toDegrees( Math.Asin(mf.vehicle.wheelbase / ((double)(nudRadius.Value) / 2.0)));
            lblSteerAngle.Text = Math.Round(steerAngle,1).ToString();
            countsPerDegree = (double)(nudRawData.Value) / steerAngle;
            lblCountsPerDegree.Text = Math.Round(countsPerDegree,1).ToString();
        }

        private void nudRawData_ValueChanged(object sender, EventArgs e)
        {
            nudRadius.Enabled = true;
        }

        private void nudRadius_ValueChanged(object sender, EventArgs e)
        {
            btnCalculate.Enabled = true;
        }
    }
}
