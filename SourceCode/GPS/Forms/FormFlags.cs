using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormFlags : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        public FormFlags(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();

            //this.bntOK.Text = gStr.gsForNow;
            //this.btnSave.Text = gStr.gsToFile;

            //this.Text = gStr.gsSmoothABCurve;
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            mf.FileSaveFlags();
            Close();
        }

        private void UpdateLabels()
        {
           lblLatStart.Text = mf.flagPts[mf.flagNumberPicked - 1].latitude.ToString();
            lblLonStart.Text = mf.flagPts[mf.flagNumberPicked - 1].longitude.ToString();
            lblEasting.Text = mf.flagPts[mf.flagNumberPicked - 1].easting.ToString();
            lblNorthing.Text = mf.flagPts[mf.flagNumberPicked - 1].northing.ToString();

            //lblLatStart.Text = mf.flagPts[mf.flagNumberPicked - 1].color.ToString();
            lblFlagSelected.Text = mf.flagPts[mf.flagNumberPicked - 1].ID.ToString();
            tboxFlagNotes.Text = mf.flagPts[mf.flagNumberPicked - 1].notes;
        }
        private void FormFlags_Load(object sender, EventArgs e)
        {
            UpdateLabels();        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNorth_MouseDown(object sender, MouseEventArgs e)
        {
            mf.flagNumberPicked++;
            if (mf.flagNumberPicked > mf.flagPts.Count) mf.flagNumberPicked = 1;
            UpdateLabels();
        }

    private void btnSouth_MouseDown(object sender, MouseEventArgs e)
        {
            mf.flagNumberPicked--;
            if (mf.flagNumberPicked < 1) mf.flagNumberPicked = mf.flagPts.Count;
            UpdateLabels();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            mf.flagNumberPicked = 0;
            Close();

        }

        private void btnDeleteFlag_Click(object sender, EventArgs e)
        {
            int flag = mf.flagNumberPicked;
            if (mf.flagPts.Count > 0) mf.DeleteSelectedFlag();
            if (mf.flagPts.Count == 0)
            {
                Close();
                return;
            }
            if (flag > mf.flagPts.Count) mf.flagNumberPicked = mf.flagPts.Count;
            else mf.flagNumberPicked = flag;
            UpdateLabels();
        }

        private void tboxFlagNotes_Leave(object sender, EventArgs e)
        {
            mf.flagPts[mf.flagNumberPicked - 1].notes = tboxFlagNotes.Text;
        }

        private void tboxFlagNotes_TextChanged(object sender, EventArgs e)
        {
            
            //mf.flagPts[mf.flagNumberPicked - 1].notes = tboxFlagNotes.Text;
        }

        private void tboxFlagNotes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') e.Handled = true;
        }
    }
}