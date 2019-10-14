using System;
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

            btnOpenExistingLv.Text = gStr.gsUseSelected;
            btnJobOpen.Text = gStr.gsOpen;
            btnJobNew.Text = gStr.gsNew;
            btnJobResume.Text = gStr.gsResume;

            lblChoose.Text = gStr.gsSelectAField;
            label1.Text = gStr.gsLastFieldUsed;

            this.Text = gStr.gsStartNewField;
        }

        private void btnJobOpen_Click(object sender, EventArgs e)
        {

            timer1.Enabled = true;

            string[] dirs = Directory.GetDirectories(mf.fieldsDirectory);

            ListViewItem itm;

            foreach (string dir in dirs)
            {
                // fieldName = Path.GetDirectoryName(dir).ToString(CultureInfo.InvariantCulture);
                string fieldName = Path.GetFileName(dir);
                itm = new ListViewItem(fieldName);
                lvLines.Items.Add(itm);
            }

            if (lvLines.Items.Count > 0)
            {
                //ImageList imgList = new ImageList();
                //imgList.ImageSize = new System.Drawing.Size(1, 60);
                //lvLines.SmallImageList = imgList;

                ShowSavedPanel(true);
                lvLines.Items[lvLines.Items.Count - 1].EnsureVisible();
            }
            else
            {
                var form2 = new FormTimedMessage(2000, gStr.gsNoFieldsCreated, gStr.gsCreateNewFieldFirst);
                form2.Show();
                ShowSavedPanel(false);
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

            ShowSavedPanel(false);

        }

        private void ShowSavedPanel(bool showPanel)
        {
            if (showPanel)
            {
                this.Size = new System.Drawing.Size(915, 640);
                lvLines.Visible = true;
                lblChoose.Visible = true;

                btnJobNew.Visible = false;
                btnJobOpen.Visible = false;
                btnJobResume.Visible = false;
                label1.Visible = false;
                textBox1.Visible = false;
            }
            else
            {
                this.Size = new System.Drawing.Size(420, 640);
                lvLines.Visible = false;
                lblChoose.Visible = false;

                btnJobNew.Visible = true;
                btnJobOpen.Visible = true;
                btnJobResume.Visible = true;
                label1.Visible = true;
                textBox1.Visible = true;
            }
        }

        private void BtnOpenExistingLv_Click(object sender, EventArgs e)
        {
            int count = lvLines.SelectedItems.Count;
            if (count > 0)
            {
                mf.FileOpenField(mf.fieldsDirectory + lvLines.SelectedItems[0].SubItems[0].Text+"\\Field.txt");
                Close();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            int count = lvLines.SelectedItems.Count;
            if (count > 0)
            {
                btnOpenExistingLv.Enabled = true;
            }
            else
            {
                btnOpenExistingLv.Enabled = false;
            }

        }
    }
}