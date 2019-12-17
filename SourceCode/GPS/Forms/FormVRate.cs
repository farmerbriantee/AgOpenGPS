using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormVRate : Form
    {
        private readonly FormGPS mf = null;
        private bool isValidImage = false;

        public FormVRate(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void FormVRate_Load(object sender, EventArgs e)
        {
            string fileAndDirectory = mf.fieldsDirectory + mf.currentFieldDirectory + "\\Background.JPG";
            //fileAndDirectory = mf.fieldsDirectory + mf.currentFieldDirectory + "\\VR.BMP";
            //bitmap.Save(fileAndDirectory);
            if (File.Exists(fileAndDirectory))
            {
                Bitmap bmpRate = (Bitmap)Image.FromFile(fileAndDirectory);

                picboxVR.Image = bmpRate;

                isValidImage = true;
            }
            else
            {
                isValidImage = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            picboxVR.Dispose();
            if (isValidImage) mf.rateMap.BuildRateMap();
        }
    }
}
