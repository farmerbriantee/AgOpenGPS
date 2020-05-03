using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormToolSaver : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        public FormToolSaver(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();

            //this.bntOK.Text = gStr.gsForNow;
            //this.btnSave.Text = gStr.gsToFile;

            this.Text = gStr.gsSaveTool;
        }

        private void FormFlags_Load(object sender, EventArgs e)
        {
            lblLast.Text = gStr.gsCurrent + mf.toolFileName;
            DirectoryInfo dinfo = new DirectoryInfo(mf.toolsDirectory);
            FileInfo[] Files = dinfo.GetFiles("*.txt");

            if (Files.Length == 0) cboxTool.Enabled = false;

            foreach (FileInfo file in Files)
            {
                cboxTool.Items.Add(Path.GetFileNameWithoutExtension(file.Name));
            }
        }

        private void cboxVeh_SelectedIndexChanged(object sender, EventArgs e)
        {
            DialogResult result3 = MessageBox.Show(
                "Overwrite: " + cboxTool.SelectedItem.ToString() + ".txt",
                gStr.gsSaveAndReturn,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (result3 == DialogResult.Yes)
            {
                mf.FileSaveTool(mf.toolsDirectory + cboxTool.SelectedItem.ToString() + ".txt");
                Close();
            }
        }

        private void tboxName_TextChanged(object sender, EventArgs e)
        {
            var textboxSender = (TextBox)sender;
            var cursorPosition = textboxSender.SelectionStart;
            textboxSender.Text = Regex.Replace(textboxSender.Text, glm.fileRegex, "");

            textboxSender.SelectionStart = cursorPosition;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tboxName.Text.Trim().Length > 0)
            {
                mf.FileSaveTool(mf.toolsDirectory + tboxName.Text.Trim() + ".txt");
                Close();
            }
        }

        private void tboxName_Click(object sender, EventArgs e)
        {
            if (mf.isKeyboardOn)
            {
                mf.KeyboardToText((TextBox)sender);
                btnSave.Focus();
            }
        }
    }
}