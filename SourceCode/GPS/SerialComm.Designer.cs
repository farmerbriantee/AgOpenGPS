//Please, if you use this, share the improvements

using System.IO.Ports;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SharpGL;
using System.Drawing;
using System.Text;

namespace AgOpenGPS
{
    public partial class FormGPS
    {
        public static string portName = "COM GPS...";
        public static int baudRate = 4800;

        public static string portNameArduino = "COM SectionControl...";
        public static int baudRateArduino = 9600;

        //used to decide to autoconnect arduino this run
        public bool wasArduinoConnectedLastRun = false;

        //very first fix to setup grid etc
        public bool isFirstFixPositionSet = false;

        //how many fix updates per sec
        public int rmcUpdateHz = 5;

        //a distance between previous and current fix
        private double distance = 0.0;
        public double sectionDistance = 0;
        public double userDistance = 0;

        //how far travelled since last section was added, section points
        double sectionTriggerDistance = 0;
        double currentSectionNorthing = 0;
        double currentSectionEasting = 0;
        public double prevSectionNorthing = 0;
        public double prevSectionEasting = 0;

        //are we still getting valid data from GPS, resets to 0 in NMEA RMC block, watchdog 
        public int recvCounter = 20;

        //Everything is so wonky at the start, so no delay for first 20 frames
        int startCounter = 0;

        //array index for previous northing and easting positions
        private static int numPrevs = 8;
        public double[] prevNorthing = new double[numPrevs];
        public double[] prevEasting = new double[numPrevs];

        public double prevImplementNorthing = 0;
        public double prevImplementEasting = 0;
        public double prevFixHeadingSection = 0;
        public double yawRate;
        private const int TURN_STEPS = 1;

        //Low speed detection variables
        public double prevNorthingLowSpeed = 0;
        public double prevEastingLowSpeed = 0;
        double distanceLowSpeed = 0;

        public double prevFixHeading;

        public StringBuilder recvSentence = new StringBuilder();
        public StringBuilder recvSentenceArduino = new StringBuilder("SectionControl");

        public string recvSentenceSettings = "InitalSetting";
        public string recvSentenceSettingsArduino = "Section Control";

        //individual points
        List<CPointData> pointList = new List<CPointData>();

        //tally counters for display
        public double totalSquareMeters = 0;
        public double totalDistance = 0;

        //serial port gps is connected to
        public SerialPort sp = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);

        //serial port Arduino is connected to
        public SerialPort spArduino = new SerialPort(portNameArduino, baudRateArduino, Parity.None, 8, StopBits.One);

