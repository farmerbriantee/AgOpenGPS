using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AgOpenGPS
{
    public partial class FormJob : Form
    {
        //class variables
        private FormGPS mf = null;


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
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnJobNew_Click(object sender, EventArgs e)
        {
            //start a new job
            mf.JobNew();

            //back to FormGPS
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnJobResume_Click(object sender, EventArgs e)
        {
            //open the Resume.txt and continue from last exit
            mf.FileOpenField("Resume");

            //back to FormGPS
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormJob_Load(object sender, EventArgs e)
        {
            //check if directory and file exists, maybe was deleted etc
            if (String.IsNullOrEmpty(mf.currentFieldDirectory)) btnJobResume.Enabled = false;
            string directoryName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                + "\\AgOpenGPS\\Fields\\" + mf.currentFieldDirectory + "\\";

            string fileAndDirectory = directoryName + "Field.fld";

            if (!File.Exists(fileAndDirectory))
            {
                btnJobResume.Enabled = false;
                mf.currentFieldDirectory = "";
                Properties.Settings.Default.setCurrentDir = "";
                Properties.Settings.Default.Save();
            }
 
        }

    }
}
