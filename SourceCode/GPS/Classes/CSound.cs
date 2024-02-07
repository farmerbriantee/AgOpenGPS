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
        //sound objects - wave files in resources
        public readonly SoundPlayer sndBoundaryAlarm = new SoundPlayer(Properties.Resources.Alarm10);
        public readonly SoundPlayer sndAutoSteerOn = new SoundPlayer(Properties.Resources.SteerOn);
        public readonly SoundPlayer sndAutoSteerOff = new SoundPlayer(Properties.Resources.SteerOff);
        public readonly SoundPlayer sndHydLiftUp = new SoundPlayer(Properties.Resources.HydUp);
        public readonly SoundPlayer sndHydLiftDn = new SoundPlayer(Properties.Resources.HydDown);
        public readonly SoundPlayer sndRTKAlarm = new SoundPlayer(Properties.Resources.rtk_lost);

        public bool isBoundAlarming, isRTKAlarming;

        public bool isSteerSoundOn, isTurnSoundOn, isHydLiftSoundOn;

        public bool isHydLiftChange;

        public CSound()
        {
            isSteerSoundOn = Properties.Settings.Default.setSound_isAutoSteerOn;
            isHydLiftSoundOn = Properties.Settings.Default.setSound_isHydLiftOn;
            isTurnSoundOn = Properties.Settings.Default.setSound_isUturnOn;
        }
    }
}
