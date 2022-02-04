using System;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace UDP_Sim
{
    public partial class FormSim : Form
    {
        #region properties sim
        private string TimeNow = "";

        //Our two new nmea strings
        private readonly StringBuilder sbOGI = new StringBuilder();
        private readonly StringBuilder sbNDA = new StringBuilder();

        private readonly StringBuilder sbHDT = new StringBuilder();
        private readonly StringBuilder sbRMC = new StringBuilder();

        private readonly StringBuilder sbGGA = new StringBuilder();
        private readonly StringBuilder sbVTG = new StringBuilder();
        private readonly StringBuilder sbAVR = new StringBuilder();
        private readonly StringBuilder sbKSXT = new StringBuilder();

        //The entire string to send out
        private readonly StringBuilder sbSendText = new StringBuilder();

        private readonly Socket UDPSocket;
        IPEndPoint AgOpenGPS;

        //GPS related properties
        private readonly int fixQuality = 8, sats = 12;

        private readonly double HDOP = 0.9;
        public double altitude = 300;
        private char EW = 'W';
        private char NS = 'N';
        private bool isUDPNetworkConnected = false;

        public double latitude, longitude;

        private double latDeg, latMinu, longDeg, longMinu, latNMEA, longNMEA;
        public double speed = 0.6, headingTrue, stepDistance = 0.05, steerAngle;
        public double steerAngleScrollBar = 0;
        private double degrees, roll = 0;

        private int rollIMU = 0, headingIMU = 0;

        private double steerAngleWAS = 0;
        private const double ToRadians = 0.01745329251994329576923690768489, ToDegrees = 57.295779513082325225835265587528;

        //The checksum of an NMEA line
        private string sumStr = "";

        public byte[] pgnIMU = new byte[] { 0x80, 0x81, 0x7f, 0xD3, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0xCC };
        public byte[] pgnWAS = new byte[] { 0x80, 0x81, 0x7E, 0xFD, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0xCC };
        public byte[] pgnIMUDisconnect = new byte[] { 0x80, 0x81, 0x7C, 0xD4, 2, 1, 0, 0xCC };

        #endregion properties sim

        public FormSim()
        {
            InitializeComponent();

            //this.Icon = Properties.Resources.Icon;
            KeyPreview = true;
            textBox1.Lines = new string[3];
            latitude = 53.4360564;
            longitude = -111.160047;

            lblLat.Text = (latitude = Properties.Settings.Default.GPS_Latitude).ToString("N8");
            lblLon.Text = (longitude = Properties.Settings.Default.GPS_Longitude).ToString("N8");

            UDPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            UDPSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
            isUDPNetworkConnected = true;

            //AgIO sends to AgOpen on this endpoint
            AgOpenGPS = new IPEndPoint(IPAddress.Parse(Properties.Settings.Default.IPAddress), Properties.Settings.Default.Port);

            textBox2.Text = Properties.Settings.Default.IPAddress;
            nudPort.Value = Properties.Settings.Default.Port;
            nudHz.Value = Properties.Settings.Default.Hz;

            cboxGGA.Checked = Properties.Settings.Default.isGGA;
            cboxVTG.Checked = Properties.Settings.Default.isVTG;
            cboxAVR.Checked = Properties.Settings.Default.isAVR;
            cboxHDT.Checked = Properties.Settings.Default.isHDT;
            cboxRMC.Checked = Properties.Settings.Default.isRMC;
            cboxOGI.Checked = Properties.Settings.Default.isOGI;
            cboxIMU.Checked = Properties.Settings.Default.isIMU;
            cboxNDA.Checked = Properties.Settings.Default.isNDA;
            cboxKSXT.Checked = Properties.Settings.Default.isKSXT;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            isUDPNetworkConnected = false;
            if (UDPSocket != null)
            {
                try
                {
                    UDPSocket.Shutdown(SocketShutdown.Both);
                }
                finally { UDPSocket.Close(); }
            }

            //save settings before exit
            Properties.Settings.Default.isGGA = cboxGGA.Checked;
            Properties.Settings.Default.isVTG = cboxVTG.Checked;
            Properties.Settings.Default.isAVR = cboxAVR.Checked;
            Properties.Settings.Default.isHDT = cboxHDT.Checked;
            Properties.Settings.Default.isRMC = cboxRMC.Checked;
            Properties.Settings.Default.isOGI = cboxOGI.Checked;
            Properties.Settings.Default.isIMU = cboxIMU.Checked;
            Properties.Settings.Default.isNDA = cboxNDA.Checked;
            Properties.Settings.Default.isKSXT = cboxKSXT.Checked;

            Properties.Settings.Default.IPAddress = textBox2.Text;

            Properties.Settings.Default.GPS_Latitude = double.Parse(lblLat.Text);
            Properties.Settings.Default.GPS_Longitude = double.Parse(lblLon.Text);

            Properties.Settings.Default.Port = (int)nudPort.Value;

            Properties.Settings.Default.Hz = (byte)nudHz.Value;


            Properties.Settings.Default.Save();
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            if (trackBar3.Value < 0) Kmh.BackColor = Color.Salmon;
            else Kmh.BackColor = Color.LightGreen;

            Kmh.Text = "Kmh: " + (trackBar3.Value*0.1).ToString("N1");
            mSec.Text = "M/Sec: " + (trackBar3.Value * 0.027777777777).ToString("N1");
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            Heading.Text = "Heading: " + (trackBar2.Value * 0.1).ToString() +"°";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            trackBar2.Value = 0;
            headingTrue = ToRadians * trackBar2.Value * 0.1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            trackBar2.Value = 900;
            headingTrue = ToRadians * trackBar2.Value * 0.1;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Heading.Text = "Heading: " + (trackBar2.Value * 0.1).ToString() + "°";
            headingTrue = ToRadians * trackBar2.Value * 0.1;
        }

        private void tbarRoll_ValueChanged(object sender, EventArgs e)
        {
            roll = (double)tbarRoll.Value;
            lblRoll.Text = "Roll: " + roll;
        }

        private void tbarIMUHeading_ValueChanged(object sender, EventArgs e)
        {
            headingIMU = tbarIMUHeading.Value;
            lblIMUHeading.Text = "IMU Heading: " + (headingIMU).ToString();
        }

        private void tbarWAS_ValueChanged(object sender, EventArgs e)
        {
            steerAngleWAS = tbarWAS.Value;
            lblWAS.Text = "Steer Angle: " + (steerAngleWAS * 0.1).ToString("N1") + "°";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            trackBar2.Value = 1800;
            headingTrue = ToRadians * trackBar2.Value * 0.1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            trackBar2.Value = 2700;
            headingTrue = ToRadians * trackBar2.Value*0.1;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            int cursorPosition = lblLat.SelectionStart;
            if (e.KeyChar == '\b')
            {
                if (lblLat.Text.Length > 0 && cursorPosition > 0)
                {
                    if (lblLat.SelectionLength > 0)
                    {
                        lblLat.Text = lblLat.Text.Remove(cursorPosition, lblLat.SelectionLength);
                        cursorPosition -= lblLat.SelectionLength;
                    }
                    else
                        lblLat.Text = lblLat.Text.Remove(--cursorPosition, 1);
                    lblLat.SelectionStart = cursorPosition;
                }
            }
            else if (char.IsNumber(e.KeyChar))
            {
                if (lblLat.SelectionLength > 0)
                {
                    lblLat.Text = lblLat.Text.Remove(cursorPosition, lblLat.SelectionLength);
                    cursorPosition -= lblLat.SelectionLength;
                }
                string tt = e.KeyChar.ToString();
                lblLat.Text = lblLat.Text.Insert(cursorPosition, tt);
                lblLat.SelectionStart = ++cursorPosition;
            }
            else if (e.KeyChar == '.')
            {
                if (lblLat.Text.IndexOf(".") == -1)
                {
                    if (lblLat.SelectionLength > 0)
                    {
                        lblLat.Text = lblLat.Text.Remove(cursorPosition, lblLat.SelectionLength);
                        cursorPosition -= lblLat.SelectionLength;
                    }
                    if (cursorPosition == 0)
                    {
                        lblLat.Text = "0." + lblLat.Text;
                        lblLat.SelectionStart = cursorPosition+=2;
                    }
                    else if (lblLat.Text.IndexOf("-") == 0 && cursorPosition == 1)
                    {
                        lblLat.Text = lblLat.Text.Insert(cursorPosition, "0.");
                        lblLat.SelectionStart = cursorPosition+=2;
                    }
                    else
                    {
                        lblLat.Text = lblLat.Text.Insert(cursorPosition, ".");
                        lblLat.SelectionStart = ++cursorPosition;
                    }
                }
            }
            else if (e.KeyChar == '-')
            {
                int length = lblLat.SelectionLength;
                if (lblLat.Text.StartsWith("-"))
                {
                    lblLat.Text = lblLat.Text.Substring(1);
                    if (cursorPosition > 0) lblLat.SelectionStart = --cursorPosition;
                }
                else
                {
                    lblLat.Text = "-" + lblLat.Text;
                    lblLat.SelectionStart = ++cursorPosition;
                }
                lblLat.SelectionLength = length;
            }
            lblLat.Focus();
            e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            int cursorPosition = lblLon.SelectionStart;
            if (e.KeyChar == '\b')
            {
                if (lblLon.Text.Length > 0 && cursorPosition > 0)
                {
                    if (lblLon.SelectionLength > 0)
                    {
                        lblLon.Text = lblLon.Text.Remove(cursorPosition, lblLon.SelectionLength);
                        cursorPosition -= lblLon.SelectionLength;
                    }
                    else
                        lblLon.Text = lblLon.Text.Remove(--cursorPosition, 1);
                    lblLon.SelectionStart = cursorPosition;
                }
            }
            else if (char.IsNumber(e.KeyChar))
            {
                if (lblLon.SelectionLength > 0)
                {
                    lblLon.Text = lblLon.Text.Remove(cursorPosition, lblLon.SelectionLength);
                    cursorPosition -= lblLon.SelectionLength;
                }
                string tt = e.KeyChar.ToString();
                lblLon.Text = lblLon.Text.Insert(cursorPosition, tt);
                lblLon.SelectionStart = ++cursorPosition;
            }
            else if (e.KeyChar == '.')
            {
                if (lblLon.Text.IndexOf(".") == -1)
                {
                    if (lblLon.SelectionLength > 0)
                    {
                        lblLon.Text = lblLon.Text.Remove(cursorPosition, lblLon.SelectionLength);
                        cursorPosition -= lblLon.SelectionLength;
                    }
                    if (cursorPosition == 0)
                    {
                        lblLon.Text = "0." + lblLon.Text;
                        lblLon.SelectionStart = cursorPosition += 2;
                    }
                    else if (lblLon.Text.IndexOf("-") == 0 && cursorPosition == 1)
                    {
                        lblLon.Text = lblLon.Text.Insert(cursorPosition, "0.");
                        lblLon.SelectionStart = cursorPosition += 2;
                    }
                    else
                    {
                        lblLon.Text = lblLon.Text.Insert(cursorPosition, ".");
                        lblLon.SelectionStart = ++cursorPosition;
                    }
                }
            }
            else if (e.KeyChar == '-')
            {
                int length = lblLon.SelectionLength;
                if (lblLon.Text.StartsWith("-"))
                {
                    lblLon.Text = lblLon.Text.Substring(1);
                    if (cursorPosition > 0) lblLon.SelectionStart = --cursorPosition;
                }
                else
                {
                    lblLon.Text = "-" + lblLon.Text;
                    lblLon.SelectionStart = ++cursorPosition;
                }
                lblLon.SelectionLength = length;
            }
            lblLon.Focus();
            e.Handled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (IPAddress.TryParse(textBox2.Text, out _))
                Properties.Settings.Default.IPAddress = textBox2.Text;
            if(double.TryParse(lblLat.Text, out double lat))
                Properties.Settings.Default.GPS_Latitude = latitude = lat;
            if (double.TryParse(lblLon.Text, out double lon))
                Properties.Settings.Default.GPS_Longitude = longitude = lon;

            Properties.Settings.Default.Port = (int)nudPort.Value;
            Properties.Settings.Default.Hz = (byte)nudHz.Value;

            Properties.Settings.Default.Save();

            timer1.Interval = (int)(1000.0 / (double)nudHz.Value);
            AgOpenGPS = new IPEndPoint(IPAddress.Parse(Properties.Settings.Default.IPAddress), Properties.Settings.Default.Port);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            lblLat.Text = latitude.ToString("N8");
            lblLon.Text = longitude.ToString("N8");
        }

        private void lblWAS_Click(object sender, EventArgs e)
        {
            tbarWAS.Value = 0;
        }

        private void cboxIMU_Click(object sender, EventArgs e)
        {
            if (!cboxIMU.Checked)
                SendUDPMessage(pgnIMUDisconnect);
        }

        private void tbarRollIMU_ValueChanged(object sender, EventArgs e)
        {
            rollIMU = tbarRollIMU.Value;
            lblIMURoll.Text = "Roll: " + rollIMU;
        }

        private void DoSimTick(object sender, EventArgs e)
        {
            stepDistance = trackBar3.Value * 0.027777777777 * (1.0 / (double)nudHz.Value);

            steerAngle = tbarWAS.Value * 0.1;
            double temp = (stepDistance * Math.Tan(steerAngle * 0.0165329252) / 3.3);
            headingTrue += temp;



            if (headingTrue > (2.0 * Math.PI)) headingTrue -= (2.0 * Math.PI);
            if (headingTrue < 0) headingTrue += (2.0 * Math.PI);


            //Calculate the next Lat Long based on heading and distance
            degrees = ToDegrees * headingTrue;


            trackBar2.Value = (int)(degrees * 10.0);
            CalculateNewPostionFromBearingDistance(ToRadians * latitude, ToRadians * longitude, headingTrue, stepDistance / 1000.0);

            //calc the speed
            speed = Math.Round(1.944 * stepDistance * 1.0 / (1.0 / (double)nudHz.Value), 1);


            TimeNow = DateTime.UtcNow.ToString("HHmmss.fff,", CultureInfo.InvariantCulture);

            if (cboxVTG.Checked)
            {
                BuildVTG();
                sbSendText.Append(sbVTG.ToString());
                SendUDPMessage(sbVTG.ToString());
            }
            if (cboxAVR.Checked)
            {
                BuildAVR();
                sbSendText.Append(sbAVR.ToString());
                SendUDPMessage(sbAVR.ToString());
            }
            if (cboxHDT.Checked)
            {
                BuildHDT();
                sbSendText.Append(sbHDT.ToString());
                SendUDPMessage(sbHDT.ToString());
            }
            if (cboxGGA.Checked)
            {
                BuildGGA();
                sbSendText.Append(sbGGA.ToString());
                SendUDPMessage(sbGGA.ToString());
            }
            if (cboxRMC.Checked)
            {
                BuildRMC();
                sbSendText.Append(sbRMC.ToString());
                SendUDPMessage(sbRMC.ToString());
            }
            if (cboxOGI.Checked)
            {
                BuildOGI();
                sbSendText.Append(sbOGI.ToString());
                SendUDPMessage(sbOGI.ToString());
            }

            if (cboxNDA.Checked)
            {
                BuildNDA();
                sbSendText.Append(sbNDA.ToString());
                SendUDPMessage(sbNDA.ToString());
            }

            if (cboxKSXT.Checked)
            {
                BuildKSXT();
                sbSendText.Append(sbKSXT.ToString());
                SendUDPMessage(sbKSXT.ToString());
            }

            textBox1.Text = sbSendText.ToString();
            sbSendText.Clear();

            if (cboxIMU.Checked)
            {
                if (cboxIMUHeading.Checked)
                {
                    pgnIMU[5] = unchecked((byte)((int)(Math.Abs(headingIMU))));
                    pgnIMU[6] = unchecked((byte)((int)(Math.Abs(headingIMU)) >> 8));
                }
                else
                {
                    pgnIMU[5] = unchecked((byte)((int)(Math.Abs(headingTrue * ToDegrees) * 10.0)));
                    pgnIMU[6] = unchecked((byte)((int)(Math.Abs(headingTrue * ToDegrees) * 10.0) >> 8));
                }

                pgnIMU[7] = unchecked((byte)((int)(roll * 10.0)));
                pgnIMU[8] = unchecked((byte)((int)(roll * 10.0) >> 8));
                SendUDPMessage(pgnIMU);

            }

            if (cboxWAS.Checked)
            {
                pgnWAS[5] = unchecked((byte)((int)(steerAngleWAS*10)));
                pgnWAS[6] = unchecked((byte)((int)(steerAngleWAS*10) >> 8));

                pgnWAS[7] = unchecked((byte)((int)(9999)));
                pgnWAS[8] = unchecked((byte)((int)(9999) >> 8));
                pgnWAS[9] = unchecked((byte)((int)(8888)));
                pgnWAS[10] = unchecked((byte)((int)(8888) >> 8));

                if (cboxSwitch.Checked)
                    pgnWAS[11] = unchecked((byte)5);
                else
                    pgnWAS[11] = unchecked((byte)7);

                SendUDPMessage(pgnWAS);
            }
        }

        public void SendUDPMessage(string message)
        {
            if (isUDPNetworkConnected)
            {
                try
                {
                    // Get packet as byte array to send
                    byte[] byteData = Encoding.ASCII.GetBytes(message);
                    if (byteData.Length != 0)
                        UDPSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None,
                            AgOpenGPS, new AsyncCallback(SendDataUDPAsync), null);
                }
                catch (Exception)
                {
                }
            }
        }

        public void SendUDPMessage(byte[] byteData)
        {
            if (isUDPNetworkConnected)
            {
                try
                {
                    int crc = 0;
                    for (int i = 2; i + 1 < byteData.Length; i++)
                    {
                        crc += byteData[i];
                    }
                    byteData[byteData.Length - 1] = (byte)crc;

                    // Send packet to the zero
                    if (byteData.Length != 0)
                    {
                        UDPSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None,
                            AgOpenGPS, new AsyncCallback(SendDataUDPAsync), null);
                    }
                }
                catch (Exception)
                {
                    //WriteErrorLog("Sending UDP Message" + e.ToString());
                    //MessageBox.Show("Send Error: " + e.Message, "UDP Client", MessageBoxButtons.OK,
                    //MessageBoxIcon.Error);
                }
            }
        }

        private void SendDataUDPAsync(IAsyncResult asyncResult)
        {
            try
            {
                UDPSocket.EndSend(asyncResult);
            }
            catch (Exception)
            {
            }
        }

        public void CalculateNewPostionFromBearingDistance(double lat, double lng, double bearing, double distance)
        {
            double R = distance / 6371.0; // Earth Radius in Km

            double lat2 = Math.Asin((Math.Sin(lat) * Math.Cos(R)) + (Math.Cos(lat) * Math.Sin(R) * Math.Cos(bearing)));
            double lon2 = lng + Math.Atan2(Math.Sin(bearing) * Math.Sin(R) * Math.Cos(lat), Math.Cos(R) - (Math.Sin(lat) * Math.Sin(lat2)));

            latitude = ToDegrees * lat2;
            longitude = ToDegrees * lon2;

            //convert to DMS from Degrees
            latMinu = latitude;
            longMinu = longitude;

            latDeg = (int)latitude;
            longDeg = (int)longitude;

            latMinu -= latDeg;
            longMinu -= longDeg;

            latMinu = Math.Round(latMinu * 60.0, 7);
            longMinu = Math.Round(longMinu * 60.0, 7);

            latDeg *= 100.0;
            longDeg *= 100.0;

            latNMEA = latMinu + latDeg;
            longNMEA = longMinu + longDeg;

            if (latitude >= 0) NS = 'N';
            else NS = 'S';
            if (longitude >= 0) EW = 'E';
            else EW = 'W';
        }

        //calculate the NMEA checksum to stuff at the end
        public void CalculateChecksum(string Sentence)
        {
            int sum = 0, inx;
            char[] sentence_chars = Sentence.ToCharArray();
            char tmp;
            // All character xor:ed results in the trailing hex checksum
            // The checksum calc starts after '$' and ends before '*'
            for (inx = 1; ; inx++)
            {
                tmp = sentence_chars[inx];
                // Indicates end of data and start of checksum
                if (tmp == '*')
                    break;
                sum ^= tmp;    // Build checksum
            }
            // Calculated checksum converted to a 2 digit hex string
            sumStr = String.Format("{0:X2}", sum);
        }

        private void BuildGGA()
        {
            sbGGA.Clear();
            sbGGA.Append("$GPGGA,");
            sbGGA.Append(TimeNow);
            sbGGA.Append(Math.Abs(latNMEA).ToString("0000.0000000", CultureInfo.InvariantCulture)).Append(',').Append(NS).Append(',');
            sbGGA.Append(Math.Abs(longNMEA).ToString("00000.0000000", CultureInfo.InvariantCulture)).Append(',').Append(EW).Append(',');
            sbGGA.Append(fixQuality.ToString(CultureInfo.InvariantCulture)).Append(',').Append(sats.ToString(CultureInfo.InvariantCulture)).Append(',').Append(HDOP.ToString(CultureInfo.InvariantCulture)).Append(',').Append(numericUpDown2.Value.ToString(CultureInfo.InvariantCulture));
            sbGGA.Append(",M,46.9,M,37.1,,*");

            CalculateChecksum(sbGGA.ToString());
            sbGGA.Append(sumStr);
            sbGGA.Append("\r\n");
        }

        private void BuildVTG()
        {
            sbVTG.Clear();
            sbVTG.Append("$GPVTG,");
            sbVTG.Append(degrees.ToString("N5",CultureInfo.InvariantCulture));
            sbVTG.Append(",T,034.4,M,");
            sbVTG.Append(speed.ToString(CultureInfo.InvariantCulture));
            sbVTG.Append(",N,");
            sbVTG.Append((speed * 1.852).ToString(CultureInfo.InvariantCulture));
            sbVTG.Append(",K*");

            CalculateChecksum(sbVTG.ToString());
            sbVTG.Append(sumStr);
            sbVTG.Append("\r\n");
        }

        private void BuildHDT()
        {
            sbHDT.Clear();
            sbHDT.Append("$GNHDT,");
            sbHDT.Append(degrees.ToString("N5", CultureInfo.InvariantCulture));
            sbHDT.Append(",T*");

            CalculateChecksum(sbHDT.ToString());
            sbHDT.Append(sumStr);
            sbHDT.Append("\r\n");
        }

        private void BuildAVR()
        {
            sbAVR.Clear();
            sbAVR.Append("$PTNL,AVR,");
            sbAVR.Append(TimeNow);
            sbAVR.Append(degrees.ToString("N5", CultureInfo.InvariantCulture)); //field 2

            sbAVR.Append(",Yaw,-2.1,Tilt,"); //field 3,4,5

            sbAVR.Append(roll.ToString()+",Roll,"); //field 6,7

            sbAVR.Append("444.232,3,1.2,17*"); //field 8 thru 12

            CalculateChecksum(sbAVR.ToString());
            sbAVR.Append(sumStr);
            sbAVR.Append("\r\n");
        }

        private void BuildOGI()
        {

            sbOGI.Clear();
            sbOGI.Append("$PAOGI,");

            sbOGI.Append(TimeNow);
            sbOGI.Append(Math.Abs(latNMEA).ToString("0000.0000000", CultureInfo.InvariantCulture)).Append(',').Append(NS).Append(',');
            sbOGI.Append(Math.Abs(longNMEA).ToString("0000.0000000", CultureInfo.InvariantCulture)).Append(',').Append(EW).Append(',');

            sbOGI.Append(fixQuality.ToString(CultureInfo.InvariantCulture)).Append(',')
                .Append(sats.ToString(CultureInfo.InvariantCulture)).Append(',')
                .Append(HDOP.ToString(CultureInfo.InvariantCulture)).Append(',')
                .Append(numericUpDown2.Value.ToString(CultureInfo.InvariantCulture)).Append(",3.2,")                                                                    //10
                .Append(speed.ToString(CultureInfo.InvariantCulture)).Append(',')
                .Append(degrees.ToString("N5", CultureInfo.InvariantCulture)).Append(',')
                .Append(roll.ToString(CultureInfo.InvariantCulture)).Append(",0.12,359.9,T*");

            CalculateChecksum(sbOGI.ToString());
            sbOGI.Append(sumStr);
            sbOGI.Append("\r\n");
        }

        private void BuildNDA()
        {

            sbNDA.Clear();
            sbNDA.Append("$PANDA,");

            sbNDA.Append(TimeNow);
            sbNDA.Append(Math.Abs(latNMEA).ToString("0000.0000000", CultureInfo.InvariantCulture)).Append(',').Append(NS).Append(',');
            sbNDA.Append(Math.Abs(longNMEA).ToString("0000.0000000", CultureInfo.InvariantCulture)).Append(',').Append(EW).Append(',');

            sbNDA.Append(fixQuality.ToString(CultureInfo.InvariantCulture)).Append(',')
                .Append(sats.ToString(CultureInfo.InvariantCulture)).Append(',')
                .Append(HDOP.ToString(CultureInfo.InvariantCulture)).Append(',')
                .Append(numericUpDown2.Value.ToString(CultureInfo.InvariantCulture)).Append(",3.2,")                                                                    //10
                .Append(speed.ToString(CultureInfo.InvariantCulture)).Append(',')
                .Append((headingIMU).ToString(CultureInfo.InvariantCulture)).Append(',')
                .Append((rollIMU).ToString(CultureInfo.InvariantCulture)).Append(",3.2,29.8").Append("*");

            CalculateChecksum(sbNDA.ToString());
            sbNDA.Append(sumStr);
            sbNDA.Append("\r\n");
        }

        private void BuildKSXT()
        {
            sbKSXT.Clear();
            sbKSXT.Append("$KSXT,"); //0

            sbKSXT.Append(TimeNow); //1
            sbKSXT.Append(longitude.ToString("N7", CultureInfo.InvariantCulture)).Append(',');//2
            sbKSXT.Append(latitude.ToString("N7", CultureInfo.InvariantCulture)).Append(','); //3

            sbKSXT.Append(altitude.ToString(CultureInfo.InvariantCulture)).Append(',') //4 altitude
                .Append(degrees.ToString("N5", CultureInfo.InvariantCulture)).Append(',') //5 true heading
                .Append(roll.ToString(CultureInfo.InvariantCulture))//6 Roll
                .Append(",22,") // 7 Pitch
                .Append(speed.ToString(CultureInfo.InvariantCulture)).Append(',')// 8 Speed in kmh
                .Append(",35,3,3,13,-1075,-98,-8,,,,37,13,,")// 9 to ... SpeedAngle to end
                .Append("*3FCF0C9B");

            //sbKSXT.Append(sumStr);
            sbKSXT.Append("\r\n");
        }

        /*
                0 $KSXT  Log header

                1 20191219093115.00 YYYYMMDDhhmmss.ss Satellite time in format of yyyymmddhhmmss.ss,
                                    e.g. 2016040106284180 means
                                    2016(year)4(month)1(day)06(hour)28(mins)41.80(secs)

                2 112.87713062  Longitude(°)

                3 28.23315515  Latitude(°)

                4 65.5618  Height (m) Elevation

                5 0.00  Yaw, the angle between the line connecting two
                antennas and True North (primary antenna
                positioning and secondary antenna heading) (0°
                360°)

                6 0.00  Pitch (-90° 90°) IS ACTUALLY ROLL USED

                7 336.65 Speed angle, the angle between vehicle traveling
                direction and True North (0° 360°)

                8 0.010  Speed in vehicle traveling direction (km/h)

                9 0.00  Roll (-90° 90°) IS ACTUALLY PITCH

                10 3  Positioning status: 0-invalid solution; 1-single point solution; 
                                            2-RTK floating point; 3-RTK fixed point

                11 0  Heading status: 0-invalid solution; 1-single point solution; 
                                        2-RTK floating point; 3-RTK fixed point

                12 0    Number of satellites used in heading

                13 23   Number of satellites used in positioning (primary antenna)

                14 -1075.146  East position under geographic coordinates with
                                the base station as the origin (m) (empty if none)

                15 -98.462  North position under geographic coordinates with
                the base station as the origin (m) (empty if none)

                16 -8.618  Up position under geographic coordinates with
                the base station as the origin (m) (empty if none)

                17 -0.004  East speed under geographic coordinates (km/h)
                (empty if none)

                18 0.009 North speed under geographic coordinates (km/h)
                (empty if none)

                19 0.004  Up speed under geographic coordinates (km/h)
                (empty if none)

                20 1.0  Age of differential

                21 30  Number of satellites tracked in base station

                22  Reserved

                23 Parity 3FCF0C9B XOR check sum (Hex string, check from the
                beginning of the frame)


                        */

        private void BuildRMC()
        {
            sbRMC.Clear();
            sbRMC.Append("$GPRMC,")
            .Append(TimeNow).Append("A,")
            .Append(Math.Abs(latNMEA).ToString("0000.0000000", CultureInfo.InvariantCulture)).Append(',').Append(NS).Append(',')
            .Append(Math.Abs(longNMEA).ToString("0000.0000000", CultureInfo.InvariantCulture)).Append(',').Append(EW).Append(',')
            .Append(speed.ToString(CultureInfo.InvariantCulture)).Append(',')
            .Append(degrees.ToString("N5", CultureInfo.InvariantCulture))
            .Append(",230394,359.9*");

            CalculateChecksum(sbRMC.ToString());
            sbRMC.Append(sumStr);
            sbRMC.Append("\r\n");
        }
    }
}
