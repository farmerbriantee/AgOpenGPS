using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AgIO
{
    public partial class FormCommSaver : Form
    {
        //class variables
        private readonly FormLoop mf = null;

        public FormCommSaver(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormLoop;
            InitializeComponent();
        }

        private void FormCommSaver_Load(object sender, EventArgs e)
        {
            lblLast.Text = "Current " + mf.commFileName;
            DirectoryInfo dinfo = new DirectoryInfo(mf.commDirectory);
            FileInfo[] Files = dinfo.GetFiles("*.xml");

            if (Files.Length == 0)
            {
                cboxEnv.Enabled = false;
            }

            foreach (FileInfo file in Files)
            {
                cboxEnv.Items.Add(Path.GetFileNameWithoutExtension(file.Name));
            }
        }

        private void cboxVeh_SelectedIndexChanged(object sender, EventArgs e)
        {
            DialogResult result3 = MessageBox.Show(
                "Overwrite: " + cboxEnv.SelectedItem.ToString() + ".xml",
                "Save And Return",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result3 == DialogResult.Yes)
            {
                SettingsIO.ExportSettings(mf.commDirectory + cboxEnv.SelectedItem.ToString() + ".xml");
                Close();
            }
        }

        private void tboxName_TextChanged(object sender, EventArgs e)
        {
            TextBox textboxSender = (TextBox)sender;
            int cursorPosition = textboxSender.SelectionStart;
            textboxSender.Text = Regex.Replace(textboxSender.Text, glm.fileRegex, "");

            textboxSender.SelectionStart = cursorPosition;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tboxName.Text.Trim().Length > 0)
            {
                SettingsIO.ExportSettings(mf.commDirectory + tboxName.Text.Trim() + ".xml");
                Close();
            }
            else
            {
                _ = MessageBox.Show("Enter a File Name To Save...",
                "Save And Return", MessageBoxButtons.OK);
            }
        }

        private void tboxName_Click(object sender, EventArgs e)
        {
            if (mf.isKeyboardOn)
            {
                mf.KeyboardToText((TextBox)sender, this);
                btnSave.Focus();
            }
        }

        private void btnSerialCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}