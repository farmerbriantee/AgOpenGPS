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
        }
    }
}
