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
            btnSteerMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssSteerOffset].ToString();
            lblWheelbase.Text = Convert.ToString(Math.Round(mf.vehicle.wheelbase,1));

            btnSaveOK.Enabled = false;
            nudRadius.Enabled = false;
            btnCalculate.Enabled = false;
        }

        public FormWizardSteer(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void btnSaveOK_Click(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssCountsPerDegree] = (byte)(countsPerDegree);
            Properties.Settings.Default.setAS_countsPerDegree = mf.mc.autoSteerSettings[mf.mc.ssCountsPerDegree];
            Properties.Settings.Default.Save();
        }

        private void btnSerialCancel_Click(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssCountsPerDegree] = (byte)(prevSteerCount*10);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            words = mf.mc.serialRecvAutoSteerStr.Split(',');
            if (words.Length == 5)
                lblRawSteer.Text = (words[0]);
        }

        private void btnSteerPlus_Click(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssSteerOffset] += 1;
            btnSteerMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssSteerOffset].ToString();
            Properties.Settings.Default.setAS_steerAngleOffset = mf.mc.autoSteerSettings[mf.mc.ssSteerOffset];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnSteerMinus_Click(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssSteerOffset] -= 1;
            btnSteerMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssSteerOffset].ToString();
            Properties.Settings.Default.setAS_steerAngleOffset = mf.mc.autoSteerSettings[mf.mc.ssSteerOffset];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //diameter entered so /2 for radius
            steerAngle = glm.toDegrees( Math.Asin(mf.vehicle.wheelbase / ((double)(nudRadius.Value) / 2.0)));
            lblSteerAngle.Text = Math.Round(steerAngle,1).ToString();
            countsPerDegree = (double)(nudRawData.Value) / steerAngle;
            lblCountsPerDegree.Text = Math.Round(countsPerDegree,1).ToString();
            btnSaveOK.Enabled = true;
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
