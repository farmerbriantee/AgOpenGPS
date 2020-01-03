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

        private void BtnOpenExistingLv_Click(object sender, EventArgs e)
        {
            //int count = lvLines.SelectedItems.Count;
            //if (count > 0)
            //{
            //    if (isOrderByName) mf.FileOpenField(mf.fieldsDirectory + lvLines.SelectedItems[0].SubItems[0].Text+"\\Field.txt");
            //    else mf.FileOpenField(mf.fieldsDirectory + lvLines.SelectedItems[0].SubItems[1].Text + "\\Field.txt");
            //    Close();
            //}
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
    }
}