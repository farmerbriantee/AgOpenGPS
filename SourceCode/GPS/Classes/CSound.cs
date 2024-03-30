using System.Media;

namespace AgOpenGPS
{
    public class CSound
    {
        //sound objects - wave files in resources
        public readonly SoundPlayer sndBoundaryAlarm = new SoundPlayer(Properties.Resources.Alarm10);
        public readonly SoundPlayer sndUTurnTooClose = new SoundPlayer(Properties.Resources.TF012);

        public readonly SoundPlayer sndAutoSteerOn = new SoundPlayer(Properties.Resources.SteerOn);
        public readonly SoundPlayer sndAutoSteerOff = new SoundPlayer(Properties.Resources.SteerOff);
        public readonly SoundPlayer sndHydLiftUp = new SoundPlayer(Properties.Resources.HydUp);
        public readonly SoundPlayer sndHydLiftDn = new SoundPlayer(Properties.Resources.HydDown);
        public readonly SoundPlayer sndRTKAlarm = new SoundPlayer(Properties.Resources.rtk_lost);
        public readonly SoundPlayer sndSectionOn = new SoundPlayer(Properties.Resources.SectionOn);
        public readonly SoundPlayer sndSectionOff = new SoundPlayer(Properties.Resources.SectionOff);

        public bool isBoundAlarming, isRTKAlarming;

        public bool isSteerSoundOn, isTurnSoundOn, isHydLiftSoundOn, isSectionsSoundOn;

        public bool isHydLiftChange;

        public CSound()
        {
            isSteerSoundOn = Properties.Settings.Default.setSound_isAutoSteerOn;
            isHydLiftSoundOn = Properties.Settings.Default.setSound_isHydLiftOn;
            isTurnSoundOn = Properties.Settings.Default.setSound_isUturnOn;
            isSectionsSoundOn = Properties.Settings.Default.setSound_isSectionsOn;
        }
    }
}