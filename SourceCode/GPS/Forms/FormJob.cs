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

        private bool isOrderByName;

        private List<string> fileList = new List<string>();

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
            isOrderByName = true;
        }

        private void btnJobOpen_Click(object sender, EventArgs e)
        {

            timer1.Enabled = true;
            ListViewItem itm;

            string[] dirs = Directory.GetDirectories(mf.fieldsDirectory);

            fileList?.Clear();

            foreach (string dir in dirs)
            {
                double latStart=0;
                double lonStart=0;
                double distance=0;
                string fieldDirectory = Path.GetFileName(dir);
                string filename = dir + "\\Field.txt";
                string line;
                using (StreamReader reader = new StreamReader(filename))
                {
                    try
                    {
                        //Date time line
                        for (int i = 0; i < 8; i++)
                        {
                            line = reader.ReadLine();
                        }

                        //start positions
                        if (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();
                            string[] offs = line.Split(',');

                            latStart = (double.Parse(offs[0], CultureInfo.InvariantCulture));
                            lonStart = (double.Parse(offs[1], CultureInfo.InvariantCulture));
                        }
                    }

                    catch (Exception er)
                    {
                        var form = new FormTimedMessage(2000, gStr.gsFieldFileIsCorrupt, gStr.gsChooseADifferentField);
                    }
                }

                distance = Math.Pow((latStart - mf.pn.latitude), 2) + Math.Pow((lonStart - mf.pn.longitude), 2);
                distance = Math.Sqrt(distance);
                distance *= 100;

                fileList.Add(fieldDirectory);
                fileList.Add(distance.ToString("00.###"));

            }

           
            for (int i = 0; i < fileList.Count; i += 2)
            {
                string[] fieldNames = { fileList[i], fileList[i + 1] };
                itm = new ListViewItem(fieldNames);
                lvLines.Items.Add(itm);                
            }

            //string fieldName = Path.GetDirectoryName(dir).ToString(CultureInfo.InvariantCulture);

            if (lvLines.Items.Count > 0)
            {
                this.chName.Text = "Field Name";
                this.chName.Width = 750;

                this.chDistance.Text = "Distance";
                this.chDistance.Width = 150;


                //ImageList imgList = new ImageList();
                //imgList.ImageSize = new System.Drawing.Size(1, 60);
                //lvLines.SmallImageList = imgList;

                ShowSavedPanel(true);
                //lvLines.Items[lvLines.Items.Count - 1].EnsureVisible();
            }
            else
            {
                var form2 = new FormTimedMessage(2000, gStr.gsNoFieldsCreated, gStr.gsCreateNewFieldFirst);
                form2.Show();
                ShowSavedPanel(false);
            }
        }
        private void btnByDistance_Click(object sender, EventArgs e)
        {
            ListViewItem itm;

            lvLines.Items.Clear();
            isOrderByName = !isOrderByName;

            for (int i = 0; i < fileList.Count; i += 2)
            {
                if (isOrderByName)
                {
                    string[] fieldNames = { fileList[i], fileList[i + 1] };
                    itm = new ListViewItem(fieldNames);
                }
                else
                {
                    string[] fieldNames = { fileList[i + 1], fileList[i] };
                    itm = new ListViewItem(fieldNames);
                }
                lvLines.Items.Add(itm);
            }

            //string fieldName = Path.GetDirectoryName(dir).ToString(CultureInfo.InvariantCulture);

            if (lvLines.Items.Count > 0)
            {
                if (isOrderByName)
                {
                    this.chName.Text = "Field Name";
                    this.chName.Width = 750;

                    this.chDistance.Text = "Distance";
                    this.chDistance.Width = 150;
                }
                else
                {
                    this.chName.Text = "Dist";
                    this.chName.Width = 150;

                    this.chDistance.Text = "Field Name";
                    this.chDistance.Width = 750;
                }
            }

        }

        private void BtnOpenExistingLv_Click(object sender, EventArgs e)
        {
            int count = lvLines.SelectedItems.Count;
            if (count > 0)
            {
                if (isOrderByName) mf.FileOpenField(mf.fieldsDirectory + lvLines.SelectedItems[0].SubItems[0].Text+"\\Field.txt");
                else mf.FileOpenField(mf.fieldsDirectory + lvLines.SelectedItems[0].SubItems[1].Text + "\\Field.txt");
                Close();
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
                this.Size = new System.Drawing.Size(942, 640);
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