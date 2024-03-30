using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AgOpenGPS
{
    
    public class WGS84
    {
        public double Lat;
        public double Lon;

        public WGS84(double lat, double lon)
        {
            Lat = lat;
            Lon = lon;
        }
    }

    public class Polyline2
    {
        public List<vec2> points = new List<vec2>();
        public bool loop;

        public override string ToString()
        {
            return "points = " + points.Count.ToString() + ", loop = " + loop.ToString();
        }

    }
    public class RatePolyline : Polyline2
    {
        public Color color = Color.Transparent;
        public double rate = 100;

        public bool IsClockwise()
        {
            double area = 0;         // Accumulates area in the loop
            int ptCount = points.Count;
            if (ptCount < 1) return false;

            int j = ptCount - 1;  // The last vertex is the 'previous' one to the first

            for (int i = 0; i < ptCount; j = i++)
            {
                area += (points[j].easting + points[i].easting) * (points[j].northing - points[i].northing);
            }

            bool isClockwise = area >= 0;

            area = Math.Abs(area / 2);

            //make sure boundary is clockwise
            if (!isClockwise)
                points.Reverse();
            return isClockwise;
        }
    }


    public class ShapePolygon2
    {
        public double bndBoxLeft;
        public double bndBoxRight;
        public double bndBoxTop;
        public double bndBoxBottom;
        public List<Polyline2> Parts = new List<Polyline2>();
        public int[] BufferID, NumElements, BufferIndex;
        public Color color = Color.FromArgb(0x78000000);
    }


    public class ShapeFile
    {
        private const int HeaderLength = 100;

        private readonly FormGPS mf;
        Random rnd = new Random();

        public ShapeFile(FormGPS _f)
        {
            mf = _f;
        }

        public void Main(string FilePath)
        {
            FileStream MainStream = File.Open(FilePath + ".shp", FileMode.Open, FileAccess.Read, FileShare.Read);

            DataTable table = new DataTable();

            if (File.Exists(FilePath + ".dbf"))
            {
                FileStream DBFStream = File.Open(FilePath + ".dbf", FileMode.Open, FileAccess.Read, FileShare.Read);

                byte[] buffer = new byte[4];
                DBFStream.Position = 4;
                DBFStream.Read(buffer, 0, buffer.Length);

                int RowsCount = buffer[0] +
                    (buffer[1] * 0x100) +
                    (buffer[2] * 0x10000) +
                    (buffer[3] * 0x1000000);

                buffer = new byte[2];
                DBFStream.Position = 8;
                DBFStream.Read(buffer, 0, buffer.Length);

                int FieldCount = (((buffer[0] + (buffer[1] * 0x100)) - 1) / 32) - 1;


                string[] FieldName = new string[FieldCount];
                string[] FieldType = new string[FieldCount]; // Массив типов полей

                byte[] FieldSize = new byte[FieldCount]; // Массив размеров полей
                byte[] FieldDigs = new byte[FieldCount]; // Массив размеров дробной части

                buffer = new byte[32 * FieldCount];
                DBFStream.Position = 32;
                DBFStream.Read(buffer, 0, buffer.Length);
                int FieldsLength = 0;

                // Типы полей DBF
                Type typeC = Type.GetType("System.String");
                Type typeL = Type.GetType("System.Boolean");
                Type typeD = Type.GetType("System.DateTime");
                Type typeN0 = Type.GetType("System.Int32");
                Type typeN = Type.GetType("System.Decimal");
                Type typeF = Type.GetType("System.Double");

                for (int col = 0; col < FieldCount; col++)
                {
                    // Заголовки
                    FieldName[col] = Encoding.Default
                        .GetString(buffer, col * 32, 10)
                        .TrimEnd(new char[] { (char)0x00 });
                    FieldType[col] = "" + (char)buffer[col * 32 + 11];
                    FieldSize[col] = buffer[col * 32 + 16];
                    FieldDigs[col] = buffer[col * 32 + 17];

                    FieldsLength += FieldSize[col];

                    // Создаю колонки
                    Type type;
                    switch (FieldType[col])
                    {
                        case "C":
                            type = typeC;
                            break;

                        case "L":
                            type = typeL;
                            break;

                        case "D":
                            type = typeD;
                            break;

                        case "N":
                            type = FieldDigs[col] == 0 ? typeN0 : typeN;
                            break;

                        case "F":
                            type = typeF;
                            break;

                        default:
                            throw new Exception("Неизвестный тип поля DBF");
                    }
                    table.Columns.Add(FieldName[col], type);
                }
                DBFStream.ReadByte(); // Пропускаю разделитель схемы и данных

                DateTimeFormatInfo dfi = new CultureInfo("en-US", false).DateTimeFormat;
                NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;

                buffer = new byte[FieldsLength];
                table.BeginLoadData();

                for (int row = 0; row < RowsCount; row++)
                {
                    DBFStream.ReadByte(); // Пропускаю стартовый байт элемента данных
                    DBFStream.Read(buffer, 0, buffer.Length);
                    DataRow R = table.NewRow();
                    int Index = 0;

                    for (int col = 0; col < FieldCount; col++)
                    {
                        string value = Encoding.GetEncoding(866)
                            .GetString(buffer, Index, FieldSize[col])
                            .TrimEnd(new char[] { (char)0x00 })
                            .TrimEnd(new char[] { (char)0x20 });

                        Index += FieldSize[col];

                        if (string.IsNullOrEmpty(value) || value  == "******************")
                        {
                            R[col] = DBNull.Value;
                        }
                        else
                        {
                            switch (FieldType[col])
                            {
                                case "L":
                                    R[col] = value.Equals("T"); // ? true : false;
                                    break;

                                case "D":
                                    R[col] = DateTime.ParseExact(value, "yyyyMMdd", dfi);
                                    break;

                                case "N":
                                    if (FieldDigs[col] == 0)
                                    {
                                        R[col] = int.Parse(value, nfi);
                                    }
                                    else
                                    {
                                        R[col] = decimal.Parse(value, nfi);
                                    }
                                    break;

                                case "F":
                                    R[col] = double.Parse(value, nfi);
                                    break;

                                default:
                                    R[col] = value;
                                    break;
                            }
                        }
                    }
                    table.Rows.Add(R);
                    //Application.DoEvents();
                }
                DBFStream.Close();
            }

            if (MainStream.Length > HeaderLength)
            {
                // read in and parse the headers
                byte[] ByteArray = new byte[HeaderLength];
                MainStream.Read(ByteArray, 0, HeaderLength);

                int FileCode = ParseInt(ByteArray, 0, false);
                int FileLength = ParseInt(ByteArray, 24, false) * 2;
                int FileVersion = ParseInt(ByteArray, 28, true);
                //int FileShapeType = ParseInt(ByteArray, 32, true);

                if (FileCode == 9994 && FileVersion == 1000 && MainStream.Length == FileLength)
                {


                    //int XMin = ReadInt(ByteArray, 36, true);
                    //int YMin = ReadInt(ByteArray, 44, true);
                    //int XMax = ReadInt(ByteArray, 52, true);
                    //int YMax = ReadInt(ByteArray, 60, true);
                    //int ZMin = ReadInt(ByteArray, 68, true);
                    //int ZMax = ReadInt(ByteArray, 76, true);
                    //int MMin = ReadInt(ByteArray, 84, true);
                    //int MMax = ReadInt(ByteArray, 92, true);

                    int Index = HeaderLength;
                    int ShapeLength = 12;
                    while (FileLength > Index + ShapeLength)
                    {
                        ByteArray = new byte[ShapeLength];
                        //MainStream.Seek(Index, SeekOrigin.Begin);
                        MainStream.Read(ByteArray, 0, ShapeLength);

                        //int RecordNum = ReadInt(ByteArray, Index, false);
                        ShapeLength = ParseInt(ByteArray, 4, false) * 2 + 8;

                        ByteArray = new byte[ShapeLength];
                        MainStream.Seek(Index, SeekOrigin.Begin);
                        MainStream.Read(ByteArray, 0, ShapeLength);
                        int ShapeType = ParseInt(ByteArray, 8, true);
                        if (ShapeType == 5 && ShapeLength >= 52)
                        {
                            //bndBoxLeft = ParseDouble(ByteArray, 12, true),
                            //bndBoxTop = ParseDouble(ByteArray, 20, true),
                            //bndBoxRight = ParseDouble(ByteArray, 28, true),
                            //bndBoxBottom = ParseDouble(ByteArray, 36, true)

                            int numParts = ParseInt(ByteArray, 44, true);
                            int numPoints = ParseInt(ByteArray, 48, true);

                            if (ShapeLength == 52 + (4 * numParts) + (16 * numPoints))
                            {
                                int Offset = 52 + (4 * numParts);

                                for (int part = 0; part < numParts; part++)
                                {
                                    int startPart = ParseInt(ByteArray, 52 + 4 * part, true) * 16 + Offset;
                                    int nextPart = part + 1 < numParts ? ParseInt(ByteArray, 52 + 4 * (part + 1), true) * 16 + Offset : ShapeLength;

                                    int numBytes = nextPart - startPart;

                                    // the number of 16-byte points to read for this segment
                                    int numPointsInPart = numBytes / 16;

                                    RatePolyline newRateLine = new RatePolyline();

                                    for (int point = 0; point < numPointsInPart; point++)
                                    {
                                        WGS84 tt = new WGS84(ParseDouble(ByteArray, startPart + 8 + (16 * point), true), ParseDouble(ByteArray, startPart + 0 + (16 * point), true));

                                        mf.pn.ConvertWGS84ToLocal(tt.Lat, tt.Lon, out double Northing, out double Easting);
                                        newRateLine.points.Add(new vec2(Easting, Northing));
                                    }

                                    if (newRateLine.points[0].easting == newRateLine.points[newRateLine.points.Count - 1].easting && newRateLine.points[0].northing == newRateLine.points[newRateLine.points.Count - 1].northing)
                                    {
                                        newRateLine.points.RemoveAt(0);
                                    }
                                    newRateLine.IsClockwise();

                                    int dd;
                                    if ((dd = table.Columns.IndexOf("rate")) >=0)
                                    {
                                        newRateLine.rate = double.Parse(table.Rows[mf.bnd.shpList.Count][dd].ToString(), CultureInfo.InvariantCulture);
                                    }
                                    if ((dd = table.Columns.IndexOf("rgb")) >= 0)
                                    {
                                        string[] ddd = table.Rows[mf.bnd.shpList.Count][dd].ToString().Split(',');
                                        newRateLine.color = Color.FromArgb(int.Parse(ddd[0], CultureInfo.InvariantCulture), int.Parse(ddd[1], CultureInfo.InvariantCulture), int.Parse(ddd[2], CultureInfo.InvariantCulture));

                                    }
                                    else
                                    {
                                        newRateLine.color = Color.FromArgb((255), rnd.Next(127) + 127, rnd.Next(127) + 127, rnd.Next(127) + 127);
                                    }

                                    double bndBoxLeft = ParseDouble(ByteArray, 12, true);
                                    double bndBoxTop = ParseDouble(ByteArray, 20, true);
                                    double bndBoxRight = ParseDouble(ByteArray, 28, true);
                                    double bndBoxBottom = ParseDouble(ByteArray, 36, true);


                                    mf.bnd.shpList.Add(newRateLine);
                                }
                            }
                        }
                        else if (ShapeType == 8 && ShapeLength >= 48)
                        {
                            //double bndBoxLeft = ParseDouble(ByteArray, 12, true);
                            //double bndBoxTop = ParseDouble(ByteArray, 20, true);
                            //double bndBoxRight = ParseDouble(ByteArray, 28, true);
                            //double bndBoxBottom = ParseDouble(ByteArray, 36, true);
                            int numPoints = ParseInt(ByteArray, 44, true);

                            if (ShapeLength == 48 + (16 * numPoints))
                            {
                                for (int point = 0; point < numPoints; point++)
                                {
                                    WGS84 tt = new WGS84(ParseDouble(ByteArray, 56 + (16 * point), true), ParseDouble(ByteArray, 48 + (16 * point), true));
                                    mf.pn.ConvertWGS84ToLocal(tt.Lat, tt.Lon, out double Northing, out double Easting);
                                    mf.flagPts.Add(new CFlag(tt.Lat, tt.Lon, Easting, Northing, 0, 0, mf.flagPts.Count+1, (mf.flagPts.Count + 1).ToString()));
                                }
                            }
                        }
                        else if (Debugger.IsAttached && ShapeType == 31 && ShapeLength >= 48)
                        {
                            //aa.bndBoxLeft = ParseDouble(ByteArray, 12, true);
                            //aa.bndBoxTop = ParseDouble(ByteArray, 20, true);
                            //aa.bndBoxRight = ParseDouble(ByteArray, 28, true);
                            //aa.bndBoxBottom = ParseDouble(ByteArray, 36, true);
                            int numParts = ParseInt(ByteArray, 44, true);
                            int numPoints = ParseInt(ByteArray, 48, true);

                            if (ShapeLength == 68 + (8 * numParts) + (24 * numPoints) || ShapeLength == 84 + (8 * numParts) + (32 * numPoints))//dont care for the Marray
                            {
                                int Offset = 52 + (8 * numParts);

                                for (int part = 0; part < numParts; part++)
                                {
                                    int startPart = ParseInt(ByteArray, 52 + 4 * part, true) * 16 + Offset;

                                    int nextPart = part + 1 < numParts ? ParseInt(ByteArray, 52 + 4 * (part + 1), true) * 16 + Offset : Offset + 16 * numPoints;

                                    int numBytes = nextPart - startPart;
                                    int type = ParseInt(ByteArray, 52 + 4 * numParts + 4 * part, true);

                                    // the number of 16-byte points to read for this segment
                                    int numPointsInPart = numBytes / 16;

                                    Polyline2 New = new Polyline2();
                                    for (int point = 0; point < numPointsInPart; point++)
                                    {
                                        WGS84 tt = new WGS84(ParseDouble(ByteArray, startPart + 8 + (16 * point), true), ParseDouble(ByteArray, startPart + (16 * point), true));
                                        mf.pn.ConvertWGS84ToLocal(tt.Lat, tt.Lon, out double Northing, out double Easting);
                                        New.points.Add(new vec2(Easting, Northing));
                                    }

                                    if (type == 0)
                                    {
                                        //mf.patchList.Add(newRateLine);  TODO
                                        throw new Exception("patchlist not implemented");
                                    }
                                    else if (type > 1)
                                    {
                                        ShapePolygon2 aa = new ShapePolygon2
                                        {
                                            bndBoxLeft = ParseDouble(ByteArray, 12, true),
                                            bndBoxTop = ParseDouble(ByteArray, 20, true),
                                            bndBoxRight = ParseDouble(ByteArray, 28, true),
                                            bndBoxBottom = ParseDouble(ByteArray, 36, true)
                                        };

                                        //if (table.Rows.Count > Polygons.Count && table.Columns.Count > 3)
                                        //    aa.color = table.Rows[Polygons.Count][4].ToString() == "100" ? Color.FromArgb(0x78FF0000) : Color.FromArgb(0x7800FF00);
                                        aa.Parts.Add(New);
                                        //Polygons.Add(aa);
                                    }
                                }
                            }
                        }
                        Index += ShapeLength;
                        ShapeLength = 12;//reset length for next
                    }
                }
            }

            MainStream.Close();
        }

        public double ParseDouble(byte[] ByteArray, int Idx, bool LittleEndian)
        {
            if (BitConverter.IsLittleEndian != LittleEndian)
            {
                byte[] Code = new byte[8];
                Array.Copy(ByteArray, Idx, Code, 0, 8);
                Array.Reverse(Code);
                return BitConverter.ToDouble(Code, 0);
            }
            else return BitConverter.ToDouble(ByteArray, Idx);
        }

        public int ParseInt(byte[] ByteArray, int Idx, bool LittleEndian)
        {
            if (BitConverter.IsLittleEndian != LittleEndian)
            {
                byte[] Code = new byte[4];
                Array.Copy(ByteArray, Idx, Code, 0, 4);
                Array.Reverse(Code);
                return BitConverter.ToInt32(Code, 0);
            }
            else return BitConverter.ToInt32(ByteArray, Idx);
        }
        /*
        public void FileCreateShapeFile()
        {
            string directoryName = Path.GetDirectoryName(mf.baseDirectory);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            using (FileStream StringWriter = new FileStream(mf.baseDirectory + "WTest.prj", FileMode.Create))
            {
                byte[] text = Encoding.ASCII.GetBytes("GEOGCS[\"GCS_WGS_1984\",DATUM[\"D_WGS_1984\",SPHEROID[\"WGS_1984\",6378137,298.257223563]],PRIMEM[\"Greenwich\",0],UNIT[\"Degree\",0.017453292519943295]]");
                StringWriter.Write(text, 0, text.Length);
            }

            using (FileStream IndexWriter = new FileStream(mf.baseDirectory + "WTest.shx", FileMode.Create))
            {
                using (FileStream MainWriter = new FileStream(mf.baseDirectory + "WTest.shp", FileMode.Create))
                {
                    int mainIndex = 100, Cnt = 0;
                    double MaxBndBoxLeft = 0;
                    double MaxBndBoxRight = 0;
                    double MaxBndBoxTop = 0;
                    double MaxBndBoxBottom = 0;
                    bool first = true;

                    for (int i = 0; i < mf.ShapeFile.Polygons.Count; i++)
                    {
                        if (mf.ShapeFile.Polygons[i].InsideLargeView)
                        {

                            if (first || mf.ShapeFile.Polygons[i].bndBoxLeft < MaxBndBoxLeft)
                            {
                                MaxBndBoxLeft = mf.ShapeFile.Polygons[i].bndBoxLeft;
                            }
                            if (first || mf.ShapeFile.Polygons[i].bndBoxRight > MaxBndBoxRight)
                            {
                                MaxBndBoxRight = mf.ShapeFile.Polygons[i].bndBoxRight;
                            }
                            if (first || mf.ShapeFile.Polygons[i].bndBoxTop < MaxBndBoxTop)
                            {
                                MaxBndBoxTop = mf.ShapeFile.Polygons[i].bndBoxTop;
                            }
                            if (first || mf.ShapeFile.Polygons[i].bndBoxBottom > MaxBndBoxBottom)
                            {
                                MaxBndBoxBottom = mf.ShapeFile.Polygons[i].bndBoxBottom;
                            }
                            first = false;


                            int numpoints = 0;

                            int actualpointidx = 52 + 4 * mf.ShapeFile.Polygons[i].Parts.Count;

                            for (int j = 0; j < mf.ShapeFile.Polygons[i].Parts.Count; j++)
                            {
                                WriteBytes(MainWriter, mainIndex + 52 + j * 4, BitConverter.GetBytes(numpoints), true);//numParts

                                numpoints += mf.ShapeFile.Polygons[i].Parts[j].Length;

                                for (int k = 0; k < mf.ShapeFile.Polygons[i].Parts[j].Length; k++)
                                {
                                    WriteBytes(MainWriter, mainIndex + actualpointidx, BitConverter.GetBytes(mf.ShapeFile.Polygons[i].Parts[j][k].Lon), true);//Points
                                    actualpointidx += 8;
                                    WriteBytes(MainWriter, mainIndex + actualpointidx, BitConverter.GetBytes(mf.ShapeFile.Polygons[i].Parts[j][k].Lat), true);//Points
                                    actualpointidx += 8;
                                }
                            }

                            WriteBytes(MainWriter, mainIndex + 0, BitConverter.GetBytes(Cnt + 1), false);//Number
                            WriteBytes(MainWriter, mainIndex + 4, BitConverter.GetBytes(actualpointidx / 2 - 4), false);//Content Length
                            WriteBytes(MainWriter, mainIndex + 8, BitConverter.GetBytes(5), true);//polygon
                            WriteBytes(MainWriter, mainIndex + 12, BitConverter.GetBytes(mf.ShapeFile.Polygons[i].bndBoxLeft), true);//box
                            WriteBytes(MainWriter, mainIndex + 20, BitConverter.GetBytes(mf.ShapeFile.Polygons[i].bndBoxTop), true);//box
                            WriteBytes(MainWriter, mainIndex + 28, BitConverter.GetBytes(mf.ShapeFile.Polygons[i].bndBoxRight), true);//box
                            WriteBytes(MainWriter, mainIndex + 36, BitConverter.GetBytes(mf.ShapeFile.Polygons[i].bndBoxBottom), true);//box
                            WriteBytes(MainWriter, mainIndex + 44, BitConverter.GetBytes(mf.ShapeFile.Polygons[i].Parts.Count), true);//NumParts
                            WriteBytes(MainWriter, mainIndex + 48, BitConverter.GetBytes(numpoints), true);//NumPoints

                            WriteBytes(IndexWriter, HeaderLength + Cnt * 8, BitConverter.GetBytes(mainIndex / 2), false);
                            WriteBytes(IndexWriter, HeaderLength + Cnt * 8 + 4, BitConverter.GetBytes(actualpointidx / 2 - 4), false);

                            mainIndex += actualpointidx;
                            Cnt++;
                        }
                    }

                    WriteBytes(MainWriter, 0, BitConverter.GetBytes(9994), false);//FileCode
                    WriteBytes(MainWriter, 4, BitConverter.GetBytes(0), false);//Unused
                    WriteBytes(MainWriter, 8, BitConverter.GetBytes(0), false);//Unused
                    WriteBytes(MainWriter, 12, BitConverter.GetBytes(0), false);//Unused
                    WriteBytes(MainWriter, 16, BitConverter.GetBytes(0), false);//Unused
                    WriteBytes(MainWriter, 20, BitConverter.GetBytes(0), false);//Unused
                    WriteBytes(MainWriter, 24, BitConverter.GetBytes(mainIndex / 2), false);//FileLength
                    WriteBytes(MainWriter, 28, BitConverter.GetBytes(1000), true);//Version
                    WriteBytes(MainWriter, 32, BitConverter.GetBytes(5), true);//polygon
                    WriteBytes(MainWriter, 36, BitConverter.GetBytes(MaxBndBoxLeft), true);//BoundingBox Xmin
                    WriteBytes(MainWriter, 44, BitConverter.GetBytes(MaxBndBoxTop), true);//BoundingBox Ymin
                    WriteBytes(MainWriter, 52, BitConverter.GetBytes(MaxBndBoxRight), true);//BoundingBox Xmax
                    WriteBytes(MainWriter, 60, BitConverter.GetBytes(MaxBndBoxBottom), true);//BoundingBox Ymax
                    WriteBytes(MainWriter, 68, BitConverter.GetBytes(0.0), true);//Zmin
                    WriteBytes(MainWriter, 76, BitConverter.GetBytes(0.0), true);//Zmax
                    WriteBytes(MainWriter, 84, BitConverter.GetBytes(0.0), true);//Mmin
                    WriteBytes(MainWriter, 92, BitConverter.GetBytes(0.0), true);//Mmax


                    WriteBytes(IndexWriter, 0, BitConverter.GetBytes(9994), false);//FileCode
                    WriteBytes(IndexWriter, 4, BitConverter.GetBytes(0), false);//Unused
                    WriteBytes(IndexWriter, 8, BitConverter.GetBytes(0), false);//Unused
                    WriteBytes(IndexWriter, 12, BitConverter.GetBytes(0), false);//Unused
                    WriteBytes(IndexWriter, 16, BitConverter.GetBytes(0), false);//Unused
                    WriteBytes(IndexWriter, 20, BitConverter.GetBytes(0), false);//Unused
                    WriteBytes(IndexWriter, 24, BitConverter.GetBytes(50 + Cnt * 4), false); ;//FileLength
                    WriteBytes(IndexWriter, 28, BitConverter.GetBytes(1000), true);//Version
                    WriteBytes(IndexWriter, 32, BitConverter.GetBytes(5), true);//polygon
                    WriteBytes(IndexWriter, 36, BitConverter.GetBytes(MaxBndBoxLeft), true);//BoundingBox Xmin
                    WriteBytes(IndexWriter, 44, BitConverter.GetBytes(MaxBndBoxTop), true);//BoundingBox Ymin
                    WriteBytes(IndexWriter, 52, BitConverter.GetBytes(MaxBndBoxRight), true);//BoundingBox Xmax
                    WriteBytes(IndexWriter, 60, BitConverter.GetBytes(MaxBndBoxBottom), true);//BoundingBox Ymax
                    WriteBytes(IndexWriter, 68, BitConverter.GetBytes(0.0), true);//Zmin
                    WriteBytes(IndexWriter, 76, BitConverter.GetBytes(0.0), true);//Zmax
                    WriteBytes(IndexWriter, 84, BitConverter.GetBytes(0.0), true);//Mmin
                    WriteBytes(IndexWriter, 92, BitConverter.GetBytes(0.0), true);//Mmax
                }
            }
        }

        public void FileCreateShapeFileStrip()
        {
            string directoryName = Path.GetDirectoryName(mf.baseDirectory);
            if ((directoryName.Length > 0) && (!Directory.Exists(directoryName)))
            { Directory.CreateDirectory(directoryName); }

            using (FileStream StringWriter = new FileStream(mf.baseDirectory + "WTest2.prj", FileMode.Create))
            {
                byte[] text = Encoding.ASCII.GetBytes("GEOGCS[\"GCS_WGS_1984\",DATUM[\"D_WGS_1984\",SPHEROID[\"WGS_1984\",6378137,298.257223563]],PRIMEM[\"Greenwich\",0],UNIT[\"Degree\",0.017453292519943295]]");
                StringWriter.Write(text, 0, text.Length);
            }
            using (FileStream IndexWriter = new FileStream(mf.baseDirectory + "WTest2.shx", FileMode.Create))
            {
                using (FileStream MainWriter = new FileStream(mf.baseDirectory + "WTest2.shp", FileMode.Create))
                {
                    int mainIndex = 100, Cnt = 0;
                    double MaxBndBoxLeft = 0;
                    double MaxBndBoxRight = 0;
                    double MaxBndBoxTop = 0;
                    double MaxBndBoxBottom = 0;
                    bool first = true;

                    for (int i = 0; i < 1; i++)
                    {
                        int numpoints = 0;

                        int ddd = mf.PatchDrawList.Count;
                        int actualpointidx = 52 + 8 * ddd;

                        //Position          Field           Value       Type        Number      Order
                        //Byte      44      NumParts        NumParts    Integer     1           Little
                        //Byte      48      NumPoints       NumPoints   Integer     1           Little
                        //Byte      52      Parts           Parts       Integer     NumParts    Little
                        //Byte      W       PartTypes       PartTypes   Integer     NumParts    Little
                        //Byte      X       Points          Points      Point       NumPoints   Little

                        //Byte      Y       Zmin            Zmin        Double      1           Little
                        //Byte      Y + 8   Zmax            Zmax        Double      1           Little
                        //Byte      Y + 16  Zarray          Zarray      Double      NumPoints   Little
                        //Byte      Z*      Mmin            Mmin        Double      1           Little
                        //Byte      Z + 8*  Mmax            Mmax        Double      1           Little
                        //Byte      Z + 16* Marray          Marray      Double      NumPoints   Little

                        //Note: W = 52 + (4 * NumParts)
                        //      X = W + (4 * NumParts)
                        //      Y = X + (16 * NumPoints)
                        //      Z = Y + 16 + (8 * NumPoints)

                        double ShapeMaxBndBoxLeft = 0;
                        double ShapeMaxBndBoxRight = 0;
                        double ShapeMaxBndBoxTop = 0;
                        double ShapeMaxBndBoxBottom = 0;
                        bool second = true;

                        for (int j = 0; j < ddd; j++)
                        {
                            WriteBytes(MainWriter, mainIndex + 52 + j * 4, BitConverter.GetBytes(numpoints), true);//PartsIndex
                            WriteBytes(MainWriter, mainIndex + 52 + ddd * 4 + j * 4, BitConverter.GetBytes(0), true);//PartTypes

                            numpoints += mf.PatchDrawList[j].Count-1;
                            for (int k = 1; k < mf.PatchDrawList[j].Count; k++)
                            {
                                mf.ConvertLocalToWGS84(mf.PatchDrawList[j][k].northing, mf.PatchDrawList[j][k].easting, out double Lat, out double Lon);

                                if (first || Lon < MaxBndBoxLeft)
                                    MaxBndBoxLeft = Lon;
                                if (first || Lon > MaxBndBoxRight)
                                    MaxBndBoxRight = Lon;
                                if (first || Lat < MaxBndBoxTop)
                                    MaxBndBoxTop = Lat;
                                if (first || Lat > MaxBndBoxBottom)
                                    MaxBndBoxBottom = Lat;
                                first = false;

                                if (second || Lon < ShapeMaxBndBoxLeft)
                                    ShapeMaxBndBoxLeft = Lon;
                                if (second || Lon > ShapeMaxBndBoxRight)
                                    ShapeMaxBndBoxRight = Lon;
                                if (second || Lat < ShapeMaxBndBoxTop)
                                    ShapeMaxBndBoxTop = Lat;
                                if (second || Lat > ShapeMaxBndBoxBottom)
                                    ShapeMaxBndBoxBottom = Lat;
                                second = false; 




                                WriteBytes(MainWriter, mainIndex + actualpointidx, BitConverter.GetBytes(Lon), true);//Points
                                actualpointidx += 8;
                                WriteBytes(MainWriter, mainIndex + actualpointidx, BitConverter.GetBytes(Lat), true);//Points
                                actualpointidx += 8;
                            }
                        }

                        WriteBytes(MainWriter, mainIndex + actualpointidx, BitConverter.GetBytes(0.0), true);//Points
                        actualpointidx += 8;
                        WriteBytes(MainWriter, mainIndex + actualpointidx, BitConverter.GetBytes(0.0), true);//Points
                        actualpointidx += 8;

                        for (int j = 0; j < numpoints; j++)
                        {
                            WriteBytes(MainWriter, mainIndex + actualpointidx, BitConverter.GetBytes(0.0), true);//Points
                            actualpointidx += 8;
                        }

                        //optional?
                        //WriteBytes(MainWriter, mainIndex + actualpointidx, BitConverter.GetBytes(0.0), true);//Points
                        ///actualpointidx += 8;
                        //WriteBytes(MainWriter, mainIndex + actualpointidx, BitConverter.GetBytes(0.0), true);//Points
                        //actualpointidx += 8;

                        //for (int j = 0; j < numpoints; j++)
                        //{
                        //    WriteBytes(MainWriter, mainIndex + actualpointidx, BitConverter.GetBytes(0.0), true);//Points
                        //    actualpointidx += 8;
                        //}
                        //to here
                        

                        WriteBytes(MainWriter, mainIndex + 0, BitConverter.GetBytes(Cnt + 1), false);//Number
                        WriteBytes(MainWriter, mainIndex + 4, BitConverter.GetBytes(actualpointidx / 2 - 4), false);//Content Length
                        WriteBytes(MainWriter, mainIndex + 8, BitConverter.GetBytes(31), true);//polygon
                        WriteBytes(MainWriter, mainIndex + 12, BitConverter.GetBytes(ShapeMaxBndBoxLeft), true);//box
                        WriteBytes(MainWriter, mainIndex + 20, BitConverter.GetBytes(ShapeMaxBndBoxTop), true);//box
                        WriteBytes(MainWriter, mainIndex + 28, BitConverter.GetBytes(ShapeMaxBndBoxRight), true);//box
                        WriteBytes(MainWriter, mainIndex + 36, BitConverter.GetBytes(ShapeMaxBndBoxBottom), true);//box
                        WriteBytes(MainWriter, mainIndex + 44, BitConverter.GetBytes(ddd), true);//NumParts
                        WriteBytes(MainWriter, mainIndex + 48, BitConverter.GetBytes(numpoints), true);//NumPoints

                        WriteBytes(IndexWriter, HeaderLength + Cnt * 8, BitConverter.GetBytes(mainIndex / 2), false);
                        WriteBytes(IndexWriter, HeaderLength + Cnt * 8 + 4, BitConverter.GetBytes(actualpointidx / 2 - 4), false);

                        mainIndex += actualpointidx;
                        Cnt++;
                    }

                    WriteBytes(MainWriter, 0, BitConverter.GetBytes(9994), false);//FileCode
                    WriteBytes(MainWriter, 4, BitConverter.GetBytes(0), false);//Unused
                    WriteBytes(MainWriter, 8, BitConverter.GetBytes(0), false);//Unused
                    WriteBytes(MainWriter, 12, BitConverter.GetBytes(0), false);//Unused
                    WriteBytes(MainWriter, 16, BitConverter.GetBytes(0), false);//Unused
                    WriteBytes(MainWriter, 20, BitConverter.GetBytes(0), false);//Unused
                    WriteBytes(MainWriter, 24, BitConverter.GetBytes(mainIndex / 2), false);//FileLength
                    WriteBytes(MainWriter, 28, BitConverter.GetBytes(1000), true);//Version
                    WriteBytes(MainWriter, 32, BitConverter.GetBytes(31), true);//polygon
                    WriteBytes(MainWriter, 36, BitConverter.GetBytes(MaxBndBoxLeft), true);//BoundingBox Xmin
                    WriteBytes(MainWriter, 44, BitConverter.GetBytes(MaxBndBoxTop), true);//BoundingBox Ymin
                    WriteBytes(MainWriter, 52, BitConverter.GetBytes(MaxBndBoxRight), true);//BoundingBox Xmax
                    WriteBytes(MainWriter, 60, BitConverter.GetBytes(MaxBndBoxBottom), true);//BoundingBox Ymax
                    WriteBytes(MainWriter, 68, BitConverter.GetBytes(0.0), true);//Zmin
                    WriteBytes(MainWriter, 76, BitConverter.GetBytes(0.0), true);//Zmax
                    WriteBytes(MainWriter, 84, BitConverter.GetBytes(0.0), true);//Mmin
                    WriteBytes(MainWriter, 92, BitConverter.GetBytes(0.0), true);//Mmax






                    WriteBytes(IndexWriter, 0, BitConverter.GetBytes(9994), false);//FileCode
                    WriteBytes(IndexWriter, 4, BitConverter.GetBytes(0), false);//Unused
                    WriteBytes(IndexWriter, 8, BitConverter.GetBytes(0), false);//Unused
                    WriteBytes(IndexWriter, 12, BitConverter.GetBytes(0), false);//Unused
                    WriteBytes(IndexWriter, 16, BitConverter.GetBytes(0), false);//Unused
                    WriteBytes(IndexWriter, 20, BitConverter.GetBytes(0), false);//Unused
                    WriteBytes(IndexWriter, 24, BitConverter.GetBytes(50 + Cnt * 4), false); ;//FileLength
                    WriteBytes(IndexWriter, 28, BitConverter.GetBytes(1000), true);//Version
                    WriteBytes(IndexWriter, 32, BitConverter.GetBytes(31), true);//polygon
                    WriteBytes(IndexWriter, 36, BitConverter.GetBytes(MaxBndBoxLeft), true);//BoundingBox Xmin
                    WriteBytes(IndexWriter, 44, BitConverter.GetBytes(MaxBndBoxTop), true);//BoundingBox Ymin
                    WriteBytes(IndexWriter, 52, BitConverter.GetBytes(MaxBndBoxRight), true);//BoundingBox Xmax
                    WriteBytes(IndexWriter, 60, BitConverter.GetBytes(MaxBndBoxBottom), true);//BoundingBox Ymax
                    WriteBytes(IndexWriter, 68, BitConverter.GetBytes(0.0), true);//Zmin
                    WriteBytes(IndexWriter, 76, BitConverter.GetBytes(0.0), true);//Zmax
                    WriteBytes(IndexWriter, 84, BitConverter.GetBytes(0.0), true);//Mmin
                    WriteBytes(IndexWriter, 92, BitConverter.GetBytes(0.0), true);//Mmax
                }
            }
        }
        
        public void WriteBytes(FileStream Writer, int Idx, byte[] Code, bool LittleEndian)
        {
            if (BitConverter.IsLittleEndian != LittleEndian)
                Array.Reverse(Code);
            if (Writer.Position != Idx)
                Writer.Position = Idx;
            Writer.Write(Code, 0, Code.Length);
        }
        */
    }
}
