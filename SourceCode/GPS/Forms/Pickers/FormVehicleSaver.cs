using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormVehicleSaver : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        public FormVehicleSaver(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();

            //this.bntOK.Text = gStr.gsForNow;
            //this.btnSave.Text = gStr.gsToFile;

            this.Text = gStr.gsSaveVehicle;
        }

        private void FormFlags_Load(object sender, EventArgs e)
        {
            lblLast.Text = gStr.gsCurrent + mf.vehicleFileName;
            DirectoryInfo dinfo = new DirectoryInfo(mf.vehiclesDirectory);
            FileInfo[] Files = dinfo.GetFiles("*.xml");

            if (Files.Length == 0) cboxVeh.Enabled = false;

            foreach (FileInfo file in Files)
            {
                cboxVeh.Items.Add(Path.GetFileNameWithoutExtension(file.Name));
            }
        }

        private void cboxVeh_SelectedIndexChanged(object sender, EventArgs e)
        {
            DialogResult result3 = MessageBox.Show(
                "Overwrite: " + cboxVeh.SelectedItem.ToString() + ".xml",
                gStr.gsSaveAndReturn,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (result3 == DialogResult.Yes)
            {
                //mf.FileSaveVehicle(mf.vehiclesDirectory + cboxVeh.SelectedItem.ToString() + ".xml");
                SettingsIO.ExportAll(mf.vehiclesDirectory + cboxVeh.SelectedItem.ToString() + ".XML");
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
                //mf.FileSaveVehicle(mf.vehiclesDirectory + tboxName.Text.Trim() + ".xml");
                SettingsIO.ExportAll(mf.vehiclesDirectory + tboxName.Text.Trim() + ".XML");
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