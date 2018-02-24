using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormFieldDir : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        private string templateFileAndDirectory;
        private bool isTemplateSet;

        public FormFieldDir(Form _callingForm)
        {
            //get copy of the calling main form
            mf = _callingForm as FormGPS;

            InitializeComponent();
        }

        private void FormFieldDir_Load(object sender, EventArgs e)
        {
            btnTemplate.Enabled = false;
            btnSave.Enabled = false;
            lblTemplateChosen.Text = "None Selected";
        }

        private void tboxFieldName_TextChanged(object sender, EventArgs e)
        {
            var textboxSender = (TextBox)sender;
            var cursorPosition = textboxSender.SelectionStart;
            textboxSender.Text = Regex.Replace(textboxSender.Text, "[^0-9a-zA-Z ]", "");
            textboxSender.SelectionStart = cursorPosition;

            if (String.IsNullOrEmpty(tboxFieldName.Text.Trim()))
            {
                btnTemplate.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                btnTemplate.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void btnSerialCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            //create the dialog instance
            OpenFileDialog ofd = new OpenFileDialog
            {
                //the initial directory, fields, for the open dialog
                InitialDirectory = mf.fieldsDirectory,

                //When leaving dialog put windows back where it was
                RestoreDirectory = true,

                //set the filter to text files only
                Filter = "Field files (Field.txt)|Field.txt"
            };

            //was a file selected
            if (ofd.ShowDialog() == DialogResult.Cancel)
            {
                isTemplateSet = false;
                mf.TimedMessageBox(1500, "Template Cancelled", "You can still start a new field");
                return;
            }
            else
            {
                templateFileAndDirectory = ofd.FileName;
                isTemplateSet = true;
                lblTemplateChosen.Text = new DirectoryInfo(Path.GetDirectoryName(templateFileAndDirectory)).Name;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //fill something in
            if (String.IsNullOrEmpty(tboxFieldName.Text.Trim()))
            {
                Close();
                return;
            }

            //append date time to name
            mf.currentFieldDirectory = tboxFieldName.Text.Trim() + String.Format("{0}", DateTime.Now.ToString("-yyyy.MMM.dd HH_mm", CultureInfo.InvariantCulture));

            //get the directory and make sure it exists, create if not
            string dirNewField = mf.fieldsDirectory + mf.currentFieldDirectory + "\\";

            //if no template set just make a new file.
            if (!isTemplateSet)
            {
                try
                {
                    //start a new job
                    mf.JobNew();

                    //create it for first save
                    string directoryName = Path.GetDirectoryName(dirNewField);

                    if ((!string.IsNullOrEmpty(directoryName)) && (Directory.Exists(directoryName)))
                    {
                        MessageBox.Show("Choose a different name", "Directory Exists", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    else
                    {
                        //reset the offsets
                        mf.pn.utmEast = (int)mf.pn.actualEasting;
                        mf.pn.utmNorth = (int)mf.pn.actualNorthing;

                        mf.worldGrid.CreateWorldGrid(0, 0);

                        //make sure directory exists, or create it
                        if ((!string.IsNullOrEmpty(directoryName)) && (!Directory.Exists(directoryName)))
                        { Directory.CreateDirectory(directoryName); }

                        //create the field file header info
                        mf.FileCreateField();
                        mf.FileCreateSections();
                        mf.FileCreateRecPath();
                        mf.FileCreateContour();
                        mf.FileSaveFlags();
                        mf.FileSaveABLine();
                    }
                }
                catch (Exception ex)
                {
                    mf.WriteErrorLog("Creating new field " + ex);

                    MessageBox.Show("Error", ex.ToString());
                    mf.currentFieldDirectory = "";
                }
            }
            else
            {
                // create from template
                string directoryName = Path.GetDirectoryName(dirNewField);

                if ((!string.IsNullOrEmpty(directoryName)) && (Directory.Exists(directoryName)))
                {
                    MessageBox.Show("Choose a different name", "Directory Exists", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    //create the new directory
                    if ((!string.IsNullOrEmpty(directoryName)) && (!Directory.Exists(directoryName)))
                    { Directory.CreateDirectory(directoryName); }
                }

                string line;
                string offsets;

                using (StreamReader reader = new StreamReader(templateFileAndDirectory))
                {
                    try
                    {
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        line = reader.ReadLine();

                        //read the Offsets  - all we really need from template field file
                        offsets = reader.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        mf.WriteErrorLog("While Opening Field" + ex);

                        var form = new FormTimedMessage(4000, "Field File is Corrupt", "Choose a different field");
                        form.Show();
                        mf.JobClose();
                        return;
                    }

                    const string myFileName = "Field.txt";

                    using (StreamWriter writer = new StreamWriter(dirNewField + myFileName))
                    {
                        //Write out the date
                        writer.WriteLine(DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss tt", CultureInfo.InvariantCulture));

                        writer.WriteLine("$FieldDir");
                        writer.WriteLine(mf.currentFieldDirectory.ToString(CultureInfo.InvariantCulture));

                        //write out the easting and northing Offsets
                        writer.WriteLine("$Offsets");
                        writer.WriteLine(offsets);
                    }

                    //create blank Contour and Section files
                    mf.FileCreateSections();
                    mf.FileCreateContour();

                    //copy over the files from template
                    string templateDirectoryName = Path.GetDirectoryName(templateFileAndDirectory);

                    string fileToCopy = templateDirectoryName + "\\Boundary.txt";
                    string destinationDirectory = directoryName + "\\Boundary.txt";
                    if (File.Exists(fileToCopy))
                        File.Copy(fileToCopy, destinationDirectory);

                    fileToCopy = templateDirectoryName + "\\Headland.txt";
                    destinationDirectory = directoryName + "\\Headland.txt";
                    if (File.Exists(fileToCopy))
                        File.Copy(fileToCopy, destinationDirectory);

                    fileToCopy = templateDirectoryName + "\\Flags.txt";
                    destinationDirectory = directoryName + "\\Flags.txt";
                    if (File.Exists(fileToCopy))
                        File.Copy(fileToCopy, destinationDirectory);

                    fileToCopy = templateDirectoryName + "\\ABLine.txt";
                    destinationDirectory = directoryName + "\\ABLine.txt";
                    if (File.Exists(fileToCopy))
                        File.Copy(fileToCopy, destinationDirectory);

                    fileToCopy = templateDirectoryName + "\\RecPath.txt";
                    destinationDirectory = directoryName + "\\RecPath.txt";
                    if (File.Exists(fileToCopy))
                        File.Copy(fileToCopy, destinationDirectory);

                    //now open the newly cloned field
                    mf.FileOpenField(dirNewField + myFileName);
                }
            }

            DialogResult = DialogResult.OK;
            Close();

        }
    }
}