using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormTemp : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        public FormTemp(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void FormToolPivot_Load(object sender, EventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}