        //called by the openglDraw routine 10 times per second.
        private void UpdateFixPosition()
        {
            startCounter++;

            //if saving a file ignore any movement
            if (isSavingFile) return;

            //add what has been rec'd to the nmea buffer
            pn.rawBuffer += recvSentence.ToString();

            //empty the received sentence
            recvSentence.Clear();

            //parse the line received GGA and RMC
            pn.ParseNMEA();

            //if its a valid fix data for RMC
            if (pn.updatedGGA | pn.updatedRMC)
            {
                //this is the current position taken from the latest sentence
                textBoxRcv.Text = pn.theSent;

                //Point where the GPS antenna is.
                CPointData pd = new CPointData(pn.northing, pn.easting);
                pointList.Add(pd);

                if (!isFirstFixPositionSet)
                {
                    //Draw a grid once we know where in the world we are.
                    isFirstFixPositionSet = true;
                    worldGrid.CreateWorldGrid(pn.northing, pn.easting);

                    //most recent fixes
                    prevEasting[0] = pn.easting;   prevNorthing[0] = pn.northing;
                    prevFixHeading = fixHeading;
                    prevSectionEasting = pn.easting;  prevSectionNorthing = pn.northing;
                    prevImplementEasting = pn.easting + Math.Sin(fixHeading) * vehicle.toolForeAft;
                    prevImplementNorthing = pn.northing + Math.Cos(fixHeading) * vehicle.toolForeAft;
                    fixHeadingSection = fixHeading;

                    //save a copy of previous positions for cam heading of desired filtering or delay
                    for (int x = 0; x > numPrevs; x++) {  prevNorthing[x] = prevNorthing[0]; prevEasting[x] = prevEasting[0]; }
                    return;
                }

                //calc low speed distance travelled if speed < 2 kph and app not starting
                if (pn.speed < 2.0) distanceLowSpeed = pn.Distance(pn.northing, pn.easting, prevNorthingLowSpeed, prevEastingLowSpeed);
                else distanceLowSpeed = -1;

                //time to record next fix
                if (distanceLowSpeed > 0.5 | pn.speed > 2.0 | startCounter < 50)
                {

                    //determine fix positions and heading
                    fixPosX = (pn.easting);
                    fixPosZ = (pn.northing);

                    //save a copy to calc distance 
                    prevNorthingLowSpeed = pn.northing;
                    prevEastingLowSpeed = pn.easting;

                    //in radians
                    fixHeading = Math.Atan2(pn.easting - prevEasting[1], pn.northing - prevNorthing[1]);
                    //if (fixHeading < 0) fixHeading += Math.PI * 2.0;
                    

                    double temp;
                    temp = fixHeading-prevFixHeading;
                    if (temp > Math.PI) temp -= 2 * Math.PI;
                    if (temp < -Math.PI) temp += 2 * Math.PI;

                    if (temp > 0.78) {
                        //System.Console.Write("Large heading change from {0:N2} to ", fixHeading);
                        //System.Console.Write("{0:N2} ", prevFixHeading);

                        //If there's a very large heading change, just put the implement straight
                        //back and go from here.
                        prevImplementEasting = pn.easting + Math.Sin(fixHeading) * vehicle.toolForeAft;
                        prevImplementNorthing = pn.northing + Math.Cos(fixHeading) * vehicle.toolForeAft;
                        fixHeadingSection = fixHeading;
                    }
 

                    //in radians
                    if (vehicle.isHitched)
                    {
                       //Torriem rules!!!!! Oh yes, this is all his. Thank-you
                        double t;
                        double dist = Math.Sqrt( (pn.northing - prevImplementNorthing) * (pn.northing - prevImplementNorthing) +
                                                                    (pn.easting - prevImplementEasting) * (pn.easting - prevImplementEasting));

                        double newImplementNorthing;
                        double newImplementEasting;

                        if (dist != 0)
                        {
                            t = vehicle.toolForeAft / dist;
                            newImplementNorthing = pn.northing + t * (pn.northing - prevImplementNorthing);
                            newImplementEasting = pn.easting + t * (pn.easting - prevImplementEasting);
                            fixHeadingSection = Math.Atan2(pn.easting - newImplementEasting, pn.northing - newImplementNorthing);
                        } else {
                            // The new tractor position is exactly the same as the old
                            // implement position, so push the implement straight back.
                            fixHeadingSection = prevFixHeadingSection;
                            newImplementEasting = pn.easting - Math.Sin(fixHeadingSection) * vehicle.toolForeAft;
                            newImplementNorthing = pn.northing - Math.Cos(fixHeadingSection) * vehicle.toolForeAft;
                        }

                        //System.Console.Write(" {0:N} ", (fixHeadingSection * 180 / Math.PI + 360) % 360);

                        // calculate speed of implement, which will vary from tractor speed
                        // as it's turning.
                        dist = Math.Sqrt( (pn.northing - prevNorthing[0]) * (pn.northing - prevNorthing[0]) +
                                          (pn.easting - prevEasting[0]) * (pn.easting - prevEasting[0]) );
                        if (dist != 0) {
                            dist = Math.Sqrt( (newImplementNorthing - prevImplementNorthing) * (newImplementNorthing - prevImplementNorthing) +
                                              (newImplementEasting - prevImplementEasting) * (newImplementEasting - prevImplementEasting) ) /
                                              dist; //ratio of implement movement to tractor movement

                            // overwrite the GPS speed with the estimated implement speed
                            pn.speed = dist * pn.speed;
                        }
                        
                        prevImplementNorthing = newImplementNorthing;
                        prevImplementEasting = newImplementEasting;

                    } else fixHeadingSection = fixHeading;

                    // calculate yaw rate in radians/second
                    double newYawRate = fixHeadingSection - prevFixHeadingSection;
                    
                    //Account for crossing 360/0.  
                    if (newYawRate < -Math.PI) 
                        newYawRate += Math.PI * 2;
                    else if (newYawRate > Math.PI)
                        newYawRate -= 2 * Math.PI;

                    newYawRate *= rmcUpdateHz;

                    double yawAccel = newYawRate - yawRate;

                    yawRate = newYawRate;
                    //System.Console.Write("{0:N2},", newYawRate * 180 / Math.PI);
                    //System.Console.Write("{0:N2} ", yawAccel * 180 / Math.PI);
                    
                    prevFixHeadingSection = fixHeadingSection;


                    //in degrees for glRotate opengl methods.
                    //fixHeadingCam = Math.Atan2(pn.easting - prevEasting[1], pn.northing - prevNorthing[1]);
                    //fixHeadingCam = (fixHeadingCam * 180.0 / Math.PI + 360) % 360;

                    //use NMEA headings for camera and tractor graphic
                    fixHeadingCam = pn.headingTrue;
                    fixHeading = pn.headingTrue * Math.PI / 180.0;


                    //check to make sure the grid is big enough
                    worldGrid.checkZoomWorldGrid(pn.northing, pn.easting);

                    //precalc the sin and cos of heading * -1
                    sinHeading = Math.Sin(-fixHeadingSection);
                    cosHeading = Math.Cos(-fixHeadingSection);

                    //calc distance travelled since last GPS fix
                    distance = pn.Distance(pn.northing, pn.easting, prevNorthing[0], prevEasting[0]);

                    //calculate how far since the last section triangle was made
                    currentSectionNorthing = pn.northing + vehicle.toolForeAft * cosHeading;
                    currentSectionEasting = pn.easting + vehicle.toolForeAft * -sinHeading;

                    //To prevent drawing high numbers of triangles, determine and test before drawing vertex
                    sectionTriggerDistance = pn.Distance(currentSectionNorthing, currentSectionEasting, prevSectionNorthing, prevSectionEasting);

                    //speed compensated min length limit triangles. The faster you go, the less of them
                    if (sectionTriggerDistance > (pn.speed / 7 + 0.3))
                    {
                        if (isJobStarted && isMasterSectionOn)//add the pathpoint
                        {
                            //save the north & east as previous
                            prevSectionNorthing = currentSectionNorthing;
                            prevSectionEasting = currentSectionEasting;

                            //send the current and previous GPS fore/aft corrected fix to each section
                            for (int j = 0; j < vehicle.numberOfSections; j++)
                            {
                                if (section[j].isSectionOn)
                                {
                                    section[j].AddPathPoint(currentSectionNorthing, currentSectionEasting, cosHeading, sinHeading);
                                    totalSquareMeters += sectionTriggerDistance * section[j].sectionWidth;
                                }//area is made up of square meters in each section
                            }
                        }
                    }

                    totalDistance += distance; //distance tally                   
                    userDistance += distance;//userDistance can be reset

                    //save a copy of previous positions for cam heading of desired filtering or delay
                    for (int x = numPrevs - 1; x > 0; x--)
                    {
                        prevNorthing[x] = prevNorthing[x - 1]; prevEasting[x] = prevEasting[x - 1];
                    }

                    //most recent fixes
                    prevEasting[0] = pn.easting;
                    prevNorthing[0] = pn.northing;
                    prevFixHeading = fixHeading;
                } else {
                    yawRate = 0;
                }
                //openGLControl.DoRender();
            }

            else if (recvCounter > 16) textBoxRcv.Text = "************  NO GGA or RMC **************";


        }//end of UppdateFixPosition

