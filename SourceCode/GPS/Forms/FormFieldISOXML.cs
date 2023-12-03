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

        private int idxFieldSelected = -1;

        public FormFieldISOXML(Form _callingForm)
        {
            //get copy of the calling main form
            mf = _callingForm as FormGPS;

            InitializeComponent();
        }

        private void FormFieldISOXML_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            textBox1.Text = "a1a";
        }

        XmlNodeList pfd;
        private void btnLoadXML_Click(object sender, EventArgs e)
        {
            string newFieldDir = mf.fieldsDirectory;
            tree.Nodes?.Clear();

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
            //xmlFilename = "C:\\Users\\Grizs\\Documents\\AgOpenGPS\\Fields\\xml\\TASKDATARich3.XML";

            iso = new XmlDocument();
            iso.PreserveWhitespace = false;
            iso.Load(xmlFilename);

            //Partial Field Group
            //PFD - A = Field ID, B = , C = Field Name, D = Area

            pfd = iso.GetElementsByTagName("PFD");
            //textBox2.Text = "Fields Count: " + pfd.Count + "\r\n";

            //scan thru all the fields
            foreach (XmlNode nodePFD in pfd)
            {
                double area;
                double.TryParse(nodePFD.Attributes["D"].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out area);
                area *= 0.0001;

                //textBox2.Text += //"ID: " + nodePFD.Attributes["A"].Value + 
                //                "Field Name: " + nodePFD.Attributes["C"].Value + 
                //                "\tArea: " + area + " Ha \r\n";
                tree.Nodes.Add(nodePFD.Attributes["C"].Value + " Area: " + area + " Ha");

                //nodes in current Partial Field like PLN, GGP, LSG etc
                XmlNodeList fieldParts = nodePFD.ChildNodes;

                //do the boundary first - find all the polygons (PLN)
                foreach (XmlNode nodePart in fieldParts)
                {
                    //grab the polygons
                    if (nodePart.Name == "PLN")
                    {
                        // "A" is the Polygon Type - usually 1 or 2
                        //textBox2.Text += "Node: " + nodePart.Name + "\tType: " + nodePart.Attributes["A"].Value + "\r\n";
                        tree.Nodes[tree.Nodes.Count - 1].Nodes.Add(
                            "Boundary: " + nodePart.Attributes["A"].Value +
                            "   Points: " + nodePart.ChildNodes[0].ChildNodes.Count);

                        // PLN/LSG/PNT Count the points
                        //textBox2.Text += "Bnd Points: " + nodePart.ChildNodes[0].ChildNodes.Count.ToString() + "\r\n";
                    }
                }

                //First kind of Gudance  GGP\GPN\LSG\PNT
                foreach (XmlNode nodePart in fieldParts)
                {
                    if (nodePart.Name == "GGP")
                    {
                        //in GPN "B" is the name and "C" is the type
                        //textBox2.Text += nodePart.ChildNodes[0].Attributes["B"].Value
                        //    + " LineType: " + nodePart.ChildNodes[0].Attributes["C"].Value;

                        //LSG in current Partial Field like PLN, GGP, LSG etc
                        //textBox2.Text += "  Line Points: " + nodePart.ChildNodes[0].ChildNodes[0].ChildNodes.Count.ToString() + "\r\n";

                        if (nodePart.ChildNodes[0].Attributes["C"].Value == "1")
                            tree.Nodes[tree.Nodes.Count - 1].Nodes.Add("ABLine: " + nodePart.ChildNodes[0].Attributes["B"].Value);
                        else if (nodePart.ChildNodes[0].Attributes["C"].Value == "2")
                            tree.Nodes[tree.Nodes.Count - 1].Nodes.Add("A+: " + nodePart.ChildNodes[0].Attributes["B"].Value);
                        else if (nodePart.ChildNodes[0].Attributes["C"].Value == "3")
                            tree.Nodes[tree.Nodes.Count - 1].Nodes.Add("Curve: " + nodePart.ChildNodes[0].Attributes["B"].Value);
                        else if (nodePart.ChildNodes[0].Attributes["C"].Value == "4")
                            tree.Nodes[tree.Nodes.Count - 1].Nodes.Add("Pivot: " + nodePart.ChildNodes[0].Attributes["B"].Value);
                        else if (nodePart.ChildNodes[0].Attributes["C"].Value == "5")
                            tree.Nodes[tree.Nodes.Count - 1].Nodes.Add("Spiral: " + nodePart.ChildNodes[0].Attributes["B"].Value);
                    }
                }

                //Second type of Gudance LSG\PNT
                foreach (XmlNode nodePart in fieldParts)
                {
                    //LSG with a "5" in [A] means Guidance line [B] is the name of line
                    if (nodePart.Name == "LSG" && nodePart.Attributes["A"].Value == "5")
                    {
                        //textBox2.Text += "Guidance Line: " + nodePart.Attributes["B"].Value
                        //    + "  LineType: " + nodePart.Attributes["A"].Value;

                        //PNT is 1 node down
                        //textBox2.Text += "  Line Points: " + nodePart.ChildNodes.Count + "\r\n";

                        if (nodePart.ChildNodes[0].ChildNodes[0].ChildNodes.Count < 3)
                            tree.Nodes[tree.Nodes.Count - 1].Nodes.Add("ABLine: " + nodePart.Attributes["B"].Value);
                        else
                            tree.Nodes[tree.Nodes.Count - 1].Nodes.Add("Curve: " + nodePart.Attributes["B"].Value);

                    }
                }

            }
        }

        private void btnBuildFields_Click(object sender, EventArgs e)
        {
            //get lat and lon from boundary in kml
            try
            {
                //at least 3 points
                double counter = 0, lat = 0, lon = 0;
                latK = lonK = 0;

                //extract field name from selected tree node
                textBox1.Text = pfd[idxFieldSelected].Attributes["C"].Value;

                //Find the PLN in the field
                XmlNodeList fieldParts = pfd[idxFieldSelected].ChildNodes;

                foreach (XmlNode nodePart in fieldParts)
                {
                    //grab the polygons
                    if (nodePart.Name == "PLN")
                    {

                        foreach (XmlNode pnt in nodePart.ChildNodes[0].ChildNodes) //PNT
                        {
                            double.TryParse(pnt.Attributes["C"].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out latK);
                            double.TryParse(pnt.Attributes["D"].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out lonK);

                            lat += latK;
                            lon += lonK;
                            counter += 1;
                        }
                    }
                }

                lonK = lon / counter;
                latK = lat / counter;

            }
            catch (Exception)
            {
                mf.TimedMessageBox(2000, "Exception", "Catch Exception");
                return;
            }

            //reset sim and world to kml position
            //append date time to name

            mf.currentFieldDirectory = textBox1.Text.Trim() + " " + DateTime.Now.ToString("HH-mm", CultureInfo.InvariantCulture).Trim();

            //get the directory and make sure it exists, create if not
            string dirNewField = mf.fieldsDirectory + mf.currentFieldDirectory + "\\";

            mf.menustripLanguage.Enabled = false;
            //if no template set just make a new file.
            try
            {
                //start a new job
                mf.JobNew();

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

                    if (!mf.isJobStarted)
                    {
                        using (FormTimedMessage form = new FormTimedMessage(3000, gStr.gsFieldNotOpen, gStr.gsCreateNewField))
                        { form.Show(this); }
                        return;
                    }
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

            //Load the outer boundary
            try
            {
                XmlNodeList fieldParts = pfd[idxFieldSelected].ChildNodes;
                CBoundaryList NewList = new CBoundaryList();

                foreach (XmlNode nodePart in fieldParts)
                {
                    //grab the polygons
                    if (nodePart.Name == "PLN")
                    {
                        if (nodePart.Attributes["A"].Value == "1")
                        {
                            if (nodePart.ChildNodes[0].Attributes["A"].Value == "1") //LSG
                            {

                                foreach (XmlNode pnt in nodePart.ChildNodes[0].ChildNodes) //PNT
                                {
                                    double.TryParse(pnt.Attributes["C"].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out latK);
                                    double.TryParse(pnt.Attributes["D"].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out lonK);

                                    mf.pn.ConvertWGS84ToLocal(latK, lonK, out northing, out easting);

                                    //add the point to boundary
                                    NewList.fenceLine.Add(new vec3(easting, northing, 0));
                                }
                            }
                        }
                    }
                }

                //build the boundary, make sure is clockwise for outer counter clockwise for inner
                NewList.CalculateFenceArea(mf.bnd.bndList.Count);
                NewList.FixFenceLine(mf.bnd.bndList.Count);

                mf.bnd.bndList.Add(NewList);

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
                //XmlNodeList nodes = iso.GetElementsByTagName("PLN");

                //Find the PLN in the field
                XmlNodeList fieldParts = pfd[idxFieldSelected].ChildNodes;

                foreach (XmlNode nodePart in fieldParts)
                {
                    //grab the polygons
                    if (nodePart.Name == "PLN")
                    {

                        foreach (XmlNode pnt in nodePart.ChildNodes[0].ChildNodes) //PNT
                        {
                            double.TryParse(pnt.Attributes["C"].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out latK);
                            double.TryParse(pnt.Attributes["D"].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out lonK);

                            lat += latK;
                            lon += lonK;
                            counter += 1;
                        }
                    }
                }

                lonK = lon / counter;
                latK = lat / counter;

                //textBox2.Text += "Field Center Longitude: " + lonK.ToString() + "\r\n";
                //textBox2.Text += "Field Center Latitude: " + latK.ToString() + "\r\n";


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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //tree.sel
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tree.SelectedNode.Parent == null)
            {
                if (tree.SelectedNode.Index != null)
                {
                    idxFieldSelected = tree.SelectedNode.Index;
                    lblField.Text = idxFieldSelected.ToString() + " " + pfd[idxFieldSelected].Attributes["C"].Value;
                    textBox1.Text = pfd[idxFieldSelected].Attributes["C"].Value;
                }
                else
                {
                    lblField.Text = "";
                    textBox1.Text = "";
                }
            }
            else
            {
                idxFieldSelected = tree.SelectedNode.Parent.Index;
                lblField.Text = idxFieldSelected.ToString() + " " + pfd[idxFieldSelected].Attributes["C"].Value;
                textBox1.Text = pfd[idxFieldSelected].Attributes["C"].Value;
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
    }
}

