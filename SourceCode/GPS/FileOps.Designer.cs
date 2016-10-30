using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpGL;
using System.IO.Ports;
using System.IO;
using System.Diagnostics;

namespace AgOpenGPS
{
    public partial class FormGPS
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
                    writer.Write("ForeAft," + Properties.Settings.Default.setVehicle_toolForeAft + ",");
                    writer.Write("AntennaHeight," + Properties.Settings.Default.setVehicle_antennaHeight + ",");
                    writer.Write("LookAhead," + Properties.Settings.Default.setVehicle_lookAhead + ",");
                    writer.Write("IsHitched," + Properties.Settings.Default.setVehicle_isHitched + ",");

                    writer.Write("Spinner1," + Properties.Settings.Default.setSection_nudSpin1 + ",");
                    writer.Write("Spinner2," + Properties.Settings.Default.setSection_nudSpin2 + ",");
                    writer.Write("Spinner3," + Properties.Settings.Default.setSection_nudSpin3 + ",");
                    writer.Write("Spinner4," + Properties.Settings.Default.setSection_nudSpin4 + ",");
                    writer.Write("Spinner5," + Properties.Settings.Default.setSection_nudSpin5 + ",");
                    writer.Write("Spinner6," + Properties.Settings.Default.setSection_nudSpin6 + ",");

