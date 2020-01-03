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

        //private string templateFileAndDirectory;
        private bool isTemplateSet;

        public FormFieldDir(Form _callingForm)
        {
            //get copy of the calling main form
            mf = _callingForm as FormGPS;

            InitializeComponent();

            label1.Text = gStr.gsEnterFieldName;
            label2.Text = gStr.gsDateWillBeAdded;
            label3.Text = gStr.gsBasedOnField;
            label4.Text = gStr.gsEnterTask;
            label5.Text = gStr.gsEnterVehicleUsed;

            btnTemplate.Text = gStr.gsCloneFrom;

            this.Text = gStr.gsCreateNewField;
            lblTemplateChosen.Text = gStr.gsNoneUsed;

        }

        private void FormFieldDir_Load(object sender, EventArgs e)
        {
            btnTemplate.Enabled = false;
            btnSave.Enabled = false;
            lblTemplateChosen.Text = "None Selected";
            tboxVehicle.Text = mf.vehicleFileName + " " + mf.toolFileName;
            lblFilename.Text = "";
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

            lblFilename.Text = tboxFieldName.Text.Trim() + "_" + tboxTask.Text.Trim()
                + "_" + tboxVehicle.Text.Trim() + "_" + DateTime.Now.ToString("yyyy.MMM.dd HH_mm", CultureInfo.InvariantCulture);
        }

        private void tboxTask_TextChanged(object sender, EventArgs e)
        {
            var textboxSender = (TextBox)sender;
            var cursorPosition = textboxSender.SelectionStart;
            textboxSender.Text = Regex.Replace(textboxSender.Text, "[^0-9a-zA-Z ]", "");
            textboxSender.SelectionStart = cursorPosition;

            lblFilename.Text = tboxFieldName.Text.Trim() + "_" + tboxTask.Text.Trim() 
                + "_" + tboxVehicle.Text.Trim() + "_" + DateTime.Now.ToString("yyyy.MMM.dd HH_mm", CultureInfo.InvariantCulture);
        }

        private void tboxVehicle_TextChanged(object sender, EventArgs e)
        {
            var textboxSender = (TextBox)sender;
            var cursorPosition = textboxSender.SelectionStart;
            textboxSender.Text = Regex.Replace(textboxSender.Text, "[^0-9a-zA-Z ]", "");
            textboxSender.SelectionStart = cursorPosition;

            lblFilename.Text = tboxFieldName.Text.Trim() + "_" + tboxTask.Text.Trim()
                + "_" + tboxVehicle.Text.Trim() + "_" + DateTime.Now.ToString("yyyy.MMM.dd HH_mm", CultureInfo.InvariantCulture);
        }

        private void btnSerialCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            using (var form = new FormFilePicker( mf))
            {
                var result = form.ShowDialog();

                //returns full field.txt file dir name
                if (result == DialogResult.Yes)
                {
                    isTemplateSet = true;
                    lblTemplateChosen.Text = new DirectoryInfo(Path.GetDirectoryName(mf.filePickerFileAndDirectory)).Name;
                }
                else
                {
                    isTemplateSet = false;
                    mf.TimedMessageBox(1500, gStr.gsTemplateCancelled, gStr.gsYoucanstillstartnewfield);
                    return;
                }
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

            mf.currentFieldDirectory = tboxFieldName.Text.Trim() + "_";

            //task
            if (!String.IsNullOrEmpty(tboxTask.Text.Trim())) mf.currentFieldDirectory += tboxTask.Text.Trim() + "_";

            //vehicle
            if (!String.IsNullOrEmpty(tboxVehicle.Text.Trim())) mf.currentFieldDirectory += tboxVehicle.Text.Trim() + "_";

            //date
            mf.currentFieldDirectory += String.Format("{0}", DateTime.Now.ToString("yyyy.MMM.dd HH_mm", CultureInfo.InvariantCulture));

            //get the directory and make sure it exists, create if not
            string dirNewField = mf.fieldsDirectory + mf.currentFieldDirectory + "\\";

            mf.menustripLanguage.Enabled = false;
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
                        MessageBox.Show(gStr.gsChooseADifferentName, gStr.gsDirectoryExists, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    else
                    {
                        //reset the offsets
                        mf.pn.utmEast = (int)mf.pn.actualEasting;
                        mf.pn.utmNorth = (int)mf.pn.actualNorthing;

                        mf.worldGrid.CreateWorldGrid(0, 0);

                        //calculate the central meridian of current zone
                        mf.pn.centralMeridian = -177 + ((mf.pn.zone - 1) * 6);

                        //Azimuth Error - utm declination
                        mf.pn.convergenceAngle = Math.Atan(Math.Sin(glm.toRadians(mf.pn.latitude))
                                                    * Math.Tan(glm.toRadians(mf.pn.longitude - mf.pn.centralMeridian)));
                        mf.lblConvergenceAngle.Text = Math.Round(glm.toDegrees(mf.pn.convergenceAngle), 3).ToString();

                        //make sure directory exists, or create it
                        if ((!string.IsNullOrEmpty(directoryName)) && (!Directory.Exists(directoryName)))
                        { Directory.CreateDirectory(directoryName); }

                        //create the field file header info
                        mf.FileCreateField();
                        mf.FileCreateSections();
                        mf.FileCreateRecPath();
                        mf.FileCreateContour();
                        mf.FileCreateElevation();
                        mf.FileSaveFlags();
                        //mf.FileSaveABLine();
                        //mf.FileSaveCurveLine();
                        //mf.FileSaveHeadland();
                    }
                }
                catch (Exception ex)
                {
                    mf.WriteErrorLog("Creating new field " + ex);

                    MessageBox.Show(gStr.gsError, ex.ToString());
                    mf.currentFieldDirectory = "";
                }
            }
            else
            {
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

                using (StreamReader reader = new StreamReader(mf.filePickerFileAndDirectory))
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

                    //create blank Contour and Section files
                    mf.FileCreateSections();
                    mf.FileCreateContour();
                    //mf.FileCreateElevation();

                    //copy over the files from template
                    string templateDirectoryName = Path.GetDirectoryName(mf.filePickerFileAndDirectory);

                    string fileToCopy = templateDirectoryName + "\\Boundary.txt";
                    string destinationDirectory = directoryName + "\\Boundary.txt";
                    if (File.Exists(fileToCopy))
                        File.Copy(fileToCopy, destinationDirectory);

                    fileToCopy = templateDirectoryName + "\\Elevation.txt";
                    destinationDirectory = directoryName + "\\Elevation.txt";
                    if (File.Exists(fileToCopy))
                        File.Copy(fileToCopy, destinationDirectory);

                    fileToCopy = templateDirectoryName + "\\Flags.txt";
                    destinationDirectory = directoryName + "\\Flags.txt";
                    if (File.Exists(fileToCopy))
                        File.Copy(fileToCopy, destinationDirectory);

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

                    //now open the newly cloned field
                    mf.FileOpenField(dirNewField + myFileName);
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}