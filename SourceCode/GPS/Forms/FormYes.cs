using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormYes : Form
    {
        public FormYes(string messageStr)
        {
            InitializeComponent();

            lblMessage2.Text = messageStr;
        }
    }
}