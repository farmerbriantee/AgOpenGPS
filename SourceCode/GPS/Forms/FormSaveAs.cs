using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormSaveAs : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        public FormSaveAs(Form _callingForm)
        {
            //get copy of the calling main form
            mf = _callingForm as FormGPS;

            InitializeComponent();

            label1.Text = gStr.gsEnterFieldName;
            label2.Text = gStr.gsDateWillBeAdded;
            label3.Text = gStr.gsBasedOnField;
            label4.Text = gStr.gsEnterTask;
            label5.Text = gStr.gsEnterVehicleUsed;

            chkHeadland.Text = gStr.gsHeadland;
            chkFlags.Text = gStr.gsFlags;
            chkGuidanceLines.Text = gStr.gsGuidance;
            chkApplied.Text = gStr.gsMapping;

            this.Text = gStr.gsSaveAs;
            lblTemplateChosen.Text = gStr.gsNoneUsed;
        }

        private void FormSaveAs_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            lblTemplateChosen.Text = Properties.Settings.Default.setF_CurrentDir;
            //tboxVehicle.Text = mf.vehicleFileName + " " + mf.toolFileName;
            lblFilename.Text = "";
        }

        private void tboxFieldName_TextChanged(object sender, EventArgs e)
        {
            var textboxSender = (TextBox)sender;
            var cursorPosition = textboxSender.SelectionStart;
            textboxSender.Text = Regex.Replace(textboxSender.Text, glm.fileRegex, "");
            textboxSender.SelectionStart = cursorPosition;

            if (String.IsNullOrEmpty(tboxFieldName.Text.Trim()))
            {
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
            }

            lblFilename.Text = tboxFieldName.Text.Trim() + " " + tboxTask.Text.Trim()
                + " " + tboxVehicle.Text.Trim() + " " + DateTime.Now.ToString("yyyy.MMM.dd HH_mm", CultureInfo.InvariantCulture);
        }

        private void tboxTask_TextChanged(object sender, EventArgs e)
        {
            var textboxSender = (TextBox)sender;
            var cursorPosition = textboxSender.SelectionStart;
            textboxSender.Text = Regex.Replace(textboxSender.Text, glm.fileRegex, "");
            textboxSender.SelectionStart = cursorPosition;

            lblFilename.Text = tboxFieldName.Text.Trim() + " " + tboxTask.Text.Trim()
                + " " + tboxVehicle.Text.Trim() + " " + DateTime.Now.ToString("yyyy.MMM.dd HH_mm", CultureInfo.InvariantCulture);
        }

        private void tboxVehicle_TextChanged(object sender, EventArgs e)
        {
            var textboxSender = (TextBox)sender;
            var cursorPosition = textboxSender.SelectionStart;
            textboxSender.Text = Regex.Replace(textboxSender.Text, glm.fileRegex, "");
            textboxSender.SelectionStart = cursorPosition;

            lblFilename.Text = tboxFieldName.Text.Trim() + " " + tboxTask.Text.Trim()
                + " " + tboxVehicle.Text.Trim() + " " + DateTime.Now.ToString("yyyy.MMM.dd HH_mm", CultureInfo.InvariantCulture);
        }

        private void btnSerialCancel_Click(object sender, EventArgs e)
        {
            Close();
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

            mf.currentFieldDirectory = tboxFieldName.Text.Trim() + " ";

            //task
            if (!String.IsNullOrEmpty(tboxTask.Text.Trim())) mf.currentFieldDirectory += tboxTask.Text.Trim() + " ";

            //vehicle
            if (!String.IsNullOrEmpty(tboxVehicle.Text.Trim())) mf.currentFieldDirectory += tboxVehicle.Text.Trim() + " ";

            //date
            mf.currentFieldDirectory += String.Format("{0}", DateTime.Now.ToString("yyyy.MMM.dd HH_mm", CultureInfo.InvariantCulture));

            //get the directory and make sure it exists, create if not
            string dirNewField = mf.fieldsDirectory + mf.currentFieldDirectory + "\\";

            mf.menustripLanguage.Enabled = false;

            // create from template
            string directoryName = Path.GetDirectoryName(dirNewField);

            if ((!string.IsNullOrEmpty(directoryName)) && (Directory.Exists(directoryName)))
            {
                MessageBox.Show(gStr.gsChooseADifferentName, gStr.gsDirectoryExists, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                //create the new directory
                if ((!string.IsNullOrEmpty(directoryName)) && (!Directory.Exists(directoryName)))
                { Directory.CreateDirectory(directoryName); }
            }

            string line;
            string offsets, convergence, startFix;

            using (StreamReader reader = new StreamReader(mf.fieldsDirectory + lblTemplateChosen.Text + "\\Field.txt"))
            {
                try
                {
                    line = reader.ReadLine();
                    line = reader.ReadLine();
                    line = reader.ReadLine();
                    line = reader.ReadLine();

                    //read the Offsets  - all we really need from template field file
                    offsets = reader.ReadLine();

                    line = reader.ReadLine();
                    convergence = reader.ReadLine();

                    line = reader.ReadLine();
                    startFix = reader.ReadLine();
                }
                catch (Exception ex)
                {
                    mf.WriteErrorLog("While Opening Field" + ex);

                    var form = new FormTimedMessage(2000, gStr.gsFieldFileIsCorrupt, gStr.gsChooseADifferentField);
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

                    writer.WriteLine("$Convergence");
                    writer.WriteLine(convergence);

                    writer.WriteLine("StartFix");
                    writer.WriteLine(startFix);
                }

                //create txt file copies
                string templateDirectoryName = (mf.fieldsDirectory + lblTemplateChosen.Text);
                string fileToCopy = "";
                string destinationDirectory = "";

                if (chkApplied.Checked)
                {
                     fileToCopy = templateDirectoryName + "\\Contour.txt";
                     destinationDirectory = directoryName + "\\Contour.txt";
                    if (File.Exists(fileToCopy))
                        File.Copy(fileToCopy, destinationDirectory);

                     fileToCopy = templateDirectoryName + "\\Sections.txt";
                     destinationDirectory = directoryName + "\\Sections.txt";
                    if (File.Exists(fileToCopy))
                        File.Copy(fileToCopy, destinationDirectory);
                }

                else
                {
                    //create blank Contour and Section files
                    mf.FileCreateSections();
                    mf.FileCreateContour();
                    //mf.FileCreateElevation();
                }

                 fileToCopy = templateDirectoryName + "\\Boundary.txt";
                 destinationDirectory = directoryName + "\\Boundary.txt";
                if (File.Exists(fileToCopy))
                    File.Copy(fileToCopy, destinationDirectory);

                if (chkFlags.Checked)
                {
                    fileToCopy = templateDirectoryName + "\\Flags.txt";
                    destinationDirectory = directoryName + "\\Flags.txt";
                    if (File.Exists(fileToCopy))
                        File.Copy(fileToCopy, destinationDirectory);
                }
                else
                {
                    mf.FileSaveFlags();
                }

                if (chkGuidanceLines.Checked)
                {
                    fileToCopy = templateDirectoryName + "\\ABLines.txt";
                    destinationDirectory = directoryName + "\\ABLines.txt";
                    if (File.Exists(fileToCopy))
                        File.Copy(fileToCopy, destinationDirectory);

                    fileToCopy = templateDirectoryName + "\\RecPath.txt";
                    destinationDirectory = directoryName + "\\RecPath.txt";
                    if (File.Exists(fileToCopy))
                        File.Copy(fileToCopy, destinationDirectory);

                    fileToCopy = templateDirectoryName + "\\CurveLines.txt";
                    destinationDirectory = directoryName + "\\CurveLines.txt";
                    if (File.Exists(fileToCopy))
                        File.Copy(fileToCopy, destinationDirectory);
                }
                else
                {
                    mf.FileSaveABLines();
                    mf.FileSaveCurveLines();
                }

                if (chkHeadland.Checked)
                {
                    fileToCopy = templateDirectoryName + "\\Headland.txt";
                    destinationDirectory = directoryName + "\\Headland.txt";
                    if (File.Exists(fileToCopy))
                        File.Copy(fileToCopy, destinationDirectory);
                }
                else
                    mf.FileSaveHeadland();

                //fileToCopy = templateDirectoryName + "\\Elevation.txt";
                //destinationDirectory = directoryName + "\\Elevation.txt";
                //if (File.Exists(fileToCopy))
                //    File.Copy(fileToCopy, destinationDirectory);

                //now open the newly cloned field
                mf.FileOpenField(dirNewField + myFileName);
                mf.Text = "AgOpenGPS - " + mf.currentFieldDirectory;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void tboxFieldName_Click(object sender, EventArgs e)
        {
            if (mf.isKeyboardOn)
            {
                mf.KeyboardToText((TextBox)sender);
                btnSerialCancel.Focus();
            }
        }

        private void tboxTask_Click(object sender, EventArgs e)
        {
            if (mf.isKeyboardOn)
            {
                mf.KeyboardToText((TextBox)sender);
                btnSerialCancel.Focus();
            }
        }

        private void tboxVehicle_Click(object sender, EventArgs e)
        {
            if (mf.isKeyboardOn)
            {
                mf.KeyboardToText((TextBox)sender);
                btnSerialCancel.Focus();
            }
        }
    }
}
