using AgOpenGPS.Properties;
using Microsoft.Win32;
using System;
using System.Threading;
using System.Windows.Forms;

namespace AgOpenGPS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static readonly Mutex Mutex = new Mutex(true, "{516-0AC5-B9A1-55fd-A8CE-72F04E6BDE8F}");

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

                Settings.Default.setF_culture = "en";
                Settings.Default.Save();
            }
            else
            {
                //check for corrupt settings file
                try
                {
                    Settings.Default.setF_culture = regKey.GetValue("Language").ToString();
                }
                catch (System.Configuration.ConfigurationErrorsException ex)
                {
                    // Corrupted XML! Delete the file, the user can just reload when this fails to appear. No need to worry them
                    MessageBoxButtons btns = MessageBoxButtons.OK;
                    System.Windows.Forms.MessageBox.Show("Error detected in config file - fixing it now, please close this and restart app", "Problem!", btns);
                    string filename = ((ex.InnerException as System.Configuration.ConfigurationErrorsException)?.Filename) as string;
                    System.IO.File.Delete(filename);
                    Settings.Default.Reload();
                    Application.Exit();
                }

                Settings.Default.Save();
                regKey.Close();
            }

            if (Mutex.WaitOne(TimeSpan.Zero, true))
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Properties.Settings.Default.setF_culture);
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Properties.Settings.Default.setF_culture);
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