namespace AgOpenGPS
{
    public class CAutoSteer
    {
        private readonly FormGPS mf;

        //flag for free drive window to control autosteer
        public bool isInFreeDriveMode;

        //the trackbar angle for free drive
        public System.Int16 driveFreeSteerAngle = 0;

        //constructor
        public CAutoSteer(FormGPS _f)
        {
            mf = _f;
            isInFreeDriveMode = false;
        }
    }
}