        //Send relay info out to relay board
        private void SectionControlOutToArduino()
        {
            if (!spArduino.IsOpen) return;

            byte set = 1;
            byte reset = 254;
            bufferArd[0] = 0;

            for (int j = 0; j < MAXSECTIONS; j++)
            {
                if (section[j].isSectionOn) bufferArd[0] = (byte)(bufferArd[0] | set);
                else bufferArd[0] = (byte)(bufferArd[0] & reset);

                set = (byte)(set << 1);

                reset = (byte)(reset << 1);
                reset = (byte)(reset + 1);
            }

            //Tell Arduino to turn section on or off accordingly
            if (isMasterSectionOn & spArduino.IsOpen)
            {
                try { spArduino.Write(bufferArd, 0, 1); }
                catch (Exception) { SerialPortCloseArduino(); }
            }
            else
            {
                bufferArd[0] = 0;

                try { spArduino.Write(bufferArd, 0, 1); }
                catch (Exception)
                {
                    SerialPortCloseArduino();
                }
                return;
            }


        }

        //called by the delegate every time a chunk is rec'd
        private void SerialLineReceived(string sentence)
        {
            //spit it out no matter what it says
            recvSentence.Append(sentence);
            recvSentenceSettings = recvSentence.ToString();
            //textBoxRcv.Text = recvSentence.ToString(); 
            //textBoxRcv.Text = pn.theSent;
        }

