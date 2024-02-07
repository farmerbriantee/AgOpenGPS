using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormNumeric : Form
    {
        private readonly double max;
        private readonly double min;
        private bool isFirstKey;

        public double ReturnValue { get; set; }

        public FormNumeric(double _min, double _max, double currentValue)
        {
            max = _max;
            min = _min;
            InitializeComponent();

            this.Text = gStr.gsEnteraValue;
            //fill in the display
            tboxNumber.Text = currentValue.ToString();

            isFirstKey = true;
        }

        private void FormNumeric_Load(object sender, EventArgs e)
        {
            lblMax.Text = max.ToString();
            lblMin.Text = min.ToString();
            tboxNumber.SelectionStart = tboxNumber.Text.Length;
            tboxNumber.SelectionLength = 0;
            keypad1.Focus();
        }

        private void RegisterKeypad1_ButtonPressed(object sender, KeyPressEventArgs e)
        {

            if (isFirstKey)
            {
                tboxNumber.Text = "";
                isFirstKey = false;
            }

            //clear the error as user entered new values
            if(tboxNumber.Text == gStr.gsError)
            {
                tboxNumber.Text = "";
                lblMin.ForeColor = SystemColors.ControlText;
                lblMax.ForeColor = SystemColors.ControlText;
            }

            //if its a number just add it
            if (Char.IsNumber(e.KeyChar))
            {
                tboxNumber.Text += e.KeyChar;
            }

            //Backspace key, remove 1 char
            else if (e.KeyChar == 'B')
            {
                if (tboxNumber.Text.Length > 0)
                {
                    tboxNumber.Text = tboxNumber.Text.Remove(tboxNumber.Text.Length - 1);
                }
            }

            //decimal point
            else if (e.KeyChar == '.')
            {
                //does it already have a decimal?
                if (!tboxNumber.Text.Contains(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator))
                {
                    tboxNumber.Text += Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

                    //if decimal is first char, prefix with a zero
                    if (tboxNumber.Text.IndexOf(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator) == 0)
                    {
                        tboxNumber.Text = "0" + tboxNumber.Text;
                    }

                    //neg sign then added a decimal, insert a 0 
                    if (tboxNumber.Text.IndexOf("-") == 0 && tboxNumber.Text.IndexOf(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator) == 1)
                    {
                        tboxNumber.Text = "-0" + Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                    }
                }
            }

            //negative sign
            else if (e.KeyChar == '-')
            {
                //If already has a negative don't add again
                if (!tboxNumber.Text.Contains("-"))
                {
                    //prefix the negative sign
                    tboxNumber.Text = "-" + tboxNumber.Text;
                }
                else
                {
                    //if already has one, take it away = +/- does that
                    if (tboxNumber.Text.StartsWith("-"))
                    {
                        tboxNumber.Text = tboxNumber.Text.Substring(1);
                    }
                }
            }

            //Exit or cancel
            else if (e.KeyChar == 'X')
            {
                this.DialogResult = DialogResult.Cancel;
                Close();
            }

            //clear whole display
            else if (e.KeyChar == 'C')
            {
                tboxNumber.Text = "";
            }

            //ok button
            else if (e.KeyChar == 'K')
            {
                //not ok if empty - just return
                if (tboxNumber.Text == "") return;

                //culture invariant parse to double
                double tryNumber = double.Parse(tboxNumber.Text, CultureInfo.CurrentCulture);

                //test if above or below min/max
                if (tryNumber < min)
                {
                    tboxNumber.Text = gStr.gsError;
                    lblMin.ForeColor = System.Drawing.Color.Red;
                }
                else if (tryNumber > max)
                {
                    tboxNumber.Text = gStr.gsError;
                    lblMax.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    //all good, return the value
                    this.ReturnValue = tryNumber;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void BtnDistanceUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (tboxNumber.Text == "" || tboxNumber.Text == "-" || tboxNumber.Text == gStr.gsError) tboxNumber.Text = "0";
            double tryNumber = double.Parse(tboxNumber.Text, CultureInfo.CurrentCulture);


            tryNumber++;

            if (tryNumber > max) tryNumber = max;

            tboxNumber.Text = tryNumber.ToString();

            isFirstKey = false;
        }

        private void BtnDistanceDn_MouseDown(object sender, MouseEventArgs e)
        {
            if (tboxNumber.Text == "" || tboxNumber.Text == "-" || tboxNumber.Text == gStr.gsError) tboxNumber.Text = "0";
            double tryNumber = double.Parse(tboxNumber.Text, CultureInfo.CurrentCulture);

            tryNumber--;
            if (tryNumber < min) tryNumber = min;

            tboxNumber.Text = tryNumber.ToString();

            isFirstKey = false;
        }
    }
}