using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgOpenGPS.Properties;
using OpenTK.Graphics.OpenGL;

//                MessageBox.Show(gStr, gStr.gsHelp);

namespace AgOpenGPS
{
    public partial class FormConfig
    {
        private NudlessNumericUpDown nudCutoffSpeed;
        private Label lblTurnOffBelowUnits;
        private PictureBox pictureBox11;
    }
}