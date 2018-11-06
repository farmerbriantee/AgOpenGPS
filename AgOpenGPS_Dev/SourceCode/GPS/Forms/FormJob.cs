using System;
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
        }

        private void btnJobOpen_Click(object sender, EventArgs e)
        {
            mf.FileOpenField("Open");

            //determine if field was actually opened
            if (mf.isJobStarted)
            {
                //back to FormGPS
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                //back to FormGPS
                DialogResult = DialogResult.Cancel;
                mf.JobClose();
                Close();
            }
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
                lblResumeDirectory.Text = "";
                btnJobResume.Enabled = false;
                mf.currentFieldDirectory = "";
                Properties.Settings.Default.setF_CurrentDir = "";
                Properties.Settings.Default.Save();
            }
            else
            {
                lblResumeDirectory.Text = mf.currentFieldDirectory;
            }
        }
    }
}
