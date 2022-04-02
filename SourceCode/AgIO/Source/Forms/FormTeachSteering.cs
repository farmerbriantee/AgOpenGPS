using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgIO.Forms
{
    public partial class FormTeachSteering : Form
    {
        //class variables
        private readonly FormLoop mf = null;

        private int TState = 0;     // state of teaching process
        int WASStraight, maxWAS, minWAS;
        double maxN, maxE, maxS, maxW, myTurnAngle, myMaxAngleLeft = 0, myMaxAngleRight = 0, lastHeading;
        bool WASinverted = false;

        private void hsbarAckerman_HelpRequested(object sender, HelpEventArgs hlpevent)
        {

        }

        private void hsbarMaxSteerAngle_ValueChanged(object sender, EventArgs e)
        {

        }

        private void hsbarMaxSteerAngle_HelpRequested(object sender, HelpEventArgs hlpevent)
        {

        }

        private void btnVideoHelp_Click(object sender, EventArgs e)
        {

        }

        private void btnZeroWAS_HelpRequested(object sender, HelpEventArgs hlpevent)
        {

        }

        private void btnZeroWAS_Click(object sender, EventArgs e)
        {

        }

        private void hsbarCountsPerDegree_ValueChanged(object sender, EventArgs e)
        {

        }

        private void hsbarCountsPerDegree_HelpRequested(object sender, HelpEventArgs hlpevent)
        {

        }

        private void hsbarSteerAngleSensorZero_ValueChanged(object sender, EventArgs e)
        {

        }

        private void hsbarWasOffset_HelpRequested(object sender, HelpEventArgs hlpevent)
        {

        }

        private void hsbarAckerman_ValueChanged(object sender, EventArgs e)
        {

        }

        static double distanceDeg = 40080000 / 360;  // circumference of the earth in [m] / 360°
        int myGPS = 2;

       //constructor
        public FormTeachSteering(Form callingForm)
        {
            mf = callingForm as FormLoop; 
            InitializeComponent();
            
            WASStraight = mf.rawWAS;                        // set actual value as straitforward value
            lblATSZero.Text = WASStraight.ToString();   
        }

        private void trackCircle()
        {
            if (mf.latitude > maxN) maxN = mf.latitude;   // get the max. value in each cardinal direction
            if (mf.longitude > maxE) maxE = mf.longitude;
            if (mf.latitude < maxS) maxS = mf.latitude;
            if (mf.longitude < maxW) maxW = mf.longitude;
            if (mf.rawWAS < minWAS) minWAS = mf.rawWAS;
            if (mf.rawWAS > maxWAS) maxWAS = mf.rawWAS;
            double thisHeading = mf.headingTrueData[myGPS & 1];
            double headingDiff = thisHeading - lastHeading;
            if (headingDiff < -180) headingDiff += 360;
            if (headingDiff >  180) headingDiff -= 360;
            myTurnAngle += headingDiff;
            lastHeading = thisHeading;
            if (myTurnAngle < -20)
            {
                lblATSDoneLeft.Text = (-myTurnAngle / 3.8).ToString("N0");
                if (minWAS < WASStraight - 500)
                {
                    lblATSWASLeft.Text = minWAS.ToString();    // this "if" can be used to detect WAS inversion
                    WASinverted = false;
                    lblATSWASInverted.Text = "WAS not inverted.";
                }
                if (maxWAS > WASStraight + 500)
                {
                    lblATSWASLeft.Text = maxWAS.ToString();    // this "if" can be used to detect WAS inversion
                    WASinverted = true;
                    lblATSWASInverted.Text = "WAS inverted.";
                }
            }
            if (myTurnAngle > 20)
            {
                lblATSDoneRight.Text = (+myTurnAngle / 3.8).ToString("N0");
                if (minWAS < WASStraight - 500)
                {
                    lblATSWASRight.Text = minWAS.ToString();    // this "if" can be used to detect WAS inversion
                    WASinverted = true;
                    lblATSWASInverted.Text = "WAS inverted.";
                }
                if (maxWAS > WASStraight + 500)
                {
                    lblATSWASRight.Text = maxWAS.ToString();    // this "if" can be used to detect WAS inversion
                    WASinverted = false;
                    lblATSWASInverted.Text = "WAS not inverted.";
                }
            }
        }

        private void timerATS_Tick(object sender, EventArgs e)  // this is the core of the self-learing function for the steer parameters
        {
            if ((mf.spGPS.IsOpen || mf.spGPS2.IsOpen) && mf.spModule1.IsOpen)
            {
                lblATSWAS.Text = mf.headingTrueData[myGPS & 1].ToString();

                if (TState == 0 && (mf.spGPS.IsOpen  && mf.speedData[0] > 3) || (mf.spGPS2.IsOpen && mf.speedData[1] > 3))   // wait for speed > recording limit
                {
                    myTurnAngle = 0;
                    maxN = mf.latitude;   // init recordings
                    maxE = mf.longitude;
                    maxS = mf.latitude;
                    maxW = mf.longitude;
                    maxWAS = mf.rawWAS;                        
                    minWAS = mf.rawWAS;
                    myGPS = 2;                                    // just take one GPS heading for detecting the circle 
                    if (mf.spGPS.IsOpen) myGPS = 0;
                    if (mf.spGPS2.IsOpen) myGPS = 1;
                    if (myGPS != 2)
                    {
                        lastHeading = mf.headingTrueData[myGPS];
                        TState++;
                    }
                }
                if (TState == 1)  // wait right circle to be finished
                {
                    trackCircle();
                    if (myTurnAngle > 380 || myTurnAngle < -380)  // calculate angle
                    {
                        double diameterNS = Math.Abs(maxN - maxS) * distanceDeg;        // diameter of the circuit driven in north-south
                        double diameterWE = Math.Abs(maxE - maxW) * distanceDeg * Math.Cos(maxN * Math.PI / 180);  // .. in east-west
                        int distanceOfAxis = (int)nudAxisDist.Value;
                        double steeringAngle = Math.Asin(distanceOfAxis / (25 * (diameterNS + diameterWE))) * 180 / Math.PI;  // arcsin(axes/radius)
                        if (myTurnAngle < -20)
                        {
                            lblATSAngleLeft.Text = steeringAngle.ToString("N1");
                            myMaxAngleLeft = steeringAngle;
                        }
                        if (myTurnAngle > 20)
                        {
                            lblATSAngleRight.Text = steeringAngle.ToString("N1");
                            myMaxAngleRight = steeringAngle;
                        }
                        if (myMaxAngleRight != 0 && myMaxAngleLeft != 0)
                        {
                            lblATSMaxDeg.Text = Math.Min(myMaxAngleLeft, myMaxAngleRight).ToString("N1");
                            if (WASinverted)
                            {
                                lblATSAckermann.Text = (100 * (minWAS - WASStraight) / (maxWAS - WASStraight)).ToString();
                                lblATSDigPerDeg.Text = ((minWAS - WASStraight) / myMaxAngleRight).ToString();
                            }
                            else
                            {
                                lblATSAckermann.Text = (100 * (maxWAS - WASStraight) / (minWAS - WASStraight)).ToString();
                                lblATSDigPerDeg.Text = ((maxWAS - WASStraight) / myMaxAngleRight).ToString();
                            }
                        }
                        TState++;
                        //mf.TimedMessageBox(4000, "Well done! Diameters N-S and W-E", "N-S = " + diameterNS + "m, W-E = " + diameterWE + "m");
                    }
                }
                if (TState == 2 && (mf.spGPS.IsOpen && mf.speedData[0]  < 1)  || (mf.spGPS2.IsOpen && mf.speedData[1] < 1))    TState = 0;  // wait for speed < 1km/h to restart
            }
        }

        private void btnATSOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
