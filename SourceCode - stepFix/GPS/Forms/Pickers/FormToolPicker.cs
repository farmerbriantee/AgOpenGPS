using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormToolPicker : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        public FormToolPicker(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();

            this.Text = gStr.gsLoadTool;
        }

        private void FormFlags_Load(object sender, EventArgs e)
        {
            lblLast.Text = gStr.gsCurrent + mf.toolFileName;

            DirectoryInfo dinfo = new DirectoryInfo(mf.toolsDirectory);
            FileInfo[] Files = dinfo.GetFiles("*.txt");
            if (Files.Length == 0)
            {
                Close();
                var form = new FormTimedMessage(2000, gStr.gsNoToolSaved, gStr.gsSaveAToolFirst);
                form.Show();

            }

            foreach (FileInfo file in Files)
            {
                cboxTool.Items.Add(Path.GetFileNameWithoutExtension(file.Name));
            }
        }

        private void cboxVeh_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.FileOpenTool(mf.toolsDirectory + cboxTool.SelectedItem.ToString() + ".txt");
            Close();
        }
    }
}