using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Drawing;
using System.Xml;
using System.Text;

namespace AgOpenGPS
{
    
    public partial class FormGPS
    {
        //list of the list of patch data individual triangles for field sections
        public List<List<vec3>> patchSaveList = new List<List<vec3>>();

        //list of the list of patch data individual triangles for contour tracking
        public List<List<vec3>> contourSaveList = new List<List<vec3>>();

        public void FileSaveCurveLines()
        {
            curve.moveDistance = 0;

            string dirField = fieldsDirectory + currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField).ToString(CultureInfo.InvariantCulture);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string filename = directoryName + "\\CurveLines.txt";

            int cnt = curve.curveArr.Count;
            curve.numCurveLines = cnt;

            using (StreamWriter writer = new StreamWriter(filename, false))
            {
                try
                {
                    if (cnt > 0)
                    {
                        writer.WriteLine("$CurveLines");

                        for (int i = 0; i < cnt; i++)
                        {
                            //write out the Name
                            writer.WriteLine(curve.curveArr[i].Name);

                            //write out the aveheading
                            writer.WriteLine(curve.curveArr[i].aveHeading.ToString(CultureInfo.InvariantCulture));

                            //write out the points of ref line
                            int cnt2 = curve.curveArr[i].curvePts.Count;

                            writer.WriteLine(cnt2.ToString(CultureInfo.InvariantCulture));
                            if (curve.curveArr[i].curvePts.Count > 0)
                            {
                                for (int j = 0; j < cnt2; j++)
                                    writer.WriteLine(Math.Round(curve.curveArr[i].curvePts[j].easting, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                                        Math.Round(curve.curveArr[i].curvePts[j].northing, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                                            Math.Round(curve.curveArr[i].curvePts[j].heading, 5).ToString(CultureInfo.InvariantCulture));
                            }
                        }
                    }
                    else
                    {
                        writer.WriteLine("$CurveLines");
                    }
                }
                catch (Exception er)
                {
                    WriteErrorLog("Saving Curve Line" + er.ToString());

                    return;
                }
            }

            if (curve.numCurveLines == 0) curve.numCurveLineSelected = 0;
            if (curve.numCurveLineSelected > curve.numCurveLines) curve.numCurveLineSelected = curve.numCurveLines;

        }

        public void FileLoadCurveLines()
        {
            curve.moveDistance = 0;

            curve.curveArr?.Clear();
            curve.numCurveLines = 0;

            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string filename = directoryName + "\\CurveLines.txt";

            if (!File.Exists(filename))
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine("$CurveLines");
                }
            }

