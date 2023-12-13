using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AgOpenGPS
{
    public partial class FormActions : Form
    {
        private readonly FormGPS mf = null;

        public FormActions(Form callingForm)
        {
            mf = callingForm as FormGPS;

            InitializeComponent();
        }

        private void FormActions_Load(object sender, EventArgs e)
        {
            tab1.Appearance = TabAppearance.FlatButtons;
            tab1.ItemSize = new Size(0, 1);
            tab1.SizeMode = TabSizeMode.Fixed;
        }

        private void ShowSubMenu(System.Windows.Forms.Button btn)
        {
            {
                if (btn.Name == "btnField") tab1.SelectedTab = tabField;
                else if (btn.Name == "btnCharts") tab1.SelectedTab = tabCharts;
                else if (btn.Name == "btnWebCam") tab1.SelectedTab = tabWebCam;
            }
            btn.BackColor = Color.Gainsboro;
        }

        private void btnField_Click(object sender, EventArgs e)
        {
            SetButtonsBackColor();
            ShowSubMenu(sender as System.Windows.Forms.Button);
        }

        private void SetButtonsBackColor()
        {
            btnField.BackColor =  Color.Transparent;
            btnCharts.BackColor = Color.Transparent;
            btnWebCam.BackColor = Color.Transparent;
        }
    }
}
