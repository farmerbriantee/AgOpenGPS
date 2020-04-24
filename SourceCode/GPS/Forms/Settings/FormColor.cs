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
            ColorDialog colorDlg = new ColorDialog
            {
                FullOpen = true,
                AnyColor = true,
                SolidColorOnly = true,
                Color = Properties.Settings.Default.setDisplay_colorDayMode
            };
            colorDlg.CustomColors = mf.customColorsList;

            if (colorDlg.ShowDialog() != DialogResult.OK) return;

            mf.dayColor = colorDlg.Color;

            //save the custom colors
            mf.customColorsList = colorDlg.CustomColors;
            Properties.Settings.Default.setDisplay_customColors = "";
            for (int i = 0; i < 15; i++)
                Properties.Settings.Default.setDisplay_customColors += mf.customColorsList[i].ToString() + ",";
            Properties.Settings.Default.setDisplay_customColors += mf.customColorsList[15].ToString();


            Properties.Settings.Default.setDisplay_colorDayMode = mf.dayColor;
            Settings.Default.Save();
        }

        private void btnFrameNight_Click(object sender, EventArgs e)
        {
            if (mf.isDay) mf.SwapDayNightMode();

            ColorDialog colorDlg = new ColorDialog
            {
                FullOpen = true,
                AnyColor = true,
                SolidColorOnly = true,
                Color = Properties.Settings.Default.setDisplay_colorNightMode
            };
            colorDlg.CustomColors = mf.customColorsList;

            if (colorDlg.ShowDialog() != DialogResult.OK) return;

            mf.nightColor = colorDlg.Color;

            //save the custom colors
            mf.customColorsList = colorDlg.CustomColors;
            Properties.Settings.Default.setDisplay_customColors = "";
            for (int i = 0; i < 15; i++)
                Properties.Settings.Default.setDisplay_customColors += mf.customColorsList[i].ToString() + ",";
            Properties.Settings.Default.setDisplay_customColors += mf.customColorsList[15].ToString();

            Properties.Settings.Default.setDisplay_colorNightMode = mf.nightColor;
            Settings.Default.Save();
        }

        private void btnFieldDay_Click(object sender, EventArgs e)
        {
            if (!mf.isDay) mf.SwapDayNightMode();

            ColorDialog colorDlg = new ColorDialog
            {
                FullOpen = true,
                AnyColor = true,
                SolidColorOnly = false,
                Color = Settings.Default.setDisplay_colorFieldDay
            };
            colorDlg.CustomColors = mf.customColorsList;

            if (colorDlg.ShowDialog() != DialogResult.OK) return;

            mf.fieldColorDay = colorDlg.Color;

            //save the custom colors
            mf.customColorsList = colorDlg.CustomColors;
            Properties.Settings.Default.setDisplay_customColors = "";
            for (int i = 0; i < 15; i++)
                Properties.Settings.Default.setDisplay_customColors += mf.customColorsList[i].ToString() + ",";
            Properties.Settings.Default.setDisplay_customColors += mf.customColorsList[15].ToString();


            Settings.Default.setDisplay_colorFieldDay = mf.fieldColorDay;
            Settings.Default.Save();
        }

        private void btnFieldNight_Click(object sender, EventArgs e)
        {
            if (mf.isDay) mf.SwapDayNightMode();

            ColorDialog colorDlg = new ColorDialog
            {
                FullOpen = true,
                AnyColor = true,
                SolidColorOnly = false,
                Color = Settings.Default.setDisplay_colorFieldNight
            };
            colorDlg.CustomColors = mf.customColorsList;

            if (colorDlg.ShowDialog() != DialogResult.OK) return;

            mf.fieldColorNight = colorDlg.Color;

            //save the custom colors
            mf.customColorsList = colorDlg.CustomColors;
            Properties.Settings.Default.setDisplay_customColors = "";
            for (int i = 0; i < 15; i++)
                Properties.Settings.Default.setDisplay_customColors += mf.customColorsList[i].ToString() + ",";
            Properties.Settings.Default.setDisplay_customColors += mf.customColorsList[15].ToString();

            Settings.Default.setDisplay_colorFieldNight = mf.fieldColorNight;
            Settings.Default.Save();
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            mf.SwapDayNightMode();
        }
    }
}