using Microsoft.Win32;
using System;
using System.Threading;
using System.Windows.Forms;

namespace AgIO
{
    internal static class Program
    {
        private static readonly Mutex Mutex = new Mutex(true, "{8F6F0AC4-B9A1-55fd-A8CF-72F04E6BDE8F}");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            ////opening the subkey
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AgOpenGPS");

            ////create default keys if not existing
            if (regKey == null)
            {
                RegistryKey Key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AgOpenGPS");

                //storing the values
                Key.SetValue("Language", "en");
                Key.Close();

                Properties.Settings.Default.setF_culture = "en";
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.setF_culture = regKey.GetValue("Language").ToString();
                Properties.Settings.Default.Save();
                regKey.Close();
            }

            if (Mutex.WaitOne(TimeSpan.Zero, true))
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormLoop());
            }
        }
    }
}
