using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgOpenGPS.Forms
{
    public partial class FormMenuSettings : Form
    {
        private readonly FormGPS mf = null;

        public FormMenuSettings(Form callingForm)
        {
            InitializeComponent();

            mf = callingForm as FormGPS;
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            Close();
            using (FormConfig form = new FormConfig(mf, 0))
            {
                form.ShowDialog(this);
            }
        }

        private void btnStartAgIO_Click(object sender, EventArgs e)
        {
            Process[] processName = Process.GetProcessesByName("AgIO");
            if (processName.Length == 0)
            {
                //Start application here
                DirectoryInfo di = new DirectoryInfo(Application.StartupPath);
                string strPath = di.ToString();
                strPath += "\\AgIO.exe";
                try
                {
                    //TimedMessageBox(2000, "Please Wait", "Starting AgIO");
                    ProcessStartInfo processInfo = new ProcessStartInfo();
                    processInfo.FileName = strPath;
                    //processInfo.ErrorDialog = true;
                    //processInfo.UseShellExecute = false;
                    processInfo.WorkingDirectory = Path.GetDirectoryName(strPath);
                    Process proc = Process.Start(processInfo);
                }
                catch
                {
                    mf.TimedMessageBox(2000, "No File Found", "Can't Find AgIO");
                }
            }
            else
            {
                //Set foreground window
                FormGPS.ShowWindow(processName[0].MainWindowHandle, 9);
                FormGPS.SetForegroundWindow(processName[0].MainWindowHandle);
            }

            Close();
        }

        private void btnConfgTool_Click(object sender, EventArgs e)
        {
            Close();
            using (FormConfig form = new FormConfig(mf, 1))
            {
                form.ShowDialog(this);
            }
        }
        private void btnConfigGuidance_Click(object sender, EventArgs e)
        {
            Close();
            using (FormConfig form = new FormConfig(mf, 2))
            {
                form.ShowDialog(this);
            }
        }

        private void btnConfigUTurn_Click(object sender, EventArgs e)
        {
            Close();
            using (FormConfig form = new FormConfig(mf, 3))
            {
                form.ShowDialog(this);
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            //buttonPanelCounter = 0;
            Form f = Application.OpenForms["FormGPSData"];

            if (f != null)
            {
                f.Focus();
                f.Close();
            }

            Form f1 = Application.OpenForms["FormFieldData"];

            if (f1 != null)
            {
                f1.Focus();
                f1.Close();
            }

            if (mf.panelNavigation.Visible)
            {
                mf.panelNavigation.Visible = false;
            }
            else
            {
                mf.panelNavigation.Visible = true;
                mf.navPanelCounter = 2;
                if (mf.displayBrightness.isWmiMonitor) mf.btnBrightnessDn.Text = (mf.displayBrightness.GetBrightness().ToString()) + "%";
                else mf.btnBrightnessDn.Text = "??";
            }
            Close();
        }

        private void btnSteerSettings_Click(object sender, EventArgs e)
        {
            //check if window already exists
            Form fc = Application.OpenForms["FormSteer"];

            if (fc != null)
            {
                fc.Focus();
                fc.Close();
                return;
            }

            //
            Form form = new FormSteer(mf);
            form.Top = 0;
            form.Left = 0;
            form.Show(mf);
            Close();
        }
    }
}
