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

        public FormFieldDir(Form _callingForm)
        {
            //get copy of the calling main form
            mf = _callingForm as FormGPS;

            InitializeComponent();

            label1.Text = gStr.gsEnterFieldName;
            label2.Text = gStr.gsDateWillBeAdded;
            label4.Text = gStr.gsEnterTask;
            label5.Text = gStr.gsEnterVehicleUsed;
            this.Text = gStr.gsCreateNewField;
        }

        private void FormFieldDir_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
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
            //if no template set just make a new file.
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

                    mf.worldGrid.CreateWorldGrid(0, 0);

                    mf.pn.latStart = mf.pn.latitude; mf.pn.lonStart = mf.pn.longitude;

                    mf.pn.SetLocalMetersPerDegree();


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