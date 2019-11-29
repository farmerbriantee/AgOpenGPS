//Please, if you use this, share the improvements

using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormSettings : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        private double toolOverlap, toolTrailingHitchLength, tankTrailingHitchLength, toolOffset, toolTurnOffDelay, toolLookAhead;
        private double antennaHeight, antennaOffset, antennaPivot, wheelbase, hitchLength, minTurningRadius;

        private bool isToolTrailing, isToolBehindPivot, isPivotBehindAntenna, isSteerAxleAhead;
        private int numberOfSections, minApplied;

        private decimal sectionWidth1, sectionWidth2, sectionWidth3, sectionWidth4, sectionWidth5, sectionWidth6,
                        sectionWidth7, sectionWidth8, sectionWidth9, sectionWidth10, sectionWidth11, sectionWidth12;

        private decimal sectionPosition1, sectionPosition2, sectionPosition3, sectionPosition4,
                        sectionPosition5, sectionPosition6, sectionPosition7, sectionPosition8, sectionPosition9,
                        sectionPosition10, sectionPosition11, sectionPosition12, sectionPosition13;

        private bool isWorkSwEn, isWorkSwActiveLow, isWorkSwitchManual;

        private readonly double metImp2m, m2MetImp, cutoffMetricImperial, maxWidth;
        private double cutoffSpeed;

        private bool isAutoSteerAuto;
        private int snapDistance, snapDistanceSmall;

        private int lightbarCmPerPixie;

        //constructor
        public FormSettings(Form callingForm, int page)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();

            //Language keys
            tabAntenna.Text = gStr.gsAntenna;
            tabVehicle.Text = gStr.gsVehicle;
            tabSections.Text = gStr.gsSection;
            tabTool.Text = gStr.gsTool;
            tabWorkSwitch.Text = gStr.gsSwitches;
            tabExamples.Text = gStr.gsExamples;

            label6.Text = gStr.gsTurnRadius;
            label24.Text = gStr.gsHitchLength;
            label26.Text = gStr.gsWheelbase;
            label9.Text = gStr.gsLeftIs_;
            label12.Text = gStr.gsLocation;
            label15.Text = gStr.gsHeight;
            label7.Text = gStr.gsOffset;
            label4.Text = gStr.gsSteeringFrontOrBack;
            label18.Text = gStr.gsDistance;
            label25.Text = gStr.gsLeftIs_;
            label13.Text = gStr.gsRightIs_;
            label8.Text = gStr.gsTowBetweenLength;
            label22.Text = gStr.gsTowBetweenDisabledWhen;

            label23.Text = gStr.gsTurnOffDelaySecs;
            label3.Text = gStr.gsTurnOnAheadSecs;
            label19.Text = gStr.gsTrailingHitchLength;
            label1.Text = gStr.gsSkip_Overlap_;
            label5.Text = gStr.gsToolOffsetLR;
            label41.Text = gStr.gsMinUnapplied;
            lblTurnOffBelowUnits.Text = gStr.gsKMH;
            label30.Text = gStr.gsSectionsTurnOffBelow;
            label2.Text = gStr.gs_OfSections;

            groupBox2.Text = gStr.gsCmPerLightbarPixel;
            groupBox9.Text = gStr.gsAutoManualAutosteerBtn;
            cboxAutoSteerAuto.Text = gStr.gsManual;
            groupBox8.Text = gStr.gs__SnapDistance;
            groupBox1.Text = gStr.gs____SnapDistance;
            groupBox3.Text = gStr.gsWorkSwitch;
            checkWorkSwitchManual.Text = gStr.gsWorkSwitchControlsManual;
            chkWorkSwActiveLow.Text = gStr.gsActiveLow;
            chkEnableWorkSwitch.Text = gStr.gsEnableWorkSwitch;
            label17.Text = gStr.gsMeasurementsIn;
            label16.Text = gStr.gsToolWidth;

            Text = gStr.gsVehicleSettings;




            nudMinTurnRadius.Controls[0].Enabled = false;
            nudAntennaHeight.Controls[0].Enabled = false;
            nudAntennaOffset.Controls[0].Enabled = false;
            nudAntennaPivot.Controls[0].Enabled = false;
            nudCutoffSpeed.Controls[0].Enabled = false;
            nudForeAft.Controls[0].Enabled = false;
            nudHitchLength.Controls[0].Enabled = false;
            nudLightbarCmPerPixel.Controls[0].Enabled = false;
            nudLookAhead.Controls[0].Enabled = false;
            nudMinApplied.Controls[0].Enabled = false;
            nudMinTurnRadius.Controls[0].Enabled = false;
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
            nudSnapDistance.Controls[0].Enabled = false;
            nudSnapDistanceSmall.Controls[0].Enabled = false;
            nudTankHitch.Controls[0].Enabled = false;
            nudTurnOffDelay.Controls[0].Enabled = false;
            nudWheelbase.Controls[0].Enabled = false;
            nudLineWidth.Controls[0].Enabled = false;

            if (mf.isMetric)
            {
                metImp2m = 0.01;
                m2MetImp = 100.0;
                lblInchesCm.Text = gStr.gsCentimeters;
                lblSecTotalWidthFeet.Visible = false;
                lblSecTotalWidthInches.Visible = false;
                lblSecTotalWidthMeters.Visible = true;
                lblDoNotExceed.Text = "* < 5000 cm*";
                lblTurnOffBelowUnits.Text = gStr.gsKMH;
                cutoffMetricImperial = 1;
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
                lblTurnOffBelowUnits.Text = gStr.gsMPH;
                cutoffMetricImperial = 1.60934;
                maxWidth = 1968;
            }
            //select the page as per calling menu or button from mainGPS form
            tabControl1.SelectedIndex = page;
        }

        //do any field initializing for form here
        private void FormSettings_Load(object sender, EventArgs e)
        {
            nudLightbarCmPerPixel.Value = (Properties.Settings.Default.setDisplay_lightbarCmPerPixel);
            lightbarCmPerPixie = Properties.Settings.Default.setDisplay_lightbarCmPerPixel;

            //Vehicle settings to what it is in the settings page------------------------------------------------
            antennaHeight = Properties.Vehicle.Default.setVehicle_antennaHeight;
            if (nudAntennaHeight.CheckValueCm(ref antennaHeight)) nudAntennaHeight.BackColor = System.Drawing.Color.OrangeRed;

            antennaPivot = Math.Abs(Properties.Vehicle.Default.setVehicle_antennaPivot);
            if (nudAntennaPivot.CheckValueCm(ref antennaPivot)) nudAntennaPivot.BackColor = System.Drawing.Color.OrangeRed;

            hitchLength = Math.Abs(Properties.Vehicle.Default.setVehicle_hitchLength);
            if (nudHitchLength.CheckValueCm(ref hitchLength)) nudHitchLength.BackColor = System.Drawing.Color.OrangeRed;

            wheelbase = Math.Abs(Properties.Vehicle.Default.setVehicle_wheelbase);
            if (nudWheelbase.CheckValueCm(ref wheelbase)) nudWheelbase.BackColor = System.Drawing.Color.OrangeRed;

            minTurningRadius = Properties.Vehicle.Default.setVehicle_minTurningRadius;
            if (nudMinTurnRadius.CheckValueCm(ref minTurningRadius)) nudMinTurnRadius.BackColor = System.Drawing.Color.OrangeRed;

            antennaOffset = Properties.Vehicle.Default.setVehicle_antennaOffset;
            if (nudAntennaOffset.CheckValueCm(ref antennaOffset)) nudAntennaOffset.BackColor = System.Drawing.Color.OrangeRed;

            toolTrailingHitchLength = Math.Abs(Properties.Vehicle.Default.setVehicle_toolTrailingHitchLength);
            if (nudForeAft.CheckValueCm(ref toolTrailingHitchLength)) nudForeAft.BackColor = System.Drawing.Color.OrangeRed;

            tankTrailingHitchLength = Math.Abs(Properties.Vehicle.Default.setVehicle_tankTrailingHitchLength);
            if (nudTankHitch.CheckValueCm(ref tankTrailingHitchLength)) nudTankHitch.BackColor = System.Drawing.Color.OrangeRed;

            toolOverlap = Properties.Vehicle.Default.setVehicle_toolOverlap;
            if (nudOverlap.CheckValueCm(ref toolOverlap)) nudOverlap.BackColor = System.Drawing.Color.OrangeRed;

            toolOffset = Properties.Vehicle.Default.setVehicle_toolOffset;
            if (nudOffset.CheckValueCm(ref toolOffset)) nudOffset.BackColor = System.Drawing.Color.OrangeRed;

            decimal temp;
            toolTurnOffDelay = Properties.Vehicle.Default.setVehicle_turnOffDelay;
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

            cutoffSpeed = Properties.Vehicle.Default.setVehicle_slowSpeedCutoff / cutoffMetricImperial;
            temp = (decimal)cutoffSpeed;
            if (nudCutoffSpeed.CheckValue(ref temp)) nudCutoffSpeed.BackColor = System.Drawing.Color.OrangeRed;
            cutoffSpeed = (double)temp;

            isToolBehindPivot = Properties.Vehicle.Default.setVehicle_isToolBehindPivot;
            isToolTrailing = Properties.Vehicle.Default.setVehicle_isToolTrailing;
            isPivotBehindAntenna = Properties.Vehicle.Default.setVehicle_isPivotBehindAntenna;
            isSteerAxleAhead = Properties.Vehicle.Default.setVehicle_isSteerAxleAhead;

            nudSnapDistance.Value = Properties.Settings.Default.setDisplay_snapDistance;
            nudSnapDistanceSmall.Value = Properties.Settings.Default.setDisplay_snapDistanceSmall;

            cboxAutoSteerAuto.Checked = Properties.Settings.Default.setAS_isAutoSteerAutoOn;
            isAutoSteerAuto = Properties.Settings.Default.setAS_isAutoSteerAutoOn;
            if (isAutoSteerAuto)
            {
                cboxAutoSteerAuto.Image = Properties.Resources.AutoSteerOn;
                cboxAutoSteerAuto.Text = gStr.gsAuto;
            }
            else
            {
                cboxAutoSteerAuto.Image = Properties.Resources.AutoSteerOff;
                cboxAutoSteerAuto.Text = gStr.gsManual;
            }

            //fix the min max based on inches - they are 2.54 times smaller then cm
            if (!mf.isMetric)
            {
                nudAntennaHeight.Maximum /= 2.54M;
                nudAntennaHeight.Minimum /= 2.54M;

                nudAntennaPivot.Maximum /= 2.54M;
                nudAntennaPivot.Minimum /= 2.54M;

                nudHitchLength.Maximum /= 2.54M;
                nudHitchLength.Minimum /= 2.54M;

                nudWheelbase.Maximum /= 2.54M;
                nudWheelbase.Minimum /= 2.54M;

                nudAntennaOffset.Maximum /= 2.54M;
                nudAntennaOffset.Minimum /= 2.54M;

                nudMinTurnRadius.Maximum /= 2.54M;
                nudMinTurnRadius.Minimum /= 2.54M;

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
            }

            nudAntennaHeight.ValueChanged -= nudAntennaHeight_ValueChanged;
            nudAntennaHeight.Value = (decimal)(antennaHeight * m2MetImp);
            nudAntennaHeight.ValueChanged += nudAntennaHeight_ValueChanged;

            nudAntennaOffset.ValueChanged -= nudAntennaOffset_ValueChanged;
            nudAntennaOffset.Value = (decimal)(antennaOffset * m2MetImp);
            nudAntennaOffset.ValueChanged += nudAntennaOffset_ValueChanged;

            nudAntennaPivot.ValueChanged -= nudAntennaPivot_ValueChanged;
            nudAntennaPivot.Value = (decimal)(antennaPivot * m2MetImp);
            nudAntennaPivot.ValueChanged += nudAntennaPivot_ValueChanged;

            nudHitchLength.ValueChanged -= nudHitchLength_ValueChanged;
            nudHitchLength.Value = (decimal)(hitchLength * m2MetImp);
            nudHitchLength.ValueChanged += nudHitchLength_ValueChanged;

            nudWheelbase.ValueChanged -= nudWheelbase_ValueChanged;
            nudWheelbase.Value = (decimal)(wheelbase * m2MetImp);
            nudWheelbase.ValueChanged += nudWheelbase_ValueChanged;

            nudMinTurnRadius.ValueChanged -= nudMinTurnRadius_ValueChanged;
            nudMinTurnRadius.Value = (decimal)(minTurningRadius * m2MetImp);
            nudMinTurnRadius.ValueChanged += nudMinTurnRadius_ValueChanged;

            nudMinApplied.ValueChanged -= nudMinApplied_ValueChanged;
            nudMinApplied.Value = (decimal)(minApplied);
            nudMinApplied.ValueChanged += nudMinApplied_ValueChanged;

            chkIsAft.CheckedChanged -= chkIsAft_CheckedChanged;
            chkIsAft.Checked = isToolBehindPivot;
            chkIsAft.CheckedChanged += chkIsAft_CheckedChanged;

            chkIsTrailingRigid.CheckedChanged -= chkIsTrailingRigid_CheckedChanged;
            chkIsTrailingRigid.Checked = isToolTrailing;
            chkIsTrailingRigid.CheckedChanged += chkIsTrailingRigid_CheckedChanged;

            chkIsPivotBehindAntenna.CheckedChanged -= chkIsPivotBehindAntenna_CheckedChanged;
            chkIsPivotBehindAntenna.Checked = isPivotBehindAntenna;
            chkIsPivotBehindAntenna.CheckedChanged += chkIsPivotBehindAntenna_CheckedChanged;

            chkIsSteerAxleAhead.CheckedChanged -= chkIsSteerAxleAhead_CheckedChanged;
            chkIsSteerAxleAhead.Checked = isSteerAxleAhead;
            chkIsSteerAxleAhead.CheckedChanged += chkIsSteerAxleAhead_CheckedChanged;

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

            //based on number of sections and values update the page before displaying
            UpdateSpinners();

            UpdateTrailingRigidCheckbox();
            UpdateIsAftCheckbox();
            UpdateIsPivotBehindAntennaCheckbox();
            UpdateIsSteerAxleAhead();

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

            nudCutoffSpeed.ValueChanged -= nudCutoffSpeed_ValueChanged;
            nudCutoffSpeed.Value = (decimal)cutoffSpeed;
            nudCutoffSpeed.ValueChanged += nudCutoffSpeed_ValueChanged;

            nudLineWidth.Value = Properties.Settings.Default.setDisplay_lineWidth;                
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.setDisplay_lightbarCmPerPixel = lightbarCmPerPixie;
            mf.lightbarCmPerPixel = lightbarCmPerPixie;

            //Vehicle settings -------------------------------------------------------------------------------

            if (!isPivotBehindAntenna) antennaPivot *= -1;
            mf.vehicle.antennaPivot = antennaPivot;
            Properties.Vehicle.Default.setVehicle_antennaPivot = mf.vehicle.antennaPivot;

            mf.vehicle.isPivotBehindAntenna = isPivotBehindAntenna;
            Properties.Vehicle.Default.setVehicle_isPivotBehindAntenna = mf.vehicle.isPivotBehindAntenna;

            if (!isSteerAxleAhead) wheelbase *= -1;
            mf.vehicle.wheelbase = wheelbase;
            Properties.Vehicle.Default.setVehicle_wheelbase = wheelbase;

            mf.vehicle.minTurningRadius = minTurningRadius;
            Properties.Vehicle.Default.setVehicle_minTurningRadius = minTurningRadius;

            mf.vehicle.isSteerAxleAhead = isSteerAxleAhead;
            Properties.Vehicle.Default.setVehicle_isSteerAxleAhead = mf.vehicle.isSteerAxleAhead;

            mf.vehicle.antennaHeight = antennaHeight;
            Properties.Vehicle.Default.setVehicle_antennaHeight = mf.vehicle.antennaHeight;

            mf.vehicle.antennaOffset = antennaOffset;
            Properties.Vehicle.Default.setVehicle_antennaOffset = antennaOffset;

            //Tool  ------------------------------------------------------------------------------------------

            //trailing hitch is always behind
            toolTrailingHitchLength *= -1;
            mf.vehicle.toolTrailingHitchLength = toolTrailingHitchLength;
            Properties.Vehicle.Default.setVehicle_toolTrailingHitchLength = mf.vehicle.toolTrailingHitchLength;

            tankTrailingHitchLength *= -1;
            mf.vehicle.tankTrailingHitchLength = tankTrailingHitchLength;
            Properties.Vehicle.Default.setVehicle_tankTrailingHitchLength = mf.vehicle.tankTrailingHitchLength;

            mf.vehicle.toolLookAhead = toolLookAhead;
            Properties.Vehicle.Default.setVehicle_lookAhead = mf.vehicle.toolLookAhead;

            mf.vehicle.toolOverlap = toolOverlap;
            Properties.Vehicle.Default.setVehicle_toolOverlap = mf.vehicle.toolOverlap;

            mf.vehicle.toolTurnOffDelay = toolTurnOffDelay;
            Properties.Vehicle.Default.setVehicle_turnOffDelay = mf.vehicle.toolTurnOffDelay;

            mf.vehicle.toolOffset = toolOffset;
            Properties.Vehicle.Default.setVehicle_toolOffset = mf.vehicle.toolOffset;

            mf.vehicle.isToolTrailing = isToolTrailing;
            Properties.Vehicle.Default.setVehicle_isToolTrailing = mf.vehicle.isToolTrailing;

            mf.vehicle.isToolBehindPivot = isToolBehindPivot;
            Properties.Vehicle.Default.setVehicle_isToolBehindPivot = mf.vehicle.isToolBehindPivot;

            if (isToolBehindPivot) hitchLength *= -1;
            mf.vehicle.hitchLength = hitchLength;
            Properties.Vehicle.Default.setVehicle_hitchLength = mf.vehicle.hitchLength;

            //Guidance

            Properties.Settings.Default.setDisplay_snapDistance = snapDistance;
            Properties.Settings.Default.setDisplay_snapDistanceSmall = snapDistanceSmall;

            mf.ahrs.isAutoSteerAuto = isAutoSteerAuto;
            Properties.Settings.Default.setAS_isAutoSteerAutoOn = isAutoSteerAuto;

            //Sections ------------------------------------------------------------------------------------------

            mf.vehicle.numOfSections = numberOfSections;
            mf.vehicle.numSuperSection = numberOfSections + 1;
            Properties.Vehicle.Default.setVehicle_numSections = mf.vehicle.numOfSections;

            mf.vehicle.toolMinUnappliedPixels = minApplied;
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

            //line up manual buttons based on # of sections
            mf.LineUpManualBtns();

            //update the sections to newly configured widths and positions in main
            mf.SectionSetPosition();

            //update the widths of sections and tool width in main
            mf.SectionCalcWidths();

            //update toolwidth in mainform
            Properties.Vehicle.Default.setVehicle_toolWidth = mf.vehicle.toolWidth;

            //WorkSwitch settings
            mf.mc.isWorkSwitchActiveLow = isWorkSwActiveLow;
            Properties.Settings.Default.setF_IsWorkSwitchActiveLow = isWorkSwActiveLow;

            mf.mc.isWorkSwitchEnabled = isWorkSwEn;
            Properties.Settings.Default.setF_IsWorkSwitchEnabled = isWorkSwEn;

            mf.mc.isWorkSwitchManual = isWorkSwitchManual;
            Properties.Settings.Default.setF_IsWorkSwitchManual = isWorkSwitchManual;

            //Slow speed cutoff
            Properties.Vehicle.Default.setVehicle_slowSpeedCutoff = cutoffSpeed * cutoffMetricImperial;
            mf.vehicle.slowSpeedCutoff = cutoffSpeed * cutoffMetricImperial;

            Properties.Settings.Default.setDisplay_lineWidth = (int)(nudLineWidth.Value);
            mf.ABLine.lineWidth = (float)(nudLineWidth.Value);

            mf.tram.abOffset = (Math.Round((mf.vehicle.toolWidth - mf.vehicle.toolOverlap) / 2.0, 3));

            Properties.Settings.Default.Save();
            Properties.Vehicle.Default.Save();

            //back to FormGPS
            DialogResult = DialogResult.OK;
            Close();
        }

        private void NudLightbarCmPerPixel_ValueChanged(object sender, EventArgs e)
        {
            lightbarCmPerPixie = (int)nudLightbarCmPerPixel.Value;
        }

        private void NudSnapDistanceSmall_ValueChanged(object sender, EventArgs e)
        {
            if (nudSnapDistanceSmall.Value > nudSnapDistance.Value) nudSnapDistanceSmall.Value = nudSnapDistance.Value;
            snapDistanceSmall = (int)nudSnapDistanceSmall.Value;
        }

        private void NudSnapDistance_ValueChanged(object sender, EventArgs e)
        {
            if (nudSnapDistanceSmall.Value > nudSnapDistance.Value) nudSnapDistanceSmall.Value = nudSnapDistance.Value;

            snapDistance = (int)nudSnapDistance.Value;
        }

        private void NudMinTurnRadius_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
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

        private void NudNumberOfSections_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudMinApplied_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudCutoffSpeed_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudSnapDistanceSmall_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudSnapDistance_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void NudLightbarCmPerPixel_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void nudLineWidth_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void CboxNumSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            numberOfSections = cboxNumSections.SelectedIndex + 1;
             
            decimal wide = 300;
            if (!mf.isMetric) wide = 100;

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

            UpdateSpinners();
        }

        private void CboxAutoSteerAuto_CheckedChanged(object sender, EventArgs e)
        {
            isAutoSteerAuto = cboxAutoSteerAuto.Checked;
            if (isAutoSteerAuto)
            {
                cboxAutoSteerAuto.Image = Properties.Resources.AutoSteerOn;
                cboxAutoSteerAuto.Text = gStr.gsAuto;
            }
            else
            {
                cboxAutoSteerAuto.Image = Properties.Resources.AutoSteerOff;
                cboxAutoSteerAuto.Text = gStr.gsManual;
            }
        }

        //don't save anything, leave the settings as before
        private void btnCancel_Click(object sender, EventArgs e)
        { DialogResult = DialogResult.Cancel; Close(); }

        #region Vehicle //----------------------------------------------------------------

        private void nudAntennaHeight_ValueChanged(object sender, EventArgs e)
        {
            antennaHeight = (double)nudAntennaHeight.Value * metImp2m;
        }

        private void nudAntennaPivot_ValueChanged(object sender, EventArgs e)
        {
            antennaPivot = (double)nudAntennaPivot.Value * metImp2m;
        }

        private void nudHitchLength_ValueChanged(object sender, EventArgs e)
        {
            hitchLength = (double)nudHitchLength.Value * metImp2m;
        }

        private void nudAntennaOffset_ValueChanged(object sender, EventArgs e)
        {
            antennaOffset = (double)nudAntennaOffset.Value * metImp2m;
        }

        private void nudMinTurnRadius_ValueChanged(object sender, EventArgs e)
        {
            minTurningRadius = (double)nudMinTurnRadius.Value * metImp2m;
        }

        private void nudWheelbase_ValueChanged(object sender, EventArgs e)
        {
            wheelbase = (double)nudWheelbase.Value * metImp2m;
        }

        private void UpdateTrailingRigidCheckbox()
        {
            //change 2D or 3D icon accordingly on button
            chkIsTrailingRigid.Image = chkIsTrailingRigid.Checked ? Properties.Resources.VehHitched64
                                                                           : Properties.Resources.VehRigid64;
        }

        private void UpdateIsAftCheckbox()
        {
            if (chkIsAft.Checked)
            {
                chkIsTrailingRigid.Enabled = true;
                nudForeAft.Enabled = true;
                chkIsAft.Image = Properties.Resources.VehAft64;
            }
            else
            {
                chkIsTrailingRigid.Checked = false;
                nudForeAft.Enabled = false;
                isToolTrailing = false;
                UpdateTrailingRigidCheckbox();
                chkIsTrailingRigid.Enabled = false;
                chkIsAft.Image = Properties.Resources.VehFore64;
            }
        }

        private void UpdateIsPivotBehindAntennaCheckbox()
        {
            chkIsPivotBehindAntenna.Image = chkIsPivotBehindAntenna.Checked ? Properties.Resources.PivotBehind
                                                                                    : Properties.Resources.PivotAhead;
        }

        private void UpdateIsSteerAxleAhead()
        {
            chkIsSteerAxleAhead.Image = chkIsSteerAxleAhead.Checked ? Properties.Resources.SteerAhead
                                                                            : Properties.Resources.SteerBehind;
        }

        private void chkIsTrailingRigid_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTrailingRigidCheckbox();
            isToolTrailing = !isToolTrailing;
        }

        private void chkIsAft_CheckedChanged(object sender, EventArgs e)
        {
            UpdateIsAftCheckbox();
            isToolBehindPivot = !isToolBehindPivot;
        }

        private void chkIsPivotBehindAntenna_CheckedChanged(object sender, EventArgs e)
        {
            isPivotBehindAntenna = !isPivotBehindAntenna;
            UpdateIsPivotBehindAntennaCheckbox();
        }

        private void chkIsSteerAxleAhead_CheckedChanged(object sender, EventArgs e)
        {
            isSteerAxleAhead = !isSteerAxleAhead;
            UpdateIsSteerAxleAhead();
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

        #endregion Vehicle //----------------------------------------------------------------

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

                        lblVehicleToolWidth.Text = Convert.ToString((int)(nudSection1.Value + nudSection2.Value + nudSection3.Value
                            + nudSection4.Value + nudSection5.Value + nudSection6.Value + nudSection7.Value + nudSection8.Value
                            + nudSection9.Value + nudSection10.Value + nudSection11.Value + nudSection12.Value));
                        break;
                    }
            }
            //update in settings dialog ONLY total tool width
            SectionFeetInchesTotalWidthLabelUpdate();
        }

        //the minimum speed before sections turn off
        private void nudCutoffSpeed_ValueChanged(object sender, EventArgs e)
        {
            cutoffSpeed = (double)nudCutoffSpeed.Value;
        }

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
                        break;
                    }
                case 5:
                    {
                        sectionPosition4 = sectionWidth3 / 2.0M;
                        sectionPosition3 = sectionPosition4 * -1;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition5 = sectionPosition4 + sectionWidth4;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition6 = sectionPosition5 + sectionWidth5;
                        sectionPosition7 = 0;
                        sectionPosition8 = 0;
                        sectionPosition9 = 0;
                        sectionPosition10 = 0;
                        sectionPosition11 = 0;
                        sectionPosition12 = 0;
                        sectionPosition13 = 0;
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
                        break;
                    }
                case 8:
                    {
                        sectionPosition4 = sectionWidth4 * -1;
                        sectionPosition3 = sectionPosition4 - sectionWidth3;
                        sectionPosition2 = sectionPosition3 - sectionWidth2;
                        sectionPosition1 = sectionPosition2 - sectionWidth1;
                        sectionPosition5 = 0;
                        sectionPosition6 = sectionWidth5;
                        sectionPosition7 = sectionPosition6 + sectionWidth6;
                        sectionPosition8 = sectionPosition7 + sectionWidth7;
                        sectionPosition9 = sectionPosition8 + sectionWidth8;
                        sectionPosition10 = 0;
                        sectionPosition11 = 0;
                        sectionPosition12 = 0;
                        sectionPosition13 = 0;
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
                        break;
                    }
                case 11:
                    {
                        sectionPosition7 = sectionWidth4 / 2.0M;
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