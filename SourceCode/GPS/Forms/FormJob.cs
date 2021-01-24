using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormJob : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        public FormJob(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();

            btnJobOpen.Text = gStr.gsOpen;
            btnJobNew.Text = gStr.gsNew;
            btnJobResume.Text = gStr.gsResume;

            label1.Text = gStr.gsLastFieldUsed;

            this.Text = gStr.gsStartNewField;
        }

        private void btnJobNew_Click(object sender, EventArgs e)
        {
            //back to FormGPS
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void btnJobResume_Click(object sender, EventArgs e)
        {
            //open the Resume.txt and continue from last exit
            mf.FileOpenField("Resume");

            //back to FormGPS
            DialogResult = DialogResult.OK;
            Close();
        }

        private void FormJob_Load(object sender, EventArgs e)
        {
            //check if directory and file exists, maybe was deleted etc
            if (String.IsNullOrEmpty(mf.currentFieldDirectory)) btnJobResume.Enabled = false;
            string directoryName = mf.fieldsDirectory + mf.currentFieldDirectory + "\\";

            string fileAndDirectory = directoryName + "Field.txt";

            if (!File.Exists(fileAndDirectory))
            {
                textBox1.Text = "";
                btnJobResume.Enabled = false;
                mf.currentFieldDirectory = "";
                Properties.Settings.Default.setF_CurrentDir = "";
                Properties.Settings.Default.Save();
            }
            else
            {
                textBox1.Text = mf.currentFieldDirectory;
            }
        }

        private void btnJobTouch_Click(object sender, EventArgs e)
        {
            mf.filePickerFileAndDirectory = "";

            using (var form = new FormTouchPick(mf))
            {
                var result = form.ShowDialog();

                //returns full field.txt file dir name
                if (result == DialogResult.Yes)
                {
                    mf.FileOpenField(mf.filePickerFileAndDirectory);
                    Close();
                }
                else
                {
                    return;
                }
            }
        }

        private void btnJobOpen_Click(object sender, EventArgs e)
        {
            mf.filePickerFileAndDirectory = "";

            using (var form = new FormFilePicker(mf))
            {
                var result = form.ShowDialog();

                //returns full field.txt file dir name
                if (result == DialogResult.Yes)
                {
                    mf.FileOpenField(mf.filePickerFileAndDirectory);
                    Close();
                }
                else
                {
                    return;
                }
            }
        }

        private void btnInField_Click(object sender, EventArgs e)
        {
            string infieldList = "";
            int numFields = 0;

            string[] dirs = Directory.GetDirectories(mf.fieldsDirectory);

            foreach (string dir in dirs)
            {
                double northingOffset = 0;
                double eastingOffset = 0;
                
                string fieldDirectory = Path.GetFileName(dir);
                string filename = dir + "\\Field.txt";
                string line;

                //make sure directory has a field.txt in it
                if (File.Exists(filename))
                {
                    using (StreamReader reader = new StreamReader(filename))
                    {
                        try
                        {
                            //Date time line
                            for (int i = 0; i < 4; i++)
                            {
                                line = reader.ReadLine();
                            }

                            //start positions
                            if (!reader.EndOfStream)
                            {
                                line = reader.ReadLine();
                                string[] offs = line.Split(',');

                                eastingOffset = (double.Parse(offs[0], CultureInfo.InvariantCulture));
                                northingOffset = (double.Parse(offs[1], CultureInfo.InvariantCulture));
                            }
                        }
                        catch (Exception)
                        {
                            var form = new FormTimedMessage(2000, gStr.gsFieldFileIsCorrupt, gStr.gsChooseADifferentField);
                        }
                    }

                    //grab the boundary
                    filename = dir + "\\Boundary.txt";

                    if (File.Exists(filename))
                    {
                        List<vec3> pointList = new List<vec3>();

                        using (StreamReader reader = new StreamReader(filename))
                        {
                            try
                            {

                                //read header
                                line = reader.ReadLine();//Boundary

                                if (!reader.EndOfStream) //empty boundary field
                                {
                                    //True or False OR points from older boundary files
                                    line = reader.ReadLine();


                                    //Check for older boundary files, then above line string is num of points
                                    if (line == "True" || line == "False")
                                    {
                                        line = reader.ReadLine(); //number of points
                                    }

                                    //Check for latest boundary files, then above line string is num of points
                                    if (line == "True" || line == "False")
                                    {
                                        line = reader.ReadLine(); //number of points
                                    }

                                    int numPoints = int.Parse(line);
                                    vec2[] linePoints = new vec2[numPoints];

                                    if (numPoints > 0)
                                    {
                                        //load the line
                                        for (int i = 0; i < numPoints; i++)
                                        {
                                            line = reader.ReadLine();
                                            string[] words = line.Split(',');
                                            vec2 vecPt = new vec2(
                                            double.Parse(words[0], CultureInfo.InvariantCulture) + eastingOffset,
                                            double.Parse(words[1], CultureInfo.InvariantCulture) + northingOffset);

                                            linePoints[i] = vecPt;
                                        }

                                        int j = linePoints.Length - 1;
                                        bool oddNodes = false;
                                        double x = mf.pn.fix.easting;
                                        double y = mf.pn.fix.northing;

                                        for (int i = 0; i < linePoints.Length; i++)
                                        {
                                            if ((linePoints[i].northing < y && linePoints[j].northing >= y
                                            || linePoints[j].northing < y && linePoints[i].northing >= y)
                                            && (linePoints[i].easting <= x || linePoints[j].easting <= x))
                                            {
                                                oddNodes ^= (linePoints[i].easting + (y - linePoints[i].northing) /
                                                (linePoints[j].northing - linePoints[i].northing) * (linePoints[j].easting - linePoints[i].easting) < x);
                                            }
                                            j = i;
                                        }

                                        if (oddNodes)
                                        {
                                            numFields++;
                                            if (string.IsNullOrEmpty(infieldList))
                                                infieldList += Path.GetFileName(dir); 
                                            else
                                                infieldList += "," + Path.GetFileName(dir);
                                        }
                                    }
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(infieldList))
            {
                mf.filePickerFileAndDirectory = "";

                if (numFields > 1)
                {
                    using (var form = new FormDrivePicker(mf, infieldList))
                    {
                        var result = form.ShowDialog();

                        //returns full field.txt file dir name
                        if (result == DialogResult.Yes)
                        {
                            mf.FileOpenField(mf.filePickerFileAndDirectory);
                            Close();
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else // 1 field found
                {
                    mf.filePickerFileAndDirectory = mf.fieldsDirectory + infieldList + "\\Field.txt";
                    mf.FileOpenField(mf.filePickerFileAndDirectory);
                    Close();
                }
            }
            else //no fields found
            {
                var form2 = new FormTimedMessage(2000, gStr.gsNoFieldsFound, gStr.gsFieldNotOpen);
                form2.Show();
            }

        }
    }
}