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
                var form2 = new FormTimedMessage(2000, gStr.gsNo_Fields_Created_mess, gStr.gsCreate_New_Field_First);
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
            //Set language 
            Set_Language();
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
        //Set language 
        private void Set_Language()
        {
            btnJobOpen.Text = gStr.gsOpen_Existing;
            btnJobNew.Text = gStr.gsCreate_New;
            btnDeleteAB.Text = gStr.gsGo_Back;
            btnJobResume.Text = gStr.gsResume_Last;
            label1.Text = gStr.gsLast_Field_Used;
            chName.Text = gStr.gsField_Name;
            lblChoose.Text = gStr.gsSelect_Field;
            btnOpenExistingLv.Text = gStr.gsUse_Selected;
            Text = gStr.gsStart_Field;
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