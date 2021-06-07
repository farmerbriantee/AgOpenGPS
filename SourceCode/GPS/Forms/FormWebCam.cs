using System;
using System.Windows.Forms;
using WebEye.Controls.WinForms.WebCameraControl;

namespace AgOpenGPS
{
    public partial class FormWebCam : Form
    {
        public FormWebCam()
        {
            InitializeComponent();
        }

        private class ComboBoxItem
        {
            public ComboBoxItem(WebCameraId id)
            {
                _id = id;
            }

            private readonly WebCameraId _id;

            public WebCameraId Id => _id;

            public override string ToString()
            {
                // Generates the text shown in the combo box.
                return _id.Name;
            }
        }

        private void FormWebCam_Load(object sender, EventArgs e)
        {
            foreach (WebCameraId camera in webCameraControl1.GetVideoCaptureDevices())
            {
                comboBox1.Items.Add(new ComboBoxItem(camera));
            }

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedItem = comboBox1.Items[0];
            }
        }

        private void UpdateButtons()
        {
            startButton.Enabled = comboBox1.SelectedItem != null;
            stopButton.Enabled = webCameraControl1.IsCapturing;
            //imageButton.Enabled = webCameraControl1.IsCapturing;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void startButton_Click_1(object sender, EventArgs e)
        {
            ComboBoxItem i = (ComboBoxItem)comboBox1.SelectedItem;

            try
            {
                webCameraControl1.StartCapture(i.Id);
            }
            finally
            {
                UpdateButtons();
            }
        }

        private void stopButton_Click_1(object sender, EventArgs e)
        {
            webCameraControl1.StopCapture();

            UpdateButtons();
        }
    }
}