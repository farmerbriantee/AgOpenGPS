using Tinkerforge;

namespace AgOpenGPS
{
    public class CAHRS
    {
        private readonly FormGPS mf;

        /// <summary>
        /// The USB TinkerForge comm
        /// </summary>
        public readonly IPConnection ipcon;

        /// <summary>
        /// The Tinker IMU object
        /// </summary>
        public readonly BrickIMUV2 imu;

        public static string HOST = "localhost";
        public static int PORT = 4223;
        public static readonly string UID = Properties.Settings.Default.setIMU_UID; // "68wESU"; // Change XXYYZZ to the UID of your IMU Brick 2.0

        //flags for desired sources
        public bool isHeadingBNO, isHeadingBrick, isHeadingPAOGI, isRollDogs, isRollBrick, isRollPAOGI;

        //actual value in degrees* 16 to modify the imu*16 values
        public int rollZero, pitchZero;

        //constructor
        public CAHRS(FormGPS _f)
        {
            mf = _f;

            //non GPS AHRS sensors
            isHeadingBNO = Properties.Settings.Default.setIMU_isHeadingFromBNO;
            isHeadingBrick = Properties.Settings.Default.setIMU_isHeadingFromBrick;
            isHeadingPAOGI = Properties.Settings.Default.setIMU_isHeadingFromPAOGI;

            isRollDogs = Properties.Settings.Default.setIMU_isRollFromDogs;
            isRollBrick = Properties.Settings.Default.setIMU_isRollFromBrick;
            isRollPAOGI = Properties.Settings.Default.setIMU_isRollFromPAOGI;

            rollZero = Properties.Settings.Default.setIMU_rollZero;
            pitchZero = Properties.Settings.Default.setIMU_pitchZero;

            //usb IMU Tinker
            if (isHeadingBrick | isRollBrick)
            {
                ipcon = new IPConnection(); // Create IP connection
                imu = new BrickIMUV2(CAHRS.UID, ipcon); // Create device object

                try
                {
                    ipcon.Connect(HOST, PORT); // Connect to brickd - daemon
                                                           // Don't use device before ipcon is connected

                    // Register Orientation callback in AHRS class
                    imu.OrientationCallback += OrientCB;

                    // Set period for Orientation callback to 0.1s (100ms)
                    imu.SetOrientationPeriod(200);

                    //set the mode without mag
                    imu.SetSensorFusionMode(1);

                    imu.LedsOff();
                }
                catch
                {
                }
            }
        }

        //event for TinkerForge IMU
        public void OrientCB(BrickIMUV2 sender, short heading, short roll, short pitch)
        {
            if (isHeadingBrick)
            {
                mf.mc.prevGyroHeading = mf.mc.gyroHeading;
                mf.mc.gyroHeading = heading;
            }

            if (isRollBrick) mf.mc.rollRaw = roll;
        }
    }
}

////input to the Kalman
//rollK = roll;

////Kalman filter
//Pc = P + varProcess;
//G = Pc / (Pc + varRoll);
//P = (1 - G) * Pc;
//Xp = XeRoll;
//Zp = Xp;
//XeRoll = (G * (rollK - Zp)) + Xp;
////Kalman variables
//private double rollK = 0;
//private double Pc = 0.0;
//private double G = 0.0;
//private double P = 1.0;
//private double Xp = 0.0;
//private double Zp = 0.0;
//private double XeRoll = 0;
//private readonly double varRoll = 0.06; // variance, smaller, more faster filtering
//private readonly double varProcess = 0.02;