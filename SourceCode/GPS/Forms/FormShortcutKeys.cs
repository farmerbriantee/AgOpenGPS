using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormShortcutKeys : Form
    {
        public FormShortcutKeys()
        {
            InitializeComponent();

            textBox1.Text = gStr.gsAutoSectionOnOff + "\r\n\r\n" + gStr.gsAutoSteerOnOff + "\r\n" + gStr.gsAutoSteerConfig+ "\r\n" + gStr.gsSteerChart + "\r\n\r\n" +
    gStr.gsFieldOpenClose + "\r\n" + gStr.gsSnap + "\r\n" +  gStr.gsFlagsMark + "\r\n\r\n" + gStr.gsUTurnSettings + "\r\n" +gStr.gsVehicleSetting;
        }

        private void FormShortcutKeys_Load(object sender, EventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}