using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Globalization;

namespace AgOpenGPS
{
    public partial class FormFieldDir : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        public FormFieldDir(Form _callingForm)
        {
            //get copy of the calling main form
            mf = _callingForm as FormGPS;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //fill something in
            if (String.IsNullOrEmpty(tboxFieldName.Text)) tboxFieldName.Text = "XX";

            //append date time to name
            mf.currentFieldDirectory = tboxFieldName.Text.Trim() +
                String.Format("{0}", DateTime.Now.ToString(" MMMdd", CultureInfo.InvariantCulture));
            try
            {
                //get the directory and make sure it exists, create if not
                string dirField = mf.fieldsDirectory + mf.currentFieldDirectory + "\\";

                //make sure directory exists, or create it for first save
                string directoryName = Path.GetDirectoryName(dirField);

                if ((!string.IsNullOrEmpty(directoryName)) && (Directory.Exists(directoryName)))
                {
                    MessageBox.Show("Choose a different name", "Directory Exists", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    //reset the offsets
                    mf.pn.utmEast = (int)mf.pn.actualEasting;
                    mf.pn.utmNorth = (int)mf.pn.actualNorthing;

                    mf.worldGrid.CreateWorldGrid(0, 0);

                    //make sure directory exists, or create it
                    if ((!string.IsNullOrEmpty(directoryName)) && (!Directory.Exists(directoryName)))
                    { Directory.CreateDirectory(directoryName); }

                    //create the field file header info
                    mf.FileCreateField();
                    mf.FileCreateContour();
                    mf.FileSaveFlags();
                    mf.FileSaveABLine();
                }
            }
            catch (Exception ex)
            {
                mf.WriteErrorLog("Creating new field " + ex);

                MessageBox.Show("Error", ex.ToString());
                mf.currentFieldDirectory = "";
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void tboxFieldName_TextChanged(object sender, EventArgs e)
        {
            var textboxSender = (TextBox)sender;
            var cursorPosition = textboxSender.SelectionStart;
            textboxSender.Text = Regex.Replace(textboxSender.Text, "[^0-9a-zA-Z ]", "");
            textboxSender.SelectionStart = cursorPosition;
        }
    }
}
