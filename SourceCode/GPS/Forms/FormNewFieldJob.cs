using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormNewFieldJob : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        public FormNewFieldJob(Form _callingForm)
        {
            //get copy of the calling main form
            mf = _callingForm as FormGPS;

            InitializeComponent();

            //label1.Text = gStr.gsEnterFieldName;
            this.Text = gStr.gsCreateNewField;
        }

        private void FormFieldDir_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;

            try
            {
                string[] fDirs = Directory.GetDirectories(mf.fieldsDirectory);

                if (fDirs == null || fDirs.Length < 1)
                {
                    comboxFields.Visible = false;
                    label4.Visible = false; 
                    label1.Visible = false;
                }
                else
                {
                    foreach (string dir in fDirs)
                    {
                        comboxFields.Items.Add(new DirectoryInfo(dir).Name);
                    }

                    //if (mf.currentFieldDirectory == "")
                    //{
                    //    mf.currentFieldDirectory = comboxFields.Text;
                    //    comboxFields.Text = mf.currentFieldDirectory;
                    //}
                    //else
                    //{
                    //    //check if current field dir actually exists *TODO
                    //    comboxFields.Text = mf.currentFieldDirectory;
                    //}
                }
            }
            catch (Exception)
            {
                return;
                throw;
            }


        }

        private void tboxNewFieldName_TextChanged(object sender, EventArgs e)
        {
            TextBox textboxSender = (TextBox)sender;
            int cursorPosition = textboxSender.SelectionStart;
            textboxSender.Text = Regex.Replace(textboxSender.Text, glm.fileRegex, "");
            textboxSender.SelectionStart = cursorPosition;

            comboxFields.SelectedItem = null;

            if (String.IsNullOrEmpty(tboxJobName.Text.Trim()) || String.IsNullOrEmpty(tboxNewFieldName.Text.Trim()))
            {
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
            }
        }

        private void tboxJobName_TextChanged(object sender, EventArgs e)
        {
            TextBox textboxSender = (TextBox)sender;
            int cursorPosition = textboxSender.SelectionStart;
            textboxSender.Text = Regex.Replace(textboxSender.Text, glm.fileRegex, "");
            textboxSender.SelectionStart = cursorPosition;

            if (String.IsNullOrEmpty(tboxJobName.Text.Trim()))
            {
                btnSave.Enabled = false;
            }
            else
            {
                if (
                    (String.IsNullOrEmpty(tboxNewFieldName.Text.Trim()) && comboxFields.SelectedIndex != -1) ||
                    (!String.IsNullOrEmpty(tboxNewFieldName.Text.Trim()) && comboxFields.SelectedIndex == -1)
                    )
                    btnSave.Enabled = true;
                else
                    btnSave.Enabled = false;
            }

            //lblFilename.Text = tboxJobName.Text.Trim();
            //if (cboxAddDate.Checked) lblFilename.Text += " " + DateTime.Now.ToString("MMM.dd", CultureInfo.InvariantCulture);
            //if (cboxAddTime.Checked) lblFilename.Text += " " + DateTime.Now.ToString("HH_mm", CultureInfo.InvariantCulture);
        }

        private void btnSerialCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //field first
            if (String.IsNullOrEmpty(tboxNewFieldName.Text.Trim()))
            {
                if (String.IsNullOrEmpty(comboxFields.Text.Trim()))
                {
                    //everything blank
                    Close();
                    return;
                }
                else
                {
                    //using existing field dir from field combo box
                    mf.currentFieldDirectory = comboxFields.Text.Trim();
                }

            }
            else
            {
                //new field
                //create it for first save
                mf.currentFieldDirectory = tboxNewFieldName.Text.Trim() + " ";

                string dirNewField = mf.fieldsDirectory + mf.currentFieldDirectory + "\\";
                string directoryName = Path.GetDirectoryName(dirNewField);

                if ((!string.IsNullOrEmpty(directoryName)) && (Directory.Exists(directoryName)))
                {
                    MessageBox.Show(gStr.gsChooseADifferentName, gStr.gsDirectoryExists, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    //make sure directory exists, or create it
                    if ((!string.IsNullOrEmpty(directoryName)) && (!Directory.Exists(directoryName)))
                    { 
                        Directory.CreateDirectory(directoryName); 
                    }
                }
            }


            //fill something in
            if (String.IsNullOrEmpty(tboxJobName.Text.Trim()))
            {
                Close();
                return;
            }

            //append date time to name

            mf.currentJobDirectory = tboxJobName.Text.Trim() + " ";

            //date
            if (cboxAddDate.Checked) mf.currentJobDirectory += " " + DateTime.Now.ToString("MMM.dd", CultureInfo.InvariantCulture);
            if (cboxAddTime.Checked) mf.currentJobDirectory += " " + DateTime.Now.ToString("HH_mm", CultureInfo.InvariantCulture);

            //get the directory and make sure it exists, create if not
            string dirNewFieldJob = mf.fieldsDirectory + mf.currentFieldDirectory + "\\" + mf.currentJobDirectory + "\\";

            mf.menustripLanguage.Enabled = false;
            //if no template set just make a new file.
            try
            {
                //start a new job
                mf.JobNew();

                //create it for first save
                string directoryName = Path.GetDirectoryName(dirNewFieldJob);

                if ((!string.IsNullOrEmpty(directoryName)) && (Directory.Exists(directoryName)))
                {
                    MessageBox.Show(gStr.gsChooseADifferentName, gStr.gsDirectoryExists, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    mf.pn.latStart = mf.pn.latitude; mf.pn.lonStart = mf.pn.longitude;

                    mf.pn.SetLocalMetersPerDegree();


                    //make sure directory exists, or create it
                    if ((!string.IsNullOrEmpty(directoryName)) && (!Directory.Exists(directoryName)))
                    { Directory.CreateDirectory(directoryName); }

                    mf.displayJobName = mf.currentJobDirectory;
                    mf.displayFieldName = mf.currentFieldDirectory;

                    //create the field file header info
                    mf.FileCreateField();
                    mf.FileCreateSections();
                    mf.FileCreateRecPath();
                    mf.FileCreateContour();
                    mf.FileCreateElevation();
                    mf.FileSaveFlags();
                    mf.FileCreateBoundary();
                    //mf.FileSaveABLine();
                    //mf.FileSaveCurveLine();
                    //mf.FileSaveHeadland();
                }
            }
            catch (Exception ex)
            {
                mf.WriteErrorLog("Creating new field " + ex);

                MessageBox.Show(gStr.gsError, ex.ToString());
                mf.currentJobDirectory = "";
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void tboxJobName_Click(object sender, EventArgs e)
        {
            if (mf.isKeyboardOn)
            {
                mf.KeyboardToText((TextBox)sender, this);
                btnSerialCancel.Focus();
            }
        }

        private void comboxFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboxFields.SelectedIndex != -1)
            {
                mf.currentFieldDirectory = comboxFields.SelectedItem.ToString();
                tboxNewFieldName.TextChanged -= tboxNewFieldName_TextChanged;
                tboxNewFieldName.Text = "";
                tboxNewFieldName.TextChanged += tboxNewFieldName_TextChanged;

                if (String.IsNullOrEmpty(tboxJobName.Text.Trim()))
                {
                    btnSave.Enabled = false;
                }
                else
                {
                    btnSave.Enabled = true;
                }
            }
        }
    }
}