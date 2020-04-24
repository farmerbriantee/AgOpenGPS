//Please, if you use this, share the improvements

using AgOpenGPS.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormDisplayOptions : Form
    {
        //class variables
        private readonly FormGPS mf = null;


        //constructor
        public FormDisplayOptions(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();

            //Language keys
            this.Text = gStr.gsOptions;

            chkExtraGuides.Text = gStr.gsExtraGuides;
            chkGrid.Text = gStr.gsGridOn;
            chkLogNMEA.Text = gStr.gsLogNMEA;
            chkPolygons.Text = gStr.gsPolygonsOn;
            chkPursuitLines.Text = gStr.gsPursuitLine;
            chkSky.Text = gStr.gsSkyOn;
            chkUTurnOn.Text = gStr.gsUTurnAlwaysOn;
            chkCompass.Text = gStr.gsCompassOn;
            chkSpeedo.Text = gStr.gsSpeedoOn;
            chkStartFullScreen.Text = gStr.gsStartFullScreen;
            chkDayNight.Text = gStr.gsAutoDayNightMode;

            rbtnMetric.Text = gStr.gsMetric;
            rbtnImperial.Text = gStr.gsImperial;
            unitsGroupBox.Text = gStr.gsUnits;

        }
        private void FormDisplaySettings_Load(object sender, EventArgs e)
        {
            chkSky.Checked = mf.isSkyOn;
            chkGrid.Checked = mf.isGridOn;
            chkCompass.Checked = mf.isCompassOn;
            chkSpeedo.Checked = mf.isSpeedoOn;
            chkDayNight.Checked = mf.isAutoDayNight;
            chkStartFullScreen.Checked = Properties.Settings.Default.setDisplay_isStartFullScreen;
            chkExtraGuides.Checked = mf.isSideGuideLines;
            chkLogNMEA.Checked = mf.isLogNMEA;
            chkPolygons.Checked = mf.isDrawPolygons;
            chkPursuitLines.Checked = mf.isPureDisplayOn;
            chkUTurnOn.Checked = mf.isUTurnAlwaysOn;

            if (mf.isMetric) rbtnMetric.Checked = true;
            else rbtnImperial.Checked = true;
        }
        private void bntOK_Click(object sender, EventArgs e)
        {
            mf.isSkyOn = chkSky.Checked;
            mf.isGridOn = chkGrid.Checked;
            mf.isCompassOn = chkCompass.Checked;
            mf.isSpeedoOn = chkSpeedo.Checked;
            mf.isAutoDayNight = chkDayNight.Checked;
            mf.isSideGuideLines = chkExtraGuides.Checked;
            mf.isLogNMEA = chkLogNMEA.Checked;
            mf.isDrawPolygons = chkPolygons.Checked;
            mf.isPureDisplayOn = chkPursuitLines.Checked;
            mf.isUTurnAlwaysOn = chkUTurnOn.Checked;

            Settings.Default.setMenu_isSkyOn = mf.isSkyOn;
            Settings.Default.setMenu_isGridOn = mf.isGridOn;
            Settings.Default.setMenu_isCompassOn = mf.isCompassOn;
            Settings.Default.setMenu_isSpeedoOn = mf.isSpeedoOn;
            Settings.Default.setDisplay_isAutoDayNight = mf.isAutoDayNight;
            Settings.Default.setDisplay_isStartFullScreen = chkStartFullScreen.Checked;
            Settings.Default.setMenu_isSideGuideLines = mf.isSideGuideLines;
            Settings.Default.setMenu_isLogNMEA = mf.isLogNMEA;
            mf.isDrawPolygons = chkPolygons.Checked ;
            Settings.Default.setMenu_isPureOn = mf.isPureDisplayOn;
            Settings.Default.setMenu_isUTurnAlwaysOn = mf.isUTurnAlwaysOn;

            if (rbtnMetric.Checked) { Settings.Default.setMenu_isMetric = true; mf.isMetric = true; }
            else { Settings.Default.setMenu_isMetric = false; mf.isMetric = false; }

            Settings.Default.Save();
            Close();
        }
    }
}