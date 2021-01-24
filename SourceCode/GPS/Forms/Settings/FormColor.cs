//Please, if you use this, share the improvements

using AgOpenGPS.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormColor : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        private bool daySet;

        //constructor
        public FormColor(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();

            //Language keys
            this.Text = gStr.gsColors;
        }
        private void FormDisplaySettings_Load(object sender, EventArgs e)
        {
            daySet = mf.isDay;
        }
        private void bntOK_Click(object sender, EventArgs e)
        {
            if (daySet != mf.isDay) mf.SwapDayNightMode();
            Close();
        }

        private void btnFrameDay_Click(object sender, EventArgs e)
        {
            if (!mf.isDay) mf.SwapDayNightMode();

            using (var form = new FormColorPicker(mf, mf.dayColor))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    mf.dayColor = form.useThisColor;
                }
            }

            Properties.Settings.Default.setDisplay_colorDayMode = mf.dayColor;
            Settings.Default.Save();

            mf.SwapDayNightMode();
            mf.SwapDayNightMode();
        }

        private void btnFrameNight_Click(object sender, EventArgs e)
        {
            if (mf.isDay) mf.SwapDayNightMode();

            using (var form = new FormColorPicker(mf, mf.nightColor))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    mf.nightColor = form.useThisColor;
                }
            }

            Properties.Settings.Default.setDisplay_colorNightMode = mf.nightColor;
            Settings.Default.Save();

            mf.SwapDayNightMode();
            mf.SwapDayNightMode();
        }

        private void btnFieldDay_Click(object sender, EventArgs e)
        {
            if (!mf.isDay) mf.SwapDayNightMode();

            using (var form = new FormColorPicker(mf, mf.fieldColorDay))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    mf.fieldColorDay = form.useThisColor;
                }
            }


            Settings.Default.setDisplay_colorFieldDay = mf.fieldColorDay;
            Settings.Default.Save();
        }

        private void btnFieldNight_Click(object sender, EventArgs e)
        {
            if (mf.isDay) mf.SwapDayNightMode();

            using (var form = new FormColorPicker(mf, mf.fieldColorNight))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    mf.fieldColorNight = form.useThisColor;
                }
            }

            Settings.Default.setDisplay_colorFieldNight = mf.fieldColorNight;
            Settings.Default.Save();
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            mf.SwapDayNightMode();
        }
    }
}