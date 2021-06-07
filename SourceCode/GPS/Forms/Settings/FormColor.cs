//Please, if you use this, share the improvements

using AgOpenGPS.Properties;
using System;
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
            hsbarOpacity.Value = Properties.Settings.Default.setDisplay_vehicleOpacity;
            cboxIsImage.Checked = mf.isVehicleImage;
        }
        private void bntOK_Click(object sender, EventArgs e)
        {
            if (daySet != mf.isDay) mf.SwapDayNightMode();
            Properties.Settings.Default.setDisplay_vehicleOpacity = hsbarOpacity.Value;
            mf.vehicleOpacity = (hsbarOpacity.Value * 0.01);
            mf.vehicleOpacityByte = (byte)(255 * (hsbarOpacity.Value * 0.01));

            mf.isVehicleImage = cboxIsImage.Checked;
            Properties.Settings.Default.setDisplay_isVehicleImage = cboxIsImage.Checked;
            Settings.Default.Save();
            Close();
        }

        private void btnVehicleColor_Click(object sender, EventArgs e)
        {
            using (FormColorPicker form = new FormColorPicker(mf, mf.vehicleColor))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    mf.vehicleColor = form.useThisColor;
                }
            }

            Properties.Settings.Default.setDisplay_colorVehicle = mf.vehicleColor;
            Settings.Default.Save();
        }

        private void btnFrameDay_Click(object sender, EventArgs e)
        {
            if (!mf.isDay) mf.SwapDayNightMode();

            using (FormColorPicker form = new FormColorPicker(mf, mf.frameDayColor))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    mf.frameDayColor = form.useThisColor;
                }
            }

            Properties.Settings.Default.setDisplay_colorDayFrame = mf.frameDayColor;
            Settings.Default.Save();

            mf.SwapDayNightMode();
            mf.SwapDayNightMode();
        }

        private void btnFrameNight_Click(object sender, EventArgs e)
        {
            if (mf.isDay) mf.SwapDayNightMode();

            using (FormColorPicker form = new FormColorPicker(mf, mf.frameNightColor))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    mf.frameNightColor = form.useThisColor;
                }
            }

            Properties.Settings.Default.setDisplay_colorNightFrame = mf.frameNightColor;
            Settings.Default.Save();

            mf.SwapDayNightMode();
            mf.SwapDayNightMode();
        }

        private void btnFieldDay_Click(object sender, EventArgs e)
        {
            if (!mf.isDay) mf.SwapDayNightMode();

            using (FormColorPicker form = new FormColorPicker(mf, mf.fieldColorDay))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    mf.fieldColorDay = form.useThisColor;
                }
            }


            Settings.Default.setDisplay_colorFieldDay = mf.fieldColorDay;
            Settings.Default.Save();

            mf.SwapDayNightMode();
            mf.SwapDayNightMode();
        }

        private void btnFieldNight_Click(object sender, EventArgs e)
        {
            if (mf.isDay) mf.SwapDayNightMode();

            using (FormColorPicker form = new FormColorPicker(mf, mf.fieldColorNight))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    mf.fieldColorNight = form.useThisColor;
                }
            }

            Settings.Default.setDisplay_colorFieldNight = mf.fieldColorNight;
            Settings.Default.Save();

            mf.SwapDayNightMode();
            mf.SwapDayNightMode();
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            mf.SwapDayNightMode();
        }

        private void btnNightText_Click(object sender, EventArgs e)
        {
            if (mf.isDay) mf.SwapDayNightMode();

            using (FormColorPicker form = new FormColorPicker(mf, mf.textColorNight))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    mf.textColorNight = form.useThisColor;
                }
            }

            Settings.Default.setDisplay_colorTextNight = mf.textColorNight;
            Settings.Default.Save();

            mf.SwapDayNightMode();
            mf.SwapDayNightMode();
        }

        private void btnDayText_Click(object sender, EventArgs e)
        {
            if (!mf.isDay) mf.SwapDayNightMode();

            using (FormColorPicker form = new FormColorPicker(mf, mf.textColorDay))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    mf.textColorDay = form.useThisColor;
                }
            }

            Settings.Default.setDisplay_colorTextDay = mf.textColorDay;
            Settings.Default.Save();

            mf.SwapDayNightMode();
            mf.SwapDayNightMode();
        }

        private void hsbarOpacity_ValueChanged(object sender, EventArgs e)
        {
            lblOpacityPercent.Text = hsbarOpacity.Value.ToString();
        }
    }
}