        //Arduino port called by the delegate every time
        private void SerialLineReceivedArduino(string sentence)
        {
            //spit it out no matter what it says
            recvSentenceArduino.Append(sentence);
            recvSentenceSettingsArduino = sentence;

            if (txtBoxRecvArduino.TextLength > 10) txtBoxRecvArduino.Text = "";
            txtBoxRecvArduino.Text += recvSentenceArduino;

        }

        #region ArduinoSerialPort //--------------------------------------------------------------------

        //the delegate for thread
        private delegate void LineReceivedEventHandlerArduino(string sentence);

        //Arduino serial port receive in its own thread
        private void sp_DataReceivedArduino(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (spArduino.IsOpen)
            {
                try
                {
                    System.Threading.Thread.Sleep(100);
                    string sentence = spArduino.ReadExisting();
                    this.BeginInvoke(new LineReceivedEventHandlerArduino(SerialLineReceivedArduino), sentence);
                }
                //this is bad programming, it just ignores errors until its hooked up again.
                catch (Exception) { }

            }
        }

        //open the Arduino serial port
        public void SerialPortOpenArduino()
        {
            if (!spArduino.IsOpen)
            {
                spArduino.PortName = portNameArduino;
                spArduino.BaudRate = baudRateArduino;
                spArduino.DataReceived += sp_DataReceivedArduino;
            }

            try { spArduino.Open(); }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message + "\n\r" + "\n\r" + "Go to Settings -> COM Ports to Fix", "No Arduino Port Active");

                //update port status label
                stripPortArduino.Text = "* *";
                stripOnlineArduino.Value = 1;
                stripPortArduino.ForeColor = Color.Red;

                Properties.Settings.Default.setPort_wasArduinoConnected = false;
                Properties.Settings.Default.Save();
            }

            if (spArduino.IsOpen)
            {
                spArduino.DiscardOutBuffer();
                spArduino.DiscardInBuffer();

                //update port status label
                stripPortArduino.Text = portNameArduino;
                stripPortArduino.ForeColor = Color.ForestGreen;
                stripOnlineArduino.Value = 100;


                Properties.Settings.Default.setPort_portNameArduino = portNameArduino;
                Properties.Settings.Default.setPort_wasArduinoConnected = true;
                Properties.Settings.Default.Save();
            }
        }

        public void SerialPortCloseArduino()
        {
            if (spArduino.IsOpen)
            {
                spArduino.DataReceived -= sp_DataReceivedArduino;
                try { spArduino.Close(); }
                catch (Exception exc) { MessageBox.Show(exc.Message, "Connection already terminated??"); }

                //update port status label
                stripPortArduino.Text = "* *";
                stripOnlineArduino.Value = 1;
                stripPortArduino.ForeColor = Color.Red;

                Properties.Settings.Default.setPort_wasArduinoConnected = false;
                Properties.Settings.Default.Save();

                spArduino.Dispose();
            }

        }
        #endregion


        #region GPS SerialPort //--------------------------------------------------------------------------

        private delegate void LineReceivedEventHandler(string sentence);

        //serial port receive in its own thread
        private void sp_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (sp.IsOpen)
            {
                try
                {
                    //give it a sec to spit it out
                    System.Threading.Thread.Sleep(50);

                    //read whatever is in port
                    string sentence = sp.ReadExisting();
                    this.BeginInvoke(new LineReceivedEventHandler(SerialLineReceived), sentence);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message + "\n\r" + "\n\r" + "Go to Settings -> COM Ports to Fix", "Screwed!");
                }

            }

        }

        //Event Handlers
        //private void btnExit_Click(object sender, EventArgs e) { this.Exit(); }


        public void SerialPortOpenGPS()
        {
            //close it first
            SerialPortCloseGPS();

            if (!sp.IsOpen)
            {
                sp.PortName = portName;
                sp.BaudRate = baudRate;
                sp.DataReceived += sp_DataReceived;
                sp.WriteTimeout = 1000;
            }

            try { sp.Open(); }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message + "\n\r" + "\n\r" + "Go to Settings -> COM Ports to Fix", "No Serial Port Active");

                //update port status labels
                stripPortGPS.Text = " * * ";
                stripPortGPS.ForeColor = Color.Red;
                stripOnlineGPS.Value = 1;

                //SettingsPageOpen(0);
            }

            if (sp.IsOpen)
            {
                //btnOpenSerial.Enabled = false;

                //discard any stuff in the buffers
                sp.DiscardOutBuffer();
                sp.DiscardInBuffer();

                //update port status label
                stripPortGPS.Text = portName + " " + baudRate.ToString();
                stripPortGPS.ForeColor = Color.ForestGreen;

                Properties.Settings.Default.setPort_portName = portName;
                Properties.Settings.Default.setPort_baudRate = baudRate;
                Properties.Settings.Default.Save();
            }
        }

        public void SerialPortCloseGPS()
        {
            //if (sp.IsOpen)
            {
                sp.DataReceived -= sp_DataReceived;
                try { sp.Close(); }
                catch (Exception exc) { MessageBox.Show(exc.Message, "Connection already terminated?"); }

                //update port status labels
                stripPortGPS.Text = " * * " + baudRate.ToString();
                stripPortGPS.ForeColor = Color.ForestGreen;
                stripOnlineGPS.Value = 1;

                sp.Dispose();
            }

        }

        #endregion SerialPortGPS

    }//end class
}//end namespace

