using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RateController
{
    public class clsTools
    {
        private static Hashtable ht;
        private string cAppName = "RateController";
        private string cPropertiesFile;

        private string cSettingsDir;
        private string cVersionDate = "02-May-2021";
        private FormStart mf;

        public clsTools(FormStart CallingForm)
        {
            mf = CallingForm;
            CheckFolders();
        }

        public string PropertiesFile
        {
            get
            {
                return cPropertiesFile;
            }
            set
            {
                if (File.Exists(value))
                {
                    OpenFile(value);
                }
            }
        }

        public void DrawGroupBox(GroupBox box, Graphics g, Color BackColor, Color textColor, Color borderColor)
        {
            // useage:
            // point the Groupbox paint event to this sub:
            //private void GroupBoxPaint(object sender, PaintEventArgs e)
            //{
            //    GroupBox box = sender as GroupBox;
            //    mf.Tls.DrawGroupBox(box, e.Graphics, this.BackColor, Color.Black, Color.Blue);
            //}

            if (box != null)
            {
                Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

                // Clear text and border
                g.Clear(BackColor);

                // Draw text
                g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);

                // Drawing Border
                //Left
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                //Right
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Bottom
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Top1
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                //Top2
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
            }
        }

        public bool IsOnScreen(Form form, bool PutOnScreen = false)
        {
            // Create rectangle
            Rectangle formRectangle = new Rectangle(form.Left, form.Top, form.Width, form.Height);

            // Test
            bool IsOn = Screen.AllScreens.Any(s => s.WorkingArea.IntersectsWith(formRectangle));

            if (!IsOn & PutOnScreen)
            {
                form.Top = 0;
                form.Left = 0;
            }

            return IsOn;
        }

        public void LoadFormData(Form Frm)
        {
            int Leftloc = 0;
            int.TryParse(LoadProperty(Frm.Name + ".Left"), out Leftloc);
            Frm.Left = Leftloc;

            int Toploc = 0;
            int.TryParse(LoadProperty(Frm.Name + ".Top"), out Toploc);
            Frm.Top = Toploc;

            IsOnScreen(Frm, true);
        }

        public string LoadProperty(string Key)
        {
            string Prop = "";
            if (ht.Contains(Key)) Prop = ht[Key].ToString();
            return Prop;
        }

        public bool PrevInstance()
        {
            string PrsName = Process.GetCurrentProcess().ProcessName;
            Process[] All = Process.GetProcessesByName(PrsName); //Get the name of all processes having the same name as this process name
            if (All.Length > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SaveFile(string NewFile)
        {
            try
            {
                NewFile = Path.GetFileName(NewFile);
                cPropertiesFile = cSettingsDir + "\\" + NewFile;
                if (!File.Exists(cPropertiesFile)) File.Create(cPropertiesFile).Dispose();

                SaveProperties();
                Properties.Settings.Default.FileName = NewFile;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                WriteErrorLog("clsTools: SaveFile: " + ex.Message);
            }
        }

        public void SaveFormData(Form Frm)
        {
            SaveProperty(Frm.Name + ".Left", Frm.Left.ToString());
            SaveProperty(Frm.Name + ".Top", Frm.Top.ToString());
        }

        public void SaveProperty(string Key, string Value)
        {
            bool Changed = false;
            if (ht.Contains(Key))
            {
                if (!ht[Key].ToString().Equals(Value))
                {
                    ht[Key] = Value;
                    Changed = true;
                }
            }
            else
            {
                ht.Add(Key, Value);
                Changed = true;
            }
            if (Changed) SaveProperties();
        }

        public string SettingsDir()
        {
            return cSettingsDir;
        }

        public void TimedMessageBox(string s1, string s2 = "", int timeout = 3000, bool LogError = false)
        {
            var form = new FormTimedMessage(s1, s2, timeout);
            form.Show();
            if (LogError) WriteErrorLog(s1 + "  " + s2);
        }

        public string VersionDate()
        {
            return cVersionDate;
        }

        public void WriteActivityLog(string Message)
        {
            try
            {
                string FileName = cSettingsDir + "\\Activity Log.txt";
                TrimFile(FileName);
                File.AppendAllText(FileName, DateTime.Now.ToString() + "  -  " + Message + "\r\n");
            }
            catch (Exception ex)
            {
                WriteErrorLog("Tools: WriteActivityLog: " + ex.Message);
            }
        }

        public void WriteErrorLog(string strErrorText)
        {
            try
            {
                string FileName = cSettingsDir + "\\Error Log.txt";
                TrimFile(FileName);
                File.AppendAllText(FileName, DateTime.Now.ToString() + "  -  " + strErrorText + "\r\n\r\n");
            }
            catch (Exception)
            {
            }
        }

        private void CheckFolders()
        {
            try
            {
                // SettingsDir
                cSettingsDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + cAppName;
                if (!Directory.Exists(cSettingsDir))
                {
                    Directory.CreateDirectory(cSettingsDir);
                    File.WriteAllBytes(cSettingsDir + "\\Example.rcs", Properties.Resources.Example);
                }

                OpenFile(Properties.Settings.Default.FileName);
            }
            catch (Exception)
            {
            }
        }

        private void LoadProperties(string path)
        {
            // property:  key=value  ex: "LastFile=Main.mdb"
            try
            {
                ht = new Hashtable();
                string[] lines = System.IO.File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    if (line.Contains("=") && !String.IsNullOrEmpty(line.Split('=')[0]) && !String.IsNullOrEmpty(line.Split('=')[1]))
                    {
                        string[] splitText = line.Split('=');
                        ht.Add(splitText[0], splitText[1]);
                    }
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog("Tools: LoadProperties: " + ex.Message);
            }
        }

        private void OpenFile(string NewFile)
        {
            try
            {
                NewFile = Path.GetFileName(NewFile);
                cPropertiesFile = cSettingsDir + "\\" + NewFile;
                if (!File.Exists(cPropertiesFile)) File.Create(cPropertiesFile).Dispose();

                LoadProperties(cPropertiesFile);
                Properties.Settings.Default.FileName = NewFile;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                WriteErrorLog("Tools: OpenFile: " + ex.Message);
            }
        }

        private void SaveProperties()
        {
            try
            {
                string[] NewLines = new string[ht.Count];
                int i = -1;
                foreach (DictionaryEntry Pair in ht)
                {
                    i++;
                    NewLines[i] = Pair.Key.ToString() + "=" + Pair.Value.ToString();
                }
                if (i > -1) File.WriteAllLines(cPropertiesFile, NewLines);
            }
            catch (Exception)
            {
            }
        }

        private void TrimFile(string FileName, int MaxSize = 50000)
        {
            try
            {
                if (File.Exists(FileName))
                {
                    long FileSize = new FileInfo(FileName).Length;
                    if (FileSize > MaxSize)
                    {
                        // trim file
                        string[] Lines = File.ReadAllLines(FileName);
                        int Len = (int)Lines.Length;
                        int St = (int)(Len * .1); // skip first 10% of old lines
                        string[] NewLines = new string[Len - St];
                        Array.Copy(Lines, St, NewLines, 0, Len - St);
                        File.Delete(FileName);
                        File.AppendAllLines(FileName, NewLines);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public bool BitRead(byte b, int pos)
        {
            return ((b >> pos) & 1) != 0;
        }

        public byte BitSet(byte b, int pos)
        {
            return (byte)(b | (1 << pos));
        }

        public byte BitClear(byte b, int pos)
        {
            byte msk = (byte)(1 << pos);
            msk = (byte)~msk;
            return (byte)(b & msk);
        }

        public byte ParseModID(byte ID)
        {
            // top 4 bits
            return (byte)(ID >> 4);
        }

        public byte ParseSenID(byte ID)
        {
            // bottom 4 bits
            return (byte)(ID & 0b00001111);
        }

        public byte BuildModSenID(byte ArdID, byte SenID)
        {
            return (byte)((ArdID << 4) | (SenID & 0b00001111));
        }
    }
}