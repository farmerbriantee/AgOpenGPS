using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormKeyboard : Form
    {

        //private bool isFirstKey;

        public string ReturnString { get; set; }
        public FormKeyboard(string currentString)
        {

            InitializeComponent();

            this.Text = gStr.gsEnteraValue;
            //fill in the display
            keyboardString.Text = currentString.ToString();

            //isFirstKey = true;
        }

        private void FormKeyboard_Load(object sender, EventArgs e)
        {
            keyboardString.SelectionStart = keyboardString.Text.Length;
            keyboardString.SelectionLength = 0;
            keyboard1.Focus();
        }

        private void RegisterKeyboard1_ButtonPressed(object sender, KeyPressEventArgs e)
        {

            //if (isFirstKey)
            //{
            //    keyboardString.Text = "";
            //    isFirstKey = false;
            //}

            //clear the error as user entered new values
            if (keyboardString.Text == gStr.gsError)
            {
                keyboardString.Text = "";
            }

            //if its a character just add it
            if (Char.IsLetterOrDigit(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
            {
                keyboardString.Text += e.KeyChar;
            }

            //Backspace key, remove 1 char
            else if (e.KeyChar == '<')
            {
                if (keyboardString.Text.Length > 0)
                {
                    keyboardString.Text = keyboardString.Text.Remove(keyboardString.Text.Length - 1);
                }
            }

            //Exit or cancel
            else if (e.KeyChar == '>')
            {
                this.DialogResult = DialogResult.Cancel;
                Close();
            }

            //clear whole display
            else if (e.KeyChar == '?')
            {
                keyboardString.Text = "";
            }

            //ok button
            else if (e.KeyChar == ':')
            {
                //not ok if empty - just return
                if (keyboardString.Text == "")
                {
                    return;
                }
                else
                {
                    //all good, return the value
                    this.ReturnString = keyboardString.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
