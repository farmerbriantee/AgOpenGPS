using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            mf.FileOpenField("");

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
            this.DialogResult = DialogResult.OK;
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

    }
}
