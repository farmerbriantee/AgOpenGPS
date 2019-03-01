using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgOpenGPS
{
    public class CWorkSwitch
    {
        private readonly FormGPS mf;
        public CWorkSwitch(FormGPS _f) { mf = _f; }

        private int _switchValue;
        private int CurrentSwitchValue
        {
            get =>  _switchValue;
            set
            {
                //compares the last recorded value to the current switch value
                if (_switchValue != value)
                {
                    //records and toggles if requried
                    _switchValue = value;
                    WorkSwitchToggle();
                }
            }
        }

        //Record of the required value based on switch type
        private int triggerValue;

        //Called from "OpenGL.Designer.cs" when requied
        public void CheckWorkSwitch()
        {
            //Checks the type of workswitch -> records the trigger value
            if (mf.mc.isWorkSwitchActiveLow == true) { triggerValue = 0; }
            else if (mf.mc.isWorkSwitchActiveLow == false) { triggerValue = 1; }
            //Checks if swtich state has changed -> calls "set" accessor of "CurrentSwitchValue"
            CurrentSwitchValue = mf.mc.workSwitchValue;

        }
        //Toggles the switch if state has changed
        void WorkSwitchToggle()
        {
            if (CurrentSwitchValue == triggerValue)
            {
                //Checks current state of on-screen button -> "clicks" if required
                if (mf.autoBtnState != FormGPS.btnStates.Auto) { mf.btnSectionOffAutoOn.PerformClick(); }
            }
            else
            {
                if (mf.autoBtnState != FormGPS.btnStates.Off) { mf.btnSectionOffAutoOn.PerformClick(); }
            }
        }
    }
}
