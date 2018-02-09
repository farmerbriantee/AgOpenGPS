using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Drawing;

namespace AgOpenGPS
{
    
    public partial class FormGPS
    {
        //list of the list of patch data individual triangles for field sections
        public List<List<vec2>> patchSaveList = new List<List<vec2>>();

        //list of the list of patch data individual triangles for contour tracking
        public List<List<vec4>> contourSaveList = new List<List<vec4>>();

        //function that save vehicle and section settings
        public void FileSaveVehicle()
        {
            //in the current application directory
            //string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //string fieldDir = dir + "\\fields\\";

            string dirVehicle = vehiclesDirectory;

            string directoryName = Path.GetDirectoryName(dirVehicle).ToString(CultureInfo.InvariantCulture);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Title = "Save Vehicle";
            saveDialog.Filter = "Text Files (*.txt)|*.txt";
            saveDialog.InitialDirectory = directoryName;

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                vehiclefileName = Path.GetFileNameWithoutExtension(saveDialog.FileName) + " - ";
                Properties.Vehicle.Default.setVehicle_Name = vehiclefileName;
                Properties.Vehicle.Default.Save();

                using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                {
                    writer.WriteLine("Version," + Application.ProductVersion.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("Overlap," + Properties.Vehicle.Default.setVehicle_toolOverlap.ToString(CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("ToolTrailingHitchLength," + Properties.Vehicle.Default.setVehicle_toolTrailingHitchLength.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("TankTrailingHitchLength," + Properties.Vehicle.Default.setVehicle_tankTrailingHitchLength.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("AntennaHeight," + Properties.Vehicle.Default.setVehicle_antennaHeight.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("LookAhead," + Properties.Vehicle.Default.setVehicle_lookAhead.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("AntennaPivot," + Properties.Vehicle.Default.setVehicle_antennaPivot.ToString(CultureInfo.InvariantCulture));

                    writer.WriteLine("HitchLength," + Properties.Vehicle.Default.setVehicle_hitchLength.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("ToolOffset," + Properties.Vehicle.Default.setVehicle_toolOffset.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("TurnOffDelay," + Properties.Vehicle.Default.setVehicle_turnOffDelay.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("Wheelbase," + Properties.Vehicle.Default.setVehicle_wheelbase.ToString(CultureInfo.InvariantCulture));

                    writer.WriteLine("IsPivotBehindAntenna," + Properties.Vehicle.Default.setVehicle_isPivotBehindAntenna.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("IsSteerAxleAhead," + Properties.Vehicle.Default.setVehicle_isSteerAxleAhead.ToString(CultureInfo.InvariantCulture)); 
                    writer.WriteLine("IsToolBehindPivot," + Properties.Vehicle.Default.setVehicle_isToolBehindPivot.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("IsToolTrailing," + Properties.Vehicle.Default.setVehicle_isToolTrailing.ToString(CultureInfo.InvariantCulture));

                    writer.WriteLine("Spinner1," + Properties.Vehicle.Default.setSection_position1.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("Spinner2," + Properties.Vehicle.Default.setSection_position2.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("Spinner3," + Properties.Vehicle.Default.setSection_position3.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("Spinner4," + Properties.Vehicle.Default.setSection_position4.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("Spinner5," + Properties.Vehicle.Default.setSection_position5.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("Spinner6," + Properties.Vehicle.Default.setSection_position6.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("Spinner7," + Properties.Vehicle.Default.setSection_position7.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("Spinner8," + Properties.Vehicle.Default.setSection_position8.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("Spinner9," + Properties.Vehicle.Default.setSection_position9.ToString(CultureInfo.InvariantCulture));

                    writer.WriteLine("Sections," + Properties.Vehicle.Default.setVehicle_numSections.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("ToolWidth," + Properties.Vehicle.Default.setVehicle_toolWidth.ToString(CultureInfo.InvariantCulture));

                    writer.WriteLine("WorkSwitch," + Properties.Settings.Default.setF_IsWorkSwitchEnabled.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("ActiveLow," + Properties.Settings.Default.setF_IsWorkSwitchActiveLow.ToString(CultureInfo.InvariantCulture));

                    writer.WriteLine("CamPitch," + Properties.Settings.Default.setCam_pitch.ToString(CultureInfo.InvariantCulture));

                    writer.WriteLine("IsAtanCam," + Properties.Settings.Default.setHeading_isFromPosition.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("TriangleResolution," + Properties.Settings.Default.setDisplay_triangleResolution.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("IsMetric," + Properties.Settings.Default.setMenu_isMetric.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("IsGridOn," + Properties.Settings.Default.setMenu_isGridOn.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("IsLightBarOn," + Properties.Settings.Default.setMenu_isLightbarOn.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("IsAreaRight," + Properties.Settings.Default.setMenu_isAreaRight.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("IsPurePursuitLineOn," + Properties.Settings.Default.setMenu_isPureOn.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("IsGuideLinesOn," + Properties.Settings.Default.setMenu_isSideGuideLines.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("Empty," + "10");
                    writer.WriteLine("Empty," + "10");
                    writer.WriteLine("Empty," + "10");
                    writer.WriteLine("Empty," + "10");

                    writer.WriteLine("FieldColorR," + Properties.Settings.Default.setF_FieldColorR.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("FieldColorG," + Properties.Settings.Default.setF_FieldColorG.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("FieldColorB," + Properties.Settings.Default.setF_FieldColorB.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("SectionColorR," + Properties.Settings.Default.setF_SectionColorR.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("SectionColorG," + Properties.Settings.Default.setF_SectionColorG.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("SectionColorB," + Properties.Settings.Default.setF_SectionColorB.ToString(CultureInfo.InvariantCulture));

                    writer.WriteLine("SlowSpeedCutoff," + Properties.Vehicle.Default.setVehicle_slowSpeedCutoff.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("ToolMinUnappliedPixels," + Properties.Vehicle.Default.setVehicle_minApplied.ToString(CultureInfo.InvariantCulture));

                    writer.WriteLine("Empty," + "10");
                    writer.WriteLine("Empty," + "10");
                    writer.WriteLine("Empty," + "10");
                    writer.WriteLine("Empty," + "10");
                    writer.WriteLine("Empty," + "10");
                    writer.WriteLine("Empty," + "10");

                    writer.WriteLine("IMUPitchZero," + Properties.Settings.Default.setIMU_pitchZero.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("IMURollZero," + Properties.Settings.Default.setIMU_rollZero.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("IsLogNMEA," + Properties.Settings.Default.setMenu_isLogNMEA.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("MinFixStep," + Properties.Settings.Default.setF_minFixStep.ToString(CultureInfo.InvariantCulture));

                    writer.WriteLine("pidP," + Properties.Settings.Default.setAS_Kp.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("pidI," + Properties.Settings.Default.setAS_Ki.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("pidD," + Properties.Settings.Default.setAS_Kd.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("pidO," + Properties.Settings.Default.setAS_Ko.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("SteerAngleOffset," + Properties.Settings.Default.setAS_steerAngleOffset.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("minPWM," + Properties.Settings.Default.setAS_minSteerPWM.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("MaxIntegral," + Properties.Settings.Default.setAS_maxIntegral.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("CountsPerDegree," + Properties.Settings.Default.setAS_countsPerDegree.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("Empty," + "10");
                    writer.WriteLine("Empty," + "10");

                    writer.WriteLine("GoalPointLookAhead," + Properties.Vehicle.Default.setVehicle_goalPointLookAhead.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("MaxSteerAngle," + Properties.Vehicle.Default.setVehicle_maxSteerAngle.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine("MaxAngularVelocity," + Properties.Vehicle.Default.setVehicle_maxAngularVelocity.ToString(CultureInfo.InvariantCulture));

                    writer.WriteLine("SequenceFunctionEnter;" + Properties.Vehicle.Default.seq_FunctionEnter);
                    writer.WriteLine("SequenceFunctionExit;" + Properties.Vehicle.Default.seq_FunctionExit);
                    writer.WriteLine("SequenceActionEnter;" + Properties.Vehicle.Default.seq_ActionEnter);
                    writer.WriteLine("SequenceActionExit;" + Properties.Vehicle.Default.seq_ActionExit);
                    writer.WriteLine("SequenceDistanceEnter;" + Properties.Vehicle.Default.seq_DistanceEnter);
                    writer.WriteLine("SequenceDistanceExit;" + Properties.Vehicle.Default.seq_DistanceExit);

                    writer.WriteLine("FunctionList;" + Properties.Vehicle.Default.seq_FunctionList);
                    writer.WriteLine("ActionList;" + Properties.Vehicle.Default.seq_ActionList);

                    writer.WriteLine("RollFromBrick," + Properties.Settings.Default.setIMU_isRollFromBrick);
                    writer.WriteLine("HeadingFromBrick," + Properties.Settings.Default.setIMU_isHeadingFromBrick);
                    writer.WriteLine("RollFromDogs," + Properties.Settings.Default.setIMU_isRollFromDogs);
                    writer.WriteLine("HeadingFromBNO," + Properties.Settings.Default.setIMU_isHeadingFromBNO);
                    writer.WriteLine("Empty," + "10");
                    writer.WriteLine("Empty," + "10");
                    writer.WriteLine("Empty," + "10");
                    writer.WriteLine("Empty," + "10");
                    writer.WriteLine("Empty," + "10");
                    writer.WriteLine("Empty," + "10");

                }

                //little show to say saved and where
                var form = new FormTimedMessage(3000, "Saved in Folder: ", dirVehicle);
                form.Show();
            }

        }

        //function to open a previously saved field
        public void FileOpenVehicle()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            //get the directory where the fields are stored
            string directoryName = vehiclesDirectory;

            //make sure the directory exists, if not, create it
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            //the initial directory, fields, for the open dialog
            ofd.InitialDirectory = directoryName;

            //When leaving dialog put windows back where it was
            ofd.RestoreDirectory = true;

            //set the filter to text files only
            ofd.Filter = "txt files (*.txt)|*.txt";

            //was a file selected
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //if job started close it
                if (isJobStarted) JobClose();

                //make sure the file if fully valid and vehicle matches sections
                using (StreamReader reader = new StreamReader(ofd.FileName))
                {
                    try
                    {
                        string line;
                        Properties.Vehicle.Default.setVehicle_Name = ofd.FileName;
                        string[] words;
                        line = reader.ReadLine(); words = line.Split(',');

                        if (words[0] != "Version")

                        {
                            var form = new FormTimedMessage(5000, "Vehicle File is Wrong Version", "Must be Version 2.16 or higher");
                            form.Show();
                            return;
                        }

                        double test = double.Parse(words[1], CultureInfo.InvariantCulture);

                        if (test < 2.16)
                        {
                            var form = new FormTimedMessage(5000, "Vehicle File is Wrong Version", "Must be Version 2.16 or higher");
                            form.Show();
                            return;
                        }

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_toolOverlap = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_toolTrailingHitchLength = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_tankTrailingHitchLength = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_antennaHeight = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_lookAhead = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_antennaPivot = double.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_hitchLength = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_toolOffset = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_turnOffDelay = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_wheelbase = double.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_isPivotBehindAntenna = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_isSteerAxleAhead = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_isToolBehindPivot = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_isToolTrailing = bool.Parse(words[1]);

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setSection_position1 = decimal.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setSection_position2 = decimal.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setSection_position3 = decimal.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setSection_position4 = decimal.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setSection_position5 = decimal.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setSection_position6 = decimal.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setSection_position7 = decimal.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setSection_position8 = decimal.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setSection_position9 = decimal.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_numSections = int.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_toolWidth = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setF_IsWorkSwitchEnabled = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setF_IsWorkSwitchActiveLow = bool.Parse(words[1]);

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setCam_pitch = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setHeading_isFromPosition = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setDisplay_triangleResolution = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setMenu_isMetric = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setMenu_isGridOn = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setMenu_isLightbarOn = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setMenu_isAreaRight = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setMenu_isPureOn = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setMenu_isSideGuideLines = bool.Parse(words[1]);
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setF_FieldColorR = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setF_FieldColorG = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setF_FieldColorB = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setF_SectionColorR = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setF_SectionColorG = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setF_SectionColorB = byte.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_slowSpeedCutoff = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_minApplied = int.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setIMU_pitchZero = int.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setIMU_rollZero = int.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setMenu_isLogNMEA = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setF_minFixStep = double.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setAS_Kp = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setAS_Ki = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setAS_Kd = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setAS_Ko = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setAS_steerAngleOffset = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setAS_minSteerPWM = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setAS_maxIntegral = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine();words = line.Split(',');
                        Properties.Settings.Default.setAS_countsPerDegree = byte.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_lookAhead = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_maxSteerAngle = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_maxAngularVelocity = double.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine(); words = line.Split(';');
                        Properties.Vehicle.Default.seq_FunctionEnter = words[1];
                        line = reader.ReadLine(); words = line.Split(';');
                        Properties.Vehicle.Default.seq_FunctionExit = words[1];
                        line = reader.ReadLine(); words = line.Split(';');
                        Properties.Vehicle.Default.seq_ActionEnter = words[1];
                        line = reader.ReadLine(); words = line.Split(';');
                        Properties.Vehicle.Default.seq_ActionExit = words[1];
                        line = reader.ReadLine(); words = line.Split(';');
                        Properties.Vehicle.Default.seq_DistanceEnter = words[1];
                        line = reader.ReadLine(); words = line.Split(';');
                        Properties.Vehicle.Default.seq_DistanceExit = words[1];

                        line = reader.ReadLine(); words = line.Split(';');
                        Properties.Vehicle.Default.seq_FunctionList = words[1];
                        line = reader.ReadLine(); words = line.Split(';');
                        Properties.Vehicle.Default.seq_ActionList = words[1];

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setIMU_isRollFromBrick = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setIMU_isHeadingFromBrick = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setIMU_isRollFromDogs = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setIMU_isHeadingFromBNO = bool.Parse(words[1]);

                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();

                        //fill in the current variables with restored data
                        vehiclefileName = Path.GetFileNameWithoutExtension(ofd.FileName) + " - ";
                        Properties.Vehicle.Default.setVehicle_Name = vehiclefileName;

                        Properties.Settings.Default.Save();
                        Properties.Vehicle.Default.Save();

                        //get the number of sections from settings
                        vehicle.numOfSections = Properties.Vehicle.Default.setVehicle_numSections;
                        vehicle.numSuperSection = vehicle.numOfSections + 1;

                        //from settings grab the vehicle specifics
                        vehicle.toolOverlap = Properties.Vehicle.Default.setVehicle_toolOverlap;
                        vehicle.toolTrailingHitchLength = Properties.Vehicle.Default.setVehicle_toolTrailingHitchLength;
                        vehicle.tankTrailingHitchLength = Properties.Vehicle.Default.setVehicle_tankTrailingHitchLength;
                        vehicle.antennaHeight = Properties.Vehicle.Default.setVehicle_antennaHeight;
                        vehicle.toolLookAhead = Properties.Vehicle.Default.setVehicle_lookAhead;

                        vehicle.antennaPivot = Properties.Vehicle.Default.setVehicle_antennaPivot;
                        vehicle.hitchLength = Properties.Vehicle.Default.setVehicle_hitchLength;
                        vehicle.toolOffset = Properties.Vehicle.Default.setVehicle_toolOffset;
                        vehicle.toolTurnOffDelay = Properties.Vehicle.Default.setVehicle_turnOffDelay;
                        vehicle.wheelbase = Properties.Vehicle.Default.setVehicle_wheelbase;

                        vehicle.isToolTrailing = Properties.Vehicle.Default.setVehicle_isToolTrailing;
                        vehicle.isPivotBehindAntenna = Properties.Vehicle.Default.setVehicle_isPivotBehindAntenna;
                        vehicle.isSteerAxleAhead = Properties.Vehicle.Default.setVehicle_isSteerAxleAhead;
                        vehicle.isPivotBehindAntenna = Properties.Vehicle.Default.setVehicle_isToolBehindPivot;
                        vehicle.toolMinUnappliedPixels = Properties.Vehicle.Default.setVehicle_minApplied;

                        vehicle.maxAngularVelocity = Properties.Vehicle.Default.setVehicle_maxAngularVelocity;
                        vehicle.maxSteerAngle = Properties.Vehicle.Default.setVehicle_maxSteerAngle;

                        mc.autoSteerSettings[mc.ssKp] = Properties.Settings.Default.setAS_Kp;
                        mc.autoSteerSettings[mc.ssKi] = Properties.Settings.Default.setAS_Ki;
                        mc.autoSteerSettings[mc.ssKd] = Properties.Settings.Default.setAS_Kd;
                        mc.autoSteerSettings[mc.ssKo] = Properties.Settings.Default.setAS_Ko;
                        mc.autoSteerSettings[mc.ssSteerOffset] = Properties.Settings.Default.setAS_steerAngleOffset;
                        mc.autoSteerSettings[mc.ssMinPWM] = Properties.Settings.Default.setAS_minSteerPWM;
                        mc.autoSteerSettings[mc.ssMaxIntegral] = Properties.Settings.Default.setAS_maxIntegral;
                        mc.autoSteerSettings[mc.ssCountsPerDegree] = Properties.Settings.Default.setAS_countsPerDegree;

                        mc.isWorkSwitchEnabled = Properties.Settings.Default.setF_IsWorkSwitchEnabled;
                        mc.isWorkSwitchActiveLow = Properties.Settings.Default.setF_IsWorkSwitchActiveLow;

                        //Set width of section and positions for each section
                        SectionSetPosition();

                        //Calculate total width and each section width
                        SectionCalcWidths();

                        //enable disable manual buttons
                        LineUpManualBtns();

                        btnSection1Man.Enabled = false;
                        btnSection2Man.Enabled = false;
                        btnSection3Man.Enabled = false;
                        btnSection4Man.Enabled = false;
                        btnSection5Man.Enabled = false;
                        btnSection6Man.Enabled = false;
                        btnSection7Man.Enabled = false;
                        btnSection8Man.Enabled = false;

                        camera.camPitch = Properties.Settings.Default.setCam_pitch;

                        isHeadingFromFix = Properties.Settings.Default.setHeading_isFromPosition;
                        camera.triangleResolution = Properties.Settings.Default.setDisplay_triangleResolution;

                        isMetric = Properties.Settings.Default.setMenu_isMetric;
                        metricToolStrip.Checked = isMetric;
                        imperialToolStrip.Checked = isMetric;

                        isGridOn = Properties.Settings.Default.setMenu_isGridOn;
                        gridToolStripMenuItem.Checked = (isGridOn);

                        isLightbarOn = Properties.Settings.Default.setMenu_isLightbarOn;
                        lightbarToolStripMenuItem.Checked = isLightbarOn;

                        isPureDisplayOn = Properties.Settings.Default.setMenu_isPureOn;
                        pursuitLineToolStripMenuItem.Checked = isPureDisplayOn;

                        isSideGuideLines = Properties.Settings.Default.setMenu_isSideGuideLines;
                        sideGuideLines.Checked = isSideGuideLines;

                        isAreaOnRight = Properties.Settings.Default.setMenu_isAreaRight;

                        redSections = Properties.Settings.Default.setF_SectionColorR;
                        grnSections = Properties.Settings.Default.setF_SectionColorG;
                        bluSections = Properties.Settings.Default.setF_SectionColorB;
                        redField = Properties.Settings.Default.setF_FieldColorR;
                        grnField = Properties.Settings.Default.setF_FieldColorG;
                        bluField = Properties.Settings.Default.setF_FieldColorB;

                        vehicle.slowSpeedCutoff = Properties.Vehicle.Default.setVehicle_slowSpeedCutoff;

                        ahrs.pitchZero = Properties.Settings.Default.setIMU_pitchZero;
                        ahrs.rollZero = Properties.Settings.Default.setIMU_rollZero;
                        isLogNMEA = Properties.Settings.Default.setMenu_isLogNMEA;
                        minFixStepDist = Properties.Settings.Default.setF_minFixStep;

                        string sentence = Properties.Vehicle.Default.seq_FunctionEnter;
                        words = sentence.Split(',');
                        for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++) int.TryParse(words[i], out seq.seqEnter[i].function);

                        sentence = Properties.Vehicle.Default.seq_ActionEnter;
                        words = sentence.Split(',');
                        for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++) int.TryParse(words[i], out seq.seqEnter[i].action);

                        sentence = Properties.Vehicle.Default.seq_DistanceEnter;
                        words = sentence.Split(',');
                        for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
                            double.TryParse(words[i], NumberStyles.Float, CultureInfo.InvariantCulture, out seq.seqEnter[i].distance);

                        sentence = Properties.Vehicle.Default.seq_FunctionExit;
                        words = sentence.Split(',');
                        for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++) int.TryParse(words[i], out seq.seqExit[i].function);

                        sentence = Properties.Vehicle.Default.seq_ActionExit;
                        words = sentence.Split(',');
                        for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++) int.TryParse(words[i], out seq.seqExit[i].action);

                        sentence = Properties.Vehicle.Default.seq_DistanceExit;
                        words = sentence.Split(',');
                        for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
                            double.TryParse(words[i], NumberStyles.Float, CultureInfo.InvariantCulture, out seq.seqExit[i].distance);

                        ahrs.isRollBrick = Properties.Settings.Default.setIMU_isRollFromBrick;
                        ahrs.isHeadingBrick = Properties.Settings.Default.setIMU_isHeadingFromBrick;
                        ahrs.isRollDogs = Properties.Settings.Default.setIMU_isRollFromDogs;
                        ahrs.isHeadingBNO = Properties.Settings.Default.setIMU_isHeadingFromBNO;


                        //Application.Exit();
                    }
                    catch (Exception e) //FormatException e || IndexOutOfRangeException e2)
                    {
                        WriteErrorLog("Open Vehicle" + e.ToString());

                        //vehicle is corrupt, reload with all default information
                        Properties.Settings.Default.Reset();
                        Properties.Settings.Default.Save();
                        MessageBox.Show("Program will Reset to Recover. Please Restart", "Vehicle file is Corrupt", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Application.Exit();
                    }
                }
            }      //cancelled out of open file
        }//end of open file

        //function to open a previously saved field, resume, open exisiting, open named field
        public void FileOpenField(string _openType)
        {
            string fileAndDirectory = "";
            if (_openType.Contains("Field.txt"))
            {
                fileAndDirectory = _openType;
                _openType = "Load";
            }

            else fileAndDirectory = "Cancel";

            //get the directory where the fields are stored
            //string directoryName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+ "\\fields\\";
            switch (_openType)
            {
                case "Resume":
                    {
                        //Either exit or update running save
                        fileAndDirectory = fieldsDirectory + currentFieldDirectory + "\\Field.txt";
                        if (!File.Exists(fileAndDirectory)) fileAndDirectory = "Cancel";
                        break;
                    }

                case "Open":
                    {
                        //create the dialog instance
                        OpenFileDialog ofd = new OpenFileDialog();

                        //the initial directory, fields, for the open dialog
                        ofd.InitialDirectory = fieldsDirectory;

                        //When leaving dialog put windows back where it was
                        ofd.RestoreDirectory = true;

                        //set the filter to text files only
                        ofd.Filter = "Field files (Field.txt)|Field.txt";

                        //was a file selected
                        if (ofd.ShowDialog() == DialogResult.Cancel) fileAndDirectory = "Cancel";
                        else fileAndDirectory = ofd.FileName;
                        break;
                    }
            }

            if (fileAndDirectory == "Cancel") return;

            //close the existing job and reset everything
            this.JobClose();

            //and open a new job
            this.JobNew();

            //Saturday, February 11, 2017  -->  7:26:52 AM
            //$FieldDir
            //Bob_Feb11
            //$Offsets
            //533172,5927719,12 - offset easting, northing, zone
            //$Sections
            //10 - points in this patch
            //10.1728031317344,0.723157039771303 -easting, northing

            //start to read the file
            string line;
            using (StreamReader reader = new StreamReader(fileAndDirectory))
            {
                try
                {
                    //Date time line
                    line = reader.ReadLine();

                    //dir header $FieldDir
                    line = reader.ReadLine();

                    //read field directory
                    line = reader.ReadLine();

                    currentFieldDirectory = line.Trim();

                    //Offset header
                    line = reader.ReadLine();

                    //read the Offsets 
                    line = reader.ReadLine();
                    string[] offs = line.Split(',');
                    pn.utmEast = int.Parse(offs[0]);
                    pn.utmNorth = int.Parse(offs[1]);
                    pn.zone = int.Parse(offs[2]);

                    //create a new grid
                    worldGrid.CreateWorldGrid(pn.actualNorthing - pn.utmNorth, pn.actualEasting - pn.utmEast);
                }

                catch (Exception e)
                {
                    WriteErrorLog("While Opening Field" + e.ToString());

                    var form = new FormTimedMessage(4000, "Field File is Corrupt", "Choose a different field");
                    form.Show();
                    JobClose();
                    return;
                }
            }

            //section patches
            fileAndDirectory = fieldsDirectory + currentFieldDirectory + "\\Sections.txt";
            if (!File.Exists(fileAndDirectory))
            {
                var form = new FormTimedMessage(4000, "Missing Section File", "But Field is Loaded");
                form.Show();
                //return;
            }
            else
            {
                using (StreamReader reader = new StreamReader(fileAndDirectory))
                {
                    try
                    {
                        totalSquareMeters = 0;
                        userDistance = 0;
                        vec2 vecFix = new vec2(0, 0);

                        //read header
                        line = reader.ReadLine();

                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();
                            int verts = int.Parse(line);

                            section[0].triangleList = new List<vec2>();
                            section[0].patchList.Add(section[0].triangleList);

                            for (int v = 0; v < verts; v++)
                            {
                                line = reader.ReadLine();
                                string[] words = line.Split(',');
                                vecFix.easting = double.Parse(words[0], CultureInfo.InvariantCulture);
                                vecFix.northing = double.Parse(words[1], CultureInfo.InvariantCulture);
                                section[0].triangleList.Add(vecFix);
                            }

                            //calculate area of this patch - AbsoluteValue of (Ax(By-Cy) + Bx(Cy-Ay) + Cx(Ay-By)/2)
                            verts -= 2;
                            if (verts >= 2)
                            {
                                for (int j = 0; j < verts; j++)
                                {
                                    double temp = 0;
                                    temp = section[0].triangleList[j].easting * (section[0].triangleList[j + 1].northing - section[0].triangleList[j + 2].northing) +
                                              section[0].triangleList[j + 1].easting * (section[0].triangleList[j + 2].northing - section[0].triangleList[j].northing) +
                                                  section[0].triangleList[j + 2].easting * (section[0].triangleList[j].northing - section[0].triangleList[j + 1].northing);

                                    totalSquareMeters += Math.Abs((temp * 0.5));
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        WriteErrorLog("Loading Contour file" + e.ToString());

                        var form = new FormTimedMessage(4000, "Contour File is Corrupt", "But Field is Loaded");
                        form.Show();
                    }
                }
            }

                    // Contour points ----------------------------------------------------------------------------

                    fileAndDirectory = fieldsDirectory + currentFieldDirectory + "\\Contour.txt";
            if (!File.Exists(fileAndDirectory))
            {
                var form = new FormTimedMessage(4000, "Missing Contour File", "But Field is Loaded");
                form.Show();
                //return;
            }
            
            //Points in Patch followed by easting, heading, northing, altitude
            else
            {
                using (StreamReader reader = new StreamReader(fileAndDirectory))
                {
                    try
                    {
                        //read header
                        line = reader.ReadLine();

                        while (!reader.EndOfStream)
                        {
                            //read how many vertices in the following patch
                            line = reader.ReadLine();
                            int verts = int.Parse(line);

                            vec4 vecFix = new vec4(0, 0, 0, 0);

                            ct.ptList = new List<vec4>();
                            ct.stripList.Add(ct.ptList);

                            for (int v = 0; v < verts; v++)
                            {
                                line = reader.ReadLine();
                                string[] words = line.Split(',');
                                vecFix.x = double.Parse(words[0], CultureInfo.InvariantCulture);
                                vecFix.y = double.Parse(words[1], CultureInfo.InvariantCulture);
                                vecFix.z = double.Parse(words[2], CultureInfo.InvariantCulture);
                                vecFix.k = double.Parse(words[3], CultureInfo.InvariantCulture);

                                ct.ptList.Add(vecFix);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        WriteErrorLog("Loading Contour file" + e.ToString());

                        var form = new FormTimedMessage(4000, "Contour File is Corrupt", "But Field is Loaded");
                        form.Show();
                    }
                }
            }


            // Flags -------------------------------------------------------------------------------------------------

            //Either exit or update running save
            fileAndDirectory = fieldsDirectory + currentFieldDirectory + "\\Flags.txt";
            if (!File.Exists(fileAndDirectory))
            {
                var form = new FormTimedMessage(4000, "Missing Flags File", "But Field is Loaded");
                form.Show();
            }

            else
            {
                using (StreamReader reader = new StreamReader(fileAndDirectory))
                {
                    try
                    {
                        //read header
                        line = reader.ReadLine();

                        line = reader.ReadLine();
                        int points = int.Parse(line);

                        if (points > 0)
                        {
                            double lat;
                            double longi;
                            double east;
                            double nort;
                            int color, ID;

                            for (int v = 0; v < points; v++)
                            {

                                line = reader.ReadLine();
                                string[] words = line.Split(',');

                                lat = double.Parse(words[0], CultureInfo.InvariantCulture);
                                longi = double.Parse(words[1], CultureInfo.InvariantCulture);
                                east = double.Parse(words[2], CultureInfo.InvariantCulture);
                                nort = double.Parse(words[3], CultureInfo.InvariantCulture);
                                color = int.Parse(words[4]);
                                ID = int.Parse(words[5]);

                                CFlag flagPt = new CFlag(lat, longi, east, nort, color, ID);
                                flagPts.Add(flagPt);
                            }

                        }
                    }

                    catch (Exception e)
                    {
                        var form = new FormTimedMessage(4000, "Flag File is Corrupt", "But Field is Loaded");
                        form.Show();
                        WriteErrorLog("FieldOpen, Loading Flags, Corrupt Flag File" + e.ToString());
                    }
                }
            }


            // ABLine -------------------------------------------------------------------------------------------------

            //Either exit or update running save
            fileAndDirectory = fieldsDirectory + currentFieldDirectory + "\\ABLine.txt";
            if (!File.Exists(fileAndDirectory))
            {
                var form = new FormTimedMessage(4000, "Missing ABLine File", "But Field is Loaded");
                form.Show();
            }

            else
            {
                using (StreamReader reader = new StreamReader(fileAndDirectory))
                {
                    try
                    {
                        //read header
                        line = reader.ReadLine();

                        line = reader.ReadLine();
                        bool isAB = bool.Parse(line);

                        if (isAB)
                        {
                            //set gui image button on
                            btnABLine.Image = global::AgOpenGPS.Properties.Resources.ABLineOn;
                            btnRightYouTurn.Visible = true;
                            btnLeftYouTurn.Visible = true;

                            //Heading  , ,refPoint2x,z                    
                            line = reader.ReadLine();
                            ABLine.abHeading = double.Parse(line, CultureInfo.InvariantCulture);

                            //refPoint1x,z
                            line = reader.ReadLine();
                            string[] words = line.Split(',');
                            ABLine.refPoint1.easting = double.Parse(words[0], CultureInfo.InvariantCulture);
                            ABLine.refPoint1.northing = double.Parse(words[1], CultureInfo.InvariantCulture);

                            //refPoint2x,z
                            line = reader.ReadLine();
                            words = line.Split(',');
                            ABLine.refPoint2.easting = double.Parse(words[0], CultureInfo.InvariantCulture);
                            ABLine.refPoint2.northing = double.Parse(words[1], CultureInfo.InvariantCulture);

                            //Tramline
                            line = reader.ReadLine();
                            words = line.Split(',');
                            ABLine.tramPassEvery = int.Parse(words[0]);
                            ABLine.passBasedOn = int.Parse(words[1]);

                            ABLine.refABLineP1.easting = ABLine.refPoint1.easting - Math.Sin(ABLine.abHeading) * 10000.0;
                            ABLine.refABLineP1.northing = ABLine.refPoint1.northing - Math.Cos(ABLine.abHeading) * 10000.0;

                            ABLine.refABLineP2.easting = ABLine.refPoint1.easting + Math.Sin(ABLine.abHeading) * 10000.0;
                            ABLine.refABLineP2.northing = ABLine.refPoint1.northing + Math.Cos(ABLine.abHeading) * 10000.0;

                            ABLine.isABLineSet = true;

                            btnRightYouTurn.Enabled = true;
                            btnLeftYouTurn.Enabled = true;
                            btnRightYouTurn.Visible = true;
                            btnLeftYouTurn.Visible = true;

                            //auto YouTurn shutdown
                            yt.isYouTurnBtnOn = false;
                            yt.ResetYouTurnAndSequenceEvents();
                            youTurnProgressBar = 0;

                            //turn off youturn...
                            btnEnableAutoYouTurn.Enabled = true;
                            btnEnableAutoYouTurn.Image = Properties.Resources.YouTurnNo;
                        }

                        //if ABLine isn't set, turn off the YouTurn
                        else
                        {
                            btnRightYouTurn.Enabled = false;
                            btnLeftYouTurn.Enabled = false;
                            btnRightYouTurn.Visible = false;
                            btnLeftYouTurn.Visible = false;
                            btnEnableAutoYouTurn.Enabled = false;
                            yt.isYouTurnBtnOn = false;
                        }
                    }

                    catch (Exception e)
                    {
                        var form = new FormTimedMessage(4000, "AB Line File is Corrupt", "But Field is Loaded");
                        form.Show();
                        WriteErrorLog("Load AB Line" + e.ToString());

                    }
                }
            }


                // Boundary  -------------------------------------------------------------------------------------------------

                //Either exit or update running save
                fileAndDirectory = fieldsDirectory + currentFieldDirectory + "\\Boundary.txt";
            if (!File.Exists(fileAndDirectory))
            {
                var form = new FormTimedMessage(4000, "Missing Boundary File", "But Field is Loaded");
                form.Show();
            }

            else
            {
                using (StreamReader reader = new StreamReader(fileAndDirectory))
                {
                    try
                    {
                        //read header
                        line = reader.ReadLine();

                        line = reader.ReadLine();
                        int numPoints = int.Parse(line);

                        if (numPoints > 0)
                        {
                            vec2 vecPt = new vec2(0, 0);
                            boundz.ptList.Clear();

                            //load the line
                            for (int i = 0; i < numPoints; i++)
                            {
                                line = reader.ReadLine();
                                string[] words = line.Split(',');
                                vecPt.easting = double.Parse(words[0], CultureInfo.InvariantCulture);
                                vecPt.northing = double.Parse(words[1], CultureInfo.InvariantCulture);
                                boundz.ptList.Add(vecPt);
                            }

                            boundz.CalculateBoundaryArea();
                            boundz.PreCalcBoundaryLines();
                            if (boundz.area > 0) boundz.isSet = true;
                            else boundz.isSet = false;
                        }
                    }

                    catch (Exception e)
                    {
                        var form = new FormTimedMessage(4000, "Boundary Line File is Corrupt", "But Field is Loaded");
                        form.Show();
                        WriteErrorLog("Load Boundary Line" + e.ToString());

                    }
                }
            }
            

            // Headland  -------------------------------------------------------------------------------------------------

            //Either exit or update running save
            fileAndDirectory = fieldsDirectory + currentFieldDirectory + "\\Headland.txt";
            if (!File.Exists(fileAndDirectory))
            {
                var form = new FormTimedMessage(4000, "Missing Headland File", "But Field is Loaded");
                form.Show();
            }

            else
            {
                using (StreamReader reader = new StreamReader(fileAndDirectory))
                {
                    try
                    {
                        //read header
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        int numPoints = int.Parse(line);

                        if (numPoints > 0)
                        {
                            vec2 vecPt = new vec2(0, 0);
                            hl.ptList.Clear();

                            //load the line
                            for (int i = 0; i < numPoints; i++)
                            {
                                line = reader.ReadLine();
                                string[] words = line.Split(',');
                                vecPt.easting = double.Parse(words[0], CultureInfo.InvariantCulture);
                                vecPt.northing = double.Parse(words[1], CultureInfo.InvariantCulture);
                                hl.ptList.Add(vecPt);
                            }

                            hl.PreCalcHeadlandLines();

                            //quick double check to make sure its a valid loop
                            double area = hl.CalculateHeadlandArea();
                            if (area > 0) hl.isSet = true;
                            else hl.isSet = false;
                        }
                    }

                    catch (Exception e)
                    {
                        var form = new FormTimedMessage(4000, "Headland File is Corrupt", "But Field is Loaded");
                        form.Show();
                        WriteErrorLog("Load Headland Loop" + e.ToString());
                    }
                }
            }
        }//end of open file

        //creates the field file when starting new field
        public void FileCreateField()
        {
            //Saturday, February 11, 2017  -->  7:26:52 AM
            //$FieldDir
            //Bob_Feb11
            //$Offsets
            //533172,5927719,12 - offset easting, northing, zone

            if (!isJobStarted)
            {
                using (var form = new FormTimedMessage(3000, "Ooops, Job Not Started", "Start a Job First"))
                { form.Show(); }
                return;
            }
            string myFileName, dirField;

            //get the directory and make sure it exists, create if not
            dirField = fieldsDirectory + currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            myFileName = "Field.txt";

            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {
                //Write out the date
                writer.WriteLine(DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss tt", CultureInfo.InvariantCulture));

                writer.WriteLine("$FieldDir");
                writer.WriteLine(currentFieldDirectory.ToString(CultureInfo.InvariantCulture));

                //write out the easting and northing Offsets
                writer.WriteLine("$Offsets");
                writer.WriteLine(pn.utmEast.ToString(CultureInfo.InvariantCulture) + "," + 
                    pn.utmNorth.ToString(CultureInfo.InvariantCulture) + "," + 
                    pn.zone.ToString(CultureInfo.InvariantCulture));
            }
        }

        //save field Patches
        public void FileSaveSections()
        {
            //make sure there is something to save
            if (patchSaveList.Count() > 0)
            {
                //Append the current list to the field file
                using (StreamWriter writer = new StreamWriter((fieldsDirectory + currentFieldDirectory + "\\Sections.txt"), true))
                {
                    //for each patch, write out the list of triangles to the file
                    foreach (var triList in patchSaveList)
                    {
                        int count2 = triList.Count();
                        writer.WriteLine(count2.ToString(CultureInfo.InvariantCulture));

                        for (int i = 0; i < count2; i++)
                            writer.WriteLine((Math.Round(triList[i].easting,4)).ToString(CultureInfo.InvariantCulture) +
                                "," + (Math.Round(triList[i].northing,4)).ToString(CultureInfo.InvariantCulture));
                    }
                }

                //clear out that patchList and begin adding new ones for next save
                patchSaveList.Clear();
            }
        }

        //Create contour file
        public void FileCreateSections()
        {
            //$Sections
            //10 - points in this patch
            //10.1728031317344,0.723157039771303 -easting, northing

            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string myFileName = "Sections.txt";

            //write out the file
            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {
                //write paths # of sections
                writer.WriteLine("$Sections");
            }
        }

        //Create contour file
        public void FileCreateContour()
        {
            //12  - points in patch
            //64.697,0.168,-21.654,0 - east, heading, north, altitude

            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string myFileName = "Contour.txt";

            //write out the file
            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {
                writer.WriteLine("$Contour");
            }
        }

        //save the contour points which include elevation values
        public void FileSaveContour()
        {
            //1  - points in patch
            //64.697,0.168,-21.654,0 - east, heading, north, altitude

            //make sure there is something to save
            if (contourSaveList.Count() > 0)
            {
                //Append the current list to the field file
                using (StreamWriter writer = new StreamWriter((fieldsDirectory + currentFieldDirectory + "\\Contour.txt"), true))
                {

                    //for every new chunk of patch in the whole section
                    foreach (var triList in contourSaveList)
                    {
                        int count2 = triList.Count;

                        writer.WriteLine(count2.ToString(CultureInfo.InvariantCulture));

                        for (int i = 0; i < count2; i++)
                        {
                            writer.WriteLine(Math.Round((triList[i].x), 4).ToString(CultureInfo.InvariantCulture) + "," +
                                Math.Round(triList[i].y, 4).ToString(CultureInfo.InvariantCulture) + "," +
                                Math.Round(triList[i].z, 4).ToString(CultureInfo.InvariantCulture) + "," +
                                Math.Round(triList[i].k, 4).ToString(CultureInfo.InvariantCulture));
                        }
                    }
                }

                contourSaveList.Clear();

            }

            //set saving flag off
            isSavingFile = false;
        }

        //save the boundary
        public void FileSaveOuterBoundary()
        {
            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            //write out the file
            using (StreamWriter writer = new StreamWriter(dirField + "boundary.Txt"))
            {
                writer.WriteLine("$Boundary");                
                writer.WriteLine(boundz.ptList.Count.ToString(CultureInfo.InvariantCulture));
                if (boundz.ptList.Count > 0)
                {
                    for (int j = 0; j < boundz.ptList.Count; j++)
                        writer.WriteLine(boundz.ptList[j].easting.ToString(CultureInfo.InvariantCulture) + "," + 
                                            boundz.ptList[j].northing.ToString(CultureInfo.InvariantCulture));
                }
            }
        }

        //save the headland
        public void FileSaveHeadlandYouTurn()
        {
            //Saturday, February 11, 2017  -->  7:26:52 AM
            //12  - points in patch
            //64.697,0.168,-21.654,0 - east, heading, north, altitude
            //$ContourDir
            //Bob_Feb11
            //$Offsets
            //533172,5927719,12

            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            //write out the file
            using (StreamWriter writer = new StreamWriter(dirField + "Headland.Txt"))
            {
                writer.WriteLine("$Headland");
                writer.WriteLine(hl.ptList.Count.ToString(CultureInfo.InvariantCulture));
                if (hl.ptList.Count > 0)
                {
                    for (int j = 0; j < hl.ptList.Count; j++)
                        writer.WriteLine(hl.ptList[j].easting.ToString(CultureInfo.InvariantCulture) + "," +
                                            hl.ptList[j].northing.ToString(CultureInfo.InvariantCulture));
                }
            }
        }

        //save all the flag markers
        public void FileSaveFlags()
        {
            //Saturday, February 11, 2017  -->  7:26:52 AM
            //$FlagsDir
            //Bob_Feb11
            //$Offsets
            //533172,5927719,12 - offset easting, northing, zone

            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            //use Streamwriter to create and overwrite existing flag file
            using (StreamWriter writer = new StreamWriter(dirField + "Flags.txt"))
            {
                try
                {
                    writer.WriteLine("$Flags");

                    int count2 = flagPts.Count;
                    writer.WriteLine(count2);

                    for (int i = 0; i < count2; i++)
                    {
                        writer.WriteLine(
                            flagPts[i].latitude.ToString(CultureInfo.InvariantCulture) + "," +
                            flagPts[i].longitude.ToString(CultureInfo.InvariantCulture) + "," +
                            flagPts[i].easting.ToString(CultureInfo.InvariantCulture) + "," +
                            flagPts[i].northing.ToString(CultureInfo.InvariantCulture) + "," +
                            flagPts[i].color.ToString(CultureInfo.InvariantCulture) + "," +
                            flagPts[i].ID.ToString(CultureInfo.InvariantCulture));
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n Cannot write to file.");
                    WriteErrorLog("Saving Flags" + e.ToString());
                    return;
                }
            }
        }

        //save all the flag markers
        public void FileSaveABLine()
        {
            //Saturday, February 11, 2017  -->  7:26:52 AM

            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            //use Streamwriter to create and overwrite existing ABLine file
            using (StreamWriter writer = new StreamWriter(dirField + "ABLine.txt"))
            {
                try
                {
                    //write out the ABLine
                    writer.WriteLine("$ABLine");

                    //true or false if ABLine is set
                    if (ABLine.isABLineSet) writer.WriteLine(true);
                    else writer.WriteLine(false);

                    writer.WriteLine(ABLine.abHeading.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine(ABLine.refPoint1.easting.ToString(CultureInfo.InvariantCulture) + "," + ABLine.refPoint1.northing.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine(ABLine.refPoint2.easting.ToString(CultureInfo.InvariantCulture) + "," + ABLine.refPoint2.northing.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine(ABLine.tramPassEvery.ToString(CultureInfo.InvariantCulture) + "," + ABLine.passBasedOn.ToString(CultureInfo.InvariantCulture));
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n Cannot write to file.");
                    WriteErrorLog("Saving AB Line" + e.ToString());

                    return;
                }

            }
        }

        //save nmea sentences
        public void FileSaveNMEA()
        {
            using (StreamWriter writer =  new StreamWriter((fieldsDirectory + currentFieldDirectory + "\\NMEA_log.txt"), true))
            {
                writer.Write(pn.logNMEASentence.ToString());
            }
            pn.logNMEASentence.Clear();
        }

        //generate KML file from flags
        public void FileSaveFlagsKML()
        {

            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string myFileName;
            myFileName = "Flags.kml";

            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {

                writer.WriteLine(@"<?xml version=""1.0"" encoding=""UTF-8""?>     ");
                writer.WriteLine(@"<kml xmlns=""http://www.opengis.net/kml/2.2""> ");

                int count2 = flagPts.Count;

                writer.WriteLine(@"<Document>");

                for (int i = 0; i < count2; i++)
                {
                    writer.WriteLine(@"  <Placemark>                                  ");
                    writer.WriteLine(@"<Style> <IconStyle>");
                    if (flagPts[i].color == 0)  //red - xbgr
                        writer.WriteLine(@"<color>ff4400ff</color>");
                    if (flagPts[i].color == 1)  //grn - xbgr
                        writer.WriteLine(@"<color>ff44ff00</color>");
                    if (flagPts[i].color == 2)  //yel - xbgr
                        writer.WriteLine(@"<color>ff44ffff</color>");

                    writer.WriteLine(@"</IconStyle> </Style>");
                    writer.WriteLine(@" <name> " + (i+1) + @"</name>");
                    writer.WriteLine(@"<Point><coordinates> " +
                                    flagPts[i].longitude.ToString(CultureInfo.InvariantCulture) + "," + flagPts[i].latitude.ToString(CultureInfo.InvariantCulture) + ",0" +
                                    @"</coordinates> </Point> ");
                writer.WriteLine(@"  </Placemark>                                 ");
                       
                }

                writer.WriteLine(@"</Document>");

                writer.WriteLine(@"</kml>                                         ");


            
            }

        }

        //generate KML file from flag
        public void FileSaveSingleFlagKML(int flagNumber)
        {

            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string myFileName;
            myFileName = "Flag.kml";

            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {

                writer.WriteLine(@"<?xml version=""1.0"" encoding=""UTF-8""?>     ");
                writer.WriteLine(@"<kml xmlns=""http://www.opengis.net/kml/2.2""> ");

                int count2 = flagPts.Count;

                writer.WriteLine(@"<Document>");

                    writer.WriteLine(@"  <Placemark>                                  ");
                    writer.WriteLine(@"<Style> <IconStyle>");
                    if (flagPts[flagNumber - 1].color == 0)  //red - xbgr
                        writer.WriteLine(@"<color>ff4400ff</color>");
                    if (flagPts[flagNumber - 1].color == 1)  //grn - xbgr
                        writer.WriteLine(@"<color>ff44ff00</color>");
                    if (flagPts[flagNumber - 1].color == 2)  //yel - xbgr
                        writer.WriteLine(@"<color>ff44ffff</color>");
                    writer.WriteLine(@"</IconStyle> </Style>");
                    writer.WriteLine(@" <name> " + flagNumber.ToString(CultureInfo.InvariantCulture) + @"</name>");
                    writer.WriteLine(@"<Point><coordinates> " +
                                    flagPts[flagNumber-1].longitude.ToString(CultureInfo.InvariantCulture) + "," + flagPts[flagNumber-1].latitude.ToString(CultureInfo.InvariantCulture) + ",0" +
                                    @"</coordinates> </Point> ");
                    writer.WriteLine(@"  </Placemark>                                 ");
                writer.WriteLine(@"</Document>");
                writer.WriteLine(@"</kml>                                         ");

            }
        }

        //generate KML file from flag
        public void FileMakeCurrentKML(double lat, double lon)
        {
            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string myFileName;
            myFileName = "CurrentPosition.kml";

            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {

                writer.WriteLine(@"<?xml version=""1.0"" encoding=""UTF-8""?>     ");
                writer.WriteLine(@"<kml xmlns=""http://www.opengis.net/kml/2.2""> ");

                int count2 = flagPts.Count;

                writer.WriteLine(@"<Document>");

                writer.WriteLine(@"  <Placemark>                                  ");
                writer.WriteLine(@"<Style> <IconStyle>");
                writer.WriteLine(@"<color>ff4400ff</color>");
                writer.WriteLine(@"</IconStyle> </Style>");
                writer.WriteLine(@" <name> Your Current Position </name>");
                writer.WriteLine(@"<Point><coordinates> " +
                                lon.ToString(CultureInfo.InvariantCulture) + "," + lat.ToString(CultureInfo.InvariantCulture) + ",0" +
                                @"</coordinates> </Point> ");
                writer.WriteLine(@"  </Placemark>                                 ");
                writer.WriteLine(@"</Document>");
                writer.WriteLine(@"</kml>                                         ");

            }
        }
    }
}