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
        public bool isHeadingFromAutoSteer, isHeadingFromBrick, isHeadingFromPAOGI, isHeadingFromExtUDP;

        public bool isRollFromAutoSteer, isRollFromBrick, isRollFromGPS, isRollFromExtUDP;

        //Roll and heading from the IMU
        public int correctionHeadingX16 = 9999, prevCorrectionHeadingX16 = 9999, rollX16 = 9999;

        //actual value in degrees* 16 to modify the imu*16 values
        public int rollZeroX16, pitchZeroX16;

        //is the auto steer in auto turn on mode or not
        public bool isAutoSteerAuto;

        //constructor
        public CAHRS(FormGPS _f)
        {
            mf = _f;

            //non GPS AHRS sensors
            isHeadingFromAutoSteer = Properties.Settings.Default.setIMU_isHeadingFromAutoSteer;
            isHeadingFromBrick = Properties.Settings.Default.setIMU_isHeadingFromBrick;
            isHeadingFromPAOGI = Properties.Settings.Default.setIMU_isHeadingFromPAOGI;
            isHeadingFromExtUDP = Properties.Settings.Default.setIMU_isHeadingFromExtUDP;

            isRollFromAutoSteer = Properties.Settings.Default.setIMU_isRollFromAutoSteer;
            isRollFromBrick = Properties.Settings.Default.setIMU_isRollFromBrick;
            isRollFromGPS = Properties.Settings.Default.setIMU_isRollFromGPS;
            isRollFromExtUDP = Properties.Settings.Default.setIMU_isRollFromExtUDP;

            rollZeroX16 = Properties.Settings.Default.setIMU_rollZeroX16;
            pitchZeroX16 = Properties.Settings.Default.setIMU_pitchZeroX16;

            isAutoSteerAuto = Properties.Settings.Default.setAS_isAutoSteerAutoOn;

            //usb IMU Tinker
            if (isHeadingFromBrick || isRollFromBrick)
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
                    imu.SetOrientationPeriod(100);

                    //set the mode with mag
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
            if (isHeadingFromBrick)
            {
                mf.ahrs.correctionHeadingX16 = heading;
            }

            if (isRollFromBrick) mf.ahrs.rollX16 = roll;
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