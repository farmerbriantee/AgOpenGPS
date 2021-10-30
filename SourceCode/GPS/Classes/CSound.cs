using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace AgOpenGPS
{
    public class CSound
    {
        public static SoundPlayer sndBoundaryAlarm, autoSteerOn, autoSteerOff;
        public bool isBoundAlarming;

        public CSound()
        {
            sndBoundaryAlarm = new SoundPlayer(Properties.Resources.Alarm10);
            autoSteerOn = new SoundPlayer(Properties.Resources.SteerOn);
            autoSteerOff = new SoundPlayer(Properties.Resources.SteerOff);
        }
    }
}
