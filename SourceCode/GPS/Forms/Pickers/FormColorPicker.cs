using MechanikaDesign.WinForms.UI.ColorPicker;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

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

            //Properties.Settings.Default.setDisplay_customColors += mf.customColorsList[i].ToString() + ",";
            //Properties.Settings.Default.setDisplay_customColors += mf.customColorsList[15].ToString();

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

namespace MechanikaDesign.WinForms.UI.ColorPicker
{
    [DefaultEvent("ColorChanged")]
    public class ColorBox2D : UserControl
    {
        private HslColor colorHSL;
        private ColorModes colorMode;
        private Color colorRGB = Color.Empty;
        private Point markerPoint = Point.Empty;
        private bool mouseMoving;
        private IContainer components = (IContainer)null;

        public event ColorBox2D.ColorChangedEventHandler ColorChanged;

        public ColorModes ColorMode
        {
            get => this.colorMode;
            set
            {
                this.colorMode = value;
                this.ResetMarker();
                this.Refresh();
            }
        }

        public HslColor ColorHSL
        {
            get => this.colorHSL;
            set
            {
                this.colorHSL = value;
                this.colorRGB = this.colorHSL.RgbValue;
                this.ResetMarker();
                this.Refresh();
            }
        }

        public Color ColorRGB
        {
            get => this.colorRGB;
            set
            {
                this.colorRGB = value;
                this.colorHSL = HslColor.FromColor(this.colorRGB);
                this.ResetMarker();
                this.Refresh();
            }
        }

