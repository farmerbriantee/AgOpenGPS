//Please, if you use this, share the improvements

using System.IO.Ports;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SharpGL;


namespace AgOpenGPS
{
    public partial class FormGPS
    {
        public static string portName = "COM1";
        public static int baudRate = 4800;

        public bool isFirstFixPositionSet = false;

        //a distance between previous and current fix
        public double distance = 0.0;

        //array index for previous northing and easting positions
        public static int numPrevs = 20;

        //able to go back in time
        public double[] prevNorthing = new double[numPrevs];
        public double[] prevEasting = new double[numPrevs];

        public string recvSentence = "Nothing";

        //tally counters for display
        public double totalSquareMeters = 0;
        public double totalDistance = 0;

        //serial port gps is connected to
        public SerialPort sp = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);

        public int rmcUpdateHz = 1;

       //individual points
        //List<CPointData> pointList = new List<CPointData>();

        //called by the delegate every time a sentence terminated in * is rec'd
        private void SerialLineReceived(string sentence)
        {
            //spit it out no matter what it says
            recvSentence = sentence;
            textBoxRcv.Text = "";
            textBoxRcv.Text = sentence;

            //if saving a file ignore any movement
            if (isSavingFile) return;


            //parse the line received GGA and RMC
            //return 0 Bad Data, 1 RMC Data updated, 2 GGA updated 
            int newFix = pn.ParseNMEA(sentence);

            //if its a valid fix data
            if (newFix == 1)
            {
                recvSentence = sentence;
                //this is the current position taken from the latest sentence
                //CPointData pd = new CPointData(pn.northing, pn.easting, pn.speed, pn.headingTrue);

                if (!isFirstFixPositionSet)
                {
                    //Draw a grid once we know where in the world we are.
                    isFirstFixPositionSet = true;
                    worldGrid.CreateWorldGrid(pn.northing, pn.easting);

                    //moved enough to add position
                    prevNorthing[0] = pn.northing;
                    prevEasting[0] = pn.easting;

                    return;
                }

                //check if position moved enough at least 0.5 meter, if not don't save point, just return
                distance = pn.Distance(pn.northing, pn.easting, prevNorthing[0], prevEasting[0]);
                if (distance < 0.1)
                {
                    return;
                }

                //determine fix positions and heading
                fixPosX = (pn.easting);
                fixPosZ = (pn.northing);


                //in radians
                fixHeading = Math.Atan2(pn.easting - prevEasting[1], pn.northing - prevNorthing[1]);
                if (fixHeading < 0) fixHeading += Math.PI * 2.0;
 
                //in radians
                fixHeadingSection = Math.Atan2(pn.easting - prevEasting[rmcUpdateHz*2], pn.northing - prevNorthing[rmcUpdateHz*2]);
                if (fixHeadingSection < 0) fixHeadingSection += Math.PI * 2.0;

                //in degrees for glRotate opengl methods. 
                //can be filtered for smoother display by higher prevEastings and prevNorthings
                fixHeadingCam = Math.Atan2(pn.easting - prevEasting[1], pn.northing - prevNorthing[1]);
                if (fixHeadingCam < 0) fixHeadingCam += Math.PI * 2.0;
                fixHeadingCam = fixHeadingCam * 180.0 / Math.PI;

                //check to make sure the grid is big enough
                worldGrid.checkZoomWorldGrid(pn.northing, pn.easting);


                //precalc the sin and cos of heading * -1
                sinHeading = Math.Sin(-fixHeadingSection);
                cosHeading = Math.Cos(-fixHeadingSection);

                //add the pathpoint
                if (isJobStarted && isMasterSectionOn)
                {
                    //calculate the new GPS coordinates based on fore / aft of tool
                    double north = pn.northing + vehicle.toolForeAft * cosHeading;
                    double east = pn.easting + vehicle.toolForeAft * -sinHeading;
                    double prevNorth = prevNorthing[0] + vehicle.toolForeAft * cosHeading;
                    double prevEast = prevEasting[0] + vehicle.toolForeAft * -sinHeading;

                    //send the current and previous GPS fore/aft corrected fix to each section
                    for (int j = 0; j < numberOfSections; j++)
                    {
                        if (section[j].isSectionOn)
                        {
                            section[j].AddPathPoint(north, east, prevNorth, prevEast, cosHeading, sinHeading);

                            //area is made up of square meters in each section
                            totalSquareMeters += distance * section[j].sectionWidth;
                        }
                    }
                }

                //distance tally, calculated based on fixposition updates, NOT sections. Runs continuously.
                totalDistance += distance;
                
 
                //save a copy of previous positions for cam heading of desired filtering or delay
                for (int x = numPrevs-1; x > 0; x--)
                {
                    prevNorthing[x] = prevNorthing[x - 1];
                    prevEasting[x] = prevEasting[x - 1];
                }

                //most recent fixes
                prevEasting[0] = pn.easting;
                prevNorthing[0] = pn.northing;

                //speed in kph on menubar
                this.lblSpeed.Text = SpeedMPH;

                //position data fields
                this.lblLatitude.Text = Latitude;
                this.lblLongitude.Text = Longitude;
                //this.lblNorthing.Text = FixNorthing;
                //this.lblEasting.Text = FixEasting;

                //Pass number from ref ABLine
                this.lblPassNumber.Text = PassNumber;

                //accumulated hectare and distance
                this.chkSectionsOnOff.Text = Convert.ToString(Math.Round(totalSquareMeters/4046.8627,2));
                this.lblTotalDistance.Text = Convert.ToString(Math.Round(totalDistance,1));

                //  **** important *************************
                //draw the main window as its manually triggered from here    
                //no GPS signal - no drawing for OpenGL
                openGLControl.DoRender();
            }

            //a GGA sentnece rec'd

            if (newFix == 2)
            {
                recvSentence = sentence;
                this.lblSatellites.Text = SatsTracked;
                this.lblGridSpacing.Text = Convert.ToString(gridZoom);
            }

        }//end of lineReceived

 

 
        #region SerialPort
        private delegate void LineReceivedEventHandler(string sentence);

