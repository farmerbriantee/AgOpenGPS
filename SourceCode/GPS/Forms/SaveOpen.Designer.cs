﻿using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Xml;
using System.Text;
using AgOpenGPS.Culture;

namespace AgOpenGPS
{
    
    public partial class FormGPS
    {
        //list of the list of patch data individual triangles for field sections
        public List<List<vec3>> patchSaveList = new List<List<vec3>>();

        //list of the list of patch data individual triangles for contour tracking
        public List<List<vec3>> contourSaveList = new List<List<vec3>>();

        public void ExportFieldAs_ISOXMLv3()
        {
            //if (bnd.bndList.Count < 1) return;//If no Bnd, Quit

            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\zISOXML\\v3\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string myFileName = "TASKDATA.xml";

            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "  ";
                XmlWriter xml = XmlWriter.Create(dirField + myFileName, settings);

                xml.WriteStartElement("ISO11783_TaskData");//Settings
                xml.WriteAttributeString("DataTransferOrigin", "1");
                xml.WriteAttributeString("ManagementSoftwareManufacturer", "AgOpenGPS");
                xml.WriteAttributeString("ManagementSoftwareVersion", "1.4.0");
                xml.WriteAttributeString("VersionMajor", "3");
                xml.WriteAttributeString("VersionMinor", "3");

                {
                    //PFD A = "Field ID" B = "Code" C = "Name" D = "Area sq m" E = "Customer Ref" F = "Farm Ref" >
                    xml.WriteStartElement("PFD");//Field
                    xml.WriteAttributeString("A", "PFD-1");
                    xml.WriteAttributeString("C", currentFieldDirectory);
                    xml.WriteAttributeString("D", ((int)(fd.areaOuterBoundary)).ToString());

                    double lat = 0;
                    double lon = 0;

                    {
                        //all the boundaries
                        /*
                        < PLN A = "1" C="Area in Sq M like 12568" >
                            < LSG A = "1" >
                                < PNT A = "2" C = "51.61918340" D = "4.51054560" />
                                < PNT A = "2" C = "51.61915460" D = "4.51056120" />
                            </ LSG >
                        </ PLN >
                        */
                        for (int i = 0; i < bnd.bndList.Count; i++)
                        {
                            xml.WriteStartElement("PLN");//BND

                            if (i == 0) xml.WriteAttributeString("A", "1"); //outerBnd
                            else xml.WriteAttributeString("A", "6");  //innerBnd

                            xml.WriteStartElement("LSG");//Polygon
                            xml.WriteAttributeString("A", "1");

                            for (int j = 0; j < bnd.bndList[i].fenceLineEar.Count; j++)
                            {

                                pn.ConvertLocalToWGS84(bnd.bndList[i].fenceLineEar[j].northing, bnd.bndList[i].fenceLineEar[j].easting, out lat, out lon);
                                xml.WriteStartElement("PNT");//Boundary Points
                                xml.WriteAttributeString("A", "2");
                                xml.WriteAttributeString("C", lat.ToString());
                                xml.WriteAttributeString("D", lon.ToString());
                                xml.WriteEndElement(); //Boundary Points                   
                            }

                            xml.WriteEndElement();//Polygon
                            xml.WriteEndElement();//BND
                        }

                        //all the headlands A=10
                        if (bnd.bndList.Count > 0)
                        {
                            for (int i = 0; i < bnd.bndList.Count; i++)
                            {
                                if (bnd.bndList[i].hdLine.Count < 1) continue;

                                xml.WriteStartElement("PLN");//BND

                                xml.WriteAttributeString("A", "10"); //headland

                                xml.WriteStartElement("LSG");//Polygon
                                xml.WriteAttributeString("A", "1");

                                for (int j = 0; j < bnd.bndList[i].hdLine.Count; j++)
                                {
                                    pn.ConvertLocalToWGS84(bnd.bndList[i].hdLine[j].northing, bnd.bndList[i].hdLine[j].easting, out lat, out lon);
                                    xml.WriteStartElement("PNT");//Boundary Points
                                    xml.WriteAttributeString("A", "2");
                                    xml.WriteAttributeString("C", lat.ToString());
                                    xml.WriteAttributeString("D", lon.ToString());
                                    xml.WriteEndElement(); //Boundary Points                   
                                }

                                xml.WriteEndElement();//Polygon
                                xml.WriteEndElement();//BND
                            }
                        }

                        //AB Lines
                        /*
                        LSG A = "5" B = "Line Name" >
                            < PNT A = "2" C = "51.61851540" D = "4.51137030" />
                            < PNT A = "2" C = "51.61912230" D = "4.51056060" />
                        </ LSG >
                        */

                        if (trk.gArr != null && trk.gArr.Count > 0)
                        {
                            for (int i = 0; i < trk.gArr.Count; i++)
                            {
                                xml.WriteStartElement("LSG");//Line
                                xml.WriteAttributeString("A", "5");
                                xml.WriteAttributeString("B", trk.gArr[i].name);
                                ///xml.WriteAttributeString("C", (tool.width).ToString());
                                {
                                    xml.WriteStartElement("PNT");//A

                                    pn.ConvertLocalToWGS84(trk.gArr[i].ptA.northing - (Math.Cos(trk.gArr[i].heading) * 1000),
                                        trk.gArr[i].ptA.easting - (Math.Sin(trk.gArr[i].heading) * 1000), out lat, out lon);

                                    xml.WriteAttributeString("A", "2");
                                    xml.WriteAttributeString("C", lat.ToString());
                                    xml.WriteAttributeString("D", lon.ToString());

                                    xml.WriteEndElement();//A
                                    xml.WriteStartElement("PNT");//B

                                    pn.ConvertLocalToWGS84(trk.gArr[i].ptA.northing + (Math.Cos(trk.gArr[i].heading) * 1000),
                                        trk.gArr[i].ptA.easting + (Math.Sin(trk.gArr[i].heading) * 1000), out lat, out lon);

                                    xml.WriteAttributeString("A", "2");

                                    xml.WriteAttributeString("C", lat.ToString());
                                    xml.WriteAttributeString("D", lon.ToString());
                                }
                                xml.WriteEndElement();//B
                                xml.WriteEndElement();//Line
                            }
                        }

                        //curves
                        /*
                        LSG A = "5" B = "Name Here" >
                            < PNT A = "2" C = "51.61851540" D = "4.51137030" />
                            < PNT A = "2" C = "51.61912230" D = "4.51056060" />
                            < PNT A = "2" C = "51.61962230" D = "4.51056760" />
                        </ LSG >
                        */
                        if (trk.gArr != null && trk.gArr.Count > 0)
                        {
                            for (int i = 0; i < trk.gArr.Count; i++)
                            {
                                xml.WriteStartElement("LSG");//Curve
                                xml.WriteAttributeString("A", "5"); //denotes guidance
                                xml.WriteAttributeString("B", trk.gArr[i].name);
                                //xml.WriteAttributeString("C", (tool.width).ToString());

                                for (int j = 0; j < trk.gArr[i].curvePts.Count; j++)
                                {
                                    xml.WriteStartElement("PNT");//point
                                    pn.ConvertLocalToWGS84(trk.gArr[i].curvePts[j].northing,
                                        trk.gArr[i].curvePts[j].easting, out lat, out lon);

                                    xml.WriteAttributeString("A", "2");
                                    xml.WriteAttributeString("C", lat.ToString());
                                    xml.WriteAttributeString("D", lon.ToString());

                                    xml.WriteEndElement();//point
                                }
                                xml.WriteEndElement(); //Curve   
                            }
                        }
                    }

                    //Last
                    xml.WriteEndElement();//End Field
                }

                xml.WriteEndElement();//ISO11783_TaskData Settings

                xml.Flush();

                //Write the XML to file and close the kml
                xml.Close();

            }
            catch (Exception)
            {
                //throw;
            }
        }

        public void ExportFieldAs_ISOXMLv4()
        {
            int lineCounter = 0;

            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\zISOXML\\v4\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }
           
            string myFileName = "TASKDATA.xml";

            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "  ";
                XmlWriter xml = XmlWriter.Create(dirField + myFileName, settings);

                xml.WriteStartElement("ISO11783_TaskData");//Settings
                xml.WriteAttributeString("DataTransferOrigin", "1");
                xml.WriteAttributeString("ManagementSoftwareManufacturer", "AgOpenGPS");
                xml.WriteAttributeString("ManagementSoftwareVersion", "1.4.0");
                xml.WriteAttributeString("VersionMajor", "4");
                xml.WriteAttributeString("VersionMinor", "2");

