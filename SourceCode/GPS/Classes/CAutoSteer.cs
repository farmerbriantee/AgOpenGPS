namespace AgOpenGPS
{
    public class CAutoSteer
    {
        //private readonly FormGPS mf;

        //flag for free drive window to control autosteer
        public bool isInFreeDriveMode;

        //the trackbar angle for free drive
        public double driveFreeSteerAngle = 0;

        public double modeXTE, modeMultiplier, modeMultiplierStanley, modeActualXTE = 0, modeActualHeadingError = 0;
        public int modeTime = 0;

        //constructor
        public CAutoSteer()
        {
            isInFreeDriveMode = false;
            modeXTE = Properties.Settings.Default.setAS_ModeXTE;
            modeMultiplier = Properties.Settings.Default.setAS_ModeMultiplier;
            modeMultiplierStanley = Properties.Settings.Default.setAS_ModeMultiplierStanley;
            modeTime = Properties.Settings.Default.setAS_ModeTime;
        }
    }
}