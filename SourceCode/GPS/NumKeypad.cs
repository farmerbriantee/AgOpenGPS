using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keypad
{
    public partial class NumKeypad : GenericKeypad
    {
        public NumKeypad()
        {
            InitializeComponent();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            RaiseButtonPressed('0');
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            RaiseButtonPressed('1');
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            RaiseButtonPressed('2');
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            RaiseButtonPressed('3');
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            RaiseButtonPressed('4');
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            RaiseButtonPressed('5');
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            RaiseButtonPressed('6');
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            RaiseButtonPressed('7');
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            RaiseButtonPressed('8');
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            RaiseButtonPressed('9');
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            RaiseButtonPressed('.');
        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            RaiseButtonPressed('-');
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            RaiseButtonPressed('C');
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            RaiseButtonPressed('O');
        }
    }
}
