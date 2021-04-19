using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormVehiclePicker : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        public FormVehiclePicker(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();

            //this.bntOK.Text = gStr.gsForNow;
            //this.btnSave.Text = gStr.gsToFile;

            this.Text = gStr.gsLoadVehicle;
        }

        private void FormFlags_Load(object sender, EventArgs e)
        {
            lblLast.Text = gStr.gsCurrent + mf.vehicleFileName;
            DirectoryInfo dinfo = new DirectoryInfo(mf.vehiclesDirectory);
            FileInfo[] Files = dinfo.GetFiles("*.xml");
            if (Files.Length == 0)
            {
                Close();
                var form = new FormTimedMessage(2000, gStr.gsNoVehiclesSaved, gStr.gsSaveAVehicleFirst);
                form.Show();

            }

            foreach (FileInfo file in Files)
            {
                cboxVeh.Items.Add(Path.GetFileNameWithoutExtension(file.Name));
            }
        }

        private void cboxVeh_SelectedIndexChanged(object sender, EventArgs e)
        {
            //mf.FileOpenVehicle(mf.vehiclesDirectory + cboxVeh.SelectedItem.ToString() + ".xml");
            SettingsIO.ImportAll( mf.vehiclesDirectory + cboxVeh.SelectedItem.ToString() + ".XML");

            mf.LoadSettings();
            Close();
        }
    }
}