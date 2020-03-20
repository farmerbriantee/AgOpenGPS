//Please, if you use this give me some credit
//Copyright BrianTee, copy right out of it.

using System;
using System.Globalization;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormModules : Form
    {
        private readonly FormGPS mf = null;

        double disp = 0;
        int dispInt = 0;

        public FormModules(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] words = mf.mc.serialRecvAutoSteerStr.Split(',');
            if (words.Length == 5)
            {
                double.TryParse(words[0], NumberStyles.Float, CultureInfo.InvariantCulture, out disp);
                lblFromASActual.Text = disp.ToString();

                double.TryParse(words[1], NumberStyles.Float, CultureInfo.InvariantCulture, out disp);
                lblFromAsSet.Text = disp.ToString();

                int.TryParse(words[2], NumberStyles.Float, CultureInfo.InvariantCulture, out dispInt);
                lblFromAsHeading.Text = dispInt.ToString();

                int.TryParse(words[3], NumberStyles.Float, CultureInfo.InvariantCulture, out dispInt);
                lblFromAsRoll.Text = dispInt.ToString();

                int.TryParse(words[4], out dispInt);
                lblFromAsSwitch.Text = Convert.ToString
                                (dispInt, 2).PadLeft(8, '0');
            }

            //PGN MachineData

            lblPgnHiRd.Text = Convert.ToString(mf.mc.machineData[mf.mc.mdHeaderHi]);
            lblPgnLoRd.Text = Convert.ToString(mf.mc.machineData[mf.mc.mdHeaderLo]);

            lblSectionLoByte.Text = Convert.ToString
                (mf.mc.machineData[mf.mc.mdSectionControlByteLo], 2).PadLeft(8, '0');
            lblSectionHiByte.Text = Convert.ToString
                (mf.mc.machineData[mf.mc.mdSectionControlByteHi], 2).PadLeft(8, '0');

            lblSpd.Text = Convert.ToString (mf.mc.machineData[mf.mc.mdSpeedXFour]);

            lblUTurn.Text = Convert.ToString
                (mf.mc.machineData[mf.mc.mdUTurn], 2).PadLeft(8, '0');

            lblTree.Text = Convert.ToString
                (mf.mc.machineData[mf.mc.mdTree], 2).PadLeft(8, '0');

            lblMachine.Text = Convert.ToString
                (mf.mc.machineData[mf.mc.mdHydLift], 2).PadLeft(8, '0');

            //Steer Data
            lblPgnHiSd.Text = Convert.ToString(mf.mc.autoSteerData[mf.mc.sdHeaderHi]);
            lblPgnLoSd.Text = Convert.ToString(mf.mc.autoSteerData[mf.mc.sdHeaderLo]);

            //lblSectionLoSd.Text = Convert.ToString
            //    (mf.mc.autoSteerData[mf.mc.sdMachineLo], 2).PadLeft(8, '0');

            lblSpdSd.Text = Convert.ToString(mf.mc.autoSteerData[mf.mc.sdSpeed]);

            lblDistHi.Text = Convert.ToString(mf.mc.autoSteerData[mf.mc.sdDistanceHi]);
            lblDistLo.Text = Convert.ToString(mf.mc.autoSteerData[mf.mc.sdDistanceLo]);

            lblAngleHi.Text = Convert.ToString(mf.mc.autoSteerData[mf.mc.sdSteerAngleHi]);
            lblAngleLo.Text = Convert.ToString(mf.mc.autoSteerData[mf.mc.sdSteerAngleLo]);

            //lblUTurnSd.Text = Convert.ToString
            //    (mf.mc.autoSteerData[mf.mc.sdYouTurnByte], 2).PadLeft(8, '0');

        }
    }
}