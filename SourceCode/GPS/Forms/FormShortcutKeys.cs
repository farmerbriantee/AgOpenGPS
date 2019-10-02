using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormShortcutKeys : Form
    {
        public FormShortcutKeys()
        {
            InitializeComponent();
        }

        private void FormShortcutKeys_Load(object sender, EventArgs e)
        {
            this.Text = gStr.gsShortcut_Keys;
            textBox1.Text = gStr.gsShortcut_Keys_textbox;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}