            //get the file of previous AB Lines
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            if (!File.Exists(filename))
            {
                TimedMessageBox(2000, gStr.gsFileError, gStr.gsMissingABCurveFile);
            }
            else
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    try
                    {
                        string line;

                        //read header $CurveLine
                        line = reader.ReadLine();

                        while (!reader.EndOfStream)
                        {
                            curve.curveArr.Add(new CCurveLines());

                            //read header $CurveLine
                            curve.curveArr[curve.numCurveLines].Name = reader.ReadLine();
                            // get the average heading
                            line = reader.ReadLine();
                            curve.curveArr[curve.numCurveLines].aveHeading = double.Parse(line, CultureInfo.InvariantCulture);

                            line = reader.ReadLine();
                            int numPoints = int.Parse(line);

                            if (numPoints > 1)
                            {
                                curve.curveArr[curve.numCurveLines].curvePts?.Clear();

                                for (int i = 0; i < numPoints; i++)
                                {
                                    line = reader.ReadLine();
                                    string[] words = line.Split(',');
                                    vec3 vecPt = new vec3(double.Parse(words[0], CultureInfo.InvariantCulture),
                                        double.Parse(words[1], CultureInfo.InvariantCulture),
                                        double.Parse(words[2], CultureInfo.InvariantCulture));
                                    curve.curveArr[curve.numCurveLines].curvePts.Add(vecPt);
                                }
                                curve.numCurveLines++;
                            }
                            else
                            {
                                if (curve.curveArr.Count > 0)
                                {
                                    curve.curveArr.RemoveAt(curve.numCurveLines);
                                }
                            }
                        }
                    }
                    catch (Exception er)
                    {
                        var form = new FormTimedMessage(2000, gStr.gsCurveLineFileIsCorrupt, gStr.gsButFieldIsLoaded);
                        form.Show();
                        WriteErrorLog("Load Curve Line" + er.ToString());
                    }
                }
            }

            if (curve.numCurveLines == 0) curve.numCurveLineSelected = 0;
            if (curve.numCurveLineSelected > curve.numCurveLines) curve.numCurveLineSelected = curve.numCurveLines;
        }

        public void FileSaveABLines()
        {
            ABLine.moveDistance = 0;

            //make sure at least a global blank AB Line file exists
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField).ToString(CultureInfo.InvariantCulture);

            //get the file of previous AB Lines
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string filename = directoryName + "\\ABLines.txt";
            int cnt = ABLine.lineArr.Count;

            using (StreamWriter writer = new StreamWriter(filename, false))
            {
                if (cnt > 0)
                {
                    foreach (var item in ABLine.lineArr)
                    {
                        //make it culture invariant
                        string line = item.Name
                            + ',' + (Math.Round(glm.toDegrees(item.heading), 8)).ToString(CultureInfo.InvariantCulture)
                            + ',' + (Math.Round(item.origin.easting, 3)).ToString(CultureInfo.InvariantCulture)
                            + ',' + (Math.Round(item.origin.northing, 3)).ToString(CultureInfo.InvariantCulture);

                        //write out to file
                        writer.WriteLine(line);
                    }
                }
            }

            if (ABLine.numABLines == 0) ABLine.numABLineSelected = 0;
            if (ABLine.numABLineSelected > ABLine.numABLines) ABLine.numABLineSelected = ABLine.numABLines;
        }

        public void FileLoadABLines()
        {
            ABLine.moveDistance = 0;

            //make sure at least a global blank AB Line file exists
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField).ToString(CultureInfo.InvariantCulture);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string filename = directoryName + "\\ABLines.txt";

            if (!File.Exists(filename))
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                }
            }

            if (!File.Exists(filename))
            {
                TimedMessageBox(2000, gStr.gsFileError, gStr.gsMissingABLinesFile);
            }
            else
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    try
                    {
                        string line;
                        ABLine.numABLines = 0;
                        ABLine.numABLineSelected = 0;
                        ABLine.lineArr?.Clear();

                        //read all the lines
                        for (int i = 0; !reader.EndOfStream; i++)
                        {

                            line = reader.ReadLine();
                            string[] words = line.Split(',');

                            if (words.Length != 4) break;

                            ABLine.lineArr.Add(new CABLines());

                            ABLine.lineArr[i].Name = words[0];


                            ABLine.lineArr[i].heading = glm.toRadians(double.Parse(words[1], CultureInfo.InvariantCulture));
                            ABLine.lineArr[i].origin.easting = double.Parse(words[2], CultureInfo.InvariantCulture);
                            ABLine.lineArr[i].origin.northing = double.Parse(words[3], CultureInfo.InvariantCulture);

                            ABLine.lineArr[i].ref1.easting = ABLine.lineArr[i].origin.easting - (Math.Sin(ABLine.lineArr[i].heading) * 1000.0);
                            ABLine.lineArr[i].ref1.northing = ABLine.lineArr[i].origin.northing - (Math.Cos(ABLine.lineArr[i].heading) *1000.0);

                            ABLine.lineArr[i].ref2.easting = ABLine.lineArr[i].origin.easting + (Math.Sin(ABLine.lineArr[i].heading) * 1000.0);
                            ABLine.lineArr[i].ref2.northing = ABLine.lineArr[i].origin.northing + (Math.Cos(ABLine.lineArr[i].heading) * 1000.0);
                            ABLine.numABLines++;
                        }
                    }
                    catch (Exception er)
                    {
                        var form = new FormTimedMessage(2000, gStr.gsABLineFileIsCorrupt, "Please delete it!!!");
                        form.Show();
                        WriteErrorLog("FieldOpen, Loading ABLine, Corrupt ABLine File" + er);
                    }
                }
            }

            if (ABLine.numABLines == 0) ABLine.numABLineSelected = 0;
            if (ABLine.numABLineSelected > ABLine.numABLines) ABLine.numABLineSelected = ABLine.numABLines;
        }

        //function that save vehicle and section settings
        public void FileSaveVehicle(string FileName)
        {
            vehicleFileName = Path.GetFileNameWithoutExtension(FileName) + " - ";
            Properties.Vehicle.Default.setVehicle_vehicleName = vehicleFileName;
            Properties.Vehicle.Default.Save();

            using (StreamWriter writer = new StreamWriter(FileName))
            {
                writer.WriteLine("Version," + Application.ProductVersion.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("AntennaHeight," + Properties.Vehicle.Default.setVehicle_antennaHeight.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("AntennaPivot," + Properties.Vehicle.Default.setVehicle_antennaPivot.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("AntennaOffset," + Properties.Vehicle.Default.setVehicle_antennaOffset.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsPivotBehindAntenna," + Properties.Vehicle.Default.setVehicle_isPivotBehindAntenna.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsSteerAxleAhead," + Properties.Vehicle.Default.setVehicle_isSteerAxleAhead.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("Wheelbase," + Properties.Vehicle.Default.setVehicle_wheelbase.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("MinTurningRadius," + Properties.Vehicle.Default.setVehicle_minTurningRadius.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("MinFixStep," + Properties.Settings.Default.setF_minFixStep.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("LowSpeedCutoff," + Properties.Vehicle.Default.setVehicle_slowSpeedCutoff.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("VehicleType," + Properties.Vehicle.Default.setVehicle_vehicleType.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");

                writer.WriteLine("GeoFenceDistance," + Properties.Vehicle.Default.set_geoFenceDistance.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("UTurnSkipWidth," + Properties.Vehicle.Default.set_youSkipWidth.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("YouTurnDistance," + Properties.Vehicle.Default.set_youTurnDistance.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("youTriggerDistance," + Properties.Vehicle.Default.set_youTriggerDistance.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("YouTurnUseDubins," + Properties.Vehicle.Default.set_youUseDubins.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsMachineControlToAS," + Properties.Vehicle.Default.setVehicle_isMachineControlToAutoSteer.ToString(CultureInfo.InvariantCulture));

                //AutoSteer
                writer.WriteLine("pidP," + Properties.Settings.Default.setAS_Kp.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("LowSteerPWM," + Properties.Settings.Default.setAS_lowSteerPWM.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("pidD," + Properties.Settings.Default.setAS_Kd.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("pidO," + Properties.Settings.Default.setAS_Ko.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("SteerAngleOffset," + Properties.Settings.Default.setAS_steerAngleOffset.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("minPWM," + Properties.Settings.Default.setAS_minSteerPWM.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("HighSteerPWM," + Properties.Settings.Default.setAS_highSteerPWM.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("CountsPerDegree," + Properties.Settings.Default.setAS_countsPerDegree.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("MaxSteerAngle," + Properties.Vehicle.Default.setVehicle_maxSteerAngle.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("MaxAngularVelocity," + Properties.Vehicle.Default.setVehicle_maxAngularVelocity.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("SnapDistance," + Properties.Settings.Default.setAS_snapDistance.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("isStanleyUsed," + Properties.Vehicle.Default.setVehicle_isStanleyUsed.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("StanleyGain," + Properties.Vehicle.Default.setVehicle_stanleyGain.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("StanleyHeadingError," + Properties.Vehicle.Default.setVehicle_stanleyHeadingErrorGain.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("GoalPointLookAhead," +
                    Properties.Vehicle.Default.setVehicle_goalPointLookAhead.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("GoalPointLookAheadUTurnMult," +
                    Properties.Vehicle.Default.setVehicle_goalPointLookAheadUturnMult.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("GoalPointLookAheadMinumum," +
                    Properties.Vehicle.Default.setVehicle_lookAheadMinimum.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("GoalPointLookAheadDistanceFromLine," +
                    Properties.Vehicle.Default.setVehicle_lookAheadDistanceFromLine.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("HydLiftLookAhead," + Properties.Vehicle.Default.setVehicle_hydraulicLiftLookAhead.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");

                //IMU
                writer.WriteLine("HeadingFromSource," + Properties.Settings.Default.setGPS_headingFromWhichSource);
                writer.WriteLine("GPSWhichSentence," + Properties.Settings.Default.setGPS_fixFromWhichSentence.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("HeadingFromBrick," + Properties.Settings.Default.setIMU_isHeadingCorrectionFromBrick);
                writer.WriteLine("RollFromAutoSteer," + Properties.Settings.Default.setIMU_isRollFromAutoSteer);
                writer.WriteLine("HeadingFromAutoSteer," + Properties.Settings.Default.setIMU_isHeadingCorrectionFromAutoSteer);
                writer.WriteLine("IMUPitchZero," + Properties.Settings.Default.setIMU_pitchZeroX16.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IMURollZero," + Properties.Settings.Default.setIMU_rollZeroX16.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("IMUFusion," + Properties.Settings.Default.setIMU_fusionWeight.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");

                //Arduino steer Config
                writer.WriteLine("ArduinoInclinometer," + Properties.Vehicle.Default.setArdSteer_inclinometer.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("ArduinoMaxPulseCounts," + Properties.Vehicle.Default.setArdSteer_maxPulseCounts.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("ArduinoMaxSpeed," + Properties.Vehicle.Default.setArdSteer_maxSpeed.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("ArduinoMinSpeed," + Properties.Vehicle.Default.setArdSteer_minSpeed.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("ArduinoSetting0," + Properties.Vehicle.Default.setArdSteer_setting0.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("ArduinoSetting1," + Properties.Vehicle.Default.setArdSteer_setting1.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("ArduinoAckermanFix," + Properties.Vehicle.Default.setArdSteer_ackermanFix.ToString(CultureInfo.InvariantCulture));

                //Arduino Machine Config
                writer.WriteLine("ArdMachineRaiseTime," + Properties.Vehicle.Default.setArdMac_hydRaiseTime.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("ArdMachineLowerTime," + Properties.Vehicle.Default.setArdMac_hydLowerTime.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("ArdMachineEnableHydraulics," + Properties.Vehicle.Default.setArdMac_isHydEnabled.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("ArdSteerSetting2," + Properties.Vehicle.Default.setArdSteer_setting2);
                writer.WriteLine("ArdMacSetting0," + Properties.Vehicle.Default.setArdMac_setting0);

                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");

                //uturn sequences
                writer.WriteLine("SequenceFunctionEnter;" + Properties.Vehicle.Default.seq_FunctionEnter);
                writer.WriteLine("SequenceFunctionExit;" + Properties.Vehicle.Default.seq_FunctionExit);
                writer.WriteLine("SequenceActionEnter;" + Properties.Vehicle.Default.seq_ActionEnter);
                writer.WriteLine("SequenceActionExit;" + Properties.Vehicle.Default.seq_ActionExit);
                writer.WriteLine("SequenceDistanceEnter;" + Properties.Vehicle.Default.seq_DistanceEnter);
                writer.WriteLine("SequenceDistanceExit;" + Properties.Vehicle.Default.seq_DistanceExit);

                writer.WriteLine("FunctionList;" + Properties.Vehicle.Default.seq_FunctionList);
                writer.WriteLine("ActionList;" + Properties.Vehicle.Default.seq_ActionList);

                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
            }

            //little show to say saved and where
            var form = new FormTimedMessage(3000, gStr.gsSavedInFolder, vehiclesDirectory);
            form.Show();
        }

        //function to open a previously saved field
        public bool FileOpenVehicle(string filename)
        {
            //OpenFileDialog ofd = new OpenFileDialog();

            ////get the directory where the fields are stored
            //string directoryName = vehiclesDirectory;

            ////make sure the directory exists, if not, create it
            //if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            //{ Directory.CreateDirectory(directoryName); }

            ////the initial directory, fields, for the open dialog
            //ofd.InitialDirectory = directoryName;

            ////When leaving dialog put windows back where it was
            //ofd.RestoreDirectory = true;

            ////set the filter to text files only
            //ofd.Filter = "txt files (*.txt)|*.txt";

            ////was a file selected
            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    //if job started close it
            //    if (isJobStarted) JobClose();

            //make sure the file if fully valid and vehicle matches sections
            using (StreamReader reader = new StreamReader(filename))
            {
                try
                {
                    string line;
                    Properties.Vehicle.Default.setVehicle_vehicleName = filename;
                    string[] words;
                    line = reader.ReadLine(); words = line.Split(',');

                    //file version
                    string []fullVers = words[1].Split('.');
                    string vers = fullVers[0] + fullVers[1];
                    int fileVersion = int.Parse(vers, CultureInfo.InvariantCulture);

                    //assembly version
                    string assemblyVersion = Application.ProductVersion.ToString(CultureInfo.InvariantCulture);
                    fullVers = assemblyVersion.Split('.');
                    int appVersion = int.Parse(fullVers[0]+fullVers[1], CultureInfo.InvariantCulture);

                    if (fileVersion < appVersion)
                    {
                        var form = new FormTimedMessage(5000, gStr.gsVehicleFileIsWrongVersion, gStr.gsMustBeVersion + Application.ProductVersion.ToString(CultureInfo.InvariantCulture) + " or higher");
                        form.Show();
                        return false;
                    }
                    else
                    {
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_antennaHeight = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_antennaPivot = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_antennaOffset = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_isPivotBehindAntenna = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');

                        Properties.Vehicle.Default.setVehicle_isSteerAxleAhead = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_wheelbase = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_minTurningRadius = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setF_minFixStep = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_slowSpeedCutoff = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_vehicleType = int.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.set_geoFenceDistance = int.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.set_youSkipWidth = int.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.set_youTurnDistance = int.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.set_youTriggerDistance = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.set_youUseDubins = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_isMachineControlToAutoSteer = bool.Parse(words[1]);

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setAS_Kp = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setAS_lowSteerPWM = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setAS_Kd = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setAS_Ko = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setAS_steerAngleOffset = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setAS_minSteerPWM = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setAS_highSteerPWM = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setAS_countsPerDegree = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_maxSteerAngle = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_maxAngularVelocity = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setAS_snapDistance = int.Parse(words[1]);

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_isStanleyUsed = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_stanleyGain = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_stanleyHeadingErrorGain = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');

                        Properties.Vehicle.Default.setVehicle_goalPointLookAhead = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_goalPointLookAheadUturnMult = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_lookAheadMinimum = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_lookAheadDistanceFromLine = double.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_hydraulicLiftLookAhead = double.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setGPS_headingFromWhichSource = (words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setGPS_fixFromWhichSentence = (words[1]);

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setIMU_isHeadingCorrectionFromBrick = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setIMU_isRollFromAutoSteer = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setIMU_isHeadingCorrectionFromAutoSteer = bool.Parse(words[1]);

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setIMU_pitchZeroX16 = int.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setIMU_rollZeroX16 = int.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setIMU_fusionWeight = double.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setArdSteer_inclinometer = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setArdSteer_maxPulseCounts = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setArdSteer_maxSpeed = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setArdSteer_minSpeed = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setArdSteer_setting0 = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setArdSteer_setting1 = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setArdSteer_ackermanFix = byte.Parse(words[1], CultureInfo.InvariantCulture);

                        //Arduino Machine Config
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setArdMac_hydRaiseTime = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setArdMac_hydLowerTime = byte.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setArdMac_isHydEnabled = byte.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine(); words = line.Split(',');
                        //if (words[0] == "Empty") Properties.Vehicle.Default.setVehicle_lookAheadDistanceFromLine = 0;
                        Properties.Vehicle.Default.setArdSteer_setting2 = byte.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine(); words = line.Split(',');
                        //if (words[0] == "Empty") Properties.Vehicle.Default.setVehicle_lookAheadDistanceFromLine = 0;
                        Properties.Vehicle.Default.setArdMac_setting0 = byte.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine();
                        line = reader.ReadLine();

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

                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();

                        //fill in the current variables with restored data
                        vehicleFileName = Path.GetFileNameWithoutExtension(filename) + " - ";
                        Properties.Vehicle.Default.setVehicle_vehicleName = vehicleFileName;

                        Properties.Settings.Default.Save();
                        Properties.Vehicle.Default.Save();

                        //from settings grab the vehicle specifics
                        vehicle.antennaHeight = Properties.Vehicle.Default.setVehicle_antennaHeight;
                        vehicle.antennaPivot = Properties.Vehicle.Default.setVehicle_antennaPivot;
                        vehicle.antennaOffset = Properties.Vehicle.Default.setVehicle_antennaOffset;
                        vehicle.isPivotBehindAntenna = Properties.Vehicle.Default.setVehicle_isPivotBehindAntenna;
                        vehicle.isSteerAxleAhead = Properties.Vehicle.Default.setVehicle_isSteerAxleAhead;

                        vehicle.wheelbase = Properties.Vehicle.Default.setVehicle_wheelbase;
                        vehicle.minTurningRadius = Properties.Vehicle.Default.setVehicle_minTurningRadius;
                        minFixStepDist = Properties.Settings.Default.setF_minFixStep;
                        vehicle.slowSpeedCutoff = Properties.Vehicle.Default.setVehicle_slowSpeedCutoff;
                        vehicle.vehicleType = Properties.Vehicle.Default.setVehicle_vehicleType;

                        yt.rowSkipsWidth = Properties.Vehicle.Default.set_youSkipWidth;
                        yt.youTurnStartOffset = Properties.Vehicle.Default.set_youTurnDistance;
                        yt.triggerDistanceOffset = Properties.Vehicle.Default.set_youTriggerDistance;
                        yt.isUsingDubinsTurn = Properties.Vehicle.Default.set_youUseDubins;
                        mc.isMachineDataSentToAutoSteer = Properties.Vehicle.Default.setVehicle_isMachineControlToAutoSteer;

                        mc.autoSteerSettings[mc.ssKp] = Properties.Settings.Default.setAS_Kp;
                        mc.autoSteerSettings[mc.ssLowPWM] = Properties.Settings.Default.setAS_lowSteerPWM;
                        mc.autoSteerSettings[mc.ssKd] = Properties.Settings.Default.setAS_Kd;
                        mc.autoSteerSettings[mc.ssKo] = Properties.Settings.Default.setAS_Ko;
                        mc.autoSteerSettings[mc.ssSteerOffset] = Properties.Settings.Default.setAS_steerAngleOffset;
                        mc.autoSteerSettings[mc.ssMinPWM] = Properties.Settings.Default.setAS_minSteerPWM;
                        mc.autoSteerSettings[mc.ssHighPWM] = Properties.Settings.Default.setAS_highSteerPWM;
                        mc.autoSteerSettings[mc.ssCountsPerDegree] = Properties.Settings.Default.setAS_countsPerDegree;

                        vehicle.maxSteerAngle = Properties.Vehicle.Default.setVehicle_maxSteerAngle;
                        vehicle.maxAngularVelocity = Properties.Vehicle.Default.setVehicle_maxAngularVelocity;

                        isStanleyUsed = Properties.Vehicle.Default.setVehicle_isStanleyUsed;
                        vehicle.stanleyGain = Properties.Vehicle.Default.setVehicle_stanleyGain;
                        vehicle.stanleyHeadingErrorGain = Properties.Vehicle.Default.setVehicle_stanleyHeadingErrorGain;

                        vehicle.goalPointLookAheadSeconds = Properties.Vehicle.Default.setVehicle_toolLookAheadOn;
                        vehicle.goalPointLookAheadMinimumDistance = Properties.Vehicle.Default.setVehicle_lookAheadMinimum;
                        vehicle.goalPointDistanceMultiplier = Properties.Vehicle.Default.setVehicle_lookAheadDistanceFromLine;
                        vehicle.goalPointLookAheadUturnMult = Properties.Vehicle.Default.setVehicle_goalPointLookAheadUturnMult;

                        vehicle.hydLiftLookAheadTime = Properties.Vehicle.Default.setVehicle_hydraulicLiftLookAhead;

                        headingFromSource = Properties.Settings.Default.setGPS_headingFromWhichSource;
                        pn.fixFrom = Properties.Settings.Default.setGPS_fixFromWhichSentence;

                        ahrs.isHeadingCorrectionFromBrick = Properties.Settings.Default.setIMU_isHeadingCorrectionFromBrick;
                        ahrs.isRollFromAutoSteer = Properties.Settings.Default.setIMU_isRollFromAutoSteer;
                        ahrs.isHeadingCorrectionFromAutoSteer = Properties.Settings.Default.setIMU_isHeadingCorrectionFromAutoSteer;

                        ahrs.pitchZeroX16 = Properties.Settings.Default.setIMU_pitchZeroX16;
                        ahrs.rollZeroX16 = Properties.Settings.Default.setIMU_rollZeroX16;

                        ahrs.fusionWeight = Properties.Settings.Default.setIMU_fusionWeight;

                        mc.ardSteerConfig[mc.arHeaderHi] = 127; //PGN - 32750
                        mc.ardSteerConfig[mc.arHeaderLo] = 238;
                        mc.ardSteerConfig[mc.arSet0] = Properties.Vehicle.Default.setArdSteer_setting0;
                        mc.ardSteerConfig[mc.arSet1] = Properties.Vehicle.Default.setArdSteer_setting1;
                        mc.ardSteerConfig[mc.arMaxSpd] = Properties.Vehicle.Default.setArdSteer_maxSpeed;
                        mc.ardSteerConfig[mc.arMinSpd] = Properties.Vehicle.Default.setArdSteer_minSpeed;
                        mc.ardSteerConfig[mc.arAckermanFix] = Properties.Vehicle.Default.setArdSteer_ackermanFix;

                        byte inc = (byte)(Properties.Vehicle.Default.setArdSteer_inclinometer << 6);
                        mc.ardSteerConfig[mc.arIncMaxPulse] = (byte)(inc + (byte)Properties.Vehicle.Default.setArdSteer_maxPulseCounts);

                        mc.ardSteerConfig[mc.arSet2] = Properties.Vehicle.Default.setArdSteer_setting2; 
                        mc.ardSteerConfig[mc.ar9] = 0;

                        mc.ardMachineConfig[mc.amHeaderHi] = 127; //PGN - 32760
                        mc.ardMachineConfig[mc.amHeaderLo] = 248;
                        mc.ardMachineConfig[mc.amRaiseTime] = Properties.Vehicle.Default.setArdMac_hydRaiseTime;
                        mc.ardMachineConfig[mc.amLowerTime] = Properties.Vehicle.Default.setArdMac_hydLowerTime;
                        mc.ardMachineConfig[mc.amEnableHyd] = Properties.Vehicle.Default.setArdMac_isHydEnabled;
                        mc.ardMachineConfig[mc.amSet0] = Properties.Vehicle.Default.setArdMac_setting0; 
                        mc.ardMachineConfig[mc.am6] = 0;
                        mc.ardMachineConfig[mc.am7] = 0;
                        mc.ardMachineConfig[mc.am8] = 0;
                        mc.ardMachineConfig[mc.am9] = 0;

                        string sentence = Properties.Vehicle.Default.seq_FunctionEnter;
                        words = sentence.Split(',');

                        sentence = Properties.Vehicle.Default.seq_ActionEnter;
                        words = sentence.Split(',');

                        sentence = Properties.Vehicle.Default.seq_DistanceEnter;
                        words = sentence.Split(',');
                        for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)

                        sentence = Properties.Vehicle.Default.seq_FunctionExit;
                        words = sentence.Split(',');

                        sentence = Properties.Vehicle.Default.seq_ActionExit;
                        words = sentence.Split(',');

                        sentence = Properties.Vehicle.Default.seq_DistanceExit;
                        words = sentence.Split(',');

                    }
                    return true;
                }
                catch (Exception e) //FormatException e || IndexOutOfRangeException e2)
                {
                    WriteErrorLog("Open Vehicle" + e.ToString());

                    //vehicle is corrupt, reload with all default information
                    Properties.Vehicle.Default.Reset();
                    Properties.Vehicle.Default.Save();
                    Properties.Settings.Default.Reset();
                    Properties.Settings.Default.Save();
                    MessageBox.Show(gStr.gsProgramWillResetToRecoverPleaseRestart, gStr.gsVehicleFileIsCorrupt, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Restart();
                    Environment.Exit(0);
                    return false;
                }
            }
        }//end of open file

        //function that save vehicle and section settings
        public void FileSaveTool(string FileName)
        {
            toolFileName = Path.GetFileNameWithoutExtension(FileName) + " - ";
            Properties.Vehicle.Default.setVehicle_toolName = toolFileName;
            Properties.Vehicle.Default.Save();

            using (StreamWriter writer = new StreamWriter(FileName))
            {
                writer.WriteLine("Version," + Application.ProductVersion.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("Overlap," + Properties.Vehicle.Default.setVehicle_toolOverlap.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("ToolOffset," + Properties.Vehicle.Default.setVehicle_toolOffset.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("LookAheadOff," + Properties.Vehicle.Default.setVehicle_toolLookAheadOff.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("LookAheadOn," + Properties.Vehicle.Default.setVehicle_toolLookAheadOn.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("TurnOffDelay," + Properties.Vehicle.Default.setVehicle_toolOffDelay.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("ToolMinUnappliedPixels," + Properties.Vehicle.Default.setVehicle_minApplied.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");

                writer.WriteLine("ToolTrailingHitchLength," + Properties.Vehicle.Default.setTool_toolTrailingHitchLength.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("TankTrailingHitchLength," + Properties.Vehicle.Default.setVehicle_tankTrailingHitchLength.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("HitchLength," + Properties.Vehicle.Default.setVehicle_hitchLength.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("IsToolBehindPivot," + Properties.Vehicle.Default.setTool_isToolBehindPivot.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsToolTrailing," + Properties.Vehicle.Default.setTool_isToolTrailing.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsToolTBT," + Properties.Vehicle.Default.setTool_isToolTBT.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");

                writer.WriteLine("Spinner1," + Properties.Vehicle.Default.setSection_position1.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("Spinner2," + Properties.Vehicle.Default.setSection_position2.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("Spinner3," + Properties.Vehicle.Default.setSection_position3.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("Spinner4," + Properties.Vehicle.Default.setSection_position4.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("Spinner5," + Properties.Vehicle.Default.setSection_position5.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("Spinner6," + Properties.Vehicle.Default.setSection_position6.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("Spinner7," + Properties.Vehicle.Default.setSection_position7.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("Spinner8," + Properties.Vehicle.Default.setSection_position8.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("Spinner9," + Properties.Vehicle.Default.setSection_position9.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("Spinner10," + Properties.Vehicle.Default.setSection_position10.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("Spinner11," + Properties.Vehicle.Default.setSection_position11.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("Spinner12," + Properties.Vehicle.Default.setSection_position12.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("Spinner13," + Properties.Vehicle.Default.setSection_position13.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("Spinner14," + Properties.Vehicle.Default.setSection_position14.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("Spinner15," + Properties.Vehicle.Default.setSection_position15.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("Spinner16," + Properties.Vehicle.Default.setSection_position16.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("Spinner17," + Properties.Vehicle.Default.setSection_position17.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");

                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");

                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");

                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");


                writer.WriteLine("Sections," + Properties.Vehicle.Default.setVehicle_numSections.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("ToolWidth," + Properties.Vehicle.Default.setVehicle_toolWidth.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");

                writer.WriteLine("WorkSwitch," + Properties.Settings.Default.setF_IsWorkSwitchEnabled.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("ActiveLow," + Properties.Settings.Default.setF_IsWorkSwitchActiveLow.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("SwitchManual," + Properties.Settings.Default.setF_IsWorkSwitchManual.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
            }

            //little show to say saved and where
            var form = new FormTimedMessage(3000, gStr.gsSavedInFolder, toolsDirectory);
            form.Show();
        }        

        //function to open a previously saved field
        public bool FileOpenTool(string fileName)
        {
            //make sure the file if fully valid and vehicle matches sections
            using (StreamReader reader = new StreamReader(fileName))
            {
                try
                {
                    string line;
                    Properties.Vehicle.Default.setVehicle_toolName = fileName;
                    string[] words;
                    line = reader.ReadLine(); words = line.Split(',');

                    string vers = words[1].Replace('.', '0');
                    int fileVersion = int.Parse(vers, CultureInfo.InvariantCulture);

                    string assemblyVersion = Application.ProductVersion.ToString(CultureInfo.InvariantCulture);
                    assemblyVersion = assemblyVersion.Replace('.', '0');
                    int appVersion = int.Parse(assemblyVersion, CultureInfo.InvariantCulture);

                    appVersion /= 100;
                    fileVersion /= 100;

                    if (fileVersion < appVersion)
                    {
                        var form = new FormTimedMessage(5000, gStr.gsFileError, gStr.gsMustBeVersion + Application.ProductVersion.ToString(CultureInfo.InvariantCulture) + " or higher");
                        form.Show();
                        return false;
                    }

                    else
                    {
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_toolOverlap = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_toolOffset = double.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_toolLookAheadOff = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_toolLookAheadOn = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_toolOffDelay = double.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_minApplied = int.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setTool_toolTrailingHitchLength = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_tankTrailingHitchLength = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_hitchLength = double.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setTool_isToolBehindPivot = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setTool_isToolTrailing = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setTool_isToolTBT = bool.Parse(words[1]);

                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();

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
                        Properties.Vehicle.Default.setSection_position10 = decimal.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setSection_position11 = decimal.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setSection_position12 = decimal.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setSection_position13 = decimal.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setSection_position14 = decimal.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setSection_position15 = decimal.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setSection_position16 = decimal.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setSection_position17 = decimal.Parse(words[1], CultureInfo.InvariantCulture);


                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();

                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();

                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();

                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_numSections = int.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Vehicle.Default.setVehicle_toolWidth = double.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setF_IsWorkSwitchEnabled = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setF_IsWorkSwitchActiveLow = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setF_IsWorkSwitchManual = bool.Parse(words[1]);

                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();

                        //fill in the current variables with restored data
                        toolFileName = Path.GetFileNameWithoutExtension(fileName) + " - ";
                        Properties.Vehicle.Default.setVehicle_toolName = toolFileName;

                        Properties.Settings.Default.Save();
                        Properties.Vehicle.Default.Save();

                        //get the number of sections from settings
                        tool.numOfSections = Properties.Vehicle.Default.setVehicle_numSections;
                        tool.numSuperSection = tool.numOfSections + 1;

                        //from settings grab the vehicle specifics
                        tool.toolOverlap = Properties.Vehicle.Default.setVehicle_toolOverlap;
                        tool.toolOffset = Properties.Vehicle.Default.setVehicle_toolOffset;

                        tool.lookAheadOffSetting = Properties.Vehicle.Default.setVehicle_toolLookAheadOff;
                        tool.lookAheadOnSetting = Properties.Vehicle.Default.setVehicle_toolLookAheadOn;
                        tool.turnOffDelay = Properties.Vehicle.Default.setVehicle_toolOffDelay;

                        tool.toolMinUnappliedPixels = Properties.Vehicle.Default.setVehicle_minApplied;

                        tool.toolTrailingHitchLength = Properties.Vehicle.Default.setTool_toolTrailingHitchLength;
                        tool.toolTankTrailingHitchLength = Properties.Vehicle.Default.setVehicle_tankTrailingHitchLength;
                        tool.hitchLength = Properties.Vehicle.Default.setVehicle_hitchLength;

                        tool.isToolBehindPivot = Properties.Vehicle.Default.setTool_isToolBehindPivot;
                        tool.isToolTrailing = Properties.Vehicle.Default.setTool_isToolTrailing;
                        tool.isToolTBT = Properties.Vehicle.Default.setTool_isToolTBT;

                        mc.isWorkSwitchEnabled = Properties.Settings.Default.setF_IsWorkSwitchEnabled;
                        mc.isWorkSwitchActiveLow = Properties.Settings.Default.setF_IsWorkSwitchActiveLow;
                        mc.isWorkSwitchManual = Properties.Settings.Default.setF_IsWorkSwitchManual;

                        //Set width of section and positions for each section
                        SectionSetPosition();

                        //Calculate total width and each section width
                        SectionCalcWidths();

                        //enable disable manual buttons
                        LineUpManualBtns();

                        return true;
                    }
                }
                catch (Exception e) //FormatException e || IndexOutOfRangeException e2)
                {
                    WriteErrorLog("pen Tool" + e.ToString());

                    //vehicle is corrupt, reload with all default information
                    Properties.Settings.Default.Reset();
                    Properties.Settings.Default.Save();
                    MessageBox.Show(gStr.gsProgramWillResetToRecoverPleaseRestart, gStr.gsFileError, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Restart();
                    Environment.Exit(0);
                    return false;
                }
            }    //cancelled out of open file
        }//end of open file

        //function that save vehicle and section settings
        public void FileSaveEnvironment(string FileName)
        {
                envFileName = Path.GetFileNameWithoutExtension(FileName);
                Properties.Vehicle.Default.setVehicle_envName = envFileName;
                Properties.Vehicle.Default.Save();

            using (StreamWriter writer = new StreamWriter(FileName))
            {
                writer.WriteLine("Version," + Application.ProductVersion.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("Culture," + Properties.Settings.Default.setF_culture.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("CamPitch," + Properties.Settings.Default.setDisplay_camPitch.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsBatmanOn," + Properties.Settings.Default.setDisplay_isBatmanOn.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("LightBarCMPerPixel," + Properties.Settings.Default.setDisplay_lightbarCmPerPixel.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("LineWidth," + Properties.Settings.Default.setDisplay_lineWidth.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("IsCompassOn," + Properties.Settings.Default.setMenu_isCompassOn.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsGridOn," + Properties.Settings.Default.setMenu_isGridOn.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsLightBarOn," + Properties.Settings.Default.setMenu_isLightbarOn.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsLogNMEA," + Properties.Settings.Default.setMenu_isLogNMEA.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsMetric," + Properties.Settings.Default.setMenu_isMetric.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsOGLZoom," + Properties.Settings.Default.setMenu_isOGLZoomOn.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("IsPurePursuitLineOn," + Properties.Settings.Default.setMenu_isPureOn.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsGuideLinesOn," + Properties.Settings.Default.setMenu_isSideGuideLines.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsSimulatorOn," + Properties.Settings.Default.setMenu_isSimulatorOn.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsSkyOn," + Properties.Settings.Default.setMenu_isSkyOn.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsSpeedoOn," + Properties.Settings.Default.setMenu_isSpeedoOn.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsUTurnAlwaysOn," + Properties.Settings.Default.setMenu_isUTurnAlwaysOn.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsAutoDayNightModeOn," + Properties.Settings.Default.setDisplay_isAutoDayNight.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("StartFullScreen," + Properties.Settings.Default.setDisplay_isStartFullScreen.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsRTKOn," + Properties.Settings.Default.setGPS_isRTK.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("NMEA_Hz," + Properties.Settings.Default.setPort_NMEAHz.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");

                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");

                writer.WriteLine("IsNtripCasterIP," + Properties.Settings.Default.setNTRIP_casterIP.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsNtripCasterPort," + Properties.Settings.Default.setNTRIP_casterPort.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsNtripCasterURL," + Properties.Settings.Default.setNTRIP_casterURL.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsNtripGGAManual," + Properties.Settings.Default.setNTRIP_isGGAManual.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsNtripOn," + Properties.Settings.Default.setNTRIP_isOn.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsNtripTCP," + Properties.Settings.Default.setNTRIP_isTCP.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsNtripManualLat," + Properties.Settings.Default.setNTRIP_manualLat.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsNtripManualLon," + Properties.Settings.Default.setNTRIP_manualLon.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsNtripMount," + Properties.Settings.Default.setNTRIP_mount.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsNtripGGAInterval," + Properties.Settings.Default.setNTRIP_sendGGAInterval.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsNtripSendToUDPPort," + Properties.Settings.Default.setNTRIP_sendToUDPPort.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsNtripUserName," + Properties.Settings.Default.setNTRIP_userName.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsNtripUserPassword," + Properties.Settings.Default.setNTRIP_userPassword.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("IsUDPOn," + Properties.Settings.Default.setUDP_isOn.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("GPSSimLatitude," + Properties.Settings.Default.setGPS_SimLatitude.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("GPSSimLongitude" + "," + Properties.Settings.Default.setGPS_SimLongitude.ToString(CultureInfo.InvariantCulture));


                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");


                writer.WriteLine("FieldColorDay," + Properties.Settings.Default.setDisplay_colorFieldDay.ToArgb().ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("SectionColorDay," + Properties.Settings.Default.setDisplay_colorSectionsDay.ToArgb().ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("FieldColorNight," + Properties.Settings.Default.setDisplay_colorFieldNight.ToArgb().ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("SectionColorNight," + Properties.Settings.Default.setDisplay_colorSectionsNight.ToArgb().ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("DayColor," + Properties.Settings.Default.setDisplay_colorDayMode.ToArgb().ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("NightColor," + Properties.Settings.Default.setDisplay_colorNightMode.ToArgb().ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsSimple," + Properties.Settings.Default.setDisplay_isSimple.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("IsDayMode," + Properties.Settings.Default.setDisplay_isDayMode.ToString(CultureInfo.InvariantCulture));
                writer.WriteLine("CustomColors," + Properties.Settings.Default.setDisplay_customColors.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
                writer.WriteLine("Empty," + "10");
            }

                //little show to say saved and where
                var form = new FormTimedMessage(3000, gStr.gsSavedInFolder, envDirectory);
                form.Show();
            
        }

        //function to open a previously saved field
        public DialogResult FileOpenEnvironment(string fileName)
        {
            //make sure the file if fully valid and vehicle matches sections
            using (StreamReader reader = new StreamReader(fileName))
            {
                try
                {
                    string line;
                    Properties.Vehicle.Default.setVehicle_envName = fileName;
                    string[] words;
                    line = reader.ReadLine(); words = line.Split(',');


                    string vers = words[1].Replace('.', '0');
                    int fileVersion = int.Parse(vers, CultureInfo.InvariantCulture);

                    string assemblyVersion = Application.ProductVersion.ToString(CultureInfo.InvariantCulture);
                    assemblyVersion = assemblyVersion.Replace('.', '0');
                    int appVersion = int.Parse(assemblyVersion, CultureInfo.InvariantCulture);

                    appVersion /= 100;
                    fileVersion /= 100;

                    if (fileVersion < appVersion)
                    {
                        var form = new FormTimedMessage(5000, gStr.gsFileError, gStr.gsMustBeVersion + Application.ProductVersion.ToString(CultureInfo.InvariantCulture) + " or higher");
                        form.Show();
                        return DialogResult.Abort;
                    }

                    else
                    {
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setF_culture = (words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setDisplay_camPitch = double.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setDisplay_isBatmanOn = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setDisplay_lightbarCmPerPixel = int.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setDisplay_lineWidth = int.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setMenu_isCompassOn = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setMenu_isGridOn = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setMenu_isLightbarOn = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setMenu_isLogNMEA = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setMenu_isMetric = bool.Parse(words[1]);

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setMenu_isOGLZoomOn = int.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setMenu_isPureOn = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setMenu_isSideGuideLines = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setMenu_isSimulatorOn = bool.Parse(words[1]);

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setMenu_isSkyOn = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setMenu_isSpeedoOn = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setMenu_isUTurnAlwaysOn = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setDisplay_isAutoDayNight = bool.Parse(words[1]);

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setDisplay_isStartFullScreen = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setGPS_isRTK = bool.Parse(words[1]);

                        line = reader.ReadLine(); words = line.Split(',');
                        //if (words[0] == "Empty") Properties.Settings.Default.setPort_NMEAHz = 5;
                        Properties.Settings.Default.setPort_NMEAHz = int.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setNTRIP_casterIP = words[1];
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setNTRIP_casterPort = int.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setNTRIP_casterURL = words[1];

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setNTRIP_isGGAManual = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setNTRIP_isOn = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setNTRIP_isTCP = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setNTRIP_manualLat = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setNTRIP_manualLon = double.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setNTRIP_mount = (words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setNTRIP_sendGGAInterval = int.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setNTRIP_sendToUDPPort = int.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setNTRIP_userName = (words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setNTRIP_userPassword = (words[1]);

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setUDP_isOn = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setGPS_SimLatitude = double.Parse(words[1], CultureInfo.InvariantCulture);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setGPS_SimLongitude = double.Parse(words[1], CultureInfo.InvariantCulture);

                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setDisplay_colorFieldDay = Color.FromArgb(int.Parse(words[1], CultureInfo.InvariantCulture));
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setDisplay_colorSectionsDay = Color.FromArgb(int.Parse(words[1], CultureInfo.InvariantCulture));
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setDisplay_colorFieldNight = Color.FromArgb(int.Parse(words[1], CultureInfo.InvariantCulture));
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setDisplay_colorSectionsNight = Color.FromArgb(int.Parse(words[1], CultureInfo.InvariantCulture));
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setDisplay_colorDayMode = Color.FromArgb(int.Parse(words[1], CultureInfo.InvariantCulture));
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setDisplay_colorNightMode = Color.FromArgb(int.Parse(words[1], CultureInfo.InvariantCulture));

                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setDisplay_isSimple = bool.Parse(words[1]);
                        line = reader.ReadLine(); words = line.Split(',');
                        Properties.Settings.Default.setDisplay_isDayMode = bool.Parse(words[1]);

                        line = reader.ReadLine();
                        Properties.Settings.Default.setDisplay_customColors = line.Substring(13);

                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();

                        //fill in the current variables with restored data
                        envFileName = Path.GetFileNameWithoutExtension(fileName);
                        Properties.Vehicle.Default.setVehicle_envName = envFileName;

                        Properties.Settings.Default.Save();
                        Properties.Vehicle.Default.Save();
                    }

                    return DialogResult.OK;
                }
                catch (Exception e) //FormatException e || IndexOutOfRangeException e2)
                {
                    WriteErrorLog("Open Vehicle" + e.ToString());

                    //vehicle is corrupt, reload with all default information
                    Properties.Settings.Default.Reset();
                    Properties.Settings.Default.Save();
                    MessageBox.Show(gStr.gsProgramWillResetToRecoverPleaseRestart, gStr.gsLoadEnvironment, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Restart();
                    Environment.Exit(0);
                    return DialogResult.Cancel;
                }
            }
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

                    //create a new grid
                    worldGrid.CreateWorldGrid(pn.fix.northing, pn.fix.easting);

                    //convergence angle update
                    if (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                    }

                    //start positions
                    if (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        offs = line.Split(',');

                        pn.latStart = double.Parse(offs[0], CultureInfo.InvariantCulture);
                        pn.lonStart = double.Parse(offs[1], CultureInfo.InvariantCulture);

                        pn.SetLocalMetersPerDegree();
                    }
                }

                catch (Exception e)
                {
                    WriteErrorLog("While Opening Field" + e.ToString());

                    var form = new FormTimedMessage(2000, gStr.gsFieldFileIsCorrupt, gStr.gsChooseADifferentField);

                    form.Show();
                    JobClose();
                    return;
                }
            }

            // ABLine -------------------------------------------------------------------------------------------------
            FileLoadABLines();

            if (ABLine.lineArr.Count > 0)
            {
                ABLine.numABLineSelected = 1;
                ABLine.refPoint1 = ABLine.lineArr[ABLine.numABLineSelected - 1].origin;
                //ABLine.refPoint2 = ABLine.lineArr[ABLine.numABLineSelected - 1].ref2;
                ABLine.abHeading = ABLine.lineArr[ABLine.numABLineSelected - 1].heading;
                ABLine.SetABLineByHeading();
                ABLine.isABLineSet = false;
                ABLine.isABLineLoaded = true;
            }
            else
            {
                ABLine.isABLineSet = false;
                ABLine.isABLineLoaded = false;
            }


            //CurveLines
            FileLoadCurveLines();
            if (curve.curveArr.Count > 0)
            {
                curve.numCurveLineSelected = 1;
                int idx = curve.numCurveLineSelected - 1;
                curve.aveLineHeading = curve.curveArr[idx].aveHeading;

                curve.refList?.Clear();
                for (int i = 0; i < curve.curveArr[idx].curvePts.Count; i++)
                {
                    curve.refList.Add(curve.curveArr[idx].curvePts[i]);
                }
                curve.isCurveSet = true;
            }
            else
            {
                curve.isCurveSet = false;
                curve.refList?.Clear();
            }
            
            //section patches
            fileAndDirectory = fieldsDirectory + currentFieldDirectory + "\\Sections.txt";
            if (!File.Exists(fileAndDirectory))
            {
                var form = new FormTimedMessage(2000, gStr.gsMissingSectionFile, gStr.gsButFieldIsLoaded);
                form.Show();
                //return;
            }
            else
            {
                bool isv3 = false;
                using (StreamReader reader = new StreamReader(fileAndDirectory))
                {
                    try
                    {
                        fd.workedAreaTotal = 0;
                        fd.distanceUser = 0;
                        vec3 vecFix = new vec3();

                        //read header
                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();
                            if (line.Contains("ect"))
                            {
                                isv3 = true;
                                break;
                            }
                            int verts = int.Parse(line);

                            section[0].triangleList = new List<vec3>();
                            section[0].patchList.Add(section[0].triangleList);


                            for (int v = 0; v < verts; v++)
                            {
                                line = reader.ReadLine();
                                string[] words = line.Split(',');
                                vecFix.easting = double.Parse(words[0], CultureInfo.InvariantCulture);
                                vecFix.northing = double.Parse(words[1], CultureInfo.InvariantCulture);
                                vecFix.heading = double.Parse(words[2], CultureInfo.InvariantCulture);
                                section[0].triangleList.Add(vecFix);
                            }

                            //calculate area of this patch - AbsoluteValue of (Ax(By-Cy) + Bx(Cy-Ay) + Cx(Ay-By)/2)
                            verts -= 2;
                            if (verts >= 2)
                            {
                                for (int j = 1; j < verts; j++)
                                {
                                    double temp = 0;
                                    temp = section[0].triangleList[j].easting * (section[0].triangleList[j + 1].northing - section[0].triangleList[j + 2].northing) +
                                              section[0].triangleList[j + 1].easting * (section[0].triangleList[j + 2].northing - section[0].triangleList[j].northing) +
                                                  section[0].triangleList[j + 2].easting * (section[0].triangleList[j].northing - section[0].triangleList[j + 1].northing);

                                    fd.workedAreaTotal += Math.Abs((temp * 0.5));
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        WriteErrorLog("Section file" + e.ToString());

                        var form = new FormTimedMessage(2000, gStr.gsSectionFileIsCorrupt, gStr.gsButFieldIsLoaded);
                        form.Show();
                    }

                }

                //was old version prior to v4
                if (isv3)
                {
                        //Append the current list to the field file
                        using (StreamWriter writer = new StreamWriter((fieldsDirectory + currentFieldDirectory + "\\Sections.txt"), false))
                        {
                        }
                }
            }

            // Contour points ----------------------------------------------------------------------------

            fileAndDirectory = fieldsDirectory + currentFieldDirectory + "\\Contour.txt";
            if (!File.Exists(fileAndDirectory))
            {
                var form = new FormTimedMessage(2000, gStr.gsMissingContourFile, gStr.gsButFieldIsLoaded);
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

                            vec3 vecFix = new vec3(0, 0, 0);

                            ct.ptList = new List<vec3>();
                            ct.stripList.Add(ct.ptList);

                            for (int v = 0; v < verts; v++)
                            {
                                line = reader.ReadLine();
                                string[] words = line.Split(',');
                                vecFix.easting = double.Parse(words[0], CultureInfo.InvariantCulture);
                                vecFix.northing = double.Parse(words[1], CultureInfo.InvariantCulture);
                                vecFix.heading = double.Parse(words[2], CultureInfo.InvariantCulture);
                                ct.ptList.Add(vecFix);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        WriteErrorLog("Loading Contour file" + e.ToString());

                        var form = new FormTimedMessage(2000, gStr.gsContourFileIsCorrupt, gStr.gsButFieldIsLoaded);
                        form.Show();
                    }
                }
            }


            // Flags -------------------------------------------------------------------------------------------------

            //Either exit or update running save
            fileAndDirectory = fieldsDirectory + currentFieldDirectory + "\\Flags.txt";
            if (!File.Exists(fileAndDirectory))
            {
                var form = new FormTimedMessage(2000, gStr.gsMissingFlagsFile, gStr.gsButFieldIsLoaded);
                form.Show();
            }

            else
            {
                flagPts?.Clear();
                using (StreamReader reader = new StreamReader(fileAndDirectory))
                {
                    try
                    {
                        //read header
                        line = reader.ReadLine();

                        //number of flags
                        line = reader.ReadLine();
                        int points = int.Parse(line);

                        if (points > 0)
                        {
                            double lat;
                            double longi;
                            double east;
                            double nort;
                            double head;
                            int color, ID;
                            string notes;

                            for (int v = 0; v < points; v++)
                            {
                                line = reader.ReadLine();
                                string[] words = line.Split(',');

                                if (words.Length == 8)
                                {
                                    lat = double.Parse(words[0], CultureInfo.InvariantCulture);
                                    longi = double.Parse(words[1], CultureInfo.InvariantCulture);
                                    east = double.Parse(words[2], CultureInfo.InvariantCulture);
                                    nort = double.Parse(words[3], CultureInfo.InvariantCulture);
                                    head = double.Parse(words[4], CultureInfo.InvariantCulture);
                                    color = int.Parse(words[5]);
                                    ID = int.Parse(words[6]);
                                    notes = words[7].Trim();
                                }
                                else
                                {
                                    lat = double.Parse(words[0], CultureInfo.InvariantCulture);
                                    longi = double.Parse(words[1], CultureInfo.InvariantCulture);
                                    east = double.Parse(words[2], CultureInfo.InvariantCulture);
                                    nort = double.Parse(words[3], CultureInfo.InvariantCulture);
                                    head = 0;
                                    color = int.Parse(words[4]);
                                    ID = int.Parse(words[5]);
                                    notes = "";
                                }

                                CFlag flagPt = new CFlag(lat, longi, east, nort, head, color, ID, notes);
                                flagPts.Add(flagPt);
                            }
                        }
                    }

                    catch (Exception e)
                    {
                        var form = new FormTimedMessage(2000, gStr.gsFlagFileIsCorrupt, gStr.gsButFieldIsLoaded);
                        form.Show();
                        WriteErrorLog("FieldOpen, Loading Flags, Corrupt Flag File" + e.ToString());
                    }
                }
            }

            //Boundaries
            //Either exit or update running save
                fileAndDirectory = fieldsDirectory + currentFieldDirectory + "\\Boundary.txt";
            if (!File.Exists(fileAndDirectory))
            {
                var form = new FormTimedMessage(2000, gStr.gsMissingBoundaryFile, gStr.gsButFieldIsLoaded);
                form.Show();
            }
            else
            {
                using (StreamReader reader = new StreamReader(fileAndDirectory))
                {
                    try
                    {

                        //read header
                        line = reader.ReadLine();//Boundary

                        for (int k = 0; true; k++)
                        {
                            if (reader.EndOfStream) break;

                            bnd.bndArr.Add(new CBoundaryLines());
                            turn.turnArr.Add(new CTurnLines());

                            //True or False OR points from older boundary files
                            line = reader.ReadLine();

                            //Check for older boundary files, then above line string is num of points
                            if (line == "True" || line == "False")
                            {
                                bnd.bndArr[k].isDriveThru = bool.Parse(line);
                                line = reader.ReadLine(); //number of points
                            }

                            //Check for latest boundary files, then above line string is num of points
                            if (line == "True" || line == "False")
                            {
                                bnd.bndArr[k].isDriveAround = bool.Parse(line);
                                line = reader.ReadLine(); //number of points
                            }

                            int numPoints = int.Parse(line);

                            if (numPoints > 0)
                            {
                                //load the line
                                for (int i = 0; i < numPoints; i++)
                                {
                                    line = reader.ReadLine();
                                    string[] words = line.Split(',');
                                    vec3 vecPt = new vec3(
                                    double.Parse(words[0], CultureInfo.InvariantCulture),
                                    double.Parse(words[1], CultureInfo.InvariantCulture),
                                    double.Parse(words[2], CultureInfo.InvariantCulture));

                                    //if (turnheading)
                                    //{
                                    //    vecPt.heading = vecPt.heading + Math.PI;
                                    //}
                                    bnd.bndArr[k].bndLine.Add(vecPt);
                                }

                                bnd.bndArr[k].CalculateBoundaryArea();
                                bnd.bndArr[k].PreCalcBoundaryLines();
                                if (bnd.bndArr[k].area > 0) bnd.bndArr[k].isSet = true;
                                else bnd.bndArr[k].isSet = false;

                                double delta = 0;
                                bnd.bndArr[k].bndLineEar?.Clear();

                                for (int i = 0; i < bnd.bndArr[k].bndLine.Count; i++)
                                {
                                    if (i == 0)
                                    {
                                        bnd.bndArr[k].bndLineEar.Add(new vec2(bnd.bndArr[k].bndLine[i].easting, bnd.bndArr[k].bndLine[i].northing));
                                        continue;
                                    }
                                    delta += (bnd.bndArr[k].bndLine[i - 1].heading - bnd.bndArr[k].bndLine[i].heading);
                                    if (Math.Abs(delta) > 0.04)
                                    {
                                        bnd.bndArr[k].bndLineEar.Add(new vec2(bnd.bndArr[k].bndLine[i].easting, bnd.bndArr[k].bndLine[i].northing));
                                        delta = 0;
                                    }
                                }

                                bnd.bndArr[k].PreCalcBoundaryEarLines();

                            }
                            else
                            {
                                bnd.bndArr.RemoveAt(bnd.bndArr.Count - 1);
                                turn.turnArr.RemoveAt(bnd.bndArr.Count - 1);
                                k = k - 1;
                            }
                            if (reader.EndOfStream) break;
                        }

                        CalculateMinMax();
                        turn.BuildTurnLines();
                    }

                    catch (Exception e)
                    {
                        var form = new FormTimedMessage(2000, gStr.gsBoundaryLineFilesAreCorrupt, gStr.gsButFieldIsLoaded);
                        form.Show();
                        WriteErrorLog("Load Boundary Line" + e.ToString());
                    }


                }
            }

            // Headland  -------------------------------------------------------------------------------------------------
            fileAndDirectory = fieldsDirectory + currentFieldDirectory + "\\Headland.txt";

            if (File.Exists(fileAndDirectory))
            {
                using (StreamReader reader = new StreamReader(fileAndDirectory))
                {
                    try
                    {
                        //read header
                        line = reader.ReadLine();

                        for (int k = 0; true; k++)
                        {
                            if (reader.EndOfStream) break;

                            hd.headArr[0].hdLine.Clear();

                            //read the number of points
                            line = reader.ReadLine();
                            int numPoints = int.Parse(line);

                            if (numPoints > 0 && bnd.bndArr.Count >= hd.headArr.Count)
                            {

                                hd.headArr[k].hdLine.Clear();
                                hd.headArr[k].calcList.Clear();

                                //load the line
                                for (int i = 0; i < numPoints; i++)
                                {
                                    line = reader.ReadLine();
                                    string[] words = line.Split(',');
                                    vec3 vecPt = new vec3(
                                        double.Parse(words[0], CultureInfo.InvariantCulture),
                                        double.Parse(words[1], CultureInfo.InvariantCulture),
                                        double.Parse(words[2], CultureInfo.InvariantCulture));
                                    hd.headArr[k].hdLine.Add(vecPt);

                                    if (bnd.bndArr[0].IsPointInsideBoundary(vecPt)) hd.headArr[0].isDrawList.Add(true);
                                    else hd.headArr[0].isDrawList.Add(false);
                                }
                                hd.headArr[k].PreCalcHeadLines();
                            }
                        }
                    }

                    catch (Exception e)
                    {
                        var form = new FormTimedMessage(2000, "Headland File is Corrupt", "But Field is Loaded");
                        form.Show();
                        WriteErrorLog("Load Headland Loop" + e.ToString());
                    }
                }
            }

            //if (hd.headArr[0].hdLine.Count > 0) hd.isOn = true;
             hd.isOn = false;

            //if (hd.isOn) btnHeadlandOnOff.Image = Properties.Resources.HeadlandOn;
            btnHeadlandOnOff.Image = Properties.Resources.HeadlandOff;

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
                using (var form = new FormTimedMessage(3000, gStr.gsFieldNotOpen, gStr.gsCreateNewField))
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
                writer.WriteLine("0,0");

                writer.WriteLine("Convergence");
                writer.WriteLine("0");

                writer.WriteLine("StartFix");
                writer.WriteLine(pn.latitude.ToString(CultureInfo.InvariantCulture) + "," + pn.longitude.ToString(CultureInfo.InvariantCulture));
            }
        }

        public void FileCreateElevation()
        {
            //Saturday, February 11, 2017  -->  7:26:52 AM
            //$FieldDir
            //Bob_Feb11
            //$Offsets
            //533172,5927719,12 - offset easting, northing, zone

            //if (!isJobStarted)
            //{
            //    using (var form = new FormTimedMessage(3000, "Ooops, Job Not Started", "Start a Job First"))
            //    { form.Show(); }
            //    return;
            //}

            string myFileName, dirField;

            //get the directory and make sure it exists, create if not
            dirField = fieldsDirectory + currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            myFileName = "Elevation.txt";

            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {
                //Write out the date
                writer.WriteLine(DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss tt", CultureInfo.InvariantCulture));

                writer.WriteLine("$FieldDir");
                writer.WriteLine(currentFieldDirectory.ToString(CultureInfo.InvariantCulture));

                //write out the easting and northing Offsets
                writer.WriteLine("$Offsets");
                writer.WriteLine("0,0");

                writer.WriteLine("Convergence");
                writer.WriteLine("0");

                writer.WriteLine("StartFix");
                writer.WriteLine(pn.latitude.ToString(CultureInfo.InvariantCulture) + "," + pn.longitude.ToString(CultureInfo.InvariantCulture));
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
                            writer.WriteLine((Math.Round(triList[i].easting,3)).ToString(CultureInfo.InvariantCulture) +
                                "," + (Math.Round(triList[i].northing,3)).ToString(CultureInfo.InvariantCulture) +
                                 "," + (Math.Round(triList[i].heading, 3)).ToString(CultureInfo.InvariantCulture));
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
                //writer.WriteLine("$Sectionsv4");
            }
        }

        //Create Flag file
        public void FileCreateFlags()
        {
            //$Sections
            //10 - points in this patch
            //10.1728031317344,0.723157039771303 -easting, northing

            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string myFileName = "Flags.txt";

            //write out the file
            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {
                //write paths # of sections
                //writer.WriteLine("$Sectionsv4");
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
                            writer.WriteLine(Math.Round((triList[i].easting), 3).ToString(CultureInfo.InvariantCulture) + "," +
                                Math.Round(triList[i].northing, 3).ToString(CultureInfo.InvariantCulture)+ "," +
                                Math.Round(triList[i].heading, 3).ToString(CultureInfo.InvariantCulture));
                        }
                    }
                }

                contourSaveList.Clear();

            }
        }

        //save the boundary
        public void FileSaveBoundary()
        {
            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            //write out the file
            using (StreamWriter writer = new StreamWriter(dirField + "Boundary.Txt"))
            {
                writer.WriteLine("$Boundary");
                for (int i = 0; i < bnd.bndArr.Count; i++)
                {
                    writer.WriteLine(bnd.bndArr[i].isDriveThru);
                    writer.WriteLine(bnd.bndArr[i].isDriveAround);
                    //writer.WriteLine(bnd.bndArr[i].isOwnField);

                    writer.WriteLine(bnd.bndArr[i].bndLine.Count.ToString(CultureInfo.InvariantCulture));
                    if (bnd.bndArr[i].bndLine.Count > 0)
                    {
                        for (int j = 0; j < bnd.bndArr[i].bndLine.Count; j++)
                            writer.WriteLine(Math.Round(bnd.bndArr[i].bndLine[j].easting,3).ToString(CultureInfo.InvariantCulture) + "," +
                                                Math.Round(bnd.bndArr[i].bndLine[j].northing, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                                    Math.Round(bnd.bndArr[i].bndLine[j].heading,5).ToString(CultureInfo.InvariantCulture));
                    }
                }
            }
        }

        //save the headland
        public void FileSaveHeadland()
        {
            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            //write out the file
            using (StreamWriter writer = new StreamWriter(dirField + "Headland.Txt"))
            {
                writer.WriteLine("$Headland");

                if (hd.headArr[0].hdLine.Count > 0)
                {
                    for (int i = 0; i < hd.headArr.Count; i++)
                    {
                        writer.WriteLine(hd.headArr[i].hdLine.Count.ToString(CultureInfo.InvariantCulture));
                        if (hd.headArr[0].hdLine.Count > 0)
                        {
                            for (int j = 0; j < hd.headArr[i].hdLine.Count; j++)
                                writer.WriteLine(Math.Round(hd.headArr[i].hdLine[j].easting, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                                 Math.Round(hd.headArr[i].hdLine[j].northing, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                                 Math.Round(hd.headArr[i].hdLine[j].heading, 3).ToString(CultureInfo.InvariantCulture));
                        }
                    }
                }
            }
        }

        //Create contour file
        public void FileCreateRecPath()
        {
            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string myFileName = "RecPath.txt";

            //write out the file
            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {
                //write paths # of sections
                writer.WriteLine("$RecPath");
                writer.WriteLine("0");
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
                            flagPts[i].heading.ToString(CultureInfo.InvariantCulture) + "," +
                            flagPts[i].color.ToString(CultureInfo.InvariantCulture) + "," +
                            flagPts[i].ID.ToString(CultureInfo.InvariantCulture) + "," +
                            flagPts[i].notes);
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
        //public void FileSaveABLine()
        //{
        //    //Saturday, February 11, 2017  -->  7:26:52 AM

        //    //get the directory and make sure it exists, create if not
        //    string dirField = fieldsDirectory + currentFieldDirectory + "\\";

        //    string directoryName = Path.GetDirectoryName(dirField);
        //    if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
        //    { Directory.CreateDirectory(directoryName); }

        //    //use Streamwriter to create and overwrite existing ABLine file
        //    using (StreamWriter writer = new StreamWriter(dirField + "ABLine.txt"))
        //    {
        //        try
        //        {
        //            //write out the ABLine
        //            writer.WriteLine("$ABLine");

        //            //true or false if ABLine is set
        //            if (ABLine.isABLineSet) writer.WriteLine(true);
        //            else writer.WriteLine(false);

        //            writer.WriteLine(ABLine.abHeading.ToString(CultureInfo.InvariantCulture));
        //            writer.WriteLine(ABLine.refPoint1.easting.ToString(CultureInfo.InvariantCulture) + "," + ABLine.refPoint1.northing.ToString(CultureInfo.InvariantCulture));
        //            writer.WriteLine(ABLine.refPoint2.easting.ToString(CultureInfo.InvariantCulture) + "," + ABLine.refPoint2.northing.ToString(CultureInfo.InvariantCulture));
        //            writer.WriteLine(ABLine.tramPassEvery.ToString(CultureInfo.InvariantCulture) + "," + ABLine.passBasedOn.ToString(CultureInfo.InvariantCulture));
        //        }

        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message + "\n Cannot write to file.");
        //            WriteErrorLog("Saving AB Line" + e.ToString());

        //            return;
        //        }

        //    }
        //}

        //save all the flag markers
        //public void FileSaveCurveLine()
        //{
        //    //Saturday, February 11, 2017  -->  7:26:52 AM

        //    //get the directory and make sure it exists, create if not
        //    string dirField = fieldsDirectory + currentFieldDirectory + "\\";

        //    string directoryName = Path.GetDirectoryName(dirField);
        //    if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
        //    { Directory.CreateDirectory(directoryName); }

        //    //use Streamwriter to create and overwrite existing ABLine file
        //    using (StreamWriter writer = new StreamWriter(dirField + "CurveLine.txt"))
        //    {
        //        try
        //        {
        //            //write out the ABLine
        //            writer.WriteLine("$CurveLine");

        //            //write out the aveheading
        //            writer.WriteLine(curve.aveLineHeading.ToString(CultureInfo.InvariantCulture));

        //            //write out the points of ref line
        //            writer.WriteLine(curve.refList.Count.ToString(CultureInfo.InvariantCulture));
        //            if (curve.refList.Count > 0)
        //            {
        //                for (int j = 0; j < curve.refList.Count; j++)
        //                    writer.WriteLine(Math.Round(curve.refList[j].easting, 3).ToString(CultureInfo.InvariantCulture) + "," +
        //                                        Math.Round(curve.refList[j].northing, 3).ToString(CultureInfo.InvariantCulture) + "," +
        //                                            Math.Round(curve.refList[j].heading, 5).ToString(CultureInfo.InvariantCulture));
        //            }
        //        }

        //        catch (Exception e)
        //        {
        //            WriteErrorLog("Saving Curve Line" + e.ToString());

        //            return;
        //        }

        //    }
        //}

        //save nmea sentences
        public void FileSaveNMEA()
        {
            using (StreamWriter writer = new StreamWriter((fieldsDirectory + "\\NMEA_log.txt"), true))
            {
                writer.Write(pn.logNMEASentence.ToString());
            }
            pn.logNMEASentence.Clear();
        }

        //save nmea sentences
        public void FileSaveElevation()
        {
            using (StreamWriter writer = new StreamWriter((fieldsDirectory + currentFieldDirectory + "\\Elevation.txt"), true))
            {
                writer.Write(sbFix.ToString());
            }
            sbFix.Clear();
        }

        //generate KML file from flag
        public void FileSaveSingleFlagKML2(int flagNumber)
        {
            double lat = 0;
            double lon = 0;

            pn.ConvertLocalToWGS84(flagPts[flagNumber - 1].northing, flagPts[flagNumber - 1].easting, out lat, out lon);

            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string myFileName;
            myFileName = "Flag.kml";

            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {
                //match new fix to current position


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
                                lon.ToString(CultureInfo.InvariantCulture) + "," + lat.ToString(CultureInfo.InvariantCulture) + ",0" +
                                @"</coordinates> </Point> ");
                writer.WriteLine(@"  </Placemark>                                 ");
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
                //match new fix to current position

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
        public void FileMakeKMLFromCurrentPosition(double lat, double lon)
        {
            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }


            using (StreamWriter writer = new StreamWriter(dirField + "CurrentPosition.kml"))
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

        //generate KML file from flags
        public void FileSaveFieldKML()
        {
            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string myFileName;
            myFileName = "Field.kml";

            XmlTextWriter kml = new XmlTextWriter(dirField + myFileName, Encoding.UTF8);

            kml.Formatting = Formatting.Indented;
            kml.Indentation = 3;

            kml.WriteStartDocument();
            kml.WriteStartElement("kml", "http://www.opengis.net/kml/2.2");
            kml.WriteStartElement("Document");

            //guidance lines AB
            kml.WriteStartElement("Folder");
            kml.WriteElementString("name", "AB_Lines");
            kml.WriteElementString("visibility", "0");

            string linePts = "";

            for (int i = 0; i < ABLine.lineArr.Count; i++)
            {
                kml.WriteStartElement("Placemark");
                kml.WriteElementString("visibility", "0");

                kml.WriteElementString("name", ABLine.lineArr[i].Name);
                kml.WriteStartElement("Style");

                kml.WriteStartElement("LineStyle");
                kml.WriteElementString("color", "ff0000ff");
                kml.WriteElementString("width", "2");
                kml.WriteEndElement(); // <LineStyle>
                kml.WriteEndElement(); //Style

                kml.WriteStartElement("LineString");
                kml.WriteElementString("tessellate", "1");
                kml.WriteStartElement("coordinates");

                //linePts = GetUTMToLatLon(ABLine.lineArr[i].ref1.easting, ABLine.lineArr[i].ref1.northing);
                //linePts += GetUTMToLatLon(ABLine.lineArr[i].ref2.easting, ABLine.lineArr[i].ref2.northing);
                kml.WriteRaw(linePts);

                kml.WriteEndElement(); // <coordinates>
                kml.WriteEndElement(); // <LineString>

                kml.WriteEndElement(); // <Placemark>

            }
            kml.WriteEndElement(); // <Folder>   

            //guidance lines Curve
            kml.WriteStartElement("Folder");
            kml.WriteElementString("name", "Curve_Lines");
            kml.WriteElementString("visibility", "0");

            for (int i = 0; i < curve.curveArr.Count; i++)
            {
                linePts = "";
                kml.WriteStartElement("Placemark");
                kml.WriteElementString("visibility", "0");

                kml.WriteElementString("name", curve.curveArr[i].Name);
                kml.WriteStartElement("Style");

                kml.WriteStartElement("LineStyle");
                kml.WriteElementString("color", "ff6699ff");
                kml.WriteElementString("width", "2");
                kml.WriteEndElement(); // <LineStyle>
                kml.WriteEndElement(); //Style

                kml.WriteStartElement("LineString");
                kml.WriteElementString("tessellate", "1");
                kml.WriteStartElement("coordinates");

                for (int j = 0; j < curve.curveArr[i].curvePts.Count; j++)
                {
                    linePts += pn.GetLocalToWSG84_KML(curve.curveArr[i].curvePts[j].easting, curve.curveArr[i].curvePts[j].northing);
                }
                kml.WriteRaw(linePts);

                kml.WriteEndElement(); // <coordinates>
                kml.WriteEndElement(); // <LineString>

                kml.WriteEndElement(); // <Placemark>
            }
            kml.WriteEndElement(); // <Folder>   

            //flags  *************************************************************************
            kml.WriteStartElement("Folder");
            kml.WriteElementString("name", "Flags");

            for (int i = 0; i < flagPts.Count; i++)
            {
                kml.WriteStartElement("Placemark");
                kml.WriteElementString("name", "Flag_"+ i.ToString());

                kml.WriteStartElement("Style");
                kml.WriteStartElement("IconStyle");

                if (flagPts[i].color == 0)  //red - xbgr
                    kml.WriteElementString("color", "ff4400ff");
                if (flagPts[i].color == 1)  //grn - xbgr
                    kml.WriteElementString("color", "ff44ff00");
                if (flagPts[i].color == 2)  //yel - xbgr
                    kml.WriteElementString("color", "ff44ffff");

                kml.WriteEndElement(); //IconStyle
                kml.WriteEndElement(); //Style

                kml.WriteElementString("name", (i+1).ToString());
                kml.WriteStartElement("Point");
                kml.WriteElementString("coordinates", flagPts[i].longitude.ToString(CultureInfo.InvariantCulture) +
                    "," + flagPts[i].latitude.ToString(CultureInfo.InvariantCulture) + ",0");
                kml.WriteEndElement(); //Point
                kml.WriteEndElement(); // <Placemark>
            }
            kml.WriteEndElement(); // <Folder>   
            //End of Flags

                //Boundary  ----------------------------------------------------------------------
            kml.WriteStartElement("Folder");
            kml.WriteElementString("name", "Boundaries");

            for (int i = 0; i < bnd.bndArr.Count; i++)
            {
                kml.WriteStartElement("Placemark");
                if (i == 0) kml.WriteElementString("name", currentFieldDirectory);

                //lineStyle
                kml.WriteStartElement("Style");
                kml.WriteStartElement("LineStyle");
                if (i == 0) kml.WriteElementString("color", "ffdd00dd");
                else kml.WriteElementString("color", "ff4d3ffd");
                kml.WriteElementString("width", "4");
                kml.WriteEndElement(); // <LineStyle>

                kml.WriteStartElement("PolyStyle");
                if (i == 0)   kml.WriteElementString("color", "407f3f55");
                else kml.WriteElementString("color", "703f38f1");
                kml.WriteEndElement(); // <PloyStyle>
                kml.WriteEndElement(); //Style

                kml.WriteStartElement("Polygon");
                kml.WriteElementString("tessellate", "1");
                kml.WriteStartElement("outerBoundaryIs");
                kml.WriteStartElement("LinearRing");

                //coords
                kml.WriteStartElement("coordinates");
                string bndPts = "";
                if (bnd.bndArr[i].bndLine.Count > 3)
                    bndPts = GetBoundaryPointsLatLon(i);
                kml.WriteRaw(bndPts);
                kml.WriteEndElement(); // <coordinates>

                kml.WriteEndElement(); // <Linear>
                kml.WriteEndElement(); // <OuterBoundary>
                kml.WriteEndElement(); // <Polygon>
                kml.WriteEndElement(); // <Placemark>
            }

            kml.WriteEndElement(); // <Folder>  
            //End of Boundary

            //Sections  ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
            kml.WriteStartElement("Folder");
            kml.WriteElementString("name", "Sections");

            string secPts = "";
            int cntr = 0;

            for (int j = 0; j < tool.numSuperSection; j++)
            {
                int patches = section[j].patchList.Count;

                if (patches > 0)
                {
                    //for every new chunk of patch
                    foreach (var triList in section[j].patchList)
                    {
                        if (triList.Count > 0)
                        {
                            kml.WriteStartElement("Placemark");
                            kml.WriteElementString("name", "Sections_" + cntr.ToString());
                            cntr++;

                            string collor = "F0" + ((byte)(triList[0].heading)).ToString("X2") +
                                ((byte)(triList[0].northing)).ToString("X2") + ((byte)(triList[0].easting)).ToString("X2");

                            //lineStyle
                            kml.WriteStartElement("Style");

                            kml.WriteStartElement("LineStyle");
                            kml.WriteElementString("color", collor);
                            //kml.WriteElementString("width", "6");
                            kml.WriteEndElement(); // <LineStyle>
                            
                            kml.WriteStartElement("PolyStyle");
                            kml.WriteElementString("color", collor);
                            kml.WriteEndElement(); // <PloyStyle>
                            kml.WriteEndElement(); //Style

                            kml.WriteStartElement("Polygon");
                            kml.WriteElementString("tessellate", "1");
                            kml.WriteStartElement("outerBoundaryIs");
                            kml.WriteStartElement("LinearRing");
                            
                            //coords
                            kml.WriteStartElement("coordinates");
                            secPts = "";
                            for (int i = 1; i < triList.Count; i += 2)
                            {
                                secPts += pn.GetLocalToWSG84_KML(triList[i].easting, triList[i].northing);
                            }
                            for (int i = triList.Count - 1; i > 1; i -= 2)
                            {
                                secPts += pn.GetLocalToWSG84_KML(triList[i].easting, triList[i].northing);
                            }
                            secPts += pn.GetLocalToWSG84_KML(triList[1].easting, triList[1].northing);

                            kml.WriteRaw(secPts);
                            kml.WriteEndElement(); // <coordinates>

                            kml.WriteEndElement(); // <LinearRing>
                            kml.WriteEndElement(); // <outerBoundaryIs>
                            kml.WriteEndElement(); // <Polygon>

                            kml.WriteEndElement(); // <Placemark>
                        }
                    }
                }
            }
            kml.WriteEndElement(); // <Folder>
            //End of sections

            //end of document
            kml.WriteEndElement(); // <Document>
            kml.WriteEndElement(); // <kml>

            //The end
            kml.WriteEndDocument();

            kml.Flush();

            //Write the XML to file and close the kml
            kml.Close();
        }


        public string GetBoundaryPointsLatLon(int bndNum)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < bnd.bndArr[bndNum].bndLine.Count; i++)
            {
                double lat = 0;
                double lon = 0;

                pn.ConvertLocalToWGS84(bnd.bndArr[bndNum].bndLine[i].northing, bnd.bndArr[bndNum].bndLine[i].easting, out lat, out lon);

                sb.Append(lon.ToString("N7", CultureInfo.InvariantCulture) + ',' + lat.ToString("N7", CultureInfo.InvariantCulture) + ",0 ");
            }
            return sb.ToString();
        }
    }
}