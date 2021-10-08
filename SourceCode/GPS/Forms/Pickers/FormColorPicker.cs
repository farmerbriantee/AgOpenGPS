using MechanikaDesign.WinForms.UI.ColorPicker;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormColorPicker : Form
    {
        //class variables
        private readonly FormGPS mf = null;
        private readonly Color inColor;
        public Color useThisColor { get; set; }

        private bool isUse = true;

        private HslColor colorHsl = HslColor.FromAhsl(0xff);
        private Color colorRgb = Color.Empty;


        public FormColorPicker(Form callingForm, Color _inColor)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();

            inColor = _inColor;

            btnNight.BackColor = inColor;
            btnDay.BackColor = inColor;

            useThisColor = inColor;

            UpdateColor(inColor);


            //this.bntOK.Text = gStr.gsForNow;
            //this.btnSave.Text = gStr.gsToFile;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void colorBox2D_ColorChanged(object sender, ColorChangedEventArgs args)
        {
            HslColor colorHSL = this.colorBox2D.ColorHSL;
            this.colorHsl = colorHSL;
            this.colorRgb = this.colorHsl.RgbValue;
            this.colorSlider.ColorHSL = this.colorHsl;

            useThisColor = colorRgb;
            btnNight.BackColor = colorRgb;
            btnDay.BackColor = colorRgb;
        }
        private void colorSlider_ColorChanged(object sender, MechanikaDesign.WinForms.UI.ColorPicker.ColorChangedEventArgs args)
        {
            HslColor colorHSL = this.colorSlider.ColorHSL;
            this.colorHsl = colorHSL;
            this.colorRgb = this.colorHsl.RgbValue;
            this.colorBox2D.ColorHSL = this.colorHsl;

            useThisColor = colorRgb;
            btnNight.BackColor = colorRgb;
            btnDay.BackColor = colorRgb;
        }

        private void UpdateColor(Color col)
        {
            this.colorHsl = HslColor.FromColor(col);
            this.colorRgb = col;
            //this.lockUpdates = true;
            //this.numHue.Value = (int)(((decimal)this.colorHsl.H) * 360M);
            //this.numSaturation.Value = (int)(((decimal)this.colorHsl.S) * 100M);
            //this.numLuminance.Value = (int)(((decimal)this.colorHsl.L) * 100M);
            //this.lockUpdates = false;
            this.colorSlider.ColorHSL = this.colorHsl;
            this.colorBox2D.ColorHSL = this.colorHsl;

            useThisColor = col;
            btnNight.BackColor = col;
            btnDay.BackColor = col;
        }



        private void FormColorPicker_Load(object sender, EventArgs e)
        {
            //Properties.Settings.Default.setDisplay_customColors = "";
            {
                btn00.BackColor = Color.FromArgb(mf.customColorsList[0]);
                btn01.BackColor = Color.FromArgb(mf.customColorsList[1]);
                btn02.BackColor = Color.FromArgb(mf.customColorsList[2]);
                btn03.BackColor = Color.FromArgb(mf.customColorsList[3]);
                btn04.BackColor = Color.FromArgb(mf.customColorsList[4]);
                btn05.BackColor = Color.FromArgb(mf.customColorsList[5]);
                btn06.BackColor = Color.FromArgb(mf.customColorsList[6]);
                btn07.BackColor = Color.FromArgb(mf.customColorsList[7]);
                btn08.BackColor = Color.FromArgb(mf.customColorsList[8]);
                btn09.BackColor = Color.FromArgb(mf.customColorsList[9]);
                btn10.BackColor = Color.FromArgb(mf.customColorsList[10]);
                btn11.BackColor = Color.FromArgb(mf.customColorsList[11]);
                btn12.BackColor = Color.FromArgb(mf.customColorsList[12]);
                btn13.BackColor = Color.FromArgb(mf.customColorsList[13]);
                btn14.BackColor = Color.FromArgb(mf.customColorsList[14]);
                btn15.BackColor = Color.FromArgb(mf.customColorsList[15]);
            }
        }

        private void SaveCustomColor()
        {
            Properties.Settings.Default.setDisplay_customColors = "";
            for (int i = 0; i < 15; i++)
                Properties.Settings.Default.setDisplay_customColors += mf.customColorsList[i].ToString() + ",";
            Properties.Settings.Default.setDisplay_customColors += mf.customColorsList[15].ToString();

            Properties.Settings.Default.Save();
        }

        private void btn00_Click(object sender, EventArgs e)
        {
            if (isUse)
            {
                useThisColor = btn00.BackColor;
                UpdateColor(useThisColor);
            }
            else
            {
                int iCol = (useThisColor.A << 24) | (useThisColor.R << 16) | (useThisColor.G << 8) | useThisColor.B;
                (mf.customColorsList[00]) = iCol;
                btn00.BackColor = useThisColor;
                SaveCustomColor();
            }
        }
        private void btn01_Click(object sender, EventArgs e)
        {
            if (isUse)
            {
                useThisColor = btn01.BackColor;
                UpdateColor(useThisColor);
            }
            else
            {
                int iCol = (useThisColor.A << 24) | (useThisColor.R << 16) | (useThisColor.G << 8) | useThisColor.B;
                (mf.customColorsList[01]) = iCol;
                btn01.BackColor = useThisColor;
                SaveCustomColor();
            }
        }

        private void btn02_Click(object sender, EventArgs e)
        {
            if (isUse)
            {
                useThisColor = btn02.BackColor;
                UpdateColor(useThisColor);
            }
            else
            {
                // To integer
                int iCol = (useThisColor.A << 24) | (useThisColor.R << 16) | (useThisColor.G << 8) | useThisColor.B;
                (mf.customColorsList[02]) = iCol;
                btn02.BackColor = useThisColor;
                SaveCustomColor();
            }
        }

        private void btn03_Click(object sender, EventArgs e)
        {
            if (isUse)
            {
                useThisColor = btn03.BackColor;
                UpdateColor(useThisColor);
            }
            else
            {
                int iCol = (useThisColor.A << 24) | (useThisColor.R << 16) | (useThisColor.G << 8) | useThisColor.B;
                (mf.customColorsList[03]) = iCol;
                btn03.BackColor = useThisColor;
                SaveCustomColor();
            }
        }

        private void btn04_Click(object sender, EventArgs e)
        {
            if (isUse)
            {
                useThisColor = btn04.BackColor;
                UpdateColor(useThisColor);
            }
            else
            {
                int iCol = (useThisColor.A << 24) | (useThisColor.R << 16) | (useThisColor.G << 8) | useThisColor.B;
                (mf.customColorsList[04]) = iCol;
                btn04.BackColor = useThisColor;
                SaveCustomColor();
            }
        }

        private void btn05_Click(object sender, EventArgs e)
        {
            if (isUse)
            {
                useThisColor = btn05.BackColor;
                UpdateColor(useThisColor);
            }
            else
            {
                int iCol = (useThisColor.A << 24) | (useThisColor.R << 16) | (useThisColor.G << 8) | useThisColor.B;
                (mf.customColorsList[05]) = iCol;
                btn05.BackColor = useThisColor;
                SaveCustomColor();
            }
        }

        private void btn06_Click(object sender, EventArgs e)
        {
            if (isUse)
            {
                useThisColor = btn06.BackColor;
                UpdateColor(useThisColor);
            }
            else
            {
                int iCol = (useThisColor.A << 24) | (useThisColor.R << 16) | (useThisColor.G << 8) | useThisColor.B;
                (mf.customColorsList[06]) = iCol;
                btn06.BackColor = useThisColor;
                SaveCustomColor();
            }
        }

        private void btn07_Click(object sender, EventArgs e)
        {
            if (isUse)
            {
                useThisColor = btn07.BackColor;
                UpdateColor(useThisColor);
            }
            else
            {
                int iCol = (useThisColor.A << 24) | (useThisColor.R << 16) | (useThisColor.G << 8) | useThisColor.B;
                (mf.customColorsList[07]) = iCol;
                btn07.BackColor = useThisColor;
                SaveCustomColor();
            }
        }

        private void btn08_Click(object sender, EventArgs e)
        {
            if (isUse)
            {
                useThisColor = btn08.BackColor;
                UpdateColor(useThisColor);
            }
            else
            {
                int iCol = (useThisColor.A << 24) | (useThisColor.R << 16) | (useThisColor.G << 8) | useThisColor.B;
                (mf.customColorsList[08]) = iCol;
                btn08.BackColor = useThisColor;
                SaveCustomColor();
            }
        }

        private void btn09_Click(object sender, EventArgs e)
        {
            if (isUse)
            {
                useThisColor = btn09.BackColor;
                UpdateColor(useThisColor);
            }
            else
            {
                int iCol = (useThisColor.A << 24) | (useThisColor.R << 16) | (useThisColor.G << 8) | useThisColor.B;
                (mf.customColorsList[09]) = iCol;
                btn09.BackColor = useThisColor;
                SaveCustomColor();
            }
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            if (isUse)
            {
                useThisColor = btn10.BackColor;
                UpdateColor(useThisColor);
            }
            else
            {
                int iCol = (useThisColor.A << 24) | (useThisColor.R << 16) | (useThisColor.G << 8) | useThisColor.B;
                (mf.customColorsList[10]) = iCol;
                btn10.BackColor = useThisColor;
                SaveCustomColor();
            }
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            if (isUse)
            {
                useThisColor = btn11.BackColor;
                UpdateColor(useThisColor);
            }
            else
            {
                int iCol = (useThisColor.A << 24) | (useThisColor.R << 16) | (useThisColor.G << 8) | useThisColor.B;
                (mf.customColorsList[11]) = iCol;
                btn11.BackColor = useThisColor;
                SaveCustomColor();
            }
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            if (isUse)
            {
                useThisColor = btn12.BackColor;
                UpdateColor(useThisColor);
            }
            else
            {
                int iCol = (useThisColor.A << 24) | (useThisColor.R << 16) | (useThisColor.G << 8) | useThisColor.B;
                (mf.customColorsList[12]) = iCol;
                btn12.BackColor = useThisColor;
                SaveCustomColor();
            }
        }

        private void btn13_Click(object sender, EventArgs e)
        {
            if (isUse)
            {
                useThisColor = btn13.BackColor;
                UpdateColor(useThisColor);
            }
            else
            {
                int iCol = (useThisColor.A << 24) | (useThisColor.R << 16) | (useThisColor.G << 8) | useThisColor.B;
                (mf.customColorsList[13]) = iCol;
                btn13.BackColor = useThisColor;
                SaveCustomColor();
            }
        }

        private void btn14_Click(object sender, EventArgs e)
        {
            if (isUse)
            {
                useThisColor = btn14.BackColor;
                UpdateColor(useThisColor);
            }
            else
            {
                int iCol = (useThisColor.A << 24) | (useThisColor.R << 16) | (useThisColor.G << 8) | useThisColor.B;
                (mf.customColorsList[14]) = iCol;
                btn14.BackColor = useThisColor;
                SaveCustomColor();
            }
        }

        private void btn15_Click(object sender, EventArgs e)
        {
            if (isUse)
            {
                useThisColor = btn15.BackColor;
                UpdateColor(useThisColor);
            }
            else
            {
                int iCol = (useThisColor.A << 24) | (useThisColor.R << 16) | (useThisColor.G << 8) | useThisColor.B;
                (mf.customColorsList[15]) = iCol;
                btn15.BackColor = useThisColor;
                SaveCustomColor();
            }
        }
        private void chkUse_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUse.Checked)
            {
                groupBox1.Text = "Pick New Color and Select Square Below to Save Preset";
                chkUse.Image = Properties.Resources.ColorUnlocked;
                isUse = false;
            }
            else
            {
                isUse = true;
                groupBox1.Text = "Select Preset Color";
                chkUse.Image = Properties.Resources.ColorLocked;
            }
        }
    }
}