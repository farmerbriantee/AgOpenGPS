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
        public static SoundPlayer sndBoundaryAlarm, sndAutoSteerOn, sndAutoSteerOff, sndHydLiftUp, sndHydLiftDn;
        public bool isBoundAlarming;

        public bool isSteerSoundOn, isTurnSoundOn, isHydLiftSoundOn;

        public bool isHydLiftChange;

        public CSound()
        {
            sndBoundaryAlarm = new SoundPlayer(Properties.Resources.Alarm10);
            sndAutoSteerOn = new SoundPlayer(Properties.Resources.SteerOn);
            sndAutoSteerOff = new SoundPlayer(Properties.Resources.SteerOff);
            sndHydLiftUp = new SoundPlayer(Properties.Resources.HydUp);
            sndHydLiftDn = new SoundPlayer(Properties.Resources.HydDown);


            isSteerSoundOn = Properties.Settings.Default.setSound_isAutoSteerOn;
            isHydLiftSoundOn = Properties.Settings.Default.setSound_isHydLiftOn;
            isTurnSoundOn = Properties.Settings.Default.setSound_isUturnOn;
        }
    }
}
