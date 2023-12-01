using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AgOpenGPS
{
    public partial class FormFieldISOXML : Form
    {
        //class variables
        private readonly FormGPS mf = null;
        private double easting, northing, latK, lonK;

        private XmlDocument iso;

        string xmlFilename;

        public FormFieldISOXML(Form _callingForm)
        {
            //get copy of the calling main form
            mf = _callingForm as FormGPS;

            InitializeComponent();
        }

        private void FormFieldDir_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            textBox1.Text = "a1a";
        }

        private void btnSerialCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        //private void btnAddDate_Click(object sender, EventArgs e)
        //{
        //    tboxFieldName.Text += " " + DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

        //}

        //private void btnAddTime_Click(object sender, EventArgs e)
        //{
        //    tboxFieldName.Text += " " + DateTime.Now.ToString("HH-mm", CultureInfo.InvariantCulture);

        //}

        private void btnLoadXML_Click(object sender, EventArgs e)
        {
            string newFieldDir = mf.fieldsDirectory;
            //create the dialog instance
            OpenFileDialog ofd = new OpenFileDialog
            {
                //set the filter to text KML only
                Filter = "XML files (*.XML)|*.XML",

                //the initial directory, fields, for the open dialog
                InitialDirectory = mf.fieldsDirectory + "xml\\"
        };

            //was a file selected
            if (ofd.ShowDialog() == DialogResult.Cancel) return;

            xmlFilename = ofd.FileName;

            textBox2.Text = "";

            iso = new XmlDocument();
            iso.PreserveWhitespace = false;
            iso.Load(xmlFilename);

            //first field count and names
            XmlNodeList pfd = iso.GetElementsByTagName("PFD");
            textBox2.Text = "Fields Count: " + pfd.Count + "\r\n";

            foreach (XmlNode node in pfd)
                textBox2.Text += "Field Name: " + node.Attributes["C"].Value + "\r\n";
        }

        private void btnBuildFields_Click(object sender, EventArgs e)
        {
            //get lat and lon from boundary in kml
            FindLatLon(xmlFilename);

            //reset sim and world to kml position
            CreateNewField();

            //Load the outer boundary
            LoadKMLBoundary();

        }

        private void LoadKMLBoundary()
        {
            try
            {
                XmlNodeList nodes = iso.GetElementsByTagName("PLN");

                foreach (XmlNode node in nodes) 
                {
                    foreach (XmlNode item in node.ChildNodes[0].ChildNodes) //PNT
                    {
                        string bob = item.Attributes["C"].Value;
                    }
                }

                CBoundaryList New = new CBoundaryList();
                foreach (XmlNode xmlNode in iso.DocumentElement.ChildNodes[0].ChildNodes)
                {
                    if (xmlNode.Name == "PLN")
                    {
                        if (xmlNode.Attributes["A"].Value == "1")
                        {
                            if (xmlNode.ChildNodes[0].Attributes["A"].Value == "1") //LSG
                            {
                                //Console.WriteLine(xmlNode.Attributes["A"].Value);
                                foreach (XmlNode item in xmlNode.ChildNodes[0].ChildNodes) //PNT
                                {
                                    double.TryParse(item.Attributes["C"].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out latK);
                                    double.TryParse(item.Attributes["D"].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out lonK);

                                    mf.pn.ConvertWGS84ToLocal(latK, lonK, out northing, out easting);

                                    //add the point to boundary
                                    New.fenceLine.Add(new vec3(easting, northing, 0));
                                }
                            }
                        }
                    }
                }

                //build the boundary, make sure is clockwise for outer counter clockwise for inner
                New.CalculateFenceArea(mf.bnd.bndList.Count);
                New.FixFenceLine(mf.bnd.bndList.Count);

                mf.bnd.bndList.Add(New);

                mf.btnABDraw.Visible = true;

                mf.FileSaveBoundary();
                mf.bnd.BuildTurnLines();
                mf.fd.UpdateFieldBoundaryGUIAreas();
                mf.CalculateMinMax();

                btnSave.Enabled = true;
            }
            catch (Exception)
            {
                btnSave.Enabled = false;
                return;
            }

            mf.bnd.isOkToAddPoints = false;
        }

        private void FindLatLon(string filename)
        {
            try
            {
                //at least 3 points
                double counter = 0, lat = 0, lon = 0;
                latK = lonK = 0;

                //find first polygon
                XmlNodeList nodes = iso.GetElementsByTagName("PLN");

                textBox2.Text += "Bnd Points: " + nodes[0].ChildNodes[0].ChildNodes.Count.ToString() + "\r\n";
                
                foreach (XmlNode pnt in nodes[0].ChildNodes[0].ChildNodes) //PNT
                {
                    double.TryParse(pnt.Attributes["C"].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out latK);
                    double.TryParse(pnt.Attributes["D"].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out lonK);

                    lat += latK;
                    lon += lonK;
                    counter += 1;
                }

                lonK = lon / counter;
                latK = lat / counter;

                textBox2.Text += "Field Center Longitude: " + lonK.ToString() + "\r\n";
                textBox2.Text += "Field Center Latitude: " + latK.ToString() + "\r\n";


                //foreach (XmlNode xmlNode in iso.DocumentElement.ChildNodes[0].ChildNodes)
                //{
                //    if (xmlNode.Name == "PLN")
                //    {
                //        if (xmlNode.Attributes["A"].Value == "1")
                //        {
                //            if (xmlNode.ChildNodes[0].Attributes["A"].Value == "1") //LSG
                //            {
                //                //Console.WriteLine(xmlNode.Attributes["A"].Value);
                //                foreach (XmlNode item in xmlNode.ChildNodes[0].ChildNodes) //PNT
                //                {
                //                    double.TryParse(item.Attributes["C"].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out latK);
                //                    double.TryParse(item.Attributes["D"].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out lonK);
                //
                //                    lat += latK;
                //                    lon += lonK;
                //                    counter += 1;
                //                }
                //            }
                //        }
                //    }
                //}
            }
            catch (Exception)
            {
                mf.TimedMessageBox(2000, "Exception", "Catch Exception");
                return;
            }
        }

        private void CreateNewField()
        {
            //append date time to name

            mf.currentFieldDirectory = textBox1.Text.Trim() + " " + DateTime.Now.ToString("HH-mm", CultureInfo.InvariantCulture).Trim();

            //get the directory and make sure it exists, create if not
            string dirNewField = mf.fieldsDirectory + mf.currentFieldDirectory + "\\";

            mf.menustripLanguage.Enabled = false;
            //if no template set just make a new file.
            try
            {
                //start a new job
                //mf.JobNew();

                //create it for first save
                string directoryName = Path.GetDirectoryName(dirNewField);

                if ((!string.IsNullOrEmpty(directoryName)) && (Directory.Exists(directoryName)))
                {
                    MessageBox.Show(gStr.gsChooseADifferentName, gStr.gsDirectoryExists, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    mf.pn.latStart = latK;
                    mf.pn.lonStart = lonK;

                    if (mf.timerSim.Enabled)
                    {
                        mf.sim.latitude = Properties.Settings.Default.setGPS_SimLatitude = latK;
                        mf.sim.longitude = Properties.Settings.Default.setGPS_SimLongitude = lonK;

                        mf.pn.latitude = latK;
                        mf.pn.longitude = lonK;

                        Properties.Settings.Default.Save();
                    }

                    mf.pn.SetLocalMetersPerDegree();

                    //make sure directory exists, or create it
                    if ((!string.IsNullOrEmpty(directoryName)) && (!Directory.Exists(directoryName)))
                    { Directory.CreateDirectory(directoryName); }

                    mf.displayFieldName = mf.currentFieldDirectory;

                    //create the field file header info

                    //if (!mf.isJobStarted)
                    //{
                    //    using (FormTimedMessage form = new FormTimedMessage(3000, gStr.gsFieldNotOpen, gStr.gsCreateNewField))
                    //    { form.Show(this); }
                    //    return;
                    //}
                    string myFileName, dirField;

                    //get the directory and make sure it exists, create if not
                    dirField = mf.fieldsDirectory + mf.currentFieldDirectory + "\\";
                    directoryName = Path.GetDirectoryName(dirField);

                    if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
                    { Directory.CreateDirectory(directoryName); }

                    myFileName = "Field.txt";

                    using (StreamWriter writer = new StreamWriter(dirField + myFileName))
                    {
                        //Write out the date
                        writer.WriteLine(DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss tt", CultureInfo.InvariantCulture));

                        writer.WriteLine("$FieldDir");
                        writer.WriteLine("XML Derived");

                        //write out the easting and northing Offsets
                        writer.WriteLine("$Offsets");
                        writer.WriteLine("0,0");

                        writer.WriteLine("Convergence");
                        writer.WriteLine("0");

                        writer.WriteLine("StartFix");
                        writer.WriteLine(mf.pn.latStart.ToString(CultureInfo.InvariantCulture) + "," + mf.pn.lonStart.ToString(CultureInfo.InvariantCulture));
                    }

                    mf.FileCreateSections();
                    mf.FileCreateRecPath();
                    mf.FileCreateContour();
                    mf.FileCreateElevation();
                    mf.FileSaveFlags();
                    //mf.FileSaveABLine();
                    //mf.FileSaveCurveLine();
                    //mf.FileSaveHeadland();
                }
            }
            catch (Exception ex)
            {
                mf.WriteErrorLog("Creating new field " + ex);

                MessageBox.Show(gStr.gsError, ex.ToString());
                mf.currentFieldDirectory = "";
            }
        }
    }
}