                {
                    //PFD A = "Field ID" B = "Code" C = "Name" D = "Area sq m" E = "Customer Ref" F = "Farm Ref" >
                    xml.WriteStartElement("PFD");//Field
                    xml.WriteAttributeString("A", "PFD-1");
                    xml.WriteAttributeString("C", currentFieldDirectory);
                    xml.WriteAttributeString("D", ((int)(fd.areaOuterBoundary)).ToString());

                    double lat = 0;
                    double lon = 0;

                    {
                        //all the boundaries
                        /*
                        < PLN A = "1" C="Area in Sq M like 12568" >
                            < LSG A = "1" >
                                < PNT A = "2" C = "51.61918340" D = "4.51054560" />
                                < PNT A = "2" C = "51.61915460" D = "4.51056120" />
                            </ LSG >
                        </ PLN >
                        */
                        for (int i = 0; i < bnd.bndList.Count; i++)
                        {
                            xml.WriteStartElement("PLN");//BND

                            if (i == 0) xml.WriteAttributeString("A", "1"); //outerBnd
                            else xml.WriteAttributeString("A", "6");  //innerBnd

                            xml.WriteStartElement("LSG");//Polygon
                            xml.WriteAttributeString("A", "1");

                            for (int j = 0; j < bnd.bndList[i].fenceLineEar.Count; j++)
                            {

                                pn.ConvertLocalToWGS84(bnd.bndList[i].fenceLineEar[j].northing, bnd.bndList[i].fenceLineEar[j].easting, out lat, out lon);
                                xml.WriteStartElement("PNT");//Boundary Points
                                xml.WriteAttributeString("A", "10");
                                xml.WriteAttributeString("C", lat.ToString());
                                xml.WriteAttributeString("D", lon.ToString());
                                xml.WriteEndElement(); //Boundary Points                   
                            }

                            xml.WriteEndElement();//Polygon
                            xml.WriteEndElement();//BND
                        }

                        //all the headlands A=10
                        if (bnd.bndList.Count > 0)
                        {
                            for (int i = 0; i < bnd.bndList.Count; i++)
                            {
                                if (bnd.bndList[i].hdLine.Count < 1) continue;

                                xml.WriteStartElement("PLN");//BND

                                xml.WriteAttributeString("A", "10"); //headland

                                xml.WriteStartElement("LSG");//Polygon
                                xml.WriteAttributeString("A", "1");

                                for (int j = 0; j < bnd.bndList[i].hdLine.Count; j++)
                                {
                                    pn.ConvertLocalToWGS84(bnd.bndList[i].hdLine[j].northing, bnd.bndList[i].hdLine[j].easting, out lat, out lon);
                                    xml.WriteStartElement("PNT");//Boundary Points
                                    xml.WriteAttributeString("A", "10");
                                    xml.WriteAttributeString("C", lat.ToString());
                                    xml.WriteAttributeString("D", lon.ToString());
                                    xml.WriteEndElement(); //Boundary Points                   
                                }

                                xml.WriteEndElement();//Polygon
                                xml.WriteEndElement();//BND
                            }
                        }

                        //AB Lines
                        /*
                        LSG A = "5" B = "Line Name" >
                            < PNT A = "2" C = "51.61851540" D = "4.51137030" />
                            < PNT A = "2" C = "51.61912230" D = "4.51056060" />
                        </ LSG >
                        */

                        if (trk.gArr != null && trk.gArr.Count > 0)
                        {
                            for (int i = 0; i < trk.gArr.Count; i++)
                            {
                                xml.WriteStartElement("GGP");//Guide-P
                                string name = "GGP" + lineCounter.ToString();
                                lineCounter++;
                                xml.WriteAttributeString("A", name);
                                xml.WriteAttributeString("B", trk.gArr[i].name);
                                {
                                    xml.WriteStartElement("GPN");//Guide-N
                                    xml.WriteAttributeString("A", name);
                                    xml.WriteAttributeString("B", trk.gArr[i].name);
                                    xml.WriteAttributeString("C", "1");
                                    xml.WriteAttributeString("E", "1");
                                    xml.WriteAttributeString("F", "1");
                                    xml.WriteAttributeString("I", "16");
                                    {
                                        xml.WriteStartElement("LSG");//Line
                                        xml.WriteAttributeString("A", "5");
                                        {
                                            xml.WriteStartElement("PNT");//A

                                            pn.ConvertLocalToWGS84(trk.gArr[i].ptA.northing - (Math.Cos(trk.gArr[i].heading) * 1000),
                                                trk.gArr[i].ptA.easting - (Math.Sin(trk.gArr[i].heading) * 1000), out lat, out lon);

                                            xml.WriteAttributeString("A", "6");
                                            xml.WriteAttributeString("C", lat.ToString());
                                            xml.WriteAttributeString("D", lon.ToString());

                                            xml.WriteEndElement();//A
                                            xml.WriteStartElement("PNT");//B

                                            pn.ConvertLocalToWGS84(trk.gArr[i].ptA.northing + (Math.Cos(trk.gArr[i].heading) * 1000),
                                                trk.gArr[i].ptA.easting + (Math.Sin(trk.gArr[i].heading) * 1000), out lat, out lon);

                                            xml.WriteAttributeString("A", "7");

                                            xml.WriteAttributeString("C", lat.ToString());
                                            xml.WriteAttributeString("D", lon.ToString());
                                            xml.WriteEndElement();//B
                                        }
                                        xml.WriteEndElement();//Line
                                    }
                                    xml.WriteEndElement(); //Guide-N
                                }
                                xml.WriteEndElement(); //Guide-P
                            }
                        }

                        //curves
                        /*
                        LSG A = "5" B = "Name Here" >
                            < PNT A = "2" C = "51.61851540" D = "4.51137030" />
                            < PNT A = "2" C = "51.61912230" D = "4.51056060" />
                            < PNT A = "2" C = "51.61962230" D = "4.51056760" />
                        </ LSG >
                        */

                        if (trk.gArr != null && trk.gArr.Count > 0)
                        {
                            for (int i = 0; i < trk.gArr.Count; i++)
                            {
                                xml.WriteStartElement("GGP");//Guide-P
                                string name = "GGP" + lineCounter.ToString();
                                lineCounter++;
                                xml.WriteAttributeString("A", name);
                                xml.WriteAttributeString("B", trk.gArr[i].name);
                                {
                                    xml.WriteStartElement("GPN");//Guide-N
                                    xml.WriteAttributeString("A", name);
                                    xml.WriteAttributeString("B", trk.gArr[i].name);
                                    xml.WriteAttributeString("C", "3");
                                    xml.WriteAttributeString("E", "1");
                                    xml.WriteAttributeString("F", "1");
                                    xml.WriteAttributeString("I", "16");
                                    {
                                        xml.WriteStartElement("LSG");//Curve
                                        xml.WriteAttributeString("A", "5"); //denotes guidance

                                        for (int j = 0; j < trk.gArr[i].curvePts.Count; j++)
                                        {
                                            xml.WriteStartElement("PNT");//point
                                            pn.ConvertLocalToWGS84(trk.gArr[i].curvePts[j].northing,
                                                trk.gArr[i].curvePts[j].easting, out lat, out lon);
                                            if (j == 0)
                                            {
                                                xml.WriteAttributeString("A", "6");
                                            }
                                            else if (j == trk.gArr[i].curvePts.Count - 1)
                                            {
                                                xml.WriteAttributeString("A", "7");
                                            }
                                            else
                                            {
                                                xml.WriteAttributeString("A", "9");
                                            }
                                            xml.WriteAttributeString("C", lat.ToString());
                                            xml.WriteAttributeString("D", lon.ToString());

                                            xml.WriteEndElement();//point
                                        }
                                        xml.WriteEndElement(); //end LSG curve
                                    }
                                    xml.WriteEndElement(); //Guide-N
                                }
                                xml.WriteEndElement(); //Guide-P
                            }
                        }
                    }

                    //Last
                    xml.WriteEndElement();//End Field
                }

                xml.WriteEndElement();//ISO11783_TaskData Settings

                xml.Flush();

