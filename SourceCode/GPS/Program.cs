
using System;
using System.Windows.Forms;
using System.Threading;

namespace AgOpenGPS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static readonly Mutex Mutex = new Mutex(true, "{8F6F0AC5-B9A1-55fd-A8CF-72F04E6BDE8F}");
        [STAThread]
        static void Main()
        {
            if (Mutex.WaitOne(TimeSpan.Zero, true))
            {
                //if (Environment.OSVersion.Version.Major >= 6) SetProcessDPIAware();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormGPS());
            }
            else
            {
                MessageBox.Show("AgOpenGPS is Already Running");
            }
        }

        //[System.Runtime.InteropServices.DllImport("user32.dll")]
        //private static extern bool SetProcessDPIAware();
    }
}
