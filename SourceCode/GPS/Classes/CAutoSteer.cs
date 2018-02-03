using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgOpenGPS
{
    public class CAutoSteer
    {
        private readonly FormGPS mf;

        //flag for free drive window to control autosteer
        public bool isInFreeDriveMode;

        //constructor
        public CAutoSteer(FormGPS _f)
        {
            mf = _f;
            isInFreeDriveMode = false;
        }



    }
}