                //Write the XML to file and close the kml
                xml.Close();

        }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

    /*
        //xml.WriteStartElement("TSK");//Task
        //xml.WriteAttributeString("A", "TSK1");
        //xml.WriteAttributeString("B", "Tractor Work");
        //xml.WriteAttributeString("C", "CTR1");
        //xml.WriteAttributeString("E", "PFD-1");
        //xml.WriteAttributeString("G", "1");
        //xml.WriteAttributeString("I", "1");
        //xml.WriteAttributeString("J", "0");
        //xml.WriteEndElement();//Task
    */

}

        public void FileSaveHeadLines()
        {
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField).ToString(CultureInfo.InvariantCulture);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string filename = directoryName + "\\Headlines.txt";

            int cnt = hdl.tracksArr.Count;

            using (StreamWriter writer = new StreamWriter(filename, false))
            {
                try
                {
                    if (cnt > 0)
                    {
                        writer.WriteLine("$HeadLines");

                        for (int i = 0; i < cnt; i++)
                        {
                            //write out the name
                            writer.WriteLine(hdl.tracksArr[i].name);


                            //write out the moveDistance
                            writer.WriteLine(hdl.tracksArr[i].moveDistance.ToString(CultureInfo.InvariantCulture));

                            //write out the mode
                            writer.WriteLine(hdl.tracksArr[i].mode.ToString(CultureInfo.InvariantCulture));
                            
                            //write out the A_Point index
                            writer.WriteLine(hdl.tracksArr[i].a_point.ToString(CultureInfo.InvariantCulture));

                            //write out the points of ref line
                            int cnt2 = hdl.tracksArr[i].trackPts.Count;

                            writer.WriteLine(cnt2.ToString(CultureInfo.InvariantCulture));
                            if (hdl.tracksArr[i].trackPts.Count > 0)
                            {
                                for (int j = 0; j < cnt2; j++)
                                    writer.WriteLine(Math.Round(hdl.tracksArr[i].trackPts[j].easting, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                                        Math.Round(hdl.tracksArr[i].trackPts[j].northing, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                                            Math.Round(hdl.tracksArr[i].trackPts[j].heading, 5).ToString(CultureInfo.InvariantCulture));
                            }
                        }
                    }
                    else
                    {
                        writer.WriteLine("$HeadLines");
                        return;
                    }
                }
                catch (Exception er)
                {
                    WriteErrorLog("Saving Head Lines" + er.ToString());

                    return;
                }
            }
        }

        public void FileLoadHeadLines()
        {
            hdl.tracksArr?.Clear();

            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string filename = directoryName + "\\Headlines.txt";

            if (!File.Exists(filename))
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine("$Headlines");
                }
            }

            //get the file of previous AB Lines
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            if (!File.Exists(filename))
            {
                TimedMessageBox(2000, gStr.gsFileError, "Missing Headlines File");
                SystemEventWriter("Load Field, Missing Headlines File");
            }
            else
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    try
                    {
                        string line;

                        //read header $CurveLine
                        line = reader.ReadLine();

                        while (!reader.EndOfStream)
                        {

                            hdl.tracksArr.Add(new CHeadPath());
                            hdl.idx = hdl.tracksArr.Count - 1;

                            //read header $CurveLine
                            hdl.tracksArr[hdl.idx].name = reader.ReadLine();

                            line = reader.ReadLine();
                            hdl.tracksArr[hdl.idx].moveDistance = double.Parse(line, CultureInfo.InvariantCulture);

                            line = reader.ReadLine();
                            hdl.tracksArr[hdl.idx].mode = int.Parse(line, CultureInfo.InvariantCulture);

                            line = reader.ReadLine();
                            hdl.tracksArr[hdl.idx].a_point = int.Parse(line, CultureInfo.InvariantCulture);

                            line = reader.ReadLine();
                            int numPoints = int.Parse(line);

                            if (numPoints > 3)
                            {
                                hdl.tracksArr[hdl.idx].trackPts?.Clear();

                                for (int i = 0; i < numPoints; i++)
                                {
                                    line = reader.ReadLine();
                                    string[] words = line.Split(',');
                                    vec3 vecPt = new vec3(double.Parse(words[0], CultureInfo.InvariantCulture),
                                        double.Parse(words[1], CultureInfo.InvariantCulture),
                                        double.Parse(words[2], CultureInfo.InvariantCulture));
                                    hdl.tracksArr[hdl.idx].trackPts.Add(vecPt);
                                }
                            }
                            else
                            {
                                if (hdl.tracksArr.Count > 0)
                                {
                                    hdl.tracksArr.RemoveAt(hdl.idx);
                                }
                            }
                        }
                    }

                    catch (Exception er)
                    {
                        hdl.tracksArr?.Clear();

                        var form = new FormTimedMessage(2000, "Headline Error", "Lines Deleted");
                        form.Show(this);

                        dirField = fieldsDirectory + currentFieldDirectory + "\\";
                        directoryName = Path.GetDirectoryName(dirField).ToString(CultureInfo.InvariantCulture);

                        if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
                        { Directory.CreateDirectory(directoryName); }

                        filename = directoryName + "\\Headlines.txt";

                        using (StreamWriter writer = new StreamWriter(filename, false))
                        {
                            try
                            {
                                writer.WriteLine("$Headlines");
                                return;

                            }
                            catch { }
                        }
                        WriteErrorLog("Load Head Lines" + er.ToString());
                    }
                }
            }

            hdl.idx = -1;
        }

        public void FileSaveTracks()
        {
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField).ToString(CultureInfo.InvariantCulture);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string filename = directoryName + "\\TrackLines.txt";

            int cnt = trk.gArr.Count;

            using (StreamWriter writer = new StreamWriter(filename, false))
            {
                try
                {
                    if (cnt > 0)
                    {
                        writer.WriteLine("$TrackLines");

                        for (int i = 0; i < cnt; i++)
                        {
                            //write out the name
                            writer.WriteLine(trk.gArr[i].name);

                            //write out the heading
                            writer.WriteLine(trk.gArr[i].heading.ToString(CultureInfo.InvariantCulture));

                            //A nd B
                            writer.WriteLine(Math.Round(trk.gArr[i].ptA.easting, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                                Math.Round(trk.gArr[i].ptA.northing, 3).ToString(CultureInfo.InvariantCulture));
                            writer.WriteLine(Math.Round(trk.gArr[i].ptB.easting, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                                Math.Round(trk.gArr[i].ptB.northing, 3).ToString(CultureInfo.InvariantCulture));

                            //write out the nudgeDistance
                            writer.WriteLine(trk.gArr[i].nudgeDistance.ToString(CultureInfo.InvariantCulture));

                            //write out the mode
                            writer.WriteLine(((int)trk.gArr[i].mode).ToString(CultureInfo.InvariantCulture));

                            //visible?
                            writer.WriteLine(trk.gArr[i].isVisible.ToString(CultureInfo.InvariantCulture));

                            //write out the points of ref line
                            int cnt2 = trk.gArr[i].curvePts.Count;

                            writer.WriteLine(cnt2.ToString(CultureInfo.InvariantCulture));
                            if (trk.gArr[i].curvePts.Count > 0)
                            {
                                for (int j = 0; j < cnt2; j++)
                                    writer.WriteLine(Math.Round(trk.gArr[i].curvePts[j].easting, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                                        Math.Round(trk.gArr[i].curvePts[j].northing, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                                            Math.Round(trk.gArr[i].curvePts[j].heading, 5).ToString(CultureInfo.InvariantCulture));
                            }
                        }
                    }
                    else
                    {
                        writer.WriteLine("$TrackLines");
                        return;
                    }
                }
                catch (Exception er)
                {
                    WriteErrorLog("Saving Curve Line" + er.ToString());

                    return;
                }
            }

            if (trk.idx > (trk.gArr.Count - 1)) trk.idx = trk.gArr.Count - 1;

            FileSaveABLines();
            FileSaveCurveLines();
        }

        public void FileLoadTracks()
        {
            trk.gArr?.Clear();

            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string filename = directoryName + "\\TrackLines.txt";

            if (!File.Exists(filename))
            {
                FileLoadABLines();
                FileLoadCurveLines();
                FileSaveTracks();
                return;
            }

            //get the file of previous AB Lines
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            if (!File.Exists(filename))
            {
                TimedMessageBox(2000, gStr.gsFileError, "Missing Tracks File");
                SystemEventWriter("Load Field, Missing Tracks File");
            }
            else
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    try
                    {
                        string line;

                        //read header $CurveLine
                        line = reader.ReadLine();

                        while (!reader.EndOfStream)
                        {

                            trk.gArr.Add(new CTrk());
                            trk.idx = trk.gArr.Count - 1;

                            //read header $CurveLine
                            trk.gArr[trk.idx].name = reader.ReadLine();
                            // get the average heading
                            line = reader.ReadLine();
                            trk.gArr[trk.idx].heading = double.Parse(line, CultureInfo.InvariantCulture);

                            line = reader.ReadLine();
                            string[] words = line.Split(',');
                            vec2 vecPt = new vec2(double.Parse(words[0], CultureInfo.InvariantCulture),
                                double.Parse(words[1], CultureInfo.InvariantCulture));
                            trk.gArr[trk.idx].ptA = (vecPt);

                            line = reader.ReadLine();
                            words = line.Split(',');
                            vecPt = new vec2(double.Parse(words[0], CultureInfo.InvariantCulture),
                                double.Parse(words[1], CultureInfo.InvariantCulture));
                            trk.gArr[trk.idx].ptB = (vecPt);

                            line = reader.ReadLine();
                            trk.gArr[trk.idx].nudgeDistance = double.Parse(line, CultureInfo.InvariantCulture);

                            line = reader.ReadLine();
                            trk.gArr[trk.idx].mode = (TrackMode)int.Parse(line, CultureInfo.InvariantCulture);

                            line = reader.ReadLine();
                            trk.gArr[trk.idx].isVisible = bool.Parse(line);

                            line = reader.ReadLine();
                            int numPoints = int.Parse(line);

                            if (numPoints > 3)
                            {
                                trk.gArr[trk.idx].curvePts?.Clear();

                                for (int i = 0; i < numPoints; i++)
                                {
                                    line = reader.ReadLine();
                                    words = line.Split(',');
                                    vec3 vecPtt = new vec3(double.Parse(words[0], CultureInfo.InvariantCulture),
                                        double.Parse(words[1], CultureInfo.InvariantCulture),
                                        double.Parse(words[2], CultureInfo.InvariantCulture));
                                    trk.gArr[trk.idx].curvePts.Add(vecPtt);
                                }
                            }
                        }
                    }
                    catch (Exception er)
                    {
                        var form = new FormTimedMessage(2000, gStr.gsCurveLineFileIsCorrupt, gStr.gsButFieldIsLoaded);
                        form.Show(this);
                        WriteErrorLog("Load Curve Line" + er.ToString());
                    }
                }
            }

            trk.idx = -1;
        }

        public void FileSaveCurveLines()
        {
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField).ToString(CultureInfo.InvariantCulture);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string filename = directoryName + "\\CurveLines.txt";

            int cnt = trk.gArr.Count;

            using (StreamWriter writer = new StreamWriter(filename, false))
            {
                try
                {
                    if (cnt > 0)
                    {
                        writer.WriteLine("$CurveLines");

                        for (int i = 0; i < cnt; i++)
                        {
                            if (trk.gArr[i].mode != TrackMode.Curve) continue;

                            //write out the Name
                            writer.WriteLine(trk.gArr[i].name);

                            //write out the heading
                            writer.WriteLine(trk.gArr[i].heading.ToString(CultureInfo.InvariantCulture));

                            //write out the points of ref line
                            int cnt2 = trk.gArr[i].curvePts.Count;

                            writer.WriteLine(cnt2.ToString(CultureInfo.InvariantCulture));
                            if (trk.gArr[i].curvePts.Count > 0)
                            {
                                for (int j = 0; j < cnt2; j++)
                                    writer.WriteLine(Math.Round(trk.gArr[i].curvePts[j].easting, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                                        Math.Round(trk.gArr[i].curvePts[j].northing, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                                            Math.Round(trk.gArr[i].curvePts[j].heading, 5).ToString(CultureInfo.InvariantCulture));
                            }
                        }
                    }
                    else
                    {
                        writer.WriteLine("$CurveLines");
                    }
                }
                catch (Exception er)
                {
                    WriteErrorLog("Saving Curve Line" + er.ToString());

                    return;
                }
            }
        }

        public void FileLoadCurveLines()
        {
            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string filename = directoryName + "\\CurveLines.txt";

            if (!File.Exists(filename))
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine("$CurveLines");
                }
            }

            //get the file of previous AB Lines
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            if (!File.Exists(filename))
            {
                TimedMessageBox(2000, gStr.gsFileError, "Missing Curve File");
                SystemEventWriter("Load Field, Missing Curve File");
            }
            else
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    try
                    {
                        string line;

                        //read header $CurveLine
                        line = reader.ReadLine();

                        while (!reader.EndOfStream)
                        {
                            trk.gArr.Add(new CTrk());

                            //read header $CurveLine
                            string nam = reader.ReadLine();

                            if (nam.Length > 4 && nam.Substring(0, 5) == "Bound")
                            {
                                trk.gArr[trk.gArr.Count - 1].name = nam;
                                trk.gArr[trk.gArr.Count - 1].mode = TrackMode.bndCurve;
                            }
                            else
                            {
                                if (nam.Length > 2 && nam.Substring(0, 2) != "Cu")
                                    trk.gArr[trk.gArr.Count - 1].name = "Cu " + nam;
                                else
                                    trk.gArr[trk.gArr.Count - 1].name = nam;

                                trk.gArr[trk.gArr.Count - 1].mode = TrackMode.Curve;
                            }

                            // get the average heading
                            line = reader.ReadLine();
                            trk.gArr[trk.gArr.Count - 1].heading = double.Parse(line, CultureInfo.InvariantCulture);


                            line = reader.ReadLine();
                            int numPoints = int.Parse(line);

                            if (numPoints > 1) 
                            {
                                trk.gArr[trk.gArr.Count - 1].curvePts?.Clear();

                                for (int i = 0; i < numPoints; i++)
                                {
                                    line = reader.ReadLine();
                                    string[] words = line.Split(',');
                                    vec3 vecPt = new vec3(double.Parse(words[0], CultureInfo.InvariantCulture),
                                        double.Parse(words[1], CultureInfo.InvariantCulture),
                                        double.Parse(words[2], CultureInfo.InvariantCulture));
                                    trk.gArr[trk.gArr.Count - 1].curvePts.Add(vecPt);
                                }

                                trk.gArr[trk.gArr.Count - 1].ptB.easting = trk.gArr[trk.gArr.Count - 1].curvePts[0].easting;
                                trk.gArr[trk.gArr.Count - 1].ptB.northing = trk.gArr[trk.gArr.Count - 1].curvePts[0].northing;
                                
                                trk.gArr[trk.gArr.Count - 1].ptB.easting = trk.gArr[trk.gArr.Count - 1].curvePts[trk.gArr[trk.gArr.Count - 1].curvePts.Count - 1].easting;
                                trk.gArr[trk.gArr.Count - 1].ptB.northing = trk.gArr[trk.gArr.Count - 1].curvePts[trk.gArr[trk.gArr.Count - 1].curvePts.Count - 1].northing;
                            }
                            else
                            {
                                if (trk.gArr.Count > 0)
                                {
                                    trk.gArr.RemoveAt(trk.gArr.Count - 1);
                                }
                            }
                        }
                    }
                    catch (Exception er)
                    {
                        var form = new FormTimedMessage(2000, gStr.gsCurveLineFileIsCorrupt, gStr.gsButFieldIsLoaded);
                        form.Show(this);
                        WriteErrorLog("Load Curve Line" + er.ToString());
                    }
                }
            }
        }

        public void FileSaveABLines()
        {
            //make sure at least a global blank AB Line file exists
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField).ToString(CultureInfo.InvariantCulture);

            //get the file of previous AB Lines
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string filename = directoryName + "\\ABLines.txt";
            int cnt = trk.gArr.Count;

            using (StreamWriter writer = new StreamWriter(filename, false))
            {
                if (cnt > 0)
                {
                    foreach (var item in trk.gArr)
                    {
                        if (item.mode == TrackMode.AB)
                        {
                            //make it culture invariant
                            string line = item.name
                                + ',' + (Math.Round(glm.toDegrees(item.heading), 8)).ToString(CultureInfo.InvariantCulture)
                                + ',' + (Math.Round(item.ptA.easting, 3)).ToString(CultureInfo.InvariantCulture)
                                + ',' + (Math.Round(item.ptA.northing, 3)).ToString(CultureInfo.InvariantCulture);

                            //write out to file
                            writer.WriteLine(line);
                        }
                    }
                }
            }
        }

        public void FileLoadABLines()
        {
            //make sure at least a global blank AB Line file exists
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField).ToString(CultureInfo.InvariantCulture);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string filename = directoryName + "\\ABLines.txt";

            if (!File.Exists(filename))
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                }
            }

            if (!File.Exists(filename))
            {
                TimedMessageBox(2000, gStr.gsFileError, gStr.gsMissingABLinesFile);
            }
            else
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    try
                    {
                        string line;

                        //read all the lines
                        for (int i = 0; !reader.EndOfStream; i++)
                        {

                            line = reader.ReadLine();
                            string[] words = line.Split(',');

                            if (words.Length != 4) break;

                            trk.gArr.Add(new CTrk());

                            if (words[0].Length > 2 && words[0].Substring(0, 2) != "AB")
                                trk.gArr[i].name = "AB " + words[0];
                            else
                                trk.gArr[i].name = words[0];

                            trk.gArr[i].mode = TrackMode.AB;


                            trk.gArr[i].heading = glm.toRadians(double.Parse(words[1], CultureInfo.InvariantCulture));
                            trk.gArr[i].ptA.easting = double.Parse(words[2], CultureInfo.InvariantCulture);
                            trk.gArr[i].ptA.northing = double.Parse(words[3], CultureInfo.InvariantCulture);

                            trk.gArr[i].ptB.easting = trk.gArr[i].ptA.easting + (Math.Sin(trk.gArr[i].heading) * 100);
                            trk.gArr[i].ptB.northing = trk.gArr[i].ptA.northing + (Math.Cos(trk.gArr[i].heading) * 100);
                        }
                    }
                    catch (Exception er)
                    {
                        var form = new FormTimedMessage(2000, "AB Line Corrupt", "Please delete it!!!");
                        form.Show(this);
                        WriteErrorLog("FieldOpen, Loading ABLine, Corrupt ABLine File" + er);
                    }
                }
            }
        }

        //function to open a previously saved field, resume, open exisiting, open named field
        public void FileOpenField(string _openType)
        {
            string fileAndDirectory = "";
            if (_openType.Contains("Field.txt"))
            {
                fileAndDirectory = _openType;
                _openType = "Load";
            }

            else fileAndDirectory = "Cancel";

            //get the directory where the fields are stored
            //string directoryName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+ "\\fields\\";
            switch (_openType)
            {
                case "Resume":
                    {
                        //Either exit or update running save
                        fileAndDirectory = fieldsDirectory + currentFieldDirectory + "\\Field.txt";
                        if (!File.Exists(fileAndDirectory)) fileAndDirectory = "Cancel";
                        break;
                    }

                case "Open":
                    {
                        //create the dialog instance
                        OpenFileDialog ofd = new OpenFileDialog();

                        //the initial directory, fields, for the open dialog
                        ofd.InitialDirectory = fieldsDirectory;

                        //When leaving dialog put windows back where it was
                        ofd.RestoreDirectory = true;

                        //set the filter to text files only
                        ofd.Filter = "Field files (Field.txt)|Field.txt";

                        //was a file selected
                        if (ofd.ShowDialog(this) == DialogResult.Cancel) fileAndDirectory = "Cancel";
                        else fileAndDirectory = ofd.FileName;
                        break;
                    }
            }

            if (fileAndDirectory == "Cancel") return;

            //close the existing job and reset everything
            this.JobClose();

            //and open a new job
            this.JobNew();

            //Saturday, February 11, 2017  -->  7:26:52 AM
            //$FieldDir
            //Bob_Feb11
            //$Offsets
            //533172,5927719,12 - offset easting, northing, zone

            //start to read the file
            string line;
            using (StreamReader reader = new StreamReader(fileAndDirectory))
            {
                try
                {
                    //Date time line
                    line = reader.ReadLine();

                    //dir header $FieldDir
                    line = reader.ReadLine();

                    //read field directory
                    line = reader.ReadLine();

                    currentFieldDirectory = Path.GetDirectoryName(fileAndDirectory);
                    currentFieldDirectory = new DirectoryInfo(currentFieldDirectory).Name;

                    displayFieldName = currentFieldDirectory;

                    //Offset header
                    line = reader.ReadLine();

                    //read the Offsets 
                    line = reader.ReadLine();
                    string[] offs = line.Split(',');

                    //convergence angle update
                    if (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                    }

                    //start positions
                    if (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        offs = line.Split(',');

                        pn.latStart = double.Parse(offs[0], CultureInfo.InvariantCulture);
                        pn.lonStart = double.Parse(offs[1], CultureInfo.InvariantCulture);

                        if (timerSim.Enabled)
                        {
                            pn.latitude = pn.latStart;
                            pn.longitude = pn.lonStart;

                            sim.latitude = Properties.Settings.Default.setGPS_SimLatitude = pn.latitude;
                            sim.longitude = Properties.Settings.Default.setGPS_SimLongitude = pn.longitude;
                            Properties.Settings.Default.Save();
                        }

                        pn.SetLocalMetersPerDegree();
                    }
                }

                catch (Exception e)
                {
                    WriteErrorLog("While Opening Field" + e.ToString());

                    var form = new FormTimedMessage(2000, gStr.gsFieldFileIsCorrupt, gStr.gsChooseADifferentField);

                    form.Show(this);
                    JobClose();
                    return;
                }
            }

            // Tracks -------------------------------------------------------------------------------------------------

            trk.gArr?.Clear();

            FileLoadTracks();

            
            //section patches
            fileAndDirectory = fieldsDirectory + currentFieldDirectory + "\\Sections.txt";
            if (!File.Exists(fileAndDirectory))
            {
                var form = new FormTimedMessage(2000, gStr.gsMissingSectionFile, gStr.gsButFieldIsLoaded);
                form.Show(this);
                //return;
            }
            else
            {
                bool isv3 = false;
                using (StreamReader reader = new StreamReader(fileAndDirectory))
                {
                    try
                    {
                        fd.workedAreaTotal = 0;
                        fd.distanceUser = 0;
                        vec3 vecFix = new vec3();

                        //read header
                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();
                            if (line.Contains("ect"))
                            {
                                isv3 = true;
                                break;
                            }
                            int verts = int.Parse(line);

                            triStrip[0].triangleList = new List<vec3>();
                            triStrip[0].triangleList.Capacity = verts + 1;

                            triStrip[0].patchList.Add(triStrip[0].triangleList);


                            for (int v = 0; v < verts; v++)
                            {
                                line = reader.ReadLine();
                                string[] words = line.Split(',');
                                vecFix.easting = double.Parse(words[0], CultureInfo.InvariantCulture);
                                vecFix.northing = double.Parse(words[1], CultureInfo.InvariantCulture);
                                vecFix.heading = double.Parse(words[2], CultureInfo.InvariantCulture);
                                triStrip[0].triangleList.Add(vecFix);
                            }

                            //calculate area of this patch - AbsoluteValue of (Ax(By-Cy) + Bx(Cy-Ay) + Cx(Ay-By)/2)
                            verts -= 2;
                            if (verts >= 2)
                            {
                                for (int j = 1; j < verts; j++)
                                {
                                    double temp = 0;
                                    temp = triStrip[0].triangleList[j].easting * (triStrip[0].triangleList[j + 1].northing - triStrip[0].triangleList[j + 2].northing) +
                                              triStrip[0].triangleList[j + 1].easting * (triStrip[0].triangleList[j + 2].northing - triStrip[0].triangleList[j].northing) +
                                                  triStrip[0].triangleList[j + 2].easting * (triStrip[0].triangleList[j].northing - triStrip[0].triangleList[j + 1].northing);

                                    fd.workedAreaTotal += Math.Abs((temp * 0.5));
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        WriteErrorLog("Section file" + e.ToString());

                        var form = new FormTimedMessage(2000, "Section File is Corrupt", gStr.gsButFieldIsLoaded);
                        form.Show(this);
                    }

                }

                //was old version prior to v4
                if (isv3)
                {
                        //Append the current list to the field file
                        using (StreamWriter writer = new StreamWriter((fieldsDirectory + currentFieldDirectory + "\\Sections.txt"), false))
                        {
                        }
                }
            }

            // Contour points ----------------------------------------------------------------------------

            fileAndDirectory = fieldsDirectory + currentFieldDirectory + "\\Contour.txt";
            if (!File.Exists(fileAndDirectory))
            {
                var form = new FormTimedMessage(2000, gStr.gsMissingContourFile, gStr.gsButFieldIsLoaded);
                form.Show(this);
                //return;
            }
            
            //Points in Patch followed by easting, heading, northing, altitude
            else
            {
                using (StreamReader reader = new StreamReader(fileAndDirectory))
                {
                    try
                    {
                        //read header
                        line = reader.ReadLine();

                        while (!reader.EndOfStream)
                        {
                            //read how many vertices in the following patch
                            line = reader.ReadLine();
                            int verts = int.Parse(line);

                            vec3 vecFix = new vec3(0, 0, 0);

                            ct.ptList = new List<vec3>();
                            ct.ptList.Capacity = verts + 1;
                            ct.stripList.Add(ct.ptList);

                            for (int v = 0; v < verts; v++)
                            {
                                line = reader.ReadLine();
                                string[] words = line.Split(',');
                                vecFix.easting = double.Parse(words[0], CultureInfo.InvariantCulture);
                                vecFix.northing = double.Parse(words[1], CultureInfo.InvariantCulture);
                                vecFix.heading = double.Parse(words[2], CultureInfo.InvariantCulture);
                                ct.ptList.Add(vecFix);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        WriteErrorLog("Loading Contour file" + e.ToString());

                        var form = new FormTimedMessage(2000, gStr.gsContourFileIsCorrupt, gStr.gsButFieldIsLoaded);
                        form.Show(this);
                    }
                }
            }


            // Flags -------------------------------------------------------------------------------------------------

            //Either exit or update running save
            fileAndDirectory = fieldsDirectory + currentFieldDirectory + "\\Flags.txt";
            if (!File.Exists(fileAndDirectory))
            {
                var form = new FormTimedMessage(2000, gStr.gsMissingFlagsFile, gStr.gsButFieldIsLoaded);
                form.Show(this);
            }

            else
            {
                flagPts?.Clear();
                using (StreamReader reader = new StreamReader(fileAndDirectory))
                {
                    try
                    {
                        //read header
                        line = reader.ReadLine();

                        //number of flags
                        line = reader.ReadLine();
                        int points = int.Parse(line);

                        if (points > 0)
                        {
                            double lat;
                            double longi;
                            double elev;
                            double east;
                            double nort;
                            double head;
                            int color, ID;
                            string notes;

                            for (int v = 0; v < points; v++)
                            {
                                line = reader.ReadLine();
                                string[] words = line.Split(',');

                                if (words.Length == 9)
                                {
                                    lat = double.Parse(words[0], CultureInfo.InvariantCulture);
                                    longi = double.Parse(words[1], CultureInfo.InvariantCulture);
                                    elev = double.Parse(words[2], CultureInfo.InvariantCulture);
                                    east = double.Parse(words[3], CultureInfo.InvariantCulture);
                                    nort = double.Parse(words[4], CultureInfo.InvariantCulture);
                                    head = double.Parse(words[5], CultureInfo.InvariantCulture);
                                    color = int.Parse(words[6]);
                                    ID = int.Parse(words[7]);
                                    notes = words[8].Trim();
                                }
                                else
                                {
                                    lat = double.Parse(words[0], CultureInfo.InvariantCulture);
                                    longi = double.Parse(words[1], CultureInfo.InvariantCulture);
                                    elev = double.Parse(words[2], CultureInfo.InvariantCulture);
                                    east = double.Parse(words[3], CultureInfo.InvariantCulture);
                                    nort = double.Parse(words[4], CultureInfo.InvariantCulture);
                                    head = 0;
                                    color = int.Parse(words[5]);
                                    ID = int.Parse(words[6]);
                                    notes = "";
                                }

                                CFlag flagPt = new CFlag(lat, longi, elev, east, nort, head, color, ID, notes);
                                flagPts.Add(flagPt);
                            }
                        }
                    }

                    catch (Exception e)
                    {
                        var form = new FormTimedMessage(2000, gStr.gsFlagFileIsCorrupt, gStr.gsButFieldIsLoaded);
                        form.Show(this);
                        WriteErrorLog("FieldOpen, Loading Flags, Corrupt Flag File" + e.ToString());
                    }
                }
            }

            //Boundaries
            //Either exit or update running save
            fileAndDirectory = fieldsDirectory + currentFieldDirectory + "\\Boundary.txt";
            if (!File.Exists(fileAndDirectory))
            {
                var form = new FormTimedMessage(2000, gStr.gsMissingBoundaryFile, gStr.gsButFieldIsLoaded);
                form.Show(this);
            }
            else
            {
                using (StreamReader reader = new StreamReader(fileAndDirectory))
                {
                    try
                    {

                        //read header
                        line = reader.ReadLine();//Boundary

                        for (int k = 0; true; k++)
                        {
                            if (reader.EndOfStream) break;

                            CBoundaryList New = new CBoundaryList();

                            //True or False OR points from older boundary files
                            line = reader.ReadLine();

                            //Check for older boundary files, then above line string is num of points
                            if (line == "True" || line == "False")
                            {
                                New.isDriveThru = bool.Parse(line);
                                line = reader.ReadLine(); //number of points
                            }

                            //Check for latest boundary files, then above line string is num of points
                            if (line == "True" || line == "False")
                            {
                                line = reader.ReadLine(); //number of points
                            }

                            int numPoints = int.Parse(line);

                            if (numPoints > 0)
                            {
                                //load the line
                                for (int i = 0; i < numPoints; i++)
                                {
                                    line = reader.ReadLine();
                                    string[] words = line.Split(',');
                                    vec3 vecPt = new vec3(
                                    double.Parse(words[0], CultureInfo.InvariantCulture),
                                    double.Parse(words[1], CultureInfo.InvariantCulture),
                                    double.Parse(words[2], CultureInfo.InvariantCulture));

                                    New.fenceLine.Add(vecPt);
                                }

                                New.CalculateFenceArea(k);

                                double delta = 0;
                                New.fenceLineEar?.Clear();

                                for (int i = 0; i < New.fenceLine.Count; i++)
                                {
                                    if (i == 0)
                                    {
                                        New.fenceLineEar.Add(new vec2(New.fenceLine[i].easting, New.fenceLine[i].northing));
                                        continue;
                                    }
                                    delta += (New.fenceLine[i - 1].heading - New.fenceLine[i].heading);
                                    if (Math.Abs(delta) > 0.005)
                                    {
                                        New.fenceLineEar.Add(new vec2(New.fenceLine[i].easting, New.fenceLine[i].northing));
                                        delta = 0;
                                    }
                                }

                                bnd.bndList.Add(New);
                            }
                        }

                        CalculateMinMax();
                        bnd.BuildTurnLines();
                        if (bnd.bndList.Count > 0) btnABDraw.Visible = true;
                    }

                    catch (Exception e)
                    {
                        var form = new FormTimedMessage(2000, gStr.gsBoundaryLineFilesAreCorrupt, gStr.gsButFieldIsLoaded);
                        form.Show(this);
                        WriteErrorLog("Load Boundary Line" + e.ToString());
                    }
                }
            }

            // Headland  -------------------------------------------------------------------------------------------------
            fileAndDirectory = fieldsDirectory + currentFieldDirectory + "\\Headland.txt";

            if (File.Exists(fileAndDirectory))
            {
                using (StreamReader reader = new StreamReader(fileAndDirectory))
                {
                    try
                    {
                        //read header
                        line = reader.ReadLine();

                        for (int k = 0; true; k++)
                        {
                            if (reader.EndOfStream) break;

                            if (bnd.bndList.Count > k)
                            {
                                bnd.bndList[k].hdLine.Clear();

                                //read the number of points
                                line = reader.ReadLine();
                                int numPoints = int.Parse(line);

                                if (numPoints > 0)
                                {
                                    //load the line
                                    for (int i = 0; i < numPoints; i++)
                                    {
                                        line = reader.ReadLine();
                                        string[] words = line.Split(',');
                                        vec3 vecPt = new vec3(
                                            double.Parse(words[0], CultureInfo.InvariantCulture),
                                            double.Parse(words[1], CultureInfo.InvariantCulture),
                                            double.Parse(words[2], CultureInfo.InvariantCulture));
                                        bnd.bndList[k].hdLine.Add(vecPt);
                                    }
                                }
                            }
                        }
                    }

                    catch (Exception e)
                    {
                        var form = new FormTimedMessage(2000, "Headland File is Corrupt", "But Field is Loaded");
                        form.Show(this);
                        WriteErrorLog("Load Headland Loop" + e.ToString());
                    }
                }
            }

            if (bnd.bndList.Count > 0 && bnd.bndList[0].hdLine.Count > 0)
            {
                bnd.isHeadlandOn = true;
                btnHeadlandOnOff.Image = Properties.Resources.HeadlandOn;
                btnHeadlandOnOff.Visible = true;
                btnHydLift.Image = Properties.Resources.HydraulicLiftOff;
            }
            else
            {
                bnd.isHeadlandOn = false;
                btnHeadlandOnOff.Image = Properties.Resources.HeadlandOff;
                btnHeadlandOnOff.Visible = false;
            }

            int sett = Properties.Settings.Default.setArdMac_setting0;
            btnHydLift.Visible = (((sett & 2) == 2) && bnd.isHeadlandOn); 

            //trams ---------------------------------------------------------------------------------
            fileAndDirectory = fieldsDirectory + currentFieldDirectory + "\\Tram.txt";

            tram.tramBndOuterArr?.Clear();
            tram.tramBndInnerArr?.Clear();
            tram.tramList?.Clear();
            tram.displayMode = 0;
            btnTramDisplayMode.Visible = false;

            if (File.Exists(fileAndDirectory))
            {
                using (StreamReader reader = new StreamReader(fileAndDirectory))
                {
                    try
                    {
                        //read header
                        line = reader.ReadLine();//$Tram

                        //outer track of boundary tram
                        line = reader.ReadLine();
                        if (line != null)
                        {
                            int numPoints = int.Parse(line);

                            if (numPoints > 0)
                            {
                                //load the line
                                for (int i = 0; i < numPoints; i++)
                                {
                                    line = reader.ReadLine();
                                    string[] words = line.Split(',');
                                    vec2 vecPt = new vec2(
                                    double.Parse(words[0], CultureInfo.InvariantCulture),
                                    double.Parse(words[1], CultureInfo.InvariantCulture));

                                    tram.tramBndOuterArr.Add(vecPt);
                                }
                                tram.displayMode = 1;
                            }

                            //inner track of boundary tram
                            line = reader.ReadLine();
                            numPoints = int.Parse(line);

                            if (numPoints > 0)
                            {
                                //load the line
                                for (int i = 0; i < numPoints; i++)
                                {
                                    line = reader.ReadLine();
                                    string[] words = line.Split(',');
                                    vec2 vecPt = new vec2(
                                    double.Parse(words[0], CultureInfo.InvariantCulture),
                                    double.Parse(words[1], CultureInfo.InvariantCulture));

                                    tram.tramBndInnerArr.Add(vecPt);
                                }
                            }

                            if (!reader.EndOfStream)
                            {
                                line = reader.ReadLine();
                                int numLines = int.Parse(line);

                                for (int k = 0; k < numLines; k++)
                                {
                                    line = reader.ReadLine();
                                    numPoints = int.Parse(line);

                                    tram.tramArr = new List<vec2>();
                                    tram.tramList.Add(tram.tramArr);

                                    for (int i = 0; i < numPoints; i++)
                                    {
                                        line = reader.ReadLine();
                                        string[] words = line.Split(',');
                                        vec2 vecPt = new vec2(
                                        double.Parse(words[0], CultureInfo.InvariantCulture),
                                        double.Parse(words[1], CultureInfo.InvariantCulture));

                                        tram.tramArr.Add(vecPt);
                                    }
                                }
                            }
                        }

                        FixTramModeButton();
                    }

                    catch (Exception e)
                    {
                        var form = new FormTimedMessage(2000, "Tram is corrupt", gStr.gsButFieldIsLoaded);
                        form.Show(this);
                        WriteErrorLog("Load Boundary Line" + e.ToString());
                    }
                }
            }

            //if (Directory.Exists(fieldsDirectory + currentFieldDirectory))
            //{
            //    foreach (string file in Directory.GetFiles(fieldsDirectory + currentFieldDirectory, "*.shp", SearchOption.TopDirectoryOnly))
            //    {
            //        shape.Main(fieldsDirectory + currentFieldDirectory + "\\" + Path.GetFileNameWithoutExtension(file));
            //    }
            //}

            //Recorded Path
            fileAndDirectory = fieldsDirectory + currentFieldDirectory + "\\RecPath.txt";
            if (File.Exists(fileAndDirectory))
            {
                using (StreamReader reader = new StreamReader(fileAndDirectory))
                {
                    try
                    {
                        //read header
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        int numPoints = int.Parse(line);
                        recPath.recList.Clear();

                        while (!reader.EndOfStream)
                        {
                            for (int v = 0; v < numPoints; v++)
                            {
                                line = reader.ReadLine();
                                string[] words = line.Split(',');
                                CRecPathPt point = new CRecPathPt(
                                    double.Parse(words[0], CultureInfo.InvariantCulture),
                                    double.Parse(words[1], CultureInfo.InvariantCulture),
                                    double.Parse(words[2], CultureInfo.InvariantCulture),
                                    double.Parse(words[3], CultureInfo.InvariantCulture),
                                    bool.Parse(words[4]));

                                //add the point
                                recPath.recList.Add(point);
                            }
                        }

                        if (recPath.recList.Count > 0) panelDrag.Visible = true;
                        else panelDrag.Visible = false;
                    }

                    catch (Exception e)
                    {
                        var form = new FormTimedMessage(2000, gStr.gsRecordedPathFileIsCorrupt, gStr.gsButFieldIsLoaded);
                        form.Show(this);
                        WriteErrorLog("Load Recorded Path" + e.ToString());
                    }
                }
            }

            worldGrid.isGeoMap = false;

            //Back Image
            fileAndDirectory = fieldsDirectory + currentFieldDirectory + "\\BackPic.txt";
            if (File.Exists(fileAndDirectory))
            {
                using (StreamReader reader = new StreamReader(fileAndDirectory))
                {
                    try
                    {
                        //read header
                        line = reader.ReadLine();

                        line = reader.ReadLine();
                        worldGrid.isGeoMap = bool.Parse(line);

                        line = reader.ReadLine();
                        worldGrid.eastingMaxGeo = double.Parse(line, CultureInfo.InvariantCulture);
                        line = reader.ReadLine();
                        worldGrid.eastingMinGeo = double.Parse(line, CultureInfo.InvariantCulture);
                        line = reader.ReadLine();
                        worldGrid.northingMaxGeo = double.Parse(line, CultureInfo.InvariantCulture);
                        line = reader.ReadLine();
                        worldGrid.northingMinGeo = double.Parse(line, CultureInfo.InvariantCulture);
                    }
                    catch (Exception)
                    {
                        worldGrid.isGeoMap = false;
                    }

                    if (worldGrid.isGeoMap)
                    {
                        fileAndDirectory = fieldsDirectory + currentFieldDirectory + "\\BackPic.png";
                        if (File.Exists(fileAndDirectory))
                        {
                            var bitmap = new Bitmap(Image.FromFile(fileAndDirectory));

                            GL.BindTexture(TextureTarget.Texture2D, texture[(int)textures.bingGrid]);
                            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapData.Width, bitmapData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);
                            bitmap.UnlockBits(bitmapData);
                        }
                        else
                        {
                            worldGrid.isGeoMap = false;
                        }
                    }
                }
            }

            PanelsAndOGLSize();
            SetZoom();

            //update field data
            oglZoom.Refresh();

        }//end of open file

        //creates the field file when starting new field
        public void FileCreateField()
        {
            //Saturday, February 11, 2017  -->  7:26:52 AM
            //$FieldDir
            //Bob_Feb11
            //$Offsets
            //533172,5927719,12 - offset easting, northing, zone

            if (!isJobStarted)
            {
                using (var form = new FormTimedMessage(3000, gStr.gsFieldNotOpen, gStr.gsCreateNewField))
                { form.Show(this); }
                return;
            }
            string myFileName, dirField;

            //get the directory and make sure it exists, create if not
            dirField = fieldsDirectory + currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            myFileName = "Field.txt";

            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {
                //Write out the date
                writer.WriteLine(DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss tt", CultureInfo.InvariantCulture));

                writer.WriteLine("$FieldDir");
                writer.WriteLine("FieldNew");

                //write out the easting and northing Offsets
                writer.WriteLine("$Offsets");
                writer.WriteLine("0,0");

                writer.WriteLine("Convergence");
                writer.WriteLine("0");

                writer.WriteLine("StartFix");
                writer.WriteLine(pn.latitude.ToString(CultureInfo.InvariantCulture) + "," + pn.longitude.ToString(CultureInfo.InvariantCulture));
            }
        }

        public void FileCreateElevation()
        {
            //Saturday, February 11, 2017  -->  7:26:52 AM
            //$FieldDir
            //Bob_Feb11
            //$Offsets
            //533172,5927719,12 - offset easting, northing, zone

            //if (!isJobStarted)
            //{
            //    using (var form = new FormTimedMessage(3000, "Ooops, Job Not Started", "Start a Job First"))
            //    { form.Show(this); }
            //    return;
            //}

            string myFileName, dirField;

            //get the directory and make sure it exists, create if not
            dirField = fieldsDirectory + currentFieldDirectory + "\\";
            string directoryName = Path.GetDirectoryName(dirField);

            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            myFileName = "Elevation.txt";

            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {
                //Write out the date
                writer.WriteLine(DateTime.Now.ToString("yyyy-MMMM-dd hh:mm:ss tt", CultureInfo.InvariantCulture));

                writer.WriteLine("$FieldDir");
                writer.WriteLine("Elevation");

                //write out the easting and northing Offsets
                writer.WriteLine("$Offsets");
                writer.WriteLine("0,0");

                writer.WriteLine("Convergence");
                writer.WriteLine("0");

                writer.WriteLine("StartFix");
                writer.WriteLine(pn.latitude.ToString(CultureInfo.InvariantCulture) + "," + pn.longitude.ToString(CultureInfo.InvariantCulture));

                writer.WriteLine("Latitude,Longitude,Elevation,Quality,Easting,Northing,Heading,Roll,TimeStamp");
            }
        }

        //save field Patches
        public void FileSaveSections()
        {
            //make sure there is something to save
            if (patchSaveList.Count() > 0)
            {
                //Append the current list to the field file
                using (StreamWriter writer = new StreamWriter((fieldsDirectory + currentFieldDirectory + "\\Sections.txt"), true))
                {
                    //for each patch, write out the list of triangles to the file
                    foreach (var triList in patchSaveList)
                    {
                        int count2 = triList.Count();
                        writer.WriteLine(count2.ToString(CultureInfo.InvariantCulture));

                        for (int i = 0; i < count2; i++)
                            writer.WriteLine((Math.Round(triList[i].easting,3)).ToString(CultureInfo.InvariantCulture) +
                                "," + (Math.Round(triList[i].northing,3)).ToString(CultureInfo.InvariantCulture) +
                                 "," + (Math.Round(triList[i].heading, 3)).ToString(CultureInfo.InvariantCulture));
                    }
                }

                //clear out that patchList and begin adding new ones for next save
                patchSaveList.Clear();
            }
        }

        //Create contour file
        public void FileCreateSections()
        {
            //$Sections
            //10 - points in this patch
            //10.1728031317344,0.723157039771303 -easting, northing

            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string myFileName = "Sections.txt";

            //write out the file
            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {
                //write paths # of sections
                //writer.WriteLine("$Sectionsv4");
            }
        }

        public void FileCreateBoundary()
        {
            //$Sections
            //10 - points in this patch
            //10.1728031317344,0.723157039771303 -easting, northing

            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string myFileName = "Boundary.txt";

            //write out the file
            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {
                //write paths # of sections
                writer.WriteLine("$Boundary");
            }
        }

        //Create Flag file
        public void FileCreateFlags()
        {
            //$Sections
            //10 - points in this patch
            //10.1728031317344,0.723157039771303 -easting, northing

            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string myFileName = "Flags.txt";

            //write out the file
            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {
                //write paths # of sections
                //writer.WriteLine("$Sectionsv4");
                writer.WriteLine("Latitude, Longitude, Elevation, Easting, Northing, Heading, Color, ID, Notes");
            }
        }

        //Create contour file
        public void FileCreateContour()
        {
            //12  - points in patch
            //64.697,0.168,-21.654,0 - east, heading, north, altitude

            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string myFileName = "Contour.txt";

            //write out the file
            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {
                writer.WriteLine("$Contour");
            }
        }

        //save the contour points
        public void FileSaveContour()
        {
            //1  - points in patch
            //64.697,0.168,-21.654,0 - east, heading, north, altitude

            //make sure there is something to save
            if (contourSaveList.Count() > 0)
            {
                //Append the current list to the field file
                using (StreamWriter writer = new StreamWriter((fieldsDirectory + currentFieldDirectory + "\\Contour.txt"), true))
                {

                    //for every new chunk of patch in the whole section
                    foreach (var triList in contourSaveList)
                    {
                        int count2 = triList.Count;

                        writer.WriteLine(count2.ToString(CultureInfo.InvariantCulture));

                        for (int i = 0; i < count2; i++)
                        {
                            writer.WriteLine(Math.Round((triList[i].easting), 3).ToString(CultureInfo.InvariantCulture) + "," +
                                Math.Round(triList[i].northing, 3).ToString(CultureInfo.InvariantCulture)+ "," +
                                Math.Round(triList[i].heading, 3).ToString(CultureInfo.InvariantCulture));
                        }
                    }
                }

                contourSaveList.Clear();

            }
        }

        //save the boundary
        public void FileSaveBoundary()
        {
            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            //write out the file
            using (StreamWriter writer = new StreamWriter(dirField + "Boundary.Txt"))
            {
                writer.WriteLine("$Boundary");
                for (int i = 0; i < bnd.bndList.Count; i++)
                {
                    writer.WriteLine(bnd.bndList[i].isDriveThru);
                    //writer.WriteLine(bnd.bndList[i].isDriveAround);

                    writer.WriteLine(bnd.bndList[i].fenceLine.Count.ToString(CultureInfo.InvariantCulture));
                    if (bnd.bndList[i].fenceLine.Count > 0)
                    {
                        for (int j = 0; j < bnd.bndList[i].fenceLine.Count; j++)
                            writer.WriteLine(Math.Round(bnd.bndList[i].fenceLine[j].easting,3).ToString(CultureInfo.InvariantCulture) + "," +
                                                Math.Round(bnd.bndList[i].fenceLine[j].northing, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                                    Math.Round(bnd.bndList[i].fenceLine[j].heading,5).ToString(CultureInfo.InvariantCulture));
                    }
                }
            }
        }

        //save tram
        public void FileSaveTram()
        {
            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            //write out the file
            using (StreamWriter writer = new StreamWriter(dirField + "Tram.Txt"))
            {
                writer.WriteLine("$Tram");

                if (tram.tramBndOuterArr.Count > 0)
                {
                    //outer track of outer boundary tram
                    writer.WriteLine(tram.tramBndOuterArr.Count.ToString(CultureInfo.InvariantCulture));

                    for (int i = 0; i < tram.tramBndOuterArr.Count; i++)
                    {
                        writer.WriteLine(Math.Round(tram.tramBndOuterArr[i].easting, 3).ToString(CultureInfo.InvariantCulture) + "," +
                            Math.Round(tram.tramBndOuterArr[i].northing, 3).ToString(CultureInfo.InvariantCulture));
                    }

                    //inner track of outer boundary tram
                    writer.WriteLine(tram.tramBndInnerArr.Count.ToString(CultureInfo.InvariantCulture));

                    for (int i = 0; i < tram.tramBndInnerArr.Count; i++)
                    {
                        writer.WriteLine(Math.Round(tram.tramBndInnerArr[i].easting, 3).ToString(CultureInfo.InvariantCulture) + "," +
                            Math.Round(tram.tramBndInnerArr[i].northing, 3).ToString(CultureInfo.InvariantCulture));
                    }
                }

                //no outer bnd
                else
                {
                    writer.WriteLine("0");
                    writer.WriteLine("0");
                }

                if (tram.tramList.Count > 0)
                {
                    writer.WriteLine(tram.tramList.Count.ToString(CultureInfo.InvariantCulture));
                    for (int i = 0; i < tram.tramList.Count; i++)
                    {
                        writer.WriteLine(tram.tramList[i].Count.ToString(CultureInfo.InvariantCulture));
                        for (int h = 0; h < tram.tramList[i].Count; h++)
                        {
                            writer.WriteLine(Math.Round(tram.tramList[i][h].easting, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                Math.Round(tram.tramList[i][h].northing, 3).ToString(CultureInfo.InvariantCulture));
                        }
                    }
                }
            }
        }

        //save tram
        public void FileSaveBackPic()
        {
            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            //write out the file
            using (StreamWriter writer = new StreamWriter(dirField + "BackPic.Txt"))
            {
                writer.WriteLine("$BackPic");
                //outer track of outer boundary tram
                if (worldGrid.isGeoMap)
                {
                    writer.WriteLine(true);
                    writer.WriteLine(worldGrid.eastingMaxGeo.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine(worldGrid.eastingMinGeo.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine(worldGrid.northingMaxGeo.ToString(CultureInfo.InvariantCulture));
                    writer.WriteLine(worldGrid.northingMinGeo.ToString(CultureInfo.InvariantCulture));
                }
                else
                {
                    writer.WriteLine(false);
                    writer.WriteLine(300);
                    writer.WriteLine(-300);
                    writer.WriteLine(300);
                    writer.WriteLine(-300);
                }
            }
        }

        //save the headland
        public void FileSaveHeadland()
        {
            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            //write out the file
            using (StreamWriter writer = new StreamWriter(dirField + "Headland.Txt"))
            {
                writer.WriteLine("$Headland");

                if (bnd.bndList.Count > 0 && bnd.bndList[0].hdLine.Count > 0)
                {
                    for (int i = 0; i < bnd.bndList.Count; i++)
                    {
                        writer.WriteLine(bnd.bndList[i].hdLine.Count.ToString(CultureInfo.InvariantCulture));
                        if (bnd.bndList[0].hdLine.Count > 0)
                        {
                            for (int j = 0; j < bnd.bndList[i].hdLine.Count; j++)
                                writer.WriteLine(Math.Round(bnd.bndList[i].hdLine[j].easting, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                                    Math.Round(bnd.bndList[i].hdLine[j].northing, 3).ToString(CultureInfo.InvariantCulture) + "," +
                                                    Math.Round(bnd.bndList[i].hdLine[j].heading, 3).ToString(CultureInfo.InvariantCulture));
                        }
                    }
                }
            }
        }

        //Create contour file
        public void FileCreateRecPath()
        {
            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string myFileName = "RecPath.txt";

            //write out the file
            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {
                //write paths # of sections
                writer.WriteLine("$RecPath");
                writer.WriteLine("0");
            }
        }

        //save the recorded path
        public void FileSaveRecPath(string name = "RecPath.Txt")
        {
            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            //string fileAndDirectory = fieldsDirectory + currentFieldDirectory + "\\RecPath.txt";
            //if (!File.Exists(fileAndDirectory)) FileCreateRecPath();

            //write out the file
            using (StreamWriter writer = new StreamWriter((dirField + name)))
            {
                writer.WriteLine("$RecPath");
                writer.WriteLine(recPath.recList.Count.ToString(CultureInfo.InvariantCulture));
                if (recPath.recList.Count > 0)
                {
                    for (int j = 0; j < recPath.recList.Count; j++)
                        writer.WriteLine(
                            Math.Round(recPath.recList[j].easting, 3).ToString(CultureInfo.InvariantCulture) + "," +
                            Math.Round(recPath.recList[j].northing, 3).ToString(CultureInfo.InvariantCulture) + "," +
                            Math.Round(recPath.recList[j].heading, 3).ToString(CultureInfo.InvariantCulture) + "," +
                            Math.Round(recPath.recList[j].speed, 1).ToString(CultureInfo.InvariantCulture) + "," +
                            (recPath.recList[j].autoBtnState).ToString());

                    //Clear list
                    //recPath.recList.Clear();
                }
            }
        }

        //load Recpath.txt
        public void FileLoadRecPath()
        {
            string line;
            //Recorded Path
            string fileAndDirectory = fieldsDirectory + currentFieldDirectory + "\\RecPath.txt";
            if (File.Exists(fileAndDirectory))
            {
                using (StreamReader reader = new StreamReader(fileAndDirectory))
                {
                    try
                    {
                        //read header
                        line = reader.ReadLine();
                        line = reader.ReadLine();
                        int numPoints = int.Parse(line);
                        recPath.recList.Clear();

                        while (!reader.EndOfStream)
                        {
                            for (int v = 0; v < numPoints; v++)
                            {
                                line = reader.ReadLine();
                                string[] words = line.Split(',');
                                CRecPathPt point = new CRecPathPt(
                                    double.Parse(words[0], CultureInfo.InvariantCulture),
                                    double.Parse(words[1], CultureInfo.InvariantCulture),
                                    double.Parse(words[2], CultureInfo.InvariantCulture),
                                    double.Parse(words[3], CultureInfo.InvariantCulture),
                                    bool.Parse(words[4]));

                                //add the point
                                recPath.recList.Add(point);
                            }
                        }
                    }

                    catch (Exception e)
                    {
                        var form = new FormTimedMessage(2000, gStr.gsRecordedPathFileIsCorrupt, gStr.gsButFieldIsLoaded);
                        form.Show(this);
                        WriteErrorLog("Load Recorded Path" + e.ToString());
                    }
                }
            }
        }

        //save all the flag markers
        public void FileSaveFlags()
        {
            //Saturday, February 11, 2017  -->  7:26:52 AM
            //$FlagsDir
            //Bob_Feb11
            //$Offsets
            //533172,5927719,12 - offset easting, northing, zone

            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            //use Streamwriter to create and overwrite existing flag file
            using (StreamWriter writer = new StreamWriter(dirField + "Flags.txt"))
            {
                try
                {
                    writer.WriteLine("$Flags");

                    int count2 = flagPts.Count;
                    writer.WriteLine(count2);

                    for (int i = 0; i < count2; i++)
                    {
                        writer.WriteLine(
                            flagPts[i].latitude.ToString(CultureInfo.InvariantCulture) + "," +
                            flagPts[i].longitude.ToString(CultureInfo.InvariantCulture) + "," +
                            flagPts[i].elevation.ToString(CultureInfo.InvariantCulture) + "," +
                            flagPts[i].easting.ToString(CultureInfo.InvariantCulture) + "," +
                            flagPts[i].northing.ToString(CultureInfo.InvariantCulture) + "," +
                            flagPts[i].heading.ToString(CultureInfo.InvariantCulture) + "," +
                            flagPts[i].color.ToString(CultureInfo.InvariantCulture) + "," +
                            flagPts[i].ID.ToString(CultureInfo.InvariantCulture) + "," +
                            flagPts[i].notes);
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n Cannot write to file.");
                    WriteErrorLog("Saving Flags" + e.ToString());
                    return;
                }
            }
        }

        //save all the flag markers
        //public void FileSaveABLine()
        //{
        //    //Saturday, February 11, 2017  -->  7:26:52 AM

        //    //get the directory and make sure it exists, create if not
        //    string dirField = fieldsDirectory + currentFieldDirectory + "\\";

        //    string directoryName = Path.GetDirectoryName(dirField);
        //    if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
        //    { Directory.CreateDirectory(directoryName); }

        //    //use Streamwriter to create and overwrite existing ABLine file
        //    using (StreamWriter writer = new StreamWriter(dirField + "ABLine.txt"))
        //    {
        //        try
        //        {
        //            //write out the ABLine
        //            writer.WriteLine("$ABLine");

        //            //true or false if ABLine is set
        //            if (ABLine.isABLineSet) writer.WriteLine(true);
        //            else writer.WriteLine(false);

        //            writer.WriteLine(ABLine.abHeading.ToString(CultureInfo.InvariantCulture));
        //            writer.WriteLine(ABLine.refPtA.easting.ToString(CultureInfo.InvariantCulture) + "," + ABLine.refPtA.northing.ToString(CultureInfo.InvariantCulture));
        //            writer.WriteLine(ABLine.refPtB.easting.ToString(CultureInfo.InvariantCulture) + "," + ABLine.refPtB.northing.ToString(CultureInfo.InvariantCulture));
        //            writer.WriteLine(ABLine.tramPassEvery.ToString(CultureInfo.InvariantCulture) + "," + ABLine.passBasedOn.ToString(CultureInfo.InvariantCulture));
        //        }

        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message + "\n Cannot write to file.");
        //            WriteErrorLog("Saving AB Line" + e.ToString());

        //            return;
        //        }

        //    }
        //}

        //save all the flag markers
        //public void FileSaveCurveLine()
        //{
        //    //Saturday, February 11, 2017  -->  7:26:52 AM

        //    //get the directory and make sure it exists, create if not
        //    string dirField = fieldsDirectory + currentFieldDirectory + "\\";

        //    string directoryName = Path.GetDirectoryName(dirField);
        //    if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
        //    { Directory.CreateDirectory(directoryName); }

        //    //use Streamwriter to create and overwrite existing ABLine file
        //    using (StreamWriter writer = new StreamWriter(dirField + "CurveLine.txt"))
        //    {
        //        try
        //        {
        //            //write out the ABLine
        //            writer.WriteLine("$CurveLine");

        //            //write out the heading
        //            writer.WriteLine(curve.refCurve.heading.ToString(CultureInfo.InvariantCulture));

        //            //write out the points of ref line
        //            writer.WriteLine(curve.refCurve.curvePts.Count.ToString(CultureInfo.InvariantCulture));
        //            if (curve.refCurve.curvePts.Count > 0)
        //            {
        //                for (int j = 0; j < curve.refCurve.curvePts.Count; j++)
        //                    writer.WriteLine(Math.Round(curve.refCurve.curvePts[j].easting, 3).ToString(CultureInfo.InvariantCulture) + "," +
        //                                        Math.Round(curve.refCurve.curvePts[j].northing, 3).ToString(CultureInfo.InvariantCulture) + "," +
        //                                            Math.Round(curve.refCurve.curvePts[j].heading, 5).ToString(CultureInfo.InvariantCulture));
        //            }
        //        }

        //        catch (Exception e)
        //        {
        //            WriteErrorLog("Saving Curve Line" + e.ToString());

        //            return;
        //        }

        //    }
        //}

        //save nmea sentences
        public void FileSaveNMEA()
        {
            using (StreamWriter writer = new StreamWriter("zAOG_log.txt", true))
            {
                writer.Write(pn.logNMEASentence.ToString());
            }
            pn.logNMEASentence.Clear();
        }

        public void FileSaveSystemEvents()
        {
            using (StreamWriter writer = new StreamWriter("zSystemEventsLog_log.txt", true))
            {
                writer.Write(sbSystemEvents);
            }
        }

        //save nmea sentences
        public void FileSaveElevation()
        {
            using (StreamWriter writer = new StreamWriter((fieldsDirectory + currentFieldDirectory + "\\Elevation.txt"), true))
            {
                writer.Write(sbGrid.ToString());
            }
            sbGrid.Clear();
        }

        //generate KML file from flag
        public void FileSaveSingleFlagKML2(int flagNumber)
        {
            double lat = 0;
            double lon = 0;
            double elev = Math.Round(pn.altitude, 4);
            pn.ConvertLocalToWGS84(flagPts[flagNumber - 1].northing, flagPts[flagNumber - 1].easting, out lat, out lon);

            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string myFileName;
            myFileName = "Flag.kml";

            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {
                //match new fix to current position


                writer.WriteLine(@"<?xml version=""1.0"" encoding=""UTF-8""?>     ");
                writer.WriteLine(@"<kml xmlns=""http://www.opengis.net/kml/2.2""> ");

                int count2 = flagPts.Count;

                writer.WriteLine(@"<Document>");

                writer.WriteLine(@"  <Placemark>                                  ");
                writer.WriteLine(@"<Style> <IconStyle>");
                if (flagPts[flagNumber - 1].color == 0)  //red - xbgr
                    writer.WriteLine(@"<color>ff4400ff</color>");
                if (flagPts[flagNumber - 1].color == 1)  //grn - xbgr
                    writer.WriteLine(@"<color>ff44ff00</color>");
                if (flagPts[flagNumber - 1].color == 2)  //yel - xbgr
                    writer.WriteLine(@"<color>ff44ffff</color>");
                writer.WriteLine(@"</IconStyle> </Style>");
                writer.WriteLine(@" <name> " + flagNumber.ToString(CultureInfo.InvariantCulture) + @"</name>");
                writer.WriteLine(@"<Point><coordinates> " +
                                lon.ToString(CultureInfo.InvariantCulture) + "," + lat.ToString(CultureInfo.InvariantCulture) + "," + elev.ToString(CultureInfo.InvariantCulture) +
                                @"</coordinates> </Point> ");
                writer.WriteLine(@"  </Placemark>                                 ");
                writer.WriteLine(@"</Document>");
                writer.WriteLine(@"</kml>                                         ");

            }
        }
                                   
        //generate KML file from flag
        public void FileSaveSingleFlagKML(int flagNumber)
        {
            double elev = Math.Round(pn.altitude, 4);
            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string myFileName;
            myFileName = "Flag.kml";

            using (StreamWriter writer = new StreamWriter(dirField + myFileName))
            {
                //match new fix to current position

                writer.WriteLine(@"<?xml version=""1.0"" encoding=""UTF-8""?>     ");
                writer.WriteLine(@"<kml xmlns=""http://www.opengis.net/kml/2.2""> ");

                int count2 = flagPts.Count;

                writer.WriteLine(@"<Document>");

                    writer.WriteLine(@"  <Placemark>                                  ");
                    writer.WriteLine(@"<Style> <IconStyle>");
                    if (flagPts[flagNumber - 1].color == 0)  //red - xbgr
                        writer.WriteLine(@"<color>ff4400ff</color>");
                    if (flagPts[flagNumber - 1].color == 1)  //grn - xbgr
                        writer.WriteLine(@"<color>ff44ff00</color>");
                    if (flagPts[flagNumber - 1].color == 2)  //yel - xbgr
                        writer.WriteLine(@"<color>ff44ffff</color>");
                    writer.WriteLine(@"</IconStyle> </Style>");
                    writer.WriteLine(@" <name> " + flagNumber.ToString(CultureInfo.InvariantCulture) + @"</name>");
                    writer.WriteLine(@"<Point><coordinates> " +
                                    flagPts[flagNumber-1].longitude.ToString(CultureInfo.InvariantCulture) + "," + flagPts[flagNumber-1].latitude.ToString(CultureInfo.InvariantCulture) + "," + elev.ToString(CultureInfo.InvariantCulture) +
                                    @"</coordinates> </Point> ");
                    writer.WriteLine(@"  </Placemark>                                 ");
                writer.WriteLine(@"</Document>");
                writer.WriteLine(@"</kml>                                         ");

            }
        }

        //generate KML file from flag
        public void FileMakeKMLFromCurrentPosition(double lat, double lon)
        {
            double elev = Math.Round(pn.altitude, 4);

            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }


            using (StreamWriter writer = new StreamWriter(dirField + "CurrentPosition.kml"))
            {

                writer.WriteLine(@"<?xml version=""1.0"" encoding=""UTF-8""?>     ");
                writer.WriteLine(@"<kml xmlns=""http://www.opengis.net/kml/2.2""> ");

                int count2 = flagPts.Count;

                writer.WriteLine(@"<Document>");

                writer.WriteLine(@"  <Placemark>                                  ");
                writer.WriteLine(@"<Style> <IconStyle>");
                writer.WriteLine(@"<color>ff4400ff</color>");
                writer.WriteLine(@"</IconStyle> </Style>");
                writer.WriteLine(@" <name> Your Current Position </name>");
                writer.WriteLine(@"<Point><coordinates> " +
                                lon.ToString(CultureInfo.InvariantCulture) + "," + lat.ToString(CultureInfo.InvariantCulture) + "," + elev.ToString(CultureInfo.InvariantCulture) +
                                @"</coordinates> </Point> ");
                writer.WriteLine(@"  </Placemark>                                 ");
                writer.WriteLine(@"</Document>");
                writer.WriteLine(@"</kml>                                         ");

            }
        }

        //generate KML file from flags
        public void ExportFieldAs_KML()
        {
            //get the directory and make sure it exists, create if not
            string dirField = fieldsDirectory + currentFieldDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            string myFileName;
            myFileName = "Field.kml";

            XmlTextWriter kml = new XmlTextWriter(dirField + myFileName, Encoding.UTF8);

            kml.Formatting = Formatting.Indented;
            kml.Indentation = 3;

            kml.WriteStartDocument();
            kml.WriteStartElement("kml", "http://www.opengis.net/kml/2.2");
            kml.WriteStartElement("Document");

            //Description  ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
            kml.WriteStartElement("Folder");
            kml.WriteElementString("name", "Field Stats");
            kml.WriteElementString("description", fd.GetDescription());
            kml.WriteEndElement(); // <Folder>
            //End of Desc

            //Boundary  ----------------------------------------------------------------------
            kml.WriteStartElement("Folder");
            kml.WriteElementString("name", "Boundaries");

            for (int i = 0; i < bnd.bndList.Count; i++)
            {
                kml.WriteStartElement("Placemark");
                if (i == 0) kml.WriteElementString("name", currentFieldDirectory);

                //lineStyle
                kml.WriteStartElement("Style");
                kml.WriteStartElement("LineStyle");
                if (i == 0) kml.WriteElementString("color", "ffdd00dd");
                else kml.WriteElementString("color", "ff4d3ffd");
                kml.WriteElementString("width", "4");
                kml.WriteEndElement(); // <LineStyle>

                kml.WriteStartElement("PolyStyle");
                if (i == 0) kml.WriteElementString("color", "407f3f55");
                else kml.WriteElementString("color", "703f38f1");
                kml.WriteEndElement(); // <PloyStyle>
                kml.WriteEndElement(); //Style

                kml.WriteStartElement("Polygon");
                kml.WriteElementString("tessellate", "1");
                kml.WriteStartElement("outerBoundaryIs");
                kml.WriteStartElement("LinearRing");

                //coords
                kml.WriteStartElement("coordinates");
                string bndPts = "";
                if (bnd.bndList[i].fenceLine.Count > 3)
                    bndPts = GetBoundaryPointsLatLon(i);
                kml.WriteRaw(bndPts);
                kml.WriteEndElement(); // <coordinates>

                kml.WriteEndElement(); // <Linear>
                kml.WriteEndElement(); // <OuterBoundary>
                kml.WriteEndElement(); // <Polygon>
                kml.WriteEndElement(); // <Placemark>
            }

            kml.WriteEndElement(); // <Folder>  
            //End of Boundary

            //guidance lines AB
            kml.WriteStartElement("Folder");
            kml.WriteElementString("name", "AB_Lines");
            kml.WriteElementString("visibility", "0");

            string linePts = "";

            for (int i = 0; i < trk.gArr.Count; i++)
            {
                kml.WriteStartElement("Placemark");
                kml.WriteElementString("visibility", "0");

                kml.WriteElementString("name", trk.gArr[i].name);
                kml.WriteStartElement("Style");

                kml.WriteStartElement("LineStyle");
                kml.WriteElementString("color", "ff0000ff");
                kml.WriteElementString("width", "2");
                kml.WriteEndElement(); // <LineStyle>
                kml.WriteEndElement(); //Style

                kml.WriteStartElement("LineString");
                kml.WriteElementString("tessellate", "1");
                kml.WriteStartElement("coordinates");

                linePts = pn.GetLocalToWSG84_KML(trk.gArr[i].ptA.easting - (Math.Sin(trk.gArr[i].heading) * ABLine.abLength),
                    trk.gArr[i].ptA.northing - (Math.Cos(trk.gArr[i].heading) * ABLine.abLength));
                linePts += pn.GetLocalToWSG84_KML(trk.gArr[i].ptA.easting + (Math.Sin(trk.gArr[i].heading) * ABLine.abLength),
                    trk.gArr[i].ptA.northing + (Math.Cos(trk.gArr[i].heading) * ABLine.abLength));
                kml.WriteRaw(linePts);

                kml.WriteEndElement(); // <coordinates>
                kml.WriteEndElement(); // <LineString>

                kml.WriteEndElement(); // <Placemark>

            }
            kml.WriteEndElement(); // <Folder>   

            //guidance lines Curve
            kml.WriteStartElement("Folder");
            kml.WriteElementString("name", "Curve_Lines");
            kml.WriteElementString("visibility", "0");

            for (int i = 0; i < trk.gArr.Count; i++)
            {
                linePts = "";
                kml.WriteStartElement("Placemark");
                kml.WriteElementString("visibility", "0");

                kml.WriteElementString("name", trk.gArr[i].name);
                kml.WriteStartElement("Style");

                kml.WriteStartElement("LineStyle");
                kml.WriteElementString("color", "ff6699ff");
                kml.WriteElementString("width", "2");
                kml.WriteEndElement(); // <LineStyle>
                kml.WriteEndElement(); //Style

                kml.WriteStartElement("LineString");
                kml.WriteElementString("tessellate", "1");
                kml.WriteStartElement("coordinates");

                for (int j = 0; j < trk.gArr[i].curvePts.Count; j++)
                {
                    linePts += pn.GetLocalToWSG84_KML(trk.gArr[i].curvePts[j].easting, trk.gArr[i].curvePts[j].northing);
                }
                kml.WriteRaw(linePts);

                kml.WriteEndElement(); // <coordinates>
                kml.WriteEndElement(); // <LineString>

                kml.WriteEndElement(); // <Placemark>
            }
            kml.WriteEndElement(); // <Folder>   

            //Recorded Path
            kml.WriteStartElement("Folder");
            kml.WriteElementString("name", "Recorded Path");
            kml.WriteElementString("visibility", "1");

            linePts = "";
            kml.WriteStartElement("Placemark");
            kml.WriteElementString("visibility", "1");

            kml.WriteElementString("name", "Path " + 1);
            kml.WriteStartElement("Style");

            kml.WriteStartElement("LineStyle");
            kml.WriteElementString("color", "ff44ffff");
            kml.WriteElementString("width", "2");
            kml.WriteEndElement(); // <LineStyle>
            kml.WriteEndElement(); //Style

            kml.WriteStartElement("LineString");
            kml.WriteElementString("tessellate", "1");
            kml.WriteStartElement("coordinates");

            for (int j = 0; j < recPath.recList.Count; j++)
            {
                linePts += pn.GetLocalToWSG84_KML(recPath.recList[j].easting, recPath.recList[j].northing);
            }
            kml.WriteRaw(linePts);

            kml.WriteEndElement(); // <coordinates>
            kml.WriteEndElement(); // <LineString>

            kml.WriteEndElement(); // <Placemark>
            kml.WriteEndElement(); // <Folder>

            //flags  *************************************************************************
            kml.WriteStartElement("Folder");
            kml.WriteElementString("name", "Flags");

            for (int i = 0; i < flagPts.Count; i++)
            {
                kml.WriteStartElement("Placemark");
                kml.WriteElementString("name", "Flag_"+ i.ToString());

                kml.WriteStartElement("Style");
                kml.WriteStartElement("IconStyle");

                if (flagPts[i].color == 0)  //red - xbgr
                    kml.WriteElementString("color", "ff4400ff");
                if (flagPts[i].color == 1)  //grn - xbgr
                    kml.WriteElementString("color", "ff44ff00");
                if (flagPts[i].color == 2)  //yel - xbgr
                    kml.WriteElementString("color", "ff44ffff");

                kml.WriteEndElement(); //IconStyle
                kml.WriteEndElement(); //Style

                kml.WriteElementString("name", ((i + 1).ToString() + " " + flagPts[i].notes));
                kml.WriteStartElement("Point");
                kml.WriteElementString("coordinates", flagPts[i].longitude.ToString(CultureInfo.InvariantCulture) +
                    "," + flagPts[i].latitude.ToString(CultureInfo.InvariantCulture) + "," + flagPts[i].elevation.ToString(CultureInfo.InvariantCulture));
                kml.WriteEndElement(); //Point
                kml.WriteEndElement(); // <Placemark>
            }
            kml.WriteEndElement(); // <Folder>   
            //End of Flags

            //Sections  ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
            kml.WriteStartElement("Folder");
            kml.WriteElementString("name", "Sections");
            //kml.WriteElementString("description", fd.GetDescription() );

            string secPts = "";
            int cntr = 0;

            for (int j = 0; j < triStrip.Count; j++)
            {
                int patches = triStrip[j].patchList.Count;

                if (patches > 0)
                {
                    //for every new chunk of patch
                    foreach (var triList in triStrip[j].patchList)
                    {
                        if (triList.Count > 0)
                        {
                            kml.WriteStartElement("Placemark");
                            kml.WriteElementString("name", "Sections_" + cntr.ToString());
                            cntr++;

                            string collor = "F0" + ((byte)(triList[0].heading)).ToString("X2") +
                                ((byte)(triList[0].northing)).ToString("X2") + ((byte)(triList[0].easting)).ToString("X2");

                            //lineStyle
                            kml.WriteStartElement("Style");

                            kml.WriteStartElement("LineStyle");
                            kml.WriteElementString("color", collor);
                            //kml.WriteElementString("width", "6");
                            kml.WriteEndElement(); // <LineStyle>
                            
                            kml.WriteStartElement("PolyStyle");
                            kml.WriteElementString("color", collor);
                            kml.WriteEndElement(); // <PloyStyle>
                            kml.WriteEndElement(); //Style

                            kml.WriteStartElement("Polygon");
                            kml.WriteElementString("tessellate", "1");
                            kml.WriteStartElement("outerBoundaryIs");
                            kml.WriteStartElement("LinearRing");
                            
                            //coords
                            kml.WriteStartElement("coordinates");
                            secPts = "";
                            for (int i = 1; i < triList.Count; i += 2)
                            {
                                secPts += pn.GetLocalToWSG84_KML(triList[i].easting, triList[i].northing);
                            }
                            for (int i = triList.Count - 1; i > 1; i -= 2)
                            {
                                secPts += pn.GetLocalToWSG84_KML(triList[i].easting, triList[i].northing);
                            }
                            secPts += pn.GetLocalToWSG84_KML(triList[1].easting, triList[1].northing);

                            kml.WriteRaw(secPts);
                            kml.WriteEndElement(); // <coordinates>

                            kml.WriteEndElement(); // <LinearRing>
                            kml.WriteEndElement(); // <outerBoundaryIs>
                            kml.WriteEndElement(); // <Polygon>

                            kml.WriteEndElement(); // <Placemark>
                        }
                    }
                }
            }
            kml.WriteEndElement(); // <Folder>
            //End of sections

            //end of document
            kml.WriteEndElement(); // <Document>
            kml.WriteEndElement(); // <kml>

            //The end
            kml.WriteEndDocument();

            kml.Flush();

            //Write the XML to file and close the kml
            kml.Close();
        }

        public string GetBoundaryPointsLatLon(int bndNum)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < bnd.bndList[bndNum].fenceLine.Count; i++)
            {
                double lat = 0;
                double lon = 0;

                pn.ConvertLocalToWGS84(bnd.bndList[bndNum].fenceLine[i].northing, bnd.bndList[bndNum].fenceLine[i].easting, out lat, out lon);

                sb.Append(lon.ToString("N7", CultureInfo.InvariantCulture) + ',' + lat.ToString("N7", CultureInfo.InvariantCulture) + ",0 ");
            }
            return sb.ToString();
        }

        private void FileUpdateAllFieldsKML()
        {

            //get the directory and make sure it exists, create if not
            string dirAllField = fieldsDirectory + "\\";

            string directoryName = Path.GetDirectoryName(dirAllField);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            {
                return; //We have no fields to aggregate.
            }

            string myFileName;
            myFileName = "AllFields.kml";

            XmlTextWriter kml = new XmlTextWriter(dirAllField + myFileName, Encoding.UTF8);

            kml.Formatting = Formatting.Indented;
            kml.Indentation = 3;

            kml.WriteStartDocument();
            kml.WriteStartElement("kml", "http://www.opengis.net/kml/2.2");
            kml.WriteStartElement("Document");

            foreach(String dir in Directory.EnumerateDirectories(directoryName).OrderBy(d => new DirectoryInfo(d).Name).ToArray())
            //loop
            {
                if (!File.Exists(dir + "\\" + "Field.kml")) continue;

                directoryName = Path.GetFileName(dir);
                kml.WriteStartElement("Folder");
                kml.WriteElementString("name", directoryName);

                var lines = File.ReadAllLines(dir + "\\" + "Field.kml");
                LinkedList<string> linebuffer = new LinkedList<string>();
                for( var i = 3; i < lines.Length-2; i++)  //We want to skip the first 3 and last 2 lines
                {
                    linebuffer.AddLast(lines[i]);
                    if(linebuffer.Count > 2)
                    {
                        kml.WriteRaw("   ");
                        kml.WriteRaw(Environment.NewLine);
                        kml.WriteRaw(linebuffer.First.Value);
                        linebuffer.RemoveFirst();
                    }
                }
                kml.WriteRaw("   ");
                kml.WriteRaw(Environment.NewLine);
                kml.WriteRaw(linebuffer.First.Value);
                linebuffer.RemoveFirst();
                kml.WriteRaw("   ");
                kml.WriteRaw(Environment.NewLine);
                kml.WriteRaw(linebuffer.First.Value);
                kml.WriteRaw(Environment.NewLine);

                kml.WriteEndElement(); // <Folder>
                kml.WriteComment("End of " +directoryName);
            }

            //end of document
            kml.WriteEndElement(); // <Document>
            kml.WriteEndElement(); // <kml>

            //The end
            kml.WriteEndDocument();

            kml.Flush();

            //Write the XML to file and close the kml
            kml.Close();

        }
    }
}