        //serial port receive in its own thread
        private void sp_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (sp.IsOpen)
            {
                try
                {
                    string sentence = sp.ReadLine();
                    this.BeginInvoke(new LineReceivedEventHandler(SerialLineReceived), sentence);
                }
                //this is bad programming, it just ignores errors until its hooked up again.
                catch (Exception) { }

                System.Threading.Thread.Sleep(100);
            }

        }

        //Event Handlers
        //private void btnExit_Click(object sender, EventArgs e) { this.Exit(); }


        public void SerialPortOpen()
        {
            if (!sp.IsOpen)
            {
                sp.PortName = portName;
                sp.BaudRate = baudRate;
                sp.DataReceived += sp_DataReceived;
            }

            try { sp.Open(); }
            catch (Exception exc) 
            {
                MessageBox.Show(exc.Message + "\n\r" + "\n\r" + "Go to Settings -> COM Ports to Fix", "No Serial Port Active");
                //SettingsPageOpen(0);
            }

            if (sp.IsOpen)
            {
                //btnOpenSerial.Enabled = false;

                //discard any stuff in the buffers
                sp.DiscardOutBuffer();
                sp.DiscardInBuffer();

                //update port status label
                this.lblConnected.ForeColor = System.Drawing.Color.YellowGreen;
                this.lblConnected.Text = "Online";

                this.lblBaudRate.Text = Convert.ToString(baudRate);
                this.lblPortName.Text = portName;

                Properties.Settings.Default.settings_portName = portName;
                Properties.Settings.Default.setting_baudRate = baudRate;
                Properties.Settings.Default.Save();
            }
        }

        public void SerialPortClose()
        {
            if (sp.IsOpen)
            {
                sp.DataReceived -= sp_DataReceived;
                try { sp.Close(); }
                catch (Exception exc) { MessageBox.Show(exc.Message, "Connection already terminated?"); }

                //btnOpenSerial.Enabled = true;

                //update port status labels
                this.lblConnected.ForeColor = System.Drawing.Color.Crimson;
                this.lblConnected.Text = "Offline";

                this.lblBaudRate.Text = "-";
                this.lblPortName.Text = "-";

                sp.Dispose();
            }

        }

         #endregion SerialPort

    }//end class
}//end namespace