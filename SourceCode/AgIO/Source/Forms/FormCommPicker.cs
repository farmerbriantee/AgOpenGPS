using System;
using System.IO;
using System.Windows.Forms;

namespace AgIO
{
    public partial class FormCommPicker : Form
    {
        //class variables
        private readonly FormLoop mf = null;

        public FormCommPicker(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormLoop;
            InitializeComponent();

            //this.bntOK.Text = gStr.gsForNow;
            //this.btnSave.Text = gStr.gsToFile;

            //this.Text = gStr.gsLoadComm;
        }

        private void FormCommPicker_Load(object sender, EventArgs e)
        {
            DirectoryInfo dinfo = new DirectoryInfo(mf.commDirectory);
            FileInfo[] Files = dinfo.GetFiles("*.xml");
            if (Files.Length == 0)
            {
                DialogResult = DialogResult.Ignore;
                Close();
                FormTimedMessage form = new FormTimedMessage(2000, "Non Saved", "Save one First");
                form.Show();
            }

            else
            {
                foreach (FileInfo file in Files)
                {
                    cboxEnv.Items.Add(Path.GetFileNameWithoutExtension(file.Name));
                }
            }
        }

        private void cboxVeh_SelectedIndexChanged(object sender, EventArgs e)
        {
            SettingsIO.ImportSettings(mf.commDirectory + cboxEnv.SelectedItem.ToString() + ".xml");

            Close();

            //mf.LoadSettings();
        }
    }
}