//if (prevImplementNorthing == 0 && prevImplementEasting == 0)
//{
//    //No previous location known; assume it's straight back from the tractor
//    fixHeadingSection = fixHeading;
//    prevImplementEasting = pn.easting - Math.Sin(fixHeadingSection) * vehicle.toolForeAft;
//    prevImplementNorthing = pn.northing - Math.Cos(fixHeadingSection) * vehicle.toolForeAft;
//    //System.Console.WriteLine("Initialized to starting position.");

//}
//else
//{
//if (Math.Abs(pn.northing - prevImplementNorthing) < 0.000009 &&
//    Math.Abs(pn.easting - prevImplementEasting) < 0.0000009)
//{
//    // The new tractor position is exactly the same as the old
//    // implement position, so push the implement straight back.
//    fixHeadingSection = prevFixHeadingSection;
//    prevImplementEasting = pn.easting - Math.Sin(fixHeadingSection) * vehicle.toolForeAft;
//    prevImplementNorthing = pn.northing - Math.Cos(fixHeadingSection) * vehicle.toolForeAft;
//    //System.Console.WriteLine("Tractor moved to where implement was; pushing implement back.");
//}
//else


// Because this approximation over-estimates, break the change in tractor
// position into several sub-steps and do this approximation for each
// step.

//double in_temp = prevImplementNorthing;
//double ie_temp = prevImplementEasting;
//double n_step = (pn.northing - prevNorthing[1]) / TURN_STEPS;
//double e_step = (pn.easting - prevEasting[1]) / TURN_STEPS;
//double tn_temp = prevNorthing[1];
//double te_temp = prevEasting[1];

//double t;


//    //Break the tractor movement up into little steps and move
//    //apply the approximation to each step.
//    tn_temp += n_step;
//    te_temp += e_step;
//    t = vehicle.toolForeAft / Math.Sqrt((tn_temp - in_temp) * (tn_temp - in_temp) +
//                                         (te_temp - ie_temp) * (te_temp - ie_temp));
//    in_temp = tn_temp + t * (tn_temp - in_temp);
//    ie_temp = te_temp + t * (te_temp - ie_temp);


////Now we are in the new position and the last approximation is the 
////new position of the implement.
//prevImplementNorthing = in_temp;
//prevImplementEasting = ie_temp;


//}
/*
System.Console.Write("Tractor heading is ");
System.Console.Write((fixHeading * 180.0 / Math.PI + 360) % 360);
System.Console.Write(" and implement heading is ");
System.Console.WriteLine((fixHeadingSection * 180.0 / Math.PI + 360) % 360);
*/
