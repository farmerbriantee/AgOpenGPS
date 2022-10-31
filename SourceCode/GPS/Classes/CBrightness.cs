using System;
using System.Management;

public class WindowsSettingsBrightnessController
{
    public int Get()
    {
        try // this will fail if not a device with controllable brightness (eg, a desktop)
        {
            var mclass = new ManagementClass("WmiMonitorBrightness")
            {
                Scope = new ManagementScope(@"\\.\root\wmi")
            };
            var instances = mclass.GetInstances();
            foreach (ManagementObject instance in instances)
            {
                return (byte)instance.GetPropertyValue("CurrentBrightness");
            }
            return 0;

        } catch
        {
            return -1; // check this and disable the buttons if not available
        }
    }

    public void Set(int brightness)
    {
        try // and so will this
        {
            var mclass = new ManagementClass("WmiMonitorBrightnessMethods")
            {
                Scope = new ManagementScope(@"\\.\root\wmi")
            };
            var instances = mclass.GetInstances();
            var args = new object[] { 1, brightness };
            foreach (ManagementObject instance in instances)
            {
                instance.InvokeMethod("WmiSetBrightness", args);
            }

        } catch
        {
            // meh, don't care
        }
    }
}