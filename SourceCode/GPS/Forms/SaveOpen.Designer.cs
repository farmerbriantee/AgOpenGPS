using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace AgOpenGPS
{
    
    public partial class  FormGPS
    {
        public void FileSaveVehicle()
        {
            //in the current application directory
            //string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //string fieldDir = dir + "\\fields\\";

            string dirVehicle = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AgOpenGPS\\Vehicles\\";

            string directoryName = Path.GetDirectoryName(dirVehicle);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Title = "Save Vehicle";
            saveDialog.Filter = "Text Files (*.txt)|*.txt";
            saveDialog.InitialDirectory = directoryName;

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                {
                    writer.Write("Overlap," + Properties.Settings.Default.setVehicle_toolOverlap + ",");
                    writer.Write("ToolTrailingHitchLength," + Properties.Settings.Default.setVehicle_toolTrailingHitchLength + ",");
                    writer.Write("AntennaHeight," + Properties.Settings.Default.setVehicle_antennaHeight + ",");
                    writer.Write("LookAhead," + Properties.Settings.Default.setVehicle_lookAhead + ",");
                    writer.Write("AntennaPivot," + Properties.Settings.Default.setVehicle_antennaPivot + ",");

                    writer.Write("HitchLength," + Properties.Settings.Default.setVehicle_hitchLength + ",");
                    writer.Write("ToolOffset," + Properties.Settings.Default.setVehicle_toolOffset + ",");
                    writer.Write("TurnOffDelay," + Properties.Settings.Default.setVehicle_turnOffDelay + ",");
                    writer.Write("Wheelbase," + Properties.Settings.Default.setVehicle_wheelbase + ",");

                    writer.Write("IsPivotBehindAntenna," + Properties.Settings.Default.setVehicle_isPivotBehindAntenna + ",");
                    writer.Write("IsSteerAxleAhead," + Properties.Settings.Default.setVehicle_isSteerAxleAhead + ","); 
                    writer.Write("IsToolBehindPivot," + Properties.Settings.Default.setVehicle_isToolBehindPivot + ",");
                    writer.Write("IsToolTrailing," + Properties.Settings.Default.setVehicle_isToolTrailing + ",");                   

                    writer.Write("Spinner1," + Properties.Settings.Default.setSection_position1 + ",");
                    writer.Write("Spinner2," + Properties.Settings.Default.setSection_position2 + ",");
                    writer.Write("Spinner3," + Properties.Settings.Default.setSection_position3 + ",");
                    writer.Write("Spinner4," + Properties.Settings.Default.setSection_position4 + ",");
                    writer.Write("Spinner5," + Properties.Settings.Default.setSection_position5 + ",");
                    writer.Write("Spinner6," + Properties.Settings.Default.setSection_position6 + ",");
                    writer.Write("Spinner7," + Properties.Settings.Default.setSection_position7 + ",");
                    writer.Write("Spinner8," + Properties.Settings.Default.setSection_position8 + ",");
                    writer.Write("Spinner9," + Properties.Settings.Default.setSection_position9 + ",");

                    writer.Write("Sections," + Properties.Settings.Default.setVehicle_numSections + ",");
                    writer.Write("ToolWidth," + Properties.Settings.Default.setVehicle_toolWidth + ",");

                    writer.Write("WorkSwitch," + Properties.Settings.Default.setIsWorkSwitchEnabled + ",");                  
                    writer.Write("ActiveLow," + Properties.Settings.Default.setIsWorkSwitchActiveLow + ",");

                    writer.Write("Reserved,0,");
                    writer.Write("Reserved,0,"); writer.Write("Reserved,0,"); writer.Write("Reserved,0,");
                    writer.Write("Reserved,0,"); writer.Write("Reserved,0,"); writer.Write("Reserved,0,");
                    writer.Write("Reserved,0");
                    
                }
                //little show to say saved and where

                var form = new FormTimedMessage(this, 3000, "Saved in Folder: ", dirVehicle);
                form.Show();

                vehiclefileName = Path.GetFileNameWithoutExtension(saveDialog.FileName) + " - "; 
                Properties.Settings.Default.setVehicle_Name = vehiclefileName;
                Properties.Settings.Default.Save();
            }

        }

        //function to open a previously saved field
        public void FileOpenVehicle()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            //get the directory where the fields are stored
            string directoryName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AgOpenGPS\\Vehicles\\";

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
                    string line;
                    //Overlap,0.1,ToolTrailingHitchLength,-2,AntennaHeight,3,LookAhead,2,AntennaPivot,1.1,HitchLength,-0.5,
                    //ToolOffset,0,TurnOffDelay,1,Wheelbase,5,IsPivotBehindAntenna,True,IsSteerAxleAhead,True,IsToolBehindPivot,True,
                    //IsToolTrailing,True,Spinner1,-8,Spinner2,-3,Spinner3,3,Spinner4,8,Spinner5,0,Spinner6,0,Sections,3,ToolWidth,16

                    line = reader.ReadLine(); 
                    string[] words;
                    words = line.Split(',');
                    if (words.Length != 68) { MessageBox.Show("Corrupt Vehicle file"); return; }

                    Properties.Settings.Default.setVehicle_Name = ofd.FileName;

                    Properties.Settings.Default.setVehicle_toolOverlap = double.Parse(words[1]);
                    Properties.Settings.Default.setVehicle_toolTrailingHitchLength = double.Parse(words[3]);
                    Properties.Settings.Default.setVehicle_antennaHeight = double.Parse(words[5]);
                    Properties.Settings.Default.setVehicle_lookAhead = double.Parse(words[7]);
                    Properties.Settings.Default.setVehicle_antennaPivot = double.Parse(words[9]);

                    Properties.Settings.Default.setVehicle_hitchLength = double.Parse(words[11]);
                    Properties.Settings.Default.setVehicle_toolOffset = double.Parse(words[13]);
                    Properties.Settings.Default.setVehicle_turnOffDelay = double.Parse(words[15]);
                    Properties.Settings.Default.setVehicle_wheelbase = double.Parse(words[17]);

                    Properties.Settings.Default.setVehicle_isPivotBehindAntenna = bool.Parse(words[19]);
                    Properties.Settings.Default.setVehicle_isSteerAxleAhead = bool.Parse(words[21]);
                    Properties.Settings.Default.setVehicle_isToolBehindPivot = bool.Parse(words[23]);
                    Properties.Settings.Default.setVehicle_isToolTrailing = bool.Parse(words[25]);

                    Properties.Settings.Default.setSection_position1 = decimal.Parse(words[27]);
                    Properties.Settings.Default.setSection_position2 = decimal.Parse(words[29]);
                    Properties.Settings.Default.setSection_position3 = decimal.Parse(words[31]);
                    Properties.Settings.Default.setSection_position4 = decimal.Parse(words[33]);
                    Properties.Settings.Default.setSection_position5 = decimal.Parse(words[35]);
                    Properties.Settings.Default.setSection_position6 = decimal.Parse(words[37]);
                    Properties.Settings.Default.setSection_position7 = decimal.Parse(words[39]);
                    Properties.Settings.Default.setSection_position8 = decimal.Parse(words[41]);
                    Properties.Settings.Default.setSection_position9 = decimal.Parse(words[43]);

                    Properties.Settings.Default.setVehicle_numSections = int.Parse(words[45]);
                    Properties.Settings.Default.setVehicle_toolWidth = double.Parse(words[47]);

                    Properties.Settings.Default.setIsWorkSwitchEnabled = bool.Parse(words[49]);
                    Properties.Settings.Default.setIsWorkSwitchActiveLow = bool.Parse(words[51]);

                    vehiclefileName = Path.GetFileNameWithoutExtension(ofd.FileName) + " - ";
                    Properties.Settings.Default.setVehicle_Name = vehiclefileName;

                    Properties.Settings.Default.Save();
                    
                    //get the number of sections from settings
                    vehicle.numOfSections = Properties.Settings.Default.setVehicle_numSections;
                    vehicle.numSuperSection = vehicle.numOfSections + 1;

                    //from settings grab the vehicle specifics
                    vehicle.toolOverlap = Properties.Settings.Default.setVehicle_toolOverlap;
                    vehicle.toolTrailingHitchLength = Properties.Settings.Default.setVehicle_toolTrailingHitchLength;
                    vehicle.antennaHeight = Properties.Settings.Default.setVehicle_antennaHeight;
                    vehicle.toolLookAhead = Properties.Settings.Default.setVehicle_lookAhead;

                    vehicle.antennaPivot = Properties.Settings.Default.setVehicle_antennaPivot;
                    vehicle.hitchLength = Properties.Settings.Default.setVehicle_hitchLength; 
                    vehicle.toolOffset = Properties.Settings.Default.setVehicle_toolOffset;
                    vehicle.toolTurnOffDelay = Properties.Settings.Default.setVehicle_turnOffDelay;
                    vehicle.wheelbase = Properties.Settings.Default.setVehicle_wheelbase;

                    vehicle.isToolTrailing = Properties.Settings.Default.setVehicle_isToolTrailing;
                    vehicle.isPivotBehindAntenna = Properties.Settings.Default.setVehicle_isPivotBehindAntenna;
                    vehicle.isSteerAxleAhead = Properties.Settings.Default.setVehicle_isSteerAxleAhead;
                    vehicle.isPivotBehindAntenna = Properties.Settings.Default.setVehicle_isToolBehindPivot;

                    modcom.isWorkSwitchEnabled = Properties.Settings.Default.setIsWorkSwitchEnabled;
                    modcom.isWorkSwitchActiveLow = Properties.Settings.Default.setIsWorkSwitchActiveLow;

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


                    //Application.Exit();

                }

            }
            //cancelled out of open file

        }//end of open file

        //function to open a previously saved field, Contour, Flags
        public void FileOpenField(string _openType)
        {
            string fileAndDirectory;
            //get the directory where the fields are stored
            //string directoryName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+ "\\fields\\";

            if (_openType == "Resume")
            {
                //Either exit or update running save
                fileAndDirectory = workingDirectory + currentFieldDirectory + "\\Field.fld";
                if (!File.Exists(fileAndDirectory)) return;
            }

            //open file dialog instead
            else
            {
                //create the dialog instance
                OpenFileDialog ofd = new OpenFileDialog();

                //the initial directory, fields, for the open dialog
                ofd.InitialDirectory = workingDirectory;

                //When leaving dialog put windows back where it was
                ofd.RestoreDirectory = true;

                //set the filter to text files only
                ofd.Filter = "fld files (*.fld)|*.fld";

                //was a file selected
                if (ofd.ShowDialog() == DialogResult.Cancel) return;
                else fileAndDirectory = ofd.FileName;
            }


            //Friday, February 10, 2017  -->  2:58:24 PM
            //$FieldDir
            //test_2017Feb10_02.55.46.PM
            //$Offsets
            //533210,5927965,12
            //$Heading
            //False
            //0,0.2,0.2,0.3,0.3,0,0
            //$Sections
            //3
            //4
            //76
            //-10.791,-10.964

            //close the existing job and reset everything
            this.JobClose();

            //and open a new job
            this.JobNew();

            using (BinaryReader br = new BinaryReader(new FileStream(fileAndDirectory, FileMode.Open)))
            {
                string s = br.ReadString(); //Date/time

                s = br.ReadString();        //$FieldDir
                if (s.IndexOf("$FieldDir") == -1)
                { MessageBox.Show("Sections header is Corrupt"); JobClose(); return; }


                currentFieldDirectory = br.ReadString(); //read current directory
                currentFieldDirectory = currentFieldDirectory.Trim();

                //Offset header
                s = br.ReadString(); //$Offsets

                //read the Offsets 
                pn.utmEast = br.ReadInt32();
                pn.utmNorth = br.ReadInt32();
                pn.zone = br.ReadDouble();

                worldGrid.CreateWorldGrid(pn.actualNorthing - pn.utmNorth, pn.actualEasting - pn.utmEast);

                //AB Line header
                s = br.ReadString(); //$Heading


                //read the boolean if AB is set
                bool b = br.ReadBoolean();

                //If is true there is AB Line data
                if (b)
                {
                    //set gui image button on
                    btnABLine.Image = global::AgOpenGPS.Properties.Resources.ABLineOn;

                    //Heading, refPoint1x,z,refPoint2x,z                    
                    ABLine.abHeading        = br.ReadDouble();
                    ABLine.refPoint1.x      = br.ReadDouble();
                    ABLine.refPoint1.z      = br.ReadDouble();
                    ABLine.refPoint2.x      = br.ReadDouble();
                    ABLine.refPoint2.z      = br.ReadDouble();
                    ABLine.tramPassEvery    = br.ReadInt32();
                    ABLine.passBasedOn      = br.ReadInt32();

                    ABLine.refABLineP1.x = ABLine.refPoint1.x - Math.Sin(ABLine.abHeading) * 10000.0;
                    ABLine.refABLineP1.z = ABLine.refPoint1.z - Math.Cos(ABLine.abHeading) * 10000.0;

                    ABLine.refABLineP2.x = ABLine.refPoint1.x + Math.Sin(ABLine.abHeading) * 10000.0;
                    ABLine.refABLineP2.z = ABLine.refPoint1.z + Math.Cos(ABLine.abHeading) * 10000.0;

                    ABLine.isABLineSet = true;
                }
                  
                //false so just read and skip the heading line, reset btn image
                else 
                {
                    btnABLine.Image = global::AgOpenGPS.Properties.Resources.ABLineOff;
                    
                    br.ReadDouble();
                    br.ReadDouble();
                    br.ReadDouble();
                    br.ReadDouble();
                    br.ReadDouble();
                    br.ReadInt32();
                    br.ReadInt32();
                }

                //read the line $Sections
                s = br.ReadString();        //$Sections
                if (s.IndexOf("$Sections") == -1)
                { MessageBox.Show("Sections header is Corrupt"); JobClose(); return; }

                //read number of sections
                int numSects = br.ReadInt32() - 1;        //$Sections

                //make sure sections in file matches sections set in current vehicle
                if (vehicle.numOfSections != numSects)
                { MessageBox.Show("# of Sections doesn't match this field"); JobClose(); return; }


                //finally start loading triangles
                vec2 vecFix = new vec2(0, 0);

                for (int j = 0; j < vehicle.numOfSections+1; j++)
                {
                    //now read number of patches, then how many vertex's
                    int patches = br.ReadInt32();
                    for (int k = 0; k < patches; k++)
                    {
                        section[j].triangleList = new List<vec2>();
                        section[j].patchList.Add(section[j].triangleList);
                        int verts = br.ReadInt32();
                        for (int v = 0; v < verts; v++)
                        {
                            vecFix.x = br.ReadDouble();
                            vecFix.z = br.ReadDouble();
                            section[j].triangleList.Add(vecFix);
                        }
                    }
                }

                s = br.ReadString();
                if (s.IndexOf("$TotalSqM") == -1)
                { MessageBox.Show("Meters header is Corrupt"); JobClose(); return; }
                
                totalSquareMeters = br.ReadDouble();//total square meters
            }

            // Contour points ----------------------------------------------------------------------------

            fileAndDirectory = workingDirectory + currentFieldDirectory + "\\Contour.ctr";
            if (!File.Exists(fileAndDirectory))
            {
                MessageBox.Show("Missing Contour File");
                return;
            }

            /*
                $Contour
                First_2017Feb10_09.58.51.AM
                //$Offsets
                //533210,5927965,12
                $Patches
                2
                76
                1.384,3.135,-86.304,0 -easting, heading, northing, altitude
             */
            using (BinaryReader br = new BinaryReader(new FileStream(fileAndDirectory, FileMode.Open)))
            {
                string s = br.ReadString(); //$Contour string
                s = br.ReadString();        //current directory string


                //Offset header
                s = br.ReadString(); //$Offsets

                //read the Offsets  - Just read and skip them
                br.ReadInt32();
                br.ReadInt32();
                br.ReadDouble();

                //$Patches line
                s = br.ReadString();
                if (s.IndexOf("$Patches") == -1)
                { MessageBox.Show("Contour File is Corrupt"); return; }

                vec4 vecFix = new vec4(0, 0, 0, 0);

                //now read number of patches, then how many vertex's
                int patches = br.ReadInt32();

                for (int k = 0; k < patches; k++)
                {
                    ct.ptList = new List<vec4>();
                    ct.stripList.Add(ct.ptList);

                    int verts = br.ReadInt32();

                    for (int v = 0; v < verts; v++)
                    {
                        vecFix.x = br.ReadDouble();
                        vecFix.y = br.ReadDouble();
                        vecFix.z = br.ReadDouble();
                        vecFix.k = br.ReadDouble();  

                        ct.ptList.Add(vecFix);
                    }

                }
            }


       // Flags -------------------------------------------------------------------------------------------------

            //Either exit or update running save
            fileAndDirectory = workingDirectory + currentFieldDirectory + "\\Flags.flg";
            if (!File.Exists(fileAndDirectory))
            {
                MessageBox.Show("Missing Flag File");
                return;
            }

            using (BinaryReader br = new BinaryReader(new FileStream(fileAndDirectory, FileMode.Open)))
            {
                string s = br.ReadString();
                s = br.ReadString();

                //Offset header
                s = br.ReadString(); //$Offsets

                //read the Offsets - Just read and skip them
                br.ReadInt32();
                br.ReadInt32();
                br.ReadDouble();
 
                //CFlag flagPt = new CFlag(0,0,0,0,0);
                int points = br.ReadInt32();
 
                if (points > 0)
                {
                    double lat  ;
                    double longi;
                    double east ;
                    double nort ;
                    int color, ID;

                    for (int v = 0; v < points; v++)
                    {
                        
                    
                        lat = br.ReadDouble();
                        longi = br.ReadDouble();
                        east = br.ReadDouble();
                        nort = br.ReadDouble();
                        color = br.ReadInt32();
                        ID = br.ReadInt32();
                        
                        CFlag flagPt = new CFlag(lat, longi, east, nort, color, ID);
                        flagPts.Add(flagPt);
                     }
                    
                }
            }
        }//end of open file

        //Function to save a field
        public void FileSaveField()
        {
           //Friday, February 10, 2017  -->  2:58:24 PM
            //$FieldDir
            //test_2017Feb10_02.55.46.PM
            //$Offsets
            //533210,5927965
            //$Heading
            //False
            //0,0.2,0.2,0.3,0.3,0,0
            //$Sections
            //3
            //4
            //76
            //-10.791,-10.964

            if (!isJobStarted)
            {
                using (var form = new FormTimedMessage(this, 3000, "Ooops, Job Not Started", "Start a job"))
                { form.Show(); }
                return;
            }

            //the saved filename
            string myFileName = workingDirectory + currentFieldDirectory + "\\Field.fld";

            //set saving flag on to ensure rapid save, no gps update
            isSavingFile = true;

 
            //make the file
            using (BinaryWriter bw = new BinaryWriter(File.Open(myFileName, FileMode.Create, FileAccess.Write)))
            {
                //Write out the date
                bw.Write(DateTime.Now.ToLongDateString() + "  -->  " + DateTime.Now.ToLongTimeString()); //string
 
                bw.Write("$FieldDir");
                bw.Write(currentFieldDirectory); //string

                //write out the easting and northing Offsets
                bw.Write("$Offsets");
                bw.Write(pn.utmEast); //int
                bw.Write(pn.utmNorth); //int
                bw.Write(pn.zone); //double

                //write out the ABLine
                bw.Write("$Heading");

                //true or false if ABLine is set
                if (ABLine.isABLineSet) bw.Write(true); //bool
                else bw.Write(false);

                bw.Write(ABLine.abHeading);
                bw.Write(ABLine.refPoint1.x);   // double
                bw.Write(ABLine.refPoint1.z);   // double
                bw.Write(ABLine.refPoint2.x);   // double
                bw.Write(ABLine.refPoint2.z);   // double
                bw.Write(ABLine.tramPassEvery); //int
                bw.Write(ABLine.passBasedOn);   //int
                 
                //write paths # of sections
                bw.Write("$Sections");
                bw.Write(vehicle.numOfSections+1);

                for (int j = 0; j < vehicle.numOfSections+1; j++)
                {
                    //total patches for each section
                    int patchCount = section[j].patchList.Count;

                    //Write out the patches number
                    bw.Write(patchCount);

                    if (patchCount > 0)
                    {
                        //for every new chunk of patch in the whole section
                        for (int q = 0; q < patchCount; q++ ) //each (var triList in section[j].patchList)
                        {
                            int count2 = section[j].patchList[q].Count();

                            bw.Write(count2);

                            for (int i = 0; i < count2; i++)
                            {
                                bw.Write(section[j].patchList[q][i].x);
                                bw.Write(section[j].patchList[q][i].z);
                            }
                        }
                    }

                }

                bw.Write("$TotalSqM");
                bw.Write(totalSquareMeters); //double                
                //bw.Close();

            }

            //set saving flag off
            isSavingFile = false;
        }

        //save flags binary
        public void FileSaveFlags()
        {
            //$FieldDir
            //helpme_2017Feb10_05.10.08.PM
            //$Offsets
            //533210,5927965,12
            //2
            //53.5015412233333,-110.51300932,-26.9707244188758,37.5710366722196

            //get the directory and make sure it exists, create if not
            string myFileName = workingDirectory + currentFieldDirectory  + "\\Flags.flg";
          
            //create the file
            using (BinaryWriter bw = new BinaryWriter(File.Open(myFileName, FileMode.Create, FileAccess.Write)))
            {
                //writing into the file
                try
                {

                    //which field directory
                    bw.Write("$FieldDir");
                    bw.Write(currentFieldDirectory);

                    //write out the easting and northing Offsets
                    bw.Write("$Offsets");
                    bw.Write(pn.utmEast); //int
                    bw.Write(pn.utmNorth); //int
                    bw.Write(pn.zone); //double

                    int count2 = flagPts.Count;
                    bw.Write(count2);

                    for (int i = 0; i < count2; i++)
                    {
                        bw.Write(flagPts[i].latitude);
                        bw.Write(flagPts[i].longitude);
                        bw.Write(flagPts[i].easting);
                        bw.Write(flagPts[i].northing);
                        bw.Write(flagPts[i].color);
                        bw.Write(flagPts[i].ID);
                    }
                   
                }

                catch (IOException e)
                {
                    Console.WriteLine(e.Message + "\n Cannot write to file.");
                    return;
                }
                //bw.Close();

            }
        }

        //save binary version of contour points
        public void FileSaveContour()
        {
            //get the directory and make sure it exists, create if not
            string dirField = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                         "\\AgOpenGPS\\Fields\\" + currentFieldDirectory + "\\" + "Contour.ctr";;

            //set saving flag on to ensure rapid save, no gps update
            isSavingFile = true;

            //every time the patch turns off and on is a new patch
            int stripCount = ct.stripList.Count;

                       //create the file
            using (BinaryWriter bw = new BinaryWriter(File.Open(dirField, FileMode.Create, FileAccess.Write)))
            {
                //$Contour
                //First_2017Feb10_09.58.51.AM
                //$Offsets
                //533210,5927965,12
                //$Patches
                //2
                //76
                //1.384,3.135,-86.304,0

                //writing into the file
                try
                {
                    //which field directory
                    bw.Write("$FieldDir");
                    bw.Write(currentFieldDirectory);

                    //write out the easting and northing Offsets
                    bw.Write("$Offsets");
                    bw.Write(pn.utmEast); //int
                    bw.Write(pn.utmNorth); //int
                    bw.Write(pn.zone); //double

                    //write out how many strips total
                    bw.Write("$Patches");
                    bw.Write(stripCount);

                    if (stripCount > 0)
                    {
                        //for every new chunk of patch in the whole section
                        for (int i = 0; i < stripCount; i++)
                        {
                            int count2 = ct.stripList[i].Count;
                            bw.Write(count2);

                            for (int j = 0; j < count2; j++)
                            {
                                bw.Write(Math.Round(ct.stripList[i][j].x, 3));
                                bw.Write(Math.Round(ct.stripList[i][j].y, 3));
                                bw.Write(Math.Round(ct.stripList[i][j].z, 3));
                                bw.Write(Math.Round(ct.stripList[i][j].k, 3));
                            }
                        }
                    }

                }

                catch (IOException e)
                {
                    MessageBox.Show(e.Message, "\n Cannot write to file.");
                    return;
                }
                //bw.Close();

            }

            isSavingFile = false;

        }

        //----------  Text Versions of Save  --------------------- //

        //Function to save a field
        public void FileSaveFieldText()
        {
            //Saturday, February 11, 2017  -->  7:26:52 AM
            //$FieldDir
            //Bob_Feb11
            //$Offsets
            //533172,5927719,12 - offset easting, northing, zone
            //$Heading
            //True - ABLine is set, below is heading and ref points, tramline base and offset
            //4.32475480730906,25.4121330033522,18.2562255775556,10.5295032855356,12.1358088953421,0,0
            //$Sections
            //1 
            //2 - patches in this section
            //10 - points in this patch
            //10.1728031317344,0.723157039771303 -easting, northing
            //$totalSquareMeters
            //970.761820481737
            //$SectionMeters
            //256.988029010753,367.092667389756,346.681124081229,0,0

            if (!isJobStarted)
            {
                using (var form = new FormTimedMessage(this, 3000, "Ooops, Job Not Started", "Start a Job First"))
                { form.Show(); }
                return;
            }
            string myFileName;
            string dirField;



            //get the directory and make sure it exists, create if not
            dirField = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                                                    "\\AgOpenGPS\\Fields\\" + currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            myFileName = currentFieldDirectory+"_Field.txt";



            //set saving flag on to ensure rapid save, no gps update
            isSavingFile = true;

            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {
                //Write out the date
                writer.WriteLine(DateTime.Now.ToLongDateString() + "  -->  " + DateTime.Now.ToLongTimeString());

                writer.WriteLine("$FieldDir");
                writer.WriteLine(currentFieldDirectory);

                //write out the easting and northing Offsets
                writer.WriteLine("$Offsets");
                writer.WriteLine(pn.utmEast + "," + pn.utmNorth + "," + pn.zone);

                //write out the ABLine
                writer.WriteLine("$Heading");

                //true or false if ABLine is set
                if (ABLine.isABLineSet) writer.WriteLine(true);
                else writer.WriteLine(false);

                writer.WriteLine(ABLine.abHeading + "," + ABLine.refPoint1.x + ","
                    + ABLine.refPoint1.z + "," + ABLine.refPoint2.x + "," + ABLine.refPoint2.z + "," + ABLine.tramPassEvery + "," + ABLine.passBasedOn);

                //write paths # of sections
                writer.WriteLine("$Sections");
                writer.WriteLine(vehicle.numOfSections+1);
                for (int j = 0; j < vehicle.numOfSections+1; j++)
                {
                    //every time the patch turns off and on is a new patch
                    int patchCount = section[j].patchList.Count();

                    //Write out the patch
                    writer.WriteLine(patchCount);

                    if (patchCount > 0)
                    {
                        //for every new chunk of patch in the whole section
                        foreach (var triList in section[j].patchList)
                        {
                            int count2 = triList.Count();

                            writer.WriteLine(count2);

                            for (int i = 0; i < count2; i++)
                            {
                                writer.WriteLine(triList[i].x + "," + triList[i].z);
                            }
                        }
                    }

                }

                writer.WriteLine("$totalSquareMeters");
                writer.WriteLine(totalSquareMeters);
           }

            //set saving flag off
            isSavingFile = false;

        }

        //the file of all the sections in a list
        public void FileSaveSectionPatchesText()
        {

            //get the directory and make sure it exists, create if not
            string dirField = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                         "\\AgOpenGPS\\Fields\\" + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string myFileName;
            myFileName = currentFieldDirectory + "_SectionArea.txt";

            //set saving flag on to ensure rapid save, no gps update
            isSavingFile = true;

            int patchCoun = 0;
            for (int j = 0; j < vehicle.numOfSections+1; j++)
            {
                //every time the patch turns off and on is a new patch
                patchCoun += section[j].patchList.Count;
            }


            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {
                //which field directory
                writer.WriteLine("$FieldDir");
                writer.WriteLine(currentFieldDirectory);

                //write out the easting and northing Offsets
                writer.WriteLine("$Offsets");
                writer.WriteLine(pn.utmEast + "," + pn.utmNorth + "," + pn.zone);

                //write out how many patches total
                writer.WriteLine("$Patches");
                writer.WriteLine(patchCoun);

                for (int j = 0; j < vehicle.numOfSections+1; j++)
                {
                    //every time the patch turns off and on is a new patch
                    int patchCount = section[j].patchList.Count;

                    if (patchCount > 0)
                    {
                        //for every new chunk of patch in the whole section
                        foreach (var triList in section[j].patchList)
                        {
                            int count2 = triList.Count;

                            writer.WriteLine(count2);

                            for (int i = 0; i < count2; i++)
                            {
                                writer.WriteLine(Math.Round(triList[i].x, 5) + "," + Math.Round(triList[i].z, 5));
                            }
                        }
                    }

                }

                writer.WriteLine("$totalSquareMeters");
                writer.WriteLine(totalSquareMeters);
            }

            //set saving flag off
            isSavingFile = false;
        }

        //save all the flag markers
        public void FileSaveFlagsText()
        {
            //$FieldDir
            //Bob_Feb11
            //$Offsets
            //533172,5927719,12  - utm offsets, zone
            //1 -number of flags
            //53.49753484,-110.499324226667,40.8840432226425,17.1507146684453 - lat, long, easting, northing

            //get the directory and make sure it exists, create if not
            string dirField = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                         "\\AgOpenGPS\\Fields\\" + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string myFileName;
            myFileName = currentFieldDirectory + "_Flags.txt";

            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {
                //which field directory
                writer.WriteLine("$FieldDir");
                writer.WriteLine(currentFieldDirectory);

                //write out the easting and northing Offsets
                writer.WriteLine("$Offsets");
                writer.WriteLine(pn.utmEast + "," + pn.utmNorth + "," + pn.zone);

                int count2 = flagPts.Count;

                writer.WriteLine(count2);

                for (int i = 0; i < count2; i++)
                {
                    writer.WriteLine(
                        flagPts[i].latitude + "," +
                        flagPts[i].longitude + "," +
                        flagPts[i].easting + "," +
                        flagPts[i].northing + "," +
                        flagPts[i].color + "," +
                        flagPts[i].ID);
                }
            }
        }

        //save the contour points which include elevation values
        public void FileSaveContourText()
        {
            //$Contour
            //Bob_Feb11
            //$Offsets
            //533172,5927719,12
            //$Patches
            //1   - total patches
            //1  - points in patch
            //64.697,0.168,-21.654,0 - east, heading, north, altitude

            //get the directory and make sure it exists, create if not
            string dirField = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                         "\\AgOpenGPS\\Fields\\" + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string myFileName;
            myFileName = currentFieldDirectory + "_Contour.txt";

            //set saving flag on to ensure rapid save, no gps update
            isSavingFile = true;

            int stripCount = 0;
            //every time the patch turns off and on is a new patch
            stripCount = ct.stripList.Count;

            //write out the file
            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {
                //which field directory
                writer.WriteLine("$Contour");
                writer.WriteLine(currentFieldDirectory);

                //write out the easting and northing Offsets
                writer.WriteLine("$Offsets");
                writer.WriteLine(pn.utmEast + "," + pn.utmNorth + "," + pn.zone);

                //write out how many patches total
                writer.WriteLine("$Patches");
                writer.WriteLine(stripCount);


                if (stripCount > 0)
                {
                    //for every new chunk of patch in the whole section
                    foreach (var triList in ct.stripList)
                    {
                        int count2 = triList.Count;

                        writer.WriteLine(count2);

                        for (int i = 0; i < count2; i++)
                        {
                            writer.WriteLine(Math.Round(triList[i].x, 3) + "," +
                                Math.Round(triList[i].y, 3) + "," +
                                Math.Round(triList[i].z, 3) + "," +
                                Math.Round(triList[i].k, 3));
                        }
                    }
                }

            }

            //set saving flag off
            isSavingFile = false;
        }

        //generate KML file from flags
        public void FileSaveFlagKML()
        {

            //get the directory and make sure it exists, create if not
            string dirField = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                         "\\AgOpenGPS\\Fields\\" + currentFieldDirectory + "\\";

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
                                    flagPts[i].longitude + "," + flagPts[i].latitude + ",0" +
                                    @"</coordinates> </Point> ");
                writer.WriteLine(@"  </Placemark>                                 ");
                       
                }

                writer.WriteLine(@"</Document>");

                writer.WriteLine(@"</kml>                                         ");


            
            }

        }

        //generate KML file from flags
        public void FileSaveSingleFlagKML(int flagNumber)
        {

            //get the directory and make sure it exists, create if not
            string dirField = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                         "\\AgOpenGPS\\Fields\\" + currentFieldDirectory + "\\";

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
                    writer.WriteLine(@" <name> " + flagNumber + @"</name>");
                    writer.WriteLine(@"<Point><coordinates> " +
                                    flagPts[flagNumber-1].longitude + "," + flagPts[flagNumber-1].latitude + ",0" +
                                    @"</coordinates> </Point> ");
                    writer.WriteLine(@"  </Placemark>                                 ");
                writer.WriteLine(@"</Document>");
                writer.WriteLine(@"</kml>                                         ");

            }
        }

        //save nmea sentences
        public void FileSaveNMEA()
        {
            using (StreamWriter writer =  new StreamWriter((workingDirectory + currentFieldDirectory + "\\NMEA_log.txt"), true))
            {
                writer.Write(pn.logNMEASentence.ToString());
            }
            pn.logNMEASentence.Clear();
        }
    }
}