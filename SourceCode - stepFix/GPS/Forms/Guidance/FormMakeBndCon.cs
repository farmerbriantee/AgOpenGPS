using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormMakeBndCon : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf;

        public FormMakeBndCon(Form _mf)
        {
            mf = _mf as FormGPS;
            InitializeComponent();

            lblHz.Text = gStr.gsPass;
            label1.Text = gStr.gsSpacing;

            this.Text = gStr.gsMakeBoundaryContours;

            nudPass.Controls[0].Enabled = false;
            nudSpacing.Controls[0].Enabled = false;
        }

        private void BtnOk_Click(object sender, System.EventArgs e)
        {
            mf.ct.BuildBoundaryContours((int)nudPass.Value, (int)nudSpacing.Value);
            Close();
        }

        private void BtnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void NudPass_Enter(object sender, System.EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();

        }

        private void NudSpacing_Enter(object sender, System.EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void FormMakeBndCon_Load(object sender, System.EventArgs e)
        {
            btnCancel.Focus();
        }
    }
}