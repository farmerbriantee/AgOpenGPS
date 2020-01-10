//Please, if you use this, share the improvements

using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormToolSettings : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        private double toolOverlap, toolTrailingHitchLength, tankTrailingHitchLength, toolOffset, toolTurnOffDelay, toolLookAhead;
        private double hitchLength;

        private bool isToolTrailing, isToolBehindPivot, isToolTBT;
        private int numberOfSections, minApplied;

        private decimal sectionWidth1, sectionWidth2, sectionWidth3, sectionWidth4, sectionWidth5, sectionWidth6,
                        sectionWidth7, sectionWidth8, sectionWidth9, sectionWidth10, sectionWidth11, sectionWidth12,
                        sectionWidth13, sectionWidth14, sectionWidth15, sectionWidth16;

        private decimal sectionPosition1, sectionPosition2, sectionPosition3, sectionPosition4,
                        sectionPosition5, sectionPosition6, sectionPosition7, sectionPosition8, sectionPosition9,
                        sectionPosition10, sectionPosition11, sectionPosition12, sectionPosition13, sectionPosition14,
                        sectionPosition15, sectionPosition16, sectionPosition17;

        private bool isWorkSwEn, isWorkSwActiveLow, isWorkSwitchManual;

        private readonly double metImp2m, m2MetImp, maxWidth ;
        private double cutoffSpeed, cutoffMetricImperial;

        //constructor
        public FormToolSettings(Form callingForm, int page)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();

            //Language keys
            gboxAttachment.Text = gStr.gsAttachmentStyle;
            tabHitch.Text = gStr.gsHitch;
            tabConfig.Text = gStr.gsConfiguration;
            tabSections.Text = gStr.gsSection;
            tabSettings.Text = gStr.gsSettings;
            tabWorkSwitch.Text = gStr.gsSwitches;

            label23.Text = gStr.gsTurnOffDelaySecs;
            label3.Text = gStr.gsTurnOnAheadSecs;
            label41.Text = gStr.gsMinUnapplied;
            label2.Text = gStr.gs_OfSections;

            lblTurnOffBelowUnits.Text = gStr.gsKMH;
            label30.Text = gStr.gsSectionsTurnOffBelow;

            groupBox3.Text = gStr.gsWorkSwitch;
            checkWorkSwitchManual.Text = gStr.gsWorkSwitchControlsManual;
            chkWorkSwActiveLow.Text = gStr.gsActiveLow;
            chkEnableWorkSwitch.Text = gStr.gsEnableWorkSwitch;
            label17.Text = gStr.gsMeasurementsIn;
            label16.Text = gStr.gsToolWidth;

            Text = gStr.gsToolSettings;

            nudCutoffSpeed.Controls[0].Enabled = false;
            nudForeAft.Controls[0].Enabled = false;
            nudHitchLength.Controls[0].Enabled = false;
            nudLookAhead.Controls[0].Enabled = false;
            nudMinApplied.Controls[0].Enabled = false;
            nudDefaultSectionWidth.Controls[0].Enabled = false;
            nudOffset.Controls[0].Enabled = false;
            nudOverlap.Controls[0].Enabled = false;
            nudSection1.Controls[0].Enabled = false;
            nudSection2.Controls[0].Enabled = false;
            nudSection3.Controls[0].Enabled = false;
            nudSection4.Controls[0].Enabled = false;
            nudSection5.Controls[0].Enabled = false;
            nudSection6.Controls[0].Enabled = false;
            nudSection7.Controls[0].Enabled = false;
            nudSection8.Controls[0].Enabled = false;
            nudSection9.Controls[0].Enabled = false;
            nudSection10.Controls[0].Enabled = false;
            nudSection11.Controls[0].Enabled = false;
            nudSection12.Controls[0].Enabled = false;
            nudSection13.Controls[0].Enabled = false;
            nudSection14.Controls[0].Enabled = false;
            nudSection15.Controls[0].Enabled = false;
            nudSection16.Controls[0].Enabled = false;
            nudTankHitch.Controls[0].Enabled = false;
            nudTurnOffDelay.Controls[0].Enabled = false;

            if (mf.isMetric)
            {
                metImp2m = 0.01;
                m2MetImp = 100.0;
                lblInchesCm.Text = gStr.gsCentimeters;
                lblSecTotalWidthFeet.Visible = false;
                lblSecTotalWidthInches.Visible = false;
                lblSecTotalWidthMeters.Visible = true;
                lblDoNotExceed.Text = "* < 5000 cm*";
                maxWidth = 5000;
            }
            else
            {
                metImp2m = glm.in2m;
                m2MetImp = glm.m2in;
                lblInchesCm.Text = gStr.gsInches;
                lblSecTotalWidthFeet.Visible = true;
                lblSecTotalWidthInches.Visible = true;
                lblSecTotalWidthMeters.Visible = false;
                lblDoNotExceed.Text = "* < 1968 inches *";
                maxWidth = 1968;
            }
            //select the page as per calling menu or button from mainGPS form
            tabControl1.SelectedIndex = page;
        }

        //do any field initializing for form here
        private void FormToolSettings_Load(object sender, EventArgs e)
        {
            if (mf.isJobStarted)
            {
                cboxNumSections.Enabled = false;
                nudDefaultSectionWidth.Enabled = false;
            }

            hitchLength = Math.Abs(Properties.Vehicle.Default.setVehicle_hitchLength);
            if (nudHitchLength.CheckValueCm(ref hitchLength)) nudHitchLength.BackColor = System.Drawing.Color.OrangeRed;

            toolTrailingHitchLength = Math.Abs(Properties.Vehicle.Default.setTool_toolTrailingHitchLength);
            if (nudForeAft.CheckValueCm(ref toolTrailingHitchLength)) nudForeAft.BackColor = System.Drawing.Color.OrangeRed;

            tankTrailingHitchLength = Math.Abs(Properties.Vehicle.Default.setVehicle_tankTrailingHitchLength);
            if (nudTankHitch.CheckValueCm(ref tankTrailingHitchLength)) nudTankHitch.BackColor = System.Drawing.Color.OrangeRed;

            toolOverlap = Properties.Vehicle.Default.setVehicle_toolOverlap;
            if (nudOverlap.CheckValueCm(ref toolOverlap)) nudOverlap.BackColor = System.Drawing.Color.OrangeRed;

            toolOffset = Properties.Vehicle.Default.setVehicle_toolOffset;
            if (nudOffset.CheckValueCm(ref toolOffset)) nudOffset.BackColor = System.Drawing.Color.OrangeRed;

            decimal temp;
            toolTurnOffDelay = Properties.Vehicle.Default.setVehicle_toolTurnOffDelay;
            temp = (decimal)toolTurnOffDelay;
            if (nudTurnOffDelay.CheckValue(ref temp)) nudTurnOffDelay.BackColor = System.Drawing.Color.OrangeRed;
            toolTurnOffDelay = (double)temp;

            minApplied = Properties.Vehicle.Default.setVehicle_minApplied;
            temp = minApplied;
            if (nudMinApplied.CheckValue(ref temp)) nudMinApplied.BackColor = System.Drawing.Color.OrangeRed;

            toolLookAhead = Properties.Vehicle.Default.setVehicle_lookAhead;
            temp = (decimal)toolLookAhead;
            if (nudLookAhead.CheckValue(ref temp)) nudLookAhead.BackColor = System.Drawing.Color.OrangeRed;
            toolLookAhead = (double)temp;

            numberOfSections = Properties.Vehicle.Default.setVehicle_numSections;
            temp = numberOfSections;
            
            isToolBehindPivot = Properties.Vehicle.Default.setTool_isToolBehindPivot;
            isToolTrailing = Properties.Vehicle.Default.setTool_isToolTrailing;
            isToolTBT = Properties.Vehicle.Default.setTool_isToolTBT;

            if (!isToolBehindPivot)
            {
                rbtnTBT.Checked = false;
                rbtnTrailing.Checked = false;
                rbtnFixedRear.Checked = false;
                rbtnFront.Checked = true;
            }
            else if (isToolTBT)
            {
                rbtnTBT.Checked = true;
                rbtnTrailing.Checked = false;
                rbtnFixedRear.Checked = false;
                rbtnFront.Checked = false;
            }
            else if (!isToolTrailing)
            {
                rbtnTBT.Checked = false;
                rbtnTrailing.Checked = false;
                rbtnFixedRear.Checked = true;
                rbtnFront.Checked = false;
            }
            else
            {
                rbtnTBT.Checked = false;
                rbtnTrailing.Checked = true;
                rbtnFixedRear.Checked = false;
                rbtnFront.Checked = false;
            }

            btnChangeAttachment.Enabled = false;

            FixRadioButtonsAndImages();

            //fix the min max based on inches - they are 2.54 times smaller then cm
            if (!mf.isMetric)
            {
                nudTankHitch.Maximum /= 2.54M;
                nudTankHitch.Minimum /= 2.54M;

                nudForeAft.Maximum /= 2.54M;
                nudForeAft.Minimum /= 2.54M;

                nudOverlap.Maximum /= 2.54M;
                nudOverlap.Minimum /= 2.54M;

                nudOffset.Maximum /= 2.54M;
                nudOffset.Minimum /= 2.54M;

                nudCutoffSpeed.Maximum /= 1.60934M;
                nudCutoffSpeed.Minimum /= 1.60934M;

                nudSection1.Maximum /= 2.54M;
                nudSection1.Minimum /= 2.54M;
                nudSection2.Maximum /= 2.54M;
                nudSection2.Minimum /= 2.54M;
                nudSection3.Maximum /= 2.54M;
                nudSection3.Minimum /= 2.54M;
                nudSection4.Maximum /= 2.54M;
                nudSection4.Minimum /= 2.54M;
                nudSection5.Maximum /= 2.54M;
                nudSection5.Minimum /= 2.54M;
                nudSection6.Maximum /= 2.54M;
                nudSection6.Minimum /= 2.54M;
                nudSection7.Maximum /= 2.54M;
                nudSection7.Minimum /= 2.54M;
                nudSection8.Maximum /= 2.54M;
                nudSection8.Minimum /= 2.54M;
                nudSection9.Maximum /= 2.54M;
                nudSection9.Minimum /= 2.54M;
                nudSection10.Maximum /= 2.54M;
                nudSection10.Minimum /= 2.54M;
                nudSection11.Maximum /= 2.54M;
                nudSection11.Minimum /= 2.54M;
                nudSection12.Maximum /= 2.54M;
                nudSection12.Minimum /= 2.54M;
                nudSection13.Maximum /= 2.54M;
                nudSection13.Minimum /= 2.54M;
                nudSection14.Maximum /= 2.54M;
                nudSection14.Minimum /= 2.54M;
                nudSection15.Maximum /= 2.54M;
                nudSection15.Minimum /= 2.54M;
                nudSection16.Maximum /= 2.54M;
                nudSection16.Minimum /= 2.54M;

                nudDefaultSectionWidth.Maximum /= 2.54M;
                nudDefaultSectionWidth.Minimum /= 2.54M;

                lblTurnOffBelowUnits.Text = gStr.gsMPH;
                cutoffMetricImperial = 1.60934;

            }
            else
            {
                lblTurnOffBelowUnits.Text = gStr.gsKMH;
                cutoffMetricImperial = 1;
            }

            nudHitchLength.ValueChanged -= nudHitchLength_ValueChanged;
            nudHitchLength.Value = (decimal)(hitchLength * m2MetImp);
            nudHitchLength.ValueChanged += nudHitchLength_ValueChanged;

            nudMinApplied.ValueChanged -= nudMinApplied_ValueChanged;
            nudMinApplied.Value = (decimal)(minApplied);
            nudMinApplied.ValueChanged += nudMinApplied_ValueChanged;

            nudOverlap.ValueChanged -= nudOverlap_ValueChanged;
            nudOverlap.Value = (decimal)(toolOverlap * m2MetImp);
            nudOverlap.ValueChanged += nudOverlap_ValueChanged;

            nudForeAft.ValueChanged -= nudForeAft_ValueChanged;
            nudForeAft.Value = (decimal)(toolTrailingHitchLength * m2MetImp);
            nudForeAft.ValueChanged += nudForeAft_ValueChanged;

            nudTankHitch.ValueChanged -= nudTankHitch_ValueChanged;
            nudTankHitch.Value = (decimal)(tankTrailingHitchLength * m2MetImp);
            nudTankHitch.ValueChanged += nudTankHitch_ValueChanged;

            nudOffset.ValueChanged -= nudOffset_ValueChanged;
            nudOffset.Value = (decimal)(toolOffset * m2MetImp);
            nudOffset.ValueChanged += nudOffset_ValueChanged;

            nudTurnOffDelay.ValueChanged -= nudTurnOffDelay_ValueChanged;
            nudTurnOffDelay.Value = (decimal)(toolTurnOffDelay);
            nudTurnOffDelay.ValueChanged += nudTurnOffDelay_ValueChanged;

            nudLookAhead.ValueChanged -= nudLookAhead_ValueChanged;
            nudLookAhead.Value = (decimal)(toolLookAhead);
            nudLookAhead.ValueChanged += nudLookAhead_ValueChanged;

            cboxNumSections.Text = numberOfSections.ToString();

            //calc the 8 section widths based on settings.settings also meters to inches
            nudSection1.Value = Math.Abs((Properties.Vehicle.Default.setSection_position2 - Properties.Vehicle.Default.setSection_position1) * (decimal)m2MetImp);
            nudSection2.Value = Math.Abs((Properties.Vehicle.Default.setSection_position3 - Properties.Vehicle.Default.setSection_position2) * (decimal)m2MetImp);
            nudSection3.Value = Math.Abs((Properties.Vehicle.Default.setSection_position4 - Properties.Vehicle.Default.setSection_position3) * (decimal)m2MetImp);
            nudSection4.Value = Math.Abs((Properties.Vehicle.Default.setSection_position5 - Properties.Vehicle.Default.setSection_position4) * (decimal)m2MetImp);
            nudSection5.Value = Math.Abs((Properties.Vehicle.Default.setSection_position6 - Properties.Vehicle.Default.setSection_position5) * (decimal)m2MetImp);
            nudSection6.Value = Math.Abs((Properties.Vehicle.Default.setSection_position7 - Properties.Vehicle.Default.setSection_position6) * (decimal)m2MetImp);
            nudSection7.Value = Math.Abs((Properties.Vehicle.Default.setSection_position8 - Properties.Vehicle.Default.setSection_position7) * (decimal)m2MetImp);
            nudSection8.Value = Math.Abs((Properties.Vehicle.Default.setSection_position9 - Properties.Vehicle.Default.setSection_position8) * (decimal)m2MetImp);
            nudSection9.Value = Math.Abs((Properties.Vehicle.Default.setSection_position10 - Properties.Vehicle.Default.setSection_position9) * (decimal)m2MetImp);
            nudSection10.Value = Math.Abs((Properties.Vehicle.Default.setSection_position11 - Properties.Vehicle.Default.setSection_position10) * (decimal)m2MetImp);
            nudSection11.Value = Math.Abs((Properties.Vehicle.Default.setSection_position12 - Properties.Vehicle.Default.setSection_position11) * (decimal)m2MetImp);
            nudSection12.Value = Math.Abs((Properties.Vehicle.Default.setSection_position13 - Properties.Vehicle.Default.setSection_position12) * (decimal)m2MetImp);
            nudSection13.Value = Math.Abs((Properties.Vehicle.Default.setSection_position14 - Properties.Vehicle.Default.setSection_position13) * (decimal)m2MetImp);
            nudSection14.Value = Math.Abs((Properties.Vehicle.Default.setSection_position15 - Properties.Vehicle.Default.setSection_position14) * (decimal)m2MetImp);
            nudSection15.Value = Math.Abs((Properties.Vehicle.Default.setSection_position16 - Properties.Vehicle.Default.setSection_position15) * (decimal)m2MetImp);
            nudSection16.Value = Math.Abs((Properties.Vehicle.Default.setSection_position17 - Properties.Vehicle.Default.setSection_position16) * (decimal)m2MetImp);

            //based on number of sections and values update the page before displaying
            UpdateSpinners();

            isWorkSwActiveLow = Properties.Settings.Default.setF_IsWorkSwitchActiveLow;

            chkWorkSwActiveLow.CheckedChanged -= chkWorkSwActiveLow_CheckedChanged;
            chkWorkSwActiveLow.Checked = isWorkSwActiveLow;
            chkWorkSwActiveLow.CheckedChanged += chkWorkSwActiveLow_CheckedChanged;

            isWorkSwEn = Properties.Settings.Default.setF_IsWorkSwitchEnabled;

            chkEnableWorkSwitch.CheckedChanged -= chkEnableWorkSwitch_CheckedChanged;
            chkEnableWorkSwitch.Checked = isWorkSwEn;
            chkEnableWorkSwitch.CheckedChanged += chkEnableWorkSwitch_CheckedChanged;

            isWorkSwitchManual = Properties.Settings.Default.setF_IsWorkSwitchManual;

            checkWorkSwitchManual.CheckedChanged -= checkWorkSwitchManual_CheckedChanged;
            checkWorkSwitchManual.Checked = isWorkSwitchManual;
            checkWorkSwitchManual.CheckedChanged += checkWorkSwitchManual_CheckedChanged;

            btnChangeAttachment.BackColor = System.Drawing.Color.Transparent;
            btnChangeAttachment.Enabled = false;


            cutoffSpeed = Properties.Vehicle.Default.setVehicle_slowSpeedCutoff / cutoffMetricImperial;
            temp = (decimal)cutoffSpeed;
            if (nudCutoffSpeed.CheckValue(ref temp)) nudCutoffSpeed.BackColor = System.Drawing.Color.OrangeRed;
            cutoffSpeed = (double)temp;

            nudCutoffSpeed.ValueChanged -= nudCutoffSpeed_ValueChanged;
            nudCutoffSpeed.Value = (decimal)cutoffSpeed;
            nudCutoffSpeed.ValueChanged += nudCutoffSpeed_ValueChanged;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Tool  ------------------------------------------------------------------------------------------

            //trailing hitch is always behind
            toolTrailingHitchLength *= -1;
            mf.tool.toolTrailingHitchLength = toolTrailingHitchLength;
            Properties.Vehicle.Default.setTool_toolTrailingHitchLength = mf.tool.toolTrailingHitchLength;

            tankTrailingHitchLength *= -1;
            mf.tool.toolTankTrailingHitchLength = tankTrailingHitchLength;
            Properties.Vehicle.Default.setVehicle_tankTrailingHitchLength = mf.tool.toolTankTrailingHitchLength;

            mf.tool.toolLookAhead = toolLookAhead;
            Properties.Vehicle.Default.setVehicle_lookAhead = mf.tool.toolLookAhead;

            mf.tool.toolOverlap = toolOverlap;
            Properties.Vehicle.Default.setVehicle_toolOverlap = mf.tool.toolOverlap;

            mf.tool.toolTurnOffDelay = toolTurnOffDelay;
            Properties.Vehicle.Default.setVehicle_toolTurnOffDelay = mf.tool.toolTurnOffDelay;

            mf.tool.toolOffset = toolOffset;
            Properties.Vehicle.Default.setVehicle_toolOffset = mf.tool.toolOffset;

            mf.tool.isToolTrailing = isToolTrailing;
            Properties.Vehicle.Default.setTool_isToolTrailing = mf.tool.isToolTrailing;

            mf.tool.isToolBehindPivot = isToolBehindPivot;
            Properties.Vehicle.Default.setTool_isToolBehindPivot = mf.tool.isToolBehindPivot;

            mf.tool.isToolTBT = isToolTBT;
            Properties.Vehicle.Default.setTool_isToolTBT = mf.tool.isToolTBT;

            if (isToolBehindPivot) hitchLength *= -1;
            mf.tool.hitchLength = hitchLength;
            Properties.Vehicle.Default.setVehicle_hitchLength = mf.tool.hitchLength;

            //Slow speed cutoff
            Properties.Vehicle.Default.setVehicle_slowSpeedCutoff = cutoffSpeed * cutoffMetricImperial;
            mf.vehicle.slowSpeedCutoff = cutoffSpeed * cutoffMetricImperial;

            //Sections ------------------------------------------------------------------------------------------

            mf.tool.numOfSections = numberOfSections;
            mf.tool.numSuperSection = numberOfSections + 1;
            Properties.Vehicle.Default.setVehicle_numSections = mf.tool.numOfSections;

            mf.tool.toolMinUnappliedPixels = minApplied;
            Properties.Vehicle.Default.setVehicle_minApplied = minApplied;

            //take the section widths and convert to meters and positions along tool.
            CalculateSectionPositions();

            //save the values in each spinner for section position widths in settings
            Properties.Vehicle.Default.setSection_position1 = sectionPosition1;
            Properties.Vehicle.Default.setSection_position2 = sectionPosition2;
            Properties.Vehicle.Default.setSection_position3 = sectionPosition3;
            Properties.Vehicle.Default.setSection_position4 = sectionPosition4;
            Properties.Vehicle.Default.setSection_position5 = sectionPosition5;
            Properties.Vehicle.Default.setSection_position6 = sectionPosition6;
            Properties.Vehicle.Default.setSection_position7 = sectionPosition7;
            Properties.Vehicle.Default.setSection_position8 = sectionPosition8;
            Properties.Vehicle.Default.setSection_position9 = sectionPosition9;
            Properties.Vehicle.Default.setSection_position10 = sectionPosition10;
            Properties.Vehicle.Default.setSection_position11 = sectionPosition11;
            Properties.Vehicle.Default.setSection_position12 = sectionPosition12;
            Properties.Vehicle.Default.setSection_position13 = sectionPosition13;
            Properties.Vehicle.Default.setSection_position14 = sectionPosition14;
            Properties.Vehicle.Default.setSection_position15 = sectionPosition15;
            Properties.Vehicle.Default.setSection_position16 = sectionPosition16;
            Properties.Vehicle.Default.setSection_position17 = sectionPosition17;

            //line up manual buttons based on # of sections
            mf.LineUpManualBtns();

            //update the sections to newly configured widths and positions in main
            mf.SectionSetPosition();

            //update the widths of sections and tool width in main
            mf.SectionCalcWidths();

            //update toolwidth in mainform
            Properties.Vehicle.Default.setVehicle_toolWidth = mf.tool.toolWidth;

            //WorkSwitch settings
            mf.mc.isWorkSwitchActiveLow = isWorkSwActiveLow;
            Properties.Settings.Default.setF_IsWorkSwitchActiveLow = isWorkSwActiveLow;

            mf.mc.isWorkSwitchEnabled = isWorkSwEn;
            Properties.Settings.Default.setF_IsWorkSwitchEnabled = isWorkSwEn;

            mf.mc.isWorkSwitchManual = isWorkSwitchManual;
            Properties.Settings.Default.setF_IsWorkSwitchManual = isWorkSwitchManual;

            mf.tram.abOffset = (Math.Round((mf.tool.toolWidth - mf.tool.toolOverlap) / 2.0, 3));

            Properties.Settings.Default.Save();
            Properties.Vehicle.Default.Save();

            //back to FormGPS
            DialogResult = DialogResult.OK;
            Close();
        }

        private void NudCutoffSpeed_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void nudCutoffSpeed_ValueChanged(object sender, EventArgs e)
        {
            cutoffSpeed = (double)nudCutoffSpeed.Value;
        }
               
        private void NudHitchLength_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudWheelbase_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudAntennaPivot_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudAntennaHeight_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudAntennaOffset_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudTankHitch_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudForeAft_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudOffset_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudOverlap_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudTurnOffDelay_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void nudDefaultSectionWidth_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();

        }

        private void NudLookAhead_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudSection1_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudSection2_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudSection3_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudSection4_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudSection5_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudSection6_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudSection7_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudSection8_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudSection9_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudSection10_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudSection11_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudSection12_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void nudSection13_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void nudSection14_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void nudSection15_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void nudSection16_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudMinApplied_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void rbtnFront_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;

            // Only do something when the event was raised by the radiobutton 
            // being checked, so we don't do this twice.
            if (radioButton.Checked)
            {
                btnChangeAttachment.Enabled = true;
                btnChangeAttachment.BackColor = System.Drawing.SystemColors.ActiveCaption;

            }
        }

        private void FixRadioButtonsAndImages()
        {
            if (rbtnTrailing.Checked)
            {
                isToolBehindPivot = true;
                isToolTrailing = true;
                isToolTBT = false;

                nudForeAft.Visible = true;
                nudHitchLength.Visible = true;
                nudTankHitch.Visible = false;

                nudForeAft.Left = 596;
                nudHitchLength.Left = 384;
                nudTankHitch.Left = 0;

                tabHitch.BackgroundImage = Properties.Resources.ToolHitchPageTrailing;

            }
            else if (rbtnFixedRear.Checked)
            {
                isToolBehindPivot = true;
                isToolTrailing = false;
                isToolTBT = false;

                nudForeAft.Visible = false;
                nudHitchLength.Visible = true;
                nudTankHitch.Visible = false;

                nudForeAft.Left = 0;
                nudHitchLength.Left = 443;
                nudTankHitch.Left = 0;

                tabHitch.BackgroundImage = Properties.Resources.ToolHitchPageRear;

            }
            else if (rbtnFront.Checked)
            {
                isToolBehindPivot = false;
                isToolTrailing = false;
                isToolTBT = false;

                nudForeAft.Visible = false;
                nudHitchLength.Visible = true;
                nudTankHitch.Visible = false;

                nudForeAft.Left = 0;
                nudHitchLength.Left = 384;
                nudTankHitch.Left = 0;

                tabHitch.BackgroundImage = Properties.Resources.ToolHitchPageFront;

            }
            else //TBT
            {
                isToolBehindPivot = true;
                isToolTrailing = true;
                isToolTBT = true;

                nudForeAft.Visible = true;
                nudHitchLength.Visible = true;
                nudTankHitch.Visible = true;

                nudForeAft.Left = 700;
                nudHitchLength.Left = 283;
                nudTankHitch.Left = 486;

                tabHitch.BackgroundImage = Properties.Resources.ToolHitchPageTBT;
            }
        }

        private void btnChangeAttachment_Click(object sender, EventArgs e)
        {
            btnChangeAttachment.Enabled = false;
            btnChangeAttachment.BackColor = System.Drawing.Color.Transparent;
            FixRadioButtonsAndImages();
            tabControl1.SelectedTab = tabHitch;
            btnNext.Focus();
        }

        private void CboxNumSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            numberOfSections = cboxNumSections.SelectedIndex+1;

            decimal wide = nudDefaultSectionWidth.Value;

            
            if (mf.isMetric)
            {
            if (numberOfSections * wide > 4800) wide = 99;
                
            }
            else
            {
                if (numberOfSections * wide > 1900) wide = 19;
            }

            nudSection1.ValueChanged -= nudSection1_ValueChanged;
            nudSection1.Value = wide;
            nudSection1.ValueChanged += nudSection1_ValueChanged;

            nudSection2.ValueChanged -= nudSection2_ValueChanged;
            nudSection2.Value = wide;
            nudSection2.ValueChanged += nudSection2_ValueChanged;

            nudSection3.ValueChanged -= nudSection3_ValueChanged;
            nudSection3.Value = wide;
            nudSection3.ValueChanged += nudSection3_ValueChanged;

            nudSection4.ValueChanged -= nudSection4_ValueChanged;
            nudSection4.Value = wide;
            nudSection4.ValueChanged += nudSection4_ValueChanged;

            nudSection5.ValueChanged -= nudSection5_ValueChanged;
            nudSection5.Value = wide;
            nudSection5.ValueChanged += nudSection5_ValueChanged;

            nudSection6.ValueChanged -= nudSection6_ValueChanged;
            nudSection6.Value = wide;
            nudSection6.ValueChanged += nudSection6_ValueChanged;

            nudSection7.ValueChanged -= nudSection7_ValueChanged;
            nudSection7.Value = wide;
            nudSection7.ValueChanged += nudSection7_ValueChanged;

            nudSection8.ValueChanged -= nudSection8_ValueChanged;
            nudSection8.Value = wide;
            nudSection8.ValueChanged += nudSection8_ValueChanged;

            nudSection9.ValueChanged -= nudSection9_ValueChanged;
            nudSection9.Value = wide;
            nudSection9.ValueChanged += nudSection9_ValueChanged;

            nudSection10.ValueChanged -= nudSection10_ValueChanged;
            nudSection10.Value = wide;
            nudSection10.ValueChanged += nudSection10_ValueChanged;

            nudSection11.ValueChanged -= nudSection11_ValueChanged;
            nudSection11.Value = wide;
            nudSection11.ValueChanged += nudSection11_ValueChanged;

            nudSection12.ValueChanged -= nudSection12_ValueChanged;
            nudSection12.Value = wide;
            nudSection12.ValueChanged += nudSection12_ValueChanged;

            nudSection13.ValueChanged -= nudSection13_ValueChanged;
            nudSection13.Value = wide;
            nudSection13.ValueChanged += nudSection13_ValueChanged;

            nudSection14.ValueChanged -= nudSection14_ValueChanged;
            nudSection14.Value = wide;
            nudSection14.ValueChanged += nudSection14_ValueChanged;

            nudSection15.ValueChanged -= nudSection15_ValueChanged;
            nudSection15.Value = wide;
            nudSection15.ValueChanged += nudSection15_ValueChanged;

            nudSection16.ValueChanged -= nudSection16_ValueChanged;
            nudSection16.Value = wide;
            nudSection16.ValueChanged += nudSection16_ValueChanged;

            UpdateSpinners();
        }

        //don't save anything, leave the settings as before
        private void btnCancel_Click(object sender, EventArgs e)
        { DialogResult = DialogResult.Cancel; Close(); }

        private void nudHitchLength_ValueChanged(object sender, EventArgs e)
        {
            hitchLength = (double)nudHitchLength.Value * metImp2m;
        }

        private void nudForeAft_ValueChanged(object sender, EventArgs e)
        {
            toolTrailingHitchLength = (double)(nudForeAft.Value) * metImp2m;
        }

        private void nudTankHitch_ValueChanged(object sender, EventArgs e)
        {
            tankTrailingHitchLength = (double)(nudTankHitch.Value) * metImp2m;
        }

        private void nudOffset_ValueChanged(object sender, EventArgs e)
        {
            toolOffset = (double)nudOffset.Value * metImp2m;
        }

        private void nudLookAhead_ValueChanged(object sender, EventArgs e)
        {
            toolLookAhead = (double)nudLookAhead.Value;
        }

        private void nudTurnOffDelay_ValueChanged(object sender, EventArgs e)
        {
            toolTurnOffDelay = (double)nudTurnOffDelay.Value;
        }

        private void nudOverlap_ValueChanged(object sender, EventArgs e)
        {
            toolOverlap = (double)nudOverlap.Value * metImp2m;
        }


        #region Sections //---------------------------------------------------------------

        //enable or disable section width spinners based on number sections selected
        public void UpdateSpinners()
        {
            int i = (int)numberOfSections;
            switch (i)
            {
                case 1:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = false; nudSection2.Visible = false;
                        nudSection3.Enabled = false; nudSection3.Visible = false;
                        nudSection4.Enabled = false; nudSection4.Visible = false;
                        nudSection5.Enabled = false; nudSection5.Visible = false;
                        nudSection6.Enabled = false; nudSection6.Visible = false;
                        nudSection7.Enabled = false; nudSection7.Visible = false;
                        nudSection8.Enabled = false; nudSection8.Visible = false;
                        nudSection9.Enabled = false; nudSection9.Visible = false;
                        nudSection10.Enabled = false; nudSection10.Visible = false;
                        nudSection11.Enabled = false; nudSection11.Visible = false;
                        nudSection12.Enabled = false; nudSection12.Visible = false;
                        nudSection13.Enabled = false; nudSection13.Visible = false;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)nudSection1.Value);
                        break;
                    }
                case 2:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = false; nudSection3.Visible = false;
                        nudSection4.Enabled = false; nudSection4.Visible = false;
                        nudSection6.Enabled = false; nudSection6.Visible = false;
                        nudSection7.Enabled = false; nudSection7.Visible = false;
                        nudSection8.Enabled = false; nudSection8.Visible = false;
                        nudSection5.Enabled = false; nudSection5.Visible = false;
                        nudSection9.Enabled = false; nudSection9.Visible = false;
                        nudSection10.Enabled = false; nudSection10.Visible = false;
                        nudSection11.Enabled = false; nudSection11.Visible = false;
                        nudSection12.Enabled = false; nudSection12.Visible = false;
                        nudSection13.Enabled = false; nudSection13.Visible = false;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value));
                        break;
                    }
                case 3:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = false; nudSection4.Visible = false;
                        nudSection5.Enabled = false; nudSection5.Visible = false;
                        nudSection6.Enabled = false; nudSection6.Visible = false;
                        nudSection7.Enabled = false; nudSection7.Visible = false;
                        nudSection8.Enabled = false; nudSection8.Visible = false;
                        nudSection9.Enabled = false; nudSection9.Visible = false;
                        nudSection10.Enabled = false; nudSection10.Visible = false;
                        nudSection11.Enabled = false; nudSection11.Visible = false;
                        nudSection12.Enabled = false; nudSection12.Visible = false;
                        nudSection13.Enabled = false; nudSection13.Visible = false;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value));
                        break;
                    }
                case 4:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = false; nudSection5.Visible = false;
                        nudSection6.Enabled = false; nudSection6.Visible = false;
                        nudSection7.Enabled = false; nudSection7.Visible = false;
                        nudSection8.Enabled = false; nudSection8.Visible = false;
                        nudSection9.Enabled = false; nudSection9.Visible = false;
                        nudSection10.Enabled = false; nudSection10.Visible = false;
                        nudSection11.Enabled = false; nudSection11.Visible = false;
                        nudSection12.Enabled = false; nudSection12.Visible = false;
                        nudSection13.Enabled = false; nudSection13.Visible = false;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value + nudSection4.Value));
                        break;
                    }
                case 5:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = true; nudSection5.Visible = true;
                        nudSection6.Enabled = false; nudSection6.Visible = false;
                        nudSection7.Enabled = false; nudSection7.Visible = false;
                        nudSection8.Enabled = false; nudSection8.Visible = false;
                        nudSection9.Enabled = false; nudSection9.Visible = false;
                        nudSection10.Enabled = false; nudSection10.Visible = false;
                        nudSection11.Enabled = false; nudSection11.Visible = false;
                        nudSection12.Enabled = false; nudSection12.Visible = false;
                        nudSection13.Enabled = false; nudSection13.Visible = false;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value + nudSection4.Value + nudSection5.Value));
                        break;
                    }
                case 6:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = true; nudSection5.Visible = true;
                        nudSection6.Enabled = true; nudSection6.Visible = true;
                        nudSection7.Enabled = false; nudSection7.Visible = false;
                        nudSection8.Enabled = false; nudSection8.Visible = false;
                        nudSection9.Enabled = false; nudSection9.Visible = false;
                        nudSection10.Enabled = false; nudSection10.Visible = false;
                        nudSection11.Enabled = false; nudSection11.Visible = false;
                        nudSection12.Enabled = false; nudSection12.Visible = false;
                        nudSection13.Enabled = false; nudSection13.Visible = false;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value + nudSection4.Value
                                + nudSection5.Value + nudSection6.Value));
                        break;
                    }
                case 7:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = true; nudSection5.Visible = true;
                        nudSection6.Enabled = true; nudSection6.Visible = true;
                        nudSection7.Enabled = true; nudSection7.Visible = true;
                        nudSection8.Enabled = false; nudSection8.Visible = false;
                        nudSection9.Enabled = false; nudSection9.Visible = false;
                        nudSection10.Enabled = false; nudSection10.Visible = false;
                        nudSection11.Enabled = false; nudSection11.Visible = false;
                        nudSection12.Enabled = false; nudSection12.Visible = false;
                        nudSection13.Enabled = false; nudSection13.Visible = false;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value
                            + nudSection4.Value + nudSection5.Value + nudSection6.Value + nudSection7.Value));
                        break;
                    }
                case 8:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = true; nudSection5.Visible = true;
                        nudSection6.Enabled = true; nudSection6.Visible = true;
                        nudSection7.Enabled = true; nudSection7.Visible = true;
                        nudSection8.Enabled = true; nudSection8.Visible = true;
                        nudSection9.Enabled = false; nudSection9.Visible = false;
                        nudSection10.Enabled = false; nudSection10.Visible = false;
                        nudSection11.Enabled = false; nudSection11.Visible = false;
                        nudSection12.Enabled = false; nudSection12.Visible = false;
                        nudSection13.Enabled = false; nudSection13.Visible = false;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value
                            + nudSection4.Value + nudSection5.Value + nudSection6.Value + nudSection7.Value + nudSection8.Value));
                        break;
                    }

                case 9:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = true; nudSection5.Visible = true;
                        nudSection6.Enabled = true; nudSection6.Visible = true;
                        nudSection7.Enabled = true; nudSection7.Visible = true;
                        nudSection8.Enabled = true; nudSection8.Visible = true;
                        nudSection9.Enabled = true; nudSection9.Visible = true;
                        nudSection10.Enabled = false; nudSection10.Visible = false;
                        nudSection11.Enabled = false; nudSection11.Visible = false;
                        nudSection12.Enabled = false; nudSection12.Visible = false;
                        nudSection13.Enabled = false; nudSection13.Visible = false;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value
                            + nudSection4.Value + nudSection5.Value + nudSection6.Value + nudSection7.Value + nudSection8.Value
                            + nudSection9.Value));
                        break;
                    }

                case 10:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = true; nudSection5.Visible = true;
                        nudSection6.Enabled = true; nudSection6.Visible = true;
                        nudSection7.Enabled = true; nudSection7.Visible = true;
                        nudSection8.Enabled = true; nudSection8.Visible = true;
                        nudSection9.Enabled = true; nudSection9.Visible = true;
                        nudSection10.Enabled = true; nudSection10.Visible = true;
                        nudSection11.Enabled = false; nudSection11.Visible = false;
                        nudSection12.Enabled = false; nudSection12.Visible = false;
                        nudSection13.Enabled = false; nudSection13.Visible = false;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value
                            + nudSection4.Value + nudSection5.Value + nudSection6.Value + nudSection7.Value + nudSection8.Value
                            + nudSection9.Value + nudSection10.Value));
                        break;
                    }

                case 11:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = true; nudSection5.Visible = true;
                        nudSection6.Enabled = true; nudSection6.Visible = true;
                        nudSection7.Enabled = true; nudSection7.Visible = true;
                        nudSection8.Enabled = true; nudSection8.Visible = true;
                        nudSection9.Enabled = true; nudSection9.Visible = true;
                        nudSection10.Enabled = true; nudSection10.Visible = true;
                        nudSection11.Enabled = true; nudSection11.Visible = true;
                        nudSection12.Enabled = false; nudSection12.Visible = false;
                        nudSection13.Enabled = false; nudSection13.Visible = false;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value
                            + nudSection4.Value + nudSection5.Value + nudSection6.Value + nudSection7.Value + nudSection8.Value
                             + nudSection9.Value + nudSection10.Value + nudSection11.Value));
                        break;
                    }

                case 12:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = true; nudSection5.Visible = true;
                        nudSection6.Enabled = true; nudSection6.Visible = true;
                        nudSection7.Enabled = true; nudSection7.Visible = true;
                        nudSection8.Enabled = true; nudSection8.Visible = true;
                        nudSection9.Enabled = true; nudSection9.Visible = true;
                        nudSection10.Enabled = true; nudSection10.Visible = true;
                        nudSection11.Enabled = true; nudSection11.Visible = true;
                        nudSection12.Enabled = true; nudSection12.Visible = true;
                        nudSection13.Enabled = false; nudSection13.Visible = false;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value
                            + nudSection4.Value + nudSection5.Value + nudSection6.Value + nudSection7.Value + nudSection8.Value
                            + nudSection9.Value + nudSection10.Value + nudSection11.Value + nudSection12.Value));
                        break;
                    }

                case 13:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = true; nudSection5.Visible = true;
                        nudSection6.Enabled = true; nudSection6.Visible = true;
                        nudSection7.Enabled = true; nudSection7.Visible = true;
                        nudSection8.Enabled = true; nudSection8.Visible = true;
                        nudSection9.Enabled = true; nudSection9.Visible = true;
                        nudSection10.Enabled = true; nudSection10.Visible = true;
                        nudSection11.Enabled = true; nudSection11.Visible = true;
                        nudSection12.Enabled = true; nudSection12.Visible = true;
                        nudSection13.Enabled = true; nudSection13.Visible = true;
                        nudSection14.Enabled = false; nudSection14.Visible = false;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value
                            + nudSection4.Value + nudSection5.Value + nudSection6.Value + nudSection7.Value + nudSection8.Value
                            + nudSection9.Value + nudSection10.Value + nudSection11.Value + nudSection12.Value
                            + nudSection13.Value));
                        break;
                    }

                case 14:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = true; nudSection5.Visible = true;
                        nudSection6.Enabled = true; nudSection6.Visible = true;
                        nudSection7.Enabled = true; nudSection7.Visible = true;
                        nudSection8.Enabled = true; nudSection8.Visible = true;
                        nudSection9.Enabled = true; nudSection9.Visible = true;
                        nudSection10.Enabled = true; nudSection10.Visible = true;
                        nudSection11.Enabled = true; nudSection11.Visible = true;
                        nudSection12.Enabled = true; nudSection12.Visible = true;
                        nudSection13.Enabled = true; nudSection13.Visible = true;
                        nudSection14.Enabled = true; nudSection14.Visible = true;
                        nudSection15.Enabled = false; nudSection15.Visible = false;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value
                            + nudSection4.Value + nudSection5.Value + nudSection6.Value + nudSection7.Value + nudSection8.Value
                            + nudSection9.Value + nudSection10.Value + nudSection11.Value + nudSection12.Value
                            + nudSection13.Value + nudSection14.Value));
                        break;
                    }

                case 15:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = true; nudSection5.Visible = true;
                        nudSection6.Enabled = true; nudSection6.Visible = true;
                        nudSection7.Enabled = true; nudSection7.Visible = true;
                        nudSection8.Enabled = true; nudSection8.Visible = true;
                        nudSection9.Enabled = true; nudSection9.Visible = true;
                        nudSection10.Enabled = true; nudSection10.Visible = true;
                        nudSection11.Enabled = true; nudSection11.Visible = true;
                        nudSection12.Enabled = true; nudSection12.Visible = true;
                        nudSection13.Enabled = true; nudSection13.Visible = true;
                        nudSection14.Enabled = true; nudSection14.Visible = true;
                        nudSection15.Enabled = true; nudSection15.Visible = true;
                        nudSection16.Enabled = false; nudSection16.Visible = false;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value
                            + nudSection4.Value + nudSection5.Value + nudSection6.Value + nudSection7.Value + nudSection8.Value
                            + nudSection9.Value + nudSection10.Value + nudSection11.Value + nudSection12.Value
                            + nudSection13.Value + nudSection14.Value + nudSection15.Value));
                        break;
                    }

                case 16:
                    {
                        nudSection1.Enabled = true; nudSection1.Visible = true;
                        nudSection2.Enabled = true; nudSection2.Visible = true;
                        nudSection3.Enabled = true; nudSection3.Visible = true;
                        nudSection4.Enabled = true; nudSection4.Visible = true;
                        nudSection5.Enabled = true; nudSection5.Visible = true;
                        nudSection6.Enabled = true; nudSection6.Visible = true;
                        nudSection7.Enabled = true; nudSection7.Visible = true;
                        nudSection8.Enabled = true; nudSection8.Visible = true;
                        nudSection9.Enabled = true; nudSection9.Visible = true;
                        nudSection10.Enabled = true; nudSection10.Visible = true;
                        nudSection11.Enabled = true; nudSection11.Visible = true;
                        nudSection12.Enabled = true; nudSection12.Visible = true;
                        nudSection13.Enabled = true; nudSection13.Visible = true;
                        nudSection14.Enabled = true; nudSection14.Visible = true;
                        nudSection15.Enabled = true; nudSection15.Visible = true;
                        nudSection16.Enabled = true; nudSection16.Visible = true;

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value
                            + nudSection4.Value + nudSection5.Value + nudSection6.Value + nudSection7.Value + nudSection8.Value
                            + nudSection9.Value + nudSection10.Value + nudSection11.Value + nudSection12.Value
                            + nudSection13.Value + nudSection14.Value + nudSection15.Value + nudSection16.Value));
                        break;
                    }

            }
            //update in settings dialog ONLY total tool width
            SectionFeetInchesTotalWidthLabelUpdate();
        }

        //the minimum speed before sections turn off

        private void nudMinApplied_ValueChanged(object sender, EventArgs e)
        {
            minApplied = (int)nudMinApplied.Value;
        }

        //update tool width label at bottom of window
        private void SectionFeetInchesTotalWidthLabelUpdate()
        {
            if (mf.isMetric)
            {
                lblSecTotalWidthMeters.Text = Convert.ToDouble(lblVehicleToolWidth.Text) + " cm";
            }
            else
            {
                double toFeet = (Convert.ToDouble(lblVehicleToolWidth.Text) * 0.08334);
                lblSecTotalWidthFeet.Text = Convert.ToString((int)toFeet) + "'";
                double temp = Math.Round((toFeet - Math.Truncate(toFeet)) * 12, 0);
                lblSecTotalWidthInches.Text = Convert.ToString(temp) + '"';
            }
        }

        //Convert section width to positions along toolbar
        private void CalculateSectionPositions()
        {
            int i = (int)numberOfSections;

            //convert to meters spinner value
            sectionWidth1 = nudSection1.Value * (decimal)metImp2m;
            sectionWidth2 = nudSection2.Value * (decimal)metImp2m;
            sectionWidth3 = nudSection3.Value * (decimal)metImp2m;
            sectionWidth4 = nudSection4.Value * (decimal)metImp2m;
            sectionWidth5 = nudSection5.Value * (decimal)metImp2m;
            sectionWidth6 = nudSection6.Value * (decimal)metImp2m;
            sectionWidth7 = nudSection7.Value * (decimal)metImp2m;
            sectionWidth8 = nudSection8.Value * (decimal)metImp2m;
            sectionWidth9 = nudSection9.Value * (decimal)metImp2m;
            sectionWidth10 = nudSection10.Value * (decimal)metImp2m;
            sectionWidth11 = nudSection11.Value * (decimal)metImp2m;
            sectionWidth12 = nudSection12.Value * (decimal)metImp2m;
            sectionWidth13 = nudSection13.Value * (decimal)metImp2m;
            sectionWidth14 = nudSection14.Value * (decimal)metImp2m;
            sectionWidth15 = nudSection15.Value * (decimal)metImp2m;
            sectionWidth16 = nudSection16.Value * (decimal)metImp2m;

            switch (i)
            {
                case 1:
                    {
                        sectionPosition2 = sectionWidth1 / 2.0M;
                        sectionPosition1 = sectionPosition2 * -1;
                        sectionPosition3 = 0;
                        sectionPosition4 = 0;
                        sectionPosition5 = 0;
                        sectionPosition6 = 0;
                        sectionPosition7 = 0;
                        sectionPosition8 = 0;
                        sectionPosition9 = 0;
                        sectionPosition10 = 0;
                        sectionPosition11 = 0;
                        sectionPosition12 = 0;
                        sectionPosition13 = 0;
                        sectionPosition14 = 0;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;

                        break;
                    }
                case 2:
                    {
                        sectionPosition1 = sectionWidth1 * -1;
                        sectionPosition2 = 0;
                        sectionPosition3 = sectionWidth2;
                        sectionPosition4 = 0;
                        sectionPosition5 = 0;
                        sectionPosition6 = 0;
                        sectionPosition7 = 0;
                        sectionPosition8 = 0;
                        sectionPosition9 = 0;
                        sectionPosition10 = 0;
                        sectionPosition11 = 0;
                        sectionPosition12 = 0;
                        sectionPosition13 = 0;
                        sectionPosition14 = 0;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;

                        break;
                    }
                case 3:
                    {
                        sectionPosition3 = sectionWidth2 / 2.0M;
                        sectionPosition2 = sectionPosition3 * -1;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition4 = sectionPosition3 + sectionWidth3;
                        sectionPosition5 = 0;
                        sectionPosition6 = 0;
                        sectionPosition7 = 0;
                        sectionPosition8 = 0;
                        sectionPosition9 = 0;
                        sectionPosition10 = 0;
                        sectionPosition11 = 0;
                        sectionPosition12 = 0;
                        sectionPosition13 = 0;
                        sectionPosition14 = 0;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;

                        break;
                    }
                case 4:
                    {
                        sectionPosition2 = sectionWidth2 * -1;
                        sectionPosition3 = 0;
                        sectionPosition4 = sectionWidth3;
                        sectionPosition5 = sectionWidth3 + sectionWidth4;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition6 = 0;
                        sectionPosition7 = 0;
                        sectionPosition8 = 0;
                        sectionPosition9 = 0;
                        sectionPosition10 = 0;
                        sectionPosition11 = 0;
                        sectionPosition12 = 0;
                        sectionPosition13 = 0;
                        sectionPosition14 = 0;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;

                        break;
                    }
                case 5:
                    {
                        sectionPosition4 = sectionWidth3 / 2.0M;
                        sectionPosition3 = sectionPosition4 * -1;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition5 = sectionPosition4 + sectionWidth4;
                        sectionPosition6 = sectionPosition5 + sectionWidth5;
                        sectionPosition7 = 0;
                        sectionPosition8 = 0;
                        sectionPosition9 = 0;
                        sectionPosition10 = 0;
                        sectionPosition11 = 0;
                        sectionPosition12 = 0;
                        sectionPosition13 = 0;
                        sectionPosition14 = 0;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;

                        break;
                    }
                case 6:
                    {
                        sectionPosition4 = 0;
                        sectionPosition3 = sectionWidth3 * -1;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition5 = sectionWidth4;
                        sectionPosition6 = sectionPosition5 + sectionWidth5;
                        sectionPosition7 = sectionPosition6 + sectionWidth6;
                        sectionPosition8 = 0;
                        sectionPosition9 = 0;
                        sectionPosition10 = 0;
                        sectionPosition11 = 0;
                        sectionPosition12 = 0;
                        sectionPosition13 = 0;
                        sectionPosition14 = 0;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;

                        break;
                    }
                case 7:
                    {
                        sectionPosition5 = sectionWidth4 / 2.0M;
                        sectionPosition4 = sectionPosition5 * -1;
                        sectionPosition3 = sectionPosition4 - sectionWidth3;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition6 = sectionPosition5 + sectionWidth5;
                        sectionPosition7 = sectionPosition6 + sectionWidth6;
                        sectionPosition8 = sectionPosition7 + sectionWidth7;
                        sectionPosition9 = 0;
                        sectionPosition10 = 0;
                        sectionPosition11 = 0;
                        sectionPosition12 = 0;
                        sectionPosition13 = 0;
                        sectionPosition14 = 0;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;

                        break;
                    }
                case 8:
                    {
                        sectionPosition5 = 0;
                        sectionPosition4 = sectionWidth4 * -1;
                        sectionPosition3 = sectionPosition4 - sectionWidth3;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition6 = sectionWidth5;
                        sectionPosition7 = sectionPosition6 + sectionWidth6;
                        sectionPosition8 = sectionPosition7 + sectionWidth7;
                        sectionPosition9 = sectionPosition8 + sectionWidth8;
                        sectionPosition10 = 0;
                        sectionPosition11 = 0;
                        sectionPosition12 = 0;
                        sectionPosition13 = 0;
                        sectionPosition14 = 0;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;

                        break;
                    }
                case 9:
                    {
                        sectionPosition6 = sectionWidth5 / 2.0M;
                        sectionPosition5 = sectionPosition6 * -1;
                        sectionPosition4 = sectionPosition5 - sectionWidth4;
                        sectionPosition3 = sectionPosition4 - sectionWidth3;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition7 = sectionPosition6 + sectionWidth6;
                        sectionPosition8 = sectionPosition7 + sectionWidth7;
                        sectionPosition9 = sectionPosition8 + sectionWidth8;
                        sectionPosition10 = sectionPosition9 + sectionWidth9;
                        sectionPosition11 = 0;
                        sectionPosition12 = 0;
                        sectionPosition13 = 0;
                        sectionPosition14 = 0;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;

                        break;
                    }
                case 10:
                    {
                        sectionPosition6 = 0;
                        sectionPosition5 = sectionWidth5 * -1;
                        sectionPosition4 = sectionPosition5 - sectionWidth4;
                        sectionPosition3 = sectionPosition4 - sectionWidth3;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition7 = sectionWidth6;
                        sectionPosition8 = sectionPosition7 + sectionWidth7;
                        sectionPosition9 = sectionPosition8 + sectionWidth8;
                        sectionPosition10 = sectionPosition9 + sectionWidth9;
                        sectionPosition11 = sectionPosition10 + sectionWidth10;
                        sectionPosition12 = 0;
                        sectionPosition13 = 0;
                        sectionPosition14 = 0;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;

                        break;
                    }
                case 11:
                    {
                        sectionPosition7 = sectionWidth6 / 2.0M;
                        sectionPosition6 = sectionPosition7 * -1;
                        sectionPosition5 = sectionPosition6 - sectionWidth5;
                        sectionPosition4 = sectionPosition5 - sectionWidth4;
                        sectionPosition3 = sectionPosition4 - sectionWidth3;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition8 = sectionPosition7 + sectionWidth7;
                        sectionPosition9 = sectionPosition8 + sectionWidth8;
                        sectionPosition10 = sectionPosition9 + sectionWidth9;
                        sectionPosition11 = sectionPosition10 + sectionWidth10;
                        sectionPosition12 = sectionPosition11 + sectionWidth11;
                        sectionPosition13 = 0;
                        sectionPosition14 = 0;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;

                        break;
                    }
                case 12:
                    {
                        sectionPosition7 = 0;
                        sectionPosition6 = sectionWidth6 * -1;
                        sectionPosition5 = sectionPosition6 - sectionWidth5;
                        sectionPosition4 = sectionPosition5 - sectionWidth4;
                        sectionPosition3 = sectionPosition4 - sectionWidth3;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition8 = sectionWidth7;
                        sectionPosition9 = sectionPosition8 + sectionWidth8;
                        sectionPosition10 = sectionPosition9 + sectionWidth9;
                        sectionPosition11 = sectionPosition10 + sectionWidth10;
                        sectionPosition12 = sectionPosition11 + sectionWidth11;
                        sectionPosition13 = sectionPosition12 + sectionWidth12;
                        sectionPosition14 = 0;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;
                        break;
                    }
                case 13:
                    {
                        sectionPosition8 = sectionWidth7 / 2.0M; ;
                        sectionPosition7 = sectionPosition8 * -1;
                        sectionPosition6 = sectionPosition7 - sectionWidth6;
                        sectionPosition5 = sectionPosition6 - sectionWidth5;
                        sectionPosition4 = sectionPosition5 - sectionWidth4;
                        sectionPosition3 = sectionPosition4 - sectionWidth3;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition9 = sectionPosition8 + sectionWidth8;
                        sectionPosition10 = sectionPosition9 + sectionWidth9;
                        sectionPosition11 = sectionPosition10 + sectionWidth10;
                        sectionPosition12 = sectionPosition11 + sectionWidth11;
                        sectionPosition13 = sectionPosition12 + sectionWidth12;
                        sectionPosition14 = sectionPosition13 + sectionWidth13;
                        sectionPosition15 = 0;
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;

                        break;
                    }

                case 14:
                    {
                        sectionPosition8 = 0;
                        sectionPosition7 = sectionWidth7 * -1;
                        sectionPosition6 = sectionPosition7 - sectionWidth6;
                        sectionPosition5 = sectionPosition6 - sectionWidth5;
                        sectionPosition4 = sectionPosition5 - sectionWidth4;
                        sectionPosition3 = sectionPosition4 - sectionWidth3;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition9 = sectionWidth8;
                        sectionPosition10 = sectionPosition9 + sectionWidth9;
                        sectionPosition11 = sectionPosition10 + sectionWidth10;
                        sectionPosition12 = sectionPosition11 + sectionWidth11;
                        sectionPosition13 = sectionPosition12 + sectionWidth12;
                        sectionPosition14 = sectionPosition13 + sectionWidth13;
                        sectionPosition15 = sectionPosition14 + sectionWidth14; 
                        sectionPosition16 = 0;
                        sectionPosition17 = 0;
                        break;
                    }
                case 15:
                    {
                        sectionPosition9 = sectionWidth8 / 2.0M;
                        sectionPosition8 = sectionPosition9  * -1;;
                        sectionPosition7 = sectionPosition8 - sectionWidth7;
                        sectionPosition6 = sectionPosition7 - sectionWidth6;
                        sectionPosition5 = sectionPosition6 - sectionWidth5;
                        sectionPosition4 = sectionPosition5 - sectionWidth4;
                        sectionPosition3 = sectionPosition4 - sectionWidth3;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition10 = sectionPosition9 + sectionWidth9;
                        sectionPosition11 = sectionPosition10 + sectionWidth10;
                        sectionPosition12 = sectionPosition11 + sectionWidth11;
                        sectionPosition13 = sectionPosition12 + sectionWidth12;
                        sectionPosition14 = sectionPosition13 + sectionWidth13;
                        sectionPosition15 = sectionPosition14 + sectionWidth14;
                        sectionPosition16 = sectionPosition15 + sectionWidth15;
                        sectionPosition17 = 0;

                        break;
                    }


                case 16:
                    {
                        sectionPosition9 = 0;
                        sectionPosition8 = sectionWidth8 * -1;
                        sectionPosition7 = sectionPosition8 - sectionWidth7;
                        sectionPosition6 = sectionPosition7 - sectionWidth6;
                        sectionPosition5 = sectionPosition6 - sectionWidth5;
                        sectionPosition4 = sectionPosition5 - sectionWidth4;
                        sectionPosition3 = sectionPosition4 - sectionWidth3;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition10 = sectionWidth9;
                        sectionPosition11 = sectionPosition10 + sectionWidth10;
                        sectionPosition12 = sectionPosition11 + sectionWidth11;
                        sectionPosition13 = sectionPosition12 + sectionWidth12;
                        sectionPosition14 = sectionPosition13 + sectionWidth13;
                        sectionPosition15 = sectionPosition14 + sectionWidth14;
                        sectionPosition16 = sectionPosition15 + sectionWidth15; 
                        sectionPosition17 = sectionPosition16 + sectionWidth16;
                        break;
                    }
            }
        }

        //Did user spin a section distance spinner?
        private void nudSection1_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpinners();
            if (Convert.ToDouble(lblVehicleToolWidth.Text) > maxWidth) nudSection1.Value--;
        }

        private void nudSection2_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpinners();
            if (Convert.ToDouble(lblVehicleToolWidth.Text) > maxWidth) nudSection2.Value--;
        }

        private void nudSection3_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpinners();
            if (Convert.ToDouble(lblVehicleToolWidth.Text) > maxWidth) nudSection3.Value--;
        }

        private void nudSection4_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpinners();
            if (Convert.ToDouble(lblVehicleToolWidth.Text) > maxWidth) nudSection4.Value--;
        }

        private void nudSection5_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpinners();
            if (Convert.ToDouble(lblVehicleToolWidth.Text) > maxWidth) nudSection5.Value--;
        }

        private void nudSection6_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpinners();
            if (Convert.ToDouble(lblVehicleToolWidth.Text) > maxWidth) nudSection6.Value--;
        }

        private void nudSection7_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpinners();
            if (Convert.ToDouble(lblVehicleToolWidth.Text) > maxWidth) nudSection7.Value--;
        }

        private void nudSection8_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpinners();
            if (Convert.ToDouble(lblVehicleToolWidth.Text) > maxWidth) nudSection8.Value--;
        }

        private void nudSection9_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpinners();
            if (Convert.ToDouble(lblVehicleToolWidth.Text) > maxWidth) nudSection9.Value--;
        }

        private void nudSection10_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpinners();
            if (Convert.ToDouble(lblVehicleToolWidth.Text) > maxWidth) nudSection10.Value--;
        }

        private void nudSection11_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpinners();
            if (Convert.ToDouble(lblVehicleToolWidth.Text) > maxWidth) nudSection11.Value--;
        }

        private void nudSection12_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpinners();
            if (Convert.ToDouble(lblVehicleToolWidth.Text) > maxWidth) nudSection12.Value--;
        }

        private void nudSection13_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpinners();
            if (Convert.ToDouble(lblVehicleToolWidth.Text) > maxWidth) nudSection13.Value--;
        }

        private void nudSection14_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpinners();
            if (Convert.ToDouble(lblVehicleToolWidth.Text) > maxWidth) nudSection14.Value--;
        }

        private void nudSection15_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpinners();
            if (Convert.ToDouble(lblVehicleToolWidth.Text) > maxWidth) nudSection15.Value--;
        }

        private void nudSection16_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpinners();
            if (Convert.ToDouble(lblVehicleToolWidth.Text) > maxWidth) nudSection16.Value--;
        }

        #endregion Sections //---------------------------------------------------------------

        #region WorkSwitch //---------------------------------------------------------

        private void chkWorkSwActiveLow_CheckedChanged(object sender, EventArgs e)
        {
            isWorkSwActiveLow = !isWorkSwActiveLow;
            chkWorkSwActiveLow.Checked = isWorkSwActiveLow;
        }

        private void chkEnableWorkSwitch_CheckedChanged(object sender, EventArgs e)
        {
            isWorkSwEn = !isWorkSwEn;
            chkEnableWorkSwitch.Checked = isWorkSwEn;
        }

        private void checkWorkSwitchManual_CheckedChanged(object sender, EventArgs e)
        {
            isWorkSwitchManual = !isWorkSwitchManual;
            checkWorkSwitchManual.Checked = isWorkSwitchManual;
        }

        #endregion WorkSwitch //---------------------------------------------------------
    }
}