        public ColorBox2D()
        {
            this.InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.colorHSL = HslColor.FromAhsl(1.0, 1.0, 1.0);
            this.colorRGB = this.colorHSL.RgbValue;
            this.colorMode = ColorModes.Hue;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.mouseMoving = true;
            this.SetMarker(e.X, e.Y);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!this.mouseMoving)
                return;
            this.SetMarker(e.X, e.Y);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.mouseMoving = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            HslColor hslColor1 = HslColor.FromAhsl((int)byte.MaxValue);
            HslColor hslColor2 = HslColor.FromAhsl((int)byte.MaxValue);
            switch (this.ColorMode)
            {
                case ColorModes.Hue:
                    ref HslColor local1 = ref hslColor1;
                    HslColor colorHsl1 = this.ColorHSL;
                    double h1 = colorHsl1.H;
                    local1.H = h1;
                    ref HslColor local2 = ref hslColor2;
                    colorHsl1 = this.ColorHSL;
                    double h2 = colorHsl1.H;
                    local2.H = h2;
                    hslColor1.S = 0.0;
                    hslColor2.S = 1.0;
                    break;
                case ColorModes.Saturation:
                    ref HslColor local3 = ref hslColor1;
                    HslColor colorHsl2 = this.ColorHSL;
                    double s1 = colorHsl2.S;
                    local3.S = s1;
                    ref HslColor local4 = ref hslColor2;
                    colorHsl2 = this.ColorHSL;
                    double s2 = colorHsl2.S;
                    local4.S = s2;
                    hslColor1.L = 1.0;
                    hslColor2.L = 0.0;
                    break;
                case ColorModes.Luminance:
                    ref HslColor local5 = ref hslColor1;
                    HslColor colorHsl3 = this.ColorHSL;
                    double l1 = colorHsl3.L;
                    local5.L = l1;
                    ref HslColor local6 = ref hslColor2;
                    colorHsl3 = this.ColorHSL;
                    double l2 = colorHsl3.L;
                    local6.L = l2;
                    hslColor1.S = 1.0;
                    hslColor2.S = 0.0;
                    break;
            }
            for (int index = 0; index < this.Height - 4; ++index)
            {
                int green = MathExtensions.Round((double)byte.MaxValue - (double)byte.MaxValue * (double)index / (double)(this.Height - 4));
                Color color1 = Color.Empty;
                Color color2 = Color.Empty;
                switch (this.ColorMode)
                {
                    case ColorModes.Red:
                        Color colorRgb1 = this.ColorRGB;
                        color1 = Color.FromArgb((int)colorRgb1.R, green, 0);
                        colorRgb1 = this.ColorRGB;
                        color2 = Color.FromArgb((int)colorRgb1.R, green, (int)byte.MaxValue);
                        break;
                    case ColorModes.Green:
                        int red1 = green;
                        Color colorRgb2 = this.ColorRGB;
                        int g1 = (int)colorRgb2.G;
                        color1 = Color.FromArgb(red1, g1, 0);
                        int red2 = green;
                        colorRgb2 = this.ColorRGB;
                        int g2 = (int)colorRgb2.G;
                        color2 = Color.FromArgb(red2, g2, (int)byte.MaxValue);
                        break;
                    case ColorModes.Blue:
                        color1 = Color.FromArgb(0, green, (int)this.ColorRGB.B);
                        color2 = Color.FromArgb((int)byte.MaxValue, green, (int)this.ColorRGB.B);
                        break;
                    case ColorModes.Hue:
                        hslColor2.L = hslColor1.L = 1.0 - (double)index / (double)(this.Height - 4);
                        color1 = hslColor1.RgbValue;
                        color2 = hslColor2.RgbValue;
                        break;
                    case ColorModes.Saturation:
                    case ColorModes.Luminance:
                        hslColor2.H = hslColor1.H = (double)index / (double)(this.Width - 4);
                        color1 = hslColor1.RgbValue;
                        color2 = hslColor2.RgbValue;
                        break;
                }
                Rectangle rect1 = new Rectangle(2, 2, this.Width - 4, 1);
                Rectangle rect2 = new Rectangle(2, index + 2, this.Width - 4, 1);
                if (this.ColorMode == ColorModes.Saturation || this.ColorMode == ColorModes.Luminance)
                {
                    rect1 = new Rectangle(2, 2, 1, this.Height - 4);
                    rect2 = new Rectangle(index + 2, 2, 1, this.Height - 4);
                    using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect1, color1, color2, 90f, false))
                        e.Graphics.FillRectangle((Brush)linearGradientBrush, rect2);
                }
                else
                {
                    using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect1, color1, color2, 0.0f, false))
                        e.Graphics.FillRectangle((Brush)linearGradientBrush, rect2);
                }
            }
            Pen pen = Pens.White;
            if (this.colorHSL.L >= 40.0 / 51.0)
            {
                if (this.colorHSL.H < 13.0 / 180.0 || this.colorHSL.H > 5.0 / 9.0)
                {
                    if (this.colorHSL.S <= 14.0 / 51.0)
                        pen = Pens.Black;
                }
                else
                    pen = Pens.Black;
            }
            e.Graphics.DrawEllipse(pen, this.markerPoint.X - 5, this.markerPoint.Y - 5, 10, 10);
        }

        private HslColor GetColor(int x, int y)
        {
            HslColor hslColor = HslColor.FromAhsl((int)byte.MaxValue);
            switch (this.ColorMode)
            {
                case ColorModes.Red:
                    return HslColor.FromColor(Color.FromArgb((int)this.colorRGB.R, MathExtensions.Round((double)byte.MaxValue * (1.0 - (double)y / (double)(this.Height - 4))), MathExtensions.Round((double)byte.MaxValue * (double)x / (double)(this.Width - 4))));
                case ColorModes.Green:
                    return HslColor.FromColor(Color.FromArgb(MathExtensions.Round((double)byte.MaxValue * (1.0 - (double)y / (double)(this.Height - 4))), (int)this.colorRGB.G, MathExtensions.Round((double)byte.MaxValue * (double)x / (double)(this.Width - 4))));
                case ColorModes.Blue:
                    return HslColor.FromColor(Color.FromArgb(MathExtensions.Round((double)byte.MaxValue * (double)x / (double)(this.Width - 4)), MathExtensions.Round((double)byte.MaxValue * (1.0 - (double)y / (double)(this.Height - 4))), (int)this.colorRGB.B));
                case ColorModes.Hue:
                    hslColor.H = this.colorHSL.H;
                    hslColor.S = (double)x / (double)(this.Width - 4);
                    hslColor.L = 1.0 - (double)y / (double)(this.Height - 4);
                    return hslColor;
                case ColorModes.Saturation:
                    hslColor.S = this.colorHSL.S;
                    hslColor.H = (double)x / (double)(this.Width - 4);
                    hslColor.L = 1.0 - (double)y / (double)(this.Height - 4);
                    return hslColor;
                case ColorModes.Luminance:
                    hslColor.L = this.colorHSL.L;
                    hslColor.H = (double)x / (double)(this.Width - 4);
                    hslColor.S = 1.0 - (double)y / (double)(this.Height - 4);
                    return hslColor;
                default:
                    return hslColor;
            }
        }

        private void ResetMarker()
        {
            switch (this.colorMode)
            {
                case ColorModes.Red:
                    this.markerPoint.X = MathExtensions.Round((double)((this.Width - 4) * (int)this.colorRGB.B) / (double)byte.MaxValue);
                    this.markerPoint.Y = MathExtensions.Round((double)(this.Height - 4) * (1.0 - (double)this.colorRGB.G / (double)byte.MaxValue));
                    break;
                case ColorModes.Green:
                    this.markerPoint.X = MathExtensions.Round((double)((this.Width - 4) * (int)this.colorRGB.B) / (double)byte.MaxValue);
                    this.markerPoint.Y = MathExtensions.Round((double)(this.Height - 4) * (1.0 - (double)this.colorRGB.R / (double)byte.MaxValue));
                    break;
                case ColorModes.Blue:
                    this.markerPoint.X = MathExtensions.Round((double)((this.Width - 4) * (int)this.colorRGB.R) / (double)byte.MaxValue);
                    this.markerPoint.Y = MathExtensions.Round((double)(this.Height - 4) * (1.0 - (double)this.colorRGB.G / (double)byte.MaxValue));
                    break;
                case ColorModes.Hue:
                    this.markerPoint.X = MathExtensions.Round((double)(this.Width - 4) * this.colorHSL.S);
                    this.markerPoint.Y = MathExtensions.Round((double)(this.Height - 4) * (1.0 - this.colorHSL.L));
                    break;
                case ColorModes.Saturation:
                    this.markerPoint.X = MathExtensions.Round((double)(this.Width - 4) * this.colorHSL.H);
                    this.markerPoint.Y = MathExtensions.Round((double)(this.Height - 4) * (1.0 - this.colorHSL.L));
                    break;
                case ColorModes.Luminance:
                    this.markerPoint.X = MathExtensions.Round((double)(this.Width - 4) * this.colorHSL.H);
                    this.markerPoint.Y = MathExtensions.Round((double)(this.Height - 4) * (1.0 - this.colorHSL.S));
                    break;
            }
        }

        private void SetMarker(int x, int y)
        {
            x = MathExtensions.LimitToRange(x, 0, this.Width - 4);
            y = MathExtensions.LimitToRange(y, 0, this.Height - 4);
            if (this.markerPoint.X == x && this.markerPoint.Y == y)
                return;
            this.markerPoint = new Point(x, y);
            this.colorHSL = this.GetColor(x, y);
            this.colorRGB = this.colorHSL.RgbValue;
            this.Refresh();
            if (this.ColorChanged != null)
                ColorChanged((object)this, new ColorChangedEventArgs(this.colorRGB));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = (IContainer)new Container();
            this.AutoScaleMode = AutoScaleMode.Font;
        }

        public delegate void ColorChangedEventHandler(object sender, ColorChangedEventArgs args);
    }
    public class ColorChangedEventArgs : EventArgs
    {
        private Color selectedColor;
        private HslColor selectedHslColor;

        public ColorChangedEventArgs(Color selectedColor)
        {
            this.selectedColor = selectedColor;
            this.selectedHslColor = HslColor.FromColor(selectedColor);
        }

        public ColorChangedEventArgs(HslColor selectedHslColor)
        {
            this.selectedColor = selectedHslColor.RgbValue;
            this.selectedHslColor = selectedHslColor;
        }

        public Color SelectedColor => this.selectedColor;

        public HslColor SelectedHslColor => this.selectedHslColor;
    }
    [DefaultEvent("ColorChanged")]
    public class ColorHexagon : UserControl
    {
        private ColorHexagonElement[] hexagonElements = new ColorHexagonElement[147];
        private float[] matrix1 = new float[6]
        {
      -0.5f,
      -1f,
      -0.5f,
      0.5f,
      1f,
      0.5f
        };
        private float[] matrix2 = new float[6]
        {
      0.824f,
      0.0f,
      -0.824f,
      -0.824f,
      0.0f,
      0.824f
        };
        private int oldSelectedHexagonIndex = -1;
        private int sectorMaximum = 7;
        private int selectedHexagonIndex = -1;
        private IContainer components = (IContainer)null;

        public event ColorHexagon.ColorChangedEventHandler ColorChanged;

        public Color SelectedColor => this.selectedHexagonIndex < 0 ? Color.Empty : this.hexagonElements[this.selectedHexagonIndex].CurrentColor;

        public ColorHexagon()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            for (int index = 0; index < this.hexagonElements.Length; ++index)
                this.hexagonElements[index] = new ColorHexagonElement();
            this.InitializeComponent();
        }

        private void DrawHexagonHighlighter(int selectedHexagonIndex)
        {
            if (selectedHexagonIndex == this.oldSelectedHexagonIndex)
                return;
            if (this.oldSelectedHexagonIndex >= 0)
            {
                this.hexagonElements[this.oldSelectedHexagonIndex].IsHovered = false;
                this.Invalidate(this.hexagonElements[this.oldSelectedHexagonIndex].BoundingRectangle);
            }
            this.oldSelectedHexagonIndex = selectedHexagonIndex;
            if (this.oldSelectedHexagonIndex >= 0)
            {
                this.hexagonElements[this.oldSelectedHexagonIndex].IsHovered = true;
                this.Invalidate(this.hexagonElements[this.oldSelectedHexagonIndex].BoundingRectangle);
            }
        }

        private int GetHexagonIndexFromCoordinates(int xCoordinate, int yCoordinate)
        {
            for (int index = 0; index < this.hexagonElements.Length; ++index)
            {
                if (this.hexagonElements[index].BoundingRectangle.Contains(xCoordinate, yCoordinate))
                    return index;
            }
            return -1;
        }

        private int GetHexgaonWidth(int availableHeight)
        {
            int num = availableHeight / (2 * this.sectorMaximum);
            if ((int)Math.Floor((double)num / 2.0) * 2 < num)
                --num;
            return num;
        }

        private void InitializeGrayscaleHexagons(
          ref Rectangle clientRectangle,
          int hexagonWidth,
          ref int centerOfMiddleHexagonX,
          ref int centerOfMiddleHexagonY,
          ref int index)
        {
            int maxValue = (int)byte.MaxValue;
            int num1 = 17;
            int num2 = 16;
            int num3 = (clientRectangle.Width - 7 * hexagonWidth) / 2 + clientRectangle.X - hexagonWidth / 3;
            centerOfMiddleHexagonX = num3;
            centerOfMiddleHexagonY = clientRectangle.Bottom;
            for (int index1 = 0; index1 < num2; ++index1)
            {
                this.hexagonElements[index].CurrentColor = Color.FromArgb(maxValue, maxValue, maxValue);
                this.hexagonElements[index].SetHexagonPoints((float)centerOfMiddleHexagonX, (float)centerOfMiddleHexagonY, hexagonWidth);
                centerOfMiddleHexagonX += hexagonWidth;
                ++index;
                if (index1 == 7)
                {
                    centerOfMiddleHexagonX = num3 + hexagonWidth / 2;
                    centerOfMiddleHexagonY += (int)((double)hexagonWidth * 0.824000000953674);
                }
                maxValue -= num1;
            }
        }

        private void InitializeHexagons()
        {
            Rectangle clientRectangle = this.ClientRectangle;
            clientRectangle.Offset(0, -8);
            if (clientRectangle.Height < clientRectangle.Width)
                clientRectangle.Inflate(-(clientRectangle.Width - clientRectangle.Height) / 2, 0);
            else
                clientRectangle.Inflate(0, -(clientRectangle.Height - clientRectangle.Width) / 2);
            int hexgaonWidth = this.GetHexgaonWidth(Math.Min(clientRectangle.Height, clientRectangle.Width));
            int centerOfMiddleHexagonX = (clientRectangle.Left + clientRectangle.Right) / 2;
            int centerOfMiddleHexagonY = (clientRectangle.Top + clientRectangle.Bottom) / 2 - hexgaonWidth;
            this.hexagonElements[0].CurrentColor = Color.White;
            this.hexagonElements[0].SetHexagonPoints((float)centerOfMiddleHexagonX, (float)centerOfMiddleHexagonY, hexgaonWidth);
            int index1 = 1;
            for (int index2 = 1; index2 < this.sectorMaximum; ++index2)
            {
                float yCoordinate = (float)centerOfMiddleHexagonY;
                float xCoordinate = (float)(centerOfMiddleHexagonX + hexgaonWidth * index2);
                for (int index3 = 0; index3 < this.sectorMaximum - 1; ++index3)
                {
                    int num1 = (int)((double)hexgaonWidth * (double)this.matrix2[index3]);
                    int num2 = (int)((double)hexgaonWidth * (double)this.matrix1[index3]);
                    for (int index4 = 0; index4 < index2; ++index4)
                    {
                        double num3 = 0.936 * (double)(this.sectorMaximum - index2) / (double)this.sectorMaximum + 0.12;
                        float colorQuotient = ColorHexagon.GetColorQuotient(xCoordinate - (float)centerOfMiddleHexagonX, yCoordinate - (float)centerOfMiddleHexagonY);
                        this.hexagonElements[index1].SetHexagonPoints(xCoordinate, yCoordinate, hexgaonWidth);
                        this.hexagonElements[index1].CurrentColor = ColorHexagon.ColorFromRGBRatios((double)colorQuotient, num3, 1.0);
                        yCoordinate += (float)num1;
                        xCoordinate += (float)num2;
                        ++index1;
                    }
                }
            }
            clientRectangle.Y -= hexgaonWidth + hexgaonWidth / 2;
            this.InitializeGrayscaleHexagons(ref clientRectangle, hexgaonWidth, ref centerOfMiddleHexagonX, ref centerOfMiddleHexagonY, ref index1);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.selectedHexagonIndex >= 0)
                {
                    this.hexagonElements[this.selectedHexagonIndex].IsSelected = false;
                    this.Invalidate(this.hexagonElements[this.selectedHexagonIndex].BoundingRectangle);
                }
                this.selectedHexagonIndex = -1;
                if (this.oldSelectedHexagonIndex >= 0)
                {
                    this.selectedHexagonIndex = this.oldSelectedHexagonIndex;
                    this.hexagonElements[this.selectedHexagonIndex].IsSelected = true;
                    if (this.ColorChanged != null)
                        ColorChanged((object)this, new ColorChangedEventArgs(this.SelectedColor));
                    this.Invalidate(this.hexagonElements[this.selectedHexagonIndex].BoundingRectangle);
                }
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.DrawHexagonHighlighter(-1);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.DrawHexagonHighlighter(this.GetHexagonIndexFromCoordinates(e.X, e.Y));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.BackColor == Color.Transparent)
                this.OnPaintBackground(e);
            Graphics graphics = e.Graphics;
            using (SolidBrush solidBrush = new SolidBrush(this.BackColor))
                graphics.FillRectangle((Brush)solidBrush, this.ClientRectangle);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            foreach (ColorHexagonElement hexagonElement in this.hexagonElements)
                hexagonElement.Paint(graphics);
            if (this.oldSelectedHexagonIndex >= 0)
                this.hexagonElements[this.oldSelectedHexagonIndex].Paint(graphics);
            if (this.selectedHexagonIndex >= 0)
                this.hexagonElements[this.selectedHexagonIndex].Paint(graphics);
            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            this.InitializeHexagons();
            base.OnResize(e);
        }

        private static float GetColorQuotient(float value1, float value2) => (float)(Math.Atan2((double)value2, (double)value1) * 180.0 / Math.PI);

        private static int GetColorChannelValue(float value1, float value2, float value3)
        {
            if ((double)value3 > 360.0)
                value3 -= 360f;
            else if ((double)value3 < 0.0)
                value3 += 360f;
            if ((double)value3 < 60.0)
                value1 += (float)(((double)value2 - (double)value1) * (double)value3 / 60.0);
            else if ((double)value3 < 180.0)
                value1 = value2;
            else if ((double)value3 < 240.0)
                value1 += (float)(((double)value2 - (double)value1) * (240.0 - (double)value3) / 60.0);
            return (int)((double)value1 * (double)byte.MaxValue);
        }

        private static Color ColorFromRGBRatios(double value1, double value2, double value3)
        {
            int blue;
            int green;
            int red;
            if (value3 == 0.0)
            {
                int num;
                blue = num = (int)(value2 * (double)byte.MaxValue);
                green = num;
                red = num;
            }
            else
            {
                float num1 = value2 > 0.5 ? (float)(value2 + value3 - value2 * value3) : (float)(value2 + value2 * value3);
                float num2 = (float)(2.0 * value2) - num1;
                red = ColorHexagon.GetColorChannelValue(num2, num1, (float)(value1 + 120.0));
                green = ColorHexagon.GetColorChannelValue(num2, num1, (float)value1);
                blue = ColorHexagon.GetColorChannelValue(num2, num1, (float)(value1 - 120.0));
            }
            return Color.FromArgb(red, green, blue);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent() => this.components = (IContainer)new Container();

        public delegate void ColorChangedEventHandler(object sender, ColorChangedEventArgs args);
    }
    internal class ColorHexagonElement
    {
        private Rectangle boundingRect = Rectangle.Empty;
        private Color hexagonColor = Color.Empty;
        private Point[] hexagonPoints = new Point[6];
        private bool isHovered;
        private bool isSelected;

        public void Paint(Graphics g)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddPolygon(this.hexagonPoints);
            path.CloseAllFigures();
            using (SolidBrush solidBrush = new SolidBrush(this.hexagonColor))
                g.FillPath((Brush)solidBrush, path);
            if (this.isHovered || this.isSelected)
            {
                SmoothingMode smoothingMode = g.SmoothingMode;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.FromArgb(42, 91, 150), 2f))
                    g.DrawPath(pen, path);
                using (Pen pen = new Pen(Color.FromArgb(150, 177, 239), 1f))
                    g.DrawPath(pen, path);
                g.SmoothingMode = smoothingMode;
            }
            path.Dispose();
        }

        public void SetHexagonPoints(float xCoordinate, float yCoordinate, int hexagonWidth)
        {
            float num = (float)hexagonWidth * 0.5773503f;
            this.hexagonPoints[0] = new Point((int)Math.Floor((double)xCoordinate - (double)(hexagonWidth / 2)), (int)Math.Floor((double)yCoordinate - (double)num / 2.0) - 1);
            this.hexagonPoints[1] = new Point((int)Math.Floor((double)xCoordinate), (int)Math.Floor((double)yCoordinate - (double)(hexagonWidth / 2)) - 1);
            this.hexagonPoints[2] = new Point((int)Math.Floor((double)xCoordinate + (double)(hexagonWidth / 2)), (int)Math.Floor((double)yCoordinate - (double)num / 2.0) - 1);
            this.hexagonPoints[3] = new Point((int)Math.Floor((double)xCoordinate + (double)(hexagonWidth / 2)), (int)Math.Floor((double)yCoordinate + (double)num / 2.0) + 1);
            this.hexagonPoints[4] = new Point((int)Math.Floor((double)xCoordinate), (int)Math.Floor((double)yCoordinate + (double)(hexagonWidth / 2)) + 1);
            this.hexagonPoints[5] = new Point((int)Math.Floor((double)xCoordinate - (double)(hexagonWidth / 2)), (int)Math.Floor((double)yCoordinate + (double)num / 2.0) + 1);
            using (GraphicsPath graphicsPath = new GraphicsPath())
            {
                graphicsPath.AddPolygon(this.hexagonPoints);
                this.boundingRect = Rectangle.Round(graphicsPath.GetBounds());
                this.boundingRect.Inflate(2, 2);
            }
        }

        public Rectangle BoundingRectangle => this.boundingRect;

        public Color CurrentColor
        {
            get => this.hexagonColor;
            set => this.hexagonColor = value;
        }

        public bool IsHovered
        {
            get => this.isHovered;
            set => this.isHovered = value;
        }

        public bool IsSelected
        {
            get => this.isSelected;
            set => this.isSelected = value;
        }
    }
    public enum ColorModes
    {
        Red,
        Green,
        Blue,
        Hue,
        Saturation,
        Luminance,
    }
    [DefaultEvent("ColorChanged")]
    public class ColorSliderVertical : UserControl
    {
        private HslColor colorHSL = HslColor.FromAhsl((int)byte.MaxValue);
        private ColorModes colorMode;
        private Color colorRGB = Color.Empty;
        private bool mouseMoving;
        private int position;
        private bool setHueSilently;
        private Color nubColor;
        private IContainer components = (IContainer)null;

        public event ColorSliderVertical.ColorChangedEventHandler ColorChanged;

        public Color ColorRGB
        {
            get => this.colorRGB;
            set
            {
                this.colorRGB = value;
                if (!this.setHueSilently)
                    this.colorHSL = HslColor.FromColor(this.ColorRGB);
                this.ResetSlider();
                this.Refresh();
            }
        }

        public HslColor ColorHSL
        {
            get => this.colorHSL;
            set
            {
                this.colorHSL = value;
                this.colorRGB = this.colorHSL.RgbValue;
                this.ResetSlider();
                this.Refresh();
            }
        }

        public ColorModes ColorMode
        {
            get => this.colorMode;
            set
            {
                this.colorMode = value;
                this.ResetSlider();
                this.Refresh();
            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Black")]
        public Color NubColor
        {
            get => this.nubColor;
            set => this.nubColor = value;
        }

        public int Position
        {
            get => this.position;
            set
            {
                int range = MathExtensions.LimitToRange(value, 0, this.Height - 9);
                if (range == this.position)
                    return;
                this.position = range;
                this.ResetHSLRGB();
                this.Refresh();
                if (this.ColorChanged != null)
                    ColorChanged((object)this, new ColorChangedEventArgs(this.colorRGB));
            }
        }

        public ColorSliderVertical()
        {
            this.InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.colorHSL = HslColor.FromAhsl(1.0, 1.0, 1.0);
            this.colorRGB = this.colorHSL.RgbValue;
            this.colorMode = ColorModes.Hue;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.mouseMoving = true;
            this.Position = e.Y - 4;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.mouseMoving = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!this.mouseMoving)
                return;
            this.Position = e.Y - 4;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            HslColor hslColor = HslColor.FromAhsl((int)byte.MaxValue);
            switch (this.ColorMode)
            {
                case ColorModes.Hue:
                    hslColor.L = hslColor.S = 1.0;
                    break;
                case ColorModes.Saturation:
                    ref HslColor local1 = ref hslColor;
                    HslColor colorHsl1 = this.ColorHSL;
                    double h1 = colorHsl1.H;
                    local1.H = h1;
                    ref HslColor local2 = ref hslColor;
                    colorHsl1 = this.ColorHSL;
                    double l = colorHsl1.L;
                    local2.L = l;
                    break;
                case ColorModes.Luminance:
                    ref HslColor local3 = ref hslColor;
                    HslColor colorHsl2 = this.ColorHSL;
                    double h2 = colorHsl2.H;
                    local3.H = h2;
                    ref HslColor local4 = ref hslColor;
                    colorHsl2 = this.ColorHSL;
                    double s = colorHsl2.S;
                    local4.S = s;
                    break;
            }
            for (int index = 0; index < this.Height - 8; ++index)
            {
                double num = this.ColorMode >= ColorModes.Hue ? 1.0 - (double)index / (double)(this.Height - 8) : (double)byte.MaxValue - (double)MathExtensions.Round((double)byte.MaxValue * (double)index / ((double)this.Height - 8.0));
                Color color = Color.Empty;
                switch (this.ColorMode)
                {
                    case ColorModes.Red:
                        color = Color.FromArgb((int)num, (int)this.ColorRGB.G, (int)this.ColorRGB.B);
                        break;
                    case ColorModes.Green:
                        Color colorRgb1 = this.ColorRGB;
                        int r1 = (int)colorRgb1.R;
                        int green = (int)num;
                        colorRgb1 = this.ColorRGB;
                        int b = (int)colorRgb1.B;
                        color = Color.FromArgb(r1, green, b);
                        break;
                    case ColorModes.Blue:
                        Color colorRgb2 = this.ColorRGB;
                        int r2 = (int)colorRgb2.R;
                        colorRgb2 = this.ColorRGB;
                        int g = (int)colorRgb2.G;
                        int blue = (int)num;
                        color = Color.FromArgb(r2, g, blue);
                        break;
                    case ColorModes.Hue:
                        hslColor.H = num;
                        color = hslColor.RgbValue;
                        break;
                    case ColorModes.Saturation:
                        hslColor.S = num;
                        color = hslColor.RgbValue;
                        break;
                    case ColorModes.Luminance:
                        hslColor.L = num;
                        color = hslColor.RgbValue;
                        break;
                }
                using (Pen pen = new Pen(color))
                    e.Graphics.DrawLine(pen, 11, index + 4, this.Width - 11, index + 4);
            }
            this.DrawSlider(e.Graphics);
        }

        private void DrawSlider(Graphics g)
        {
            using (Pen pen = new Pen(Color.FromArgb(116, 114, 106)))
            {
                SolidBrush solidBrush = new SolidBrush(this.nubColor);
                Point[] points = new Point[7]
                {
          new Point(1, this.position),
          new Point(3, this.position),
          new Point(7, this.position + 4),
          new Point(3, this.position + 8),
          new Point(1, this.position + 8),
          new Point(0, this.position + 7),
          new Point(0, this.position + 1)
                };
                g.FillPolygon((Brush)solidBrush, points);
                g.DrawPolygon(pen, points);
                points[0] = new Point(this.Width - 2, this.position);
                points[1] = new Point(this.Width - 4, this.position);
                points[2] = new Point(this.Width - 8, this.position + 4);
                points[3] = new Point(this.Width - 4, this.position + 8);
                points[4] = new Point(this.Width - 2, this.position + 8);
                points[5] = new Point(this.Width - 1, this.position + 7);
                points[6] = new Point(this.Width - 1, this.position + 1);
                g.FillPolygon((Brush)solidBrush, points);
                g.DrawPolygon(pen, points);
            }
        }

        private void ResetSlider()
        {
            double num = 0.0;
            switch (this.ColorMode)
            {
                case ColorModes.Red:
                    num = (double)this.colorRGB.R / (double)byte.MaxValue;
                    break;
                case ColorModes.Green:
                    num = (double)this.colorRGB.G / (double)byte.MaxValue;
                    break;
                case ColorModes.Blue:
                    num = (double)this.colorRGB.B / (double)byte.MaxValue;
                    break;
                case ColorModes.Hue:
                    num = this.colorHSL.H;
                    break;
                case ColorModes.Saturation:
                    num = this.colorHSL.S;
                    break;
                case ColorModes.Luminance:
                    num = this.colorHSL.L;
                    break;
            }
            this.position = this.Height - 8 - MathExtensions.Round((double)(this.Height - 8) * num);
        }

        private void ResetHSLRGB()
        {
            this.setHueSilently = true;
            switch (this.ColorMode)
            {
                case ColorModes.Red:
                    int red = (int)byte.MaxValue - MathExtensions.Round((double)byte.MaxValue * (double)this.position / (double)(this.Height - 9));
                    Color colorRgb = this.ColorRGB;
                    int g = (int)colorRgb.G;
                    colorRgb = this.ColorRGB;
                    int b = (int)colorRgb.B;
                    this.ColorRGB = Color.FromArgb(red, g, b);
                    this.ColorHSL = HslColor.FromColor(this.ColorRGB);
                    break;
                case ColorModes.Green:
                    this.ColorRGB = Color.FromArgb((int)this.ColorRGB.R, (int)byte.MaxValue - MathExtensions.Round((double)byte.MaxValue * (double)this.position / (double)(this.Height - 9)), (int)this.ColorRGB.B);
                    this.ColorHSL = HslColor.FromColor(this.ColorRGB);
                    break;
                case ColorModes.Blue:
                    this.ColorRGB = Color.FromArgb((int)this.ColorRGB.R, (int)this.ColorRGB.G, (int)byte.MaxValue - MathExtensions.Round((double)byte.MaxValue * (double)this.position / (double)(this.Height - 9)));
                    this.ColorHSL = HslColor.FromColor(this.ColorRGB);
                    break;
                case ColorModes.Hue:
                    this.colorHSL.H = 1.0 - (double)this.position / (double)(this.Height - 9);
                    this.ColorRGB = this.ColorHSL.RgbValue;
                    break;
                case ColorModes.Saturation:
                    this.colorHSL.S = 1.0 - (double)this.position / (double)(this.Height - 9);
                    this.ColorRGB = this.ColorHSL.RgbValue;
                    break;
                case ColorModes.Luminance:
                    this.colorHSL.L = 1.0 - (double)this.position / (double)(this.Height - 9);
                    this.ColorRGB = this.ColorHSL.RgbValue;
                    break;
            }
            this.setHueSilently = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Name = "ColorSlider";
            this.Size = new Size(25, 150);
            this.ResumeLayout(false);
        }

        public delegate void ColorChangedEventHandler(object sender, ColorChangedEventArgs args);
    }
    internal static class MathExtensions
    {
        public static int Round(double val)
        {
            int num = (int)val;
            if ((int)(val * 100.0) % 100 >= 50)
                ++num;
            return num;
        }

        public static int LimitToRange(int value, int inclusiveMinimum, int inclusiveMaximum)
        {
            if (value < inclusiveMinimum)
                return inclusiveMinimum;
            return value > inclusiveMaximum ? inclusiveMaximum : value;
        }
    }
    public struct HslColor
    {
        public static readonly HslColor Empty = new HslColor();
        private double hue;
        private double saturation;
        private double luminance;
        private int alpha;

        public HslColor(int a, double h, double s, double l)
        {
            this.alpha = a;
            this.hue = h;
            this.saturation = s;
            this.luminance = l;
            this.A = a;
            this.H = this.hue;
            this.S = this.saturation;
            this.L = this.luminance;
        }

        public HslColor(double h, double s, double l)
        {
            this.alpha = (int)byte.MaxValue;
            this.hue = h;
            this.saturation = s;
            this.luminance = l;
        }

        public HslColor(Color color)
        {
            this.alpha = (int)color.A;
            this.hue = 0.0;
            this.saturation = 0.0;
            this.luminance = 0.0;
            this.RGBtoHSL(color);
        }

        public static HslColor FromArgb(int a, int r, int g, int b) => new HslColor(Color.FromArgb(a, r, g, b));

        public static HslColor FromColor(Color color) => new HslColor(color);

        public static HslColor FromAhsl(int a) => new HslColor(a, 0.0, 0.0, 0.0);

        public static HslColor FromAhsl(int a, HslColor hsl) => new HslColor(a, hsl.hue, hsl.saturation, hsl.luminance);

        public static HslColor FromAhsl(double h, double s, double l) => new HslColor((int)byte.MaxValue, h, s, l);

        public static HslColor FromAhsl(int a, double h, double s, double l) => new HslColor(a, h, s, l);

        public static bool operator ==(HslColor left, HslColor right) => left.A == right.A && left.H == right.H && left.S == right.S && left.L == right.L;

        public static bool operator !=(HslColor left, HslColor right) => !(left == right);

        public override bool Equals(object obj) => obj is HslColor hslColor && this.A == hslColor.A && this.H == hslColor.H && this.S == hslColor.S && this.L == hslColor.L;

        public override int GetHashCode() => this.alpha.GetHashCode() ^ this.hue.GetHashCode() ^ this.saturation.GetHashCode() ^ this.luminance.GetHashCode();

        [DefaultValue(0.0)]
        [Category("Appearance")]
        [Description("H Channel value")]
        public double H
        {
            get => this.hue;
            set
            {
                this.hue = value;
                this.hue = this.hue > 1.0 ? 1.0 : (this.hue < 0.0 ? 0.0 : this.hue);
            }
        }

        [Category("Appearance")]
        [Description("S Channel value")]
        [DefaultValue(0.0)]
        public double S
        {
            get => this.saturation;
            set
            {
                this.saturation = value;
                this.saturation = this.saturation > 1.0 ? 1.0 : (this.saturation < 0.0 ? 0.0 : this.saturation);
            }
        }

        [Category("Appearance")]
        [Description("L Channel value")]
        [DefaultValue(0.0)]
        public double L
        {
            get => this.luminance;
            set
            {
                this.luminance = value;
                this.luminance = this.luminance > 1.0 ? 1.0 : (this.luminance < 0.0 ? 0.0 : this.luminance);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color RgbValue
        {
            get => this.HSLtoRGB();
            set => this.RGBtoHSL(value);
        }

        public int A
        {
            get => this.alpha;
            set => this.alpha = value > (int)byte.MaxValue ? (int)byte.MaxValue : (value < 0 ? 0 : value);
        }

        public bool IsEmpty => this.alpha == 0 && this.H == 0.0 && this.S == 0.0 && this.L == 0.0;

        public Color ToRgbColor() => this.ToRgbColor(this.A);

        public Color ToRgbColor(int alpha)
        {
            double num1 = this.L >= 0.5 ? this.L + this.S - this.L * this.S : this.L * (1.0 + this.S);
            double num2 = 2.0 * this.L - num1;
            double num3 = this.H / 360.0;
            double[] numArray1 = new double[3]
            {
        num3 + 1.0 / 3.0,
        num3,
        num3 - 1.0 / 3.0
            };
            double[] numArray2 = new double[3];
            for (int index = 0; index < numArray2.Length; ++index)
            {
                if (numArray1[index] < 0.0)
                    ++numArray1[index];
                if (numArray1[index] > 1.0)
                    --numArray1[index];
                if (numArray1[index] < 1.0 / 6.0)
                    numArray2[index] = num2 + (num1 - num2) * 6.0 * numArray1[index];
                else if (numArray1[index] >= 1.0 / 6.0 && numArray1[index] < 0.5)
                {
                    numArray2[index] = num1;
                }
                else
                {
                    int num4 = numArray1[index] < 0.5 ? 0 : (numArray1[index] < 2.0 / 3.0 ? 1 : 0);
                    numArray2[index] = num4 == 0 ? num2 : num2 + (num1 - num2) * 6.0 * (2.0 / 3.0 - numArray1[index]);
                }
                numArray2[index] *= (double)byte.MaxValue;
            }
            return Color.FromArgb(alpha, (int)numArray2[0], (int)numArray2[1], (int)numArray2[2]);
        }

        private Color HSLtoRGB()
        {
            int num1 = this.Round(this.luminance * (double)byte.MaxValue);
            int num2 = this.Round((1.0 - this.saturation) * (this.luminance / 1.0) * (double)byte.MaxValue);
            double num3 = (double)(num1 - num2) / (double)byte.MaxValue;
            if (this.hue >= 0.0 && this.hue <= 1.0 / 6.0)
            {
                int green = this.Round((this.hue - 0.0) * num3 * 1530.0 + (double)num2);
                return Color.FromArgb(this.alpha, num1, green, num2);
            }
            if (this.hue <= 1.0 / 3.0)
                return Color.FromArgb(this.alpha, this.Round(-((this.hue - 1.0 / 6.0) * num3) * 1530.0 + (double)num1), num1, num2);
            if (this.hue <= 0.5)
            {
                int blue = this.Round((this.hue - 1.0 / 3.0) * num3 * 1530.0 + (double)num2);
                return Color.FromArgb(this.alpha, num2, num1, blue);
            }
            if (this.hue <= 2.0 / 3.0)
            {
                int green = this.Round(-((this.hue - 0.5) * num3) * 1530.0 + (double)num1);
                return Color.FromArgb(this.alpha, num2, green, num1);
            }
            if (this.hue <= 5.0 / 6.0)
                return Color.FromArgb(this.alpha, this.Round((this.hue - 2.0 / 3.0) * num3 * 1530.0 + (double)num2), num2, num1);
            if (this.hue > 1.0)
                return Color.FromArgb(this.alpha, 0, 0, 0);
            int blue1 = this.Round(-((this.hue - 5.0 / 6.0) * num3) * 1530.0 + (double)num1);
            return Color.FromArgb(this.alpha, num1, num2, blue1);
        }

        private void RGBtoHSL(Color color)
        {
            this.alpha = (int)color.A;
            int num1;
            int num2;
            if ((int)color.R > (int)color.G)
            {
                num1 = (int)color.R;
                num2 = (int)color.G;
            }
            else
            {
                num1 = (int)color.G;
                num2 = (int)color.R;
            }
            if ((int)color.B > num1)
                num1 = (int)color.B;
            else if ((int)color.B < num2)
                num2 = (int)color.B;
            int num3 = num1 - num2;
            this.luminance = (double)num1 / (double)byte.MaxValue;
            this.saturation = num1 != 0 ? (double)num3 / (double)num1 : 0.0;
            double num4 = num3 != 0 ? 60.0 / (double)num3 : 0.0;
            if (num1 == (int)color.R)
            {
                if ((int)color.G < (int)color.B)
                    this.hue = (360.0 + num4 * (double)((int)color.G - (int)color.B)) / 360.0;
                else
                    this.hue = num4 * (double)((int)color.G - (int)color.B) / 360.0;
            }
            else if (num1 == (int)color.G)
                this.hue = (120.0 + num4 * (double)((int)color.B - (int)color.R)) / 360.0;
            else if (num1 == (int)color.B)
                this.hue = (240.0 + num4 * (double)((int)color.R - (int)color.G)) / 360.0;
            else
                this.hue = 0.0;
        }

        private int Round(double val) => (int)(val + 0.5);
    }
}