using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormTrip : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        public FormTrip(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();
        }

        private void FormTrip_Load(object sender, System.EventArgs e)
        {
            if (mf.isMetric) nudAlarm.Value = (decimal)(mf.userSquareMetersAlarm * 0.0001);
            else nudAlarm.Value = (decimal)(mf.userSquareMetersAlarm * 0.00024710499815078974633856493327535);

            if (mf.isMetric) nudSetTrip.Value = (decimal)(mf.totalUserSquareMeters * 0.0001);
            else nudSetTrip.Value = (decimal)(mf.totalUserSquareMeters * 0.00024710499815078974633856493327535);
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (mf.isMetric) nudSetTrip.Value = (decimal)(mf.totalUserSquareMeters * 0.0001);
            else   nudSetTrip.Value = (decimal)(mf.totalUserSquareMeters * 0.00024710499815078974633856493327535);
        }

        private void nudSetTrip_ValueChanged(object sender, System.EventArgs e)
        {
            if (mf.isMetric) mf.totalUserSquareMeters = (double)nudSetTrip.Value * 10000;
            else mf.totalUserSquareMeters = (double)nudSetTrip.Value * 4046.85642;
        }

        private void btnReset1_Click(object sender, System.EventArgs e)
        {
            mf.totalUserSquareMeters = 0;
            nudSetTrip.Value = 0;
        }

        private void btnUp_MouseDown(object sender, MouseEventArgs e)
        {
            nudSetTrip.Value = nudSetTrip.Value + (decimal) 0.1;
        }

        private void btnDown_MouseDown(object sender, MouseEventArgs e)
        {
            nudSetTrip.Value = nudSetTrip.Value - (decimal)0.1;
        }

        //Alarm setup
        private void btnUpAlarm_MouseDown(object sender, MouseEventArgs e)
        {
            nudAlarm.Value = nudAlarm.Value + (decimal)0.1;
        }

        private void btnDnAlarm_MouseDown(object sender, MouseEventArgs e)
        {
            nudAlarm.Value = nudAlarm.Value - (decimal)0.1;
        }

        private void btnResetAlarm_Click(object sender, System.EventArgs e)
        {
            nudAlarm.Value = 0;
        }

        private void nudAlarm_ValueChanged(object sender, System.EventArgs e)
        {
            if (mf.isMetric) mf.userSquareMetersAlarm = (double)nudAlarm.Value * 10000;
            else mf.userSquareMetersAlarm = (double)nudAlarm.Value * 4046.85642;
        }
    }
}
