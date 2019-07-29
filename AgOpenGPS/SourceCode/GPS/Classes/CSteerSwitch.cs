namespace AgOpenGPS
{
    public class CSteerSwitch
    {
        private readonly FormGPS mf;
        public CSteerSwitch(FormGPS _f) { mf = _f; }

        private int _steerSwitchValue;
        private int CurrentSteerSwitchValue
        {
            get => _steerSwitchValue;
            set
            {
                //compares the last recorded value to the current switch value
                if (_steerSwitchValue != value)
                {
                    //records and toggles if requiried
                    _steerSwitchValue = value;
                    SteerSwitchToggle();
                }
            }
        }

        //Record of the required value based on switch type
        //private int steerTriggerValue0, steerTriggerValue2, previousSwitchValue = 0;
        private int steerTriggerValue;

        //Called from "OpenGL.Designer.cs" when requied
        public void CheckSteerSwitch()
        {
            //Checks the type of steerswitch -> records the trigger value
            if (mf.mc.isSteerSwitchActiveLow == true) { steerTriggerValue = 2; }
            else if (mf.mc.isSteerSwitchActiveLow == false) { steerTriggerValue = 1; }
            //Checks if swtich state has changed -> calls "set" accessor of "CurrentSwitchValue"
            CurrentSteerSwitchValue = mf.mc.steerSwitchValue;
        }
        //Toggles the switch if state has changed
        void SteerSwitchToggle()
        {
            if (CurrentSteerSwitchValue == steerTriggerValue)
            {
                //Checks current state of on-screen button -> "clicks" if required
                if (mf.btnAutoSteerState != FormGPS.btnSteerStates.On)
                {
                    mf.btnAutoSteer.PerformClick();
                }
            }
            else
            {
                if (mf.btnAutoSteerState != FormGPS.btnSteerStates.On)
                {
                    mf.btnAutoSteer.PerformClick();
                }
            }

        }
    }
}