                    writer.Write("Sections," + Properties.Settings.Default.setVehicle_numSections + ",");
                    writer.Write("ToolWidth," + Properties.Settings.Default.setVehicle_toolWidth + ",");
                    writer.Write("Reserved,0,"); writer.Write("Reserved,0,"); writer.Write("Reserved,0,");
                    writer.Write("Reserved,0,"); writer.Write("Reserved,0,"); writer.Write("Reserved,0,");
                    writer.Write("Reserved,0,"); writer.Write("Reserved,0,"); writer.Write("Reserved,0,");
                    writer.Write("Reserved,0");
                    ////little show to say saved and where
                    MessageBox.Show(saveDialog.FileName, "File Saved to ");
                }
            }

        }

        //function to open a previously saved field
        public void FileOpenVehicle()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            //get the directory where the fields are stored
            //string directoryName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+ "\\fields\\";
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
                    //Overlap,0.5,ForeAft,-2,AntennaHeight,3,LookAhead,2,IsHitched,False,
                    //Spinner1,-8.0,Spinner2,-3.0,Spinner3,3.0,Spinner4,8.0,Spinner5,0,Spinner6,0,Sections,3,ToolWidth,16

                    line = reader.ReadLine();//Date time line  

                    string[] words;

                    words = line.Split(',');

                    if (words.Count() != 46) { MessageBox.Show("Corrupt Vehicle file"); return; }

                    Properties.Settings.Default.setVehicle_toolOverlap = double.Parse(words[1]);
                    Properties.Settings.Default.setVehicle_toolForeAft = double.Parse(words[3]);
                    Properties.Settings.Default.setVehicle_antennaHeight = double.Parse(words[5]);
                    Properties.Settings.Default.setVehicle_lookAhead = double.Parse(words[7]);
                    Properties.Settings.Default.setVehicle_isHitched = bool.Parse(words[9]);

                    Properties.Settings.Default.setSection_nudSpin1 = decimal.Parse(words[11]);
                    Properties.Settings.Default.setSection_nudSpin2 = decimal.Parse(words[13]);
                    Properties.Settings.Default.setSection_nudSpin3 = decimal.Parse(words[15]);
                    Properties.Settings.Default.setSection_nudSpin4 = decimal.Parse(words[17]);
                    Properties.Settings.Default.setSection_nudSpin5 = decimal.Parse(words[19]);
                    Properties.Settings.Default.setSection_nudSpin6 = decimal.Parse(words[21]);

                    Properties.Settings.Default.setVehicle_numSections = int.Parse(words[23]);
                    Properties.Settings.Default.setVehicle_toolWidth = double.Parse(words[25]);

                    Properties.Settings.Default.Save();

                    //get the number of sections from settings
                    vehicle.numberOfSections = Properties.Settings.Default.setVehicle_numSections;

                    //from settings grab the vehicle specifics
                    vehicle.toolOverlap = Properties.Settings.Default.setVehicle_toolOverlap;
                    vehicle.toolForeAft = Properties.Settings.Default.setVehicle_toolForeAft;
                    vehicle.antennaHeight = Properties.Settings.Default.setVehicle_antennaHeight;
                    vehicle.lookAhead = Properties.Settings.Default.setVehicle_lookAhead;
                    vehicle.isHitched = Properties.Settings.Default.setVehicle_isHitched;

                    //Set width of section and positions for each section
                    SectionSetPosition();

                    //Calculate total width and each section width
                    SectionCalcWidths();

                    //MessageBox.Show("*** AgOpenGPS needs a Restart ***");

                    //Application.Exit();

                }

            }
            //cancelled out of open file

        }//end of open file


        //function to open a previously saved field
        private void FileOpenField()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            //get the directory where the fields are stored
            //string directoryName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+ "\\fields\\";
            string directoryName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AgOpenGPS\\Fields\\";

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
                 //make sure the file if fully valid and vehicle matches sections
                using (StreamReader reader = new StreamReader(ofd.FileName))
                {
                    string line2;

                    line2 = reader.ReadLine();//Date time line                  
                    line2 = reader.ReadLine();//AB Line header

                    if (line2.IndexOf("$Heading") == -1)
                    { MessageBox.Show("File is Corrupt"); return; }

                    //read the boolean if AB is set
                    line2 = reader.ReadLine();
                    if ((line2.IndexOf("True") == -1 && (line2.IndexOf("False") == -1)))
                    { MessageBox.Show("AB Line is Corrupt"); return; }

                    line2 = reader.ReadLine();//just read and skip the heading line                
                    line2 = reader.ReadLine();//read the line $Sections

                    if (line2.IndexOf("$Sections") == -1)
                    { MessageBox.Show("Sections header is Corrupt"); return; }

                    //read number of sections
                    line2 = reader.ReadLine();
                    int numSects = int.Parse(line2);

                    //make sure sections in file matches sections set in current vehicle
                    if (vehicle.numberOfSections != numSects)
                    { MessageBox.Show("Vehicle doesn't match this field"); return; }


                    for (int j = 0; j < vehicle.numberOfSections; j++)
                    {
                        //now read number of patches, then how many vertex's
                        line2 = reader.ReadLine();
                        int patches = int.Parse(line2);

                        for (int k = 0; k < patches; k++)
                        {

                            line2 = reader.ReadLine();
                            int verts = int.Parse(line2);

                            for (int v = 0; v < verts; v++)
                            {
                                line2 = reader.ReadLine();
                            }
                        }
                    }

                    //read final area and header lines
                    line2 = reader.ReadLine();
                    if (line2.IndexOf("$totalSquareMeters") == -1)
                    {
                        MessageBox.Show("Meters header is Corrupt");
                        return;
                    }

                }
                //made it to here so file is mostly valid

                //close the existing job and reset everything
                this.JobClose();

                //and open a new job
                this.JobNew();

                //start to read the file
                string line;
                using (StreamReader reader = new StreamReader(ofd.FileName))
                {
                    //Date time line
                    line = reader.ReadLine();

                    //AB Line header
                    line = reader.ReadLine();

                    //read the boolean if AB is set
                    line = reader.ReadLine();
                    bool b = bool.Parse(line);

                    //If is true there is AB Line data
                    if (b)
                    {
                        //Heading, refPoint1x,z,refPoint2x,z
                        line = reader.ReadLine();

                        //separate it into the 4 words
                        string[] words = line.Split(',');
                        ABLine.abHeading = double.Parse(words[0]);
                        ABLine.refPoint1.x = double.Parse(words[1]);
                        ABLine.refPoint1.z = double.Parse(words[2]);
                        ABLine.refPoint2.x = double.Parse(words[3]);
                        ABLine.refPoint2.z = double.Parse(words[4]);

                        ABLine.refABLineP1.x = ABLine.refPoint1.x - Math.Sin(ABLine.abHeading) * 10000.0;
                        ABLine.refABLineP1.z = ABLine.refPoint1.z - Math.Cos(ABLine.abHeading) * 10000.0;

                        ABLine.refABLineP2.x = ABLine.refPoint1.x + Math.Sin(ABLine.abHeading) * 10000.0;
                        ABLine.refABLineP2.z = ABLine.refPoint1.z + Math.Cos(ABLine.abHeading) * 10000.0;

                        ABLine.isABLineSet = true;
                    }

                    //false so just read and skip the heading line
                    else line = reader.ReadLine();

                    //read the section and patch triangles...

                    //read the line $Sections
                    line = reader.ReadLine();

                    //read number of sections
                    line = reader.ReadLine();

                    //finally start loading triangles
                    vec3 vecFix = new vec3(0, 0, 0);

                    for (int j = 0; j < vehicle.numberOfSections; j++)
                    {
                        //now read number of patches, then how many vertex's
                        line = reader.ReadLine();
                        int patches = int.Parse(line);

                        for (int k = 0; k < patches; k++)
                        {
                            section[j].triangleList = new List<vec3>();
                            section[j].patchList.Add(section[j].triangleList);

                            line = reader.ReadLine();
                            int verts = int.Parse(line);

                            for (int v = 0; v < verts; v++)
                            {
                                line = reader.ReadLine();
                                string[] words = line.Split(',');
                                vecFix.x = double.Parse(words[0]);
                                vecFix.y = 0;
                                vecFix.z = double.Parse(words[1]);

                                section[j].triangleList.Add(vecFix);
                            }

                        }

                    }

                    line = reader.ReadLine();
                    if (line.IndexOf("$totalSquareMeters") == -1)
                    {
                        MessageBox.Show("Meters header is Corrupt");
                        return;
                    }

                    line = reader.ReadLine();
                    totalSquareMeters = double.Parse(line);



                }
                //cancelled out of open file
            }


        }//end of open file

        //Function to save a field
        private void FileSaveField()
        {
            //in the current application directory
            //string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //string fieldDir = dir + "\\fields\\";

            if (!isJobStarted)
            {
                MessageBox.Show("Can't save a job if no job is open");
                return;
            }

            string dirField = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AgOpenGPS\\Fields\\";

            string directoryName = Path.GetDirectoryName(dirField);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string myFileName = String.Format("{0}{1}", DateTime.Now.ToString("yyyy_MMM_dd__hh.mm.ss.tt"), ".txt");

            //set saving flag on
            isSavingFile = true;

            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {
                //Write out the date
                writer.WriteLine(DateTime.Now.ToLongDateString() + "  -->  " + DateTime.Now.ToLongTimeString());

                //write out the ABLine
                writer.WriteLine("$Heading");

                //true or false if ABLine is set
                if (ABLine.isABLineSet) writer.WriteLine(true);
                else writer.WriteLine(false);

                writer.WriteLine(ABLine.abHeading + "," + ABLine.refPoint1.x + ","
                    + ABLine.refPoint1.z + "," + ABLine.refPoint2.x + "," + ABLine.refPoint2.z);

                //write paths # of sections
                writer.WriteLine("$Sections");
                writer.WriteLine(vehicle.numberOfSections);
                for (int j = 0; j < vehicle.numberOfSections; j++)
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
                                writer.WriteLine(Math.Round(triList[i].x, 2) + "," + Math.Round(triList[i].z, 2));
                            }
                        }
                    }

                }

                //writer.WriteLine(Math.Round(totalSquareMeters / 4046.8627, 2));
                writer.WriteLine("$totalSquareMeters");
                writer.WriteLine(totalSquareMeters);
            }

            //set saving flag off
            isSavingFile = false;

            //little show to say saved and where
            MessageBox.Show((dirField + "\n\r\n\r" + myFileName), "File Saved to ");

        }

    }
}
