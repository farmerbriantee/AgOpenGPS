//Please, if you use this, share the improvements

using AgOpenGPS.Properties;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormSectionColor : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        public int[] customSectionColorsList = new int[16];

        private bool isUse = true, isChange = false;

        //constructor
        public FormSectionColor(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();

            //Language keys
            //this.Text = gStr.gsColors;

            string[] words = Properties.Settings.Default.setDisplay_customSectionColors.Split(',');
            for (int i = 0; i < 16; i++)
            {
                customSectionColorsList[i] = int.Parse(words[i], CultureInfo.InvariantCulture);
            }
        }

        private void FormDisplaySettings_Load(object sender, EventArgs e)
        {
            cb01.BackColor = Settings.Default.setColor_sec01;
            cb02.BackColor = Settings.Default.setColor_sec02;
            cb03.BackColor = Settings.Default.setColor_sec03;
            cb04.BackColor = Settings.Default.setColor_sec04;
            cb05.BackColor = Settings.Default.setColor_sec05;
            cb06.BackColor = Settings.Default.setColor_sec06;
            cb07.BackColor = Settings.Default.setColor_sec07;
            cb08.BackColor = Settings.Default.setColor_sec08;
            cb09.BackColor = Settings.Default.setColor_sec09;
            cb10.BackColor = Settings.Default.setColor_sec10;
            cb11.BackColor = Settings.Default.setColor_sec11;
            cb12.BackColor = Settings.Default.setColor_sec12;
            cb13.BackColor = Settings.Default.setColor_sec13;
            cb14.BackColor = Settings.Default.setColor_sec14;
            cb15.BackColor = Settings.Default.setColor_sec15;
            cb16.BackColor = Settings.Default.setColor_sec16;

            if (Settings.Default.setColor_isMultiColorSections) cboxIsMulti.Checked = true;
            else cboxIsMulti.Checked = false;

                btnC01.BackColor = Color.FromArgb(customSectionColorsList[0]);
                btnC02.BackColor = Color.FromArgb(customSectionColorsList[1]);
                btnC03.BackColor = Color.FromArgb(customSectionColorsList[2]);
                btnC04.BackColor = Color.FromArgb(customSectionColorsList[3]);
                btnC05.BackColor = Color.FromArgb(customSectionColorsList[4]);
                btnC06.BackColor = Color.FromArgb(customSectionColorsList[5]);
                btnC07.BackColor = Color.FromArgb(customSectionColorsList[6]);
                btnC08.BackColor = Color.FromArgb(customSectionColorsList[7]);
                btnC09.BackColor = Color.FromArgb(customSectionColorsList[8]);
                btnC10.BackColor = Color.FromArgb(customSectionColorsList[9]);
                btnC11.BackColor = Color.FromArgb(customSectionColorsList[10]);
                btnC12.BackColor = Color.FromArgb(customSectionColorsList[11]);
                btnC13.BackColor = Color.FromArgb(customSectionColorsList[12]);
                btnC14.BackColor = Color.FromArgb(customSectionColorsList[13]);
                btnC15.BackColor = Color.FromArgb(customSectionColorsList[14]);
                btnC16.BackColor = Color.FromArgb(customSectionColorsList[15]);

            if (!cboxIsMulti.Checked)
            {
                SetGui(false);
            }
        }

        private void SetGui(bool set)
        {
            btnC01.Enabled = set;
            btnC02.Enabled = set;
            btnC03.Enabled = set;
            btnC04.Enabled = set;
            btnC05.Enabled = set;
            btnC06.Enabled = set;
            btnC07.Enabled = set;
            btnC08.Enabled = set;
            btnC09.Enabled = set;
            btnC10.Enabled = set;
            btnC11.Enabled = set;
            btnC12.Enabled = set;
            btnC13.Enabled = set;
            btnC14.Enabled = set;
            btnC15.Enabled = set;
            btnC16.Enabled = set;

            cb01.Enabled = set;
            cb02.Enabled = set;
            cb03.Enabled = set;
            cb04.Enabled = set;
            cb05.Enabled = set;
            cb06.Enabled = set;
            cb07.Enabled = set;
            cb08.Enabled = set;
            cb09.Enabled = set;
            cb10.Enabled = set;
            cb11.Enabled = set;
            cb12.Enabled = set;
            cb13.Enabled = set;
            cb14.Enabled = set;
            cb15.Enabled = set;
            cb16.Enabled = set;

            chkUse.Enabled = set;

        }

        private void SaveCustomColor()
        {
            Properties.Settings.Default.setDisplay_customSectionColors = "";
            for (int i = 0; i < 15; i++)
                Properties.Settings.Default.setDisplay_customSectionColors += customSectionColorsList[i].ToString() + ",";
            Properties.Settings.Default.setDisplay_customSectionColors += customSectionColorsList[15].ToString();

            Properties.Settings.Default.Save();
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            mf.tool.secColors[0] = Settings.Default.setColor_sec01  = cb01.BackColor;
            mf.tool.secColors[1] = Settings.Default.setColor_sec02  = cb02.BackColor;
            mf.tool.secColors[2] = Settings.Default.setColor_sec03  = cb03.BackColor;
            mf.tool.secColors[3] = Settings.Default.setColor_sec04  = cb04.BackColor;
            mf.tool.secColors[4] = Settings.Default.setColor_sec05  = cb05.BackColor;
            mf.tool.secColors[5] = Settings.Default.setColor_sec06  = cb06.BackColor;
            mf.tool.secColors[6] = Settings.Default.setColor_sec07  = cb07.BackColor;
            mf.tool.secColors[7] = Settings.Default.setColor_sec08  = cb08.BackColor;
            mf.tool.secColors[8] = Settings.Default.setColor_sec09  = cb09.BackColor;
            mf.tool.secColors[9] = Settings.Default.setColor_sec10  = cb10.BackColor;
            mf.tool.secColors[10] = Settings.Default.setColor_sec11 = cb11.BackColor;
            mf.tool.secColors[11] = Settings.Default.setColor_sec12 = cb12.BackColor;
            mf.tool.secColors[12] = Settings.Default.setColor_sec13 = cb13.BackColor;
            mf.tool.secColors[13] = Settings.Default.setColor_sec14 = cb14.BackColor;
            mf.tool.secColors[14] = Settings.Default.setColor_sec15 = cb15.BackColor;
            mf.tool.secColors[15] = Settings.Default.setColor_sec16 = cb16.BackColor;

            if (cboxIsMulti.Checked)
                Settings.Default.setColor_isMultiColorSections = mf.tool.isMultiColoredSections = true;
            else Settings.Default.setColor_isMultiColorSections = mf.tool.isMultiColoredSections = false;

            Settings.Default.Save();
            Close();
        }

        private void chkUse_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUse.Checked)
            {
                groupBox1.Text = "Select Square Below And Pick New Color";
                chkUse.Image = Properties.Resources.ColorUnlocked;
                isChange = true;
                isUse = false;
            }
            else
            {
                isChange = false;
                isUse = false;
                groupBox1.Text = "Select Preset Color";
                chkUse.Image = Properties.Resources.ColorLocked;
            }

        }

        private void UpdateColor(Color col)
        {
            if (cb01.Checked) cb01.BackColor =      col;
            else if (cb02.Checked) cb02.BackColor = col;
            else if (cb03.Checked) cb03.BackColor = col;
            else if (cb04.Checked) cb04.BackColor = col;
            else if (cb05.Checked) cb05.BackColor = col;
            else if (cb06.Checked) cb06.BackColor = col;
            else if (cb07.Checked) cb07.BackColor = col;
            else if (cb08.Checked) cb08.BackColor = col;
            else if (cb09.Checked) cb09.BackColor = col;
            else if (cb10.Checked) cb10.BackColor = col;
            else if (cb11.Checked) cb11.BackColor = col;
            else if (cb12.Checked) cb12.BackColor = col;
            else if (cb13.Checked) cb13.BackColor = col;
            else if (cb14.Checked) cb14.BackColor = col;
            else if (cb15.Checked) cb15.BackColor = col;
            else if (cb16.Checked) cb16.BackColor = col;

            cb01.Checked =
                cb02.Checked =
                cb03.Checked =
                cb04.Checked =
                cb05.Checked =
                cb06.Checked =
                cb07.Checked =
                cb08.Checked =
                cb09.Checked =
                cb10.Checked =
                cb11.Checked =
                cb12.Checked =
                cb13.Checked =
                cb14.Checked =
                cb15.Checked =
                cb16.Checked = false;

            isUse = false;

        }

        private void btnC01_Click(object sender, EventArgs e)
        {
            Button butt = (Button)sender;
            if (isUse)
            {
                UpdateColor(butt.BackColor);
                isUse = false;
            }
            else if (isChange)
            {

                using (FormColorPicker form = new FormColorPicker(mf, butt.BackColor))
                {
                    int buttNumber;
                    int.TryParse((butt.Name.Substring(4,2)), out buttNumber);

                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        int iCol = (form.useThisColor.A << 24) | (form.useThisColor.R << 16) 
                            | (form.useThisColor.G << 8) | form.useThisColor.B;
                        (customSectionColorsList[buttNumber-1]) = iCol;
                        butt.BackColor = form.useThisColor;
                    }
                }

                SaveCustomColor();
                isChange = false;
            }
            chkUse.Checked = false;
        }

        private void cboxIsMulti_Click(object sender, EventArgs e)
        {
            if (cboxIsMulti.Checked) SetGui(true);
            else SetGui(false);
        }

        private void cb01_Click(object sender, EventArgs e)
        {
            CheckBox cbox = (CheckBox)sender;
            cb01.Checked =
            cb02.Checked =
            cb03.Checked =
            cb04.Checked =
            cb05.Checked =
            cb06.Checked =
            cb07.Checked =
            cb08.Checked =
            cb09.Checked =
            cb10.Checked =
            cb11.Checked =
            cb12.Checked =
            cb13.Checked =
            cb14.Checked =
            cb15.Checked =
            cb16.Checked = false;
            
            cbox.Checked = true;
            isUse = true;
            isChange = false;
        }
    }
}