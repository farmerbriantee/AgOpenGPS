using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormSwapAB : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf = null;

        //the abline stored file
        private string filename = "";

        public FormSwapAB(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();
        }

        private void btnAB1_Click(object sender, EventArgs e)
        {
            int count = lvLines.SelectedItems.Count;
            if (count > 0)
            {
                mf.AB1.fieldName = lvLines.SelectedItems[0].SubItems[0].Text;
                mf.AB1.heading = double.Parse(lvLines.SelectedItems[0].SubItems[1].Text, CultureInfo.InvariantCulture);
                mf.AB1.X = double.Parse(lvLines.SelectedItems[0].SubItems[2].Text, CultureInfo.InvariantCulture);
                mf.AB1.Y = double.Parse(lvLines.SelectedItems[0].SubItems[3].Text, CultureInfo.InvariantCulture);

                btnAB1.Enabled = false;
                btnAB2.Enabled = false;

                lblField1.Text = mf.AB1.fieldName;
                lblHeading1.Text = mf.AB1.heading.ToString("N5");

                lvLines.SelectedItems.Clear();
            }
        }

        private void btnAB2_Click(object sender, EventArgs e)
        {
            int count = lvLines.SelectedItems.Count;
            if (count > 0)
            {
                mf.AB2.fieldName = lvLines.SelectedItems[0].SubItems[0].Text;
                mf.AB2.heading = double.Parse(lvLines.SelectedItems[0].SubItems[1].Text, CultureInfo.InvariantCulture);
                mf.AB2.X = double.Parse(lvLines.SelectedItems[0].SubItems[2].Text, CultureInfo.InvariantCulture);
                mf.AB2.Y = double.Parse(lvLines.SelectedItems[0].SubItems[3].Text, CultureInfo.InvariantCulture);

                btnAB1.Enabled = false;
                btnAB2.Enabled = false;

                lblField2.Text = mf.AB2.fieldName;
                lblHeading2.Text = mf.AB2.heading.ToString("N5");

                lvLines.SelectedItems.Clear();
            }
        }

        private void btnListUse_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                string words = mf.AB1.fieldName + "," +
                        mf.AB1.heading.ToString() + "," +
                        mf.AB1.X.ToString() + "," +
                        mf.AB1.Y.ToString();

                //out to file
                writer.WriteLine(words);

                words = mf.AB2.fieldName + "," +
                        mf.AB2.heading.ToString() + "," +
                        mf.AB2.X.ToString() + "," +
                        mf.AB2.Y.ToString();

                //out to file
                writer.WriteLine(words);
            }

            //close the window
            Close();
        }

        private void FormSwapAB_Load(object sender, EventArgs e)
        {
            //different start based on AB line already set or not
            if (!mf.ABLine.isABLineSet)
            {
                Close();
            }
            else
            {
                //no AB line
            }

            //make sure at least a blank AB Line file exists
            //make sure at least a global blank AB Line file exists
            string dirField = mf.fieldsDirectory + mf.currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField).ToString(CultureInfo.InvariantCulture);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            filename = directoryName + "\\ABLines.txt";
            if (!File.Exists(filename))
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine("ABLine N S,0,0,0");
                    writer.WriteLine("ABLine E W,90,0,0");
                }
            }

            //get the file of previous AB Lines
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            filename = directoryName + "\\ABLines.txt";

            if (!File.Exists(filename))
            {
                mf.TimedMessageBox(2000, "File Error", "Missing AB Line File, Critical Error");
            }
            else
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    try
                    {
                        string line;
                        ListViewItem itm;

                        //read all the lines
                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();
                            string[] words = line.Split(',');
                            //listboxLines.Items.Add(line);
                            itm = new ListViewItem(words);
                            lvLines.Items.Add(itm);
                        }
                    }
                    catch (Exception er)
                    {
                        var form = new FormTimedMessage(2000, "ABLine File is Corrupt", "Please delete it!!!");
                        form.Show();
                        mf.WriteErrorLog("FieldOpen, Loading ABLine, Corrupt ABLine File" + er);
                    }
                }

                // go to bottom of list - if there is a bottom
                if (lvLines.Items.Count > 0) lvLines.Items[lvLines.Items.Count - 1].EnsureVisible();
            }

            //make sure at least a blank quickAB file exists
            directoryName = Path.GetDirectoryName(mf.fieldsDirectory).ToString(CultureInfo.InvariantCulture);
            directoryName += "\\" + mf.currentFieldDirectory + "\\";
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }
            filename = directoryName + "QuickAB.txt";
            if (!File.Exists(filename))
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine("ABLine N S,0,0,0");
                    writer.WriteLine("ABLine E W,90,0,0");
                }
            }

            //get the file of previous AB Lines
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            filename = directoryName + "QuickAB.txt";

            if (!File.Exists(filename))
            {
                mf.TimedMessageBox(2000, "File Error", "Missing QuickAB File, Critical Error");
            }
            else
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    try
                    {
                        string line;

                        //read all the lines
                        {
                            line = reader.ReadLine();
                            string[] words = line.Split(',');
                            mf.AB1.fieldName = words[0];
                            mf.AB1.heading = double.Parse(words[1], CultureInfo.InvariantCulture);
                            mf.AB1.X = double.Parse(words[2], CultureInfo.InvariantCulture);
                            mf.AB1.Y = double.Parse(words[3], CultureInfo.InvariantCulture);

                            lblField1.Text = mf.AB1.fieldName;
                            lblHeading1.Text = mf.AB1.heading.ToString("N5");

                            line = reader.ReadLine();
                            words = line.Split(',');
                            mf.AB2.fieldName = words[0];
                            mf.AB2.heading = double.Parse(words[1], CultureInfo.InvariantCulture);
                            mf.AB2.X = double.Parse(words[2], CultureInfo.InvariantCulture);
                            mf.AB2.Y = double.Parse(words[3], CultureInfo.InvariantCulture);

                            lblField2.Text = mf.AB2.fieldName;
                            lblHeading2.Text = mf.AB2.heading.ToString("N5");
                        }
                    }
                    catch (Exception er)
                    {
                        var form = new FormTimedMessage(2000, "QuickAB File is Corrupt", "Please delete it!!!");
                        form.Show();
                        mf.WriteErrorLog("FieldOpen, Loading QuickAB, Corrupt QuickAB File" + er);
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int count = lvLines.SelectedItems.Count;
            if (count > 0)
            {
                btnAB1.Enabled = true;
                btnAB2.Enabled = true;
            }
            else
            {
                btnAB1.Enabled = false;
                btnAB2.Enabled = false;
            }
        }
    }
}