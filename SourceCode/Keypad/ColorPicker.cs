using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Keypad
{
    [DefaultEvent("ColorPicked")]
    public class ColorPickerControl : Control
    {
        private readonly Panel _selectedColorBox = new Panel();
        private readonly Panel _hoverColorBox = new Panel();
        private Bitmap _canvas;
        private Graphics _graphicsBuffer;
        private LinearGradientBrush _spectrumGradient, _blackBottomGradient, _whiteTopGradient;
        public event EventHandler ColorPicked;

        public ColorPickerControl()
        {
            base.Cursor = Cursors.Hand;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw |
                          ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);

            this.Size = new Size(400, 200);
            UpdateLinearGradientBrushes();
            UpdateGraphicsBuffer();
        }

        protected virtual void OnColorPicked()
        {
            if (ColorPicked != null)
                ColorPicked(this, EventArgs.Empty);
        }

        private void UpdateLinearGradientBrushes()
        {
            // Update spectrum gradient
            _spectrumGradient = new LinearGradientBrush(Point.Empty, new Point(this.Width, 0), Color.White, Color.White);
            ColorBlend blend = new ColorBlend();
            blend.Positions = new[] { 0, 1 / 7f, 2 / 7f, 3 / 7f, 4 / 7f, 5 / 7f, 6 / 7f, 1 };
            blend.Colors = new[] { Color.Gray, Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Indigo, Color.Violet };
            _spectrumGradient.InterpolationColors = blend;
            // Update greyscale gradient
            RectangleF rect = new RectangleF(0, this.Height * 0.7f, this.Width, this.Height * 0.3F);
            _blackBottomGradient = new LinearGradientBrush(rect, Color.Transparent, Color.Black, 90f);
            rect = new RectangleF(Point.Empty, new SizeF(this.Width, this.Height * 0.3F));
            _whiteTopGradient = new LinearGradientBrush(rect, Color.White, Color.Transparent, 90f);
        }

        private void UpdateGraphicsBuffer()
        {
            if (this.Width > 0)
            {
                _canvas = new Bitmap(this.Width, this.Height);
                _graphicsBuffer = Graphics.FromImage(_canvas);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            _selectedColorBox.Visible = true;
            _selectedColorBox.BackColor = _canvas.GetPixel(e.X, e.Y);
            OnColorPicked();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            _graphicsBuffer.FillRectangle(_spectrumGradient, this.ClientRectangle);
            _graphicsBuffer.FillRectangle(_blackBottomGradient, 0, this.Height * 0.7f + 1, this.Width, this.Height * 0.3f);
            _graphicsBuffer.FillRectangle(_whiteTopGradient, 0, 0, this.Width, this.Height * 0.3f);
            e.Graphics.DrawImageUnscaled(_canvas, Point.Empty);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateLinearGradientBrushes();
            UpdateGraphicsBuffer();
        }


        [Description("The current selected color of the color picker control")]
        public Color SelectedColor
        {
            get { return _selectedColorBox.BackColor; }
            set
            {
                _selectedColorBox.BackColor = value;
                _selectedColorBox.Visible = true;
            }
        }
    }
}
