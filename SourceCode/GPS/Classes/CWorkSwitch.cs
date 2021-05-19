using System;

namespace AgOpenGPS
{
    public class CWorkSwitch
    {
        private readonly FormGPS mf;

        public CWorkSwitch(FormGPS _f)
        {
            mf = _f;
        }

        //Stored copies of workswitch variables, used for comparisons
        private bool workSwitchActiveLow;

        private bool workSwitchManual;
        private int workSwitchValue;

        //Record of the required value based on switch type
        private int triggerValue;

        //Stored copies of on-screen button states (and the state required by the workswitch), used for comparisons
        private FormGPS.btnStates autoButtonState, manualButtonState, requiredButtonState;

        private readonly FormGPS.btnStates offButtonState = FormGPS.btnStates.Off;

        //Defined in "Configure" based on the variables of the workswitch
        private Action CheckAndToggleOn;

        //Called from "OpenGL.Designer.cs" when requied
        public void CheckWorkSwitch()
        {
            if (mf.mc.isSteerControlsManual) mf.mc.workSwitchValue = mf.mc.steerSwitchValue;

            if (workSwitchValue == mf.mc.workSwitchValue) return;

            workSwitchValue = mf.mc.workSwitchValue;

            if (workSwitchActiveLow != mf.mc.isWorkSwitchActiveLow) { workSwitchActiveLow = mf.mc.isWorkSwitchActiveLow; Configure(); }
            if (workSwitchManual != mf.mc.isWorkSwitchManual) { workSwitchManual = mf.mc.isWorkSwitchManual; Configure(); }

            //Forces configuration if it does not occur above
            if (CheckAndToggleOn == null) { Configure(); }

            //Keeps local copies of variables updated, important for correct comparison of button states
            if (autoButtonState != mf.autoBtnState) { autoButtonState = mf.autoBtnState; }
            if (manualButtonState != mf.manualBtnState) { manualButtonState = mf.manualBtnState; }

            if (workSwitchValue == triggerValue) { CheckAndToggleOn(); }
            else
            {
                //Checks both on-screen buttons, performs click if button is not off
                if (autoButtonState != offButtonState) { mf.btnSectionOffAutoOn.PerformClick(); }
                if (manualButtonState != offButtonState) { mf.btnManualOffOn.PerformClick(); }
            }
        }

        //Assigns variables based on workswitch settings
        private void Configure()
        {
            if (workSwitchActiveLow == true) { triggerValue = 0; }
            else { triggerValue = 1; }

            if (workSwitchManual == false)
            {
                requiredButtonState = FormGPS.btnStates.Auto;
                CheckAndToggleOn = CheckAutoButtonAndClickOn;
            }
            else
            {
                requiredButtonState = FormGPS.btnStates.On;
                CheckAndToggleOn = CheckManualButtonAndClickOn;
            }
        }

        //Predefined functions, chosen based on workswitch settings
        private void CheckAutoButtonAndClickOn()
        {
            if (autoButtonState != requiredButtonState)
            {
                mf.btnSectionOffAutoOn.PerformClick();
            }
        }

        private void CheckManualButtonAndClickOn()
        {
            if (manualButtonState != requiredButtonState)
            {
                mf.btnManualOffOn.PerformClick();
            }
        }
    }
}