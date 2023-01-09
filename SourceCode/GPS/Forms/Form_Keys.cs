using System;
using System.Globalization;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class Form_Keys : Form
    {
        //class variables
        private readonly FormGPS mf = null;

        public Form_Keys(Form callingForm)
        {
            mf = callingForm as FormGPS;

            InitializeComponent();
        }

        private void btnEditShortcut_Click(object sender, EventArgs e)
        {
            EditShortcut((Button)sender);
        }

        private void EditShortcut(Button btn)
        {
            lblAutosteer.Text = "Press New Shortcut Key";
            btn.Text = "...";
            tboxKey.Focus();
        }

        private void tboxKey_TextChanged(object sender, EventArgs e)
        {
            lblAutosteer.Text = "<- Press Button to Edit Shortcut";
            string but = tboxKey.Text.ToUpper();

            if      (btnAutosteer.Text == "...") { btnAutosteer.Text = but; }
            else if (btnCycleLines.Text == "...") { btnCycleLines.Text = but; }
            else if (btnFieldMenu.Text== "...") { btnFieldMenu.Text = but; }
            else if (btnNewFlag.Text == "...") { btnNewFlag.Text = but; }
            else if (btnManualSection.Text == "...") { btnManualSection.Text = but; }
            else if (btnAutoSection.Text == "...") { btnAutoSection.Text = but; }
            else if (btnSnapToPivot.Text == "...") { btnSnapToPivot.Text = but; }
            else if (btnMoveLineLeft.Text == "...") { btnMoveLineLeft.Text = but; }
            else if (btnMoveLineRight.Text == "...") { btnMoveLineRight.Text = but; }
            else if (btnVehicleSettings.Text == "...") { btnVehicleSettings.Text = but; }
            else if (btnSteerWizard.Text == "...") { btnSteerWizard.Text = but; }
            tboxKey.Text = "";
        }

        private void Form_Keys_Load(object sender, EventArgs e)
        {
            LoadButtonText();
        }

        private void Form_Keys_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.setKey_hotkeys =
                btnAutosteer.Text + btnCycleLines.Text + btnFieldMenu.Text +
                btnNewFlag.Text + btnManualSection.Text + btnAutoSection.Text +
                btnSnapToPivot.Text + btnMoveLineLeft.Text + btnMoveLineRight.Text +
                btnVehicleSettings.Text + btnSteerWizard.Text;
            Properties.Settings.Default.Save();

            mf.hotkeys = Properties.Settings.Default.setKey_hotkeys.ToCharArray();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.setKey_hotkeys = "ACFGMNPTYVW";
            Properties.Settings.Default.Save();
            mf.hotkeys = Properties.Settings.Default.setKey_hotkeys.ToCharArray();
            LoadButtonText();
        }

        void LoadButtonText()
        {
            btnAutosteer.Text = mf.hotkeys[0].ToString();
            btnCycleLines.Text = mf.hotkeys[1].ToString();
            btnFieldMenu.Text = mf.hotkeys[2].ToString();
            btnNewFlag.Text = mf.hotkeys[3].ToString();
            btnManualSection.Text = mf.hotkeys[4].ToString();
            btnAutoSection.Text = mf.hotkeys[5].ToString();
            btnSnapToPivot.Text = mf.hotkeys[6].ToString();
            btnMoveLineLeft.Text = mf.hotkeys[7].ToString();
            btnMoveLineRight.Text = mf.hotkeys[8].ToString();
            btnVehicleSettings.Text = mf.hotkeys[9].ToString();
            btnSteerWizard.Text = mf.hotkeys[10].ToString();
        }
    }
}